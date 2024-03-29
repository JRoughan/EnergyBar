﻿using System.Windows;
using System.Windows.Input;
using EnergyBar.Domain;
using Prism.Commands;

namespace EnergyBar
{
    public class ViewModel : DependencyObject
    {
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        Application.Current.MainWindow = new AboutWindow();
                        Application.Current.MainWindow.Show();
                    },
                    () => !(Application.Current.MainWindow is AboutWindow));
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                return new DelegateCommand(() => Application.Current.Shutdown());
            }
        }

        public static readonly DependencyProperty DisableSleepProperty = DependencyProperty.Register(
            nameof(DisableSleep), typeof(bool), typeof(ViewModel), new PropertyMetadata(default(bool), ToggleDisableSleep));

        public bool DisableSleep
        {
            get { return (bool) GetValue(DisableSleepProperty); }
            set { SetValue(DisableSleepProperty, value); }
        }

        private static void ToggleDisableSleep(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                SystemStateHandler.DisableSleep();
            }
            else
            {
                SystemStateHandler.EnableSleep();
            }
        }

        public static readonly DependencyProperty DisableScreenLockProperty = DependencyProperty.Register(
            nameof(DisableScreenLock), typeof(bool), typeof(ViewModel), new PropertyMetadata(default(bool), ToggleDisableScreenLock));

        public bool DisableScreenLock
        {
            get { return (bool)GetValue(DisableScreenLockProperty); }
            set { SetValue(DisableScreenLockProperty, value); }
        }

        private static void ToggleDisableScreenLock(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                SystemStateHandler.DisableScreenLock();
            }
            else
            {
                SystemStateHandler.EnableScreenLock();
            }
        }
    }
}
