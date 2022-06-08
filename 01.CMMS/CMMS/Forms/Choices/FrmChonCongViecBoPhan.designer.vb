<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChonCongViecBoPhan
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LblChonCV = New System.Windows.Forms.Label()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBoChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtGiatri = New DevExpress.XtraEditors.TextEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboLoaithietbi = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboLoaiCV = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLoaithietbi = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCongviec = New DevExpress.XtraGrid.GridControl()
        Me.grvCongviec = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cboLoaithietbi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoaiCV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCongviec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCongviec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblChonCV
        '
        Me.LblChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChonCV.Location = New System.Drawing.Point(153, 8)
        Me.LblChonCV.Name = "LblChonCV"
        Me.LblChonCV.Size = New System.Drawing.Size(104, 25)
        Me.LblChonCV.TabIndex = 26
        Me.LblChonCV.Text = "Loại công việc"
        Me.LblChonCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(774, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThucHien.Location = New System.Drawing.Point(669, 0)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(564, 0)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa.TabIndex = 87
        Me.BtnBoChonTatCa.Text = "Bỏ chọn"
        Me.BtnBoChonTatCa.Visible = False
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTatCa.Location = New System.Drawing.Point(459, 0)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa.TabIndex = 86
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        Me.BtnChonTatCa.Visible = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'txtGiatri
        '
        Me.txtGiatri.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGiatri.Location = New System.Drawing.Point(0, 10)
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Size = New System.Drawing.Size(158, 20)
        Me.txtGiatri.TabIndex = 89
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaithietbi, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonCV, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiCV, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaithietbi, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.grdCongviec, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 92
        '
        'cboLoaithietbi
        '
        Me.cboLoaithietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaithietbi.Location = New System.Drawing.Point(555, 11)
        Me.cboLoaithietbi.Name = "cboLoaithietbi"
        Me.cboLoaithietbi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaithietbi.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoaithietbi.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoaithietbi.Properties.NullText = ""
        Me.cboLoaithietbi.Size = New System.Drawing.Size(176, 20)
        Me.cboLoaithietbi.TabIndex = 95
        '
        'cboLoaiCV
        '
        Me.cboLoaiCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiCV.Location = New System.Drawing.Point(263, 11)
        Me.cboLoaiCV.Name = "cboLoaiCV"
        Me.cboLoaiCV.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaiCV.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoaiCV.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoaiCV.Properties.NullText = ""
        Me.cboLoaiCV.Size = New System.Drawing.Size(176, 20)
        Me.cboLoaiCV.TabIndex = 95
        '
        'lblLoaithietbi
        '
        Me.lblLoaithietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaithietbi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoaithietbi.Location = New System.Drawing.Point(445, 8)
        Me.lblLoaithietbi.Name = "lblLoaithietbi"
        Me.lblLoaithietbi.Size = New System.Drawing.Size(104, 25)
        Me.lblLoaithietbi.TabIndex = 26
        Me.lblLoaithietbi.Text = "Loại thiết bị"
        Me.lblLoaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.txtGiatri)
        Me.Panel1.Controls.Add(Me.BtnChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnThucHien)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 528)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 30)
        Me.Panel1.TabIndex = 92
        '
        'grdCongviec
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdCongviec, 6)
        Me.grdCongviec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCongviec.Location = New System.Drawing.Point(3, 40)
        Me.grdCongviec.MainView = Me.grvCongviec
        Me.grdCongviec.Name = "grdCongviec"
        Me.grdCongviec.Size = New System.Drawing.Size(878, 482)
        Me.grdCongviec.TabIndex = 93
        Me.grdCongviec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCongviec})
        '
        'grvCongviec
        '
        Me.grvCongviec.GridControl = Me.grdCongviec
        Me.grvCongviec.Name = "grvCongviec"
        Me.grvCongviec.OptionsView.ShowGroupPanel = False
        '
        'FrmChonCongViecBoPhan
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "FrmChonCongViecBoPhan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn công việc cho bảo trì phòng ngừa"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cboLoaithietbi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoaiCV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCongviec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCongviec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblChonCV As System.Windows.Forms.Label
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtGiatri As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBoChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider


    Friend WithEvents grdCongviec As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCongviec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboLoaiCV As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboLoaithietbi As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLoaithietbi As Label
End Class
