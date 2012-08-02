using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_TIMING_INFO
    {
        public int cbSize;
        public UNSIGNED_RATIO rateRefresh;
        public UNSIGNED_RATIO rateCompose;
        public long qpcVBlank;
        public long cRefresh;
        public long qpcCompose;
        public long cFrame;
        public long cRefreshFrame;
        public long cRefreshConfirmed;
        public int cFlipsOutstanding;
        public long cFrameCurrent;
        public long cFramesAvailable;
        public long cFrameCleared;
        public long cFramesReceived;
        public long cFramesDisplayed;
        public long cFramesDropped;
        public long cFramesMissed;
    }
}
