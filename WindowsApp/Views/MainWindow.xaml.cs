using System.Linq;
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
        }

        private void MirrorSelectionEventHandler(object sender, RoutedEventArgs e)
        {
            // Clear old mirror
            var baseStartPtr = OutputRichTextBox.Document.ContentStart;
            var baseEndPtr   = OutputRichTextBox.Document.ContentEnd;
            var baseRange    = new TextRange(baseStartPtr, baseEndPtr);
            baseRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);

            if (InputTextBox.SelectionLength == 0) return;

            // Get mirror target info
            var precedingText = InputTextBox.Text.Substring(0, InputTextBox.SelectionStart);
            var selectedText  = InputTextBox.SelectedText;

            var precedingEncoding = Cipher.Encode(precedingText);
            var selectedEncoding  = Cipher.Encode(selectedText);

            var charDelimiterOffset = Cipher.CharsDelimiter.Length;
            var precedingTextOffset = precedingText.Length == 0 || char.IsWhiteSpace(precedingText.Last()) ? 0 : charDelimiterOffset;
            var selectedTextOffset  = char.IsWhiteSpace(selectedText.Last()) ? 0 : charDelimiterOffset;

            var mirrorStart  = precedingEncoding.Length + precedingTextOffset;
            var mirrorLength = selectedEncoding .Length + selectedTextOffset;

            // Apply mirror to target
            var targetStartPtr = OutputRun.ContentStart;
            var targetEndPtr   = OutputRun.ContentEnd;
            var mirrorStartPtr = targetStartPtr .GetPositionAtOffset(mirrorStart);
            var mirrorEndPtr   = mirrorStartPtr?.GetPositionAtOffset(mirrorLength) ?? targetEndPtr;
            var mirrorRange    = new TextRange(mirrorStartPtr, mirrorEndPtr);
            mirrorRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.CornflowerBlue);
        }

    }
}