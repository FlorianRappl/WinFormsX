using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.FormsX;

namespace WFX.Showcase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Animate(new { Width = 500, Height = 500 });
            //this.Animate(new { Opacity = 0.4, Width = 1200, Height = 500 }, 1500, new SinusEasing(0.2, 2));
            new AnimationForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GraphicsForm().Show();
        }
    }
}
