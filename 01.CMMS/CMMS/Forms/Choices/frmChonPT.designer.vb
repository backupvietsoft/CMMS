<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonPT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnChon = New System.Windows.Forms.Button()
        Me.btnBoChon = New System.Windows.Forms.Button()
        Me.btnThuchien = New System.Windows.Forms.Button()
        Me.btnTrove = New System.Windows.Forms.Button()
        Me.lblTieude = New System.Windows.Forms.Label()
        Me.lblLOAI_THIET_BI = New System.Windows.Forms.Label()
        Me.lblLOAI_PHU_TUNG = New System.Windows.Forms.Label()
        Me.lblPATH = New System.Windows.Forms.Label()
        Me.btnViewImage = New System.Windows.Forms.Button()
        Me.lblLoaivattu = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTimPT = New System.Windows.Forms.Label()
        Me.lbaTenVT = New System.Windows.Forms.Label()
        Me.txtTenVT = New System.Windows.Forms.TextBox()
        Me.txtTimPT = New Commons.utcTextBox()
        Me.cboLOAI_THIET_BI = New Commons.UtcComboBox()
        Me.utcComboLoaiVT = New Commons.UtcComboBox()
        Me.cboLOAI_PHU_TUNG = New Commons.UtcComboBox()
        Me.grdChonPT = New Commons.QLGrid()
        Me.chkChon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEMCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_LOAI_VT_TV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MS_KHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_KHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChonPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChon
        '
        Me.btnChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChon.ForeColor = System.Drawing.Color.Blue
        Me.btnChon.Location = New System.Drawing.Point(416, 523)
        Me.btnChon.Name = "btnChon"
        Me.btnChon.Size = New System.Drawing.Size(90, 27)
        Me.btnChon.TabIndex = 36
        Me.btnChon.Text = "Chọn tất cả"
        Me.btnChon.UseVisualStyleBackColor = True
        '
        'btnBoChon
        '
        Me.btnBoChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBoChon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoChon.ForeColor = System.Drawing.Color.Blue
        Me.btnBoChon.Location = New System.Drawing.Point(507, 523)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(110, 27)
        Me.btnBoChon.TabIndex = 37
        Me.btnBoChon.Text = "Bỏ chọn tất cả"
        Me.btnBoChon.UseVisualStyleBackColor = True
        '
        'btnThuchien
        '
        Me.btnThuchien.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThuchien.ForeColor = System.Drawing.Color.Maroon
        Me.btnThuchien.Location = New System.Drawing.Point(776, 523)
        Me.btnThuchien.Name = "btnThuchien"
        Me.btnThuchien.Size = New System.Drawing.Size(90, 27)
        Me.btnThuchien.TabIndex = 38
        Me.btnThuchien.Text = "Thực hiện"
        Me.btnThuchien.UseVisualStyleBackColor = True
        '
        'btnTrove
        '
        Me.btnTrove.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnTrove.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrove.ForeColor = System.Drawing.Color.Black
        Me.btnTrove.Location = New System.Drawing.Point(867, 523)
        Me.btnTrove.Name = "btnTrove"
        Me.btnTrove.Size = New System.Drawing.Size(90, 27)
        Me.btnTrove.TabIndex = 39
        Me.btnTrove.Text = "Thoát"
        Me.btnTrove.UseVisualStyleBackColor = True
        '
        'lblTieude
        '
        Me.lblTieude.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(7, -4)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(950, 44)
        Me.lblTieude.TabIndex = 20
        Me.lblTieude.Text = "CHỌN VẬT TƯ CHO PHIẾU NHẬP KHO"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLOAI_THIET_BI
        '
        Me.lblLOAI_THIET_BI.AutoSize = True
        Me.lblLOAI_THIET_BI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOAI_THIET_BI.Location = New System.Drawing.Point(552, 59)
        Me.lblLOAI_THIET_BI.Name = "lblLOAI_THIET_BI"
        Me.lblLOAI_THIET_BI.Size = New System.Drawing.Size(90, 14)
        Me.lblLOAI_THIET_BI.TabIndex = 41
        Me.lblLOAI_THIET_BI.Text = "Loại thiết bị SD"
        '
        'lblLOAI_PHU_TUNG
        '
        Me.lblLOAI_PHU_TUNG.AutoSize = True
        Me.lblLOAI_PHU_TUNG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOAI_PHU_TUNG.Location = New System.Drawing.Point(252, 59)
        Me.lblLOAI_PHU_TUNG.Name = "lblLOAI_PHU_TUNG"
        Me.lblLOAI_PHU_TUNG.Size = New System.Drawing.Size(111, 14)
        Me.lblLOAI_PHU_TUNG.TabIndex = 43
        Me.lblLOAI_PHU_TUNG.Text = "Nơi sử dụng vật tư"
        '
        'lblPATH
        '
        Me.lblPATH.AutoSize = True
        Me.lblPATH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATH.Location = New System.Drawing.Point(499, 503)
        Me.lblPATH.Name = "lblPATH"
        Me.lblPATH.Size = New System.Drawing.Size(0, 14)
        Me.lblPATH.TabIndex = 46
        Me.lblPATH.Visible = False
        '
        'btnViewImage
        '
        Me.btnViewImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewImage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewImage.ForeColor = System.Drawing.Color.Blue
        Me.btnViewImage.Location = New System.Drawing.Point(618, 523)
        Me.btnViewImage.Name = "btnViewImage"
        Me.btnViewImage.Size = New System.Drawing.Size(134, 27)
        Me.btnViewImage.TabIndex = 37
        Me.btnViewImage.Text = "Xem hình vật tư"
        Me.btnViewImage.UseVisualStyleBackColor = True
        '
        'lblLoaivattu
        '
        Me.lblLoaivattu.AutoSize = True
        Me.lblLoaivattu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoaivattu.Location = New System.Drawing.Point(15, 59)
        Me.lblLoaivattu.Name = "lblLoaivattu"
        Me.lblLoaivattu.Size = New System.Drawing.Size(66, 14)
        Me.lblLoaivattu.TabIndex = 43
        Me.lblLoaivattu.Text = "Loại vật tư"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'lblTimPT
        '
        Me.lblTimPT.Location = New System.Drawing.Point(0, 536)
        Me.lblTimPT.Name = "lblTimPT"
        Me.lblTimPT.Size = New System.Drawing.Size(98, 14)
        Me.lblTimPT.TabIndex = 49
        Me.lblTimPT.Text = "Tìm mã vật tư"
        Me.lblTimPT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbaTenVT
        '
        Me.lbaTenVT.Location = New System.Drawing.Point(210, 536)
        Me.lbaTenVT.Name = "lbaTenVT"
        Me.lbaTenVT.Size = New System.Drawing.Size(94, 13)
        Me.lbaTenVT.TabIndex = 51
        Me.lbaTenVT.Text = "Tim tên VT"
        '
        'txtTenVT
        '
        Me.txtTenVT.Location = New System.Drawing.Point(311, 526)
        Me.txtTenVT.Name = "txtTenVT"
        Me.txtTenVT.Size = New System.Drawing.Size(100, 22)
        Me.txtTenVT.TabIndex = 52
        '
        'txtTimPT
        '
        Me.txtTimPT.BackColor = System.Drawing.Color.White
        Me.txtTimPT.ErrorProviderControl = Me.errProvider
        Me.txtTimPT.FieldName = ""
        Me.txtTimPT.IsNull = True
        Me.txtTimPT.Location = New System.Drawing.Point(104, 528)
        Me.txtTimPT.Name = "txtTimPT"
        Me.txtTimPT.Size = New System.Drawing.Size(100, 22)
        Me.txtTimPT.TabIndex = 50
        Me.txtTimPT.TextTypeMode = Commons.TypeMode.None
        '
        'cboLOAI_THIET_BI
        '
        Me.cboLOAI_THIET_BI.AssemblyName = ""
        Me.cboLOAI_THIET_BI.BackColor = System.Drawing.Color.White
        Me.cboLOAI_THIET_BI.ClassName = ""
        Me.cboLOAI_THIET_BI.Display = ""
        Me.cboLOAI_THIET_BI.ErrorProviderControl = Me.errProvider
        Me.cboLOAI_THIET_BI.FormattingEnabled = True
        Me.cboLOAI_THIET_BI.IsAll = True
        Me.cboLOAI_THIET_BI.isInputNull = False
        Me.cboLOAI_THIET_BI.IsNew = False
        Me.cboLOAI_THIET_BI.IsNull = True
        Me.cboLOAI_THIET_BI.ItemAll = " < ALL > "
        Me.cboLOAI_THIET_BI.ItemNew = "...New"
        Me.cboLOAI_THIET_BI.Location = New System.Drawing.Point(647, 55)
        Me.cboLOAI_THIET_BI.MethodName = ""
        Me.cboLOAI_THIET_BI.Name = "cboLOAI_THIET_BI"
        Me.cboLOAI_THIET_BI.Param = ""
        Me.cboLOAI_THIET_BI.Param2 = ""
        Me.cboLOAI_THIET_BI.Size = New System.Drawing.Size(164, 22)
        Me.cboLOAI_THIET_BI.StoreName = ""
        Me.cboLOAI_THIET_BI.TabIndex = 48
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
        Me.utcComboLoaiVT.ErrorProviderControl = Me.errProvider
        Me.utcComboLoaiVT.FormattingEnabled = True
        Me.utcComboLoaiVT.IsAll = True
        Me.utcComboLoaiVT.isInputNull = False
        Me.utcComboLoaiVT.IsNew = False
        Me.utcComboLoaiVT.IsNull = True
        Me.utcComboLoaiVT.ItemAll = " < ALL > "
        Me.utcComboLoaiVT.ItemNew = "...New"
        Me.utcComboLoaiVT.Location = New System.Drawing.Point(87, 55)
        Me.utcComboLoaiVT.MethodName = ""
        Me.utcComboLoaiVT.Name = "utcComboLoaiVT"
        Me.utcComboLoaiVT.Param = ""
        Me.utcComboLoaiVT.Param2 = ""
        Me.utcComboLoaiVT.Size = New System.Drawing.Size(145, 22)
        Me.utcComboLoaiVT.StoreName = ""
        Me.utcComboLoaiVT.TabIndex = 47
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
        Me.cboLOAI_PHU_TUNG.ErrorProviderControl = Me.errProvider
        Me.cboLOAI_PHU_TUNG.FormattingEnabled = True
        Me.cboLOAI_PHU_TUNG.IsAll = True
        Me.cboLOAI_PHU_TUNG.isInputNull = False
        Me.cboLOAI_PHU_TUNG.IsNew = False
        Me.cboLOAI_PHU_TUNG.IsNull = True
        Me.cboLOAI_PHU_TUNG.ItemAll = " < ALL > "
        Me.cboLOAI_PHU_TUNG.ItemNew = "...New"
        Me.cboLOAI_PHU_TUNG.Location = New System.Drawing.Point(369, 55)
        Me.cboLOAI_PHU_TUNG.MethodName = ""
        Me.cboLOAI_PHU_TUNG.Name = "cboLOAI_PHU_TUNG"
        Me.cboLOAI_PHU_TUNG.Param = ""
        Me.cboLOAI_PHU_TUNG.Param2 = ""
        Me.cboLOAI_PHU_TUNG.Size = New System.Drawing.Size(156, 22)
        Me.cboLOAI_PHU_TUNG.StoreName = ""
        Me.cboLOAI_PHU_TUNG.TabIndex = 47
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
        Me.grdChonPT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonPT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdChonPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdChonPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkChon, Me.MS_PT, Me.ITEMCODE, Me.PARTNO, Me.TEN_PT, Me.TEN_LOAI_VT_TV, Me.MS_KHO, Me.TEN_KHO})
        Me.grdChonPT.Location = New System.Drawing.Point(12, 96)
        Me.grdChonPT.MultiSelect = False
        Me.grdChonPT.Name = "grdChonPT"
        Me.grdChonPT.RowHeadersWidth = 25
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonPT.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdChonPT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdChonPT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grdChonPT.Size = New System.Drawing.Size(945, 421)
        Me.grdChonPT.TabIndex = 40
        '
        'chkChon
        '
        Me.chkChon.FillWeight = 27.83418!
        Me.chkChon.HeaderText = "Chọn "
        Me.chkChon.MinimumWidth = 60
        Me.chkChon.Name = "chkChon"
        Me.chkChon.Width = 60
        '
        'MS_PT
        '
        Me.MS_PT.FillWeight = 27.83418!
        Me.MS_PT.HeaderText = "MS VT"
        Me.MS_PT.MinimumWidth = 150
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.ReadOnly = True
        Me.MS_PT.Width = 150
        '
        'ITEMCODE
        '
        Me.ITEMCODE.FillWeight = 27.83418!
        Me.ITEMCODE.HeaderText = "Item code"
        Me.ITEMCODE.MinimumWidth = 100
        Me.ITEMCODE.Name = "ITEMCODE"
        Me.ITEMCODE.ReadOnly = True
        '
        'PARTNO
        '
        Me.PARTNO.FillWeight = 27.83418!
        Me.PARTNO.HeaderText = "Part No"
        Me.PARTNO.MinimumWidth = 100
        Me.PARTNO.Name = "PARTNO"
        Me.PARTNO.ReadOnly = True
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.FillWeight = 27.83418!
        Me.TEN_PT.HeaderText = "Tên vật tư"
        Me.TEN_PT.MinimumWidth = 150
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.ReadOnly = True
        '
        'TEN_LOAI_VT_TV
        '
        Me.TEN_LOAI_VT_TV.FillWeight = 27.83418!
        Me.TEN_LOAI_VT_TV.HeaderText = "Loại vật tư"
        Me.TEN_LOAI_VT_TV.MinimumWidth = 150
        Me.TEN_LOAI_VT_TV.Name = "TEN_LOAI_VT_TV"
        Me.TEN_LOAI_VT_TV.ReadOnly = True
        Me.TEN_LOAI_VT_TV.Width = 150
        '
        'MS_KHO
        '
        Me.MS_KHO.HeaderText = "MS_KHO"
        Me.MS_KHO.Name = "MS_KHO"
        Me.MS_KHO.Visible = False
        '
        'TEN_KHO
        '
        Me.TEN_KHO.FillWeight = 532.9949!
        Me.TEN_KHO.HeaderText = "TEN_KHO"
        Me.TEN_KHO.MinimumWidth = 150
        Me.TEN_KHO.Name = "TEN_KHO"
        Me.TEN_KHO.ReadOnly = True
        Me.TEN_KHO.Width = 150
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS Phụ Tùng"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tên Phụ Tùng"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Đơn vị"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tên vật tư"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 220
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Loại vật tư"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 140
        '
        'frmChonPT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 554)
        Me.Controls.Add(Me.txtTenVT)
        Me.Controls.Add(Me.lbaTenVT)
        Me.Controls.Add(Me.txtTimPT)
        Me.Controls.Add(Me.lblTimPT)
        Me.Controls.Add(Me.cboLOAI_THIET_BI)
        Me.Controls.Add(Me.utcComboLoaiVT)
        Me.Controls.Add(Me.cboLOAI_PHU_TUNG)
        Me.Controls.Add(Me.lblLoaivattu)
        Me.Controls.Add(Me.lblPATH)
        Me.Controls.Add(Me.lblLOAI_PHU_TUNG)
        Me.Controls.Add(Me.lblLOAI_THIET_BI)
        Me.Controls.Add(Me.grdChonPT)
        Me.Controls.Add(Me.btnTrove)
        Me.Controls.Add(Me.btnThuchien)
        Me.Controls.Add(Me.btnViewImage)
        Me.Controls.Add(Me.btnBoChon)
        Me.Controls.Add(Me.btnChon)
        Me.Controls.Add(Me.lblTieude)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmChonPT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn Phụ Tùng"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChonPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnChon As System.Windows.Forms.Button
    Friend WithEvents btnBoChon As System.Windows.Forms.Button
    Friend WithEvents btnThuchien As System.Windows.Forms.Button
    Friend WithEvents btnTrove As System.Windows.Forms.Button
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents grdChonPT As Commons.QLGrid
    Friend WithEvents lblLOAI_THIET_BI As System.Windows.Forms.Label
    Friend WithEvents lblLOAI_PHU_TUNG As System.Windows.Forms.Label
    Friend WithEvents lblPATH As System.Windows.Forms.Label
    Friend WithEvents cboLOAI_PHU_TUNG As Commons.UtcComboBox
    Friend WithEvents cboLOAI_THIET_BI As Commons.UtcComboBox
    Friend WithEvents btnViewImage As System.Windows.Forms.Button
    Friend WithEvents lblLoaivattu As System.Windows.Forms.Label
    Friend WithEvents utcComboLoaiVT As Commons.UtcComboBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTimPT As Commons.utcTextBox
    Friend WithEvents lblTimPT As System.Windows.Forms.Label
    Friend WithEvents txtTenVT As System.Windows.Forms.TextBox
    Friend WithEvents lbaTenVT As System.Windows.Forms.Label
    Friend WithEvents chkChon As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEMCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_LOAI_VT_TV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_KHO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_KHO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
