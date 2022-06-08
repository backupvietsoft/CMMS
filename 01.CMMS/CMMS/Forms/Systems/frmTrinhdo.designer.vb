<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrinhdo
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
        Me.lblTieude = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnSua = New System.Windows.Forms.Button
        Me.grpDanhmuctrinhdo = New System.Windows.Forms.GroupBox
        Me.grdDanhmuctrinhdo = New System.Windows.Forms.DataGridView
        Me.grpNhaptrinhdo = New System.Windows.Forms.GroupBox
        Me.txtTrinhdo = New Commons.utcTextBox
        Me.lblTrinhdo = New System.Windows.Forms.Label
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.txtMaso = New Commons.utcTextBox
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhmuctrinhdo.SuspendLayout()
        CType(Me.grdDanhmuctrinhdo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhaptrinhdo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(63, 5)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(275, 25)
        Me.lblTieude.TabIndex = 78
        Me.lblTieude.Text = "DANH MỤC TRÌNH ĐỘ"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnThem
        '
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(111, 259)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(69, 23)
        Me.BtnThem.TabIndex = 70
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(251, 259)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(69, 23)
        Me.BtnGhi.TabIndex = 74
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(321, 259)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(69, 23)
        Me.BtnKhongghi.TabIndex = 75
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(182, 259)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(69, 23)
        Me.BtnSua.TabIndex = 71
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'grpDanhmuctrinhdo
        '
        Me.grpDanhmuctrinhdo.Controls.Add(Me.grdDanhmuctrinhdo)
        Me.grpDanhmuctrinhdo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhmuctrinhdo.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhmuctrinhdo.Location = New System.Drawing.Point(9, 92)
        Me.grpDanhmuctrinhdo.Name = "grpDanhmuctrinhdo"
        Me.grpDanhmuctrinhdo.Size = New System.Drawing.Size(381, 162)
        Me.grpDanhmuctrinhdo.TabIndex = 77
        Me.grpDanhmuctrinhdo.TabStop = False
        Me.grpDanhmuctrinhdo.Text = "Danh mục trình độ"
        '
        'grdDanhmuctrinhdo
        '
        Me.grdDanhmuctrinhdo.AllowUserToAddRows = False
        Me.grdDanhmuctrinhdo.AllowUserToDeleteRows = False
        Me.grdDanhmuctrinhdo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDanhmuctrinhdo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhmuctrinhdo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhmuctrinhdo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhmuctrinhdo.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhmuctrinhdo.MultiSelect = False
        Me.grdDanhmuctrinhdo.Name = "grdDanhmuctrinhdo"
        Me.grdDanhmuctrinhdo.ReadOnly = True
        Me.grdDanhmuctrinhdo.RowHeadersWidth = 25
        Me.grdDanhmuctrinhdo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grdDanhmuctrinhdo.ShowEditingIcon = False
        Me.grdDanhmuctrinhdo.Size = New System.Drawing.Size(375, 141)
        Me.grdDanhmuctrinhdo.TabIndex = 2
        '
        'grpNhaptrinhdo
        '
        Me.grpNhaptrinhdo.Controls.Add(Me.txtTrinhdo)
        Me.grpNhaptrinhdo.Controls.Add(Me.lblTrinhdo)
        Me.grpNhaptrinhdo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhaptrinhdo.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhaptrinhdo.Location = New System.Drawing.Point(82, 39)
        Me.grpNhaptrinhdo.Name = "grpNhaptrinhdo"
        Me.grpNhaptrinhdo.Size = New System.Drawing.Size(236, 47)
        Me.grpNhaptrinhdo.TabIndex = 76
        Me.grpNhaptrinhdo.TabStop = False
        Me.grpNhaptrinhdo.Text = "Nhập trình độ"
        '
        'txtTrinhdo
        '
        Me.txtTrinhdo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTrinhdo.BackColor = System.Drawing.Color.White
        Me.txtTrinhdo.ErrorProviderControl = Me.ErrorProvider
        Me.txtTrinhdo.FieldName = ""
        Me.txtTrinhdo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrinhdo.IsNull = False
        Me.txtTrinhdo.Location = New System.Drawing.Point(72, 19)
        Me.txtTrinhdo.MaxLength = 20
        Me.txtTrinhdo.Name = "txtTrinhdo"
        Me.txtTrinhdo.Size = New System.Drawing.Size(154, 22)
        Me.txtTrinhdo.TabIndex = 1
        Me.txtTrinhdo.TextTypeMode = Commons.TypeMode.None
        '
        'lblTrinhdo
        '
        Me.lblTrinhdo.AutoSize = True
        Me.lblTrinhdo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrinhdo.ForeColor = System.Drawing.Color.Black
        Me.lblTrinhdo.Location = New System.Drawing.Point(10, 21)
        Me.lblTrinhdo.Name = "lblTrinhdo"
        Me.lblTrinhdo.Size = New System.Drawing.Size(58, 14)
        Me.lblTrinhdo.TabIndex = 5
        Me.lblTrinhdo.Text = "Trình độ"
        '
        'BtnThoat
        '
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(321, 259)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(69, 23)
        Me.BtnThoat.TabIndex = 73
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(251, 259)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(69, 23)
        Me.BtnXoa.TabIndex = 72
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'txtMaso
        '
        Me.txtMaso.BackColor = System.Drawing.Color.White
        Me.txtMaso.ErrorProviderControl = Me.ErrorProvider
        Me.txtMaso.FieldName = ""
        Me.txtMaso.IsNull = True
        Me.txtMaso.Location = New System.Drawing.Point(30, 53)
        Me.txtMaso.Name = "txtMaso"
        Me.txtMaso.Size = New System.Drawing.Size(16, 21)
        Me.txtMaso.TabIndex = 79
        Me.txtMaso.TextTypeMode = Commons.TypeMode.None
        Me.txtMaso.Visible = False
        '
        'frmTrinhdo
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 287)
        Me.Controls.Add(Me.lblTieude)
        Me.Controls.Add(Me.txtMaso)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.grpDanhmuctrinhdo)
        Me.Controls.Add(Me.grpNhaptrinhdo)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmTrinhdo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục trình độ"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhmuctrinhdo.ResumeLayout(False)
        CType(Me.grdDanhmuctrinhdo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhaptrinhdo.ResumeLayout(False)
        Me.grpNhaptrinhdo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMaso As Commons.utcTextBox
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents grpDanhmuctrinhdo As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhmuctrinhdo As System.Windows.Forms.DataGridView
    Friend WithEvents grpNhaptrinhdo As System.Windows.Forms.GroupBox
    Friend WithEvents txtTrinhdo As Commons.utcTextBox
    Friend WithEvents lblTrinhdo As System.Windows.Forms.Label
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
End Class
