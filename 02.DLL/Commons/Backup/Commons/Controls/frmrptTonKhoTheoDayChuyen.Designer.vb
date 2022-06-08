<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTonKhoTheoDayChuyen
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptTonKhoTheoDayChuyen))
        Me.TlbTonkho = New System.Windows.Forms.TableLayoutPanel
        Me.Dgvmay = New System.Windows.Forms.DataGridView
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON_MAY = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BtnClearline = New System.Windows.Forms.Button
        Me.BtnAllline = New System.Windows.Forms.Button
        Me.BtnAllmay = New System.Windows.Forms.Button
        Me.BtnClearmay = New System.Windows.Forms.Button
        Me.Labline = New System.Windows.Forms.Label
        Me.Labmay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.LabKho = New System.Windows.Forms.Label
        Me.CboKho = New System.Windows.Forms.ComboBox
        Me.Dgvline = New System.Windows.Forms.DataGridView
        Me.HE_THONG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON_HT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TlbTonkho.SuspendLayout()
        CType(Me.Dgvmay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dgvline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TlbTonkho
        '
        Me.TlbTonkho.ColumnCount = 6
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TlbTonkho.Controls.Add(Me.Dgvmay, 3, 2)
        Me.TlbTonkho.Controls.Add(Me.BtnClearline, 2, 0)
        Me.TlbTonkho.Controls.Add(Me.BtnAllline, 1, 0)
        Me.TlbTonkho.Controls.Add(Me.BtnAllmay, 4, 1)
        Me.TlbTonkho.Controls.Add(Me.BtnClearmay, 5, 1)
        Me.TlbTonkho.Controls.Add(Me.Labline, 0, 0)
        Me.TlbTonkho.Controls.Add(Me.Labmay, 3, 1)
        Me.TlbTonkho.Controls.Add(Me.TableLayoutPanel1, 3, 0)
        Me.TlbTonkho.Controls.Add(Me.Dgvline, 0, 1)
        Me.TlbTonkho.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TlbTonkho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlbTonkho.Location = New System.Drawing.Point(0, 0)
        Me.TlbTonkho.Margin = New System.Windows.Forms.Padding(0)
        Me.TlbTonkho.Name = "TlbTonkho"
        Me.TlbTonkho.RowCount = 2
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TlbTonkho.Size = New System.Drawing.Size(579, 482)
        Me.TlbTonkho.TabIndex = 1
        '
        'Dgvmay
        '
        Me.Dgvmay.AllowUserToAddRows = False
        Me.Dgvmay.AllowUserToDeleteRows = False
        Me.Dgvmay.BackgroundColor = System.Drawing.SystemColors.Window
        Me.Dgvmay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgvmay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvmay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_MAY, Me.TEN_MAY, Me.CHON_MAY})
        Me.TlbTonkho.SetColumnSpan(Me.Dgvmay, 3)
        Me.Dgvmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgvmay.Location = New System.Drawing.Point(248, 49)
        Me.Dgvmay.Margin = New System.Windows.Forms.Padding(1)
        Me.Dgvmay.Name = "Dgvmay"
        Me.Dgvmay.RowHeadersVisible = False
        Me.Dgvmay.Size = New System.Drawing.Size(330, 397)
        Me.Dgvmay.TabIndex = 10
        '
        'MS_MAY
        '
        Me.MS_MAY.HeaderText = "MS máy"
        Me.MS_MAY.MinimumWidth = 120
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.ReadOnly = True
        Me.MS_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MS_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MS_MAY.Width = 120
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_MAY.HeaderText = "Tên máy"
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.ReadOnly = True
        '
        'CHON_MAY
        '
        Me.CHON_MAY.HeaderText = ""
        Me.CHON_MAY.MinimumWidth = 50
        Me.CHON_MAY.Name = "CHON_MAY"
        Me.CHON_MAY.Width = 50
        '
        'BtnClearline
        '
        Me.BtnClearline.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClearline.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.BtnClearline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnClearline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClearline.Location = New System.Drawing.Point(169, 0)
        Me.BtnClearline.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClearline.Name = "BtnClearline"
        Me.BtnClearline.Size = New System.Drawing.Size(78, 24)
        Me.BtnClearline.TabIndex = 3
        Me.BtnClearline.Text = "Clear all"
        Me.BtnClearline.UseVisualStyleBackColor = False
        '
        'BtnAllline
        '
        Me.BtnAllline.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAllline.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.BtnAllline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnAllline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllline.Location = New System.Drawing.Point(94, 0)
        Me.BtnAllline.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnAllline.Name = "BtnAllline"
        Me.BtnAllline.Size = New System.Drawing.Size(75, 24)
        Me.BtnAllline.TabIndex = 2
        Me.BtnAllline.Text = "All"
        Me.BtnAllline.UseVisualStyleBackColor = False
        '
        'BtnAllmay
        '
        Me.BtnAllmay.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAllmay.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.BtnAllmay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnAllmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllmay.Location = New System.Drawing.Point(421, 24)
        Me.BtnAllmay.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnAllmay.Name = "BtnAllmay"
        Me.BtnAllmay.Size = New System.Drawing.Size(75, 24)
        Me.BtnAllmay.TabIndex = 4
        Me.BtnAllmay.Text = "All"
        Me.BtnAllmay.UseVisualStyleBackColor = False
        '
        'BtnClearmay
        '
        Me.BtnClearmay.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClearmay.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.BtnClearmay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnClearmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClearmay.Location = New System.Drawing.Point(496, 24)
        Me.BtnClearmay.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClearmay.Name = "BtnClearmay"
        Me.BtnClearmay.Size = New System.Drawing.Size(83, 24)
        Me.BtnClearmay.TabIndex = 5
        Me.BtnClearmay.Text = "Clear all"
        Me.BtnClearmay.UseVisualStyleBackColor = False
        '
        'Labline
        '
        Me.Labline.AutoSize = True
        Me.Labline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Labline.Location = New System.Drawing.Point(3, 0)
        Me.Labline.Name = "Labline"
        Me.Labline.Size = New System.Drawing.Size(88, 24)
        Me.Labline.TabIndex = 7
        Me.Labline.Text = "Chọn dây chuyền"
        Me.Labline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Labmay
        '
        Me.Labmay.AutoSize = True
        Me.Labmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Labmay.Location = New System.Drawing.Point(250, 24)
        Me.Labmay.Name = "Labmay"
        Me.Labmay.Size = New System.Drawing.Size(168, 24)
        Me.Labmay.TabIndex = 9
        Me.Labmay.Text = "Chọn máy"
        Me.Labmay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TlbTonkho.SetColumnSpan(Me.TableLayoutPanel1, 3)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabKho, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CboKho, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(247, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(332, 24)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'LabKho
        '
        Me.LabKho.AutoSize = True
        Me.LabKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabKho.Location = New System.Drawing.Point(3, 0)
        Me.LabKho.Name = "LabKho"
        Me.LabKho.Size = New System.Drawing.Size(89, 24)
        Me.LabKho.TabIndex = 0
        Me.LabKho.Text = "Chọn kho"
        Me.LabKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboKho
        '
        Me.CboKho.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CboKho.FormattingEnabled = True
        Me.CboKho.Location = New System.Drawing.Point(95, 3)
        Me.CboKho.Margin = New System.Windows.Forms.Padding(0)
        Me.CboKho.Name = "CboKho"
        Me.CboKho.Size = New System.Drawing.Size(237, 21)
        Me.CboKho.TabIndex = 1
        '
        'Dgvline
        '
        Me.Dgvline.AllowUserToAddRows = False
        Me.Dgvline.AllowUserToDeleteRows = False
        Me.Dgvline.BackgroundColor = System.Drawing.SystemColors.Window
        Me.Dgvline.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgvline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvline.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HE_THONG, Me.CHON_HT})
        Me.TlbTonkho.SetColumnSpan(Me.Dgvline, 3)
        Me.Dgvline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgvline.Location = New System.Drawing.Point(1, 25)
        Me.Dgvline.Margin = New System.Windows.Forms.Padding(1)
        Me.Dgvline.Name = "Dgvline"
        Me.Dgvline.RowHeadersVisible = False
        Me.TlbTonkho.SetRowSpan(Me.Dgvline, 2)
        Me.Dgvline.Size = New System.Drawing.Size(245, 421)
        Me.Dgvline.TabIndex = 6
        '
        'HE_THONG
        '
        Me.HE_THONG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HE_THONG.HeaderText = "Dây chuyền"
        Me.HE_THONG.Name = "HE_THONG"
        Me.HE_THONG.ReadOnly = True
        Me.HE_THONG.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HE_THONG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CHON_HT
        '
        Me.CHON_HT.HeaderText = ""
        Me.CHON_HT.MinimumWidth = 50
        Me.CHON_HT.Name = "CHON_HT"
        Me.CHON_HT.Width = 50
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TlbTonkho.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 450)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(573, 29)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(373, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 30
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = ""
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 30
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS máy"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tên máy"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dây chuyền"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(476, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 38
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptTonKhoTheoDayChuyen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TlbTonkho)
        Me.Name = "frmrptTonKhoTheoDayChuyen"
        Me.Size = New System.Drawing.Size(579, 482)
        Me.TlbTonkho.ResumeLayout(False)
        Me.TlbTonkho.PerformLayout()
        CType(Me.Dgvmay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Dgvline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TlbTonkho As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dgvmay As System.Windows.Forms.DataGridView
    Friend WithEvents BtnClearline As System.Windows.Forms.Button
    Friend WithEvents BtnAllline As System.Windows.Forms.Button
    Friend WithEvents BtnAllmay As System.Windows.Forms.Button
    Friend WithEvents BtnClearmay As System.Windows.Forms.Button
    Friend WithEvents Dgvline As System.Windows.Forms.DataGridView
    Friend WithEvents Labline As System.Windows.Forms.Label
    Friend WithEvents Labmay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabKho As System.Windows.Forms.Label
    Friend WithEvents CboKho As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents HE_THONG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_HT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
