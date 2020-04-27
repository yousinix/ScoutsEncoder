using System.Diagnostics;
using System.Windows;
using WindowsApp.Services;
using WindowsApp.Views;

namespace WindowsApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();

            UpdateService.CheckForUpdates((version, downloadUrl) =>
            {
                var content = $"{version} is Now Available!";
                void Action() => Process.Start(new ProcessStartInfo(downloadUrl) { UseShellExecute = true });
                mainWindow.Snackbar.MessageQueue.Enqueue(content, "Download", Action);
            });

            mainWindow.Show();
        }
    }
}
