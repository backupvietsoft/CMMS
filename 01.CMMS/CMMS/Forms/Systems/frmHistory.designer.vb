<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblTieuDe = New System.Windows.Forms.Label
        Me.LblTuNgay = New System.Windows.Forms.Label
        Me.LblDenNgay = New System.Windows.Forms.Label
        Me.txtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.txtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.TVw = New System.Windows.Forms.TreeView
        Me.grdDSBoPhan = New System.Windows.Forms.DataGridView
        Me.BtnThoat = New System.Windows.Forms.Button
        CType(Me.grdDSBoPhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTieuDe
        '
        Me.LblTieuDe.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.LblTieuDe.Location = New System.Drawing.Point(12, 9)
        Me.LblTieuDe.Name = "LblTieuDe"
        Me.LblTieuDe.Size = New System.Drawing.Size(729, 38)
        Me.LblTieuDe.TabIndex = 0
        Me.LblTieuDe.Text = "LỊCH SỬ DI CHUYỂN BỘ PHẬN CỦA THIẾT BỊ "
        Me.LblTieuDe.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblTuNgay
        '
        Me.LblTuNgay.AutoSize = True
        Me.LblTuNgay.Location = New System.Drawing.Point(283, 53)
        Me.LblTuNgay.Name = "LblTuNgay"
        Me.LblTuNgay.Size = New System.Drawing.Size(50, 13)
        Me.LblTuNgay.TabIndex = 3
        Me.LblTuNgay.Text = "Từ ngày "
        '
        'LblDenNgay
        '
        Me.LblDenNgay.AutoSize = True
        Me.LblDenNgay.Location = New System.Drawing.Point(480, 53)
        Me.LblDenNgay.Name = "LblDenNgay"
        Me.LblDenNgay.Size = New System.Drawing.Size(57, 13)
        Me.LblDenNgay.TabIndex = 4
        Me.LblDenNgay.Text = "Đến ngày "
        '
        'txtTuNgay
        '
        Me.txtTuNgay.Location = New System.Drawing.Point(366, 50)
        Me.txtTuNgay.Mask = "00/00/0000"
        Me.txtTuNgay.Name = "txtTuNgay"
        Me.txtTuNgay.Size = New System.Drawing.Size(71, 21)
        Me.txtTuNgay.TabIndex = 5
        Me.txtTuNgay.ValidatingType = GetType(Date)
        '
        'txtDenNgay
        '
        Me.txtDenNgay.Location = New System.Drawing.Point(574, 50)
        Me.txtDenNgay.Mask = "00/00/0000"
        Me.txtDenNgay.Name = "txtDenNgay"
        Me.txtDenNgay.Size = New System.Drawing.Size(72, 21)
        Me.txtDenNgay.TabIndex = 6
        Me.txtDenNgay.ValidatingType = GetType(Date)
        '
        'TVw
        '
        Me.TVw.HideSelection = False
        Me.TVw.Location = New System.Drawing.Point(12, 93)
        Me.TVw.Name = "TVw"
        Me.TVw.Size = New System.Drawing.Size(266, 386)
        Me.TVw.TabIndex = 7
        '
        'grdDSBoPhan
        '
        Me.grdDSBoPhan.AllowUserToAddRows = False
        Me.grdDSBoPhan.AllowUserToDeleteRows = False
        Me.grdDSBoPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDSBoPhan.Location = New System.Drawing.Point(284, 93)
        Me.grdDSBoPhan.Name = "grdDSBoPhan"
        Me.grdDSBoPhan.ReadOnly = True
        Me.grdDSBoPhan.Size = New System.Drawing.Size(457, 386)
        Me.grdDSBoPhan.TabIndex = 8
        '
        'BtnThoat
        '
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(658, 485)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(83, 26)
        Me.BtnThoat.TabIndex = 10
        Me.BtnThoat.Text = "Thoát "
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 517)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.grdDSBoPhan)
        Me.Controls.Add(Me.TVw)
        Me.Controls.Add(Me.txtDenNgay)
        Me.Controls.Add(Me.txtTuNgay)
        Me.Controls.Add(Me.LblDenNgay)
        Me.Controls.Add(Me.LblTuNgay)
        Me.Controls.Add(Me.LblTieuDe)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmHistory"
        Me.Text = "History"
        CType(Me.grdDSBoPhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTieuDe As System.Windows.Forms.Label
    Friend WithEvents LblTuNgay As System.Windows.Forms.Label
    Friend WithEvents LblDenNgay As System.Windows.Forms.Label
    Friend WithEvents txtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TVw As System.Windows.Forms.TreeView
    Friend WithEvents grdDSBoPhan As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
End Class
