namespace ReportHuda
{
    partial class UCMaintainceForMonth_Huda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCMaintainceForMonth_Huda));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateToDate = new DevExpress.XtraEditors.DateEdit();
            this.dateFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFactory = new System.Windows.Forms.Label();
            this.cmbFactory = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMaintaiceChooseAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnMaitainceUnChooseAll = new DevExpress.XtraEditors.SimpleButton();
            this.gdMachine = new DevExpress.XtraGrid.GridControl();
            this.gvMachine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdMaintaince = new DevExpress.XtraGrid.GridControl();
            this.gvMaintaince = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMachineChooseAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnMachineUnChooseAll = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFactory.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMaintaince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaintaince)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dateToDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateFromDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFromDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblToDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFactory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbFactory, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dateToDate
            // 
            this.dateToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToDate.EditValue = null;
            this.dateToDate.Location = new System.Drawing.Point(69, 28);
            this.dateToDate.Name = "dateToDate";
            this.dateToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateToDate.Size = new System.Drawing.Size(618, 20);
            this.dateToDate.TabIndex = 8;
            this.dateToDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateToDate_EditValueChanging);
            // 
            // dateFromDate
            // 
            this.dateFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromDate.EditValue = null;
            this.dateFromDate.Location = new System.Drawing.Point(69, 3);
            this.dateFromDate.Name = "dateFromDate";
            this.dateFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFromDate.Size = new System.Drawing.Size(618, 20);
            this.dateFromDate.TabIndex = 7;
            this.dateFromDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateFromDate_EditValueChanging);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDate.Location = new System.Drawing.Point(3, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(60, 25);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Từ ngày";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDate.Location = new System.Drawing.Point(3, 25);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(60, 25);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFactory.Location = new System.Drawing.Point(3, 50);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(60, 25);
            this.lblFactory.TabIndex = 3;
            this.lblFactory.Text = "Nhà xưởng";
            this.lblFactory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFactory
            // 
            this.cmbFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFactory.Location = new System.Drawing.Point(69, 53);
            this.cmbFactory.Name = "cmbFactory";
            this.cmbFactory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFactory.Size = new System.Drawing.Size(618, 20);
            this.cmbFactory.TabIndex = 6;
            this.cmbFactory.EditValueChanged += new System.EventHandler(this.cmbFactory_EditValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.gdMachine, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gdMaintaince, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(684, 248);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnMaintaiceChooseAll, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMaitainceUnChooseAll, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(413, 216);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(268, 29);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // btnMaintaiceChooseAll
            // 
            this.btnMaintaiceChooseAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintaiceChooseAll.Appearance.Options.UseFont = true;
            this.btnMaintaiceChooseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaintaiceChooseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMaintaiceChooseAll.Image")));
            this.btnMaintaiceChooseAll.Location = new System.Drawing.Point(3, 3);
            this.btnMaintaiceChooseAll.LookAndFeel.SkinName = "Blue";
            this.btnMaintaiceChooseAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMaintaiceChooseAll.Name = "btnMaintaiceChooseAll";
            this.btnMaintaiceChooseAll.Size = new System.Drawing.Size(84, 23);
            this.btnMaintaiceChooseAll.TabIndex = 5;
            this.btnMaintaiceChooseAll.Text = "Chọn hết";
            this.btnMaintaiceChooseAll.Click += new System.EventHandler(this.btnMaintaiceChooseAll_Click);
            // 
            // btnMaitainceUnChooseAll
            // 
            this.btnMaitainceUnChooseAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaitainceUnChooseAll.Appearance.Options.UseFont = true;
            this.btnMaitainceUnChooseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaitainceUnChooseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMaitainceUnChooseAll.Image")));
            this.btnMaitainceUnChooseAll.Location = new System.Drawing.Point(95, 3);
            this.btnMaitainceUnChooseAll.LookAndFeel.SkinName = "Blue";
            this.btnMaitainceUnChooseAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMaitainceUnChooseAll.Name = "btnMaitainceUnChooseAll";
            this.btnMaitainceUnChooseAll.Size = new System.Drawing.Size(84, 23);
            this.btnMaitainceUnChooseAll.TabIndex = 6;
            this.btnMaitainceUnChooseAll.Text = "Bỏ chọn";
            this.btnMaitainceUnChooseAll.Click += new System.EventHandler(this.btnMaitainceUnChooseAll_Click);
            // 
            // gdMachine
            // 
            this.gdMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMachine.Location = new System.Drawing.Point(3, 3);
            this.gdMachine.LookAndFeel.SkinName = "Blue";
            this.gdMachine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdMachine.MainView = this.gvMachine;
            this.gdMachine.Name = "gdMachine";
            this.gdMachine.Size = new System.Drawing.Size(404, 207);
            this.gdMachine.TabIndex = 0;
            this.gdMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMachine});
            // 
            // gvMachine
            // 
            this.gvMachine.GridControl = this.gdMachine;
            this.gvMachine.Name = "gvMachine";
            // 
            // gdMaintaince
            // 
            this.gdMaintaince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMaintaince.Location = new System.Drawing.Point(413, 3);
            this.gdMaintaince.LookAndFeel.SkinName = "Blue";
            this.gdMaintaince.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdMaintaince.MainView = this.gvMaintaince;
            this.gdMaintaince.Name = "gdMaintaince";
            this.gdMaintaince.Size = new System.Drawing.Size(268, 207);
            this.gdMaintaince.TabIndex = 1;
            this.gdMaintaince.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaintaince});
            // 
            // gvMaintaince
            // 
            this.gvMaintaince.GridControl = this.gdMaintaince;
            this.gvMaintaince.Name = "gvMaintaince";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnMachineChooseAll, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMachineUnChooseAll, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 216);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(404, 29);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnMachineChooseAll
            // 
            this.btnMachineChooseAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachineChooseAll.Appearance.Options.UseFont = true;
            this.btnMachineChooseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMachineChooseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMachineChooseAll.Image")));
            this.btnMachineChooseAll.Location = new System.Drawing.Point(3, 3);
            this.btnMachineChooseAll.LookAndFeel.SkinName = "Blue";
            this.btnMachineChooseAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMachineChooseAll.Name = "btnMachineChooseAll";
            this.btnMachineChooseAll.Size = new System.Drawing.Size(84, 23);
            this.btnMachineChooseAll.TabIndex = 5;
            this.btnMachineChooseAll.Text = "Chọn hết";
            this.btnMachineChooseAll.Click += new System.EventHandler(this.btnMachineChooseAll_Click);
            // 
            // btnMachineUnChooseAll
            // 
            this.btnMachineUnChooseAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachineUnChooseAll.Appearance.Options.UseFont = true;
            this.btnMachineUnChooseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMachineUnChooseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMachineUnChooseAll.Image")));
            this.btnMachineUnChooseAll.Location = new System.Drawing.Point(95, 3);
            this.btnMachineUnChooseAll.LookAndFeel.SkinName = "Blue";
            this.btnMachineUnChooseAll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMachineUnChooseAll.Name = "btnMachineUnChooseAll";
            this.btnMachineUnChooseAll.Size = new System.Drawing.Size(84, 23);
            this.btnMachineUnChooseAll.TabIndex = 6;
            this.btnMachineUnChooseAll.Text = "Bỏ chọn";
            this.btnMachineUnChooseAll.Click += new System.EventHandler(this.btnMachineUnChooseAll_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 364);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(684, 29);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(591, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 23);
            this.btnThoat.TabIndex = 38;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExecute.Image = global::ReportHuda.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(480, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(101, 23);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // UCMaintainceForMonth_Huda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCMaintainceForMonth_Huda";
            this.Size = new System.Drawing.Size(690, 396);
            this.Load += new System.EventHandler(this.UCMaintainceForMonth_Huda_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFactory.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMaintaince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaintaince)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFactory;
        private DevExpress.XtraEditors.LookUpEdit cmbFactory;
        private DevExpress.XtraEditors.DateEdit dateToDate;
        private DevExpress.XtraEditors.DateEdit dateFromDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gdMachine;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMachine;
        private DevExpress.XtraGrid.GridControl gdMaintaince;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaintaince;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.SimpleButton btnMaintaiceChooseAll;
        private DevExpress.XtraEditors.SimpleButton btnMaitainceUnChooseAll;
        private DevExpress.XtraEditors.SimpleButton btnMachineChooseAll;
        private DevExpress.XtraEditors.SimpleButton btnMachineUnChooseAll;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}
