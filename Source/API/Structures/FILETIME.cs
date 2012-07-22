using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public UInt32 dwLowDateTime;
        public UInt32 dwHighDateTime;
    };
}
