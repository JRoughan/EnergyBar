using System;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace EnergyBar
{
    public partial class App
    {
        private TaskbarIcon _taskbarIcon;
        private bool _disableScreenLockOnStartup = true;
        private bool _disableSleepOnStartup = true;

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                MessageBox.Show((e.ExceptionObject as Exception)?.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _taskbarIcon = FindResource("TaskbarIcon") as TaskbarIcon;
            _taskbarIcon.DataContext = new ViewModel
            {
                DisableScreenLock = _disableScreenLockOnStartup,
                DisableSleep = _disableSleepOnStartup
            };
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}
