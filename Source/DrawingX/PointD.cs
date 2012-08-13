using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace System.DrawingX
{
    public struct PointD
    {
        double _x;
        double _y;

        /// <summary>
        /// Represents a new instance of the System.DrawingX.PointD class with member data left uninitialized.
        /// </summary>
        public static readonly PointD Empty = new PointD();

        /// <summary>
        /// Initializes a new instance of the System.Drawing.PointF class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Translates a System.DrawingX.PointD by the negative of a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">A System.DrawingX.PointD to compare.</param>
        /// <param name="sz">A System.DrawingX.PointD to compare.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD operator -(PointD pt, Size sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Translates a System.DrawingX.PointD by the negative of a specified System.DrawingX.SizeD.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.DrawingX.SizeD that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD operator -(PointD pt, SizeD sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Determines whether the coordinates of the specified points are not equal.
        /// </summary>
        /// <param name="left">A System.DrawingX.PointD to compare.</param>
        /// <param name="right">A System.DrawingX.PointD to compare.</param>
        /// <returns>true to indicate the System.DrawingX.PointD.X and System.DrawingX.PointD.Y
        /// values of left and right are not equal; otherwise, false.</returns>
        public static bool operator !=(PointD left, PointD right)
        {
            if (left.Y == right.Y)
                return false;
            else if (left.X == right.X)
                return false;

            return true;
        }

        /// <summary>
        /// Translates a System.DrawingX.PointD by a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">A System.Drawing.Size that specifies the pair of numbers to add
        /// to the coordinates of pt</param>
        /// <returns>Returns the translated System.DrawingX.PointD.</returns>
        public static PointD operator +(PointD pt, Size sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Translates the System.DrawingX.PointD by the specified System.DrawingX.SizeD.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.DrawingX.SizeD that specifies the numbers to add to the x- and
        /// y-coordinates of the System.DrawingX.PointD.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD operator +(PointD pt, SizeD sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Compares two System.DrawingX.PointD structures. The result specifies whether
        /// the values of the System.DrawingX.PointD.X and System.DrawingX.PointD.Y properties
        /// of the two System.DrawingX.PointD structures are equal.
        /// </summary>
        /// <param name="left">A System.DrawingX.PointD to compare.</param>
        /// <param name="right">A System.DrawingX.PointD to compare.</param>
        /// <returns>true if the System.DrawingX.PointD.X and System.DrawingX.PointD.Y values of
        /// the left and right System.DrawingD.PointD structures are equal; otherwise,
        /// false.</returns>
        public static bool operator ==(PointD left, PointD right)
        {
            return !(left != right);
        }

        /// <summary>
        /// Converts an instance of a System.DrawingX.PointD structure to a System.Drawing.PointF structure.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD structure instance to convert.</param>
        /// <returns>The System.Drawing.PointF structure from the original.</returns>
        public static explicit operator PointF(PointD pt)
        {
            return new PointF((float)pt.X, (float)pt.Y);
        }

        /// <summary>
        /// Gets a value indicating whether this System.Drawing.PointF is empty.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        /// <summary>
        /// Gets or sets the x-coordinate of this System.DrawingX.PointD.
        /// </summary>
        public double X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Gets or sets the y-coordinate of this System.DrawingX.PointD.
        /// </summary>
        public double Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Translates a given System.DrawingX.PointD by the specified System.Drawing.Size.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.Drawing.Size that specifies the numbers to add to the coordinates of pt.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD Add(PointD pt, Size sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Translates a given System.DrawingX.PointD by a specified System.DrawingX.SizeD.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.DrawingX.SizeD that specifies the numbers to add to the coordinates of pt.</param>
        /// <returns>The translated System.DrawingD.PointF.</returns>
        public static PointD Add(PointD pt, SizeD sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Specifies whether this System.DrawingX.PointD contains the same coordinates as the specified System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to test.</param>
        /// <returns>This method returns true if obj is a System.DrawingX.PointD and has the same
        /// coordinates as this System.Drawing.Point.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PointD)
            {
                return (PointD)obj == this;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this System.DrawingX.PointD structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this System.DrawingX.PointD
        /// structure.</returns>
        public override int GetHashCode()
        {
            return (int)X + (int)Y;
        }

        /// <summary>
        /// Translates a System.DrawingX.PointD by the negative of a specified size.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.DrawingX.Size that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD Subtract(PointD pt, Size sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Translates a System.DrawingX.PointD by the negative of a specified size.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD to translate.</param>
        /// <param name="sz">The System.DrawingX.SizeD that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated System.DrawingX.PointD.</returns>
        public static PointD Subtract(PointD pt, SizeF sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Converts this System.DrawingX.PointD to a human readable string.
        /// </summary>
        /// <returns>A string that represents this System.DrawingX.PointD.</returns>
        public override string ToString()
        {
            return ((PointF)this).ToString();
        }
    }
}
