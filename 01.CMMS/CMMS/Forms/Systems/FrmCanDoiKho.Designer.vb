<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCanDoiKho
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
        Me.TB_LAYOUT = New System.Windows.Forms.TableLayoutPanel
        Me.labTitle = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btEdit = New System.Windows.Forms.Button
        Me.btExit = New System.Windows.Forms.Button
        Me.labPBT = New System.Windows.Forms.Label
        Me.cboPBT = New System.Windows.Forms.ComboBox
        Me.gvCanDoiXuat = New System.Windows.Forms.DataGridView
        Me.MS_DHX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MS_PBT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MS_KHO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MS_DHN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_VI_TRI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SL_VT = New ControlInfo.DataGridviewNumberColumn
        Me.SL_XUAT = New ControlInfo.DataGridviewNumberColumn
        Me.ID_XUAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TB_LAYOUT.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gvCanDoiXuat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_LAYOUT
        '
        Me.TB_LAYOUT.ColumnCount = 4
        Me.TB_LAYOUT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TB_LAYOUT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TB_LAYOUT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199.0!))
        Me.TB_LAYOUT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TB_LAYOUT.Controls.Add(Me.labTitle, 0, 0)
        Me.TB_LAYOUT.Controls.Add(Me.Panel1, 0, 3)
        Me.TB_LAYOUT.Controls.Add(Me.labPBT, 1, 1)
        Me.TB_LAYOUT.Controls.Add(Me.cboPBT, 2, 1)
        Me.TB_LAYOUT.Controls.Add(Me.gvCanDoiXuat, 0, 2)
        Me.TB_LAYOUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_LAYOUT.Location = New System.Drawing.Point(0, 0)
        Me.TB_LAYOUT.Name = "TB_LAYOUT"
        Me.TB_LAYOUT.RowCount = 4
        Me.TB_LAYOUT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TB_LAYOUT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TB_LAYOUT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TB_LAYOUT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TB_LAYOUT.Size = New System.Drawing.Size(759, 427)
        Me.TB_LAYOUT.TabIndex = 0
        '
        'labTitle
        '
        Me.labTitle.AutoSize = True
        Me.TB_LAYOUT.SetColumnSpan(Me.labTitle, 4)
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTitle.Location = New System.Drawing.Point(3, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(753, 32)
        Me.labTitle.TabIndex = 0
        Me.labTitle.Text = "CÂN ĐỐI DỮ LIỆU XUẤT KHO CHO PHIẾU BÁO TRÌ"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TB_LAYOUT.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btEdit)
        Me.Panel1.Controls.Add(Me.btExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 398)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 26)
        Me.Panel1.TabIndex = 1
        '
        'btEdit
        '
        Me.btEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btEdit.Location = New System.Drawing.Point(565, 0)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(94, 27)
        Me.btEdit.TabIndex = 1
        Me.btEdit.Text = "Update"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'btExit
        '
        Me.btExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExit.Location = New System.Drawing.Point(659, 0)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(94, 27)
        Me.btExit.TabIndex = 0
        Me.btExit.Text = "Th&oát"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'labPBT
        '
        Me.labPBT.AutoSize = True
        Me.labPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labPBT.Location = New System.Drawing.Point(223, 32)
        Me.labPBT.Name = "labPBT"
        Me.labPBT.Size = New System.Drawing.Size(114, 28)
        Me.labPBT.TabIndex = 2
        Me.labPBT.Text = "Chọn phiếu bảo trì"
        Me.labPBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPBT
        '
        Me.cboPBT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboPBT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPBT.FormattingEnabled = True
        Me.cboPBT.Location = New System.Drawing.Point(343, 35)
        Me.cboPBT.Name = "cboPBT"
        Me.cboPBT.Size = New System.Drawing.Size(193, 23)
        Me.cboPBT.TabIndex = 3
        '
        'gvCanDoiXuat
        '
        Me.gvCanDoiXuat.AllowUserToAddRows = False
        Me.gvCanDoiXuat.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gvCanDoiXuat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gvCanDoiXuat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvCanDoiXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCanDoiXuat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_DHX, Me.MS_PBT, Me.MS_KHO, Me.MS_DHN, Me.MS_PT, Me.TEN_PT, Me.VT, Me.TEN_VI_TRI, Me.STT, Me.SL_VT, Me.SL_XUAT, Me.ID_XUAT})
        Me.TB_LAYOUT.SetColumnSpan(Me.gvCanDoiXuat, 4)
        Me.gvCanDoiXuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvCanDoiXuat.Location = New System.Drawing.Point(3, 63)
        Me.gvCanDoiXuat.Name = "gvCanDoiXuat"
        Me.gvCanDoiXuat.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.gvCanDoiXuat.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.gvCanDoiXuat.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.gvCanDoiXuat.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gvCanDoiXuat.Size = New System.Drawing.Size(753, 329)
        Me.gvCanDoiXuat.TabIndex = 4
        '
        'MS_DHX
        '
        Me.MS_DHX.HeaderText = "Mã số đơn hàng xuất"
        Me.MS_DHX.MinimumWidth = 160
        Me.MS_DHX.Name = "MS_DHX"
        Me.MS_DHX.ReadOnly = True
        Me.MS_DHX.Width = 160
        '
        'MS_PBT
        '
        Me.MS_PBT.HeaderText = "Mã số phiếu bảo trì"
        Me.MS_PBT.MinimumWidth = 160
        Me.MS_PBT.Name = "MS_PBT"
        Me.MS_PBT.ReadOnly = True
        Me.MS_PBT.Visible = False
        Me.MS_PBT.Width = 160
        '
        'MS_KHO
        '
        Me.MS_KHO.HeaderText = "Mã số kho"
        Me.MS_KHO.MinimumWidth = 120
        Me.MS_KHO.Name = "MS_KHO"
        Me.MS_KHO.Visible = False
        Me.MS_KHO.Width = 120
        '
        'MS_DHN
        '
        Me.MS_DHN.HeaderText = "Mã số đơn hàng nhập"
        Me.MS_DHN.MinimumWidth = 160
        Me.MS_DHN.Name = "MS_DHN"
        Me.MS_DHN.ReadOnly = True
        Me.MS_DHN.Width = 160
        '
        'MS_PT
        '
        Me.MS_PT.HeaderText = "Mã số phụ tùng"
        Me.MS_PT.MinimumWidth = 120
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.ReadOnly = True
        Me.MS_PT.Width = 120
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.HeaderText = "Tên phụ tùng"
        Me.TEN_PT.MinimumWidth = 200
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.ReadOnly = True
        '
        'VT
        '
        Me.VT.HeaderText = "Vị trí"
        Me.VT.MinimumWidth = 80
        Me.VT.Name = "VT"
        Me.VT.ReadOnly = True
        Me.VT.Visible = False
        Me.VT.Width = 80
        '
        'TEN_VI_TRI
        '
        Me.TEN_VI_TRI.HeaderText = "Vị trí kho"
        Me.TEN_VI_TRI.Name = "TEN_VI_TRI"
        '
        'STT
        '
        Me.STT.HeaderText = "STT"
        Me.STT.Name = "STT"
        Me.STT.Visible = False
        '
        'SL_VT
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "N2"
        Me.SL_VT.DefaultCellStyle = DataGridViewCellStyle3
        Me.SL_VT.FormatNumber = "N2"
        Me.SL_VT.HeaderText = "SL Đã xuất"
        Me.SL_VT.Isdouble = True
        Me.SL_VT.MinimumWidth = 120
        Me.SL_VT.Name = "SL_VT"
        Me.SL_VT.Negative = False
        Me.SL_VT.ReadOnly = True
        Me.SL_VT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SL_VT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SL_VT.Width = 120
        '
        'SL_XUAT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.SL_XUAT.DefaultCellStyle = DataGridViewCellStyle4
        Me.SL_XUAT.FormatNumber = "N2"
        Me.SL_XUAT.HeaderText = "SL Xuất"
        Me.SL_XUAT.Isdouble = True
        Me.SL_XUAT.Name = "SL_XUAT"
        Me.SL_XUAT.Negative = False
        '
        'ID_XUAT
        '
        Me.ID_XUAT.HeaderText = "ID_XUAT"
        Me.ID_XUAT.Name = "ID_XUAT"
        Me.ID_XUAT.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Mã số đơn hàng xuất"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 160
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 160
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Mã số phiếu bảo trì"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 160
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Mã số kho"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Mã số đơn hàng nhập"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 160
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 160
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Mã số phụ tùng"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Tên phụ tùng"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Vị trí"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "SL Đã xuất"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 120
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "STT"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "ID_XUAT"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'FrmCanDoiKho
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 427)
        Me.Controls.Add(Me.TB_LAYOUT)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmCanDoiKho"
        Me.Text = "FrmCanDoiKho"
        Me.TB_LAYOUT.ResumeLayout(False)
        Me.TB_LAYOUT.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gvCanDoiXuat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TB_LAYOUT As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btEdit As System.Windows.Forms.Button
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents labPBT As System.Windows.Forms.Label
    Friend WithEvents cboPBT As System.Windows.Forms.ComboBox
    Friend WithEvents gvCanDoiXuat As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_DHX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_PBT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_KHO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_DHN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_VI_TRI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_VT As ControlInfo.DataGridviewNumberColumn
    Friend WithEvents SL_XUAT As ControlInfo.DataGridviewNumberColumn
    Friend WithEvents ID_XUAT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
