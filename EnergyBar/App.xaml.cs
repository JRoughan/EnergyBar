using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace EnergyBar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private TaskbarIcon _taskbarIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _taskbarIcon = FindResource("TaskbarIcon") as TaskbarIcon;
            _taskbarIcon.DataContext = new EnergyBarViewModel { StayAwake = true };
            MainWindow = null;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}
