using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EnergyBar.Native
{
    internal class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
    }
}
