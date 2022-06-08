namespace VietShape
{
    partial class frmInDSDiChuyenKho
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
            this.lblKhoDen = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.lblKhoDi = new System.Windows.Forms.Label();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cboKhoDen = new Commons.UtcComboBox();
            this.cboKhoDi = new Commons.UtcComboBox();
            this.datDNgay = new System.Windows.Forms.DateTimePicker();
            this.datTNgay = new System.Windows.Forms.DateTimePicker();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKhoDen
            // 
            this.lblKhoDen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKhoDen.AutoSize = true;
            this.lblKhoDen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoDen.Location = new System.Drawing.Point(20, 80);
            this.lblKhoDen.Name = "lblKhoDen";
            this.lblKhoDen.Size = new System.Drawing.Size(46, 13);
            this.lblKhoDen.TabIndex = 129;
            this.lblKhoDen.Text = "Kho đến";
            this.lblKhoDen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNgay.Location = new System.Drawing.Point(204, 23);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(56, 13);
            this.lblDNgay.TabIndex = 130;
            this.lblDNgay.Text = "Đến ngày";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKhoDi
            // 
            this.lblKhoDi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKhoDi.AutoSize = true;
            this.lblKhoDi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoDi.Location = new System.Drawing.Point(20, 51);
            this.lblKhoDi.Name = "lblKhoDi";
            this.lblKhoDi.Size = new System.Drawing.Size(36, 13);
            this.lblKhoDi.TabIndex = 131;
            this.lblKhoDi.Text = "Kho đi";
            this.lblKhoDi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTNgay.AutoSize = true;
            this.lblTNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTNgay.Location = new System.Drawing.Point(20, 24);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(47, 13);
            this.lblTNgay.TabIndex = 132;
            this.lblTNgay.Text = "Từ ngày";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnExit.Location = new System.Drawing.Point(283, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 25);
            this.btnExit.TabIndex = 128;
            this.btnExit.Text = "Thoát ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnStart.Location = new System.Drawing.Point(192, 112);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 25);
            this.btnStart.TabIndex = 127;
            this.btnStart.Text = "Thực hiện";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cboKhoDen
            // 
            this.cboKhoDen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboKhoDen.AssemblyName = "";
            this.cboKhoDen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKhoDen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKhoDen.BackColor = System.Drawing.Color.White;
            this.cboKhoDen.ClassName = "";
            this.cboKhoDen.Display = "TEN_KHO";
            this.cboKhoDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoDen.ErrorProviderControl = null;
            this.cboKhoDen.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboKhoDen.FormattingEnabled = true;
            this.cboKhoDen.IsAll = false;
            this.cboKhoDen.isInputNull = false;
            this.cboKhoDen.IsNew = false;
            this.cboKhoDen.IsNull = true;
            this.cboKhoDen.ItemAll = " < ALL > ";
            this.cboKhoDen.ItemNew = "...New";
            this.cboKhoDen.Items.AddRange(new object[] {
            ""});
            this.cboKhoDen.Location = new System.Drawing.Point(91, 75);
            this.cboKhoDen.MethodName = "";
            this.cboKhoDen.Name = "cboKhoDen";
            this.cboKhoDen.Param = "";
            this.cboKhoDen.Param2 = "";
            this.cboKhoDen.Size = new System.Drawing.Size(275, 22);
            this.cboKhoDen.StoreName = "QL_LISTKHO";
            this.cboKhoDen.TabIndex = 125;
            this.cboKhoDen.Table = null;
            this.cboKhoDen.TextReadonly = false;
            this.cboKhoDen.Value = "MS_KHO";
            // 
            // cboKhoDi
            // 
            this.cboKhoDi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboKhoDi.AssemblyName = "";
            this.cboKhoDi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKhoDi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKhoDi.BackColor = System.Drawing.Color.White;
            this.cboKhoDi.ClassName = "";
            this.cboKhoDi.Display = "TEN_KHO";
            this.cboKhoDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoDi.ErrorProviderControl = null;
            this.cboKhoDi.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboKhoDi.FormattingEnabled = true;
            this.cboKhoDi.IsAll = false;
            this.cboKhoDi.isInputNull = false;
            this.cboKhoDi.IsNew = false;
            this.cboKhoDi.IsNull = true;
            this.cboKhoDi.ItemAll = " < ALL > ";
            this.cboKhoDi.ItemNew = "...New";
            this.cboKhoDi.Items.AddRange(new object[] {
            ""});
            this.cboKhoDi.Location = new System.Drawing.Point(91, 47);
            this.cboKhoDi.MethodName = "";
            this.cboKhoDi.Name = "cboKhoDi";
            this.cboKhoDi.Param = "";
            this.cboKhoDi.Param2 = "";
            this.cboKhoDi.Size = new System.Drawing.Size(275, 22);
            this.cboKhoDi.StoreName = "QL_LISTKHO";
            this.cboKhoDi.TabIndex = 126;
            this.cboKhoDi.Table = null;
            this.cboKhoDi.TextReadonly = false;
            this.cboKhoDi.Value = "MS_KHO";
            // 
            // datDNgay
            // 
            this.datDNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datDNgay.Font = new System.Drawing.Font("Tahoma", 9F);
            this.datDNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datDNgay.Location = new System.Drawing.Point(262, 19);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Size = new System.Drawing.Size(104, 22);
            this.datDNgay.TabIndex = 123;
            // 
            // datTNgay
            // 
            this.datTNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datTNgay.Font = new System.Drawing.Font("Tahoma", 9F);
            this.datTNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datTNgay.Location = new System.Drawing.Point(91, 19);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Size = new System.Drawing.Size(104, 22);
            this.datTNgay.TabIndex = 124;
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(-13, 133);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(10, 20);
            this.grdChung.TabIndex = 134;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // prbIN
            // 
            this.prbIN.Location = new System.Drawing.Point(-19, 112);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(18, 15);
            this.prbIN.TabIndex = 135;
            this.prbIN.Visible = false;
            // 
            // frmInDSDiChuyenKho
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 149);
            this.Controls.Add(this.prbIN);
            this.Controls.Add(this.grdChung);
            this.Controls.Add(this.lblKhoDen);
            this.Controls.Add(this.lblDNgay);
            this.Controls.Add(this.lblKhoDi);
            this.Controls.Add(this.lblTNgay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cboKhoDen);
            this.Controls.Add(this.cboKhoDi);
            this.Controls.Add(this.datDNgay);
            this.Controls.Add(this.datTNgay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmInDSDiChuyenKho";
            this.Text = "frmInDSDiChuyenKho";
            this.Load += new System.EventHandler(this.frmInDSDiChuyenKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblKhoDen;
        internal System.Windows.Forms.Label lblDNgay;
        internal System.Windows.Forms.Label lblKhoDi;
        internal System.Windows.Forms.Label lblTNgay;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnStart;
        internal Commons.UtcComboBox cboKhoDen;
        internal Commons.UtcComboBox cboKhoDi;
        internal System.Windows.Forms.DateTimePicker datDNgay;
        internal System.Windows.Forms.DateTimePicker datTNgay;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
    }
}