<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMayloaiBTPNchuky
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
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachchukyBTPN = New System.Windows.Forms.GroupBox()
        Me.grdBTPN = New DevExpress.XtraGrid.GridControl()
        Me.grvBTPN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GrpNhapchukyBTPN = New System.Windows.Forms.GroupBox()
        Me.CboMS_LOAI_BT = New DevExpress.XtraEditors.LookUpEdit()
        Me.TxtTEN_NHOM_MAY = New DevExpress.XtraEditors.TextEdit()
        Me.TxtMS_MAY = New DevExpress.XtraEditors.TextEdit()
        Me.LblMS_MAY = New System.Windows.Forms.Label()
        Me.LblLOAI_BTPN = New System.Windows.Forms.Label()
        Me.LblNHOM_TB = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThemsua = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpDanhsachchukyBTPN.SuspendLayout()
        CType(Me.grdBTPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvBTPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapchukyBTPN.SuspendLayout()
        CType(Me.CboMS_LOAI_BT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTEN_NHOM_MAY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMS_MAY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(476, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 9
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Location = New System.Drawing.Point(371, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 8
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachchukyBTPN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpDanhsachchukyBTPN, 4)
        Me.GrpDanhsachchukyBTPN.Controls.Add(Me.grdBTPN)
        Me.GrpDanhsachchukyBTPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhsachchukyBTPN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachchukyBTPN.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachchukyBTPN.Location = New System.Drawing.Point(3, 120)
        Me.GrpDanhsachchukyBTPN.Name = "GrpDanhsachchukyBTPN"
        Me.GrpDanhsachchukyBTPN.Size = New System.Drawing.Size(582, 263)
        Me.GrpDanhsachchukyBTPN.TabIndex = 27
        Me.GrpDanhsachchukyBTPN.TabStop = False
        Me.GrpDanhsachchukyBTPN.Text = "Danh sách chu kỳ BTPN"
        '
        'grdBTPN
        '
        Me.grdBTPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBTPN.Location = New System.Drawing.Point(3, 18)
        Me.grdBTPN.MainView = Me.grvBTPN
        Me.grdBTPN.Name = "grdBTPN"
        Me.grdBTPN.Size = New System.Drawing.Size(576, 242)
        Me.grdBTPN.TabIndex = 82
        Me.grdBTPN.Tag = ""
        Me.grdBTPN.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvBTPN, Me.GridView2})
        '
        'grvBTPN
        '
        Me.grvBTPN.GridControl = Me.grdBTPN
        Me.grvBTPN.Name = "grvBTPN"
        Me.grvBTPN.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvBTPN.OptionsLayout.StoreAllOptions = True
        Me.grvBTPN.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdBTPN
        Me.GridView2.Name = "GridView2"
        '
        'GrpNhapchukyBTPN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpNhapchukyBTPN, 4)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.CboMS_LOAI_BT)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.TxtTEN_NHOM_MAY)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.TxtMS_MAY)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.LblMS_MAY)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.LblLOAI_BTPN)
        Me.GrpNhapchukyBTPN.Controls.Add(Me.LblNHOM_TB)
        Me.GrpNhapchukyBTPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpNhapchukyBTPN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapchukyBTPN.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapchukyBTPN.Location = New System.Drawing.Point(3, 11)
        Me.GrpNhapchukyBTPN.Name = "GrpNhapchukyBTPN"
        Me.GrpNhapchukyBTPN.Size = New System.Drawing.Size(582, 103)
        Me.GrpNhapchukyBTPN.TabIndex = 26
        Me.GrpNhapchukyBTPN.TabStop = False
        Me.GrpNhapchukyBTPN.Text = "Nhập chu kỳ BTPN"
        '
        'CboMS_LOAI_BT
        '
        Me.CboMS_LOAI_BT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CboMS_LOAI_BT.Location = New System.Drawing.Point(200, 68)
        Me.CboMS_LOAI_BT.Name = "CboMS_LOAI_BT"
        Me.CboMS_LOAI_BT.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.CboMS_LOAI_BT.Properties.Appearance.Options.UseBackColor = True
        Me.CboMS_LOAI_BT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboMS_LOAI_BT.Size = New System.Drawing.Size(292, 20)
        Me.CboMS_LOAI_BT.TabIndex = 4
        '
        'TxtTEN_NHOM_MAY
        '
        Me.TxtTEN_NHOM_MAY.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TxtTEN_NHOM_MAY.Location = New System.Drawing.Point(200, 45)
        Me.TxtTEN_NHOM_MAY.Name = "TxtTEN_NHOM_MAY"
        Me.TxtTEN_NHOM_MAY.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTEN_NHOM_MAY.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTEN_NHOM_MAY.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTEN_NHOM_MAY.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtTEN_NHOM_MAY.Properties.ReadOnly = True
        Me.TxtTEN_NHOM_MAY.Size = New System.Drawing.Size(292, 20)
        Me.TxtTEN_NHOM_MAY.TabIndex = 2
        '
        'TxtMS_MAY
        '
        Me.TxtMS_MAY.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TxtMS_MAY.Location = New System.Drawing.Point(200, 22)
        Me.TxtMS_MAY.Name = "TxtMS_MAY"
        Me.TxtMS_MAY.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMS_MAY.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMS_MAY.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMS_MAY.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMS_MAY.Properties.ReadOnly = True
        Me.TxtMS_MAY.Size = New System.Drawing.Size(292, 20)
        Me.TxtMS_MAY.TabIndex = 1
        '
        'LblMS_MAY
        '
        Me.LblMS_MAY.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblMS_MAY.AutoSize = True
        Me.LblMS_MAY.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LblMS_MAY.ForeColor = System.Drawing.Color.Black
        Me.LblMS_MAY.Location = New System.Drawing.Point(89, 25)
        Me.LblMS_MAY.Name = "LblMS_MAY"
        Me.LblMS_MAY.Size = New System.Drawing.Size(81, 14)
        Me.LblMS_MAY.TabIndex = 3
        Me.LblMS_MAY.Text = "Mã số thiết bị"
        '
        'LblLOAI_BTPN
        '
        Me.LblLOAI_BTPN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblLOAI_BTPN.AutoSize = True
        Me.LblLOAI_BTPN.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LblLOAI_BTPN.ForeColor = System.Drawing.Color.Black
        Me.LblLOAI_BTPN.Location = New System.Drawing.Point(89, 71)
        Me.LblLOAI_BTPN.Name = "LblLOAI_BTPN"
        Me.LblLOAI_BTPN.Size = New System.Drawing.Size(62, 14)
        Me.LblLOAI_BTPN.TabIndex = 7
        Me.LblLOAI_BTPN.Text = "Loại BTPN"
        '
        'LblNHOM_TB
        '
        Me.LblNHOM_TB.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblNHOM_TB.AutoSize = True
        Me.LblNHOM_TB.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LblNHOM_TB.ForeColor = System.Drawing.Color.Black
        Me.LblNHOM_TB.Location = New System.Drawing.Point(89, 48)
        Me.LblNHOM_TB.Name = "LblNHOM_TB"
        Me.LblNHOM_TB.Size = New System.Drawing.Size(82, 14)
        Me.LblNHOM_TB.TabIndex = 5
        Me.LblNHOM_TB.Text = "Nhóm thiết bị"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Location = New System.Drawing.Point(371, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 10
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Location = New System.Drawing.Point(476, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 11
        Me.BtnKhongghi.Text = "&Không"
        '
        'btnThemsua
        '
        Me.btnThemsua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemsua.Location = New System.Drawing.Point(266, 2)
        Me.btnThemsua.Name = "btnThemsua"
        Me.btnThemsua.Size = New System.Drawing.Size(104, 30)
        Me.btnThemsua.TabIndex = 81
        Me.btnThemsua.Text = "&Thêm/Sửa"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpDanhsachchukyBTPN, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpNhapchukyBTPN, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.88283!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.11716!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(588, 425)
        Me.TableLayoutPanel1.TabIndex = 82
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btnThemsua)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 389)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(582, 33)
        Me.Panel1.TabIndex = 0
        '
        'frmMayloaiBTPNchuky
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 425)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMayloaiBTPNchuky"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chu kỳ bảo trì phòng ngừa"
        Me.GrpDanhsachchukyBTPN.ResumeLayout(False)
        CType(Me.grdBTPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvBTPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapchukyBTPN.ResumeLayout(False)
        Me.GrpNhapchukyBTPN.PerformLayout()
        CType(Me.CboMS_LOAI_BT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTEN_NHOM_MAY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMS_MAY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachchukyBTPN As System.Windows.Forms.GroupBox
    Friend WithEvents GrpNhapchukyBTPN As System.Windows.Forms.GroupBox
    Friend WithEvents LblMS_MAY As System.Windows.Forms.Label
    Friend WithEvents LblLOAI_BTPN As System.Windows.Forms.Label
    Friend WithEvents LblNHOM_TB As System.Windows.Forms.Label
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtMS_MAY As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CboMS_LOAI_BT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TxtTEN_NHOM_MAY As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnThemsua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdBTPN As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvBTPN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
End Class
