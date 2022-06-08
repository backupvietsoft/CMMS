<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonNX
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
        Me.lblTitle = New System.Windows.Forms.Label
        Me.gdNX = New DevExpress.XtraGrid.GridControl
        Me.gvNX = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.btnExcute = New DevExpress.XtraEditors.SimpleButton
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gdNX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvNX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gdNX, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExcute, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(690, 452)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTitle, 2)
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(684, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Label1"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gdNX
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gdNX, 2)
        Me.gdNX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdNX.Location = New System.Drawing.Point(3, 33)
        Me.gdNX.MainView = Me.gvNX
        Me.gdNX.Name = "gdNX"
        Me.gdNX.Size = New System.Drawing.Size(684, 386)
        Me.gdNX.TabIndex = 1
        Me.gdNX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvNX})
        '
        'gvNX
        '
        Me.gvNX.GridControl = Me.gdNX
        Me.gvNX.Name = "gvNX"
        Me.gvNX.OptionsBehavior.Editable = False
        Me.gvNX.OptionsView.EnableAppearanceEvenRow = True
        Me.gvNX.OptionsView.EnableAppearanceOddRow = True
        Me.gvNX.OptionsView.ShowGroupPanel = False
        '
        'btnExcute
        '
        Me.btnExcute.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExcute.Location = New System.Drawing.Point(493, 425)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(94, 24)
        Me.btnExcute.TabIndex = 2
        Me.btnExcute.Text = "SimpleButton1"
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(593, 425)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "SimpleButton2"
        '
        'frmChonNX
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 452)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonNX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonNX"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gdNX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvNX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gdNX As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvNX As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExcute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
End Class
