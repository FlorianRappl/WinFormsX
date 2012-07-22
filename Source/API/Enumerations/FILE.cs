using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum FILE : uint
    {
        BEGIN = 0,
        CURRENT = 1,
        END = 2,
        MOVE_FAILED = 0xFFFFFFFF,
    }
}
