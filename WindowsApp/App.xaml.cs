using Services.Updater;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using WindowsApp.ViewModels;
using WindowsApp.Views;

namespace WindowsApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            var viewModel = (MainWindowViewModel) mainWindow.DataContext;

            var assembly = Assembly.GetExecutingAssembly();
            UpdateService.CheckForUpdates(assembly, (version, downloadUrl) =>
            {
                var content = $"{version} is Now Available!";
                void Action() => Process.Start(new ProcessStartInfo(downloadUrl) { UseShellExecute = true });
                viewModel.MessageQueue.Enqueue(content, "Download", Action);
            });

            mainWindow.Show();
        }
    }
}
