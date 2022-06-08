<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBIEU_DO_CHI_PHI_MAINT_COST
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptBIEU_DO_CHI_PHI_MAINT_COST))
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.cbBPCP = New System.Windows.Forms.ComboBox
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.lblBPCP = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDenngay
        '
        Me.dtpDenngay.CustomFormat = "MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(336, 3)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(173, 20)
        Me.dtpDenngay.TabIndex = 8
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(98, 3)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(173, 20)
        Me.dtpTungay.TabIndex = 9
        '
        'cbBPCP
        '
        Me.cbBPCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBPCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbBPCP, 3)
        Me.cbBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbBPCP.FormattingEnabled = True
        Me.cbBPCP.Location = New System.Drawing.Point(98, 30)
        Me.cbBPCP.Name = "cbBPCP"
        Me.cbBPCP.Size = New System.Drawing.Size(411, 21)
        Me.cbBPCP.TabIndex = 7
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(277, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(53, 27)
        Me.lblDenngay.TabIndex = 4
        Me.lblDenngay.Text = "Đến ngày"
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
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBPCP
        '
        Me.lblBPCP.AutoSize = True
        Me.lblBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBPCP.Location = New System.Drawing.Point(3, 27)
        Me.lblBPCP.Name = "lblBPCP"
        Me.lblBPCP.Size = New System.Drawing.Size(89, 28)
        Me.lblBPCP.TabIndex = 6
        Me.lblBPCP.Text = "Bộ phận chịu phí"
        Me.lblBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbBPCP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBPCP, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(512, 413)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 381)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(506, 29)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(409, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 17
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Image = CType(resources.GetObject("btnThucHien.Image"), System.Drawing.Image)
        Me.btnThucHien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.Location = New System.Drawing.Point(306, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'frmrptBIEU_DO_CHI_PHI_MAINT_COST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptBIEU_DO_CHI_PHI_MAINT_COST"
        Me.Size = New System.Drawing.Size(512, 413)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
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
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
