<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRefreshData
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
        Me.prgBar = New System.Windows.Forms.ProgressBar
        Me.btnTinhToanLai = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboKHO = New Commons.UtcComboBox
        Me.lblTieude = New System.Windows.Forms.Label
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'prgBar
        '
        Me.prgBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.prgBar.Location = New System.Drawing.Point(0, 172)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(352, 23)
        Me.prgBar.TabIndex = 0
        '
        'btnTinhToanLai
        '
        Me.btnTinhToanLai.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTinhToanLai.ForeColor = System.Drawing.Color.Maroon
        Me.btnTinhToanLai.Location = New System.Drawing.Point(77, 123)
        Me.btnTinhToanLai.Name = "btnTinhToanLai"
        Me.btnTinhToanLai.Size = New System.Drawing.Size(120, 23)
        Me.btnTinhToanLai.TabIndex = 2
        Me.btnTinhToanLai.Text = "Tính Toán Lại"
        Me.btnTinhToanLai.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(203, 123)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 3
        Me.btnThoat.Text = "&Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'cboKHO
        '
        Me.cboKHO.AssemblyName = ""
        Me.cboKHO.BackColor = System.Drawing.Color.White
        Me.cboKHO.ClassName = ""
        Me.cboKHO.Display = "TEN_KHO"
        Me.cboKHO.ErrorProviderControl = Me.errProvider
        Me.cboKHO.FormattingEnabled = True
        Me.cboKHO.IsAll = False
        Me.cboKHO.IsNew = False
        Me.cboKHO.ItemAll = " < ALL > "
        Me.cboKHO.ItemNew = "...New"
        Me.cboKHO.Location = New System.Drawing.Point(77, 79)
        Me.cboKHO.MethodName = ""
        Me.cboKHO.Name = "cboKHO"
        Me.cboKHO.Param = ""
        Me.cboKHO.Size = New System.Drawing.Size(201, 21)
        Me.cboKHO.StoreName = "QL_LISTKHO"
        Me.cboKHO.TabIndex = 1
        Me.cboKHO.Table = Nothing
        Me.cboKHO.TextReadonly = False
        Me.cboKHO.Value = "MS_KHO"
        '
        'lblTieude
        '
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(12, 13)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(328, 23)
        Me.lblTieude.TabIndex = 4
        Me.lblTieude.Text = "PHỤC HỒI DỮ LIỆU KHO"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmRefreshData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTieude)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnTinhToanLai)
        Me.Controls.Add(Me.cboKHO)
        Me.Controls.Add(Me.prgBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmRefreshData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRefreshData"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cboKHO As Commons.UtcComboBox
    Friend WithEvents btnTinhToanLai As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieude As System.Windows.Forms.Label
End Class
