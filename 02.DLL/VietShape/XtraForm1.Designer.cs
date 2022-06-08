namespace VietShape
{
    partial class XtraForm1
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbDieuDo = new DevExpress.XtraTab.XtraTabControl();
            this.tabKHTT = new DevExpress.XtraTab.XtraTabPage();
            this.tabGSTT = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tbDieuDo)).BeginInit();
            this.tbDieuDo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDieuDo
            // 
            this.tbDieuDo.Location = new System.Drawing.Point(305, 221);
            this.tbDieuDo.Name = "tbDieuDo";
            this.tbDieuDo.SelectedTabPage = this.tabKHTT;
            this.tbDieuDo.Size = new System.Drawing.Size(262, 100);
            this.tbDieuDo.TabIndex = 27;
            this.tbDieuDo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabKHTT,
            this.tabGSTT});
            // 
            // tabKHTT
            // 
            this.tabKHTT.Name = "tabKHTT";
            this.tabKHTT.Size = new System.Drawing.Size(255, 72);
            this.tabKHTT.Text = "tabKHTT";
            // 
            // tabGSTT
            // 
            this.tabGSTT.Name = "tabGSTT";
            this.tabGSTT.Size = new System.Drawing.Size(911, 691);
            this.tabGSTT.Text = "tabGSTT";
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 719);
            this.Controls.Add(this.tbDieuDo);
            this.Controls.Add(this.button1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbDieuDo)).EndInit();
            this.tbDieuDo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DevExpress.XtraTab.XtraTabControl tbDieuDo;
        private DevExpress.XtraTab.XtraTabPage tabKHTT;
        private DevExpress.XtraTab.XtraTabPage tabGSTT;
    }
}