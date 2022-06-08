<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDDiem = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblDChuyen = New System.Windows.Forms.Label()
        Me.lblLMay = New System.Windows.Forms.Label()
        Me.lblLBaoTri = New System.Windows.Forms.Label()
        Me.cboDDiem = New MVControl.ucComboboxTreeList()
        Me.cboDChuyen = New MVControl.ucComboboxTreeList()
        Me.cboLMay = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboLBTri = New DevExpress.XtraEditors.LookUpEdit()
        Me.datDNgay = New DevExpress.XtraEditors.DateEdit()
        Me.datTNgay = New DevExpress.XtraEditors.DateEdit()
        Me.lblTNgay = New System.Windows.Forms.Label()
        Me.lblDNgay = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLBTri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblDDiem
        '
        Me.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDDiem.Location = New System.Drawing.Point(104, 34)
        Me.lblDDiem.Name = "lblDDiem"
        Me.lblDDiem.Size = New System.Drawing.Size(74, 25)
        Me.lblDDiem.TabIndex = 3
        Me.lblDDiem.Text = "lblDDiem"
        Me.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01495!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.90344!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.03178!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01196!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02292!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01495!))
        Me.TableLayoutPanel1.Controls.Add(Me.prbIN, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDDiem, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grdChung, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDChuyen, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLMay, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLBaoTri, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDDiem, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDChuyen, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLMay, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLBTri, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.datDNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.datTNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDNgay, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(678, 467)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'prbIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.prbIN, 6)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 402)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Properties.Maximum = 0
        Me.prbIN.Properties.Step = 1
        Me.prbIN.Size = New System.Drawing.Size(672, 20)
        Me.prbIN.TabIndex = 101
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 428)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(672, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(455, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 11
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(565, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(3, 37)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(10, 10)
        Me.grdChung.TabIndex = 99
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung, Me.GridView1})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdChung
        Me.GridView1.Name = "GridView1"
        '
        'lblDChuyen
        '
        Me.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDChuyen.Location = New System.Drawing.Point(340, 34)
        Me.lblDChuyen.Name = "lblDChuyen"
        Me.lblDChuyen.Size = New System.Drawing.Size(75, 25)
        Me.lblDChuyen.TabIndex = 3
        Me.lblDChuyen.Text = "lblDChuyen"
        Me.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLMay
        '
        Me.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLMay.Location = New System.Drawing.Point(104, 59)
        Me.lblLMay.Name = "lblLMay"
        Me.lblLMay.Size = New System.Drawing.Size(74, 25)
        Me.lblLMay.TabIndex = 3
        Me.lblLMay.Text = "lblLMay"
        Me.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLBaoTri
        '
        Me.lblLBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLBaoTri.Location = New System.Drawing.Point(340, 59)
        Me.lblLBaoTri.Name = "lblLBaoTri"
        Me.lblLBaoTri.Size = New System.Drawing.Size(75, 25)
        Me.lblLBaoTri.TabIndex = 3
        Me.lblLBaoTri.Text = "lblLBaoTri"
        Me.lblLBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDDiem
        '
        Me.cboDDiem.ColumnDisplayName = Nothing
        Me.cboDDiem.DataSource = Nothing
        Me.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDDiem.EditValue = Nothing
        Me.cboDDiem.KeyFieldName = Nothing
        Me.cboDDiem.Location = New System.Drawing.Point(184, 37)
        Me.cboDDiem.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboDDiem.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboDDiem.Name = "cboDDiem"
        Me.cboDDiem.ParentFieldName = Nothing
        Me.cboDDiem.ReadOnly = False
        Me.cboDDiem.SelectedIndex = 0
        Me.cboDDiem.Size = New System.Drawing.Size(150, 20)
        Me.cboDDiem.TabIndex = 102
        Me.cboDDiem.TextValue = Nothing
        '
        'cboDChuyen
        '
        Me.cboDChuyen.ColumnDisplayName = Nothing
        Me.cboDChuyen.DataSource = Nothing
        Me.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDChuyen.EditValue = Nothing
        Me.cboDChuyen.KeyFieldName = Nothing
        Me.cboDChuyen.Location = New System.Drawing.Point(421, 37)
        Me.cboDChuyen.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboDChuyen.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboDChuyen.Name = "cboDChuyen"
        Me.cboDChuyen.ParentFieldName = Nothing
        Me.cboDChuyen.ReadOnly = False
        Me.cboDChuyen.SelectedIndex = 0
        Me.cboDChuyen.Size = New System.Drawing.Size(150, 20)
        Me.cboDChuyen.TabIndex = 102
        Me.cboDChuyen.TextValue = Nothing
        '
        'cboLMay
        '
        Me.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLMay.Location = New System.Drawing.Point(184, 62)
        Me.cboLMay.Name = "cboLMay"
        Me.cboLMay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLMay.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLMay.Size = New System.Drawing.Size(150, 20)
        Me.cboLMay.TabIndex = 102
        '
        'cboLBTri
        '
        Me.cboLBTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLBTri.Location = New System.Drawing.Point(421, 62)
        Me.cboLBTri.Name = "cboLBTri"
        Me.cboLBTri.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLBTri.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLBTri.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLBTri.Size = New System.Drawing.Size(150, 20)
        Me.cboLBTri.TabIndex = 102
        '
        'datDNgay
        '
        Me.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datDNgay.EditValue = Nothing
        Me.datDNgay.Location = New System.Drawing.Point(421, 12)
        Me.datDNgay.Name = "datDNgay"
        Me.datDNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.datDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.datDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datDNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.datDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.datDNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.datDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDNgay.Size = New System.Drawing.Size(150, 20)
        Me.datDNgay.TabIndex = 104
        '
        'datTNgay
        '
        Me.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datTNgay.EditValue = Nothing
        Me.datTNgay.Location = New System.Drawing.Point(184, 12)
        Me.datTNgay.Name = "datTNgay"
        Me.datTNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datTNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.datTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.datTNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.datTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datTNgay.Size = New System.Drawing.Size(150, 20)
        Me.datTNgay.TabIndex = 103
        '
        'lblTNgay
        '
        Me.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTNgay.Location = New System.Drawing.Point(104, 9)
        Me.lblTNgay.Name = "lblTNgay"
        Me.lblTNgay.Size = New System.Drawing.Size(74, 25)
        Me.lblTNgay.TabIndex = 105
        Me.lblTNgay.Text = "lblTNgay"
        Me.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDNgay
        '
        Me.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDNgay.Location = New System.Drawing.Point(340, 9)
        Me.lblDNgay.Name = "lblDNgay"
        Me.lblDNgay.Size = New System.Drawing.Size(75, 25)
        Me.lblDNgay.TabIndex = 106
        Me.lblDNgay.Text = "lblDNgay"
        Me.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI"
        Me.Size = New System.Drawing.Size(678, 467)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLBTri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDDiem As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents lblDChuyen As Windows.Forms.Label
    Friend WithEvents lblLMay As Windows.Forms.Label
    Friend WithEvents lblLBaoTri As Windows.Forms.Label
    Private WithEvents cboDDiem As MVControl.ucComboboxTreeList
    Private WithEvents cboDChuyen As MVControl.ucComboboxTreeList
    Private WithEvents cboLMay As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cboLBTri As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents datDNgay As DevExpress.XtraEditors.DateEdit
    Private WithEvents datTNgay As DevExpress.XtraEditors.DateEdit
    Private WithEvents lblTNgay As Windows.Forms.Label
    Private WithEvents lblDNgay As Windows.Forms.Label
End Class
