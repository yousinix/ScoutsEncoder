using System.Windows.Controls;
using WindowsApp.Commands;
using WindowsApp.Extensions;

namespace WindowsApp.ViewModels
{
    public class MainViewModel
    {
        public CommandBase<RichTextBox> Copy { get; set; } = new CommandBase<RichTextBox>(r => r.CopyToClipboard());
        public CommandBase<RichTextBox> Clear { get; set; } = new CommandBase<RichTextBox>(r => r.Clear());
    }
}
