<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBIEU_DO_MAIN_HOUR
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
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.cbBPCP = New System.Windows.Forms.ComboBox
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.lblBPCP = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDenngay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenngay, 2)
        Me.dtpDenngay.CustomFormat = "MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(303, 3)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(237, 20)
        Me.dtpDenngay.TabIndex = 8
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(98, 3)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(136, 20)
        Me.dtpTungay.TabIndex = 9
        '
        'cbBPCP
        '
        Me.cbBPCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBPCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbBPCP, 4)
        Me.cbBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbBPCP.FormattingEnabled = True
        Me.cbBPCP.Location = New System.Drawing.Point(98, 30)
        Me.cbBPCP.Name = "cbBPCP"
        Me.cbBPCP.Size = New System.Drawing.Size(442, 21)
        Me.cbBPCP.TabIndex = 7
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(240, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(57, 27)
        Me.lblDenngay.TabIndex = 4
        Me.lblDenngay.Text = "Đến tháng"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(3, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(89, 27)
        Me.lblTungay.TabIndex = 5
        Me.lblTungay.Text = "Từ tháng"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBPCP
        '
        Me.lblBPCP.AutoSize = True
        Me.lblBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBPCP.Location = New System.Drawing.Point(3, 27)
        Me.lblBPCP.Name = "lblBPCP"
        Me.lblBPCP.Size = New System.Drawing.Size(89, 26)
        Me.lblBPCP.TabIndex = 6
        Me.lblBPCP.Text = "Bộ phận chịu phí"
        Me.lblBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblBPCP, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbBPCP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(543, 423)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(342, 396)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = Global.Commons.My.Resources.Resources.Thoat
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(445, 396)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(88, 24)
        Me.btnThoat.TabIndex = 17
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptBIEU_DO_MAIN_HOUR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptBIEU_DO_MAIN_HOUR"
        Me.Size = New System.Drawing.Size(543, 423)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbBPCP As System.Windows.Forms.ComboBox
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblBPCP As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
