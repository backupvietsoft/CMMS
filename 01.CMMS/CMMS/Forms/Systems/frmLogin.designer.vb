<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.labUserName = New DevExpress.XtraEditors.LabelControl()
        Me.labPassword = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.labDbName = New DevExpress.XtraEditors.LabelControl()
        Me.chkRememberUser = New DevExpress.XtraEditors.CheckEdit()
        Me.tlMain = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.chkRememberpass = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDatabase = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblUser = New DevExpress.XtraEditors.LabelControl()
        Me.cboLic = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.errProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkRememberUser.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tlMain.SuspendLayout
        CType(Me.txtPassword.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtUserName.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkRememberpass.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboDatabase.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboLic.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'labUserName
        '
        Me.labUserName.Appearance.ForeColor = System.Drawing.Color.Black
        Me.labUserName.Appearance.Options.UseForeColor = true
        Me.labUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labUserName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labUserName.Location = New System.Drawing.Point(3, 37)
        Me.labUserName.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.labUserName.Name = "labUserName"
        Me.labUserName.Size = New System.Drawing.Size(89, 20)
        Me.labUserName.TabIndex = 6
        Me.labUserName.Text = "User name"
        '
        'labPassword
        '
        Me.labPassword.Appearance.ForeColor = System.Drawing.Color.Black
        Me.labPassword.Appearance.Options.UseForeColor = True
        Me.labPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labPassword.Location = New System.Drawing.Point(3, 67)
        Me.labPassword.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.labPassword.Name = "labPassword"
        Me.labPassword.Size = New System.Drawing.Size(89, 17)
        Me.labPassword.TabIndex = 8
        Me.labPassword.Text = "Password"
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.Image = Global.My.Resources.Resources.btnthoat
        Me.btnCancel.Location = New System.Drawing.Point(245, 124)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Appearance.Options.UseForeColor = True
        Me.btnLogin.Image = Global.My.Resources.Resources.login_icon_3037_16x16
        Me.btnLogin.Location = New System.Drawing.Point(140, 124)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(99, 30)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "&Login"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'labDbName
        '
        Me.labDbName.Appearance.Options.UseTextOptions = True
        Me.labDbName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labDbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labDbName.Location = New System.Drawing.Point(3, 7)
        Me.labDbName.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.labDbName.Name = "labDbName"
        Me.labDbName.Size = New System.Drawing.Size(89, 20)
        Me.labDbName.TabIndex = 12
        Me.labDbName.Text = "Database "
        '
        'chkRememberUser
        '
        Me.chkRememberUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkRememberUser.Location = New System.Drawing.Point(98, 94)
        Me.chkRememberUser.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.chkRememberUser.Name = "chkRememberUser"
        Me.chkRememberUser.Properties.Caption = "Remember user"
        Me.chkRememberUser.Properties.LookAndFeel.SkinName = "Blue"
        Me.chkRememberUser.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.chkRememberUser.Size = New System.Drawing.Size(141, 18)
        Me.chkRememberUser.TabIndex = 4
        '
        'tlMain
        '
        Me.tlMain.BackColor = System.Drawing.Color.Transparent
        Me.tlMain.ColumnCount = 3
        Me.tlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.tlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.tlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546!))
        Me.tlMain.Controls.Add(Me.btnLogin, 1, 4)
        Me.tlMain.Controls.Add(Me.labUserName, 0, 1)
        Me.tlMain.Controls.Add(Me.labPassword, 0, 2)
        Me.tlMain.Controls.Add(Me.btnCancel, 2, 4)
        Me.tlMain.Controls.Add(Me.txtPassword, 1, 2)
        Me.tlMain.Controls.Add(Me.txtUserName, 1, 1)
        Me.tlMain.Controls.Add(Me.labDbName, 0, 0)
        Me.tlMain.Controls.Add(Me.chkRememberUser, 1, 3)
        Me.tlMain.Controls.Add(Me.chkRememberpass, 2, 3)
        Me.tlMain.Controls.Add(Me.cboDatabase, 1, 0)
        Me.tlMain.Controls.Add(Me.lblUser, 0, 5)
        Me.tlMain.Controls.Add(Me.cboLic, 0, 3)
        Me.tlMain.Location = New System.Drawing.Point(130, 118)
        Me.tlMain.Name = "tlMain"
        Me.tlMain.RowCount = 6
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.95609!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75644!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.51678!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77069!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlMain.Size = New System.Drawing.Size(420, 185)
        Me.tlMain.TabIndex = 15
        '
        'txtPassword
        '
        Me.tlMain.SetColumnSpan(Me.txtPassword, 2)
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.Location = New System.Drawing.Point(98, 67)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPassword.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Properties.Appearance.Options.UseBackColor = True
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(319, 21)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.tlMain.SetColumnSpan(Me.txtUserName, 2)
        Me.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUserName.Location = New System.Drawing.Point(98, 37)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtUserName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserName.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Properties.Appearance.Options.UseBackColor = True
        Me.txtUserName.Properties.Appearance.Options.UseFont = True
        Me.txtUserName.Size = New System.Drawing.Size(319, 21)
        Me.txtUserName.TabIndex = 2
        '
        'chkRememberpass
        '
        Me.chkRememberpass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkRememberpass.Location = New System.Drawing.Point(245, 94)
        Me.chkRememberpass.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.chkRememberpass.Name = "chkRememberpass"
        Me.chkRememberpass.Properties.Caption = "Remember password"
        Me.chkRememberpass.Properties.LookAndFeel.SkinName = "Blue"
        Me.chkRememberpass.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.chkRememberpass.Size = New System.Drawing.Size(172, 18)
        Me.chkRememberpass.TabIndex = 5
        '
        'cboDatabase
        '
        Me.tlMain.SetColumnSpan(Me.cboDatabase, 2)
        Me.cboDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDatabase.Location = New System.Drawing.Point(98, 7)
        Me.cboDatabase.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabase.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboDatabase.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboDatabase.Properties.NullText = ""
        Me.cboDatabase.Size = New System.Drawing.Size(319, 20)
        Me.cboDatabase.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.Appearance.Options.UseTextOptions = True
        Me.lblUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblUser.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.lblUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.tlMain.SetColumnSpan(Me.lblUser, 3)
        Me.lblUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUser.Location = New System.Drawing.Point(3, 164)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(414, 18)
        Me.lblUser.TabIndex = 6
        Me.lblUser.Text = "User name"
        '
        'cboLic
        '
        Me.cboLic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLic.Location = New System.Drawing.Point(3, 94)
        Me.cboLic.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.cboLic.Name = "cboLic"
        Me.cboLic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLic.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLic.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLic.Properties.NullText = ""
        Me.cboLic.Size = New System.Drawing.Size(89, 20)
        Me.cboLic.TabIndex = 1
        Me.cboLic.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(89, 296)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 21)
        Me.LabelControl1.TabIndex = 16
        '
        'LabelControl2
        '
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(96, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 21)
        Me.LabelControl2.TabIndex = 16
        '
        'LabelControl3
        '
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.Location = New System.Drawing.Point(171, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(22, 21)
        Me.LabelControl3.TabIndex = 16
        '
        'LabelControl4
        '
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.Location = New System.Drawing.Point(44, 171)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 21)
        Me.LabelControl4.TabIndex = 16
        '
        'frmLogin
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch
        Me.BackgroundImageStore = Global.My.Resources.Resources.login
        Me.ClientSize = New System.Drawing.Size(584, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.tlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.MaximizeBox = false
        Me.MaximumSize = New System.Drawing.Size(606, 427)
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(600, 405)
        Me.Name = "frmLogin"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login "
        CType(Me.errProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkRememberUser.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.tlMain.ResumeLayout(false)
        CType(Me.txtPassword.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtUserName.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkRememberpass.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboDatabase.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboLic.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents labUserName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents labPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents labDbName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkRememberUser As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tlMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkRememberpass As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Private WithEvents cboDatabase As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblUser As DevExpress.XtraEditors.LabelControl
    Private WithEvents cboLic As DevExpress.XtraEditors.LookUpEdit
End Class
