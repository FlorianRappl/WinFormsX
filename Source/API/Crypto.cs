using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Class with API methods for cryptographic purposes
    /// </summary>
    public class Crypto
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptAcquireContextW(ref IntPtr hProv, [MarshalAs(UnmanagedType.LPWStr)]string pszContainer, [MarshalAs(UnmanagedType.LPWStr)]string pszProvider, UInt32 dwProvType, UInt32 dwFlags);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptGenRandom(IntPtr hProv, UInt32 dwLen, IntPtr pbBuffer);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptReleaseContext(IntPtr hProv, UInt32 dwFlags);
    }
}
