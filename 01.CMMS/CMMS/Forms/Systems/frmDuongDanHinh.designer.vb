<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDuongDanHinh
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
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.grdHinh = New DevExpress.XtraGrid.GridControl()
        Me.grvHinh = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.grdHinh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvHinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Đường dẫn hình"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(477, 328)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 29
        Me.btnThoat.Text = "T&hoát"
        '
        'btnView
        '
        Me.btnView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnView.Location = New System.Drawing.Point(367, 328)
        Me.btnView.LookAndFeel.SkinName = "Blue"
        Me.btnView.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(104, 30)
        Me.btnView.TabIndex = 29
        Me.btnView.Text = "btnView"
        '
        'grdHinh
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdHinh, 3)
        Me.grdHinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHinh.Location = New System.Drawing.Point(3, 11)
        Me.grdHinh.MainView = Me.grvHinh
        Me.grdHinh.Name = "grdHinh"
        Me.grdHinh.Size = New System.Drawing.Size(578, 311)
        Me.grdHinh.TabIndex = 30
        Me.grdHinh.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvHinh})
        '
        'grvHinh
        '
        Me.grvHinh.GridControl = Me.grdHinh
        Me.grvHinh.HorzScrollStep = 5
        Me.grvHinh.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.grvHinh.Name = "grvHinh"
        Me.grvHinh.OptionsView.ColumnAutoWidth = False
        Me.grvHinh.OptionsView.EnableAppearanceEvenRow = True
        Me.grvHinh.OptionsView.EnableAppearanceOddRow = True
        Me.grvHinh.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.13014!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdHinh, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnView, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.08498!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.915014!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(584, 361)
        Me.TableLayoutPanel1.TabIndex = 31
        '
        'frmDuongDanHinh
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDuongDanHinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Duong dan hinh"
        CType(Me.grdHinh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvHinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdHinh As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvHinh As DevExpress.XtraGrid.Views.Grid.GridView
End Class
