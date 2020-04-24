using System.Collections.Generic;
using System.Linq;
using CCPair = System.Collections.Generic.KeyValuePair<char, char>;

namespace Core.Models.Languages
{
    /// <summary>
    /// Represents a set of characters that are "visually" similar and
    /// should be treated the same way while encoding.
    /// For example: "ï, ì, î" should all be treated as "i"
    /// </summary>
    public class AlikeChar
    {
        public char Master { get; set; }
        public HashSet<char> Slaves { get; set; } = new HashSet<char>();
        public List<CCPair> Mappings => Slaves.Select(s => new CCPair(s, Master)).ToList();
    }
}
