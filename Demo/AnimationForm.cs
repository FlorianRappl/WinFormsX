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
    public partial class AnimationForm : Form
    {
        bool finalize;

        public AnimationForm()
        {
            InitializeComponent();
        }

        private void btResizeForm_Click(object sender, EventArgs e)
        {
            var _w = _width.Value;
            var _h = _height.Value;
            var _d = Convert.ToInt32(_formDuration.Value);
            this.Animate(new { Width = _w, Height = _h }, _d, Easing.Linear, () => { MessageBox.Show("Animation complete!"); });
        }

        private void btSetTransparent_Click(object sender, EventArgs e)
        {
            var _o = _opacity.Value;
            var _d = Convert.ToInt32(_transDuration.Value);
            this.Animate(new { Opacity = _o }, _d, Easing.Sinus);
        }

        private void btControlAnimate_Click(object sender, EventArgs e)
        {
            var original = _cart.Location;
            _cart.Animate(new { Location = new Point(0, _cart.Location.Y) }, 5000, Easing.Linear, () => { _cart.Location = original; });
        }

        private void AnimationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finalize)
                e.Cancel = finalize = true;

            this.Animate(new { Location = new Point(600, 400), Size = new Size(0, 0), Opacity = 0.0 }, 500, Easing.Linear, () => { Close(); });
        }
    }
}
