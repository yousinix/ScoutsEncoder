using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScoutsEncoder
{
    public class Cipher
    {

        // Local Fields

        private static string arabicletters    = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        private List<char>   _arabicAlphabet   = new List<char>(arabicletters);
        private List<string> _cipherCharacters = new List<string>(arabicletters.Length);




        // Properties

        //// Basic Properties

        public string DisplayName { get; set; }

        public List<string> CipherCharacters
        {
            get
            {
                if (HasOverloads)
                    return Overloads[Key].CipherCharacters;
                else
                    return _cipherCharacters;
            }

            set { _cipherCharacters = value; }
        }

        public bool HasShapes { get; set; } = false;

        public bool IsAudible { get; set; } = false;


        //// Overloads Properties

        public bool HasOverloads { get; set; } = false;

        public List<Cipher> Overloads { get; set; }


        //// Key Properties

        public bool HasKeys { get; set; } = false;

        public int Key { get; set; } = 0;

        public int KeyWeight { get; set; } = 1;

        private int EncodingKey
        {
            get
            {
                if (HasOverloads) return 0;
                return Key * KeyWeight;
            }
        }

        public List<string> KeysList
        {
            get
            {
                List<string> _keysList = new List<string>();

                if (HasKeys)
                {
                    int numberOfAlphabetCharacters = _arabicAlphabet.Count;
                    for (int i = 0; i < numberOfAlphabetCharacters; i += KeyWeight)
                        _keysList.Add("أ = " + CipherCharacters[i]);
                }

                else if (HasOverloads)
                {
                    int numberOfOverloads = Overloads.Count;
                    for (int i = 0; i < numberOfOverloads; i++)
                        _keysList.Add(Overloads[i].DisplayName);
                }

                return _keysList;
            }

            set { KeysList = value; }
        }




        // Methods

        private void ModifyText(ref string textToModify)
        {
            // Replace odd characters with known characters
            textToModify = textToModify
                           .Replace("أ", "ا")
                           .Replace("إ", "ا")
                           .Replace("آ", "ا")
                           .Replace("ء", "ا")
                           .Replace("ة", "ه")
                           .Replace("ؤ", "و")
                           .Replace("ى", "ي")
                           .Replace("ئ", "ي");

            // Replace multiple spaces with a single space
            textToModify = Regex.Replace(textToModify, " {2,}", " ");

            // Remove Space at the end of the string
            if (textToModify.Length > 0 && textToModify[textToModify.Length - 1] == ' ')
                textToModify = textToModify.Remove(textToModify.Length - 1);
        }

        public string Encode(string text, string charDelimiter, string wordDelimiter)
        {
            ModifyText(ref text);
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
                        encodedText += " " + text[i] + " ";

                    // Add any new line or strange character as is
                    else
                        encodedText += text[i];
                }

                else
                {
                    // Encoding the character
                    index = (index + EncodingKey) % numberOfAlphabetCharacters;
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
                    index = (i + j * numberOfRows + EncodingKey) % numberOfAlphabetCharacters;
                    outputText += (_arabicAlphabet[i + j * numberOfRows] + " = "
                                   + CipherCharacters[index]).PadRight(12);
                }
                outputText += "\r\n";
            }

            return outputText;
        }

    }
}
