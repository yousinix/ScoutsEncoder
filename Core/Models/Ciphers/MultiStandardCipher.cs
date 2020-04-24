using System.Collections.Generic;

namespace Core.Models.Ciphers
{
    public class MultiStandardCipher : CipherBase
    {
        public int StandardIndex { get; set; }
        public List<CipherStandard> Standards { get; set; } = new List<CipherStandard>();

        public override List<string> Characters
        {
            get => Standards[StandardIndex].Characters;
            set => Standards[StandardIndex].Characters = value;
        }
    }
}
