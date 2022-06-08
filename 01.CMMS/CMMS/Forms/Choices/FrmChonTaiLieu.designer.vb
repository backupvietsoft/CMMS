<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonTaiLieu
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
        Me.lblTieude = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabNguoisudung = New System.Windows.Forms.TabPage
        Me.grpDanhsachtailieunsd = New System.Windows.Forms.GroupBox
        Me.grdDanhsachtailieunsd = New System.Windows.Forms.DataGridView
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.grpDanhsachyeucau = New System.Windows.Forms.GroupBox
        Me.grdDanhsachyeucau = New System.Windows.Forms.DataGridView
        Me.BtnXemTL1 = New System.Windows.Forms.Button
        Me.BtnThucHien = New System.Windows.Forms.Button
        Me.dtDenngay_nsd = New System.Windows.Forms.DateTimePicker
        Me.dtTungay_nsd = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.LblTungay_nsd = New System.Windows.Forms.Label
        Me.TabGiamsattinhtrang = New System.Windows.Forms.TabPage
        Me.grpDanhsachtailieugiamsat = New System.Windows.Forms.GroupBox
        Me.grdDanhsachtailieugiamsat = New System.Windows.Forms.DataGridView
        Me.BtnThoat2 = New System.Windows.Forms.Button
        Me.BtnXemTL = New System.Windows.Forms.Button
        Me.BtnThuchien2 = New System.Windows.Forms.Button
        Me.grpDanhsachgiamsattinhtrang = New System.Windows.Forms.GroupBox
        Me.grdDanhsachgiamsattinhtrang = New System.Windows.Forms.DataGridView
        Me.dtDenngay_gstt = New System.Windows.Forms.DateTimePicker
        Me.dtTungay_gstt = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay_gstt = New System.Windows.Forms.Label
        Me.lblTungay_gstt = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabNguoisudung.SuspendLayout()
        Me.grpDanhsachtailieunsd.SuspendLayout()
        CType(Me.grdDanhsachtailieunsd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachyeucau.SuspendLayout()
        CType(Me.grdDanhsachyeucau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGiamsattinhtrang.SuspendLayout()
        Me.grpDanhsachtailieugiamsat.SuspendLayout()
        CType(Me.grdDanhsachtailieugiamsat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachgiamsattinhtrang.SuspendLayout()
        CType(Me.grdDanhsachgiamsattinhtrang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.lblTieude.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(96, -2)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(627, 39)
        Me.lblTieude.TabIndex = 48
        Me.lblTieude.Text = "CHỌN TÀI LIỆU "
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabNguoisudung)
        Me.TabControl1.Controls.Add(Me.TabGiamsattinhtrang)
        Me.TabControl1.Location = New System.Drawing.Point(3, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(786, 482)
        Me.TabControl1.TabIndex = 49
        '
        'TabNguoisudung
        '
        Me.TabNguoisudung.Controls.Add(Me.grpDanhsachtailieunsd)
        Me.TabNguoisudung.Controls.Add(Me.BtnThoat)
        Me.TabNguoisudung.Controls.Add(Me.grpDanhsachyeucau)
        Me.TabNguoisudung.Controls.Add(Me.BtnXemTL1)
        Me.TabNguoisudung.Controls.Add(Me.BtnThucHien)
        Me.TabNguoisudung.Controls.Add(Me.dtDenngay_nsd)
        Me.TabNguoisudung.Controls.Add(Me.dtTungay_nsd)
        Me.TabNguoisudung.Controls.Add(Me.lblDenngay)
        Me.TabNguoisudung.Controls.Add(Me.LblTungay_nsd)
        Me.TabNguoisudung.Location = New System.Drawing.Point(4, 22)
        Me.TabNguoisudung.Name = "TabNguoisudung"
        Me.TabNguoisudung.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNguoisudung.Size = New System.Drawing.Size(778, 456)
        Me.TabNguoisudung.TabIndex = 0
        Me.TabNguoisudung.Text = "Chọn từ yêu cầu NSD"
        Me.TabNguoisudung.UseVisualStyleBackColor = True
        '
        'grpDanhsachtailieunsd
        '
        Me.grpDanhsachtailieunsd.Controls.Add(Me.grdDanhsachtailieunsd)
        Me.grpDanhsachtailieunsd.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachtailieunsd.Location = New System.Drawing.Point(474, 55)
        Me.grpDanhsachtailieunsd.Name = "grpDanhsachtailieunsd"
        Me.grpDanhsachtailieunsd.Size = New System.Drawing.Size(299, 353)
        Me.grpDanhsachtailieunsd.TabIndex = 87
        Me.grpDanhsachtailieunsd.TabStop = False
        Me.grpDanhsachtailieunsd.Text = "Danh sách tài liệu "
        '
        'grdDanhsachtailieunsd
        '
        Me.grdDanhsachtailieunsd.AllowUserToAddRows = False
        Me.grdDanhsachtailieunsd.AllowUserToDeleteRows = False
        Me.grdDanhsachtailieunsd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDanhsachtailieunsd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachtailieunsd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachtailieunsd.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachtailieunsd.Name = "grdDanhsachtailieunsd"
        Me.grdDanhsachtailieunsd.Size = New System.Drawing.Size(293, 333)
        Me.grdDanhsachtailieunsd.TabIndex = 0
        '
        'BtnThoat
        '
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(696, 423)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 86
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'grpDanhsachyeucau
        '
        Me.grpDanhsachyeucau.Controls.Add(Me.grdDanhsachyeucau)
        Me.grpDanhsachyeucau.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachyeucau.Location = New System.Drawing.Point(10, 56)
        Me.grpDanhsachyeucau.Name = "grpDanhsachyeucau"
        Me.grpDanhsachyeucau.Size = New System.Drawing.Size(458, 392)
        Me.grpDanhsachyeucau.TabIndex = 31
        Me.grpDanhsachyeucau.TabStop = False
        Me.grpDanhsachyeucau.Text = "Danh sách tài liệu "
        '
        'grdDanhsachyeucau
        '
        Me.grdDanhsachyeucau.AllowUserToAddRows = False
        Me.grdDanhsachyeucau.AllowUserToDeleteRows = False
        Me.grdDanhsachyeucau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDanhsachyeucau.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachyeucau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachyeucau.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachyeucau.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachyeucau.Name = "grdDanhsachyeucau"
        Me.grdDanhsachyeucau.Size = New System.Drawing.Size(452, 372)
        Me.grdDanhsachyeucau.TabIndex = 30
        '
        'BtnXemTL1
        '
        Me.BtnXemTL1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXemTL1.ForeColor = System.Drawing.Color.Teal
        Me.BtnXemTL1.Location = New System.Drawing.Point(477, 423)
        Me.BtnXemTL1.Name = "BtnXemTL1"
        Me.BtnXemTL1.Size = New System.Drawing.Size(130, 25)
        Me.BtnXemTL1.TabIndex = 85
        Me.BtnXemTL1.Text = "Xem tài liệu"
        Me.BtnXemTL1.UseVisualStyleBackColor = True
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThucHien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThucHien.Location = New System.Drawing.Point(608, 423)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(88, 25)
        Me.BtnThucHien.TabIndex = 85
        Me.BtnThucHien.Text = "Thực hiện"
        Me.BtnThucHien.UseVisualStyleBackColor = True
        '
        'dtDenngay_nsd
        '
        Me.dtDenngay_nsd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenngay_nsd.Location = New System.Drawing.Point(450, 18)
        Me.dtDenngay_nsd.Name = "dtDenngay_nsd"
        Me.dtDenngay_nsd.Size = New System.Drawing.Size(130, 21)
        Me.dtDenngay_nsd.TabIndex = 29
        '
        'dtTungay_nsd
        '
        Me.dtTungay_nsd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTungay_nsd.Location = New System.Drawing.Point(217, 18)
        Me.dtTungay_nsd.Name = "dtTungay_nsd"
        Me.dtTungay_nsd.Size = New System.Drawing.Size(130, 21)
        Me.dtTungay_nsd.TabIndex = 29
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenngay.Location = New System.Drawing.Point(369, 22)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(56, 13)
        Me.lblDenngay.TabIndex = 28
        Me.lblDenngay.Text = "Đến ngày "
        '
        'LblTungay_nsd
        '
        Me.LblTungay_nsd.AutoSize = True
        Me.LblTungay_nsd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTungay_nsd.Location = New System.Drawing.Point(78, 22)
        Me.LblTungay_nsd.Name = "LblTungay_nsd"
        Me.LblTungay_nsd.Size = New System.Drawing.Size(133, 13)
        Me.LblTungay_nsd.TabIndex = 28
        Me.LblTungay_nsd.Text = "Yêu cầu được lập từ ngày "
        '
        'TabGiamsattinhtrang
        '
        Me.TabGiamsattinhtrang.Controls.Add(Me.grpDanhsachtailieugiamsat)
        Me.TabGiamsattinhtrang.Controls.Add(Me.BtnThoat2)
        Me.TabGiamsattinhtrang.Controls.Add(Me.BtnXemTL)
        Me.TabGiamsattinhtrang.Controls.Add(Me.BtnThuchien2)
        Me.TabGiamsattinhtrang.Controls.Add(Me.grpDanhsachgiamsattinhtrang)
        Me.TabGiamsattinhtrang.Controls.Add(Me.dtDenngay_gstt)
        Me.TabGiamsattinhtrang.Controls.Add(Me.dtTungay_gstt)
        Me.TabGiamsattinhtrang.Controls.Add(Me.lblDenngay_gstt)
        Me.TabGiamsattinhtrang.Controls.Add(Me.lblTungay_gstt)
        Me.TabGiamsattinhtrang.Location = New System.Drawing.Point(4, 22)
        Me.TabGiamsattinhtrang.Name = "TabGiamsattinhtrang"
        Me.TabGiamsattinhtrang.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGiamsattinhtrang.Size = New System.Drawing.Size(778, 456)
        Me.TabGiamsattinhtrang.TabIndex = 1
        Me.TabGiamsattinhtrang.Text = "Chọn từ GSTT"
        Me.TabGiamsattinhtrang.UseVisualStyleBackColor = True
        '
        'grpDanhsachtailieugiamsat
        '
        Me.grpDanhsachtailieugiamsat.Controls.Add(Me.grdDanhsachtailieugiamsat)
        Me.grpDanhsachtailieugiamsat.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachtailieugiamsat.Location = New System.Drawing.Point(473, 51)
        Me.grpDanhsachtailieugiamsat.Name = "grpDanhsachtailieugiamsat"
        Me.grpDanhsachtailieugiamsat.Size = New System.Drawing.Size(299, 353)
        Me.grpDanhsachtailieugiamsat.TabIndex = 92
        Me.grpDanhsachtailieugiamsat.TabStop = False
        Me.grpDanhsachtailieugiamsat.Text = "Danh sách tài liệu "
        '
        'grdDanhsachtailieugiamsat
        '
        Me.grdDanhsachtailieugiamsat.AllowUserToAddRows = False
        Me.grdDanhsachtailieugiamsat.AllowUserToDeleteRows = False
        Me.grdDanhsachtailieugiamsat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDanhsachtailieugiamsat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachtailieugiamsat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachtailieugiamsat.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachtailieugiamsat.Name = "grdDanhsachtailieugiamsat"
        Me.grdDanhsachtailieugiamsat.Size = New System.Drawing.Size(293, 333)
        Me.grdDanhsachtailieugiamsat.TabIndex = 0
        '
        'BtnThoat2
        '
        Me.BtnThoat2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat2.Location = New System.Drawing.Point(695, 418)
        Me.BtnThoat2.Name = "BtnThoat2"
        Me.BtnThoat2.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat2.TabIndex = 91
        Me.BtnThoat2.Text = "T&hoát"
        Me.BtnThoat2.UseVisualStyleBackColor = True
        '
        'BtnXemTL
        '
        Me.BtnXemTL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXemTL.ForeColor = System.Drawing.Color.Teal
        Me.BtnXemTL.Location = New System.Drawing.Point(477, 418)
        Me.BtnXemTL.Name = "BtnXemTL"
        Me.BtnXemTL.Size = New System.Drawing.Size(130, 25)
        Me.BtnXemTL.TabIndex = 90
        Me.BtnXemTL.Text = "Xem tài liệu"
        Me.BtnXemTL.UseVisualStyleBackColor = True
        '
        'BtnThuchien2
        '
        Me.BtnThuchien2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThuchien2.ForeColor = System.Drawing.Color.Blue
        Me.BtnThuchien2.Location = New System.Drawing.Point(607, 418)
        Me.BtnThuchien2.Name = "BtnThuchien2"
        Me.BtnThuchien2.Size = New System.Drawing.Size(88, 25)
        Me.BtnThuchien2.TabIndex = 89
        Me.BtnThuchien2.Text = "Thực hiện"
        Me.BtnThuchien2.UseVisualStyleBackColor = True
        '
        'grpDanhsachgiamsattinhtrang
        '
        Me.grpDanhsachgiamsattinhtrang.Controls.Add(Me.grdDanhsachgiamsattinhtrang)
        Me.grpDanhsachgiamsattinhtrang.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachgiamsattinhtrang.Location = New System.Drawing.Point(8, 51)
        Me.grpDanhsachgiamsattinhtrang.Name = "grpDanhsachgiamsattinhtrang"
        Me.grpDanhsachgiamsattinhtrang.Size = New System.Drawing.Size(459, 392)
        Me.grpDanhsachgiamsattinhtrang.TabIndex = 35
        Me.grpDanhsachgiamsattinhtrang.TabStop = False
        Me.grpDanhsachgiamsattinhtrang.Text = "Danh sách tài liệu "
        '
        'grdDanhsachgiamsattinhtrang
        '
        Me.grdDanhsachgiamsattinhtrang.AllowUserToAddRows = False
        Me.grdDanhsachgiamsattinhtrang.AllowUserToDeleteRows = False
        Me.grdDanhsachgiamsattinhtrang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.grdDanhsachgiamsattinhtrang.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachgiamsattinhtrang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachgiamsattinhtrang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachgiamsattinhtrang.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachgiamsattinhtrang.Name = "grdDanhsachgiamsattinhtrang"
        Me.grdDanhsachgiamsattinhtrang.Size = New System.Drawing.Size(453, 372)
        Me.grdDanhsachgiamsattinhtrang.TabIndex = 30
        '
        'dtDenngay_gstt
        '
        Me.dtDenngay_gstt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenngay_gstt.Location = New System.Drawing.Point(448, 15)
        Me.dtDenngay_gstt.Name = "dtDenngay_gstt"
        Me.dtDenngay_gstt.Size = New System.Drawing.Size(130, 21)
        Me.dtDenngay_gstt.TabIndex = 34
        '
        'dtTungay_gstt
        '
        Me.dtTungay_gstt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTungay_gstt.Location = New System.Drawing.Point(215, 15)
        Me.dtTungay_gstt.Name = "dtTungay_gstt"
        Me.dtTungay_gstt.Size = New System.Drawing.Size(130, 21)
        Me.dtTungay_gstt.TabIndex = 33
        '
        'lblDenngay_gstt
        '
        Me.lblDenngay_gstt.AutoSize = True
        Me.lblDenngay_gstt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenngay_gstt.Location = New System.Drawing.Point(364, 19)
        Me.lblDenngay_gstt.Name = "lblDenngay_gstt"
        Me.lblDenngay_gstt.Size = New System.Drawing.Size(55, 13)
        Me.lblDenngay_gstt.TabIndex = 32
        Me.lblDenngay_gstt.Text = "đến ngày "
        '
        'lblTungay_gstt
        '
        Me.lblTungay_gstt.AutoSize = True
        Me.lblTungay_gstt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTungay_gstt.Location = New System.Drawing.Point(76, 19)
        Me.lblTungay_gstt.Name = "lblTungay_gstt"
        Me.lblTungay_gstt.Size = New System.Drawing.Size(117, 13)
        Me.lblTungay_gstt.TabIndex = 32
        Me.lblTungay_gstt.Text = "Phiếu giám sát từ ngày "
        '
        'FrmChonTaiLieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTieude)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmChonTaiLieu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmChonTaiLieu"
        Me.TabControl1.ResumeLayout(False)
        Me.TabNguoisudung.ResumeLayout(False)
        Me.TabNguoisudung.PerformLayout()
        Me.grpDanhsachtailieunsd.ResumeLayout(False)
        CType(Me.grdDanhsachtailieunsd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachyeucau.ResumeLayout(False)
        CType(Me.grdDanhsachyeucau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGiamsattinhtrang.ResumeLayout(False)
        Me.TabGiamsattinhtrang.PerformLayout()
        Me.grpDanhsachtailieugiamsat.ResumeLayout(False)
        CType(Me.grdDanhsachtailieugiamsat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachgiamsattinhtrang.ResumeLayout(False)
        CType(Me.grdDanhsachgiamsattinhtrang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabNguoisudung As System.Windows.Forms.TabPage
    Friend WithEvents grpDanhsachtailieunsd As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachtailieunsd As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents grpDanhsachyeucau As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachyeucau As System.Windows.Forms.DataGridView
    Friend WithEvents BtnXemTL1 As System.Windows.Forms.Button
    Friend WithEvents BtnThucHien As System.Windows.Forms.Button
    Friend WithEvents dtDenngay_nsd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTungay_nsd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents LblTungay_nsd As System.Windows.Forms.Label
    Friend WithEvents TabGiamsattinhtrang As System.Windows.Forms.TabPage
    Friend WithEvents grpDanhsachtailieugiamsat As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachtailieugiamsat As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat2 As System.Windows.Forms.Button
    Friend WithEvents BtnXemTL As System.Windows.Forms.Button
    Friend WithEvents BtnThuchien2 As System.Windows.Forms.Button
    Friend WithEvents grpDanhsachgiamsattinhtrang As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachgiamsattinhtrang As System.Windows.Forms.DataGridView
    Friend WithEvents dtDenngay_gstt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTungay_gstt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay_gstt As System.Windows.Forms.Label
    Friend WithEvents lblTungay_gstt As System.Windows.Forms.Label
End Class
