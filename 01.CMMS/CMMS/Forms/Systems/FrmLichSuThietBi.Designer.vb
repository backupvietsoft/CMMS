<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLichSuThietBi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.grdPhuTungThayThe = New System.Windows.Forms.GroupBox
        Me.grdLichsuPTThayThe = New System.Windows.Forms.DataGridView
        Me.grpDieulienchon = New System.Windows.Forms.GroupBox
        Me.txtGiatri = New System.Windows.Forms.TextBox
        Me.rdchontheoten = New System.Windows.Forms.RadioButton
        Me.rdChontheoma = New System.Windows.Forms.RadioButton
        Me.grpLichsuthietbi = New System.Windows.Forms.GroupBox
        Me.grdLichsuthietbi = New System.Windows.Forms.DataGridView
        Me.grpThietBi = New System.Windows.Forms.GroupBox
        Me.tvHistory = New System.Windows.Forms.TreeView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblTuNgay1 = New System.Windows.Forms.Label
        Me.txtBoPhanTT = New Commons.utcTextBox
        Me.dtpDenNgay1 = New System.Windows.Forms.DateTimePicker
        Me.lblMayTT = New System.Windows.Forms.Label
        Me.lblBoPhanTT = New System.Windows.Forms.Label
        Me.lblDenNgay1 = New System.Windows.Forms.Label
        Me.dtpTuNgay1 = New System.Windows.Forms.DateTimePicker
        Me.txtMayTT = New Commons.utcTextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnXemPBT = New System.Windows.Forms.Button
        Me.BtnThoat6 = New System.Windows.Forms.Button
        Me.btLichSuCauTrucTB = New System.Windows.Forms.Button
        Me.TableLayoutPanel4.SuspendLayout()
        Me.grdPhuTungThayThe.SuspendLayout()
        CType(Me.grdLichsuPTThayThe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDieulienchon.SuspendLayout()
        Me.grpLichsuthietbi.SuspendLayout()
        CType(Me.grdLichsuthietbi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpThietBi.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.grdPhuTungThayThe, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.grpDieulienchon, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.grpLichsuthietbi, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.grpThietBi, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel2, 1, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(707, 436)
        Me.TableLayoutPanel4.TabIndex = 97
        '
        'grdPhuTungThayThe
        '
        Me.grdPhuTungThayThe.Controls.Add(Me.grdLichsuPTThayThe)
        Me.grdPhuTungThayThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPhuTungThayThe.ForeColor = System.Drawing.Color.Maroon
        Me.grdPhuTungThayThe.Location = New System.Drawing.Point(256, 217)
        Me.grdPhuTungThayThe.Name = "grdPhuTungThayThe"
        Me.grdPhuTungThayThe.Size = New System.Drawing.Size(448, 176)
        Me.grdPhuTungThayThe.TabIndex = 4
        Me.grdPhuTungThayThe.TabStop = False
        Me.grdPhuTungThayThe.Text = "Danh sách phụ tùng thay thế"
        '
        'grdLichsuPTThayThe
        '
        Me.grdLichsuPTThayThe.AllowUserToAddRows = False
        Me.grdLichsuPTThayThe.AllowUserToDeleteRows = False
        Me.grdLichsuPTThayThe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLichsuPTThayThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLichsuPTThayThe.Location = New System.Drawing.Point(3, 16)
        Me.grdLichsuPTThayThe.Name = "grdLichsuPTThayThe"
        Me.grdLichsuPTThayThe.ReadOnly = True
        Me.grdLichsuPTThayThe.RowHeadersWidth = 20
        Me.grdLichsuPTThayThe.Size = New System.Drawing.Size(442, 157)
        Me.grdLichsuPTThayThe.TabIndex = 0
        '
        'grpDieulienchon
        '
        Me.grpDieulienchon.Controls.Add(Me.txtGiatri)
        Me.grpDieulienchon.Controls.Add(Me.rdchontheoten)
        Me.grpDieulienchon.Controls.Add(Me.rdChontheoma)
        Me.grpDieulienchon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDieulienchon.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDieulienchon.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieulienchon.Location = New System.Drawing.Point(3, 399)
        Me.grpDieulienchon.Name = "grpDieulienchon"
        Me.grpDieulienchon.Size = New System.Drawing.Size(247, 34)
        Me.grpDieulienchon.TabIndex = 89
        Me.grpDieulienchon.TabStop = False
        Me.grpDieulienchon.Text = "điều kiện chọn"
        '
        'txtGiatri
        '
        Me.txtGiatri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGiatri.ForeColor = System.Drawing.Color.Black
        Me.txtGiatri.Location = New System.Drawing.Point(251, 11)
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Size = New System.Drawing.Size(0, 21)
        Me.txtGiatri.TabIndex = 2
        '
        'rdchontheoten
        '
        Me.rdchontheoten.AutoSize = True
        Me.rdchontheoten.ForeColor = System.Drawing.Color.Black
        Me.rdchontheoten.Location = New System.Drawing.Point(131, 12)
        Me.rdchontheoten.Name = "rdchontheoten"
        Me.rdchontheoten.Size = New System.Drawing.Size(94, 17)
        Me.rdchontheoten.TabIndex = 1
        Me.rdchontheoten.Text = "Chọn theo tên"
        Me.rdchontheoten.UseVisualStyleBackColor = True
        '
        'rdChontheoma
        '
        Me.rdChontheoma.AutoSize = True
        Me.rdChontheoma.Checked = True
        Me.rdChontheoma.ForeColor = System.Drawing.Color.Black
        Me.rdChontheoma.Location = New System.Drawing.Point(6, 14)
        Me.rdChontheoma.Name = "rdChontheoma"
        Me.rdChontheoma.Size = New System.Drawing.Size(92, 17)
        Me.rdChontheoma.TabIndex = 0
        Me.rdChontheoma.TabStop = True
        Me.rdChontheoma.Text = "Chọn theo mã"
        Me.rdChontheoma.UseVisualStyleBackColor = True
        '
        'grpLichsuthietbi
        '
        Me.grpLichsuthietbi.Controls.Add(Me.grdLichsuthietbi)
        Me.grpLichsuthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLichsuthietbi.ForeColor = System.Drawing.Color.Maroon
        Me.grpLichsuthietbi.Location = New System.Drawing.Point(256, 35)
        Me.grpLichsuthietbi.Name = "grpLichsuthietbi"
        Me.grpLichsuthietbi.Size = New System.Drawing.Size(448, 176)
        Me.grpLichsuthietbi.TabIndex = 3
        Me.grpLichsuthietbi.TabStop = False
        Me.grpLichsuthietbi.Text = "Lịch sử thiết bị"
        '
        'grdLichsuthietbi
        '
        Me.grdLichsuthietbi.AllowUserToAddRows = False
        Me.grdLichsuthietbi.AllowUserToDeleteRows = False
        Me.grdLichsuthietbi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLichsuthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLichsuthietbi.Location = New System.Drawing.Point(3, 16)
        Me.grdLichsuthietbi.Name = "grdLichsuthietbi"
        Me.grdLichsuthietbi.ReadOnly = True
        Me.grdLichsuthietbi.RowHeadersWidth = 20
        Me.grdLichsuthietbi.Size = New System.Drawing.Size(442, 157)
        Me.grdLichsuthietbi.TabIndex = 0
        '
        'grpThietBi
        '
        Me.grpThietBi.Controls.Add(Me.tvHistory)
        Me.grpThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThietBi.ForeColor = System.Drawing.Color.Maroon
        Me.grpThietBi.Location = New System.Drawing.Point(3, 35)
        Me.grpThietBi.Name = "grpThietBi"
        Me.TableLayoutPanel4.SetRowSpan(Me.grpThietBi, 2)
        Me.grpThietBi.Size = New System.Drawing.Size(247, 358)
        Me.grpThietBi.TabIndex = 2
        Me.grpThietBi.TabStop = False
        Me.grpThietBi.Text = "Cấu thúc thiết bị"
        '
        'tvHistory
        '
        Me.tvHistory.AllowDrop = True
        Me.tvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvHistory.HideSelection = False
        Me.tvHistory.Location = New System.Drawing.Point(3, 16)
        Me.tvHistory.Name = "tvHistory"
        Me.tvHistory.Size = New System.Drawing.Size(241, 339)
        Me.tvHistory.TabIndex = 1
        '
        'Panel1
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.lblTuNgay1)
        Me.Panel1.Controls.Add(Me.txtBoPhanTT)
        Me.Panel1.Controls.Add(Me.dtpDenNgay1)
        Me.Panel1.Controls.Add(Me.lblMayTT)
        Me.Panel1.Controls.Add(Me.lblBoPhanTT)
        Me.Panel1.Controls.Add(Me.lblDenNgay1)
        Me.Panel1.Controls.Add(Me.dtpTuNgay1)
        Me.Panel1.Controls.Add(Me.txtMayTT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(701, 26)
        Me.Panel1.TabIndex = 96
        '
        'lblTuNgay1
        '
        Me.lblTuNgay1.AutoSize = True
        Me.lblTuNgay1.Location = New System.Drawing.Point(3, 7)
        Me.lblTuNgay1.Name = "lblTuNgay1"
        Me.lblTuNgay1.Size = New System.Drawing.Size(46, 13)
        Me.lblTuNgay1.TabIndex = 92
        Me.lblTuNgay1.Text = "Từ ngày"
        '
        'txtBoPhanTT
        '
        Me.txtBoPhanTT.BackColor = System.Drawing.Color.White
        Me.txtBoPhanTT.ErrorProviderControl = Nothing
        Me.txtBoPhanTT.FieldName = ""
        Me.txtBoPhanTT.IsNull = True
        Me.txtBoPhanTT.Location = New System.Drawing.Point(372, 3)
        Me.txtBoPhanTT.Name = "txtBoPhanTT"
        Me.txtBoPhanTT.ReadOnly = True
        Me.txtBoPhanTT.Size = New System.Drawing.Size(213, 20)
        Me.txtBoPhanTT.TabIndex = 87
        Me.txtBoPhanTT.TextTypeMode = Commons.TypeMode.None
        Me.txtBoPhanTT.Visible = False
        '
        'dtpDenNgay1
        '
        Me.dtpDenNgay1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNgay1.Location = New System.Drawing.Point(372, 3)
        Me.dtpDenNgay1.Name = "dtpDenNgay1"
        Me.dtpDenNgay1.Size = New System.Drawing.Size(137, 20)
        Me.dtpDenNgay1.TabIndex = 94
        '
        'lblMayTT
        '
        Me.lblMayTT.AutoSize = True
        Me.lblMayTT.Location = New System.Drawing.Point(3, 8)
        Me.lblMayTT.Name = "lblMayTT"
        Me.lblMayTT.Size = New System.Drawing.Size(68, 13)
        Me.lblMayTT.TabIndex = 84
        Me.lblMayTT.Text = "Máy thay thế"
        Me.lblMayTT.Visible = False
        '
        'lblBoPhanTT
        '
        Me.lblBoPhanTT.AutoSize = True
        Me.lblBoPhanTT.Location = New System.Drawing.Point(255, 6)
        Me.lblBoPhanTT.Name = "lblBoPhanTT"
        Me.lblBoPhanTT.Size = New System.Drawing.Size(88, 13)
        Me.lblBoPhanTT.TabIndex = 85
        Me.lblBoPhanTT.Text = "Bộ phận thay thế"
        Me.lblBoPhanTT.Visible = False
        '
        'lblDenNgay1
        '
        Me.lblDenNgay1.AutoSize = True
        Me.lblDenNgay1.Location = New System.Drawing.Point(255, 6)
        Me.lblDenNgay1.Name = "lblDenNgay1"
        Me.lblDenNgay1.Size = New System.Drawing.Size(53, 13)
        Me.lblDenNgay1.TabIndex = 93
        Me.lblDenNgay1.Text = "Đến ngày"
        '
        'dtpTuNgay1
        '
        Me.dtpTuNgay1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgay1.Location = New System.Drawing.Point(117, 2)
        Me.dtpTuNgay1.Name = "dtpTuNgay1"
        Me.dtpTuNgay1.Size = New System.Drawing.Size(132, 20)
        Me.dtpTuNgay1.TabIndex = 91
        '
        'txtMayTT
        '
        Me.txtMayTT.BackColor = System.Drawing.SystemColors.Window
        Me.txtMayTT.ErrorProviderControl = Nothing
        Me.txtMayTT.FieldName = ""
        Me.txtMayTT.IsNull = True
        Me.txtMayTT.Location = New System.Drawing.Point(117, 3)
        Me.txtMayTT.Name = "txtMayTT"
        Me.txtMayTT.ReadOnly = True
        Me.txtMayTT.Size = New System.Drawing.Size(132, 20)
        Me.txtMayTT.TabIndex = 86
        Me.txtMayTT.TextTypeMode = Commons.TypeMode.None
        Me.txtMayTT.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnXemPBT)
        Me.Panel2.Controls.Add(Me.BtnThoat6)
        Me.Panel2.Controls.Add(Me.btLichSuCauTrucTB)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(256, 399)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(448, 34)
        Me.Panel2.TabIndex = 97
        '
        'BtnXemPBT
        '
        Me.BtnXemPBT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXemPBT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXemPBT.ForeColor = System.Drawing.Color.Blue
        Me.BtnXemPBT.Location = New System.Drawing.Point(217, 6)
        Me.BtnXemPBT.Name = "BtnXemPBT"
        Me.BtnXemPBT.Size = New System.Drawing.Size(114, 25)
        Me.BtnXemPBT.TabIndex = 95
        Me.BtnXemPBT.Text = "Xem PBT"
        Me.BtnXemPBT.UseVisualStyleBackColor = True
        '
        'BtnThoat6
        '
        Me.BtnThoat6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat6.Location = New System.Drawing.Point(331, 6)
        Me.BtnThoat6.Name = "BtnThoat6"
        Me.BtnThoat6.Size = New System.Drawing.Size(114, 25)
        Me.BtnThoat6.TabIndex = 83
        Me.BtnThoat6.Text = "T&hoát"
        Me.BtnThoat6.UseVisualStyleBackColor = True
        '
        'btLichSuCauTrucTB
        '
        Me.btLichSuCauTrucTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btLichSuCauTrucTB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLichSuCauTrucTB.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btLichSuCauTrucTB.Location = New System.Drawing.Point(103, 6)
        Me.btLichSuCauTrucTB.Name = "btLichSuCauTrucTB"
        Me.btLichSuCauTrucTB.Size = New System.Drawing.Size(114, 25)
        Me.btLichSuCauTrucTB.TabIndex = 90
        Me.btLichSuCauTrucTB.Text = "In lịch sử"
        Me.btLichSuCauTrucTB.UseVisualStyleBackColor = True
        '
        'FrmLichSuThietBi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 436)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Name = "FrmLichSuThietBi"
        Me.Text = "Lịch sử thiết bị"
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.grdPhuTungThayThe.ResumeLayout(False)
        CType(Me.grdLichsuPTThayThe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDieulienchon.ResumeLayout(False)
        Me.grpDieulienchon.PerformLayout()
        Me.grpLichsuthietbi.ResumeLayout(False)
        CType(Me.grdLichsuthietbi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpThietBi.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdPhuTungThayThe As System.Windows.Forms.GroupBox
    Friend WithEvents grdLichsuPTThayThe As System.Windows.Forms.DataGridView
    Friend WithEvents grpDieulienchon As System.Windows.Forms.GroupBox
    Friend WithEvents txtGiatri As System.Windows.Forms.TextBox
    Friend WithEvents rdchontheoten As System.Windows.Forms.RadioButton
    Friend WithEvents rdChontheoma As System.Windows.Forms.RadioButton
    Friend WithEvents grpLichsuthietbi As System.Windows.Forms.GroupBox
    Friend WithEvents grdLichsuthietbi As System.Windows.Forms.DataGridView
    Friend WithEvents grpThietBi As System.Windows.Forms.GroupBox
    Friend WithEvents tvHistory As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTuNgay1 As System.Windows.Forms.Label
    Friend WithEvents txtBoPhanTT As Commons.utcTextBox
    Friend WithEvents dtpDenNgay1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMayTT As System.Windows.Forms.Label
    Friend WithEvents lblBoPhanTT As System.Windows.Forms.Label
    Friend WithEvents lblDenNgay1 As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMayTT As Commons.utcTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnXemPBT As System.Windows.Forms.Button
    Friend WithEvents BtnThoat6 As System.Windows.Forms.Button
    Friend WithEvents btLichSuCauTrucTB As System.Windows.Forms.Button
End Class
