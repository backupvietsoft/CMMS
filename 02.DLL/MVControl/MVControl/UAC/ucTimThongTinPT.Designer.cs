namespace MVControl
{
    partial class ucTimThongTinPT
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.prbIN = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtPT = new DevExpress.XtraEditors.TextEdit();
            this.BtnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVideo = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPT.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.prbIN, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.grd, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.Panel2, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(802, 525);
            this.TableLayoutPanel1.TabIndex = 9;
            // 
            // prbIN
            // 
            this.prbIN.EditValue = "";
            this.prbIN.Location = new System.Drawing.Point(3, 465);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.AllowFocused = false;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.MarqueeAnimationSpeed = 10;
            this.prbIN.Properties.NullText = "Exporting excel, please wait..\";";
            this.prbIN.Properties.Stopped = true;
            this.prbIN.Size = new System.Drawing.Size(796, 18);
            this.prbIN.TabIndex = 27;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(3, 39);
            this.grd.LookAndFeel.SkinName = "Blue";
            this.grd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(796, 420);
            this.grd.TabIndex = 25;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnIn);
            this.Panel2.Controls.Add(this.txtPT);
            this.Panel2.Controls.Add(this.BtnThoat);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 489);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(796, 33);
            this.Panel2.TabIndex = 24;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(565, 2);
            this.btnIn.LookAndFeel.SkinName = "Blue";
            this.btnIn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(114, 30);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtPT
            // 
            this.txtPT.Location = new System.Drawing.Point(3, 7);
            this.txtPT.Name = "txtPT";
            this.txtPT.Size = new System.Drawing.Size(270, 20);
            this.txtPT.TabIndex = 6;
            this.txtPT.TextChanged += new System.EventHandler(this.txtPT_TextChanged);
            // 
            // BtnThoat
            // 
            this.BtnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnThoat.Location = new System.Drawing.Point(680, 2);
            this.BtnThoat.LookAndFeel.SkinName = "Blue";
            this.BtnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(114, 30);
            this.BtnThoat.TabIndex = 4;
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 30);
            this.panel1.TabIndex = 26;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Controls.Add(this.btnVideo, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.btnHelp, 0, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(732, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 1;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(64, 30);
            this.TableLayoutPanel3.TabIndex = 24;
            // 
            // btnVideo
            // 
            this.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVideo.Location = new System.Drawing.Point(33, 1);
            this.btnVideo.LookAndFeel.SkinName = "Blue";
            this.btnVideo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnVideo.Margin = new System.Windows.Forms.Padding(1);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(30, 28);
            this.btnVideo.TabIndex = 99;
            this.btnVideo.Tag = "CMMS!frmTimThongTinPT";
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHelp.Location = new System.Drawing.Point(1, 1);
            this.btnHelp.LookAndFeel.SkinName = "Blue";
            this.btnHelp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnHelp.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 28);
            this.btnHelp.TabIndex = 98;
            this.btnHelp.Tag = "CMMS!frmTimThongTinPT";
            // 
            // ucTimThongTinPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "ucTimThongTinPT";
            this.Size = new System.Drawing.Size(802, 525);
            this.Load += new System.EventHandler(this.ucTimThongTinPT_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPT.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal DevExpress.XtraGrid.GridControl grd;
        internal DevExpress.XtraGrid.Views.Grid.GridView grv;
        internal System.Windows.Forms.Panel Panel2;
        internal DevExpress.XtraEditors.TextEdit txtPT;
        internal DevExpress.XtraEditors.SimpleButton BtnThoat;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal DevExpress.XtraEditors.SimpleButton btnVideo;
        internal DevExpress.XtraEditors.SimpleButton btnHelp;
        internal DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.MarqueeProgressBarControl prbIN;
    }
}
