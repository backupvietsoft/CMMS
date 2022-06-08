namespace ReportMain
{
    partial class ucKHBDThietBi
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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.datTNgay = new ReportMain.MMonthYearEdit();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.optLoaiBC = new DevExpress.XtraEditors.RadioGroup();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            
            
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optLoaiBC.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.datTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.optLoaiBC, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(775, 519);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 106);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(769, 346);
            this.grdChung.TabIndex = 5;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung,
            this.gridView2});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.PreviewFieldName = "Description";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdChung;
            this.gridView2.Name = "gridView2";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 480);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(769, 36);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(662, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(552, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 8;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 458);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(769, 16);
            this.prbIN.TabIndex = 6;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(119, 15);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(87, 25);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(212, 18);
            this.datTNgay.MMonthYear = true;
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.DisplayFormat.FormatString = "yyyy";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.EditFormat.FormatString = "yyyy";
            this.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.Mask.EditMask = "yyyy";
            this.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datTNgay.Size = new System.Drawing.Size(172, 20);
            this.datTNgay.TabIndex = 10;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(390, 15);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(87, 25);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.Location = new System.Drawing.Point(483, 18);
            this.cboDDiem.Name = "cboDDiem";
       
            this.cboDDiem.Size = new System.Drawing.Size(172, 20);
            this.cboDDiem.TabIndex = 2;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(119, 40);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(87, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.Location = new System.Drawing.Point(212, 43);
            this.cboDChuyen.Name = "cboDChuyen";
        
            this.cboDChuyen.Size = new System.Drawing.Size(172, 20);
            this.cboDChuyen.TabIndex = 3;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(390, 40);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(87, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(483, 43);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboLMay.Size = new System.Drawing.Size(172, 20);
            this.cboLMay.TabIndex = 4;
            // 
            // optLoaiBC
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.optLoaiBC, 4);
            this.optLoaiBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optLoaiBC.Location = new System.Drawing.Point(119, 68);
            this.optLoaiBC.Name = "optLoaiBC";
            this.optLoaiBC.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optLoaiBC.Properties.Appearance.Options.UseBackColor = true;
            this.optLoaiBC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optLoaiBC.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optLoaiBoKHTTPBT", "optLoaiBoKHTTPBT"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optKhongLoaiBoKHTTPBT", "optKhongLoaiBoKHTTPBT")});
            this.optLoaiBC.Properties.LookAndFeel.SkinName = "Blue";
            this.optLoaiBC.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optLoaiBC.Size = new System.Drawing.Size(536, 24);
            this.optLoaiBC.TabIndex = 38;
            // 
            // ucKHBDThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucKHBDThietBi";
            this.Size = new System.Drawing.Size(775, 519);
            this.Load += new System.EventHandler(this.ucKHBDThietBi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            
            
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optLoaiBC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Label lblDChuyen;
       private MVControl.ucComboboxTreeList cboDChuyen;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblDDiem;
        private MVControl.ucComboboxTreeList cboDDiem;
        private MMonthYearEdit datTNgay;
        private System.Windows.Forms.Label lblLMay;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.RadioGroup optLoaiBC;
    }
}
