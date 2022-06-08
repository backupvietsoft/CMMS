namespace Vs.Support
{
    partial class frmLogin
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.chkRePassword = new System.Windows.Forms.CheckBox();
            this.chkReUser = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.lblLogin, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDatabase, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUserName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPassWord, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkRePassword, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkReUser, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboDatabase, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.48484F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.51515F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblLogin, 2);
            this.lblLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(155, 8);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(230, 52);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "lblLogin";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatabase.Location = new System.Drawing.Point(155, 60);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(117, 26);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "lblDatabase";
            this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Location = new System.Drawing.Point(155, 86);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(117, 26);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "lblUserName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassWord.Location = new System.Drawing.Point(155, 112);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(117, 26);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "lblPassWord";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRePassword
            // 
            this.chkRePassword.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkRePassword, 2);
            this.chkRePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRePassword.Location = new System.Drawing.Point(278, 141);
            this.chkRePassword.Name = "chkRePassword";
            this.chkRePassword.Size = new System.Drawing.Size(227, 20);
            this.chkRePassword.TabIndex = 5;
            this.chkRePassword.Text = "chkRePassword";
            this.chkRePassword.UseVisualStyleBackColor = true;
            // 
            // chkReUser
            // 
            this.chkReUser.AutoSize = true;
            this.chkReUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkReUser.Location = new System.Drawing.Point(155, 141);
            this.chkReUser.Name = "chkReUser";
            this.chkReUser.Size = new System.Drawing.Size(117, 20);
            this.chkReUser.TabIndex = 4;
            this.chkReUser.Text = "chkReUser";
            this.chkReUser.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUsername, 2);
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(278, 89);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(227, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPassword, 2);
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(278, 115);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(227, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cboDatabase
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDatabase, 2);
            this.cboDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(278, 63);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(227, 21);
            this.cboDatabase.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(386, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 36);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDangNhap.Location = new System.Drawing.Point(278, 0);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(108, 36);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "btnDangNhap";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 36);
            this.panel1.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.CheckBox chkRePassword;
        private System.Windows.Forms.CheckBox chkReUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}