namespace ReportHuda.Colgate
{
    partial class frmMaintaince_Colgate
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
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.gdMachine = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gdMachine, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1125, 722);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 667);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(1119, 16);
            this.prbIN.TabIndex = 30;
            // 
            // gdMachine
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gdMachine, 5);
            this.gdMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMachine.Location = new System.Drawing.Point(3, 43);
            this.gdMachine.LookAndFeel.SkinName = "Blue";
            this.gdMachine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdMachine.MainView = this.gridView1;
            this.gdMachine.Name = "gdMachine";
            this.gdMachine.Size = new System.Drawing.Size(1119, 618);
            this.gdMachine.TabIndex = 1;
            this.gdMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.advBandedGridView1,
            this.layoutView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gdMachine;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.gdMachine;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 189;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gdMachine;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 5);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1119, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "KẾ HOẠCH BẢO TRÌ THIẾT BỊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(908, 689);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(1018, 689);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTKiem, 2);
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(3, 699);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(224, 20);
            this.txtTKiem.TabIndex = 29;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(233, 689);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(121, 19);
            this.grdChung.TabIndex = 31;
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
            // frmMaintaince_Colgate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 722);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmMaintaince_Colgate";
            this.Text = "frmMaintaince_Colgate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMaintaince_Colgate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gdMachine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
    }
}