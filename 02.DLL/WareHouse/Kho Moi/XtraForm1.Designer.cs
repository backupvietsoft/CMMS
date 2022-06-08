namespace WareHouse.Forms
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
            this.cboLVT = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cboDDiem = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLVT
            // 
            this.cboLVT.Location = new System.Drawing.Point(0, 179);
            this.cboLVT.Name = "cboLVT";
            this.cboLVT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLVT.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLVT.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLVT.Size = new System.Drawing.Size(66, 20);
            this.cboLVT.TabIndex = 4;
            // 
            // cboDDiem
            // 
            this.cboDDiem.Location = new System.Drawing.Point(51, 107);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDDiem.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDDiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDDiem.Size = new System.Drawing.Size(104, 20);
            this.cboDDiem.TabIndex = 5;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 378);
            this.Controls.Add(this.cboDDiem);
            this.Controls.Add(this.cboLVT);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedComboBoxEdit cboLVT;
        private DevExpress.XtraEditors.LookUpEdit cboDDiem;
    }
}