using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum PROCESS
    {
        TERMINATE = 0x001,
        VM_READ = 0x016,
        SET_INFORMATION = 0x200,
        QUERY_INFORMATION = 0x400,
    }
}
