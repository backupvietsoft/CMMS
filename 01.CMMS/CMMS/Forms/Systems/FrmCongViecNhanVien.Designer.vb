<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCongViecNhanVien
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
        Me.btExit = New DevExpress.XtraEditors.SimpleButton()
        Me.grdDS = New DevExpress.XtraGrid.GridControl()
        Me.grvDS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btExit, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdDS, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btExit
        '
        Me.btExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btExit.Location = New System.Drawing.Point(777, 528)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(104, 30)
        Me.btExit.TabIndex = 1
        Me.btExit.Text = "Thoát"
        '
        'grdDS
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdDS, 2)
        Me.grdDS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDS.Location = New System.Drawing.Point(3, 3)
        Me.grdDS.LookAndFeel.SkinName = "Blue"
        Me.grdDS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdDS.MainView = Me.grvDS
        Me.grdDS.Name = "grdDS"
        Me.grdDS.Size = New System.Drawing.Size(878, 519)
        Me.grdDS.TabIndex = 99
        Me.grdDS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDS})
        '
        'grvDS
        '
        Me.grvDS.GridControl = Me.grdDS
        Me.grvDS.Name = "grvDS"
        Me.grvDS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvDS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvDS.OptionsBehavior.Editable = False
        Me.grvDS.OptionsLayout.Columns.AddNewColumns = False
        Me.grvDS.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvDS.OptionsView.ColumnAutoWidth = False
        Me.grvDS.OptionsView.EnableAppearanceEvenRow = True
        Me.grvDS.OptionsView.EnableAppearanceOddRow = True
        Me.grvDS.OptionsView.ShowGroupPanel = False
        '
        'FrmCongViecNhanVien
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCongViecNhanVien"
        Me.Text = "Cong Viec Nhan Vien Da Thuc Hien"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDS As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvDS As DevExpress.XtraGrid.Views.Grid.GridView
End Class
