namespace CustomerInfoReport
{
    partial class ReportCustomerInfo
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridview1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_n_xuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ten_n_xuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_dia_chi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ten_duong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_district = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_city = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_dien_thoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_model = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ms_tb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_barCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_seri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_affiliate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExcute, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1204, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl1, 4);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 37);
            this.gridControl1.LookAndFeel.SkinName = "Blue";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridview1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1198, 188);
            this.gridControl1.TabIndex = 33;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridview1});
            // 
            // gridview1
            // 
            this.gridview1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_n_xuong,
            this.col_ten_n_xuong,
            this.col_dia_chi,
            this.col_ten_duong,
            this.col_district,
            this.col_city,
            this.col_dien_thoai,
            this.col_model,
            this.col_ms_tb,
            this.col_barCode,
            this.col_seri,
            this.col_affiliate});
            this.gridview1.GridControl = this.gridControl1;
            this.gridview1.Name = "gridview1";
            this.gridview1.OptionsView.ColumnAutoWidth = false;
            // 
            // col_n_xuong
            // 
            this.col_n_xuong.Caption = "IDCus";
            this.col_n_xuong.FieldName = "MS_N_XUONG";
            this.col_n_xuong.Name = "col_n_xuong";
            this.col_n_xuong.Visible = true;
            this.col_n_xuong.VisibleIndex = 0;
            this.col_n_xuong.Width = 150;
            // 
            // col_ten_n_xuong
            // 
            this.col_ten_n_xuong.Caption = "CusName";
            this.col_ten_n_xuong.FieldName = "TEN_N_XUONG";
            this.col_ten_n_xuong.Name = "col_ten_n_xuong";
            this.col_ten_n_xuong.Visible = true;
            this.col_ten_n_xuong.VisibleIndex = 1;
            this.col_ten_n_xuong.Width = 149;
            // 
            // col_dia_chi
            // 
            this.col_dia_chi.Caption = "Address";
            this.col_dia_chi.FieldName = "DIA_CHI";
            this.col_dia_chi.Name = "col_dia_chi";
            this.col_dia_chi.Visible = true;
            this.col_dia_chi.VisibleIndex = 2;
            this.col_dia_chi.Width = 199;
            // 
            // col_ten_duong
            // 
            this.col_ten_duong.Caption = "street";
            this.col_ten_duong.FieldName = "tenduong";
            this.col_ten_duong.Name = "col_ten_duong";
            this.col_ten_duong.Visible = true;
            this.col_ten_duong.VisibleIndex = 3;
            this.col_ten_duong.Width = 148;
            // 
            // col_district
            // 
            this.col_district.Caption = "district";
            this.col_district.FieldName = "quan";
            this.col_district.Name = "col_district";
            this.col_district.Visible = true;
            this.col_district.VisibleIndex = 4;
            this.col_district.Width = 135;
            // 
            // col_city
            // 
            this.col_city.Caption = "city";
            this.col_city.FieldName = "Tinh";
            this.col_city.Name = "col_city";
            this.col_city.Visible = true;
            this.col_city.VisibleIndex = 5;
            // 
            // col_dien_thoai
            // 
            this.col_dien_thoai.Caption = "phone";
            this.col_dien_thoai.FieldName = "DIEN_THOAI";
            this.col_dien_thoai.Name = "col_dien_thoai";
            this.col_dien_thoai.Visible = true;
            this.col_dien_thoai.VisibleIndex = 6;
            // 
            // col_model
            // 
            this.col_model.Caption = "model";
            this.col_model.FieldName = "TEN_NHOM_MAY";
            this.col_model.Name = "col_model";
            this.col_model.Visible = true;
            this.col_model.VisibleIndex = 7;
            this.col_model.Width = 100;
            // 
            // col_ms_tb
            // 
            this.col_ms_tb.Caption = "CodeDevice";
            this.col_ms_tb.FieldName = "MS_MAY";
            this.col_ms_tb.Name = "col_ms_tb";
            this.col_ms_tb.Visible = true;
            this.col_ms_tb.VisibleIndex = 8;
            // 
            // col_barCode
            // 
            this.col_barCode.Caption = "barCode";
            this.col_barCode.FieldName = "SO_THE";
            this.col_barCode.Name = "col_barCode";
            this.col_barCode.Visible = true;
            this.col_barCode.VisibleIndex = 9;
            // 
            // col_seri
            // 
            this.col_seri.Caption = "seri";
            this.col_seri.FieldName = "SERIAL_NUMBER";
            this.col_seri.Name = "col_seri";
            this.col_seri.Visible = true;
            this.col_seri.VisibleIndex = 10;
            // 
            // col_affiliate
            // 
            this.col_affiliate.Caption = "affiliate";
            this.col_affiliate.FieldName = "tendaily";
            this.col_affiliate.Name = "col_affiliate";
            this.col_affiliate.Visible = true;
            this.col_affiliate.VisibleIndex = 11;
            this.col_affiliate.Width = 100;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1198, 34);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcute
            // 
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcute.Location = new System.Drawing.Point(1017, 231);
            this.btnExcute.LookAndFeel.SkinName = "Blue";
            this.btnExcute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 28);
            this.btnExcute.TabIndex = 35;
            this.btnExcute.Text = "simpleButton1";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(1116, 231);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReportCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportCustomerInfo";
            this.Text = "ReportCustomerInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportCustomerInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview1;
        private DevExpress.XtraGrid.Columns.GridColumn col_n_xuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_ten_n_xuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_dia_chi;
        private DevExpress.XtraGrid.Columns.GridColumn col_ten_duong;
        private DevExpress.XtraGrid.Columns.GridColumn col_district;
        private DevExpress.XtraGrid.Columns.GridColumn col_city;
        private DevExpress.XtraGrid.Columns.GridColumn col_dien_thoai;
        private DevExpress.XtraGrid.Columns.GridColumn col_model;
        private DevExpress.XtraGrid.Columns.GridColumn col_ms_tb;
        private DevExpress.XtraGrid.Columns.GridColumn col_barCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_seri;
        private DevExpress.XtraGrid.Columns.GridColumn col_affiliate;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}