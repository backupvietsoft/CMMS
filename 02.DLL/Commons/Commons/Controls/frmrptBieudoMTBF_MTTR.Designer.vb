<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBieudoMTBF_MTTR
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
        Me.lblNhaxuong = New System.Windows.Forms.Label()
        Me.lblDenthang = New System.Windows.Forms.Label()
        Me.lblTuthang = New System.Windows.Forms.Label()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gvLoaimay = New System.Windows.Forms.DataGridView()
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_LOAI_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_LOAI_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbLoaimay = New System.Windows.Forms.GroupBox()
        Me.btnChonhet = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBochon = New DevExpress.XtraEditors.SimpleButton()
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox()
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker()
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvLoaimay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoaimay.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(174, 33)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(104, 25)
        Me.lblNhaxuong.TabIndex = 14
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenthang
        '
        Me.lblDenthang.AutoSize = True
        Me.lblDenthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenthang.Location = New System.Drawing.Point(626, 8)
        Me.lblDenthang.Name = "lblDenthang"
        Me.lblDenthang.Size = New System.Drawing.Size(104, 25)
        Me.lblDenthang.TabIndex = 12
        Me.lblDenthang.Text = "Đến tháng"
        Me.lblDenthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTuthang
        '
        Me.lblTuthang.AutoSize = True
        Me.lblTuthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuthang.Location = New System.Drawing.Point(174, 8)
        Me.lblTuthang.Name = "lblTuthang"
        Me.lblTuthang.Size = New System.Drawing.Size(104, 25)
        Me.lblTuthang.TabIndex = 13
        Me.lblTuthang.Text = "Từ tháng"
        Me.lblTuthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 125
        '
        'gvLoaimay
        '
        Me.gvLoaimay.AllowUserToAddRows = False
        Me.gvLoaimay.AllowUserToDeleteRows = False
        Me.gvLoaimay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gvLoaimay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvLoaimay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvLoaimay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_LOAI_MAY, Me.TEN_LOAI_MAY})
        Me.gvLoaimay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvLoaimay.Location = New System.Drawing.Point(3, 17)
        Me.gvLoaimay.Name = "gvLoaimay"
        Me.gvLoaimay.RowHeadersWidth = 21
        Me.gvLoaimay.Size = New System.Drawing.Size(1235, 592)
        Me.gvLoaimay.TabIndex = 0
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.Name = "CHON"
        '
        'MS_LOAI_MAY
        '
        Me.MS_LOAI_MAY.HeaderText = "MS Loại Máy"
        Me.MS_LOAI_MAY.Name = "MS_LOAI_MAY"
        Me.MS_LOAI_MAY.ReadOnly = True
        '
        'TEN_LOAI_MAY
        '
        Me.TEN_LOAI_MAY.HeaderText = "Tên Loại Máy"
        Me.TEN_LOAI_MAY.Name = "TEN_LOAI_MAY"
        Me.TEN_LOAI_MAY.ReadOnly = True
        '
        'gbLoaimay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbLoaimay, 6)
        Me.gbLoaimay.Controls.Add(Me.gvLoaimay)
        Me.gbLoaimay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLoaimay.Location = New System.Drawing.Point(3, 65)
        Me.gbLoaimay.Name = "gbLoaimay"
        Me.gbLoaimay.Size = New System.Drawing.Size(1241, 612)
        Me.gbLoaimay.TabIndex = 11
        Me.gbLoaimay.TabStop = False
        Me.gbLoaimay.Text = "Loại máy"
        '
        'btnChonhet
        '
        Me.btnChonhet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChonhet.Location = New System.Drawing.Point(804, 3)
        Me.btnChonhet.LookAndFeel.SkinName = "Blue"
        Me.btnChonhet.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonhet.Name = "btnChonhet"
        Me.btnChonhet.Size = New System.Drawing.Size(104, 30)
        Me.btnChonhet.TabIndex = 1
        Me.btnChonhet.Text = "Chọn hết"
        '
        'btnBochon
        '
        Me.btnBochon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBochon.Location = New System.Drawing.Point(914, 3)
        Me.btnBochon.LookAndFeel.SkinName = "Blue"
        Me.btnBochon.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(104, 30)
        Me.btnBochon.TabIndex = 1
        Me.btnBochon.Text = "Bỏ chọn"
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNhaxuong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaxuong, 3)
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(284, 36)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(788, 21)
        Me.cboNhaxuong.TabIndex = 10
        '
        'dtpDenngay
        '
        Me.dtpDenngay.CustomFormat = "MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(736, 11)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(336, 21)
        Me.dtpDenngay.TabIndex = 8
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(284, 11)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(336, 21)
        Me.dtpTungay.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuthang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenthang, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.gbLoaimay, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1247, 722)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 6)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnChonhet, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnThoat, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBochon, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnThucHien, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 683)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1241, 36)
        Me.TableLayoutPanel3.TabIndex = 16
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(1134, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 16
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(1024, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 15
        Me.btnThucHien.Text = "Thực hiện"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_LOAI_MAY"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_LOAI_MAY"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'frmrptBieudoMTBF_MTTR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBieudoMTBF_MTTR"
        Me.Size = New System.Drawing.Size(1247, 722)
        CType(Me.gvLoaimay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoaimay.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents lblDenthang As System.Windows.Forms.Label
    Friend WithEvents lblTuthang As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvLoaimay As System.Windows.Forms.DataGridView
    Friend WithEvents gbLoaimay As System.Windows.Forms.GroupBox
    Friend WithEvents btnBochon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonhet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_LOAI_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_LOAI_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
