namespace Core.Models.Ciphers
{
    public class Key
    {
        public bool IsEnabled { get; set; } = true;
        public int Base { get; set; }
        public int Weight { get; set; } = 1;
        public int Value => Base * Weight;
    }
}
