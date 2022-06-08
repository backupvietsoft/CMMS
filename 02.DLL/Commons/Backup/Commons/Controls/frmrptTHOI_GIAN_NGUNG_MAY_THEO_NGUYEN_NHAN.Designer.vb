<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GrbCause = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.DgvCause = New System.Windows.Forms.DataGridView
        Me.MS_NGUYEN_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_NGUYEN_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON_NGUYEN_NHAN = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BtnAllCause = New System.Windows.Forms.Button
        Me.BtnClearCause = New System.Windows.Forms.Button
        Me.GrbLine = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.BtnNo = New System.Windows.Forms.Button
        Me.BtnAllLine = New System.Windows.Forms.Button
        Me.DgvLine = New System.Windows.Forms.DataGridView
        Me.MS_HE_THONG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_HE_THONG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON_HE_THONG = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.MskTodate = New System.Windows.Forms.MaskedTextBox
        Me.MskFromdate = New System.Windows.Forms.MaskedTextBox
        Me.LabFromdate = New System.Windows.Forms.Label
        Me.LabTodate = New System.Windows.Forms.Label
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GrbCause.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DgvCause, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrbLine.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.DgvLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GrbCause, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrbLine, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MskTodate, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MskFromdate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabFromdate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabTodate, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(494, 336)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'GrbCause
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrbCause, 3)
        Me.GrbCause.Controls.Add(Me.TableLayoutPanel3)
        Me.GrbCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrbCause.Location = New System.Drawing.Point(249, 28)
        Me.GrbCause.Name = "GrbCause"
        Me.GrbCause.Size = New System.Drawing.Size(242, 263)
        Me.GrbCause.TabIndex = 11
        Me.GrbCause.TabStop = False
        Me.GrbCause.Text = "Chọn nguyên nhân"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DgvCause, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnAllCause, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnClearCause, 2, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(236, 244)
        Me.TableLayoutPanel3.TabIndex = 10
        '
        'DgvCause
        '
        Me.DgvCause.AllowUserToAddRows = False
        Me.DgvCause.AllowUserToDeleteRows = False
        Me.DgvCause.AllowUserToResizeRows = False
        Me.DgvCause.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvCause.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvCause.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCause.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_NGUYEN_NHAN, Me.TEN_NGUYEN_NHAN, Me.CHON_NGUYEN_NHAN})
        Me.TableLayoutPanel3.SetColumnSpan(Me.DgvCause, 4)
        Me.DgvCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCause.Location = New System.Drawing.Point(3, 3)
        Me.DgvCause.Name = "DgvCause"
        Me.DgvCause.RowHeadersWidth = 30
        Me.DgvCause.Size = New System.Drawing.Size(230, 202)
        Me.DgvCause.TabIndex = 11
        '
        'MS_NGUYEN_NHAN
        '
        Me.MS_NGUYEN_NHAN.HeaderText = ""
        Me.MS_NGUYEN_NHAN.Name = "MS_NGUYEN_NHAN"
        Me.MS_NGUYEN_NHAN.ReadOnly = True
        Me.MS_NGUYEN_NHAN.Visible = False
        '
        'TEN_NGUYEN_NHAN
        '
        Me.TEN_NGUYEN_NHAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_NGUYEN_NHAN.FillWeight = 169.5432!
        Me.TEN_NGUYEN_NHAN.HeaderText = "Nguyên nhân"
        Me.TEN_NGUYEN_NHAN.Name = "TEN_NGUYEN_NHAN"
        Me.TEN_NGUYEN_NHAN.ReadOnly = True
        '
        'CHON_NGUYEN_NHAN
        '
        Me.CHON_NGUYEN_NHAN.FillWeight = 30.45686!
        Me.CHON_NGUYEN_NHAN.HeaderText = ""
        Me.CHON_NGUYEN_NHAN.MinimumWidth = 30
        Me.CHON_NGUYEN_NHAN.Name = "CHON_NGUYEN_NHAN"
        '
        'BtnAllCause
        '
        Me.BtnAllCause.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.BtnAllCause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnAllCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllCause.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAllCause.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnAllCause.Location = New System.Drawing.Point(8, 211)
        Me.BtnAllCause.Name = "BtnAllCause"
        Me.BtnAllCause.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnAllCause.Size = New System.Drawing.Size(84, 30)
        Me.BtnAllCause.TabIndex = 2
        Me.BtnAllCause.Text = "&Chọn"
        Me.BtnAllCause.UseVisualStyleBackColor = True
        '
        'BtnClearCause
        '
        Me.BtnClearCause.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.BtnClearCause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnClearCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClearCause.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearCause.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnClearCause.Location = New System.Drawing.Point(98, 211)
        Me.BtnClearCause.Name = "BtnClearCause"
        Me.BtnClearCause.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnClearCause.Size = New System.Drawing.Size(84, 30)
        Me.BtnClearCause.TabIndex = 2
        Me.BtnClearCause.Text = "&Bỏ chọn"
        Me.BtnClearCause.UseVisualStyleBackColor = True
        '
        'GrbLine
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrbLine, 3)
        Me.GrbLine.Controls.Add(Me.TableLayoutPanel2)
        Me.GrbLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrbLine.Location = New System.Drawing.Point(3, 28)
        Me.GrbLine.Name = "GrbLine"
        Me.GrbLine.Size = New System.Drawing.Size(240, 263)
        Me.GrbLine.TabIndex = 10
        Me.GrbLine.TabStop = False
        Me.GrbLine.Text = "Chọn dây chuyền"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnNo, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnAllLine, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DgvLine, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(234, 244)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'BtnNo
        '
        Me.BtnNo.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.BtnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnNo.Location = New System.Drawing.Point(98, 211)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnNo.Size = New System.Drawing.Size(84, 30)
        Me.BtnNo.TabIndex = 2
        Me.BtnNo.Text = "&Bỏ chọn"
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'BtnAllLine
        '
        Me.BtnAllLine.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.BtnAllLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnAllLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAllLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAllLine.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnAllLine.Location = New System.Drawing.Point(8, 211)
        Me.BtnAllLine.Name = "BtnAllLine"
        Me.BtnAllLine.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnAllLine.Size = New System.Drawing.Size(84, 30)
        Me.BtnAllLine.TabIndex = 2
        Me.BtnAllLine.Text = "&Chọn"
        Me.BtnAllLine.UseVisualStyleBackColor = True
        '
        'DgvLine
        '
        Me.DgvLine.AllowUserToAddRows = False
        Me.DgvLine.AllowUserToDeleteRows = False
        Me.DgvLine.AllowUserToResizeRows = False
        Me.DgvLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvLine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_HE_THONG, Me.TEN_HE_THONG, Me.CHON_HE_THONG})
        Me.TableLayoutPanel2.SetColumnSpan(Me.DgvLine, 4)
        Me.DgvLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvLine.Location = New System.Drawing.Point(3, 3)
        Me.DgvLine.Name = "DgvLine"
        Me.DgvLine.RowHeadersWidth = 30
        Me.DgvLine.Size = New System.Drawing.Size(228, 202)
        Me.DgvLine.TabIndex = 9
        '
        'MS_HE_THONG
        '
        Me.MS_HE_THONG.HeaderText = ""
        Me.MS_HE_THONG.Name = "MS_HE_THONG"
        Me.MS_HE_THONG.ReadOnly = True
        Me.MS_HE_THONG.Visible = False
        '
        'TEN_HE_THONG
        '
        Me.TEN_HE_THONG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_HE_THONG.FillWeight = 169.5432!
        Me.TEN_HE_THONG.HeaderText = "Hệ thống"
        Me.TEN_HE_THONG.Name = "TEN_HE_THONG"
        Me.TEN_HE_THONG.ReadOnly = True
        '
        'CHON_HE_THONG
        '
        Me.CHON_HE_THONG.FillWeight = 30.45686!
        Me.CHON_HE_THONG.HeaderText = ""
        Me.CHON_HE_THONG.MinimumWidth = 30
        Me.CHON_HE_THONG.Name = "CHON_HE_THONG"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel4, 6)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 297)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(488, 36)
        Me.TableLayoutPanel4.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(401, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(311, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'MskTodate
        '
        Me.MskTodate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MskTodate.Location = New System.Drawing.Point(308, 3)
        Me.MskTodate.Mask = "00/00/0000"
        Me.MskTodate.Name = "MskTodate"
        Me.MskTodate.Size = New System.Drawing.Size(107, 20)
        Me.MskTodate.TabIndex = 3
        Me.MskTodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MskTodate.ValidatingType = GetType(Date)
        '
        'MskFromdate
        '
        Me.MskFromdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MskFromdate.Location = New System.Drawing.Point(136, 3)
        Me.MskFromdate.Mask = "00/00/0000"
        Me.MskFromdate.Name = "MskFromdate"
        Me.MskFromdate.Size = New System.Drawing.Size(107, 20)
        Me.MskFromdate.TabIndex = 2
        Me.MskFromdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MskFromdate.ValidatingType = GetType(Date)
        '
        'LabFromdate
        '
        Me.LabFromdate.AutoSize = True
        Me.LabFromdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabFromdate.Location = New System.Drawing.Point(77, 0)
        Me.LabFromdate.Name = "LabFromdate"
        Me.LabFromdate.Size = New System.Drawing.Size(53, 25)
        Me.LabFromdate.TabIndex = 0
        Me.LabFromdate.Text = "Từ ngày"
        Me.LabFromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabTodate
        '
        Me.LabTodate.AutoSize = True
        Me.LabTodate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabTodate.Location = New System.Drawing.Point(249, 0)
        Me.LabTodate.Name = "LabTodate"
        Me.LabTodate.Size = New System.Drawing.Size(53, 25)
        Me.LabTodate.TabIndex = 1
        Me.LabTodate.Text = "Đến ngày"
        Me.LabTodate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FillWeight = 30.45685!
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 30
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.FillWeight = 30.45685!
        Me.DataGridViewCheckBoxColumn2.HeaderText = ""
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 30
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.FillWeight = 169.5432!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Hệ thống"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.FillWeight = 169.5432!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
        Me.Size = New System.Drawing.Size(494, 336)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GrbCause.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.DgvCause, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrbLine.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.DgvLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabFromdate As System.Windows.Forms.Label
    Friend WithEvents LabTodate As System.Windows.Forms.Label
    Friend WithEvents MskFromdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MskTodate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GrbCause As System.Windows.Forms.GroupBox
    Friend WithEvents DgvCause As System.Windows.Forms.DataGridView
    Friend WithEvents MS_NGUYEN_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_NGUYEN_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_NGUYEN_NHAN As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClearCause As System.Windows.Forms.Button
    Friend WithEvents BtnAllCause As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GrbLine As System.Windows.Forms.GroupBox
    Friend WithEvents DgvLine As System.Windows.Forms.DataGridView
    Friend WithEvents MS_HE_THONG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_HE_THONG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_HE_THONG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents BtnAllLine As System.Windows.Forms.Button
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
