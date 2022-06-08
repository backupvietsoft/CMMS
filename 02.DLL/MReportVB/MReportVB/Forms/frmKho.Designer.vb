<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKho
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grdKho = New DevExpress.XtraGrid.GridControl
        Me.grvKho = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.grdVTri = New DevExpress.XtraGrid.GridControl
        Me.grvVTri = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdKho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvKho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVTri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvVTri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdKho, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdVTri, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(867, 618)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grdKho
        '
        Me.grdKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdKho.Location = New System.Drawing.Point(3, 45)
        Me.grdKho.MainView = Me.grvKho
        Me.grdKho.Name = "grdKho"
        Me.grdKho.Size = New System.Drawing.Size(514, 528)
        Me.grdKho.TabIndex = 8
        Me.grdKho.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvKho, Me.GridView1})
        '
        'grvKho
        '
        Me.grvKho.GridControl = Me.grdKho
        Me.grvKho.Name = "grvKho"
        Me.grvKho.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdKho
        Me.GridView1.Name = "GridView1"
        '
        'grdVTri
        '
        Me.grdVTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVTri.Location = New System.Drawing.Point(523, 45)
        Me.grdVTri.MainView = Me.grvVTri
        Me.grdVTri.Name = "grdVTri"
        Me.grdVTri.Size = New System.Drawing.Size(341, 528)
        Me.grdVTri.TabIndex = 8
        Me.grdVTri.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvVTri, Me.GridView3})
        '
        'grvVTri
        '
        Me.grvVTri.GridControl = Me.grdVTri
        Me.grvVTri.Name = "grvVTri"
        Me.grvVTri.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdVTri
        Me.GridView3.Name = "GridView3"
        '
        'frmKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 618)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmKho"
        Me.Text = "frmKho"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdKho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvKho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVTri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvVTri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdKho As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvKho As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdVTri As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvVTri As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
