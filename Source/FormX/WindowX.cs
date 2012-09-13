using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.DrawingX;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.API;
using System.Runtime.InteropServices;

namespace System.Windows.FormsX
{
    /// <summary>
    /// Class for a Metroish form (like the Zune client, the GitHub Windows client, ...) without WPF
    /// </summary>
    public partial class WindowX : Form
    {
        #region Constants

        #region Desktop Window Manager

        const int DWM_BB_BLURREGION = 2;
        const int DWM_BB_ENABLE = 1;
        const int DWM_BB_TRANSITIONONMAXIMIZED = 4;
        const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 0x40;
        const int DWM_FRAME_DURATION_DEFAULT = -1;
        const int DWM_TNP_OPACITY = 4;
        const int DWM_TNP_RECTDESTINATION = 1;
        const int DWM_TNP_RECTSOURCE = 2;
        const int DWM_TNP_SOURCECLIENTAREAONLY = 0x10;
        const int DWM_TNP_VISIBLE = 8;
        const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";
        const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";

        #endregion

        #region WM

        const int WM_DWMCOMPOSITIONCHANGED = 0x31e;
        const int WM_NCLBUTTONDOWN = 0xa1;

        #endregion

        #region Hittest

        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        const int HTGROWBOX = 4;
        const int HTSIZE = 4;
        const int HTMINBUTTON = 8;
        const int HTMAXBUTTON = 9;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 16;
        const int HTBOTTOMRIGHT = 17;
        const int HTBORDER = 18;

        #endregion

        const int BORDERWIDTH = 10;

        #endregion

        #region Readonly

        static readonly bool DwmApiAvailable = (Environment.OSVersion.Version.Major >= 6);
        static readonly Color startColor = Color.FromArgb(102, 0, 0, 0);

        #endregion

        #region Members
        
        bool _marginOk;
        bool _aeroEnabled;
        MARGINS _dwmMargins;
        ResizeDirection _resizeDir;
        Color _buttonColor;
        Color _hoverColor;
        Color _pushColor;
        PushButton _min;
        PushButton _max;
        PushButton _close;

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Constructs a WindowX form instance
        /// </summary>
        public WindowX()
        {
            _buttonColor = startColor;
            _hoverColor = Color.FromArgb(80, 80, 80);
            _pushColor = Color.White;
            _aeroEnabled = false;
            _resizeDir = ResizeDirection.None;
            ClientSize = new Size(640, 480);
            MouseMove += new MouseEventHandler(OnMouseMove);
            MouseDown += new MouseEventHandler(OnMouseDown);
            Activated += new EventHandler(OnActivated);
            SetStyle(ControlStyles.ResizeRedraw, true);
            AutoScaleDimensions = new SizeF(6f, 13f);
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            SetupButtons();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the used close button.
        /// </summary>
        [Description("Gets the used close button.")]
        [Category("FormsX")]
        public PushButton CloseButton
        {
            get { return _close; }
        }

        /// <summary>
        /// Gets the used minimize button.
        /// </summary>
        [Description("Gets the used minimize button.")]
        [Category("FormsX")]
        public PushButton MinimizeButton
        {
            get { return _min; }
        }

        /// <summary>
        /// Gets the used maximize / shrink button.
        /// </summary>
        [Description("Gets the used maximize / shrink button.")]
        [Category("FormsX")]
        public PushButton MaximizeButton
        {
            get { return _max; }
        }

        /// <summary>
        /// Gets or sets the usual color of the buttons.
        /// </summary>
        [Description("Gets or sets the standard color of the three system buttons.")]
        [Category("FormsX")]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                SetButtonNormalImages();
            }
        }

        /// <summary>
        /// Gets or sets the color of the buttons while hovering.
        /// </summary>
        [Description("Gets or sets the hover color of the three system buttons.")]
        [Category("FormsX")]
        public Color HoverColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
                SetButtonHoverImages();
            }
        }

        /// <summary>
        /// Gets or sets the color of the buttons while hovering.
        /// </summary>
        [Description("Gets or sets the push color of the three system buttons.")]
        [Category("FormsX")]
        public Color PushColor
        {
            get { return _pushColor; }
            set
            {
                _pushColor = value;
                SetButtonPushImages();
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the minimize box in the upper right corner.
        /// </summary>
        [Description("Gets or sets the visibility of the minimize box.")]
        [Category("FormsX")]
        public new bool MinimizeBox
        {
            get { return base.MinimizeBox; }
            set
            {
                base.MinimizeBox = value;
                _min.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the maximize box in the upper right corner.
        /// </summary>
        [Description("Gets or sets the visibility of the maximize box.")]
        [Category("FormsX")]
        public new bool MaximizeBox
        {
            get { return base.MaximizeBox; }
            set
            {
                base.MaximizeBox = value;
                _max.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the close box in the upper right corner.
        /// </summary>
        [Description("Gets or sets the visibility of the close box.")]
        [Category("FormsX")]
        public bool CloseBox
        {
            get { return _close.Visible; }
            set
            {
                _close.Visible = value;
            }
        }

        /// <summary>
        /// Gets the status of the aero display manager.
        /// </summary>
        [Browsable(false)]
        public bool AeroEnabled
        {
            get { return _aeroEnabled; }
        }

        ResizeDirection ResizeDirection
        {
            get { return _resizeDir; }
            set
            {
                _resizeDir = value;

                //Change cursor
                switch (value)
                {
                    case ResizeDirection.Left:
                        this.Cursor = Cursors.SizeWE;

                        break;
                    case ResizeDirection.Right:
                        this.Cursor = Cursors.SizeWE;

                        break;
                    case ResizeDirection.Top:
                        this.Cursor = Cursors.SizeNS;

                        break;
                    case ResizeDirection.Bottom:
                        this.Cursor = Cursors.SizeNS;

                        break;
                    case ResizeDirection.BottomLeft:
                        this.Cursor = Cursors.SizeNESW;

                        break;
                    case ResizeDirection.TopRight:
                        this.Cursor = Cursors.SizeNESW;

                        break;
                    case ResizeDirection.BottomRight:
                        this.Cursor = Cursors.SizeNWSE;

                        break;
                    case ResizeDirection.TopLeft:
                        this.Cursor = Cursors.SizeNWSE;

                        break;
                    default:
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
        }

        #endregion

        #region Event Handlers

        void OnActivated(object sender, EventArgs e)
        {
            Window.DwmExtendFrameIntoClientArea(Handle, ref _dwmMargins);
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Width - BORDERWIDTH > e.Location.X && e.Location.X > BORDERWIDTH && e.Location.Y > BORDERWIDTH)
                {
                    MoveControl(Handle);
                }
                else if (this.WindowState != FormWindowState.Maximized)
                {
                    ResizeForm(_resizeDir);
                }
            }
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {        
            //Calculate which direction to resize based on mouse position

            if (e.Location.X < BORDERWIDTH & e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.TopLeft;
            else if (e.Location.X < BORDERWIDTH & e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.BottomLeft;
            else if (e.Location.X > Width - BORDERWIDTH & e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.BottomRight;
            else if (e.Location.X > Width - BORDERWIDTH & e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.TopRight;
            else if (e.Location.X < BORDERWIDTH)
                ResizeDirection = ResizeDirection.Left;
            else if (e.Location.X > Width - BORDERWIDTH)
                ResizeDirection = ResizeDirection.Right;
            else if (e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.Top;
            else if (e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.Bottom;
            else
                ResizeDirection = ResizeDirection.None;
        }

        #endregion

        #region Message Loop

        protected override void WndProc(ref Message m)
        {
            int WM_NCCALCSIZE = 0x83;
            int WM_NCHITTEST = 0x84;
            IntPtr result = default(IntPtr);

            int dwmHandled = Window.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out result);
            
            if (dwmHandled == 1)
            {
                m.Result = result;
                return;
            }

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                NCCALCSIZE_PARAMS nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

                // Adjust (shrink) the client rectangle to accommodate the border:
                nccsp.rect0.Top += 0;
                nccsp.rect0.Bottom += 0;
                nccsp.rect0.Left += 0;
                nccsp.rect0.Right += 0;

                if (!_marginOk)
                {
                    //Set what client area would be for passing to DwmExtendIntoClientArea.
                    //Also remember that at least one of these values NEEDS TO BE > 1, else
                    //it won't work.
                    _dwmMargins.cyTopHeight = 0;
                    _dwmMargins.cxLeftWidth = 0;
                    _dwmMargins.cyBottomHeight = 3;
                    _dwmMargins.cxRightWidth = 0;
                    _marginOk = true;
                }

                Marshal.StructureToPtr(nccsp, m.LParam, false);
                m.Result = IntPtr.Zero;
            }
            else if (m.Msg == WM_NCHITTEST && m.Result.ToInt32() == 0)
            {
                m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        static int LoWord(int dwValue)
        {
            return dwValue & 0xffff;
        }

        static int HiWord(int dwValue)
        {
            return (dwValue >> 16) & 0xffff;
        }

        IntPtr HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
        {
            var p = new Point(LoWord(lparam.ToInt32()), HiWord(lparam.ToInt32()));
            var topleft = RectangleToScreen(new Rectangle(0, 0, _dwmMargins.cxLeftWidth, _dwmMargins.cxLeftWidth));

            if (topleft.Contains(p))
                return new IntPtr(HTTOPLEFT);

            var topright = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, 0, _dwmMargins.cxRightWidth, _dwmMargins.cxRightWidth));

            if (topright.Contains(p))
                return new IntPtr(HTTOPRIGHT);

            var botleft = RectangleToScreen(new Rectangle(0, Height - _dwmMargins.cyBottomHeight, _dwmMargins.cxLeftWidth, _dwmMargins.cyBottomHeight));

            if (botleft.Contains(p))
                return new IntPtr(HTBOTTOMLEFT);

            var botright = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, Height - _dwmMargins.cyBottomHeight, _dwmMargins.cxRightWidth, _dwmMargins.cyBottomHeight));

            if (botright.Contains(p))
                return new IntPtr(HTBOTTOMRIGHT);

            var top = RectangleToScreen(new Rectangle(0, 0, Width, _dwmMargins.cxLeftWidth));

            if (top.Contains(p))
                return new IntPtr(HTTOP);

            var cap = RectangleToScreen(new Rectangle(0, _dwmMargins.cxLeftWidth, Width, _dwmMargins.cyTopHeight - _dwmMargins.cxLeftWidth));

            if (cap.Contains(p))
                return new IntPtr(HTCAPTION);

            var left = RectangleToScreen(new Rectangle(0, 0, _dwmMargins.cxLeftWidth, Height));

            if (left.Contains(p))
                return new IntPtr(HTLEFT);

            var right = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, 0, _dwmMargins.cxRightWidth, Height));

            if (right.Contains(p))
                return new IntPtr(HTRIGHT);

            var bottom = RectangleToScreen(new Rectangle(0, Height - _dwmMargins.cyBottomHeight, Width, _dwmMargins.cyBottomHeight));

            if (bottom.Contains(p))
                return new IntPtr(HTBOTTOM);

            return new IntPtr(HTCLIENT);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prevents a bug that occurs while restoring the form after a minimize operation.
        /// </summary>
        /// <param name="x">The upper left corner x-coordinate.</param>
        /// <param name="y">The upper left corner y-coordinate.</param>
        /// <param name="width">The new width of the form (it is too large - use current Width value).</param>
        /// <param name="height">The new height of the form (it is too large - use the current Height value).</param>
        /// <param name="specified">What kind of boundaries should be changed?!</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Width, Height, specified);
        }

        /// <summary>
        /// Uses the original PerformLayout() method (this is a workaround for the designer).
        /// </summary>
        public new void PerformLayout()
        {
            base.PerformLayout();

            if (ClientSize.Width - _close.Right != 14)
            {
                var k = ClientSize.Width - _close.Right - 14;
                _close.Location = new Point(_close.Location.X + k, _close.Location.Y);
                _max.Location = new Point(_max.Location.X + k, _max.Location.Y);
                _min.Location = new Point(_min.Location.X + k, _min.Location.Y);
            }
        }

        void MoveControl(IntPtr hWnd)
        {
            Window.ReleaseCapture();
            Window.SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        void ResizeForm(ResizeDirection direction)
        {
            int dir = -1;

            switch (direction)
            {
                case ResizeDirection.Left:
                    dir = HTLEFT;
                    break;
                case ResizeDirection.TopLeft:
                    dir = HTTOPLEFT;
                    break;
                case ResizeDirection.Top:
                    dir = HTTOP;
                    break;
                case ResizeDirection.TopRight:
                    dir = HTTOPRIGHT;
                    break;
                case ResizeDirection.Right:
                    dir = HTRIGHT;
                    break;
                case ResizeDirection.BottomRight:
                    dir = HTBOTTOMRIGHT;
                    break;
                case ResizeDirection.Bottom:
                    dir = HTBOTTOM;
                    break;
                case ResizeDirection.BottomLeft:
                    dir = HTBOTTOMLEFT;
                    break;
            }

            if (dir != -1)
            {
                Window.ReleaseCapture();
                Window.SendMessage(Handle, WM_NCLBUTTONDOWN, dir, 0);
            }
        }

        void SetupButtons()
        {
            _min = new PushButton();
            _max = new PushButton();
            _close = new PushButton();
            _max.Width = _close.Width = _min.Width = 32;
            _max.Height = _close.Height = _min.Height = 32;
            _min.Location = new Point(552, 0);
            _max.Location = new Point(584, 0);
            _close.Location = new Point(616, 0);
            _max.Anchor = _close.Anchor = _min.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _min.Click += new EventHandler(OnMinimizeClick);
            _max.Click += new EventHandler(OnMaximizeClick);
            _close.Click += new EventHandler(OnCloseClick);
            _min.HoverBackColor = Color.FromArgb(224, 224, 224);
            _close.HoverBackColor = Color.FromArgb(224, 224, 224);
            _max.HoverBackColor = Color.FromArgb(224, 224, 224);
            _min.PushBackColor = Color.FromArgb(78, 166, 234);
            _close.PushBackColor = Color.FromArgb(78, 166, 234);
            _max.PushBackColor = Color.FromArgb(78, 166, 234);
            SetButtonNormalImages();
            SetButtonHoverImages();
            SetButtonPushImages();
            _close.ToolTipText = "Close";
            _min.ToolTipText = "Minimize";
            _max.ToolTipText = "Maximize";
            Controls.Add(_min);
            Controls.Add(_max);
            Controls.Add(_close);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(WindowState != FormWindowState.Maximized && SizeGripStyle != SizeGripStyle.Hide)
                e.Graphics.DrawImage(Images.resize, new Point(Width - 10, Height - 10));
        }

        void SetButtonPushImages()
        {
            _min.PushImage = Images.min.ChangeColor(startColor, _pushColor);
            _close.PushImage = Images.close.ChangeColor(startColor, _pushColor);

            if (WindowState == FormWindowState.Maximized)
                _max.PushImage = Images.shrink.ChangeColor(startColor, _pushColor);
            else
                _max.PushImage = Images.max.ChangeColor(startColor, _pushColor);
        }

        void SetButtonHoverImages()
        {
            _min.HoverImage = Images.min.ChangeColor(startColor, _hoverColor);
            _close.HoverImage = Images.close.ChangeColor(startColor, _hoverColor);

            if(WindowState == FormWindowState.Maximized)
                _max.HoverImage = Images.shrink.ChangeColor(startColor, _hoverColor);
            else
                _max.HoverImage = Images.max.ChangeColor(startColor, _hoverColor);
        }

        void SetButtonNormalImages()
        {
            _min.Image = Images.min.ChangeColor(startColor, _buttonColor);
            _close.Image = Images.close.ChangeColor(startColor, _buttonColor);

            if (WindowState == FormWindowState.Maximized)
                _max.Image = Images.shrink.ChangeColor(startColor, _buttonColor);
            else
                _max.Image = Images.max.ChangeColor(startColor, _buttonColor);
        }

        void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        void OnMaximizeClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                _max.HoverImage = Images.shrink.ChangeColor(startColor, _hoverColor);
                _max.Image = Images.shrink.ChangeColor(startColor, _buttonColor);
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                _max.HoverImage = Images.max.ChangeColor(startColor, _hoverColor);
                _max.Image = Images.max.ChangeColor(startColor, _buttonColor);
                WindowState = FormWindowState.Normal;
            }
        }

        void OnMinimizeClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion
    }
}
