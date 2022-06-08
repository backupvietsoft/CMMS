<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonThoiGianNgungMay
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.lbaDiaDiem = New System.Windows.Forms.Label
        Me.lbaDaychuyen = New System.Windows.Forms.Label
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.cboNhaxuong = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboHeThong = New Commons.UtcComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDiaDiem, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDaychuyen, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboHeThong, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(358, 141)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 8)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(86, 30)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Tu ngay"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(182, 8)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(79, 30)
        Me.lbaDenNgay.TabIndex = 1
        Me.lbaDenNgay.Text = "Den Ngay"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDiaDiem
        '
        Me.lbaDiaDiem.AutoSize = True
        Me.lbaDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDiaDiem.Location = New System.Drawing.Point(3, 38)
        Me.lbaDiaDiem.Name = "lbaDiaDiem"
        Me.lbaDiaDiem.Size = New System.Drawing.Size(86, 39)
        Me.lbaDiaDiem.TabIndex = 2
        Me.lbaDiaDiem.Text = "Nha xuong"
        Me.lbaDiaDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDaychuyen
        '
        Me.lbaDaychuyen.AutoSize = True
        Me.lbaDaychuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDaychuyen.Location = New System.Drawing.Point(3, 77)
        Me.lbaDaychuyen.Name = "lbaDaychuyen"
        Me.lbaDaychuyen.Size = New System.Drawing.Size(86, 27)
        Me.lbaDaychuyen.TabIndex = 3
        Me.lbaDaychuyen.Text = "Day chuyen"
        Me.lbaDaychuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Location = New System.Drawing.Point(95, 11)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(81, 21)
        Me.mtxtTuNgay.TabIndex = 4
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Location = New System.Drawing.Point(267, 11)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(84, 21)
        Me.mtxtDenNgay.TabIndex = 5
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.AssemblyName = ""
        Me.cboNhaxuong.BackColor = System.Drawing.Color.White
        Me.cboNhaxuong.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaxuong, 3)
        Me.cboNhaxuong.Display = ""
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.IsAll = False
        Me.cboNhaxuong.IsNew = False
        Me.cboNhaxuong.ItemAll = " < ALL > "
        Me.cboNhaxuong.ItemNew = "...New"
        Me.cboNhaxuong.Location = New System.Drawing.Point(95, 41)
        Me.cboNhaxuong.MethodName = ""
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Param = ""
        Me.cboNhaxuong.Size = New System.Drawing.Size(260, 21)
        Me.cboNhaxuong.StoreName = ""
        Me.cboNhaxuong.TabIndex = 6
        Me.cboNhaxuong.Table = Nothing
        Me.cboNhaxuong.TextReadonly = False
        Me.cboNhaxuong.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboHeThong
        '
        Me.cboHeThong.AssemblyName = ""
        Me.cboHeThong.BackColor = System.Drawing.Color.White
        Me.cboHeThong.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboHeThong, 3)
        Me.cboHeThong.Display = ""
        Me.cboHeThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboHeThong.ErrorProviderControl = Me.ErrorProvider1
        Me.cboHeThong.FormattingEnabled = True
        Me.cboHeThong.IsAll = True
        Me.cboHeThong.IsNew = False
        Me.cboHeThong.ItemAll = " < ALL > "
        Me.cboHeThong.ItemNew = "...New"
        Me.cboHeThong.Location = New System.Drawing.Point(95, 80)
        Me.cboHeThong.MethodName = ""
        Me.cboHeThong.Name = "cboHeThong"
        Me.cboHeThong.Param = ""
        Me.cboHeThong.Size = New System.Drawing.Size(260, 21)
        Me.cboHeThong.StoreName = ""
        Me.cboHeThong.TabIndex = 7
        Me.cboHeThong.Table = Nothing
        Me.cboHeThong.TextReadonly = False
        Me.cboHeThong.Value = ""
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 31)
        Me.Panel1.TabIndex = 8
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnThucHien.Location = New System.Drawing.Point(181, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(86, 31)
        Me.btnThucHien.TabIndex = 1
        Me.btnThucHien.Text = "Thuc hien"
        
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(267, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(85, 31)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoat"
        
        '
        'FrmChonThoiGianNgungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(358, 141)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChonThoiGianNgungMay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmChonThoiGianNgungMay"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDiaDiem As System.Windows.Forms.Label
    Friend WithEvents lbaDaychuyen As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboNhaxuong As Commons.UtcComboBox
    Friend WithEvents cboHeThong As Commons.UtcComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
