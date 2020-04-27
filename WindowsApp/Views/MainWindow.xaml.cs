using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using WindowsApp.Extensions;
using WindowsApp.Services;
using Core.Data;
using Core.Models.Ciphers;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using MorseGenerator;

namespace WindowsApp.Views
{
    public partial class MainWindow
    {
        private CipherBase _selectedCipher;
        private bool _isFilled = true;

        private static readonly Dictionary<char, char> Shapes = new Dictionary<char, char>
        {
            { '◼', '◻' },
            { '▲', '△' },
            { '▼', '▽' },
            { '◀', '◁' },
            { '▶', '▷' },
            { '◢', '◿' },
            { '◣', '◺' },
            { '◥', '◹' },
            { '◤', '◸' },
        };

        private static readonly List<char> SolidShapes   = new List<char>(Shapes.Keys);
        private static readonly List<char> OutlineShapes = new List<char>(Shapes.Values);


        private string CharsDelimiter => CharsDelimiterTextBox.Text;

        private string WordsDelimiter => WordsDelimiterTextBox.Text;


        public MainWindow()
        {
            InitializeComponent();
            SubscribeToRealtimeEvent();

            // Initialize NewCipherDialog
            NewCipherDialog.Context = this;

            // Initialize messageQueue and Assign it to Snack bar's MessageQueue
            var messageQueue      = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
            Snackbar.MessageQueue = messageQueue;

            // Initialize ComboBoxes
            CiphersComboBox.ItemsSource         = CiphersList.Instance;
            CiphersComboBox.SelectedIndex       = 0;
            CiphersComboBox.DisplayMemberPath   = nameof(CipherBase.Name);
            StandardsComboBox.DisplayMemberPath = nameof(CipherStandard.Name);
        }

        //// Input Event Handlers ////

        private void CiphersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher = (CipherBase) CiphersComboBox.SelectedItem;

            // Standards
            if (_selectedCipher is MultiStandardCipher c)
                ConfigureComboBox(StandardsComboBox, true, c.Standards);
            else
                ConfigureComboBox(StandardsComboBox, false);

            // Keys
            ConfigureComboBox(KeysComboBox, _selectedCipher.Key.IsEnabled, _selectedCipher.KeysList);

            // Configure Keys
            ToggleFillButton  .IsEnabled = _selectedCipher.Type == CipherType.Geometric;
            ExportAudioButton .IsEnabled = _selectedCipher.Type == CipherType.Audible;
            AudioSpeedComboBox.IsEnabled = _selectedCipher.Type == CipherType.Audible;
        }

        private void ConfigureComboBox(Selector comboBox, bool state, IEnumerable items = null)
        {
            comboBox.IsEnabled = state;

            if (state)
            {
                comboBox.ItemsSource   = items;
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.ItemsSource   = null;
                comboBox.SelectedIndex = -1;
            }
        }

        private void DetailsButton_OnClick(object sender, RoutedEventArgs e)
        {
            CipherDetailsDialog.CipherNameTextBlock.Text = _selectedCipher.Name;
            CipherDetailsDialog.CipherSchemaTextBox.Text = _selectedCipher.GetSchema();
        }

        // Real-time Encoding & Mirror Selection Modes

        private void SubscribeToRealtimeEvent()
        {
            var listeners = new List<Control>
            {
                InputRichTextBox, CharsDelimiterTextBox, WordsDelimiterTextBox,
                CiphersComboBox, StandardsComboBox, KeysComboBox
            };

            listeners.ForEach(c =>
            {
                if (c is TextBoxBase t) t.TextChanged += RealtimeEventHandler;
                else if (c is Selector s) s.SelectionChanged += RealtimeEventHandler;
            });
        }

        private void RealtimeEventHandler(object sender, RoutedEventArgs e)
        {
            // Cipher Config
            if (_selectedCipher is MultiStandardCipher c) c.StandardIndex = StandardsComboBox.SelectedIndex;
            _selectedCipher.Key.Base = _selectedCipher.Key.IsEnabled ? KeysComboBox.SelectedIndex : 0;

            // Encoding
            var text = InputRichTextBox.GetText();
            var encodedText = _selectedCipher.Encode(text, CharsDelimiter, WordsDelimiter);
            OutputRichTextBox.SetText(encodedText);
        }

        private void MirrorSelectionEventHandler(object sender, RoutedEventArgs e)
        {
            OutputRichTextBox.ClearFormatting();
            if (InputRichTextBox.Selection.IsEmpty || OutputRichTextBox.IsEmpty()) return;

            var inputStartPointer     = InputRichTextBox.GetStart();
            var outputStartPointer    = OutputRichTextBox.GetStart();

            var selectionStartPointer = InputRichTextBox.Selection.Start;
            var selectedText          = InputRichTextBox.Selection.Text;
            var precedingText         = new TextRange(inputStartPointer, selectionStartPointer).Text;
            var encodedSelectedText   = _selectedCipher.Encode(selectedText, CharsDelimiter, WordsDelimiter);
            var encodedPrecedingText  = _selectedCipher.Encode(precedingText, CharsDelimiter, WordsDelimiter);

            var highlightStartPointer = outputStartPointer.GetPositionAtOffset(encodedPrecedingText.Length + 2);
            var highlightEndPointer   = highlightStartPointer?.GetPositionAtOffset(encodedSelectedText.Length + 2) ?? OutputRichTextBox.GetEnd();
            var highlightTextRange    = new TextRange(highlightStartPointer, highlightEndPointer);

            highlightTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.CornflowerBlue);
        }


        //// Output Event Handlers & Properties ////

        private void ToggleFillButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isFilled) OutputRichTextBox.Replace(SolidShapes, OutlineShapes);
            else OutputRichTextBox.Replace(OutlineShapes, SolidShapes);
            _isFilled ^= true;
        }

        private void ExportAudioButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "MorseCode - " + AudioSpeedComboBox.Text,
                DefaultExt = ".wav",
                Filter = "Waveform Audio File|*.wav"
            };

            if (saveFileDialog.ShowDialog() != true) return;

            var text      = OutputRichTextBox.GetText();
            var speed     = AudioSpeedComboBox.SelectedIndex;
            var fileName  = saveFileDialog.FileName;
            
            MorseAudioGenerator.Generate(fileName, text, CharsDelimiter, WordsDelimiter, speed);

            var content = $"{saveFileDialog.SafeFileName} is Saved!";
            var arguments = $"/select, \"{fileName}\"";
            void Action() => Process.Start("explorer.exe", arguments);
            Snackbar.MessageQueue.Enqueue(content, "Open", Action);
        }
    }
}