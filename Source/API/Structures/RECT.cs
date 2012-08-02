using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace System.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(Rectangle rect)
        {
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Right = rect.Right;
            this.Bottom = rect.Bottom;
        }

        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
        }

        public int Height
        {
            get { return (this.Bottom - this.Top); }
        }

        public int Width
        {
            get { return (this.Right - this.Left); }
        }

        public Size Size
        {
            get { return new Size(this.Width, this.Height); }
        }
    }
}
