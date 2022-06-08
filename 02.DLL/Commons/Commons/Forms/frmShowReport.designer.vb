<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowReport
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
        Me.oReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'oReport
        '
        Me.oReport.ActiveViewIndex = -1
        Me.oReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.oReport.DisplayGroupTree = False
        Me.oReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oReport.Location = New System.Drawing.Point(0, 0)
        Me.oReport.Name = "oReport"
        Me.oReport.SelectionFormula = ""
        Me.oReport.ShowGroupTreeButton = False
        Me.oReport.ShowRefreshButton = False
        Me.oReport.Size = New System.Drawing.Size(441, 201)
        Me.oReport.TabIndex = 0
        Me.oReport.ViewTimeSelectionFormula = ""
        '
        'frmShowReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 201)
        Me.Controls.Add(Me.oReport)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmShowReport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print preview"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents oReport As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
