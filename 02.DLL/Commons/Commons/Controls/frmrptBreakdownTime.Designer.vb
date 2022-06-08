<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBreakdownTime
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
        Me.lblTG_TuNam = New System.Windows.Forms.Label()
        Me.TableLayoutPanel18 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTG_LoaiTB = New System.Windows.Forms.Label()
        Me.dtpTu = New System.Windows.Forms.DateTimePicker()
        Me.lblTG_DenNam = New System.Windows.Forms.Label()
        Me.dtpDen = New System.Windows.Forms.DateTimePicker()
        Me.cboTG_LoaiTB = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel18.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTG_TuNam
        '
        Me.lblTG_TuNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_TuNam.Location = New System.Drawing.Point(113, 8)
        Me.lblTG_TuNam.Name = "lblTG_TuNam"
        Me.lblTG_TuNam.Size = New System.Drawing.Size(104, 25)
        Me.lblTG_TuNam.TabIndex = 0
        Me.lblTG_TuNam.Text = "Từ năm:"
        Me.lblTG_TuNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel18
        '
        Me.TableLayoutPanel18.ColumnCount = 5
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel18.Controls.Add(Me.btnThoat, 4, 5)
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_TuNam, 1, 1)
        Me.TableLayoutPanel18.Controls.Add(Me.btnThucHien, 3, 5)
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_LoaiTB, 1, 3)
        Me.TableLayoutPanel18.Controls.Add(Me.dtpTu, 2, 1)
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_DenNam, 1, 2)
        Me.TableLayoutPanel18.Controls.Add(Me.dtpDen, 2, 2)
        Me.TableLayoutPanel18.Controls.Add(Me.cboTG_LoaiTB, 2, 3)
        Me.TableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel18.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel18.Name = "TableLayoutPanel18"
        Me.TableLayoutPanel18.RowCount = 7
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel18.Size = New System.Drawing.Size(503, 404)
        Me.TableLayoutPanel18.TabIndex = 13
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(396, 367)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 21
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(286, 367)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"
        '
        'lblTG_LoaiTB
        '
        Me.lblTG_LoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_LoaiTB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTG_LoaiTB.Location = New System.Drawing.Point(113, 58)
        Me.lblTG_LoaiTB.Name = "lblTG_LoaiTB"
        Me.lblTG_LoaiTB.Size = New System.Drawing.Size(104, 25)
        Me.lblTG_LoaiTB.TabIndex = 10
        Me.lblTG_LoaiTB.Text = "Loại thiết bị"
        Me.lblTG_LoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTG_LoaiTB.Visible = False
        '
        'dtpTu
        '
        Me.TableLayoutPanel18.SetColumnSpan(Me.dtpTu, 2)
        Me.dtpTu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTu.Location = New System.Drawing.Point(223, 11)
        Me.dtpTu.Name = "dtpTu"
        Me.dtpTu.Size = New System.Drawing.Size(167, 21)
        Me.dtpTu.TabIndex = 4
        '
        'lblTG_DenNam
        '
        Me.lblTG_DenNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_DenNam.Location = New System.Drawing.Point(113, 33)
        Me.lblTG_DenNam.Name = "lblTG_DenNam"
        Me.lblTG_DenNam.Size = New System.Drawing.Size(104, 25)
        Me.lblTG_DenNam.TabIndex = 1
        Me.lblTG_DenNam.Text = "Đến năm:"
        Me.lblTG_DenNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDen
        '
        Me.TableLayoutPanel18.SetColumnSpan(Me.dtpDen, 2)
        Me.dtpDen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDen.Location = New System.Drawing.Point(223, 36)
        Me.dtpDen.Name = "dtpDen"
        Me.dtpDen.Size = New System.Drawing.Size(167, 21)
        Me.dtpDen.TabIndex = 5
        '
        'cboTG_LoaiTB
        '
        Me.TableLayoutPanel18.SetColumnSpan(Me.cboTG_LoaiTB, 2)
        Me.cboTG_LoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTG_LoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTG_LoaiTB.FormattingEnabled = True
        Me.cboTG_LoaiTB.Location = New System.Drawing.Point(223, 61)
        Me.cboTG_LoaiTB.Name = "cboTG_LoaiTB"
        Me.cboTG_LoaiTB.Size = New System.Drawing.Size(167, 21)
        Me.cboTG_LoaiTB.TabIndex = 20
        Me.cboTG_LoaiTB.Visible = False
        '
        'frmrptBreakdownTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel18)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBreakdownTime"
        Me.Size = New System.Drawing.Size(503, 404)
        Me.TableLayoutPanel18.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTG_TuNam As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel18 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTG_LoaiTB As System.Windows.Forms.Label
    Friend WithEvents dtpTu As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTG_DenNam As System.Windows.Forms.Label
    Friend WithEvents dtpDen As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTG_LoaiTB As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
