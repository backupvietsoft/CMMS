<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNguyenNhanDungMay
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
        Me.lblTenNguyenhan = New System.Windows.Forms.Label()
        Me.GrdDanhmucnguyennhan = New System.Windows.Forms.DataGridView()
        Me.lblTieuDe = New System.Windows.Forms.Label()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhmucnguyennhan = New System.Windows.Forms.GroupBox()
        Me.GrpNhapnguyenhan = New System.Windows.Forms.GroupBox()
        Me.txtNguyennhan = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkMacDinh = New System.Windows.Forms.CheckBox()
        Me.chkBTDK = New System.Windows.Forms.CheckBox()
        Me.CHKHUHONG = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMS_NGUYEN_NHAN = New Commons.utcTextBox()
        CType(Me.GrdDanhmucnguyennhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDanhmucnguyennhan.SuspendLayout()
        Me.GrpNhapnguyenhan.SuspendLayout()
        CType(Me.txtNguyennhan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMS_NGUYEN_NHAN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTenNguyenhan
        '
        Me.lblTenNguyenhan.AutoSize = True
        Me.lblTenNguyenhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenNguyenhan.ForeColor = System.Drawing.Color.Black
        Me.lblTenNguyenhan.Location = New System.Drawing.Point(12, 28)
        Me.lblTenNguyenhan.Name = "lblTenNguyenhan"
        Me.lblTenNguyenhan.Size = New System.Drawing.Size(154, 14)
        Me.lblTenNguyenhan.TabIndex = 5
        Me.lblTenNguyenhan.Text = "Nguyên nhân dừng máy"
        '
        'GrdDanhmucnguyennhan
        '
        Me.GrdDanhmucnguyennhan.AllowUserToAddRows = False
        Me.GrdDanhmucnguyennhan.AllowUserToDeleteRows = False
        Me.GrdDanhmucnguyennhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhmucnguyennhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhmucnguyennhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhmucnguyennhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhmucnguyennhan.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhmucnguyennhan.Location = New System.Drawing.Point(3, 21)
        Me.GrdDanhmucnguyennhan.MultiSelect = False
        Me.GrdDanhmucnguyennhan.Name = "GrdDanhmucnguyennhan"
        Me.GrdDanhmucnguyennhan.ReadOnly = True
        Me.GrdDanhmucnguyennhan.RowHeadersWidth = 25
        Me.GrdDanhmucnguyennhan.ShowEditingIcon = False
        Me.GrdDanhmucnguyennhan.Size = New System.Drawing.Size(705, 270)
        Me.GrdDanhmucnguyennhan.TabIndex = 2
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.lblTieuDe.Location = New System.Drawing.Point(-1, 4)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(723, 33)
        Me.lblTieuDe.TabIndex = 60
        Me.lblTieuDe.Text = "NGUYÊN NHÂN DỪNG MÁY"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(410, 425)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 53
        Me.BtnSua.Text = "&Sửa"
        '
        'GrpDanhmucnguyennhan
        '
        Me.GrpDanhmucnguyennhan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhmucnguyennhan.Controls.Add(Me.GrdDanhmucnguyennhan)
        Me.GrpDanhmucnguyennhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucnguyennhan.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucnguyennhan.Location = New System.Drawing.Point(13, 125)
        Me.GrpDanhmucnguyennhan.Name = "GrpDanhmucnguyennhan"
        Me.GrpDanhmucnguyennhan.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.GrpDanhmucnguyennhan.Size = New System.Drawing.Size(711, 294)
        Me.GrpDanhmucnguyennhan.TabIndex = 59
        Me.GrpDanhmucnguyennhan.TabStop = False
        Me.GrpDanhmucnguyennhan.Text = "Danh mục nguyên nhân dừng máy"
        '
        'GrpNhapnguyenhan
        '
        Me.GrpNhapnguyenhan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapnguyenhan.Controls.Add(Me.txtNguyennhan)
        Me.GrpNhapnguyenhan.Controls.Add(Me.chkMacDinh)
        Me.GrpNhapnguyenhan.Controls.Add(Me.chkBTDK)
        Me.GrpNhapnguyenhan.Controls.Add(Me.CHKHUHONG)
        Me.GrpNhapnguyenhan.Controls.Add(Me.lblTenNguyenhan)
        Me.GrpNhapnguyenhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapnguyenhan.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapnguyenhan.Location = New System.Drawing.Point(12, 40)
        Me.GrpNhapnguyenhan.Name = "GrpNhapnguyenhan"
        Me.GrpNhapnguyenhan.Size = New System.Drawing.Size(712, 79)
        Me.GrpNhapnguyenhan.TabIndex = 58
        Me.GrpNhapnguyenhan.TabStop = False
        Me.GrpNhapnguyenhan.Text = "Nhập nguyên nhân dừng máy"
        '
        'txtNguyennhan
        '
        Me.txtNguyennhan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNguyennhan.EditValue = ""
        Me.txtNguyennhan.Location = New System.Drawing.Point(172, 25)
        Me.txtNguyennhan.Name = "txtNguyennhan"
        Me.txtNguyennhan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtNguyennhan.Size = New System.Drawing.Size(500, 20)
        Me.txtNguyennhan.TabIndex = 62
        '
        'chkMacDinh
        '
        Me.chkMacDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMacDinh.Location = New System.Drawing.Point(543, 51)
        Me.chkMacDinh.Name = "chkMacDinh"
        Me.chkMacDinh.Size = New System.Drawing.Size(129, 20)
        Me.chkMacDinh.TabIndex = 6
        Me.chkMacDinh.Text = "Bảo trì định kỳ"
        Me.chkMacDinh.UseVisualStyleBackColor = True
        '
        'chkBTDK
        '
        Me.chkBTDK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkBTDK.Location = New System.Drawing.Point(337, 51)
        Me.chkBTDK.Name = "chkBTDK"
        Me.chkBTDK.Size = New System.Drawing.Size(129, 20)
        Me.chkBTDK.TabIndex = 6
        Me.chkBTDK.Text = "Bảo trì định kỳ"
        Me.chkBTDK.UseVisualStyleBackColor = True
        '
        'CHKHUHONG
        '
        Me.CHKHUHONG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CHKHUHONG.Location = New System.Drawing.Point(114, 51)
        Me.CHKHUHONG.Name = "CHKHUHONG"
        Me.CHKHUHONG.Size = New System.Drawing.Size(169, 20)
        Me.CHKHUHONG.TabIndex = 6
        Me.CHKHUHONG.Text = "Hư hỏng"
        Me.CHKHUHONG.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(305, 425)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 52
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(515, 425)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 54
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(515, 425)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 56
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(620, 425)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 55
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(620, 425)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 57
        Me.BtnKhongghi.Text = "&Không"
        '
        'txtMS_NGUYEN_NHAN
        '
        Me.txtMS_NGUYEN_NHAN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMS_NGUYEN_NHAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMS_NGUYEN_NHAN.ErrorProviderControl = Me.ErrorProvider1
        Me.txtMS_NGUYEN_NHAN.FieldName = ""
        Me.txtMS_NGUYEN_NHAN.IsNull = True
        Me.txtMS_NGUYEN_NHAN.Location = New System.Drawing.Point(16, 6)
        Me.txtMS_NGUYEN_NHAN.MaxLength = 0
        Me.txtMS_NGUYEN_NHAN.Multiline = False
        Me.txtMS_NGUYEN_NHAN.Name = "txtMS_NGUYEN_NHAN"
        Me.txtMS_NGUYEN_NHAN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMS_NGUYEN_NHAN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMS_NGUYEN_NHAN.Properties.Appearance.Options.UseBackColor = True
        Me.txtMS_NGUYEN_NHAN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMS_NGUYEN_NHAN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMS_NGUYEN_NHAN.Properties.ReadOnly = True
        Me.txtMS_NGUYEN_NHAN.ReadOnly = True
        Me.txtMS_NGUYEN_NHAN.Size = New System.Drawing.Size(60, 20)
        Me.txtMS_NGUYEN_NHAN.TabIndex = 61
        Me.txtMS_NGUYEN_NHAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMS_NGUYEN_NHAN.TextTypeMode = Commons.TypeMode.None
        Me.txtMS_NGUYEN_NHAN.Visible = False
        '
        'frmNguyenNhanDungMay
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.txtMS_NGUYEN_NHAN)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.GrpDanhmucnguyennhan)
        Me.Controls.Add(Me.GrpNhapnguyenhan)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnGhi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmNguyenNhanDungMay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNguyenNhanDungMay"
        CType(Me.GrdDanhmucnguyennhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDanhmucnguyennhan.ResumeLayout(False)
        Me.GrpNhapnguyenhan.ResumeLayout(False)
        Me.GrpNhapnguyenhan.PerformLayout()
        CType(Me.txtNguyennhan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMS_NGUYEN_NHAN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTenNguyenhan As System.Windows.Forms.Label
    Friend WithEvents GrdDanhmucnguyennhan As System.Windows.Forms.DataGridView
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhmucnguyennhan As System.Windows.Forms.GroupBox
    Friend WithEvents GrpNhapnguyenhan As System.Windows.Forms.GroupBox
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMS_NGUYEN_NHAN As Commons.utcTextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CHKHUHONG As System.Windows.Forms.CheckBox
    Friend WithEvents chkBTDK As System.Windows.Forms.CheckBox
    Private WithEvents txtNguyennhan As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents chkMacDinh As CheckBox
End Class
