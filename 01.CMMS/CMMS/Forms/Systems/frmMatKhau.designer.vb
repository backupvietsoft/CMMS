<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatKhau
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
        Me.lblOLD_PASSWORD = New System.Windows.Forms.Label
        Me.lblNEW_PASSWORD = New System.Windows.Forms.Label
        Me.btnXAC_NHAN = New System.Windows.Forms.Button
        Me.btnDOI_MAT_KHAU = New System.Windows.Forms.Button
        Me.lblTIEU_DE = New System.Windows.Forms.Label
        Me.lblCONFIRM_PASSWORD = New System.Windows.Forms.Label
        Me.btnDONG_Y = New System.Windows.Forms.Button
        Me.btnTRO_VE = New System.Windows.Forms.Button
        Me.txtPASSWORD = New System.Windows.Forms.TextBox
        Me.txtNEW_PASSWORD = New System.Windows.Forms.TextBox
        Me.txtCONFIRM_PASSWORD = New System.Windows.Forms.TextBox
        Me.btnTHOAT = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblOLD_PASSWORD
        '
        Me.lblOLD_PASSWORD.AutoSize = True
        Me.lblOLD_PASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOLD_PASSWORD.Location = New System.Drawing.Point(8, 55)
        Me.lblOLD_PASSWORD.Name = "lblOLD_PASSWORD"
        Me.lblOLD_PASSWORD.Size = New System.Drawing.Size(65, 14)
        Me.lblOLD_PASSWORD.TabIndex = 1
        Me.lblOLD_PASSWORD.Text = "Mật khẩu"
        '
        'lblNEW_PASSWORD
        '
        Me.lblNEW_PASSWORD.AutoSize = True
        Me.lblNEW_PASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNEW_PASSWORD.Location = New System.Drawing.Point(7, 83)
        Me.lblNEW_PASSWORD.Name = "lblNEW_PASSWORD"
        Me.lblNEW_PASSWORD.Size = New System.Drawing.Size(91, 14)
        Me.lblNEW_PASSWORD.TabIndex = 3
        Me.lblNEW_PASSWORD.Text = "Mật khẩu mới"
        '
        'btnXAC_NHAN
        '
        Me.btnXAC_NHAN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXAC_NHAN.ForeColor = System.Drawing.Color.Blue
        Me.btnXAC_NHAN.Location = New System.Drawing.Point(60, 134)
        Me.btnXAC_NHAN.Name = "btnXAC_NHAN"
        Me.btnXAC_NHAN.Size = New System.Drawing.Size(99, 25)
        Me.btnXAC_NHAN.TabIndex = 7
        Me.btnXAC_NHAN.Text = "Xác nhận"
        Me.btnXAC_NHAN.UseVisualStyleBackColor = True
        '
        'btnDOI_MAT_KHAU
        '
        Me.btnDOI_MAT_KHAU.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDOI_MAT_KHAU.ForeColor = System.Drawing.Color.Blue
        Me.btnDOI_MAT_KHAU.Location = New System.Drawing.Point(160, 134)
        Me.btnDOI_MAT_KHAU.Name = "btnDOI_MAT_KHAU"
        Me.btnDOI_MAT_KHAU.Size = New System.Drawing.Size(99, 25)
        Me.btnDOI_MAT_KHAU.TabIndex = 8
        Me.btnDOI_MAT_KHAU.Text = "Đổi mật khẩu"
        Me.btnDOI_MAT_KHAU.UseVisualStyleBackColor = True
        '
        'lblTIEU_DE
        '
        Me.lblTIEU_DE.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIEU_DE.ForeColor = System.Drawing.Color.Navy
        Me.lblTIEU_DE.Location = New System.Drawing.Point(4, 3)
        Me.lblTIEU_DE.Name = "lblTIEU_DE"
        Me.lblTIEU_DE.Size = New System.Drawing.Size(367, 33)
        Me.lblTIEU_DE.TabIndex = 0
        Me.lblTIEU_DE.Text = "MẬT KHẨU"
        Me.lblTIEU_DE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCONFIRM_PASSWORD
        '
        Me.lblCONFIRM_PASSWORD.AutoSize = True
        Me.lblCONFIRM_PASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCONFIRM_PASSWORD.Location = New System.Drawing.Point(6, 111)
        Me.lblCONFIRM_PASSWORD.Name = "lblCONFIRM_PASSWORD"
        Me.lblCONFIRM_PASSWORD.Size = New System.Drawing.Size(142, 14)
        Me.lblCONFIRM_PASSWORD.TabIndex = 5
        Me.lblCONFIRM_PASSWORD.Text = "Xác nhận lại mật khẩu"
        '
        'btnDONG_Y
        '
        Me.btnDONG_Y.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDONG_Y.ForeColor = System.Drawing.Color.Blue
        Me.btnDONG_Y.Location = New System.Drawing.Point(60, 134)
        Me.btnDONG_Y.Name = "btnDONG_Y"
        Me.btnDONG_Y.Size = New System.Drawing.Size(99, 25)
        Me.btnDONG_Y.TabIndex = 9
        Me.btnDONG_Y.Text = "Đồng ý"
        Me.btnDONG_Y.UseVisualStyleBackColor = True
        '
        'btnTRO_VE
        '
        Me.btnTRO_VE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTRO_VE.ForeColor = System.Drawing.Color.Black
        Me.btnTRO_VE.Location = New System.Drawing.Point(160, 134)
        Me.btnTRO_VE.Name = "btnTRO_VE"
        Me.btnTRO_VE.Size = New System.Drawing.Size(99, 25)
        Me.btnTRO_VE.TabIndex = 10
        Me.btnTRO_VE.Text = "Trở về"
        Me.btnTRO_VE.UseVisualStyleBackColor = True
        '
        'txtPASSWORD
        '
        Me.txtPASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPASSWORD.Location = New System.Drawing.Point(159, 48)
        Me.txtPASSWORD.Name = "txtPASSWORD"
        Me.txtPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPASSWORD.Size = New System.Drawing.Size(199, 22)
        Me.txtPASSWORD.TabIndex = 2
        '
        'txtNEW_PASSWORD
        '
        Me.txtNEW_PASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNEW_PASSWORD.Location = New System.Drawing.Point(159, 76)
        Me.txtNEW_PASSWORD.Name = "txtNEW_PASSWORD"
        Me.txtNEW_PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNEW_PASSWORD.Size = New System.Drawing.Size(199, 22)
        Me.txtNEW_PASSWORD.TabIndex = 4
        '
        'txtCONFIRM_PASSWORD
        '
        Me.txtCONFIRM_PASSWORD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONFIRM_PASSWORD.Location = New System.Drawing.Point(159, 104)
        Me.txtCONFIRM_PASSWORD.Name = "txtCONFIRM_PASSWORD"
        Me.txtCONFIRM_PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCONFIRM_PASSWORD.Size = New System.Drawing.Size(199, 22)
        Me.txtCONFIRM_PASSWORD.TabIndex = 6
        '
        'btnTHOAT
        '
        Me.btnTHOAT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTHOAT.ForeColor = System.Drawing.Color.Black
        Me.btnTHOAT.Location = New System.Drawing.Point(260, 134)
        Me.btnTHOAT.Name = "btnTHOAT"
        Me.btnTHOAT.Size = New System.Drawing.Size(99, 25)
        Me.btnTHOAT.TabIndex = 11
        Me.btnTHOAT.Text = "Thoát"
        Me.btnTHOAT.UseVisualStyleBackColor = True
        '
        'frmMatKhau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 165)
        Me.Controls.Add(Me.btnTHOAT)
        Me.Controls.Add(Me.txtCONFIRM_PASSWORD)
        Me.Controls.Add(Me.txtNEW_PASSWORD)
        Me.Controls.Add(Me.txtPASSWORD)
        Me.Controls.Add(Me.btnTRO_VE)
        Me.Controls.Add(Me.btnDONG_Y)
        Me.Controls.Add(Me.lblCONFIRM_PASSWORD)
        Me.Controls.Add(Me.lblTIEU_DE)
        Me.Controls.Add(Me.btnDOI_MAT_KHAU)
        Me.Controls.Add(Me.btnXAC_NHAN)
        Me.Controls.Add(Me.lblNEW_PASSWORD)
        Me.Controls.Add(Me.lblOLD_PASSWORD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmMatKhau"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mật khẩu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOLD_PASSWORD As System.Windows.Forms.Label
    Friend WithEvents lblNEW_PASSWORD As System.Windows.Forms.Label
    Friend WithEvents btnXAC_NHAN As System.Windows.Forms.Button
    Friend WithEvents btnDOI_MAT_KHAU As System.Windows.Forms.Button
    Friend WithEvents lblTIEU_DE As System.Windows.Forms.Label
    Friend WithEvents lblCONFIRM_PASSWORD As System.Windows.Forms.Label
    Friend WithEvents btnDONG_Y As System.Windows.Forms.Button
    Friend WithEvents btnTRO_VE As System.Windows.Forms.Button
    Friend WithEvents txtPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents txtNEW_PASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents txtCONFIRM_PASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents btnTHOAT As System.Windows.Forms.Button
End Class
