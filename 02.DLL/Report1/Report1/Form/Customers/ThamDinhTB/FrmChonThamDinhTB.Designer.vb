<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonThamDinhTB
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.lbaNhaXuong = New System.Windows.Forms.Label
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbxNhaXuong = New Commons.UtcComboBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Location = New System.Drawing.Point(24, 19)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(51, 13)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày:"
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Location = New System.Drawing.Point(180, 19)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(58, 13)
        Me.lbaDenNgay.TabIndex = 1
        Me.lbaDenNgay.Text = "Đến ngày:"
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Location = New System.Drawing.Point(15, 53)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(64, 13)
        Me.lbaNhaXuong.TabIndex = 2
        Me.lbaNhaXuong.Text = "Nhà xưởng:"
        '
        'btnThucHien
        '
        Me.btnThucHien.Location = New System.Drawing.Point(170, 79)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(75, 23)
        Me.btnThucHien.TabIndex = 4
        Me.btnThucHien.Text = "Thực hiện"
        
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(251, 79)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 5
        Me.btnThoat.Text = "Thoát"
        
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Location = New System.Drawing.Point(83, 11)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(79, 21)
        Me.mtxtTuNgay.TabIndex = 6
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Location = New System.Drawing.Point(243, 10)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(83, 21)
        Me.mtxtDenNgay.TabIndex = 7
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.AssemblyName = ""
        Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.ClassName = ""
        Me.cbxNhaXuong.Display = ""
        Me.cbxNhaXuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhaXuong.FormattingEnabled = True
        Me.cbxNhaXuong.IsAll = True
        Me.cbxNhaXuong.IsNew = False
        Me.cbxNhaXuong.ItemAll = " < ALL > "
        Me.cbxNhaXuong.ItemNew = "...New"
        Me.cbxNhaXuong.Location = New System.Drawing.Point(84, 45)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(242, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 8
        Me.cbxNhaXuong.Table = Nothing
        Me.cbxNhaXuong.TextReadonly = False
        Me.cbxNhaXuong.Value = ""
        '
        'FrmChonThamDinhTB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 109)
        Me.Controls.Add(Me.cbxNhaXuong)
        Me.Controls.Add(Me.mtxtDenNgay)
        Me.Controls.Add(Me.mtxtTuNgay)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.lbaNhaXuong)
        Me.Controls.Add(Me.lbaDenNgay)
        Me.Controls.Add(Me.lbaTuNgay)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmChonThamDinhTB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmChonThamDinhTB"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
