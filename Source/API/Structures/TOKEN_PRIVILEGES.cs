using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TOKEN_PRIVILEGES
    {
        public Int32 PrivilegeCount;
        public LUID_AND_ATTRIBUTES Privileges;
    }
}
