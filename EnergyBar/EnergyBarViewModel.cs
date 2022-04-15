using System.Windows;
using System.Windows.Input;

namespace EnergyBar
{
    public class EnergyBarViewModel
    {
        /// <summary>
        /// Shows About window if not already open.
        /// </summary>
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => Application.Current.MainWindow == null,
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow = new AboutWindow();
                        Application.Current.MainWindow.Show();
                    }
                };
            }
        }

        /// <summary>
        /// Shuts down the application.
        /// </summary>
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
    }
}
