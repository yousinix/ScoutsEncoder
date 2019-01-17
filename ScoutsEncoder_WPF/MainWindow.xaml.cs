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
        }




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




        //// Output Event Handlers ////

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
