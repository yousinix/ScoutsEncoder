using System.Collections.Generic;
using System.Text;

namespace Core.Models.Languages
{
    public class Language
    {
        public string Name { get; set; }
        public char BaseCharacter { get; set; }
        public List<char> Characters { get; set; }
        public List<AlikeChar> AlikeChars { get; set; }

        /// <summary>
        /// Replaces all AlikeChars' slaves with their master
        /// </summary>
        /// <param name="text">text that contains alike characters</param>
        /// <returns>normalized text</returns>
        public string Normalize(string text)
        {
            IDictionary<char, char> mapper = new Dictionary<char, char>();
            AlikeChars.ForEach(c => c.Mappings.ForEach(m => mapper.Add(m)));

            var builder = new StringBuilder(text);

            for (var i = 0; i < builder.Length; i++)
            {
                var c = builder[i];
                if (mapper.ContainsKey(c))
                {
                    builder[i] = mapper[c];
                }
            }

            return builder.ToString();
        }
    }
}
