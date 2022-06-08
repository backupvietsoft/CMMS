<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonVTPTCS
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbaTieude = New System.Windows.Forms.Label()
        Me.lbaLoaiVT = New System.Windows.Forms.Label()
        Me.lbaNoiSuDung = New System.Windows.Forms.Label()
        Me.lbaLoaiThietBi = New System.Windows.Forms.Label()
        Me.cbxLoaiVT = New Commons.UtcComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbxNoiSuDung = New Commons.UtcComboBox()
        Me.cbxLoaiTB = New Commons.UtcComboBox()
        Me.grdDanhSachVTPT = New System.Windows.Forms.DataGridView()
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUY_CACH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTimMa = New System.Windows.Forms.TextBox()
        Me.txtTimTen = New System.Windows.Forms.TextBox()
        Me.lbaTimTen = New System.Windows.Forms.Label()
        Me.lbaTimMa = New System.Windows.Forms.Label()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhSachVTPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTieude, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiVT, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNoiSuDung, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiThietBi, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiVT, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNoiSuDung, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiTB, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdDanhSachVTPT, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(858, 391)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbaTieude
        '
        Me.lbaTieude.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbaTieude, 6)
        Me.lbaTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTieude.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTieude.Location = New System.Drawing.Point(3, 0)
        Me.lbaTieude.Name = "lbaTieude"
        Me.lbaTieude.Size = New System.Drawing.Size(852, 46)
        Me.lbaTieude.TabIndex = 0
        Me.lbaTieude.Text = "Chon VTPT Dat Hang"
        Me.lbaTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbaLoaiVT
        '
        Me.lbaLoaiVT.AutoSize = True
        Me.lbaLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiVT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaLoaiVT.Location = New System.Drawing.Point(3, 46)
        Me.lbaLoaiVT.Name = "lbaLoaiVT"
        Me.lbaLoaiVT.Size = New System.Drawing.Size(101, 26)
        Me.lbaLoaiVT.TabIndex = 1
        Me.lbaLoaiVT.Text = "Loai VT"
        Me.lbaLoaiVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNoiSuDung
        '
        Me.lbaNoiSuDung.AutoSize = True
        Me.lbaNoiSuDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNoiSuDung.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaNoiSuDung.Location = New System.Drawing.Point(252, 46)
        Me.lbaNoiSuDung.Name = "lbaNoiSuDung"
        Me.lbaNoiSuDung.Size = New System.Drawing.Size(123, 26)
        Me.lbaNoiSuDung.TabIndex = 2
        Me.lbaNoiSuDung.Text = "Noi SD VT"
        Me.lbaNoiSuDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaLoaiThietBi
        '
        Me.lbaLoaiThietBi.AutoSize = True
        Me.lbaLoaiThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiThietBi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaLoaiThietBi.Location = New System.Drawing.Point(549, 46)
        Me.lbaLoaiThietBi.Name = "lbaLoaiThietBi"
        Me.lbaLoaiThietBi.Size = New System.Drawing.Size(124, 26)
        Me.lbaLoaiThietBi.TabIndex = 3
        Me.lbaLoaiThietBi.Text = "LoaiTB"
        Me.lbaLoaiThietBi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxLoaiVT
        '
        Me.cbxLoaiVT.AssemblyName = ""
        Me.cbxLoaiVT.BackColor = System.Drawing.Color.White
        Me.cbxLoaiVT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxLoaiVT.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxLoaiVT.ClassName = ""
        Me.cbxLoaiVT.Display = ""
        Me.cbxLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiVT.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxLoaiVT.FormattingEnabled = True
        Me.cbxLoaiVT.IsAll = True
        Me.cbxLoaiVT.isInputNull = False
        Me.cbxLoaiVT.IsNew = False
        Me.cbxLoaiVT.IsNull = True
        Me.cbxLoaiVT.ItemAll = " < ALL > "
        Me.cbxLoaiVT.ItemNew = "...New"
        Me.cbxLoaiVT.Location = New System.Drawing.Point(110, 49)
        Me.cbxLoaiVT.MethodName = ""
        Me.cbxLoaiVT.Name = "cbxLoaiVT"
        Me.cbxLoaiVT.Param = ""
        Me.cbxLoaiVT.Param2 = ""
        Me.cbxLoaiVT.Size = New System.Drawing.Size(136, 21)
        Me.cbxLoaiVT.StoreName = ""
        Me.cbxLoaiVT.TabIndex = 4
        Me.cbxLoaiVT.Table = Nothing
        Me.cbxLoaiVT.TextReadonly = False
        Me.cbxLoaiVT.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cbxNoiSuDung
        '
        Me.cbxNoiSuDung.AssemblyName = ""
        Me.cbxNoiSuDung.BackColor = System.Drawing.Color.White
        Me.cbxNoiSuDung.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNoiSuDung.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNoiSuDung.ClassName = ""
        Me.cbxNoiSuDung.Display = ""
        Me.cbxNoiSuDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNoiSuDung.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNoiSuDung.FormattingEnabled = True
        Me.cbxNoiSuDung.IsAll = True
        Me.cbxNoiSuDung.isInputNull = False
        Me.cbxNoiSuDung.IsNew = False
        Me.cbxNoiSuDung.IsNull = True
        Me.cbxNoiSuDung.ItemAll = " < ALL > "
        Me.cbxNoiSuDung.ItemNew = "...New"
        Me.cbxNoiSuDung.Location = New System.Drawing.Point(381, 49)
        Me.cbxNoiSuDung.MethodName = ""
        Me.cbxNoiSuDung.Name = "cbxNoiSuDung"
        Me.cbxNoiSuDung.Param = ""
        Me.cbxNoiSuDung.Param2 = ""
        Me.cbxNoiSuDung.Size = New System.Drawing.Size(162, 21)
        Me.cbxNoiSuDung.StoreName = ""
        Me.cbxNoiSuDung.TabIndex = 5
        Me.cbxNoiSuDung.Table = Nothing
        Me.cbxNoiSuDung.TextReadonly = False
        Me.cbxNoiSuDung.Value = ""
        '
        'cbxLoaiTB
        '
        Me.cbxLoaiTB.AssemblyName = ""
        Me.cbxLoaiTB.BackColor = System.Drawing.Color.White
        Me.cbxLoaiTB.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxLoaiTB.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxLoaiTB.ClassName = ""
        Me.cbxLoaiTB.Display = ""
        Me.cbxLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxLoaiTB.FormattingEnabled = True
        Me.cbxLoaiTB.IsAll = True
        Me.cbxLoaiTB.isInputNull = False
        Me.cbxLoaiTB.IsNew = False
        Me.cbxLoaiTB.IsNull = True
        Me.cbxLoaiTB.ItemAll = " < ALL > "
        Me.cbxLoaiTB.ItemNew = "...New"
        Me.cbxLoaiTB.Location = New System.Drawing.Point(679, 49)
        Me.cbxLoaiTB.MethodName = ""
        Me.cbxLoaiTB.Name = "cbxLoaiTB"
        Me.cbxLoaiTB.Param = ""
        Me.cbxLoaiTB.Param2 = ""
        Me.cbxLoaiTB.Size = New System.Drawing.Size(176, 21)
        Me.cbxLoaiTB.StoreName = ""
        Me.cbxLoaiTB.TabIndex = 6
        Me.cbxLoaiTB.Table = Nothing
        Me.cbxLoaiTB.TextReadonly = False
        Me.cbxLoaiTB.Value = ""
        '
        'grdDanhSachVTPT
        '
        Me.grdDanhSachVTPT.AllowUserToAddRows = False
        Me.grdDanhSachVTPT.AllowUserToDeleteRows = False
        Me.grdDanhSachVTPT.AllowUserToResizeColumns = False
        Me.grdDanhSachVTPT.AllowUserToResizeRows = False
        Me.grdDanhSachVTPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhSachVTPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_PT, Me.TEN_PT, Me.DVT, Me.QUY_CACH})
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdDanhSachVTPT, 6)
        Me.grdDanhSachVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSachVTPT.Location = New System.Drawing.Point(3, 75)
        Me.grdDanhSachVTPT.MultiSelect = False
        Me.grdDanhSachVTPT.Name = "grdDanhSachVTPT"
        Me.grdDanhSachVTPT.RowHeadersVisible = False
        Me.grdDanhSachVTPT.Size = New System.Drawing.Size(852, 277)
        Me.grdDanhSachVTPT.TabIndex = 7
        '
        'CHON
        '
        Me.CHON.HeaderText = "CHON"
        Me.CHON.MinimumWidth = 70
        Me.CHON.Name = "CHON"
        Me.CHON.Width = 70
        '
        'MS_PT
        '
        Me.MS_PT.HeaderText = "MS_VTPT"
        Me.MS_PT.MinimumWidth = 130
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.Width = 130
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.HeaderText = "TEN_PT"
        Me.TEN_PT.MinimumWidth = 200
        Me.TEN_PT.Name = "TEN_PT"
        '
        'DVT
        '
        Me.DVT.HeaderText = "DVT"
        Me.DVT.MinimumWidth = 100
        Me.DVT.Name = "DVT"
        '
        'QUY_CACH
        '
        Me.QUY_CACH.HeaderText = "QUY_CACH"
        Me.QUY_CACH.MinimumWidth = 200
        Me.QUY_CACH.Name = "QUY_CACH"
        Me.QUY_CACH.Width = 200
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.txtTimMa)
        Me.Panel1.Controls.Add(Me.txtTimTen)
        Me.Panel1.Controls.Add(Me.lbaTimTen)
        Me.Panel1.Controls.Add(Me.lbaTimMa)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 358)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 30)
        Me.Panel1.TabIndex = 8
        '
        'txtTimMa
        '
        Me.txtTimMa.Location = New System.Drawing.Point(83, 6)
        Me.txtTimMa.Name = "txtTimMa"
        Me.txtTimMa.Size = New System.Drawing.Size(115, 21)
        Me.txtTimMa.TabIndex = 5
        '
        'txtTimTen
        '
        Me.txtTimTen.Location = New System.Drawing.Point(272, 6)
        Me.txtTimTen.Name = "txtTimTen"
        Me.txtTimTen.Size = New System.Drawing.Size(131, 21)
        Me.txtTimTen.TabIndex = 4
        '
        'lbaTimTen
        '
        Me.lbaTimTen.AutoSize = True
        Me.lbaTimTen.Location = New System.Drawing.Point(204, 11)
        Me.lbaTimTen.Name = "lbaTimTen"
        Me.lbaTimTen.Size = New System.Drawing.Size(42, 13)
        Me.lbaTimTen.TabIndex = 3
        Me.lbaTimTen.Text = "Tim tên"
        '
        'lbaTimMa
        '
        Me.lbaTimMa.AutoSize = True
        Me.lbaTimMa.Location = New System.Drawing.Point(10, 8)
        Me.lbaTimMa.Name = "lbaTimMa"
        Me.lbaTimMa.Size = New System.Drawing.Size(40, 13)
        Me.lbaTimMa.TabIndex = 2
        Me.lbaTimMa.Text = "Tìm mã"
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(692, 4)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(93, 23)
        Me.btnThoat.TabIndex = 1
        Me.btnThoat.Text = "Thoat"
        '
        'btnThucHien
        '
        Me.btnThucHien.Location = New System.Drawing.Point(596, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 0
        Me.btnThucHien.Text = "Thuc Hien"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 70
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_VTPT"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 130
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_PT"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "QUY_CACH"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'frmChonVTPTCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 391)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonVTPTCS"
        Me.Text = "frmChonVTPTCS"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhSachVTPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTieude As System.Windows.Forms.Label
    Friend WithEvents lbaLoaiVT As System.Windows.Forms.Label
    Friend WithEvents lbaNoiSuDung As System.Windows.Forms.Label
    Friend WithEvents lbaLoaiThietBi As System.Windows.Forms.Label
    Friend WithEvents cbxLoaiVT As Commons.UtcComboBox
    Friend WithEvents cbxNoiSuDung As Commons.UtcComboBox
    Friend WithEvents cbxLoaiTB As Commons.UtcComboBox
    Friend WithEvents grdDanhSachVTPT As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUY_CACH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbaTimTen As System.Windows.Forms.Label
    Friend WithEvents lbaTimMa As System.Windows.Forms.Label
    Friend WithEvents txtTimMa As System.Windows.Forms.TextBox
    Friend WithEvents txtTimTen As System.Windows.Forms.TextBox
End Class
