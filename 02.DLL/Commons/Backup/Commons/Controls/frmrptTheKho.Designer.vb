<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTheKho
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptTheKho))
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.lbaKho = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.mDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.cbxVTPT = New System.Windows.Forms.ComboBox
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.lbaVTPT = New System.Windows.Forms.Label
        Me.mTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.cbxKho = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTuNgay.Location = New System.Drawing.Point(74, 18)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(46, 25)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaKho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaKho.Location = New System.Drawing.Point(74, 43)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(26, 28)
        Me.lbaKho.TabIndex = 2
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mDenNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxVTPT, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaVTPT, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxKho, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(462, 395)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 362)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(450, 29)
        Me.TableLayoutPanel2.TabIndex = 19
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(340, 0)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(110, 29)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(230, 0)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(110, 29)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'mDenNgay
        '
        Me.mDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mDenNgay.Location = New System.Drawing.Point(286, 21)
        Me.mDenNgay.Mask = "00/00/0000"
        Me.mDenNgay.Name = "mDenNgay"
        Me.mDenNgay.Size = New System.Drawing.Size(98, 20)
        Me.mDenNgay.TabIndex = 5
        Me.mDenNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mDenNgay.ValidatingType = GetType(Date)
        '
        'cbxVTPT
        '
        Me.cbxVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxVTPT.DropDownWidth = 200
        Me.cbxVTPT.FormattingEnabled = True
        Me.cbxVTPT.Location = New System.Drawing.Point(286, 46)
        Me.cbxVTPT.Name = "cbxVTPT"
        Me.cbxVTPT.Size = New System.Drawing.Size(98, 21)
        Me.cbxVTPT.TabIndex = 7
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaDenNgay.Location = New System.Drawing.Point(232, 18)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(30, 25)
        Me.lbaDenNgay.TabIndex = 6
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbaVTPT
        '
        Me.lbaVTPT.AutoSize = True
        Me.lbaVTPT.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaVTPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaVTPT.Location = New System.Drawing.Point(232, 43)
        Me.lbaVTPT.Name = "lbaVTPT"
        Me.lbaVTPT.Size = New System.Drawing.Size(44, 28)
        Me.lbaVTPT.TabIndex = 3
        Me.lbaVTPT.Text = "VT - PT"
        Me.lbaVTPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mTuNgay
        '
        Me.mTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mTuNgay.Location = New System.Drawing.Point(128, 21)
        Me.mTuNgay.Mask = "00/00/0000"
        Me.mTuNgay.Name = "mTuNgay"
        Me.mTuNgay.Size = New System.Drawing.Size(98, 20)
        Me.mTuNgay.TabIndex = 4
        Me.mTuNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mTuNgay.ValidatingType = GetType(Date)
        '
        'cbxKho
        '
        Me.cbxKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxKho.DropDownWidth = 150
        Me.cbxKho.FormattingEnabled = True
        Me.cbxKho.Location = New System.Drawing.Point(128, 46)
        Me.cbxKho.Name = "cbxKho"
        Me.cbxKho.Size = New System.Drawing.Size(98, 21)
        Me.cbxKho.TabIndex = 1
        '
        'frmrptTheKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptTheKho"
        Me.Size = New System.Drawing.Size(462, 395)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents mDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxVTPT As System.Windows.Forms.ComboBox
    Friend WithEvents mTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxKho As System.Windows.Forms.ComboBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaVTPT As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
