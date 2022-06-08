<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonphutung_thaythe
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
        Me.components = New System.ComponentModel.Container()
        Me.LblTieuDe = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.btnALL = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNotALL = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSearch = New DevExpress.XtraEditors.TextEdit()
        Me.grdPTung = New DevExpress.XtraGrid.GridControl()
        Me.grvPTung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPTung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPTung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTieuDe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LblTieuDe, 6)
        Me.LblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieuDe.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.LblTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.LblTieuDe.Name = "LblTieuDe"
        Me.LblTieuDe.Size = New System.Drawing.Size(878, 44)
        Me.LblTieuDe.TabIndex = 7
        Me.LblTieuDe.Text = "CHỌN PHỤ TÙNG THAY THẾ"
        Me.LblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnThoat, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExecute, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnALL, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNotALL, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSearch, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grdPTung, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnThoat.Location = New System.Drawing.Point(777, 528)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        '
        'btnExecute
        '
        Me.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExecute.Location = New System.Drawing.Point(667, 528)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(104, 30)
        Me.btnExecute.TabIndex = 84
        Me.btnExecute.Text = "Thực hiện"
        '
        'btnALL
        '
        Me.btnALL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnALL.Location = New System.Drawing.Point(447, 528)
        Me.btnALL.Name = "btnALL"
        Me.btnALL.Size = New System.Drawing.Size(104, 30)
        Me.btnALL.TabIndex = 86
        Me.btnALL.Text = "Chọn tất cả"
        '
        'btnNotALL
        '
        Me.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNotALL.Location = New System.Drawing.Point(557, 528)
        Me.btnNotALL.Name = "btnNotALL"
        Me.btnNotALL.Size = New System.Drawing.Size(104, 30)
        Me.btnNotALL.TabIndex = 87
        Me.btnNotALL.Text = "Bỏ chọn"
        '
        'txtSearch
        '
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtSearch.Location = New System.Drawing.Point(3, 538)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSearch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtSearch.Size = New System.Drawing.Size(179, 20)
        Me.txtSearch.TabIndex = 88
        '
        'grdPTung
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdPTung, 6)
        Me.grdPTung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPTung.Location = New System.Drawing.Point(3, 51)
        Me.grdPTung.MainView = Me.grvPTung
        Me.grdPTung.Name = "grdPTung"
        Me.grdPTung.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3})
        Me.grdPTung.Size = New System.Drawing.Size(878, 471)
        Me.grdPTung.TabIndex = 89
        Me.grdPTung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPTung, Me.GridView4})
        '
        'grvPTung
        '
        Me.grvPTung.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvPTung.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvPTung.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvPTung.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvPTung.GridControl = Me.grdPTung
        Me.grvPTung.Name = "grvPTung"
        Me.grvPTung.OptionsView.ColumnAutoWidth = False
        Me.grvPTung.OptionsView.EnableAppearanceEvenRow = True
        Me.grvPTung.OptionsView.EnableAppearanceOddRow = True
        Me.grvPTung.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdPTung
        Me.GridView4.Name = "GridView4"
        '
        'frmChonphutung_thaythe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonphutung_thaythe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonphutung_thaythe"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.txtSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPTung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPTung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTieuDe As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnALL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNotALL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Public WithEvents txtSearch As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grdPTung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPTung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
