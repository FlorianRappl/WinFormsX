using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Class to provide basic registry API access
    /// </summary>
    public class Registry
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] System.Text.StringBuilder lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] [MarshalAs(UnmanagedType.LPStr)]string lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, IntPtr lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueEA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, [MarshalAs(UnmanagedType.LPStr)]string lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", SetLastError = true)]
        public static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", SetLastError = true)]
        public static extern int RegCreateKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyA", SetLastError = true)]
        public static extern int RegCreateKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", SetLastError = true)]
        public static extern int RegOpenKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegOpenKeyExA", SetLastError = true)]
        public static extern int RegOpenKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyA", SetLastError = true)]
        public static extern int RegDeleteKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteKeyW", SetLastError = true)]
        public static extern int RegDeleteKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteValueW", SetLastError = true)]
        public static extern int RegDeleteValue(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteValueA", SetLastError = true)]
        public static extern int RegDeleteValueA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", SetLastError = true)]
        public static extern int RegCreateKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyExA", SetLastError = true)]
        public static extern int RegCreateKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyExW", SetLastError = true)]
        public static extern int RegEnumKeyEx(UIntPtr hKey, uint index, StringBuilder lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumKeyExA", SetLastError = true)]
        public static extern int RegEnumKeyExA(UIntPtr hKey, uint index, [MarshalAs(UnmanagedType.LPStr)]string lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumValueW", SetLastError = true)]
        public static extern int RegEnumValue(UIntPtr hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumValueA", SetLastError = true)]
        public static extern int RegEnumValueA(UIntPtr hKey, uint dwIndex, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);
    }
}
