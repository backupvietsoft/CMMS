<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXemHinh
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
        Me.PctHinh = New System.Windows.Forms.PictureBox
        CType(Me.PctHinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PctHinh
        '
        Me.PctHinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PctHinh.Location = New System.Drawing.Point(0, 0)
        Me.PctHinh.Name = "PctHinh"
        Me.PctHinh.Size = New System.Drawing.Size(627, 473)
        Me.PctHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PctHinh.TabIndex = 0
        Me.PctHinh.TabStop = False
        '
        'frmXemHinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 473)
        Me.Controls.Add(Me.PctHinh)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmXemHinh"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PctHinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PctHinh As System.Windows.Forms.PictureBox
End Class
