<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonPhuTung
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
        Me.btnChapnhan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblLoaiPT = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTimMaCTTB = New DevExpress.XtraEditors.TextEdit()
        Me.BtnChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBoChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.grdPT = New DevExpress.XtraGrid.GridControl()
        Me.grvPT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkDanhmucPhuTung = New DevExpress.XtraEditors.CheckEdit()
        Me.cboLoaiPT = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTimMaCTTB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.chkDanhmucPhuTung.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoaiPT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChapnhan
        '
        Me.btnChapnhan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChapnhan.Location = New System.Drawing.Point(667, 3)
        Me.btnChapnhan.Name = "btnChapnhan"
        Me.btnChapnhan.Size = New System.Drawing.Size(104, 30)
        Me.btnChapnhan.TabIndex = 1
        Me.btnChapnhan.Text = "&Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Location = New System.Drawing.Point(772, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 1
        Me.btnThoat.Text = "&Thoát"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'LblLoaiPT
        '
        Me.LblLoaiPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.LblLoaiPT.AutoSize = True
        Me.LblLoaiPT.Location = New System.Drawing.Point(291, 6)
        Me.LblLoaiPT.Name = "LblLoaiPT"
        Me.LblLoaiPT.Size = New System.Drawing.Size(77, 13)
        Me.LblLoaiPT.TabIndex = 5
        Me.LblLoaiPT.Text = "Loại Phụ Tùng "
        Me.LblLoaiPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtTimMaCTTB)
        Me.Panel1.Controls.Add(Me.BtnChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.btnChapnhan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 523)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 35)
        Me.Panel1.TabIndex = 11
        '
        'txtTimMaCTTB
        '
        Me.txtTimMaCTTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTimMaCTTB.Location = New System.Drawing.Point(2, 7)
        Me.txtTimMaCTTB.Name = "txtTimMaCTTB"
        Me.txtTimMaCTTB.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtTimMaCTTB.Properties.Appearance.Options.UseForeColor = True
        Me.txtTimMaCTTB.Size = New System.Drawing.Size(240, 20)
        Me.txtTimMaCTTB.TabIndex = 90
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTatCa.Location = New System.Drawing.Point(457, 3)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa.TabIndex = 88
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(562, 3)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa.TabIndex = 89
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        '
        'grdPT
        '
        Me.grdPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPT.Location = New System.Drawing.Point(3, 42)
        Me.grdPT.MainView = Me.grvPT
        Me.grdPT.Name = "grdPT"
        Me.grdPT.Size = New System.Drawing.Size(878, 475)
        Me.grdPT.TabIndex = 70
        Me.grdPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPT})
        '
        'grvPT
        '
        Me.grvPT.GridControl = Me.grdPT
        Me.grvPT.Name = "grvPT"
        Me.grvPT.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.grdPT, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkDanhmucPhuTung)
        Me.Panel2.Controls.Add(Me.LblLoaiPT)
        Me.Panel2.Controls.Add(Me.cboLoaiPT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(878, 25)
        Me.Panel2.TabIndex = 71
        '
        'chkDanhmucPhuTung
        '
        Me.chkDanhmucPhuTung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDanhmucPhuTung.Location = New System.Drawing.Point(730, 4)
        Me.chkDanhmucPhuTung.Name = "chkDanhmucPhuTung"
        Me.chkDanhmucPhuTung.Properties.Caption = "ckDanhMucPhuTung"
        Me.chkDanhmucPhuTung.Size = New System.Drawing.Size(145, 18)
        Me.chkDanhmucPhuTung.TabIndex = 72
        '
        'cboLoaiPT
        '
        Me.cboLoaiPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cboLoaiPT.Location = New System.Drawing.Point(386, 2)
        Me.cboLoaiPT.Name = "cboLoaiPT"
        Me.cboLoaiPT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaiPT.Properties.NullText = ""
        Me.cboLoaiPT.Size = New System.Drawing.Size(145, 20)
        Me.cboLoaiPT.TabIndex = 71
        '
        'frmChonPhuTung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonPhuTung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn phụ tùng"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtTimMaCTTB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.chkDanhmucPhuTung.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoaiPT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnChapnhan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents LblLoaiPT As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBoChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkDanhmucPhuTung As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboLoaiPT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtTimMaCTTB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grdPT As DevExpress.XtraGrid.GridControl
    Public WithEvents grvPT As DevExpress.XtraGrid.Views.Grid.GridView
End Class
