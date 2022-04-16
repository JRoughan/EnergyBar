using System.Windows;
using EnergyBar.Domain;
using Hardcodet.Wpf.TaskbarNotification;

namespace EnergyBar
{
    public partial class App
    {
        private TaskbarIcon _taskbarIcon;

        public App()
        {
            ErrorHandler.RegisterGlobalErrorHandler();
            NavigationHandler.RegisterGlobalHyperlinkHandler();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _taskbarIcon = FindResource("TaskbarIcon") as TaskbarIcon;
            _taskbarIcon.DataContext = new ViewModel
            {
                DisableScreenLock = ConfigurationHandler.DisableScreenLockOnStartup,
                DisableSleep = ConfigurationHandler.DisableSleepOnStartup
            };
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}
