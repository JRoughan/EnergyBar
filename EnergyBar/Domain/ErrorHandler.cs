using System;
using System.Windows;

namespace EnergyBar.Domain
{
    public static class ErrorHandler
    {
        public static void RegisterGlobalErrorHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                MessageBox.Show((e.ExceptionObject as Exception)?.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}