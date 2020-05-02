using Core.Models.Ciphers;
using System.Collections.Generic;
using WindowsApp.ViewModels.Common;

namespace WindowsApp.ViewModels
{
    public sealed class CipherViewModel : ViewModelBase
    {
        #region Model

        private Cipher _model;
        public Cipher Model
        {
            get => _model;
            set => SetField(ref _model, value, ResetIndices)
                .WithDependents(nameof(HasSets),   nameof(Sets), nameof(SetIndex)) // Sets
                .WithDependents(nameof(HasKeys),   nameof(Keys), nameof(KeyIndex)) // Keys
                .WithDependents(nameof(IsAudible), nameof(Name), nameof(Schema))   // Props
                .WithDependents(nameof(EncodedText));
        }

        public bool IsAudible => _model.Type == CipherType.Audible;

        public string Name => _model.Name;

        public string Schema => _model.GetSchema();


        #endregion


        #region Sets

        public bool HasSets => _model.CharactersSets.Count > 1;

        public int SetIndex
        {
            get => HasSets ? _model.SetIndex : -1;
            set => SetProp(() => _model.SetIndex, v => _model.SetIndex = v, value, ResetKeyIndex)
                .WithDependents(nameof(Keys),   nameof(KeyIndex))  // Keys
                .WithDependents(nameof(Schema), nameof(EncodedText));
        }

        public IEnumerable<CharactersSet> Sets => HasSets ? _model.CharactersSets : null;

        #endregion


        #region Keys

        public bool HasKeys => _model.Key.IsEnabled;

        public int KeyIndex
        {
            get => HasKeys ? _model.Key.Base : -1;
            set => SetProp(() => _model.Key.Base, v => _model.Key.Base = v, value)
                .WithDependents(nameof(Schema), nameof(EncodedText));
        }

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
            _model.SetIndex = 0;
            _model.Key.Base = 0;
        }

        private void ResetKeyIndex()
        {
            _model.Key.Base = 0;
        }

        #endregion

    }
}