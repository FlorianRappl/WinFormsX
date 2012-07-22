using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;

        public MARGINS(int Left, int Right, int Top, int Bottom)
        {
            this.cxLeftWidth = Left;
            this.cxRightWidth = Right;
            this.cyTopHeight = Top;
            this.cyBottomHeight = Bottom;
        }
    } 
}
