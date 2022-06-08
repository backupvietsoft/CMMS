<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompareSLXuat
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
        Me.grdCompare = New DevExpress.XtraGrid.GridControl()
        Me.grvCompare = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btprint = New DevExpress.XtraEditors.SimpleButton()
        Me.btExit = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 799.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdCompare, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(903, 556)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'grdCompare
        '
        Me.grdCompare.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCompare.Location = New System.Drawing.Point(3, 11)
        Me.grdCompare.MainView = Me.grvCompare
        Me.grdCompare.Name = "grdCompare"
        Me.grdCompare.Size = New System.Drawing.Size(897, 502)
        Me.grdCompare.TabIndex = 4
        Me.grdCompare.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCompare})
        '
        'grvCompare
        '
        Me.grvCompare.GridControl = Me.grdCompare
        Me.grvCompare.Name = "grvCompare"
        Me.grvCompare.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btprint)
        Me.Panel1.Controls.Add(Me.btExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 519)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 34)
        Me.Panel1.TabIndex = 3
        '
        'btprint
        '
        Me.btprint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btprint.Location = New System.Drawing.Point(685, 2)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(104, 30)
        Me.btprint.TabIndex = 2
        Me.btprint.Text = "In"
        Me.btprint.Visible = False
        '
        'btExit
        '
        Me.btExit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExit.Location = New System.Drawing.Point(790, 2)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(104, 30)
        Me.btExit.TabIndex = 1
        Me.btExit.Text = "Th&oát"
        '
        'frmCompareSLXuat
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 556)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimumSize = New System.Drawing.Size(679, 456)
        Me.Name = "frmCompareSLXuat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCompareSLXuat"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCompare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btprint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCompare As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCompare As DevExpress.XtraGrid.Views.Grid.GridView
End Class
