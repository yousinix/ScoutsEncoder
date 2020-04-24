using System.Collections.Generic;
using Core.Data;
using Core.Models.Languages;

namespace Core.Models.Ciphers
{
    public abstract class CipherBase
    {
        public abstract List<string> Characters { get; set; }
        public string Name { get; set; }
        public CipherType Type { get; set; } = CipherType.Text;
        public Language Language { get; set; } = LanguagesList.Ar; // Default is Arabic
        public Key Key { get; set; } = new Key();

        public IEnumerable<string> KeysList
        {
            get
            {
                var keysList = new List<string>();
                for (var i = 0; i < Language.Characters.Count; i += Key.Weight)
                    keysList.Add($"{Language.BaseCharacter} = {Characters[i]}");
                return keysList;
            }
        }

        public string Encode(string text, string charDelimiter, string wordDelimiter)
        {
            text = Language.Normalize(text);
            var encodedText = "";

            for (var i = 0; i < text.Length; i++)
            {
                // Get the index of the current character from Arabic Alphabet's list
                var index = Language.Characters.IndexOf(text[i]);

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
                    index = (index + Key.Value) % Language.Characters.Count;
                    encodedText += Characters[index];

                    // Add a delimiter after the character if the next character
                    // isn't: (last character, space, new line, punctuation mark)
                    var next = i != text.Length - 1 ? text[i + 1] : ' ';
                    encodedText += char.IsWhiteSpace(next) || char.IsPunctuation(next) ? "" : charDelimiter;
                }
            }

            return encodedText;
        }

        public string GetSchema()
        {
            var outputText    = "";
            var columnsCount  = 4;
            var alphabetCount = Language.Characters.Count;
            var rowsCount     = alphabetCount / columnsCount;

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    var index1 = i + j * rowsCount;
                    var index2 = (index1 + Key.Value) % alphabetCount;
                    outputText += (Language.Characters[index1] + " = " + Characters[index2]).PadRight(14);
                }

                outputText += "\r\n";
            }

            return outputText;
        }
    }
}
