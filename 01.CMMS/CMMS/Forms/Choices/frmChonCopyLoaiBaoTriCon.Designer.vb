<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonCopyLoaiBaoTriCon
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
        Me.grdLoaiBaoTri = New DevExpress.XtraGrid.GridControl
        Me.grvLoaiBaoTri = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton
        Me.lblLoaiBaoTriCT = New System.Windows.Forms.Label
        Me.lblLoaiBTCT = New System.Windows.Forms.Label
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdLoaiBaoTri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvLoaiBaoTri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.03743!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.96257!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdLoaiBaoTri, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(402, 419)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'grdLoaiBaoTri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdLoaiBaoTri, 4)
        Me.grdLoaiBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLoaiBaoTri.Location = New System.Drawing.Point(3, 49)
        Me.grdLoaiBaoTri.MainView = Me.grvLoaiBaoTri
        Me.grdLoaiBaoTri.Name = "grdLoaiBaoTri"
        Me.grdLoaiBaoTri.Size = New System.Drawing.Size(396, 332)
        Me.grdLoaiBaoTri.TabIndex = 2
        Me.grdLoaiBaoTri.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvLoaiBaoTri})
        '
        'grvLoaiBaoTri
        '
        Me.grvLoaiBaoTri.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvLoaiBaoTri.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvLoaiBaoTri.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvLoaiBaoTri.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvLoaiBaoTri.GridControl = Me.grdLoaiBaoTri
        Me.grvLoaiBaoTri.Name = "grvLoaiBaoTri"
        Me.grvLoaiBaoTri.OptionsView.ColumnAutoWidth = False
        Me.grvLoaiBaoTri.OptionsView.EnableAppearanceEvenRow = True
        Me.grvLoaiBaoTri.OptionsView.EnableAppearanceOddRow = True
        Me.grvLoaiBaoTri.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnVideo, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnHelp, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLoaiBaoTriCT, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLoaiBTCT, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(396, 32)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(368, 1)
        Me.btnVideo.LookAndFeel.SkinName = "Blue"
        Me.btnVideo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(27, 30)
        Me.btnVideo.TabIndex = 96
        Me.btnVideo.Tag = "CMMS!frmChonCopyLoaiBaoTriCon"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(339, 1)
        Me.btnHelp.LookAndFeel.SkinName = "Blue"
        Me.btnHelp.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(27, 30)
        Me.btnHelp.TabIndex = 97
        Me.btnHelp.Tag = "CMMS!frmChonCopyLoaiBaoTriCon"
        '
        'lblLoaiBaoTriCT
        '
        Me.lblLoaiBaoTriCT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiBaoTriCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoaiBaoTriCT.Location = New System.Drawing.Point(3, 0)
        Me.lblLoaiBaoTriCT.Name = "lblLoaiBaoTriCT"
        Me.lblLoaiBaoTriCT.Size = New System.Drawing.Size(113, 32)
        Me.lblLoaiBaoTriCT.TabIndex = 6
        Me.lblLoaiBaoTriCT.Text = "Label1"
        Me.lblLoaiBaoTriCT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLoaiBTCT
        '
        Me.lblLoaiBTCT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiBTCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoaiBTCT.Location = New System.Drawing.Point(122, 0)
        Me.lblLoaiBTCT.Name = "lblLoaiBTCT"
        Me.lblLoaiBTCT.Size = New System.Drawing.Size(213, 32)
        Me.lblLoaiBTCT.TabIndex = 7
        Me.lblLoaiBTCT.Text = "Label2"
        Me.lblLoaiBTCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Image = Global.My.Resources.Resources.btnthuchien
        Me.btnThucHien.Location = New System.Drawing.Point(189, 387)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(108, 29)
        Me.btnThucHien.TabIndex = 4
        Me.btnThucHien.Text = "btnThucHien"
        '
        'btnThoat
        '
        Me.btnThoat.Image = Global.My.Resources.Resources.btnthoat
        Me.btnThoat.Location = New System.Drawing.Point(303, 387)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(96, 29)
        Me.btnThoat.TabIndex = 4
        Me.btnThoat.Text = "btnThoat"
        '
        'frmChonCopyLoaiBaoTriCon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(402, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmChonCopyLoaiBaoTriCon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonCopyLoaiBaoTriCon"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdLoaiBaoTri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvLoaiBaoTri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdLoaiBaoTri As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvLoaiBaoTri As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblLoaiBaoTriCT As Label
    Friend WithEvents lblLoaiBTCT As Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
End Class
