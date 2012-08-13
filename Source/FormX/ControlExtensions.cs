﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.DrawingX;
using System.Reflection;

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
            var values = new ReflectionCache[props.Length];

            for (int i = 0; i < props.Length; i++)
            {
                values[i] = new ReflectionCache(target.GetProperty(props[i].Name));
                values[i].SetStart(values[i].Info.GetValue(c, null));
                values[i].SetEnd(props[i].GetValue(properties, null));
            }

            t.Tick += (s, e) =>
            {
                frame++;

                for (int i = 0; i < values.Length; i++)
                {
                    values[i].Execute(c, easing, frame, maxframes);
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

        class ReflectionCache
        {
            public ReflectionCache(PropertyInfo info)
            {
                Info = info;

                if(info == null)
                    throw new ArgumentException("Invalid property to animate. The given properties have to match a property of the control.");

                var subprops = info.PropertyType.GetProperties().Where(m => m.CanRead && m.CanWrite).ToArray();

                if (subprops.Length > 0)
                {
                    SubList = new ReflectionCache[subprops.Length];

                    for (int i = 0; i < subprops.Length; i++)
                        SubList[i] = new ReflectionCache(subprops[i]);
                }
            }

            public double Start { get; private set; }

            public double End { get; private set; }

            public bool HasItems { get { return SubList != null; } }

            public Type ListType { get; private set; }

            public ReflectionCache[] SubList { get; private set; }

            public PropertyInfo Info { get; private set; }

            public Action<object, object> SetValue { get; private set; }

            public void Execute(object c, Easing easing, int frame, int frames)
            {
                if (HasItems)
                {
                    var cp = Activator.CreateInstance(ListType);

                    foreach (var item in SubList)
                    {
                        item.Execute(cp, easing, frame, frames);
                    }

                    Info.SetValue(c, cp, null);
                }
                else
                {
                    var value = easing.CalculateStep(frame, frames, Start, End);
                    this.SetValue(c, value);
                }
            }

            public ReflectionCache SetStart(object value)
            {
                if (HasItems)
                {
                    ListType = value.GetType();

                    foreach (var item in SubList)
                    {
                        item.SetStart(item.Info.GetValue(value, null));
                    }
                }
                else
                {
                    Start = Convert.ToDouble(value);

                    if (value is int)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToInt32(v), null);
                        };
                    }
                    else if (value is long)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToInt64(v), null);
                        };
                    }
                    else if (value is float)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToSingle(v), null);
                        };
                    }
                    else if (value is decimal)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToDecimal(v), null);
                        };
                    }
                    else
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, v, null);
                        };
                    }
                }

                return this;
            }

            public ReflectionCache SetEnd(object value)
            {
                if (HasItems)
                {
                    foreach (var item in SubList)
                    {
                        item.SetEnd(item.Info.GetValue(value, null));
                    }
                }
                else
                {
                    End = Convert.ToDouble(value);
                }

                return this;
            }
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
