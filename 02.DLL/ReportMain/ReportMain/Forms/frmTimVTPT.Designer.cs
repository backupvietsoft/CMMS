namespace ReportMain
{
    partial class frmTimVTPT
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
            this.lblTKiem = new DevExpress.XtraEditors.LabelControl();
            this.grdVT = new DevExpress.XtraGrid.GridControl();
            this.grvVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblLVT = new System.Windows.Forms.Label();
            this.cboLVT = new DevExpress.XtraEditors.LookUpEdit();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.lblTKiem, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdVT, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTieuDe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLVT, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboLVT, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnALL, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnNotALL, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblTKiem
            // 
            this.lblTKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTKiem.Location = new System.Drawing.Point(3, 528);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Size = new System.Drawing.Size(114, 30);
            this.lblTKiem.TabIndex = 25;
            this.lblTKiem.Text = "lblTKiem";
            // 
            // grdVT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdVT, 7);
            this.grdVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVT.Location = new System.Drawing.Point(3, 74);
            this.grdVT.LookAndFeel.SkinName = "Blue";
            this.grdVT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdVT.MainView = this.grvVT;
            this.grdVT.Name = "grdVT";
            this.grdVT.Size = new System.Drawing.Size(878, 448);
            this.grdVT.TabIndex = 4;
            this.grdVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVT});
            // 
            // grvVT
            // 
            this.grvVT.GridControl = this.grdVT;
            this.grvVT.Name = "grvVT";
            this.grvVT.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvVT.OptionsCustomization.AllowColumnMoving = false;
            this.grvVT.OptionsCustomization.AllowGroup = false;
            this.grvVT.OptionsView.ShowGroupPanel = false;
            this.grvVT.ShownEditor += new System.EventHandler(this.grvVT_ShownEditor);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTieuDe, 7);
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
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(123, 538);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(114, 20);
            this.txtTKiem.TabIndex = 5;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // lblLVT
            // 
            this.lblLVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLVT.Location = new System.Drawing.Point(123, 38);
            this.lblLVT.Name = "lblLVT";
            this.lblLVT.Size = new System.Drawing.Size(114, 25);
            this.lblLVT.TabIndex = 27;
            this.lblLVT.Text = "lblLVT";
            this.lblLVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLVT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLVT, 4);
            this.cboLVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLVT.Location = new System.Drawing.Point(243, 41);
            this.cboLVT.Name = "cboLVT";
            this.cboLVT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLVT.Size = new System.Drawing.Size(528, 20);
            this.cboLVT.TabIndex = 1;
            this.cboLVT.EditValueChanged += new System.EventHandler(this.cboLVT_EditValueChanged);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Image = global::ReportMain.Properties.Resources.btnall;
            this.btnALL.Location = new System.Drawing.Point(447, 528);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 28;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Image = global::ReportMain.Properties.Resources.btnuncheckall;
            this.btnNotALL.Location = new System.Drawing.Point(557, 528);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 29;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // frmTimVTPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTimVTPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTimVT";
            this.Load += new System.EventHandler(this.frmTimVT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblTKiem;
        private DevExpress.XtraGrid.GridControl grdVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVT;
        private System.Windows.Forms.Label lblTieuDe;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private System.Windows.Forms.Label lblLVT;
        private DevExpress.XtraEditors.LookUpEdit cboLVT;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
    }
}