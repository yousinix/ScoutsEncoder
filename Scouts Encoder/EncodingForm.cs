using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scouts_Encoder
{
    public partial class EncodingForm : Form
    {
        public EncodingForm()
        {
            InitializeComponent();
        }


        private List<string> arabicLetters = new List<string>
                                             {"ا", "ب", "ت", "ث", "ج", "ح", "خ",
                                              "د", "ذ", "ر", "ز", "س", "ش", "ص",
                                              "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                                              "ك", "ل", "م", "ن", "ه", "و", "ي"};

        private string[] numericCode       = {"١" , "٢" , "٣" , "٤" , "٥" , "٦" , "٧" ,
                                              "٨" , "٩" , "١٠", "١١", "١٢", "١٣", "١٤",
                                              "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                                              "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"};
                                           
        private string[] jesusCode         = {"ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                                              "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                                             "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                                             "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"};
                                           
        private string[] invertedCode      = {"ي", "و", "ه", "ن", "م", "ل", "ك",
                                              "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                                              "ص", "ش", "س", "ز", "ر", "ذ", "د",
                                              "خ", "ح", "ج", "ث", "ت", "ب", "ا"};

                                           
        private string[] morseCode         = {"(•-)"  , "(-•••)", "(-)"   , "(-•-•)", "(•---)" , "(••••)", "(---)" ,
                                              "(-••)" , "(--••)", "(•-•)" , "(---•)", "(•••)"  , "(----)", "(-••-)",
                                              "(•••-)", "(••-)" , "(-•--)", "(•-•-)", "(--•)"  , "(••-•)", "(--•-)",
                                              "(-•-)" , "(•-••)", "(--)"  , "(-•)"  , "(••-••)", "(•--)" , "(••)"  };

        private string[] clockwiseCode     = {"١:١٢", "١:١" , "١:٢" , "١:٣" , "١:٤" , "١:٥" , "١:٦",
                                              "١:٧" , "١:٨" , "١:٩" , "١:١٠", "١:١١", "٢:١٢", "٢:١",
                                              "٢:٢" , "٢:٣" , "٢:٤" , "٢:٥" , "٢:٦" , "٢:٧" , "٢:٨",
                                              "٢:٩" , "٢:١٠", "٢:١١", "٣:١٢", "٣:١" , "٣:٢" , "٣:٣"};

        private string[] antiClockwiseCode = {"١:١٢", "١:١١", "١:١٠", "١:٩" , "١:٨" , "١:٧" , "١:٦" ,
                                              "١:٥" , "١:٤" , "١:٣" , "١:٢" , "١:١" , "٢:١٢", "٢:١١",
                                              "٢:١٠", "٢:٩" , "٢:٨" , "٢:٧" , "٢:٦" , "٢:٥" , "٢:٤" ,
                                              "٢:٣" , "٢:٢" , "٢:١" , "٣:١٢", "٣:١١", "٣:١٠", "٣:٩" };

        private string[] mobile01Code      = {"٣"   , "٢"   , "٢٢"    , "٢٢٢" , "٦"   , "٦٦" , "٦٦٦"  ,
                                              "٥"   , "٥٥"  , "٥٥٥"   , "٥٥٥٥", "٤"   , "٤٤" , "٤٤٤"  ,
                                              "٤٤٤٤", "٩"   , "٩٩"    , "٩٩٩" , "٩٩٩٩", "٨"  , "٨٨"   ,
                                              "٨٨٨" , "٨٨٨٨", "٨٨٨٨٨", "٧"    , "٧٧"  , "٧٧٧", "٧٧٧٧"};

        private string[] mobile02Code      = {"٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                                              "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                                              "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                                              "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"};

        private string[] manuscriptCode    = {"ا ", "ب ", "ت ", "ث ", "ج ", "ح ", "خ ",
                                              "د ", "ذ ", "ر ", "ز ", "س ", "ش ", "ص ",
                                              "ض ", "ط ", "ظ ", "ع ", "غ ", "ف ", "ق ",
                                              "ك ", "ل ", "م ", "ن ", "ه ", "و ", "ي "};

        private int codeIndex;
        private int shiftingKey;
        private string textCopy;
        private bool isDashesChecked  = true;
        private bool isSlashesChecked = true;
        private bool isCharactersSpacingChecked = true;
        private bool isWordsSpacingChecked      = true;

        private void replaceOddCharacters()
        {
            textCopy = InputTextBox.Text
                      .Replace("أ", "ا")
                      .Replace("إ", "ا")
                      .Replace("آ", "ا")
                      .Replace("ء", "ا")
                      .Replace("ة", "ه")
                      .Replace("ؤ", "و")
                      .Replace("ى", "ي")
                      .Replace("ئ", "ي");
        }

        private void encode(string[] code)
        {
            int index;
            for (int i = 0; i <= textCopy.Length - 1; i++)
            {
                index = arabicLetters.IndexOf(textCopy[i].ToString());
                if (index == -1)
                {
                    if (textCopy[i] == ' ')
                    {
                        if (isSlashesChecked && isWordsSpacingChecked)
                            OutputTextBox.Text += "  /  ";
                        else if (!isSlashesChecked && !isWordsSpacingChecked)
                            OutputTextBox.Text += " ";
                        else if (isSlashesChecked && !isWordsSpacingChecked)
                            OutputTextBox.Text += " / ";
                        else if (!isSlashesChecked && isWordsSpacingChecked)
                            OutputTextBox.Text += "   ";
                    }
                    else if (Char.IsPunctuation(textCopy[i]))
                        OutputTextBox.Text += " " + textCopy[i];
                    else
                        OutputTextBox.Text += textCopy[i];
                }
                else
                {
                    index += shiftingKey;
                    if (index >= code.Length)
                        index -= code.Length;
                    OutputTextBox.Text += code[index];

                    if (i + 1 <= textCopy.Length - 1) //check if (i + 1) is an existing index
                        if (textCopy[i + 1] != ' ' && textCopy[i + 1] != '\r' && !Char.IsPunctuation(textCopy[i + 1]))
                            if (isDashesChecked && isCharactersSpacingChecked)
                                OutputTextBox.Text += " - ";
                            else if (!isDashesChecked && !isCharactersSpacingChecked)
                                OutputTextBox.Text += "";
                            else if (isDashesChecked && !isCharactersSpacingChecked)
                                OutputTextBox.Text += "-";
                            else if (!isDashesChecked && isCharactersSpacingChecked)
                                OutputTextBox.Text += " ";
                }
            }
        }

        private void showEncodingKey(string[] code)
        {
            int index;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    index = i + j * 7 + shiftingKey;
                    if (index >= code.Length)
                        index -= code.Length;
                    OutputTextBox.Text += (arabicLetters[i + j * 7] + " = " + code[index + 0]).PadRight(13);
                }
                OutputTextBox.Text += "\r\n";
            }       
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = "";
            replaceOddCharacters();

            switch (codeIndex)
            {
                case 0:
                    encode(jesusCode);
                    break;

                case 1:
                    encode(numericCode);
                    break;

                case 2:
                    encode(invertedCode);
                    break;

                case 3:
                    if (shiftingKey == 0)
                        encode(clockwiseCode);
                    if (shiftingKey == 1)
                    {
                        shiftingKey = 0;
                        encode(antiClockwiseCode);
                        shiftingKey = 1;
                    }
                    break;

                case 4:
                    if (shiftingKey == 0)
                        encode(mobile01Code);
                    if (shiftingKey == 1)
                    {
                        shiftingKey = 0;
                        encode(mobile02Code);
                        shiftingKey = 1;
                    }
                    break;

                case 5:
                    encode(morseCode);
                    break;

                case 6:
                    if (!isSlashesChecked && !isWordsSpacingChecked)
                        textCopy = textCopy.Replace(" ", "");
                    encode(manuscriptCode);
                    break;
            }

        }

        private void ShowKeyButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = "";

            switch (codeIndex)
            {
                case 0:
                    showEncodingKey(jesusCode);
                    break;

                case 1:
                    showEncodingKey(numericCode);
                    break;

                case 2:
                    showEncodingKey(invertedCode);
                    break;

                case 3:
                    if (shiftingKey == 0)
                        showEncodingKey(clockwiseCode);
                    if (shiftingKey == 1)
                    {
                        shiftingKey = 0;
                        showEncodingKey(antiClockwiseCode);
                        shiftingKey = 1;
                    }
                    break;

                case 4:
                    if (shiftingKey == 0)
                        showEncodingKey(mobile01Code);
                    if (shiftingKey == 1)
                    {
                        shiftingKey = 0;
                        showEncodingKey(mobile02Code);
                        shiftingKey = 1;
                    }
                    break;

                case 5:
                    showEncodingKey(morseCode);
                    OutputTextBox.Text = OutputTextBox.Text.Replace("(", "").Replace(")", "");
                    break;

                case 6:
                    showEncodingKey(manuscriptCode);
                    break;
            }
        }

        private void CodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CodesComboBox.SelectedItem != null)
            {
                codeIndex = CodesComboBox.SelectedIndex;
                EncodeButton .Enabled = true;
                ShowKeyButton.Enabled = true;
                CopyButton   .Enabled = true;
                ClearButton  .Enabled = true;
                KeysComboBox.Items.Clear();
                shiftingKey = 0;

                switch (codeIndex)
                {
                    case 0:
                        KeysComboBox.Text = "أ = " + jesusCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysComboBoxItems(jesusCode));
                        break;
                        
                    case 1:
                        KeysComboBox.Text = "أ = " + numericCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysComboBoxItems(numericCode));
                        break;

                    case 2:
                        KeysComboBox.Text = "أ = " + invertedCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysComboBoxItems(invertedCode));
                        break;

                    case 3:
                        KeysComboBox.Text = "مع عقارب الساعة";
                        KeysComboBox.Items.AddRange(new object[] {"مع عقارب الساعة", "عكس عقارب الساعة"});
                        break;

                    case 4:
                        KeysComboBox.Text = "أ = " + mobile01Code[0];
                        KeysComboBox.Items.AddRange(new object[] { "أ = " + mobile01Code[0], "أ = " + mobile02Code[0] });
                        break;

                    case 5:
                        KeysComboBox.Text =    "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("لا يوجد مفاتيح");
                        break;

                    case 6:
                        KeysComboBox.Text = "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("لا يوجد مفاتيح");
                        break;
                }
            }
        }

        private void KeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftingKey = KeysComboBox.SelectedIndex;
        }

        private string[] initializeKeysComboBoxItems(string[] code)
        {
            string[] items = new string[code.Length];
            for (int i = 0; i < code.Length; i++)
            {
                items[i] = "أ = " + code[i];
            }
            return items;
        }



        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputTextBox .Text = "";
            OutputTextBox.Text = "";
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputTextBox.Text);
        }

        private void DashesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isDashesChecked = DashesCheckBox.Checked;
        }

        private void SlashesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isSlashesChecked = SlashesCheckBox.Checked;
        }

        private void CharactersSpacingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isCharactersSpacingChecked = CharactersSpacingCheckBox.Checked;
        }

        private void WordsSpacingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isWordsSpacingChecked = WordsSpacingCheckBox.Checked;
        }


        //Placeholder Text Events
        private void InputTextBox_Enter(object sender, EventArgs e)
        {
            if (InputTextBox.Text == "ادخل الشفرة هنا ...")
                InputTextBox.Text = "";
        }

        private void InputTextBox_Leave(object sender, EventArgs e)
        {
            if (InputTextBox.Text == "")
                InputTextBox.Text = "ادخل الشفرة هنا ...";
        }

    }
}
