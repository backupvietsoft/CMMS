<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonPTDeXuat_CS
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblLoaivattu = New System.Windows.Forms.Label
        Me.lblLOAI_PHU_TUNG = New System.Windows.Forms.Label
        Me.lblLOAI_THIET_BI = New System.Windows.Forms.Label
        Me.lblTimPT = New System.Windows.Forms.Label
        Me.btnBoChon = New DevExpress.XtraEditors.SimpleButton
        Me.btnChon = New DevExpress.XtraEditors.SimpleButton
        Me.btnTrove = New DevExpress.XtraEditors.SimpleButton
        Me.btnThuchien = New DevExpress.XtraEditors.SimpleButton
        Me.rdbTatCa = New System.Windows.Forms.RadioButton
        Me.rdbSLMinNhoHonHT = New System.Windows.Forms.RadioButton
        Me.txtTimPT = New Commons.utcTextBox
        Me.cboLOAI_THIET_BI = New Commons.UtcComboBox
        Me.utcComboLoaiVT = New Commons.UtcComboBox
        Me.cboLOAI_PHU_TUNG = New Commons.UtcComboBox
        Me.grdChonPT = New Commons.QLGrid
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLTON = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TON_TOI_THIEU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NGAY_CUOI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbaTimTen = New System.Windows.Forms.Label
        Me.txtTimTen = New System.Windows.Forms.TextBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChonPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(198, 6)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(538, 28)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "CHỌN PHỤ TÙNG"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblLoaivattu
        '
        Me.lblLoaivattu.AutoSize = True
        Me.lblLoaivattu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoaivattu.Location = New System.Drawing.Point(5, 76)
        Me.lblLoaivattu.Name = "lblLoaivattu"
        Me.lblLoaivattu.Size = New System.Drawing.Size(66, 14)
        Me.lblLoaivattu.TabIndex = 52
        Me.lblLoaivattu.Text = "Loại vật tư"
        '
        'lblLOAI_PHU_TUNG
        '
        Me.lblLOAI_PHU_TUNG.AutoSize = True
        Me.lblLOAI_PHU_TUNG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOAI_PHU_TUNG.Location = New System.Drawing.Point(263, 76)
        Me.lblLOAI_PHU_TUNG.Name = "lblLOAI_PHU_TUNG"
        Me.lblLOAI_PHU_TUNG.Size = New System.Drawing.Size(111, 14)
        Me.lblLOAI_PHU_TUNG.TabIndex = 51
        Me.lblLOAI_PHU_TUNG.Text = "Nơi sử dụng vật tư"
        '
        'lblLOAI_THIET_BI
        '
        Me.lblLOAI_THIET_BI.AutoSize = True
        Me.lblLOAI_THIET_BI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOAI_THIET_BI.Location = New System.Drawing.Point(566, 76)
        Me.lblLOAI_THIET_BI.Name = "lblLOAI_THIET_BI"
        Me.lblLOAI_THIET_BI.Size = New System.Drawing.Size(90, 14)
        Me.lblLOAI_THIET_BI.TabIndex = 50
        Me.lblLOAI_THIET_BI.Text = "Loại thiết bị SD"
        '
        'lblTimPT
        '
        Me.lblTimPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTimPT.Location = New System.Drawing.Point(5, 489)
        Me.lblTimPT.Name = "lblTimPT"
        Me.lblTimPT.Size = New System.Drawing.Size(81, 18)
        Me.lblTimPT.TabIndex = 58
        Me.lblTimPT.Text = "Tìm mã vật tư"
        Me.lblTimPT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnBoChon
        '
        Me.btnBoChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBoChon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoChon.ForeColor = System.Drawing.Color.Blue
        Me.btnBoChon.Location = New System.Drawing.Point(528, 480)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(110, 27)
        Me.btnBoChon.TabIndex = 57
        Me.btnBoChon.Text = "Bỏ chọn tất cả"
        
        Me.btnBoChon.Visible = False
        '
        'btnChon
        '
        Me.btnChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChon.ForeColor = System.Drawing.Color.Blue
        Me.btnChon.Location = New System.Drawing.Point(432, 480)
        Me.btnChon.Name = "btnChon"
        Me.btnChon.Size = New System.Drawing.Size(90, 27)
        Me.btnChon.TabIndex = 56
        Me.btnChon.Text = "Chọn tất cả"
        
        Me.btnChon.Visible = False
        '
        'btnTrove
        '
        Me.btnTrove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTrove.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrove.ForeColor = System.Drawing.Color.Black
        Me.btnTrove.Location = New System.Drawing.Point(764, 482)
        Me.btnTrove.Name = "btnTrove"
        Me.btnTrove.Size = New System.Drawing.Size(90, 27)
        Me.btnTrove.TabIndex = 61
        Me.btnTrove.Text = "Thoát"

        '
        'btnThuchien
        '
        Me.btnThuchien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThuchien.ForeColor = System.Drawing.Color.Maroon
        Me.btnThuchien.Location = New System.Drawing.Point(673, 482)
        Me.btnThuchien.Name = "btnThuchien"
        Me.btnThuchien.Size = New System.Drawing.Size(90, 27)
        Me.btnThuchien.TabIndex = 60
        Me.btnThuchien.Text = "Thực hiện"
        
        '
        'rdbTatCa
        '
        Me.rdbTatCa.AutoSize = True
        Me.rdbTatCa.Location = New System.Drawing.Point(23, 6)
        Me.rdbTatCa.Name = "rdbTatCa"
        Me.rdbTatCa.Size = New System.Drawing.Size(90, 17)
        Me.rdbTatCa.TabIndex = 62
        Me.rdbTatCa.Text = "RadioButton1"
        Me.rdbTatCa.UseVisualStyleBackColor = True
        '
        'rdbSLMinNhoHonHT
        '
        Me.rdbSLMinNhoHonHT.AutoSize = True
        Me.rdbSLMinNhoHonHT.Checked = True
        Me.rdbSLMinNhoHonHT.Location = New System.Drawing.Point(23, 29)
        Me.rdbSLMinNhoHonHT.Name = "rdbSLMinNhoHonHT"
        Me.rdbSLMinNhoHonHT.Size = New System.Drawing.Size(90, 17)
        Me.rdbSLMinNhoHonHT.TabIndex = 63
        Me.rdbSLMinNhoHonHT.TabStop = True
        Me.rdbSLMinNhoHonHT.Text = "RadioButton1"
        Me.rdbSLMinNhoHonHT.UseVisualStyleBackColor = True
        '
        'txtTimPT
        '
        Me.txtTimPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTimPT.BackColor = System.Drawing.Color.White
        Me.txtTimPT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTimPT.FieldName = ""
        Me.txtTimPT.IsNull = True
        Me.txtTimPT.Location = New System.Drawing.Point(92, 486)
        Me.txtTimPT.Name = "txtTimPT"
        Me.txtTimPT.Size = New System.Drawing.Size(100, 21)
        Me.txtTimPT.TabIndex = 59
        Me.txtTimPT.TextTypeMode = Commons.TypeMode.None
        '
        'cboLOAI_THIET_BI
        '
        Me.cboLOAI_THIET_BI.AssemblyName = ""
        Me.cboLOAI_THIET_BI.BackColor = System.Drawing.Color.White
        Me.cboLOAI_THIET_BI.ClassName = ""
        Me.cboLOAI_THIET_BI.Display = ""
        Me.cboLOAI_THIET_BI.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLOAI_THIET_BI.FormattingEnabled = True
        Me.cboLOAI_THIET_BI.IsAll = True
        Me.cboLOAI_THIET_BI.IsNew = False
        Me.cboLOAI_THIET_BI.ItemAll = " < ALL > "
        Me.cboLOAI_THIET_BI.ItemNew = "...New"
        Me.cboLOAI_THIET_BI.Location = New System.Drawing.Point(679, 69)
        Me.cboLOAI_THIET_BI.MethodName = ""
        Me.cboLOAI_THIET_BI.Name = "cboLOAI_THIET_BI"
        Me.cboLOAI_THIET_BI.Param = ""
        Me.cboLOAI_THIET_BI.Size = New System.Drawing.Size(169, 21)
        Me.cboLOAI_THIET_BI.StoreName = ""
        Me.cboLOAI_THIET_BI.TabIndex = 55
        Me.cboLOAI_THIET_BI.Table = Nothing
        Me.cboLOAI_THIET_BI.TextReadonly = True
        Me.cboLOAI_THIET_BI.Value = ""
        '
        'utcComboLoaiVT
        '
        Me.utcComboLoaiVT.AssemblyName = ""
        Me.utcComboLoaiVT.BackColor = System.Drawing.Color.White
        Me.utcComboLoaiVT.ClassName = ""
        Me.utcComboLoaiVT.Display = ""
        Me.utcComboLoaiVT.ErrorProviderControl = Me.ErrorProvider1
        Me.utcComboLoaiVT.FormattingEnabled = True
        Me.utcComboLoaiVT.IsAll = True
        Me.utcComboLoaiVT.IsNew = False
        Me.utcComboLoaiVT.ItemAll = " < ALL > "
        Me.utcComboLoaiVT.ItemNew = "...New"
        Me.utcComboLoaiVT.Location = New System.Drawing.Point(92, 69)
        Me.utcComboLoaiVT.MethodName = ""
        Me.utcComboLoaiVT.Name = "utcComboLoaiVT"
        Me.utcComboLoaiVT.Param = ""
        Me.utcComboLoaiVT.Size = New System.Drawing.Size(165, 21)
        Me.utcComboLoaiVT.StoreName = ""
        Me.utcComboLoaiVT.TabIndex = 53
        Me.utcComboLoaiVT.Table = Nothing
        Me.utcComboLoaiVT.TextReadonly = True
        Me.utcComboLoaiVT.Value = ""
        '
        'cboLOAI_PHU_TUNG
        '
        Me.cboLOAI_PHU_TUNG.AssemblyName = ""
        Me.cboLOAI_PHU_TUNG.BackColor = System.Drawing.Color.White
        Me.cboLOAI_PHU_TUNG.ClassName = ""
        Me.cboLOAI_PHU_TUNG.Display = ""
        Me.cboLOAI_PHU_TUNG.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLOAI_PHU_TUNG.FormattingEnabled = True
        Me.cboLOAI_PHU_TUNG.IsAll = True
        Me.cboLOAI_PHU_TUNG.IsNew = False
        Me.cboLOAI_PHU_TUNG.ItemAll = " < ALL > "
        Me.cboLOAI_PHU_TUNG.ItemNew = "...New"
        Me.cboLOAI_PHU_TUNG.Location = New System.Drawing.Point(391, 69)
        Me.cboLOAI_PHU_TUNG.MethodName = ""
        Me.cboLOAI_PHU_TUNG.Name = "cboLOAI_PHU_TUNG"
        Me.cboLOAI_PHU_TUNG.Param = ""
        Me.cboLOAI_PHU_TUNG.Size = New System.Drawing.Size(169, 21)
        Me.cboLOAI_PHU_TUNG.StoreName = ""
        Me.cboLOAI_PHU_TUNG.TabIndex = 54
        Me.cboLOAI_PHU_TUNG.Table = Nothing
        Me.cboLOAI_PHU_TUNG.TextReadonly = True
        Me.cboLOAI_PHU_TUNG.Value = ""
        '
        'grdChonPT
        '
        Me.grdChonPT.AllowUserToAddRows = False
        Me.grdChonPT.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.grdChonPT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdChonPT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonPT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdChonPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdChonPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_PT, Me.TEN_PT, Me.DVT, Me.SLTON, Me.TON_TOI_THIEU, Me.NGAY_CUOI})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdChonPT.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdChonPT.Location = New System.Drawing.Point(7, 100)
        Me.grdChonPT.MultiSelect = False
        Me.grdChonPT.Name = "grdChonPT"
        Me.grdChonPT.RowHeadersWidth = 25
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonPT.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdChonPT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdChonPT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grdChonPT.Size = New System.Drawing.Size(847, 376)
        Me.grdChonPT.TabIndex = 49
        '
        'CHON
        '
        Me.CHON.HeaderText = "CHON"
        Me.CHON.MinimumWidth = 60
        Me.CHON.Name = "CHON"
        Me.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHON.Width = 60
        '
        'MS_PT
        '
        Me.MS_PT.HeaderText = "MS_VTPT"
        Me.MS_PT.MinimumWidth = 100
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.ReadOnly = True
        Me.MS_PT.Width = 120
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.HeaderText = "TEN_PT"
        Me.TEN_PT.MinimumWidth = 100
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.ReadOnly = True
        '
        'DVT
        '
        Me.DVT.HeaderText = "DVT"
        Me.DVT.MinimumWidth = 90
        Me.DVT.Name = "DVT"
        Me.DVT.ReadOnly = True
        Me.DVT.Width = 90
        '
        'SLTON
        '
        Me.SLTON.HeaderText = "SLTON"
        Me.SLTON.MinimumWidth = 80
        Me.SLTON.Name = "SLTON"
        Me.SLTON.ReadOnly = True
        Me.SLTON.Width = 80
        '
        'TON_TOI_THIEU
        '
        Me.TON_TOI_THIEU.HeaderText = "TON_TOI_THIEU"
        Me.TON_TOI_THIEU.MinimumWidth = 80
        Me.TON_TOI_THIEU.Name = "TON_TOI_THIEU"
        Me.TON_TOI_THIEU.ReadOnly = True
        Me.TON_TOI_THIEU.Width = 80
        '
        'NGAY_CUOI
        '
        Me.NGAY_CUOI.HeaderText = "NGAY_CUOI"
        Me.NGAY_CUOI.MinimumWidth = 100
        Me.NGAY_CUOI.Name = "NGAY_CUOI"
        Me.NGAY_CUOI.ReadOnly = True
        '
        'lbaTimTen
        '
        Me.lbaTimTen.AutoSize = True
        Me.lbaTimTen.Location = New System.Drawing.Point(203, 489)
        Me.lbaTimTen.Name = "lbaTimTen"
        Me.lbaTimTen.Size = New System.Drawing.Size(38, 13)
        Me.lbaTimTen.TabIndex = 64
        Me.lbaTimTen.Text = "Label1"
        '
        'txtTimTen
        '
        Me.txtTimTen.Location = New System.Drawing.Point(301, 486)
        Me.txtTimTen.Name = "txtTimTen"
        Me.txtTimTen.Size = New System.Drawing.Size(125, 21)
        Me.txtTimTen.TabIndex = 65
        '
        'frmChonPTDeXuat_CS
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 511)
        Me.Controls.Add(Me.txtTimTen)
        Me.Controls.Add(Me.lbaTimTen)
        Me.Controls.Add(Me.rdbSLMinNhoHonHT)
        Me.Controls.Add(Me.rdbTatCa)
        Me.Controls.Add(Me.btnTrove)
        Me.Controls.Add(Me.btnThuchien)
        Me.Controls.Add(Me.txtTimPT)
        Me.Controls.Add(Me.lblTimPT)
        Me.Controls.Add(Me.btnBoChon)
        Me.Controls.Add(Me.btnChon)
        Me.Controls.Add(Me.cboLOAI_THIET_BI)
        Me.Controls.Add(Me.utcComboLoaiVT)
        Me.Controls.Add(Me.cboLOAI_PHU_TUNG)
        Me.Controls.Add(Me.lblLoaivattu)
        Me.Controls.Add(Me.lblLOAI_PHU_TUNG)
        Me.Controls.Add(Me.lblLOAI_THIET_BI)
        Me.Controls.Add(Me.grdChonPT)
        Me.Controls.Add(Me.lblTieuDe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonPTDeXuat_CS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonPTDeXuat"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChonPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents cboLOAI_THIET_BI As Commons.UtcComboBox
    Friend WithEvents utcComboLoaiVT As Commons.UtcComboBox
    Friend WithEvents cboLOAI_PHU_TUNG As Commons.UtcComboBox
    Friend WithEvents lblLoaivattu As System.Windows.Forms.Label
    Friend WithEvents lblLOAI_PHU_TUNG As System.Windows.Forms.Label
    Friend WithEvents lblLOAI_THIET_BI As System.Windows.Forms.Label
    Friend WithEvents grdChonPT As Commons.QLGrid
    Friend WithEvents txtTimPT As Commons.utcTextBox
    Friend WithEvents lblTimPT As System.Windows.Forms.Label
    Friend WithEvents btnBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTrove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThuchien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents rdbSLMinNhoHonHT As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTatCa As System.Windows.Forms.RadioButton
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLTON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TON_TOI_THIEU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGAY_CUOI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTimTen As System.Windows.Forms.TextBox
    Friend WithEvents lbaTimTen As System.Windows.Forms.Label
End Class
