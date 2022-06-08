<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCa
    'Inherits System.Windows.Forms.Form
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TEDenGio = New DevExpress.XtraEditors.TimeEdit()
        Me.txtCA = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblTieudeCa = New System.Windows.Forms.Label()
        Me.lblTenCa = New System.Windows.Forms.Label()
        Me.GrpCa = New System.Windows.Forms.GroupBox()
        Me.grdCA = New DevExpress.XtraGrid.GridControl()
        Me.grvCA = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSTT = New System.Windows.Forms.TextBox()
        Me.BtnKhongGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTuGio = New System.Windows.Forms.Label()
        Me.lblDenGio = New System.Windows.Forms.Label()
        Me.TETuGio = New DevExpress.XtraEditors.TimeEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TEDenGio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCa.SuspendLayout()
        CType(Me.grdCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TETuGio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TEDenGio, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCA, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudeCa, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenCa, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpCa, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuGio, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenGio, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TETuGio, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TEDenGio
        '
        Me.TEDenGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TEDenGio.EditValue = New Date(2016, 11, 4, 0, 0, 0, 0)
        Me.TEDenGio.Location = New System.Drawing.Point(300, 93)
        Me.TEDenGio.Name = "TEDenGio"
        Me.TEDenGio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TEDenGio.Size = New System.Drawing.Size(243, 20)
        Me.TEDenGio.TabIndex = 67
        '
        'txtCA
        '
        Me.txtCA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCA.EditValue = ""
        Me.txtCA.Location = New System.Drawing.Point(300, 43)
        Me.txtCA.Name = "txtCA"
        Me.txtCA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCA.Size = New System.Drawing.Size(243, 20)
        Me.txtCA.TabIndex = 63
        '
        'lblTieudeCa
        '
        Me.lblTieudeCa.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieudeCa, 4)
        Me.lblTieudeCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudeCa.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudeCa.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudeCa.Location = New System.Drawing.Point(1, 0)
        Me.lblTieudeCa.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTieudeCa.Name = "lblTieudeCa"
        Me.lblTieudeCa.Size = New System.Drawing.Size(732, 40)
        Me.lblTieudeCa.TabIndex = 0
        Me.lblTieudeCa.Text = "lblTieudeCa"
        Me.lblTieudeCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTenCa
        '
        Me.lblTenCa.AutoSize = True
        Me.lblTenCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenCa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenCa.ForeColor = System.Drawing.Color.Black
        Me.lblTenCa.Location = New System.Drawing.Point(190, 40)
        Me.lblTenCa.Name = "lblTenCa"
        Me.lblTenCa.Size = New System.Drawing.Size(104, 25)
        Me.lblTenCa.TabIndex = 6
        Me.lblTenCa.Text = "Tên Ca"
        Me.lblTenCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrpCa
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpCa, 4)
        Me.GrpCa.Controls.Add(Me.grdCA)
        Me.GrpCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCa.Location = New System.Drawing.Point(1, 116)
        Me.GrpCa.Margin = New System.Windows.Forms.Padding(1)
        Me.GrpCa.Name = "GrpCa"
        Me.GrpCa.Padding = New System.Windows.Forms.Padding(1)
        Me.GrpCa.Size = New System.Drawing.Size(732, 304)
        Me.GrpCa.TabIndex = 8
        Me.GrpCa.TabStop = False
        Me.GrpCa.Text = "Danh sách Ca"
        '
        'grdCA
        '
        Me.grdCA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCA.Location = New System.Drawing.Point(1, 15)
        Me.grdCA.LookAndFeel.SkinName = "Blue"
        Me.grdCA.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdCA.MainView = Me.grvCA
        Me.grdCA.Name = "grdCA"
        Me.grdCA.Size = New System.Drawing.Size(730, 288)
        Me.grdCA.TabIndex = 3
        Me.grdCA.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCA})
        '
        'grvCA
        '
        Me.grvCA.GridControl = Me.grdCA
        Me.grvCA.Name = "grvCA"
        Me.grvCA.OptionsCustomization.AllowGroup = False
        Me.grvCA.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.txtSTT)
        Me.Panel1.Controls.Add(Me.BtnKhongGhi)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 422)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(732, 38)
        Me.Panel1.TabIndex = 9
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Location = New System.Drawing.Point(310, 6)
        Me.BtnThem.LookAndFeel.SkinName = "Blue"
        Me.BtnThem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 11
        Me.BtnThem.Text = "Thêm"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Location = New System.Drawing.Point(415, 6)
        Me.BtnSua.LookAndFeel.SkinName = "Blue"
        Me.BtnSua.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 10
        Me.BtnSua.Text = "Sửa"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(625, 6)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 8
        Me.btnThoat.Text = "Thoát"
        '
        'txtSTT
        '
        Me.txtSTT.Location = New System.Drawing.Point(1, 2)
        Me.txtSTT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSTT.Name = "txtSTT"
        Me.txtSTT.Size = New System.Drawing.Size(40, 21)
        Me.txtSTT.TabIndex = 6
        Me.txtSTT.Visible = False
        '
        'BtnKhongGhi
        '
        Me.BtnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongGhi.Appearance.Options.UseFont = True
        Me.BtnKhongGhi.Location = New System.Drawing.Point(625, 6)
        Me.BtnKhongGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnKhongGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnKhongGhi.Name = "BtnKhongGhi"
        Me.BtnKhongGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongGhi.TabIndex = 12
        Me.BtnKhongGhi.Text = "Không Ghi"
        Me.BtnKhongGhi.Visible = False
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Location = New System.Drawing.Point(520, 6)
        Me.BtnXoa.LookAndFeel.SkinName = "Blue"
        Me.BtnXoa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 9
        Me.BtnXoa.Text = "Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Location = New System.Drawing.Point(520, 6)
        Me.BtnGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 13
        Me.BtnGhi.Text = "Ghi"
        Me.BtnGhi.Visible = False
        '
        'lblTuGio
        '
        Me.lblTuGio.AutoSize = True
        Me.lblTuGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuGio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTuGio.Location = New System.Drawing.Point(188, 65)
        Me.lblTuGio.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTuGio.Name = "lblTuGio"
        Me.lblTuGio.Size = New System.Drawing.Size(108, 25)
        Me.lblTuGio.TabIndex = 64
        Me.lblTuGio.Text = "Từ giờ"
        Me.lblTuGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenGio
        '
        Me.lblDenGio.AutoSize = True
        Me.lblDenGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenGio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDenGio.Location = New System.Drawing.Point(188, 90)
        Me.lblDenGio.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblDenGio.Name = "lblDenGio"
        Me.lblDenGio.Size = New System.Drawing.Size(108, 25)
        Me.lblDenGio.TabIndex = 65
        Me.lblDenGio.Text = "Đến giờ"
        Me.lblDenGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TETuGio
        '
        Me.TETuGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TETuGio.EditValue = New Date(2016, 11, 4, 0, 0, 0, 0)
        Me.TETuGio.Location = New System.Drawing.Point(300, 68)
        Me.TETuGio.Name = "TETuGio"
        Me.TETuGio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TETuGio.Size = New System.Drawing.Size(243, 20)
        Me.TETuGio.TabIndex = 66
        '
        'frmCa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmCa"
        Me.Text = "frmCa"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TEDenGio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCa.ResumeLayout(False)
        CType(Me.grdCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TETuGio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblTenCa As Label
    Friend WithEvents GrpCa As GroupBox
    Friend WithEvents Panel1 As Panel
    Private WithEvents txtCA As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtSTT As TextBox
    Friend WithEvents lblTuGio As Label
    Friend WithEvents lblDenGio As Label
    Friend WithEvents TEDenGio As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents TETuGio As DevExpress.XtraEditors.TimeEdit
    Private WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnKhongGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents grdCA As DevExpress.XtraGrid.GridControl
    Private WithEvents grvCA As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblTieudeCa As Label
End Class
