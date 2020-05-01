using System.Diagnostics;
using System.Windows.Input;
using WindowsApp.ViewModels.Common;
using MaterialDesignThemes.Wpf;

namespace WindowsApp.ViewModels
{
    public class FooterViewModel : ViewModelBase
    {
        public ICommand ToggleTheme { get; set; } = new CommandBase<bool>(ExecuteToggleTheme);

        public ICommand OpenUrl { get; set; } = new CommandBase<string>(ExecuteOpenUrl);

        private static void ExecuteToggleTheme(bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(isDark ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private static void ExecuteOpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
