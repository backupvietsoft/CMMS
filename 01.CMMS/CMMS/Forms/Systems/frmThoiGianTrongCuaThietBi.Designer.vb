<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThoiGianTrongCuaThietBi
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
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnIN = New System.Windows.Forms.Button
        Me.grpDieuKienLoc = New System.Windows.Forms.GroupBox
        Me.cboThietBi = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblThietBi = New System.Windows.Forms.Label
        Me.dtTuNgay = New System.Windows.Forms.DateTimePicker
        Me.dtDenNgay = New System.Windows.Forms.DateTimePicker
        Me.cboLoaiTB = New Commons.UtcComboBox
        Me.lblDenNgay = New System.Windows.Forms.Label
        Me.lblTuNgay = New System.Windows.Forms.Label
        Me.lblBoPhan = New System.Windows.Forms.Label
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.grdDanhsachthoigiantrong = New System.Windows.Forms.DataGridView
        Me.grpDieuKienLoc.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhsachthoigiantrong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(552, 385)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 24)
        Me.btnThoat.TabIndex = 6
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnIN
        '
        Me.btnIN.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnIN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIN.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnIN.Location = New System.Drawing.Point(477, 385)
        Me.btnIN.Name = "btnIN"
        Me.btnIN.Size = New System.Drawing.Size(75, 24)
        Me.btnIN.TabIndex = 5
        Me.btnIN.Text = "In"
        Me.btnIN.UseVisualStyleBackColor = True
        '
        'grpDieuKienLoc
        '
        Me.grpDieuKienLoc.Controls.Add(Me.cboThietBi)
        Me.grpDieuKienLoc.Controls.Add(Me.lblThietBi)
        Me.grpDieuKienLoc.Controls.Add(Me.dtTuNgay)
        Me.grpDieuKienLoc.Controls.Add(Me.dtDenNgay)
        Me.grpDieuKienLoc.Controls.Add(Me.cboLoaiTB)
        Me.grpDieuKienLoc.Controls.Add(Me.lblDenNgay)
        Me.grpDieuKienLoc.Controls.Add(Me.lblTuNgay)
        Me.grpDieuKienLoc.Controls.Add(Me.lblBoPhan)
        Me.grpDieuKienLoc.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieuKienLoc.Location = New System.Drawing.Point(12, 40)
        Me.grpDieuKienLoc.Name = "grpDieuKienLoc"
        Me.grpDieuKienLoc.Size = New System.Drawing.Size(604, 63)
        Me.grpDieuKienLoc.TabIndex = 160
        Me.grpDieuKienLoc.TabStop = False
        Me.grpDieuKienLoc.Text = "Điều kiện lọc"
        '
        'cboThietBi
        '
        Me.cboThietBi.AssemblyName = ""
        Me.cboThietBi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboThietBi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboThietBi.BackColor = System.Drawing.Color.White
        Me.cboThietBi.ClassName = ""
        Me.cboThietBi.Display = ""
        Me.cboThietBi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboThietBi.FormattingEnabled = True
        Me.cboThietBi.IsAll = True
        Me.cboThietBi.IsNew = False
        Me.cboThietBi.ItemAll = " < ALL > "
        Me.cboThietBi.ItemNew = "...New"
        Me.cboThietBi.Location = New System.Drawing.Point(379, 15)
        Me.cboThietBi.MethodName = ""
        Me.cboThietBi.Name = "cboThietBi"
        Me.cboThietBi.Param = ""
        Me.cboThietBi.Size = New System.Drawing.Size(190, 21)
        Me.cboThietBi.StoreName = ""
        Me.cboThietBi.TabIndex = 2
        Me.cboThietBi.Table = Nothing
        Me.cboThietBi.TextReadonly = False
        Me.cboThietBi.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblThietBi
        '
        Me.lblThietBi.AutoSize = True
        Me.lblThietBi.ForeColor = System.Drawing.Color.Black
        Me.lblThietBi.Location = New System.Drawing.Point(294, 18)
        Me.lblThietBi.Name = "lblThietBi"
        Me.lblThietBi.Size = New System.Drawing.Size(42, 13)
        Me.lblThietBi.TabIndex = 163
        Me.lblThietBi.Text = "Thiết bị"
        '
        'dtTuNgay
        '
        Me.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTuNgay.Location = New System.Drawing.Point(98, 40)
        Me.dtTuNgay.Name = "dtTuNgay"
        Me.dtTuNgay.Size = New System.Drawing.Size(90, 21)
        Me.dtTuNgay.TabIndex = 3
        '
        'dtDenNgay
        '
        Me.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay.Location = New System.Drawing.Point(379, 40)
        Me.dtDenNgay.Name = "dtDenNgay"
        Me.dtDenNgay.Size = New System.Drawing.Size(90, 21)
        Me.dtDenNgay.TabIndex = 4
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.AssemblyName = ""
        Me.cboLoaiTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoaiTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoaiTB.BackColor = System.Drawing.Color.White
        Me.cboLoaiTB.ClassName = ""
        Me.cboLoaiTB.Display = ""
        Me.cboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.IsAll = False
        Me.cboLoaiTB.IsNew = False
        Me.cboLoaiTB.ItemAll = " < ALL > "
        Me.cboLoaiTB.ItemNew = "...New"
        Me.cboLoaiTB.Location = New System.Drawing.Point(98, 15)
        Me.cboLoaiTB.MethodName = ""
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Param = ""
        Me.cboLoaiTB.Size = New System.Drawing.Size(190, 21)
        Me.cboLoaiTB.StoreName = ""
        Me.cboLoaiTB.TabIndex = 1
        Me.cboLoaiTB.Table = Nothing
        Me.cboLoaiTB.TextReadonly = False
        Me.cboLoaiTB.Value = ""
        '
        'lblDenNgay
        '
        Me.lblDenNgay.AutoSize = True
        Me.lblDenNgay.ForeColor = System.Drawing.Color.Black
        Me.lblDenNgay.Location = New System.Drawing.Point(294, 44)
        Me.lblDenNgay.Name = "lblDenNgay"
        Me.lblDenNgay.Size = New System.Drawing.Size(54, 13)
        Me.lblDenNgay.TabIndex = 2
        Me.lblDenNgay.Text = "Đến ngày"
        '
        'lblTuNgay
        '
        Me.lblTuNgay.AutoSize = True
        Me.lblTuNgay.ForeColor = System.Drawing.Color.Black
        Me.lblTuNgay.Location = New System.Drawing.Point(34, 44)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(47, 13)
        Me.lblTuNgay.TabIndex = 1
        Me.lblTuNgay.Text = "Từ ngày"
        '
        'lblBoPhan
        '
        Me.lblBoPhan.AutoSize = True
        Me.lblBoPhan.ForeColor = System.Drawing.Color.Black
        Me.lblBoPhan.Location = New System.Drawing.Point(35, 18)
        Me.lblBoPhan.Name = "lblBoPhan"
        Me.lblBoPhan.Size = New System.Drawing.Size(46, 13)
        Me.lblBoPhan.TabIndex = 0
        Me.lblBoPhan.Text = "Bộ phận"
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(2, 8)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(625, 23)
        Me.lblTieuDe.TabIndex = 161
        Me.lblTieuDe.Text = "THỜI GIAN TRỐNG CỦA THIẾT BỊ"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDanhsachthoigiantrong
        '
        Me.grdDanhsachthoigiantrong.AllowUserToAddRows = False
        Me.grdDanhsachthoigiantrong.AllowUserToDeleteRows = False
        Me.grdDanhsachthoigiantrong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachthoigiantrong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachthoigiantrong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachthoigiantrong.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachthoigiantrong.Location = New System.Drawing.Point(12, 109)
        Me.grdDanhsachthoigiantrong.Name = "grdDanhsachthoigiantrong"
        Me.grdDanhsachthoigiantrong.ReadOnly = True
        Me.grdDanhsachthoigiantrong.Size = New System.Drawing.Size(604, 267)
        Me.grdDanhsachthoigiantrong.TabIndex = 162
        '
        'frmThoiGianTrongCuaThietBi
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 409)
        Me.Controls.Add(Me.grdDanhsachthoigiantrong)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.grpDieuKienLoc)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnIN)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmThoiGianTrongCuaThietBi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmThoiGianTrongCuaThietBi"
        Me.grpDieuKienLoc.ResumeLayout(False)
        Me.grpDieuKienLoc.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhsachthoigiantrong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnIN As System.Windows.Forms.Button
    Friend WithEvents grpDieuKienLoc As System.Windows.Forms.GroupBox
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB As Commons.UtcComboBox
    Friend WithEvents lblDenNgay As System.Windows.Forms.Label
    Friend WithEvents lblTuNgay As System.Windows.Forms.Label
    Friend WithEvents lblBoPhan As System.Windows.Forms.Label
    Friend WithEvents dtTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDanhsachthoigiantrong As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboThietBi As Commons.UtcComboBox
    Friend WithEvents lblThietBi As System.Windows.Forms.Label
End Class
