<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonvattubaoduong
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
        Me.components = New System.ComponentModel.Container
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnThuchien = New System.Windows.Forms.Button
        Me.grdDanhsachvattu = New System.Windows.Forms.DataGridView
        Me.grpDanhsachvattu = New System.Windows.Forms.GroupBox
        Me.lblTieude = New System.Windows.Forms.Label
        Me.lblLoaiPT = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtMSPT = New System.Windows.Forms.TextBox
        Me.lblMSPT = New System.Windows.Forms.Label
        Me.cboLoaiPT = New Commons.UtcComboBox
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattu.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Black
        Me.BtnThoat.Location = New System.Drawing.Point(603, 431)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 12
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThuchien
        '
        Me.BtnThuchien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThuchien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThuchien.Location = New System.Drawing.Point(522, 431)
        Me.BtnThuchien.Name = "BtnThuchien"
        Me.BtnThuchien.Size = New System.Drawing.Size(81, 25)
        Me.BtnThuchien.TabIndex = 11
        Me.BtnThuchien.Text = "Thực hiện"
        Me.BtnThuchien.UseVisualStyleBackColor = True
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
        Me.grdDanhsachvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(680, 314)
        Me.grdDanhsachvattu.TabIndex = 0
        '
        'grpDanhsachvattu
        '
        Me.grpDanhsachvattu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDanhsachvattu.Controls.Add(Me.grdDanhsachvattu)
        Me.grpDanhsachvattu.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachvattu.Location = New System.Drawing.Point(3, 78)
        Me.grpDanhsachvattu.Name = "grpDanhsachvattu"
        Me.grpDanhsachvattu.Size = New System.Drawing.Size(686, 334)
        Me.grpDanhsachvattu.TabIndex = 10
        Me.grpDanhsachvattu.TabStop = False
        Me.grpDanhsachvattu.Text = "Danh sách vật tư"
        '
        'lblTieude
        '
        Me.lblTieude.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(2, 3)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(689, 39)
        Me.lblTieude.TabIndex = 9
        Me.lblTieude.Text = "CHỌN VẬT TƯ CHO CÔNG VIỆC BẢO DƯỠNG"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLoaiPT
        '
        Me.lblLoaiPT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLoaiPT.ForeColor = System.Drawing.Color.Black
        Me.lblLoaiPT.Location = New System.Drawing.Point(190, 54)
        Me.lblLoaiPT.Name = "lblLoaiPT"
        Me.lblLoaiPT.Size = New System.Drawing.Size(138, 18)
        Me.lblLoaiPT.TabIndex = 13
        Me.lblLoaiPT.Text = "Loại thiết bị"
        Me.lblLoaiPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtMSPT
        '
        Me.txtMSPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMSPT.Location = New System.Drawing.Point(119, 431)
        Me.txtMSPT.Name = "txtMSPT"
        Me.txtMSPT.Size = New System.Drawing.Size(171, 21)
        Me.txtMSPT.TabIndex = 15
        '
        'lblMSPT
        '
        Me.lblMSPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMSPT.ForeColor = System.Drawing.Color.Black
        Me.lblMSPT.Location = New System.Drawing.Point(0, 434)
        Me.lblMSPT.Name = "lblMSPT"
        Me.lblMSPT.Size = New System.Drawing.Size(113, 16)
        Me.lblMSPT.TabIndex = 13
        Me.lblMSPT.Text = "Nhập MS PT:"
        Me.lblMSPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLoaiPT
        '
        Me.cboLoaiPT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboLoaiPT.AssemblyName = ""
        Me.cboLoaiPT.BackColor = System.Drawing.SystemColors.Window
        Me.cboLoaiPT.ClassName = ""
        Me.cboLoaiPT.Display = ""
        Me.cboLoaiPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiPT.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiPT.FormattingEnabled = True
        Me.cboLoaiPT.IsAll = True
        Me.cboLoaiPT.IsNew = False
        Me.cboLoaiPT.ItemAll = " < ALL > "
        Me.cboLoaiPT.ItemNew = "...New"
        Me.cboLoaiPT.Location = New System.Drawing.Point(334, 51)
        Me.cboLoaiPT.MethodName = ""
        Me.cboLoaiPT.Name = "cboLoaiPT"
        Me.cboLoaiPT.Param = ""
        Me.cboLoaiPT.Size = New System.Drawing.Size(168, 21)
        Me.cboLoaiPT.StoreName = ""
        Me.cboLoaiPT.TabIndex = 14
        Me.cboLoaiPT.Table = Nothing
        Me.cboLoaiPT.TextReadonly = False
        Me.cboLoaiPT.Value = ""
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "MS_TO1"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "TEN_TO"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.HeaderText = "MS_TO"
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        '
        'frmChonvattubaoduong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 459)
        Me.Controls.Add(Me.txtMSPT)
        Me.Controls.Add(Me.cboLoaiPT)
        Me.Controls.Add(Me.lblMSPT)
        Me.Controls.Add(Me.lblLoaiPT)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnThuchien)
        Me.Controls.Add(Me.grpDanhsachvattu)
        Me.Controls.Add(Me.lblTieude)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonvattubaoduong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonvattubaoduong"
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattu.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThuchien As System.Windows.Forms.Button
    Friend WithEvents grdDanhsachvattu As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachvattu As System.Windows.Forms.GroupBox
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboLoaiPT As Commons.UtcComboBox
    Friend WithEvents lblLoaiPT As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMSPT As System.Windows.Forms.TextBox
    Friend WithEvents lblMSPT As System.Windows.Forms.Label
End Class
