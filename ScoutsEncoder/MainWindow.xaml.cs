using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Serialization;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Octokit;
using FileMode = System.IO.FileMode;

namespace ScoutsEncoder
{
    public partial class MainWindow : Window
    {
        private Cipher _selectedCipher;
        private FileStream _fileStream;

        private bool _isFilled = true;
        private bool _isLight  = true;

        private readonly CiphersList _ciphers            = new CiphersList();
        private readonly List<TextBox> _lettersTextBoxes = new List<TextBox>();
        private readonly XmlSerializer _xmlSerializer    = new XmlSerializer(typeof(Cipher));

        private const string GoogleDocsBase = "https://doc.new/";
        private const string GitHubBase     = "https://github.com/";
        private const string OwnerName      = "YoussefRaafatNasry";
        private const string OwnerEmail     = "YoussefRaafatNasry@gmail.com";
        private const string RepoName       = "ScoutsEncoder";

        private static readonly string SiteBase          = $"https://{OwnerName}.github.io/";
        private static readonly string RepoPath          = $"{RepoName}/";
        private static readonly string DocumentationPath = "docs/all/";
        private static readonly string ReportSubject     = Uri.EscapeUriString($"{RepoName} | Bug Report");
        

        public MainWindow()
        {
            InitializeComponent();

            // Initialize messageQueue and Assign it to Snackbar's MessageQueue
            var messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
            Snackbar.MessageQueue = messageQueue;

            // Check for updates
            CheckForUpdates();

            // Initialize CiphersComboBox
            CiphersComboBox.ItemsSource = _ciphers;
            CiphersComboBox.DisplayMemberPath = "DisplayName";

            // Initialize lettersTextBoxes (used while adding new ciphers)
            var dialogContent = NewCipherDialogHost.DialogContent as Grid;
            foreach (var stackPanel in dialogContent.Children.OfType<StackPanel>())
            {
                var children = stackPanel.Children;
                _lettersTextBoxes.AddRange(children.OfType<TextBox>());
            }

            // Clear initial block from RichTextBoxes
            InputRichTextBox.Clear();
            OutputRichTextBox.Clear();
        }

        public string CharsDelimiter
        {
            get
            {
                var count = CharSpacingCheckBox.IsChecked.Value ? 1 : 0;
                var spaces = new string(' ', count);
                return string.Format("{0}{1}{0}", spaces, CharsDelimiterTextBox.Text);
            }
        }

        public string WordsDelimiter
        {
            get
            {
                var count = WordSpacingCheckBox.IsChecked.Value ? 2 : 1;
                var spaces = new string(' ', count);
                return string.Format("{0}{1}{0}", spaces, WordsDelimiterTextBox.Text);
            }
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
            var isUpToDate = currentVersion.Equals(latestVersion);

            if (isUpToDate) return;
            var content = $"ScoutsEncoder {latest.TagName} is Now Available!";
            void Action() => Process.Start(latest.Assets[0].BrowserDownloadUrl);
            Snackbar.MessageQueue.Enqueue(content, "Download", Action);
        }


        //// Dialog Event Handlers ////

        private Cipher GetNewCipher()
        {
            return new Cipher
            {
                DisplayName = NewCipherNameTextBox.Text,
                Characters = _lettersTextBoxes.Select(t => t.Text).ToList()
            };
        }

        private void CloseDialog()
        {
            _lettersTextBoxes.ForEach(t => t.Clear());
            NewCipherNameTextBox.Clear();
            NewCipherDialogHost.IsOpen = false;
        }

        private void CloseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog();
        }

        private void AddCipherButton_Click(object sender, RoutedEventArgs e)
        {
            _ciphers.Add(GetNewCipher());
            CiphersComboBox.SelectedIndex = _ciphers.Count - 1;
            CloseDialog();
            Snackbar.MessageQueue.Enqueue("Cipher added");
        }

        private void SaveCipherButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = NewCipherNameTextBox.Text,
                DefaultExt = ".cipher.se",
                Filter = "SE Cipher File (.cipher.se)|*.cipher.se"
            };

            if (saveFileDialog.ShowDialog() != true) return;

            _fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            _xmlSerializer.Serialize(_fileStream, GetNewCipher());
            _fileStream.Close();
        }

        private void ImportCipherButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "SE Cipher File (.cipher.se)|*.cipher.se"
            };

            if (openFileDialog.ShowDialog() != true) return;

            _fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
            var newCipher = _xmlSerializer.Deserialize(_fileStream) as Cipher;
            _fileStream.Close();

            NewCipherNameTextBox.Text = newCipher.DisplayName;
            for (var i = 0; i < newCipher.Characters.Count; i++) _lettersTextBoxes[i].Text = newCipher.Characters[i];
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

            KeysComboBox.IsEnabled     = _selectedCipher.HasKeys || _selectedCipher.HasOverloads;
            KeysComboBox.ItemsSource   = _selectedCipher.KeysList;
            KeysComboBox.SelectedIndex = 0;

            EncodeButton               .IsEnabled = true;
            ShowKeyButton              .IsEnabled = true;
            RealTimeToggleButton       .IsEnabled = true;
            MirrorSelectionToggleButton.IsEnabled = true;
            ToggleFillButton           .IsEnabled = _selectedCipher.HasShapes;
            ExportAudioButton          .IsEnabled = _selectedCipher.IsAudible;
            AudioSpeedComboBox         .IsEnabled = _selectedCipher.IsAudible;

            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set Key to zero if KeysComboBox is empty
            // or while changing the KeysComboBox's ItemsSource,
            // instead of making Key = SelectedIndex = -1
            // which will cause an error while encoding
            _selectedCipher.Key = KeysComboBox.SelectedIndex == -1 ? 0 : KeysComboBox.SelectedIndex;

            RealtimeEventHandler(sender, e); // Real-time syncing 
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var keys = _selectedCipher.ShowKey();
            OutputRichTextBox.SetText(keys);
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            Encode();
        }

        private void Encode()
        {
            var text = InputRichTextBox.GetText();
            var encodedText = _selectedCipher.Encode(text, CharsDelimiter, WordsDelimiter);
            OutputRichTextBox.SetText(encodedText);
        }

        // Real-time Encoding & Mirror Selection Modes

        private void RealtimeEventHandler(object sender, RoutedEventArgs e)
        {
            if (!RealTimeToggleButton.IsChecked.Value) return;
            Encode();
        }

        private void MirrorSelectionToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            OutputRichTextBox.ClearHighlight();
        }

        private void InputRichTextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!MirrorSelectionToggleButton.IsChecked.Value) return;

            OutputRichTextBox.ClearHighlight();

            if (_selectedCipher == null || InputRichTextBox.Selection.IsEmpty || OutputRichTextBox.IsEmpty()) return;

            var inputStartPointer     = InputRichTextBox.GetStart();
            var outputStartPointer    = OutputRichTextBox.GetStart();

            var selectionStartPointer = InputRichTextBox.Selection.Start;
            var selectedText          = InputRichTextBox.Selection.Text;
            var precedingText         = new TextRange(inputStartPointer, selectionStartPointer).Text;
            var encodedSelectedText   = _selectedCipher.Encode(selectedText, CharsDelimiter, WordsDelimiter);
            var encodedPrecedingText  = _selectedCipher.Encode(precedingText, CharsDelimiter, WordsDelimiter);

            var highlightStartPointer = outputStartPointer.GetPositionAtOffset(encodedPrecedingText.Length);
            var highlightEndPointer   = highlightStartPointer?.GetPositionAtOffset(encodedSelectedText.Length + 2);
            var highlightTextRange    = new TextRange(highlightStartPointer, highlightEndPointer);

            highlightTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow);
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
            var filledShapes = new List<char> {'◼', '▲', '▼', '◀', '▶', '◢', '◣', '◥', '◤'};
            var strokedShapes = new List<char> {'◻', '△', '▽', '◁', '▷', '◿', '◺', '◹', '◸'};
            var param = _isFilled
                ? Tuple.Create(filledShapes, strokedShapes)
                : Tuple.Create(strokedShapes, filledShapes);
            OutputRichTextBox.Replace(param.Item1, param.Item2);
            _isFilled ^= true;
        }

        private void ExportAudioButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "MorseCode - " + AudioSpeedComboBox.Text,
                DefaultExt = ".wav",
                Filter = "Waveform Audio File (.wav)|*.wav"
            };

            if (saveFileDialog.ShowDialog() != true) return;

            var speed = AudioSpeedComboBox.SelectedIndex;
            var audioData = new MorseCodeGenerator(OutputRichTextBox.GetText(), CharsDelimiter, WordsDelimiter, speed);
            audioData.Save(saveFileDialog.FileName);

            var content = $"{saveFileDialog.SafeFileName} is Saved!";
            var arguments = $"/select, \"{saveFileDialog.FileName}\"";
            void Action() => Process.Start("explorer.exe", arguments);
            Snackbar.MessageQueue.Enqueue(content, "Open", Action);
        }


        //// Footer's Event Handlers ////

        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var mode = _isLight ? BaseTheme.Dark : BaseTheme.Light;
            ThemeAssist.SetTheme(this, mode);
            _isLight ^= true;
        }

        private Dictionary<string, string> _links = new Dictionary<string, string>()
        {
            { "Repo"          , $"{GitHubBase}{OwnerName}/{RepoName}"          },
            { "GoogleDocs"    , GoogleDocsBase                                 },
            { "Website"       , $"{SiteBase}{RepoPath}"                        },
            { "Documentation" , $"{SiteBase}{RepoPath}{DocumentationPath}"     },
            { "BugReport"     , $"mailto:{OwnerEmail}?subject={ReportSubject}" },
            { "Owner"         , SiteBase                                       }
        };

        private void Footer_Click(object sender, RoutedEventArgs e)
        {
            var key = sender is Control ? (sender as Control).Name : (sender as Hyperlink).Name;
            Process.Start(_links[key]);
        }

    }
}