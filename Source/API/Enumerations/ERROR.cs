using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum ERROR
    {
        NONE = 0x0,
        BADDB = 0x1,
        BADKEY = 0x2,
        CANTOPEN = 0x3,
        CANTREAD = 0x4,
        CANTWRITE = 0x5,
        OUTOFMEMORY = 0x6,
        ARENA_TRASHED = 0x7,
        ACCESS_DENIED = 0x8,
        INVALID_PARAMETERS = 0x57,
        MORE_DATA = 0xEA,
        NO_MORE_ITEMS = 0x103,
    }
}
