namespace WareHouse
{
    partial class frmChonPhuTung : DevExpress.XtraEditors.XtraForm
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
            this.CboKho = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTonToiThieu = new DevExpress.XtraEditors.CheckEdit();
            this.LabKho = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grvVatTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdVatTu = new DevExpress.XtraGrid.GridControl();
            this.TlbSelectItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTonToiThieu.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVatTu)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 1;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.Controls.Add(this.grdVatTu, 0, 2);
            this.TlbSelectItem.Controls.Add(this.panel1, 0, 3);
            this.TlbSelectItem.Controls.Add(this.panel2, 0, 1);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 4;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.Size = new System.Drawing.Size(1044, 668);
            this.TlbSelectItem.TabIndex = 0;
            // 
            // CboKho
            // 
            this.CboKho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CboKho.Location = new System.Drawing.Point(416, 3);
            this.CboKho.Name = "CboKho";
            this.CboKho.Padding = new System.Windows.Forms.Padding(3);
            this.CboKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboKho.Size = new System.Drawing.Size(179, 20);
            this.CboKho.TabIndex = 4;
            this.CboKho.EditValueChanged += new System.EventHandler(this.CboKho_EditValueChanged);
            // 
            // chkTonToiThieu
            // 
            this.chkTonToiThieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkTonToiThieu.Location = new System.Drawing.Point(601, 4);
            this.chkTonToiThieu.Name = "chkTonToiThieu";
            this.chkTonToiThieu.Padding = new System.Windows.Forms.Padding(3);
            this.chkTonToiThieu.Properties.Caption = "Số lượng tồn nhỏ hơn tối thiểu";
            this.chkTonToiThieu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTonToiThieu.Size = new System.Drawing.Size(279, 18);
            this.chkTonToiThieu.TabIndex = 6;
            this.chkTonToiThieu.CheckedChanged += new System.EventHandler(this.txtTimKiem_EditValueChanged);
            // 
            // LabKho
            // 
            this.LabKho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabKho.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.LabKho.Location = new System.Drawing.Point(365, 6);
            this.LabKho.Margin = new System.Windows.Forms.Padding(0);
            this.LabKho.Name = "LabKho";
            this.LabKho.Size = new System.Drawing.Size(45, 13);
            this.LabKho.TabIndex = 3;
            this.LabKho.Text = "Chọn kho";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabKho);
            this.panel2.Controls.Add(this.chkTonToiThieu);
            this.panel2.Controls.Add(this.CboKho);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 25);
            this.panel2.TabIndex = 9;
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Location = new System.Drawing.Point(617, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(104, 30);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotALL.Location = new System.Drawing.Point(722, 2);
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 3;
            this.btnNotALL.Text = "Clear";
            this.btnNotALL.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(827, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(104, 30);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "&Thực hiện";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(932, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiem.Location = new System.Drawing.Point(3, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(263, 20);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.EditValueChanged += new System.EventHandler(this.txtTimKiem_EditValueChanged);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtMSPT_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.BtnOK);
            this.panel1.Controls.Add(this.btnNotALL);
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 631);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 34);
            this.panel1.TabIndex = 8;
            // 
            // grvVatTu
            // 
            this.grvVatTu.GridControl = this.grdVatTu;
            this.grvVatTu.Name = "grvVatTu";
            this.grvVatTu.OptionsCustomization.AllowGroup = false;
            this.grvVatTu.OptionsView.ShowGroupPanel = false;
            this.grvVatTu.GridMenuItemClick += new DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventHandler(this.grvVatTu_GridMenuItemClick);
            this.grvVatTu.HideCustomizationForm += new System.EventHandler(this.grvVatTu_HideCustomizationForm);
            this.grvVatTu.ColumnPositionChanged += new System.EventHandler(this.grvVatTu_ColumnPositionChanged);
            // 
            // grdVatTu
            // 
            this.grdVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVatTu.Location = new System.Drawing.Point(3, 42);
            this.grdVatTu.LookAndFeel.SkinName = "Blue";
            this.grdVatTu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdVatTu.MainView = this.grvVatTu;
            this.grdVatTu.Name = "grdVatTu";
            this.grdVatTu.Size = new System.Drawing.Size(1038, 583);
            this.grdVatTu.TabIndex = 7;
            this.grdVatTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVatTu});
            // 
            // frmChonPhuTung
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 668);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonPhuTung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Vật Tư Phụ Tùng";
            this.Load += new System.EventHandler(this.frmSelectItem_Load);
            this.TlbSelectItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTonToiThieu.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVatTu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private DevExpress.XtraGrid.GridControl grdVatTu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVatTu;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton BtnOK;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl LabKho;
        private DevExpress.XtraEditors.CheckEdit chkTonToiThieu;
        private DevExpress.XtraEditors.LookUpEdit CboKho;
    }
}