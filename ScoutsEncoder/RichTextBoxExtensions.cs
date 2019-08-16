using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ScoutsEncoder
{
    public static class RichTextBoxExtensions
    {
        public static string GetText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }

        public static void Clear(this RichTextBox richTextBox)
        {
            richTextBox.Document.Blocks.Clear();
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

        public static void Replace(this RichTextBox richTextBox, List<char> old, List<char> @new)
        {
            var text = richTextBox.GetText();
            for (var i = 0; i < old.Count; i++)
            {
                text = text.Replace(old[i], @new[i]);
            }
            richTextBox.SetText(text);
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