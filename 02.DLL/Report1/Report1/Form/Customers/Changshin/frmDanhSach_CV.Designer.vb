<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSach_CV
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_TKThongSo = New DevExpress.XtraEditors.TextEdit()
        Me.txt_TKCongViec = New DevExpress.XtraEditors.TextEdit()
        Me.btnNotAllGSTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAllGSTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonCongViec = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GrpDanhmucthongso = New DevExpress.XtraEditors.GroupControl()
        Me.Grdthongso = New DevExpress.XtraGrid.GridControl()
        Me.Grvthongso = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpDanhsachCV = New DevExpress.XtraEditors.GroupControl()
        Me.Grdcongviec = New DevExpress.XtraGrid.GridControl()
        Me.Grvcongviec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.PanelControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelControl1.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        CType(Me.txt_TKThongSo.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txt_TKCongViec.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SplitContainerControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainerControl1.SuspendLayout
        CType(Me.GrpDanhmucthongso,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GrpDanhmucthongso.SuspendLayout
        CType(Me.Grdthongso,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Grvthongso,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grpDanhsachCV,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpDanhsachCV.SuspendLayout
        CType(Me.Grdcongviec,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Grvcongviec,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelControl1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainerControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TableLayoutPanel2)
        Me.PanelControl1.Controls.Add(Me.btnNotAllGSTT)
        Me.PanelControl1.Controls.Add(Me.btnAllGSTT)
        Me.PanelControl1.Controls.Add(Me.btnThoat)
        Me.PanelControl1.Controls.Add(Me.BtnChonCongViec)
        Me.PanelControl1.Controls.Add(Me.btnThucHien)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(3, 526)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(878, 32)
        Me.PanelControl1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.Controls.Add(Me.txt_TKThongSo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_TKCongViec, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(325, 28)
        Me.TableLayoutPanel2.TabIndex = 22
        '
        'txt_TKThongSo
        '
        Me.txt_TKThongSo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_TKThongSo.Location = New System.Drawing.Point(3, 3)
        Me.txt_TKThongSo.Name = "txt_TKThongSo"
        Me.txt_TKThongSo.Size = New System.Drawing.Size(156, 20)
        Me.txt_TKThongSo.TabIndex = 0
        '
        'txt_TKCongViec
        '
        Me.txt_TKCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_TKCongViec.Location = New System.Drawing.Point(165, 3)
        Me.txt_TKCongViec.Name = "txt_TKCongViec"
        Me.txt_TKCongViec.Size = New System.Drawing.Size(157, 20)
        Me.txt_TKCongViec.TabIndex = 0
        '
        'btnNotAllGSTT
        '
        Me.btnNotAllGSTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnNotAllGSTT.Location = New System.Drawing.Point(471, 1)
        Me.btnNotAllGSTT.LookAndFeel.SkinName = "Blue"
        Me.btnNotAllGSTT.LookAndFeel.UseDefaultLookAndFeel = false
        Me.btnNotAllGSTT.Name = "btnNotAllGSTT"
        Me.btnNotAllGSTT.Size = New System.Drawing.Size(104, 30)
        Me.btnNotAllGSTT.TabIndex = 20
        Me.btnNotAllGSTT.Text = "btnUnSelect"
        '
        'btnAllGSTT
        '
        Me.btnAllGSTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnAllGSTT.Location = New System.Drawing.Point(366, 1)
        Me.btnAllGSTT.LookAndFeel.SkinName = "Blue"
        Me.btnAllGSTT.LookAndFeel.UseDefaultLookAndFeel = false
        Me.btnAllGSTT.Name = "btnAllGSTT"
        Me.btnAllGSTT.Size = New System.Drawing.Size(104, 30)
        Me.btnAllGSTT.TabIndex = 21
        Me.btnAllGSTT.Text = "btnChon"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Location = New System.Drawing.Point(778, 1)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(100, 30)
        Me.btnThoat.TabIndex = 19
        Me.btnThoat.Text = "Thoat"
        '
        'BtnChonCongViec
        '
        Me.BtnChonCongViec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.BtnChonCongViec.Location = New System.Drawing.Point(576, 1)
        Me.BtnChonCongViec.Name = "BtnChonCongViec"
        Me.BtnChonCongViec.Size = New System.Drawing.Size(100, 30)
        Me.BtnChonCongViec.TabIndex = 18
        Me.BtnChonCongViec.Text = "Chọn công việc"
        '
        'btnThucHien
        '
        Me.btnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnThucHien.Location = New System.Drawing.Point(677, 1)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(100, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 11)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GrpDanhmucthongso)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grpDanhsachCV)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(878, 509)
        Me.SplitContainerControl1.SplitterPosition = 327
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GrpDanhmucthongso
        '
        Me.GrpDanhmucthongso.Controls.Add(Me.Grdthongso)
        Me.GrpDanhmucthongso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhmucthongso.Location = New System.Drawing.Point(0, 0)
        Me.GrpDanhmucthongso.Name = "GrpDanhmucthongso"
        Me.GrpDanhmucthongso.Size = New System.Drawing.Size(327, 509)
        Me.GrpDanhmucthongso.TabIndex = 2
        Me.GrpDanhmucthongso.Text = "GrpDanhmucthongso"
        '
        'Grdthongso
        '
        Me.Grdthongso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grdthongso.Location = New System.Drawing.Point(2, 22)
        Me.Grdthongso.MainView = Me.Grvthongso
        Me.Grdthongso.Name = "Grdthongso"
        Me.Grdthongso.Size = New System.Drawing.Size(323, 485)
        Me.Grdthongso.TabIndex = 0
        Me.Grdthongso.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Grvthongso})
        '
        'Grvthongso
        '
        Me.Grvthongso.GridControl = Me.Grdthongso
        Me.Grvthongso.Name = "Grvthongso"
        Me.Grvthongso.OptionsView.ShowGroupPanel = false
        '
        'grpDanhsachCV
        '
        Me.grpDanhsachCV.Controls.Add(Me.Grdcongviec)
        Me.grpDanhsachCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachCV.Location = New System.Drawing.Point(0, 0)
        Me.grpDanhsachCV.Name = "grpDanhsachCV"
        Me.grpDanhsachCV.Size = New System.Drawing.Size(545, 509)
        Me.grpDanhsachCV.TabIndex = 2
        Me.grpDanhsachCV.Text = "grpDanhsachCV"
        '
        'Grdcongviec
        '
        Me.Grdcongviec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grdcongviec.Location = New System.Drawing.Point(2, 22)
        Me.Grdcongviec.MainView = Me.Grvcongviec
        Me.Grdcongviec.Name = "Grdcongviec"
        Me.Grdcongviec.Size = New System.Drawing.Size(541, 485)
        Me.Grdcongviec.TabIndex = 0
        Me.Grdcongviec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Grvcongviec})
        '
        'Grvcongviec
        '
        Me.Grvcongviec.GridControl = Me.Grdcongviec
        Me.Grvcongviec.Name = "Grvcongviec"
        Me.Grvcongviec.OptionsView.ShowGroupPanel = false
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'frmDanhSach_CV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmDanhSach_CV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDanhSach_CV"
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.PanelControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelControl1.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        CType(Me.txt_TKThongSo.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txt_TKCongViec.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SplitContainerControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl1.ResumeLayout(false)
        CType(Me.GrpDanhmucthongso,System.ComponentModel.ISupportInitialize).EndInit
        Me.GrpDanhmucthongso.ResumeLayout(false)
        CType(Me.Grdthongso,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Grvthongso,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grpDanhsachCV,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpDanhsachCV.ResumeLayout(false)
        CType(Me.Grdcongviec,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Grvcongviec,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachCV As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Grdcongviec As DevExpress.XtraGrid.GridControl
    Friend WithEvents Grvcongviec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GrpDanhmucthongso As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Grdthongso As DevExpress.XtraGrid.GridControl
    Friend WithEvents Grvthongso As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnChonCongViec As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnNotAllGSTT As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnAllGSTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txt_TKThongSo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_TKCongViec As DevExpress.XtraEditors.TextEdit
End Class
