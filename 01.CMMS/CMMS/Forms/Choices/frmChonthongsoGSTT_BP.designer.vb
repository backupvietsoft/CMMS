<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonthongsoGSTT_BP
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
        Me.btnThuchien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBochon = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBophan = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtGiatri = New DevExpress.XtraEditors.TextEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdTS = New DevExpress.XtraGrid.GridControl()
        Me.grvTS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboBoPhan = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.cboBoPhan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnThuchien
        '
        Me.btnThuchien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThuchien.Location = New System.Drawing.Point(671, 2)
        Me.btnThuchien.Name = "btnThuchien"
        Me.btnThuchien.Size = New System.Drawing.Size(104, 30)
        Me.btnThuchien.TabIndex = 3
        Me.btnThuchien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Location = New System.Drawing.Point(776, 2)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 4
        Me.btnThoat.Text = "Thoát"
        '
        'btnChonAll
        '
        Me.btnChonAll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonAll.Location = New System.Drawing.Point(461, 2)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(104, 30)
        Me.btnChonAll.TabIndex = 5
        Me.btnChonAll.Text = "Chọn tất cả"
        '
        'btnBochon
        '
        Me.btnBochon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBochon.Location = New System.Drawing.Point(566, 2)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(104, 30)
        Me.btnBochon.TabIndex = 6
        Me.btnBochon.Text = "Bỏ chọn"
        '
        'lblBophan
        '
        Me.lblBophan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblBophan.AutoSize = True
        Me.lblBophan.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblBophan.Location = New System.Drawing.Point(336, 5)
        Me.lblBophan.Name = "lblBophan"
        Me.lblBophan.Size = New System.Drawing.Size(46, 13)
        Me.lblBophan.TabIndex = 7
        Me.lblBophan.Text = "Bộ phận"
        Me.lblBophan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'txtGiatri
        '
        Me.txtGiatri.Location = New System.Drawing.Point(2, 6)
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Size = New System.Drawing.Size(200, 20)
        Me.txtGiatri.TabIndex = 93
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnChonAll)
        Me.Panel1.Controls.Add(Me.btnBochon)
        Me.Panel1.Controls.Add(Me.btnThuchien)
        Me.Panel1.Controls.Add(Me.txtGiatri)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 526)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 34)
        Me.Panel1.TabIndex = 94
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.grdTS, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel2.TabIndex = 96
        '
        'grdTS
        '
        Me.grdTS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTS.Location = New System.Drawing.Point(3, 41)
        Me.grdTS.MainView = Me.grvTS
        Me.grdTS.Name = "grdTS"
        Me.grdTS.Size = New System.Drawing.Size(878, 481)
        Me.grdTS.TabIndex = 71
        Me.grdTS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTS})
        '
        'grvTS
        '
        Me.grvTS.GridControl = Me.grdTS
        Me.grvTS.Name = "grvTS"
        Me.grvTS.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cboBoPhan)
        Me.Panel2.Controls.Add(Me.lblBophan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(878, 24)
        Me.Panel2.TabIndex = 72
        '
        'cboBoPhan
        '
        Me.cboBoPhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cboBoPhan.Location = New System.Drawing.Point(397, 2)
        Me.cboBoPhan.Name = "cboBoPhan"
        Me.cboBoPhan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBoPhan.Properties.NullText = ""
        Me.cboBoPhan.Size = New System.Drawing.Size(188, 20)
        Me.cboBoPhan.TabIndex = 8
        '
        'frmChonthongsoGSTT_BP
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonthongsoGSTT_BP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn thông số giám sát tình trạng"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.grdTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvTS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.cboBoPhan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThuchien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBochon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblBophan As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtGiatri As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents grdTS As DevExpress.XtraGrid.GridControl
    Public WithEvents grvTS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboBoPhan As DevExpress.XtraEditors.LookUpEdit
End Class
