<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKiemSoatDiChuyenBoPhan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnThoat = New System.Windows.Forms.Button
        Me.grpDanhsach = New System.Windows.Forms.GroupBox
        Me.grdDanhsach = New System.Windows.Forms.DataGridView
        Me.btnIn = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPhieuBaoTri = New System.Windows.Forms.Label
        Me.btnSua = New System.Windows.Forms.Button
        Me.lblTieude = New System.Windows.Forms.Label
        Me.lblMS_ThietBi = New System.Windows.Forms.Label
        Me.btnKhongghi = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboMS_ThietBi = New Commons.UtcComboBox
        Me.UtcComboBox1 = New Commons.UtcComboBox
        Me.radChuatra = New System.Windows.Forms.RadioButton
        Me.radDatra = New System.Windows.Forms.RadioButton
        Me.grpXemtheo = New System.Windows.Forms.GroupBox
        Me.btnGhi = New System.Windows.Forms.Button
        Me.grpDanhsach.SuspendLayout()
        CType(Me.grdDanhsach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpXemtheo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(680, 521)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(69, 27)
        Me.btnThoat.TabIndex = 50
        Me.btnThoat.Text = "T&hoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'grpDanhsach
        '
        Me.grpDanhsach.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpDanhsach.Controls.Add(Me.grdDanhsach)
        Me.grpDanhsach.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsach.Location = New System.Drawing.Point(3, 116)
        Me.grpDanhsach.Name = "grpDanhsach"
        Me.grpDanhsach.Size = New System.Drawing.Size(745, 399)
        Me.grpDanhsach.TabIndex = 33
        Me.grpDanhsach.TabStop = False
        Me.grpDanhsach.Text = "Danh sách các thiết bị có bộ phận di chuyển "
        '
        'grdDanhsach
        '
        Me.grdDanhsach.AllowUserToAddRows = False
        Me.grdDanhsach.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDanhsach.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsach.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsach.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsach.Name = "grdDanhsach"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.Format = "N2"
        Me.grdDanhsach.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdDanhsach.RowHeadersWidth = 25
        Me.grdDanhsach.Size = New System.Drawing.Size(739, 378)
        Me.grdDanhsach.TabIndex = 0
        '
        'btnIn
        '
        Me.btnIn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn.ForeColor = System.Drawing.Color.Teal
        Me.btnIn.Location = New System.Drawing.Point(3, 521)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(69, 27)
        Me.btnIn.TabIndex = 49
        Me.btnIn.Text = "&In"
        Me.btnIn.UseVisualStyleBackColor = True
        Me.btnIn.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(-49, -26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Loại thiết bị "
        '
        'lblPhieuBaoTri
        '
        Me.lblPhieuBaoTri.AutoSize = True
        Me.lblPhieuBaoTri.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhieuBaoTri.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPhieuBaoTri.Location = New System.Drawing.Point(643, -44)
        Me.lblPhieuBaoTri.Name = "lblPhieuBaoTri"
        Me.lblPhieuBaoTri.Size = New System.Drawing.Size(133, 29)
        Me.lblPhieuBaoTri.TabIndex = 32
        Me.lblPhieuBaoTri.Text = "JOB CARD"
        '
        'btnSua
        '
        Me.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.Color.Blue
        Me.btnSua.Location = New System.Drawing.Point(610, 521)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(69, 27)
        Me.btnSua.TabIndex = 43
        Me.btnSua.Text = "&Sửa "
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'lblTieude
        '
        Me.lblTieude.AutoSize = True
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieude.Location = New System.Drawing.Point(253, 19)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(419, 29)
        Me.lblTieude.TabIndex = 51
        Me.lblTieude.Text = "KIỂM SOÁT DI CHUYỂN BỘ PHẬN "
        '
        'lblMS_ThietBi
        '
        Me.lblMS_ThietBi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMS_ThietBi.AutoSize = True
        Me.lblMS_ThietBi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMS_ThietBi.ForeColor = System.Drawing.Color.Black
        Me.lblMS_ThietBi.Location = New System.Drawing.Point(253, 76)
        Me.lblMS_ThietBi.Name = "lblMS_ThietBi"
        Me.lblMS_ThietBi.Size = New System.Drawing.Size(64, 13)
        Me.lblMS_ThietBi.TabIndex = 52
        Me.lblMS_ThietBi.Text = "Loại thiết bị "
        '
        'btnKhongghi
        '
        Me.btnKhongghi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.btnKhongghi.Location = New System.Drawing.Point(680, 521)
        Me.btnKhongghi.Name = "btnKhongghi"
        Me.btnKhongghi.Size = New System.Drawing.Size(69, 27)
        Me.btnKhongghi.TabIndex = 57
        Me.btnKhongghi.Text = "Không ghi"
        Me.btnKhongghi.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS thiết bị"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Bộ phận "
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Từ máy "
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Bộ phận thay "
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Người cho phép "
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Ngày thay"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Đến ngày "
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Ngày trả"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "MS Phiếu bảo trì "
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 110
        '
        'cboMS_ThietBi
        '
        Me.cboMS_ThietBi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboMS_ThietBi.AssemblyName = ""
        Me.cboMS_ThietBi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMS_ThietBi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMS_ThietBi.BackColor = System.Drawing.Color.White
        Me.cboMS_ThietBi.ClassName = ""
        Me.cboMS_ThietBi.Display = ""
        Me.cboMS_ThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMS_ThietBi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboMS_ThietBi.FormattingEnabled = True
        Me.cboMS_ThietBi.IsAll = False
        Me.cboMS_ThietBi.IsNew = False
        Me.cboMS_ThietBi.ItemAll = " < ALL > "
        Me.cboMS_ThietBi.ItemNew = "...New"
        Me.cboMS_ThietBi.Location = New System.Drawing.Point(326, 72)
        Me.cboMS_ThietBi.MethodName = ""
        Me.cboMS_ThietBi.Name = "cboMS_ThietBi"
        Me.cboMS_ThietBi.Param = ""
        Me.cboMS_ThietBi.Size = New System.Drawing.Size(189, 21)
        Me.cboMS_ThietBi.StoreName = ""
        Me.cboMS_ThietBi.TabIndex = 53
        Me.cboMS_ThietBi.Table = Nothing
        Me.cboMS_ThietBi.TextReadonly = False
        Me.cboMS_ThietBi.Value = ""
        '
        'UtcComboBox1
        '
        Me.UtcComboBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UtcComboBox1.AssemblyName = ""
        Me.UtcComboBox1.BackColor = System.Drawing.Color.White
        Me.UtcComboBox1.ClassName = ""
        Me.UtcComboBox1.Display = ""
        Me.UtcComboBox1.ErrorProviderControl = Nothing
        Me.UtcComboBox1.FormattingEnabled = True
        Me.UtcComboBox1.IsAll = False
        Me.UtcComboBox1.IsNew = False
        Me.UtcComboBox1.ItemAll = " < ALL > "
        Me.UtcComboBox1.ItemNew = "...New"
        Me.UtcComboBox1.Location = New System.Drawing.Point(59, -29)
        Me.UtcComboBox1.MethodName = ""
        Me.UtcComboBox1.Name = "UtcComboBox1"
        Me.UtcComboBox1.Param = ""
        Me.UtcComboBox1.Size = New System.Drawing.Size(197, 21)
        Me.UtcComboBox1.StoreName = ""
        Me.UtcComboBox1.TabIndex = 41
        Me.UtcComboBox1.Table = Nothing
        Me.UtcComboBox1.TextReadonly = False
        Me.UtcComboBox1.Value = ""
        '
        'radChuatra
        '
        Me.radChuatra.AutoSize = True
        Me.radChuatra.Checked = True
        Me.radChuatra.Location = New System.Drawing.Point(36, 27)
        Me.radChuatra.Name = "radChuatra"
        Me.radChuatra.Size = New System.Drawing.Size(72, 18)
        Me.radChuatra.TabIndex = 54
        Me.radChuatra.TabStop = True
        Me.radChuatra.Text = "Chưa trả"
        Me.radChuatra.UseVisualStyleBackColor = True
        '
        'radDatra
        '
        Me.radDatra.AutoSize = True
        Me.radDatra.Location = New System.Drawing.Point(36, 53)
        Me.radDatra.Name = "radDatra"
        Me.radDatra.Size = New System.Drawing.Size(58, 18)
        Me.radDatra.TabIndex = 54
        Me.radDatra.Text = "Đã trả"
        Me.radDatra.UseVisualStyleBackColor = True
        '
        'grpXemtheo
        '
        Me.grpXemtheo.Controls.Add(Me.radDatra)
        Me.grpXemtheo.Controls.Add(Me.radChuatra)
        Me.grpXemtheo.Location = New System.Drawing.Point(41, 19)
        Me.grpXemtheo.Name = "grpXemtheo"
        Me.grpXemtheo.Size = New System.Drawing.Size(158, 81)
        Me.grpXemtheo.TabIndex = 55
        Me.grpXemtheo.TabStop = False
        Me.grpXemtheo.Text = "Xem theo"
        '
        'btnGhi
        '
        Me.btnGhi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.Color.Blue
        Me.btnGhi.Location = New System.Drawing.Point(610, 521)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(69, 27)
        Me.btnGhi.TabIndex = 56
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'FrmKiemSoatDiChuyenBoPhan
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 552)
        Me.Controls.Add(Me.grpXemtheo)
        Me.Controls.Add(Me.cboMS_ThietBi)
        Me.Controls.Add(Me.lblMS_ThietBi)
        Me.Controls.Add(Me.lblTieude)
        Me.Controls.Add(Me.grpDanhsach)
        Me.Controls.Add(Me.UtcComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPhieuBaoTri)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnKhongghi)
        Me.Controls.Add(Me.btnIn)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnGhi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmKiemSoatDiChuyenBoPhan"
        Me.Text = "Kiểm soát di chuyển bộ phận"
        Me.grpDanhsach.ResumeLayout(False)
        CType(Me.grdDanhsach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpXemtheo.ResumeLayout(False)
        Me.grpXemtheo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents grpDanhsach As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsach As System.Windows.Forms.DataGridView
    Friend WithEvents btnIn As System.Windows.Forms.Button
    Friend WithEvents UtcComboBox1 As Commons.UtcComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPhieuBaoTri As System.Windows.Forms.Label
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents cboMS_ThietBi As Commons.UtcComboBox
    Friend WithEvents lblMS_ThietBi As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnKhongghi As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpXemtheo As System.Windows.Forms.GroupBox
    Friend WithEvents radDatra As System.Windows.Forms.RadioButton
    Friend WithEvents radChuatra As System.Windows.Forms.RadioButton
    Friend WithEvents btnGhi As System.Windows.Forms.Button
End Class
