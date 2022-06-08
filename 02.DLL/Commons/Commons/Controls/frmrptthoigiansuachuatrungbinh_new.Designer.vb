<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptthoigiansuachuatrungbinh_new
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
        Me.TableLayoutPanel19 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboInTheo = New System.Windows.Forms.ComboBox()
        Me.Lblbaocaotheo = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.lblTuQuy = New System.Windows.Forms.Label()
        Me.lblTuNam_MTBF = New System.Windows.Forms.Label()
        Me.Lbtuthang = New System.Windows.Forms.Label()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.lblDenQuy = New System.Windows.Forms.Label()
        Me.lbdenthang = New System.Windows.Forms.Label()
        Me.lblDenNam_MTBF = New System.Windows.Forms.Label()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.txtdenthang1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDenQuy = New System.Windows.Forms.MaskedTextBox()
        Me.txtDenNam_MTBF = New System.Windows.Forms.MaskedTextBox()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.txtttuthang = New System.Windows.Forms.MaskedTextBox()
        Me.txtTuQuy = New System.Windows.Forms.MaskedTextBox()
        Me.txtTuNam_MTBF = New System.Windows.Forms.MaskedTextBox()
        Me.lbaDayChuyen = New System.Windows.Forms.Label()
        Me.cbxDaychuyen = New System.Windows.Forms.ComboBox()
        Me.btnTheoMay = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTheoDC = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel19.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel19
        '
        Me.TableLayoutPanel19.ColumnCount = 2
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel19.Controls.Add(Me.cboInTheo, 1, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.Lblbaocaotheo, 0, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.Panel23, 0, 1)
        Me.TableLayoutPanel19.Controls.Add(Me.Panel25, 0, 2)
        Me.TableLayoutPanel19.Controls.Add(Me.Panel26, 1, 2)
        Me.TableLayoutPanel19.Controls.Add(Me.Panel24, 1, 1)
        Me.TableLayoutPanel19.Controls.Add(Me.lbaDayChuyen, 0, 3)
        Me.TableLayoutPanel19.Controls.Add(Me.cbxDaychuyen, 1, 3)
        Me.TableLayoutPanel19.Controls.Add(Me.btnTheoMay, 0, 4)
        Me.TableLayoutPanel19.Controls.Add(Me.btnTheoDC, 0, 5)
        Me.TableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel19.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel19.Name = "TableLayoutPanel19"
        Me.TableLayoutPanel19.RowCount = 7
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel19.Size = New System.Drawing.Size(550, 465)
        Me.TableLayoutPanel19.TabIndex = 30
        '
        'cboInTheo
        '
        Me.cboInTheo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboInTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInTheo.FormattingEnabled = True
        Me.cboInTheo.Items.AddRange(New Object() {"Tháng- Month", "Quý - Quarter", "Năm - Year"})
        Me.cboInTheo.Location = New System.Drawing.Point(123, 4)
        Me.cboInTheo.Name = "cboInTheo"
        Me.cboInTheo.Size = New System.Drawing.Size(424, 21)
        Me.cboInTheo.TabIndex = 13
        '
        'Lblbaocaotheo
        '
        Me.Lblbaocaotheo.AutoSize = True
        Me.Lblbaocaotheo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lblbaocaotheo.Location = New System.Drawing.Point(3, 0)
        Me.Lblbaocaotheo.Name = "Lblbaocaotheo"
        Me.Lblbaocaotheo.Size = New System.Drawing.Size(114, 28)
        Me.Lblbaocaotheo.TabIndex = 26
        Me.Lblbaocaotheo.Text = "Báo cáo theo"
        Me.Lblbaocaotheo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel23
        '
        Me.Panel23.Controls.Add(Me.lblTuQuy)
        Me.Panel23.Controls.Add(Me.lblTuNam_MTBF)
        Me.Panel23.Controls.Add(Me.Lbtuthang)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel23.Location = New System.Drawing.Point(3, 31)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(114, 22)
        Me.Panel23.TabIndex = 27
        '
        'lblTuQuy
        '
        Me.lblTuQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuQuy.Location = New System.Drawing.Point(0, 0)
        Me.lblTuQuy.Name = "lblTuQuy"
        Me.lblTuQuy.Size = New System.Drawing.Size(114, 22)
        Me.lblTuQuy.TabIndex = 14
        Me.lblTuQuy.Text = "Từ quý"
        Me.lblTuQuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTuQuy.Visible = False
        '
        'lblTuNam_MTBF
        '
        Me.lblTuNam_MTBF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNam_MTBF.Location = New System.Drawing.Point(0, 0)
        Me.lblTuNam_MTBF.Name = "lblTuNam_MTBF"
        Me.lblTuNam_MTBF.Size = New System.Drawing.Size(114, 22)
        Me.lblTuNam_MTBF.TabIndex = 16
        Me.lblTuNam_MTBF.Text = "Từ năm"
        Me.lblTuNam_MTBF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTuNam_MTBF.Visible = False
        '
        'Lbtuthang
        '
        Me.Lbtuthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbtuthang.Location = New System.Drawing.Point(0, 0)
        Me.Lbtuthang.Name = "Lbtuthang"
        Me.Lbtuthang.Size = New System.Drawing.Size(114, 22)
        Me.Lbtuthang.TabIndex = 22
        Me.Lbtuthang.Text = "Từ tháng"
        Me.Lbtuthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbtuthang.Visible = False
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.lblDenQuy)
        Me.Panel25.Controls.Add(Me.lbdenthang)
        Me.Panel25.Controls.Add(Me.lblDenNam_MTBF)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel25.Location = New System.Drawing.Point(3, 59)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(114, 22)
        Me.Panel25.TabIndex = 29
        '
        'lblDenQuy
        '
        Me.lblDenQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenQuy.Location = New System.Drawing.Point(0, 0)
        Me.lblDenQuy.Name = "lblDenQuy"
        Me.lblDenQuy.Size = New System.Drawing.Size(114, 22)
        Me.lblDenQuy.TabIndex = 17
        Me.lblDenQuy.Text = "Đến quý"
        Me.lblDenQuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDenQuy.Visible = False
        '
        'lbdenthang
        '
        Me.lbdenthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbdenthang.Location = New System.Drawing.Point(0, 0)
        Me.lbdenthang.Name = "lbdenthang"
        Me.lbdenthang.Size = New System.Drawing.Size(114, 22)
        Me.lbdenthang.TabIndex = 23
        Me.lbdenthang.Text = "Đến tháng"
        Me.lbdenthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbdenthang.Visible = False
        '
        'lblDenNam_MTBF
        '
        Me.lblDenNam_MTBF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNam_MTBF.Location = New System.Drawing.Point(0, 0)
        Me.lblDenNam_MTBF.Name = "lblDenNam_MTBF"
        Me.lblDenNam_MTBF.Size = New System.Drawing.Size(114, 22)
        Me.lblDenNam_MTBF.TabIndex = 15
        Me.lblDenNam_MTBF.Text = "Đến năm"
        Me.lblDenNam_MTBF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDenNam_MTBF.Visible = False
        '
        'Panel26
        '
        Me.Panel26.Controls.Add(Me.txtdenthang1)
        Me.Panel26.Controls.Add(Me.txtDenQuy)
        Me.Panel26.Controls.Add(Me.txtDenNam_MTBF)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel26.Location = New System.Drawing.Point(123, 59)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(424, 22)
        Me.Panel26.TabIndex = 30
        '
        'txtdenthang1
        '
        Me.txtdenthang1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtdenthang1.Location = New System.Drawing.Point(0, -41)
        Me.txtdenthang1.Mask = "00/0000"
        Me.txtdenthang1.Name = "txtdenthang1"
        Me.txtdenthang1.Size = New System.Drawing.Size(424, 21)
        Me.txtdenthang1.TabIndex = 25
        '
        'txtDenQuy
        '
        Me.txtDenQuy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDenQuy.Location = New System.Drawing.Point(0, -20)
        Me.txtDenQuy.Mask = "0/0000"
        Me.txtDenQuy.Name = "txtDenQuy"
        Me.txtDenQuy.Size = New System.Drawing.Size(424, 21)
        Me.txtDenQuy.TabIndex = 18
        Me.txtDenQuy.Visible = False
        '
        'txtDenNam_MTBF
        '
        Me.txtDenNam_MTBF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDenNam_MTBF.Location = New System.Drawing.Point(0, 1)
        Me.txtDenNam_MTBF.Mask = "0000"
        Me.txtDenNam_MTBF.Name = "txtDenNam_MTBF"
        Me.txtDenNam_MTBF.Size = New System.Drawing.Size(424, 21)
        Me.txtDenNam_MTBF.TabIndex = 21
        Me.txtDenNam_MTBF.Visible = False
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.txtttuthang)
        Me.Panel24.Controls.Add(Me.txtTuQuy)
        Me.Panel24.Controls.Add(Me.txtTuNam_MTBF)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel24.Location = New System.Drawing.Point(123, 31)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(424, 22)
        Me.Panel24.TabIndex = 28
        '
        'txtttuthang
        '
        Me.txtttuthang.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtttuthang.Location = New System.Drawing.Point(0, -41)
        Me.txtttuthang.Mask = "00/0000"
        Me.txtttuthang.Name = "txtttuthang"
        Me.txtttuthang.Size = New System.Drawing.Size(424, 21)
        Me.txtttuthang.TabIndex = 24
        '
        'txtTuQuy
        '
        Me.txtTuQuy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTuQuy.Location = New System.Drawing.Point(0, -20)
        Me.txtTuQuy.Mask = "0/0000"
        Me.txtTuQuy.Name = "txtTuQuy"
        Me.txtTuQuy.Size = New System.Drawing.Size(424, 21)
        Me.txtTuQuy.TabIndex = 20
        Me.txtTuQuy.Visible = False
        '
        'txtTuNam_MTBF
        '
        Me.txtTuNam_MTBF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTuNam_MTBF.Location = New System.Drawing.Point(0, 1)
        Me.txtTuNam_MTBF.Mask = "0000"
        Me.txtTuNam_MTBF.Name = "txtTuNam_MTBF"
        Me.txtTuNam_MTBF.Size = New System.Drawing.Size(424, 21)
        Me.txtTuNam_MTBF.TabIndex = 19
        Me.txtTuNam_MTBF.Visible = False
        '
        'lbaDayChuyen
        '
        Me.lbaDayChuyen.AutoSize = True
        Me.lbaDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDayChuyen.Location = New System.Drawing.Point(3, 84)
        Me.lbaDayChuyen.Name = "lbaDayChuyen"
        Me.lbaDayChuyen.Size = New System.Drawing.Size(114, 26)
        Me.lbaDayChuyen.TabIndex = 31
        Me.lbaDayChuyen.Text = "Day chuyen "
        Me.lbaDayChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxDaychuyen
        '
        Me.cbxDaychuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxDaychuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDaychuyen.FormattingEnabled = True
        Me.cbxDaychuyen.Location = New System.Drawing.Point(123, 87)
        Me.cbxDaychuyen.Name = "cbxDaychuyen"
        Me.cbxDaychuyen.Size = New System.Drawing.Size(424, 21)
        Me.cbxDaychuyen.TabIndex = 32
        '
        'btnTheoMay
        '
        Me.TableLayoutPanel19.SetColumnSpan(Me.btnTheoMay, 2)
        Me.btnTheoMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTheoMay.Location = New System.Drawing.Point(3, 113)
        Me.btnTheoMay.Name = "btnTheoMay"
        Me.btnTheoMay.Size = New System.Drawing.Size(544, 29)
        Me.btnTheoMay.TabIndex = 11
        Me.btnTheoMay.Text = "Theo máy"
        '
        'btnTheoDC
        '
        Me.TableLayoutPanel19.SetColumnSpan(Me.btnTheoDC, 2)
        Me.btnTheoDC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTheoDC.Location = New System.Drawing.Point(3, 148)
        Me.btnTheoDC.Name = "btnTheoDC"
        Me.btnTheoDC.Size = New System.Drawing.Size(544, 28)
        Me.btnTheoDC.TabIndex = 12
        Me.btnTheoDC.Text = "Theo dây Chuyền"
        '
        'frmrptthoigiansuachuatrungbinh_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel19)
        Me.Name = "frmrptthoigiansuachuatrungbinh_new"
        Me.Size = New System.Drawing.Size(550, 465)
        Me.TableLayoutPanel19.ResumeLayout(False)
        Me.TableLayoutPanel19.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel19 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboInTheo As System.Windows.Forms.ComboBox
    Friend WithEvents Lblbaocaotheo As System.Windows.Forms.Label
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents lblTuQuy As System.Windows.Forms.Label
    Friend WithEvents lblTuNam_MTBF As System.Windows.Forms.Label
    Friend WithEvents Lbtuthang As System.Windows.Forms.Label
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents lblDenQuy As System.Windows.Forms.Label
    Friend WithEvents lbdenthang As System.Windows.Forms.Label
    Friend WithEvents lblDenNam_MTBF As System.Windows.Forms.Label
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents txtdenthang1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDenQuy As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDenNam_MTBF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents txtttuthang As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTuQuy As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTuNam_MTBF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaDayChuyen As System.Windows.Forms.Label
    Friend WithEvents cbxDaychuyen As System.Windows.Forms.ComboBox
    Friend WithEvents btnTheoMay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTheoDC As DevExpress.XtraEditors.SimpleButton

End Class
