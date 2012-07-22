using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATAA
    {
        public Int32 dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public Int32 nFileSizeHigh;
        public Int32 nFileSizeLow;
        public Int32 dwReserved0;
        public Int32 dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAX.PATH)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAX.ALTERNATE)]
        public string cAlternate;
    }
}
