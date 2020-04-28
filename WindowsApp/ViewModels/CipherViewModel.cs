using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Core.Models.Ciphers;

namespace WindowsApp.ViewModels
{
    public sealed class CipherViewModel : INotifyPropertyChanged
    {
        #region Model

        private CipherBase _model;
        public CipherBase Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();

                // Standards
                OnPropertyChanged(nameof(HasStandards));
                OnPropertyChanged(nameof(Standards));
                _standardIndex = HasStandards ? 0 : -1;
                OnPropertyChanged(nameof(StandardIndex));

                // Keys
                OnPropertyChanged(nameof(HasKeys));
                OnPropertyChanged(nameof(Keys));
                _keyIndex = HasKeys ? 0 : -1;
                OnPropertyChanged(nameof(KeyIndex));

                // Types
                OnPropertyChanged(nameof(IsGeometric));
                OnPropertyChanged(nameof(IsAudible));

                OnPropertyChanged(nameof(EncodedText));
            }
        }

        #endregion


        #region Standards

        private int _standardIndex;
        public int StandardIndex
        {
            get => _standardIndex;
            set => SetField(ref _standardIndex, value);
        }

        public bool HasStandards => Model is MultiStandardCipher;

        public IEnumerable<CipherStandard> Standards => HasStandards ? ((MultiStandardCipher)Model).Standards : null;

        #endregion


        #region Keys

        private int _keyIndex;
        public int KeyIndex
        {
            get => _keyIndex;
            set => SetField(ref _keyIndex, value);
        }

        public bool HasKeys => Model.Key.IsEnabled;

        public IEnumerable<string> Keys => HasKeys ? Model.KeysList : null;

        #endregion


        #region Types

        public bool IsGeometric => Model.Type == CipherType.Geometric;

        public bool IsAudible => Model.Type == CipherType.Audible;

        #endregion


        #region Delimiters

        private string _charsDelimiter = " - ";
        public string CharsDelimiter
        {
            get => _charsDelimiter;
            set => SetField(ref _charsDelimiter, value);
        }

        private string _wordsDelimiter = "  /  ";
        public string WordsDelimiter
        {
            get => _wordsDelimiter;
            set => SetField(ref _wordsDelimiter, value);
        }

        #endregion


        #region I/O

        private string _plainText = string.Empty;
        public string PlainText
        {
            get => _plainText;
            set => SetField(ref _plainText, value);
        }

        public string EncodedText
        {
            get
            {
                if (KeyIndex != -1) Model.Key.Base = KeyIndex;
                if (StandardIndex != -1) ((MultiStandardCipher)Model).StandardIndex = StandardIndex;
                return Model.Encode(PlainText, CharsDelimiter, WordsDelimiter);
            }
        }

        #endregion


        #region Property Change Notification

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
            OnPropertyChanged(nameof(EncodedText)); // All properties affect EncodedText
        }

        #endregion
    }
}