<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptVAT_TU_XUAT_KHO
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptVAT_TU_XUAT_KHO))
        Me.grvDangxuat = New System.Windows.Forms.DataGridView
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.grbDangxuat = New System.Windows.Forms.GroupBox
        Me.mtxtdenNgay = New System.Windows.Forms.DateTimePicker
        Me.mtxtuNgay = New System.Windows.Forms.DateTimePicker
        Me.cboKho = New System.Windows.Forms.ComboBox
        Me.lbaKho = New System.Windows.Forms.Label
        Me.lbadenNgay = New System.Windows.Forms.Label
        Me.lbatuNgay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grvDangxuat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDangxuat.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grvDangxuat
        '
        Me.grvDangxuat.AllowUserToAddRows = False
        Me.grvDangxuat.AllowUserToDeleteRows = False
        Me.grvDangxuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grvDangxuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvDangxuat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON})
        Me.grvDangxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvDangxuat.Location = New System.Drawing.Point(3, 16)
        Me.grvDangxuat.Name = "grvDangxuat"
        Me.grvDangxuat.RowHeadersWidth = 21
        Me.grvDangxuat.Size = New System.Drawing.Size(396, 246)
        Me.grvDangxuat.TabIndex = 15
        '
        'CHON
        '
        Me.CHON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.Name = "CHON"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 110
        '
        'grbDangxuat
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbDangxuat, 6)
        Me.grbDangxuat.Controls.Add(Me.grvDangxuat)
        Me.grbDangxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDangxuat.Location = New System.Drawing.Point(3, 73)
        Me.grbDangxuat.Name = "grbDangxuat"
        Me.grbDangxuat.Size = New System.Drawing.Size(402, 265)
        Me.grbDangxuat.TabIndex = 23
        Me.grbDangxuat.TabStop = False
        Me.grbDangxuat.Text = "Dạng xuất"
        '
        'mtxtdenNgay
        '
        Me.mtxtdenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtdenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mtxtdenNgay.Location = New System.Drawing.Point(253, 23)
        Me.mtxtdenNgay.Name = "mtxtdenNgay"
        Me.mtxtdenNgay.Size = New System.Drawing.Size(87, 20)
        Me.mtxtdenNgay.TabIndex = 22
        '
        'mtxtuNgay
        '
        Me.mtxtuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mtxtuNgay.Location = New System.Drawing.Point(112, 23)
        Me.mtxtuNgay.Name = "mtxtuNgay"
        Me.mtxtuNgay.Size = New System.Drawing.Size(87, 20)
        Me.mtxtuNgay.TabIndex = 21
        '
        'cboKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.Location = New System.Drawing.Point(112, 48)
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Size = New System.Drawing.Size(228, 21)
        Me.cboKho.TabIndex = 20
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKho.Location = New System.Drawing.Point(64, 45)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(42, 25)
        Me.lbaKho.TabIndex = 18
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbadenNgay
        '
        Me.lbadenNgay.AutoSize = True
        Me.lbadenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbadenNgay.Location = New System.Drawing.Point(205, 20)
        Me.lbadenNgay.Name = "lbadenNgay"
        Me.lbadenNgay.Size = New System.Drawing.Size(42, 25)
        Me.lbadenNgay.TabIndex = 19
        Me.lbadenNgay.Text = "Đến ngày"
        Me.lbadenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbatuNgay
        '
        Me.lbatuNgay.AutoSize = True
        Me.lbatuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbatuNgay.Location = New System.Drawing.Point(64, 20)
        Me.lbatuNgay.Name = "lbatuNgay"
        Me.lbatuNgay.Size = New System.Drawing.Size(42, 25)
        Me.lbatuNgay.TabIndex = 17
        Me.lbatuNgay.Text = "Từ ngày"
        Me.lbatuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grbDangxuat, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbatuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtdenNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbadenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(408, 383)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 344)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(402, 36)
        Me.TableLayoutPanel2.TabIndex = 25
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(295, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(185, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 24
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Dạng xuất"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 109
        '
        'frmrptVAT_TU_XUAT_KHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptVAT_TU_XUAT_KHO"
        Me.Size = New System.Drawing.Size(408, 383)
        CType(Me.grvDangxuat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDangxuat.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grvDangxuat As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents grbDangxuat As System.Windows.Forms.GroupBox
    Friend WithEvents mtxtdenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents mtxtuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboKho As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents lbadenNgay As System.Windows.Forms.Label
    Friend WithEvents lbatuNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
