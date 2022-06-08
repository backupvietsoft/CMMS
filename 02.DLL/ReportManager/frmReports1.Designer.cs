namespace ReportManager
{
    partial class frmReports1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports1));
            this.grbList = new System.Windows.Forms.GroupBox();
            this.navBarControl = new ReportManager.navBarControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbList
            // 
            this.grbList.Controls.Add(this.navBarControl);
            this.grbList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbList.Location = new System.Drawing.Point(0, 0);
            this.grbList.Name = "grbList";
            this.grbList.Size = new System.Drawing.Size(275, 600);
            this.grbList.TabIndex = 0;
            this.grbList.TabStop = false;
            this.grbList.Text = "Danh sách báo cáo";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = null;
            this.navBarControl.AllowSelectedLink = true;
            this.navBarControl.Appearance.Item.ForeColor = System.Drawing.SystemColors.Desktop;
            this.navBarControl.Appearance.Item.Options.UseForeColor = true;
            this.navBarControl.Appearance.ItemPressed.BackColor = System.Drawing.Color.Blue;
            this.navBarControl.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Appearance.ItemPressed.ForeColor = System.Drawing.Color.Red;
            this.navBarControl.Appearance.ItemPressed.Options.UseBackColor = true;
            this.navBarControl.Appearance.ItemPressed.Options.UseFont = true;
            this.navBarControl.Appearance.ItemPressed.Options.UseForeColor = true;
            this.navBarControl.ContentButtonHint = null;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Location = new System.Drawing.Point(3, 16);
            this.navBarControl.LookAndFeel.SkinName = "Blue";
            this.navBarControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 181;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(269, 581);
            this.navBarControl.SmallImages = this.imageList1;
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "Danh sách báo cáo";
            this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "events.png");
            this.imageList1.Images.SetKeyName(1, "excel.gif");
            this.imageList1.Images.SetKeyName(2, "icoreport.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(275, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 600);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(278, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtHelp);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(559, 412);
            this.splitContainer1.SplitterDistance = 34;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // txtHelp
            // 
            this.txtHelp.BackColor = System.Drawing.SystemColors.Info;
            this.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.txtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelp.Enabled = false;
            this.txtHelp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelp.ForeColor = System.Drawing.Color.Maroon;
            this.txtHelp.Location = new System.Drawing.Point(39, 0);
            this.txtHelp.Margin = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHelp.Size = new System.Drawing.Size(520, 34);
            this.txtHelp.TabIndex = 2;
            this.txtHelp.Text = "Help...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 34);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(278, 415);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(559, 185);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(278, 412);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(559, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 600);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grbList);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.grbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbList;
        private navBarControl navBarControl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Splitter splitter2;
    }
}