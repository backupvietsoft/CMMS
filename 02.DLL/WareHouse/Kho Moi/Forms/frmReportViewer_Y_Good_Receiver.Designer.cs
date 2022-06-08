namespace WareHouse
{
    partial class frmReportViewer_Y_Good_Receiver : DevExpress.XtraEditors.XtraForm
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
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.Exit = new DevExpress.XtraEditors.SimpleButton();
            this.ecomaintGrid1 = new WareHouse.EcomaintGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rptVENDOR_REPORT_GOOD_RECEIPT = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ecomaintGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnExcel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Exit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ecomaintGrid1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rptVENDOR_REPORT_GOOD_RECEIPT, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 367);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExcel.Location = new System.Drawing.Point(627, 310);
            this.btnExcel.LookAndFeel.SkinName = "Blue";
            this.btnExcel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 24);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Exit
            // 
            this.Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exit.Location = new System.Drawing.Point(727, 310);
            this.Exit.LookAndFeel.SkinName = "Blue";
            this.Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 24);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ecomaintGrid1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ecomaintGrid1, 3);
            this.ecomaintGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecomaintGrid1.Location = new System.Drawing.Point(3, 33);
            this.ecomaintGrid1.LookAndFeel.SkinName = "Blue";
            this.ecomaintGrid1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ecomaintGrid1.MainView = this.gridView1;
            this.ecomaintGrid1.Name = "ecomaintGrid1";
            this.ecomaintGrid1.Size = new System.Drawing.Size(799, 271);
            this.ecomaintGrid1.TabIndex = 2;
            this.ecomaintGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.ecomaintGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // progressBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 3);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 340);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(799, 24);
            this.progressBar1.TabIndex = 3;
            // 
            // rptVENDOR_REPORT_GOOD_RECEIPT
            // 
            this.rptVENDOR_REPORT_GOOD_RECEIPT.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rptVENDOR_REPORT_GOOD_RECEIPT, 3);
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Location = new System.Drawing.Point(3, 0);
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Name = "rptVENDOR_REPORT_GOOD_RECEIPT";
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Size = new System.Drawing.Size(799, 30);
            this.rptVENDOR_REPORT_GOOD_RECEIPT.TabIndex = 4;
            this.rptVENDOR_REPORT_GOOD_RECEIPT.Text = "label1";
            this.rptVENDOR_REPORT_GOOD_RECEIPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReportViewer_Y_Good_Receiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 367);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmReportViewer_Y_Good_Receiver";
            this.Text = "frmReportViewer_Y_Good_Receiver";
            this.Load += new System.EventHandler(this.frmReportViewer_Y_Good_Receiver_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ecomaintGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton Exit;
        public EcomaintGrid ecomaintGrid1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label rptVENDOR_REPORT_GOOD_RECEIPT;
    }
}