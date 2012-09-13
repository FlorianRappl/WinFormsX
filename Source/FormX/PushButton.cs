using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace System.Windows.FormsX
{
    /// <summary>
    /// A class for a very simple push kind of button.
    /// </summary>
    public class PushButton : Control
    {
        #region Members

        string _toolTipText;
        Color _hoverColor = Color.Transparent;
        Color _pushColor = Color.Transparent;
        Image _idleImage;
        Image _hoverImage;
        Image _pushImage;
        bool _hover;
        bool _push;
        SimpleToolTip tt;

        #endregion

        /// <summary>
        /// The constructor.
        /// </summary>
        public PushButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            tt = new SimpleToolTip();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the tooltip text to display when the mouse is over the button.
        /// </summary>
        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                _toolTipText = value;
                tt.RemoveAll();
                tt.SetToolTip(this, value);
            }
        }

        /// <summary>
        /// Gets or sets the color when the mouse is over the button.
        /// </summary>
        public Color HoverBackColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color when the button is pushed.
        /// </summary>
        public Color PushBackColor
        {
            get { return _pushColor; }
            set
            {
                _pushColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the image that is used when the mouse is not over the button.
        /// </summary>
        public Image Image
        {
            get { return _idleImage; }
            set { _idleImage = value; }
        }

        /// <summary>
        /// Gets or sets the image that is used when the mouse is over the button.
        /// </summary>
        public Image HoverImage
        {
            get { return _hoverImage; }
            set { _hoverImage = value; }
        }

        /// <summary>
        /// Gets or sets the image that is used when the button is pressed.
        /// </summary>
        public Image PushImage
        {
            get { return _pushImage; }
            set { _pushImage = value; }
        }

        #endregion

        #region Overrides

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Refresh();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _push = true;
            Refresh();
            base.OnMouseClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _push = false;
            Refresh();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_push)
            {
                e.Graphics.Clear(PushBackColor);
                
                if(PushImage != null)
                    e.Graphics.DrawImageUnscaled(PushImage, (Width - PushImage.Width) / 2, (Height - PushImage.Height) / 2);
            }
            else if (_hover)
            {
                e.Graphics.Clear(HoverBackColor);

                if(HoverImage != null)
                    e.Graphics.DrawImageUnscaled(HoverImage, (Width - HoverImage.Width) / 2, (Height - HoverImage.Height) / 2);
            }
            else
            {
                e.Graphics.Clear(BackColor);

                if (Image != null)
                    e.Graphics.DrawImageUnscaled(Image, (Width - Image.Width) / 2, (Height - Image.Height) / 2);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Left blank intentionally.
        }

        #endregion
    }
}
