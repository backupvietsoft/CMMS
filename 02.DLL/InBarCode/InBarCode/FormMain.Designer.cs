namespace InBarCode
{
    partial class FormMain
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_ThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btn_BoChon = new DevExpress.XtraEditors.SimpleButton();
            this.btn_chonAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.tablePanel1.Controls.Add(this.searchControl1);
            this.tablePanel1.Controls.Add(this.grdMay);
            this.tablePanel1.Controls.Add(this.btn_ThucHien);
            this.tablePanel1.Controls.Add(this.btn_BoChon);
            this.tablePanel1.Controls.Add(this.btn_chonAll);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 25F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 25F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F)});
            this.tablePanel1.Size = new System.Drawing.Size(890, 568);
            this.tablePanel1.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdMay;
            this.tablePanel1.SetColumn(this.searchControl1, 0);
            this.searchControl1.Location = new System.Drawing.Point(3, 538);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdMay;
            this.tablePanel1.SetRow(this.searchControl1, 4);
            this.searchControl1.Size = new System.Drawing.Size(550, 20);
            this.searchControl1.TabIndex = 2;
            // 
            // grdMay
            // 
            this.tablePanel1.SetColumn(this.grdMay, 0);
            this.tablePanel1.SetColumnSpan(this.grdMay, 4);
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.Location = new System.Drawing.Point(3, 53);
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.tablePanel1.SetRow(this.grdMay, 2);
            this.grdMay.Size = new System.Drawing.Size(884, 464);
            this.grdMay.TabIndex = 1;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsSelection.MultiSelect = true;
            this.grvMay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvMay.OptionsView.ShowGroupPanel = false;
            // 
            // btn_ThucHien
            // 
            this.tablePanel1.SetColumn(this.btn_ThucHien, 3);
            this.btn_ThucHien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ThucHien.Location = new System.Drawing.Point(782, 531);
            this.btn_ThucHien.Name = "btn_ThucHien";
            this.tablePanel1.SetRow(this.btn_ThucHien, 4);
            this.btn_ThucHien.Size = new System.Drawing.Size(105, 34);
            this.btn_ThucHien.TabIndex = 0;
            this.btn_ThucHien.Text = "Thực Hiện";
            this.btn_ThucHien.Click += new System.EventHandler(this.btn_ThucHien_Click);
            // 
            // btn_BoChon
            // 
            this.tablePanel1.SetColumn(this.btn_BoChon, 2);
            this.btn_BoChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_BoChon.Location = new System.Drawing.Point(671, 531);
            this.btn_BoChon.Name = "btn_BoChon";
            this.tablePanel1.SetRow(this.btn_BoChon, 4);
            this.btn_BoChon.Size = new System.Drawing.Size(105, 34);
            this.btn_BoChon.TabIndex = 0;
            this.btn_BoChon.Text = "Bỏ Chọn";
            // 
            // btn_chonAll
            // 
            this.tablePanel1.SetColumn(this.btn_chonAll, 1);
            this.btn_chonAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_chonAll.Location = new System.Drawing.Point(559, 531);
            this.btn_chonAll.Name = "btn_chonAll";
            this.tablePanel1.SetRow(this.btn_chonAll, 4);
            this.btn_chonAll.Size = new System.Drawing.Size(105, 34);
            this.btn_chonAll.TabIndex = 0;
            this.btn_chonAll.Text = "Chọn All";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 568);
            this.Controls.Add(this.tablePanel1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
        private DevExpress.XtraEditors.SimpleButton btn_ThucHien;
        private DevExpress.XtraEditors.SimpleButton btn_BoChon;
        private DevExpress.XtraEditors.SimpleButton btn_chonAll;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}