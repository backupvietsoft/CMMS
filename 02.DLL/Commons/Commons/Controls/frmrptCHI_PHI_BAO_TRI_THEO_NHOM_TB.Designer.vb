<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptCHI_PHI_BAO_TRI_THEO_NHOM_TB
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
        Me.dtpDenNam_TKCP = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDenNam_TKCP = New System.Windows.Forms.Label()
        Me.dtpTuNam_TKCP = New System.Windows.Forms.DateTimePicker()
        Me.lblNhomTB_CP = New System.Windows.Forms.Label()
        Me.lblTuNam_TKCP = New System.Windows.Forms.Label()
        Me.cboNhomTB_CP = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDenNam_TKCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenNam_TKCP, 2)
        Me.dtpDenNam_TKCP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpDenNam_TKCP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNam_TKCP.Location = New System.Drawing.Point(223, 86)
        Me.dtpDenNam_TKCP.Name = "dtpDenNam_TKCP"
        Me.dtpDenNam_TKCP.Size = New System.Drawing.Size(391, 21)
        Me.dtpDenNam_TKCP.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 3)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(113, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 25)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Thống kê chi phí theo giai đoạn"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenNam_TKCP, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenNam_TKCP, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTuNam_TKCP, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhomTB_CP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuNam_TKCP, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhomTB_CP, 2, 1)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(727, 540)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(620, 503)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 22
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(510, 503)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'lblDenNam_TKCP
        '
        Me.lblDenNam_TKCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNam_TKCP.ForeColor = System.Drawing.Color.Black
        Me.lblDenNam_TKCP.Location = New System.Drawing.Point(113, 83)
        Me.lblDenNam_TKCP.Name = "lblDenNam_TKCP"
        Me.lblDenNam_TKCP.Size = New System.Drawing.Size(104, 25)
        Me.lblDenNam_TKCP.TabIndex = 16
        Me.lblDenNam_TKCP.Text = "Đến ngày:"
        Me.lblDenNam_TKCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTuNam_TKCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTuNam_TKCP, 2)
        Me.dtpTuNam_TKCP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpTuNam_TKCP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNam_TKCP.Location = New System.Drawing.Point(223, 61)
        Me.dtpTuNam_TKCP.Name = "dtpTuNam_TKCP"
        Me.dtpTuNam_TKCP.Size = New System.Drawing.Size(391, 21)
        Me.dtpTuNam_TKCP.TabIndex = 17
        '
        'lblNhomTB_CP
        '
        Me.lblNhomTB_CP.AutoSize = True
        Me.lblNhomTB_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhomTB_CP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNhomTB_CP.Location = New System.Drawing.Point(113, 8)
        Me.lblNhomTB_CP.Name = "lblNhomTB_CP"
        Me.lblNhomTB_CP.Size = New System.Drawing.Size(104, 25)
        Me.lblNhomTB_CP.TabIndex = 10
        Me.lblNhomTB_CP.Text = "Nhóm thiết bị"
        Me.lblNhomTB_CP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTuNam_TKCP
        '
        Me.lblTuNam_TKCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNam_TKCP.ForeColor = System.Drawing.Color.Black
        Me.lblTuNam_TKCP.Location = New System.Drawing.Point(113, 58)
        Me.lblTuNam_TKCP.Name = "lblTuNam_TKCP"
        Me.lblTuNam_TKCP.Size = New System.Drawing.Size(104, 25)
        Me.lblTuNam_TKCP.TabIndex = 15
        Me.lblTuNam_TKCP.Text = "Từ ngày:"
        Me.lblTuNam_TKCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhomTB_CP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhomTB_CP, 2)
        Me.cboNhomTB_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhomTB_CP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhomTB_CP.FormattingEnabled = True
        Me.cboNhomTB_CP.Location = New System.Drawing.Point(223, 11)
        Me.cboNhomTB_CP.Name = "cboNhomTB_CP"
        Me.cboNhomTB_CP.Size = New System.Drawing.Size(391, 21)
        Me.cboNhomTB_CP.TabIndex = 21
        '
        'frmrptCHI_PHI_BAO_TRI_THEO_NHOM_TB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
        Me.Size = New System.Drawing.Size(727, 540)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtpDenNam_TKCP As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDenNam_TKCP As System.Windows.Forms.Label
    Friend WithEvents dtpTuNam_TKCP As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNhomTB_CP As System.Windows.Forms.Label
    Friend WithEvents lblTuNam_TKCP As System.Windows.Forms.Label
    Friend WithEvents cboNhomTB_CP As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
