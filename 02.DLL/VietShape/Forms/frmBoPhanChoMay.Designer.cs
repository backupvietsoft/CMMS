namespace VietShape
{
    partial class frmBoPhanChoMay
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
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDanhsachBP = new DevExpress.XtraEditors.GroupControl();
            this.grdBP = new DevExpress.XtraGrid.GridControl();
            this.grvBP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.txtTimKiemTheoMaPBT_1 = new Commons.utcTextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDanhsachBP)).BeginInit();
            this.grpDanhsachBP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBP)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiemTheoMaPBT_1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TableLayoutPanel3.Controls.Add(this.grpDanhsachBP, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.Panel2, 0, 1);
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 12);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(822, 487);
            this.TableLayoutPanel3.TabIndex = 68;
            // 
            // grpDanhsachBP
            // 
            this.TableLayoutPanel3.SetColumnSpan(this.grpDanhsachBP, 2);
            this.grpDanhsachBP.Controls.Add(this.grdBP);
            this.grpDanhsachBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhsachBP.Location = new System.Drawing.Point(3, 3);
            this.grpDanhsachBP.LookAndFeel.SkinName = "Blue";
            this.grpDanhsachBP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpDanhsachBP.Name = "grpDanhsachBP";
            this.grpDanhsachBP.Size = new System.Drawing.Size(816, 447);
            this.grpDanhsachBP.TabIndex = 28;
            this.grpDanhsachBP.Text = "grpDanhsachBP";
            // 
            // grdBP
            // 
            this.grdBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBP.Location = new System.Drawing.Point(2, 22);
            this.grdBP.LookAndFeel.SkinName = "Blue";
            this.grdBP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBP.MainView = this.grvBP;
            this.grdBP.Name = "grdBP";
            this.grdBP.Size = new System.Drawing.Size(812, 423);
            this.grdBP.TabIndex = 5;
            this.grdBP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBP});
            // 
            // grvBP
            // 
            this.grvBP.GridControl = this.grdBP;
            this.grvBP.Name = "grvBP";
            this.grvBP.OptionsView.ColumnAutoWidth = false;
            this.grvBP.OptionsView.ShowGroupPanel = false;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TableLayoutPanel3.SetColumnSpan(this.Panel2, 2);
            this.Panel2.Controls.Add(this.btnDuyet);
            this.Panel2.Controls.Add(this.txtTimKiemTheoMaPBT_1);
            this.Panel2.Controls.Add(this.lblTimKiem);
            this.Panel2.Controls.Add(this.btnThoat);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 456);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(816, 28);
            this.Panel2.TabIndex = 26;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.Location = new System.Drawing.Point(604, 0);
            this.btnDuyet.LookAndFeel.SkinName = "Blue";
            this.btnDuyet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(104, 28);
            this.btnDuyet.TabIndex = 35;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // txtTimKiemTheoMaPBT_1
            // 
            this.txtTimKiemTheoMaPBT_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiemTheoMaPBT_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(193)))), ((int)(((byte)(222)))));
            this.txtTimKiemTheoMaPBT_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTimKiemTheoMaPBT_1.ErrorProviderControl = null;
            this.txtTimKiemTheoMaPBT_1.FieldName = "";
            this.txtTimKiemTheoMaPBT_1.IsNull = true;
            this.txtTimKiemTheoMaPBT_1.Location = new System.Drawing.Point(85, 4);
            this.txtTimKiemTheoMaPBT_1.MaxLength = 0;
            this.txtTimKiemTheoMaPBT_1.Multiline = false;
            this.txtTimKiemTheoMaPBT_1.Name = "txtTimKiemTheoMaPBT_1";
            this.txtTimKiemTheoMaPBT_1.PasswordChar = '\0';
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.Options.UseBackColor = true;
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.Options.UseFont = true;
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTimKiemTheoMaPBT_1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtTimKiemTheoMaPBT_1.Properties.ReadOnly = true;
            this.txtTimKiemTheoMaPBT_1.ReadOnly = true;
            this.txtTimKiemTheoMaPBT_1.Size = new System.Drawing.Size(120, 20);
            this.txtTimKiemTheoMaPBT_1.TabIndex = 32;
            this.txtTimKiemTheoMaPBT_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTimKiemTheoMaPBT_1.TextTypeMode = Commons.TypeMode.None;
            this.txtTimKiemTheoMaPBT_1.Visible = false;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(3, 8);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(47, 13);
            this.lblTimKiem.TabIndex = 33;
            this.lblTimKiem.Text = "Tìm kiếm";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimKiem.Visible = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(712, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 28);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.TableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(822, 499);
            this.panel3.TabIndex = 70;
            // 
            // frmBoPhanChoMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 499);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBoPhanChoMay";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmChonPTTuBoPhan_Load);
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDanhsachBP)).EndInit();
            this.grpDanhsachBP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBP)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiemTheoMaPBT_1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.Panel Panel2;
        internal Commons.utcTextBox txtTimKiemTheoMaPBT_1;
        internal System.Windows.Forms.Label lblTimKiem;
        internal DevExpress.XtraEditors.SimpleButton btnDuyet;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.GroupControl grpDanhsachBP;
        internal DevExpress.XtraGrid.GridControl grdBP;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvBP;
        private System.Windows.Forms.Panel panel3;
    }
}