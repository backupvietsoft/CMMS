namespace ReportHuda
{
    partial class frmMergeCongViec
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
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblMaSo = new System.Windows.Forms.Label();
            this.grdCViec = new DevExpress.XtraGrid.GridControl();
            this.grvCViec = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.lblTKiem = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMaSo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdCViec, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTenCV, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTKiem, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // txtTKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTKiem, 2);
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(113, 538);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(114, 20);
            this.txtTKiem.TabIndex = 19;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // lblMaSo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblMaSo, 2);
            this.lblMaSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaSo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMaSo.Location = new System.Drawing.Point(3, 40);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblMaSo.Size = new System.Drawing.Size(184, 25);
            this.lblMaSo.TabIndex = 16;
            this.lblMaSo.Text = "lblKho";
            this.lblMaSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdCViec
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdCViec, 7);
            this.grdCViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCViec.Location = new System.Drawing.Point(3, 68);
            this.grdCViec.LookAndFeel.SkinName = "Blue";
            this.grdCViec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCViec.MainView = this.grvCViec;
            this.grdCViec.Name = "grdCViec";
            this.grdCViec.Size = new System.Drawing.Size(878, 454);
            this.grdCViec.TabIndex = 1;
            this.grdCViec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCViec,
            this.advBandedGridView1,
            this.layoutView1,
            this.gridView1});
            // 
            // grvCViec
            // 
            this.grvCViec.GridControl = this.grdCViec;
            this.grvCViec.Name = "grvCViec";
            this.grvCViec.OptionsBehavior.Editable = false;
            this.grvCViec.OptionsView.ColumnAutoWidth = false;
            this.grvCViec.OptionsView.ShowGroupPanel = false;
            this.grvCViec.ShownEditor += new System.EventHandler(this.grvCV_ShownEditor);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.grdCViec;
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
            this.layoutView1.GridControl = this.grdCViec;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCViec;
            this.gridView1.Name = "gridView1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 7);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(878, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "frmMergeCongViec";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportHuda.Properties.Resources.btnexcel;
            this.btnExecute.Location = new System.Drawing.Point(667, 528);
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
            this.btnCancel.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnCancel.Location = new System.Drawing.Point(777, 528);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTenCV
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblTenCV, 4);
            this.lblTenCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenCV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTenCV.Location = new System.Drawing.Point(193, 40);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTenCV.Size = new System.Drawing.Size(578, 25);
            this.lblTenCV.TabIndex = 16;
            this.lblTenCV.Text = "lblKho";
            this.lblTenCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTKiem
            // 
            this.lblTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTKiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTKiem.Location = new System.Drawing.Point(3, 536);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTKiem.Size = new System.Drawing.Size(104, 25);
            this.lblTKiem.TabIndex = 16;
            this.lblTKiem.Text = "lblTKiem";
            this.lblTKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMergeCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmMergeCongViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMergeCongViec";
            this.Load += new System.EventHandler(this.frmMergeCongViec_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdCViec;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCViec;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblMaSo;
        private System.Windows.Forms.Label lblTenCV;
        private System.Windows.Forms.Label lblTKiem;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
    }
}