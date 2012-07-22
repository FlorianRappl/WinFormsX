using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Provides API access to process resources
    /// </summary>
    public class Process
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumProcesses([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] processIds, UInt32 arraySizeBytes, [MarshalAs(UnmanagedType.U4)] out UInt32 bytesCopied);

        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumProcessModules(IntPtr hProcess, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] lphModule, UInt32 cb, [MarshalAs(UnmanagedType.U4)] out UInt32 lpcbNeeded);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern UInt32 GetModuleFileNameExA(IntPtr hProcess, IntPtr hModule,
        [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] UInt32 nSize);

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern UInt32 NtTerminateProcess(IntPtr ProcessHandle, UInt32 ExitStatus);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetExitCodeProcess(IntPtr hProcess, out UInt32 lpExitCode);

        [DllImport("kernel32.dll")]
        public static extern uint WaitForMultipleObjects(uint nCount, IntPtr[] pHandles, Boolean bWaitAll, uint dwMilliseconds);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessId", SetLastError = true)]
        public static extern int GetCurrentProcessId();

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Int32 OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, ref IntPtr TokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(Int32 dwDesiredAccess, Int32 blnheritHandle, UInt32 dwAppProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, int blnheritHandle, int dwAppProcessId);
    }
}
