using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WindowsApp.Extensions
{
    public static class RichTextBoxExtensions
    {

        public static TextPointer GetStart(this RichTextBox richTextBox)
        {
            return richTextBox.Document.ContentStart;
        }

        public static TextPointer GetEnd(this RichTextBox richTextBox)
        {
            return richTextBox.Document.ContentEnd;
        }

        public static TextRange GetRange(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.GetStart(), richTextBox.GetEnd());
        }

        public static string GetText(this RichTextBox richTextBox)
        {
            return richTextBox.GetRange().Text;
        }

        public static void AppendText(this RichTextBox richTextBox, string text)
        {
            var paragraph = new Paragraph(new Run(richTextBox.GetText() + text));
            richTextBox.Document.Blocks.Add(paragraph);
        }

        public static void SetText(this RichTextBox richTextBox, string text)
        {
            richTextBox.Clear();
            richTextBox.AppendText(text);
        }

        public static bool IsEmpty(this RichTextBox richTextBox)
        {
            return richTextBox.GetRange().IsEmpty;
        }

        public static void Clear(this RichTextBox richTextBox)
        {
            richTextBox.Document.Blocks.Clear();
        }

        public static void ClearFormatting(this RichTextBox richTextBox)
        {
            richTextBox.GetRange().ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);
        }

        public static void CopyToClipboard(this RichTextBox richTextBox)
        {
            var text = richTextBox.GetText();
            if (text != "")
            {
                Clipboard.SetText(text);
            }
        }

    }
}