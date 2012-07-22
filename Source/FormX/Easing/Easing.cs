using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.FormsX
{
    /// <summary>
    /// Inherit from this class in order to implement your own easing feature
    /// </summary>
    public abstract class Easing
    {
        /// <summary>
        /// Calculate the current value for the given properties.
        /// </summary>
        /// <param name="frame">The current frame number.</param>
        /// <param name="frames">The total frame number.</param>
        /// <param name="start">The start value (at frame 0).</param>
        /// <param name="end">The final value (at frame total - 1).</param>
        /// <returns>The current value.</returns>
        public abstract double CalculateStep(int frame, int frames, double start, double end);

        static Easing linear;
        static Easing sinus;

        /// <summary>
        /// Gets an instance of the provided linear easing.
        /// </summary>
        public static Easing Linear
        {
            get
            {
                if (linear == null)
                    linear = new LinearEasing();

                return linear;
            }
        }

        /// <summary>
        /// Gets an instance of the provided sinus easing.
        /// </summary>
        public static Easing Sinus
        {
            get
            {
                if (sinus == null)
                    sinus = new SinusEasing();

                return sinus;
            }
        }
    }
}
