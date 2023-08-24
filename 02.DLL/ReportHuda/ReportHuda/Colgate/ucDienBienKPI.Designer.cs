namespace ReportHuda
{
    partial class ucDienBienKPI
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
            this.lblToYear = new System.Windows.Forms.Label();
            this.lblChonInTheo = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblFromYear = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.cmbToYear = new ReportHuda.MMonthYearEdit();
            this.cmbFromYear = new ReportHuda.MMonthYearEdit();
            this.optLoaiBC = new DevExpress.XtraEditors.RadioGroup();
            this.cboDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optLoaiBC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.lblToYear, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblChonInTheo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDonVi, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFromYear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbToYear, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbFromYear, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.optLoaiBC, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDonVi, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdData, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1144, 703);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(4, 616);
            this.prbIN.Margin = new System.Windows.Forms.Padding(4);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(1136, 22);
            this.prbIN.TabIndex = 52;
            // 
            // lblToYear
            // 
            this.lblToYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToYear.Location = new System.Drawing.Point(575, 22);
            this.lblToYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToYear.Name = "lblToYear";
            this.lblToYear.Size = new System.Drawing.Size(129, 37);
            this.lblToYear.TabIndex = 0;
            this.lblToYear.Text = "lblToYear";
            this.lblToYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChonInTheo
            // 
            this.lblChonInTheo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChonInTheo.Location = new System.Drawing.Point(175, 59);
            this.lblChonInTheo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChonInTheo.Name = "lblChonInTheo";
            this.lblChonInTheo.Size = new System.Drawing.Size(129, 37);
            this.lblChonInTheo.TabIndex = 0;
            this.lblChonInTheo.Text = "lblChonInTheo";
            this.lblChonInTheo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDonVi
            // 
            this.lblDonVi.Location = new System.Drawing.Point(175, 96);
            this.lblDonVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(129, 37);
            this.lblDonVi.TabIndex = 0;
            this.lblDonVi.Text = "lblDonVi";
            this.lblDonVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromYear
            // 
            this.lblFromYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromYear.Location = new System.Drawing.Point(175, 22);
            this.lblFromYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromYear.Name = "lblFromYear";
            this.lblFromYear.Size = new System.Drawing.Size(129, 37);
            this.lblFromYear.TabIndex = 0;
            this.lblFromYear.Text = "lblFromYear";
            this.lblFromYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 646);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1136, 53);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(975, 4);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(157, 45);
            this.btnThoat.TabIndex = 36;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(810, 4);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(157, 45);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // cmbToYear
            // 
            this.cmbToYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbToYear.EditValue = new System.DateTime(2016, 5, 25, 10, 36, 55, 338);
            this.cmbToYear.Location = new System.Drawing.Point(712, 26);
            this.cmbToYear.Margin = new System.Windows.Forms.Padding(4);
            this.cmbToYear.MMonthYear = true;
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbToYear.Properties.DisplayFormat.FormatString = "yyyy";
            this.cmbToYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbToYear.Properties.EditFormat.FormatString = "MM/yyyy";
            this.cmbToYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbToYear.Properties.LookAndFeel.SkinName = "Blue";
            this.cmbToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbToYear.Properties.Mask.EditMask = "yyyy";
            this.cmbToYear.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbToYear.Size = new System.Drawing.Size(255, 26);
            this.cmbToYear.TabIndex = 39;
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFromYear.EditValue = new System.DateTime(2016, 5, 25, 10, 36, 55, 338);
            this.cmbFromYear.Location = new System.Drawing.Point(312, 26);
            this.cmbFromYear.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFromYear.MMonthYear = true;
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFromYear.Properties.DisplayFormat.FormatString = "yyyy";
            this.cmbFromYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFromYear.Properties.EditFormat.FormatString = "yyyy";
            this.cmbFromYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFromYear.Properties.LookAndFeel.SkinName = "Blue";
            this.cmbFromYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbFromYear.Properties.Mask.EditMask = "yyyy";
            this.cmbFromYear.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbFromYear.Size = new System.Drawing.Size(255, 26);
            this.cmbFromYear.TabIndex = 39;
            // 
            // optLoaiBC
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.optLoaiBC, 3);
            this.optLoaiBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optLoaiBC.Location = new System.Drawing.Point(312, 63);
            this.optLoaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.optLoaiBC.Name = "optLoaiBC";
            this.optLoaiBC.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optLoaiBC.Properties.Appearance.Options.UseBackColor = true;
            this.optLoaiBC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optLoaiBC.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optCongTy", "optCongTy"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDonVi", "optDonVi")});
            this.optLoaiBC.Properties.LookAndFeel.SkinName = "Blue";
            this.optLoaiBC.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optLoaiBC.Size = new System.Drawing.Size(655, 29);
            this.optLoaiBC.TabIndex = 40;
            this.optLoaiBC.SelectedIndexChanged += new System.EventHandler(this.optLoaiBC_SelectedIndexChanged);
            // 
            // cboDonVi
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDonVi, 3);
            this.cboDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDonVi.Location = new System.Drawing.Point(311, 99);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.NullText = "";
            this.cboDonVi.Size = new System.Drawing.Size(657, 26);
            this.cboDonVi.TabIndex = 41;
            this.cboDonVi.EditValueChanged += new System.EventHandler(this.cboDonVi_EditValueChanged);
            // 
            // grdData
            // 
            this.grdData.Location = new System.Drawing.Point(3, 180);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(165, 200);
            this.grdData.TabIndex = 42;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grdData.Visible = false;
            // 
            // grvData
            // 
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // ucDienBienKPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucDienBienKPI";
            this.Size = new System.Drawing.Size(1144, 703);
            this.Load += new System.EventHandler(this.ucDienBienKPI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optLoaiBC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFromYear;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MMonthYearEdit cmbFromYear;
        private DevExpress.XtraEditors.RadioGroup optLoaiBC;
        private MMonthYearEdit cmbToYear;
        private System.Windows.Forms.Label lblToYear;
        private System.Windows.Forms.Label lblDonVi;
        private DevExpress.XtraEditors.LookUpEdit cboDonVi;
        private System.Windows.Forms.Label lblChonInTheo;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
    }
}
