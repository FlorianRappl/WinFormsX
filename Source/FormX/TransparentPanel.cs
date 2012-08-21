using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace System.Windows.FormsX
{
    public class TransparentPanel : Panel
    {
        double opacity;

        public TransparentPanel()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background.
        }
    }
}
