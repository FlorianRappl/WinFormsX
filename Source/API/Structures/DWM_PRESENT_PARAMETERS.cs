using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_PRESENT_PARAMETERS
    {
        public int cbSize;
        public int fQueue;
        public long cRefreshStart;
        public int cBuffer;
        public int fUseSourceRate;
        public UNSIGNED_RATIO rateSource;
        public int cRefreshesPerFrame;
        public DWM_SOURCE_FRAME_SAMPLING eSampling;
    }
}
