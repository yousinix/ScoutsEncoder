using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;
using WindowsApp.ViewModels.Common;
using Core.Models.Ciphers;
using Microsoft.Win32;

namespace WindowsApp.ViewModels
{
    public class NewCipherDialogViewModel : ViewModelBase
    {
        private const string Ext    = ".se.cipher";
        private const string Filter = "ScoutsEncoder Cipher|*" + Ext;

        private FileStream _fileStream;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Cipher));

        private string _cipherName;
        public string CipherName
        {
            get => _cipherName;
            set => SetField(ref _cipherName, value);
        }

        public List<CharMappingViewModel> KeysMapping { get; set; } = new List<CharMappingViewModel>();

        public Cipher NewCipher => new Cipher
        {
            Name = CipherName,
            CharactersSets = { new CharactersSet { Characters = KeysMapping.Select(m => m.Encoding).ToList() } }
        };

        public ICommand ImportCipher { get; set; }
        public ICommand ExportCipher { get; set; }

        public NewCipherDialogViewModel()
        {
            ImportCipher = new CommandBase(_ => ExecuteImportCipher());
            ExportCipher = new CommandBase(_ => ExecuteExportCipher());
            foreach (var c in NewCipher.Language.Characters)
            {
                KeysMapping.Add(new CharMappingViewModel { Character = c });
            }
        }

        private void ExecuteImportCipher()
        {
            var openFileDialog = new OpenFileDialog { Filter = Filter };
            if (openFileDialog.ShowDialog() != true) return;

            _fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
            var cipher = (Cipher) _xmlSerializer.Deserialize(_fileStream);
            PopulateView(cipher);
            _fileStream.Close();
        }

        private void ExecuteExportCipher()
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = CipherName,
                DefaultExt = Ext,
                Filter = Filter
            };
            
            if (saveFileDialog.ShowDialog() != true) return;
            
            _fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            _xmlSerializer.Serialize(_fileStream, NewCipher);
            _fileStream.Close();
        }

        private void PopulateView(Cipher cipher)
        {
            CipherName = cipher.Name;
            for (var i = 0; i < cipher.Characters.Count; i++)
            {
                KeysMapping[i].Encoding = cipher.Characters[i];
            }
        }

        public void Reset()
        {
            CipherName = "";
            foreach (var m in KeysMapping)
            {
                m.Encoding = "";
            }
        }
    }
}