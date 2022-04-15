using System;
using System.Windows;
using EnergyBar.Native;

namespace EnergyBar
{
    internal static class SystemState
    {
        private static bool _allowSleep = false;
        private static bool _allowScreenLock = false;

        public static void DisableSleep()
        {
            _allowSleep = false;
            Update();
        }

        public static void EnableSleep()
        {
            _allowSleep = true;
            Update();
        }

        public static void DisableScreenLock()
        {
            _allowScreenLock = false;
            Update();
        }

        public static void EnableScreenLock()
        {
            _allowScreenLock = true;
            Update();
        }

        private static void Update()
        {
            var state = EXECUTION_STATE.ES_CONTINUOUS;
            if (!_allowSleep) state |= EXECUTION_STATE.ES_SYSTEM_REQUIRED;
            if (!_allowScreenLock) state |= EXECUTION_STATE.ES_DISPLAY_REQUIRED;

            var existing = NativeMethods.SetThreadExecutionState(state);
            if (existing == 0) throw new Exception("Cannot set sleep or screen lock state");
        }
    }
}
