<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStreet
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.labCode = New System.Windows.Forms.Label
        Me.labNameViet = New System.Windows.Forms.Label
        Me.labNameEnglish = New System.Windows.Forms.Label
        Me.labNameChina = New System.Windows.Forms.Label
        Me.labNote = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.txtNameViet = New System.Windows.Forms.TextBox
        Me.txtNameEnglish = New System.Windows.Forms.TextBox
        Me.txtNameChina = New System.Windows.Forms.TextBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.labTitle = New System.Windows.Forms.Label
        Me.grvList = New System.Windows.Forms.DataGridView
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNameViet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNameEnglish = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNameChina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.labCode, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.labNameViet, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.labNameEnglish, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.labNameChina, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.labNote, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNameViet, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNameEnglish, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNameChina, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNote, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.labTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grvList, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(600, 424)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'labCode
        '
        Me.labCode.AutoSize = True
        Me.labCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labCode.Location = New System.Drawing.Point(3, 45)
        Me.labCode.Name = "labCode"
        Me.labCode.Size = New System.Drawing.Size(73, 27)
        Me.labCode.TabIndex = 0
        Me.labCode.Text = "Mã số"
        Me.labCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labNameViet
        '
        Me.labNameViet.AutoSize = True
        Me.labNameViet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNameViet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNameViet.Location = New System.Drawing.Point(3, 72)
        Me.labNameViet.Name = "labNameViet"
        Me.labNameViet.Size = New System.Drawing.Size(73, 27)
        Me.labNameViet.TabIndex = 1
        Me.labNameViet.Text = "Tên tiếng việt"
        Me.labNameViet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labNameEnglish
        '
        Me.labNameEnglish.AutoSize = True
        Me.labNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNameEnglish.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNameEnglish.Location = New System.Drawing.Point(3, 99)
        Me.labNameEnglish.Name = "labNameEnglish"
        Me.labNameEnglish.Size = New System.Drawing.Size(73, 27)
        Me.labNameEnglish.TabIndex = 2
        Me.labNameEnglish.Text = "Tên tiếng anh"
        Me.labNameEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labNameChina
        '
        Me.labNameChina.AutoSize = True
        Me.labNameChina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNameChina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNameChina.Location = New System.Drawing.Point(3, 126)
        Me.labNameChina.Name = "labNameChina"
        Me.labNameChina.Size = New System.Drawing.Size(73, 27)
        Me.labNameChina.TabIndex = 3
        Me.labNameChina.Text = "Tên tiếng hoa"
        Me.labNameChina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labNote
        '
        Me.labNote.AutoSize = True
        Me.labNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNote.Location = New System.Drawing.Point(271, 45)
        Me.labNote.Name = "labNote"
        Me.labNote.Size = New System.Drawing.Size(42, 27)
        Me.labNote.TabIndex = 4
        Me.labNote.Text = "Ghi chú"
        Me.labNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCode
        '
        Me.txtCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(82, 48)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(183, 21)
        Me.txtCode.TabIndex = 5
        '
        'txtNameViet
        '
        Me.txtNameViet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNameViet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameViet.Location = New System.Drawing.Point(82, 75)
        Me.txtNameViet.Name = "txtNameViet"
        Me.txtNameViet.Size = New System.Drawing.Size(183, 21)
        Me.txtNameViet.TabIndex = 6
        '
        'txtNameEnglish
        '
        Me.txtNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNameEnglish.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameEnglish.Location = New System.Drawing.Point(82, 102)
        Me.txtNameEnglish.Name = "txtNameEnglish"
        Me.txtNameEnglish.Size = New System.Drawing.Size(183, 21)
        Me.txtNameEnglish.TabIndex = 7
        '
        'txtNameChina
        '
        Me.txtNameChina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNameChina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameChina.Location = New System.Drawing.Point(82, 129)
        Me.txtNameChina.Name = "txtNameChina"
        Me.txtNameChina.Size = New System.Drawing.Size(183, 21)
        Me.txtNameChina.TabIndex = 8
        '
        'txtNote
        '
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(319, 48)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.TableLayoutPanel1.SetRowSpan(Me.txtNote, 4)
        Me.txtNote.Size = New System.Drawing.Size(278, 102)
        Me.txtNote.TabIndex = 9
        '
        'labTitle
        '
        Me.labTitle.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.labTitle, 4)
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTitle.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.labTitle.Location = New System.Drawing.Point(3, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(594, 45)
        Me.labTitle.TabIndex = 10
        Me.labTitle.Text = "DANH SÁCH ĐƯỜNG"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grvList
        '
        Me.grvList.AllowUserToAddRows = False
        Me.grvList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameViet, Me.colNameEnglish, Me.colNameChina, Me.colNote})
        Me.TableLayoutPanel1.SetColumnSpan(Me.grvList, 4)
        Me.grvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvList.Location = New System.Drawing.Point(3, 156)
        Me.grvList.Name = "grvList"
        Me.grvList.Size = New System.Drawing.Size(594, 230)
        Me.grvList.TabIndex = 11
        '
        'colId
        '
        Me.colId.HeaderText = "Mã số"
        Me.colId.MinimumWidth = 120
        Me.colId.Name = "colId"
        Me.colId.Width = 120
        '
        'colNameViet
        '
        Me.colNameViet.HeaderText = "Tên tiếng việt"
        Me.colNameViet.MinimumWidth = 150
        Me.colNameViet.Name = "colNameViet"
        Me.colNameViet.Width = 150
        '
        'colNameEnglish
        '
        Me.colNameEnglish.HeaderText = "Tên tiếng anh"
        Me.colNameEnglish.MinimumWidth = 150
        Me.colNameEnglish.Name = "colNameEnglish"
        Me.colNameEnglish.Width = 150
        '
        'colNameChina
        '
        Me.colNameChina.HeaderText = "Tên tiếng hoa"
        Me.colNameChina.MinimumWidth = 150
        Me.colNameChina.Name = "colNameChina"
        Me.colNameChina.Width = 150
        '
        'colNote
        '
        Me.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNote.HeaderText = "Ghi chú"
        Me.colNote.MinimumWidth = 150
        Me.colNote.Name = "colNote"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Panel1.Size = New System.Drawing.Size(594, 29)
        Me.Panel1.TabIndex = 12
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(519, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
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
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
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
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
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
        Me.btnEdit.Size = New System.Drawing.Size(75, 25)
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
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
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
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
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
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&Thêm"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Mã số"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tên tiếng việt"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tên tiếng anh"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tên tiếng hoa"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'frmStreet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 424)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmStreet"
        Me.Text = "frmStreet"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labCode As System.Windows.Forms.Label
    Friend WithEvents labNameViet As System.Windows.Forms.Label
    Friend WithEvents labNameEnglish As System.Windows.Forms.Label
    Friend WithEvents labNameChina As System.Windows.Forms.Label
    Friend WithEvents labNote As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtNameViet As System.Windows.Forms.TextBox
    Friend WithEvents txtNameEnglish As System.Windows.Forms.TextBox
    Friend WithEvents txtNameChina As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents grvList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNameViet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNameEnglish As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNameChina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
