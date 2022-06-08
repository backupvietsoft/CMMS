namespace MVControl
{
    partial class ucMonitoring
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
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.optGroup = new DevExpress.XtraEditors.RadioGroup();
            this.grpMonitoring = new DevExpress.XtraEditors.GroupControl();
            this.gdMonitoring = new DevExpress.XtraGrid.GridControl();
            this.gvMonitoring = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectedAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeselectedAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboStaff = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitoring)).BeginInit();
            this.grpMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 1;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel3.Controls.Add(this.optGroup, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.grpMonitoring, 0, 2);
            this.TableLayoutPanel3.Controls.Add(this.panel1, 0, 3);
            this.TableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 4;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(778, 367);
            this.TableLayoutPanel3.TabIndex = 96;
            // 
            // optGroup
            // 
            this.optGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.optGroup.EditValue = "optAll";
            this.optGroup.Location = new System.Drawing.Point(3, 62);
            this.optGroup.Name = "optGroup";
            this.optGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optGroup.Properties.Appearance.Options.UseBackColor = true;
            this.optGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optAll", "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optWorkSite", "Work site"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDevice", "Device")});
            this.optGroup.Properties.LookAndFeel.SkinName = "Blue";
            this.optGroup.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optGroup.Size = new System.Drawing.Size(349, 25);
            this.optGroup.TabIndex = 100;
            this.optGroup.SelectedIndexChanged += new System.EventHandler(this.optGroup_SelectedIndexChanged);
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Controls.Add(this.gdMonitoring);
            this.grpMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMonitoring.Location = new System.Drawing.Point(3, 93);
            this.grpMonitoring.LookAndFeel.SkinName = "Blue";
            this.grpMonitoring.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Size = new System.Drawing.Size(772, 232);
            this.grpMonitoring.TabIndex = 97;
            this.grpMonitoring.Text = "grpMonitoring";
            // 
            // gdMonitoring
            // 
            this.gdMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMonitoring.Location = new System.Drawing.Point(2, 22);
            this.gdMonitoring.LookAndFeel.SkinName = "Blue";
            this.gdMonitoring.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdMonitoring.MainView = this.gvMonitoring;
            this.gdMonitoring.Name = "gdMonitoring";
            this.gdMonitoring.Size = new System.Drawing.Size(768, 208);
            this.gdMonitoring.TabIndex = 0;
            this.gdMonitoring.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMonitoring,
            this.gridView1});
            // 
            // gvMonitoring
            // 
            this.gvMonitoring.GridControl = this.gdMonitoring;
            this.gvMonitoring.Name = "gvMonitoring";
            this.gvMonitoring.OptionsView.ColumnAutoWidth = false;
            this.gvMonitoring.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMonitoring.OptionsView.EnableAppearanceOddRow = true;
            this.gvMonitoring.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gdMonitoring;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectedAll);
            this.panel1.Controls.Add(this.btnDeselectedAll);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 33);
            this.panel1.TabIndex = 98;
            // 
            // btnSelectedAll
            // 
            this.btnSelectedAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectedAll.Location = new System.Drawing.Point(0, 2);
            this.btnSelectedAll.LookAndFeel.SkinName = "Blue";
            this.btnSelectedAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSelectedAll.Name = "btnSelectedAll";
            this.btnSelectedAll.Size = new System.Drawing.Size(104, 30);
            this.btnSelectedAll.TabIndex = 92;
            this.btnSelectedAll.Text = "Chọn tất cả";
            this.btnSelectedAll.Click += new System.EventHandler(this.btnSelectedAll_Click);
            // 
            // btnDeselectedAll
            // 
            this.btnDeselectedAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeselectedAll.Location = new System.Drawing.Point(105, 2);
            this.btnDeselectedAll.LookAndFeel.SkinName = "Blue";
            this.btnDeselectedAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeselectedAll.Name = "btnDeselectedAll";
            this.btnDeselectedAll.Size = new System.Drawing.Size(104, 30);
            this.btnDeselectedAll.TabIndex = 93;
            this.btnDeselectedAll.Text = "Bỏ chọn tất cả";
            this.btnDeselectedAll.Click += new System.EventHandler(this.btnDeselectedAll_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(564, 2);
            this.btnCreate.LookAndFeel.SkinName = "Blue";
            this.btnCreate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 30);
            this.btnCreate.TabIndex = 48;
            this.btnCreate.Text = "Lập kế hoạch GS";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(677, 2);
            this.btnExit.LookAndFeel.SkinName = "Blue";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 30);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "T&hoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboStaff);
            this.panel2.Controls.Add(this.lblTuNgay);
            this.panel2.Controls.Add(this.dtFromDate);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Controls.Add(this.lblDenNgay);
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 53);
            this.panel2.TabIndex = 99;
            // 
            // cboStaff
            // 
            this.cboStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboStaff.Location = new System.Drawing.Point(470, 16);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboStaff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStaff.Properties.DropDownRows = 3;
            this.cboStaff.Properties.LookAndFeel.SkinName = "Blue";
            this.cboStaff.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboStaff.Properties.NullText = "";
            this.cboStaff.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboStaff.Size = new System.Drawing.Size(138, 20);
            this.cboStaff.TabIndex = 78;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTuNgay.Location = new System.Drawing.Point(152, 5);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(72, 20);
            this.lblTuNgay.TabIndex = 48;
            this.lblTuNgay.Text = "Từ ngày";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(230, 6);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.LookAndFeel.SkinName = "Blue";
            this.dtFromDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtFromDate.Size = new System.Drawing.Size(123, 20);
            this.dtFromDate.TabIndex = 53;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnProcess.Location = new System.Drawing.Point(359, 5);
            this.btnProcess.LookAndFeel.SkinName = "Blue";
            this.btnProcess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(70, 43);
            this.btnProcess.TabIndex = 52;
            this.btnProcess.Text = "Thực hiện";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblDenNgay.Location = new System.Drawing.Point(152, 28);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(72, 20);
            this.lblDenNgay.TabIndex = 50;
            this.lblDenNgay.Text = "Đến ngày";
            this.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(230, 28);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.LookAndFeel.SkinName = "Blue";
            this.dtToDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtToDate.Size = new System.Drawing.Size(123, 20);
            this.dtToDate.TabIndex = 54;
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // ucMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.TableLayoutPanel3);
            this.Name = "ucMonitoring";
            this.Size = new System.Drawing.Size(778, 367);
            this.Load += new System.EventHandler(this.ucMonitoring_Load);
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitoring)).EndInit();
            this.grpMonitoring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal DevExpress.XtraEditors.GroupControl grpMonitoring;
        internal DevExpress.XtraGrid.GridControl gdMonitoring;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvMonitoring;
        private System.Windows.Forms.Panel panel1;
        internal DevExpress.XtraEditors.SimpleButton btnSelectedAll;
        internal DevExpress.XtraEditors.SimpleButton btnDeselectedAll;
        internal DevExpress.XtraEditors.SimpleButton btnCreate;
        internal DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lblTuNgay;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        internal DevExpress.XtraEditors.SimpleButton btnProcess;
        internal System.Windows.Forms.Label lblDenNgay;
        internal DevExpress.XtraEditors.RadioGroup optGroup;
        internal DevExpress.XtraEditors.LookUpEdit cboStaff;
    }
}
