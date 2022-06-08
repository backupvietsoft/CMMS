<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCauseRemedy
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.grvCauseList = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.grvRemdyList = New System.Windows.Forms.DataGridView()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.labNote = New System.Windows.Forms.Label()
        Me.labCauseCode = New System.Windows.Forms.Label()
        Me.txtCauseCode = New System.Windows.Forms.TextBox()
        Me.txtCauseName = New System.Windows.Forms.TextBox()
        Me.labCauseName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel4.SuspendLayout
        CType(Me.grvCauseList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel6.SuspendLayout
        CType(Me.grvRemdyList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
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
        Me.Panel4.Location = New System.Drawing.Point(0, 711)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1277, 30)
        Me.Panel4.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.btnAdd.Appearance.Options.UseFont = true
        Me.btnAdd.Appearance.Options.UseForeColor = true
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAdd.Location = New System.Drawing.Point(689, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 30)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Thêm"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.btnSave.Appearance.Options.UseFont = true
        Me.btnSave.Appearance.Options.UseForeColor = true
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(787, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 30)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.Visible = false
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Appearance.Options.UseFont = true
        Me.btnCancel.Appearance.Options.UseForeColor = true
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(885, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Hủy"
        Me.btnCancel.Visible = false
        '
        'btnEdit
        '
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.btnEdit.Appearance.Options.UseFont = true
        Me.btnEdit.Appearance.Options.UseForeColor = true
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEdit.Location = New System.Drawing.Point(983, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(98, 30)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "&Sửa"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.btnDelete.Appearance.Options.UseFont = true
        Me.btnDelete.Appearance.Options.UseForeColor = true
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelete.Location = New System.Drawing.Point(1081, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 30)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "&Xóa"
        '
        'btnExit
        '
        Me.btnExit.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.btnExit.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnExit.Appearance.Options.UseFont = true
        Me.btnExit.Appearance.Options.UseForeColor = true
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(1179, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 30)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Th&oát"
        '
        'grvCauseList
        '
        Me.grvCauseList.AllowUserToAddRows = false
        Me.grvCauseList.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grvCauseList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvCauseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvCauseList.DefaultCellStyle = DataGridViewCellStyle2
        Me.grvCauseList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvCauseList.Location = New System.Drawing.Point(0, 0)
        Me.grvCauseList.MultiSelect = false
        Me.grvCauseList.Name = "grvCauseList"
        Me.grvCauseList.ReadOnly = true
        Me.grvCauseList.RowHeadersWidth = 35
        Me.grvCauseList.Size = New System.Drawing.Size(333, 675)
        Me.grvCauseList.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel6.Controls.Add(Me.grvRemdyList, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.txtNote, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.labNote, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.labCauseCode, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.txtCauseCode, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.txtCauseName, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.labCauseName, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(333, 33)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 5
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(944, 678)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'grvRemdyList
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvRemdyList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grvRemdyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel6.SetColumnSpan(Me.grvRemdyList, 2)
        Me.grvRemdyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvRemdyList.Location = New System.Drawing.Point(3, 103)
        Me.grvRemdyList.MultiSelect = false
        Me.grvRemdyList.Name = "grvRemdyList"
        Me.grvRemdyList.RowHeadersWidth = 35
        Me.grvRemdyList.Size = New System.Drawing.Size(938, 572)
        Me.grvRemdyList.TabIndex = 3
        '
        'txtNote
        '
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNote.Location = New System.Drawing.Point(113, 53)
        Me.txtNote.Multiline = true
        Me.txtNote.Name = "txtNote"
        Me.TableLayoutPanel6.SetRowSpan(Me.txtNote, 2)
        Me.txtNote.Size = New System.Drawing.Size(828, 44)
        Me.txtNote.TabIndex = 2
        '
        'labNote
        '
        Me.labNote.AutoSize = true
        Me.labNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labNote.Location = New System.Drawing.Point(3, 50)
        Me.labNote.Name = "labNote"
        Me.labNote.Size = New System.Drawing.Size(104, 25)
        Me.labNote.TabIndex = 0
        Me.labNote.Text = "Ghi chú"
        Me.labNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labCauseCode
        '
        Me.labCauseCode.AutoSize = true
        Me.labCauseCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labCauseCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labCauseCode.Location = New System.Drawing.Point(3, 0)
        Me.labCauseCode.Name = "labCauseCode"
        Me.labCauseCode.Size = New System.Drawing.Size(104, 25)
        Me.labCauseCode.TabIndex = 0
        Me.labCauseCode.Text = "Mã nguyên nhân"
        Me.labCauseCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCauseCode
        '
        Me.txtCauseCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCauseCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCauseCode.Location = New System.Drawing.Point(113, 3)
        Me.txtCauseCode.Name = "txtCauseCode"
        Me.txtCauseCode.Size = New System.Drawing.Size(828, 21)
        Me.txtCauseCode.TabIndex = 0
        '
        'txtCauseName
        '
        Me.txtCauseName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCauseName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCauseName.Location = New System.Drawing.Point(113, 28)
        Me.txtCauseName.Name = "txtCauseName"
        Me.txtCauseName.Size = New System.Drawing.Size(828, 21)
        Me.txtCauseName.TabIndex = 1
        '
        'labCauseName
        '
        Me.labCauseName.AutoSize = true
        Me.labCauseName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labCauseName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labCauseName.Location = New System.Drawing.Point(3, 25)
        Me.labCauseName.Name = "labCauseName"
        Me.labCauseName.Size = New System.Drawing.Size(104, 25)
        Me.labCauseName.TabIndex = 0
        Me.labCauseName.Text = "Tên nguyên nhân"
        Me.labCauseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grvCauseList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(333, 678)
        Me.Panel1.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(333, 33)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 678)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = false
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1277, 33)
        Me.Panel2.TabIndex = 6
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1216, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(61, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(31, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(29, 31)
        Me.btnVideo.TabIndex = 99
        Me.btnVideo.Tag = "CMMS!frmGiamsattinhtrang"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 31)
        Me.btnHelp.TabIndex = 98
        Me.btnHelp.Tag = "CMMS!frmGiamsattinhtrang"
        '
        'frmCauseRemedy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 741)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TableLayoutPanel6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmCauseRemedy"
        Me.Text = "Remedy of cause"
        Me.Panel4.ResumeLayout(false)
        CType(Me.grvCauseList,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel6.ResumeLayout(false)
        Me.TableLayoutPanel6.PerformLayout
        CType(Me.grvRemdyList,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grvCauseList As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labCauseName As System.Windows.Forms.Label
    Friend WithEvents labCauseCode As System.Windows.Forms.Label
    Friend WithEvents txtCauseName As System.Windows.Forms.TextBox
    Friend WithEvents txtCauseCode As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents labNote As System.Windows.Forms.Label
    Friend WithEvents grvRemdyList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
