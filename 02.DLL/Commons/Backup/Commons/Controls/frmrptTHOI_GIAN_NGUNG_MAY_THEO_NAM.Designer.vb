<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM))
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel18 = New System.Windows.Forms.TableLayoutPanel
        Me.lblTG_TuNam = New System.Windows.Forms.Label
        Me.lblTG_LoaiTB = New System.Windows.Forms.Label
        Me.dtpTu = New System.Windows.Forms.DateTimePicker
        Me.lblTG_DenNam = New System.Windows.Forms.Label
        Me.dtpDen = New System.Windows.Forms.DateTimePicker
        Me.cboTG_LoaiTB = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TableLayoutPanel18.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(213, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel18
        '
        Me.TableLayoutPanel18.ColumnCount = 2
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_TuNam, 0, 0)
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_LoaiTB, 0, 2)
        Me.TableLayoutPanel18.Controls.Add(Me.dtpTu, 1, 0)
        Me.TableLayoutPanel18.Controls.Add(Me.lblTG_DenNam, 0, 1)
        Me.TableLayoutPanel18.Controls.Add(Me.dtpDen, 1, 1)
        Me.TableLayoutPanel18.Controls.Add(Me.cboTG_LoaiTB, 1, 2)
        Me.TableLayoutPanel18.Controls.Add(Me.TableLayoutPanel1, 0, 4)
        Me.TableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel18.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel18.Name = "TableLayoutPanel18"
        Me.TableLayoutPanel18.RowCount = 5
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel18.Size = New System.Drawing.Size(419, 391)
        Me.TableLayoutPanel18.TabIndex = 12
        '
        'lblTG_TuNam
        '
        Me.lblTG_TuNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_TuNam.Location = New System.Drawing.Point(3, 0)
        Me.lblTG_TuNam.Name = "lblTG_TuNam"
        Me.lblTG_TuNam.Size = New System.Drawing.Size(114, 28)
        Me.lblTG_TuNam.TabIndex = 0
        Me.lblTG_TuNam.Text = "Từ năm:"
        Me.lblTG_TuNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTG_LoaiTB
        '
        Me.lblTG_LoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_LoaiTB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTG_LoaiTB.Location = New System.Drawing.Point(3, 56)
        Me.lblTG_LoaiTB.Name = "lblTG_LoaiTB"
        Me.lblTG_LoaiTB.Size = New System.Drawing.Size(114, 28)
        Me.lblTG_LoaiTB.TabIndex = 10
        Me.lblTG_LoaiTB.Text = "Loại thiết bị"
        Me.lblTG_LoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTu
        '
        Me.dtpTu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTu.Location = New System.Drawing.Point(123, 5)
        Me.dtpTu.Name = "dtpTu"
        Me.dtpTu.Size = New System.Drawing.Size(293, 20)
        Me.dtpTu.TabIndex = 4
        '
        'lblTG_DenNam
        '
        Me.lblTG_DenNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTG_DenNam.Location = New System.Drawing.Point(3, 28)
        Me.lblTG_DenNam.Name = "lblTG_DenNam"
        Me.lblTG_DenNam.Size = New System.Drawing.Size(114, 28)
        Me.lblTG_DenNam.TabIndex = 1
        Me.lblTG_DenNam.Text = "Đến năm:"
        Me.lblTG_DenNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDen
        '
        Me.dtpDen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDen.Location = New System.Drawing.Point(123, 33)
        Me.dtpDen.Name = "dtpDen"
        Me.dtpDen.Size = New System.Drawing.Size(293, 20)
        Me.dtpDen.TabIndex = 5
        '
        'cboTG_LoaiTB
        '
        Me.cboTG_LoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTG_LoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTG_LoaiTB.FormattingEnabled = True
        Me.cboTG_LoaiTB.Location = New System.Drawing.Point(123, 59)
        Me.cboTG_LoaiTB.Name = "cboTG_LoaiTB"
        Me.cboTG_LoaiTB.Size = New System.Drawing.Size(293, 21)
        Me.cboTG_LoaiTB.TabIndex = 20
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel18.SetColumnSpan(Me.TableLayoutPanel1, 2)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 359)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(413, 29)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(316, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel18)
        Me.Name = "frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
        Me.Size = New System.Drawing.Size(419, 391)
        Me.TableLayoutPanel18.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel18 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTG_TuNam As System.Windows.Forms.Label
    Friend WithEvents lblTG_LoaiTB As System.Windows.Forms.Label
    Friend WithEvents dtpTu As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTG_DenNam As System.Windows.Forms.Label
    Friend WithEvents dtpDen As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTG_LoaiTB As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
