using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.FormsX
{
    /// <summary>
    /// A class that is a concrete implementation of the abstract easing class
    /// providing a linear easing.
    /// </summary>
    public class LinearEasing : Easing
    {
        public override double CalculateStep(int frame, int frames, double start, double end)
        {
            return start + frame * (end - start) / frames;
        }
    }
}
