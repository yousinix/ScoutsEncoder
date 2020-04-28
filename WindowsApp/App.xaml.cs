using System.Diagnostics;
using System.Reflection;
using System.Windows;
using WindowsApp.Views;
using Services.Updater;

namespace WindowsApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();

            var assembly = Assembly.GetExecutingAssembly();
            UpdateService.CheckForUpdates(assembly, (version, downloadUrl) =>
            {
                var content = $"{version} is Now Available!";
                void Action() => Process.Start(new ProcessStartInfo(downloadUrl) { UseShellExecute = true });
                mainWindow.Snackbar.MessageQueue.Enqueue(content, "Download", Action);
            });

            mainWindow.Show();
        }
    }
}
