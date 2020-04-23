using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Octokit;
using ScoutsEncoder.Data;
using ScoutsEncoder.Extensions;
using ScoutsEncoder.Models;
using ScoutsEncoder.Morse;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ScoutsEncoder.Views
{
    public partial class MainWindow
    {
        private Cipher _selectedCipher;
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
            CiphersComboBox.DisplayMemberPath   = nameof(Cipher.DisplayName);
            OverloadsComboBox.DisplayMemberPath = nameof(Cipher.DisplayName);

            // Initialize NewCipherDialog
            NewCipherDialog.Context = this;

            // Disable Actions
            EnableActions(false);

            // Clear initial block from RichTextBoxes
            InputRichTextBox.Clear();
            OutputRichTextBox.Clear();

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
            InputRichTextBox.CopyToClipboard();
            InputRichTextBox.Clear();
        }

        private void InputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            InputRichTextBox.CopyToClipboard();
        }

        private void InputPasteButton_Click(object sender, RoutedEventArgs e)
        {
            InputRichTextBox.AppendText(Clipboard.GetText());
        }

        private void InputClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputRichTextBox.Clear();
        }

        private void CiphersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher = (Cipher) CiphersComboBox.SelectedItem;

            OverloadsComboBox.IsEnabled     = _selectedCipher.HasOverloads;
            OverloadsComboBox.ItemsSource   = _selectedCipher.HasOverloads ? _selectedCipher.Overloads : new List<Cipher>();
            OverloadsComboBox.SelectedIndex = 0;
            _selectedCipher.OverloadKey     = 0;

            KeysComboBox.IsEnabled          = _selectedCipher.HasKeys;
            KeysComboBox.ItemsSource        = _selectedCipher.HasKeys ? _selectedCipher.KeysList : new List<string>();
            KeysComboBox.SelectedIndex      = 0;
            _selectedCipher.Key             = 0;

            ToggleFillButton.IsEnabled    = _selectedCipher.HasShapes;
            ExportAudioButton .IsEnabled    = _selectedCipher.IsAudible;
            AudioSpeedComboBox.IsEnabled    = _selectedCipher.IsAudible;

            RealtimeEventHandler(sender, e); // Real-time syncing 
            EnableActions(true);
        }

        private void OverloadsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher.OverloadKey = OverloadsComboBox.SelectedIndex;
            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher.Key = KeysComboBox.SelectedIndex;
            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var keys = _selectedCipher.GetKeysMapping();
            OutputRichTextBox.SetText(keys);
            _containKeys = true; // Used in mirror selection 
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            Encode();
            _containKeys = false; // Used in mirror selection
        }

        private void Encode()
        {
            var text = InputRichTextBox.GetText();
            var encodedText = _selectedCipher.Encode(text, CharsDelimiter, WordsDelimiter);
            OutputRichTextBox.SetText(encodedText);
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
            OutputRichTextBox.ClearFormatting();
        }

        private void InputRichTextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (MirrorToggleButton.IsChecked == false) return;

            OutputRichTextBox.ClearFormatting();
            if (InputRichTextBox.Selection.IsEmpty || OutputRichTextBox.IsEmpty() || _containKeys) return;

            var inputStartPointer     = InputRichTextBox.GetStart();
            var outputStartPointer    = OutputRichTextBox.GetStart();

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
            OutputRichTextBox.CopyToClipboard();
            OutputRichTextBox.Clear();
        }

        private void OutputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            OutputRichTextBox.CopyToClipboard();
        }

        private void OutputClearButton_Click(object sender, RoutedEventArgs e)
        {
            OutputRichTextBox.Clear();
        }

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


        //// Footer Event Handlers ////

        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var mode = _isLight ? BaseTheme.Dark : BaseTheme.Light;
            ThemeAssist.SetTheme(this, mode);
            _isLight ^= true;
            OutputRichTextBox.ClearFormatting();
        }

        private void Footer_Click(object sender, RoutedEventArgs e)
        {
            var key = ((FrameworkElement) sender).Name;
            Process.Start(Links[key]);
        }
    }
}