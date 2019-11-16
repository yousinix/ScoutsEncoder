using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScoutsEncoder
{
    public class Cipher
    {
        //////////// Local Fields ////////////

        private const string ArabicLetters = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        private readonly List<char> _arabicAlphabet = new List<char>(ArabicLetters);
        private List<string> _cipherCharacters = new List<string>(ArabicLetters.Length);


        //////////// Properties ////////////

        //// Basic Properties

        private string _name;

        public string DisplayName
        {
            get => IsNew ? $"{_name} 🆕" : _name;
            set => _name = value;
        }

        public bool IsNew { get; set; }

        public List<string> Characters
        {
            get => HasOverloads ? Overloads[Key].Characters : _cipherCharacters;
            set => _cipherCharacters = value;
        }

        public bool HasShapes { get; set; }

        public bool IsAudible { get; set; }

        //// Overloads Properties

        public bool HasOverloads { get; set; }

        public List<Cipher> Overloads { get; set; }

        //// Key Properties

        public bool HasKeys { get; set; }

        public int Key { get; set; }

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
                var keysList = new List<string>();

                if (HasKeys)
                {
                    var alphabetCount = _arabicAlphabet.Count;
                    for (var i = 0; i < alphabetCount; i += KeyWeight)
                        keysList.Add("أ = " + Characters[i]);
                }
                else if (HasOverloads)
                {
                    var numberOfOverloads = Overloads.Count;
                    for (var i = 0; i < numberOfOverloads; i++)
                        keysList.Add(Overloads[i].DisplayName);
                }

                return keysList;
            }
        }


        //////////// Methods ////////////

        private static void ModifyText(ref string textToModify)
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
        }

        public string Encode(string text, string charDelimiter, string wordDelimiter)
        {
            ModifyText(ref text);

            var encodedText   = "";
            var textLength    = text.Length;
            var alphabetCount = _arabicAlphabet.Count;

            for (var i = 0; i < textLength; i++)
            {
                // Get the index of the current character from Arabic Alphabet's list
                var index = _arabicAlphabet.IndexOf(text[i]);

                if (index == -1) // If the character is not a Valid Arabic letter
                {
                    if (text[i] == ' ')
                        encodedText += wordDelimiter;

                    // Surround punctuation marks with spaces
                    // to avoid mixing them up with the cipher characters
                    // as some ciphers may contain punctuation marks
                    else if (char.IsPunctuation(text[i]))
                        encodedText += " " + text[i] + " ";

                    // Add any new line or strange character as is
                    else
                        encodedText += text[i];
                }

                else
                {
                    // Encoding the character
                    index = (index + EncodingKey) % alphabetCount;
                    encodedText += Characters[index];

                    // Add a delimiter after the character if the next character
                    // isn't: (last character, space, new line, punctuation mark)
                    var next = i != textLength - 1 ? text[i + 1] : ' ';
                    encodedText += char.IsWhiteSpace(next) || char.IsPunctuation(next) ? "" : charDelimiter;
                }
            }

            return encodedText;
        }

        public string GetKeysMapping()
        {
            var outputText    = "";
            var columnsCount  = 4;
            var alphabetCount = _arabicAlphabet.Count;
            var rowsCount     = alphabetCount / columnsCount;

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    var index1 = i + j * rowsCount;
                    var index2 = (index1 + EncodingKey) % alphabetCount;
                    outputText += (_arabicAlphabet[index1] + " = " + Characters[index2]).PadRight(14);
                }

                outputText += "\r\n";
            }

            return outputText;
        }
    }
}