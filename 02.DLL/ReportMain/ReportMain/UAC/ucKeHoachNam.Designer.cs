namespace ReportMain
{
    partial class ucKeHoachNam
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblTuan = new System.Windows.Forms.Label();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblNXuong = new System.Windows.Forms.Label();
            this.cboNXuong = new MVControl.ucComboboxTreeList();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNgay.Properties)).BeginInit();
            
            
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTuan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.datNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNXuong, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboNXuong, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 574);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 505);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(731, 16);
            this.prbIN.TabIndex = 20;
            // 
            // lblTuan
            // 
            this.lblTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuan.Location = new System.Drawing.Point(113, 15);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(82, 25);
            this.lblTuan.TabIndex = 10;
            this.lblTuan.Text = "lblTuan";
            this.lblTuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 101);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(731, 398);
            this.grdChung.TabIndex = 5;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsCustomization.AllowGroup = false;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // datNgay
            // 
            this.datNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datNgay.EditValue = null;
            this.datNgay.Location = new System.Drawing.Point(201, 18);
            this.datNgay.Name = "datNgay";
            this.datNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.datNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNgay.Properties.DisplayFormat.FormatString = "yyyy";
            this.datNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNgay.Properties.EditFormat.FormatString = "yyyy";
            this.datNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNgay.Properties.Mask.EditMask = "yyyy";
            this.datNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datNgay.Properties.NullDate = new System.DateTime(2013, 2, 22, 9, 26, 59, 733);
            this.datNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datNgay.Size = new System.Drawing.Size(163, 20);
            this.datNgay.TabIndex = 1;
            // 
            // lblNXuong
            // 
            this.lblNXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNXuong.Location = new System.Drawing.Point(113, 40);
            this.lblNXuong.Name = "lblNXuong";
            this.lblNXuong.Size = new System.Drawing.Size(82, 25);
            this.lblNXuong.TabIndex = 10;
            this.lblNXuong.Text = "lblNXuong";
            this.lblNXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNXuong
            // 
            this.cboNXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNXuong.Location = new System.Drawing.Point(201, 43);
            this.cboNXuong.Name = "cboNXuong";
            this.cboNXuong.Size = new System.Drawing.Size(163, 20);
            this.cboNXuong.TabIndex = 2;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(370, 40);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(82, 25);
            this.lblDChuyen.TabIndex = 10;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.Location = new System.Drawing.Point(458, 43);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.Size = new System.Drawing.Size(163, 20);
            this.cboDChuyen.TabIndex = 3;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(113, 65);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(82, 25);
            this.lblLMay.TabIndex = 10;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLMay, 3);
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(201, 68);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Size = new System.Drawing.Size(420, 20);
            this.cboLMay.TabIndex = 4;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 6);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 527);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(731, 36);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(644, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 30);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(554, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(84, 30);
            this.btnExecute.TabIndex = 7;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // ucKeHoachNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucKeHoachNam";
            this.Size = new System.Drawing.Size(737, 574);
            this.Load += new System.EventHandler(this.ucKeHoachNam_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNgay.Properties)).EndInit();
            
            
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.Label lblTuan;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.DateEdit datNgay;
        private System.Windows.Forms.Label lblNXuong;
        private MVControl.ucComboboxTreeList cboNXuong;
        private System.Windows.Forms.Label lblDChuyen;
       private MVControl.ucComboboxTreeList cboDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
    }
}
