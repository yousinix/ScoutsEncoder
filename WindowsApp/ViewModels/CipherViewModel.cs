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

                // Reset Indices
                if (_model is MultiStandardCipher m) m.StandardIndex = 0;
                _model.Key.Base = 0;

                // Standards
                OnPropertyChanged(nameof(HasStandards));
                OnPropertyChanged(nameof(Standards));
                OnPropertyChanged(nameof(StandardIndex));

                // Keys
                OnPropertyChanged(nameof(HasKeys));
                OnPropertyChanged(nameof(Keys));
                OnPropertyChanged(nameof(KeyIndex));

                // Types
                OnPropertyChanged(nameof(IsGeometric));
                OnPropertyChanged(nameof(IsAudible));

                OnPropertyChanged(nameof(EncodedText));
            }
        }

        #endregion


        #region Standards

        public int StandardIndex
        {
            get => HasStandards ? ((MultiStandardCipher) _model).StandardIndex : -1;
            set
            {
                if (!(_model is MultiStandardCipher m)) return;
                if (value == m.StandardIndex) return;
                
                // Reset Key
                _model.Key.Base = 0;
                OnPropertyChanged(nameof(Keys));
                OnPropertyChanged(nameof(KeyIndex));

                m.StandardIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(EncodedText));
            }
        }

        public bool HasStandards => _model is MultiStandardCipher;

        public IEnumerable<CipherStandard> Standards => HasStandards ? ((MultiStandardCipher)_model).Standards : null;

        #endregion


        #region Keys

        public int KeyIndex
        {
            get => HasKeys ? _model.Key.Base : -1;
            set
            {
                if (value == _model.Key.Base) return;
                _model.Key.Base = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(EncodedText));
            }
        }

        public bool HasKeys => _model.Key.IsEnabled;

        public IEnumerable<string> Keys => HasKeys ? _model.KeysList : null;

        #endregion


        #region Types

        public bool IsGeometric => _model.Type == CipherType.Geometric;

        public bool IsAudible => _model.Type == CipherType.Audible;

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

        public string EncodedText => _model.Encode(_plainText, _charsDelimiter, _wordsDelimiter);

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