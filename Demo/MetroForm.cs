using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.DrawingX;
using System.Text;
using System.Windows.Forms;
using System.Windows.FormsX;

namespace WFX.Showcase
{
    public partial class MetroForm : WindowX
    {
        public MetroForm()
        {
            InitializeComponent();
            button1.Shadow(Color.DarkGray, 10, 10, 20);
            button2.Shadow(Color.FromArgb(100, Color.Black), -10, 10, 15);
            button3.Shadow(Color.Red, 0, 0, 50);
            button4.Shadow(Color.SteelBlue, 2, 2, 10);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = new Rectangle(1, 1, pictureBox1.Width - 5, pictureBox1.Height -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillRoundRectangle(Brushes.Orange, r, 15, 4);
            g.DrawRoundRectangle(Pens.Black, r, 15, 4);
            TextRenderer.DrawText(g, "A Round Rectangle!", Font, r, Color.White, Color.Transparent, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }
}
