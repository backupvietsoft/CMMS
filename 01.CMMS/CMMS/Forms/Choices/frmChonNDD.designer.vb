<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonNDD
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
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnChon = New System.Windows.Forms.Button
        Me.grdDSNDD = New System.Windows.Forms.DataGridView
        CType(Me.grdDSNDD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThoat
        '
        Me.BtnThoat.ForeColor = System.Drawing.Color.Teal
        Me.BtnThoat.Location = New System.Drawing.Point(73, 180)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(59, 21)
        Me.BtnThoat.TabIndex = 5
        Me.BtnThoat.Text = "&Thoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnChon
        '
        Me.BtnChon.ForeColor = System.Drawing.Color.Teal
        Me.BtnChon.Location = New System.Drawing.Point(12, 180)
        Me.BtnChon.Name = "BtnChon"
        Me.BtnChon.Size = New System.Drawing.Size(59, 21)
        Me.BtnChon.TabIndex = 4
        Me.BtnChon.Text = "&Chọn"
        Me.BtnChon.UseVisualStyleBackColor = True
        '
        'grdDSNDD
        '
        Me.grdDSNDD.AllowUserToAddRows = False
        Me.grdDSNDD.AllowUserToDeleteRows = False
        Me.grdDSNDD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDSNDD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdDSNDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDSNDD.ColumnHeadersVisible = False
        Me.grdDSNDD.Location = New System.Drawing.Point(2, 0)
        Me.grdDSNDD.MultiSelect = False
        Me.grdDSNDD.Name = "grdDSNDD"
        Me.grdDSNDD.ReadOnly = True
        Me.grdDSNDD.RowHeadersVisible = False
        Me.grdDSNDD.RowHeadersWidth = 4
        Me.grdDSNDD.Size = New System.Drawing.Size(150, 174)
        Me.grdDSNDD.TabIndex = 3
        '
        'frmChonNDD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(154, 203)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnChon)
        Me.Controls.Add(Me.grdDSNDD)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonNDD"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Người đại diện"
        CType(Me.grdDSNDD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnChon As System.Windows.Forms.Button
    Friend WithEvents grdDSNDD As System.Windows.Forms.DataGridView
End Class
