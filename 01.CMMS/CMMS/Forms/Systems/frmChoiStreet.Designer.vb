<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChoiStreet
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnChoice = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.labHeader = New System.Windows.Forms.Label
        Me.grvList = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.grvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnChoice)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 330)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 2, 65, 2)
        Me.Panel1.Size = New System.Drawing.Size(526, 30)
        Me.Panel1.TabIndex = 0
        '
        'btnChoice
        '
        Me.btnChoice.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnChoice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChoice.Location = New System.Drawing.Point(311, 2)
        Me.btnChoice.Name = "btnChoice"
        Me.btnChoice.Size = New System.Drawing.Size(75, 26)
        Me.btnChoice.TabIndex = 8
        Me.btnChoice.Text = "&Chọn"
        Me.btnChoice.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(386, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 26)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Th&oát"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'labHeader
        '
        Me.labHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.labHeader.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.labHeader.Location = New System.Drawing.Point(0, 0)
        Me.labHeader.Name = "labHeader"
        Me.labHeader.Size = New System.Drawing.Size(526, 35)
        Me.labHeader.TabIndex = 1
        Me.labHeader.Text = "CHỌN ĐƯỜNG"
        Me.labHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grvList
        '
        Me.grvList.AllowUserToAddRows = False
        Me.grvList.AllowUserToDeleteRows = False
        Me.grvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvList.Location = New System.Drawing.Point(0, 35)
        Me.grvList.Name = "grvList"
        Me.grvList.Size = New System.Drawing.Size(526, 295)
        Me.grvList.TabIndex = 2
        '
        'frmChoiStreet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 360)
        Me.Controls.Add(Me.grvList)
        Me.Controls.Add(Me.labHeader)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChoiStreet"
        Me.Text = "Chọn Đường"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnChoice As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents labHeader As System.Windows.Forms.Label
    Public WithEvents grvList As System.Windows.Forms.DataGridView
End Class
