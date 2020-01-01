using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace ScoutsEncoder
{
    public partial class NewCipherDialog
    {
        private const string Ext    = ".se.cipher";
        private const string Filter = "ScoutsEncoder Cipher|*" + Ext;

        private FileStream _fileStream;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Cipher));
        private readonly List<TextBox> _lettersTextBoxes = new List<TextBox>();

        public MainWindow Context { get; set; }


        public NewCipherDialog()
        {
            InitializeComponent();

            foreach (var stackPanel in MainGrid.Children.OfType<StackPanel>())
            {
                var children = stackPanel.Children;
                _lettersTextBoxes.AddRange(children.OfType<TextBox>());
            }
        }

        private Cipher GetNewCipher() => new Cipher
        {
            DisplayName = NewCipherNameTextBox.Text,
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
            var newCipher = _xmlSerializer.Deserialize(_fileStream) as Cipher;
            _fileStream.Close();
            PopulateView(newCipher);
        }

        private void PopulateView(Cipher cipher)
        {
            NewCipherNameTextBox.Text = cipher.DisplayName;
            for (var i = 0; i < cipher.Characters.Count; i++)
            {
                _lettersTextBoxes[i].Text = cipher.Characters[i];
            }
        }

    }
}
