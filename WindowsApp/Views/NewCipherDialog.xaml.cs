using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Core.Data;
using Core.Models.Ciphers;
using Microsoft.Win32;

namespace WindowsApp.Views
{
    public partial class NewCipherDialog
    {
        private const string Ext    = ".se.cipher";
        private const string Filter = "ScoutsEncoder Cipher|*" + Ext;

        private FileStream _fileStream;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(RegularCipher));
        private readonly List<TextBox> _lettersTextBoxes = new List<TextBox>();

        public WindowsApp.Views.MainWindow Context { get; set; }


        public NewCipherDialog()
        {
            InitializeComponent();

            foreach (var stackPanel in Enumerable.OfType<StackPanel>(MainGrid.Children))
            {
                var children = stackPanel.Children;
                _lettersTextBoxes.AddRange(children.OfType<TextBox>());
            }
        }

        private RegularCipher GetNewCipher() => new RegularCipher
        {
            Name = NewCipherNameTextBox.Text,
            Characters = _lettersTextBoxes.Select(t => t.Text).ToList()
        };

        private void CloseDialog()
        {
            _lettersTextBoxes.ForEach(t => t.Clear());
            NewCipherNameTextBox.Clear();
            Context.DialogHost.IsOpen = false;
        }

        private void CloseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog();
        }

        private void AddCipherButton_Click(object sender, RoutedEventArgs e)
        {
            CiphersList.Instance.Add(GetNewCipher());
            Context.CiphersComboBox.SelectedIndex = CiphersList.Instance.Count - 1;
            CloseDialog();
            Context.Snackbar.MessageQueue.Enqueue("Cipher Added!");
        }

        private void SaveCipherButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = NewCipherNameTextBox.Text,
                DefaultExt = Ext,
                Filter = Filter
            };

            if (saveFileDialog.ShowDialog() != true) return;

            _fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            _xmlSerializer.Serialize(_fileStream, GetNewCipher());
            _fileStream.Close();
        }

        private void ImportCipherButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Filter
            };

            if (openFileDialog.ShowDialog() != true) return;

            _fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
            var newCipher = _xmlSerializer.Deserialize(_fileStream) as RegularCipher;
            _fileStream.Close();
            PopulateView(newCipher);
        }

        private void PopulateView(CipherBase cipher)
        {
            NewCipherNameTextBox.Text = cipher.Name;
            for (var i = 0; i < cipher.Characters.Count; i++)
            {
                _lettersTextBoxes[i].Text = cipher.Characters[i];
            }
        }

    }
}
