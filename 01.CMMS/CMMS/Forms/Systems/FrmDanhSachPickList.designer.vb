<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDanhSachPickList
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
        Me.DtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.DtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.LblTuNgay = New System.Windows.Forms.Label
        Me.LblDenNgay = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CboUserName = New System.Windows.Forms.ComboBox
        Me.LblUserName = New System.Windows.Forms.Label
        Me.btnTHOAT = New System.Windows.Forms.Button
        Me.btnThuc_Hien = New System.Windows.Forms.Button
        Me.grdPickList = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.grdPickList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTieuDe
        '
        Me.LblTieuDe.AutoSize = True
        Me.LblTieuDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.LblTieuDe.Location = New System.Drawing.Point(31, 9)
        Me.LblTieuDe.Name = "LblTieuDe"
        Me.LblTieuDe.Size = New System.Drawing.Size(288, 29)
        Me.LblTieuDe.TabIndex = 0
        Me.LblTieuDe.Text = "DANH SÁCH PICK LIST"
        '
        'DtpTuNgay
        '
        Me.DtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpTuNgay.Location = New System.Drawing.Point(67, 12)
        Me.DtpTuNgay.Name = "DtpTuNgay"
        Me.DtpTuNgay.Size = New System.Drawing.Size(93, 21)
        Me.DtpTuNgay.TabIndex = 1
        '
        'DtpDenNgay
        '
        Me.DtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDenNgay.Location = New System.Drawing.Point(228, 12)
        Me.DtpDenNgay.Name = "DtpDenNgay"
        Me.DtpDenNgay.Size = New System.Drawing.Size(93, 21)
        Me.DtpDenNgay.TabIndex = 2
        '
        'LblTuNgay
        '
        Me.LblTuNgay.AutoSize = True
        Me.LblTuNgay.Location = New System.Drawing.Point(3, 16)
        Me.LblTuNgay.Name = "LblTuNgay"
        Me.LblTuNgay.Size = New System.Drawing.Size(50, 13)
        Me.LblTuNgay.TabIndex = 3
        Me.LblTuNgay.Text = "Từ ngày "
        '
        'LblDenNgay
        '
        Me.LblDenNgay.AutoSize = True
        Me.LblDenNgay.Location = New System.Drawing.Point(166, 16)
        Me.LblDenNgay.Name = "LblDenNgay"
        Me.LblDenNgay.Size = New System.Drawing.Size(57, 13)
        Me.LblDenNgay.TabIndex = 4
        Me.LblDenNgay.Text = "Đến ngày "
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CboUserName)
        Me.Panel1.Controls.Add(Me.LblUserName)
        Me.Panel1.Controls.Add(Me.DtpDenNgay)
        Me.Panel1.Controls.Add(Me.LblDenNgay)
        Me.Panel1.Controls.Add(Me.DtpTuNgay)
        Me.Panel1.Controls.Add(Me.LblTuNgay)
        Me.Panel1.Location = New System.Drawing.Point(10, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 68)
        Me.Panel1.TabIndex = 5
        '
        'CboUserName
        '
        Me.CboUserName.FormattingEnabled = True
        Me.CboUserName.Location = New System.Drawing.Point(67, 38)
        Me.CboUserName.Name = "CboUserName"
        Me.CboUserName.Size = New System.Drawing.Size(254, 21)
        Me.CboUserName.TabIndex = 6
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Location = New System.Drawing.Point(3, 41)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(58, 13)
        Me.LblUserName.TabIndex = 7
        Me.LblUserName.Text = "User name"
        '
        'btnTHOAT
        '
        Me.btnTHOAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTHOAT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTHOAT.ForeColor = System.Drawing.Color.Black
        Me.btnTHOAT.Location = New System.Drawing.Point(252, 231)
        Me.btnTHOAT.Name = "btnTHOAT"
        Me.btnTHOAT.Size = New System.Drawing.Size(85, 25)
        Me.btnTHOAT.TabIndex = 97
        Me.btnTHOAT.Text = "Thoát"
        Me.btnTHOAT.UseVisualStyleBackColor = True
        '
        'btnThuc_Hien
        '
        Me.btnThuc_Hien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThuc_Hien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThuc_Hien.ForeColor = System.Drawing.Color.Maroon
        Me.btnThuc_Hien.Location = New System.Drawing.Point(162, 231)
        Me.btnThuc_Hien.Name = "btnThuc_Hien"
        Me.btnThuc_Hien.Size = New System.Drawing.Size(90, 25)
        Me.btnThuc_Hien.TabIndex = 96
        Me.btnThuc_Hien.Text = "Thực hiện"
        Me.btnThuc_Hien.UseVisualStyleBackColor = True
        '
        'grdPickList
        '
        Me.grdPickList.AllowUserToAddRows = False
        Me.grdPickList.AllowUserToDeleteRows = False
        Me.grdPickList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPickList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPickList.Location = New System.Drawing.Point(10, 115)
        Me.grdPickList.MultiSelect = False
        Me.grdPickList.Name = "grdPickList"
        Me.grdPickList.ReadOnly = True
        Me.grdPickList.Size = New System.Drawing.Size(327, 110)
        Me.grdPickList.TabIndex = 98
        '
        'FrmDanhSachPickList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 259)
        Me.Controls.Add(Me.grdPickList)
        Me.Controls.Add(Me.btnTHOAT)
        Me.Controls.Add(Me.btnThuc_Hien)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblTieuDe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmDanhSachPickList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDanhSachPickList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdPickList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTieuDe As System.Windows.Forms.Label
    Friend WithEvents DtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblTuNgay As System.Windows.Forms.Label
    Friend WithEvents LblDenNgay As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CboUserName As System.Windows.Forms.ComboBox
    Friend WithEvents LblUserName As System.Windows.Forms.Label
    Friend WithEvents btnTHOAT As System.Windows.Forms.Button
    Friend WithEvents btnThuc_Hien As System.Windows.Forms.Button
    Friend WithEvents grdPickList As System.Windows.Forms.DataGridView
End Class
