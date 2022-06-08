namespace ReportHuda
{
    partial class ucTTMay
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
            this.chkDChuyen = new System.Windows.Forms.CheckBox();
            this.lblLoaiMay = new System.Windows.Forms.Label();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDChuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDDiem = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTTBT = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTTBT)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDChuyen
            // 
            this.chkDChuyen.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkDChuyen, 2);
            this.chkDChuyen.Location = new System.Drawing.Point(575, 135);
            this.chkDChuyen.Name = "chkDChuyen";
            this.chkDChuyen.Size = new System.Drawing.Size(382, 38);
            this.chkDChuyen.TabIndex = 3;
            this.chkDChuyen.Text = "Group by theo dây chuyền";
            this.chkDChuyen.UseVisualStyleBackColor = true;
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.AutoSize = true;
            this.lblLoaiMay.Location = new System.Drawing.Point(575, 66);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.lblLoaiMay.Size = new System.Drawing.Size(127, 34);
            this.lblLoaiMay.TabIndex = 4;
            this.lblLoaiMay.Text = "Loại máy";
            this.lblLoaiMay.Click += new System.EventHandler(this.cboLMay_Click);
            // 
            // lblDDiem
            // 
            this.lblDDiem.AutoSize = true;
            this.lblDDiem.Location = new System.Drawing.Point(3, 66);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(126, 34);
            this.lblDDiem.TabIndex = 5;
            this.lblDDiem.Text = "Địa điểm";
            this.lblDDiem.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.AutoSize = true;
            this.lblDChuyen.Location = new System.Drawing.Point(3, 132);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(162, 34);
            this.lblDChuyen.TabIndex = 6;
            this.lblDChuyen.Text = "Dây chuyền";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 660);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Controls.Add(this.grdMay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboLoaiMay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTTBT, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiMay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkDChuyen, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1185, 660);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdMay, 6);
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.grdMay.Location = new System.Drawing.Point(8, 272);
            this.grdMay.LookAndFeel.SkinName = "Blue";
            this.grdMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Margin = new System.Windows.Forms.Padding(8);
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(1169, 314);
            this.grdMay.TabIndex = 28;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvMay.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvMay.OptionsView.ShowGroupPanel = false;
            // 
            // cboLoaiMay
            // 
            this.cboLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiMay.Location = new System.Drawing.Point(751, 74);
            this.cboLoaiMay.Margin = new System.Windows.Forms.Padding(8);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLoaiMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLoaiMay.Properties.NullText = "";
            this.cboLoaiMay.Size = new System.Drawing.Size(385, 39);
            this.cboLoaiMay.TabIndex = 26;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.Location = new System.Drawing.Point(179, 140);
            this.cboDChuyen.Margin = new System.Windows.Forms.Padding(8);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDChuyen.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDChuyen.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDChuyen.Properties.NullText = "";
            this.cboDChuyen.Size = new System.Drawing.Size(385, 39);
            this.cboDChuyen.TabIndex = 25;
            // 
            // cboDDiem
            // 
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.Location = new System.Drawing.Point(179, 74);
            this.cboDDiem.Margin = new System.Windows.Forms.Padding(8);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDDiem.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDDiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDDiem.Properties.NullText = "";
            this.cboDDiem.Size = new System.Drawing.Size(385, 39);
            this.cboDDiem.TabIndex = 24;
            // 
            // chkTTBT
            // 
            this.chkTTBT.Appearance.BackColor = System.Drawing.Color.White;
            this.chkTTBT.Appearance.Options.UseBackColor = true;
            this.chkTTBT.Appearance.Options.UseTextOptions = true;
            this.chkTTBT.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tableLayoutPanel1.SetColumnSpan(this.chkTTBT, 4);
            this.chkTTBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTTBT.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkAll", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkBaoTri", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkThucHien", System.Windows.Forms.CheckState.Checked)});
            this.chkTTBT.Location = new System.Drawing.Point(8, 207);
            this.chkTTBT.LookAndFeel.SkinName = "Blue";
            this.chkTTBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkTTBT.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.chkTTBT.MultiColumn = true;
            this.chkTTBT.Name = "chkTTBT";
            this.chkTTBT.Size = new System.Drawing.Size(1128, 48);
            this.chkTTBT.TabIndex = 22;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.btnThucHien);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 597);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 60);
            this.panel2.TabIndex = 23;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThucHien.Location = new System.Drawing.Point(861, 0);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(159, 60);
            this.btnThucHien.TabIndex = 1;
            this.btnThucHien.Text = "Thuc Hien";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(1020, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(159, 60);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ucTTMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucTTMay";
            this.Size = new System.Drawing.Size(1185, 660);
            this.Load += new System.EventHandler(this.ucTTMay_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTTBT)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkDChuyen;
        private System.Windows.Forms.Label lblLoaiMay;
        private System.Windows.Forms.Label lblDDiem;
        private System.Windows.Forms.Label lblDChuyen;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkTTBT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.LookUpEdit cboDDiem;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.LookUpEdit cboDChuyen;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
    }
}