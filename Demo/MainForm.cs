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
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AnimationForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GraphicsForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MetroForm().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Notify("This is a test! Now this is a lot of fucking text or something like this ...", 2000, 0.5, Color.SteelBlue, Color.Black, Color.White);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AjaxForm().Show();
        }
    }
}
