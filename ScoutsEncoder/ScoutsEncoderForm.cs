/// <ScoutsEncoder>
/// This software encodes plain text into scouts' Arabic ciphers.
/// </ScoutsEncoder>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScoutsEncoder
{
    public partial class ScoutsEncoderForm : Form
    {
        public ScoutsEncoderForm()
        {
            InitializeComponent();
            initializeCodesComboBox();
        }

        
        //Codes
        private List<string> arabicLetters = new List<string>
                                             {"ا", "ب", "ت", "ث", "ج", "ح", "خ",
                                              "د", "ذ", "ر", "ز", "س", "ش", "ص",
                                              "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                                              "ك", "ل", "م", "ن", "ه", "و", "ي"};
        ////code 00
        private string[] jesusCode         = {"ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                                              "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                                              "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                                              "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"};

        ////code 01
        private string[] numericCode       = {"١" , "٢" , "٣" , "٤" , "٥" , "٦" , "٧" ,
                                              "٨" , "٩" , "١٠", "١١", "١٢", "١٣", "١٤",
                                              "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                                              "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"};

        ////code 02
        private string[] invertedCode      = {"ي", "و", "ه", "ن", "م", "ل", "ك",
                                              "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                                              "ص", "ش", "س", "ز", "ر", "ذ", "د",
                                              "خ", "ح", "ج", "ث", "ت", "ب", "ا"};

        ////code 03
        private string[] caesarCode        = {"ا", "ب", "ت", "ث", "ج", "ح", "خ",
                                              "د", "ذ", "ر", "ز", "س", "ش", "ص",
                                              "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                                              "ك", "ل", "م", "ن", "ه", "و", "ي"};

        ////code 04
        private string[] manuscriptCode    = {"ا ", "ب ", "ت ", "ث ", "ج ", "ح ", "خ ",
                                              "د ", "ذ ", "ر ", "ز ", "س ", "ش ", "ص ",
                                              "ض ", "ط ", "ظ ", "ع ", "غ ", "ف ", "ق ",
                                              "ك ", "ل ", "م ", "ن ", "ه ", "و ", "ي "};

        ////code 05
        private string[] morseCode         = {"(•-)"  , "(-•••)", "(-)"   , "(-•-•)", "(•---)" , "(••••)", "(---)" ,
                                              "(-••)" , "(--••)", "(•-•)" , "(---•)", "(•••)"  , "(----)", "(-••-)",
                                              "(•••-)", "(••-)" , "(-•--)", "(•-•-)", "(--•)"  , "(••-•)", "(--•-)",
                                              "(-•-)" , "(•-••)", "(--)"  , "(-•)"  , "(••-••)", "(•--)" , "(••)"  };

        ////code 06
        private string[] binaryCode        = {"00001", "00010", "00011", "00100", "00101", "00110", "00111",
                                              "01000", "01001", "01010", "01011", "01100", "01101", "01110",
                                              "01111", "10000", "10001", "10010", "10011", "10100", "10101",
                                              "10110", "10111", "11000", "11001", "11010", "11011", "11100"};

        ////code 07
        private string[] compassCode       = {"N(١)", "NE(١)", "E(١)", "SE(١)", "S(١)", "SW(١)", "W(١)", "NW(١)",
                                              "N(٢)", "NE(٢)", "E(٢)", "SE(٢)", "S(٢)", "SW(٢)", "W(٢)", "NW(٢)",
                                              "N(٣)", "NE(٣)", "E(٣)", "SE(٣)", "S(٣)", "SW(٣)", "W(٣)", "NW(٣)",
                                              "N(٤)", "NE(٤)", "E(٤)", "SE(٤)"};

        ////code 08 - 01
        private string[] clockwiseCode     = {"١:١٢", "١:١" , "١:٢" , "١:٣" , "١:٤" , "١:٥" , "١:٦",
                                              "١:٧" , "١:٨" , "١:٩" , "١:١٠", "١:١١", "٢:١٢", "٢:١",
                                              "٢:٢" , "٢:٣" , "٢:٤" , "٢:٥" , "٢:٦" , "٢:٧" , "٢:٨",
                                              "٢:٩" , "٢:١٠", "٢:١١", "٣:١٢", "٣:١" , "٣:٢" , "٣:٣"};

        ////code 08 - 02
        private string[] antiClockwiseCode = {"١:١٢", "١:١١", "١:١٠", "١:٩" , "١:٨" , "١:٧" , "١:٦" ,
                                              "١:٥" , "١:٤" , "١:٣" , "١:٢" , "١:١" , "٢:١٢", "٢:١١",
                                              "٢:١٠", "٢:٩" , "٢:٨" , "٢:٧" , "٢:٦" , "٢:٥" , "٢:٤" ,
                                              "٢:٣" , "٢:٢" , "٢:١" , "٣:١٢", "٣:١١", "٣:١٠", "٣:٩" };

        ////code 09 - 01
        private string[] mobile01Code      = {"٣"   , "٢"   , "٢٢"    , "٢٢٢" , "٦"   , "٦٦" , "٦٦٦"  ,
                                              "٥"   , "٥٥"  , "٥٥٥"   , "٥٥٥٥", "٤"   , "٤٤" , "٤٤٤"  ,
                                              "٤٤٤٤", "٩"   , "٩٩"    , "٩٩٩" , "٩٩٩٩", "٨"  , "٨٨"   ,
                                              "٨٨٨" , "٨٨٨٨", "٨٨٨٨٨", "٧"    , "٧٧"  , "٧٧٧", "٧٧٧٧"};

        ////code 09 - 02
        private string[] mobile02Code      = {"٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                                              "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                                              "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                                              "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"};

        ////code 10
        private string[] xCode             = {"V(١)", "V(٢)", "V(٣)", "V(٤)", "V(٥)", "V(٦)", "V(٧)",
                                              ">(١)", ">(٢)", ">(٣)", ">(٤)", ">(٥)", ">(٦)", ">(٧)",
                                              "Λ(١)", "Λ(٢)", "Λ(٣)", "Λ(٤)", "Λ(٥)", "Λ(٦)", "Λ(٧)",
                                              "<(١)", "<(٢)", "<(٣)", "<(٤)", "<(٥)", "<(٦)", "<(٧)"};

        ////code 11
        private string[] starCode          = {"▲١", "▲٢", "▲٣", "▲٤", "▲٥", "▲٦", "▲٧",
                                              "▶١", "▶٢", "▶٣", "▶٤", "▶٥", "▶٦", "▶٧",
                                              "◀١", "◀٢", "◀٣", "◀٤", "◀٥", "◀٦", "◀٧",
                                              "▼١", "▼٢", "▼٣", "▼٤", "▼٥", "▼٦", "▼٧"};

        //code 12
        private string[] rhombusCode       = {"١◣", "١◢", "١◤", "١◥",
                                              "٢◣", "٢◢", "٢◤", "٢◥",
                                              "٣◣", "٣◢", "٣◤", "٣◥",
                                              "٤◣", "٤◢", "٤◤", "٤◥",
                                              "٥◣", "٥◢", "٥◤", "٥◥",
                                              "٦◣", "٦◢", "٦◤", "٦◥",
                                              "٧◣", "٧◢", "٧◤", "٧◥"};

        //code 13
        private string[] triangleCode      = {"١▲",
                                              "٢◣◼",  "٢◼◢",
                                              "٣◣◼", "٣◼(١)",  "٣◼◢",
                                              "٤◣◼", "٤◼(١)", "٤◼(٢)",  "٤◼◢",
                                              "٥◣◼", "٥◼(١)", "٥◼(٢)", "٥◼(٣)",  "٥◼◢",
                                              "٦◣◼", "٦◼(١)", "٦◼(٢)", "٦◼(٣)", "٦◼(٤)",  "٦◼◢",
                                              "٧◣◼", "٧◼(١)", "٧◼(٢)", "٧◼(٣)", "٧◼(٤)", "٧◼(٥)",  "٧◼◢",};


        ///  Steps for adding a new code:
        ///  ----------------------------
        ///  1] Create an array of strings from the elements of the code.
        ///     (use the "string[] newCode" array as a guide)
        ///     
        ///  2] Add the new code name in the initializeCodesComboBox function.
        ///  
        ///  3] Go to each of the following events & follow the instructions at the end of each event:
        ///     - CodesComboBox_SelectedIndexChanged
        ///     - EncodeButton_Click
        ///     - ShowKeyButton_Click


        /////////////////////////// NEW CODE : ADD HERE ///////////////////////////
        ///  //code XX                                                          ///
        ///  private string[] newCode = {"X", "X", "X", "X", "X", "X", "X",     ///
        ///                              "X", "X", "X", "X", "X", "X", "X",     ///
        ///                              "X", "X", "X", "X", "X", "X", "X",     ///
        ///                              "X", "X", "X", "X", "X", "X", "X"};    ///
        ///////////////////////////////////////////////////////////////////////////






        // Variables
        private int  codeIndex;
        private int  keyIndex;
        private bool isDashesChecked       = true;
        private bool isSlashesChecked      = true;
        private bool isCharsSpacingChecked = true;
        private bool isWordsSpacingChecked = true;




        // Processing Functions
        private void initializeCodesComboBox()
        {
            CodesComboBox.Items.AddRange(new object[] {
            ////code 00
            "  " + "يسوع",

            ////code 01
            "  " + "رقمية",
            
            ////code 02
            "  " + "عكسية",
            
            ////code 03
            "  " + "قيصر",
            
            ////code 04
            "  " + "عربي مفرط",
            
            ////code 05
            "  " + "المورس",
            
            ////code 06
            "  " + "الأعداد الثنائية",
            
            ////code 07
            "  " + "البوصلة",
            
            ////code 08
            "  " + "الساعة",
            
            ////code 09
            "  " + "الجوال",
            
            ////code 10
            "  " + "إكس",
            
            ////code 11
            "  " + "النجمة",
            
            ////code 12
            "  " + "المعين",
            
            ////code 13
            "  " + "المثلث",

            ////code XX
            //  "  " + "NEW CODE NAME HERE",

            });
        }

        private string modifyText(string textToModify)
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

        private void encode(string[] code)
        {
            string inputTextCopy  = modifyText(InputTextBox.Text);
            string outputTextCopy = "";

            int index;
            for (int i = 0; i <= inputTextCopy.Length - 1; i++)
            {
                index = arabicLetters.IndexOf(inputTextCopy[i].ToString());
                if (index == -1)
                {
                    if (inputTextCopy[i] == ' ')
                    {
                        if (isSlashesChecked && isWordsSpacingChecked)
                            outputTextCopy += "  /  ";
                        else if (!isSlashesChecked && !isWordsSpacingChecked)
                            outputTextCopy += " ";
                        else if (isSlashesChecked  && !isWordsSpacingChecked)
                            outputTextCopy += " / ";
                        else if (!isSlashesChecked && isWordsSpacingChecked)
                            outputTextCopy += "   ";
                    }
                    else if (Char.IsPunctuation(inputTextCopy[i]))
                        outputTextCopy += " " + inputTextCopy[i];
                    else
                        outputTextCopy += inputTextCopy[i];
                }
                else
                {
                    index = (index + keyIndex) % 28;
                    outputTextCopy += code[index];

                    if (i + 1 <= inputTextCopy.Length - 1) //check if (i + 1) is an existing index
                        if (inputTextCopy[i + 1] != ' ' && inputTextCopy[i + 1] != '\r' && !Char.IsPunctuation(inputTextCopy[i + 1]))
                            if (isDashesChecked && isCharsSpacingChecked)
                                outputTextCopy += " - ";
                            else if (!isDashesChecked && !isCharsSpacingChecked)
                                outputTextCopy += "";
                            else if (isDashesChecked  && !isCharsSpacingChecked)
                                outputTextCopy += "-";
                            else if (!isDashesChecked && isCharsSpacingChecked)
                                outputTextCopy += " ";
                }
            }

            OutputTextBox.Text = outputTextCopy;
        }

        private void showEncodingKey(string[] code)
        {
            int index;
            OutputTextBox.Text = "";

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    index = (i + j * 7 + keyIndex) % 28;
                    OutputTextBox.Text += (arabicLetters[i + j * 7] + " = " + code[index]).PadRight(12);
                }
                OutputTextBox.Text += "\r\n";
            }
       
        }

        private string[] initializeKeysList(string[] code)
        {
            string[] items = new string[code.Length];
            for (int i = 0; i < code.Length; i++)
            {
                items[i] = "   " + "أ = " + code[i];
            }
            return items;
        }

        private void showFillShapes(bool status)
        {
            if (status)
            {
                OptionsPanel.Size = OptionsPanel.MaximumSize;
                FillShapes.Visible = true;
                FillShapes.Enabled = true;
            }
            else
            {
                OptionsPanel.Size = OptionsPanel.MinimumSize;
                FillShapes.Visible = false;
                FillShapes.Enabled = false;
            }
        }




        // SideMenu Buttons
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCodeButton_Click(object sender, EventArgs e)
        {
            DropdownTimer.Start();
        }

        private void CodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CodesComboBox.SelectedItem != null)
            {
                codeIndex = CodesComboBox.SelectedIndex;
                KeysComboBox.Items.Clear();
                keyIndex = 0;

                switch (codeIndex)
                {
                    case 0:
                        showFillShapes(false);
                        KeysComboBox.Text = "   " + "أ = " + jesusCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysList(jesusCode));
                        break;

                    case 1:
                        showFillShapes(false);
                        KeysComboBox.Text = "   " + "أ = " + numericCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysList(numericCode));
                        break;

                    case 2:
                        showFillShapes(false);
                        KeysComboBox.Text = "   " + "أ = " + invertedCode[0];
                        KeysComboBox.Items.AddRange(initializeKeysList(invertedCode));
                        break;

                    case 3:
                        showFillShapes(false);
                        string[] items = new string[numericCode.Length];
                        for (int i = 0; i < numericCode.Length; i++)
                        {
                            items[i] = "   " + numericCode[i];
                        }
                        KeysComboBox.Text = "   " + numericCode[0];
                        KeysComboBox.Items.AddRange(items);
                        break;

                    case 4:
                        showFillShapes(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 5:
                        showFillShapes(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 6:
                        showFillShapes(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 7:
                        showFillShapes(false);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 8:
                        showFillShapes(false);
                        KeysComboBox.Text = "  " + "مع عقارب الساعة";
                        KeysComboBox.Items.AddRange(new object[] { "  " + "مع عقارب الساعة",
                                                                   "  " + "عكس عقارب الساعة" });
                        break;

                    case 9:
                        showFillShapes(false);
                        KeysComboBox.Text = "   " + "أ = " + mobile01Code[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + mobile01Code[0],
                                                                   "   " + "أ = " + mobile02Code[0] });
                        break;

                    case 10:
                        showFillShapes(false);
                        KeysComboBox.Text = "   " + "أ = " + xCode[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + xCode[0],
                                                                   "   " + "أ = " + xCode[7],
                                                                   "   " + "أ = " + xCode[14],
                                                                   "   " + "أ = " + xCode[21] });
                        break;

                    case 11:
                        showFillShapes(true);
                        KeysComboBox.Text = "   " + "أ = " + starCode[0];
                        KeysComboBox.Items.AddRange(new object[] { "   " + "أ = " + starCode[0],
                                                                   "   " + "أ = " + starCode[7],
                                                                   "   " + "أ = " + starCode[14],
                                                                   "   " + "أ = " + starCode[21] });
                        break;

                    case 12:
                        showFillShapes(true);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;

                    case 13:
                        showFillShapes(true);
                        KeysComboBox.Text =    "  " + "لا يوجد مفاتيح";
                        KeysComboBox.Items.Add("  " + "لا يوجد مفاتيح");
                        break;


                    /////////////////////////// NEW CODE : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new code in CodesComboBox)    ///
                    ///     KeysComboBox.Text = FIRST KEY OF THE NEW CODE;                  ///
                    ///     KeysComboBox.Items.AddRange(initializeKeysList(newCode));       ///
                    ///     **OR**                                                          ///
                    ///     KeysComboBox.Items.AddRange(new object[] {KEY1, KEY2,.... });   ///
                    ///     break;                                                          ///
                    ///////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void KeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyIndex = KeysComboBox.SelectedIndex;
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (CodesComboBox.Text == "  اختر الشفرة")
            {
                OutputTextBox.Text = "من فضلك اختر الشفرة عن طريق الضغط علي \"إعدادات الشفرة\" ثم اختر الشفرة المناسبة";
            }
            else
            {
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
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex + 1;
                        encode(caesarCode);
                        break;

                    case 4:
                        encode(manuscriptCode);
                        if (!isSlashesChecked && !isWordsSpacingChecked)
                            OutputTextBox.Text = OutputTextBox.Text.Replace("  ", " ");
                        break;

                    case 5:
                        encode(morseCode);
                        break;

                    case 6:
                        encode(binaryCode);
                        break;
                        
                    case 7:
                        encode(compassCode);
                        break;

                    case 8:
                        if (keyIndex == 0)
                            encode(clockwiseCode);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            encode(antiClockwiseCode);
                            keyIndex = 1;
                        }
                        break;

                    case 9:
                        if (keyIndex == 0)
                            encode(mobile01Code);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            encode(mobile02Code);
                            keyIndex = 1;
                        }
                        break;

                    case 10:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        encode(xCode);
                        break;

                    case 11:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        encode(starCode);
                        break;

                    case 12:
                        encode(rhombusCode);
                        break;

                    case 13:
                        encode(triangleCode);
                        break;


                    /////////////////////////// NEW CODE : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new code in CodesComboBox)    ///
                    ///     encode(newCode);                                                ///
                    ///     break;                                                          ///
                    ///////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void ShowKeyButton_Click(object sender, EventArgs e)
        {
            if (CodesComboBox.Text == "  اختر الشفرة")
            {
                OutputTextBox.Text = "من فضلك اختر الشفرة عن طريق الضغط علي \"إعدادات الشفرة\" ثم اختر الشفرة المناسبة";
            }
            else
            {
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
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex + 1;
                        showEncodingKey(caesarCode);
                        break;

                    case 4:
                        showEncodingKey(manuscriptCode);
                        break;

                    case 5:
                        showEncodingKey(morseCode);
                        OutputTextBox.Text = OutputTextBox.Text.Replace("(", "").Replace(")", "");
                        break;

                    case 6:
                        showEncodingKey(binaryCode);
                        break;

                    case 7:
                        showEncodingKey(compassCode);
                        break;

                    case 8:
                        if (keyIndex == 0)
                            showEncodingKey(clockwiseCode);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            showEncodingKey(antiClockwiseCode);
                            keyIndex = 1;
                        }
                        break;

                    case 9:
                        if (keyIndex == 0)
                            showEncodingKey(mobile01Code);
                        if (keyIndex == 1)
                        {
                            keyIndex = 0;
                            showEncodingKey(mobile02Code);
                            keyIndex = 1;
                        }
                        break;

                    case 10:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        showEncodingKey(xCode);
                        break;

                    case 11:
                        if (KeysComboBox.SelectedIndex == -1)
                        {
                            KeysComboBox.SelectedIndex = 0;
                        }
                        keyIndex = KeysComboBox.SelectedIndex * 7;
                        showEncodingKey(starCode);
                        break;

                    case 12:
                        showEncodingKey(rhombusCode);
                        break;

                    case 13:
                        showEncodingKey(triangleCode);
                        break;


                    /////////////////////////// NEW CODE : ADD HERE ///////////////////////////
                    ///  case X: (where X is the index of the new code in CodesComboBox)    ///
                    ///     showEncodingKey(newCode);                                       ///
                    ///     break;                                                          ///
                    ///////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void GitHubButton_Click(object sender, EventArgs e)
        {
            //Project link on GitHub
            System.Diagnostics.Process.Start("https://www.github.com/YoussefRaafatNasry/scouts-encoder");
        }

        private void DocsButton_Click(object sender, EventArgs e)
        {
            //Google Docs link
            System.Diagnostics.Process.Start("https://docs.google.com");
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
                SetCodeButton.BackColor = ColorTranslator.FromHtml("#3e3e42");
                CodesComboBox.BackColor = ColorTranslator.FromHtml("#3e3e42");
                KeysComboBox .BackColor = ColorTranslator.FromHtml("#3e3e42");
                EncodeButton .BackColor = ColorTranslator.FromHtml("#3e3e42");
                ShowKeyButton.BackColor = ColorTranslator.FromHtml("#3e3e42");
                ReportButton .BackColor = ColorTranslator.FromHtml("#3e3e42");

                SetCodeButton.ForeColor = ColorTranslator.FromHtml("#ffffff");
                EncodeButton .ForeColor = ColorTranslator.FromHtml("#ffffff");
                CodesComboBox.ForeColor = ColorTranslator.FromHtml("#ffffff");
                KeysComboBox .ForeColor = ColorTranslator.FromHtml("#ffffff");
                ShowKeyButton.ForeColor = ColorTranslator.FromHtml("#ffffff");
                ReportButton .ForeColor = ColorTranslator.FromHtml("#ffffff");


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
                InputCopy   .BackgroundImage = Properties.Resources.LightIcon_Copy;
                InputCut    .BackgroundImage = Properties.Resources.LightIcon_Cut;
                InputPaste  .BackgroundImage = Properties.Resources.LightIcon_Paste;
                InputClear  .BackgroundImage = Properties.Resources.LightIcon_Clear;
                            
                OutputCopy  .BackgroundImage = Properties.Resources.LightIcon_Copy;
                OutputCut   .BackgroundImage = Properties.Resources.LightIcon_Cut;
                OutputPaste .BackgroundImage = Properties.Resources.LightIcon_Paste;
                OutputClear .BackgroundImage = Properties.Resources.LightIcon_Clear;
                            
                ExitButton  .BackgroundImage = Properties.Resources.LightIcon_Clear;
                GitHubButton.BackgroundImage = Properties.Resources.LightIcon_github;


                //Mouse Down & Over Events
                InputCopy  .FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c1c1c");
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
                SetCodeButton.BackColor = Color.WhiteSmoke;
                CodesComboBox.BackColor = Color.WhiteSmoke;
                KeysComboBox .BackColor = Color.WhiteSmoke;
                EncodeButton .BackColor = Color.WhiteSmoke;
                ShowKeyButton.BackColor = Color.WhiteSmoke;
                ReportButton .BackColor = Color.WhiteSmoke;
                
                SetCodeButton.ForeColor = Color.Black;
                CodesComboBox.ForeColor = Color.Black;
                KeysComboBox .ForeColor = Color.Black;
                EncodeButton .ForeColor = Color.Black;
                ShowKeyButton.ForeColor = Color.Black;
                ReportButton .ForeColor = Color.Black;


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
                InputCopy   .BackgroundImage = Properties.Resources.DarkIcon_Copy;
                InputCut    .BackgroundImage = Properties.Resources.DarkIcon_Cut;
                InputPaste  .BackgroundImage = Properties.Resources.DarkIcon_Paste;
                InputClear  .BackgroundImage = Properties.Resources.DarkIcon_Clear;
                            
                OutputCopy  .BackgroundImage = Properties.Resources.DarkIcon_Copy;
                OutputCut   .BackgroundImage = Properties.Resources.DarkIcon_Cut;
                OutputPaste .BackgroundImage = Properties.Resources.DarkIcon_Paste;
                OutputClear .BackgroundImage = Properties.Resources.DarkIcon_Clear;

                ExitButton  .BackgroundImage = Properties.Resources.DarkIcon_Clear;
                GitHubButton.BackgroundImage = Properties.Resources.DarkIcon_github;


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


        //// SetCodeButton Dropdown effect
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

        private void CodesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            CodesComboBox.DroppedDown = true;
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
