<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonCongViecChoBTPN
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
        Me.LblChonCV = New System.Windows.Forms.Label()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBoChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TVw = New System.Windows.Forms.TreeView()
        Me.GrpChonBoPhan = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtGiatri = New DevExpress.XtraEditors.TextEdit()
        Me.GrpChonCV = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdCV = New DevExpress.XtraGrid.GridControl()
        Me.grvCV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CboLoaiCongViec = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpChonBoPhan.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpChonCV.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.grdCV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.CboLoaiCongViec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblChonCV
        '
        Me.LblChonCV.AutoSize = True
        Me.LblChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChonCV.Location = New System.Drawing.Point(232, 8)
        Me.LblChonCV.Name = "LblChonCV"
        Me.LblChonCV.Size = New System.Drawing.Size(114, 25)
        Me.LblChonCV.TabIndex = 26
        Me.LblChonCV.Text = "Loại công việc"
        Me.LblChonCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(451, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThucHien.Location = New System.Drawing.Point(346, 2)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(241, 2)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa.TabIndex = 87
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTatCa.Location = New System.Drawing.Point(136, 2)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa.TabIndex = 86
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TVw
        '
        Me.TVw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TVw.Location = New System.Drawing.Point(3, 3)
        Me.TVw.Name = "TVw"
        Me.TVw.Size = New System.Drawing.Size(290, 465)
        Me.TVw.TabIndex = 88
        '
        'GrpChonBoPhan
        '
        Me.GrpChonBoPhan.Controls.Add(Me.TableLayoutPanel2)
        Me.GrpChonBoPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonBoPhan.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonBoPhan.Location = New System.Drawing.Point(0, 0)
        Me.GrpChonBoPhan.Name = "GrpChonBoPhan"
        Me.GrpChonBoPhan.Size = New System.Drawing.Size(302, 518)
        Me.GrpChonBoPhan.TabIndex = 89
        Me.GrpChonBoPhan.TabStop = False
        Me.GrpChonBoPhan.Text = "Chọn bộ phận "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtGiatri, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TVw, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(296, 498)
        Me.TableLayoutPanel2.TabIndex = 89
        '
        'txtGiatri
        '
        Me.txtGiatri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGiatri.Location = New System.Drawing.Point(3, 474)
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtGiatri.Properties.Appearance.Options.UseForeColor = True
        Me.txtGiatri.Size = New System.Drawing.Size(290, 20)
        Me.txtGiatri.TabIndex = 89
        '
        'GrpChonCV
        '
        Me.GrpChonCV.Controls.Add(Me.TableLayoutPanel3)
        Me.GrpChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonCV.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonCV.Location = New System.Drawing.Point(0, 0)
        Me.GrpChonCV.Name = "GrpChonCV"
        Me.GrpChonCV.Size = New System.Drawing.Size(570, 518)
        Me.GrpChonCV.TabIndex = 90
        Me.GrpChonCV.TabStop = False
        Me.GrpChonCV.Text = "Chọn công việc"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.grdCV, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(564, 498)
        Me.TableLayoutPanel3.TabIndex = 29
        '
        'grdCV
        '
        Me.grdCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCV.Location = New System.Drawing.Point(3, 3)
        Me.grdCV.MainView = Me.grvCV
        Me.grdCV.Name = "grdCV"
        Me.grdCV.Size = New System.Drawing.Size(558, 454)
        Me.grdCV.TabIndex = 28
        Me.grdCV.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCV})
        '
        'grvCV
        '
        Me.grvCV.GridControl = Me.grdCV
        Me.grvCV.Name = "grvCV"
        Me.grvCV.OptionsView.ColumnAutoWidth = False
        Me.grvCV.OptionsView.EnableAppearanceEvenRow = True
        Me.grvCV.OptionsView.EnableAppearanceOddRow = True
        Me.grvCV.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnChonTatCa)
        Me.Panel2.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel2.Controls.Add(Me.BtnThucHien)
        Me.Panel2.Controls.Add(Me.BtnThoat)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 463)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(558, 32)
        Me.Panel2.TabIndex = 92
        '
        'CboLoaiCongViec
        '
        Me.CboLoaiCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboLoaiCongViec.Location = New System.Drawing.Point(352, 11)
        Me.CboLoaiCongViec.Name = "CboLoaiCongViec"
        Me.CboLoaiCongViec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboLoaiCongViec.Properties.LookAndFeel.SkinName = "Blue"
        Me.CboLoaiCongViec.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CboLoaiCongViec.Properties.NullText = ""
        Me.CboLoaiCongViec.Size = New System.Drawing.Size(299, 20)
        Me.CboLoaiCongViec.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainerControl1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonCV, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CboLoaiCongViec, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 92
        '
        'SplitContainerControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.SplitContainerControl1, 4)
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 40)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GrpChonBoPhan)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GrpChonCV)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(878, 518)
        Me.SplitContainerControl1.SplitterPosition = 302
        Me.SplitContainerControl1.TabIndex = 93
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'FrmChonCongViecChoBTPN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "FrmChonCongViecChoBTPN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chọn công việc cho bảo trì phòng ngừa"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpChonBoPhan.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpChonCV.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.grdCV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.CboLoaiCongViec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CboLoaiCongViec As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LblChonCV As System.Windows.Forms.Label
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBoChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpChonCV As System.Windows.Forms.GroupBox
    Friend WithEvents GrpChonBoPhan As System.Windows.Forms.GroupBox
    Friend WithEvents TVw As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grdCV As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtGiatri As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class
