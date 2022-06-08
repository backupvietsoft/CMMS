namespace WareHouse
{
    partial class frmChonMay_TGNM : DevExpress.XtraEditors.XtraForm
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTKiemNNNM = new DevExpress.XtraEditors.TextEdit();
            this.lblTKiem = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LabTitle = new System.Windows.Forms.Label();
            this.cboDChuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDDiem = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TlbSelectItem.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiemNNNM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 6;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TlbSelectItem.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.TlbSelectItem.Controls.Add(this.grdMay, 0, 3);
            this.TlbSelectItem.Controls.Add(this.LabTitle, 0, 0);
            this.TlbSelectItem.Controls.Add(this.cboDChuyen, 4, 1);
            this.TlbSelectItem.Controls.Add(this.lblDChuyen, 3, 1);
            this.TlbSelectItem.Controls.Add(this.cboDDiem, 2, 1);
            this.TlbSelectItem.Controls.Add(this.lblDDiem, 1, 1);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 5;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TlbSelectItem.Size = new System.Drawing.Size(884, 561);
            this.TlbSelectItem.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.TlbSelectItem.SetColumnSpan(this.tableLayoutPanel3, 6);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.Controls.Add(this.txtTKiemNNNM, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTKiem, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExecute, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNotALL, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnALL, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 522);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 36);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // txtTKiemNNNM
            // 
            this.txtTKiemNNNM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiemNNNM.Location = new System.Drawing.Point(97, 13);
            this.txtTKiemNNNM.Name = "txtTKiemNNNM";
            this.txtTKiemNNNM.Size = new System.Drawing.Size(120, 20);
            this.txtTKiemNNNM.TabIndex = 20;
            this.txtTKiemNNNM.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiemNNNM_EditValueChanging);
            // 
            // lblTKiem
            // 
            this.lblTKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTKiem.Location = new System.Drawing.Point(3, 3);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Size = new System.Drawing.Size(88, 30);
            this.lblTKiem.TabIndex = 21;
            this.lblTKiem.Text = "lblTKiem";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(771, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(661, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Location = new System.Drawing.Point(551, 3);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 3;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Location = new System.Drawing.Point(441, 3);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 2;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // grdMay
            // 
            this.TlbSelectItem.SetColumnSpan(this.grdMay, 6);
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.Location = new System.Drawing.Point(3, 77);
            this.grdMay.LookAndFeel.SkinName = "Blue";
            this.grdMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(878, 439);
            this.grdMay.TabIndex = 16;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvMay.OptionsCustomization.AllowColumnMoving = false;
            this.grvMay.OptionsCustomization.AllowGroup = false;
            this.grvMay.OptionsView.ShowGroupPanel = false;
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.TlbSelectItem.SetColumnSpan(this.LabTitle, 6);
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTitle.ForeColor = System.Drawing.Color.Navy;
            this.LabTitle.Location = new System.Drawing.Point(3, 0);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(878, 40);
            this.LabTitle.TabIndex = 5;
            this.LabTitle.Text = "CHỌN MAY CHO TGNM";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.Location = new System.Drawing.Point(550, 43);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDChuyen.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDChuyen.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDChuyen.Size = new System.Drawing.Size(197, 20);
            this.cboDChuyen.TabIndex = 19;
            this.cboDChuyen.EditValueChanged += new System.EventHandler(this.cboDChuyen_EditValueChanged);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Location = new System.Drawing.Point(444, 40);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(100, 25);
            this.lblDChuyen.TabIndex = 21;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.Location = new System.Drawing.Point(241, 43);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDDiem.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDDiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDDiem.Size = new System.Drawing.Size(197, 20);
            this.cboDDiem.TabIndex = 18;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Location = new System.Drawing.Point(135, 40);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(100, 25);
            this.lblDDiem.TabIndex = 20;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 40;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 194;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số May";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 195;
            // 
            // frmChonMay_TGNM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(414, 455);
            this.Name = "frmChonMay_TGNM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChonMay_TGNM";
            this.Load += new System.EventHandler(this.frmChonMay_TGNM_Load);
            this.TlbSelectItem.ResumeLayout(false);
            this.TlbSelectItem.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiemNNNM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.TextEdit txtTKiemNNNM;
        private DevExpress.XtraEditors.LabelControl lblTKiem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.LookUpEdit cboDChuyen;
        private System.Windows.Forms.Label lblDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboDDiem;
        private System.Windows.Forms.Label lblDDiem;
    }
}