<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhmucchucvu
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTieude = New System.Windows.Forms.Label()
        Me.grpNhapchucvu = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTEN_CHUC_VU = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dtpNGAY = New System.Windows.Forms.DateTimePicker()
        Me.lblNhanvien = New System.Windows.Forms.Label()
        Me.lblNgay = New System.Windows.Forms.Label()
        Me.cboCONG_NHAN = New Commons.UtcComboBox()
        Me.lblChucvu = New System.Windows.Forms.Label()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachchucvu = New System.Windows.Forms.GroupBox()
        Me.grdDanhsachchucvu = New System.Windows.Forms.DataGridView()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpNhapchucvu.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtTEN_CHUC_VU.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachchucvu.SuspendLayout()
        CType(Me.grdDanhsachchucvu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieude, 3)
        Me.lblTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(3, 0)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(728, 33)
        Me.lblTieude.TabIndex = 70
        Me.lblTieude.Text = "CHỨC VỤ"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpNhapchucvu
        '
        Me.grpNhapchucvu.Controls.Add(Me.TableLayoutPanel2)
        Me.grpNhapchucvu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhapchucvu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapchucvu.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapchucvu.Location = New System.Drawing.Point(33, 36)
        Me.grpNhapchucvu.Name = "grpNhapchucvu"
        Me.grpNhapchucvu.Size = New System.Drawing.Size(668, 72)
        Me.grpNhapchucvu.TabIndex = 0
        Me.grpNhapchucvu.TabStop = False
        Me.grpNhapchucvu.Text = "Nhập chức vụ"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtTEN_CHUC_VU, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpNGAY, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNhanvien, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgay, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCONG_NHAN, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblChucvu, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(662, 51)
        Me.TableLayoutPanel2.TabIndex = 72
        '
        'txtTEN_CHUC_VU
        '
        Me.txtTEN_CHUC_VU.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_CHUC_VU.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtTEN_CHUC_VU, 3)
        Me.txtTEN_CHUC_VU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_CHUC_VU.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_CHUC_VU.FieldName = ""
        Me.txtTEN_CHUC_VU.IsNull = False
        Me.txtTEN_CHUC_VU.Location = New System.Drawing.Point(113, 28)
        Me.txtTEN_CHUC_VU.MaxLength = 80
        Me.txtTEN_CHUC_VU.Multiline = False
        Me.txtTEN_CHUC_VU.Name = "txtTEN_CHUC_VU"
        Me.txtTEN_CHUC_VU.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_CHUC_VU.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_CHUC_VU.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_CHUC_VU.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_CHUC_VU.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_CHUC_VU.Properties.MaxLength = 80
        Me.txtTEN_CHUC_VU.Properties.ReadOnly = True
        Me.txtTEN_CHUC_VU.ReadOnly = True
        Me.txtTEN_CHUC_VU.Size = New System.Drawing.Size(546, 20)
        Me.txtTEN_CHUC_VU.TabIndex = 2
        Me.txtTEN_CHUC_VU.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_CHUC_VU.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'dtpNGAY
        '
        Me.dtpNGAY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpNGAY.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNGAY.Location = New System.Drawing.Point(444, 3)
        Me.dtpNGAY.Name = "dtpNGAY"
        Me.dtpNGAY.Size = New System.Drawing.Size(215, 22)
        Me.dtpNGAY.TabIndex = 1
        Me.dtpNGAY.Value = New Date(2006, 11, 10, 0, 0, 0, 0)
        '
        'lblNhanvien
        '
        Me.lblNhanvien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhanvien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNhanvien.ForeColor = System.Drawing.Color.Black
        Me.lblNhanvien.Location = New System.Drawing.Point(3, 0)
        Me.lblNhanvien.Name = "lblNhanvien"
        Me.lblNhanvien.Size = New System.Drawing.Size(104, 25)
        Me.lblNhanvien.TabIndex = 52
        Me.lblNhanvien.Text = "Nhân viên"
        Me.lblNhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgay
        '
        Me.lblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.ForeColor = System.Drawing.Color.Black
        Me.lblNgay.Location = New System.Drawing.Point(334, 0)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(104, 25)
        Me.lblNgay.TabIndex = 50
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCONG_NHAN
        '
        Me.cboCONG_NHAN.AssemblyName = ""
        Me.cboCONG_NHAN.BackColor = System.Drawing.SystemColors.Window
        Me.cboCONG_NHAN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboCONG_NHAN.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboCONG_NHAN.ClassName = ""
        Me.cboCONG_NHAN.Display = ""
        Me.cboCONG_NHAN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCONG_NHAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCONG_NHAN.ErrorProviderControl = Me.ErrorProvider
        Me.cboCONG_NHAN.FormattingEnabled = True
        Me.cboCONG_NHAN.IsAll = False
        Me.cboCONG_NHAN.isInputNull = False
        Me.cboCONG_NHAN.IsNew = False
        Me.cboCONG_NHAN.IsNull = True
        Me.cboCONG_NHAN.ItemAll = " < ALL > "
        Me.cboCONG_NHAN.ItemNew = "...New"
        Me.cboCONG_NHAN.Location = New System.Drawing.Point(113, 3)
        Me.cboCONG_NHAN.MethodName = ""
        Me.cboCONG_NHAN.Name = "cboCONG_NHAN"
        Me.cboCONG_NHAN.Param = ""
        Me.cboCONG_NHAN.Param2 = ""
        Me.cboCONG_NHAN.Size = New System.Drawing.Size(215, 22)
        Me.cboCONG_NHAN.StoreName = ""
        Me.cboCONG_NHAN.TabIndex = 0
        Me.cboCONG_NHAN.Table = Nothing
        Me.cboCONG_NHAN.TextReadonly = False
        Me.cboCONG_NHAN.Value = ""
        '
        'lblChucvu
        '
        Me.lblChucvu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChucvu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChucvu.ForeColor = System.Drawing.Color.Black
        Me.lblChucvu.Location = New System.Drawing.Point(3, 25)
        Me.lblChucvu.Name = "lblChucvu"
        Me.lblChucvu.Size = New System.Drawing.Size(104, 26)
        Me.lblChucvu.TabIndex = 3
        Me.lblChucvu.Text = "Chức vụ"
        Me.lblChucvu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(411, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(306, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(516, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        '
        'grpDanhsachchucvu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachchucvu, 3)
        Me.grpDanhsachchucvu.Controls.Add(Me.grdDanhsachchucvu)
        Me.grpDanhsachchucvu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachchucvu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachchucvu.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachchucvu.Location = New System.Drawing.Point(3, 114)
        Me.grpDanhsachchucvu.Name = "grpDanhsachchucvu"
        Me.grpDanhsachchucvu.Size = New System.Drawing.Size(728, 304)
        Me.grpDanhsachchucvu.TabIndex = 1
        Me.grpDanhsachchucvu.TabStop = False
        Me.grpDanhsachchucvu.Text = "Danh sách đơn vị"
        '
        'grdDanhsachchucvu
        '
        Me.grdDanhsachchucvu.AllowUserToAddRows = False
        Me.grdDanhsachchucvu.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachchucvu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachchucvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachchucvu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachchucvu.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachchucvu.Name = "grdDanhsachchucvu"
        Me.grdDanhsachchucvu.ReadOnly = True
        Me.grdDanhsachchucvu.RowHeadersWidth = 25
        Me.grdDanhsachchucvu.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grdDanhsachchucvu.ShowEditingIcon = False
        Me.grdDanhsachchucvu.Size = New System.Drawing.Size(722, 283)
        Me.grdDanhsachchucvu.TabIndex = 0
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(516, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(621, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(621, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachchucvu, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpNhapchucvu, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieude, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 71
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 3)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 34)
        Me.Panel1.TabIndex = 72
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nhân viên"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 180
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Chức vụ"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 220
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ngày"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'frmDanhmucchucvu
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDanhmucchucvu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục chức vụ"
        Me.grpNhapchucvu.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.txtTEN_CHUC_VU.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachchucvu.ResumeLayout(False)
        CType(Me.grdDanhsachchucvu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents grpNhapchucvu As System.Windows.Forms.GroupBox
    Friend WithEvents lblNhanvien As System.Windows.Forms.Label
    Friend WithEvents cboCONG_NHAN As Commons.UtcComboBox
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents txtTEN_CHUC_VU As Commons.utcTextBox
    Friend WithEvents lblChucvu As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachchucvu As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachchucvu As System.Windows.Forms.DataGridView
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpNGAY As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
