<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonTSGSTT
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
        Me.components = New System.ComponentModel.Container
        Me.LblTieudechukyBTPN = New System.Windows.Forms.Label
        Me.grdChonTSGSTT = New System.Windows.Forms.DataGridView
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnThucHien = New System.Windows.Forms.Button
        Me.BtnBoChonTatCa = New System.Windows.Forms.Button
        Me.BtnChonTatCa = New System.Windows.Forms.Button
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TVw = New System.Windows.Forms.TreeView
        Me.GrpChonBoPhan = New System.Windows.Forms.GroupBox
        Me.GrpChonCV = New System.Windows.Forms.GroupBox
        CType(Me.grdChonTSGSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpChonBoPhan.SuspendLayout()
        Me.GrpChonCV.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTieudechukyBTPN
        '
        Me.LblTieudechukyBTPN.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudechukyBTPN.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudechukyBTPN.Location = New System.Drawing.Point(96, 9)
        Me.LblTieudechukyBTPN.Name = "LblTieudechukyBTPN"
        Me.LblTieudechukyBTPN.Size = New System.Drawing.Size(590, 29)
        Me.LblTieudechukyBTPN.TabIndex = 25
        Me.LblTieudechukyBTPN.Text = "CHỌN THÔNG SỐ GIÁM SÁT TÌNH TRẠNG "
        Me.LblTieudechukyBTPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTieudechukyBTPN.UseCompatibleTextRendering = True
        '
        'grdChonTSGSTT
        '
        Me.grdChonTSGSTT.AllowUserToAddRows = False
        Me.grdChonTSGSTT.AllowUserToDeleteRows = False
        Me.grdChonTSGSTT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdChonTSGSTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdChonTSGSTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdChonTSGSTT.Location = New System.Drawing.Point(6, 19)
        Me.grdChonTSGSTT.Name = "grdChonTSGSTT"
        Me.grdChonTSGSTT.RowHeadersWidth = 25
        Me.grdChonTSGSTT.Size = New System.Drawing.Size(432, 384)
        Me.grdChonTSGSTT.TabIndex = 27
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Black
        Me.BtnThoat.Location = New System.Drawing.Point(687, 499)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThucHien.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThucHien.ForeColor = System.Drawing.Color.Blue
        Me.BtnThucHien.Location = New System.Drawing.Point(598, 499)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(88, 25)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        Me.BtnThucHien.UseVisualStyleBackColor = True
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBoChonTatCa.ForeColor = System.Drawing.Color.Red
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(98, 499)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(98, 25)
        Me.BtnBoChonTatCa.TabIndex = 87
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        Me.BtnBoChonTatCa.UseVisualStyleBackColor = True
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTatCa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChonTatCa.ForeColor = System.Drawing.Color.Blue
        Me.BtnChonTatCa.Location = New System.Drawing.Point(9, 499)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(88, 25)
        Me.BtnChonTatCa.TabIndex = 86
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        Me.BtnChonTatCa.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TVw
        '
        Me.TVw.Location = New System.Drawing.Point(6, 19)
        Me.TVw.Name = "TVw"
        Me.TVw.Size = New System.Drawing.Size(297, 384)
        Me.TVw.TabIndex = 88
        '
        'GrpChonBoPhan
        '
        Me.GrpChonBoPhan.Controls.Add(Me.TVw)
        Me.GrpChonBoPhan.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonBoPhan.Location = New System.Drawing.Point(9, 84)
        Me.GrpChonBoPhan.Name = "GrpChonBoPhan"
        Me.GrpChonBoPhan.Size = New System.Drawing.Size(309, 409)
        Me.GrpChonBoPhan.TabIndex = 89
        Me.GrpChonBoPhan.TabStop = False
        Me.GrpChonBoPhan.Text = "Chọn bộ phận "
        '
        'GrpChonCV
        '
        Me.GrpChonCV.Controls.Add(Me.grdChonTSGSTT)
        Me.GrpChonCV.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonCV.Location = New System.Drawing.Point(324, 84)
        Me.GrpChonCV.Name = "GrpChonCV"
        Me.GrpChonCV.Size = New System.Drawing.Size(444, 409)
        Me.GrpChonCV.TabIndex = 90
        Me.GrpChonCV.TabStop = False
        Me.GrpChonCV.Text = "Chọn thông số "
        '
        'FrmChonTSGSTT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 527)
        Me.Controls.Add(Me.GrpChonCV)
        Me.Controls.Add(Me.GrpChonBoPhan)
        Me.Controls.Add(Me.BtnBoChonTatCa)
        Me.Controls.Add(Me.BtnChonTatCa)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnThucHien)
        Me.Controls.Add(Me.LblTieudechukyBTPN)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmChonTSGSTT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn công việc cho bảo trì phòng ngừa"
        CType(Me.grdChonTSGSTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpChonBoPhan.ResumeLayout(False)
        Me.GrpChonCV.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTieudechukyBTPN As System.Windows.Forms.Label
    Friend WithEvents grdChonTSGSTT As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThucHien As System.Windows.Forms.Button
    Friend WithEvents BtnBoChonTatCa As System.Windows.Forms.Button
    Friend WithEvents BtnChonTatCa As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpChonCV As System.Windows.Forms.GroupBox
    Friend WithEvents GrpChonBoPhan As System.Windows.Forms.GroupBox
    Friend WithEvents TVw As System.Windows.Forms.TreeView
End Class
