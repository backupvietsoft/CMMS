<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachPhieuBT
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
        Me.GridControlDS = New DevExpress.XtraGrid.GridControl
        Me.GridViewDS = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton
        Me.txtMS_PHIEU = New DevExpress.XtraEditors.TextEdit
        Me.txtTimKiem = New DevExpress.XtraEditors.LabelControl
        Me.txtMS = New DevExpress.XtraEditors.TextEdit
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.GridControlDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMS_PHIEU.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GridControlDS, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdThucHien, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdThoat, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMS_PHIEU, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTimKiem, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMS, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(903, 502)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GridControlDS
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GridControlDS, 6)
        Me.GridControlDS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlDS.Location = New System.Drawing.Point(3, 3)
        Me.GridControlDS.MainView = Me.GridViewDS
        Me.GridControlDS.Name = "GridControlDS"
        Me.GridControlDS.Size = New System.Drawing.Size(897, 466)
        Me.GridControlDS.TabIndex = 1
        Me.GridControlDS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDS})
        '
        'GridViewDS
        '
        Me.GridViewDS.GridControl = Me.GridControlDS
        Me.GridViewDS.Name = "GridViewDS"
        Me.GridViewDS.OptionsView.ShowGroupPanel = False
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Location = New System.Drawing.Point(705, 475)
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(94, 24)
        Me.cmdThucHien.TabIndex = 2
        Me.cmdThucHien.Text = "Thuc Hien"
        '
        'cmdThoat
        '
        Me.cmdThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThoat.Location = New System.Drawing.Point(805, 475)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(95, 24)
        Me.cmdThoat.TabIndex = 3
        Me.cmdThoat.Text = "Thoat"
        '
        'txtMS_PHIEU
        '
        Me.txtMS_PHIEU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMS_PHIEU.Location = New System.Drawing.Point(223, 475)
        Me.txtMS_PHIEU.Name = "txtMS_PHIEU"
        Me.txtMS_PHIEU.Size = New System.Drawing.Size(235, 20)
        Me.txtMS_PHIEU.TabIndex = 4
        '
        'txtTimKiem
        '
        Me.txtTimKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTimKiem.Location = New System.Drawing.Point(3, 475)
        Me.txtTimKiem.Name = "txtTimKiem"
        Me.txtTimKiem.Size = New System.Drawing.Size(94, 24)
        Me.txtTimKiem.TabIndex = 5
        Me.txtTimKiem.Text = "LabelControl1"
        '
        'txtMS
        '
        Me.txtMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMS.Location = New System.Drawing.Point(103, 475)
        Me.txtMS.Name = "txtMS"
        Me.txtMS.Size = New System.Drawing.Size(114, 20)
        Me.txtMS.TabIndex = 6
        '
        'frmDanhSachPhieuBT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 502)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDanhSachPhieuBT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmDanhSachPhieuBT"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.GridControlDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMS_PHIEU.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GridControlDS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMS_PHIEU As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTimKiem As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMS As DevExpress.XtraEditors.TextEdit
End Class
