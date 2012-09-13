using System;
using System.Windows.Forms;
using System.Drawing;

namespace System.Windows.FormsX
{
    /// <summary>
    /// A very simple ToolTip wrapper to display tooltips in a more modern fashion.
    /// </summary>
    public class SimpleToolTip : ToolTip
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public SimpleToolTip()
        {
            InitialDelay = 1000;
            BackColor = Color.Black;
            ForeColor = Color.White;
            UseFading = true;
            UseAnimation = true;
            OwnerDraw = true;
            AutomaticDelay = 500;
            AutoPopDelay = 2000;
            Draw += new DrawToolTipEventHandler(Paint);
        }

        void Paint(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }
    }
}
