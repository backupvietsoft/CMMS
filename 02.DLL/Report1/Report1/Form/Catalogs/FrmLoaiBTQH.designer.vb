<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoaiBTQH
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
        Me.gChild = New DevExpress.XtraEditors.GroupControl()
        Me.grdCapDuoi = New DevExpress.XtraGrid.GridControl()
        Me.grvCapDuoi = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pUpdate = New System.Windows.Forms.Panel()
        Me.btAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btExit = New DevExpress.XtraEditors.SimpleButton()
        Me.labTile = New System.Windows.Forms.Label()
        Me.gParent = New DevExpress.XtraEditors.GroupControl()
        Me.grdCapTren = New DevExpress.XtraGrid.GridControl()
        Me.grvCapTren = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gChild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gChild.SuspendLayout()
        CType(Me.grdCapDuoi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCapDuoi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pUpdate.SuspendLayout()
        CType(Me.gParent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gParent.SuspendLayout()
        CType(Me.grdCapTren, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCapTren, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gChild, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pUpdate, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.labTile, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gParent, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gChild
        '
        Me.gChild.Controls.Add(Me.grdCapDuoi)
        Me.gChild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gChild.Location = New System.Drawing.Point(445, 41)
        Me.gChild.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gChild.Name = "gChild"
        Me.gChild.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gChild.Size = New System.Drawing.Size(436, 478)
        Me.gChild.TabIndex = 3
        Me.gChild.Text = "Loại bảo trì cấp dưới"
        '
        'grdCapDuoi
        '
        Me.grdCapDuoi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCapDuoi.Location = New System.Drawing.Point(5, 24)
        Me.grdCapDuoi.LookAndFeel.SkinName = "Blue"
        Me.grdCapDuoi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdCapDuoi.MainView = Me.grvCapDuoi
        Me.grdCapDuoi.Name = "grdCapDuoi"
        Me.grdCapDuoi.Size = New System.Drawing.Size(426, 450)
        Me.grdCapDuoi.TabIndex = 4
        Me.grdCapDuoi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCapDuoi})
        '
        'grvCapDuoi
        '
        Me.grvCapDuoi.GridControl = Me.grdCapDuoi
        Me.grvCapDuoi.Name = "grvCapDuoi"
        Me.grvCapDuoi.OptionsCustomization.AllowGroup = False
        Me.grvCapDuoi.OptionsView.ShowGroupPanel = False
        '
        'pUpdate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pUpdate, 2)
        Me.pUpdate.Controls.Add(Me.btAdd)
        Me.pUpdate.Controls.Add(Me.btSave)
        Me.pUpdate.Controls.Add(Me.btCancel)
        Me.pUpdate.Controls.Add(Me.btExit)
        Me.pUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUpdate.Location = New System.Drawing.Point(3, 523)
        Me.pUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pUpdate.Name = "pUpdate"
        Me.pUpdate.Size = New System.Drawing.Size(878, 36)
        Me.pUpdate.TabIndex = 0
        '
        'btAdd
        '
        Me.btAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAdd.Location = New System.Drawing.Point(667, 2)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btAdd.Size = New System.Drawing.Size(104, 32)
        Me.btAdd.TabIndex = 5
        Me.btAdd.Text = "&Thêm/Sửa"
        '
        'btSave
        '
        Me.btSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSave.Location = New System.Drawing.Point(667, 2)
        Me.btSave.Name = "btSave"
        Me.btSave.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btSave.Size = New System.Drawing.Size(104, 32)
        Me.btSave.TabIndex = 2
        Me.btSave.Text = "&Ghi"
        Me.btSave.Visible = False
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.Location = New System.Drawing.Point(772, 2)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btCancel.Size = New System.Drawing.Size(104, 32)
        Me.btCancel.TabIndex = 1
        Me.btCancel.Text = "&Không Ghi"
        Me.btCancel.Visible = False
        '
        'btExit
        '
        Me.btExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExit.Location = New System.Drawing.Point(772, 2)
        Me.btExit.Name = "btExit"
        Me.btExit.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btExit.Size = New System.Drawing.Size(104, 32)
        Me.btExit.TabIndex = 0
        Me.btExit.Text = "Th&oát"
        '
        'labTile
        '
        Me.labTile.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.labTile, 2)
        Me.labTile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTile.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.labTile.ForeColor = System.Drawing.Color.Navy
        Me.labTile.Location = New System.Drawing.Point(3, 0)
        Me.labTile.Name = "labTile"
        Me.labTile.Size = New System.Drawing.Size(878, 39)
        Me.labTile.TabIndex = 1
        Me.labTile.Text = "ĐỊNH NGHĨA QUAN HỆ LOẠI BẢO TRÌ"
        Me.labTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gParent
        '
        Me.gParent.Controls.Add(Me.grdCapTren)
        Me.gParent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gParent.Location = New System.Drawing.Point(3, 41)
        Me.gParent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gParent.Name = "gParent"
        Me.gParent.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gParent.Size = New System.Drawing.Size(436, 478)
        Me.gParent.TabIndex = 2
        Me.gParent.Text = "Loại bảo trì cấp trên"
        '
        'grdCapTren
        '
        Me.grdCapTren.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCapTren.Location = New System.Drawing.Point(5, 24)
        Me.grdCapTren.LookAndFeel.SkinName = "Blue"
        Me.grdCapTren.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdCapTren.MainView = Me.grvCapTren
        Me.grdCapTren.Name = "grdCapTren"
        Me.grdCapTren.Size = New System.Drawing.Size(426, 450)
        Me.grdCapTren.TabIndex = 4
        Me.grdCapTren.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCapTren})
        '
        'grvCapTren
        '
        Me.grvCapTren.GridControl = Me.grdCapTren
        Me.grvCapTren.Name = "grvCapTren"
        Me.grvCapTren.OptionsCustomization.AllowGroup = False
        Me.grvCapTren.OptionsView.ShowGroupPanel = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Loại bảo trì cấp trên"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn1.HeaderText = "Loại bảo trì cấp dưới"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Loại bảo trì cấp trên"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Loại bảo trì cấp trên"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmLoaiBTQH
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLoaiBTQH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Quan hệ của các loại bảo trì"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gChild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gChild.ResumeLayout(False)
        CType(Me.grdCapDuoi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCapDuoi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pUpdate.ResumeLayout(False)
        CType(Me.gParent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gParent.ResumeLayout(False)
        CType(Me.grdCapTren, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCapTren, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gChild As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pUpdate As System.Windows.Forms.Panel
    Friend WithEvents labTile As System.Windows.Forms.Label
    Friend WithEvents gParent As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents grdCapTren As DevExpress.XtraGrid.GridControl
    Private WithEvents grvCapTren As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents btExit As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btAdd As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btCancel As DevExpress.XtraEditors.SimpleButton
    Private WithEvents grdCapDuoi As DevExpress.XtraGrid.GridControl
    Private WithEvents grvCapDuoi As DevExpress.XtraGrid.Views.Grid.GridView
End Class
