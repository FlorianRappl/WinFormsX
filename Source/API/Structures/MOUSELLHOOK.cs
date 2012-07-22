using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public class MOUSELLHOOK
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public int extraInfo;
    }
}
