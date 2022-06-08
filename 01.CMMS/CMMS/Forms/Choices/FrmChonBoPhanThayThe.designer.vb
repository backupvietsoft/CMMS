<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonBoPhanThayThe
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
        Me.LblTieude = New System.Windows.Forms.Label()
        Me.LblChonCV = New System.Windows.Forms.Label()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnThucHien = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CboMSMayThayThe = New Commons.UtcComboBox()
        Me.TVChonBoPhanMuonThay = New System.Windows.Forms.TreeView()
        Me.GrpChonBoPhanMuonThay = New System.Windows.Forms.GroupBox()
        Me.GrpChonBoPhanDeThay = New System.Windows.Forms.GroupBox()
        Me.TVChonBoPhanDeThay = New System.Windows.Forms.TreeView()
        Me.txtMSMayCanThay = New Commons.utcTextBox()
        Me.lblMSMayThayThe = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpChonBoPhanMuonThay.SuspendLayout()
        Me.GrpChonBoPhanDeThay.SuspendLayout()
        CType(Me.txtMSMayCanThay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTieude
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LblTieude, 4)
        Me.LblTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieude.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieude.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTieude.Location = New System.Drawing.Point(3, 0)
        Me.LblTieude.Name = "LblTieude"
        Me.LblTieude.Size = New System.Drawing.Size(784, 35)
        Me.LblTieude.TabIndex = 25
        Me.LblTieude.Text = "CHỌN BỘ PHẬN THAY THẾ "
        Me.LblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTieude.UseCompatibleTextRendering = True
        '
        'LblChonCV
        '
        Me.LblChonCV.AutoSize = True
        Me.LblChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChonCV.Location = New System.Drawing.Point(398, 35)
        Me.LblChonCV.Name = "LblChonCV"
        Me.LblChonCV.Size = New System.Drawing.Size(94, 28)
        Me.LblChonCV.TabIndex = 26
        Me.LblChonCV.Text = "Chọn máy "
        Me.LblChonCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(703, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 26)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThucHien.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThucHien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThucHien.Location = New System.Drawing.Point(615, 0)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(88, 26)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        Me.BtnThucHien.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'CboMSMayThayThe
        '
        Me.CboMSMayThayThe.AssemblyName = ""
        Me.CboMSMayThayThe.BackColor = System.Drawing.Color.White
        Me.CboMSMayThayThe.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.CboMSMayThayThe.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.CboMSMayThayThe.ClassName = ""
        Me.CboMSMayThayThe.Display = ""
        Me.CboMSMayThayThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboMSMayThayThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMSMayThayThe.ErrorProviderControl = Me.ErrorProvider
        Me.CboMSMayThayThe.FormattingEnabled = True
        Me.CboMSMayThayThe.IsAll = False
        Me.CboMSMayThayThe.isInputNull = False
        Me.CboMSMayThayThe.IsNew = False
        Me.CboMSMayThayThe.IsNull = True
        Me.CboMSMayThayThe.ItemAll = " < ALL > "
        Me.CboMSMayThayThe.ItemNew = "...New"
        Me.CboMSMayThayThe.Location = New System.Drawing.Point(498, 38)
        Me.CboMSMayThayThe.MethodName = ""
        Me.CboMSMayThayThe.Name = "CboMSMayThayThe"
        Me.CboMSMayThayThe.Param = ""
        Me.CboMSMayThayThe.Param2 = ""
        Me.CboMSMayThayThe.Size = New System.Drawing.Size(289, 21)
        Me.CboMSMayThayThe.StoreName = ""
        Me.CboMSMayThayThe.TabIndex = 0
        Me.CboMSMayThayThe.Table = Nothing
        Me.CboMSMayThayThe.TextReadonly = False
        Me.CboMSMayThayThe.Value = ""
        '
        'TVChonBoPhanMuonThay
        '
        Me.TVChonBoPhanMuonThay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVChonBoPhanMuonThay.Location = New System.Drawing.Point(3, 17)
        Me.TVChonBoPhanMuonThay.Name = "TVChonBoPhanMuonThay"
        Me.TVChonBoPhanMuonThay.Size = New System.Drawing.Size(383, 395)
        Me.TVChonBoPhanMuonThay.TabIndex = 88
        '
        'GrpChonBoPhanMuonThay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpChonBoPhanMuonThay, 2)
        Me.GrpChonBoPhanMuonThay.Controls.Add(Me.TVChonBoPhanMuonThay)
        Me.GrpChonBoPhanMuonThay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonBoPhanMuonThay.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonBoPhanMuonThay.Location = New System.Drawing.Point(3, 66)
        Me.GrpChonBoPhanMuonThay.Name = "GrpChonBoPhanMuonThay"
        Me.GrpChonBoPhanMuonThay.Size = New System.Drawing.Size(389, 415)
        Me.GrpChonBoPhanMuonThay.TabIndex = 89
        Me.GrpChonBoPhanMuonThay.TabStop = False
        Me.GrpChonBoPhanMuonThay.Text = "Chọn bộ phận muốn thay "
        '
        'GrpChonBoPhanDeThay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpChonBoPhanDeThay, 2)
        Me.GrpChonBoPhanDeThay.Controls.Add(Me.TVChonBoPhanDeThay)
        Me.GrpChonBoPhanDeThay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonBoPhanDeThay.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonBoPhanDeThay.Location = New System.Drawing.Point(398, 66)
        Me.GrpChonBoPhanDeThay.Name = "GrpChonBoPhanDeThay"
        Me.GrpChonBoPhanDeThay.Size = New System.Drawing.Size(389, 415)
        Me.GrpChonBoPhanDeThay.TabIndex = 90
        Me.GrpChonBoPhanDeThay.TabStop = False
        Me.GrpChonBoPhanDeThay.Text = "Chọn bộ phận để thay "
        '
        'TVChonBoPhanDeThay
        '
        Me.TVChonBoPhanDeThay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVChonBoPhanDeThay.Location = New System.Drawing.Point(3, 17)
        Me.TVChonBoPhanDeThay.Name = "TVChonBoPhanDeThay"
        Me.TVChonBoPhanDeThay.Size = New System.Drawing.Size(383, 395)
        Me.TVChonBoPhanDeThay.TabIndex = 89
        '
        'txtMSMayCanThay
        '
        Me.txtMSMayCanThay.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMSMayCanThay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMSMayCanThay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSMayCanThay.ErrorProviderControl = Nothing
        Me.txtMSMayCanThay.FieldName = ""
        Me.txtMSMayCanThay.IsNull = True
        Me.txtMSMayCanThay.Location = New System.Drawing.Point(103, 38)
        Me.txtMSMayCanThay.MaxLength = 0
        Me.txtMSMayCanThay.Multiline = False
        Me.txtMSMayCanThay.Name = "txtMSMayCanThay"
        Me.txtMSMayCanThay.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMSMayCanThay.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMSMayCanThay.Properties.Appearance.Options.UseBackColor = True
        Me.txtMSMayCanThay.Properties.ReadOnly = True
        Me.txtMSMayCanThay.ReadOnly = True
        Me.txtMSMayCanThay.Size = New System.Drawing.Size(289, 20)
        Me.txtMSMayCanThay.TabIndex = 91
        Me.txtMSMayCanThay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMSMayCanThay.TextTypeMode = Commons.TypeMode.None
        '
        'lblMSMayThayThe
        '
        Me.lblMSMayThayThe.AutoSize = True
        Me.lblMSMayThayThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSMayThayThe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSMayThayThe.Location = New System.Drawing.Point(3, 35)
        Me.lblMSMayThayThe.Name = "lblMSMayThayThe"
        Me.lblMSMayThayThe.Size = New System.Drawing.Size(94, 28)
        Me.lblMSMayThayThe.TabIndex = 92
        Me.lblMSMayThayThe.Text = "Máy cần thay "
        Me.lblMSMayThayThe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtMSMayCanThay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMSMayThayThe, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonCV, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblTieude, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CboMSMayThayThe, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpChonBoPhanMuonThay, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpChonBoPhanDeThay, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(790, 516)
        Me.TableLayoutPanel1.TabIndex = 93
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.BtnThucHien)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 487)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 26)
        Me.Panel1.TabIndex = 93
        '
        'FrmChonBoPhanThayThe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 516)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "FrmChonBoPhanThayThe"
        Me.Text = "Chọn bộ phận thay thế "
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpChonBoPhanMuonThay.ResumeLayout(False)
        Me.GrpChonBoPhanDeThay.ResumeLayout(False)
        CType(Me.txtMSMayCanThay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CboMSMayThayThe As Commons.UtcComboBox
    Friend WithEvents LblTieude As System.Windows.Forms.Label
    Friend WithEvents LblChonCV As System.Windows.Forms.Label
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThucHien As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpChonBoPhanDeThay As System.Windows.Forms.GroupBox
    Friend WithEvents GrpChonBoPhanMuonThay As System.Windows.Forms.GroupBox
    Friend WithEvents TVChonBoPhanMuonThay As System.Windows.Forms.TreeView
    Friend WithEvents TVChonBoPhanDeThay As System.Windows.Forms.TreeView
    Friend WithEvents lblMSMayThayThe As System.Windows.Forms.Label
    Friend WithEvents txtMSMayCanThay As Commons.utcTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
