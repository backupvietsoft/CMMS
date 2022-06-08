namespace VietShape
{
    partial class frmViewLog
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
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.grdLog = new DevExpress.XtraGrid.GridControl();
            this.grvLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblForm = new System.Windows.Forms.Label();
            this.cboMenuLog = new MVControl.ucComboboxTreeList();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.dtTNgay = new DevExpress.XtraEditors.DateEdit();
            this.dtDNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31578F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdLog, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblForm, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboMenuLog, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtTNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtDNgay, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 638);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(846, 605);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grdLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdLog, 8);
            this.grdLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLog.Location = new System.Drawing.Point(3, 36);
            this.grdLog.LookAndFeel.SkinName = "Blue";
            this.grdLog.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLog.MainView = this.grvLog;
            this.grdLog.Name = "grdLog";
            this.grdLog.Size = new System.Drawing.Size(941, 557);
            this.grdLog.TabIndex = 27;
            this.grdLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLog});
            // 
            // grvLog
            // 
            this.grvLog.GridControl = this.grdLog;
            this.grvLog.Name = "grvLog";
            this.grvLog.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvLog_RowStyle);
            this.grvLog.DoubleClick += new System.EventHandler(this.grvLog_DoubleClick);
            // 
            // lblForm
            // 
            this.lblForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblForm.Location = new System.Drawing.Point(102, 8);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(93, 25);
            this.lblForm.TabIndex = 28;
            this.lblForm.Text = "lblForm";
            this.lblForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMenuLog
            // 
            this.cboMenuLog.ColumnDisplayName = null;
            this.cboMenuLog.DataSource = null;
            this.cboMenuLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMenuLog.EditValue = null;
            this.cboMenuLog.KeyFieldName = null;
            this.cboMenuLog.Location = new System.Drawing.Point(201, 11);
            this.cboMenuLog.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboMenuLog.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboMenuLog.Name = "cboMenuLog";
            this.cboMenuLog.ParentFieldName = null;
            this.cboMenuLog.ReadOnly = false;
            this.cboMenuLog.SelectedIndex = 0;
            this.cboMenuLog.Size = new System.Drawing.Size(243, 20);
            this.cboMenuLog.TabIndex = 35;
            this.cboMenuLog.TextValue = null;
            this.cboMenuLog.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValuedChanged);
            // 
            // txtTKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTKiem, 2);
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(3, 615);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(192, 20);
            this.txtTKiem.TabIndex = 12;
            // 
            // dtTNgay
            // 
            this.dtTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTNgay.EditValue = null;
            this.dtTNgay.Location = new System.Drawing.Point(549, 11);
            this.dtTNgay.Name = "dtTNgay";
            this.dtTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dtTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtTNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTNgay.Size = new System.Drawing.Size(93, 20);
            this.dtTNgay.TabIndex = 36;
            this.dtTNgay.EditValueChanged += new System.EventHandler(this.dtDNgay_EditValueChanged);
            // 
            // dtDNgay
            // 
            this.dtDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDNgay.EditValue = null;
            this.dtDNgay.Location = new System.Drawing.Point(747, 11);
            this.dtDNgay.Name = "dtDNgay";
            this.dtDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dtDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtDNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDNgay.Size = new System.Drawing.Size(93, 20);
            this.dtDNgay.TabIndex = 36;
            this.dtDNgay.EditValueChanged += new System.EventHandler(this.dtDNgay_EditValueChanged);
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(450, 8);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(93, 25);
            this.lblTNgay.TabIndex = 28;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(648, 8);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(93, 25);
            this.lblDNgay.TabIndex = 28;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmViewLog";
            this.Text = "frmViewLog";
            this.Load += new System.EventHandler(this.frmViewLog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraGrid.GridControl grdLog;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvLog;
        private System.Windows.Forms.Label lblForm;
        private MVControl.ucComboboxTreeList cboMenuLog;
        private DevExpress.XtraEditors.DateEdit dtTNgay;
        private DevExpress.XtraEditors.DateEdit dtDNgay;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblDNgay;
    }
}