<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTonKhoTheoDayChuyen
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TlbTonkho = New System.Windows.Forms.TableLayoutPanel()
        Me.Dgvmay = New System.Windows.Forms.DataGridView()
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHON_MAY = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BtnClearline = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAllline = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAllmay = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClearmay = New DevExpress.XtraEditors.SimpleButton()
        Me.Labline = New System.Windows.Forms.Label()
        Me.Labmay = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabKho = New System.Windows.Forms.Label()
        Me.CboKho = New System.Windows.Forms.ComboBox()
        Me.Dgvline = New System.Windows.Forms.DataGridView()
        Me.HE_THONG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHON_HT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TlbTonkho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
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
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlbTonkho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TlbTonkho.Size = New System.Drawing.Size(1034, 587)
        Me.TlbTonkho.TabIndex = 1
        '
        'Dgvmay
        '
        Me.Dgvmay.AllowUserToAddRows = False
        Me.Dgvmay.AllowUserToDeleteRows = False
        Me.Dgvmay.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Dgvmay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgvmay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvmay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_MAY, Me.TEN_MAY, Me.CHON_MAY})
        Me.TlbTonkho.SetColumnSpan(Me.Dgvmay, 3)
        Me.Dgvmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgvmay.Location = New System.Drawing.Point(428, 73)
        Me.Dgvmay.Margin = New System.Windows.Forms.Padding(1)
        Me.Dgvmay.Name = "Dgvmay"
        Me.Dgvmay.RowHeadersVisible = False
        Me.Dgvmay.Size = New System.Drawing.Size(605, 477)
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
        Me.BtnClearline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClearline.Location = New System.Drawing.Point(320, 3)
        Me.BtnClearline.LookAndFeel.SkinName = "Blue"
        Me.BtnClearline.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnClearline.Name = "BtnClearline"
        Me.BtnClearline.Size = New System.Drawing.Size(104, 30)
        Me.BtnClearline.TabIndex = 3
        Me.BtnClearline.Text = "Clear all"
        '
        'BtnAllline
        '
        Me.BtnAllline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllline.Location = New System.Drawing.Point(210, 3)
        Me.BtnAllline.LookAndFeel.SkinName = "Blue"
        Me.BtnAllline.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAllline.Name = "BtnAllline"
        Me.BtnAllline.Size = New System.Drawing.Size(104, 30)
        Me.BtnAllline.TabIndex = 2
        Me.BtnAllline.Text = "All"
        '
        'BtnAllmay
        '
        Me.BtnAllmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllmay.Location = New System.Drawing.Point(816, 39)
        Me.BtnAllmay.LookAndFeel.SkinName = "Blue"
        Me.BtnAllmay.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAllmay.Name = "BtnAllmay"
        Me.BtnAllmay.Size = New System.Drawing.Size(104, 30)
        Me.BtnAllmay.TabIndex = 4
        Me.BtnAllmay.Text = "All"
        '
        'BtnClearmay
        '
        Me.BtnClearmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClearmay.Location = New System.Drawing.Point(926, 39)
        Me.BtnClearmay.LookAndFeel.SkinName = "Blue"
        Me.BtnClearmay.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnClearmay.Name = "BtnClearmay"
        Me.BtnClearmay.Size = New System.Drawing.Size(105, 30)
        Me.BtnClearmay.TabIndex = 5
        Me.BtnClearmay.Text = "Clear all"
        '
        'Labline
        '
        Me.Labline.AutoSize = True
        Me.Labline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Labline.Location = New System.Drawing.Point(3, 0)
        Me.Labline.Name = "Labline"
        Me.Labline.Size = New System.Drawing.Size(201, 36)
        Me.Labline.TabIndex = 7
        Me.Labline.Text = "Chọn dây chuyền"
        Me.Labline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Labmay
        '
        Me.Labmay.AutoSize = True
        Me.Labmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Labmay.Location = New System.Drawing.Point(430, 36)
        Me.Labmay.Name = "Labmay"
        Me.Labmay.Size = New System.Drawing.Size(380, 36)
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(427, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(607, 36)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'LabKho
        '
        Me.LabKho.AutoSize = True
        Me.LabKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabKho.Location = New System.Drawing.Point(3, 0)
        Me.LabKho.Name = "LabKho"
        Me.LabKho.Size = New System.Drawing.Size(89, 36)
        Me.LabKho.TabIndex = 0
        Me.LabKho.Text = "Chọn kho"
        Me.LabKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboKho
        '
        Me.CboKho.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CboKho.FormattingEnabled = True
        Me.CboKho.Location = New System.Drawing.Point(95, 15)
        Me.CboKho.Margin = New System.Windows.Forms.Padding(0)
        Me.CboKho.Name = "CboKho"
        Me.CboKho.Size = New System.Drawing.Size(512, 21)
        Me.CboKho.TabIndex = 1
        '
        'Dgvline
        '
        Me.Dgvline.AllowUserToAddRows = False
        Me.Dgvline.AllowUserToDeleteRows = False
        Me.Dgvline.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Dgvline.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgvline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvline.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HE_THONG, Me.CHON_HT})
        Me.TlbTonkho.SetColumnSpan(Me.Dgvline, 3)
        Me.Dgvline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgvline.Location = New System.Drawing.Point(1, 37)
        Me.Dgvline.Margin = New System.Windows.Forms.Padding(1)
        Me.Dgvline.Name = "Dgvline"
        Me.Dgvline.RowHeadersVisible = False
        Me.TlbTonkho.SetRowSpan(Me.Dgvline, 2)
        Me.Dgvline.Size = New System.Drawing.Size(425, 513)
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
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TlbTonkho.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 554)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1028, 30)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(921, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 24)
        Me.btnThoat.TabIndex = 38
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(811, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 24)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
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
        'frmrptTonKhoTheoDayChuyen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TlbTonkho)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptTonKhoTheoDayChuyen"
        Me.Size = New System.Drawing.Size(1034, 587)
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
    Friend WithEvents BtnClearline As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAllline As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAllmay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClearmay As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents HE_THONG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_HT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
