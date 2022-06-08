<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowXMLReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowXMLReport))
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
        Me.CrystalReportViewer_maint.Size = New System.Drawing.Size(593, 404)
        Me.CrystalReportViewer_maint.TabIndex = 0
        Me.CrystalReportViewer_maint.ViewTimeSelectionFormula = ""
        '
        'frmShowXMLReport
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 404)
        Me.Controls.Add(Me.CrystalReportViewer_maint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmShowXMLReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Preview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CrystalReportViewer_maint As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
