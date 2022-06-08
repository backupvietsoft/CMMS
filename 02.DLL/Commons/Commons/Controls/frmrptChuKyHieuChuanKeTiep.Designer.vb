<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptChuKyHieuChuanKeTiep
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.cboDiaDiem = New Commons.UtcComboBox()
        Me.cboThietbi3 = New Commons.UtcComboBox()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cboNhomthietbi3 = New Commons.UtcComboBox()
        Me.lblDayChuyenSXTB_CP = New System.Windows.Forms.Label()
        Me.cboLoaithietbi3 = New Commons.UtcComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDiadiem = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(113, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 25)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Thiết bị"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDiaDiem, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboThietbi3, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhomthietbi3, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDayChuyenSXTB_CP, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaithietbi3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiadiem, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(689, 588)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(582, 551)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 27
        Me.btnThoat.Text = "Thoát"
        '
        'cboDiaDiem
        '
        Me.cboDiaDiem.AssemblyName = ""
        Me.cboDiaDiem.BackColor = System.Drawing.Color.White
        Me.cboDiaDiem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboDiaDiem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboDiaDiem.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDiaDiem, 2)
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
        Me.cboDiaDiem.Location = New System.Drawing.Point(223, 11)
        Me.cboDiaDiem.MethodName = ""
        Me.cboDiaDiem.Name = "cboDiaDiem"
        Me.cboDiaDiem.Param = ""
        Me.cboDiaDiem.Param2 = ""
        Me.cboDiaDiem.Size = New System.Drawing.Size(353, 21)
        Me.cboDiaDiem.StoreName = ""
        Me.cboDiaDiem.TabIndex = 25
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboThietbi3, 2)
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
        Me.cboThietbi3.Location = New System.Drawing.Point(223, 86)
        Me.cboThietbi3.MethodName = ""
        Me.cboThietbi3.Name = "cboThietbi3"
        Me.cboThietbi3.Param = ""
        Me.cboThietbi3.Param2 = ""
        Me.cboThietbi3.Size = New System.Drawing.Size(353, 21)
        Me.cboThietbi3.StoreName = ""
        Me.cboThietbi3.TabIndex = 13
        Me.cboThietbi3.Table = Nothing
        Me.cboThietbi3.TextReadonly = False
        Me.cboThietbi3.Value = ""
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(472, 551)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'cboNhomthietbi3
        '
        Me.cboNhomthietbi3.AssemblyName = ""
        Me.cboNhomthietbi3.BackColor = System.Drawing.Color.White
        Me.cboNhomthietbi3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboNhomthietbi3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboNhomthietbi3.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhomthietbi3, 2)
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
        Me.cboNhomthietbi3.Location = New System.Drawing.Point(223, 61)
        Me.cboNhomthietbi3.MethodName = ""
        Me.cboNhomthietbi3.Name = "cboNhomthietbi3"
        Me.cboNhomthietbi3.Param = ""
        Me.cboNhomthietbi3.Param2 = ""
        Me.cboNhomthietbi3.Size = New System.Drawing.Size(353, 21)
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
        Me.lblDayChuyenSXTB_CP.Location = New System.Drawing.Point(113, 33)
        Me.lblDayChuyenSXTB_CP.Name = "lblDayChuyenSXTB_CP"
        Me.lblDayChuyenSXTB_CP.Size = New System.Drawing.Size(104, 25)
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboLoaithietbi3, 2)
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
        Me.cboLoaithietbi3.Location = New System.Drawing.Point(223, 36)
        Me.cboLoaithietbi3.MethodName = ""
        Me.cboLoaithietbi3.Name = "cboLoaithietbi3"
        Me.cboLoaithietbi3.Param = ""
        Me.cboLoaithietbi3.Param2 = ""
        Me.cboLoaithietbi3.Size = New System.Drawing.Size(353, 21)
        Me.cboLoaithietbi3.StoreName = ""
        Me.cboLoaithietbi3.TabIndex = 6
        Me.cboLoaithietbi3.Table = Nothing
        Me.cboLoaithietbi3.TextReadonly = False
        Me.cboLoaithietbi3.Value = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(113, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 25)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Nhóm TB"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiadiem
        '
        Me.lblDiadiem.AutoSize = True
        Me.lblDiadiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiadiem.Location = New System.Drawing.Point(113, 8)
        Me.lblDiadiem.Name = "lblDiadiem"
        Me.lblDiadiem.Size = New System.Drawing.Size(104, 25)
        Me.lblDiadiem.TabIndex = 26
        Me.lblDiadiem.Text = "Địa điểm"
        Me.lblDiadiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmrptChuKyHieuChuanKeTiep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptChuKyHieuChuanKeTiep"
        Me.Size = New System.Drawing.Size(689, 588)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboThietbi3 As Commons.UtcComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNhomthietbi3 As Commons.UtcComboBox
    Friend WithEvents lblDayChuyenSXTB_CP As System.Windows.Forms.Label
    Friend WithEvents cboLoaithietbi3 As Commons.UtcComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDiaDiem As Commons.UtcComboBox
    Friend WithEvents lblDiadiem As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
