using System.Windows;
using System.Windows.Input;
using EnergyBar.Native;

namespace EnergyBar
{
    public class EnergyBarViewModel : DependencyObject
    {
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => !(Application.Current.MainWindow is AboutWindow),
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow = new AboutWindow();
                        Application.Current.MainWindow.Show();
                    }
                };
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () => Application.Current.Shutdown()
                };
            }
        }

        public static readonly DependencyProperty StayAwakeProperty = DependencyProperty.Register(
            "StayAwake", typeof(bool), typeof(EnergyBarViewModel), new PropertyMetadata(default(bool), new PropertyChangedCallback(ToggleStayAwake)));

        public bool StayAwake
        {
            get { return (bool) GetValue(StayAwakeProperty); }
            set { SetValue(StayAwakeProperty, value); }
        }

        private static void ToggleStayAwake(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
            }
            else
            {
                NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            }
        }
    }
}
