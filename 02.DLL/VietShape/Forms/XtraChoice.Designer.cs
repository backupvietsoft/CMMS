namespace VietShape
{
    partial class XtraChoice
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
            this.simpleButton_Add = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControl_Source = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_Source)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_Add
            // 
            this.simpleButton_Add.Location = new System.Drawing.Point(200, 342);
            this.simpleButton_Add.Name = "simpleButton_Add";
            this.simpleButton_Add.Size = new System.Drawing.Size(95, 23);
            this.simpleButton_Add.TabIndex = 1;
            this.simpleButton_Add.Text = "&Thêm mới";
            this.simpleButton_Add.Click += new System.EventHandler(this.simpleButton_Add_Click);
            // 
            // simpleButton_Exit
            // 
            this.simpleButton_Exit.Location = new System.Drawing.Point(312, 342);
            this.simpleButton_Exit.Name = "simpleButton_Exit";
            this.simpleButton_Exit.Size = new System.Drawing.Size(95, 23);
            this.simpleButton_Exit.TabIndex = 2;
            this.simpleButton_Exit.Text = "Th&oát";
            this.simpleButton_Exit.Click += new System.EventHandler(this.simpleButton_Exit_Click);
            // 
            // listBoxControl_Source
            // 
            this.listBoxControl_Source.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxControl_Source.Appearance.Options.UseFont = true;
            this.listBoxControl_Source.Location = new System.Drawing.Point(26, 21);
            this.listBoxControl_Source.Name = "listBoxControl_Source";
            this.listBoxControl_Source.Size = new System.Drawing.Size(381, 299);
            this.listBoxControl_Source.TabIndex = 3;
            // 
            // XtraChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 387);
            this.Controls.Add(this.listBoxControl_Source);
            this.Controls.Add(this.simpleButton_Exit);
            this.Controls.Add(this.simpleButton_Add);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 426);
            this.MinimumSize = new System.Drawing.Size(450, 425);
            this.Name = "XtraChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choice";
            this.Load += new System.EventHandler(this.XtraChoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_Source)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_Add;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Exit;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl_Source;
    }
}