using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;
using Application = System.Windows.Application;
using FileMode = System.IO.FileMode;

namespace ScoutsEncoder
{
    public partial class MainWindow : Window
    {

        private Cipher _selectedCipher;
        private CiphersList _ciphers = new CiphersList();

        private FileStream _fileStream;
        private readonly List<Control> _inputControls;
        private readonly List<TextBox> _lettersTextBoxes = new List<TextBox>();
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Cipher));
        
        private bool _isFilled = true;
        private bool _isLight = true;

        private const string GoogleDocsBase = "https://doc.new/";
        private const string GitHubBase = "https://github.com/";
        private const string OwnerName = "YoussefRaafatNasry";
        private const string OwnerEmail = "YoussefRaafatNasry@gmail.com";
        private const string RepoName = "ScoutsEncoder";

        private static readonly string SiteBase = $"https://{OwnerName}.github.io/";
        private static readonly string RepoPath = $"{RepoName}/";
        private static readonly string DocsPath = "docs/all/";
        private static readonly string ReportSubject = Uri.EscapeUriString($"{RepoName} | Bug Report");

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

            // Initialize inputControls (used in real-time encoding)
            _inputControls = new List<Control> {
                InputTextBox,
                CharsDelimiterTextBox,
                WordsDelimiterTextBox,
                CharSpacingCheckBox,
                CharSpacingCheckBox,
                WordSpacingCheckBox,
                WordSpacingCheckBox,
                CiphersComboBox,
                KeysComboBox
            };

            // Initialize lettersTextBoxes (used while adding new ciphers)
            var dialogContent = NewCipherDialogHost.DialogContent as Grid;
            foreach (var stackPanel in dialogContent.Children.OfType<StackPanel>())
            {
                var children = stackPanel.Children;
                _lettersTextBoxes.AddRange(children.OfType<TextBox>());
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
            for (var i = 0; i < newCipher.Characters.Count; i++)
            {
                _lettersTextBoxes[i].Text = newCipher.Characters[i];
            }
        }


        //// Input Event Handlers ////

        private void InputCutButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text != "") Clipboard.SetText(InputTextBox.Text);
            InputTextBox.Text = "";
        }

        private void InputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text != "") Clipboard.SetText(InputTextBox.Text);
        }

        private void InputPasteButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text += Clipboard.GetText();
        }

        private void InputClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "";
        }

        private void CiphersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCipher = (Cipher) CiphersComboBox.SelectedItem;

            KeysComboBox.IsEnabled     = _selectedCipher.HasKeys || _selectedCipher.HasOverloads;
            KeysComboBox.ItemsSource   = _selectedCipher.KeysList;
            KeysComboBox.SelectedIndex = 0;

            EncodeButton        .IsEnabled = true;
            ShowKeyButton       .IsEnabled = true;
            RealTimeToggleButton.IsEnabled = true;
            ToggleFillButton    .IsEnabled = _selectedCipher.HasShapes;
            ExportAudioButton   .IsEnabled = _selectedCipher.IsAudible;
            AudioSpeedComboBox  .IsEnabled = _selectedCipher.IsAudible;
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set Key to zero if KeysComboBox is empty
            // or while changing the KeysComboBox's ItemsSource,
            // instead of making Key = SelectedIndex = -1
            // which will cause an error while encoding
            _selectedCipher.Key = KeysComboBox.SelectedIndex == -1 ? 0 : KeysComboBox.SelectedIndex;
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = _selectedCipher.ShowKey();
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            Encode();
        }

        private void Encode()
        {
            OutputTextBox.Text = _selectedCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }


        // Real-time Encoding

        private void ChangeEvent(object sender, RoutedEventArgs e)
        {
            Encode();
        }

        private void RealTimeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Encode();

            RealTimeToggleButton.Foreground = new SolidColorBrush(Colors.White);

            UpdateEventHandlers(
                t => t.TextChanged += ChangeEvent,
                c => c.SelectionChanged += ChangeEvent,
                c =>
                {
                    c.Checked += ChangeEvent;
                    c.Unchecked += ChangeEvent;
                }
            );
        }

        private void RealTimeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Clear();

            if (_isLight) RealTimeToggleButton.Foreground = (Brush)Application.Current.Resources["MaterialDesignBody"];

            UpdateEventHandlers(
                t => t.TextChanged -= ChangeEvent,
                c => c.SelectionChanged -= ChangeEvent,
                c =>
                {
                    c.Checked -= ChangeEvent;
                    c.Unchecked -= ChangeEvent;
                }
            );
        }

        public void UpdateEventHandlers(Action<TextBox> a1, Action<ComboBox> a2, Action<CheckBox> a3)
        {
            foreach (var c in _inputControls)
            {
                switch (c)
                {
                    case TextBox textBox:
                        a1(textBox);
                        break;
                    case ComboBox comboBox:
                        a2(comboBox);
                        break;
                    case CheckBox checkBox:
                        a3(checkBox);
                        break;
                }
            }
        }


        //// Output Event Handlers & Properties ////

        private void OutputCutButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutputTextBox.Text != "") Clipboard.SetText(OutputTextBox.Text);
            OutputTextBox.Text = "";
        }

        private void OutputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutputTextBox.Text != "") Clipboard.SetText(OutputTextBox.Text);
        }

        private void OutputClearButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "";
        }

        private void ToggleFillButton_Click(object sender, RoutedEventArgs e)
        {
            char[] filledShapes  = {'◼', '▲', '▼', '◀', '▶', '◢', '◣', '◥', '◤'};
            char[] strokedShapes = {'◻', '△', '▽', '◁', '▷', '◿', '◺', '◹', '◸'};

            if (_isFilled)
            {
                _isFilled = false;
                for (var i = 0; i < filledShapes.Length; i++)
                    OutputTextBox.Text = OutputTextBox.Text.Replace(filledShapes[i], strokedShapes[i]);
            }
            else
            {
                _isFilled = true;
                for (var i = 0; i < filledShapes.Length; i++)
                    OutputTextBox.Text = OutputTextBox.Text.Replace(strokedShapes[i], filledShapes[i]);
            }
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

            // Process save file dialog box results
            var speed = AudioSpeedComboBox.SelectedIndex;
            var audioData = new MorseCodeGenerator(OutputTextBox.Text, CharsDelimiter, WordsDelimiter, speed);
            audioData.Save(saveFileDialog.FileName);
            Snackbar.MessageQueue.Enqueue("\"" + saveFileDialog.SafeFileName + "\"" + " Saved!");
        }


        //// Footer's Event Handlers ////

        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isLight)
            {
                _isLight = false;
                ThemeAssist.SetTheme(this, BaseTheme.Dark);
                RealTimeToggleButton.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                _isLight = true;
                ThemeAssist.SetTheme(this, BaseTheme.Light);
                if (!RealTimeToggleButton.IsChecked.Value)
                    RealTimeToggleButton.Foreground = (Brush) Application.Current.Resources["MaterialDesignBody"];
            }
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"{GitHubBase}{OwnerName}/{RepoName}");
        }

        private void GoogleDocsButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GoogleDocsBase);
        }

        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"{SiteBase}{RepoPath}");
        }

        private void ScoutsEncoderDocsButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"{SiteBase}{RepoPath}{DocsPath}");
        }

        private void BugReportButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"mailto:{OwnerEmail}?subject={ReportSubject}");
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(SiteBase);
        }
    }
}