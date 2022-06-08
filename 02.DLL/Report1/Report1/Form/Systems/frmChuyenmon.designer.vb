<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuyenmon
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhmucchuyenmon = New System.Windows.Forms.GroupBox()
        Me.GrdDanhmucchuyenmon = New System.Windows.Forms.DataGridView()
        Me.GrpNhapchuyenmon = New System.Windows.Forms.GroupBox()
        Me.TxtTEN_CM = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblTenchuyenmon = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.LblTieudechuyenmon = New System.Windows.Forms.Label()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtMS_CM = New Commons.utcTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpDanhmucchuyenmon.SuspendLayout()
        CType(Me.GrdDanhmucchuyenmon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapchuyenmon.SuspendLayout()
        CType(Me.TxtTEN_CM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMS_CM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(244, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(98, 30)
        Me.BtnSua.TabIndex = 2
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(636, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(98, 30)
        Me.BtnThoat.TabIndex = 4
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(342, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(98, 30)
        Me.BtnXoa.TabIndex = 3
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhmucchuyenmon
        '
        Me.GrpDanhmucchuyenmon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhmucchuyenmon.Controls.Add(Me.GrdDanhmucchuyenmon)
        Me.GrpDanhmucchuyenmon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucchuyenmon.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucchuyenmon.Location = New System.Drawing.Point(8, 100)
        Me.GrpDanhmucchuyenmon.Name = "GrpDanhmucchuyenmon"
        Me.GrpDanhmucchuyenmon.Size = New System.Drawing.Size(719, 321)
        Me.GrpDanhmucchuyenmon.TabIndex = 1
        Me.GrpDanhmucchuyenmon.TabStop = False
        Me.GrpDanhmucchuyenmon.Text = "Danh mục chuyên môn"
        '
        'GrdDanhmucchuyenmon
        '
        Me.GrdDanhmucchuyenmon.AllowUserToAddRows = False
        Me.GrdDanhmucchuyenmon.AllowUserToDeleteRows = False
        Me.GrdDanhmucchuyenmon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhmucchuyenmon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhmucchuyenmon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhmucchuyenmon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhmucchuyenmon.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhmucchuyenmon.MultiSelect = False
        Me.GrdDanhmucchuyenmon.Name = "GrdDanhmucchuyenmon"
        Me.GrdDanhmucchuyenmon.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "N2"
        Me.GrdDanhmucchuyenmon.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GrdDanhmucchuyenmon.RowHeadersWidth = 25
        Me.GrdDanhmucchuyenmon.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhmucchuyenmon.ShowEditingIcon = False
        Me.GrdDanhmucchuyenmon.Size = New System.Drawing.Size(713, 300)
        Me.GrdDanhmucchuyenmon.TabIndex = 2
        '
        'GrpNhapchuyenmon
        '
        Me.GrpNhapchuyenmon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapchuyenmon.Controls.Add(Me.TxtTEN_CM)
        Me.GrpNhapchuyenmon.Controls.Add(Me.LblTenchuyenmon)
        Me.GrpNhapchuyenmon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapchuyenmon.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapchuyenmon.Location = New System.Drawing.Point(72, 39)
        Me.GrpNhapchuyenmon.Name = "GrpNhapchuyenmon"
        Me.GrpNhapchuyenmon.Size = New System.Drawing.Size(591, 55)
        Me.GrpNhapchuyenmon.TabIndex = 0
        Me.GrpNhapchuyenmon.TabStop = False
        Me.GrpNhapchuyenmon.Text = "Nhập chuyên môn"
        '
        'TxtTEN_CM
        '
        Me.TxtTEN_CM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTEN_CM.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtTEN_CM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtTEN_CM.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTEN_CM.FieldName = ""
        Me.TxtTEN_CM.IsNull = False
        Me.TxtTEN_CM.Location = New System.Drawing.Point(129, 20)
        Me.TxtTEN_CM.MaxLength = 200
        Me.TxtTEN_CM.Multiline = False
        Me.TxtTEN_CM.Name = "TxtTEN_CM"
        Me.TxtTEN_CM.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtTEN_CM.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTEN_CM.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTEN_CM.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTEN_CM.Properties.Appearance.Options.UseFont = True
        Me.TxtTEN_CM.Properties.MaxLength = 200
        Me.TxtTEN_CM.ReadOnly = True
        Me.TxtTEN_CM.Size = New System.Drawing.Size(447, 21)
        Me.TxtTEN_CM.TabIndex = 0
        Me.TxtTEN_CM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtTEN_CM.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'LblTenchuyenmon
        '
        Me.LblTenchuyenmon.AutoSize = True
        Me.LblTenchuyenmon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenchuyenmon.ForeColor = System.Drawing.Color.Black
        Me.LblTenchuyenmon.Location = New System.Drawing.Point(15, 23)
        Me.LblTenchuyenmon.Name = "LblTenchuyenmon"
        Me.LblTenchuyenmon.Size = New System.Drawing.Size(108, 14)
        Me.LblTenchuyenmon.TabIndex = 5
        Me.LblTenchuyenmon.Text = "Tên chuyên môn"
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(146, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(98, 30)
        Me.BtnThem.TabIndex = 1
        Me.BtnThem.Text = "&Thêm"
        '
        'LblTieudechuyenmon
        '
        Me.LblTieudechuyenmon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudechuyenmon.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieudechuyenmon.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudechuyenmon.Location = New System.Drawing.Point(13, 9)
        Me.LblTieudechuyenmon.Name = "LblTieudechuyenmon"
        Me.LblTieudechuyenmon.Size = New System.Drawing.Size(709, 27)
        Me.LblTieudechuyenmon.TabIndex = 51
        Me.LblTieudechuyenmon.Text = "CHUYÊN MÔN"
        Me.LblTieudechuyenmon.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(440, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(98, 30)
        Me.BtnGhi.TabIndex = 5
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(538, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(98, 30)
        Me.BtnKhongghi.TabIndex = 6
        Me.BtnKhongghi.Text = "&Không"
        '
        'TxtMS_CM
        '
        Me.TxtMS_CM.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMS_CM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMS_CM.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMS_CM.FieldName = ""
        Me.TxtMS_CM.IsNull = True
        Me.TxtMS_CM.Location = New System.Drawing.Point(13, 62)
        Me.TxtMS_CM.MaxLength = 0
        Me.TxtMS_CM.Multiline = False
        Me.TxtMS_CM.Name = "TxtMS_CM"
        Me.TxtMS_CM.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMS_CM.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMS_CM.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMS_CM.ReadOnly = True
        Me.TxtMS_CM.Size = New System.Drawing.Size(14, 20)
        Me.TxtMS_CM.TabIndex = 62
        Me.TxtMS_CM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMS_CM.TextTypeMode = Commons.TypeMode.IsNumber
        Me.TxtMS_CM.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 30)
        Me.Panel1.TabIndex = 63
        '
        'frmChuyenmon
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtMS_CM)
        Me.Controls.Add(Me.GrpDanhmucchuyenmon)
        Me.Controls.Add(Me.GrpNhapchuyenmon)
        Me.Controls.Add(Me.LblTieudechuyenmon)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChuyenmon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chuyên môn"
        Me.GrpDanhmucchuyenmon.ResumeLayout(False)
        CType(Me.GrdDanhmucchuyenmon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapchuyenmon.ResumeLayout(False)
        Me.GrpNhapchuyenmon.PerformLayout()
        CType(Me.TxtTEN_CM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMS_CM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhmucchuyenmon As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhmucchuyenmon As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapchuyenmon As System.Windows.Forms.GroupBox
    Friend WithEvents LblTenchuyenmon As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblTieudechuyenmon As System.Windows.Forms.Label
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtTEN_CM As Commons.utcTextBox
    Friend WithEvents TxtMS_CM As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
