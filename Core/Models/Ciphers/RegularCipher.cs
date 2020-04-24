using System.Collections.Generic;

namespace Core.Models.Ciphers
{
    public class RegularCipher : CipherBase
    {
        public override List<string> Characters { get; set; } = new List<string>();
    }
}
