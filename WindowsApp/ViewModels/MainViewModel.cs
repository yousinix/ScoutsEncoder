using Core.Data;
using Core.Models.Ciphers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using WindowsApp.ViewModels.Common;
using Microsoft.Win32;
using Services.MorseGenerator;

namespace WindowsApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public SnackbarMessageQueue MessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        public IEnumerable<CipherBase> Ciphers => CiphersList.Instance;
        public List<string> Speeds => new List<string> { "Slow", "Medium", "Fast" };
        public CipherViewModel Cipher { get; set; } = new CipherViewModel();
        public int SpeedIndex { get; set; } = 1;
        public ICommand ClearInput { get; set; }
        public ICommand CopyOutput { get; set; }
        public ICommand ExportAudio { get; set; }

        public MainViewModel()
        {
            ClearInput = new CommandBase(_ => ExecuteClearInput());
            CopyOutput = new CommandBase(_ => ExecuteCopyOutput());
            ExportAudio = new CommandBase(_ => ExecuteExportAudio());
        }

        private void ExecuteClearInput()
        {
            Cipher.PlainText = "";  
        }

        private void ExecuteCopyOutput()
        {
            Clipboard.SetText(Cipher.EncodedText);
            MessageQueue.Enqueue("Output copied to clipboard!");
        }

        private void ExecuteExportAudio()
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "MorseCode - " + Speeds[SpeedIndex],
                DefaultExt = ".wav",
                Filter = "Waveform Audio File|*.wav"
            };

            if (saveFileDialog.ShowDialog() != true) return;

            MorseAudioGenerator.Generate(saveFileDialog.FileName,
                Cipher.EncodedText,
                Cipher.CharsDelimiter,
                Cipher.WordsDelimiter,
                SpeedIndex
            );

            var content = $"{saveFileDialog.SafeFileName} is Saved!";
            var arguments = $"/select, \"{saveFileDialog.FileName}\"";
            void Action() => Process.Start("explorer.exe", arguments);
            MessageQueue.Enqueue(content, "Open", Action);
        }
    }
}
