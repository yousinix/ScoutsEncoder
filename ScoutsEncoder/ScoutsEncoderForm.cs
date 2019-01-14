/// <ScoutsEncoder>
/// This software encodes plain text into scouts' Arabic ciphers.
/// </ScoutsEncoder>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScoutsEncoder
{
    public partial class ScoutsEncoderForm : Form
    {
        public ScoutsEncoderForm()
        {
            InitializeComponent();
            InitializeCiphersComboBox();
        }


        //Ciphers
        private List<string> arabicLetters = new List<string>
                                               {"ا", "ب", "ت", "ث", "ج", "ح", "خ",
                                                "د", "ذ", "ر", "ز", "س", "ش", "ص",
                                                "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                                                "ك", "ل", "م", "ن", "ه", "و", "ي"};
        // Cipher 00                        
        private string[] jesusCipher         = {"ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                                                "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                                                "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                                                "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"};
                                            
        // Cipher 01                        
        private string[] numericCipher       = {"١" , "٢" , "٣" , "٤" , "٥" , "٦" , "٧" ,
                                                "٨" , "٩" , "١٠", "١١", "١٢", "١٣", "١٤",
                                                "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                                                "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"};
                                            
        // Cipher 02                        
        private string[] invertedCipher      = {"ي", "و", "ه", "ن", "م", "ل", "ك",
                                                "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                                                "ص", "ش", "س", "ز", "ر", "ذ", "د",
                                                "خ", "ح", "ج", "ث", "ت", "ب", "ا"};
                                            
        // Cipher 03                        
        private string[] caesarCipher        = {"ا", "ب", "ت", "ث", "ج", "ح", "خ",
                                                "د", "ذ", "ر", "ز", "س", "ش", "ص",
                                                "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                                                "ك", "ل", "م", "ن", "ه", "و", "ي"};
                                            
        // Cipher 04                        
        private string[] manuscriptCipher    = {"ا ", "ب ", "ت ", "ث ", "ج ", "ح ", "خ ",
                                                "د ", "ذ ", "ر ", "ز ", "س ", "ش ", "ص ",
                                                "ض ", "ط ", "ظ ", "ع ", "غ ", "ف ", "ق ",
                                                "ك ", "ل ", "م ", "ن ", "ه ", "و ", "ي "};
                                            
        // Cipher 05                        
        private string[] morseCipher         = {"(•-)"  , "(-•••)", "(-)"   , "(-•-•)", "(•---)" , "(••••)", "(---)" ,
                                                "(-••)" , "(--••)", "(•-•)" , "(---•)", "(•••)"  , "(----)", "(-••-)",
                                                "(•••-)", "(••-)" , "(-•--)", "(•-•-)", "(--•)"  , "(••-•)", "(--•-)",
                                                "(-•-)" , "(•-••)", "(--)"  , "(-•)"  , "(••-••)", "(•--)" , "(••)"  };
                                            
        // Cipher 06                        
        private string[] binaryCipher        = {"00001", "00010", "00011", "00100", "00101", "00110", "00111",
                                                "01000", "01001", "01010", "01011", "01100", "01101", "01110",
                                                "01111", "10000", "10001", "10010", "10011", "10100", "10101",
                                                "10110", "10111", "11000", "11001", "11010", "11011", "11100"};
                                            
        // Cipher 07                        
        private string[] compassCipher       = {"N(١)", "NE(١)", "E(١)", "SE(١)", "S(١)", "SW(١)", "W(١)", "NW(١)",
                                                "N(٢)", "NE(٢)", "E(٢)", "SE(٢)", "S(٢)", "SW(٢)", "W(٢)", "NW(٢)",
                                                "N(٣)", "NE(٣)", "E(٣)", "SE(٣)", "S(٣)", "SW(٣)", "W(٣)", "NW(٣)",
                                                "N(٤)", "NE(٤)", "E(٤)", "SE(٤)"};
                                            
        // Cipher 08 - 01                   
        private string[] clockwiseCipher     = {"١:١٢", "١:١" , "١:٢" , "١:٣" , "١:٤" , "١:٥" , "١:٦",
                                                "١:٧" , "١:٨" , "١:٩" , "١:١٠", "١:١١", "٢:١٢", "٢:١",
                                                "٢:٢" , "٢:٣" , "٢:٤" , "٢:٥" , "٢:٦" , "٢:٧" , "٢:٨",
                                                "٢:٩" , "٢:١٠", "٢:١١", "٣:١٢", "٣:١" , "٣:٢" , "٣:٣"};
                                            
        // Cipher 08 - 02
        private string[] antiClockwiseCipher = {"١:١٢", "١:١١", "١:١٠", "١:٩" , "١:٨" , "١:٧" , "١:٦" ,
                                                "١:٥" , "١:٤" , "١:٣" , "١:٢" , "١:١" , "٢:١٢", "٢:١١",
                                                "٢:١٠", "٢:٩" , "٢:٨" , "٢:٧" , "٢:٦" , "٢:٥" , "٢:٤" ,
                                                "٢:٣" , "٢:٢" , "٢:١" , "٣:١٢", "٣:١١", "٣:١٠", "٣:٩" };
                                           
        // Cipher 09 - 01                  
        private string[] mobile01Cipher      = {"٣"   , "٢"   , "٢٢"    , "٢٢٢" , "٦"   , "٦٦" , "٦٦٦"  ,
                                                "٥"   , "٥٥"  , "٥٥٥"   , "٥٥٥٥", "٤"   , "٤٤" , "٤٤٤"  ,
                                                "٤٤٤٤", "٩"   , "٩٩"    , "٩٩٩" , "٩٩٩٩", "٨"  , "٨٨"   ,
                                                "٨٨٨" , "٨٨٨٨", "٨٨٨٨٨", "٧"    , "٧٧"  , "٧٧٧", "٧٧٧٧"};
                                           
        // Cipher 09 - 02                  
        private string[] mobile02Cipher      = {"٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                                                "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                                                "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                                                "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"};
                                           
        // Cipher 10                       
        private string[] xCipher             = {"V(١)", "V(٢)", "V(٣)", "V(٤)", "V(٥)", "V(٦)", "V(٧)",
                                                ">(١)", ">(٢)", ">(٣)", ">(٤)", ">(٥)", ">(٦)", ">(٧)",
                                                "Λ(١)", "Λ(٢)", "Λ(٣)", "Λ(٤)", "Λ(٥)", "Λ(٦)", "Λ(٧)",
                                                "<(١)", "<(٢)", "<(٣)", "<(٤)", "<(٥)", "<(٦)", "<(٧)"};
                                           
        // Cipher 11                       
        private string[] starCipher          = {"▲١", "▲٢", "▲٣", "▲٤", "▲٥", "▲٦", "▲٧",
                                                "▶١", "▶٢", "▶٣", "▶٤", "▶٥", "▶٦", "▶٧",
                                                "◀١", "◀٢", "◀٣", "◀٤", "◀٥", "◀٦", "◀٧",
                                                "▼١", "▼٢", "▼٣", "▼٤", "▼٥", "▼٦", "▼٧"};
                                           
        // Cipher 12                       
        private string[] rhombusCipher       = {"١◣", "١◢", "١◤", "١◥",
                                                "٢◣", "٢◢", "٢◤", "٢◥",
                                                "٣◣", "٣◢", "٣◤", "٣◥",
                                                "٤◣", "٤◢", "٤◤", "٤◥",
                                                "٥◣", "٥◢", "٥◤", "٥◥",
                                                "٦◣", "٦◢", "٦◤", "٦◥",
                                                "٧◣", "٧◢", "٧◤", "٧◥"};
                                           
        // Cipher 13                       
        private string[] triangleCipher      = {"١▲",
                                                "٢◣◼",  "٢◼◢",
                                                "٣◣◼", "٣◼(١)",  "٣◼◢",
                                                "٤◣◼", "٤◼(١)", "٤◼(٢)",  "٤◼◢",
                                                "٥◣◼", "٥◼(١)", "٥◼(٢)", "٥◼(٣)",  "٥◼◢",
                                                "٦◣◼", "٦◼(١)", "٦◼(٢)", "٦◼(٣)", "٦◼(٤)",  "٦◼◢",
                                                "٧◣◼", "٧◼(١)", "٧◼(٢)", "٧◼(٣)", "٧◼(٤)", "٧◼(٥)", "٧◼◢"};


        ///  Steps for adding a new cipher:
        ///  ----------------------------
        ///  1] Create an array of strings from the elements of the cipher.
        ///     (use the "string[] newCipher" array template below as a guide)
        ///     
        ///  2] Add the new cipher name in the InitializeCiphersComboBox function.
        ///  
        ///  3] Go to each of the following events & follow the instructions at the end of each event:
        ///     - CiphersComboBox_SelectedIndexChanged
        ///     - EncodeButton_Click
        ///     - ShowKeyButton_Click


        /////////////////////////// NEW CIPHER : ADD HERE ///////////////////////////
        ///  // Cipher XX (Array Template)                                        ///
        ///  private string[] newCipher = {"X", "X", "X", "X", "X", "X", "X",     ///
        ///                                "X", "X", "X", "X", "X", "X", "X",     ///
        ///                                "X", "X", "X", "X", "X", "X", "X",     ///
        ///                                "X", "X", "X", "X", "X", "X", "X"};    ///
        /////////////////////////////////////////////////////////////////////////////






        // Variables
        private int  cipherIndex;
        private int  keyIndex;
        private bool isDashesChecked       = true;
        private bool isSlashesChecked      = true;
        private bool isCharsSpacingChecked = true;
        private bool isWordsSpacingChecked = true;




        // Processing Functions
        private void InitializeCiphersComboBox()
        {
            CiphersComboBox.Items.AddRange(new object[] {
            // Cipher 00
            "  " + "يسوع",

            // Cipher 01
            "  " + "رقمية",
            
            // Cipher 02
            "  " + "عكسية",
            
            // Cipher 03
            "  " + "قيصر",
            
            // Cipher 04
            "  " + "عربي مفرط",
            
            // Cipher 05
            "  " + "المورس",
            
            // Cipher 06
            "  " + "الأعداد الثنائية",
            
            // Cipher 07
            "  " + "البوصلة",
            
            // Cipher 08
            "  " + "الساعة",
            
            // Cipher 09
            "  " + "الجوال",
            
            // Cipher 10
            "  " + "إكس",
            
            // Cipher 11
            "  " + "النجمة",
            
            // Cipher 12
            "  " + "المعين",
            
            // Cipher 13
            "  " + "المثلث",

            // Cipher XX
            //  "  " + "NEW-CIPHER-NAME-HERE",

            });
        }


        private string ModifyText(string textToModify)
        {
            // Replace odd characters with known characters
            string modifiedText = textToModify
                                  .Replace("أ", "ا")
                                  .Replace("إ", "ا")
                                  .Replace("آ", "ا")
                                  .Replace("ء", "ا")
                                  .Replace("ة", "ه")
                                  .Replace("ؤ", "و")
                                  .Replace("ى", "ي")
                                  .Replace("ئ", "ي");

            // Replace multiple spaces with a single space
            modifiedText = Regex.Replace(modifiedText, " {2,}", " ");

            return modifiedText;
        }

        private string ModifyInputTextForAudioExport(string textToModify)
        {
            // Remove all output styles
            isDashesChecked  = false;
            isSlashesChecked = false;
            isCharsSpacingChecked = false;
            isWordsSpacingChecked = false;

            // Encode input text using the previous output styles
            string modifiedText = Encode(textToModify, morseCipher);

            // Remove anything that doesn't belong to the morse cipher
            modifiedText = Regex.Replace(modifiedText, @"[^\s\-\•\(\)]", "");

            // Simplify string for audio output
            modifiedText = modifiedText
                           .Replace(") (", " ")    // Replace words splitters with spaces
                           .Replace(")(", ".")     // Replace letters splitters with dots
                           .Replace(")", "")       // Remove the bracket at the begining of the string
                           .Replace("(", "")       // Remove the bracket at the end of the string
                           .Replace("\r\n", " ");  // Replace new lines with spaces

            // Replace multiple spaces (resulting from multiple new lines) with a single space
            modifiedText = Regex.Replace(modifiedText, " {2,}", " ");

            // Reset output styles to the chosen ones
            isDashesChecked  = Dashes .Checked;
            isSlashesChecked = Slashes.Checked;
            isCharsSpacingChecked = CharsSpacing.Checked;
            isWordsSpacingChecked = WordsSpacing.Checked;

            // Add 2 whitespaces at the begining and the end of the string
            return "  " + modifiedText + "  ";
        }

        private string Encode(string textToEncode, string[] cipher)
        {
            string inputTextCopy  = ModifyText(textToEncode);
            string outputTextCopy = "";

            int index;
            for (int i = 0; i < inputTextCopy.Length; i++)
            {
                // Search for the character in the list of Arabic letters
                index = arabicLetters.IndexOf(inputTextCopy[i].ToString());

                // If the character is not an Arabic letter
                if (index == -1)
                {
                    // Words output styles
                    if (inputTextCopy[i] == ' ')
                    {
                        if (isSlashesChecked && isWordsSpacingChecked)
                            outputTextCopy += "  /  ";
                        else if (!isSlashesChecked && !isWordsSpacingChecked)
                            outputTextCopy += " ";
                        else if (isSlashesChecked && !isWordsSpacingChecked)
                            outputTextCopy += " / ";
                        else if (!isSlashesChecked && isWordsSpacingChecked)
                            outputTextCopy += "   ";
                    }

                    // Add spaces before punctuation marks
                    // To avoid mixing them up with the encoded characters
                    // as some ciphers may contain punctuation marks
                    else if (Char.IsPunctuation(inputTextCopy[i]))
                        outputTextCopy += " " + inputTextCopy[i];

                    // Add any new line or strange character as is
                    else
                        outputTextCopy += inputTextCopy[i];
                }

                else
                {
                    // Encoding the character
                    index = (index + keyIndex) % 28;
                    outputTextCopy += cipher[index];

                    // Break when i refers to the character before the last one
                    // To avoid out of index errors
                    if (i == inputTextCopy.Length - 2)
                        break;

                    // Characters output styles
                    if (inputTextCopy[i + 1] != ' ' && inputTextCopy[i + 1] != '\r' && !Char.IsPunctuation(inputTextCopy[i + 1]))
                        if (isDashesChecked && isCharsSpacingChecked)
                            outputTextCopy += " - ";
                        else if (!isDashesChecked && !isCharsSpacingChecked)
                            outputTextCopy += "";
                        else if (isDashesChecked && !isCharsSpacingChecked)
                            outputTextCopy += "-";
                        else if (!isDashesChecked && isCharsSpacingChecked)
                            outputTextCopy += " ";
                }
            }

            return outputTextCopy;
        }

        private string ShowEncodingKey(string[] cipher)
        {
            int index;
            string outputTextCopy = "";

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    index = (i + j * 7 + keyIndex) % 28;
                    outputTextCopy += (arabicLetters[i + j * 7] + " = " + cipher[index]).PadRight(12);
                }
                outputTextCopy += "\r\n";
            }

            return outputTextCopy;
        }

        private string[] InitializeKeysList(string[] cipher)
        {
            string[] items = new string[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
            {
                items[i] = "   " + "أ = " + cipher[i];
            }
            return items;
        }

        private void ShowFillShapesCheckbox(bool status)
        {
            if (status)
            {
                OptionsPanel.Size  = OptionsPanel.MaximumSize;
                FillShapes.Visible = true;
                FillShapes.Enabled = true;
            }
            else
            {
                OptionsPanel.Size  = OptionsPanel.MinimumSize;
                FillShapes.Visible = false;
                FillShapes.Enabled = false;
            }
        }


        private void ShowExportAudioButton(bool status)
        {
            if (status)
            {
                ExportAudio.Visible = true;
                ExportAudio.Enabled = true;
            }
            else
            {
                ExportAudio.Visible = false;
                ExportAudio.Enabled = false;
            }
        }


        // SideMenu Buttons
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCipherButton_Click(object sender, EventArgs e)
        {
            DropdownTimer.Start();
        }

        private void CiphersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CiphersComboBox.SelectedItem != null)
            {
                cipherIndex = CiphersComboBox.SelectedIndex;
                KeysComboBox.Items.Clear();
                keyIndex = 0;

                switch (cipherIndex)
                {
                    case 0:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + jesusCipher[0];
                        KeysComboBox.Items.AddRange(InitializeKeysList(jesusCipher));
                        break;

                    case 1:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + numericCipher[0];
                        KeysComboBox.Items.AddRange(InitializeKeysList(numericCipher));
                        break;

                    case 2:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + invertedCipher[0];
                        KeysComboBox.Items.AddRange(InitializeKeysList(invertedCipher));
                        break;

                    case 3:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        string[] items = new string[numericCipher.Length];
                        for (int i = 0; i < numericCipher.Length; i++)
                        {
                            items[i] = "   " + numericCipher[i];
                        }
                        KeysComboBox.Text = "   " + numericCipher[0];
                        KeysComboBox.Items.AddRange(items);
                        break;

                    case 4:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 5:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(true);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 6:
                        ShowFillShapesCheckbox(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 7:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 8:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "  " + "مع عقارب الساعة";
                        KeysComboBox.Items.AddRange(new object[] { "  " + "مع عقارب الساعة",
                                                                   "  " + "عكس عقارب الساعة" });
                        break;

                    case 9:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + mobile01Cipher[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + mobile01Cipher[0],
                                                                   "   " + "أ = " + mobile02Cipher[0] });
                        break;

                    case 10:
                        ShowFillShapesCheckbox(false);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + xCipher[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + xCipher[0],
                                                                   "   " + "أ = " + xCipher[7],
                                                                   "   " + "أ = " + xCipher[14],
                                                                   "   " + "أ = " + xCipher[21] });
                        break;

                    case 11:
                        ShowFillShapesCheckbox(true);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text = "   " + "أ = " + starCipher[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + starCipher[0],
                                                                   "   " + "أ = " + starCipher[7],
                                                                   "   " + "أ = " + starCipher[14],
                                                                   "   " + "أ = " + starCipher[21] });
                        break;

                    case 12:
                        ShowFillShapesCheckbox(true);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 13:
                        ShowFillShapesCheckbox(true);
                        ShowExportAudioButton(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;


                    /////////////////////////// NEW CIPHER : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new cipher in CiphersComboBox)  ///
                    ///     KeysComboBox.Text = FIRST KEY OF THE NEW CIPHER;                  ///
                    ///     KeysComboBox.Items.AddRange(InitializeKeysList(newCipher));       ///
                    ///     **OR**                                                            ///
                    ///     KeysComboBox.Items.AddRange(new object[] {KEY1, KEY2,.... });     ///
                    ///     break;                                                            ///
                    /////////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void KeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyIndex = KeysComboBox.SelectedIndex;
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (CiphersComboBox.Text == "  اختر الشفرة")
            {
                OutputTextBox.Text = "من فضلك اختر الشفرة عن طريق الضغط علي \"إعدادات الشفرة\" ثم اختر الشفرة المناسبة";
            }
            else
            {
                switch (cipherIndex)
                {
                    case 0:
                        OutputTextBox.Text = Encode(InputTextBox.Text, jesusCipher);
                        break;

                    case 1:
                        OutputTextBox.Text = Encode(InputTextBox.Text, numericCipher);
                        break;

                    case 2:
                        OutputTextBox.Text = Encode(InputTextBox.Text, invertedCipher);
                        break;

                    case 3:
                        if (KeysComboBox.SelectedIndex == -1) 
                        {
                            KeysComboBox.SelectedIndex = 0; // If no key is chosen, encode using first key
                        }
                        keyIndex = KeysComboBox.SelectedIndex + 1; // Add one to the chosen key as caesar keys are not zero based
                        OutputTextBox.Text = Encode(InputTextBox.Text, caesarCipher);
                        break;

                    case 4:
                        OutputTextBox.Text = Encode(InputTextBox.Text, manuscriptCipher);
                        if (!isSlashesChecked && !isWordsSpacingChecked)
                            OutputTextBox.Text = OutputTextBox.Text.Replace("  ", " ");
                        break;

                    case 5:
                        OutputTextBox.Text = Encode(InputTextBox.Text, morseCipher);
                        break;

                    case 6:
                        OutputTextBox.Text = Encode(InputTextBox.Text, binaryCipher);
                        break;
                        
                    case 7:
                        OutputTextBox.Text = Encode(InputTextBox.Text, compassCipher);
                        break;

                    case 8:
                        if (keyIndex == 0)
                            OutputTextBox.Text = Encode(InputTextBox.Text, clockwiseCipher);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            OutputTextBox.Text = Encode(InputTextBox.Text, antiClockwiseCipher);
                            keyIndex = 1;
                        }
                        break;

                    case 9:
                        if (keyIndex == 0)
                            OutputTextBox.Text = Encode(InputTextBox.Text, mobile01Cipher);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            OutputTextBox.Text = Encode(InputTextBox.Text, mobile02Cipher);
                            keyIndex = 1;
                        }
                        break;

                    case 10:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        OutputTextBox.Text = Encode(InputTextBox.Text, xCipher);
                        break;

                    case 11:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        OutputTextBox.Text = Encode(InputTextBox.Text, starCipher);
                        break;

                    case 12:
                        OutputTextBox.Text = Encode(InputTextBox.Text, rhombusCipher);
                        break;

                    case 13:
                        OutputTextBox.Text = Encode(InputTextBox.Text, triangleCipher);
                        break;


                    /////////////////////////// NEW CIPHER : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new cipher in CiphersComboBox)  ///
                    ///     OutputTextBox.Text = Encode(newCipher);                           ///
                    ///     break;                                                            ///
                    /////////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void ShowKeyButton_Click(object sender, EventArgs e)
        {
            if (CiphersComboBox.Text == "  اختر الشفرة")
            {
                OutputTextBox.Text = "من فضلك اختر الشفرة عن طريق الضغط علي \"إعدادات الشفرة\" ثم اختر الشفرة المناسبة";
            }
            else
            {
                switch (cipherIndex)
                {
                    case 0:
                        OutputTextBox.Text = ShowEncodingKey(jesusCipher);
                        break;

                    case 1:
                        OutputTextBox.Text = ShowEncodingKey(numericCipher);
                        break;

                    case 2:
                        OutputTextBox.Text = ShowEncodingKey(invertedCipher);
                        break;

                    case 3:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex + 1;
                        OutputTextBox.Text = ShowEncodingKey(caesarCipher);
                        break;

                    case 4:
                        OutputTextBox.Text = ShowEncodingKey(manuscriptCipher);
                        break;

                    case 5:
                        OutputTextBox.Text = ShowEncodingKey(morseCipher).Replace("(", "").Replace(")", "");
                        break;

                    case 6:
                        OutputTextBox.Text = ShowEncodingKey(binaryCipher);
                        break;

                    case 7:
                        OutputTextBox.Text = ShowEncodingKey(compassCipher);
                        break;

                    case 8:
                        if (keyIndex == 0)
                            OutputTextBox.Text = ShowEncodingKey(clockwiseCipher);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            OutputTextBox.Text = ShowEncodingKey(antiClockwiseCipher);
                            keyIndex = 1;
                        }
                        break;

                    case 9:
                        if (keyIndex == 0)
                            OutputTextBox.Text = ShowEncodingKey(mobile01Cipher);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            OutputTextBox.Text = ShowEncodingKey(mobile02Cipher);
                            keyIndex = 1;
                        }
                        break;

                    case 10:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        OutputTextBox.Text = ShowEncodingKey(xCipher);
                        break;

                    case 11:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        OutputTextBox.Text = ShowEncodingKey(starCipher);
                        break;

                    case 12:
                        OutputTextBox.Text = ShowEncodingKey(rhombusCipher);
                        break;

                    case 13:
                        OutputTextBox.Text = ShowEncodingKey(triangleCipher);
                        break;


                    /////////////////////////// NEW CIPHER : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new cipher in CiphersComboBox)  ///
                    ///     OutputTextBox.Text = ShowEncodingKey(newCipher);                  ///
                    ///     break;                                                            ///
                    /////////////////////////////////////////////////////////////////////////////
                }
            }
        }

        // Links Buttons
        private void GitHubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.github.com/YoussefRaafatNasry/scouts-encoder");
        }

        private void DocsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com");
        }

        private void WebsiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youssefraafatnasry.github.io/ScoutsEncoder/");
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youssefraafatnasry.github.io/ScoutsEncoder/docs/all/");
        }


        private void ThemeButton_Click(object sender, EventArgs e)
        {
            if (ThemeButton.Text == "Dark Theme")
            {
                //ThemeButton
                ThemeButton  .Text      = "Light Theme";
                ThemeButton  .BackColor = Color.WhiteSmoke;
                ThemeButton  .ForeColor = Color.Black;


                //Form & Panels
                this         .BackColor = ColorTranslator.FromHtml("#2d2d30");
                SideMenu     .BackColor = ColorTranslator.FromHtml("#1c1c1c");
                Title        .BackColor = ColorTranslator.FromHtml("#252526");
                OptionsPanel .BackColor = ColorTranslator.FromHtml("#252526");


                //SideMenu Buttons
                SetCipherButton.BackColor = ColorTranslator.FromHtml("#3e3e42");
                CiphersComboBox.BackColor = ColorTranslator.FromHtml("#3e3e42");
                KeysComboBox   .BackColor = ColorTranslator.FromHtml("#3e3e42");
                EncodeButton   .BackColor = ColorTranslator.FromHtml("#3e3e42");
                ShowKeyButton  .BackColor = ColorTranslator.FromHtml("#3e3e42");
                ReportButton   .BackColor = ColorTranslator.FromHtml("#3e3e42");

                SetCipherButton.ForeColor = ColorTranslator.FromHtml("#ffffff");
                CiphersComboBox.ForeColor = ColorTranslator.FromHtml("#ffffff");
                KeysComboBox   .ForeColor = ColorTranslator.FromHtml("#ffffff");
                EncodeButton   .ForeColor = ColorTranslator.FromHtml("#ffffff");
                ShowKeyButton  .ForeColor = ColorTranslator.FromHtml("#ffffff");
                ReportButton   .ForeColor = ColorTranslator.FromHtml("#ffffff");


                //Labels & Checkboxes
                ScoutsEncoder.ForeColor = ColorTranslator.FromHtml("#ffffff");
                Version      .ForeColor = ColorTranslator.FromHtml("#ffffff");
                OutputOptions.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Dashes       .ForeColor = ColorTranslator.FromHtml("#ffffff");
                Slashes      .ForeColor = ColorTranslator.FromHtml("#ffffff");
                CharsSpacing .ForeColor = ColorTranslator.FromHtml("#ffffff");
                WordsSpacing .ForeColor = ColorTranslator.FromHtml("#ffffff");
                FillShapes   .ForeColor = ColorTranslator.FromHtml("#ffffff");


                //Textboxes
                InputTextBox .BackColor = ColorTranslator.FromHtml("#3e3e42");
                OutputTextBox.BackColor = ColorTranslator.FromHtml("#3e3e42");
                
                InputTextBox .ForeColor = ColorTranslator.FromHtml("#ffffff");
                OutputTextBox.ForeColor = ColorTranslator.FromHtml("#ffffff");


                //Image Buttons                             
                InputCopy    .BackgroundImage = Properties.Resources.LightIcon_Copy;
                InputCut     .BackgroundImage = Properties.Resources.LightIcon_Cut;
                InputPaste   .BackgroundImage = Properties.Resources.LightIcon_Paste;
                InputClear   .BackgroundImage = Properties.Resources.LightIcon_Clear;
                             
                OutputCopy   .BackgroundImage = Properties.Resources.LightIcon_Copy;
                OutputCut    .BackgroundImage = Properties.Resources.LightIcon_Cut;
                OutputPaste  .BackgroundImage = Properties.Resources.LightIcon_Paste;
                OutputClear  .BackgroundImage = Properties.Resources.LightIcon_Clear;
                ExportAudio  .BackgroundImage = Properties.Resources.LightIcon_ExportAudio;

                ExitButton   .BackgroundImage = Properties.Resources.LightIcon_Clear;
                GitHubButton .BackgroundImage = Properties.Resources.LightIcon_github;
                WebsiteButton.BackgroundImage = Properties.Resources.LightIcon_site;
                HelpButton   .BackgroundImage = Properties.Resources.LightIcon_help;


                //Mouse Down & Over Events
                InputCopy.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                InputCopy  .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                InputCut   .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                InputCut   .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                InputPaste .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                InputPaste .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                InputClear .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                InputClear .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");

                OutputCopy .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                OutputCopy .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                OutputCut  .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                OutputCut  .FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                OutputPaste.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                OutputPaste.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                OutputClear.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                OutputClear.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");

                ExportAudio.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
                ExportAudio.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3e3e42");
                ExportAudio.BackColor = ColorTranslator.FromHtml("#3e3e42");
            }

            else
            {
                //ThemeButton
                ThemeButton  .Text      = "Dark Theme";
                ThemeButton  .BackColor = ColorTranslator.FromHtml("#3e3e42");
                ThemeButton  .ForeColor = ColorTranslator.FromHtml("#ffffff");


                //Form & Panels
                this         .BackColor = Color.White;
                SideMenu     .BackColor = Color.Gainsboro;
                OptionsPanel .BackColor = Color.LightGray;
                Title        .BackColor = Color.LightGray;


                //SideMenu Buttons
                SetCipherButton.BackColor = Color.WhiteSmoke;
                CiphersComboBox.BackColor = Color.WhiteSmoke;
                KeysComboBox   .BackColor = Color.WhiteSmoke;
                EncodeButton   .BackColor = Color.WhiteSmoke;
                ShowKeyButton  .BackColor = Color.WhiteSmoke;
                ReportButton   .BackColor = Color.WhiteSmoke;
                
                SetCipherButton.ForeColor = Color.Black;
                CiphersComboBox.ForeColor = Color.Black;
                KeysComboBox   .ForeColor = Color.Black;
                EncodeButton   .ForeColor = Color.Black;
                ShowKeyButton  .ForeColor = Color.Black;
                ReportButton   .ForeColor = Color.Black;


                //Labels & Checkboxes
                ScoutsEncoder.ForeColor = Color.Black;
                Version      .ForeColor = Color.Black;
                OutputOptions.ForeColor = Color.Black;

                Dashes       .ForeColor = Color.Black;
                Slashes      .ForeColor = Color.Black;
                CharsSpacing .ForeColor = Color.Black;
                WordsSpacing .ForeColor = Color.Black;
                FillShapes   .ForeColor = Color.Black;


                //Textboxes
                InputTextBox .BackColor = Color.WhiteSmoke;
                OutputTextBox.BackColor = Color.WhiteSmoke;

                InputTextBox .ForeColor = Color.Black;
                OutputTextBox.ForeColor = Color.Black;


                //Image Buttons
                InputCopy    .BackgroundImage = Properties.Resources.DarkIcon_Copy;
                InputCut     .BackgroundImage = Properties.Resources.DarkIcon_Cut;
                InputPaste   .BackgroundImage = Properties.Resources.DarkIcon_Paste;
                InputClear   .BackgroundImage = Properties.Resources.DarkIcon_Clear;
                             
                OutputCopy   .BackgroundImage = Properties.Resources.DarkIcon_Copy;
                OutputCut    .BackgroundImage = Properties.Resources.DarkIcon_Cut;
                OutputPaste  .BackgroundImage = Properties.Resources.DarkIcon_Paste;
                OutputClear  .BackgroundImage = Properties.Resources.DarkIcon_Clear;
                ExportAudio  .BackgroundImage = Properties.Resources.DarkIcon_ExportAudio;

                ExitButton   .BackgroundImage = Properties.Resources.DarkIcon_Clear;
                GitHubButton .BackgroundImage = Properties.Resources.DarkIcon_github;
                WebsiteButton.BackgroundImage = Properties.Resources.DarkIcon_site;
                HelpButton   .BackgroundImage = Properties.Resources.DarkIcon_help;


                //Mouse Down & Over Events
                InputCopy  .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                InputCopy  .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                InputCut   .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                InputCut   .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                InputPaste .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                InputPaste .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                InputClear .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                InputClear .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;

                OutputCopy .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                OutputCopy .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                OutputCut  .FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                OutputCut  .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                OutputPaste.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                OutputPaste.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                OutputClear.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                OutputClear.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;

                ExportAudio.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                ExportAudio.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                ExportAudio.BackColor = Color.WhiteSmoke;
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            //Displayed info
            string Text = "You can help improve ScoutsEncoder by reporting bugs and feature requests on the following email: "
                        + "YoussefRaafatNasry@gmail.com" 
                        + "\n\n"
                        + "© 2018 ScoutsEncoder.";

            MessageBox.Show(Text, "Report a Bug");
        }


        //// SetCipherButton Dropdown effect
        private bool isCollapsed;

        private void DropdownTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                DropdownPanel.Height += 10;
                if (DropdownPanel.Size == DropdownPanel.MaximumSize)
                {
                    DropdownTimer.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                DropdownPanel.Height -= 10;
                if (DropdownPanel.Size == DropdownPanel.MinimumSize)
                {
                    DropdownTimer.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void CiphersComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            CiphersComboBox.DroppedDown = true;
        }

        private void KeysComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            KeysComboBox.DroppedDown = true;
        }


        //// SideMenu Check Boxes
        private void Dashes_CheckedChanged(object sender, EventArgs e)
        {
            isDashesChecked = Dashes.Checked;
        }

        private void Slashes_CheckedChanged(object sender, EventArgs e)
        {
            isSlashesChecked = Slashes.Checked;
        }

        private void CharsSpacing_CheckedChanged(object sender, EventArgs e)
        {
            isCharsSpacingChecked = CharsSpacing.Checked;
        }

        private void WordsSpacing_CheckedChanged(object sender, EventArgs e)
        {
            isWordsSpacingChecked = WordsSpacing.Checked;
        }

        private void FillShapes_CheckedChanged(object sender, EventArgs e)
        {

            if (!FillShapes.Checked)
            {
                OutputTextBox.Text = OutputTextBox.Text
                                    .Replace("◼", "◻")
                                    .Replace("▲", "△")
                                    .Replace("▼", "▽")
                                    .Replace("◀", "◁")
                                    .Replace("▶", "▷")
                                    .Replace("◢", "◿")
                                    .Replace("◣", "◺")
                                    .Replace("◥", "◹")
                                    .Replace("◤", "◸");
            }
            else
            {
                OutputTextBox.Text = OutputTextBox.Text
                                    .Replace("◻", "◼")
                                    .Replace("△", "▲")
                                    .Replace("▽", "▼")
                                    .Replace("◁", "◀")
                                    .Replace("▷", "▶")
                                    .Replace("◿", "◢")
                                    .Replace("◺", "◣")
                                    .Replace("◹", "◥")
                                    .Replace("◸", "◤");
            }
        }




        // Input Tools
        private void InputCopy_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                Clipboard.SetText(InputTextBox.Text);
            }
        }

        private void InputCut_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                Clipboard.SetText(InputTextBox.Text);
            }
            InputTextBox.Text = "";
        }

        private void InputPaste_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = Clipboard.GetText();
        }

        private void InputClear_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "";
        }




        // Output Tools
        private void OutputCopy_Click(object sender, EventArgs e)
        {
            if (OutputTextBox.Text != "")
            {
                Clipboard.SetText(OutputTextBox.Text);
            }
        }

        private void OutputCut_Click(object sender, EventArgs e)
        {
            if (OutputTextBox.Text != "")
            {
                Clipboard.SetText(OutputTextBox.Text);
            }
            OutputTextBox.Text = "";
        }

        private void OutputPaste_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = Clipboard.GetText();
        }

        private void OutputClear_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = "";
        }

        private void ExportAudio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Choose output destination";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string filePath = fbd.SelectedPath + "\\MorseCode.wav";

                MorseCodeGenerator audioData = new MorseCodeGenerator(ModifyInputTextForAudioExport(InputTextBox.Text));
                audioData.Save(filePath);

                //Confirmation message
                string Text = "Your file is generated successfully!"
                            + "\n\n"
                            + "The output destination is:\n"
                            + fbd.SelectedPath;

                MessageBox.Show(Text, "MorseCode.wav");
            }
        }



        // InputTextBox Placeholder Text
        private void InputTextBox_Enter(object sender, EventArgs e)
        {
            if (InputTextBox.Text == "أدخل الشفرة هنا...")
                InputTextBox.Text = "";
        }

        private void InputTextBox_Leave(object sender, EventArgs e)
        {
            if (InputTextBox.Text == "")
                InputTextBox.Text = "أدخل الشفرة هنا...";
        }

    }
}
