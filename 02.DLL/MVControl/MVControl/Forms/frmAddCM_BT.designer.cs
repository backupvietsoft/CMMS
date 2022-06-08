namespace MVControl
{
    partial class frmAddCM_BT
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmenuChon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBoChon = new System.Windows.Forms.ToolStripMenuItem();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.grpBacTho = new DevExpress.XtraEditors.GroupControl();
            this.grdThongtinPT = new DevExpress.XtraGrid.GridControl();
            this.grvThongtinPT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.tlstCauTruc = new DevExpress.XtraTreeList.TreeList();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBacTho)).BeginInit();
            this.grpBacTho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdThongtinPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongtinPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlstCauTruc)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuChon,
            this.tsmenuBoChon});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // tsmenuChon
            // 
            this.tsmenuChon.Name = "tsmenuChon";
            this.tsmenuChon.Size = new System.Drawing.Size(118, 22);
            this.tsmenuChon.Text = "Chọn";
            // 
            // tsmenuBoChon
            // 
            this.tsmenuBoChon.Name = "tsmenuBoChon";
            this.tsmenuBoChon.Size = new System.Drawing.Size(118, 22);
            this.tsmenuBoChon.Text = "Bỏ chọn";
            // 
            // treeList1
            // 
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(400, 200);
            this.treeList1.TabIndex = 0;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TableLayoutPanel3.ColumnCount = 6;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.18736F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.81264F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel3.Controls.Add(this.btnThucHien, 4, 1);
            this.TableLayoutPanel3.Controls.Add(this.grpBacTho, 3, 0);
            this.TableLayoutPanel3.Controls.Add(this.btnThoat, 5, 1);
            this.TableLayoutPanel3.Controls.Add(this.tlstCauTruc, 0, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(802, 493);
            this.TableLayoutPanel3.TabIndex = 68;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThucHien.Location = new System.Drawing.Point(584, 458);
            this.btnThucHien.LookAndFeel.SkinName = "Blue";
            this.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(104, 32);
            this.btnThucHien.TabIndex = 35;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // grpBacTho
            // 
            this.TableLayoutPanel3.SetColumnSpan(this.grpBacTho, 3);
            this.grpBacTho.Controls.Add(this.grdThongtinPT);
            this.grpBacTho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBacTho.Location = new System.Drawing.Point(292, 3);
            this.grpBacTho.LookAndFeel.SkinName = "Blue";
            this.grpBacTho.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpBacTho.Name = "grpBacTho";
            this.grpBacTho.Size = new System.Drawing.Size(507, 449);
            this.grpBacTho.TabIndex = 28;
            this.grpBacTho.Text = "grpDanhsachPT";
            // 
            // grdThongtinPT
            // 
            this.grdThongtinPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdThongtinPT.Location = new System.Drawing.Point(2, 22);
            this.grdThongtinPT.LookAndFeel.SkinName = "Blue";
            this.grdThongtinPT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdThongtinPT.MainView = this.grvThongtinPT;
            this.grdThongtinPT.Name = "grdThongtinPT";
            this.grdThongtinPT.Size = new System.Drawing.Size(503, 425);
            this.grdThongtinPT.TabIndex = 5;
            this.grdThongtinPT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvThongtinPT,
            this.gridView1});
            // 
            // grvThongtinPT
            // 
            this.grvThongtinPT.GridControl = this.grdThongtinPT;
            this.grvThongtinPT.Name = "grvThongtinPT";
            this.grvThongtinPT.OptionsView.ColumnAutoWidth = false;
            this.grvThongtinPT.OptionsView.ShowGroupPanel = false;
            this.grvThongtinPT.ShownEditor += new System.EventHandler(this.grvThongtinPT_ShownEditor);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdThongtinPT;
            this.gridView1.Name = "gridView1";
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(694, 458);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 32);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tlstCauTruc
            // 
            this.tlstCauTruc.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Blue;
            this.tlstCauTruc.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.tlstCauTruc.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tlstCauTruc.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.TableLayoutPanel3.SetColumnSpan(this.tlstCauTruc, 3);
            this.tlstCauTruc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlstCauTruc.Location = new System.Drawing.Point(3, 3);
            this.tlstCauTruc.LookAndFeel.SkinName = "Blue";
            this.tlstCauTruc.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlstCauTruc.Name = "tlstCauTruc";
            this.tlstCauTruc.OptionsView.ShowCheckBoxes = true;
            this.tlstCauTruc.ParentFieldName = "";
            this.tlstCauTruc.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.tlstCauTruc.Size = new System.Drawing.Size(283, 449);
            this.tlstCauTruc.TabIndex = 29;
            this.tlstCauTruc.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlstCauTruc_AfterCheckNode);
            this.tlstCauTruc.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlstCauTruc_FocusedNodeChanged);
            // 
            // frmAddCM_BT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 493);
            this.Controls.Add(this.TableLayoutPanel3);
            this.Name = "frmAddCM_BT";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmAddCM_BT_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBacTho)).EndInit();
            this.grpBacTho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdThongtinPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongtinPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlstCauTruc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuChon;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBoChon;
        private DevExpress.XtraTreeList.TreeList treeList1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        private DevExpress.XtraEditors.GroupControl grpBacTho;
        internal DevExpress.XtraGrid.GridControl grdThongtinPT;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvThongtinPT;
        internal DevExpress.XtraEditors.SimpleButton btnThucHien;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraTreeList.TreeList tlstCauTruc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}