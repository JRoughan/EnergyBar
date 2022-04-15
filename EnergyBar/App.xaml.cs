using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace EnergyBar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private TaskbarIcon notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            notifyIcon = FindResource("TaskbarIcon") as TaskbarIcon;
            notifyIcon.DataContext = new EnergyBarViewModel();
            MainWindow = null;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}
