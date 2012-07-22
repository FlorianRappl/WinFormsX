using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum KEY
    {
        ALL_ACCESS = 0xF003F,
        CREATE_LINK = 0x20,
        CREATE_SUB_KEY = 0x4,
        ENUMERATE_SUB_KEYS = 0x8,
        EXECUTE = 0x20019,
        NOTIFY = 0x10,
        QUERY_VALUE = 0x1,
        READ = 0x20019,
        SET_VALUE = 0x2,
        WRITE = 0x20006,
    }
}
