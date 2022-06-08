namespace WareHouse
{
    partial class frmLocDuLieu : DevExpress.XtraEditors.XtraForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TlbFilter = new System.Windows.Forms.TableLayoutPanel();
            this.LabTitle = new System.Windows.Forms.Label();
            this.PelFilter = new System.Windows.Forms.Panel();
            this.txtLPN = new System.Windows.Forms.TextBox();
            this.BtnFilter = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DgvFilter = new Vietsoft.DataGridViewEditor();
            this.TlbFilter.SuspendLayout();
            this.PelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbFilter
            // 
            this.TlbFilter.ColumnCount = 1;
            this.TlbFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbFilter.Controls.Add(this.LabTitle, 0, 0);
            this.TlbFilter.Controls.Add(this.PelFilter, 0, 2);
            this.TlbFilter.Controls.Add(this.DgvFilter, 0, 1);
            this.TlbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbFilter.Location = new System.Drawing.Point(0, 0);
            this.TlbFilter.Name = "TlbFilter";
            this.TlbFilter.RowCount = 3;
            this.TlbFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TlbFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TlbFilter.Size = new System.Drawing.Size(782, 486);
            this.TlbFilter.TabIndex = 0;
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTitle.ForeColor = System.Drawing.Color.Navy;
            this.LabTitle.Location = new System.Drawing.Point(3, 0);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(776, 28);
            this.LabTitle.TabIndex = 0;
            this.LabTitle.Text = "LỌC DỮ LIỆU";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PelFilter
            // 
            this.PelFilter.Controls.Add(this.txtLPN);
            this.PelFilter.Controls.Add(this.BtnFilter);
            this.PelFilter.Controls.Add(this.BtnCancel);
            this.PelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PelFilter.Location = new System.Drawing.Point(0, 458);
            this.PelFilter.Margin = new System.Windows.Forms.Padding(0);
            this.PelFilter.Name = "PelFilter";
            this.PelFilter.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.PelFilter.Size = new System.Drawing.Size(782, 28);
            this.PelFilter.TabIndex = 1;
            // 
            // txtLPN
            // 
            this.txtLPN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLPN.Location = new System.Drawing.Point(3, 7);
            this.txtLPN.Margin = new System.Windows.Forms.Padding(0);
            this.txtLPN.Name = "txtLPN";
            this.txtLPN.Size = new System.Drawing.Size(176, 21);
            this.txtLPN.TabIndex = 31;
            this.txtLPN.TextChanged += new System.EventHandler(this.txtLPN_TextChanged);
            // 
            // BtnFilter
            // 
            this.BtnFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilter.Location = new System.Drawing.Point(562, 0);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(85, 28);
            this.BtnFilter.TabIndex = 1;
            this.BtnFilter.Text = "&Thực hiện";
            this.BtnFilter.UseVisualStyleBackColor = true;
            this.BtnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(647, 0);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(85, 28);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Th&oát";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // DgvFilter
            // 
            this.DgvFilter.AllowUserToAddRows = false;
            this.DgvFilter.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFilter.Location = new System.Drawing.Point(3, 31);
            this.DgvFilter.Name = "DgvFilter";
            this.DgvFilter.ReadOnly = true;
            this.DgvFilter.RowHeadersWidth = 30;
            this.DgvFilter.Size = new System.Drawing.Size(776, 424);
            this.DgvFilter.TabIndex = 2;
            // 
            // frmLocDuLieu
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 486);
            this.Controls.Add(this.TlbFilter);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmLocDuLieu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFilter";
            this.Load += new System.EventHandler(this.frmLocDuLieu_Load);
            this.TlbFilter.ResumeLayout(false);
            this.TlbFilter.PerformLayout();
            this.PelFilter.ResumeLayout(false);
            this.PelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbFilter;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.Panel PelFilter;
        private System.Windows.Forms.Button BtnFilter;
        private System.Windows.Forms.Button BtnCancel;
        private Vietsoft.DataGridViewEditor DgvFilter;
        internal System.Windows.Forms.TextBox txtLPN;
    }
}