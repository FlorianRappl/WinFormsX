using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;

namespace System.DrawingX
{
    /// <summary>
    /// Class with extensions for Bitmap and Image objects
    /// </summary>
    public static class ImageExtensions
    {
        #region Dominant Color

        /// <summary>
        /// Finds the dominant color of the given picture
        /// </summary>
        /// <param name="bitmap">The image where the dominant color should be found</param>
        /// <returns>The dominant color of the provided bitmap</returns>
        public static Color FindDominantColor(this Bitmap bitmap)
        {
            var colorCount = new Hashtable();
            var maxCount = 0;
            var dominantColor = Color.White;

            //Taken from MSDN - http://msdn.microsoft.com/en-us/library/5ey6h79d.aspx
            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var ptr = data.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            var bytes = Math.Abs(data.Stride) * bitmap.Height;
            var values = new byte[bytes];
            var bpp = data.Stride / data.Width;

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, values, 0, bytes);

            for (var i = 0; i < bytes; i += bpp)
            {
                var color = Color.FromArgb(
                    //Check required (there could be 3 bytes per pixel (no alpha) or 4) --- all other ones will be excluded...
                    bpp == 4 ? values[i + 3] : 255, //Alpha
                    values[i + 2], //Red
                    values[i + 1], //Green
                    values[i + 0]);//Blue

                // ignore fully transparent ones
                if (color.A == 0)
                    continue;

                // ignore white
                if (color.Equals(Color.White))
                    continue;

                var count = 1;

                if (colorCount.Contains(color))
                {
                    count = (int)colorCount[color] + 1;
                    colorCount[color] = count;
                }
                else
                    colorCount.Add(color, count);

                // keep track of the color that appears the most times
                if (count > maxCount)
                {
                    maxCount = count;
                    dominantColor = color;
                }
            }

            bitmap.UnlockBits(data);
            return dominantColor;
        }

        #endregion

        #region Resize
        
        /// <summary>
        /// Resizes an image with a high quality bicubic interpolation mode
        /// </summary>
        /// <param name="originalImage">The image to resize</param>
        /// <param name="newWidth">The new width in pixels</param>
        /// <param name="newHeight">The new height in pixels</param>
        /// <returns>A resized version of the original image</returns>
        public static Image Resize(this Image originalImage, int newWidth, int newHeight)
        {
            var smallVersion = new Bitmap(newWidth, newHeight);

            using (var g = Graphics.FromImage(smallVersion))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }
  
            return smallVersion;
        }

        #endregion

        #region Grayscale

        /// <summary>
        /// Converts an image to grayscale
        /// </summary>
        /// <param name="originalImage">The image to grayscale</param>
        /// <returns>A grayscale version of the image</returns>
        public static Image GetGrayScaleVersion(this Image originalImage)
        {
            var cm = new ColorMatrix(new float[][] 
            {
                new float[] {.3f, .3f, .3f, 0, 0},
                new float[] {.59f, .59f, .59f, 0, 0},
                new float[] {.11f, .11f, .11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
           });

            //http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
            //create a blank bitmap the same size as original
            var newBitmap = new Bitmap(originalImage.Width, originalImage.Height);

            //get a graphics object from the new image
            using (var g = Graphics.FromImage(newBitmap))
            {
                //create some image attributes
                ImageAttributes attributes = new ImageAttributes();

                //set the color matrix attribute
                attributes.SetColorMatrix(cm);

                //draw the original image on the new image using the grayscale color matrix
                g.DrawImage(originalImage, new Rectangle(Point.Empty, originalImage.Size),
                    0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }

        #endregion

        #region Change Color

        /// <summary>
        /// Changes a specific color of the bitmap and returns a new bitmap with the modified color.
        /// </summary>
        /// <param name="bitmap">The original bitmap</param>
        /// <param name="source">The color to change</param>
        /// <param name="destination">The final color value</param>
        /// <returns>The modified bitmap</returns>
        public static Bitmap ChangeColor(this Bitmap bitmap, Color source, Color destination)
        {
            var newBitmap = new Bitmap(bitmap);
            var data = newBitmap.LockBits(new Rectangle(Point.Empty, newBitmap.Size), ImageLockMode.ReadWrite, newBitmap.PixelFormat);
            var ptr = data.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            var bytes = Math.Abs(data.Stride) * newBitmap.Height;
            var values = new byte[bytes];
            var bpp = data.Stride / data.Width;

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, values, 0, bytes);

            for (var i = 0; i < bytes; i += bpp)
            {
                var color = Color.FromArgb(
                    bpp == 4 ? values[i + 3] : 255, //Alpha
                    values[i + 2], //Red
                    values[i + 1], //Green
                    values[i + 0]);//Blue

                if (color == source)
                {
                    if (bpp == 4)
                        values[i + 3] = destination.A;

                    values[i + 2] = destination.R;
                    values[i + 1] = destination.G;
                    values[i + 0] = destination.B;
                }
            }

            Marshal.Copy(values, 0, ptr, bytes);
            newBitmap.UnlockBits(data);
            return newBitmap;
        }

        #endregion
    }
}
