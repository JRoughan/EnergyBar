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
        private bool _stayAwakeOnStartup = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _taskbarIcon = FindResource("TaskbarIcon") as TaskbarIcon;
            _taskbarIcon.DataContext = new EnergyBarViewModel { StayAwake = _stayAwakeOnStartup };
            MainWindow = null;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}
