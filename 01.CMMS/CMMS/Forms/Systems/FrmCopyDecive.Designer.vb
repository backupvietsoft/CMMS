<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopyDecive
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
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.grdMay = New DevExpress.XtraGrid.GridControl()
        Me.grvMay = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNhomTB = New DevExpress.XtraEditors.TextEdit()
        Me.btExit = New DevExpress.XtraEditors.SimpleButton()
        Me.optOption = New DevExpress.XtraEditors.RadioGroup()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtNhomTB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optOption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.optOption, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdMay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 480)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.Text = "Thiết bị đích"
        '
        'grdMay
        '
        Me.grdMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMay.Location = New System.Drawing.Point(2, 22)
        Me.grdMay.MainView = Me.grvMay
        Me.grdMay.Name = "grdMay"
        Me.grdMay.Size = New System.Drawing.Size(874, 456)
        Me.grdMay.TabIndex = 84
        Me.grdMay.Tag = ""
        Me.grdMay.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMay, Me.GridView2, Me.GridView1})
        '
        'grvMay
        '
        Me.grvMay.GridControl = Me.grdMay
        Me.grvMay.Name = "grvMay"
        Me.grvMay.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvMay.OptionsLayout.StoreAllOptions = True
        Me.grvMay.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdMay
        Me.GridView2.Name = "GridView2"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdMay
        Me.GridView1.Name = "GridView1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCopy)
        Me.Panel1.Controls.Add(Me.txtNhomTB)
        Me.Panel1.Controls.Add(Me.btExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 526)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 32)
        Me.Panel1.TabIndex = 7
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(668, 1)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(104, 30)
        Me.btnCopy.TabIndex = 1
        Me.btnCopy.Text = "&Thực hiện"
        '
        'txtNhomTB
        '
        Me.txtNhomTB.Location = New System.Drawing.Point(5, 6)
        Me.txtNhomTB.Name = "txtNhomTB"
        Me.txtNhomTB.Size = New System.Drawing.Size(293, 20)
        Me.txtNhomTB.TabIndex = 2
        '
        'btExit
        '
        Me.btExit.Location = New System.Drawing.Point(773, 1)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(104, 30)
        Me.btExit.TabIndex = 0
        Me.btExit.Text = "Th&oát"
        '
        'optOption
        '
        Me.optOption.Dock = System.Windows.Forms.DockStyle.Left
        Me.optOption.EditValue = "optChuaNT"
        Me.optOption.Location = New System.Drawing.Point(3, 11)
        Me.optOption.Name = "optOption"
        Me.optOption.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.optOption.Properties.Appearance.Options.UseBackColor = True
        Me.optOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.optOption.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.optOption.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optChon0", "optChon0"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optChon1", "optChon1")})
        Me.optOption.Size = New System.Drawing.Size(391, 23)
        Me.optOption.TabIndex = 24
        '
        'FrmCopyDecive
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmCopyDecive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtNhomTB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optOption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grdMay As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMay As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNhomTB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents optOption As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
