namespace ReportHuda
{
    partial class frmTinhHinhTonKhoThayThe
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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTKiem = new DevExpress.XtraEditors.LabelControl();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblCXem = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkHet = new DevExpress.XtraEditors.CheckEdit();
            this.chkThieu = new DevExpress.XtraEditors.CheckEdit();
            this.chkVuaDu = new DevExpress.XtraEditors.CheckEdit();
            this.chkDu = new DevExpress.XtraEditors.CheckEdit();
            this.cboKho = new DevExpress.XtraEditors.LookUpEdit();
            this.lblKho = new System.Windows.Forms.Label();
            this.lblTVT = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVuaDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 117);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(862, 420);
            this.grdChung.TabIndex = 1;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung,
            this.advBandedGridView1,
            this.layoutView1,
            this.gridView1});
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsBehavior.Editable = false;
            this.grvChung.OptionsView.ColumnAutoWidth = false;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvChung_RowCellStyle);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.grdChung;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 189;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.grdChung;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdChung;
            this.gridView1.Name = "gridView1";
            // 
            // lblTKiem
            // 
            this.lblTKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTKiem.Location = new System.Drawing.Point(3, 577);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Size = new System.Drawing.Size(69, 19);
            this.lblTKiem.TabIndex = 17;
            this.lblTKiem.Text = "lblTKiem";
            // 
            // txtTKiem
            // 
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(78, 576);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(139, 20);
            this.txtTKiem.TabIndex = 18;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // lblCXem
            // 
            this.lblCXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCXem.Location = new System.Drawing.Point(78, 70);
            this.lblCXem.Name = "lblCXem";
            this.lblCXem.Size = new System.Drawing.Size(139, 29);
            this.lblCXem.TabIndex = 15;
            this.lblCXem.Text = "lblCXem";
            this.lblCXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.chkHet, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkThieu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkVuaDu, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkDu, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(223, 73);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 23);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // chkHet
            // 
            this.chkHet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHet.EditValue = true;
            this.chkHet.Location = new System.Drawing.Point(3, 3);
            this.chkHet.Name = "chkHet";
            this.chkHet.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.chkHet.Properties.Appearance.Options.UseBackColor = true;
            this.chkHet.Properties.Caption = "chkHet";
            this.chkHet.Size = new System.Drawing.Size(99, 18);
            this.chkHet.TabIndex = 0;
            this.chkHet.CheckedChanged += new System.EventHandler(this.chkHet_CheckedChanged);
            // 
            // chkThieu
            // 
            this.chkThieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkThieu.EditValue = true;
            this.chkThieu.Location = new System.Drawing.Point(108, 3);
            this.chkThieu.Name = "chkThieu";
            this.chkThieu.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.chkThieu.Properties.Appearance.Options.UseBackColor = true;
            this.chkThieu.Properties.Caption = "chkThieu";
            this.chkThieu.Size = new System.Drawing.Size(99, 18);
            this.chkThieu.TabIndex = 0;
            this.chkThieu.CheckedChanged += new System.EventHandler(this.chkThieu_CheckedChanged);
            // 
            // chkVuaDu
            // 
            this.chkVuaDu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkVuaDu.EditValue = true;
            this.chkVuaDu.Location = new System.Drawing.Point(213, 3);
            this.chkVuaDu.Name = "chkVuaDu";
            this.chkVuaDu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.chkVuaDu.Properties.Appearance.Options.UseBackColor = true;
            this.chkVuaDu.Properties.Caption = "chkVuaDu";
            this.chkVuaDu.Size = new System.Drawing.Size(99, 18);
            this.chkVuaDu.TabIndex = 0;
            this.chkVuaDu.CheckedChanged += new System.EventHandler(this.chkVuaDu_CheckedChanged);
            // 
            // chkDu
            // 
            this.chkDu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDu.EditValue = true;
            this.chkDu.Location = new System.Drawing.Point(318, 3);
            this.chkDu.Name = "chkDu";
            this.chkDu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            this.chkDu.Properties.Appearance.Options.UseBackColor = true;
            this.chkDu.Properties.Caption = "chkDu";
            this.chkDu.Size = new System.Drawing.Size(101, 18);
            this.chkDu.TabIndex = 0;
            this.chkDu.CheckedChanged += new System.EventHandler(this.chkDu_CheckedChanged);
            // 
            // cboKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboKho, 2);
            this.cboKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKho.Location = new System.Drawing.Point(223, 48);
            this.cboKho.Name = "cboKho";
            this.cboKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKho.Size = new System.Drawing.Size(422, 20);
            this.cboKho.TabIndex = 16;
            this.cboKho.EditValueChanged += new System.EventHandler(this.cboKho_EditValueChanged);
            // 
            // lblKho
            // 
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(78, 45);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(139, 25);
            this.lblKho.TabIndex = 15;
            this.lblKho.Text = "lblKho";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTVT
            // 
            this.lblTVT.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTVT, 6);
            this.lblTVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTVT.Location = new System.Drawing.Point(3, 99);
            this.lblTVT.Name = "lblTVT";
            this.lblTVT.Size = new System.Drawing.Size(862, 15);
            this.lblTVT.TabIndex = 13;
            this.lblTVT.Text = "lblLVT";
            this.lblTVT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnCancel.Location = new System.Drawing.Point(761, 567);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 6);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(862, 35);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 543);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(862, 18);
            this.prbIN.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblTVT, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboKho, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCXem, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblTKiem, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(868, 599);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // frmTinhHinhTonKhoThayThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(884, 637);
            this.Name = "frmTinhHinhTonKhoThayThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTinhHinhTonKhoThayThe";
            this.Load += new System.EventHandler(this.frmTinhHinhTonKhoThayThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkHet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVuaDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdChung;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblTVT;
        private System.Windows.Forms.Label lblKho;
        private DevExpress.XtraEditors.LookUpEdit cboKho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.CheckEdit chkHet;
        private DevExpress.XtraEditors.CheckEdit chkThieu;
        private DevExpress.XtraEditors.CheckEdit chkVuaDu;
        private DevExpress.XtraEditors.CheckEdit chkDu;
        private System.Windows.Forms.Label lblCXem;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.LabelControl lblTKiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}