<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptThoiGianChayMayCuoiTuan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptThoiGianChayMayCuoiTuan))
        Me.dtpDenNgayCuoiTuan = New System.Windows.Forms.DateTimePicker
        Me.lblDenngayCuoiTuan = New System.Windows.Forms.Label
        Me.lblLoaithietbi2 = New System.Windows.Forms.Label
        Me.lblTungayCuoiTuan = New System.Windows.Forms.Label
        Me.dtpTuNgayCuoiTuan = New System.Windows.Forms.DateTimePicker
        Me.lblNhomthietbi = New System.Windows.Forms.Label
        Me.btnTheoLoaiMay = New System.Windows.Forms.Button
        Me.btnTheoDayChuyen = New System.Windows.Forms.Button
        Me.cboLoaithietbi2 = New System.Windows.Forms.ComboBox
        Me.cboDayChuyenCuoiTuan = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TableLayoutPanel13.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDenNgayCuoiTuan
        '
        Me.dtpDenNgayCuoiTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenNgayCuoiTuan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNgayCuoiTuan.Location = New System.Drawing.Point(268, 3)
        Me.dtpDenNgayCuoiTuan.Name = "dtpDenNgayCuoiTuan"
        Me.dtpDenNgayCuoiTuan.Size = New System.Drawing.Size(93, 20)
        Me.dtpDenNgayCuoiTuan.TabIndex = 6
        '
        'lblDenngayCuoiTuan
        '
        Me.lblDenngayCuoiTuan.AutoSize = True
        Me.lblDenngayCuoiTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngayCuoiTuan.ForeColor = System.Drawing.Color.Black
        Me.lblDenngayCuoiTuan.Location = New System.Drawing.Point(217, 0)
        Me.lblDenngayCuoiTuan.Name = "lblDenngayCuoiTuan"
        Me.lblDenngayCuoiTuan.Size = New System.Drawing.Size(45, 25)
        Me.lblDenngayCuoiTuan.TabIndex = 7
        Me.lblDenngayCuoiTuan.Text = "Đến ngày"
        Me.lblDenngayCuoiTuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaithietbi2
        '
        Me.lblLoaithietbi2.AutoSize = True
        Me.lblLoaithietbi2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaithietbi2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoaithietbi2.Location = New System.Drawing.Point(67, 25)
        Me.lblLoaithietbi2.Name = "lblLoaithietbi2"
        Me.lblLoaithietbi2.Size = New System.Drawing.Size(45, 25)
        Me.lblLoaithietbi2.TabIndex = 2
        Me.lblLoaithietbi2.Text = "Loại thiết bị"
        Me.lblLoaithietbi2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTungayCuoiTuan
        '
        Me.lblTungayCuoiTuan.AutoSize = True
        Me.lblTungayCuoiTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungayCuoiTuan.ForeColor = System.Drawing.Color.Black
        Me.lblTungayCuoiTuan.Location = New System.Drawing.Point(67, 0)
        Me.lblTungayCuoiTuan.Name = "lblTungayCuoiTuan"
        Me.lblTungayCuoiTuan.Size = New System.Drawing.Size(45, 25)
        Me.lblTungayCuoiTuan.TabIndex = 7
        Me.lblTungayCuoiTuan.Text = "Từ ngày"
        Me.lblTungayCuoiTuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTuNgayCuoiTuan
        '
        Me.dtpTuNgayCuoiTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTuNgayCuoiTuan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgayCuoiTuan.Location = New System.Drawing.Point(118, 3)
        Me.dtpTuNgayCuoiTuan.Name = "dtpTuNgayCuoiTuan"
        Me.dtpTuNgayCuoiTuan.Size = New System.Drawing.Size(93, 20)
        Me.dtpTuNgayCuoiTuan.TabIndex = 6
        '
        'lblNhomthietbi
        '
        Me.lblNhomthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhomthietbi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNhomthietbi.Location = New System.Drawing.Point(217, 25)
        Me.lblNhomthietbi.Name = "lblNhomthietbi"
        Me.lblNhomthietbi.Size = New System.Drawing.Size(45, 25)
        Me.lblNhomthietbi.TabIndex = 3
        Me.lblNhomthietbi.Text = "Nhóm thiết bị"
        Me.lblNhomthietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTheoLoaiMay
        '
        Me.btnTheoLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTheoLoaiMay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTheoLoaiMay.ForeColor = System.Drawing.Color.Black
        Me.btnTheoLoaiMay.Location = New System.Drawing.Point(158, 3)
        Me.btnTheoLoaiMay.Name = "btnTheoLoaiMay"
        Me.btnTheoLoaiMay.Size = New System.Drawing.Size(84, 30)
        Me.btnTheoLoaiMay.TabIndex = 8
        Me.btnTheoLoaiMay.Text = "In theo loại máy"
        Me.btnTheoLoaiMay.UseVisualStyleBackColor = True
        '
        'btnTheoDayChuyen
        '
        Me.btnTheoDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTheoDayChuyen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTheoDayChuyen.ForeColor = System.Drawing.Color.Black
        Me.btnTheoDayChuyen.Location = New System.Drawing.Point(248, 3)
        Me.btnTheoDayChuyen.Name = "btnTheoDayChuyen"
        Me.btnTheoDayChuyen.Size = New System.Drawing.Size(84, 30)
        Me.btnTheoDayChuyen.TabIndex = 8
        Me.btnTheoDayChuyen.Text = "In theo dây chuyền"
        Me.btnTheoDayChuyen.UseVisualStyleBackColor = True
        '
        'cboLoaithietbi2
        '
        Me.cboLoaithietbi2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaithietbi2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaithietbi2.FormattingEnabled = True
        Me.cboLoaithietbi2.Location = New System.Drawing.Point(118, 28)
        Me.cboLoaithietbi2.Name = "cboLoaithietbi2"
        Me.cboLoaithietbi2.Size = New System.Drawing.Size(93, 21)
        Me.cboLoaithietbi2.TabIndex = 9
        '
        'cboDayChuyenCuoiTuan
        '
        Me.cboDayChuyenCuoiTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDayChuyenCuoiTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDayChuyenCuoiTuan.FormattingEnabled = True
        Me.cboDayChuyenCuoiTuan.Location = New System.Drawing.Point(268, 28)
        Me.cboDayChuyenCuoiTuan.Name = "cboDayChuyenCuoiTuan"
        Me.cboDayChuyenCuoiTuan.Size = New System.Drawing.Size(93, 21)
        Me.cboDayChuyenCuoiTuan.TabIndex = 10
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 6
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.TableLayoutPanel1, 0, 3)
        Me.TableLayoutPanel13.Controls.Add(Me.lblLoaithietbi2, 1, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.cboLoaithietbi2, 2, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.lblNhomthietbi, 3, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.cboDayChuyenCuoiTuan, 4, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.lblTungayCuoiTuan, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.lblDenngayCuoiTuan, 3, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.dtpTuNgayCuoiTuan, 2, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.dtpDenNgayCuoiTuan, 4, 0)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 4
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(431, 389)
        Me.TableLayoutPanel13.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel13.SetColumnSpan(Me.TableLayoutPanel1, 6)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnTheoLoaiMay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnTheoDayChuyen, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 350)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(425, 36)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(338, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptThoiGianChayMayCuoiTuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel13)
        Me.Name = "frmrptThoiGianChayMayCuoiTuan"
        Me.Size = New System.Drawing.Size(431, 389)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel13.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpDenNgayCuoiTuan As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngayCuoiTuan As System.Windows.Forms.Label
    Friend WithEvents lblLoaithietbi2 As System.Windows.Forms.Label
    Friend WithEvents lblTungayCuoiTuan As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgayCuoiTuan As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNhomthietbi As System.Windows.Forms.Label
    Friend WithEvents btnTheoLoaiMay As System.Windows.Forms.Button
    Friend WithEvents btnTheoDayChuyen As System.Windows.Forms.Button
    Friend WithEvents cboLoaithietbi2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDayChuyenCuoiTuan As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
