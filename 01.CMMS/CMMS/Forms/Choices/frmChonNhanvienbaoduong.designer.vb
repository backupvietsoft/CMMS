<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonNhanvienbaoduong
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
        Me.lblTieude = New System.Windows.Forms.Label
        Me.grpDanhsachnhanvien = New System.Windows.Forms.GroupBox
        Me.grdDanhsachnhanvien = New System.Windows.Forms.DataGridView
        Me.MS_CONG_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HO_TEN_CONG_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SO_GIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnThuchien = New System.Windows.Forms.Button
        Me.lblDonvi = New System.Windows.Forms.Label
        Me.lblBan = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboBan = New Commons.UtcComboBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboDonVi = New Commons.UtcComboBox
        Me.grpDanhsachnhanvien.SuspendLayout()
        CType(Me.grdDanhsachnhanvien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(2, 5)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(586, 39)
        Me.lblTieude.TabIndex = 0
        Me.lblTieude.Text = "CHỌN NHÂN VIÊN CHO CÔNG VIỆC BẢO DƯỠNG"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDanhsachnhanvien
        '
        Me.grpDanhsachnhanvien.Controls.Add(Me.grdDanhsachnhanvien)
        Me.grpDanhsachnhanvien.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachnhanvien.Location = New System.Drawing.Point(5, 88)
        Me.grpDanhsachnhanvien.Name = "grpDanhsachnhanvien"
        Me.grpDanhsachnhanvien.Size = New System.Drawing.Size(582, 257)
        Me.grpDanhsachnhanvien.TabIndex = 1
        Me.grpDanhsachnhanvien.TabStop = False
        Me.grpDanhsachnhanvien.Text = "Danh sách nhân viên"
        '
        'grdDanhsachnhanvien
        '
        Me.grdDanhsachnhanvien.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachnhanvien.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachnhanvien.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_CONG_NHAN, Me.HO_TEN_CONG_NHAN, Me.SO_GIO})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachnhanvien.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachnhanvien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachnhanvien.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachnhanvien.Name = "grdDanhsachnhanvien"
        Me.grdDanhsachnhanvien.RowHeadersWidth = 25
        Me.grdDanhsachnhanvien.Size = New System.Drawing.Size(576, 237)
        Me.grdDanhsachnhanvien.TabIndex = 0
        '
        'MS_CONG_NHAN
        '
        Me.MS_CONG_NHAN.FillWeight = 104.6092!
        Me.MS_CONG_NHAN.HeaderText = "Mã công nhân"
        Me.MS_CONG_NHAN.Name = "MS_CONG_NHAN"
        Me.MS_CONG_NHAN.ReadOnly = True
        Me.MS_CONG_NHAN.Width = 182
        '
        'HO_TEN_CONG_NHAN
        '
        Me.HO_TEN_CONG_NHAN.FillWeight = 160.3654!
        Me.HO_TEN_CONG_NHAN.HeaderText = "Họ tên"
        Me.HO_TEN_CONG_NHAN.Name = "HO_TEN_CONG_NHAN"
        Me.HO_TEN_CONG_NHAN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.HO_TEN_CONG_NHAN.Width = 182
        '
        'SO_GIO
        '
        Me.SO_GIO.FillWeight = 35.02538!
        Me.SO_GIO.HeaderText = "Số giờ"
        Me.SO_GIO.Name = "SO_GIO"
        Me.SO_GIO.Width = 182
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Black
        Me.BtnThoat.Location = New System.Drawing.Point(500, 355)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThuchien
        '
        Me.BtnThuchien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThuchien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThuchien.Location = New System.Drawing.Point(419, 355)
        Me.BtnThuchien.Name = "BtnThuchien"
        Me.BtnThuchien.Size = New System.Drawing.Size(81, 25)
        Me.BtnThuchien.TabIndex = 7
        Me.BtnThuchien.Text = "Thực hiện"
        Me.BtnThuchien.UseVisualStyleBackColor = True
        '
        'lblDonvi
        '
        Me.lblDonvi.Location = New System.Drawing.Point(40, 58)
        Me.lblDonvi.Name = "lblDonvi"
        Me.lblDonvi.Size = New System.Drawing.Size(81, 13)
        Me.lblDonvi.TabIndex = 11
        Me.lblDonvi.Text = "Ban"
        Me.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBan
        '
        Me.lblBan.Location = New System.Drawing.Point(279, 55)
        Me.lblBan.Name = "lblBan"
        Me.lblBan.Size = New System.Drawing.Size(94, 18)
        Me.lblBan.TabIndex = 12
        Me.lblBan.Text = "Đơn vị"
        Me.lblBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 104.6092!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Mã công nhân"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 190
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 160.3654!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Họ tên"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.Width = 292
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 35.02538!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Số giờ"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 64
        '
        'cboBan
        '
        Me.cboBan.AssemblyName = ""
        Me.cboBan.BackColor = System.Drawing.Color.White
        Me.cboBan.ClassName = ""
        Me.cboBan.Display = ""
        Me.cboBan.ErrorProviderControl = Me.ErrorProvider
        Me.cboBan.FormattingEnabled = True
        Me.cboBan.IsAll = False
        Me.cboBan.IsNew = False
        Me.cboBan.ItemAll = " < ALL > "
        Me.cboBan.ItemNew = "...New"
        Me.cboBan.Location = New System.Drawing.Point(379, 55)
        Me.cboBan.MethodName = ""
        Me.cboBan.Name = "cboBan"
        Me.cboBan.Param = ""
        Me.cboBan.Size = New System.Drawing.Size(121, 21)
        Me.cboBan.StoreName = ""
        Me.cboBan.TabIndex = 10
        Me.cboBan.Table = Nothing
        Me.cboBan.TextReadonly = False
        Me.cboBan.Value = ""
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'cboDonVi
        '
        Me.cboDonVi.AssemblyName = ""
        Me.cboDonVi.BackColor = System.Drawing.Color.White
        Me.cboDonVi.ClassName = ""
        Me.cboDonVi.Display = ""
        Me.cboDonVi.ErrorProviderControl = Me.ErrorProvider
        Me.cboDonVi.FormattingEnabled = True
        Me.cboDonVi.IsAll = False
        Me.cboDonVi.IsNew = False
        Me.cboDonVi.ItemAll = " < ALL > "
        Me.cboDonVi.ItemNew = "...New"
        Me.cboDonVi.Location = New System.Drawing.Point(127, 55)
        Me.cboDonVi.MethodName = ""
        Me.cboDonVi.Name = "cboDonVi"
        Me.cboDonVi.Param = ""
        Me.cboDonVi.Size = New System.Drawing.Size(121, 21)
        Me.cboDonVi.StoreName = ""
        Me.cboDonVi.TabIndex = 9
        Me.cboDonVi.Table = Nothing
        Me.cboDonVi.TextReadonly = False
        Me.cboDonVi.Value = ""
        '
        'frmChonNhanvienbaoduong
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 386)
        Me.Controls.Add(Me.lblBan)
        Me.Controls.Add(Me.lblDonvi)
        Me.Controls.Add(Me.cboBan)
        Me.Controls.Add(Me.cboDonVi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnThuchien)
        Me.Controls.Add(Me.grpDanhsachnhanvien)
        Me.Controls.Add(Me.lblTieude)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonNhanvienbaoduong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonNhanvienbaoduong"
        Me.grpDanhsachnhanvien.ResumeLayout(False)
        CType(Me.grdDanhsachnhanvien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachnhanvien As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachnhanvien As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThuchien As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_CONG_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HO_TEN_CONG_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SO_GIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDonVi As Commons.UtcComboBox
    Friend WithEvents cboBan As Commons.UtcComboBox
    Friend WithEvents lblDonvi As System.Windows.Forms.Label
    Friend WithEvents lblBan As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
