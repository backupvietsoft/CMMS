<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhuTungMay
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
        Me.grdMay = New DevExpress.XtraGrid.GridControl
        Me.grvMay = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.grdBPhan = New DevExpress.XtraGrid.GridControl
        Me.grvBPhan = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBPhan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvBPhan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdMay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grdBPhan, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grdMay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdMay, 3)
        Me.grdMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMay.Location = New System.Drawing.Point(3, 3)
        Me.grdMay.LookAndFeel.SkinName = "Blue"
        Me.grdMay.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdMay.MainView = Me.grvMay
        Me.grdMay.Name = "grdMay"
        Me.grdMay.Size = New System.Drawing.Size(878, 256)
        Me.grdMay.TabIndex = 8
        Me.grdMay.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMay, Me.GridView2})
        '
        'grvMay
        '
        Me.grvMay.GridControl = Me.grdMay
        Me.grvMay.Name = "grvMay"
        Me.grvMay.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdMay
        Me.GridView2.Name = "GridView2"
        '
        'grdBPhan
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdBPhan, 3)
        Me.grdBPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBPhan.Location = New System.Drawing.Point(3, 265)
        Me.grdBPhan.LookAndFeel.SkinName = "Blue"
        Me.grdBPhan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdBPhan.MainView = Me.grvBPhan
        Me.grdBPhan.Name = "grdBPhan"
        Me.grdBPhan.Size = New System.Drawing.Size(878, 256)
        Me.grdBPhan.TabIndex = 8
        Me.grdBPhan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvBPhan, Me.GridView3})
        '
        'grvBPhan
        '
        Me.grvBPhan.GridControl = Me.grdBPhan
        Me.grvBPhan.Name = "grvBPhan"
        Me.grvBPhan.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdBPhan
        Me.GridView3.Name = "GridView3"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(777, 527)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 31)
        Me.btnThoat.TabIndex = 10
        Me.btnThoat.Text = "btnThoat"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(667, 527)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 31)
        Me.btnThucHien.TabIndex = 9
        Me.btnThucHien.Text = "btnThucHien"
        '
        'frmPhuTungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmPhuTungMay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPhuTungMay"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBPhan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvBPhan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdMay As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMay As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdBPhan As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvBPhan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
End Class
