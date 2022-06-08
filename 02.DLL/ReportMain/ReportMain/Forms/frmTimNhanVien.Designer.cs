namespace ReportMain
{
    partial class frmTimNhanVien
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
            this.grdNVien = new DevExpress.XtraGrid.GridControl();
            this.grvNVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblPBan = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.cboDVi = new DevExpress.XtraEditors.LookUpEdit();
            this.cboPBan = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.grdNVien, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTieuDe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDonVi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPBan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboDVi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboPBan, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboTo, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdNVien
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdNVien, 5);
            this.grdNVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNVien.Location = new System.Drawing.Point(3, 124);
            this.grdNVien.LookAndFeel.SkinName = "Blue";
            this.grdNVien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdNVien.MainView = this.grvNVien;
            this.grdNVien.Name = "grdNVien";
            this.grdNVien.Size = new System.Drawing.Size(878, 398);
            this.grdNVien.TabIndex = 4;
            this.grdNVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNVien});
            // 
            // grvNVien
            // 
            this.grvNVien.GridControl = this.grdNVien;
            this.grvNVien.Name = "grvNVien";
            this.grvNVien.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvNVien.OptionsCustomization.AllowColumnMoving = false;
            this.grvNVien.OptionsCustomization.AllowGroup = false;
            this.grvNVien.OptionsView.ShowGroupPanel = false;
            this.grvNVien.ShownEditor += new System.EventHandler(this.grvNVien_ShownEditor);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTieuDe, 5);
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lblTieuDe.Location = new System.Drawing.Point(3, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(878, 38);
            this.lblTieuDe.TabIndex = 11;
            this.lblTieuDe.Text = "lblTieuDe";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(777, 528);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(667, 528);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtTKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTKiem, 2);
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(3, 538);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(234, 20);
            this.txtTKiem.TabIndex = 5;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            this.txtTKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTKiem_KeyDown);
            // 
            // lblDonVi
            // 
            this.lblDonVi.Location = new System.Drawing.Point(123, 38);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(94, 25);
            this.lblDonVi.TabIndex = 27;
            this.lblDonVi.Text = "lblDonVi";
            this.lblDonVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPBan
            // 
            this.lblPBan.Location = new System.Drawing.Point(123, 63);
            this.lblPBan.Name = "lblPBan";
            this.lblPBan.Size = new System.Drawing.Size(94, 25);
            this.lblPBan.TabIndex = 27;
            this.lblPBan.Text = "lblPBan";
            this.lblPBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(123, 88);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(94, 25);
            this.lblTo.TabIndex = 27;
            this.lblTo.Text = "lblTo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDVi
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDVi, 2);
            this.cboDVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDVi.Location = new System.Drawing.Point(243, 41);
            this.cboDVi.Name = "cboDVi";
            this.cboDVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDVi.Size = new System.Drawing.Size(528, 20);
            this.cboDVi.TabIndex = 1;
            this.cboDVi.EditValueChanged += new System.EventHandler(this.cboDVi_EditValueChanged);
            // 
            // cboPBan
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboPBan, 2);
            this.cboPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPBan.Location = new System.Drawing.Point(243, 66);
            this.cboPBan.Name = "cboPBan";
            this.cboPBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPBan.Size = new System.Drawing.Size(528, 20);
            this.cboPBan.TabIndex = 2;
            this.cboPBan.EditValueChanged += new System.EventHandler(this.cboPBan_EditValueChanged);
            // 
            // cboTo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboTo, 2);
            this.cboTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTo.Location = new System.Drawing.Point(243, 91);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Size = new System.Drawing.Size(528, 20);
            this.cboTo.TabIndex = 3;
            this.cboTo.EditValueChanged += new System.EventHandler(this.cboTo_EditValueChanged);
            // 
            // frmTimNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTimNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimNhanVien";
            this.Load += new System.EventHandler(this.frmTimNhanVien_Load);
            this.Shown += new System.EventHandler(this.frmTimNhanVien_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTieuDe;
        private DevExpress.XtraGrid.GridControl grdNVien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNVien;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblPBan;
        private System.Windows.Forms.Label lblTo;
        private DevExpress.XtraEditors.LookUpEdit cboDVi;
        private DevExpress.XtraEditors.LookUpEdit cboPBan;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
    }
}