<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonVatTuXuat
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnTHOAT = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPATH = New System.Windows.Forms.Label()
        Me.lblTIEU_DE = New System.Windows.Forms.Label()
        Me.grpDSVTchonxuat = New System.Windows.Forms.GroupBox()
        Me.grdDS_PHU_TUNG_CHON = New Commons.QLGrid()
        Me.grpDSVTcotrongkho = New System.Windows.Forms.GroupBox()
        Me.grdDS_PHU_TUNG = New System.Windows.Forms.DataGridView()
        Me.btnXuat_Tu_Dong = New DevExpress.XtraEditors.SimpleButton()
        Me.grpCTVTxuat = New System.Windows.Forms.GroupBox()
        Me.grdCT_VT_XUAT = New Commons.QLGrid()
        Me.NONNbtnAVT = New DevExpress.XtraEditors.SimpleButton()
        Me.NONNbtnMVT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThuc_Hien = New DevExpress.XtraEditors.SimpleButton()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnChonTuPickList = New DevExpress.XtraEditors.SimpleButton()
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.btnChonVTTuPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.lbaNCC = New System.Windows.Forms.Label()
        Me.txtNCC = New System.Windows.Forms.TextBox()
        Me.cbDDH = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkGoodsReceive = New System.Windows.Forms.CheckBox()
        Me.NONN = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDSVTchonxuat.SuspendLayout()
        CType(Me.grdDS_PHU_TUNG_CHON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDSVTcotrongkho.SuspendLayout()
        CType(Me.grdDS_PHU_TUNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCTVTxuat.SuspendLayout()
        CType(Me.grdCT_VT_XUAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDDH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnTHOAT
        '
        Me.btnTHOAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTHOAT.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnTHOAT.Appearance.Options.UseForeColor = True
        Me.btnTHOAT.Location = New System.Drawing.Point(371, 2)
        Me.btnTHOAT.LookAndFeel.SkinName = "Blue"
        Me.btnTHOAT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnTHOAT.Name = "btnTHOAT"
        Me.btnTHOAT.Size = New System.Drawing.Size(104, 31)
        Me.btnTHOAT.TabIndex = 95
        Me.btnTHOAT.Text = "Thoát"
        '
        'lblPATH
        '
        Me.lblPATH.AutoSize = True
        Me.lblPATH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATH.Location = New System.Drawing.Point(346, 501)
        Me.lblPATH.Name = "lblPATH"
        Me.lblPATH.Size = New System.Drawing.Size(0, 14)
        Me.lblPATH.TabIndex = 97
        Me.lblPATH.Visible = False
        '
        'lblTIEU_DE
        '
        Me.lblTIEU_DE.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIEU_DE.ForeColor = System.Drawing.Color.Navy
        Me.lblTIEU_DE.Location = New System.Drawing.Point(206, 4)
        Me.lblTIEU_DE.Name = "lblTIEU_DE"
        Me.lblTIEU_DE.Size = New System.Drawing.Size(914, 42)
        Me.lblTIEU_DE.TabIndex = 88
        Me.lblTIEU_DE.Text = "CHỌN VẬT TƯ CHO PHIẾU XUẤT KHO"
        Me.lblTIEU_DE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDSVTchonxuat
        '
        Me.grpDSVTchonxuat.Controls.Add(Me.grdDS_PHU_TUNG_CHON)
        Me.grpDSVTchonxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDSVTchonxuat.ForeColor = System.Drawing.Color.Maroon
        Me.grpDSVTchonxuat.Location = New System.Drawing.Point(50, 3)
        Me.grpDSVTchonxuat.Name = "grpDSVTchonxuat"
        Me.TableLayoutPanel1.SetRowSpan(Me.grpDSVTchonxuat, 3)
        Me.grpDSVTchonxuat.Size = New System.Drawing.Size(431, 271)
        Me.grpDSVTchonxuat.TabIndex = 98
        Me.grpDSVTchonxuat.TabStop = False
        Me.grpDSVTchonxuat.Text = "Danh sách vật tư chọn xuất "
        '
        'grdDS_PHU_TUNG_CHON
        '
        Me.grdDS_PHU_TUNG_CHON.AllowUserToAddRows = False
        Me.grdDS_PHU_TUNG_CHON.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDS_PHU_TUNG_CHON.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDS_PHU_TUNG_CHON.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdDS_PHU_TUNG_CHON.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDS_PHU_TUNG_CHON.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDS_PHU_TUNG_CHON.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDS_PHU_TUNG_CHON.Location = New System.Drawing.Point(3, 17)
        Me.grdDS_PHU_TUNG_CHON.MultiSelect = False
        Me.grdDS_PHU_TUNG_CHON.Name = "grdDS_PHU_TUNG_CHON"
        Me.grdDS_PHU_TUNG_CHON.RowHeadersWidth = 25
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdDS_PHU_TUNG_CHON.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdDS_PHU_TUNG_CHON.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.grdDS_PHU_TUNG_CHON.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdDS_PHU_TUNG_CHON.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdDS_PHU_TUNG_CHON.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdDS_PHU_TUNG_CHON.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDS_PHU_TUNG_CHON.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdDS_PHU_TUNG_CHON.ShowEditingIcon = False
        Me.grdDS_PHU_TUNG_CHON.Size = New System.Drawing.Size(425, 251)
        Me.grdDS_PHU_TUNG_CHON.TabIndex = 24
        '
        'grpDSVTcotrongkho
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.grpDSVTcotrongkho, 4)
        Me.grpDSVTcotrongkho.Controls.Add(Me.grdDS_PHU_TUNG)
        Me.grpDSVTcotrongkho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDSVTcotrongkho.ForeColor = System.Drawing.Color.Maroon
        Me.grpDSVTcotrongkho.Location = New System.Drawing.Point(3, 38)
        Me.grpDSVTcotrongkho.Name = "grpDSVTcotrongkho"
        Me.grpDSVTcotrongkho.Size = New System.Drawing.Size(388, 450)
        Me.grpDSVTcotrongkho.TabIndex = 100
        Me.grpDSVTcotrongkho.TabStop = False
        Me.grpDSVTcotrongkho.Text = "Danh sách vật tư có trong kho "
        '
        'grdDS_PHU_TUNG
        '
        Me.grdDS_PHU_TUNG.AllowUserToAddRows = False
        Me.grdDS_PHU_TUNG.AllowUserToDeleteRows = False
        Me.grdDS_PHU_TUNG.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDS_PHU_TUNG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDS_PHU_TUNG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grdDS_PHU_TUNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDS_PHU_TUNG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDS_PHU_TUNG.Location = New System.Drawing.Point(3, 17)
        Me.grdDS_PHU_TUNG.MultiSelect = False
        Me.grdDS_PHU_TUNG.Name = "grdDS_PHU_TUNG"
        Me.grdDS_PHU_TUNG.ReadOnly = True
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDS_PHU_TUNG.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.grdDS_PHU_TUNG.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.grdDS_PHU_TUNG.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdDS_PHU_TUNG.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdDS_PHU_TUNG.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdDS_PHU_TUNG.Size = New System.Drawing.Size(382, 430)
        Me.grdDS_PHU_TUNG.TabIndex = 99
        '
        'btnXuat_Tu_Dong
        '
        Me.btnXuat_Tu_Dong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXuat_Tu_Dong.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnXuat_Tu_Dong.Appearance.Options.UseForeColor = True
        Me.btnXuat_Tu_Dong.Location = New System.Drawing.Point(161, 2)
        Me.btnXuat_Tu_Dong.LookAndFeel.SkinName = "Blue"
        Me.btnXuat_Tu_Dong.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXuat_Tu_Dong.Name = "btnXuat_Tu_Dong"
        Me.btnXuat_Tu_Dong.Size = New System.Drawing.Size(104, 31)
        Me.btnXuat_Tu_Dong.TabIndex = 96
        Me.btnXuat_Tu_Dong.Text = "Xuất tự động"
        '
        'grpCTVTxuat
        '
        Me.grpCTVTxuat.Controls.Add(Me.grdCT_VT_XUAT)
        Me.grpCTVTxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCTVTxuat.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grpCTVTxuat.ForeColor = System.Drawing.Color.Maroon
        Me.grpCTVTxuat.Location = New System.Drawing.Point(50, 280)
        Me.grpCTVTxuat.Name = "grpCTVTxuat"
        Me.TableLayoutPanel1.SetRowSpan(Me.grpCTVTxuat, 2)
        Me.grpCTVTxuat.Size = New System.Drawing.Size(431, 236)
        Me.grpCTVTxuat.TabIndex = 98
        Me.grpCTVTxuat.TabStop = False
        Me.grpCTVTxuat.Text = "Chi tiết vật tư xuất "
        '
        'grdCT_VT_XUAT
        '
        Me.grdCT_VT_XUAT.AllowUserToAddRows = False
        Me.grdCT_VT_XUAT.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdCT_VT_XUAT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCT_VT_XUAT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdCT_VT_XUAT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCT_VT_XUAT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCT_VT_XUAT.Location = New System.Drawing.Point(3, 17)
        Me.grdCT_VT_XUAT.MultiSelect = False
        Me.grdCT_VT_XUAT.Name = "grdCT_VT_XUAT"
        Me.grdCT_VT_XUAT.RowHeadersWidth = 25
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdCT_VT_XUAT.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grdCT_VT_XUAT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdCT_VT_XUAT.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCT_VT_XUAT.ShowEditingIcon = False
        Me.grdCT_VT_XUAT.Size = New System.Drawing.Size(425, 216)
        Me.grdCT_VT_XUAT.TabIndex = 24
        '
        'NONNbtnAVT
        '
        Me.NONNbtnAVT.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NONNbtnAVT.Appearance.Options.UseForeColor = True
        Me.NONNbtnAVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NONNbtnAVT.Location = New System.Drawing.Point(3, 210)
        Me.NONNbtnAVT.Name = "NONNbtnAVT"
        Me.NONNbtnAVT.Size = New System.Drawing.Size(41, 29)
        Me.NONNbtnAVT.TabIndex = 96
        Me.NONNbtnAVT.Text = ">"
        '
        'NONNbtnMVT
        '
        Me.NONNbtnMVT.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NONNbtnMVT.Appearance.Options.UseForeColor = True
        Me.NONNbtnMVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NONNbtnMVT.Location = New System.Drawing.Point(3, 245)
        Me.NONNbtnMVT.Name = "NONNbtnMVT"
        Me.NONNbtnMVT.Size = New System.Drawing.Size(41, 29)
        Me.NONNbtnMVT.TabIndex = 96
        Me.NONNbtnMVT.Text = "<"
        '
        'btnThuc_Hien
        '
        Me.btnThuc_Hien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThuc_Hien.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnThuc_Hien.Appearance.Options.UseForeColor = True
        Me.btnThuc_Hien.Location = New System.Drawing.Point(266, 2)
        Me.btnThuc_Hien.LookAndFeel.SkinName = "Blue"
        Me.btnThuc_Hien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThuc_Hien.Name = "btnThuc_Hien"
        Me.btnThuc_Hien.Size = New System.Drawing.Size(104, 31)
        Me.btnThuc_Hien.TabIndex = 94
        Me.btnThuc_Hien.Text = "Thực hiện"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'BtnChonTuPickList
        '
        Me.BtnChonTuPickList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTuPickList.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnChonTuPickList.Appearance.Options.UseForeColor = True
        Me.BtnChonTuPickList.Location = New System.Drawing.Point(7, 2)
        Me.BtnChonTuPickList.Name = "BtnChonTuPickList"
        Me.BtnChonTuPickList.Size = New System.Drawing.Size(155, 31)
        Me.BtnChonTuPickList.TabIndex = 102
        Me.BtnChonTuPickList.Text = "Chọn từ PickList"
        Me.BtnChonTuPickList.Visible = False
        '
        'lblGhichu
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.lblGhichu, 3)
        Me.lblGhichu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhichu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGhichu.ForeColor = System.Drawing.Color.Maroon
        Me.lblGhichu.Location = New System.Drawing.Point(3, 491)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(388, 35)
        Me.lblGhichu.TabIndex = 103
        Me.lblGhichu.Text = "( Bạn có thể chọn vật tư bằng cách double click vao vật tư cần chọn )"
        Me.lblGhichu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnChonVTTuPBT
        '
        Me.btnChonVTTuPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonVTTuPBT.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnChonVTTuPBT.Appearance.Options.UseForeColor = True
        Me.btnChonVTTuPBT.Location = New System.Drawing.Point(5, 2)
        Me.btnChonVTTuPBT.LookAndFeel.SkinName = "Blue"
        Me.btnChonVTTuPBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonVTTuPBT.Name = "btnChonVTTuPBT"
        Me.btnChonVTTuPBT.Size = New System.Drawing.Size(155, 31)
        Me.btnChonVTTuPBT.TabIndex = 104
        Me.btnChonVTTuPBT.Text = "Chọn VT từ PBT"
        '
        'lbaNCC
        '
        Me.lbaNCC.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbaNCC.Location = New System.Drawing.Point(3, 531)
        Me.lbaNCC.Name = "lbaNCC"
        Me.lbaNCC.Size = New System.Drawing.Size(125, 30)
        Me.lbaNCC.TabIndex = 107
        Me.lbaNCC.Text = "Tìm NCC"
        Me.lbaNCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNCC
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.txtNCC, 2)
        Me.txtNCC.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtNCC.Location = New System.Drawing.Point(134, 537)
        Me.txtNCC.Name = "txtNCC"
        Me.txtNCC.Size = New System.Drawing.Size(257, 21)
        Me.txtNCC.TabIndex = 108
        '
        'cbDDH
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.cbDDH, 2)
        Me.cbDDH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbDDH.Enabled = False
        Me.cbDDH.Location = New System.Drawing.Point(134, 12)
        Me.cbDDH.Name = "cbDDH"
        Me.cbDDH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDDH.Properties.LookAndFeel.SkinName = "Blue"
        Me.cbDDH.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbDDH.Properties.NullText = ""
        Me.cbDDH.Size = New System.Drawing.Size(257, 20)
        Me.cbDDH.TabIndex = 109
        '
        'chkGoodsReceive
        '
        Me.chkGoodsReceive.AutoSize = True
        Me.chkGoodsReceive.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chkGoodsReceive.Location = New System.Drawing.Point(3, 15)
        Me.chkGoodsReceive.Name = "chkGoodsReceive"
        Me.chkGoodsReceive.Size = New System.Drawing.Size(125, 17)
        Me.chkGoodsReceive.TabIndex = 110
        Me.chkGoodsReceive.Text = "Đơn hàng nhập"
        Me.chkGoodsReceive.UseVisualStyleBackColor = True
        '
        'NONN
        '
        Me.NONN.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NONN.Appearance.Options.UseForeColor = True
        Me.NONN.Enabled = False
        Me.NONN.Location = New System.Drawing.Point(3, 280)
        Me.NONN.Name = "NONN"
        Me.NONN.Size = New System.Drawing.Size(41, 29)
        Me.NONN.TabIndex = 111
        Me.NONN.Text = ">>"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TableLayoutPanel6)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(884, 561)
        Me.SplitContainerControl1.SplitterPosition = 394
        Me.SplitContainerControl1.TabIndex = 113
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.42541!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33702!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.23757!))
        Me.TableLayoutPanel6.Controls.Add(Me.grpDSVTcotrongkho, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.lblGhichu, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtNCC, 1, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.chkGoodsReceive, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cbDDH, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lbaNCC, 0, 3)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 4
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(394, 561)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.NONNbtnAVT, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NONN, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDSVTchonxuat, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NONNbtnMVT, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpCTVTxuat, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btn, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(484, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.btnTHOAT)
        Me.Panel3.Controls.Add(Me.btnThuc_Hien)
        Me.Panel3.Controls.Add(Me.btnXuat_Tu_Dong)
        Me.Panel3.Controls.Add(Me.btnChonVTTuPBT)
        Me.Panel3.Controls.Add(Me.BtnChonTuPickList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 522)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(478, 36)
        Me.Panel3.TabIndex = 114
        '
        'btn
        '
        Me.btn.Appearance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btn.Appearance.Options.UseForeColor = True
        Me.btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn.Location = New System.Drawing.Point(3, 487)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(41, 29)
        Me.btn.TabIndex = 111
        Me.btn.Text = "+"
        Me.btn.Visible = False
        '
        'FrmChonVatTuXuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.lblPATH)
        Me.Controls.Add(Me.lblTIEU_DE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmChonVatTuXuat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmChonVatTuXuat"
        Me.grpDSVTchonxuat.ResumeLayout(False)
        CType(Me.grdDS_PHU_TUNG_CHON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDSVTcotrongkho.ResumeLayout(False)
        CType(Me.grdDS_PHU_TUNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCTVTxuat.ResumeLayout(False)
        CType(Me.grdCT_VT_XUAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDDH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTHOAT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPATH As System.Windows.Forms.Label
    Friend WithEvents lblTIEU_DE As System.Windows.Forms.Label
    Friend WithEvents grdDS_PHU_TUNG_CHON As Commons.QLGrid
    Friend WithEvents grpDSVTchonxuat As System.Windows.Forms.GroupBox
    Friend WithEvents grpDSVTcotrongkho As System.Windows.Forms.GroupBox
    Friend WithEvents btnXuat_Tu_Dong As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpCTVTxuat As System.Windows.Forms.GroupBox
    Friend WithEvents grdCT_VT_XUAT As Commons.QLGrid
    Friend WithEvents NONNbtnAVT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NONNbtnMVT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThuc_Hien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnChonTuPickList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents btnChonVTTuPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNCC As System.Windows.Forms.TextBox
    Friend WithEvents lbaNCC As System.Windows.Forms.Label
    Friend WithEvents cbDDH As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkGoodsReceive As System.Windows.Forms.CheckBox
    Friend WithEvents NONN As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDS_PHU_TUNG As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn As DevExpress.XtraEditors.SimpleButton
End Class
