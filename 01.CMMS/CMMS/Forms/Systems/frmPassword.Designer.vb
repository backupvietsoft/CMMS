<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPassword
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
        Me.labUserName = New System.Windows.Forms.Label()
        Me.labPassword = New System.Windows.Forms.Label()
        Me.labNewPassword = New System.Windows.Forms.Label()
        Me.labConfirmPass = New System.Windows.Forms.Label()
        Me.BtnChange = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tlMain = New System.Windows.Forms.TableLayoutPanel()
        Me.txtUsername = New Commons.utcTextBox()
        Me.txtPassOld = New Commons.utcTextBox()
        Me.txtPassNew = New Commons.utcTextBox()
        Me.txtComfirmPass = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlMain.SuspendLayout()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComfirmPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labUserName
        '
        Me.labUserName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labUserName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labUserName.Location = New System.Drawing.Point(3, 0)
        Me.labUserName.Name = "labUserName"
        Me.labUserName.Size = New System.Drawing.Size(132, 28)
        Me.labUserName.TabIndex = 1
        Me.labUserName.Text = "Username"
        Me.labUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.labUserName.UseCompatibleTextRendering = True
        '
        'labPassword
        '
        Me.labPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labPassword.Location = New System.Drawing.Point(3, 28)
        Me.labPassword.Name = "labPassword"
        Me.labPassword.Size = New System.Drawing.Size(132, 28)
        Me.labPassword.TabIndex = 2
        Me.labPassword.Text = "Old Pword"
        Me.labPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.labPassword.UseCompatibleTextRendering = True
        '
        'labNewPassword
        '
        Me.labNewPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNewPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNewPassword.Location = New System.Drawing.Point(3, 56)
        Me.labNewPassword.Name = "labNewPassword"
        Me.labNewPassword.Size = New System.Drawing.Size(132, 28)
        Me.labNewPassword.TabIndex = 3
        Me.labNewPassword.Text = "New Pword"
        Me.labNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.labNewPassword.UseCompatibleTextRendering = True
        '
        'labConfirmPass
        '
        Me.labConfirmPass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labConfirmPass.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labConfirmPass.Location = New System.Drawing.Point(3, 84)
        Me.labConfirmPass.Name = "labConfirmPass"
        Me.labConfirmPass.Size = New System.Drawing.Size(132, 29)
        Me.labConfirmPass.TabIndex = 4
        Me.labConfirmPass.Text = "Confirm Pwd "
        Me.labConfirmPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.labConfirmPass.UseCompatibleTextRendering = True
        '
        'BtnChange
        '
        Me.BtnChange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnChange.Location = New System.Drawing.Point(125, 3)
        Me.BtnChange.LookAndFeel.SkinName = "Blue"
        Me.BtnChange.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnChange.Name = "BtnChange"
        Me.BtnChange.Size = New System.Drawing.Size(79, 24)
        Me.BtnChange.TabIndex = 0
        Me.BtnChange.Text = "&Change"
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.Location = New System.Drawing.Point(210, 3)
        Me.btnExit.LookAndFeel.SkinName = "Blue"
        Me.btnExit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(79, 24)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "&Exit"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tlMain
        '
        Me.tlMain.ColumnCount = 2
        Me.tlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.tlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlMain.Controls.Add(Me.labUserName, 0, 0)
        Me.tlMain.Controls.Add(Me.labPassword, 0, 1)
        Me.tlMain.Controls.Add(Me.labNewPassword, 0, 2)
        Me.tlMain.Controls.Add(Me.labConfirmPass, 0, 3)
        Me.tlMain.Controls.Add(Me.txtUsername, 1, 0)
        Me.tlMain.Controls.Add(Me.txtPassOld, 1, 1)
        Me.tlMain.Controls.Add(Me.txtPassNew, 1, 2)
        Me.tlMain.Controls.Add(Me.txtComfirmPass, 1, 3)
        Me.tlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlMain.Location = New System.Drawing.Point(0, 5)
        Me.tlMain.Name = "tlMain"
        Me.tlMain.RowCount = 4
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlMain.Size = New System.Drawing.Size(414, 113)
        Me.tlMain.TabIndex = 76
        '
        'txtUsername
        '
        Me.txtUsername.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtUsername.ErrorProviderControl = Me.ErrorProvider1
        Me.txtUsername.FieldName = ""
        Me.txtUsername.IsNull = False
        Me.txtUsername.Location = New System.Drawing.Point(141, 4)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.txtUsername.MaxLength = 0
        Me.txtUsername.Multiline = False
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsername.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtUsername.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Properties.Appearance.Options.UseBackColor = True
        Me.txtUsername.Properties.Appearance.Options.UseFont = True
        Me.txtUsername.Properties.Appearance.Options.UseTextOptions = True
        Me.txtUsername.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtUsername.Properties.ReadOnly = True
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(258, 21)
        Me.txtUsername.TabIndex = 5
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUsername.TextTypeMode = Commons.TypeMode.None
        '
        'txtPassOld
        '
        Me.txtPassOld.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtPassOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtPassOld.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtPassOld.ErrorProviderControl = Me.ErrorProvider1
        Me.txtPassOld.FieldName = ""
        Me.txtPassOld.IsNull = False
        Me.txtPassOld.Location = New System.Drawing.Point(141, 32)
        Me.txtPassOld.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.txtPassOld.MaxLength = 0
        Me.txtPassOld.Multiline = False
        Me.txtPassOld.Name = "txtPassOld"
        Me.txtPassOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassOld.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtPassOld.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassOld.Properties.Appearance.Options.UseBackColor = True
        Me.txtPassOld.Properties.Appearance.Options.UseFont = True
        Me.txtPassOld.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPassOld.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtPassOld.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassOld.Properties.ReadOnly = True
        Me.txtPassOld.ReadOnly = True
        Me.txtPassOld.Size = New System.Drawing.Size(258, 21)
        Me.txtPassOld.TabIndex = 6
        Me.txtPassOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassOld.TextTypeMode = Commons.TypeMode.None
        '
        'txtPassNew
        '
        Me.txtPassNew.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtPassNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtPassNew.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtPassNew.ErrorProviderControl = Me.ErrorProvider1
        Me.txtPassNew.FieldName = ""
        Me.txtPassNew.IsNull = False
        Me.txtPassNew.Location = New System.Drawing.Point(141, 60)
        Me.txtPassNew.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.txtPassNew.MaxLength = 0
        Me.txtPassNew.Multiline = False
        Me.txtPassNew.Name = "txtPassNew"
        Me.txtPassNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassNew.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtPassNew.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassNew.Properties.Appearance.Options.UseBackColor = True
        Me.txtPassNew.Properties.Appearance.Options.UseFont = True
        Me.txtPassNew.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPassNew.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtPassNew.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassNew.ReadOnly = False
        Me.txtPassNew.Size = New System.Drawing.Size(258, 21)
        Me.txtPassNew.TabIndex = 7
        Me.txtPassNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassNew.TextTypeMode = Commons.TypeMode.None
        '
        'txtComfirmPass
        '
        Me.txtComfirmPass.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtComfirmPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtComfirmPass.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtComfirmPass.ErrorProviderControl = Me.ErrorProvider1
        Me.txtComfirmPass.FieldName = ""
        Me.txtComfirmPass.IsNull = False
        Me.txtComfirmPass.Location = New System.Drawing.Point(141, 89)
        Me.txtComfirmPass.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.txtComfirmPass.MaxLength = 0
        Me.txtComfirmPass.Multiline = False
        Me.txtComfirmPass.Name = "txtComfirmPass"
        Me.txtComfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtComfirmPass.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtComfirmPass.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComfirmPass.Properties.Appearance.Options.UseBackColor = True
        Me.txtComfirmPass.Properties.Appearance.Options.UseFont = True
        Me.txtComfirmPass.Properties.Appearance.Options.UseTextOptions = True
        Me.txtComfirmPass.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtComfirmPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtComfirmPass.ReadOnly = False
        Me.txtComfirmPass.Size = New System.Drawing.Size(258, 21)
        Me.txtComfirmPass.TabIndex = 8
        Me.txtComfirmPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtComfirmPass.TextTypeMode = Commons.TypeMode.None
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnExit, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnChange, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 121)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(414, 30)
        Me.TableLayoutPanel1.TabIndex = 77
        '
        'frmPassword
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(430, 190)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 185)
        Me.Name = "frmPassword"
        Me.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlMain.ResumeLayout(False)
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComfirmPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labUserName As System.Windows.Forms.Label
    Friend WithEvents labPassword As System.Windows.Forms.Label
    Friend WithEvents labNewPassword As System.Windows.Forms.Label
    Friend WithEvents labConfirmPass As System.Windows.Forms.Label
    Friend WithEvents txtUsername As Commons.utcTextBox
    Friend WithEvents txtPassOld As Commons.utcTextBox
    Friend WithEvents txtPassNew As Commons.utcTextBox
    Friend WithEvents txtComfirmPass As Commons.utcTextBox
    Friend WithEvents BtnChange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tlMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
