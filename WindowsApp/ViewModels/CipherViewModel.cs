using Core.Models.Ciphers;
using System.Collections.Generic;
using WindowsApp.ViewModels.Common;

namespace WindowsApp.ViewModels
{
    public sealed class CipherViewModel : ViewModelBase
    {
        #region Model

        private CipherBase _model;
        public CipherBase Model
        {
            get => _model;
            set => SetField(ref _model, value, ResetIndices)
                .WithDependents(nameof(HasStandards), nameof(Standards), nameof(StandardIndex)) // Standards
                .WithDependents(nameof(HasKeys),      nameof(Keys),      nameof(KeyIndex))      // Keys
                .WithDependents(nameof(IsAudible),    nameof(Name),      nameof(Schema))        // Props
                .WithDependents(nameof(EncodedText));
        }

        public bool IsAudible => _model.Type == CipherType.Audible;

        public string Name => Model.Name;

        public string Schema => Model.GetSchema();


        #endregion


        #region Standards

        public int StandardIndex
        {
            get => HasStandards ? ((MultiStandardCipher)_model).StandardIndex : -1;
            set
            {
                if (!(_model !is MultiStandardCipher m)) return;
                SetProp(() => m.StandardIndex, v => m.StandardIndex = v, value, ResetKeyIndex)
                    .WithDependents(nameof(Keys),   nameof(KeyIndex))  // Keys
                    .WithDependents(nameof(Schema), nameof(EncodedText));
            }
        }

        public bool HasStandards => _model is MultiStandardCipher;

        public IEnumerable<CipherStandard> Standards => HasStandards ? ((MultiStandardCipher)_model).Standards : null;

        #endregion


        #region Keys

        public int KeyIndex
        {
            get => HasKeys ? _model.Key.Base : -1;
            set => SetProp(() => _model.Key.Base, v => _model.Key.Base = v, value)
                .WithDependents(nameof(Schema), nameof(EncodedText));
        }

        public bool HasKeys => _model.Key.IsEnabled;

        public IEnumerable<string> Keys => HasKeys ? _model.KeysList : null;

        #endregion


        #region Delimiters

        private string _charsDelimiter = " - ";
        public string CharsDelimiter
        {
            get => _charsDelimiter;
            set => SetField(ref _charsDelimiter, value)
                .WithDependents(nameof(EncodedText));
        }

        private string _wordsDelimiter = "  /  ";
        public string WordsDelimiter
        {
            get => _wordsDelimiter;
            set => SetField(ref _wordsDelimiter, value)
                .WithDependents(nameof(EncodedText));
        }

        #endregion


        #region I/O

        private string _plainText = string.Empty;
        public string PlainText
        {
            get => _plainText;
            set => SetField(ref _plainText, value)
                .WithDependents(nameof(EncodedText));
        }

        public string EncodedText => _model.Encode(_plainText, _charsDelimiter, _wordsDelimiter);

        #endregion


        #region Methods

        public string Encode(string text)
        {
            return _model.Encode(text, _charsDelimiter, _wordsDelimiter);
        }

        private void ResetIndices()
        {
            if (_model is MultiStandardCipher m) m.StandardIndex = 0;
            _model.Key.Base = 0;
        }

        private void ResetKeyIndex()
        {
            _model.Key.Base = 0;
        }

        #endregion

    }
}