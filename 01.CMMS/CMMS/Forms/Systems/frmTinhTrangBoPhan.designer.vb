<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinhTrangBoPhan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LblTieude = New System.Windows.Forms.Label
        Me.grpNhap = New System.Windows.Forms.GroupBox
        Me.txt_CH = New Commons.utcTextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblCH = New System.Windows.Forms.Label
        Me.txt_EN = New Commons.utcTextBox
        Me.lblEN = New System.Windows.Forms.Label
        Me.txt_Viet = New Commons.utcTextBox
        Me.lblViet = New System.Windows.Forms.Label
        Me.TxtMa = New System.Windows.Forms.Label
        Me.lblMa = New System.Windows.Forms.Label
        Me.grpDanhSach = New System.Windows.Forms.GroupBox
        Me.dgrDanhsach = New System.Windows.Forms.DataGridView
        Me.BtnSua = New System.Windows.Forms.Button
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.grpNhap.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhSach.SuspendLayout()
        CType(Me.dgrDanhsach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTieude
        '
        Me.LblTieude.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieude.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieude.ForeColor = System.Drawing.Color.Navy
        Me.LblTieude.Location = New System.Drawing.Point(-1, -1)
        Me.LblTieude.Name = "LblTieude"
        Me.LblTieude.Size = New System.Drawing.Size(589, 50)
        Me.LblTieude.TabIndex = 47
        Me.LblTieude.Text = "TÌNH TRẠNG BỘ PHẬN"
        Me.LblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpNhap
        '
        Me.grpNhap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNhap.Controls.Add(Me.txt_CH)
        Me.grpNhap.Controls.Add(Me.lblCH)
        Me.grpNhap.Controls.Add(Me.txt_EN)
        Me.grpNhap.Controls.Add(Me.lblEN)
        Me.grpNhap.Controls.Add(Me.txt_Viet)
        Me.grpNhap.Controls.Add(Me.lblViet)
        Me.grpNhap.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhap.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhap.Location = New System.Drawing.Point(107, 47)
        Me.grpNhap.Name = "grpNhap"
        Me.grpNhap.Size = New System.Drawing.Size(379, 105)
        Me.grpNhap.TabIndex = 48
        Me.grpNhap.TabStop = False
        Me.grpNhap.Text = "Nhập tình trạng"
        '
        'txt_CH
        '
        Me.txt_CH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_CH.BackColor = System.Drawing.Color.White
        Me.txt_CH.ErrorProviderControl = Me.ErrorProvider1
        Me.txt_CH.FieldName = ""
        Me.txt_CH.IsNull = False
        Me.txt_CH.Location = New System.Drawing.Point(119, 69)
        Me.txt_CH.Name = "txt_CH"
        Me.txt_CH.Size = New System.Drawing.Size(251, 22)
        Me.txt_CH.TabIndex = 9
        Me.txt_CH.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblCH
        '
        Me.lblCH.AutoSize = True
        Me.lblCH.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblCH.ForeColor = System.Drawing.Color.Black
        Me.lblCH.Location = New System.Drawing.Point(9, 72)
        Me.lblCH.Name = "lblCH"
        Me.lblCH.Size = New System.Drawing.Size(86, 14)
        Me.lblCH.TabIndex = 8
        Me.lblCH.Text = "Tên tiếng Hoa"
        '
        'txt_EN
        '
        Me.txt_EN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_EN.BackColor = System.Drawing.Color.White
        Me.txt_EN.ErrorProviderControl = Me.ErrorProvider1
        Me.txt_EN.FieldName = ""
        Me.txt_EN.IsNull = False
        Me.txt_EN.Location = New System.Drawing.Point(119, 43)
        Me.txt_EN.Name = "txt_EN"
        Me.txt_EN.Size = New System.Drawing.Size(251, 22)
        Me.txt_EN.TabIndex = 7
        Me.txt_EN.TextTypeMode = Commons.TypeMode.None
        '
        'lblEN
        '
        Me.lblEN.AutoSize = True
        Me.lblEN.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblEN.ForeColor = System.Drawing.Color.Black
        Me.lblEN.Location = New System.Drawing.Point(9, 46)
        Me.lblEN.Name = "lblEN"
        Me.lblEN.Size = New System.Drawing.Size(87, 14)
        Me.lblEN.TabIndex = 6
        Me.lblEN.Text = "Tên tiếng Anh"
        '
        'txt_Viet
        '
        Me.txt_Viet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Viet.BackColor = System.Drawing.Color.White
        Me.txt_Viet.ErrorProviderControl = Me.ErrorProvider1
        Me.txt_Viet.FieldName = ""
        Me.txt_Viet.IsNull = False
        Me.txt_Viet.Location = New System.Drawing.Point(119, 17)
        Me.txt_Viet.Name = "txt_Viet"
        Me.txt_Viet.Size = New System.Drawing.Size(251, 22)
        Me.txt_Viet.TabIndex = 2
        Me.txt_Viet.TextTypeMode = Commons.TypeMode.None
        '
        'lblViet
        '
        Me.lblViet.AutoSize = True
        Me.lblViet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViet.ForeColor = System.Drawing.Color.Black
        Me.lblViet.Location = New System.Drawing.Point(9, 20)
        Me.lblViet.Name = "lblViet"
        Me.lblViet.Size = New System.Drawing.Size(93, 14)
        Me.lblViet.TabIndex = 5
        Me.lblViet.Text = "Tên tiếng Việt"
        '
        'TxtMa
        '
        Me.TxtMa.AutoSize = True
        Me.TxtMa.Location = New System.Drawing.Point(5, 98)
        Me.TxtMa.Name = "TxtMa"
        Me.TxtMa.Size = New System.Drawing.Size(35, 13)
        Me.TxtMa.TabIndex = 10
        Me.TxtMa.Text = "txtMa"
        Me.TxtMa.Visible = False
        '
        'lblMa
        '
        Me.lblMa.AutoSize = True
        Me.lblMa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMa.ForeColor = System.Drawing.Color.Black
        Me.lblMa.Location = New System.Drawing.Point(8, 67)
        Me.lblMa.Name = "lblMa"
        Me.lblMa.Size = New System.Drawing.Size(25, 14)
        Me.lblMa.TabIndex = 3
        Me.lblMa.Text = "Mã"
        Me.lblMa.Visible = False
        '
        'grpDanhSach
        '
        Me.grpDanhSach.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDanhSach.Controls.Add(Me.dgrDanhsach)
        Me.grpDanhSach.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhSach.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhSach.Location = New System.Drawing.Point(8, 152)
        Me.grpDanhSach.Name = "grpDanhSach"
        Me.grpDanhSach.Size = New System.Drawing.Size(576, 241)
        Me.grpDanhSach.TabIndex = 49
        Me.grpDanhSach.TabStop = False
        Me.grpDanhSach.Text = "Danh sách tình trạng"
        '
        'dgrDanhsach
        '
        Me.dgrDanhsach.AllowUserToAddRows = False
        Me.dgrDanhsach.AllowUserToDeleteRows = False
        Me.dgrDanhsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrDanhsach.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrDanhsach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrDanhsach.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgrDanhsach.Location = New System.Drawing.Point(3, 18)
        Me.dgrDanhsach.MultiSelect = False
        Me.dgrDanhsach.Name = "dgrDanhsach"
        Me.dgrDanhsach.ReadOnly = True
        Me.dgrDanhsach.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.dgrDanhsach.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgrDanhsach.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgrDanhsach.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgrDanhsach.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgrDanhsach.Size = New System.Drawing.Size(570, 220)
        Me.dgrDanhsach.TabIndex = 3
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(329, 404)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 60
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(247, 404)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 59
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(491, 404)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 62
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(491, 404)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 64
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(410, 404)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 61
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(410, 404)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 63
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'frmTinhTrangBoPhan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 433)
        Me.Controls.Add(Me.TxtMa)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.grpDanhSach)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.LblTieude)
        Me.Controls.Add(Me.lblMa)
        Me.Controls.Add(Me.grpNhap)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmTinhTrangBoPhan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tỉnh trạng bộ phận"
        Me.grpNhap.ResumeLayout(False)
        Me.grpNhap.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhSach.ResumeLayout(False)
        CType(Me.dgrDanhsach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTieude As System.Windows.Forms.Label
    Friend WithEvents grpNhap As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMa As System.Windows.Forms.Label
    Friend WithEvents txt_CH As Commons.utcTextBox
    Friend WithEvents lblCH As System.Windows.Forms.Label
    Friend WithEvents txt_EN As Commons.utcTextBox
    Friend WithEvents lblEN As System.Windows.Forms.Label
    Friend WithEvents txt_Viet As Commons.utcTextBox
    Friend WithEvents lblMa As System.Windows.Forms.Label
    Friend WithEvents lblViet As System.Windows.Forms.Label
    Friend WithEvents grpDanhSach As System.Windows.Forms.GroupBox
    Friend WithEvents dgrDanhsach As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
