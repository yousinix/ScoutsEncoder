using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace ScoutsEncoder_WPF
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

        }

        Cipher chosenCipher;

        Cipher[] ciphers = new[]
        {
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
                DisplayName = "العكسية",
                HasKeys = true,
                CipherCharacters = {"ي", "و", "ه", "ن", "م", "ل", "ك",
                                    "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                                    "ص", "ش", "س", "ز", "ر", "ذ", "د",
                                    "خ", "ح", "ج", "ث", "ت", "ب", "ا"}
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
                DisplayName = "المعين",
                HasShapes = true,
                CipherCharacters = {"١◣", "١◢", "١◤", "١◥",
                                    "٢◣", "٢◢", "٢◤", "٢◥",
                                    "٣◣", "٣◢", "٣◤", "٣◥",
                                    "٤◣", "٤◢", "٤◤", "٤◥",
                                    "٥◣", "٥◢", "٥◤", "٥◥",
                                    "٦◣", "٦◢", "٦◤", "٦◥",
                                    "٧◣", "٧◢", "٧◤", "٧◥"}
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

        private void CiphersComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EncodeButton .IsEnabled = true;
            ShowKeyButton.IsEnabled = true;

            chosenCipher = ciphers[CiphersComboBox.SelectedIndex];
            DataContext  = chosenCipher;

            if (chosenCipher.HasKeys)
                KeysComboBox.SelectedIndex = 0;
        }

        private void KeysComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (KeysComboBox.SelectedIndex != -1)
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

        string currentFormat = "Fill";
        private void ToggleShapeFillButton_Click(object sender, RoutedEventArgs e)
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




        //// Footer's Event Handlers ////

        string currentTheme = "Light"; // Default theme
        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentTheme == "Light")
            {
                ThemeAssist.SetTheme(this, BaseTheme.Dark);
                currentTheme = "Dark";
            }
            else if (currentTheme == "Dark")
            {
                ThemeAssist.SetTheme(this, BaseTheme.Light);
                currentTheme = "Light";
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

