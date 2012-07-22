using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.API
{
    public enum ETOKEN_PRIVILEGES : uint
    {
        ASSIGN_PRIMARY = 0x1,
        TOKEN_DUPLICATE = 0x2,
        TOKEN_IMPERSONATE = 0x4,
        TOKEN_QUERY = 0x8,
        TOKEN_QUERY_SOURCE = 0x10,
        TOKEN_ADJUST_PRIVILEGES = 0x20,
        TOKEN_ADJUST_GROUPS = 0x40,
        TOKEN_ADJUST_DEFAULT = 0x80,
        TOKEN_ADJUST_SESSIONID = 0x100
    }
}
