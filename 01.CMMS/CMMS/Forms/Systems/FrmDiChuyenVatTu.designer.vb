<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDiChuyenVatTu
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblPATH = New System.Windows.Forms.Label()
        Me.btnXEM_HINH = New System.Windows.Forms.Button()
        Me.lblTukho = New System.Windows.Forms.Label()
        Me.lblTuvitri = New System.Windows.Forms.Label()
        Me.lblSangkho = New System.Windows.Forms.Label()
        Me.lblSangvitri = New System.Windows.Forms.Label()
        Me.lblThoigiandichuyen = New System.Windows.Forms.Label()
        Me.dtpGio = New System.Windows.Forms.DateTimePicker()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.btnLanDiChuyenMoi = New System.Windows.Forms.Button()
        Me.btnGhi = New System.Windows.Forms.Button()
        Me.btnKhongGhi = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtgio = New System.Windows.Forms.MaskedTextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboToPosition = New Commons.UtcComboBox()
        Me.cboFromPosition = New Commons.UtcComboBox()
        Me.cboFromStock = New Commons.UtcComboBox()
        Me.cboToStock = New Commons.UtcComboBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnMoveAl = New System.Windows.Forms.Button()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnRemoveAl = New System.Windows.Forms.Button()
        Me.grpdanhsachvattudi = New System.Windows.Forms.GroupBox()
        Me.grdFromVatTu = New Commons.QLGrid()
        Me.grpDanhsachvattuden = New System.Windows.Forms.GroupBox()
        Me.grdToVatTu = New Commons.QLGrid()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboNgayGio = New Commons.UtcComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnIn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.grpdanhsachvattudi.SuspendLayout()
        CType(Me.grdFromVatTu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattuden.SuspendLayout()
        CType(Me.grdToVatTu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnExit.Location = New System.Drawing.Point(907, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(85, 25)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Thoát "
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblPATH
        '
        Me.lblPATH.AutoSize = True
        Me.lblPATH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATH.Location = New System.Drawing.Point(404, 512)
        Me.lblPATH.Name = "lblPATH"
        Me.lblPATH.Size = New System.Drawing.Size(0, 14)
        Me.lblPATH.TabIndex = 114
        Me.lblPATH.Visible = False
        '
        'btnXEM_HINH
        '
        Me.btnXEM_HINH.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnXEM_HINH.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXEM_HINH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnXEM_HINH.Location = New System.Drawing.Point(3, 6)
        Me.btnXEM_HINH.Name = "btnXEM_HINH"
        Me.btnXEM_HINH.Size = New System.Drawing.Size(90, 25)
        Me.btnXEM_HINH.TabIndex = 10
        Me.btnXEM_HINH.Text = "Xem hình"
        Me.btnXEM_HINH.UseVisualStyleBackColor = True
        '
        'lblTukho
        '
        Me.lblTukho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTukho.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTukho.Location = New System.Drawing.Point(23, 0)
        Me.lblTukho.Name = "lblTukho"
        Me.lblTukho.Size = New System.Drawing.Size(94, 24)
        Me.lblTukho.TabIndex = 102
        Me.lblTukho.Text = "Từ kho"
        Me.lblTukho.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTuvitri
        '
        Me.lblTuvitri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuvitri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTuvitri.Location = New System.Drawing.Point(23, 24)
        Me.lblTuvitri.Name = "lblTuvitri"
        Me.lblTuvitri.Size = New System.Drawing.Size(94, 25)
        Me.lblTuvitri.TabIndex = 102
        Me.lblTuvitri.Text = "Từ vị trí "
        Me.lblTuvitri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSangkho
        '
        Me.lblSangkho.AutoSize = True
        Me.lblSangkho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSangkho.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSangkho.Location = New System.Drawing.Point(477, 0)
        Me.lblSangkho.Name = "lblSangkho"
        Me.lblSangkho.Size = New System.Drawing.Size(139, 24)
        Me.lblSangkho.TabIndex = 102
        Me.lblSangkho.Text = "Sang kho "
        Me.lblSangkho.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSangvitri
        '
        Me.lblSangvitri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSangvitri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSangvitri.Location = New System.Drawing.Point(477, 24)
        Me.lblSangvitri.Name = "lblSangvitri"
        Me.lblSangvitri.Size = New System.Drawing.Size(139, 25)
        Me.lblSangvitri.TabIndex = 102
        Me.lblSangvitri.Text = "Sang vị trí "
        Me.lblSangvitri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThoigiandichuyen
        '
        Me.lblThoigiandichuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThoigiandichuyen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThoigiandichuyen.Location = New System.Drawing.Point(251, 0)
        Me.lblThoigiandichuyen.Name = "lblThoigiandichuyen"
        Me.lblThoigiandichuyen.Size = New System.Drawing.Size(108, 30)
        Me.lblThoigiandichuyen.TabIndex = 102
        Me.lblThoigiandichuyen.Text = "Thời gian chuyển "
        Me.lblThoigiandichuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpGio
        '
        Me.dtpGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpGio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpGio.Location = New System.Drawing.Point(880, 3)
        Me.dtpGio.Name = "dtpGio"
        Me.dtpGio.Size = New System.Drawing.Size(90, 22)
        Me.dtpGio.TabIndex = 1
        Me.dtpGio.Visible = False
        '
        'dtpNgay
        '
        Me.dtpNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpNgay.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(542, 3)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(104, 22)
        Me.dtpNgay.TabIndex = 2
        '
        'btnLanDiChuyenMoi
        '
        Me.btnLanDiChuyenMoi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLanDiChuyenMoi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLanDiChuyenMoi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnLanDiChuyenMoi.Location = New System.Drawing.Point(309, 7)
        Me.btnLanDiChuyenMoi.Name = "btnLanDiChuyenMoi"
        Me.btnLanDiChuyenMoi.Size = New System.Drawing.Size(133, 22)
        Me.btnLanDiChuyenMoi.TabIndex = 0
        Me.btnLanDiChuyenMoi.Text = "Lần di chuyển mới "
        Me.btnLanDiChuyenMoi.UseVisualStyleBackColor = True
        Me.btnLanDiChuyenMoi.Visible = False
        '
        'btnGhi
        '
        Me.btnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi.Enabled = False
        Me.btnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnGhi.Location = New System.Drawing.Point(823, 6)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(85, 25)
        Me.btnGhi.TabIndex = 12
        Me.btnGhi.Text = "Ghi "
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi.Enabled = False
        Me.btnKhongGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnKhongGhi.Location = New System.Drawing.Point(907, 6)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(85, 25)
        Me.btnKhongGhi.TabIndex = 13
        Me.btnKhongGhi.Text = "Không ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnStart.Location = New System.Drawing.Point(823, 6)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(85, 25)
        Me.btnStart.TabIndex = 11
        Me.btnStart.Text = "Bắt đầu "
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtgio
        '
        Me.txtgio.BackColor = System.Drawing.Color.White
        Me.txtgio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtgio.Enabled = False
        Me.txtgio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtgio.Location = New System.Drawing.Point(365, 3)
        Me.txtgio.Mask = "00:00"
        Me.txtgio.Name = "txtgio"
        Me.txtgio.Size = New System.Drawing.Size(106, 22)
        Me.txtgio.TabIndex = 120
        Me.txtgio.ValidatingType = GetType(Date)
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.Location = New System.Drawing.Point(97, 12)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(56, 13)
        Me.lblSearch.TabIndex = 121
        Me.lblSearch.Text = "Theo mã"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(159, 7)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(132, 22)
        Me.txtSearch.TabIndex = 122
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMove, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMoveAl, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnRemove, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnRemoveAl, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.grpdanhsachvattudi, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachvattuden, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1001, 611)
        Me.TableLayoutPanel1.TabIndex = 126
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 3)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cboToPosition, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblSangvitri, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboFromPosition, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboFromStock, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblSangkho, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboToStock, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblTuvitri, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblTukho, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 85)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(995, 49)
        Me.TableLayoutPanel3.TabIndex = 127
        '
        'cboToPosition
        '
        Me.cboToPosition.AssemblyName = ""
        Me.cboToPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToPosition.BackColor = System.Drawing.Color.White
        Me.cboToPosition.ClassName = ""
        Me.cboToPosition.Display = "TEN_VI_TRI"
        Me.cboToPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboToPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToPosition.ErrorProviderControl = Me.errProvider
        Me.cboToPosition.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboToPosition.FormattingEnabled = True
        Me.cboToPosition.IsAll = False
        Me.cboToPosition.isInputNull = False
        Me.cboToPosition.IsNew = False
        Me.cboToPosition.IsNull = True
        Me.cboToPosition.ItemAll = " < ALL > "
        Me.cboToPosition.ItemNew = "...New"
        Me.cboToPosition.Items.AddRange(New Object() {""})
        Me.cboToPosition.Location = New System.Drawing.Point(622, 27)
        Me.cboToPosition.MethodName = ""
        Me.cboToPosition.Name = "cboToPosition"
        Me.cboToPosition.Param = ""
        Me.cboToPosition.Param2 = ""
        Me.cboToPosition.Size = New System.Drawing.Size(348, 22)
        Me.cboToPosition.StoreName = "QL_LIST_VI_TRI"
        Me.cboToPosition.TabIndex = 6
        Me.cboToPosition.Table = Nothing
        Me.cboToPosition.TextReadonly = False
        Me.cboToPosition.Value = "MS_VI_TRI"
        '
        'cboFromPosition
        '
        Me.cboFromPosition.AssemblyName = ""
        Me.cboFromPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFromPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFromPosition.BackColor = System.Drawing.Color.White
        Me.cboFromPosition.ClassName = ""
        Me.cboFromPosition.Display = "TEN_VI_TRI"
        Me.cboFromPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFromPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromPosition.ErrorProviderControl = Me.errProvider
        Me.cboFromPosition.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboFromPosition.FormattingEnabled = True
        Me.cboFromPosition.IsAll = False
        Me.cboFromPosition.isInputNull = False
        Me.cboFromPosition.IsNew = False
        Me.cboFromPosition.IsNull = True
        Me.cboFromPosition.ItemAll = " < ALL > "
        Me.cboFromPosition.ItemNew = "...New"
        Me.cboFromPosition.Items.AddRange(New Object() {""})
        Me.cboFromPosition.Location = New System.Drawing.Point(123, 27)
        Me.cboFromPosition.MethodName = ""
        Me.cboFromPosition.Name = "cboFromPosition"
        Me.cboFromPosition.Param = ""
        Me.cboFromPosition.Param2 = ""
        Me.cboFromPosition.Size = New System.Drawing.Size(348, 22)
        Me.cboFromPosition.StoreName = "QL_LIST_VI_TRI"
        Me.cboFromPosition.TabIndex = 4
        Me.cboFromPosition.Table = Nothing
        Me.cboFromPosition.TextReadonly = False
        Me.cboFromPosition.Value = "MS_VI_TRI"
        '
        'cboFromStock
        '
        Me.cboFromStock.AssemblyName = ""
        Me.cboFromStock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFromStock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFromStock.BackColor = System.Drawing.Color.White
        Me.cboFromStock.ClassName = ""
        Me.cboFromStock.Display = "TEN_KHO"
        Me.cboFromStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFromStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromStock.ErrorProviderControl = Me.errProvider
        Me.cboFromStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboFromStock.FormattingEnabled = True
        Me.cboFromStock.IsAll = False
        Me.cboFromStock.isInputNull = False
        Me.cboFromStock.IsNew = False
        Me.cboFromStock.IsNull = True
        Me.cboFromStock.ItemAll = " < ALL > "
        Me.cboFromStock.ItemNew = "...New"
        Me.cboFromStock.Items.AddRange(New Object() {""})
        Me.cboFromStock.Location = New System.Drawing.Point(123, 3)
        Me.cboFromStock.MethodName = ""
        Me.cboFromStock.Name = "cboFromStock"
        Me.cboFromStock.Param = ""
        Me.cboFromStock.Param2 = ""
        Me.cboFromStock.Size = New System.Drawing.Size(348, 22)
        Me.cboFromStock.StoreName = "QL_LISTKHO"
        Me.cboFromStock.TabIndex = 3
        Me.cboFromStock.Table = Nothing
        Me.cboFromStock.TextReadonly = False
        Me.cboFromStock.Value = "MS_KHO"
        '
        'cboToStock
        '
        Me.cboToStock.AssemblyName = ""
        Me.cboToStock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToStock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToStock.BackColor = System.Drawing.Color.White
        Me.cboToStock.ClassName = ""
        Me.cboToStock.Display = "TEN_KHO"
        Me.cboToStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboToStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToStock.ErrorProviderControl = Me.errProvider
        Me.cboToStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboToStock.FormattingEnabled = True
        Me.cboToStock.IsAll = False
        Me.cboToStock.isInputNull = False
        Me.cboToStock.IsNew = False
        Me.cboToStock.IsNull = True
        Me.cboToStock.ItemAll = " < ALL > "
        Me.cboToStock.ItemNew = "...New"
        Me.cboToStock.Items.AddRange(New Object() {""})
        Me.cboToStock.Location = New System.Drawing.Point(622, 3)
        Me.cboToStock.MethodName = ""
        Me.cboToStock.Name = "cboToStock"
        Me.cboToStock.Param = ""
        Me.cboToStock.Param2 = ""
        Me.cboToStock.Size = New System.Drawing.Size(348, 22)
        Me.cboToStock.StoreName = "QL_LISTKHO"
        Me.cboToStock.TabIndex = 5
        Me.cboToStock.Table = Nothing
        Me.cboToStock.TextReadonly = False
        Me.cboToStock.Value = "MS_KHO"
        '
        'btnMove
        '
        Me.btnMove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMove.Enabled = False
        Me.btnMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnMove.Location = New System.Drawing.Point(481, 296)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(39, 26)
        Me.btnMove.TabIndex = 8
        Me.btnMove.Text = ">>"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnMoveAl
        '
        Me.btnMoveAl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMoveAl.Enabled = False
        Me.btnMoveAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveAl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnMoveAl.Location = New System.Drawing.Point(481, 328)
        Me.btnMoveAl.Name = "btnMoveAl"
        Me.btnMoveAl.Size = New System.Drawing.Size(39, 24)
        Me.btnMoveAl.TabIndex = 9
        Me.btnMoveAl.Text = ">>>"
        Me.btnMoveAl.UseVisualStyleBackColor = True
        '
        'BtnRemove
        '
        Me.BtnRemove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnRemove.Enabled = False
        Me.BtnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnRemove.Location = New System.Drawing.Point(481, 358)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(39, 24)
        Me.BtnRemove.TabIndex = 118
        Me.BtnRemove.Text = "<"
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnRemoveAl
        '
        Me.BtnRemoveAl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnRemoveAl.Enabled = False
        Me.BtnRemoveAl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoveAl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnRemoveAl.Location = New System.Drawing.Point(481, 388)
        Me.BtnRemoveAl.Name = "BtnRemoveAl"
        Me.BtnRemoveAl.Size = New System.Drawing.Size(39, 24)
        Me.BtnRemoveAl.TabIndex = 119
        Me.BtnRemoveAl.Text = "<<"
        Me.BtnRemoveAl.UseVisualStyleBackColor = True
        '
        'grpdanhsachvattudi
        '
        Me.grpdanhsachvattudi.Controls.Add(Me.grdFromVatTu)
        Me.grpdanhsachvattudi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpdanhsachvattudi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpdanhsachvattudi.ForeColor = System.Drawing.Color.Maroon
        Me.grpdanhsachvattudi.Location = New System.Drawing.Point(3, 140)
        Me.grpdanhsachvattudi.Name = "grpdanhsachvattudi"
        Me.TableLayoutPanel1.SetRowSpan(Me.grpdanhsachvattudi, 6)
        Me.grpdanhsachvattudi.Size = New System.Drawing.Size(472, 428)
        Me.grpdanhsachvattudi.TabIndex = 117
        Me.grpdanhsachvattudi.TabStop = False
        Me.grpdanhsachvattudi.Text = "Danh sách vật tư trong vị trí chuyển đi "
        '
        'grdFromVatTu
        '
        Me.grdFromVatTu.AllowUserToAddRows = False
        Me.grdFromVatTu.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdFromVatTu.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdFromVatTu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdFromVatTu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdFromVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFromVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFromVatTu.Location = New System.Drawing.Point(3, 17)
        Me.grdFromVatTu.MultiSelect = False
        Me.grdFromVatTu.Name = "grdFromVatTu"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFromVatTu.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdFromVatTu.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFromVatTu.Size = New System.Drawing.Size(466, 408)
        Me.grdFromVatTu.TabIndex = 99
        '
        'grpDanhsachvattuden
        '
        Me.grpDanhsachvattuden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDanhsachvattuden.Controls.Add(Me.grdToVatTu)
        Me.grpDanhsachvattuden.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachvattuden.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachvattuden.Location = New System.Drawing.Point(526, 140)
        Me.grpDanhsachvattuden.Name = "grpDanhsachvattuden"
        Me.TableLayoutPanel1.SetRowSpan(Me.grpDanhsachvattuden, 6)
        Me.grpDanhsachvattuden.Size = New System.Drawing.Size(472, 428)
        Me.grpDanhsachvattuden.TabIndex = 117
        Me.grpDanhsachvattuden.TabStop = False
        Me.grpDanhsachvattuden.Text = "Danh sách vật tư trong vị trí chuyển đến "
        '
        'grdToVatTu
        '
        Me.grdToVatTu.AllowUserToAddRows = False
        Me.grdToVatTu.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdToVatTu.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdToVatTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdToVatTu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdToVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdToVatTu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.grdToVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdToVatTu.Location = New System.Drawing.Point(3, 17)
        Me.grdToVatTu.Name = "grdToVatTu"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdToVatTu.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grdToVatTu.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.grdToVatTu.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdToVatTu.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdToVatTu.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdToVatTu.Size = New System.Drawing.Size(466, 408)
        Me.grdToVatTu.TabIndex = 99
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 3)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dtpGio, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpNgay, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtgio, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblThoigiandichuyen, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNgayGio, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 39)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(995, 40)
        Me.TableLayoutPanel2.TabIndex = 128
        '
        'cboNgayGio
        '
        Me.cboNgayGio.AssemblyName = ""
        Me.cboNgayGio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNgayGio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNgayGio.BackColor = System.Drawing.Color.White
        Me.cboNgayGio.ClassName = ""
        Me.cboNgayGio.Display = "NGAY_CHUYEN"
        Me.cboNgayGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNgayGio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNgayGio.ErrorProviderControl = Me.errProvider
        Me.cboNgayGio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboNgayGio.FormattingEnabled = True
        Me.cboNgayGio.IsAll = False
        Me.cboNgayGio.isInputNull = False
        Me.cboNgayGio.IsNew = False
        Me.cboNgayGio.IsNull = True
        Me.cboNgayGio.ItemAll = " < ALL > "
        Me.cboNgayGio.ItemNew = "...New"
        Me.cboNgayGio.Items.AddRange(New Object() {""})
        Me.cboNgayGio.Location = New System.Drawing.Point(23, 3)
        Me.cboNgayGio.MethodName = ""
        Me.cboNgayGio.Name = "cboNgayGio"
        Me.cboNgayGio.Param = ""
        Me.cboNgayGio.Param2 = ""
        Me.cboNgayGio.Size = New System.Drawing.Size(222, 22)
        Me.cboNgayGio.StoreName = "QL_LISTDC"
        Me.cboNgayGio.TabIndex = 125
        Me.cboNgayGio.Table = Nothing
        Me.cboNgayGio.TextReadonly = False
        Me.cboNgayGio.Value = "GIO_CHUYEN"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 3)
        Me.Panel1.Controls.Add(Me.btnXEM_HINH)
        Me.Panel1.Controls.Add(Me.btnLanDiChuyenMoi)
        Me.Panel1.Controls.Add(Me.lblSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnIn)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongGhi)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 574)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 34)
        Me.Panel1.TabIndex = 129
        '
        'btnIn
        '
        Me.btnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnIn.Location = New System.Drawing.Point(739, 6)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(85, 25)
        Me.btnIn.TabIndex = 11
        Me.btnIn.Text = "In"
        Me.btnIn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnHelp, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnVideo, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(526, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(472, 30)
        Me.TableLayoutPanel4.TabIndex = 130
        '
        'btnHelp
        '
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(444, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(27, 28)
        Me.btnHelp.TabIndex = 100
        Me.btnHelp.Tag = "CMMS!FrmDiChuyenVatTu"
        '
        'btnVideo
        '
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(415, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(27, 28)
        Me.btnVideo.TabIndex = 99
        Me.btnVideo.Tag = "CMMS!FrmDiChuyenVatTu"
        '
        'BackgroundWorker1
        '
        '
        'FrmDiChuyenVatTu
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 611)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblPATH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDiChuyenVatTu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDiChuyenVatTu"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.grpdanhsachvattudi.ResumeLayout(False)
        CType(Me.grdFromVatTu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattuden.ResumeLayout(False)
        CType(Me.grdToVatTu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFromStock As Commons.UtcComboBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblPATH As System.Windows.Forms.Label
    Friend WithEvents btnXEM_HINH As System.Windows.Forms.Button
    Friend WithEvents lblTukho As System.Windows.Forms.Label
    Friend WithEvents lblTuvitri As System.Windows.Forms.Label
    Friend WithEvents lblSangkho As System.Windows.Forms.Label
    Friend WithEvents cboToStock As Commons.UtcComboBox
    Friend WithEvents lblThoigiandichuyen As System.Windows.Forms.Label
    Friend WithEvents dtpGio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLanDiChuyenMoi As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cboToPosition As Commons.UtcComboBox
    Friend WithEvents cboFromPosition As Commons.UtcComboBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtgio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents cboNgayGio As Commons.UtcComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMoveAl As System.Windows.Forms.Button
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnRemoveAl As System.Windows.Forms.Button
    Private WithEvents lblSangvitri As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnIn As Button
    Friend WithEvents btnMove As Button
    Friend WithEvents grpdanhsachvattudi As GroupBox
    Friend WithEvents grdFromVatTu As Commons.QLGrid
    Friend WithEvents grpDanhsachvattuden As GroupBox
    Friend WithEvents grdToVatTu As Commons.QLGrid
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
