using System;
using System.Collections.Generic;

namespace ScoutsEncoder_WPF
{
    class Cipher
    {

        // Local Fields

        private static List<char> _arabicAlphabet = new List<char>
                                                    { 'ا', 'ب', 'ت', 'ث', 'ج', 'ح', 'خ',
                                                      'د', 'ذ', 'ر', 'ز', 'س', 'ش', 'ص',
                                                      'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق',
                                                      'ك', 'ل', 'م', 'ن', 'ه', 'و', 'ي' };


        // Properties

        public List<string> CipherCharacters { get; set; } = new List<string>(_arabicAlphabet.Count);

        public string DisplayName { get; set; }

        public bool HasKeys { get; set; } = false;

        public bool HasShapes { get; set; } = false;

        public bool IsAudible { get; set; } = false;

        public int Key { get; set; } = 0;

        public List<string> KeysList
        {
            get
            {
                List<string> _keysList = new List<string>();

                int numberOfAlphabetCharacters = _arabicAlphabet.Count;

                for (int i = 0; i < numberOfAlphabetCharacters; i++)
                {
                    _keysList.Add("أ = " + CipherCharacters[i]);
                }

                return _keysList;
            }

            set { KeysList = value; }
        }


        // Methods

        public string Encode(string text, string charDelimiter, string wordDelimiter)
        {
            string encodedText = "";
            int textLength = text.Length;
            int numberOfAlphabetCharacters = _arabicAlphabet.Count;

            for (int i = 0; i < textLength; i++)
            {
                // Get the index of the current character from Arabic Alphabet's list
                int index = _arabicAlphabet.IndexOf(text[i]);

                if (index == -1)  // If the character is not a Valid Arabic letter
                {
                    if (text[i] == ' ')
                        encodedText += wordDelimiter;

                    // Surrond punctuation marks with spaces
                    // to avoid mixing them up with the cipher characters
                    // as some ciphers may contain punctuation marks
                    else if (Char.IsPunctuation(text[i]))
                        encodedText += ' ' + text[i] + ' ';

                    // Add any new line or strange character as is
                    else
                        encodedText += text[i];
                }

                else
                {
                    // Encoding the character
                    index = (index + Key) % numberOfAlphabetCharacters;
                    encodedText += CipherCharacters[index];

                    // Add a delimeter after the character if the next character
                    // isn't: (last charcter, space, new line, punctuation mark)
                    if (i + 1 != textLength && text[i + 1] != ' ' && text[i + 1] != '\r' && !Char.IsPunctuation(text[i + 1]))
                        encodedText += charDelimiter;
                }

            }

            return encodedText;
        }

        public string ShowKey()
        {
            string outputText = "";
            int numberOfAlphabetCharacters = _arabicAlphabet.Count;
            int numberOfColumns = 4;
            int numberOfRows = numberOfAlphabetCharacters / numberOfColumns;
            int index;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    index = (i + j * numberOfRows + Key) % numberOfAlphabetCharacters;
                    outputText += (_arabicAlphabet[i + j * numberOfRows] + " = "
                                        + CipherCharacters[index]).PadLeft(12);
                }
                outputText += "\r\n";
            }

            return outputText;
        }

    }
}
