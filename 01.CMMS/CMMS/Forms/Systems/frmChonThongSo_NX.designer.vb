<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonThongSo_NX
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
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.GrpDanhmucthongsoNX = New System.Windows.Forms.GroupBox
        Me.grdDanhmucthongsoTB = New System.Windows.Forms.DataGridView
        Me.GrpNhapthongsoNX = New System.Windows.Forms.GroupBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDonvido = New System.Windows.Forms.Label
        Me.LblTenthongsoTB = New System.Windows.Forms.Label
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnSua = New System.Windows.Forms.Button
        Me.LblTieudethongsoNX = New System.Windows.Forms.Label
        Me.chkDinhTinh = New System.Windows.Forms.CheckBox
        Me.btnExcute = New System.Windows.Forms.Button
        Me.cboDonvido = New Commons.UtcComboBox
        Me.TxtTenthongsoTB = New Commons.utcTextBox
        Me.TxtMaso = New Commons.utcTextBox
        Me.GrpDanhmucthongsoNX.SuspendLayout()
        CType(Me.grdDanhmucthongsoTB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapthongsoNX.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(188, 319)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(351, 319)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 9
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(432, 319)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(432, 319)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 10
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'GrpDanhmucthongsoNX
        '
        Me.GrpDanhmucthongsoNX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhmucthongsoNX.Controls.Add(Me.grdDanhmucthongsoTB)
        Me.GrpDanhmucthongsoNX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucthongsoNX.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucthongsoNX.Location = New System.Drawing.Point(11, 161)
        Me.GrpDanhmucthongsoNX.Name = "GrpDanhmucthongsoNX"
        Me.GrpDanhmucthongsoNX.Size = New System.Drawing.Size(502, 152)
        Me.GrpDanhmucthongsoNX.TabIndex = 90
        Me.GrpDanhmucthongsoNX.TabStop = False
        Me.GrpDanhmucthongsoNX.Text = "Danh mục thông số thiết bị"
        '
        'grdDanhmucthongsoTB
        '
        Me.grdDanhmucthongsoTB.AllowUserToAddRows = False
        Me.grdDanhmucthongsoTB.AllowUserToDeleteRows = False
        Me.grdDanhmucthongsoTB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhmucthongsoTB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhmucthongsoTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhmucthongsoTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhmucthongsoTB.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.grdDanhmucthongsoTB.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhmucthongsoTB.MultiSelect = False
        Me.grdDanhmucthongsoTB.Name = "grdDanhmucthongsoTB"
        Me.grdDanhmucthongsoTB.ReadOnly = True
        Me.grdDanhmucthongsoTB.RowHeadersWidth = 25
        Me.grdDanhmucthongsoTB.ShowEditingIcon = False
        Me.grdDanhmucthongsoTB.Size = New System.Drawing.Size(496, 131)
        Me.grdDanhmucthongsoTB.TabIndex = 4
        '
        'GrpNhapthongsoNX
        '
        Me.GrpNhapthongsoNX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapthongsoNX.Controls.Add(Me.chkDinhTinh)
        Me.GrpNhapthongsoNX.Controls.Add(Me.lblDonvido)
        Me.GrpNhapthongsoNX.Controls.Add(Me.cboDonvido)
        Me.GrpNhapthongsoNX.Controls.Add(Me.TxtTenthongsoTB)
        Me.GrpNhapthongsoNX.Controls.Add(Me.LblTenthongsoTB)
        Me.GrpNhapthongsoNX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapthongsoNX.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapthongsoNX.Location = New System.Drawing.Point(34, 55)
        Me.GrpNhapthongsoNX.Name = "GrpNhapthongsoNX"
        Me.GrpNhapthongsoNX.Size = New System.Drawing.Size(457, 100)
        Me.GrpNhapthongsoNX.TabIndex = 89
        Me.GrpNhapthongsoNX.TabStop = False
        Me.GrpNhapthongsoNX.Text = "Nhập thông số thiết bị"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblDonvido
        '
        Me.lblDonvido.AutoSize = True
        Me.lblDonvido.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDonvido.ForeColor = System.Drawing.Color.Black
        Me.lblDonvido.Location = New System.Drawing.Point(6, 45)
        Me.lblDonvido.Name = "lblDonvido"
        Me.lblDonvido.Size = New System.Drawing.Size(66, 14)
        Me.lblDonvido.TabIndex = 72
        Me.lblDonvido.Text = "Đơn vị đo"
        '
        'LblTenthongsoTB
        '
        Me.LblTenthongsoTB.AutoSize = True
        Me.LblTenthongsoTB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenthongsoTB.ForeColor = System.Drawing.Color.Black
        Me.LblTenthongsoTB.Location = New System.Drawing.Point(6, 24)
        Me.LblTenthongsoTB.Name = "LblTenthongsoTB"
        Me.LblTenthongsoTB.Size = New System.Drawing.Size(89, 14)
        Me.LblTenthongsoTB.TabIndex = 5
        Me.LblTenthongsoTB.Text = "Tên thông số"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(351, 319)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(270, 319)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'LblTieudethongsoNX
        '
        Me.LblTieudethongsoNX.AutoSize = True
        Me.LblTieudethongsoNX.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudethongsoNX.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudethongsoNX.Location = New System.Drawing.Point(145, 9)
        Me.LblTieudethongsoNX.Name = "LblTieudethongsoNX"
        Me.LblTieudethongsoNX.Size = New System.Drawing.Size(253, 23)
        Me.LblTieudethongsoNX.TabIndex = 96
        Me.LblTieudethongsoNX.Text = "THOÂNG SOÁ THIEÁT BÒ"
        '
        'chkDinhTinh
        '
        Me.chkDinhTinh.AutoSize = True
        Me.chkDinhTinh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDinhTinh.ForeColor = System.Drawing.Color.Black
        Me.chkDinhTinh.Location = New System.Drawing.Point(9, 76)
        Me.chkDinhTinh.Name = "chkDinhTinh"
        Me.chkDinhTinh.Size = New System.Drawing.Size(83, 18)
        Me.chkDinhTinh.TabIndex = 73
        Me.chkDinhTinh.Text = "Định tính"
        Me.chkDinhTinh.UseVisualStyleBackColor = True
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcute.Location = New System.Drawing.Point(14, 321)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(81, 25)
        Me.btnExcute.TabIndex = 97
        Me.btnExcute.Text = "Thực hiện"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'cboDonvido
        '
        Me.cboDonvido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDonvido.AssemblyName = ""
        Me.cboDonvido.BackColor = System.Drawing.SystemColors.Window
        Me.cboDonvido.ClassName = ""
        Me.cboDonvido.Display = ""
        Me.cboDonvido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDonvido.ErrorProviderControl = Me.ErrorProvider
        Me.cboDonvido.FormattingEnabled = True
        Me.cboDonvido.IsAll = False
        Me.cboDonvido.IsNew = True
        Me.cboDonvido.ItemAll = " < ALL > "
        Me.cboDonvido.ItemNew = "...New"
        Me.cboDonvido.Location = New System.Drawing.Point(101, 42)
        Me.cboDonvido.MethodName = ""
        Me.cboDonvido.Name = "cboDonvido"
        Me.cboDonvido.Param = ""
        Me.cboDonvido.Size = New System.Drawing.Size(341, 22)
        Me.cboDonvido.StoreName = ""
        Me.cboDonvido.TabIndex = 2
        Me.cboDonvido.Table = Nothing
        Me.cboDonvido.TextReadonly = False
        Me.cboDonvido.Value = ""
        '
        'TxtTenthongsoTB
        '
        Me.TxtTenthongsoTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenthongsoTB.BackColor = System.Drawing.Color.White
        Me.TxtTenthongsoTB.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTenthongsoTB.FieldName = ""
        Me.TxtTenthongsoTB.IsNull = False
        Me.TxtTenthongsoTB.Location = New System.Drawing.Point(101, 20)
        Me.TxtTenthongsoTB.Name = "TxtTenthongsoTB"
        Me.TxtTenthongsoTB.Size = New System.Drawing.Size(341, 22)
        Me.TxtTenthongsoTB.TabIndex = 1
        Me.TxtTenthongsoTB.TextTypeMode = Commons.TypeMode.None
        '
        'TxtMaso
        '
        Me.TxtMaso.BackColor = System.Drawing.Color.White
        Me.TxtMaso.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMaso.FieldName = ""
        Me.TxtMaso.IsNull = True
        Me.TxtMaso.Location = New System.Drawing.Point(11, 3)
        Me.TxtMaso.Name = "TxtMaso"
        Me.TxtMaso.Size = New System.Drawing.Size(12, 21)
        Me.TxtMaso.TabIndex = 69
        Me.TxtMaso.TextTypeMode = Commons.TypeMode.None
        Me.TxtMaso.Visible = False
        '
        'frmChonThongSo_NX
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 356)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.GrpDanhmucthongsoNX)
        Me.Controls.Add(Me.GrpNhapthongsoNX)
        Me.Controls.Add(Me.TxtMaso)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.LblTieudethongsoNX)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonThongSo_NX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông số máy"
        Me.GrpDanhmucthongsoNX.ResumeLayout(False)
        CType(Me.grdDanhmucthongsoTB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapthongsoNX.ResumeLayout(False)
        Me.GrpNhapthongsoNX.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents GrpDanhmucthongsoNX As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhmucthongsoTB As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapthongsoNX As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents LblTieudethongsoNX As System.Windows.Forms.Label
    Friend WithEvents lblDonvido As System.Windows.Forms.Label
    Friend WithEvents cboDonvido As Commons.UtcComboBox
    Friend WithEvents TxtTenthongsoTB As Commons.utcTextBox
    Friend WithEvents TxtMaso As Commons.utcTextBox
    Friend WithEvents LblTenthongsoTB As System.Windows.Forms.Label
    Friend WithEvents chkDinhTinh As System.Windows.Forms.CheckBox
    Friend WithEvents btnExcute As System.Windows.Forms.Button
End Class
