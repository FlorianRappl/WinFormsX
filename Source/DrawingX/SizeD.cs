using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace System.DrawingX
{
    public struct SizeD
    {
        double _width;
        double _height;

        /// <summary>
        /// Gets a System.DrawingX.SizeD structure that has a System.DrawingX.SizeD.Height and System.DrawingX.SizeD.Width value of 0.
        /// </summary>
        public static readonly SizeD Empty = new SizeD();
  
        /// <summary>
        /// Initializes a new instance of the System.DrawingX.SizeD structure from the specified System.DrawingX.PointD structure.
        /// </summary>
        /// <param name="pt">The System.DrawingX.PointD structure from which to initialize this System.DrawingX.SizeD structure.</param>
        public SizeD(PointD pt)
        {
            _width = pt.X;
            _height = pt.Y;
        }

        /// <summary>
        /// Initializes a new instance of the System.DrawingX.SizeD structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width component of the new System.DrawingX.SizeD.</param>
        /// <param name="height">The height component of the new System.DrawingX.SizeD.</param>
        public SizeD(double width, double height)
        {
            _width = width;
            _height = height;
        }
 
        /// <summary>
        /// Subtracts the width and height of one System.DrawingX.SizeD structure from
        /// the width and height of another System.DrawingX.SizeD structure.
        /// </summary>
        /// <param name="sz1">The System.DrawingX.SizeD structure on the left side of the subtraction operator.</param>
        /// <param name="sz2">The System.DrawingX.SizeD structure on the right side of the subtraction operator.</param>
        /// <returns>A System.DrawingX.SizeD structure that is the result of the subtraction operation.</returns>
        public static SizeD operator -(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// Tests whether two System.DrawingX.SizeD structures are different.
        /// </summary>
        /// <param name="sz1">The System.DrawingX.SizeD structure on the left of the inequality operator.</param>
        /// <param name="sz2">The System.DrawingX.SizDe structure on the right of the inequality operator.</param>
        /// <returns>true if sz1 and sz2 differ either in width or height; false if sz1 and sz2 are equal.</returns>
        public static bool operator !=(SizeD sz1, SizeD sz2)
        {
            if (sz1.Width == sz2.Width)
                return false;
            else if (sz1.Height == sz2.Height)
                return false;

            return true;
        }

        /// <summary>
        /// Adds the width and height of one System.DrawingX.SizeD structure to the width
        /// and height of another System.DrawingX.SizeD structure.
        /// </summary>
        /// <param name="sz1">The first System.DrawingX.SizeD to add.</param>
        /// <param name="sz2">The second System.DrawingX.SizeD to add.</param>
        /// <returns>A System.DrawingX.SizeD structure that is the result of the addition operation.</returns>
        public static SizeD operator +(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// Tests whether two System.DrawingX.SizeD structures are equal.
        /// </summary>
        /// <param name="sz1">The System.DrawingX.SizeD structure on the left side of the equality operator.</param>
        /// <param name="sz2">The System.DrawingX.SizeD structure on the right of the equality operator.</param>
        /// <returns>true if sz1 and sz2 have equal width and height; otherwise, false.</returns>
        public static bool operator ==(SizeD sz1, SizeD sz2)
        {
            return !(sz1 != sz2);
        }

        /// <summary>
        /// Converts the specified System.DrawingX.SizeD structure to a System.Drawing.Point
        /// structure.
        /// </summary>
        /// <param name="size">The System.DrawingX.SizeD structure to convert.</param>
        /// <returns>The System.DrawingX.PointD structure to which this operator converts.</returns>
        public static explicit operator PointD(SizeD size)
        {
            return new PointD(size.Width, size.Height);
        }

        /// <summary>
        /// Converts the specified System.DrawingX.SizeD structure to a System.Drawing.SizeF
        /// structure.
        /// </summary>
        /// <param name="p">The System.DrawingX.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.SizeF structure to which this operator converts.</returns>
        public static explicit operator SizeF(SizeD p)
        {
            return new SizeF((float)p.Width, (float)p.Height);
        }

        /// <summary>
        /// Gets or sets the vertical component of this System.DrawingX.SizeD structure.
        /// </summary>
        public double Height { get { return _height; } set { _height = value; } }

        /// <summary>
        /// Tests whether this System.DrawingX.SizeD structure has width and height of 0.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        /// <summary>
        /// Gets or sets the horizontal component of this System.DrawingX.SizeD structure.
        /// </summary>
        public double Width { get { return _width; } set { _width = value; } }
 
        /// <summary>
        /// Adds the width and height of one System.DrawingX.SizeD structure to the width and height of another System.DrawingX.SizeD structure.
        /// </summary>
        /// <param name="sz1">The first System.DrawingX.SizeD structure to add.</param>
        /// <param name="sz2">The second System.DrawingX.SizeD structure to add.</param>
        /// <returns>A System.DrawingX.SizeD structure that is the result of the addition operation.</returns>
        public static SizeD Add(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// Converts the specified System.DrawingX.SizeD structure to a System.Drawing.Size
        /// structure by rounding the values of the System.DrawingX.SizeD structure to
        /// the next higher integer values.
        /// </summary>
        /// <param name="value">The System.DrawingX.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.Size structure this method converts to.</returns>
        public static Size Ceiling(SizeD value)
        {
            return new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));
        }
 
        /// <summary>
        /// Tests to see whether the specified object is a System.DrawingX.SizeD structure
        /// with the same dimensions as this System.DrawingX.SizeD structure.
        /// </summary>
        /// <param name="obj">The System.Object to test.</param>
        /// <returns>true if obj is a System.Drawing.Size and has the same width and height as this System.Drawing.Size; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SizeD)
            {
                return (SizeD)obj == this;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this System.DrawingX.SizeD structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this System.DrawingX.SizeD structure.</returns>
        public override int GetHashCode()
        {
            return (int)Width + (int)Height;
        }

        /// <summary>
        /// Converts the specified System.DrawingX.SizeD structure to a System.Drawing.Size
        /// structure by rounding the values of the System.DrawingX.SizeD structure to
        /// the nearest integer values.
        /// </summary>
        /// <param name="value">The System.DrawingX.SizeD structure to convert.</param>
        /// <returns> The System.Drawing.Size structure this method converts to.</returns>
        public static Size Round(SizeD value)
        {
            return new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height));
        }

        /// <summary>
        /// Subtracts the width and height of one System.DrawingX.SizeD structure from the width and height
        /// of another System.DrawingX.SizeD structure.
        /// </summary>
        /// <param name="sz1">The System.DrawingX.SizeD structure on the left side of the subtraction operator.</param>
        /// <param name="sz2">The System.DrawingX.SizeD structure on the right side of the subtraction operator.</param>
        /// <returns>A System.DrawingX.SizeD structure that is a result of the subtraction operation.</returns>
        public static SizeD Subtract(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// Creates a human-readable string that represents this System.DrawingX.SizeD structure.
        /// </summary>
        /// <returns>A string that represents this System.DrawingX.SizeD.</returns>
        public override string ToString()
        {
            return ((SizeF)this).ToString();
        }

        /// <summary>
        /// Converts the specified System.DrawingX.SizeD structure to a System.Drawing.Size structure by
        /// truncating the values of the System.Drawing.SizeF structure to the next lower integer values.
        /// </summary>
        /// <param name="value">The System.DrawingX.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.Size structure this method converts to.</returns>
        public static Size Truncate(SizeD value)
        {
            return new Size((int)Math.Truncate(value.Width), (int)Math.Truncate(value.Height));
        }
    }
}
