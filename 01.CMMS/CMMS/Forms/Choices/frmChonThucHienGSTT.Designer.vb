<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonThucHienGSTT
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gdTSGSTT = New DevExpress.XtraGrid.GridControl()
        Me.gvTSGSTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMay = New DevExpress.XtraEditors.TextEdit()
        Me.lblMay = New DevExpress.XtraEditors.LabelControl()
        Me.lblCachThucHien = New DevExpress.XtraEditors.LabelControl()
        Me.cboCTH = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblMSPBT = New DevExpress.XtraEditors.LabelControl()
        Me.cboPBT = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblCNThucHien = New DevExpress.XtraEditors.LabelControl()
        Me.cboCNTHien = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.gdTSGSTT,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gvTSGSTT,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tableLayoutPanel3.SuspendLayout
        CType(Me.txtMay.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboCTH.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboPBT.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboCNTHien.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66666!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66666!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel1.Controls.Add(Me.gdTSGSTT, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tableLayoutPanel3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCachThucHien, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCTH, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMSPBT, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPBT, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCNThucHien, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCNTHien, 2, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gdTSGSTT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gdTSGSTT, 6)
        Me.gdTSGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdTSGSTT.Location = New System.Drawing.Point(3, 87)
        Me.gdTSGSTT.MainView = Me.gvTSGSTT
        Me.gdTSGSTT.Name = "gdTSGSTT"
        Me.gdTSGSTT.Size = New System.Drawing.Size(878, 429)
        Me.gdTSGSTT.TabIndex = 29
        Me.gdTSGSTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTSGSTT})
        '
        'gvTSGSTT
        '
        Me.gvTSGSTT.GridControl = Me.gdTSGSTT
        Me.gvTSGSTT.HorzScrollStep = 5
        Me.gvTSGSTT.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gvTSGSTT.Name = "gvTSGSTT"
        Me.gvTSGSTT.OptionsView.ColumnAutoWidth = false
        Me.gvTSGSTT.OptionsView.EnableAppearanceEvenRow = true
        Me.gvTSGSTT.OptionsView.EnableAppearanceOddRow = true
        Me.gvTSGSTT.OptionsView.ShowGroupPanel = false
        '
        'tableLayoutPanel3
        '
        Me.tableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.tableLayoutPanel3, 6)
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel3.Controls.Add(Me.btnThoat, 2, 0)
        Me.tableLayoutPanel3.Controls.Add(Me.btnExecute, 1, 0)
        Me.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel3.Location = New System.Drawing.Point(3, 522)
        Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
        Me.tableLayoutPanel3.RowCount = 1
        Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel3.Size = New System.Drawing.Size(878, 36)
        Me.tableLayoutPanel3.TabIndex = 27
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(771, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 10
        Me.btnThoat.Text = "Thoát"
        '
        'btnExecute
        '
        Me.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExecute.Location = New System.Drawing.Point(661, 3)
        Me.btnExecute.LookAndFeel.SkinName = "Blue"
        Me.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(104, 30)
        Me.btnExecute.TabIndex = 9
        Me.btnExecute.Text = "Thực hiện"
        '
        'txtMay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtMay, 3)
        Me.txtMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMay.Location = New System.Drawing.Point(201, 12)
        Me.txtMay.Name = "txtMay"
        Me.txtMay.Size = New System.Drawing.Size(630, 20)
        Me.txtMay.TabIndex = 28
        '
        'lblMay
        '
        Me.lblMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMay.Location = New System.Drawing.Point(51, 12)
        Me.lblMay.Name = "lblMay"
        Me.lblMay.Size = New System.Drawing.Size(144, 19)
        Me.lblMay.TabIndex = 26
        Me.lblMay.Text = "lblMay"
        '
        'lblCachThucHien
        '
        Me.lblCachThucHien.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCachThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCachThucHien.Location = New System.Drawing.Point(51, 37)
        Me.lblCachThucHien.Name = "lblCachThucHien"
        Me.lblCachThucHien.Size = New System.Drawing.Size(144, 19)
        Me.lblCachThucHien.TabIndex = 26
        Me.lblCachThucHien.Text = "lblCachThucHien"
        '
        'cboCTH
        '
        Me.cboCTH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCTH.EditValue = ""
        Me.cboCTH.Location = New System.Drawing.Point(201, 37)
        Me.cboCTH.Name = "cboCTH"
        Me.cboCTH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCTH.Properties.NullText = ""
        Me.cboCTH.Size = New System.Drawing.Size(237, 20)
        Me.cboCTH.TabIndex = 25
        '
        'lblMSPBT
        '
        Me.lblMSPBT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMSPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSPBT.Location = New System.Drawing.Point(444, 37)
        Me.lblMSPBT.Name = "lblMSPBT"
        Me.lblMSPBT.Size = New System.Drawing.Size(144, 19)
        Me.lblMSPBT.TabIndex = 26
        Me.lblMSPBT.Text = "lblMSPBT"
        '
        'cboPBT
        '
        Me.cboPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPBT.EditValue = ""
        Me.cboPBT.Location = New System.Drawing.Point(594, 37)
        Me.cboPBT.Name = "cboPBT"
        Me.cboPBT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPBT.Properties.NullText = ""
        Me.cboPBT.Size = New System.Drawing.Size(237, 20)
        Me.cboPBT.TabIndex = 25
        '
        'lblCNThucHien
        '
        Me.lblCNThucHien.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCNThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCNThucHien.Location = New System.Drawing.Point(51, 62)
        Me.lblCNThucHien.Name = "lblCNThucHien"
        Me.lblCNThucHien.Size = New System.Drawing.Size(144, 19)
        Me.lblCNThucHien.TabIndex = 26
        Me.lblCNThucHien.Text = "lblCNThucHien"
        '
        'cboCNTHien
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboCNTHien, 3)
        Me.cboCNTHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCNTHien.EditValue = ""
        Me.cboCNTHien.Location = New System.Drawing.Point(201, 62)
        Me.cboCNTHien.Name = "cboCNTHien"
        Me.cboCNTHien.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCNTHien.Properties.NullText = ""
        Me.cboCNTHien.Size = New System.Drawing.Size(630, 20)
        Me.cboCNTHien.TabIndex = 25
        '
        'frmChonThucHienGSTT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmChonThucHienGSTT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonThucHienGSTT"
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.gdTSGSTT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gvTSGSTT,System.ComponentModel.ISupportInitialize).EndInit
        Me.tableLayoutPanel3.ResumeLayout(false)
        CType(Me.txtMay.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboCTH.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboPBT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboCNTHien.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblCachThucHien As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCTH As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents tableLayoutPanel3 As TableLayoutPanel
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblMSPBT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPBT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblCNThucHien As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCNTHien As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblMay As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtMay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gdTSGSTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTSGSTT As DevExpress.XtraGrid.Views.Grid.GridView
End Class
