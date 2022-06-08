<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClassProblem
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.grvRemdyList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCause_Name = New System.Windows.Forms.Label()
        Me.lblCause_Code = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grvRemedyList = New System.Windows.Forms.DataGridView()
        Me.grvProblemList = New System.Windows.Forms.DataGridView()
        Me.btnChoice = New DevExpress.XtraEditors.SimpleButton()
        Me.grvCauseList = New System.Windows.Forms.DataGridView()
        Me.labClassCode = New System.Windows.Forms.Label()
        Me.txtClassCode = New System.Windows.Forms.TextBox()
        Me.txtClassName = New System.Windows.Forms.TextBox()
        Me.labClassName = New System.Windows.Forms.Label()
        Me.labClassNote = New System.Windows.Forms.Label()
        Me.txtClassNote = New System.Windows.Forms.TextBox()
        Me.grvClassList = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.grvRemdyList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grvRemedyList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvProblemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCauseList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvClassList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.grvRemdyList, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.lblCause_Name, 0, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 5
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'grvRemdyList
        '
        Me.grvRemdyList.AllowUserToAddRows = False
        Me.grvRemdyList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvRemdyList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvRemdyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvRemdyList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.TableLayoutPanel6.SetColumnSpan(Me.grvRemdyList, 2)
        Me.grvRemdyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvRemdyList.Location = New System.Drawing.Point(3, 83)
        Me.grvRemdyList.MultiSelect = False
        Me.grvRemdyList.Name = "grvRemdyList"
        Me.grvRemdyList.ReadOnly = True
        Me.grvRemdyList.Size = New System.Drawing.Size(194, 14)
        Me.grvRemdyList.TabIndex = 14
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "REMEDY_CODE"
        Me.DataGridViewTextBoxColumn1.HeaderText = "REMEDY_CODE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "REMEDY_ID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "REMEDY_ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "REMEDY_NAME"
        Me.DataGridViewTextBoxColumn3.HeaderText = "REMEDY_NAME"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 51
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LINK"
        Me.DataGridViewTextBoxColumn4.HeaderText = "REMEDY_LINK"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'lblCause_Name
        '
        Me.lblCause_Name.AutoSize = True
        Me.lblCause_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCause_Name.Location = New System.Drawing.Point(3, 0)
        Me.lblCause_Name.Name = "lblCause_Name"
        Me.lblCause_Name.Size = New System.Drawing.Size(68, 20)
        Me.lblCause_Name.TabIndex = 0
        Me.lblCause_Name.Text = "Cause Name"
        Me.lblCause_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCause_Code
        '
        Me.lblCause_Code.AutoSize = True
        Me.lblCause_Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCause_Code.Location = New System.Drawing.Point(3, 25)
        Me.lblCause_Code.Name = "lblCause_Code"
        Me.lblCause_Code.Size = New System.Drawing.Size(68, 25)
        Me.lblCause_Code.TabIndex = 0
        Me.lblCause_Code.Text = "Cause Code"
        Me.lblCause_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grvRemedyList, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grvProblemList, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChoice, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.grvCauseList, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.labClassCode, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtClassCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtClassName, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.labClassName, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.labClassNote, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtClassNote, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(320, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(955, 582)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'grvRemedyList
        '
        Me.grvRemedyList.AllowUserToAddRows = False
        Me.grvRemedyList.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grvRemedyList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grvRemedyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.grvRemedyList, 4)
        Me.grvRemedyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvRemedyList.Location = New System.Drawing.Point(3, 426)
        Me.grvRemedyList.MultiSelect = False
        Me.grvRemedyList.Name = "grvRemedyList"
        Me.grvRemedyList.ReadOnly = True
        Me.grvRemedyList.Size = New System.Drawing.Size(949, 153)
        Me.grvRemedyList.TabIndex = 6
        '
        'grvProblemList
        '
        Me.grvProblemList.AllowUserToAddRows = False
        Me.grvProblemList.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvProblemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grvProblemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.grvProblemList, 4)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvProblemList.DefaultCellStyle = DataGridViewCellStyle4
        Me.grvProblemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvProblemList.Location = New System.Drawing.Point(3, 78)
        Me.grvProblemList.MultiSelect = False
        Me.grvProblemList.Name = "grvProblemList"
        Me.grvProblemList.ReadOnly = True
        Me.grvProblemList.Size = New System.Drawing.Size(949, 152)
        Me.grvProblemList.TabIndex = 3
        '
        'btnChoice
        '
        Me.btnChoice.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChoice.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnChoice.Appearance.Options.UseFont = True
        Me.btnChoice.Appearance.Options.UseForeColor = True
        Me.btnChoice.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnChoice.Location = New System.Drawing.Point(875, 236)
        Me.btnChoice.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btnChoice.Name = "btnChoice"
        Me.btnChoice.Size = New System.Drawing.Size(80, 26)
        Me.btnChoice.TabIndex = 4
        Me.btnChoice.Text = "&Chọn"
        '
        'grvCauseList
        '
        Me.grvCauseList.AllowUserToAddRows = False
        Me.grvCauseList.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvCauseList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grvCauseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.grvCauseList, 4)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvCauseList.DefaultCellStyle = DataGridViewCellStyle6
        Me.grvCauseList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvCauseList.Location = New System.Drawing.Point(3, 268)
        Me.grvCauseList.MultiSelect = False
        Me.grvCauseList.Name = "grvCauseList"
        Me.grvCauseList.ReadOnly = True
        Me.grvCauseList.Size = New System.Drawing.Size(949, 152)
        Me.grvCauseList.TabIndex = 5
        '
        'labClassCode
        '
        Me.labClassCode.AutoSize = True
        Me.labClassCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labClassCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labClassCode.Location = New System.Drawing.Point(3, 0)
        Me.labClassCode.Name = "labClassCode"
        Me.labClassCode.Size = New System.Drawing.Size(55, 25)
        Me.labClassCode.TabIndex = 0
        Me.labClassCode.Text = "Mã class"
        Me.labClassCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClassCode
        '
        Me.txtClassCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClassCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassCode.Location = New System.Drawing.Point(64, 3)
        Me.txtClassCode.Name = "txtClassCode"
        Me.txtClassCode.Size = New System.Drawing.Size(408, 21)
        Me.txtClassCode.TabIndex = 0
        '
        'txtClassName
        '
        Me.txtClassName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClassName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassName.Location = New System.Drawing.Point(543, 3)
        Me.txtClassName.Name = "txtClassName"
        Me.txtClassName.Size = New System.Drawing.Size(409, 21)
        Me.txtClassName.TabIndex = 1
        '
        'labClassName
        '
        Me.labClassName.AutoSize = True
        Me.labClassName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labClassName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labClassName.Location = New System.Drawing.Point(478, 0)
        Me.labClassName.Name = "labClassName"
        Me.labClassName.Size = New System.Drawing.Size(59, 25)
        Me.labClassName.TabIndex = 0
        Me.labClassName.Text = "Tên class"
        Me.labClassName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labClassNote
        '
        Me.labClassNote.AutoSize = True
        Me.labClassNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labClassNote.Location = New System.Drawing.Point(3, 25)
        Me.labClassNote.Name = "labClassNote"
        Me.labClassNote.Size = New System.Drawing.Size(42, 13)
        Me.labClassNote.TabIndex = 0
        Me.labClassNote.Text = "Ghi chú"
        Me.labClassNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClassNote
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtClassNote, 3)
        Me.txtClassNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClassNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassNote.Location = New System.Drawing.Point(64, 28)
        Me.txtClassNote.Multiline = True
        Me.txtClassNote.Name = "txtClassNote"
        Me.TableLayoutPanel1.SetRowSpan(Me.txtClassNote, 2)
        Me.txtClassNote.Size = New System.Drawing.Size(888, 44)
        Me.txtClassNote.TabIndex = 2
        '
        'grvClassList
        '
        Me.grvClassList.AllowUserToAddRows = False
        Me.grvClassList.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvClassList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvClassList.DefaultCellStyle = DataGridViewCellStyle8
        Me.grvClassList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvClassList.Location = New System.Drawing.Point(0, 0)
        Me.grvClassList.MultiSelect = False
        Me.grvClassList.Name = "grvClassList"
        Me.grvClassList.ReadOnly = True
        Me.grvClassList.Size = New System.Drawing.Size(320, 579)
        Me.grvClassList.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAdd)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnEdit)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnExit)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 617)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1275, 30)
        Me.Panel4.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Appearance.Options.UseForeColor = True
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAdd.Location = New System.Drawing.Point(687, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 30)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "&Thêm"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(785, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 30)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(883, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 30)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Hủy"
        Me.btnCancel.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.Appearance.Options.UseFont = True
        Me.btnEdit.Appearance.Options.UseForeColor = True
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEdit.Location = New System.Drawing.Point(981, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(98, 30)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "&Sửa"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Appearance.Options.UseForeColor = True
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelete.Location = New System.Drawing.Point(1079, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 30)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "&Xóa"
        '
        'btnExit
        '
        Me.btnExit.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExit.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnExit.Appearance.Options.UseFont = True
        Me.btnExit.Appearance.Options.UseForeColor = True
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(1177, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 30)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Th&oát"
        Me.btnExit.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grvClassList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(320, 582)
        Me.Panel1.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(320, 35)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 582)
        Me.Splitter1.TabIndex = 23
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1275, 35)
        Me.Panel2.TabIndex = 24
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(1215, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(60, 35)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(31, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(28, 33)
        Me.btnVideo.TabIndex = 99
        Me.btnVideo.Tag = "CMMS!frmClassProblem"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 33)
        Me.btnHelp.TabIndex = 98
        Me.btnHelp.Tag = "CMMS!frmClassProblem"
        '
        'frmClassProblem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 647)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmClassProblem"
        Me.Text = "Problem Of Class"
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.grvRemdyList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grvRemedyList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvProblemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCauseList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvClassList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grvRemdyList As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCause_Name As System.Windows.Forms.Label
    Friend WithEvents lblCause_Code As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grvProblemList As System.Windows.Forms.DataGridView
    Friend WithEvents labClassName As System.Windows.Forms.Label
    Friend WithEvents labClassCode As System.Windows.Forms.Label
    Friend WithEvents txtClassName As System.Windows.Forms.TextBox
    Friend WithEvents txtClassCode As System.Windows.Forms.TextBox
    Friend WithEvents txtClassNote As System.Windows.Forms.TextBox
    Friend WithEvents labClassNote As System.Windows.Forms.Label
    Friend WithEvents btnChoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grvClassList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grvCauseList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents grvRemedyList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
