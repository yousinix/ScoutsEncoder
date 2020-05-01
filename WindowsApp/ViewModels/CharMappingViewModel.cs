using WindowsApp.ViewModels.Common;

namespace WindowsApp.ViewModels
{
    public class CharMappingViewModel : ViewModelBase
    {
        public char Character { get; set; }

        private string _encoding;
        public string Encoding
        {
            get => _encoding;
            set => SetField(ref _encoding, value);
        }
    }
}