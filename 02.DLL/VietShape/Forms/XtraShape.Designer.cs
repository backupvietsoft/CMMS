namespace VietShape
{
    partial class XtraShape
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraShape));
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ContextMenuStrip_OnePopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuStrip_TwoPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuHinh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            // 
            // ContextMenuStrip_OnePopup
            // 
            this.ContextMenuStrip_OnePopup.Name = "contextMenuStrip1";
            this.ContextMenuStrip_OnePopup.Size = new System.Drawing.Size(61, 4);
            // 
            // ContextMenuStrip_TwoPopup
            // 
            this.ContextMenuStrip_TwoPopup.Name = "contextMenuStrip2";
            this.ContextMenuStrip_TwoPopup.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContextMenuStrip_TwoPopup.Size = new System.Drawing.Size(61, 4);
            // 
            // menuMay
            // 
            this.menuMay.Name = "contextMenuStrip2";
            this.menuMay.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuMay.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 279);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // mnuHinh
            // 
            this.mnuHinh.Name = "contextMenuStrip2";
            this.mnuHinh.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuHinh.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(430, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 98);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            
            // 
            // XtraShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1156, 842);
            this.ContextMenuStrip = this.ContextMenuStrip_OnePopup;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "XtraShape";
            this.Text = "Vietsoft Ecomaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraShape_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XtraShape_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.XtraShape_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        public System.Windows.Forms.ContextMenuStrip ContextMenuStrip_TwoPopup;
        public System.Windows.Forms.ContextMenuStrip ContextMenuStrip_OnePopup;
        public System.Windows.Forms.ContextMenuStrip menuMay;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ContextMenuStrip mnuHinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}