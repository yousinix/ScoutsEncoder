using Core.Data;
using Core.Models.Ciphers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WindowsApp.ViewModels.Common;

namespace WindowsApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public SnackbarMessageQueue MessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        public IEnumerable<CipherBase> Ciphers => CiphersList.Instance;
        public CipherViewModel Cipher { get; set; } = new CipherViewModel();
        public ICommand ClearInput { get; set; }
        public ICommand CopyOutput { get; set; }

        public MainViewModel()
        {
            ClearInput = new CommandBase(_ => Cipher.PlainText = "");
            CopyOutput = new CommandBase(_ =>
            {
                Clipboard.SetText(Cipher.EncodedText);
                MessageQueue.Enqueue("Output copied to clipboard!");
            });
        }
    }
}
