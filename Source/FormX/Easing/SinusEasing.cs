using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.FormsX
{
    /// <summary>
    /// A class providing a more sophisticated implemenation of the abstract
    /// Easing class.
    /// </summary>
    public class SinusEasing : Easing
    {
        /// <summary>
        /// Gets or sets the amplitude of the sinus wave.
        /// </summary>
        public double Amplitude { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the sinus wave.
        /// </summary>
        public double Frequency { get; set; }

        /// <summary>
        /// Creates an object of the sinus easing.
        /// </summary>
        /// <param name="amplitude">The amplitude of the sinus wave.</param>
        /// <param name="frequency">The frequency of the sinus wave.</param>
        public SinusEasing(double amplitude = 0.2, double frequency = 2.0)
        {
            Amplitude = amplitude;
            Frequency = frequency;
        }

        public override double CalculateStep(int frame, int frames, double start, double end)
        {
            return start + frame * (end - start) / frames + Math.Sin(frame * Frequency * 2 * Math.PI / frames) * (end - start) * Amplitude;
        }
    }
}
