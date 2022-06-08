<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportViews_Budget
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdView = New DevExpress.XtraGrid.GridControl()
        Me.grvView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdView, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExcel, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExit, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(618, 435)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grdView
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdView, 3)
        Me.grdView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdView.Location = New System.Drawing.Point(3, 11)
        Me.grdView.MainView = Me.grvView
        Me.grdView.Name = "grdView"
        Me.grdView.Size = New System.Drawing.Size(612, 381)
        Me.grdView.TabIndex = 0
        Me.grdView.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvView})
        '
        'grvView
        '
        Me.grvView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvView.GridControl = Me.grdView
        Me.grvView.Name = "grvView"
        Me.grvView.OptionsBehavior.Editable = False
        Me.grvView.OptionsView.ColumnAutoWidth = False
        Me.grvView.OptionsView.EnableAppearanceEvenRow = True
        Me.grvView.OptionsView.EnableAppearanceOddRow = True
        Me.grvView.OptionsView.ShowGroupPanel = False
        '
        'btnExcel
        '
        Me.btnExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExcel.Location = New System.Drawing.Point(401, 398)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(104, 30)
        Me.btnExcel.TabIndex = 1
        Me.btnExcel.Text = "Excel"
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.Location = New System.Drawing.Point(511, 398)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(104, 30)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        '
        'frmReportViews_Budget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 435)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmReportViews_Budget"
        Me.Text = "frmReportViews"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Public WithEvents grdView As DevExpress.XtraGrid.GridControl
    Public WithEvents grvView As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents btnExcel As DevExpress.XtraEditors.SimpleButton
End Class
