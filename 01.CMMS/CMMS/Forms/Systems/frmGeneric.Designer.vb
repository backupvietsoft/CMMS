<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneric
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
        Me.lblServerName = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblDatabaseName = New System.Windows.Forms.Label
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.cmdGeneric = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtNamespace = New System.Windows.Forms.TextBox
        Me.lblNamespace = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblServerName.Location = New System.Drawing.Point(29, 19)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(69, 13)
        Me.lblServerName.TabIndex = 0
        Me.lblServerName.Text = "Server Name"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblUsername.Location = New System.Drawing.Point(29, 48)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPassword.Location = New System.Drawing.Point(29, 82)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.AutoSize = True
        Me.lblDatabaseName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblDatabaseName.Location = New System.Drawing.Point(29, 111)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(83, 13)
        Me.lblDatabaseName.TabIndex = 3
        Me.lblDatabaseName.Text = "Database Name"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(132, 12)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(206, 21)
        Me.txtServerName.TabIndex = 4
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(132, 45)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(206, 21)
        Me.txtUsername.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(132, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(206, 21)
        Me.txtPassword.TabIndex = 6
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(132, 106)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(206, 21)
        Me.txtDatabaseName.TabIndex = 7
        '
        'cmdConnect
        '
        Me.cmdConnect.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdConnect.Location = New System.Drawing.Point(73, 172)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(75, 23)
        Me.cmdConnect.TabIndex = 8
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cmdGeneric
        '
        Me.cmdGeneric.Enabled = False
        Me.cmdGeneric.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdGeneric.Location = New System.Drawing.Point(154, 172)
        Me.cmdGeneric.Name = "cmdGeneric"
        Me.cmdGeneric.Size = New System.Drawing.Size(75, 23)
        Me.cmdGeneric.TabIndex = 9
        Me.cmdGeneric.Text = "Generic"
        Me.cmdGeneric.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.Location = New System.Drawing.Point(235, 172)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtNamespace
        '
        Me.txtNamespace.Location = New System.Drawing.Point(132, 137)
        Me.txtNamespace.Name = "txtNamespace"
        Me.txtNamespace.ReadOnly = True
        Me.txtNamespace.Size = New System.Drawing.Size(206, 21)
        Me.txtNamespace.TabIndex = 12
        '
        'lblNamespace
        '
        Me.lblNamespace.AutoSize = True
        Me.lblNamespace.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblNamespace.Location = New System.Drawing.Point(29, 142)
        Me.lblNamespace.Name = "lblNamespace"
        Me.lblNamespace.Size = New System.Drawing.Size(62, 13)
        Me.lblNamespace.TabIndex = 11
        Me.lblNamespace.Text = "Namespace"
        '
        'frmGeneric
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 214)
        Me.Controls.Add(Me.txtNamespace)
        Me.Controls.Add(Me.lblNamespace)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdGeneric)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.txtDatabaseName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.lblDatabaseName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblServerName)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmGeneric"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generic"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cmdGeneric As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtNamespace As System.Windows.Forms.TextBox
    Friend WithEvents lblNamespace As System.Windows.Forms.Label

End Class
