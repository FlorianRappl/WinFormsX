using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DrawingX;
using System.Drawing.Drawing2D;
using System.Windows.FormsX;

namespace WFX.Showcase
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm()
        {
            InitializeComponent();
            roundRect.Tag = new DrawState(roundRect, DrawRoundRect);
            shadow.Tag = new DrawState(shadow, DrawShadow);
            reflections.Tag = new DrawState(reflections, DrawReflection);
            SetReflectionStart();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            checkRadius1.Tag = numRadius1;
            checkRadius2.Tag = numRadius2;
            checkRadius3.Tag = numRadius3;
            checkRadius4.Tag = numRadius4;
        }

        private void SetReflectionStart()
        {
            var bmp = new Bitmap(640, 480);
            var i = 0;
            var j = 0;

            using (var g = Graphics.FromImage(bmp))
            {
                foreach (var pi in typeof(Resources).GetProperties())
                {
                    var obj = pi.GetValue(null, null);

                    if (obj is Bitmap)
                    {
                        g.DrawImageUnscaled(obj as Image, 100 + 100 * i++, 50 + 100 * j);

                        if (i % 5 == 0)
                        {
                            i = 0;
                            j += 1;
                        }
                    }
                }
            }

            (reflections.Tag as DrawState).StartBitmap = bmp;
            (reflections.Tag as DrawState).Reset();
        }

        private void colorClick(object sender, EventArgs e)
        {
            var p = sender as Panel;
            colorDialog.Color = p.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
                p.BackColor = colorDialog.Color;
        }

        private void DrawRoundRect(Graphics g, Point start, Point end)
        {
            //High quality graphics
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Get coordinates!
            var rect = new Rectangle();
            rect.X = Math.Min(start.X, end.X);
            rect.Y = Math.Min(start.Y, end.Y);
            rect.Width = Math.Abs(start.X - end.X);
            rect.Height = Math.Abs(start.Y - end.Y);
            //Get the radius values (0 - 4)
            var r = new List<float>();
            var ns = new NumericUpDown[] { numRadius1, numRadius2, numRadius3, numRadius4 };

            foreach (var n in ns)
                if (n.Enabled)
                    r.Add(Convert.ToSingle(n.Value));

            //This is the only requirement for a filling and a border
            g.FillRoundRectangle(new SolidBrush(fillColor.BackColor), rect, r.ToArray());
            g.DrawRoundRectangle(new Pen(borderColor.BackColor, 3f), rect, r.ToArray());
        }

        private void resetRect_Click(object sender, EventArgs e)
        {
            (roundRect.Tag as DrawState).Reset();
        }

        private void radiusCheckedChanged(object sender, EventArgs e)
        {
            var s = sender as CheckBox;
            (s.Tag as NumericUpDown).Enabled = s.Checked;
        }

        private void resetShadow_Click(object sender, EventArgs e)
        {
            (shadow.Tag as DrawState).Reset();
        }

        public void DrawShadow(Graphics g, Point start, Point end)
        {
            //High quality graphics
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Get coordinates!
            var rect = new Rectangle();
            rect.X = Math.Min(start.X, end.X);
            rect.Y = Math.Min(start.Y, end.Y);
            rect.Width = Math.Abs(start.X - end.X);
            rect.Height = Math.Abs(start.Y - end.Y);
            //Get dx, dy and blur#
            var shiftx = Convert.ToSingle(dx.Value);
            var shifty = Convert.ToSingle(dy.Value);
            var bl = Convert.ToSingle(blur.Value);

            //Here we draw the shadow
            g.DrawShadow(rect, shadowColor.BackColor, shiftx, shifty, bl);
        }

        public void DrawReflection(Graphics g, Point start, Point end)
        {
            //High quality graphics
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Get coordinates!
            var rect = new Rectangle();
            rect.X = Math.Min(start.X, end.X);
            rect.Y = Math.Min(start.Y, end.Y);
            rect.Width = Math.Abs(start.X - end.X);
            rect.Height = Math.Abs(start.Y - end.Y);
            //Get gap, height, start alpha and end alpha
            var _gap = Convert.ToInt32(gap.Value);
            var _height = Convert.ToInt32(height.Value);
            var _sa = Convert.ToSingle(sAlpha.Value);
            var _ea = Convert.ToSingle(eAlpha.Value);

            //Here we draw the reflection
            g.DrawReflection(reflections.Image, rect, _gap, _height, _sa, _ea);
        }

        private void resetReflections_Click(object sender, EventArgs e)
        {
            (reflections.Tag as DrawState).Reset();
        }

        private void resetSmoothness_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(640, 480);
            var _smooth = Convert.ToSingle(edge.Value) / 100f;
            var _anchor = 0;

            foreach (var a in anchors.CheckedIndices)
                _anchor += (int)Math.Pow(2, (int)a);

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImageSmooth(Resources.google_chrome, new RectangleF(50, 50, 200, 200), (AnchorStyles)_anchor, _smooth);
                g.DrawImage(Resources.google_chrome, new Rectangle(new Point(300, 50), 
                    new Size(200, 200)), new Rectangle(Point.Empty, Resources.google_chrome.Size), GraphicsUnit.Pixel);
            }

            smoothness.Image = bmp;
        }
    }
}
