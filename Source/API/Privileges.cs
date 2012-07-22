using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Provides API access to make privilege changes and such
    /// </summary>
    public class Privileges
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 LookupPrivilegeValueW(Int32 lpSystemName, [MarshalAs(UnmanagedType.LPWStr)]string lpName, ref LUID lpLuid);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenPrivileges", SetLastError = true)]
        public static extern int AdjustTokenPrivileges(IntPtr TokenHandle, int DisableAllPriv, ref TOKEN_PRIVILEGES NewState, int BufferLength, int PreviousState, int ReturnLength);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupPrivilegeValueA", SetLastError = true)]
        public static extern int LookupPrivilegeValueA(int lpSystemName, [MarshalAs(UnmanagedType.LPStr)]string lpName, ref LUID lpLuid);
    }
}
