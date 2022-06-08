namespace MVControl.Forms
{
    partial class frmChonNhanSuChoPBT
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdNhanSu = new DevExpress.XtraGrid.GridControl();
            this.grvNhanSu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cboDON_VI3 = new DevExpress.XtraEditors.LookUpEdit();
            this.cboToPhongBan3 = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTo3 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDonvi = new System.Windows.Forms.Label();
            this.lblDoi = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView7)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDON_VI3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboToPhongBan3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.grdNhanSu, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(748, 526);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // grdNhanSu
            // 
            this.grdNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhanSu.Location = new System.Drawing.Point(3, 43);
            this.grdNhanSu.LookAndFeel.SkinName = "Blue";
            this.grdNhanSu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdNhanSu.MainView = this.grvNhanSu;
            this.grdNhanSu.Name = "grdNhanSu";
            this.grdNhanSu.Size = new System.Drawing.Size(742, 440);
            this.grdNhanSu.TabIndex = 26;
            this.grdNhanSu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNhanSu,
            this.GridView7});
            // 
            // grvNhanSu
            // 
            this.grvNhanSu.GridControl = this.grdNhanSu;
            this.grvNhanSu.Name = "grvNhanSu";
            this.grvNhanSu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvNhanSu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvNhanSu.OptionsBehavior.Editable = false;
            this.grvNhanSu.OptionsLayout.Columns.AddNewColumns = false;
            this.grvNhanSu.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvNhanSu.OptionsView.ColumnAutoWidth = false;
            this.grvNhanSu.OptionsView.EnableAppearanceEvenRow = true;
            this.grvNhanSu.OptionsView.EnableAppearanceOddRow = true;
            this.grvNhanSu.OptionsView.ShowGroupPanel = false;
            this.grvNhanSu.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvNhanSu_CellValueChanged);
            // 
            // GridView7
            // 
            this.GridView7.GridControl = this.grdNhanSu;
            this.GridView7.Name = "GridView7";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.txtTimKiem);
            this.Panel1.Controls.Add(this.btnThoat);
            this.Panel1.Controls.Add(this.btnThucHien);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 489);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(742, 34);
            this.Panel1.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(3, 9);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.LookAndFeel.SkinName = "Blue";
            this.txtTimKiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTimKiem.Size = new System.Drawing.Size(236, 20);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.EditValueChanged += new System.EventHandler(this.txtTimKiem_EditValueChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(641, 2);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThucHien.Location = new System.Drawing.Point(541, 2);
            this.btnThucHien.LookAndFeel.SkinName = "Blue";
            this.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(98, 30);
            this.btnThucHien.TabIndex = 0;
            this.btnThucHien.Text = "btnThucHien";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 6;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.Controls.Add(this.cboDON_VI3, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.cboToPhongBan3, 3, 0);
            this.TableLayoutPanel2.Controls.Add(this.cboTo3, 5, 0);
            this.TableLayoutPanel2.Controls.Add(this.lblDonvi, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.lblDoi, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.lblTo, 4, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 11);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.85965F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(742, 26);
            this.TableLayoutPanel2.TabIndex = 1;
            // 
            // cboDON_VI3
            // 
            this.cboDON_VI3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDON_VI3.Location = new System.Drawing.Point(93, 3);
            this.cboDON_VI3.Name = "cboDON_VI3";
            this.cboDON_VI3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDON_VI3.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDON_VI3.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDON_VI3.Size = new System.Drawing.Size(151, 20);
            this.cboDON_VI3.TabIndex = 0;
            this.cboDON_VI3.EditValueChanged += new System.EventHandler(this.cboDON_VI3_EditValueChanged);
            // 
            // cboToPhongBan3
            // 
            this.cboToPhongBan3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboToPhongBan3.Location = new System.Drawing.Point(340, 3);
            this.cboToPhongBan3.Name = "cboToPhongBan3";
            this.cboToPhongBan3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboToPhongBan3.Properties.LookAndFeel.SkinName = "Blue";
            this.cboToPhongBan3.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboToPhongBan3.Size = new System.Drawing.Size(151, 20);
            this.cboToPhongBan3.TabIndex = 0;
            this.cboToPhongBan3.EditValueChanged += new System.EventHandler(this.cboToPhongBan3_EditValueChanged);
            // 
            // cboTo3
            // 
            this.cboTo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTo3.Location = new System.Drawing.Point(587, 3);
            this.cboTo3.Name = "cboTo3";
            this.cboTo3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo3.Properties.LookAndFeel.SkinName = "Blue";
            this.cboTo3.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboTo3.Size = new System.Drawing.Size(152, 20);
            this.cboTo3.TabIndex = 0;
            this.cboTo3.EditValueChanged += new System.EventHandler(this.cboTo3_EditValueChanged);
            // 
            // lblDonvi
            // 
            this.lblDonvi.AutoSize = true;
            this.lblDonvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonvi.Location = new System.Drawing.Point(3, 0);
            this.lblDonvi.Name = "lblDonvi";
            this.lblDonvi.Size = new System.Drawing.Size(84, 26);
            this.lblDonvi.TabIndex = 24;
            this.lblDonvi.Text = "lblDonvi";
            this.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoi
            // 
            this.lblDoi.AutoSize = true;
            this.lblDoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoi.Location = new System.Drawing.Point(250, 0);
            this.lblDoi.Name = "lblDoi";
            this.lblDoi.Size = new System.Drawing.Size(84, 26);
            this.lblDoi.TabIndex = 24;
            this.lblDoi.Text = "lblDoi";
            this.lblDoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Location = new System.Drawing.Point(497, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(84, 26);
            this.lblTo.TabIndex = 24;
            this.lblTo.Text = "lblTo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmChonNhanSuChoPBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 526);
            this.Controls.Add(this.TableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonNhanSuChoPBT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChonNhanSuChoPBT";
            this.Load += new System.EventHandler(this.frmChonNhanSuChoPBT_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView7)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDON_VI3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboToPhongBan3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal DevExpress.XtraGrid.GridControl grdNhanSu;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvNhanSu;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView7;
        internal System.Windows.Forms.Panel Panel1;
        internal DevExpress.XtraEditors.TextEdit txtTimKiem;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraEditors.SimpleButton btnThucHien;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal DevExpress.XtraEditors.LookUpEdit cboDON_VI3;
        internal DevExpress.XtraEditors.LookUpEdit cboToPhongBan3;
        internal DevExpress.XtraEditors.LookUpEdit cboTo3;
        internal System.Windows.Forms.Label lblDonvi;
        internal System.Windows.Forms.Label lblDoi;
        internal System.Windows.Forms.Label lblTo;
    }
}