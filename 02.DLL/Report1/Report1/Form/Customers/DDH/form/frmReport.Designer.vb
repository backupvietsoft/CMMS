<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.rptView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptView
        '
        Me.rptView.ActiveViewIndex = -1
        Me.rptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptView.Location = New System.Drawing.Point(0, 0)
        Me.rptView.Name = "rptView"
        Me.rptView.SelectionFormula = ""
        Me.rptView.Size = New System.Drawing.Size(917, 485)
        Me.rptView.TabIndex = 0
        Me.rptView.ViewTimeSelectionFormula = ""
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 485)
        Me.Controls.Add(Me.rptView)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
