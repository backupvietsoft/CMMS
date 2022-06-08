namespace WareHouse
{
    partial class frmChonPTNhapKho : DevExpress.XtraEditors.XtraForm
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
            this.TlbSelectItem = new System.Windows.Forms.TableLayoutPanel();
            this.PelSelectItem = new System.Windows.Forms.Panel();
            this.btnUncheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.txtMS = new DevExpress.XtraEditors.TextEdit();
            this.grdPhuTung = new DevExpress.XtraGrid.GridControl();
            this.grvPhuTung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TlbSelectItem.SuspendLayout();
            this.PelSelectItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhuTung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhuTung)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 1;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.Controls.Add(this.PelSelectItem, 0, 2);
            this.TlbSelectItem.Controls.Add(this.grdPhuTung, 0, 1);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 3;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TlbSelectItem.Size = new System.Drawing.Size(782, 486);
            this.TlbSelectItem.TabIndex = 1;
            // 
            // PelSelectItem
            // 
            this.PelSelectItem.Controls.Add(this.btnUncheck);
            this.PelSelectItem.Controls.Add(this.btnImport);
            this.PelSelectItem.Controls.Add(this.btnCheck);
            this.PelSelectItem.Controls.Add(this.BtnOK);
            this.PelSelectItem.Controls.Add(this.BtnExit);
            this.PelSelectItem.Controls.Add(this.txtMS);
            this.PelSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PelSelectItem.Location = new System.Drawing.Point(3, 449);
            this.PelSelectItem.Name = "PelSelectItem";
            this.PelSelectItem.Size = new System.Drawing.Size(776, 34);
            this.PelSelectItem.TabIndex = 1;
            // 
            // btnUncheck
            // 
            this.btnUncheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUncheck.Location = new System.Drawing.Point(461, 1);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(104, 30);
            this.btnUncheck.TabIndex = 7;
            this.btnUncheck.Text = "Khong";
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(251, 1);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 30);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "btnImport";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(356, 1);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(104, 30);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Chon";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Location = new System.Drawing.Point(566, 1);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(104, 30);
            this.BtnOK.TabIndex = 5;
            this.BtnOK.Text = "OK";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.Location = new System.Drawing.Point(671, 1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(104, 30);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtMS
            // 
            this.txtMS.Location = new System.Drawing.Point(6, 7);
            this.txtMS.Margin = new System.Windows.Forms.Padding(0);
            this.txtMS.Name = "txtMS";
            this.txtMS.Size = new System.Drawing.Size(195, 20);
            this.txtMS.TabIndex = 1;
            this.txtMS.TextChanged += new System.EventHandler(this.txtMS_TextChanged);
            // 
            // grdPhuTung
            // 
            this.grdPhuTung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPhuTung.Location = new System.Drawing.Point(3, 11);
            this.grdPhuTung.MainView = this.grvPhuTung;
            this.grdPhuTung.Name = "grdPhuTung";
            this.grdPhuTung.Size = new System.Drawing.Size(776, 432);
            this.grdPhuTung.TabIndex = 7;
            this.grdPhuTung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPhuTung});
            // 
            // grvPhuTung
            // 
            this.grvPhuTung.GridControl = this.grdPhuTung;
            this.grvPhuTung.Name = "grvPhuTung";
            this.grvPhuTung.OptionsView.ShowGroupPanel = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số PT";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Loại vật tư phụ tùng";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Part no";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Tên phụ tùng";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Quy cách";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ĐVT";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // frmChonPTNhapKho
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 486);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonPTNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChonPTNhapKho";
            this.Load += new System.EventHandler(this.frmChonPTNhapKho_Load);
            this.TlbSelectItem.ResumeLayout(false);
            this.PelSelectItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhuTung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhuTung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private System.Windows.Forms.Panel PelSelectItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        internal DevExpress.XtraEditors.TextEdit txtMS;
        private DevExpress.XtraEditors.SimpleButton btnUncheck;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SimpleButton BtnOK;
        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private DevExpress.XtraGrid.GridControl grdPhuTung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPhuTung;
        private DevExpress.XtraEditors.SimpleButton btnImport;
    }
}