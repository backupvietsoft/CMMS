using DevExpress.XtraEditors;
using System;

namespace MVControl
{
    partial class Form1
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
            this.cboDateTime = new DevExpress.XtraEditors.LookUpEdit();
            this.ucComboboxTreeList1 = new MVControl.ucComboboxTreeList();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDateTime
            // 
            this.cboDateTime.Location = new System.Drawing.Point(122, 22);
            this.cboDateTime.Name = "cboDateTime";
            this.cboDateTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDateTime.Properties.NullText = "";
            this.cboDateTime.Size = new System.Drawing.Size(288, 20);
            this.cboDateTime.TabIndex = 0;
            // 
            // ucComboboxTreeList1
            // 
            this.ucComboboxTreeList1.ColumnDisplayName = null;
            this.ucComboboxTreeList1.DataSource = null;
            this.ucComboboxTreeList1.EditValue = null;
            this.ucComboboxTreeList1.KeyFieldName = null;
            this.ucComboboxTreeList1.Location = new System.Drawing.Point(146, 107);
            this.ucComboboxTreeList1.LookAndFeel.SkinName = "Blue";
            this.ucComboboxTreeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucComboboxTreeList1.MaximumSize = new System.Drawing.Size(1000, 20);
            this.ucComboboxTreeList1.MinimumSize = new System.Drawing.Size(10, 20);
            this.ucComboboxTreeList1.Name = "ucComboboxTreeList1";
            this.ucComboboxTreeList1.ParentFieldName = null;
            this.ucComboboxTreeList1.ReadOnly = false;
            this.ucComboboxTreeList1.SelectedIndex = 0;
            this.ucComboboxTreeList1.Size = new System.Drawing.Size(320, 20);
            this.ucComboboxTreeList1.TabIndex = 0;
            this.ucComboboxTreeList1.TextValue = null;
            // 
            // Form1
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 616);
            this.Controls.Add(this.ucComboboxTreeList1);
            this.Name = "Form1";
            this.Text = "frmCapNhatNgayHoangThanh";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDateTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        private LookUpEdit cboDateTime;

        #endregion

        private ucComboboxTreeList ucComboboxTreeList1;
    }
}