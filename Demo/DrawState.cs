using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WFX.Showcase
{
    class DrawState
    {
        public bool MouseDown { get; set; }
        public Point Start { get; set; }
        public Bitmap State { get; set; }
        public Bitmap StartBitmap { get; set; }

        PictureBox box;
        Action<Graphics, Point, Point> draw;

        public DrawState(PictureBox box, Action<Graphics, Point, Point> draw)
        {
            this.draw = draw;
            this.box = box;
            box.Tag = this;
            box.MouseDown += mouseDown;
            box.MouseUp += mouseUp;
            box.MouseMove += mouseMove;
            box.Resize += resize;
            Reset();
        }

        public void Reset()
        {
            State = new Bitmap(box.Width, box.Height);

            if (StartBitmap != null)
            {
                using (var g = Graphics.FromImage(State))
                {
                    g.DrawImageUnscaled(StartBitmap, Point.Empty);
                }
            }    

            box.Image = State;
        }

        private void resize(object sender, EventArgs e)
        {
            var bmp = new Bitmap(box.Width, box.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(State, 0, 0);
            }

            State = bmp;
            box.Refresh();
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            Start = e.Location;
            MouseDown = true;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;

            using (var g = Graphics.FromImage(State))
            {
                draw(g, Start, e.Location);
            }

            box.Image = State;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                box.Refresh();

                using (var g = box.CreateGraphics())
                {
                    draw(g, Start, e.Location);
                }
            }
        }
    }
}
