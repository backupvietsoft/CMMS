namespace ImportExcels
{
    partial class frmImportPhuTungVC
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRowTD = new DevExpress.XtraEditors.TextEdit();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnFile = new DevExpress.XtraEditors.ButtonEdit();
            this.lokSheet = new DevExpress.XtraEditors.LookUpEdit();
            this.lblChon = new System.Windows.Forms.Label();
            this.lblRowTD = new System.Windows.Forms.Label();
            this.grdSource = new DevExpress.XtraGrid.GridControl();
            this.grvSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMS = new DevExpress.XtraEditors.TextEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.chkGT = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowTD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1100, 50);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông tin import";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.txtRowTD, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lokSheet, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblChon, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRowTD, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtRowTD
            // 
            this.txtRowTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRowTD.EditValue = "2";
            this.txtRowTD.Location = new System.Drawing.Point(1017, 3);
            this.txtRowTD.Name = "txtRowTD";
            this.txtRowTD.Size = new System.Drawing.Size(76, 20);
            this.txtRowTD.TabIndex = 15;
            this.txtRowTD.Validated += new System.EventHandler(this.btnFile_Validated);
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(3, 3);
            this.lblFile.Margin = new System.Windows.Forms.Padding(3);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(114, 19);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File excel";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFile
            // 
            this.btnFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFile.EditValue = "";
            this.btnFile.Location = new System.Drawing.Point(123, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnFile.Size = new System.Drawing.Size(341, 20);
            this.btnFile.TabIndex = 2;
            this.btnFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFile_ButtonClick);
            this.btnFile.DoubleClick += new System.EventHandler(this.btnFile_DoubleClick);
            this.btnFile.Validated += new System.EventHandler(this.btnFile_Validated);
            // 
            // lokSheet
            // 
            this.lokSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lokSheet.Location = new System.Drawing.Point(590, 3);
            this.lokSheet.Name = "lokSheet";
            this.lokSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokSheet.Properties.NullText = "";
            this.lokSheet.Size = new System.Drawing.Size(341, 20);
            this.lokSheet.TabIndex = 3;
            this.lokSheet.EditValueChanged += new System.EventHandler(this.lokSheet_EditValueChanged);
            // 
            // lblChon
            // 
            this.lblChon.Location = new System.Drawing.Point(470, 3);
            this.lblChon.Margin = new System.Windows.Forms.Padding(3);
            this.lblChon.Name = "lblChon";
            this.lblChon.Size = new System.Drawing.Size(114, 19);
            this.lblChon.TabIndex = 1;
            this.lblChon.Text = "Chọn sheet";
            this.lblChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRowTD
            // 
            this.lblRowTD.Location = new System.Drawing.Point(937, 3);
            this.lblRowTD.Margin = new System.Windows.Forms.Padding(3);
            this.lblRowTD.Name = "lblRowTD";
            this.lblRowTD.Size = new System.Drawing.Size(74, 19);
            this.lblRowTD.TabIndex = 1;
            this.lblRowTD.Text = "lblRowTD";
            this.lblRowTD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdSource
            // 
            this.grdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSource.Location = new System.Drawing.Point(2, 22);
            this.grdSource.MainView = this.grvSource;
            this.grdSource.Name = "grdSource";
            this.grdSource.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdSource.Size = new System.Drawing.Size(1096, 573);
            this.grdSource.TabIndex = 6;
            this.grdSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSource});
            // 
            // grvSource
            // 
            this.grvSource.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvSource.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSource.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvSource.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvSource.GridControl = this.grdSource;
            this.grvSource.HorzScrollStep = 1;
            this.grvSource.Name = "grvSource";
            this.grvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSource.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvSource.OptionsCustomization.AllowColumnMoving = false;
            this.grvSource.OptionsCustomization.AllowRowSizing = true;
            this.grvSource.OptionsLayout.Columns.AddNewColumns = false;
            this.grvSource.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvSource.OptionsSelection.MultiSelect = true;
            this.grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvSource.OptionsView.ColumnAutoWidth = false;
            this.grvSource.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grdSource);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 59);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1100, 597);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Dữ liệu import";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.prbIN, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1106, 723);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // prbIN
            // 
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 662);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(1100, 16);
            this.prbIN.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.txtMS, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExit, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkGT, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 684);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1100, 36);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // txtMS
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtMS, 2);
            this.txtMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMS.Location = new System.Drawing.Point(3, 3);
            this.txtMS.Name = "txtMS";
            this.txtMS.Size = new System.Drawing.Size(214, 20);
            this.txtMS.TabIndex = 15;
            this.txtMS.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtMS_EditValueChanging);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(993, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkGT
            // 
            this.chkGT.Location = new System.Drawing.Point(773, 3);
            this.chkGT.Name = "chkGT";
            this.chkGT.Properties.Caption = "chkGT";
            this.chkGT.Size = new System.Drawing.Size(104, 18);
            this.chkGT.TabIndex = 14;
            this.chkGT.Visible = false;
            // 
            // frmImportPhuTungVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 723);
            this.Controls.Add(this.tableLayoutPanel3);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmImportPhuTungVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportPhuTungVC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRowTD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblChon;
        private DevExpress.XtraEditors.ButtonEdit btnFile;
        private DevExpress.XtraEditors.LookUpEdit lokSheet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.CheckEdit chkGT;
        private DevExpress.XtraEditors.TextEdit txtMS;
        private DevExpress.XtraEditors.TextEdit txtRowTD;
        private System.Windows.Forms.Label lblRowTD;
    }
}