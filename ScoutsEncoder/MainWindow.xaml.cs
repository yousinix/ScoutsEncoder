using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace ScoutsEncoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize CiphersComboBox
            foreach (Cipher x in ciphers)
                CiphersComboBox.Items.Add(x.DisplayName);

            // Disable all controls until a cipher is chosen
            EncodeButton        .IsEnabled = false;
            ShowKeyButton       .IsEnabled = false;
            ToggleFillButton    .IsEnabled = false;
            ExportAudioButton   .IsEnabled = false;
            KeysComboBox        .IsEnabled = false;
            AudioSpeedComboBox  .IsEnabled = false;
            RealTimeToggleButton.IsEnabled = false;

            // Intialize messageQueue and Assign it to Snackbar's MessageQueue
            var messageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1800));
            Snackbar.MessageQueue = messageQueue;
        }

        Cipher chosenCipher;

        Cipher[] ciphers = new[]
        {
            new Cipher
            {
                DisplayName = "يسوع",
                HasKeys = true,
                CipherCharacters = {"ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                                    "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                                    "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                                    "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"}
            },

            new Cipher
            {
                DisplayName = "الرقمية",
                HasKeys = true,
                CipherCharacters = {"١" , "٢" , "٣" , "٤" , "٥" , "٦" , "٧" ,
                                    "٨" , "٩" , "١٠", "١١", "١٢", "١٣", "١٤",
                                    "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                                    "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"}
            },

            new Cipher
            {
                DisplayName = "الأعداد الثنائية",
                CipherCharacters = {"00001", "00010", "00011", "00100", "00101", "00110", "00111",
                                    "01000", "01001", "01010", "01011", "01100", "01101", "01110",
                                    "01111", "10000", "10001", "10010", "10011", "10100", "10101",
                                    "10110", "10111", "11000", "11001", "11010", "11011", "11100"}
            },

            new Cipher
            {
                DisplayName = "العكسية",
                HasKeys = true,
                CipherCharacters = {"ي", "و", "ه", "ن", "م", "ل", "ك",
                                    "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                                    "ص", "ش", "س", "ز", "ر", "ذ", "د",
                                    "خ", "ح", "ج", "ث", "ت", "ب", "ا"}
            },

            new Cipher
            {
                DisplayName = "قيصر",
                HasKeys = true,
                CipherCharacters = {"ب", "ت", "ث", "ج", "ح", "خ", "د",
                                    "ذ", "ر", "ز", "س", "ش", "ص", "ض",
                                    "ط", "ظ", "ع", "غ", "ف", "ق", "ك",
                                    "ل", "م", "ن", "ه", "و", "ي", "ا"}
            },

            new Cipher
            {
                DisplayName = "المورس",
                IsAudible = true,
                CipherCharacters = {"(•-)"  , "(-•••)", "(-)"   , "(-•-•)", "(•---)" , "(••••)", "(---)" ,
                                    "(-••)" , "(--••)", "(•-•)" , "(---•)", "(•••)"  , "(----)", "(-••-)",
                                    "(•••-)", "(••-)" , "(-•--)", "(•-•-)", "(--•)"  , "(••-•)", "(--•-)",
                                    "(-•-)" , "(•-••)", "(--)"  , "(-•)"  , "(••-••)", "(•--)" , "(••)"  }
            },

            new Cipher
            {
                DisplayName = "البوصلة",
                CipherCharacters = {"N(١)", "NE(١)", "E(١)", "SE(١)", "S(١)", "SW(١)", "W(١)", "NW(١)",
                                    "N(٢)", "NE(٢)", "E(٢)", "SE(٢)", "S(٢)", "SW(٢)", "W(٢)", "NW(٢)",
                                    "N(٣)", "NE(٣)", "E(٣)", "SE(٣)", "S(٣)", "SW(٣)", "W(٣)", "NW(٣)",
                                    "N(٤)", "NE(٤)", "E(٤)", "SE(٤)"}
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
                        CipherCharacters = {"١:١٢", "١:١" , "١:٢" , "١:٣" , "١:٤" , "١:٥" , "١:٦",
                                            "١:٧" , "١:٨" , "١:٩" , "١:١٠", "١:١١", "٢:١٢", "٢:١",
                                            "٢:٢" , "٢:٣" , "٢:٤" , "٢:٥" , "٢:٦" , "٢:٧" , "٢:٨",
                                            "٢:٩" , "٢:١٠", "٢:١١", "٣:١٢", "٣:١" , "٣:٢" , "٣:٣" }
                    },

                    new Cipher
                    {
                        DisplayName = "CCW",
                        CipherCharacters = {"١:١٢", "١:١١", "١:١٠", "١:٩" , "١:٨" , "١:٧" , "١:٦" ,
                                            "١:٥" , "١:٤" , "١:٣" , "١:٢" , "١:١" , "٢:١٢", "٢:١١",
                                            "٢:١٠", "٢:٩" , "٢:٨" , "٢:٧" , "٢:٦" , "٢:٥" , "٢:٤" ,
                                            "٢:٣" , "٢:٢" , "٢:١" , "٣:١٢", "٣:١١", "٣:١٠", "٣:٩" }
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
                        CipherCharacters = {"٣"   , "٢"   , "٢٢"    , "٢٢٢" , "٦"   , "٦٦" , "٦٦٦"  ,
                                            "٥"   , "٥٥"  , "٥٥٥"   , "٥٥٥٥", "٤"   , "٤٤" , "٤٤٤"  ,
                                            "٤٤٤٤", "٩"   , "٩٩"    , "٩٩٩" , "٩٩٩٩", "٨"  , "٨٨"   ,
                                            "٨٨٨" , "٨٨٨٨", "٨٨٨٨٨", "٧"    , "٧٧"  , "٧٧٧", "٧٧٧٧"}
                    },

                    new Cipher
                    {
                        DisplayName = "أ = ٣^١",
                        CipherCharacters = {"٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                                            "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                                            "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                                            "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"}
                    }
                }
            },

            new Cipher
            {
                DisplayName = "إكس",
                HasKeys = true,
                KeyWeight = 7,
                CipherCharacters = {"V(١)", "V(٢)", "V(٣)", "V(٤)", "V(٥)", "V(٦)", "V(٧)",
                                    ">(١)", ">(٢)", ">(٣)", ">(٤)", ">(٥)", ">(٦)", ">(٧)",
                                    "Λ(١)", "Λ(٢)", "Λ(٣)", "Λ(٤)", "Λ(٥)", "Λ(٦)", "Λ(٧)",
                                    "<(١)", "<(٢)", "<(٣)", "<(٤)", "<(٥)", "<(٦)", "<(٧)"}
            },

            new Cipher
            {
                DisplayName = "النجمة",
                HasKeys = true,
                HasShapes = true,
                KeyWeight = 7,
                CipherCharacters = {"▲١", "▲٢", "▲٣", "▲٤", "▲٥", "▲٦", "▲٧",
                                    "▶١", "▶٢", "▶٣", "▶٤", "▶٥", "▶٦", "▶٧",
                                    "◀١", "◀٢", "◀٣", "◀٤", "◀٥", "◀٦", "◀٧",
                                    "▼١", "▼٢", "▼٣", "▼٤", "▼٥", "▼٦", "▼٧"}
            },

            new Cipher
            {
                DisplayName = "المعين",
                HasShapes = true,
                CipherCharacters = {"١◣", "١◢", "١◤", "١◥",
                                    "٢◣", "٢◢", "٢◤", "٢◥",
                                    "٣◣", "٣◢", "٣◤", "٣◥",
                                    "٤◣", "٤◢", "٤◤", "٤◥",
                                    "٥◣", "٥◢", "٥◤", "٥◥",
                                    "٦◣", "٦◢", "٦◤", "٦◥",
                                    "٧◣", "٧◢", "٧◤", "٧◥"}
            },

            new Cipher
            {
                DisplayName = "المثلث",
                HasShapes = true,
                CipherCharacters = {"١▲",
                                    "٢◣◼",  "٢◼◢",
                                    "٣◣◼", "٣◼(١)",  "٣◼◢",
                                    "٤◣◼", "٤◼(١)", "٤◼(٢)",  "٤◼◢",
                                    "٥◣◼", "٥◼(١)", "٥◼(٢)", "٥◼(٣)",  "٥◼◢",
                                    "٦◣◼", "٦◼(١)", "٦◼(٢)", "٦◼(٣)", "٦◼(٤)",  "٦◼◢",
                                    "٧◣◼", "٧◼(١)", "٧◼(٢)", "٧◼(٣)", "٧◼(٤)", "٧◼(٥)", "٧◼◢"}
            }
        };




        //// Input Event Handlers ////

        private void InputCutButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                Clipboard.SetText(InputTextBox.Text);
            }
            InputTextBox.Text = "";
        }

        private void InputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                Clipboard.SetText(InputTextBox.Text);
            }
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
            EncodeButton .IsEnabled = true;
            ShowKeyButton.IsEnabled = true;
            RealTimeToggleButton.IsEnabled = true;

            chosenCipher = ciphers[CiphersComboBox.SelectedIndex];

            KeysComboBox      .IsEnabled = chosenCipher.HasKeys || chosenCipher.HasOverloads;
            KeysComboBox    .ItemsSource = chosenCipher.KeysList;
            ToggleFillButton  .IsEnabled = chosenCipher.HasShapes;
            ExportAudioButton .IsEnabled = chosenCipher.IsAudible;
            AudioSpeedComboBox.IsEnabled = chosenCipher.IsAudible;

            // Set Key to zero because empty KeysList
            // makes Key = KeysComboBox.SelectedIndex = -1
            chosenCipher.Key = KeysComboBox.SelectedIndex = 0;
        }

        private void KeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chosenCipher.Key = KeysComboBox.SelectedIndex;
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = chosenCipher.ShowKey();
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        // Real-time Encoding

        private void RealTimeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            RealTimeToggleButton.Foreground = new SolidColorBrush(Colors.White);

            OutputTextBox.Text = chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);

            InputTextBox.TextChanged          += TextBox_TextChanged;
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
            if (currentTheme == "Light")
                RealTimeToggleButton.Foreground = (Brush)Application.Current.Resources["MaterialDesignBody"];

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
            OutputTextBox.Text = chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        private void CheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OutputTextBox.Text = chosenCipher.Encode(InputTextBox.Text, CharsDelimiter, WordsDelimiter);
        }


        //// Output Event Handlers & Properties ////

        private void OutputCutButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutputTextBox.Text != "")
            {
                Clipboard.SetText(OutputTextBox.Text);
            }
            OutputTextBox.Text = "";
        }

        private void OutputCopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutputTextBox.Text != "")
            {
                Clipboard.SetText(OutputTextBox.Text);
            }
        }

        private void OutputClearButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "";
        }

        public string CharsDelimiter
        {
            get
            {
                if (CharSpacingCheckBox.IsChecked == true)
                    return " " + CharsDelimiterTextBox.Text + " ";
                else
                    return CharsDelimiterTextBox.Text;
            }
        }

        public string WordsDelimiter
        {
            get
            {
                if (WordSpacingCheckBox.IsChecked == true)
                    return "  " + WordsDelimiterTextBox.Text + "  ";
                else
                    return " " + WordsDelimiterTextBox.Text + " ";
            }
        }

        string currentFormat = "Fill"; // Default Format
        private void ToggleFillButton_Click(object sender, RoutedEventArgs e)
        {

            char[] filledShapes = { '◼', '▲', '▼', '◀', '▶', '◢', '◣', '◥', '◤' };
            char[] StrokedShapes = { '◻', '△', '▽', '◁', '▷', '◿', '◺', '◹', '◸' };

            if (currentFormat == "Fill")
            {
                for (int i = 0; i < filledShapes.Length; i++)
                {
                    OutputTextBox.Text = OutputTextBox.Text.Replace(filledShapes[i], StrokedShapes[i]);
                }

                currentFormat = "Stroke";
            }
            else if (currentFormat == "Stroke")
            {
                for (int i = 0; i < filledShapes.Length; i++)
                {
                    OutputTextBox.Text = OutputTextBox.Text.Replace(StrokedShapes[i], filledShapes[i]);
                }

                currentFormat = "Fill";
            }
        }

        private void ExportAudioButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                FileName = "MorseCode - " + AudioSpeedComboBox.Text, // Default file name
                DefaultExt = ".wav",    // Default file extension
                Filter = "Waveform Audio File (.wav)|*.wav" // Filter files by extension
            };

            // Process save file dialog box results
            if (dlg.ShowDialog() == true)
            {
                MorseCodeGenerator audioData = new MorseCodeGenerator(OutputTextBox.Text, CharsDelimiter, WordsDelimiter, AudioSpeedComboBox.SelectedIndex);
                audioData.Save(dlg.FileName);
                Snackbar.MessageQueue.Enqueue("\"" + dlg.SafeFileName + "\"" + " Saved!");
            }
        }



        //// Footer's Event Handlers ////

        string currentTheme = "Light"; // Default theme
        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentTheme == "Light")
            {
                ThemeAssist.SetTheme(this, BaseTheme.Dark);
                currentTheme = "Dark";

                RealTimeToggleButton.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (currentTheme == "Dark")
            {
                ThemeAssist.SetTheme(this, BaseTheme.Light);
                currentTheme = "Light";

                if (RealTimeToggleButton.IsChecked == false)
                    RealTimeToggleButton.Foreground = (Brush)Application.Current.Resources["MaterialDesignBody"];
            }
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/YoussefRaafatNasry/ScoutsEncoder/");
        }

        private void GoogleDocsButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://doc.new/");
        }

        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://youssefraafatnasry.github.io/ScoutsEncoder/");
        }

        private void ScoutsEncoderDocsButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://youssefraafatnasry.github.io/ScoutsEncoder/docs/all/");
        }

        private void BugReportButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto:YoussefRaafatNasry@gmail.com?subject=ScoutsEncoder%20|%20Bug%20Report");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}

