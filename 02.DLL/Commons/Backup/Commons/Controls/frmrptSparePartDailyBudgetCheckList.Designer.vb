<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptSparePartDailyBudgetCheckList
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptSparePartDailyBudgetCheckList))
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.btnBoChon = New System.Windows.Forms.Button
        Me.btnChonALL = New System.Windows.Forms.Button
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.lbaLoaiVTPT = New System.Windows.Forms.Label
        Me.cboLoaiVTPT = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grbBPCP = New System.Windows.Forms.GroupBox
        Me.grdListBPCP = New System.Windows.Forms.DataGridView
        Me.MS_BP_CHIU_PHI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TEN_BP_CHIU_PHI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbaKho = New System.Windows.Forms.Label
        Me.cboKho = New Commons.UtcComboBox
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbBPCP.SuspendLayout()
        CType(Me.grdListBPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(58, 25)
        Me.lbaTuNgay.TabIndex = 1
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiVTPT, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiVTPT, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grbBPCP, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(682, 513)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(476, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnBoChon
        '
        Me.btnBoChon.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.btnBoChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBoChon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoChon.Location = New System.Drawing.Point(103, 3)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(90, 23)
        Me.btnBoChon.TabIndex = 3
        Me.btnBoChon.Text = "Bo chon"
        Me.btnBoChon.UseVisualStyleBackColor = True
        '
        'btnChonALL
        '
        Me.btnChonALL.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.btnChonALL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnChonALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonALL.Location = New System.Drawing.Point(3, 3)
        Me.btnChonALL.Name = "btnChonALL"
        Me.btnChonALL.Size = New System.Drawing.Size(90, 23)
        Me.btnChonALL.TabIndex = 2
        Me.btnChonALL.Text = "Chon"
        Me.btnChonALL.UseVisualStyleBackColor = True
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(346, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(53, 25)
        Me.lbaDenNgay.TabIndex = 2
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(67, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(273, 20)
        Me.mtxtTuNgay.TabIndex = 3
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(405, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(274, 20)
        Me.mtxtDenNgay.TabIndex = 4
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'lbaLoaiVTPT
        '
        Me.lbaLoaiVTPT.AutoSize = True
        Me.lbaLoaiVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiVTPT.Location = New System.Drawing.Point(3, 25)
        Me.lbaLoaiVTPT.Name = "lbaLoaiVTPT"
        Me.lbaLoaiVTPT.Size = New System.Drawing.Size(58, 28)
        Me.lbaLoaiVTPT.TabIndex = 5
        Me.lbaLoaiVTPT.Text = "Loại VTPT"
        Me.lbaLoaiVTPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaiVTPT
        '
        Me.cboLoaiVTPT.AssemblyName = ""
        Me.cboLoaiVTPT.BackColor = System.Drawing.Color.White
        Me.cboLoaiVTPT.ClassName = ""
        Me.cboLoaiVTPT.Display = ""
        Me.cboLoaiVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiVTPT.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiVTPT.FormattingEnabled = True
        Me.cboLoaiVTPT.IsAll = True
        Me.cboLoaiVTPT.IsNew = False
        Me.cboLoaiVTPT.ItemAll = " < ALL > "
        Me.cboLoaiVTPT.ItemNew = "...New"
        Me.cboLoaiVTPT.Location = New System.Drawing.Point(67, 28)
        Me.cboLoaiVTPT.MethodName = ""
        Me.cboLoaiVTPT.Name = "cboLoaiVTPT"
        Me.cboLoaiVTPT.Param = ""
        Me.cboLoaiVTPT.Size = New System.Drawing.Size(273, 21)
        Me.cboLoaiVTPT.StoreName = ""
        Me.cboLoaiVTPT.TabIndex = 6
        Me.cboLoaiVTPT.Table = Nothing
        Me.cboLoaiVTPT.TextReadonly = False
        Me.cboLoaiVTPT.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grbBPCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbBPCP, 4)
        Me.grbBPCP.Controls.Add(Me.grdListBPCP)
        Me.grbBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbBPCP.Location = New System.Drawing.Point(3, 56)
        Me.grbBPCP.Name = "grbBPCP"
        Me.grbBPCP.Size = New System.Drawing.Size(676, 419)
        Me.grbBPCP.TabIndex = 7
        Me.grbBPCP.TabStop = False
        Me.grbBPCP.Text = "Bộ phận chịu phí"
        '
        'grdListBPCP
        '
        Me.grdListBPCP.AllowUserToAddRows = False
        Me.grdListBPCP.AllowUserToDeleteRows = False
        Me.grdListBPCP.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdListBPCP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdListBPCP.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdListBPCP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdListBPCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListBPCP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_BP_CHIU_PHI, Me.CHON, Me.TEN_BP_CHIU_PHI})
        Me.grdListBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListBPCP.Location = New System.Drawing.Point(3, 16)
        Me.grdListBPCP.Name = "grdListBPCP"
        Me.grdListBPCP.RowHeadersWidth = 30
        Me.grdListBPCP.Size = New System.Drawing.Size(670, 400)
        Me.grdListBPCP.TabIndex = 0
        '
        'MS_BP_CHIU_PHI
        '
        Me.MS_BP_CHIU_PHI.HeaderText = "MS BPCP"
        Me.MS_BP_CHIU_PHI.Name = "MS_BP_CHIU_PHI"
        Me.MS_BP_CHIU_PHI.Visible = False
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.MinimumWidth = 60
        Me.CHON.Name = "CHON"
        Me.CHON.Width = 60
        '
        'TEN_BP_CHIU_PHI
        '
        Me.TEN_BP_CHIU_PHI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_BP_CHIU_PHI.HeaderText = "Tên BP Chịu phí"
        Me.TEN_BP_CHIU_PHI.Name = "TEN_BP_CHIU_PHI"
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKho.Location = New System.Drawing.Point(346, 25)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(53, 28)
        Me.lbaKho.TabIndex = 8
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboKho
        '
        Me.cboKho.AssemblyName = ""
        Me.cboKho.BackColor = System.Drawing.Color.White
        Me.cboKho.ClassName = ""
        Me.cboKho.Display = ""
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.ErrorProviderControl = Me.ErrorProvider1
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.IsAll = True
        Me.cboKho.IsNew = False
        Me.cboKho.ItemAll = " < ALL > "
        Me.cboKho.ItemNew = "...New"
        Me.cboKho.Location = New System.Drawing.Point(405, 28)
        Me.cboKho.MethodName = ""
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Param = ""
        Me.cboKho.Size = New System.Drawing.Size(274, 21)
        Me.cboKho.StoreName = ""
        Me.cboKho.TabIndex = 9
        Me.cboKho.Table = Nothing
        Me.cboKho.TextReadonly = False
        Me.cboKho.Value = ""
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_BP_CHIU_PHI"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_BP_CHIU_PHI"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBoChon, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnChonALL, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 481)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(676, 29)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(579, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptSparePartDailyBudgetCheckList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptSparePartDailyBudgetCheckList"
        Me.Size = New System.Drawing.Size(682, 513)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbBPCP.ResumeLayout(False)
        CType(Me.grdListBPCP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnBoChon As System.Windows.Forms.Button
    Friend WithEvents btnChonALL As System.Windows.Forms.Button
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaLoaiVTPT As System.Windows.Forms.Label
    Friend WithEvents cboLoaiVTPT As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbBPCP As System.Windows.Forms.GroupBox
    Friend WithEvents grdListBPCP As System.Windows.Forms.DataGridView
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents cboKho As Commons.UtcComboBox
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents MS_BP_CHIU_PHI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TEN_BP_CHIU_PHI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
