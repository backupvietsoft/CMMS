<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonThietBiBaoDuong
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
        Me.BtnThuchien = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.grdDanhsacthietbi = New System.Windows.Forms.DataGridView
        Me.grpDanhsachthietbi = New System.Windows.Forms.GroupBox
        Me.lblTieude = New System.Windows.Forms.Label
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.cboLoaiTB = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.grdDanhsacthietbi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachthietbi.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThuchien
        '
        Me.BtnThuchien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThuchien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThuchien.Location = New System.Drawing.Point(419, 358)
        Me.BtnThuchien.Name = "BtnThuchien"
        Me.BtnThuchien.Size = New System.Drawing.Size(81, 25)
        Me.BtnThuchien.TabIndex = 15
        Me.BtnThuchien.Text = "Thực hiện"
        Me.BtnThuchien.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Black
        Me.BtnThoat.Location = New System.Drawing.Point(500, 358)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 16
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'grdDanhsacthietbi
        '
        Me.grdDanhsacthietbi.AllowUserToAddRows = False
        Me.grdDanhsacthietbi.AllowUserToDeleteRows = False
        Me.grdDanhsacthietbi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsacthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsacthietbi.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsacthietbi.Name = "grdDanhsacthietbi"
        Me.grdDanhsacthietbi.Size = New System.Drawing.Size(576, 242)
        Me.grdDanhsacthietbi.TabIndex = 0
        '
        'grpDanhsachthietbi
        '
        Me.grpDanhsachthietbi.Controls.Add(Me.grdDanhsacthietbi)
        Me.grpDanhsachthietbi.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachthietbi.Location = New System.Drawing.Point(5, 81)
        Me.grpDanhsachthietbi.Name = "grpDanhsachthietbi"
        Me.grpDanhsachthietbi.Size = New System.Drawing.Size(582, 262)
        Me.grpDanhsachthietbi.TabIndex = 14
        Me.grpDanhsachthietbi.TabStop = False
        Me.grpDanhsachthietbi.Text = "Danh sách thiết bị"
        '
        'lblTieude
        '
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(2, 3)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(586, 39)
        Me.lblTieude.TabIndex = 13
        Me.lblTieude.Text = "CHỌN THIẾT BỊ CHO CÔNG VIỆC BẢO DƯỠNG"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.Location = New System.Drawing.Point(68, 54)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(187, 18)
        Me.lblLoaiTB.TabIndex = 18
        Me.lblLoaiTB.Text = "Loại thiết bị"
        Me.lblLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.AssemblyName = ""
        Me.cboLoaiTB.BackColor = System.Drawing.Color.White
        Me.cboLoaiTB.ClassName = ""
        Me.cboLoaiTB.Display = ""
        Me.cboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.IsAll = False
        Me.cboLoaiTB.IsNew = False
        Me.cboLoaiTB.ItemAll = " < ALL > "
        Me.cboLoaiTB.ItemNew = "...New"
        Me.cboLoaiTB.Location = New System.Drawing.Point(261, 54)
        Me.cboLoaiTB.MethodName = ""
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Param = ""
        Me.cboLoaiTB.Size = New System.Drawing.Size(159, 21)
        Me.cboLoaiTB.StoreName = ""
        Me.cboLoaiTB.TabIndex = 17
        Me.cboLoaiTB.Table = Nothing
        Me.cboLoaiTB.TextReadonly = False
        Me.cboLoaiTB.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmChonThietBiBaoDuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 386)
        Me.Controls.Add(Me.lblLoaiTB)
        Me.Controls.Add(Me.cboLoaiTB)
        Me.Controls.Add(Me.BtnThuchien)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.grpDanhsachthietbi)
        Me.Controls.Add(Me.lblTieude)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonThietBiBaoDuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonThietBiBaoDuong"
        CType(Me.grdDanhsacthietbi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachthietbi.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnThuchien As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents grdDanhsacthietbi As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachthietbi As System.Windows.Forms.GroupBox
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
