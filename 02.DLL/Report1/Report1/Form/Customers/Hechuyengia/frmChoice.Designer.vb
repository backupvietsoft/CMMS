<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChoice
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.labTitle = New System.Windows.Forms.Label()
        Me.grvSource = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4.SuspendLayout()
        CType(Me.grvSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnOk)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 504)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 0, 65, 0)
        Me.Panel4.Size = New System.Drawing.Size(1037, 26)
        Me.Panel4.TabIndex = 3
        '
        'btnOk
        '
        Me.btnOk.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.btnOk.Appearance.Options.UseFont = True
        Me.btnOk.Appearance.Options.UseForeColor = True
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(812, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 26)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&Thực hiện"
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(892, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Hủy"
        '
        'labTitle
        '
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.labTitle.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.labTitle.Location = New System.Drawing.Point(0, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(1037, 35)
        Me.labTitle.TabIndex = 4
        Me.labTitle.Text = "CHOICE DATA"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grvSource
        '
        Me.grvSource.AllowUserToAddRows = False
        Me.grvSource.AllowUserToDeleteRows = False
        Me.grvSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grvSource.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvSource.DefaultCellStyle = DataGridViewCellStyle2
        Me.grvSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvSource.Location = New System.Drawing.Point(0, 0)
        Me.grvSource.MultiSelect = False
        Me.grvSource.Name = "grvSource"
        Me.grvSource.RowHeadersWidth = 35
        Me.grvSource.Size = New System.Drawing.Size(1037, 469)
        Me.grvSource.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grvSource)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1037, 469)
        Me.Panel1.TabIndex = 18
        '
        'frmChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 530)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.labTitle)
        Me.Controls.Add(Me.Panel4)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChoice"
        Me.Text = "Choice Data"
        Me.Panel4.ResumeLayout(False)
        CType(Me.grvSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Public WithEvents grvSource As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
