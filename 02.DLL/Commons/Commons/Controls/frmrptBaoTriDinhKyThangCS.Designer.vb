<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBaoTriDinhKyThangCS
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.components = New System.ComponentModel.Container()
        Me.lbaChonThang = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gvHethong = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBochon = New DevExpress.XtraEditors.SimpleButton()
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.cbxNhaXuong = New Commons.UtcComboBox()
        Me.lbaTrangThai = New System.Windows.Forms.Label()
        Me.cbxTrangThai = New System.Windows.Forms.ComboBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gvHethong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaChonThang
        '
        Me.lbaChonThang.AutoSize = True
        Me.lbaChonThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaChonThang.Location = New System.Drawing.Point(43, 8)
        Me.lbaChonThang.Name = "lbaChonThang"
        Me.lbaChonThang.Size = New System.Drawing.Size(104, 25)
        Me.lbaChonThang.TabIndex = 0
        Me.lbaChonThang.Text = "Tháng"
        Me.lbaChonThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(153, 11)
        Me.mtxtTuNgay.Mask = "00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(130, 21)
        Me.mtxtTuNgay.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846!))
        Me.TableLayoutPanel1.Controls.Add(Me.gvHethong, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaChonThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTrangThai, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxTrangThai, 4, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(574, 425)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'gvHethong
        '
        Me.gvHethong.AllowUserToAddRows = False
        Me.gvHethong.AllowUserToDeleteRows = False
        Me.gvHethong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvHethong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.gvHethong, 6)
        Me.gvHethong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvHethong.Location = New System.Drawing.Point(3, 65)
        Me.gvHethong.Name = "gvHethong"
        Me.gvHethong.Size = New System.Drawing.Size(568, 315)
        Me.gvHethong.TabIndex = 22
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAll, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBochon, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 386)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(568, 36)
        Me.TableLayoutPanel2.TabIndex = 30
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(351, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 21
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(461, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 22
        Me.btnThoat.Text = "Thoát"
        '
        'btnAll
        '
        Me.btnAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAll.Location = New System.Drawing.Point(3, 3)
        Me.btnAll.LookAndFeel.SkinName = "Blue"
        Me.btnAll.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(104, 30)
        Me.btnAll.TabIndex = 23
        Me.btnAll.Text = "Chọn All"
        '
        'btnBochon
        '
        Me.btnBochon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBochon.Location = New System.Drawing.Point(113, 3)
        Me.btnBochon.LookAndFeel.SkinName = "Blue"
        Me.btnBochon.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(104, 30)
        Me.btnBochon.TabIndex = 23
        Me.btnBochon.Text = "Bỏ chọn"
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(43, 33)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(104, 25)
        Me.lbaNhaXuong.TabIndex = 17
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.AssemblyName = ""
        Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNhaXuong.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNhaXuong.ClassName = ""
        Me.cbxNhaXuong.Display = ""
        Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaXuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhaXuong.FormattingEnabled = True
        Me.cbxNhaXuong.IsAll = False
        Me.cbxNhaXuong.isInputNull = False
        Me.cbxNhaXuong.IsNew = False
        Me.cbxNhaXuong.IsNull = True
        Me.cbxNhaXuong.ItemAll = " < ALL > "
        Me.cbxNhaXuong.ItemNew = "...New"
        Me.cbxNhaXuong.Location = New System.Drawing.Point(153, 36)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(130, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 20
        Me.cbxNhaXuong.Table = Nothing
        Me.cbxNhaXuong.TextReadonly = False
        Me.cbxNhaXuong.Value = ""
        '
        'lbaTrangThai
        '
        Me.lbaTrangThai.AutoSize = True
        Me.lbaTrangThai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTrangThai.Location = New System.Drawing.Point(289, 33)
        Me.lbaTrangThai.Name = "lbaTrangThai"
        Me.lbaTrangThai.Size = New System.Drawing.Size(104, 25)
        Me.lbaTrangThai.TabIndex = 15
        Me.lbaTrangThai.Text = "Trạng thái"
        Me.lbaTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxTrangThai
        '
        Me.cbxTrangThai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTrangThai.FormattingEnabled = True
        Me.cbxTrangThai.Items.AddRange(New Object() {"Bình thường", "An toàn", "All"})
        Me.cbxTrangThai.Location = New System.Drawing.Point(399, 36)
        Me.cbxTrangThai.Name = "cbxTrangThai"
        Me.cbxTrangThai.Size = New System.Drawing.Size(130, 21)
        Me.cbxTrangThai.TabIndex = 16
        '
        'frmrptBaoTriDinhKyThangCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBaoTriDinhKyThangCS"
        Me.Size = New System.Drawing.Size(574, 425)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gvHethong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaChonThang As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents cbxTrangThai As System.Windows.Forms.ComboBox
    Friend WithEvents lbaTrangThai As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gvHethong As System.Windows.Forms.DataGridView
    Friend WithEvents btnAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBochon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
