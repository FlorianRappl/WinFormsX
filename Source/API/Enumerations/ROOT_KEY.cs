using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum ROOT_KEY : uint
    {
        HKEY_CLASSES_ROOT = 0x80000000,
        HKEY_CURRENT_USER = 0x80000001,
        HKEY_LOCAL_MACHINE = 0x80000002,
        HKEY_USERS = 0x80000003,
        HKEY_PERFORMANCE_DATA = 0x80000004,
        HKEY_CURRENT_CONFIG = 0x80000005,
        HKEY_DYN_DATA = 0x80000006
    }
}
