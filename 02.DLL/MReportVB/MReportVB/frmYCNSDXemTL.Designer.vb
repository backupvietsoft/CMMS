<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmYCNSDXemTL
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
        Me.grdChung = New DevExpress.XtraGrid.GridControl
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnXemTL = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdChung
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdChung, 3)
        Me.grdChung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChung.Location = New System.Drawing.Point(3, 3)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(578, 320)
        Me.grdChung.TabIndex = 8
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung, Me.GridView1})
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdChung
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnXemTL, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdChung, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(584, 361)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'btnXemTL
        '
        Me.btnXemTL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXemTL.Location = New System.Drawing.Point(367, 329)
        Me.btnXemTL.Name = "btnXemTL"
        Me.btnXemTL.Size = New System.Drawing.Size(104, 29)
        Me.btnXemTL.TabIndex = 14
        Me.btnXemTL.Text = "btnXemHinh"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(477, 329)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 29)
        Me.btnThoat.TabIndex = 15
        Me.btnThoat.Text = "btnThoat"
        '
        'frmYCNSDXemTL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmYCNSDXemTL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmYCNSDXemTL"
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnXemTL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
End Class
