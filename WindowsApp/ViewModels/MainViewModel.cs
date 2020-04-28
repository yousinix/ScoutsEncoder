using System.Collections.Generic;
using System.Windows.Controls;
using WindowsApp.Commands;
using WindowsApp.Extensions;
using Core.Data;
using Core.Models.Ciphers;

namespace WindowsApp.ViewModels
{
    public class MainViewModel
    {
        public CipherViewModel Cipher { get; set; } = new CipherViewModel();
        public IEnumerable<CipherBase> Ciphers => CiphersList.Instance;
        public CommandBase<RichTextBox> Copy { get; set; } = new CommandBase<RichTextBox>(r => r.CopyToClipboard());
        public CommandBase<RichTextBox> Clear { get; set; } = new CommandBase<RichTextBox>(r => r.Clear());
    }
}
