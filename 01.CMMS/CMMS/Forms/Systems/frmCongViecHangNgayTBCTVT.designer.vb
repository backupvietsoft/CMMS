<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCongViecHangNgayTBCTVT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTieude = New System.Windows.Forms.Label
        Me.grpDanhsachTB = New System.Windows.Forms.GroupBox
        Me.grdDanhsachTB = New System.Windows.Forms.DataGridView
        Me.grpDanhsachvattu = New System.Windows.Forms.GroupBox
        Me.grdDanhsachvattu = New System.Windows.Forms.DataGridView
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnThuchien = New System.Windows.Forms.Button
        Me.grpDanhsachTB.SuspendLayout()
        CType(Me.grdDanhsachTB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattu.SuspendLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(3, 9)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(785, 32)
        Me.lblTieude.TabIndex = 0
        Me.lblTieude.Text = "PHÂN BỐ VẬT TƯ"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDanhsachTB
        '
        Me.grpDanhsachTB.Controls.Add(Me.grdDanhsachTB)
        Me.grpDanhsachTB.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachTB.Location = New System.Drawing.Point(3, 51)
        Me.grpDanhsachTB.Name = "grpDanhsachTB"
        Me.grpDanhsachTB.Size = New System.Drawing.Size(226, 439)
        Me.grpDanhsachTB.TabIndex = 1
        Me.grpDanhsachTB.TabStop = False
        Me.grpDanhsachTB.Text = "Danh sách thiết bị"
        '
        'grdDanhsachTB
        '
        Me.grdDanhsachTB.AllowUserToAddRows = False
        Me.grdDanhsachTB.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachTB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachTB.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachTB.Location = New System.Drawing.Point(5, 20)
        Me.grdDanhsachTB.Name = "grdDanhsachTB"
        Me.grdDanhsachTB.ReadOnly = True
        Me.grdDanhsachTB.RowHeadersWidth = 25
        Me.grdDanhsachTB.Size = New System.Drawing.Size(220, 413)
        Me.grdDanhsachTB.TabIndex = 0
        '
        'grpDanhsachvattu
        '
        Me.grpDanhsachvattu.Controls.Add(Me.grdDanhsachvattu)
        Me.grpDanhsachvattu.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachvattu.Location = New System.Drawing.Point(250, 58)
        Me.grpDanhsachvattu.Name = "grpDanhsachvattu"
        Me.grpDanhsachvattu.Size = New System.Drawing.Size(538, 432)
        Me.grpDanhsachvattu.TabIndex = 2
        Me.grpDanhsachvattu.TabStop = False
        Me.grpDanhsachvattu.Text = "Danh sách vật tư"
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
        Me.grdDanhsachvattu.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdDanhsachvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachvattu.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(4, 17)
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.RowHeadersWidth = 25
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(533, 409)
        Me.grdDanhsachvattu.TabIndex = 0
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Black
        Me.BtnThoat.Location = New System.Drawing.Point(705, 496)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 14
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThuchien
        '
        Me.BtnThuchien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThuchien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThuchien.Location = New System.Drawing.Point(624, 496)
        Me.BtnThuchien.Name = "BtnThuchien"
        Me.BtnThuchien.Size = New System.Drawing.Size(81, 25)
        Me.BtnThuchien.TabIndex = 13
        Me.BtnThuchien.Text = "Thực hiện"
        Me.BtnThuchien.UseVisualStyleBackColor = True
        '
        'frmCongViecHangNgayTBCTVT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnThuchien)
        Me.Controls.Add(Me.grpDanhsachvattu)
        Me.Controls.Add(Me.grpDanhsachTB)
        Me.Controls.Add(Me.lblTieude)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmCongViecHangNgayTBCTVT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCongViecHangNgayTBCTVT"
        Me.grpDanhsachTB.ResumeLayout(False)
        CType(Me.grdDanhsachTB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattu.ResumeLayout(False)
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachTB As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachTB As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachvattu As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachvattu As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThuchien As System.Windows.Forms.Button
End Class
