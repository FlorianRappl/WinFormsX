using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.DrawingX;

namespace System.Windows.FormsX
{
    /// <summary>
    /// Class with extensions for Control objects
    /// </summary>
    public static class ControlExtensions
    {
        #region Animation

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        public static void Animate(this Control c, object properties)
        {
            Animate(c, properties, 200, Easing.Linear, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        public static void Animate(this Control c, object properties, int duration)
        {
            Animate(c, properties, duration, Easing.Linear, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The Easing object to use.</param>
        public static void Animate(this Control c, object properties, int duration, Easing easing)
        {
            Animate(c, properties, duration, easing, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The Easing object to use.</param>
        /// <param name="complete">The callback method to invoke when the animation is finished.</param>
        public static void Animate(this Control c, object properties, int duration, Easing easing, Action complete)
        {
            var t = new Timer();
            t.Interval = 30;
            var frame = 0;
            var maxframes = (int)Math.Ceiling(duration / 30.0);
            var reflection = properties.GetType();
            var target = c.GetType();
            var props = reflection.GetProperties();
            var values = new object[props.Length, 2];

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];

                values[i, 1] = prop.GetValue(properties, null);
                var exist = target.GetProperty(prop.Name);

                if (exist == null)
                    throw new ArgumentException("Invalid property to animate. The given properties have to match a property of the control.");

                values[i, 0] = exist.GetValue(c, null);
            }

            t.Tick += (s, e) =>
            {
                frame++;

                for (int i = 0; i < props.Length; i++)
                {
                    var subprops = props[i].PropertyType.GetProperties().Where(m => m.CanRead && m.CanWrite).ToArray();

                    if (subprops.Length == 0)
                    {
                        var start = Convert.ToDouble(values[i, 0]);
                        var end = Convert.ToDouble(values[i, 1]);
                        var value = easing.CalculateStep(frame, maxframes, start, end);

                        if (values[i, 0] is int)
                            target.GetProperty(props[i].Name).SetValue(c, (int)value, null);
                        else if (values[i, 0] is int)
                            target.GetProperty(props[i].Name).SetValue(c, (long)value, null);
                        else if (values[i, 0] is float)
                            target.GetProperty(props[i].Name).SetValue(c, (float)value, null);
                        else if (values[i, 0] is decimal)
                            target.GetProperty(props[i].Name).SetValue(c, (decimal)value, null);
                        else
                            target.GetProperty(props[i].Name).SetValue(c, value, null);
                    }
                    else
                    {
                        var cp = Activator.CreateInstance(values[i, 0].GetType());

                        foreach (var subprop in subprops)
                        {
                            object basevalue = subprop.GetValue(values[i, 0], null);
                            var start = Convert.ToDouble(basevalue);
                            var end = Convert.ToDouble(subprop.GetValue(values[i, 1], null));
                            var value = easing.CalculateStep(frame, maxframes, start, end);

                            if (basevalue is int)
                                subprop.SetValue(cp, (int)value, null);
                            else if (basevalue is int)
                                subprop.SetValue(cp, (long)value, null);
                            else if (basevalue is float)
                                subprop.SetValue(cp, (float)value, null);
                            else if (basevalue is decimal)
                                subprop.SetValue(cp, (decimal)value, null);
                            else
                                subprop.SetValue(cp, value, null);
                        }

                        target.GetProperty(props[i].Name).SetValue(c, cp, null);
                    }
                }

                if (frame == maxframes)
                {
                    t.Stop();

                    if (complete != null)
                        complete();
                }
            };

            t.Start();
        }

        #endregion

        #region Presentation

        /// <summary>
        /// Gives a shadow to this control
        /// </summary>
        /// <param name="control">The current control</param>
        /// <param name="color">The shadow's color</param>
        /// <param name="dx">The horizontal offset of the shadow</param>
        /// <param name="dy">The vertical offset of the shadow</param>
        /// <param name="blur">The blurness of the shadow</param>
        public static void Shadow(this Control control, Color color, float dx, float dy, float blur)
        {
            if (control.Parent != null)
            {
                control.Parent.Resize += (s, e) =>
                {
                    (s as Control).Refresh();
                };
                control.Parent.Paint += (s, e) =>
                {
                    e.Graphics.DrawShadow(new Rectangle(control.Location, control.Size), color, dx, dy, blur);
                }; ;
            }
        }

        #endregion
    }
}
