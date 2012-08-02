using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WTA_OPTIONS
    {
        public uint Flags;
        public uint Mask;
    }
}
