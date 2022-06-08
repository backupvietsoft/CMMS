namespace CustomerInfoReport
{
    partial class UcrptXuatNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcrptXuatNhapKho));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.cmbStock = new System.Windows.Forms.ComboBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblStock, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFromDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblToDate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbStock, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtFromDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtToDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThuchien, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStock.Location = new System.Drawing.Point(3, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(114, 26);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "Kho";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDate.Location = new System.Drawing.Point(3, 26);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(114, 26);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Từ Ngày";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDate.Location = new System.Drawing.Point(3, 52);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(114, 26);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến Ngày";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbStock
            // 
            this.cmbStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStock.FormattingEnabled = true;
            this.cmbStock.Location = new System.Drawing.Point(123, 3);
            this.cmbStock.Name = "cmbStock";
            this.cmbStock.Size = new System.Drawing.Size(228, 21);
            this.cmbStock.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(123, 29);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(228, 20);
            this.dtFromDate.TabIndex = 4;
            // 
            // dtToDate
            // 
            this.dtToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(123, 55);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(228, 20);
            this.dtToDate.TabIndex = 5;
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThuchien.BackgroundImage")));
            this.btnThuchien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThuchien.Location = new System.Drawing.Point(226, 163);
            this.btnThuchien.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuchien.Size = new System.Drawing.Size(113, 28);
            this.btnThuchien.TabIndex = 31;
            this.btnThuchien.Text = "Thuc hien";
            this.btnThuchien.UseVisualStyleBackColor = true;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // UcrptXuatNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcrptXuatNhapKho";
            this.Size = new System.Drawing.Size(354, 194);
            this.Load += new System.EventHandler(this.UcrptXuatNhapKho_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.ComboBox cmbStock;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnThuchien;
    }
}
