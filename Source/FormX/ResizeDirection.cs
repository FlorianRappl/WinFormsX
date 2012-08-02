using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.FormsX
{
    /// <summary>
    /// Enumeration for resize direction cursors
    /// </summary>
    public enum ResizeDirection
    {
        None = 0,
        Left = 1,
        TopLeft = 2,
        Top = 4,
        TopRight = 8,
        Right = 16,
        BottomRight = 32,
        Bottom = 64,
        BottomLeft = 128
    }
}
