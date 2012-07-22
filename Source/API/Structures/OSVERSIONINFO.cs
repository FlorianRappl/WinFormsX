using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OSVERSIONINFO
    {
        internal int dwVersionInfoSize;
        internal int dwMajorVersion;
        internal int dwMinorVersion;
        internal int dwBuildNumber;
        internal int dwPlatformId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 127)]
        internal byte[] szCSDVersion;
    }
}
