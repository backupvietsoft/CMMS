<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_ChuyenTuNamTruoc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grpDanhsachBTDKcanthuchien = New System.Windows.Forms.GroupBox
        Me.gdBTDK = New DevExpress.XtraGrid.GridControl
        Me.gvBTDK = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button4 = New DevExpress.XtraEditors.SimpleButton
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton
        Me.Button2 = New DevExpress.XtraEditors.SimpleButton
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpDanhsachBTDKcanthuchien.SuspendLayout()
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachBTDKcanthuchien, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(602, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grpDanhsachBTDKcanthuchien
        '
        Me.grpDanhsachBTDKcanthuchien.Controls.Add(Me.gdBTDK)
        Me.grpDanhsachBTDKcanthuchien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachBTDKcanthuchien.ForeColor = System.Drawing.Color.Navy
        Me.grpDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(3, 33)
        Me.grpDanhsachBTDKcanthuchien.Name = "grpDanhsachBTDKcanthuchien"
        Me.grpDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(596, 384)
        Me.grpDanhsachBTDKcanthuchien.TabIndex = 2
        Me.grpDanhsachBTDKcanthuchien.TabStop = False
        Me.grpDanhsachBTDKcanthuchien.Text = "Danh sách thiết bị bảo trì định kỳ cần thực hiện"
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(3, 16)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(590, 365)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.GridControl = Me.gdBTDK
        Me.gvBTDK.Name = "gvBTDK"
        Me.gvBTDK.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(596, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bảo trì định kỳ cần thực hiện "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 35)
        Me.Panel1.TabIndex = 3
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.Location = New System.Drawing.Point(446, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 35)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Chọn"

        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.Location = New System.Drawing.Point(521, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 35)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Thoát"

        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.Location = New System.Drawing.Point(75, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Bỏ chọn tất cả"

        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Chọn tất cả"

        '
        'frmKHTT_ChuyenTuNamTruoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_ChuyenTuNamTruoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKHTT_BTDKChoose"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grpDanhsachBTDKcanthuchien.ResumeLayout(False)
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpDanhsachBTDKcanthuchien As System.Windows.Forms.GroupBox
    Friend WithEvents gdBTDK As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
End Class
