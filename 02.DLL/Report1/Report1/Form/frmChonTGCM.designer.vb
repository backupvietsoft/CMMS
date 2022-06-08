<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonTGCM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtNgaySGLK = New DevExpress.XtraEditors.TextEdit()
        Me.txtSGLuyKe = New DevExpress.XtraEditors.TextEdit()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNgayGio = New System.Windows.Forms.Label()
        Me.lblSoGio = New System.Windows.Forms.Label()
        Me.layoutForm = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblChiSoTruoc = New System.Windows.Forms.Label()
        Me.txtChiSoTruoc = New DevExpress.XtraEditors.TextEdit()
        CType(Me.dtNgaySGLK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSGLuyKe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutForm.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtChiSoTruoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtNgaySGLK
        '
        Me.dtNgaySGLK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgaySGLK.Location = New System.Drawing.Point(148, 18)
        Me.dtNgaySGLK.Name = "dtNgaySGLK"
        Me.dtNgaySGLK.Properties.EditFormat.FormatString = "d"
        Me.dtNgaySGLK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtNgaySGLK.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtNgaySGLK.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtNgaySGLK.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.dtNgaySGLK.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.dtNgaySGLK.Size = New System.Drawing.Size(207, 20)
        Me.dtNgaySGLK.TabIndex = 17
        '
        'txtSGLuyKe
        '
        Me.txtSGLuyKe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSGLuyKe.Location = New System.Drawing.Point(148, 68)
        Me.txtSGLuyKe.Name = "txtSGLuyKe"
        Me.txtSGLuyKe.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtSGLuyKe.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtSGLuyKe.Properties.Mask.EditMask = "n"
        Me.txtSGLuyKe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSGLuyKe.Size = New System.Drawing.Size(207, 20)
        Me.txtSGLuyKe.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(298, 2)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 13
        Me.btnThoat.Text = "T&hoát"
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThucHien.Appearance.Options.UseFont = True
        Me.BtnThucHien.Location = New System.Drawing.Point(193, 2)
        Me.BtnThucHien.LookAndFeel.SkinName = "Blue"
        Me.BtnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.BtnThucHien.TabIndex = 13
        Me.BtnThucHien.Text = "BtnThucHien"
        '
        'lblNgayGio
        '
        Me.lblNgayGio.AutoSize = True
        Me.lblNgayGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayGio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayGio.ForeColor = System.Drawing.Color.Black
        Me.lblNgayGio.Location = New System.Drawing.Point(47, 15)
        Me.lblNgayGio.Name = "lblNgayGio"
        Me.lblNgayGio.Size = New System.Drawing.Size(95, 25)
        Me.lblNgayGio.TabIndex = 19
        Me.lblNgayGio.Text = "lblNgayGio"
        Me.lblNgayGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSoGio
        '
        Me.lblSoGio.AutoSize = True
        Me.lblSoGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSoGio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoGio.ForeColor = System.Drawing.Color.Black
        Me.lblSoGio.Location = New System.Drawing.Point(47, 65)
        Me.lblSoGio.Name = "lblSoGio"
        Me.lblSoGio.Size = New System.Drawing.Size(95, 25)
        Me.lblSoGio.TabIndex = 19
        Me.lblSoGio.Text = "lblSoGio"
        Me.lblSoGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'layoutForm
        '
        Me.layoutForm.ColumnCount = 4
        Me.layoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.layoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.layoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.layoutForm.Controls.Add(Me.lblSoGio, 1, 3)
        Me.layoutForm.Controls.Add(Me.lblNgayGio, 1, 1)
        Me.layoutForm.Controls.Add(Me.Panel1, 0, 4)
        Me.layoutForm.Controls.Add(Me.lblChiSoTruoc, 1, 2)
        Me.layoutForm.Controls.Add(Me.txtChiSoTruoc, 2, 2)
        Me.layoutForm.Controls.Add(Me.txtSGLuyKe, 2, 3)
        Me.layoutForm.Controls.Add(Me.dtNgaySGLK, 2, 1)
        Me.layoutForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutForm.Location = New System.Drawing.Point(1, 1)
        Me.layoutForm.Name = "layoutForm"
        Me.layoutForm.RowCount = 5
        Me.layoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.layoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.layoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.layoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.layoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.layoutForm.Size = New System.Drawing.Size(410, 129)
        Me.layoutForm.TabIndex = 20
        '
        'Panel1
        '
        Me.layoutForm.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.BtnThucHien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 93)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 33)
        Me.Panel1.TabIndex = 20
        '
        'lblChiSoTruoc
        '
        Me.lblChiSoTruoc.AutoSize = True
        Me.lblChiSoTruoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiSoTruoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiSoTruoc.ForeColor = System.Drawing.Color.Black
        Me.lblChiSoTruoc.Location = New System.Drawing.Point(47, 40)
        Me.lblChiSoTruoc.Name = "lblChiSoTruoc"
        Me.lblChiSoTruoc.Size = New System.Drawing.Size(95, 25)
        Me.lblChiSoTruoc.TabIndex = 19
        Me.lblChiSoTruoc.Text = "lblChiSoTruoc"
        Me.lblChiSoTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiSoTruoc
        '
        Me.txtChiSoTruoc.Location = New System.Drawing.Point(148, 43)
        Me.txtChiSoTruoc.Name = "txtChiSoTruoc"
        Me.txtChiSoTruoc.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtChiSoTruoc.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtChiSoTruoc.Properties.ReadOnly = True
        Me.txtChiSoTruoc.Size = New System.Drawing.Size(207, 20)
        Me.txtChiSoTruoc.TabIndex = 18
        '
        'frmChonTGCM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(412, 131)
        Me.Controls.Add(Me.layoutForm)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonTGCM"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonTGCM"
        CType(Me.dtNgaySGLK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSGLuyKe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutForm.ResumeLayout(False)
        Me.layoutForm.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtChiSoTruoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtNgaySGLK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSGLuyKe As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNgayGio As System.Windows.Forms.Label
    Friend WithEvents lblSoGio As System.Windows.Forms.Label
    Friend WithEvents layoutForm As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblChiSoTruoc As Label
    Friend WithEvents txtChiSoTruoc As DevExpress.XtraEditors.TextEdit
End Class
