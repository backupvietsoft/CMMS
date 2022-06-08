namespace VietShape
{
    partial class frmNNgu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.grdNhanLuc = new DevExpress.XtraGrid.GridControl();
            this.grvNhanLuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanLuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanLuc)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.803453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66586F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76414F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76413F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76493F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76493F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.803452F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdNhanLuc, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 8);
            this.panel1.Controls.Add(this.txtTKiem);
            this.panel1.Controls.Add(this.btnThemSua);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnKhongghi);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 36);
            this.panel1.TabIndex = 112;
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(0, 14);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 12;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(666, 4);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(104, 30);
            this.btnThemSua.TabIndex = 7;
            this.btnThemSua.Text = "btnThemSua";
            this.btnThemSua.Click += new System.EventHandler(this.btnThemSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(771, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongghi
            // 
            this.btnKhongghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongghi.Location = new System.Drawing.Point(771, 4);
            this.btnKhongghi.Name = "btnKhongghi";
            this.btnKhongghi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongghi.TabIndex = 11;
            this.btnKhongghi.Text = "Không lưu";
            this.btnKhongghi.Click += new System.EventHandler(this.btnKhongghi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(666, 4);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // grdNhanLuc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdNhanLuc, 8);
            this.grdNhanLuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhanLuc.Location = new System.Drawing.Point(3, 7);
            this.grdNhanLuc.LookAndFeel.SkinName = "Blue";
            this.grdNhanLuc.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdNhanLuc.MainView = this.grvNhanLuc;
            this.grdNhanLuc.Name = "grdNhanLuc";
            this.grdNhanLuc.Size = new System.Drawing.Size(878, 509);
            this.grdNhanLuc.TabIndex = 27;
            this.grdNhanLuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNhanLuc});
            // 
            // grvNhanLuc
            // 
            this.grvNhanLuc.GridControl = this.grdNhanLuc;
            this.grvNhanLuc.Name = "grvNhanLuc";
            this.grvNhanLuc.OptionsView.ColumnAutoWidth = false;
            this.grvNhanLuc.OptionsView.ShowGroupPanel = false;
            // 
            // frmNNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmNNgu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNNgu";
            this.Load += new System.EventHandler(this.frmNNgu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanLuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanLuc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal DevExpress.XtraGrid.GridControl grdNhanLuc;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvNhanLuc;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongghi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
    }
}