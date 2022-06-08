namespace WareHouse
{
    partial class frmChooseAccessory_Issued : DevExpress.XtraEditors.XtraForm
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
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MS_PT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MS_PT_NCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOAI_VAT_TU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUY_CACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_DV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdList, 3);
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(3, 3);
            this.grdList.MainView = this.grvList;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(878, 519);
            this.grdList.TabIndex = 1;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvList});
            // 
            // grvList
            // 
            this.grvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CHON,
            this.MS_PT,
            this.MS_PT_NCC,
            this.TEN_PT,
            this.LOAI_VAT_TU,
            this.QUY_CACH,
            this.TEN_DV});
            this.grvList.GridControl = this.grdList;
            this.grvList.Name = "grvList";
            this.grvList.OptionsView.ColumnAutoWidth = false;
            this.grvList.OptionsView.EnableAppearanceEvenRow = true;
            this.grvList.OptionsView.EnableAppearanceOddRow = true;
            this.grvList.OptionsView.ShowGroupPanel = false;
            // 
            // CHON
            // 
            this.CHON.AppearanceHeader.Options.UseTextOptions = true;
            this.CHON.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CHON.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CHON.Caption = "CHỌN";
            this.CHON.FieldName = "CHON";
            this.CHON.Name = "CHON";
            this.CHON.Visible = true;
            this.CHON.VisibleIndex = 0;
            // 
            // MS_PT
            // 
            this.MS_PT.AppearanceHeader.Options.UseTextOptions = true;
            this.MS_PT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MS_PT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MS_PT.Caption = "MS_PT";
            this.MS_PT.FieldName = "MS_PT";
            this.MS_PT.Name = "MS_PT";
            this.MS_PT.OptionsColumn.AllowEdit = false;
            this.MS_PT.Visible = true;
            this.MS_PT.VisibleIndex = 1;
            this.MS_PT.Width = 150;
            // 
            // MS_PT_NCC
            // 
            this.MS_PT_NCC.AppearanceHeader.Options.UseTextOptions = true;
            this.MS_PT_NCC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MS_PT_NCC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MS_PT_NCC.Caption = "Part No";
            this.MS_PT_NCC.FieldName = "MS_PT_NCC";
            this.MS_PT_NCC.Name = "MS_PT_NCC";
            this.MS_PT_NCC.OptionsColumn.AllowEdit = false;
            this.MS_PT_NCC.Visible = true;
            this.MS_PT_NCC.VisibleIndex = 2;
            // 
            // TEN_PT
            // 
            this.TEN_PT.AppearanceHeader.Options.UseTextOptions = true;
            this.TEN_PT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEN_PT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TEN_PT.Caption = "TÊN PT";
            this.TEN_PT.FieldName = "TEN_PT";
            this.TEN_PT.Name = "TEN_PT";
            this.TEN_PT.OptionsColumn.AllowEdit = false;
            this.TEN_PT.Visible = true;
            this.TEN_PT.VisibleIndex = 3;
            this.TEN_PT.Width = 200;
            // 
            // LOAI_VAT_TU
            // 
            this.LOAI_VAT_TU.AppearanceHeader.Options.UseTextOptions = true;
            this.LOAI_VAT_TU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LOAI_VAT_TU.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LOAI_VAT_TU.Caption = "Loại Vật Tư";
            this.LOAI_VAT_TU.FieldName = "LOAI_VAT_TU";
            this.LOAI_VAT_TU.Name = "LOAI_VAT_TU";
            this.LOAI_VAT_TU.OptionsColumn.AllowEdit = false;
            this.LOAI_VAT_TU.Visible = true;
            this.LOAI_VAT_TU.VisibleIndex = 4;
            this.LOAI_VAT_TU.Width = 141;
            // 
            // QUY_CACH
            // 
            this.QUY_CACH.AppearanceHeader.Options.UseTextOptions = true;
            this.QUY_CACH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QUY_CACH.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.QUY_CACH.Caption = "QUY_CACH";
            this.QUY_CACH.FieldName = "QUY_CACH";
            this.QUY_CACH.Name = "QUY_CACH";
            this.QUY_CACH.OptionsColumn.AllowEdit = false;
            this.QUY_CACH.Visible = true;
            this.QUY_CACH.VisibleIndex = 5;
            this.QUY_CACH.Width = 150;
            // 
            // TEN_DV
            // 
            this.TEN_DV.AppearanceHeader.Options.UseTextOptions = true;
            this.TEN_DV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEN_DV.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TEN_DV.Caption = "ĐƠN VỊ TÍNH";
            this.TEN_DV.FieldName = "TEN_DV";
            this.TEN_DV.Name = "TEN_DV";
            this.TEN_DV.OptionsColumn.AllowEdit = false;
            this.TEN_DV.Visible = true;
            this.TEN_DV.VisibleIndex = 6;
            this.TEN_DV.Width = 97;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.grdList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Appearance.Options.UseFont = true;
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(667, 528);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "&Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(777, 528);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 30);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmChooseAccessory_Issued
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChooseAccessory_Issued";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChooseAccessory";
            this.Load += new System.EventHandler(this.frmChooseAccessory_Issued_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.Columns.GridColumn CHON;
        private DevExpress.XtraGrid.Columns.GridColumn MS_PT;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PT;
        private DevExpress.XtraGrid.Columns.GridColumn QUY_CACH;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_DV;
        private DevExpress.XtraGrid.Columns.GridColumn LOAI_VAT_TU;
        private DevExpress.XtraGrid.Columns.GridColumn MS_PT_NCC;
    }
}