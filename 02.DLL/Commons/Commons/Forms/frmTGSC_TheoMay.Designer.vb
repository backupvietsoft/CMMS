<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTGSC_TheoMay
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
        Me.cboTheoLoaiMay = New System.Windows.Forms.ComboBox
        Me.cboTheoXuong = New System.Windows.Forms.ComboBox
        Me.radTheoLoaiMay = New System.Windows.Forms.RadioButton
        Me.radTheoXuong = New System.Windows.Forms.RadioButton
        Me.dgvShow = New System.Windows.Forms.DataGridView
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton
        Me.btnBoChon = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.lblCity = New System.Windows.Forms.Label
        Me.lblStreet = New System.Windows.Forms.Label
        Me.lblDistrict = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbStreet = New Commons.UtcComboBox
        Me.cmbDistrict = New Commons.UtcComboBox
        Me.cmbCity = New Commons.UtcComboBox
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTheoLoaiMay
        '
        Me.cboTheoLoaiMay.FormattingEnabled = True
        Me.cboTheoLoaiMay.Location = New System.Drawing.Point(428, 9)
        Me.cboTheoLoaiMay.Name = "cboTheoLoaiMay"
        Me.cboTheoLoaiMay.Size = New System.Drawing.Size(164, 21)
        Me.cboTheoLoaiMay.TabIndex = 4
        '
        'cboTheoXuong
        '
        Me.cboTheoXuong.FormattingEnabled = True
        Me.cboTheoXuong.Location = New System.Drawing.Point(119, 9)
        Me.cboTheoXuong.Name = "cboTheoXuong"
        Me.cboTheoXuong.Size = New System.Drawing.Size(164, 21)
        Me.cboTheoXuong.TabIndex = 5
        '
        'radTheoLoaiMay
        '
        Me.radTheoLoaiMay.AutoSize = True
        Me.radTheoLoaiMay.Location = New System.Drawing.Point(331, 10)
        Me.radTheoLoaiMay.Name = "radTheoLoaiMay"
        Me.radTheoLoaiMay.Size = New System.Drawing.Size(91, 17)
        Me.radTheoLoaiMay.TabIndex = 2
        Me.radTheoLoaiMay.TabStop = True
        Me.radTheoLoaiMay.Text = "Theo loại &máy"
        Me.radTheoLoaiMay.UseVisualStyleBackColor = True
        '
        'radTheoXuong
        '
        Me.radTheoXuong.AutoSize = True
        Me.radTheoXuong.Location = New System.Drawing.Point(33, 11)
        Me.radTheoXuong.Name = "radTheoXuong"
        Me.radTheoXuong.Size = New System.Drawing.Size(83, 17)
        Me.radTheoXuong.TabIndex = 3
        Me.radTheoXuong.TabStop = True
        Me.radTheoXuong.Text = "Theo &xưởng"
        Me.radTheoXuong.UseVisualStyleBackColor = True
        '
        'dgvShow
        '
        Me.dgvShow.AllowUserToAddRows = False
        Me.dgvShow.AllowUserToDeleteRows = False
        Me.dgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.dgvShow.Location = New System.Drawing.Point(11, 94)
        Me.dgvShow.Name = "dgvShow"
        Me.dgvShow.Size = New System.Drawing.Size(599, 306)
        Me.dgvShow.TabIndex = 6
        '
        'btnChonAll
        '
        Me.btnChonAll.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnChonAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChonAll.Location = New System.Drawing.Point(12, 410)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(107, 23)
        Me.btnChonAll.TabIndex = 7
        Me.btnChonAll.Text = "&Chọn tất cả"

        '
        'btnBoChon
        '
        Me.btnBoChon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBoChon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBoChon.Location = New System.Drawing.Point(125, 410)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(107, 23)
        Me.btnBoChon.TabIndex = 7
        Me.btnBoChon.Text = "&Bỏ chọn tất cả"

        '
        'btnThoat
        '
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(536, 410)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 9
        Me.btnThoat.Text = "Tho&át"

        '
        'btnThucHien
        '
        Me.btnThucHien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnThucHien.Location = New System.Drawing.Point(455, 410)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(75, 23)
        Me.btnThucHien.TabIndex = 8
        Me.btnThucHien.Text = "&Thực hiện"

        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(51, 41)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCity.TabIndex = 13
        Me.lblCity.Text = "Tỉnh"
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(51, 68)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(40, 13)
        Me.lblStreet.TabIndex = 14
        Me.lblStreet.Text = "Đường"
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Location = New System.Drawing.Point(349, 40)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(38, 13)
        Me.lblDistrict.TabIndex = 15
        Me.lblDistrict.Text = "Huyện"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.FillWeight = 81.47208!
        Me.DataGridViewTextBoxColumn1.HeaderText = "                               Mã số máy"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 361
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.FillWeight = 81.47208!
        Me.DataGridViewTextBoxColumn2.HeaderText = "                                 Nhóm máy"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 82
        '
        'cmbStreet
        '
        Me.cmbStreet.AssemblyName = ""
        Me.cmbStreet.BackColor = System.Drawing.Color.White
        Me.cmbStreet.ClassName = ""
        Me.cmbStreet.Display = ""
        Me.cmbStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStreet.ErrorProviderControl = Nothing
        Me.cmbStreet.FormattingEnabled = True
        Me.cmbStreet.IsAll = False
        Me.cmbStreet.isInputNull = False
        Me.cmbStreet.IsNew = False
        Me.cmbStreet.IsNull = True
        Me.cmbStreet.ItemAll = " < ALL > "
        Me.cmbStreet.ItemNew = "...New"
        Me.cmbStreet.Location = New System.Drawing.Point(119, 64)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(164, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 12
        Me.cmbStreet.Table = Nothing
        Me.cmbStreet.TextReadonly = False
        Me.cmbStreet.Value = ""
        '
        'cmbDistrict
        '
        Me.cmbDistrict.AssemblyName = ""
        Me.cmbDistrict.BackColor = System.Drawing.Color.White
        Me.cmbDistrict.ClassName = ""
        Me.cmbDistrict.Display = ""
        Me.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrict.ErrorProviderControl = Nothing
        Me.cmbDistrict.FormattingEnabled = True
        Me.cmbDistrict.IsAll = False
        Me.cmbDistrict.isInputNull = False
        Me.cmbDistrict.IsNew = False
        Me.cmbDistrict.IsNull = True
        Me.cmbDistrict.ItemAll = " < ALL > "
        Me.cmbDistrict.ItemNew = "...New"
        Me.cmbDistrict.Location = New System.Drawing.Point(428, 36)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(164, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 11
        Me.cmbDistrict.Table = Nothing
        Me.cmbDistrict.TextReadonly = False
        Me.cmbDistrict.Value = ""
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
        Me.cmbCity.ClassName = ""
        Me.cmbCity.Display = ""
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.ErrorProviderControl = Nothing
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.IsAll = False
        Me.cmbCity.isInputNull = False
        Me.cmbCity.IsNew = False
        Me.cmbCity.IsNull = True
        Me.cmbCity.ItemAll = " < ALL > "
        Me.cmbCity.ItemNew = "...New"
        Me.cmbCity.Location = New System.Drawing.Point(119, 37)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(164, 21)
        Me.cmbCity.StoreName = ""
        Me.cmbCity.TabIndex = 10
        Me.cmbCity.Table = Nothing
        Me.cmbCity.TextReadonly = False
        Me.cmbCity.Value = ""
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.FillWeight = 50.0!
        Me.Column3.HeaderText = "Chọn"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 38
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.FillWeight = 160.0!
        Me.Column1.HeaderText = "Mã số máy"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 83
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.FillWeight = 200.0!
        Me.Column2.HeaderText = "Nhóm máy"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 82
        '
        'frmTGSC_TheoMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 450)
        Me.Controls.Add(Me.lblDistrict)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.cmbStreet)
        Me.Controls.Add(Me.cmbDistrict)
        Me.Controls.Add(Me.cmbCity)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.btnBoChon)
        Me.Controls.Add(Me.btnChonAll)
        Me.Controls.Add(Me.dgvShow)
        Me.Controls.Add(Me.cboTheoLoaiMay)
        Me.Controls.Add(Me.cboTheoXuong)
        Me.Controls.Add(Me.radTheoLoaiMay)
        Me.Controls.Add(Me.radTheoXuong)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTGSC_TheoMay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn máy"
        CType(Me.dgvShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTheoLoaiMay As System.Windows.Forms.ComboBox
    Friend WithEvents cboTheoXuong As System.Windows.Forms.ComboBox
    Friend WithEvents radTheoLoaiMay As System.Windows.Forms.RadioButton
    Friend WithEvents radTheoXuong As System.Windows.Forms.RadioButton
    Friend WithEvents dgvShow As System.Windows.Forms.DataGridView
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
