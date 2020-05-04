using Core.Data;
using Core.Models.Ciphers;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Services.MorseGenerator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WindowsApp.ViewModels.Common;
using WindowsApp.Views;

namespace WindowsApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isDialogHostOpen;
        public bool IsDialogHostOpen
        {
            get => _isDialogHostOpen;
            set => SetField(ref _isDialogHostOpen, value);
        }

        private int _cipherIndex;
        public int CipherIndex
        {
            get => _cipherIndex;
            set => SetField(ref _cipherIndex, value);
        }

        public int SpeedIndex { get; set; } = 1;


        #region Collections

        public SnackbarMessageQueue MessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        public ObservableCollection<Cipher> Ciphers => CiphersList.Instance;
        public List<string> Speeds => new List<string> { "Slow", "Medium", "Fast" };

        #endregion


        #region ViewModels

        public CipherViewModel Cipher { get; set; } = new CipherViewModel();
        public NewCipherDialogViewModel NewCipherDialog { get; set; } = new NewCipherDialogViewModel();

        #endregion


        #region Commands

        public ICommand ClearInput { get; set; }
        public ICommand CopyOutput { get; set; }
        public ICommand ExportAudio { get; set; }
        public ICommand AddNewCipher { get; set; }
        public ICommand CloseDialog { get; set; }
        public ICommand MirrorSelect { get; set; }
        public ICommand ScrollToEnd { get; set; }

        #endregion


        public MainViewModel()
        {
            ClearInput   = new CommandBase(_ => ExecuteClearInput());
            CopyOutput   = new CommandBase(_ => ExecuteCopyOutput());
            ExportAudio  = new CommandBase(_ => ExecuteExportAudio());
            AddNewCipher = new CommandBase(_ => ExecuteAddNewCipher());
            CloseDialog  = new CommandBase(_ => ExecuteCloseDialog());
            MirrorSelect = new CommandBase<MainWindow>(ExecuteMirrorSelect);
            ScrollToEnd  = new CommandBase<RichTextBox>(ExecuteScrollToEnd);
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

        private void ExecuteAddNewCipher()
        {
            Ciphers.Add(NewCipherDialog.NewCipher);
            CipherIndex = Ciphers.Count - 1;
            ExecuteCloseDialog();
            MessageQueue.Enqueue("New Cipher Added!");
        }

        private void ExecuteCloseDialog()
        {
            IsDialogHostOpen = false;
            NewCipherDialog.Reset();
        }

        private void ExecuteMirrorSelect(MainWindow window)
        {
            // Clear old mirror
            var baseStartPtr = window.OutputRichTextBox.Document.ContentStart;
            var baseEndPtr   = window.OutputRichTextBox.Document.ContentEnd;
            var baseRange    = new TextRange(baseStartPtr, baseEndPtr);
            baseRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);

            if (window.InputTextBox.SelectionLength == 0) return;

            // Get mirror target info
            var precedingText = window.InputTextBox.Text.Substring(0, window.InputTextBox.SelectionStart);
            var selectedText  = window.InputTextBox.SelectedText;

            var precedingEncoding = Cipher.Encode(precedingText);
            var selectedEncoding  = Cipher.Encode(selectedText);

            var charDelimiterOffset = Cipher.CharsDelimiter.Length;
            var precedingTextOffset = precedingText.Length == 0 || char.IsWhiteSpace(precedingText.Last()) ? 0 : charDelimiterOffset;
            var selectedTextOffset  = char.IsWhiteSpace(selectedText.Last()) ? 0 : charDelimiterOffset;

            var mirrorStart  = precedingEncoding.Length + precedingTextOffset;
            var mirrorLength = selectedEncoding.Length + selectedTextOffset;

            // Apply mirror to target
            var targetStartPtr = window.OutputRun.ContentStart;
            var targetEndPtr   = window.OutputRun.ContentEnd;
            var mirrorStartPtr = targetStartPtr.GetPositionAtOffset(mirrorStart);
            var mirrorEndPtr   = mirrorStartPtr?.GetPositionAtOffset(mirrorLength) ?? targetEndPtr;
            var mirrorRange    = new TextRange(mirrorStartPtr, mirrorEndPtr);
            mirrorRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.CornflowerBlue);

            // Scroll to mirror position
            if (mirrorStartPtr == null) return;
            var rect = mirrorStartPtr.GetCharacterRect(LogicalDirection.Backward);
            window.OutputRichTextBox.ScrollToVerticalOffset(rect.Y);
        }

        private void ExecuteScrollToEnd(RichTextBox richTextBox)
        {
            richTextBox.ScrollToEnd();
        }
    }
}
