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
    }
}
