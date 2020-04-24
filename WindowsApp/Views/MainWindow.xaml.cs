﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using WindowsApp.Extensions;
using Core.Data;
using Core.Models.Ciphers;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using MorseGenerator;
using Octokit;

namespace WindowsApp.Views
{
    public partial class MainWindow
    {
        private CipherBase _selectedCipher;
        private bool _isFilled = true;
        private bool _isLight  = true;
        private bool _containKeys;

        private const string OwnerName      = "YoussefRaafatNasry";
        private const string OwnerEmail     = "YoussefRaafatNasry@gmail.com";
        private const string GoogleDocsBase = "https://doc.new/";
        private const string GitHubBase     = "https://github.com/";
        private const string SiteBase       = "https://" + OwnerName + ".github.io/";
        private const string RepoName       = "ScoutsEncoder";
        private const string RepoPath       = RepoName + "/";
        private const string DocsPath       = "docs";
        private const string ReportSubject  = RepoName + " | Bug Report";

        private static readonly Dictionary<string, string> Links = new Dictionary<string, string>
        {
            { "RepoButton"          , $"{GitHubBase}{OwnerName}/{RepoName}"                               },
            { "GoogleDocsButton"    , GoogleDocsBase                                                      },
            { "WebsiteButton"       , $"{SiteBase}{RepoPath}"                                             },
            { "DocumentationButton" , $"{SiteBase}{RepoPath}{DocsPath}"                                   },
            { "BugReportButton"     , $"mailto:{OwnerEmail}?subject={Uri.EscapeUriString(ReportSubject)}" },
            { "OwnerTextBlock"      , SiteBase                                                            }
        };

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

            // Initialize messageQueue and Assign it to Snack bar's MessageQueue
            var messageQueue      = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
            Snackbar.MessageQueue = messageQueue;

            // Initialize CiphersComboBox
            CiphersComboBox.ItemsSource         = CiphersList.Instance;
            CiphersComboBox.DisplayMemberPath   = nameof(CipherBase.Name);
            StandardsComboBox.DisplayMemberPath = nameof(CipherStandard.Name);

            // Initialize NewCipherDialog
            NewCipherDialog.Context = this;

            // Disable Actions
            EnableActions(false);

            // Clear initial block from RichTextBoxes
            RichTextBoxExtensions.Clear(InputRichTextBox);
            RichTextBoxExtensions.Clear(OutputRichTextBox);

            // Check for updates
            CheckForUpdates();
        }


        private void CheckForUpdates()
        {
            Release latest;

            try
            {
                var client = new GitHubClient(new ProductHeaderValue(RepoName));
                latest = client.Repository.Release.GetLatest(OwnerName, RepoName).Result;
            }
            catch (Exception)
            {
                return;
            }

            var currentVersion = Assembly.GetEntryAssembly()?.GetName().Version;
            var latestVersion = new Version(latest.TagName.Substring(1) + ".0");
            var isUpToDate = currentVersion != null && currentVersion.CompareTo(latestVersion) >= 0;

            if (isUpToDate) return;
            var content = $"{RepoName} {latest.TagName} is Now Available!";
            void Action() => Process.Start(latest.Assets[0].BrowserDownloadUrl);
            Snackbar.MessageQueue.Enqueue(content, "Download", Action);
        }


        //// Input Event Handlers ////

        private void InputCutButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.CopyToClipboard(InputRichTextBox);
            RichTextBoxExtensions.Clear(InputRichTextBox);
        }

        private void InputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.CopyToClipboard(InputRichTextBox);
        }

        private void InputPasteButton_Click(object sender, RoutedEventArgs e)
        {
            InputRichTextBox.AppendText(Clipboard.GetText());
        }

        private void InputClearButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.Clear(InputRichTextBox);
        }

        private void CiphersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher = (CipherBase) CiphersComboBox.SelectedItem;

            // Standards
            if (_selectedCipher is MultiStandardCipher c)
            {
                c.StandardIndex = 0;
                ConfigureComboBox(StandardsComboBox, true, c.Standards);
            }
            else
            {
                ConfigureComboBox(StandardsComboBox, false);
            }

            // Keys
            _selectedCipher.Key.Base = 0;
            ConfigureComboBox(KeysComboBox, _selectedCipher.Key.IsEnabled, _selectedCipher.KeysList);

            // Output
            ToggleFillButton  .IsEnabled = _selectedCipher.Type == CipherType.Geometric;
            ExportAudioButton .IsEnabled = _selectedCipher.Type == CipherType.Audible;
            AudioSpeedComboBox.IsEnabled = _selectedCipher.Type == CipherType.Audible;

            RealtimeEventHandler(sender, e); // Real-time syncing 
            EnableActions(true);
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

        private void StandardsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_selectedCipher is MultiStandardCipher c)
            {
                c.StandardIndex = StandardsComboBox.SelectedIndex;
            }
            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher.Key.Base = KeysComboBox.SelectedIndex;
            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var keys = _selectedCipher.GetSchema();
            RichTextBoxExtensions.SetText(OutputRichTextBox, keys);
            _containKeys = true; // Used in mirror selection 
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            Encode();
            _containKeys = false; // Used in mirror selection
        }

        private void Encode()
        {
            var text = RichTextBoxExtensions.GetText(InputRichTextBox);
            var encodedText = _selectedCipher.Encode(text, CharsDelimiter, WordsDelimiter);
            RichTextBoxExtensions.SetText(OutputRichTextBox, encodedText);
        }

        private void EnableActions(bool state)
        {
            ShowKeyButton       .IsEnabled = state;
            EncodeButton        .IsEnabled = state;
            RealTimeToggleButton.IsEnabled = state;
            MirrorToggleButton  .IsEnabled = state;
        }

        // Real-time Encoding & Mirror Selection Modes

        private void RealtimeEventHandler(object sender, RoutedEventArgs e)
        {
            if (RealTimeToggleButton.IsChecked == false) return;
            Encode();
        }

        private void MirrorSelectionToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.ClearFormatting(OutputRichTextBox);
        }

        private void InputRichTextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (MirrorToggleButton.IsChecked == false) return;

            RichTextBoxExtensions.ClearFormatting(OutputRichTextBox);
            if (InputRichTextBox.Selection.IsEmpty || RichTextBoxExtensions.IsEmpty(OutputRichTextBox) || _containKeys) return;

            var inputStartPointer     = RichTextBoxExtensions.GetStart(InputRichTextBox);
            var outputStartPointer    = RichTextBoxExtensions.GetStart(OutputRichTextBox);

            var selectionStartPointer = InputRichTextBox.Selection.Start;
            var selectedText          = InputRichTextBox.Selection.Text;
            var precedingText         = new TextRange(inputStartPointer, selectionStartPointer).Text;
            var encodedSelectedText   = _selectedCipher.Encode(selectedText, CharsDelimiter, WordsDelimiter);
            var encodedPrecedingText  = _selectedCipher.Encode(precedingText, CharsDelimiter, WordsDelimiter);

            var highlightStartPointer = outputStartPointer.GetPositionAtOffset(encodedPrecedingText.Length + 2);
            var highlightEndPointer   = highlightStartPointer?.GetPositionAtOffset(encodedSelectedText.Length + 2);
            var highlightTextRange    = new TextRange(highlightStartPointer, highlightEndPointer);

            var brush = _isLight ? Brushes.Yellow : Brushes.DarkMagenta;
            highlightTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, brush);
        }


        //// Output Event Handlers & Properties ////

        private void OutputCutButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.CopyToClipboard(OutputRichTextBox);
            RichTextBoxExtensions.Clear(OutputRichTextBox);
        }

        private void OutputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.CopyToClipboard(OutputRichTextBox);
        }

        private void OutputClearButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxExtensions.Clear(OutputRichTextBox);
        }

        private void ToggleFillButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isFilled) RichTextBoxExtensions.Replace(OutputRichTextBox, SolidShapes, OutlineShapes);
            else RichTextBoxExtensions.Replace(OutputRichTextBox, OutlineShapes, SolidShapes);
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

            var text      = RichTextBoxExtensions.GetText(OutputRichTextBox);
            var speed     = AudioSpeedComboBox.SelectedIndex;
            var fileName  = saveFileDialog.FileName;
            
            MorseAudioGenerator.Generate(fileName, text, CharsDelimiter, WordsDelimiter, speed);

            var content = $"{saveFileDialog.SafeFileName} is Saved!";
            var arguments = $"/select, \"{fileName}\"";
            void Action() => Process.Start("explorer.exe", arguments);
            Snackbar.MessageQueue.Enqueue(content, "Open", Action);
        }


        //// Footer Event Handlers ////

        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var mode = _isLight ? BaseTheme.Dark : BaseTheme.Light;
            ThemeAssist.SetTheme(this, mode);
            _isLight ^= true;
            RichTextBoxExtensions.ClearFormatting(OutputRichTextBox);
        }

        private void Footer_Click(object sender, RoutedEventArgs e)
        {
            var key = ((FrameworkElement) sender).Name;
            Process.Start(Links[key]);
        }
    }
}