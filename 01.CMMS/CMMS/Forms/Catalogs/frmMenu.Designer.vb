<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.labTitle = New System.Windows.Forms.Label()
        Me.pelButton = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.labLine = New System.Windows.Forms.Label()
        Me.labLine2 = New System.Windows.Forms.Label()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.clMENU_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMENU_IMAGE = New System.Windows.Forms.DataGridViewImageColumn()
        Me.clMENU_TEXT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter = New System.Windows.Forms.Splitter()
        Me.labLine3 = New System.Windows.Forms.Label()
        Me.tblMaint = New System.Windows.Forms.TableLayoutPanel()
        Me.txtMENU_NOTE = New System.Windows.Forms.TextBox()
        Me.txtFUNCTION_NAME = New System.Windows.Forms.TextBox()
        Me.txtCLASS_NAME = New System.Windows.Forms.TextBox()
        Me.cboSHORT_KEY = New System.Windows.Forms.ComboBox()
        Me.txtMENU_CHINESE = New System.Windows.Forms.TextBox()
        Me.labMENU_ID = New System.Windows.Forms.Label()
        Me.labMENU_TEXT = New System.Windows.Forms.Label()
        Me.labMENU_ENGLISH = New System.Windows.Forms.Label()
        Me.labMENU_CHINESE = New System.Windows.Forms.Label()
        Me.txtMENU_ID = New System.Windows.Forms.TextBox()
        Me.labMENU_INDEX = New System.Windows.Forms.Label()
        Me.txtMENU_INDEX = New System.Windows.Forms.TextBox()
        Me.chkMENU_LINE = New System.Windows.Forms.CheckBox()
        Me.txtMENU_TEXT = New System.Windows.Forms.TextBox()
        Me.txtMENU_ENGLISH = New System.Windows.Forms.TextBox()
        Me.labMENU_PARENT = New System.Windows.Forms.Label()
        Me.cboMENU_PARENT = New System.Windows.Forms.ComboBox()
        Me.labSHORT_KEY = New System.Windows.Forms.Label()
        Me.labDLL_NAME = New System.Windows.Forms.Label()
        Me.labPROJECT_NAME = New System.Windows.Forms.Label()
        Me.labCLASS_NAME = New System.Windows.Forms.Label()
        Me.labFUNCTION_NAME = New System.Windows.Forms.Label()
        Me.txtDLL_NAME = New System.Windows.Forms.TextBox()
        Me.txtPROJECT_NAME = New System.Windows.Forms.TextBox()
        Me.labMENU_NOTE = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pelButton.SuspendLayout
        CType(Me.dgvList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tblMaint.SuspendLayout
        Me.SuspendLayout
        '
        'labTitle
        '
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.labTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.labTitle.Location = New System.Drawing.Point(0, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(782, 25)
        Me.labTitle.TabIndex = 0
        Me.labTitle.Text = "DANH SÁCH MENU HỆ THỐNG"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pelButton
        '
        Me.pelButton.Controls.Add(Me.btnExit)
        Me.pelButton.Controls.Add(Me.btnPrint)
        Me.pelButton.Controls.Add(Me.btnSearch)
        Me.pelButton.Controls.Add(Me.btnCancel)
        Me.pelButton.Controls.Add(Me.btnSave)
        Me.pelButton.Controls.Add(Me.btnDelete)
        Me.pelButton.Controls.Add(Me.btnEdit)
        Me.pelButton.Controls.Add(Me.btnAdd)
        Me.pelButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pelButton.Location = New System.Drawing.Point(0, 456)
        Me.pelButton.Name = "pelButton"
        Me.pelButton.Padding = New System.Windows.Forms.Padding(2)
        Me.pelButton.Size = New System.Drawing.Size(782, 30)
        Me.pelButton.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(700, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 26)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Th&oát"
        Me.btnExit.UseVisualStyleBackColor = true
        '
        'btnPrint
        '
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(482, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 26)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&In"
        Me.btnPrint.UseVisualStyleBackColor = true
        '
        'btnSearch
        '
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(402, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 26)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "&Tìm"
        Me.btnSearch.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(322, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 26)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Hủy"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(242, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 26)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(162, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 26)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Xóa"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(82, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 26)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Sửa"
        Me.btnEdit.UseVisualStyleBackColor = true
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(2, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 26)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Thêm"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'labLine
        '
        Me.labLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.labLine.Location = New System.Drawing.Point(0, 454)
        Me.labLine.Name = "labLine"
        Me.labLine.Size = New System.Drawing.Size(782, 2)
        Me.labLine.TabIndex = 2
        '
        'labLine2
        '
        Me.labLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labLine2.Dock = System.Windows.Forms.DockStyle.Top
        Me.labLine2.Location = New System.Drawing.Point(0, 25)
        Me.labLine2.Name = "labLine2"
        Me.labLine2.Size = New System.Drawing.Size(782, 2)
        Me.labLine2.TabIndex = 3
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = false
        Me.dgvList.AllowUserToDeleteRows = false
        Me.dgvList.BackgroundColor = System.Drawing.SystemColors.ScrollBar
        Me.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clMENU_ID, Me.clMENU_IMAGE, Me.clMENU_TEXT})
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvList.Location = New System.Drawing.Point(0, 27)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersWidth = 30
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(352, 427)
        Me.dgvList.TabIndex = 4
        '
        'clMENU_ID
        '
        Me.clMENU_ID.HeaderText = "Name"
        Me.clMENU_ID.MinimumWidth = 125
        Me.clMENU_ID.Name = "clMENU_ID"
        Me.clMENU_ID.Width = 125
        '
        'clMENU_IMAGE
        '
        Me.clMENU_IMAGE.HeaderText = "Image"
        Me.clMENU_IMAGE.MinimumWidth = 60
        Me.clMENU_IMAGE.Name = "clMENU_IMAGE"
        Me.clMENU_IMAGE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clMENU_IMAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clMENU_IMAGE.Width = 60
        '
        'clMENU_TEXT
        '
        Me.clMENU_TEXT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clMENU_TEXT.HeaderText = "Text"
        Me.clMENU_TEXT.MinimumWidth = 125
        Me.clMENU_TEXT.Name = "clMENU_TEXT"
        '
        'Splitter
        '
        Me.Splitter.Location = New System.Drawing.Point(352, 27)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Size = New System.Drawing.Size(3, 427)
        Me.Splitter.TabIndex = 5
        Me.Splitter.TabStop = false
        '
        'labLine3
        '
        Me.labLine3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labLine3.Dock = System.Windows.Forms.DockStyle.Left
        Me.labLine3.Location = New System.Drawing.Point(355, 27)
        Me.labLine3.Name = "labLine3"
        Me.labLine3.Size = New System.Drawing.Size(2, 427)
        Me.labLine3.TabIndex = 6
        '
        'tblMaint
        '
        Me.tblMaint.ColumnCount = 5
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105!))
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125!))
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50!))
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tblMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tblMaint.Controls.Add(Me.txtMENU_NOTE, 1, 10)
        Me.tblMaint.Controls.Add(Me.txtFUNCTION_NAME, 1, 9)
        Me.tblMaint.Controls.Add(Me.txtCLASS_NAME, 1, 8)
        Me.tblMaint.Controls.Add(Me.cboSHORT_KEY, 1, 5)
        Me.tblMaint.Controls.Add(Me.txtMENU_CHINESE, 1, 3)
        Me.tblMaint.Controls.Add(Me.labMENU_ID, 0, 0)
        Me.tblMaint.Controls.Add(Me.labMENU_TEXT, 0, 1)
        Me.tblMaint.Controls.Add(Me.labMENU_ENGLISH, 0, 2)
        Me.tblMaint.Controls.Add(Me.labMENU_CHINESE, 0, 3)
        Me.tblMaint.Controls.Add(Me.txtMENU_ID, 1, 0)
        Me.tblMaint.Controls.Add(Me.labMENU_INDEX, 2, 0)
        Me.tblMaint.Controls.Add(Me.txtMENU_INDEX, 3, 0)
        Me.tblMaint.Controls.Add(Me.chkMENU_LINE, 4, 0)
        Me.tblMaint.Controls.Add(Me.txtMENU_TEXT, 1, 1)
        Me.tblMaint.Controls.Add(Me.txtMENU_ENGLISH, 1, 2)
        Me.tblMaint.Controls.Add(Me.labMENU_PARENT, 0, 4)
        Me.tblMaint.Controls.Add(Me.cboMENU_PARENT, 1, 4)
        Me.tblMaint.Controls.Add(Me.labSHORT_KEY, 0, 5)
        Me.tblMaint.Controls.Add(Me.labDLL_NAME, 0, 6)
        Me.tblMaint.Controls.Add(Me.labPROJECT_NAME, 0, 7)
        Me.tblMaint.Controls.Add(Me.labCLASS_NAME, 0, 8)
        Me.tblMaint.Controls.Add(Me.labFUNCTION_NAME, 0, 9)
        Me.tblMaint.Controls.Add(Me.txtDLL_NAME, 1, 6)
        Me.tblMaint.Controls.Add(Me.txtPROJECT_NAME, 1, 7)
        Me.tblMaint.Controls.Add(Me.labMENU_NOTE, 0, 10)
        Me.tblMaint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMaint.Location = New System.Drawing.Point(357, 27)
        Me.tblMaint.Name = "tblMaint"
        Me.tblMaint.RowCount = 12
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tblMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tblMaint.Size = New System.Drawing.Size(425, 427)
        Me.tblMaint.TabIndex = 7
        '
        'txtMENU_NOTE
        '
        Me.tblMaint.SetColumnSpan(Me.txtMENU_NOTE, 4)
        Me.txtMENU_NOTE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMENU_NOTE.Location = New System.Drawing.Point(108, 253)
        Me.txtMENU_NOTE.Multiline = true
        Me.txtMENU_NOTE.Name = "txtMENU_NOTE"
        Me.tblMaint.SetRowSpan(Me.txtMENU_NOTE, 2)
        Me.txtMENU_NOTE.Size = New System.Drawing.Size(314, 171)
        Me.txtMENU_NOTE.TabIndex = 24
        '
        'txtFUNCTION_NAME
        '
        Me.tblMaint.SetColumnSpan(Me.txtFUNCTION_NAME, 4)
        Me.txtFUNCTION_NAME.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtFUNCTION_NAME.Location = New System.Drawing.Point(108, 228)
        Me.txtFUNCTION_NAME.Name = "txtFUNCTION_NAME"
        Me.txtFUNCTION_NAME.Size = New System.Drawing.Size(314, 21)
        Me.txtFUNCTION_NAME.TabIndex = 23
        '
        'txtCLASS_NAME
        '
        Me.tblMaint.SetColumnSpan(Me.txtCLASS_NAME, 4)
        Me.txtCLASS_NAME.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtCLASS_NAME.Location = New System.Drawing.Point(108, 203)
        Me.txtCLASS_NAME.Name = "txtCLASS_NAME"
        Me.txtCLASS_NAME.Size = New System.Drawing.Size(314, 21)
        Me.txtCLASS_NAME.TabIndex = 22
        '
        'cboSHORT_KEY
        '
        Me.tblMaint.SetColumnSpan(Me.cboSHORT_KEY, 4)
        Me.cboSHORT_KEY.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboSHORT_KEY.FormattingEnabled = true
        Me.cboSHORT_KEY.Location = New System.Drawing.Point(108, 128)
        Me.cboSHORT_KEY.Name = "cboSHORT_KEY"
        Me.cboSHORT_KEY.Size = New System.Drawing.Size(314, 21)
        Me.cboSHORT_KEY.TabIndex = 14
        '
        'txtMENU_CHINESE
        '
        Me.tblMaint.SetColumnSpan(Me.txtMENU_CHINESE, 4)
        Me.txtMENU_CHINESE.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMENU_CHINESE.Location = New System.Drawing.Point(108, 78)
        Me.txtMENU_CHINESE.Name = "txtMENU_CHINESE"
        Me.txtMENU_CHINESE.Size = New System.Drawing.Size(314, 21)
        Me.txtMENU_CHINESE.TabIndex = 10
        '
        'labMENU_ID
        '
        Me.labMENU_ID.AutoSize = true
        Me.labMENU_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_ID.Location = New System.Drawing.Point(3, 0)
        Me.labMENU_ID.Name = "labMENU_ID"
        Me.labMENU_ID.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_ID.TabIndex = 0
        Me.labMENU_ID.Text = "Menu ID"
        Me.labMENU_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labMENU_TEXT
        '
        Me.labMENU_TEXT.AutoSize = true
        Me.labMENU_TEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_TEXT.Location = New System.Drawing.Point(3, 25)
        Me.labMENU_TEXT.Name = "labMENU_TEXT"
        Me.labMENU_TEXT.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_TEXT.TabIndex = 1
        Me.labMENU_TEXT.Text = "Vietnamese"
        Me.labMENU_TEXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labMENU_ENGLISH
        '
        Me.labMENU_ENGLISH.AutoSize = true
        Me.labMENU_ENGLISH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_ENGLISH.Location = New System.Drawing.Point(3, 50)
        Me.labMENU_ENGLISH.Name = "labMENU_ENGLISH"
        Me.labMENU_ENGLISH.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_ENGLISH.TabIndex = 2
        Me.labMENU_ENGLISH.Text = "English"
        Me.labMENU_ENGLISH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labMENU_CHINESE
        '
        Me.labMENU_CHINESE.AutoSize = true
        Me.labMENU_CHINESE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_CHINESE.Location = New System.Drawing.Point(3, 75)
        Me.labMENU_CHINESE.Name = "labMENU_CHINESE"
        Me.labMENU_CHINESE.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_CHINESE.TabIndex = 3
        Me.labMENU_CHINESE.Text = "Chinese"
        Me.labMENU_CHINESE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMENU_ID
        '
        Me.txtMENU_ID.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMENU_ID.Location = New System.Drawing.Point(108, 3)
        Me.txtMENU_ID.Name = "txtMENU_ID"
        Me.txtMENU_ID.Size = New System.Drawing.Size(119, 21)
        Me.txtMENU_ID.TabIndex = 4
        '
        'labMENU_INDEX
        '
        Me.labMENU_INDEX.AutoSize = true
        Me.labMENU_INDEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_INDEX.Location = New System.Drawing.Point(233, 0)
        Me.labMENU_INDEX.Name = "labMENU_INDEX"
        Me.labMENU_INDEX.Size = New System.Drawing.Size(44, 25)
        Me.labMENU_INDEX.TabIndex = 5
        Me.labMENU_INDEX.Text = "Index"
        Me.labMENU_INDEX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMENU_INDEX
        '
        Me.txtMENU_INDEX.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMENU_INDEX.Location = New System.Drawing.Point(283, 3)
        Me.txtMENU_INDEX.Name = "txtMENU_INDEX"
        Me.txtMENU_INDEX.Size = New System.Drawing.Size(29, 21)
        Me.txtMENU_INDEX.TabIndex = 6
        '
        'chkMENU_LINE
        '
        Me.chkMENU_LINE.AutoSize = true
        Me.chkMENU_LINE.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chkMENU_LINE.Location = New System.Drawing.Point(318, 5)
        Me.chkMENU_LINE.Name = "chkMENU_LINE"
        Me.chkMENU_LINE.Size = New System.Drawing.Size(104, 17)
        Me.chkMENU_LINE.TabIndex = 7
        Me.chkMENU_LINE.Text = "Is Line"
        Me.chkMENU_LINE.UseVisualStyleBackColor = true
        '
        'txtMENU_TEXT
        '
        Me.tblMaint.SetColumnSpan(Me.txtMENU_TEXT, 4)
        Me.txtMENU_TEXT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMENU_TEXT.Location = New System.Drawing.Point(108, 28)
        Me.txtMENU_TEXT.Name = "txtMENU_TEXT"
        Me.txtMENU_TEXT.Size = New System.Drawing.Size(314, 21)
        Me.txtMENU_TEXT.TabIndex = 8
        '
        'txtMENU_ENGLISH
        '
        Me.tblMaint.SetColumnSpan(Me.txtMENU_ENGLISH, 4)
        Me.txtMENU_ENGLISH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMENU_ENGLISH.Location = New System.Drawing.Point(108, 53)
        Me.txtMENU_ENGLISH.Name = "txtMENU_ENGLISH"
        Me.txtMENU_ENGLISH.Size = New System.Drawing.Size(314, 21)
        Me.txtMENU_ENGLISH.TabIndex = 9
        '
        'labMENU_PARENT
        '
        Me.labMENU_PARENT.AutoSize = true
        Me.labMENU_PARENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_PARENT.Location = New System.Drawing.Point(3, 100)
        Me.labMENU_PARENT.Name = "labMENU_PARENT"
        Me.labMENU_PARENT.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_PARENT.TabIndex = 11
        Me.labMENU_PARENT.Text = "Parent"
        Me.labMENU_PARENT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboMENU_PARENT
        '
        Me.tblMaint.SetColumnSpan(Me.cboMENU_PARENT, 4)
        Me.cboMENU_PARENT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboMENU_PARENT.FormattingEnabled = true
        Me.cboMENU_PARENT.Location = New System.Drawing.Point(108, 103)
        Me.cboMENU_PARENT.Name = "cboMENU_PARENT"
        Me.cboMENU_PARENT.Size = New System.Drawing.Size(314, 21)
        Me.cboMENU_PARENT.TabIndex = 12
        '
        'labSHORT_KEY
        '
        Me.labSHORT_KEY.AutoSize = true
        Me.labSHORT_KEY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labSHORT_KEY.Location = New System.Drawing.Point(3, 125)
        Me.labSHORT_KEY.Name = "labSHORT_KEY"
        Me.labSHORT_KEY.Size = New System.Drawing.Size(99, 25)
        Me.labSHORT_KEY.TabIndex = 13
        Me.labSHORT_KEY.Text = "Shortcut Key"
        Me.labSHORT_KEY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labDLL_NAME
        '
        Me.labDLL_NAME.AutoSize = true
        Me.labDLL_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labDLL_NAME.Location = New System.Drawing.Point(3, 150)
        Me.labDLL_NAME.Name = "labDLL_NAME"
        Me.labDLL_NAME.Size = New System.Drawing.Size(99, 25)
        Me.labDLL_NAME.TabIndex = 15
        Me.labDLL_NAME.Text = "Dll Name"
        Me.labDLL_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labPROJECT_NAME
        '
        Me.labPROJECT_NAME.AutoSize = true
        Me.labPROJECT_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labPROJECT_NAME.Location = New System.Drawing.Point(3, 175)
        Me.labPROJECT_NAME.Name = "labPROJECT_NAME"
        Me.labPROJECT_NAME.Size = New System.Drawing.Size(99, 25)
        Me.labPROJECT_NAME.TabIndex = 16
        Me.labPROJECT_NAME.Text = "Project Name"
        Me.labPROJECT_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labCLASS_NAME
        '
        Me.labCLASS_NAME.AutoSize = true
        Me.labCLASS_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labCLASS_NAME.Location = New System.Drawing.Point(3, 200)
        Me.labCLASS_NAME.Name = "labCLASS_NAME"
        Me.labCLASS_NAME.Size = New System.Drawing.Size(99, 25)
        Me.labCLASS_NAME.TabIndex = 17
        Me.labCLASS_NAME.Text = "Class Name"
        Me.labCLASS_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labFUNCTION_NAME
        '
        Me.labFUNCTION_NAME.AutoSize = true
        Me.labFUNCTION_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labFUNCTION_NAME.Location = New System.Drawing.Point(3, 225)
        Me.labFUNCTION_NAME.Name = "labFUNCTION_NAME"
        Me.labFUNCTION_NAME.Size = New System.Drawing.Size(99, 25)
        Me.labFUNCTION_NAME.TabIndex = 18
        Me.labFUNCTION_NAME.Text = "Function Name"
        Me.labFUNCTION_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDLL_NAME
        '
        Me.tblMaint.SetColumnSpan(Me.txtDLL_NAME, 4)
        Me.txtDLL_NAME.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDLL_NAME.Location = New System.Drawing.Point(108, 153)
        Me.txtDLL_NAME.Name = "txtDLL_NAME"
        Me.txtDLL_NAME.Size = New System.Drawing.Size(314, 21)
        Me.txtDLL_NAME.TabIndex = 20
        '
        'txtPROJECT_NAME
        '
        Me.tblMaint.SetColumnSpan(Me.txtPROJECT_NAME, 4)
        Me.txtPROJECT_NAME.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtPROJECT_NAME.Location = New System.Drawing.Point(108, 178)
        Me.txtPROJECT_NAME.Name = "txtPROJECT_NAME"
        Me.txtPROJECT_NAME.Size = New System.Drawing.Size(314, 21)
        Me.txtPROJECT_NAME.TabIndex = 21
        '
        'labMENU_NOTE
        '
        Me.labMENU_NOTE.AutoSize = true
        Me.labMENU_NOTE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMENU_NOTE.Location = New System.Drawing.Point(3, 250)
        Me.labMENU_NOTE.Name = "labMENU_NOTE"
        Me.labMENU_NOTE.Size = New System.Drawing.Size(99, 25)
        Me.labMENU_NOTE.TabIndex = 19
        Me.labMENU_NOTE.Text = "Note"
        Me.labMENU_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 125
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Image"
        Me.DataGridViewImageColumn1.MinimumWidth = 70
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Text"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 125
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'frmMenu
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Appearance.Options.UseFont = true
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 486)
        Me.Controls.Add(Me.tblMaint)
        Me.Controls.Add(Me.labLine3)
        Me.Controls.Add(Me.Splitter)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.labLine2)
        Me.Controls.Add(Me.labLine)
        Me.Controls.Add(Me.pelButton)
        Me.Controls.Add(Me.labTitle)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmMenu"
        Me.Text = "frmMenu"
        Me.pelButton.ResumeLayout(false)
        CType(Me.dgvList,System.ComponentModel.ISupportInitialize).EndInit
        Me.tblMaint.ResumeLayout(false)
        Me.tblMaint.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents pelButton As System.Windows.Forms.Panel
    Friend WithEvents labLine As System.Windows.Forms.Label
    Friend WithEvents labLine2 As System.Windows.Forms.Label
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Splitter As System.Windows.Forms.Splitter
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents clMENU_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMENU_IMAGE As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents clMENU_TEXT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents labLine3 As System.Windows.Forms.Label
    Friend WithEvents tblMaint As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtMENU_NOTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFUNCTION_NAME As System.Windows.Forms.TextBox
    Friend WithEvents txtCLASS_NAME As System.Windows.Forms.TextBox
    Friend WithEvents cboSHORT_KEY As System.Windows.Forms.ComboBox
    Friend WithEvents txtMENU_CHINESE As System.Windows.Forms.TextBox
    Friend WithEvents labMENU_ID As System.Windows.Forms.Label
    Friend WithEvents labMENU_TEXT As System.Windows.Forms.Label
    Friend WithEvents labMENU_ENGLISH As System.Windows.Forms.Label
    Friend WithEvents labMENU_CHINESE As System.Windows.Forms.Label
    Friend WithEvents txtMENU_ID As System.Windows.Forms.TextBox
    Friend WithEvents labMENU_INDEX As System.Windows.Forms.Label
    Friend WithEvents txtMENU_INDEX As System.Windows.Forms.TextBox
    Friend WithEvents chkMENU_LINE As System.Windows.Forms.CheckBox
    Friend WithEvents txtMENU_TEXT As System.Windows.Forms.TextBox
    Friend WithEvents txtMENU_ENGLISH As System.Windows.Forms.TextBox
    Friend WithEvents labMENU_PARENT As System.Windows.Forms.Label
    Friend WithEvents cboMENU_PARENT As System.Windows.Forms.ComboBox
    Friend WithEvents labSHORT_KEY As System.Windows.Forms.Label
    Friend WithEvents labDLL_NAME As System.Windows.Forms.Label
    Friend WithEvents labPROJECT_NAME As System.Windows.Forms.Label
    Friend WithEvents labCLASS_NAME As System.Windows.Forms.Label
    Friend WithEvents labFUNCTION_NAME As System.Windows.Forms.Label
    Friend WithEvents txtDLL_NAME As System.Windows.Forms.TextBox
    Friend WithEvents txtPROJECT_NAME As System.Windows.Forms.TextBox
    Friend WithEvents labMENU_NOTE As System.Windows.Forms.Label
End Class
