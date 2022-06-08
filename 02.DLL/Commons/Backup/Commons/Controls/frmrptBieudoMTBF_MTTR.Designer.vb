<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBieudoMTBF_MTTR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptBieudoMTBF_MTTR))
        Me.lblNhaxuong = New System.Windows.Forms.Label
        Me.lblDenthang = New System.Windows.Forms.Label
        Me.lblTuthang = New System.Windows.Forms.Label
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.gvLoaimay = New System.Windows.Forms.DataGridView
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MS_LOAI_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_LOAI_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbLoaimay = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnChonhet = New System.Windows.Forms.Button
        Me.btnBochon = New System.Windows.Forms.Button
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvLoaimay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoaimay.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(3, 27)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(59, 28)
        Me.lblNhaxuong.TabIndex = 14
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDenthang
        '
        Me.lblDenthang.AutoSize = True
        Me.lblDenthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenthang.Location = New System.Drawing.Point(276, 0)
        Me.lblDenthang.Name = "lblDenthang"
        Me.lblDenthang.Size = New System.Drawing.Size(57, 27)
        Me.lblDenthang.TabIndex = 12
        Me.lblDenthang.Text = "Đến tháng"
        Me.lblDenthang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTuthang
        '
        Me.lblTuthang.AutoSize = True
        Me.lblTuthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuthang.Location = New System.Drawing.Point(3, 0)
        Me.lblTuthang.Name = "lblTuthang"
        Me.lblTuthang.Size = New System.Drawing.Size(59, 27)
        Me.lblTuthang.TabIndex = 13
        Me.lblTuthang.Text = "Từ tháng"
        Me.lblTuthang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.gvLoaimay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvLoaimay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvLoaimay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_LOAI_MAY, Me.TEN_LOAI_MAY})
        Me.gvLoaimay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvLoaimay.Location = New System.Drawing.Point(3, 38)
        Me.gvLoaimay.Name = "gvLoaimay"
        Me.gvLoaimay.RowHeadersWidth = 21
        Me.gvLoaimay.Size = New System.Drawing.Size(526, 359)
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbLoaimay, 4)
        Me.gbLoaimay.Controls.Add(Me.TableLayoutPanel2)
        Me.gbLoaimay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLoaimay.Location = New System.Drawing.Point(3, 58)
        Me.gbLoaimay.Name = "gbLoaimay"
        Me.gbLoaimay.Size = New System.Drawing.Size(538, 419)
        Me.gbLoaimay.TabIndex = 11
        Me.gbLoaimay.TabStop = False
        Me.gbLoaimay.Text = "Loại máy"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gvLoaimay, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(532, 400)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnChonhet)
        Me.Panel1.Controls.Add(Me.btnBochon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 29)
        Me.Panel1.TabIndex = 3
        '
        'btnChonhet
        '
        Me.btnChonhet.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.btnChonhet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnChonhet.Location = New System.Drawing.Point(3, 3)
        Me.btnChonhet.Name = "btnChonhet"
        Me.btnChonhet.Size = New System.Drawing.Size(106, 23)
        Me.btnChonhet.TabIndex = 1
        Me.btnChonhet.Text = "Chọn hết"
        Me.btnChonhet.UseVisualStyleBackColor = True
        '
        'btnBochon
        '
        Me.btnBochon.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.btnBochon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBochon.Location = New System.Drawing.Point(120, 3)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(95, 23)
        Me.btnBochon.TabIndex = 1
        Me.btnBochon.Text = "Bỏ chọn"
        Me.btnBochon.UseVisualStyleBackColor = True
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNhaxuong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaxuong, 3)
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(68, 30)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(473, 21)
        Me.cboNhaxuong.TabIndex = 10
        '
        'dtpDenngay
        '
        Me.dtpDenngay.CustomFormat = "MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(339, 3)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(202, 20)
        Me.dtpDenngay.TabIndex = 8
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(68, 3)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(202, 20)
        Me.dtpTungay.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuthang, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gbLoaimay, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenthang, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(544, 516)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 4)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 483)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(538, 30)
        Me.TableLayoutPanel3.TabIndex = 16
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(441, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 16
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(328, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(100, 24)
        Me.btnThucHien.TabIndex = 15
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
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
        Me.Name = "frmrptBieudoMTBF_MTTR"
        Me.Size = New System.Drawing.Size(544, 516)
        CType(Me.gvLoaimay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoaimay.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents btnBochon As System.Windows.Forms.Button
    Friend WithEvents btnChonhet As System.Windows.Forms.Button
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_LOAI_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_LOAI_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
