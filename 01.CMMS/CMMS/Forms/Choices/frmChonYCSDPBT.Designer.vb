<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonYCSDPBT
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
        Me.TableLayoutPanel24 = New System.Windows.Forms.TableLayoutPanel
        Me.lblTim = New DevExpress.XtraEditors.LabelControl
        Me.txtTKiem = New DevExpress.XtraEditors.TextEdit
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoatYCBT = New DevExpress.XtraEditors.SimpleButton
        Me.grdYCBT = New DevExpress.XtraGrid.GridControl
        Me.grvYCBT = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TableLayoutPanel24.SuspendLayout()
        CType(Me.txtTKiem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdYCBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvYCBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel24
        '
        Me.TableLayoutPanel24.ColumnCount = 5
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel24.Controls.Add(Me.lblTim, 0, 1)
        Me.TableLayoutPanel24.Controls.Add(Me.txtTKiem, 0, 1)
        Me.TableLayoutPanel24.Controls.Add(Me.btnThucHien, 3, 1)
        Me.TableLayoutPanel24.Controls.Add(Me.btnThoatYCBT, 4, 1)
        Me.TableLayoutPanel24.Controls.Add(Me.grdYCBT, 0, 0)
        Me.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel24.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel24.Name = "TableLayoutPanel24"
        Me.TableLayoutPanel24.RowCount = 2
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel24.Size = New System.Drawing.Size(918, 612)
        Me.TableLayoutPanel24.TabIndex = 2
        '
        'lblTim
        '
        Me.lblTim.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTim.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTim.Location = New System.Drawing.Point(3, 590)
        Me.lblTim.Name = "lblTim"
        Me.lblTim.Size = New System.Drawing.Size(104, 19)
        Me.lblTim.TabIndex = 16
        Me.lblTim.Text = "lblTim"
        '
        'txtTKiem
        '
        Me.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTKiem.Location = New System.Drawing.Point(113, 589)
        Me.txtTKiem.Name = "txtTKiem"
        Me.txtTKiem.Size = New System.Drawing.Size(156, 20)
        Me.txtTKiem.TabIndex = 15
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(701, 577)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 32)
        Me.btnThucHien.TabIndex = 7
        Me.btnThucHien.Text = "btnThucHien"
        '
        'btnThoatYCBT
        '
        Me.btnThoatYCBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoatYCBT.Location = New System.Drawing.Point(811, 577)
        Me.btnThoatYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnThoatYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoatYCBT.Name = "btnThoatYCBT"
        Me.btnThoatYCBT.Size = New System.Drawing.Size(104, 32)
        Me.btnThoatYCBT.TabIndex = 5
        Me.btnThoatYCBT.Text = "btnThoatYCBT"
        '
        'grdYCBT
        '
        Me.TableLayoutPanel24.SetColumnSpan(Me.grdYCBT, 5)
        Me.grdYCBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdYCBT.Location = New System.Drawing.Point(3, 3)
        Me.grdYCBT.LookAndFeel.SkinName = "Blue"
        Me.grdYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdYCBT.MainView = Me.grvYCBT
        Me.grdYCBT.Name = "grdYCBT"
        Me.grdYCBT.Size = New System.Drawing.Size(912, 568)
        Me.grdYCBT.TabIndex = 1
        Me.grdYCBT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvYCBT})
        '
        'grvYCBT
        '
        Me.grvYCBT.GridControl = Me.grdYCBT
        Me.grvYCBT.Name = "grvYCBT"
        Me.grvYCBT.OptionsView.ShowGroupPanel = False
        '
        'frmChonYCSDPBT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 612)
        Me.Controls.Add(Me.TableLayoutPanel24)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonYCSDPBT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonYCSDPBT"
        Me.TableLayoutPanel24.ResumeLayout(False)
        CType(Me.txtTKiem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdYCBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvYCBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel24 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdYCBT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvYCBT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnThoatYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTim As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTKiem As DevExpress.XtraEditors.TextEdit
End Class
