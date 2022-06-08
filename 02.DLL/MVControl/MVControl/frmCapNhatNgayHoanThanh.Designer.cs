using DevExpress.XtraEditors;
using System;

namespace MVControl
{
    partial class frmCapNhatNgayHoanThanh
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
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.cboDateTime = new DevExpress.XtraEditors.LookUpEdit();
            this.dpDateTime = new DevExpress.XtraEditors.DateEdit();
            this.RadioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.RadioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.lblNgayCNBDKH = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroup2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThucHien
            // 
            this.btnThucHien.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnThucHien.Location = new System.Drawing.Point(296, 102);
            this.btnThucHien.LookAndFeel.SkinName = "Blue";
            this.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(110, 32);
            this.btnThucHien.TabIndex = 0;
            this.btnThucHien.Text = "btnThucHien";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(408, 102);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 32);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "btnHuy";
            this.btnThoat.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDateTime.Location = new System.Drawing.Point(36, 45);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(56, 19);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "lblDateTime";
            // 
            // cboDateTime
            // 
            this.cboDateTime.Location = new System.Drawing.Point(118, 45);
            this.cboDateTime.Name = "cboDateTime";
            this.cboDateTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDateTime.Properties.NullText = "";
            this.cboDateTime.Size = new System.Drawing.Size(400, 20);
            this.cboDateTime.TabIndex = 0;
            // 
            // dpDateTime
            // 
            this.dpDateTime.EditValue = new System.DateTime(2017, 3, 20, 14, 37, 28, 377);
            this.dpDateTime.Location = new System.Drawing.Point(118, 45);
            this.dpDateTime.Name = "dpDateTime";
            this.dpDateTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDateTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dpDateTime.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dpDateTime.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dpDateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dpDateTime.Size = new System.Drawing.Size(400, 20);
            this.dpDateTime.TabIndex = 0;
            // 
            // RadioGroup1
            // 
            this.RadioGroup1.Location = new System.Drawing.Point(36, 73);
            this.RadioGroup1.Name = "RadioGroup1";
            this.RadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RadioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.RadioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("UpdateCurrent", "UpdateCurrent"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("UpdateNgayTrong", "UpdateNgayTrong"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("UpdateAll", "UpdateAll")});
            this.RadioGroup1.Size = new System.Drawing.Size(482, 23);
            this.RadioGroup1.TabIndex = 17;
            // 
            // RadioGroup2
            // 
            this.RadioGroup2.Location = new System.Drawing.Point(36, 16);
            this.RadioGroup2.Name = "RadioGroup2";
            this.RadioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RadioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.RadioGroup2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RadioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("NgayThucTe", "NgayThucTe"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("NgayHienTai", "NgayHienTai")});
            this.RadioGroup2.Size = new System.Drawing.Size(329, 23);
            this.RadioGroup2.TabIndex = 17;
            this.RadioGroup2.SelectedIndexChanged += new System.EventHandler(this.RadioGroup2_SelectedIndexChanged);
            // 
            // lblNgayCNBDKH
            // 
            this.lblNgayCNBDKH.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNgayCNBDKH.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNgayCNBDKH.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNgayCNBDKH.Location = new System.Drawing.Point(352, 18);
            this.lblNgayCNBDKH.Name = "lblNgayCNBDKH";
            this.lblNgayCNBDKH.Size = new System.Drawing.Size(166, 21);
            this.lblNgayCNBDKH.TabIndex = 18;
            this.lblNgayCNBDKH.Text = "lblNgayCNBDKH";
            this.lblNgayCNBDKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNgayCNBDKH.UseVisualStyleBackColor = true;
            // 
            // frmCapNhatNgayHoanThanh
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 146);
            this.Controls.Add(this.lblNgayCNBDKH);
            this.Controls.Add(this.RadioGroup2);
            this.Controls.Add(this.RadioGroup1);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.dpDateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCapNhatNgayHoanThanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCapNhatNgayHoangThanh";
            this.Load += new System.EventHandler(this.frmCapNhatNgayHoanThanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroup2.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        private SimpleButton btnThucHien;
        private SimpleButton btnThoat;
        private LabelControl lblDateTime;
        private LookUpEdit cboDateTime;
        private DateEdit dpDateTime;
        private RadioGroup RadioGroup1;
        private RadioGroup RadioGroup2;

        #endregion

        internal System.Windows.Forms.CheckBox lblNgayCNBDKH;
    }
}