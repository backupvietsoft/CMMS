<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInTuKeHoachTongThe
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
        Me.optDuTruVT_TheoMay = New System.Windows.Forms.RadioButton()
        Me.optDuTruVT_TheoDayChuyen = New System.Windows.Forms.RadioButton()
        Me.btnThucHien = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'optDuTruVT_TheoMay
        '
        Me.optDuTruVT_TheoMay.AutoSize = True
        Me.optDuTruVT_TheoMay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDuTruVT_TheoMay.Location = New System.Drawing.Point(24, 13)
        Me.optDuTruVT_TheoMay.Name = "optDuTruVT_TheoMay"
        Me.optDuTruVT_TheoMay.Size = New System.Drawing.Size(156, 17)
        Me.optDuTruVT_TheoMay.TabIndex = 0
        Me.optDuTruVT_TheoMay.Text = "Dự trù vật tư theo loại máy"
        Me.optDuTruVT_TheoMay.UseVisualStyleBackColor = True
        '
        'optDuTruVT_TheoDayChuyen
        '
        Me.optDuTruVT_TheoDayChuyen.AutoSize = True
        Me.optDuTruVT_TheoDayChuyen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDuTruVT_TheoDayChuyen.Location = New System.Drawing.Point(24, 36)
        Me.optDuTruVT_TheoDayChuyen.Name = "optDuTruVT_TheoDayChuyen"
        Me.optDuTruVT_TheoDayChuyen.Size = New System.Drawing.Size(173, 17)
        Me.optDuTruVT_TheoDayChuyen.TabIndex = 0
        Me.optDuTruVT_TheoDayChuyen.Text = "Dự trù vật tư theo dây chuyền"
        Me.optDuTruVT_TheoDayChuyen.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.Color.Blue
        Me.btnThucHien.Location = New System.Drawing.Point(108, 72)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(92, 28)
        Me.btnThucHien.TabIndex = 1
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(204, 72)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(92, 28)
        Me.btnThoat.TabIndex = 1
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmInTuKeHoachTongThe
        '
        Me.AcceptButton = Me.btnThucHien
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(308, 111)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.optDuTruVT_TheoDayChuyen)
        Me.Controls.Add(Me.optDuTruVT_TheoMay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInTuKeHoachTongThe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmInTuKeHoachTongThe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optDuTruVT_TheoMay As System.Windows.Forms.RadioButton
    Friend WithEvents optDuTruVT_TheoDayChuyen As System.Windows.Forms.RadioButton
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
End Class
