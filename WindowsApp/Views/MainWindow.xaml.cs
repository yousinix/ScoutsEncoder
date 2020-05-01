using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using WindowsApp.ViewModels;

namespace WindowsApp.Views
{
    public partial class MainWindow
    {
        private CipherViewModel Cipher => ((MainViewModel) DataContext).Cipher;

        public MainWindow() 
        {
            InitializeComponent();
            NewCipherDialog.Context = this;
        }

        private void MirrorSelectionEventHandler(object sender, RoutedEventArgs e)
        {
            // Clear old mirror
            var baseStartPtr   = OutputRichTextBox.Document.ContentStart;
            var baseEndPtr     = OutputRichTextBox.Document.ContentEnd;
            var baseRange      = new TextRange(baseStartPtr, baseEndPtr);
            baseRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);

            if (InputTextBox.SelectionLength == 0) return;

            // Get mirror target info
            var selectedText   = Cipher.Encode(InputTextBox.SelectedText);
            var precedingText  = Cipher.Encode(InputTextBox.Text.Substring(0, InputTextBox.SelectionStart));
            var mirrorStart    = precedingText.Length + 2;
            var mirrorLength   = selectedText .Length + 2;

            // Apply mirror to target
            var mirrorStartPtr = baseStartPtr.GetPositionAtOffset(mirrorStart);
            var mirrorEndPtr   = mirrorStartPtr?.GetPositionAtOffset(mirrorLength) ?? baseEndPtr;
            var mirrorRange    = new TextRange(mirrorStartPtr, mirrorEndPtr);
            mirrorRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.CornflowerBlue);
        }

    }
}