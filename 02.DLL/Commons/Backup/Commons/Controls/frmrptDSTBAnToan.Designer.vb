Namespace ReportManager

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmrptDSTBAnToan
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDSTBAnToan))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.rdbDayChuyen = New System.Windows.Forms.RadioButton
            Me.rdoLoaiMay = New System.Windows.Forms.RadioButton
            Me.cbxLoaiTB = New System.Windows.Forms.ComboBox
            Me.lbaNhaXuong = New System.Windows.Forms.Label
            Me.lbaLoaiTB = New System.Windows.Forms.Label
            Me.lbaHienTrang = New System.Windows.Forms.Label
            Me.btnThucHien = New System.Windows.Forms.Button
            Me.btnThoat = New System.Windows.Forms.Button
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
            Me.cbxHienTrang = New Commons.UtcComboBox
            Me.cbxNhaXuong = New Commons.UtcComboBox
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'rdbDayChuyen
            '
            Me.rdbDayChuyen.AutoSize = True
            Me.rdbDayChuyen.Dock = System.Windows.Forms.DockStyle.Left
            Me.rdbDayChuyen.Location = New System.Drawing.Point(228, 3)
            Me.rdbDayChuyen.Name = "rdbDayChuyen"
            Me.rdbDayChuyen.Size = New System.Drawing.Size(108, 20)
            Me.rdbDayChuyen.TabIndex = 0
            Me.rdbDayChuyen.TabStop = True
            Me.rdbDayChuyen.Text = "Theo dây chuyền"
            Me.rdbDayChuyen.UseVisualStyleBackColor = True
            '
            'rdoLoaiMay
            '
            Me.rdoLoaiMay.AutoSize = True
            Me.rdoLoaiMay.Dock = System.Windows.Forms.DockStyle.Left
            Me.rdoLoaiMay.Location = New System.Drawing.Point(3, 3)
            Me.rdoLoaiMay.Name = "rdoLoaiMay"
            Me.rdoLoaiMay.Size = New System.Drawing.Size(91, 20)
            Me.rdoLoaiMay.TabIndex = 1
            Me.rdoLoaiMay.TabStop = True
            Me.rdoLoaiMay.Text = "Theo loại máy"
            Me.rdoLoaiMay.UseVisualStyleBackColor = True
            '
            'cbxLoaiTB
            '
            Me.cbxLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbxLoaiTB.FormattingEnabled = True
            Me.cbxLoaiTB.Items.AddRange(New Object() {"Bình thường", "An toàn", "All"})
            Me.cbxLoaiTB.Location = New System.Drawing.Point(490, 3)
            Me.cbxLoaiTB.Name = "cbxLoaiTB"
            Me.cbxLoaiTB.Size = New System.Drawing.Size(175, 21)
            Me.cbxLoaiTB.TabIndex = 8
            '
            'lbaNhaXuong
            '
            Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lbaNhaXuong.Location = New System.Drawing.Point(121, 0)
            Me.lbaNhaXuong.Name = "lbaNhaXuong"
            Me.lbaNhaXuong.Size = New System.Drawing.Size(88, 25)
            Me.lbaNhaXuong.TabIndex = 1
            Me.lbaNhaXuong.Text = "Nhà xưởng"
            Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbaLoaiTB
            '
            Me.lbaLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lbaLoaiTB.Location = New System.Drawing.Point(396, 0)
            Me.lbaLoaiTB.Name = "lbaLoaiTB"
            Me.lbaLoaiTB.Size = New System.Drawing.Size(88, 25)
            Me.lbaLoaiTB.TabIndex = 0
            Me.lbaLoaiTB.Text = "Loại Thiết bị:"
            Me.lbaLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbaHienTrang
            '
            Me.lbaHienTrang.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lbaHienTrang.Location = New System.Drawing.Point(121, 25)
            Me.lbaHienTrang.Name = "lbaHienTrang"
            Me.lbaHienTrang.Size = New System.Drawing.Size(88, 25)
            Me.lbaHienTrang.TabIndex = 6
            Me.lbaHienTrang.Text = "Hiện trạng"
            Me.lbaHienTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnThucHien
            '
            Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
            Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnThucHien.Location = New System.Drawing.Point(565, 3)
            Me.btnThucHien.Name = "btnThucHien"
            Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
            Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
            Me.btnThucHien.TabIndex = 1
            Me.btnThucHien.Text = "Thực hiện"
            Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnThucHien.UseVisualStyleBackColor = True
            '
            'btnThoat
            '
            Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
            Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnThoat.Location = New System.Drawing.Point(675, 3)
            Me.btnThoat.Name = "btnThoat"
            Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
            Me.btnThoat.Size = New System.Drawing.Size(104, 30)
            Me.btnThoat.TabIndex = 32
            Me.btnThoat.Text = "Thoát"
            Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnThoat.UseVisualStyleBackColor = True
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
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiTB, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiTB, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lbaHienTrang, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cbxHienTrang, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 2, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(788, 435)
            Me.TableLayoutPanel1.TabIndex = 1
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
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 396)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 1
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(782, 36)
            Me.TableLayoutPanel2.TabIndex = 33
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 2
            Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 3)
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.rdoLoaiMay, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.rdbDayChuyen, 1, 0)
            Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(215, 53)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 1
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(450, 26)
            Me.TableLayoutPanel3.TabIndex = 34
            '
            'cbxHienTrang
            '
            Me.cbxHienTrang.AssemblyName = ""
            Me.cbxHienTrang.BackColor = System.Drawing.Color.White
            Me.cbxHienTrang.ClassName = ""
            Me.TableLayoutPanel1.SetColumnSpan(Me.cbxHienTrang, 3)
            Me.cbxHienTrang.Display = ""
            Me.cbxHienTrang.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbxHienTrang.ErrorProviderControl = Me.ErrorProvider1
            Me.cbxHienTrang.FormattingEnabled = True
            Me.cbxHienTrang.IsAll = True
            Me.cbxHienTrang.isInputNull = False
            Me.cbxHienTrang.IsNew = False
            Me.cbxHienTrang.IsNull = True
            Me.cbxHienTrang.ItemAll = " < ALL > "
            Me.cbxHienTrang.ItemNew = "...New"
            Me.cbxHienTrang.Location = New System.Drawing.Point(215, 28)
            Me.cbxHienTrang.MethodName = ""
            Me.cbxHienTrang.Name = "cbxHienTrang"
            Me.cbxHienTrang.Param = ""
            Me.cbxHienTrang.Param2 = ""
            Me.cbxHienTrang.Size = New System.Drawing.Size(450, 21)
            Me.cbxHienTrang.StoreName = ""
            Me.cbxHienTrang.TabIndex = 5
            Me.cbxHienTrang.Table = Nothing
            Me.cbxHienTrang.TextReadonly = False
            Me.cbxHienTrang.Value = ""
            '
            'cbxNhaXuong
            '
            Me.cbxNhaXuong.AssemblyName = ""
            Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
            Me.cbxNhaXuong.ClassName = ""
            Me.cbxNhaXuong.Display = ""
            Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbxNhaXuong.ErrorProviderControl = Me.ErrorProvider1
            Me.cbxNhaXuong.FormattingEnabled = True
            Me.cbxNhaXuong.IsAll = True
            Me.cbxNhaXuong.isInputNull = False
            Me.cbxNhaXuong.IsNew = False
            Me.cbxNhaXuong.IsNull = True
            Me.cbxNhaXuong.ItemAll = " < ALL > "
            Me.cbxNhaXuong.ItemNew = "...New"
            Me.cbxNhaXuong.Location = New System.Drawing.Point(215, 3)
            Me.cbxNhaXuong.MethodName = ""
            Me.cbxNhaXuong.Name = "cbxNhaXuong"
            Me.cbxNhaXuong.Param = ""
            Me.cbxNhaXuong.Param2 = ""
            Me.cbxNhaXuong.Size = New System.Drawing.Size(175, 21)
            Me.cbxNhaXuong.StoreName = ""
            Me.cbxNhaXuong.TabIndex = 7
            Me.cbxNhaXuong.Table = Nothing
            Me.cbxNhaXuong.TextReadonly = False
            Me.cbxNhaXuong.Value = ""
            '
            'frmrptDSTBAnToan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "frmrptDSTBAnToan"
            Me.Size = New System.Drawing.Size(788, 435)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnThoat As System.Windows.Forms.Button
        Friend WithEvents btnThucHien As System.Windows.Forms.Button
        Friend WithEvents rdoLoaiMay As System.Windows.Forms.RadioButton
        Friend WithEvents rdbDayChuyen As System.Windows.Forms.RadioButton
        Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
        Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
        Friend WithEvents lbaLoaiTB As System.Windows.Forms.Label
        Friend WithEvents cbxLoaiTB As System.Windows.Forms.ComboBox
        Friend WithEvents lbaHienTrang As System.Windows.Forms.Label
        Friend WithEvents cbxHienTrang As Commons.UtcComboBox
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel

    End Class

End Namespace