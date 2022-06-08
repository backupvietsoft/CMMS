<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonDichVuThueNgoaiChoPBT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LblTieudechukyBTPN = New System.Windows.Forms.Label
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.lblTungay = New System.Windows.Forms.Label
        Me.dgrDanhSachDV = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpDanhsachdichvu = New System.Windows.Forms.GroupBox
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgrDanhSachDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachdichvu.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTieudechukyBTPN
        '
        Me.LblTieudechukyBTPN.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudechukyBTPN.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudechukyBTPN.Location = New System.Drawing.Point(105, 9)
        Me.LblTieudechukyBTPN.Name = "LblTieudechukyBTPN"
        Me.LblTieudechukyBTPN.Size = New System.Drawing.Size(590, 29)
        Me.LblTieudechukyBTPN.TabIndex = 30
        Me.LblTieudechukyBTPN.Text = "CHỌN DỊCH VỤ CHO ROA"
        Me.LblTieudechukyBTPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTieudechukyBTPN.UseCompatibleTextRendering = True
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNgay.Location = New System.Drawing.Point(501, 56)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(132, 21)
        Me.dtpDenNgay.TabIndex = 34
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenngay.ForeColor = System.Drawing.Color.Black
        Me.lblDenngay.Location = New System.Drawing.Point(443, 60)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(52, 13)
        Me.lblDenngay.TabIndex = 33
        Me.lblDenngay.Text = "đến ngày"
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgay.Location = New System.Drawing.Point(305, 56)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(132, 21)
        Me.dtpTuNgay.TabIndex = 35
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTungay.ForeColor = System.Drawing.Color.Black
        Me.lblTungay.Location = New System.Drawing.Point(196, 60)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(108, 13)
        Me.lblTungay.TabIndex = 32
        Me.lblTungay.Text = "Được duyệt từ ngày "
        '
        'dgrDanhSachDV
        '
        Me.dgrDanhSachDV.AllowUserToAddRows = False
        Me.dgrDanhSachDV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dgrDanhSachDV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrDanhSachDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrDanhSachDV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgrDanhSachDV.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgrDanhSachDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrDanhSachDV.Location = New System.Drawing.Point(3, 17)
        Me.dgrDanhSachDV.Name = "dgrDanhSachDV"
        Me.dgrDanhSachDV.Size = New System.Drawing.Size(762, 376)
        Me.dgrDanhSachDV.TabIndex = 36
        '
        'Column5
        '
        Me.Column5.HeaderText = "Chọn"
        Me.Column5.Name = "Column5"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Số ROA"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Mô tả dịch vụ"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Nhà cung cấp"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 170
        '
        'Column4
        '
        Me.Column4.HeaderText = "Thời hạn thực hiện "
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 150
        '
        'grpDanhsachdichvu
        '
        Me.grpDanhsachdichvu.Controls.Add(Me.dgrDanhSachDV)
        Me.grpDanhsachdichvu.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachdichvu.Location = New System.Drawing.Point(12, 92)
        Me.grpDanhsachdichvu.Name = "grpDanhsachdichvu"
        Me.grpDanhsachdichvu.Size = New System.Drawing.Size(768, 396)
        Me.grpDanhsachdichvu.TabIndex = 37
        Me.grpDanhsachdichvu.TabStop = False
        Me.grpDanhsachdichvu.Text = "Danh sách dịch vụ"
        '
        'btnThucHien
        '
        Me.btnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThucHien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.Color.Blue
        Me.btnThucHien.Location = New System.Drawing.Point(591, 504)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(97, 27)
        Me.btnThucHien.TabIndex = 39
        Me.btnThucHien.Text = "Thực hiện "
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.ForeColor = System.Drawing.Color.Black
        Me.btnThoat.Location = New System.Drawing.Point(689, 504)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(91, 27)
        Me.btnThoat.TabIndex = 38
        Me.btnThoat.Text = "T&hoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Số ROA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Mô tả dịch vụ"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nhà cung cấp"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 170
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Thời hạn thực hiện "
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'FrmChonDichVuThueNgoaiChoPBT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 535)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.grpDanhsachdichvu)
        Me.Controls.Add(Me.dtpDenNgay)
        Me.Controls.Add(Me.lblDenngay)
        Me.Controls.Add(Me.dtpTuNgay)
        Me.Controls.Add(Me.lblTungay)
        Me.Controls.Add(Me.LblTieudechukyBTPN)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmChonDichVuThueNgoaiChoPBT"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmChonDichVuThueNgoaiChoPBT"
        CType(Me.dgrDanhSachDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachdichvu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTieudechukyBTPN As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents dgrDanhSachDV As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachdichvu As System.Windows.Forms.GroupBox
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
