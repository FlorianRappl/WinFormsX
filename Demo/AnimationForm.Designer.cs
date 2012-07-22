namespace WFX.Showcase
{
    partial class AnimationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationForm));
            this.btResizeForm = new System.Windows.Forms.Button();
            this.btSetTransparent = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btControlAnimate = new System.Windows.Forms.Button();
            this._width = new System.Windows.Forms.NumericUpDown();
            this._height = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._formDuration = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this._opacity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this._transDuration = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this._cart = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._formDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._transDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cart)).BeginInit();
            this.SuspendLayout();
            // 
            // btResizeForm
            // 
            this.btResizeForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResizeForm.Location = new System.Drawing.Point(304, 71);
            this.btResizeForm.Name = "btResizeForm";
            this.btResizeForm.Size = new System.Drawing.Size(127, 43);
            this.btResizeForm.TabIndex = 4;
            this.btResizeForm.Text = "Resize form";
            this.btResizeForm.UseVisualStyleBackColor = true;
            this.btResizeForm.Click += new System.EventHandler(this.btResizeForm_Click);
            // 
            // btSetTransparent
            // 
            this.btSetTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetTransparent.Location = new System.Drawing.Point(304, 51);
            this.btSetTransparent.Name = "btSetTransparent";
            this.btSetTransparent.Size = new System.Drawing.Size(127, 43);
            this.btSetTransparent.TabIndex = 0;
            this.btSetTransparent.Text = "Set form transparency";
            this.btSetTransparent.UseVisualStyleBackColor = true;
            this.btSetTransparent.Click += new System.EventHandler(this.btSetTransparent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._formDuration);
            this.groupBox1.Controls.Add(this._height);
            this.groupBox1.Controls.Add(this._width);
            this.groupBox1.Controls.Add(this.btResizeForm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic form animation";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btSetTransparent);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._transDuration);
            this.groupBox2.Controls.Add(this._opacity);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More sophisticated form animation";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._cart);
            this.groupBox3.Controls.Add(this.btControlAnimate);
            this.groupBox3.Location = new System.Drawing.Point(12, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Some control animation";
            // 
            // btControlAnimate
            // 
            this.btControlAnimate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btControlAnimate.Location = new System.Drawing.Point(304, 51);
            this.btControlAnimate.Name = "btControlAnimate";
            this.btControlAnimate.Size = new System.Drawing.Size(127, 43);
            this.btControlAnimate.TabIndex = 0;
            this.btControlAnimate.Text = "Animate the controls";
            this.btControlAnimate.UseVisualStyleBackColor = true;
            this.btControlAnimate.Click += new System.EventHandler(this.btControlAnimate_Click);
            // 
            // _width
            // 
            this._width.Location = new System.Drawing.Point(87, 24);
            this._width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._width.Name = "_width";
            this._width.Size = new System.Drawing.Size(120, 20);
            this._width.TabIndex = 1;
            this._width.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // _height
            // 
            this._height.Location = new System.Drawing.Point(87, 50);
            this._height.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._height.Name = "_height";
            this._height.Size = new System.Drawing.Size(120, 20);
            this._height.TabIndex = 2;
            this._height.Value = new decimal(new int[] {
            768,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // _formDuration
            // 
            this._formDuration.Location = new System.Drawing.Point(87, 76);
            this._formDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._formDuration.Name = "_formDuration";
            this._formDuration.Size = new System.Drawing.Size(120, 20);
            this._formDuration.TabIndex = 3;
            this._formDuration.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Duration";
            // 
            // _opacity
            // 
            this._opacity.DecimalPlaces = 2;
            this._opacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._opacity.Location = new System.Drawing.Point(87, 25);
            this._opacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._opacity.Name = "_opacity";
            this._opacity.Size = new System.Drawing.Size(120, 20);
            this._opacity.TabIndex = 1;
            this._opacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Opacity";
            // 
            // _transDuration
            // 
            this._transDuration.Location = new System.Drawing.Point(87, 64);
            this._transDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._transDuration.Name = "_transDuration";
            this._transDuration.Size = new System.Drawing.Size(120, 20);
            this._transDuration.TabIndex = 3;
            this._transDuration.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Duration";
            // 
            // _cart
            // 
            this._cart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cart.Image = ((System.Drawing.Image)(resources.GetObject("_cart.Image")));
            this._cart.Location = new System.Drawing.Point(266, 62);
            this._cart.Name = "_cart";
            this._cart.Size = new System.Drawing.Size(32, 32);
            this._cart.TabIndex = 1;
            this._cart.TabStop = false;
            // 
            // AnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 365);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnimationForm";
            this.Text = "AnimationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimationForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._formDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._transDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btResizeForm;
        private System.Windows.Forms.Button btSetTransparent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _formDuration;
        private System.Windows.Forms.NumericUpDown _height;
        private System.Windows.Forms.NumericUpDown _width;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btControlAnimate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _transDuration;
        private System.Windows.Forms.NumericUpDown _opacity;
        private System.Windows.Forms.PictureBox _cart;
    }
}