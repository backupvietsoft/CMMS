<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuocGia
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblTieudequocgia = New System.Windows.Forms.Label()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsach = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsach = New System.Windows.Forms.DataGridView()
        Me.GrpNhapqg = New System.Windows.Forms.GroupBox()
        Me.TxtTenquocgia = New System.Windows.Forms.TextBox()
        Me.TxtMaquocgia = New System.Windows.Forms.TextBox()
        Me.LblMa = New System.Windows.Forms.Label()
        Me.LblTen = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsach.SuspendLayout()
        CType(Me.GrdDanhsach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapqg.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTieudequocgia
        '
        Me.LblTieudequocgia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudequocgia.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieudequocgia.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudequocgia.Location = New System.Drawing.Point(5, 9)
        Me.LblTieudequocgia.Name = "LblTieudequocgia"
        Me.LblTieudequocgia.Size = New System.Drawing.Size(719, 29)
        Me.LblTieudequocgia.TabIndex = 50
        Me.LblTieudequocgia.Text = "QUỐC GIA"
        Me.LblTieudequocgia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(477, 432)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(82, 25)
        Me.BtnSua.TabIndex = 5
        Me.BtnSua.Text = "&Sửa"
        '
        'GrpDanhsach
        '
        Me.GrpDanhsach.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsach.Controls.Add(Me.GrdDanhsach)
        Me.GrpDanhsach.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsach.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsach.Location = New System.Drawing.Point(2, 134)
        Me.GrpDanhsach.Name = "GrpDanhsach"
        Me.GrpDanhsach.Size = New System.Drawing.Size(722, 289)
        Me.GrpDanhsach.TabIndex = 49
        Me.GrpDanhsach.TabStop = False
        Me.GrpDanhsach.Text = "Danh sách quốc gia"
        '
        'GrdDanhsach
        '
        Me.GrdDanhsach.AllowDrop = True
        Me.GrdDanhsach.AllowUserToAddRows = False
        Me.GrdDanhsach.AllowUserToDeleteRows = False
        Me.GrdDanhsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsach.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsach.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsach.MultiSelect = False
        Me.GrdDanhsach.Name = "GrdDanhsach"
        Me.GrdDanhsach.ReadOnly = True
        Me.GrdDanhsach.RowHeadersWidth = 25
        Me.GrdDanhsach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdDanhsach.ShowEditingIcon = False
        Me.GrdDanhsach.Size = New System.Drawing.Size(716, 268)
        Me.GrdDanhsach.TabIndex = 3
        '
        'GrpNhapqg
        '
        Me.GrpNhapqg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapqg.Controls.Add(Me.TxtTenquocgia)
        Me.GrpNhapqg.Controls.Add(Me.TxtMaquocgia)
        Me.GrpNhapqg.Controls.Add(Me.LblMa)
        Me.GrpNhapqg.Controls.Add(Me.LblTen)
        Me.GrpNhapqg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapqg.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapqg.Location = New System.Drawing.Point(24, 42)
        Me.GrpNhapqg.Name = "GrpNhapqg"
        Me.GrpNhapqg.Size = New System.Drawing.Size(675, 83)
        Me.GrpNhapqg.TabIndex = 48
        Me.GrpNhapqg.TabStop = False
        Me.GrpNhapqg.Text = "Nhập quốc gia"
        '
        'TxtTenquocgia
        '
        Me.TxtTenquocgia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenquocgia.Location = New System.Drawing.Point(230, 57)
        Me.TxtTenquocgia.Name = "TxtTenquocgia"
        Me.TxtTenquocgia.Size = New System.Drawing.Size(296, 22)
        Me.TxtTenquocgia.TabIndex = 2
        '
        'TxtMaquocgia
        '
        Me.TxtMaquocgia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaquocgia.Location = New System.Drawing.Point(230, 27)
        Me.TxtMaquocgia.Name = "TxtMaquocgia"
        Me.TxtMaquocgia.Size = New System.Drawing.Size(296, 22)
        Me.TxtMaquocgia.TabIndex = 1
        '
        'LblMa
        '
        Me.LblMa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMa.AutoSize = True
        Me.LblMa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMa.ForeColor = System.Drawing.Color.Black
        Me.LblMa.Location = New System.Drawing.Point(128, 30)
        Me.LblMa.Name = "LblMa"
        Me.LblMa.Size = New System.Drawing.Size(46, 14)
        Me.LblMa.TabIndex = 3
        Me.LblMa.Text = "Mã QG"
        '
        'LblTen
        '
        Me.LblTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTen.AutoSize = True
        Me.LblTen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTen.ForeColor = System.Drawing.Color.Black
        Me.LblTen.Location = New System.Drawing.Point(128, 60)
        Me.LblTen.Name = "LblTen"
        Me.LblTen.Size = New System.Drawing.Size(50, 14)
        Me.LblTen.TabIndex = 5
        Me.LblTen.Text = "Tên QG"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(395, 432)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(82, 25)
        Me.BtnThem.TabIndex = 4
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(558, 432)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(82, 25)
        Me.BtnXoa.TabIndex = 6
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnThoat.Location = New System.Drawing.Point(639, 432)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(82, 25)
        Me.BtnThoat.TabIndex = 9
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(477, 432)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(82, 25)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(558, 432)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(82, 25)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'frmQuocGia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.LblTieudequocgia)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.GrpDanhsach)
        Me.Controls.Add(Me.GrpNhapqg)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnThoat)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuocGia"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmQuocGia"
        Me.GrpDanhsach.ResumeLayout(False)
        CType(Me.GrdDanhsach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapqg.ResumeLayout(False)
        Me.GrpNhapqg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTieudequocgia As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsach As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsach As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapqg As System.Windows.Forms.GroupBox
    Friend WithEvents LblMa As System.Windows.Forms.Label
    Friend WithEvents LblTen As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtTenquocgia As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaquocgia As System.Windows.Forms.TextBox
End Class
