<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeHoachTongTheAtt
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
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.LblMaSoThietBiBTDK = New System.Windows.Forms.Label
        Me.LblNhomThietBiBTDK = New System.Windows.Forms.Label
        Me.lblLoaiThietBiBTDK = New System.Windows.Forms.Label
        Me.lblNguoiLap = New System.Windows.Forms.Label
        Me.LblThongBao = New System.Windows.Forms.Label
        Me.dtpDenNgayBTDK1 = New System.Windows.Forms.MaskedTextBox
        Me.lblDenNgayBTDK = New System.Windows.Forms.Label
        Me.BtnLapPBT = New System.Windows.Forms.Button
        Me.BtnThoatBTDK = New System.Windows.Forms.Button
        Me.grdDanhsachBTDKcanthuchien = New System.Windows.Forms.DataGridView
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboNguoiLap = New Commons.UtcComboBox
        Me.CboMaSoThietBiBTDK = New Commons.UtcComboBox
        Me.CboNhomThietBiBTDK = New Commons.UtcComboBox
        Me.cboLoaiThietBiBTDK = New Commons.UtcComboBox
        Me.prgBTDK = New System.Windows.Forms.ProgressBar
        CType(Me.grdDanhsachBTDKcanthuchien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(9, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(611, 29)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "BẢO TRÌ ĐỊNH KỲ"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMaSoThietBiBTDK
        '
        Me.LblMaSoThietBiBTDK.AutoSize = True
        Me.LblMaSoThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.LblMaSoThietBiBTDK.Location = New System.Drawing.Point(433, 46)
        Me.LblMaSoThietBiBTDK.Name = "LblMaSoThietBiBTDK"
        Me.LblMaSoThietBiBTDK.Size = New System.Drawing.Size(71, 13)
        Me.LblMaSoThietBiBTDK.TabIndex = 29
        Me.LblMaSoThietBiBTDK.Text = "Mã số thiết bị"
        '
        'LblNhomThietBiBTDK
        '
        Me.LblNhomThietBiBTDK.AutoSize = True
        Me.LblNhomThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.LblNhomThietBiBTDK.Location = New System.Drawing.Point(212, 46)
        Me.LblNhomThietBiBTDK.Name = "LblNhomThietBiBTDK"
        Me.LblNhomThietBiBTDK.Size = New System.Drawing.Size(70, 13)
        Me.LblNhomThietBiBTDK.TabIndex = 28
        Me.LblNhomThietBiBTDK.Text = "Nhóm thiết bị"
        '
        'lblLoaiThietBiBTDK
        '
        Me.lblLoaiThietBiBTDK.AutoSize = True
        Me.lblLoaiThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.lblLoaiThietBiBTDK.Location = New System.Drawing.Point(1, 46)
        Me.lblLoaiThietBiBTDK.Name = "lblLoaiThietBiBTDK"
        Me.lblLoaiThietBiBTDK.Size = New System.Drawing.Size(62, 13)
        Me.lblLoaiThietBiBTDK.TabIndex = 27
        Me.lblLoaiThietBiBTDK.Text = "Loại thiết bị"
        '
        'lblNguoiLap
        '
        Me.lblNguoiLap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNguoiLap.ForeColor = System.Drawing.Color.Black
        Me.lblNguoiLap.Location = New System.Drawing.Point(406, 77)
        Me.lblNguoiLap.Name = "lblNguoiLap"
        Me.lblNguoiLap.Size = New System.Drawing.Size(96, 13)
        Me.lblNguoiLap.TabIndex = 50
        Me.lblNguoiLap.Text = "Người lập"
        Me.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblThongBao
        '
        Me.LblThongBao.AutoSize = True
        Me.LblThongBao.ForeColor = System.Drawing.Color.Navy
        Me.LblThongBao.Location = New System.Drawing.Point(11, 90)
        Me.LblThongBao.Name = "LblThongBao"
        Me.LblThongBao.Size = New System.Drawing.Size(195, 13)
        Me.LblThongBao.TabIndex = 47
        Me.LblThongBao.Text = "Nhấn Enter sau mỗi lần nhập đến ngày "
        '
        'dtpDenNgayBTDK1
        '
        Me.dtpDenNgayBTDK1.Location = New System.Drawing.Point(298, 69)
        Me.dtpDenNgayBTDK1.Mask = "00/00/0000"
        Me.dtpDenNgayBTDK1.Name = "dtpDenNgayBTDK1"
        Me.dtpDenNgayBTDK1.Size = New System.Drawing.Size(75, 21)
        Me.dtpDenNgayBTDK1.TabIndex = 48
        Me.dtpDenNgayBTDK1.ValidatingType = GetType(Date)
        '
        'lblDenNgayBTDK
        '
        Me.lblDenNgayBTDK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenNgayBTDK.ForeColor = System.Drawing.Color.Maroon
        Me.lblDenNgayBTDK.Location = New System.Drawing.Point(11, 73)
        Me.lblDenNgayBTDK.Name = "lblDenNgayBTDK"
        Me.lblDenNgayBTDK.Size = New System.Drawing.Size(238, 17)
        Me.lblDenNgayBTDK.TabIndex = 46
        Me.lblDenNgayBTDK.Text = "Bảo trì định kỳ cần thực hiện đến ngày "
        '
        'BtnLapPBT
        '
        Me.BtnLapPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLapPBT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLapPBT.ForeColor = System.Drawing.Color.Maroon
        Me.BtnLapPBT.Location = New System.Drawing.Point(441, 440)
        Me.BtnLapPBT.Name = "BtnLapPBT"
        Me.BtnLapPBT.Size = New System.Drawing.Size(103, 27)
        Me.BtnLapPBT.TabIndex = 52
        Me.BtnLapPBT.Text = "Lập &phiếu BT"
        Me.BtnLapPBT.UseVisualStyleBackColor = True
        '
        'BtnThoatBTDK
        '
        Me.BtnThoatBTDK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoatBTDK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoatBTDK.Location = New System.Drawing.Point(544, 440)
        Me.BtnThoatBTDK.Name = "BtnThoatBTDK"
        Me.BtnThoatBTDK.Size = New System.Drawing.Size(103, 27)
        Me.BtnThoatBTDK.TabIndex = 51
        Me.BtnThoatBTDK.Text = "T&hoát"
        Me.BtnThoatBTDK.UseVisualStyleBackColor = True
        '
        'grdDanhsachBTDKcanthuchien
        '
        Me.grdDanhsachBTDKcanthuchien.AllowUserToAddRows = False
        Me.grdDanhsachBTDKcanthuchien.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachBTDKcanthuchien.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachBTDKcanthuchien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachBTDKcanthuchien.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(1, 110)
        Me.grdDanhsachBTDKcanthuchien.Name = "grdDanhsachBTDKcanthuchien"
        Me.grdDanhsachBTDKcanthuchien.RowHeadersWidth = 25
        Me.grdDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(644, 302)
        Me.grdDanhsachBTDKcanthuchien.TabIndex = 53
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboNguoiLap
        '
        Me.cboNguoiLap.AssemblyName = ""
        Me.cboNguoiLap.BackColor = System.Drawing.Color.White
        Me.cboNguoiLap.ClassName = ""
        Me.cboNguoiLap.Display = ""
        Me.cboNguoiLap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNguoiLap.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNguoiLap.FormattingEnabled = True
        Me.cboNguoiLap.IsAll = False
        Me.cboNguoiLap.IsNew = False
        Me.cboNguoiLap.ItemAll = " < ALL > "
        Me.cboNguoiLap.ItemNew = "...New"
        Me.cboNguoiLap.Location = New System.Drawing.Point(508, 73)
        Me.cboNguoiLap.MethodName = ""
        Me.cboNguoiLap.Name = "cboNguoiLap"
        Me.cboNguoiLap.Param = ""
        Me.cboNguoiLap.Size = New System.Drawing.Size(137, 21)
        Me.cboNguoiLap.StoreName = ""
        Me.cboNguoiLap.TabIndex = 49
        Me.cboNguoiLap.Table = Nothing
        Me.cboNguoiLap.TextReadonly = False
        Me.cboNguoiLap.Value = ""
        '
        'CboMaSoThietBiBTDK
        '
        Me.CboMaSoThietBiBTDK.AssemblyName = ""
        Me.CboMaSoThietBiBTDK.BackColor = System.Drawing.Color.White
        Me.CboMaSoThietBiBTDK.ClassName = ""
        Me.CboMaSoThietBiBTDK.Display = ""
        Me.CboMaSoThietBiBTDK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMaSoThietBiBTDK.ErrorProviderControl = Me.ErrorProvider1
        Me.CboMaSoThietBiBTDK.FormattingEnabled = True
        Me.CboMaSoThietBiBTDK.IsAll = True
        Me.CboMaSoThietBiBTDK.IsNew = False
        Me.CboMaSoThietBiBTDK.ItemAll = " < ALL > "
        Me.CboMaSoThietBiBTDK.ItemNew = "...New"
        Me.CboMaSoThietBiBTDK.Location = New System.Drawing.Point(534, 41)
        Me.CboMaSoThietBiBTDK.MethodName = ""
        Me.CboMaSoThietBiBTDK.Name = "CboMaSoThietBiBTDK"
        Me.CboMaSoThietBiBTDK.Param = ""
        Me.CboMaSoThietBiBTDK.Size = New System.Drawing.Size(111, 21)
        Me.CboMaSoThietBiBTDK.StoreName = ""
        Me.CboMaSoThietBiBTDK.TabIndex = 32
        Me.CboMaSoThietBiBTDK.Table = Nothing
        Me.CboMaSoThietBiBTDK.TextReadonly = False
        Me.CboMaSoThietBiBTDK.Value = ""
        '
        'CboNhomThietBiBTDK
        '
        Me.CboNhomThietBiBTDK.AssemblyName = ""
        Me.CboNhomThietBiBTDK.BackColor = System.Drawing.Color.White
        Me.CboNhomThietBiBTDK.ClassName = ""
        Me.CboNhomThietBiBTDK.Display = ""
        Me.CboNhomThietBiBTDK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNhomThietBiBTDK.ErrorProviderControl = Me.ErrorProvider1
        Me.CboNhomThietBiBTDK.FormattingEnabled = True
        Me.CboNhomThietBiBTDK.IsAll = True
        Me.CboNhomThietBiBTDK.IsNew = False
        Me.CboNhomThietBiBTDK.ItemAll = " < ALL > "
        Me.CboNhomThietBiBTDK.ItemNew = "...New"
        Me.CboNhomThietBiBTDK.Location = New System.Drawing.Point(298, 43)
        Me.CboNhomThietBiBTDK.MethodName = ""
        Me.CboNhomThietBiBTDK.Name = "CboNhomThietBiBTDK"
        Me.CboNhomThietBiBTDK.Param = ""
        Me.CboNhomThietBiBTDK.Size = New System.Drawing.Size(129, 21)
        Me.CboNhomThietBiBTDK.StoreName = ""
        Me.CboNhomThietBiBTDK.TabIndex = 31
        Me.CboNhomThietBiBTDK.Table = Nothing
        Me.CboNhomThietBiBTDK.TextReadonly = False
        Me.CboNhomThietBiBTDK.Value = ""
        '
        'cboLoaiThietBiBTDK
        '
        Me.cboLoaiThietBiBTDK.AssemblyName = ""
        Me.cboLoaiThietBiBTDK.BackColor = System.Drawing.Color.White
        Me.cboLoaiThietBiBTDK.ClassName = ""
        Me.cboLoaiThietBiBTDK.Display = ""
        Me.cboLoaiThietBiBTDK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiThietBiBTDK.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiThietBiBTDK.FormattingEnabled = True
        Me.cboLoaiThietBiBTDK.IsAll = False
        Me.cboLoaiThietBiBTDK.IsNew = False
        Me.cboLoaiThietBiBTDK.ItemAll = " < ALL > "
        Me.cboLoaiThietBiBTDK.ItemNew = "...New"
        Me.cboLoaiThietBiBTDK.Location = New System.Drawing.Point(75, 41)
        Me.cboLoaiThietBiBTDK.MethodName = ""
        Me.cboLoaiThietBiBTDK.Name = "cboLoaiThietBiBTDK"
        Me.cboLoaiThietBiBTDK.Param = ""
        Me.cboLoaiThietBiBTDK.Size = New System.Drawing.Size(131, 21)
        Me.cboLoaiThietBiBTDK.StoreName = ""
        Me.cboLoaiThietBiBTDK.TabIndex = 30
        Me.cboLoaiThietBiBTDK.Table = Nothing
        Me.cboLoaiThietBiBTDK.TextReadonly = False
        Me.cboLoaiThietBiBTDK.Value = ""
        '
        'prgBTDK
        '
        Me.prgBTDK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgBTDK.Location = New System.Drawing.Point(1, 418)
        Me.prgBTDK.Maximum = 1000000
        Me.prgBTDK.Name = "prgBTDK"
        Me.prgBTDK.Size = New System.Drawing.Size(644, 16)
        Me.prgBTDK.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBTDK.TabIndex = 54
        '
        'frmKeHoachTongTheAtt
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 467)
        Me.Controls.Add(Me.prgBTDK)
        Me.Controls.Add(Me.grdDanhsachBTDKcanthuchien)
        Me.Controls.Add(Me.BtnLapPBT)
        Me.Controls.Add(Me.BtnThoatBTDK)
        Me.Controls.Add(Me.lblNguoiLap)
        Me.Controls.Add(Me.cboNguoiLap)
        Me.Controls.Add(Me.LblThongBao)
        Me.Controls.Add(Me.dtpDenNgayBTDK1)
        Me.Controls.Add(Me.lblDenNgayBTDK)
        Me.Controls.Add(Me.CboMaSoThietBiBTDK)
        Me.Controls.Add(Me.CboNhomThietBiBTDK)
        Me.Controls.Add(Me.cboLoaiThietBiBTDK)
        Me.Controls.Add(Me.LblMaSoThietBiBTDK)
        Me.Controls.Add(Me.LblNhomThietBiBTDK)
        Me.Controls.Add(Me.lblLoaiThietBiBTDK)
        Me.Controls.Add(Me.lblTieuDe)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmKeHoachTongTheAtt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmKeHoachTongTheAtt"
        CType(Me.grdDanhsachBTDKcanthuchien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents CboMaSoThietBiBTDK As Commons.UtcComboBox
    Friend WithEvents CboNhomThietBiBTDK As Commons.UtcComboBox
    Friend WithEvents cboLoaiThietBiBTDK As Commons.UtcComboBox
    Friend WithEvents LblMaSoThietBiBTDK As System.Windows.Forms.Label
    Friend WithEvents LblNhomThietBiBTDK As System.Windows.Forms.Label
    Friend WithEvents lblLoaiThietBiBTDK As System.Windows.Forms.Label
    Friend WithEvents lblNguoiLap As System.Windows.Forms.Label
    Friend WithEvents cboNguoiLap As Commons.UtcComboBox
    Friend WithEvents LblThongBao As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgayBTDK1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDenNgayBTDK As System.Windows.Forms.Label
    Friend WithEvents BtnLapPBT As System.Windows.Forms.Button
    Friend WithEvents BtnThoatBTDK As System.Windows.Forms.Button
    Friend WithEvents grdDanhsachBTDKcanthuchien As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents prgBTDK As System.Windows.Forms.ProgressBar
End Class
