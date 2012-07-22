using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public int lpSecurityDescriptor;
        public bool bInheritHandle;
    }
}
