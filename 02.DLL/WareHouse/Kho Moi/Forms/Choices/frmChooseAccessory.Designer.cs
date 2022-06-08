﻿namespace WareHouse
{
    partial class frmChooseAccessory : DevExpress.XtraEditors.XtraForm
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
            this.TEN_PT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOAI_VAT_TU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_DV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTK = new DevExpress.XtraEditors.TextEdit();
            this.btnUncheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdList, 3);
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(3, 3);
            this.grdList.MainView = this.grvList;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(878, 515);
            this.grdList.TabIndex = 1;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvList});
            // 
            // grvList
            // 
            this.grvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CHON,
            this.MS_PT,
            this.TEN_PT,
            this.LOAI_VAT_TU,
            this.PART_NO,
            this.TEN_DV,
            this.SL});
            this.grvList.GridControl = this.grdList;
            this.grvList.Name = "grvList";
            this.grvList.OptionsView.EnableAppearanceEvenRow = true;
            this.grvList.OptionsView.EnableAppearanceOddRow = true;
            this.grvList.OptionsView.ShowGroupPanel = false;
            // 
            // CHON
            // 
            this.CHON.Caption = "CHỌN";
            this.CHON.FieldName = "CHON";
            this.CHON.Name = "CHON";
            this.CHON.Visible = true;
            this.CHON.VisibleIndex = 0;
            // 
            // MS_PT
            // 
            this.MS_PT.Caption = "MS_PT";
            this.MS_PT.FieldName = "MS_PT";
            this.MS_PT.Name = "MS_PT";
            this.MS_PT.OptionsColumn.AllowEdit = false;
            this.MS_PT.Visible = true;
            this.MS_PT.VisibleIndex = 1;
            this.MS_PT.Width = 150;
            // 
            // TEN_PT
            // 
            this.TEN_PT.Caption = "TÊN PT";
            this.TEN_PT.FieldName = "TEN_PT";
            this.TEN_PT.Name = "TEN_PT";
            this.TEN_PT.OptionsColumn.AllowEdit = false;
            this.TEN_PT.Visible = true;
            this.TEN_PT.VisibleIndex = 2;
            this.TEN_PT.Width = 200;
            // 
            // LOAI_VAT_TU
            // 
            this.LOAI_VAT_TU.Caption = "LOẠI VẬT TƯ";
            this.LOAI_VAT_TU.FieldName = "LOAI_VAT_TU";
            this.LOAI_VAT_TU.Name = "LOAI_VAT_TU";
            this.LOAI_VAT_TU.OptionsColumn.AllowEdit = false;
            this.LOAI_VAT_TU.Visible = true;
            this.LOAI_VAT_TU.VisibleIndex = 3;
            this.LOAI_VAT_TU.Width = 150;
            // 
            // PART_NO
            // 
            this.PART_NO.Caption = "PART_NO";
            this.PART_NO.FieldName = "MS_PT_NCC";
            this.PART_NO.Name = "PART_NO";
            this.PART_NO.OptionsColumn.AllowEdit = false;
            this.PART_NO.Visible = true;
            this.PART_NO.VisibleIndex = 4;
            this.PART_NO.Width = 150;
            // 
            // TEN_DV
            // 
            this.TEN_DV.Caption = "ĐƠN VỊ TÍNH";
            this.TEN_DV.FieldName = "TEN_DV";
            this.TEN_DV.Name = "TEN_DV";
            this.TEN_DV.OptionsColumn.AllowEdit = false;
            this.TEN_DV.Visible = true;
            this.TEN_DV.VisibleIndex = 5;
            // 
            // SL
            // 
            this.SL.Caption = "SỐ LƯỢNG";
            this.SL.FieldName = "SL";
            this.SL.Name = "SL";
            this.SL.OptionsColumn.AllowEdit = false;
            this.SL.Visible = true;
            this.SL.VisibleIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.grdList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelControl1, 3);
            this.panelControl1.Controls.Add(this.btnExecute);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnUncheck);
            this.panelControl1.Controls.Add(this.btnCheck);
            this.panelControl1.Controls.Add(this.txtTK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 524);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(878, 34);
            this.panelControl1.TabIndex = 6;
            // 
            // txtTK
            // 
            this.txtTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTK.Location = new System.Drawing.Point(1, 8);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(195, 20);
            this.txtTK.TabIndex = 0;
            this.txtTK.EditValueChanged += new System.EventHandler(this.txtTK_EditValueChanged);
            // 
            // btnUncheck
            // 
            this.btnUncheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUncheck.Location = new System.Drawing.Point(561, 2);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(104, 30);
            this.btnUncheck.TabIndex = 9;
            this.btnUncheck.Text = "Khong";
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(456, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(104, 30);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "Chon";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(666, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "OK";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(771, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 30);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmChooseAccessory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChooseAccessory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChooseAccessory";
            this.Load += new System.EventHandler(this.frmChooseAccessory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn CHON;
        private DevExpress.XtraGrid.Columns.GridColumn MS_PT;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PT;
        private DevExpress.XtraGrid.Columns.GridColumn LOAI_VAT_TU;
        private DevExpress.XtraGrid.Columns.GridColumn PART_NO;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_DV;
        private DevExpress.XtraGrid.Columns.GridColumn SL;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTK;
        private DevExpress.XtraEditors.SimpleButton btnUncheck;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}