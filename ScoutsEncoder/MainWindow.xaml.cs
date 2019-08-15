using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ScoutsEncoder
{
    public partial class MainWindow : Window
    {
        private List<Cipher> _ciphers = new List<Cipher>
        {
            new Cipher
            {
                DisplayName = "يسوع",
                HasKeys = true,
                Characters =
                {
                    "ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                    "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                    "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                    "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"
                }
            },

            new Cipher
            {
                DisplayName = "الرقمية",
                HasKeys = true,
                Characters =
                {
                    "١" , "٢" , "٣" , "٤" , "٥" , "٦" , "٧" ,
                    "٨" , "٩" , "١٠", "١١", "١٢", "١٣", "١٤",
                    "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                    "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"
                }
            },

            new Cipher
            {
                DisplayName = "الأعداد الثنائية",
                Characters =
                {
                    "00001", "00010", "00011", "00100", "00101", "00110", "00111",
                    "01000", "01001", "01010", "01011", "01100", "01101", "01110",
                    "01111", "10000", "10001", "10010", "10011", "10100", "10101",
                    "10110", "10111", "11000", "11001", "11010", "11011", "11100"
                }
            },

            new Cipher
            {
                DisplayName = "العكسية",
                HasKeys = true,
                Characters =
                {
                    "ي", "و", "ه", "ن", "م", "ل", "ك",
                    "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                    "ص", "ش", "س", "ز", "ر", "ذ", "د",
                    "خ", "ح", "ج", "ث", "ت", "ب", "ا"
                }
            },

            new Cipher
            {
                DisplayName = "قيصر",
                HasKeys = true,
                Characters =
                {
                    "ب", "ت", "ث", "ج", "ح", "خ", "د",
                    "ذ", "ر", "ز", "س", "ش", "ص", "ض",
                    "ط", "ظ", "ع", "غ", "ف", "ق", "ك",
                    "ل", "م", "ن", "ه", "و", "ي", "ا"
                }
            },

            new Cipher
            {
                DisplayName = "المورس",
                IsAudible = true,
                Characters =
                {
                    "(•-)"  , "(-•••)", "(-)"   , "(-•-•)", "(•---)" , "(••••)", "(---)" ,
                    "(-••)" , "(--••)", "(•-•)" , "(---•)", "(•••)"  , "(----)", "(-••-)",
                    "(•••-)", "(••-)" , "(-•--)", "(•-•-)", "(--•)"  , "(••-•)", "(--•-)",
                    "(-•-)" , "(•-••)", "(--)"  , "(-•)"  , "(••-••)", "(•--)" , "(••)"
                }
            },

            new Cipher
            {
                DisplayName = "البوصلة",
                Characters =
                {
                    "N(١)", "NE(١)", "E(١)", "SE(١)", "S(١)", "SW(١)", "W(١)", "NW(١)",
                    "N(٢)", "NE(٢)", "E(٢)", "SE(٢)", "S(٢)", "SW(٢)", "W(٢)", "NW(٢)",
                    "N(٣)", "NE(٣)", "E(٣)", "SE(٣)", "S(٣)", "SW(٣)", "W(٣)", "NW(٣)",
                    "N(٤)", "NE(٤)", "E(٤)", "SE(٤)"
                }
            },

            new Cipher
            {
                DisplayName = "الساعة",
                HasOverloads = true,
                Overloads = new List<Cipher>
                {
                    new Cipher
                    {
                        DisplayName = "CW",
                        Characters =
                        {
                            "١:١٢", "١:١" , "١:٢" , "١:٣" , "١:٤" , "١:٥" , "١:٦",
                            "١:٧" , "١:٨" , "١:٩" , "١:١٠", "١:١١", "٢:١٢", "٢:١",
                            "٢:٢" , "٢:٣" , "٢:٤" , "٢:٥" , "٢:٦" , "٢:٧" , "٢:٨",
                            "٢:٩" , "٢:١٠", "٢:١١", "٣:١٢", "٣:١" , "٣:٢" , "٣:٣"
                        }
                    },

                    new Cipher
                    {
                        DisplayName = "CCW",
                        Characters =
                        {
                            "١:١٢", "١:١١", "١:١٠", "١:٩" , "١:٨" , "١:٧" , "١:٦" ,
                            "١:٥" , "١:٤" , "١:٣" , "١:٢" , "١:١" , "٢:١٢", "٢:١١",
                            "٢:١٠", "٢:٩" , "٢:٨" , "٢:٧" , "٢:٦" , "٢:٥" , "٢:٤" ,
                            "٢:٣" , "٢:٢" , "٢:١" , "٣:١٢", "٣:١١", "٣:١٠", "٣:٩"
                        }
                    }
                }
            },

            new Cipher
            {
                DisplayName = "الجوال",
                HasOverloads = true,
                Overloads = new List<Cipher>
                {
                    new Cipher
                    {
                        DisplayName = "أ = ٣",
                        Characters =
                        {
                            "٣"   , "٢"   , "٢٢"    , "٢٢٢" , "٦"   , "٦٦" , "٦٦٦",
                            "٥"   , "٥٥"  , "٥٥٥"   , "٥٥٥٥", "٤"   , "٤٤" , "٤٤٤",
                            "٤٤٤٤", "٩"   , "٩٩"    , "٩٩٩" , "٩٩٩٩", "٨"  , "٨٨" ,
                            "٨٨٨" , "٨٨٨٨", "٨٨٨٨٨", "٧"    , "٧٧"  , "٧٧٧", "٧٧٧٧"
                        }
                    },

                    new Cipher
                    {
                        DisplayName = "أ = ٣^١",
                        Characters =
                        {
                            "٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                            "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                            "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                            "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"
                        }
                    }
                }
            },

            new Cipher
            {
                DisplayName = "إكس",
                HasKeys = true,
                KeyWeight = 7,
                Characters =
                {
                    "˅١", "˅٢", "˅٣", "˅٤", "˅٥", "˅٦", "˅٧",
                    "˂١", "˂٢", "˂٣", "˂٤", "˂٥", "˂٦", "˂٧",
                    "˄١", "˄٢", "˄٣", "˄٤", "˄٥", "˄٦", "˄٧",
                    "˃١", "˃٢", "˃٣", "˃٤", "˃٥", "˃٦", "˃٧"
                }
            },

            new Cipher
            {
                DisplayName = "النجمة",
                HasKeys = true,
                HasShapes = true,
                KeyWeight = 7,
                Characters =
                {
                    "▲١", "▲٢", "▲٣", "▲٤", "▲٥", "▲٦", "▲٧",
                    "▶١", "▶٢", "▶٣", "▶٤", "▶٥", "▶٦", "▶٧",
                    "▼١", "▼٢", "▼٣", "▼٤", "▼٥", "▼٦", "▼٧",
                    "◀١", "◀٢", "◀٣", "◀٤", "◀٥", "◀٦", "◀٧"
                }
            },

            new Cipher
            {
                DisplayName = "المعين",
                HasShapes = true,
                Characters =
                {
                    "١◣", "١◢", "١◤", "١◥",
                    "٢◣", "٢◢", "٢◤", "٢◥",
                    "٣◣", "٣◢", "٣◤", "٣◥",
                    "٤◣", "٤◢", "٤◤", "٤◥",
                    "٥◣", "٥◢", "٥◤", "٥◥",
                    "٦◣", "٦◢", "٦◤", "٦◥",
                    "٧◣", "٧◢", "٧◤", "٧◥"
                }
            },

            new Cipher
            {
                DisplayName = "المثلث",
                HasShapes = true,
                Characters =
                {
                    "١▲",
                    "٢◣◼", "٢◼◢",
                    "٣◣◼", "٣◼(١)", "٣◼◢",
                    "٤◣◼", "٤◼(١)", "٤◼(٢)", "٤◼◢",
                    "٥◣◼", "٥◼(١)", "٥◼(٢)", "٥◼(٣)", "٥◼◢",
                    "٦◣◼", "٦◼(١)", "٦◼(٢)", "٦◼(٣)", "٦◼(٤)", "٦◼◢",
                    "٧◣◼", "٧◼(١)", "٧◼(٢)", "٧◼(٣)", "٧◼(٤)", "٧◼(٥)", "٧◼◢"
                }
            }
        };

        private Cipher _chosenCipher;
        private FileStream _fileStream;

        private readonly List<TextBox> _lettersTextBoxes = new List<TextBox>();
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Cipher));
        
        private bool _isFilled = true;   // Default Format
        private bool _isLight  = true;   // Default Theme

        private const string GoogleDocsBase = "https://doc.new/";
        private const string GitHubBase = "https://github.com/";
        private const string OwnerName = "YoussefRaafatNasry";
        private const string OwnerEmail = "YoussefRaafatNasry@gmail.com";
        private const string RepoName = "ScoutsEncoder";

        private static readonly string SiteBase = $"https://{OwnerName}.github.io/";
        private static readonly string RepoPath = $"{RepoName}/";
        private static readonly string DocsPath = "docs/all/";
        private static readonly string ReportSubject = Uri.EscapeUriString($"{RepoName} | Bug Report");

        public MainWindow()
        {
            InitializeComponent();

            // Initialize CiphersComboBox
            foreach (var x in _ciphers)
            {
                CiphersComboBox.Items.Add(x.DisplayName);
            }

            // Initialize lettersTextBoxes (used while adding new ciphers)
            var dialogContent = NewCipherDialogHost.DialogContent as Grid;
            foreach (var stackPanel in dialogContent.Children.OfType<StackPanel>())
            {
                var children = (stackPanel as StackPanel).Children;
                _lettersTextBoxes.AddRange(children.OfType<TextBox>());
            }

            // Initialize messageQueue and Assign it to Snackbar's MessageQueue
            var messageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1800));
            Snackbar.MessageQueue = messageQueue;
        }

        public string CharsDelimiter
        {
            get
            {
                int count = CharSpacingCheckBox.IsChecked.Value ? 1 : 0;
                string spaces = new string(' ', count);
                return string.Format("{0}{1}{0}", spaces, CharsDelimiterTextBox.Text);
            }
        }

        public string WordsDelimiter
        {
            get
            {
                int count = WordSpacingCheckBox.IsChecked.Value ? 2 : 1;
                string spaces = new string(' ', count);
                return string.Format("{0}{1}{0}", spaces, WordsDelimiterTextBox.Text);
            }
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
            var newCipher = GetNewCipher();
            _ciphers.Add(newCipher);
            CiphersComboBox.Items.Add(newCipher.DisplayName);

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

            var newCipher = GetNewCipher();
            _fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            _xmlSerializer.Serialize(_fileStream, newCipher);
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
            for (int i = 0; i < newCipher.Characters.Count; i++)
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
            _chosenCipher = _ciphers[CiphersComboBox.SelectedIndex];

            KeysComboBox.IsEnabled     = _chosenCipher.HasKeys || _chosenCipher.HasOverloads;
            KeysComboBox.ItemsSource   = _chosenCipher.KeysList;
            KeysComboBox.SelectedIndex = 0;

            EncodeButton        .IsEnabled = true;
            ShowKeyButton       .IsEnabled = true;
            RealTimeToggleButton.IsEnabled = true;
            ToggleFillButton    .IsEnabled = _chosenCipher.HasShapes;
            ExportAudioButton   .IsEnabled = _chosenCipher.IsAudible;
            AudioSpeedComboBox  .IsEnabled = _chosenCipher.IsAudible;
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set Key to zero if KeysComboBox is empty
            // or while changing the KeysComboBox's ItemsSource,
            // instead of making Key = SelectedIndex = -1
            // which will cause an error while encoding
            _chosenCipher.Key = KeysComboBox.SelectedIndex == -1 ? 0 : KeysComboBox.SelectedIndex;
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = _chosenCipher.ShowKey();
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = _chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        // Real-time Encoding

        private void RealTimeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            RealTimeToggleButton.Foreground = new SolidColorBrush(Colors.White);

            OutputTextBox.Text = _chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);

            InputTextBox         .TextChanged += TextBox_TextChanged;
            CharsDelimiterTextBox.TextChanged += TextBox_TextChanged;
            WordsDelimiterTextBox.TextChanged += TextBox_TextChanged;

            CharSpacingCheckBox.Checked   += CheckBox_CheckChanged;
            CharSpacingCheckBox.Unchecked += CheckBox_CheckChanged;
            WordSpacingCheckBox.Checked   += CheckBox_CheckChanged;
            WordSpacingCheckBox.Unchecked += CheckBox_CheckChanged;

            CiphersComboBox.SelectionChanged += ComboBox_SelectionChanged;
            KeysComboBox   .SelectionChanged += ComboBox_SelectionChanged;
        }

        private void RealTimeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_isLight) RealTimeToggleButton.Foreground = (Brush) Application.Current.Resources["MaterialDesignBody"];

            OutputTextBox.Text = "";

            InputTextBox         .TextChanged -= TextBox_TextChanged;
            CharsDelimiterTextBox.TextChanged -= TextBox_TextChanged;
            WordsDelimiterTextBox.TextChanged -= TextBox_TextChanged;

            CharSpacingCheckBox.Checked   -= CheckBox_CheckChanged;
            CharSpacingCheckBox.Unchecked -= CheckBox_CheckChanged;
            WordSpacingCheckBox.Checked   -= CheckBox_CheckChanged;
            WordSpacingCheckBox.Unchecked -= CheckBox_CheckChanged;

            CiphersComboBox.SelectionChanged -= ComboBox_SelectionChanged;
            KeysComboBox   .SelectionChanged -= ComboBox_SelectionChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OutputTextBox.Text = _chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        private void CheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = _chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OutputTextBox.Text = _chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
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
            var audioData = new MorseCodeGenerator(OutputTextBox.Text, CharsDelimiter, WordsDelimiter,
                AudioSpeedComboBox.SelectedIndex);
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