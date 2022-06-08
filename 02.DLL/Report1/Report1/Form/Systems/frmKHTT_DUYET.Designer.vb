<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_DUYET
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
        Me.btnDuyet = New DevExpress.XtraEditors.SimpleButton
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.lbNam = New System.Windows.Forms.Label
        Me.cbKHNam = New System.Windows.Forms.ComboBox
        Me.lbThang = New System.Windows.Forms.Label
        Me.cbKHThang = New System.Windows.Forms.ComboBox
        Me.lbDiaDiem = New System.Windows.Forms.Label
        Me.cbDiaDiem = New System.Windows.Forms.ComboBox
        Me.lbLoai = New System.Windows.Forms.Label
        Me.cbLoaiKH = New System.Windows.Forms.ComboBox
        Me.blTitleDuyet = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnDuyet
        '
        Me.btnDuyet.Location = New System.Drawing.Point(8, 196)
        Me.btnDuyet.Name = "btnDuyet"
        Me.btnDuyet.Size = New System.Drawing.Size(75, 23)
        Me.btnDuyet.TabIndex = 0
        Me.btnDuyet.Text = "Duyệt"

        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(90, 196)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Thoát"

        '
        'lbNam
        '
        Me.lbNam.AutoSize = True
        Me.lbNam.Location = New System.Drawing.Point(14, 86)
        Me.lbNam.Name = "lbNam"
        Me.lbNam.Size = New System.Drawing.Size(29, 13)
        Me.lbNam.TabIndex = 2
        Me.lbNam.Text = "Năm"
        '
        'cbKHNam
        '
        Me.cbKHNam.FormattingEnabled = True
        Me.cbKHNam.Location = New System.Drawing.Point(113, 78)
        Me.cbKHNam.Name = "cbKHNam"
        Me.cbKHNam.Size = New System.Drawing.Size(128, 21)
        Me.cbKHNam.TabIndex = 3
        '
        'lbThang
        '
        Me.lbThang.AutoSize = True
        Me.lbThang.Location = New System.Drawing.Point(274, 86)
        Me.lbThang.Name = "lbThang"
        Me.lbThang.Size = New System.Drawing.Size(38, 13)
        Me.lbThang.TabIndex = 4
        Me.lbThang.Text = "Tháng"
        '
        'cbKHThang
        '
        Me.cbKHThang.FormattingEnabled = True
        Me.cbKHThang.Location = New System.Drawing.Point(354, 78)
        Me.cbKHThang.Name = "cbKHThang"
        Me.cbKHThang.Size = New System.Drawing.Size(104, 21)
        Me.cbKHThang.TabIndex = 5
        '
        'lbDiaDiem
        '
        Me.lbDiaDiem.AutoSize = True
        Me.lbDiaDiem.Location = New System.Drawing.Point(14, 129)
        Me.lbDiaDiem.Name = "lbDiaDiem"
        Me.lbDiaDiem.Size = New System.Drawing.Size(49, 13)
        Me.lbDiaDiem.TabIndex = 6
        Me.lbDiaDiem.Text = "Địa điểm"
        '
        'cbDiaDiem
        '
        Me.cbDiaDiem.FormattingEnabled = True
        Me.cbDiaDiem.Location = New System.Drawing.Point(113, 120)
        Me.cbDiaDiem.Name = "cbDiaDiem"
        Me.cbDiaDiem.Size = New System.Drawing.Size(345, 21)
        Me.cbDiaDiem.TabIndex = 7
        '
        'lbLoai
        '
        Me.lbLoai.AutoSize = True
        Me.lbLoai.Location = New System.Drawing.Point(14, 51)
        Me.lbLoai.Name = "lbLoai"
        Me.lbLoai.Size = New System.Drawing.Size(75, 13)
        Me.lbLoai.TabIndex = 8
        Me.lbLoai.Text = "Loại kế hoạch"
        '
        'cbLoaiKH
        '
        Me.cbLoaiKH.FormattingEnabled = True
        Me.cbLoaiKH.Location = New System.Drawing.Point(113, 43)
        Me.cbLoaiKH.Name = "cbLoaiKH"
        Me.cbLoaiKH.Size = New System.Drawing.Size(345, 21)
        Me.cbLoaiKH.TabIndex = 9
        '
        'blTitleDuyet
        '
        Me.blTitleDuyet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blTitleDuyet.Location = New System.Drawing.Point(4, 9)
        Me.blTitleDuyet.Name = "blTitleDuyet"
        Me.blTitleDuyet.Size = New System.Drawing.Size(454, 23)
        Me.blTitleDuyet.TabIndex = 10
        Me.blTitleDuyet.Text = "DUYỆT KẾ HOẠCH BẢO TRÌ"
        Me.blTitleDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmKHTT_DUYET
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 226)
        Me.Controls.Add(Me.blTitleDuyet)
        Me.Controls.Add(Me.cbLoaiKH)
        Me.Controls.Add(Me.lbLoai)
        Me.Controls.Add(Me.cbDiaDiem)
        Me.Controls.Add(Me.lbDiaDiem)
        Me.Controls.Add(Me.cbKHThang)
        Me.Controls.Add(Me.lbThang)
        Me.Controls.Add(Me.cbKHNam)
        Me.Controls.Add(Me.lbNam)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDuyet)
        Me.Name = "frmKHTT_DUYET"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKHTT_DUYET"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDuyet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbNam As System.Windows.Forms.Label
    Friend WithEvents cbKHNam As System.Windows.Forms.ComboBox
    Friend WithEvents lbThang As System.Windows.Forms.Label
    Friend WithEvents cbKHThang As System.Windows.Forms.ComboBox
    Friend WithEvents lbDiaDiem As System.Windows.Forms.Label
    Friend WithEvents cbDiaDiem As System.Windows.Forms.ComboBox
    Friend WithEvents lbLoai As System.Windows.Forms.Label
    Friend WithEvents cbLoaiKH As System.Windows.Forms.ComboBox
    Friend WithEvents blTitleDuyet As System.Windows.Forms.Label
End Class
