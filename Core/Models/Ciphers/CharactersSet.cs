using System.Collections.Generic;

namespace Core.Models.Ciphers
{
    public class CharactersSet
    {
        public string Name { get; set; }
        public List<string> Characters { get; set; } = new List<string>();
    }
}
