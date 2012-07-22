using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DTTOPTS
    {
        public uint dwSize;
        public uint dwFlags;
        public uint crText;
        public uint crBorder;
        public uint crShadow;
        public int iTextShadowType;
        public POINT ptShadowOffset;
        public int iBorderSize;
        public int iFontPropId;
        public int iColorPropId;
        public int iStateId;
        public int fApplyOverlay;
        public int iGlowSize;
        public IntPtr pfnDrawTextCallback;
        public int lParam;
    }
}
