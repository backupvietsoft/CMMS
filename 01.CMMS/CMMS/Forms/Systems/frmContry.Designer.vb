<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContry
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnPCBT = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.labHeader = New System.Windows.Forms.Label
        Me.trvList = New System.Windows.Forms.TreeView
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.labMS = New System.Windows.Forms.Label
        Me.labTEN_V = New System.Windows.Forms.Label
        Me.labTEN_A = New System.Windows.Forms.Label
        Me.labTEN_H = New System.Windows.Forms.Label
        Me.labGHI_CHU = New System.Windows.Forms.Label
        Me.txtMS = New System.Windows.Forms.TextBox
        Me.txtTEN_V = New System.Windows.Forms.TextBox
        Me.txtTEN_A = New System.Windows.Forms.TextBox
        Me.txtTEN_H = New System.Windows.Forms.TextBox
        Me.txtGHI_CHU = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tapDetial = New System.Windows.Forms.TabPage
        Me.grvDetial = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnChoice = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMS_QG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTEN_V = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTEN_A = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTEN_H = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGHI_CHU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tapDetial.SuspendLayout()
        CType(Me.grvDetial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnPCBT)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 405)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Panel1.Size = New System.Drawing.Size(676, 30)
        Me.Panel1.TabIndex = 0
        '
        'btnPCBT
        '
        Me.btnPCBT.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPCBT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPCBT.Location = New System.Drawing.Point(450, 2)
        Me.btnPCBT.Name = "btnPCBT"
        Me.btnPCBT.Size = New System.Drawing.Size(75, 26)
        Me.btnPCBT.TabIndex = 7
        Me.btnPCBT.Text = "&In"
        Me.btnPCBT.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(601, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 26)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Th&oát"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(375, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 26)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "&In"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(300, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 26)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "&Xóa"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(225, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 26)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "&Sửa"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(150, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 26)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Hủy"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(75, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 26)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(0, 2)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 26)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&Thêm"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'labHeader
        '
        Me.labHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.labHeader.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.labHeader.Location = New System.Drawing.Point(0, 0)
        Me.labHeader.Name = "labHeader"
        Me.labHeader.Size = New System.Drawing.Size(676, 48)
        Me.labHeader.TabIndex = 1
        Me.labHeader.Text = "DANH SÁCH ĐƠN VỊ HÀNH CHÍNH"
        Me.labHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trvList
        '
        Me.trvList.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvList.Location = New System.Drawing.Point(0, 48)
        Me.trvList.Name = "trvList"
        Me.trvList.Size = New System.Drawing.Size(363, 357)
        Me.trvList.TabIndex = 2
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(363, 48)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 357)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.labMS, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.labTEN_V, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.labTEN_A, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.labTEN_H, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.labGHI_CHU, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMS, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTEN_V, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTEN_A, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTEN_H, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGHI_CHU, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(368, 48)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(308, 357)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'labMS
        '
        Me.labMS.AutoSize = True
        Me.labMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labMS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labMS.Location = New System.Drawing.Point(3, 0)
        Me.labMS.Name = "labMS"
        Me.labMS.Size = New System.Drawing.Size(85, 27)
        Me.labMS.TabIndex = 0
        Me.labMS.Text = "Mã số"
        Me.labMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labTEN_V
        '
        Me.labTEN_V.AutoSize = True
        Me.labTEN_V.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTEN_V.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTEN_V.Location = New System.Drawing.Point(3, 27)
        Me.labTEN_V.Name = "labTEN_V"
        Me.labTEN_V.Size = New System.Drawing.Size(85, 27)
        Me.labTEN_V.TabIndex = 1
        Me.labTEN_V.Text = "Tên tiếng việt"
        Me.labTEN_V.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labTEN_A
        '
        Me.labTEN_A.AutoSize = True
        Me.labTEN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTEN_A.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTEN_A.Location = New System.Drawing.Point(3, 54)
        Me.labTEN_A.Name = "labTEN_A"
        Me.labTEN_A.Size = New System.Drawing.Size(85, 27)
        Me.labTEN_A.TabIndex = 2
        Me.labTEN_A.Text = "Tên tiếng anh"
        Me.labTEN_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labTEN_H
        '
        Me.labTEN_H.AutoSize = True
        Me.labTEN_H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTEN_H.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTEN_H.Location = New System.Drawing.Point(3, 81)
        Me.labTEN_H.Name = "labTEN_H"
        Me.labTEN_H.Size = New System.Drawing.Size(85, 27)
        Me.labTEN_H.TabIndex = 3
        Me.labTEN_H.Text = "Tên tiếng hoa"
        Me.labTEN_H.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labGHI_CHU
        '
        Me.labGHI_CHU.AutoSize = True
        Me.labGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labGHI_CHU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labGHI_CHU.Location = New System.Drawing.Point(178, 0)
        Me.labGHI_CHU.Name = "labGHI_CHU"
        Me.labGHI_CHU.Size = New System.Drawing.Size(42, 27)
        Me.labGHI_CHU.TabIndex = 4
        Me.labGHI_CHU.Text = "Ghi chú"
        Me.labGHI_CHU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMS
        '
        Me.txtMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMS.Location = New System.Drawing.Point(94, 3)
        Me.txtMS.Name = "txtMS"
        Me.txtMS.Size = New System.Drawing.Size(78, 21)
        Me.txtMS.TabIndex = 5
        '
        'txtTEN_V
        '
        Me.txtTEN_V.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_V.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTEN_V.Location = New System.Drawing.Point(94, 30)
        Me.txtTEN_V.Name = "txtTEN_V"
        Me.txtTEN_V.Size = New System.Drawing.Size(78, 21)
        Me.txtTEN_V.TabIndex = 6
        '
        'txtTEN_A
        '
        Me.txtTEN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_A.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTEN_A.Location = New System.Drawing.Point(94, 57)
        Me.txtTEN_A.Name = "txtTEN_A"
        Me.txtTEN_A.Size = New System.Drawing.Size(78, 21)
        Me.txtTEN_A.TabIndex = 7
        '
        'txtTEN_H
        '
        Me.txtTEN_H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_H.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTEN_H.Location = New System.Drawing.Point(94, 84)
        Me.txtTEN_H.Name = "txtTEN_H"
        Me.txtTEN_H.Size = New System.Drawing.Size(78, 21)
        Me.txtTEN_H.TabIndex = 8
        '
        'txtGHI_CHU
        '
        Me.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGHI_CHU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGHI_CHU.Location = New System.Drawing.Point(226, 3)
        Me.txtGHI_CHU.Multiline = True
        Me.txtGHI_CHU.Name = "txtGHI_CHU"
        Me.TableLayoutPanel1.SetRowSpan(Me.txtGHI_CHU, 4)
        Me.txtGHI_CHU.Size = New System.Drawing.Size(79, 102)
        Me.txtGHI_CHU.TabIndex = 9
        '
        'TabControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 4)
        Me.TabControl1.Controls.Add(Me.tapDetial)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 108)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(308, 249)
        Me.TabControl1.TabIndex = 10
        '
        'tapDetial
        '
        Me.tapDetial.Controls.Add(Me.grvDetial)
        Me.tapDetial.Controls.Add(Me.Panel2)
        Me.tapDetial.Location = New System.Drawing.Point(4, 22)
        Me.tapDetial.Name = "tapDetial"
        Me.tapDetial.Padding = New System.Windows.Forms.Padding(3)
        Me.tapDetial.Size = New System.Drawing.Size(300, 223)
        Me.tapDetial.TabIndex = 0
        Me.tapDetial.Text = "Danh sách đường"
        Me.tapDetial.UseVisualStyleBackColor = True
        '
        'grvDetial
        '
        Me.grvDetial.AllowUserToAddRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grvDetial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvDetial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMS_QG, Me.colMS, Me.colTEN_V, Me.colTEN_A, Me.colTEN_H, Me.colGHI_CHU})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvDetial.DefaultCellStyle = DataGridViewCellStyle2
        Me.grvDetial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvDetial.Location = New System.Drawing.Point(3, 3)
        Me.grvDetial.Name = "grvDetial"
        Me.grvDetial.ReadOnly = True
        Me.grvDetial.Size = New System.Drawing.Size(294, 187)
        Me.grvDetial.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnChoice)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 190)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Panel2.Size = New System.Drawing.Size(294, 30)
        Me.Panel2.TabIndex = 1
        '
        'btnChoice
        '
        Me.btnChoice.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnChoice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChoice.Location = New System.Drawing.Point(0, 2)
        Me.btnChoice.Name = "btnChoice"
        Me.btnChoice.Size = New System.Drawing.Size(75, 26)
        Me.btnChoice.TabIndex = 6
        Me.btnChoice.Text = "&Chọn"
        Me.btnChoice.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Mã số"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 129
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tên tiếng việt"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tên tiếng anh"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tên tiếng hoa"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'colMS_QG
        '
        Me.colMS_QG.HeaderText = ""
        Me.colMS_QG.Name = "colMS_QG"
        Me.colMS_QG.ReadOnly = True
        Me.colMS_QG.Visible = False
        '
        'colMS
        '
        Me.colMS.HeaderText = "Mã số"
        Me.colMS.Name = "colMS"
        Me.colMS.ReadOnly = True
        Me.colMS.Width = 129
        '
        'colTEN_V
        '
        Me.colTEN_V.HeaderText = "Tên tiếng việt"
        Me.colTEN_V.Name = "colTEN_V"
        Me.colTEN_V.ReadOnly = True
        Me.colTEN_V.Width = 150
        '
        'colTEN_A
        '
        Me.colTEN_A.HeaderText = "Tên tiếng anh"
        Me.colTEN_A.Name = "colTEN_A"
        Me.colTEN_A.ReadOnly = True
        Me.colTEN_A.Width = 150
        '
        'colTEN_H
        '
        Me.colTEN_H.HeaderText = "Tên tiếng hoa"
        Me.colTEN_H.Name = "colTEN_H"
        Me.colTEN_H.ReadOnly = True
        Me.colTEN_H.Width = 150
        '
        'colGHI_CHU
        '
        Me.colGHI_CHU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colGHI_CHU.HeaderText = "Ghi chú"
        Me.colGHI_CHU.MinimumWidth = 150
        Me.colGHI_CHU.Name = "colGHI_CHU"
        Me.colGHI_CHU.ReadOnly = True
        '
        'frmContry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 435)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.trvList)
        Me.Controls.Add(Me.labHeader)
        Me.Controls.Add(Me.Panel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmContry"
        Me.Text = "frmContry"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tapDetial.ResumeLayout(False)
        CType(Me.grvDetial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labHeader As System.Windows.Forms.Label
    Friend WithEvents trvList As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labMS As System.Windows.Forms.Label
    Friend WithEvents labTEN_V As System.Windows.Forms.Label
    Friend WithEvents labTEN_A As System.Windows.Forms.Label
    Friend WithEvents labTEN_H As System.Windows.Forms.Label
    Friend WithEvents labGHI_CHU As System.Windows.Forms.Label
    Friend WithEvents txtMS As System.Windows.Forms.TextBox
    Friend WithEvents txtTEN_V As System.Windows.Forms.TextBox
    Friend WithEvents txtTEN_A As System.Windows.Forms.TextBox
    Friend WithEvents txtTEN_H As System.Windows.Forms.TextBox
    Friend WithEvents txtGHI_CHU As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tapDetial As System.Windows.Forms.TabPage
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grvDetial As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnChoice As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMS_QG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTEN_V As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTEN_A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTEN_H As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGHI_CHU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPCBT As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
