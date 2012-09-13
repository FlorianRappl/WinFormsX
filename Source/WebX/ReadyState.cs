using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.WebX
{
    /// <summary>
    /// Represents the different status of a web request.
    /// </summary>
    public enum ReadyState
    {
        Uninitialized = 0,
        Open = 1,
        Sent = 2,
        Receiving = 3,
        Loaded = 4
    }
}
