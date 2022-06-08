namespace MVControl
{
    partial class frmChonMay
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboNMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhomMay = new System.Windows.Forms.Label();
            this.lblTCong = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNMay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdMay, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboNMay, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomMay, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTCong, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1266, 638);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 7);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExecute, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNotALL, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnALL, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTKiem, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 599);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1260, 36);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(1153, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(1043, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Location = new System.Drawing.Point(933, 3);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 8;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(823, 3);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 7;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(3, 13);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 26;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // cboDDiem
            // 
            this.cboDDiem.ColumnDisplayName = null;
            this.cboDDiem.DataSource = null;
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.EditValue = null;
            this.cboDDiem.KeyFieldName = null;
            this.cboDDiem.Location = new System.Drawing.Point(344, 19);
            this.cboDDiem.Margin = new System.Windows.Forms.Padding(4);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(283, 20);
            this.cboDDiem.TabIndex = 5;
            this.cboDDiem.TextValue = null;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValuedChanged);
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(192, 15);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(145, 25);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.ColumnDisplayName = null;
            this.cboDChuyen.DataSource = null;
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.EditValue = null;
            this.cboDChuyen.KeyFieldName = null;
            this.cboDChuyen.Location = new System.Drawing.Point(786, 19);
            this.cboDChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(283, 20);
            this.cboDChuyen.TabIndex = 5;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValuedChanged);
            // 
            // grdMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdMay, 6);
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.Location = new System.Drawing.Point(3, 101);
            this.grdMay.LookAndFeel.SkinName = "Blue";
            this.grdMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(1260, 492);
            this.grdMay.TabIndex = 6;
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
            this.grvMay.ShownEditor += new System.EventHandler(this.grvMay_ShownEditor);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(634, 15);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(145, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(192, 40);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(145, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(343, 43);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.NullText = "";
            this.cboLMay.Size = new System.Drawing.Size(285, 20);
            this.cboLMay.TabIndex = 5;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cboNMay
            // 
            this.cboNMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNMay.Location = new System.Drawing.Point(785, 43);
            this.cboNMay.Name = "cboNMay";
            this.cboNMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNMay.Properties.NullText = "";
            this.cboNMay.Size = new System.Drawing.Size(285, 20);
            this.cboNMay.TabIndex = 5;
            this.cboNMay.EditValueChanged += new System.EventHandler(this.cboNMay_EditValueChanged);
            // 
            // lblNhomMay
            // 
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(634, 40);
            this.lblNhomMay.Name = "lblNhomMay";
            this.lblNhomMay.Size = new System.Drawing.Size(145, 25);
            this.lblNhomMay.TabIndex = 9;
            this.lblNhomMay.Text = "lblNMay";
            this.lblNhomMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTCong
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblTCong, 2);
            this.lblTCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTCong.Location = new System.Drawing.Point(785, 65);
            this.lblTCong.Name = "lblTCong";
            this.lblTCong.Size = new System.Drawing.Size(478, 25);
            this.lblTCong.TabIndex = 9;
            this.lblTCong.Text = "lblLMay";
            this.lblTCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonMay";
            this.Text = "frmChonMay";
            this.Load += new System.EventHandler(this.frmChonMay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private ucComboboxTreeList cboDDiem;
        private System.Windows.Forms.Label lblDDiem;
        private ucComboboxTreeList cboDChuyen;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
        private System.Windows.Forms.Label lblDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.LookUpEdit cboNMay;
        private System.Windows.Forms.Label lblNhomMay;
        private System.Windows.Forms.Label lblTCong;
    }
}