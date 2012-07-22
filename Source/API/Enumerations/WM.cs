using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum WM
    {
        SHOWNORMAL = 0x001,
        SIZE = 0x5,
        CLOSE = 0x010,
        ERASEBKGND = 0x14,
        NCCALCSIZE = 0x83,
        NCHITTEST = 0x84,
        KEYDOWN = 0x100,
        KEYUP = 0x101,
        SYSKEYDOWN = 0x104,
        SYSKEYUP = 0x105,
        NCMOUSEMOVE = 0x00A0,
        NCLBUTTONUP = 0x00A2,
        MOUSEFIRST = 0x0200,
        MOUSEMOVE = 0x0200,
        LBUTTONDOWN = 0x0201,
        LBUTTONUP = 0x0202,
        LBUTTONDBLCLK = 0x0203,
        RBUTTONDOWN = 0x0204,
        RBUTTONUP = 0x0205,
        RBUTTONDBLCLK = 0x0206,
        MBUTTONDOWN = 0x0207,
        MBUTTONUP = 0x0208,
        MBUTTONDBLCLK = 0x0209,
        MOUSEWHEEL = 0x020A,
        XBUTTONDOWN = 0x020B,
        XBUTTONUP = 0x020C,
        XBUTTONDBLCLK = 0x020D,
        MOUSELAST = 0x020D,
        NCMOUSELEAVE = 0x02A2,
        HOTKEY = 0x0312,

    }
}
