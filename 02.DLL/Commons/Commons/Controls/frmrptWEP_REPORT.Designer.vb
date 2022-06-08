<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptWEP_REPORT
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTuan_DN = New System.Windows.Forms.TextBox()
        Me.lblDiadiem = New System.Windows.Forms.Label()
        Me.grpThoiGian = New System.Windows.Forms.GroupBox()
        Me.txtTuan_TN = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbNam = New System.Windows.Forms.Label()
        Me.cboNam = New Commons.UtcComboBox()
        Me.cboTuan = New Commons.UtcComboBox()
        Me.lblThietbi = New System.Windows.Forms.Label()
        Me.cboDiaDiem = New Commons.UtcComboBox()
        Me.cboThietbi3 = New Commons.UtcComboBox()
        Me.cboNhomthietbi3 = New Commons.UtcComboBox()
        Me.lblDayChuyenSXTB_CP = New System.Windows.Forms.Label()
        Me.cboLoaithietbi3 = New Commons.UtcComboBox()
        Me.lblNhomTB = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpThoiGian.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTuan_DN, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiadiem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpThoiGian, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThietbi, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDiaDiem, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboThietbi3, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhomthietbi3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDayChuyenSXTB_CP, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaithietbi3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhomTB, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(412, 384)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'txtTuan_DN
        '
        Me.txtTuan_DN.Location = New System.Drawing.Point(3, 155)
        Me.txtTuan_DN.Name = "txtTuan_DN"
        Me.txtTuan_DN.Size = New System.Drawing.Size(100, 21)
        Me.txtTuan_DN.TabIndex = 27
        Me.txtTuan_DN.Visible = False
        '
        'lblDiadiem
        '
        Me.lblDiadiem.AutoSize = True
        Me.lblDiadiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiadiem.Location = New System.Drawing.Point(3, 0)
        Me.lblDiadiem.Name = "lblDiadiem"
        Me.lblDiadiem.Size = New System.Drawing.Size(109, 25)
        Me.lblDiadiem.TabIndex = 13
        Me.lblDiadiem.Text = "Địa điểm"
        Me.lblDiadiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpThoiGian
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpThoiGian, 2)
        Me.grpThoiGian.Controls.Add(Me.txtTuan_TN)
        Me.grpThoiGian.Controls.Add(Me.TableLayoutPanel3)
        Me.grpThoiGian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThoiGian.Location = New System.Drawing.Point(3, 103)
        Me.grpThoiGian.Name = "grpThoiGian"
        Me.grpThoiGian.Size = New System.Drawing.Size(406, 46)
        Me.grpThoiGian.TabIndex = 25
        Me.grpThoiGian.TabStop = False
        Me.grpThoiGian.Text = "Thời gian"
        '
        'txtTuan_TN
        '
        Me.txtTuan_TN.Location = New System.Drawing.Point(3, 89)
        Me.txtTuan_TN.Name = "txtTuan_TN"
        Me.txtTuan_TN.Size = New System.Drawing.Size(100, 21)
        Me.txtTuan_TN.TabIndex = 26
        Me.txtTuan_TN.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lbNam, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboNam, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboTuan, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(400, 26)
        Me.TableLayoutPanel3.TabIndex = 21
        '
        'lbNam
        '
        Me.lbNam.AutoSize = True
        Me.lbNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbNam.Location = New System.Drawing.Point(3, 0)
        Me.lbNam.Name = "lbNam"
        Me.lbNam.Size = New System.Drawing.Size(59, 26)
        Me.lbNam.TabIndex = 19
        Me.lbNam.Text = "Năm"
        Me.lbNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNam
        '
        Me.cboNam.AssemblyName = ""
        Me.cboNam.BackColor = System.Drawing.Color.White
        Me.cboNam.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboNam.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboNam.ClassName = ""
        Me.cboNam.Display = ""
        Me.cboNam.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNam.ErrorProviderControl = Nothing
        Me.cboNam.FormattingEnabled = True
        Me.cboNam.IsAll = True
        Me.cboNam.isInputNull = False
        Me.cboNam.IsNew = False
        Me.cboNam.IsNull = True
        Me.cboNam.ItemAll = " < ALL > "
        Me.cboNam.ItemNew = "...New"
        Me.cboNam.Location = New System.Drawing.Point(68, 3)
        Me.cboNam.MethodName = ""
        Me.cboNam.Name = "cboNam"
        Me.cboNam.Param = ""
        Me.cboNam.Param2 = ""
        Me.cboNam.Size = New System.Drawing.Size(114, 21)
        Me.cboNam.StoreName = ""
        Me.cboNam.TabIndex = 18
        Me.cboNam.Table = Nothing
        Me.cboNam.TextReadonly = False
        Me.cboNam.Value = ""
        '
        'cboTuan
        '
        Me.cboTuan.AssemblyName = ""
        Me.cboTuan.BackColor = System.Drawing.Color.White
        Me.cboTuan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboTuan.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboTuan.ClassName = ""
        Me.cboTuan.Display = ""
        Me.cboTuan.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTuan.ErrorProviderControl = Nothing
        Me.cboTuan.FormattingEnabled = True
        Me.cboTuan.IsAll = True
        Me.cboTuan.isInputNull = False
        Me.cboTuan.IsNew = False
        Me.cboTuan.IsNull = True
        Me.cboTuan.ItemAll = " < ALL > "
        Me.cboTuan.ItemNew = "...New"
        Me.cboTuan.Location = New System.Drawing.Point(188, 3)
        Me.cboTuan.MethodName = ""
        Me.cboTuan.Name = "cboTuan"
        Me.cboTuan.Param = ""
        Me.cboTuan.Param2 = ""
        Me.cboTuan.Size = New System.Drawing.Size(209, 21)
        Me.cboTuan.StoreName = ""
        Me.cboTuan.TabIndex = 20
        Me.cboTuan.Table = Nothing
        Me.cboTuan.TextReadonly = False
        Me.cboTuan.Value = ""
        '
        'lblThietbi
        '
        Me.lblThietbi.AutoSize = True
        Me.lblThietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThietbi.Location = New System.Drawing.Point(3, 75)
        Me.lblThietbi.Name = "lblThietbi"
        Me.lblThietbi.Size = New System.Drawing.Size(109, 25)
        Me.lblThietbi.TabIndex = 23
        Me.lblThietbi.Text = "Thiết bị"
        Me.lblThietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDiaDiem
        '
        Me.cboDiaDiem.AssemblyName = ""
        Me.cboDiaDiem.BackColor = System.Drawing.Color.White
        Me.cboDiaDiem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboDiaDiem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboDiaDiem.ClassName = ""
        Me.cboDiaDiem.Display = ""
        Me.cboDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiaDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiaDiem.ErrorProviderControl = Nothing
        Me.cboDiaDiem.FormattingEnabled = True
        Me.cboDiaDiem.IsAll = True
        Me.cboDiaDiem.isInputNull = False
        Me.cboDiaDiem.IsNew = False
        Me.cboDiaDiem.IsNull = True
        Me.cboDiaDiem.ItemAll = " < ALL > "
        Me.cboDiaDiem.ItemNew = "...New"
        Me.cboDiaDiem.Location = New System.Drawing.Point(118, 3)
        Me.cboDiaDiem.MethodName = ""
        Me.cboDiaDiem.Name = "cboDiaDiem"
        Me.cboDiaDiem.Param = ""
        Me.cboDiaDiem.Param2 = ""
        Me.cboDiaDiem.Size = New System.Drawing.Size(291, 21)
        Me.cboDiaDiem.StoreName = ""
        Me.cboDiaDiem.TabIndex = 24
        Me.cboDiaDiem.Table = Nothing
        Me.cboDiaDiem.TextReadonly = False
        Me.cboDiaDiem.Value = ""
        '
        'cboThietbi3
        '
        Me.cboThietbi3.AssemblyName = ""
        Me.cboThietbi3.BackColor = System.Drawing.Color.White
        Me.cboThietbi3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboThietbi3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboThietbi3.ClassName = ""
        Me.cboThietbi3.Display = ""
        Me.cboThietbi3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboThietbi3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThietbi3.ErrorProviderControl = Nothing
        Me.cboThietbi3.FormattingEnabled = True
        Me.cboThietbi3.IsAll = True
        Me.cboThietbi3.isInputNull = False
        Me.cboThietbi3.IsNew = False
        Me.cboThietbi3.IsNull = True
        Me.cboThietbi3.ItemAll = " < ALL > "
        Me.cboThietbi3.ItemNew = "...New"
        Me.cboThietbi3.Location = New System.Drawing.Point(118, 78)
        Me.cboThietbi3.MethodName = ""
        Me.cboThietbi3.Name = "cboThietbi3"
        Me.cboThietbi3.Param = ""
        Me.cboThietbi3.Param2 = ""
        Me.cboThietbi3.Size = New System.Drawing.Size(291, 21)
        Me.cboThietbi3.StoreName = ""
        Me.cboThietbi3.TabIndex = 13
        Me.cboThietbi3.Table = Nothing
        Me.cboThietbi3.TextReadonly = False
        Me.cboThietbi3.Value = ""
        '
        'cboNhomthietbi3
        '
        Me.cboNhomthietbi3.AssemblyName = ""
        Me.cboNhomthietbi3.BackColor = System.Drawing.Color.White
        Me.cboNhomthietbi3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboNhomthietbi3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboNhomthietbi3.ClassName = ""
        Me.cboNhomthietbi3.Display = ""
        Me.cboNhomthietbi3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhomthietbi3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhomthietbi3.ErrorProviderControl = Nothing
        Me.cboNhomthietbi3.FormattingEnabled = True
        Me.cboNhomthietbi3.IsAll = True
        Me.cboNhomthietbi3.isInputNull = False
        Me.cboNhomthietbi3.IsNew = False
        Me.cboNhomthietbi3.IsNull = True
        Me.cboNhomthietbi3.ItemAll = " < ALL > "
        Me.cboNhomthietbi3.ItemNew = "...New"
        Me.cboNhomthietbi3.Location = New System.Drawing.Point(118, 53)
        Me.cboNhomthietbi3.MethodName = ""
        Me.cboNhomthietbi3.Name = "cboNhomthietbi3"
        Me.cboNhomthietbi3.Param = ""
        Me.cboNhomthietbi3.Param2 = ""
        Me.cboNhomthietbi3.Size = New System.Drawing.Size(291, 21)
        Me.cboNhomthietbi3.StoreName = ""
        Me.cboNhomthietbi3.TabIndex = 21
        Me.cboNhomthietbi3.Table = Nothing
        Me.cboNhomthietbi3.TextReadonly = False
        Me.cboNhomthietbi3.Value = ""
        '
        'lblDayChuyenSXTB_CP
        '
        Me.lblDayChuyenSXTB_CP.AutoSize = True
        Me.lblDayChuyenSXTB_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDayChuyenSXTB_CP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDayChuyenSXTB_CP.Location = New System.Drawing.Point(3, 25)
        Me.lblDayChuyenSXTB_CP.Name = "lblDayChuyenSXTB_CP"
        Me.lblDayChuyenSXTB_CP.Size = New System.Drawing.Size(109, 25)
        Me.lblDayChuyenSXTB_CP.TabIndex = 8
        Me.lblDayChuyenSXTB_CP.Text = "Dây chuyền sản xuất"
        Me.lblDayChuyenSXTB_CP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaithietbi3
        '
        Me.cboLoaithietbi3.AssemblyName = ""
        Me.cboLoaithietbi3.BackColor = System.Drawing.Color.White
        Me.cboLoaithietbi3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboLoaithietbi3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboLoaithietbi3.ClassName = ""
        Me.cboLoaithietbi3.Display = ""
        Me.cboLoaithietbi3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaithietbi3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaithietbi3.ErrorProviderControl = Nothing
        Me.cboLoaithietbi3.FormattingEnabled = True
        Me.cboLoaithietbi3.IsAll = True
        Me.cboLoaithietbi3.isInputNull = False
        Me.cboLoaithietbi3.IsNew = False
        Me.cboLoaithietbi3.IsNull = True
        Me.cboLoaithietbi3.ItemAll = " < ALL > "
        Me.cboLoaithietbi3.ItemNew = "...New"
        Me.cboLoaithietbi3.Location = New System.Drawing.Point(118, 28)
        Me.cboLoaithietbi3.MethodName = ""
        Me.cboLoaithietbi3.Name = "cboLoaithietbi3"
        Me.cboLoaithietbi3.Param = ""
        Me.cboLoaithietbi3.Param2 = ""
        Me.cboLoaithietbi3.Size = New System.Drawing.Size(291, 21)
        Me.cboLoaithietbi3.StoreName = ""
        Me.cboLoaithietbi3.TabIndex = 6
        Me.cboLoaithietbi3.Table = Nothing
        Me.cboLoaithietbi3.TextReadonly = False
        Me.cboLoaithietbi3.Value = ""
        '
        'lblNhomTB
        '
        Me.lblNhomTB.AutoSize = True
        Me.lblNhomTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhomTB.Location = New System.Drawing.Point(3, 50)
        Me.lblNhomTB.Name = "lblNhomTB"
        Me.lblNhomTB.Size = New System.Drawing.Size(109, 25)
        Me.lblNhomTB.TabIndex = 22
        Me.lblNhomTB.Text = "Nhóm TB"
        Me.lblNhomTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 353)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(406, 28)
        Me.TableLayoutPanel2.TabIndex = 28
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(316, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(87, 22)
        Me.btnThoat.TabIndex = 37
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(203, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 22)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptWEP_REPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptWEP_REPORT"
        Me.Size = New System.Drawing.Size(412, 384)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grpThoiGian.ResumeLayout(False)
        Me.grpThoiGian.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblThietbi As System.Windows.Forms.Label
    Friend WithEvents cboThietbi3 As Commons.UtcComboBox
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNhomthietbi3 As Commons.UtcComboBox
    Friend WithEvents lblDayChuyenSXTB_CP As System.Windows.Forms.Label
    Friend WithEvents cboLoaithietbi3 As Commons.UtcComboBox
    Friend WithEvents lblNhomTB As System.Windows.Forms.Label
    Friend WithEvents grpThoiGian As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbNam As System.Windows.Forms.Label
    Friend WithEvents cboNam As Commons.UtcComboBox
    Friend WithEvents cboTuan As Commons.UtcComboBox
    Friend WithEvents lblDiadiem As System.Windows.Forms.Label
    Friend WithEvents cboDiaDiem As Commons.UtcComboBox
    Friend WithEvents txtTuan_DN As System.Windows.Forms.TextBox
    Friend WithEvents txtTuan_TN As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
