<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonKho
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
        Me.grdKho = New DevExpress.XtraGrid.GridControl()
        Me.grvKho = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdKho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvKho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdKho, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(683, 422)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grdKho
        '
        Me.grdKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdKho.Location = New System.Drawing.Point(3, 3)
        Me.grdKho.MainView = Me.grvKho
        Me.grdKho.Name = "grdKho"
        Me.grdKho.Size = New System.Drawing.Size(677, 380)
        Me.grdKho.TabIndex = 2
        Me.grdKho.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvKho})
        '
        'grvKho
        '
        Me.grvKho.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvKho.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvKho.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvKho.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvKho.GridControl = Me.grdKho
        Me.grvKho.Name = "grvKho"
        Me.grvKho.OptionsView.ColumnAutoWidth = False
        Me.grvKho.OptionsView.EnableAppearanceEvenRow = True
        Me.grvKho.OptionsView.EnableAppearanceOddRow = True
        Me.grvKho.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 389)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 30)
        Me.Panel1.TabIndex = 5
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Location = New System.Drawing.Point(571, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 4
        Me.btnThoat.Text = "btnThoat"
        '
        'btnThucHien
        '
        Me.btnThucHien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThucHien.Location = New System.Drawing.Point(466, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 4
        Me.btnThucHien.Text = "btnThucHien"
        '
        'frmChonKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 422)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonKho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonKho"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdKho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvKho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdKho As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvKho As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
End Class
