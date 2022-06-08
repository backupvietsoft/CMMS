<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCachdathang
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
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblcachDH = New System.Windows.Forms.Label()
        Me.BtnGhi = New System.Windows.Forms.Button()
        Me.BtnKhongghi = New System.Windows.Forms.Button()
        Me.BtnSua = New System.Windows.Forms.Button()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnXoa = New System.Windows.Forms.Button()
        Me.grpDanhsachcachDH = New System.Windows.Forms.GroupBox()
        Me.grdDanhsachcachDH = New System.Windows.Forms.DataGridView()
        Me.grpNhapcachDH = New System.Windows.Forms.GroupBox()
        Me.txtTencachDH = New Commons.utcTextBox()
        Me.BtnThem = New System.Windows.Forms.Button()
        Me.lblTieudecachdathang = New System.Windows.Forms.Label()
        Me.txtMasocachDH = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachcachDH.SuspendLayout()
        CType(Me.grdDanhsachcachDH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTencachDH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMasocachDH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblcachDH
        '
        Me.lblcachDH.AutoSize = True
        Me.lblcachDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblcachDH.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcachDH.ForeColor = System.Drawing.Color.Black
        Me.lblcachDH.Location = New System.Drawing.Point(3, 35)
        Me.lblcachDH.Name = "lblcachDH"
        Me.lblcachDH.Size = New System.Drawing.Size(114, 28)
        Me.lblcachDH.TabIndex = 5
        Me.lblcachDH.Text = "Cách đặt hàng"
        Me.lblcachDH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnGhi
        '
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnGhi.Location = New System.Drawing.Point(300, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 26)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(381, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 26)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSua.Location = New System.Drawing.Point(543, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 26)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(705, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 26)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnXoa.Location = New System.Drawing.Point(624, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 26)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'grpDanhsachcachDH
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachcachDH, 2)
        Me.grpDanhsachcachDH.Controls.Add(Me.grdDanhsachcachDH)
        Me.grpDanhsachcachDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachcachDH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachcachDH.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachcachDH.Location = New System.Drawing.Point(3, 66)
        Me.grpDanhsachcachDH.Name = "grpDanhsachcachDH"
        Me.grpDanhsachcachDH.Size = New System.Drawing.Size(786, 421)
        Me.grpDanhsachcachDH.TabIndex = 76
        Me.grpDanhsachcachDH.TabStop = False
        Me.grpDanhsachcachDH.Text = "Danh sách cách đặt hàng"
        '
        'grdDanhsachcachDH
        '
        Me.grdDanhsachcachDH.AllowUserToAddRows = False
        Me.grdDanhsachcachDH.AllowUserToDeleteRows = False
        Me.grdDanhsachcachDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachcachDH.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachcachDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachcachDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachcachDH.GridColor = System.Drawing.SystemColors.InactiveBorder
        Me.grdDanhsachcachDH.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachcachDH.MultiSelect = False
        Me.grdDanhsachcachDH.Name = "grdDanhsachcachDH"
        Me.grdDanhsachcachDH.ReadOnly = True
        Me.grdDanhsachcachDH.RowHeadersWidth = 25
        Me.grdDanhsachcachDH.ShowEditingIcon = False
        Me.grdDanhsachcachDH.Size = New System.Drawing.Size(780, 400)
        Me.grdDanhsachcachDH.TabIndex = 4
        '
        'grpNhapcachDH
        '
        Me.grpNhapcachDH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapcachDH.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapcachDH.Location = New System.Drawing.Point(46, 54)
        Me.grpNhapcachDH.Name = "grpNhapcachDH"
        Me.grpNhapcachDH.Size = New System.Drawing.Size(508, 52)
        Me.grpNhapcachDH.TabIndex = 75
        Me.grpNhapcachDH.TabStop = False
        Me.grpNhapcachDH.Text = "Nhập cách đặt hàng"
        '
        'txtTencachDH
        '
        Me.txtTencachDH.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTencachDH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTencachDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTencachDH.ErrorProviderControl = Me.ErrorProvider
        Me.txtTencachDH.FieldName = ""
        Me.txtTencachDH.IsNull = False
        Me.txtTencachDH.Location = New System.Drawing.Point(123, 38)
        Me.txtTencachDH.MaxLength = 0
        Me.txtTencachDH.Multiline = False
        Me.txtTencachDH.Name = "txtTencachDH"
        Me.txtTencachDH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTencachDH.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTencachDH.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTencachDH.Properties.Appearance.Options.UseBackColor = True
        Me.txtTencachDH.Properties.Appearance.Options.UseFont = True
        Me.txtTencachDH.ReadOnly = True
        Me.txtTencachDH.Size = New System.Drawing.Size(666, 21)
        Me.txtTencachDH.TabIndex = 1
        Me.txtTencachDH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTencachDH.TextTypeMode = Commons.TypeMode.None
        '
        'BtnThem
        '
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThem.Location = New System.Drawing.Point(462, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 26)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'lblTieudecachdathang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieudecachdathang, 2)
        Me.lblTieudecachdathang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudecachdathang.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieudecachdathang.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieudecachdathang.Location = New System.Drawing.Point(3, 0)
        Me.lblTieudecachdathang.Name = "lblTieudecachdathang"
        Me.lblTieudecachdathang.Size = New System.Drawing.Size(786, 35)
        Me.lblTieudecachdathang.TabIndex = 84
        Me.lblTieudecachdathang.Text = "PURCHASING METHOD"
        Me.lblTieudecachdathang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMasocachDH
        '
        Me.txtMasocachDH.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMasocachDH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMasocachDH.ErrorProviderControl = Me.ErrorProvider
        Me.txtMasocachDH.FieldName = ""
        Me.txtMasocachDH.IsNull = True
        Me.txtMasocachDH.Location = New System.Drawing.Point(12, 56)
        Me.txtMasocachDH.MaxLength = 0
        Me.txtMasocachDH.Multiline = False
        Me.txtMasocachDH.Name = "txtMasocachDH"
        Me.txtMasocachDH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMasocachDH.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMasocachDH.Properties.Appearance.Options.UseBackColor = True
        Me.txtMasocachDH.ReadOnly = True
        Me.txtMasocachDH.Size = New System.Drawing.Size(14, 20)
        Me.txtMasocachDH.TabIndex = 82
        Me.txtMasocachDH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMasocachDH.TextTypeMode = Commons.TypeMode.None
        Me.txtMasocachDH.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTencachDH, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudecachdathang, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblcachDH, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachcachDH, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(792, 522)
        Me.TableLayoutPanel1.TabIndex = 85
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 493)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 26)
        Me.Panel1.TabIndex = 85
        '
        'frmCachdathang
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 522)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.grpNhapcachDH)
        Me.Controls.Add(Me.txtMasocachDH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "frmCachdathang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cách đặt hàng"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachcachDH.ResumeLayout(False)
        CType(Me.grdDanhsachcachDH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTencachDH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMasocachDH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents grpDanhsachcachDH As System.Windows.Forms.GroupBox
    Friend WithEvents grpNhapcachDH As System.Windows.Forms.GroupBox
    Friend WithEvents txtTencachDH As Commons.utcTextBox
    Friend WithEvents lblcachDH As System.Windows.Forms.Label
    Friend WithEvents txtMasocachDH As Commons.utcTextBox
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents grdDanhsachcachDH As System.Windows.Forms.DataGridView
    Friend WithEvents lblTieudecachdathang As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
