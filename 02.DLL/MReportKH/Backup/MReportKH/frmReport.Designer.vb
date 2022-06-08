<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrystalReportViewer_maint = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CrystalReportViewer_maint
        '
        Me.CrystalReportViewer_maint.ActiveViewIndex = -1
        Me.CrystalReportViewer_maint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer_maint.DisplayGroupTree = False
        Me.CrystalReportViewer_maint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer_maint.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer_maint.Name = "CrystalReportViewer_maint"
        Me.CrystalReportViewer_maint.SelectionFormula = ""
        Me.CrystalReportViewer_maint.Size = New System.Drawing.Size(657, 630)
        Me.CrystalReportViewer_maint.TabIndex = 1
        Me.CrystalReportViewer_maint.ViewTimeSelectionFormula = ""
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 630)
        Me.Controls.Add(Me.CrystalReportViewer_maint)
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CrystalReportViewer_maint As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
