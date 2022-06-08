<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapTaiChe
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdNhapTaiChe = New DevExpress.XtraGrid.GridControl()
        Me.grvNhapTaiChe = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.grdNhapTaiChe,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grvNhapTaiChe,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdNhapTaiChe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grdNhapTaiChe
        '
        Me.grdNhapTaiChe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNhapTaiChe.Location = New System.Drawing.Point(3, 3)
        Me.grdNhapTaiChe.MainView = Me.grvNhapTaiChe
        Me.grdNhapTaiChe.Name = "grdNhapTaiChe"
        Me.grdNhapTaiChe.Size = New System.Drawing.Size(878, 519)
        Me.grdNhapTaiChe.TabIndex = 2
        Me.grdNhapTaiChe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvNhapTaiChe})
        '
        'grvNhapTaiChe
        '
        Me.grvNhapTaiChe.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grvNhapTaiChe.Appearance.HeaderPanel.Options.UseFont = true
        Me.grvNhapTaiChe.Appearance.HeaderPanel.Options.UseTextOptions = true
        Me.grvNhapTaiChe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvNhapTaiChe.GridControl = Me.grdNhapTaiChe
        Me.grvNhapTaiChe.Name = "grvNhapTaiChe"
        Me.grvNhapTaiChe.OptionsView.ColumnAutoWidth = false
        Me.grvNhapTaiChe.OptionsView.EnableAppearanceEvenRow = true
        Me.grvNhapTaiChe.OptionsView.EnableAppearanceOddRow = true
        Me.grvNhapTaiChe.OptionsView.ShowGroupPanel = false
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 528)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 30)
        Me.Panel1.TabIndex = 5
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Location = New System.Drawing.Point(772, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 4
        Me.btnThoat.Text = "btnThoat"
        '
        'btnThucHien
        '
        Me.btnThucHien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnThucHien.Location = New System.Drawing.Point(667, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 4
        Me.btnThucHien.Text = "btnThucHien"
        '
        'frmNhapTaiChe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmNhapTaiChe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmNhapTaiChe"
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.grdNhapTaiChe,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvNhapTaiChe,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdNhapTaiChe As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvNhapTaiChe As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
End Class
