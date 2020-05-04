using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Windows.Input;
using WindowsApp.ViewModels.Common;

namespace WindowsApp.ViewModels
{
    public class FooterViewModel : ViewModelBase
    {
        public ICommand ToggleThemeCommand { get; set; } = new CommandBase<bool>(ToggleTheme);

        public ICommand OpenUrlCommand { get; set; } = new CommandBase<string>(OpenUrl);

        private static void ToggleTheme(bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(isDark ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private static void OpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
