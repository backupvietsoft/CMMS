namespace eAquaServer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblThoat = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTrogiup = new System.Windows.Forms.Label();
            this.btnTrogiup = new System.Windows.Forms.Button();
            this.lblTrangchu = new System.Windows.Forms.Label();
            this.btnTrangchu = new System.Windows.Forms.Button();
            this.lblKiemtraCSDL = new System.Windows.Forms.Label();
            this.btnKiemtraSql = new System.Windows.Forms.Button();
            this.lblQuaylai = new System.Windows.Forms.Label();
            this.stsSMain = new System.Windows.Forms.StatusStrip();
            this.tlLblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.pnlKetnoi = new System.Windows.Forms.Panel();
            this.btnNgatketnoi = new System.Windows.Forms.Button();
            this.btnKetnoi = new System.Windows.Forms.Button();
            this.chkBoxChotudong = new System.Windows.Forms.CheckBox();
            this.lstViewSukien = new System.Windows.Forms.ListView();
            this.clmHdrSukien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHdrThoigian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrXulydulieu_1s = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.stsSMain.SuspendLayout();
            this.pnlKetnoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::eAquaServer.Properties.Resources.BACK;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(37, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(35, 24);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlMenu.Controls.Add(this.lblThoat);
            this.pnlMenu.Controls.Add(this.btnThoat);
            this.pnlMenu.Controls.Add(this.lblTrogiup);
            this.pnlMenu.Controls.Add(this.btnTrogiup);
            this.pnlMenu.Controls.Add(this.lblTrangchu);
            this.pnlMenu.Controls.Add(this.btnTrangchu);
            this.pnlMenu.Controls.Add(this.lblKiemtraCSDL);
            this.pnlMenu.Controls.Add(this.btnKiemtraSql);
            this.pnlMenu.Controls.Add(this.lblQuaylai);
            this.pnlMenu.Controls.Add(this.btnBack);
            this.pnlMenu.Location = new System.Drawing.Point(68, 433);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(559, 46);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblThoat
            // 
            this.lblThoat.AutoSize = true;
            this.lblThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThoat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblThoat.Location = new System.Drawing.Point(496, 32);
            this.lblThoat.Name = "lblThoat";
            this.lblThoat.Size = new System.Drawing.Size(40, 13);
            this.lblThoat.TabIndex = 9;
            this.lblThoat.Text = "Thoát";
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::eAquaServer.Properties.Resources.Cancel;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.Location = new System.Drawing.Point(499, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(37, 24);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTrogiup
            // 
            this.lblTrogiup.AutoSize = true;
            this.lblTrogiup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTrogiup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTrogiup.Location = new System.Drawing.Point(363, 32);
            this.lblTrogiup.Name = "lblTrogiup";
            this.lblTrogiup.Size = new System.Drawing.Size(53, 13);
            this.lblTrogiup.TabIndex = 7;
            this.lblTrogiup.Text = "Trợ giúp";
            // 
            // btnTrogiup
            // 
            this.btnTrogiup.BackgroundImage = global::eAquaServer.Properties.Resources.HELP;
            this.btnTrogiup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrogiup.Location = new System.Drawing.Point(370, 5);
            this.btnTrogiup.Name = "btnTrogiup";
            this.btnTrogiup.Size = new System.Drawing.Size(38, 24);
            this.btnTrogiup.TabIndex = 6;
            this.btnTrogiup.UseVisualStyleBackColor = true;
            this.btnTrogiup.Click += new System.EventHandler(this.btnTrogiup_Click);
            // 
            // lblTrangchu
            // 
            this.lblTrangchu.AutoSize = true;
            this.lblTrangchu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTrangchu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTrangchu.Location = new System.Drawing.Point(234, 32);
            this.lblTrangchu.Name = "lblTrangchu";
            this.lblTrangchu.Size = new System.Drawing.Size(63, 13);
            this.lblTrangchu.TabIndex = 5;
            this.lblTrangchu.Text = "Trang chủ";
            // 
            // btnTrangchu
            // 
            this.btnTrangchu.BackgroundImage = global::eAquaServer.Properties.Resources.HOME;
            this.btnTrangchu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrangchu.Location = new System.Drawing.Point(247, 5);
            this.btnTrangchu.Name = "btnTrangchu";
            this.btnTrangchu.Size = new System.Drawing.Size(38, 24);
            this.btnTrangchu.TabIndex = 4;
            this.btnTrangchu.UseVisualStyleBackColor = true;
            // 
            // lblKiemtraCSDL
            // 
            this.lblKiemtraCSDL.AutoSize = true;
            this.lblKiemtraCSDL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblKiemtraCSDL.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblKiemtraCSDL.Location = new System.Drawing.Point(119, 32);
            this.lblKiemtraCSDL.Name = "lblKiemtraCSDL";
            this.lblKiemtraCSDL.Size = new System.Drawing.Size(86, 13);
            this.lblKiemtraCSDL.TabIndex = 3;
            this.lblKiemtraCSDL.Text = "Kiểm tra CSDL";
            // 
            // btnKiemtraSql
            // 
            this.btnKiemtraSql.BackgroundImage = global::eAquaServer.Properties.Resources.CHECKDATABASE;
            this.btnKiemtraSql.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKiemtraSql.Location = new System.Drawing.Point(144, 5);
            this.btnKiemtraSql.Name = "btnKiemtraSql";
            this.btnKiemtraSql.Size = new System.Drawing.Size(34, 24);
            this.btnKiemtraSql.TabIndex = 2;
            this.btnKiemtraSql.UseVisualStyleBackColor = true;
            this.btnKiemtraSql.Click += new System.EventHandler(this.btnKiemtraSql_Click);
            // 
            // lblQuaylai
            // 
            this.lblQuaylai.AutoSize = true;
            this.lblQuaylai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuaylai.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblQuaylai.Location = new System.Drawing.Point(29, 32);
            this.lblQuaylai.Name = "lblQuaylai";
            this.lblQuaylai.Size = new System.Drawing.Size(52, 13);
            this.lblQuaylai.TabIndex = 1;
            this.lblQuaylai.Text = "Quay lại";
            // 
            // stsSMain
            // 
            this.stsSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlLblMain});
            this.stsSMain.Location = new System.Drawing.Point(0, 521);
            this.stsSMain.Name = "stsSMain";
            this.stsSMain.Size = new System.Drawing.Size(693, 22);
            this.stsSMain.TabIndex = 2;
            this.stsSMain.Text = "statusStrip1";
            // 
            // tlLblMain
            // 
            this.tlLblMain.Name = "tlLblMain";
            this.tlLblMain.Size = new System.Drawing.Size(81, 17);
            this.tlLblMain.Text = "e-Aqua Server";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBoxPort.Location = new System.Drawing.Point(198, 62);
            this.txtBoxPort.Multiline = true;
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(94, 31);
            this.txtBoxPort.TabIndex = 5;
            this.txtBoxPort.Text = "600";
            this.txtBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPort.TextChanged += new System.EventHandler(this.txtBoxPort_TextChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPort.Location = new System.Drawing.Point(122, 67);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(56, 19);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "PORT:";
            // 
            // pnlKetnoi
            // 
            this.pnlKetnoi.Controls.Add(this.btnNgatketnoi);
            this.pnlKetnoi.Controls.Add(this.btnKetnoi);
            this.pnlKetnoi.Location = new System.Drawing.Point(530, 62);
            this.pnlKetnoi.Name = "pnlKetnoi";
            this.pnlKetnoi.Size = new System.Drawing.Size(110, 50);
            this.pnlKetnoi.TabIndex = 7;
            // 
            // btnNgatketnoi
            // 
            this.btnNgatketnoi.BackgroundImage = global::eAquaServer.Properties.Resources.Connected;
            this.btnNgatketnoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNgatketnoi.Location = new System.Drawing.Point(60, 0);
            this.btnNgatketnoi.Name = "btnNgatketnoi";
            this.btnNgatketnoi.Size = new System.Drawing.Size(50, 50);
            this.btnNgatketnoi.TabIndex = 1;
            this.btnNgatketnoi.UseVisualStyleBackColor = true;
            this.btnNgatketnoi.Visible = false;
            this.btnNgatketnoi.Click += new System.EventHandler(this.btnNgatketnoi_Click);
            // 
            // btnKetnoi
            // 
            this.btnKetnoi.BackgroundImage = global::eAquaServer.Properties.Resources.Disconnected;
            this.btnKetnoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKetnoi.Location = new System.Drawing.Point(0, 0);
            this.btnKetnoi.Name = "btnKetnoi";
            this.btnKetnoi.Size = new System.Drawing.Size(50, 50);
            this.btnKetnoi.TabIndex = 0;
            this.btnKetnoi.UseVisualStyleBackColor = true;
            this.btnKetnoi.Click += new System.EventHandler(this.btnKetnoi_Click);
            // 
            // chkBoxChotudong
            // 
            this.chkBoxChotudong.AutoSize = true;
            this.chkBoxChotudong.BackColor = System.Drawing.Color.Transparent;
            this.chkBoxChotudong.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkBoxChotudong.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkBoxChotudong.Location = new System.Drawing.Point(126, 99);
            this.chkBoxChotudong.Name = "chkBoxChotudong";
            this.chkBoxChotudong.Size = new System.Drawing.Size(117, 23);
            this.chkBoxChotudong.TabIndex = 8;
            this.chkBoxChotudong.Text = "Chờ tự động";
            this.chkBoxChotudong.UseVisualStyleBackColor = false;
            this.chkBoxChotudong.CheckedChanged += new System.EventHandler(this.chkBoxChotudong_CheckedChanged);
            // 
            // lstViewSukien
            // 
            this.lstViewSukien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewSukien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmHdrSukien,
            this.clmHdrThoigian});
            this.lstViewSukien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lstViewSukien.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstViewSukien.Location = new System.Drawing.Point(68, 148);
            this.lstViewSukien.Name = "lstViewSukien";
            this.lstViewSukien.Size = new System.Drawing.Size(559, 288);
            this.lstViewSukien.TabIndex = 13;
            this.lstViewSukien.UseCompatibleStateImageBehavior = false;
            this.lstViewSukien.View = System.Windows.Forms.View.Details;
            this.lstViewSukien.SelectedIndexChanged += new System.EventHandler(this.lstViewSukien_SelectedIndexChanged);
            // 
            // clmHdrSukien
            // 
            this.clmHdrSukien.Text = "Lắng nghe kết nối từ client";
            this.clmHdrSukien.Width = 399;
            // 
            // clmHdrThoigian
            // 
            this.clmHdrThoigian.Text = "Thời gian";
            this.clmHdrThoigian.Width = 156;
            // 
            // tmrXulydulieu_1s
            // 
            this.tmrXulydulieu_1s.Interval = 1000;
            this.tmrXulydulieu_1s.Tick += new System.EventHandler(this.tmrXulydulieu_1s_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eAquaServer.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(693, 543);
            this.Controls.Add(this.lstViewSukien);
            this.Controls.Add(this.chkBoxChotudong);
            this.Controls.Add(this.pnlKetnoi);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtBoxPort);
            this.Controls.Add(this.stsSMain);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e - Aqua Server";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.stsSMain.ResumeLayout(false);
            this.stsSMain.PerformLayout();
            this.pnlKetnoi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.StatusStrip stsSMain;
        private System.Windows.Forms.ToolStripStatusLabel tlLblMain;
        private System.Windows.Forms.Label lblKiemtraCSDL;
        private System.Windows.Forms.Button btnKiemtraSql;
        private System.Windows.Forms.Label lblQuaylai;
        private System.Windows.Forms.Label lblTrangchu;
        private System.Windows.Forms.Button btnTrangchu;
        private System.Windows.Forms.Label lblTrogiup;
        private System.Windows.Forms.Button btnTrogiup;
        private System.Windows.Forms.Label lblThoat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Panel pnlKetnoi;
        private System.Windows.Forms.Button btnKetnoi;
        private System.Windows.Forms.CheckBox chkBoxChotudong;
        private System.Windows.Forms.Button btnNgatketnoi;
        private System.Windows.Forms.ListView lstViewSukien;
        private System.Windows.Forms.ColumnHeader clmHdrSukien;
        private System.Windows.Forms.ColumnHeader clmHdrThoigian;
        private System.Windows.Forms.Timer tmrXulydulieu_1s;
    }
}

