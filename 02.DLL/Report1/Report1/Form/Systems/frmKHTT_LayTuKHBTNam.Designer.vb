<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_LayTuKHBTNam
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
        Me.grpDanhsachBTDKcanthuchien = New System.Windows.Forms.GroupBox
        Me.gdBTDK = New DevExpress.XtraGrid.GridControl
        Me.gvBTDK = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.chkChon = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.NGAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.NGAY_DK_HT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NN_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GHI_CHU = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_LOAI_BT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.NGAY_BTPN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LY_DO_SC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_CACH_TH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.USERNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_LOAI_BT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.HANG_MUC_ID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnBoChonAll = New DevExpress.XtraEditors.SimpleButton
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.cbNam = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnLayDL = New DevExpress.XtraEditors.SimpleButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbThang = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpDanhsachBTDKcanthuchien.SuspendLayout()
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachBTDKcanthuchien, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grpDanhsachBTDKcanthuchien
        '
        Me.grpDanhsachBTDKcanthuchien.Controls.Add(Me.gdBTDK)
        Me.grpDanhsachBTDKcanthuchien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachBTDKcanthuchien.ForeColor = System.Drawing.Color.Navy
        Me.grpDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(3, 40)
        Me.grpDanhsachBTDKcanthuchien.Name = "grpDanhsachBTDKcanthuchien"
        Me.grpDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(1002, 377)
        Me.grpDanhsachBTDKcanthuchien.TabIndex = 2
        Me.grpDanhsachBTDKcanthuchien.TabStop = False
        Me.grpDanhsachBTDKcanthuchien.Text = "Danh sách KHBT trích từ KHBT năm"
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(3, 16)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(996, 358)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.chkChon, Me.MS_MAY, Me.TEN_MAY, Me.TEN_HANG_MUC, Me.NGAY, Me.NGAY_DK_HT, Me.MS_UU_TIEN, Me.CP_VT_NN_NGOAI_DM, Me.CP_VT_NGOAI_DM, Me.CP_THUE_NGOAI, Me.GHI_CHU, Me.MS_LOAI_BT, Me.NGAY_BTPN, Me.LY_DO_SC, Me.MS_CACH_TH, Me.USERNAME, Me.TEN_LOAI_BT, Me.ID, Me.HANG_MUC_ID})
        Me.gvBTDK.GridControl = Me.gdBTDK
        Me.gvBTDK.Name = "gvBTDK"
        Me.gvBTDK.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK.OptionsView.ShowGroupPanel = False
        '
        'chkChon
        '
        Me.chkChon.Caption = "chkChon"
        Me.chkChon.FieldName = "chkChon"
        Me.chkChon.Name = "chkChon"
        Me.chkChon.Visible = True
        Me.chkChon.VisibleIndex = 0
        '
        'MS_MAY
        '
        Me.MS_MAY.Caption = "MS_MAY"
        Me.MS_MAY.FieldName = "MS_MAY"
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.OptionsColumn.AllowEdit = False
        Me.MS_MAY.Visible = True
        Me.MS_MAY.VisibleIndex = 1
        Me.MS_MAY.Width = 150
        '
        'TEN_MAY
        '
        Me.TEN_MAY.Caption = "TEN_MAY"
        Me.TEN_MAY.FieldName = "TEN_MAY"
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_MAY.Visible = True
        Me.TEN_MAY.VisibleIndex = 2
        Me.TEN_MAY.Width = 200
        '
        'TEN_HANG_MUC
        '
        Me.TEN_HANG_MUC.Caption = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.FieldName = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.Name = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.OptionsColumn.AllowEdit = False
        Me.TEN_HANG_MUC.Visible = True
        Me.TEN_HANG_MUC.VisibleIndex = 3
        Me.TEN_HANG_MUC.Width = 200
        '
        'NGAY
        '
        Me.NGAY.Caption = "NGAY"
        Me.NGAY.FieldName = "NGAY"
        Me.NGAY.Name = "NGAY"
        Me.NGAY.Visible = True
        Me.NGAY.VisibleIndex = 4
        Me.NGAY.Width = 100
        '
        'NGAY_DK_HT
        '
        Me.NGAY_DK_HT.Caption = "NGAY_DK_HT"
        Me.NGAY_DK_HT.FieldName = "NGAY_DK_HT"
        Me.NGAY_DK_HT.Name = "NGAY_DK_HT"
        Me.NGAY_DK_HT.Visible = True
        Me.NGAY_DK_HT.VisibleIndex = 5
        Me.NGAY_DK_HT.Width = 100
        '
        'MS_UU_TIEN
        '
        Me.MS_UU_TIEN.Caption = "MS_UU_TIEN"
        Me.MS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Name = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Visible = True
        Me.MS_UU_TIEN.VisibleIndex = 6
        Me.MS_UU_TIEN.Width = 100
        '
        'CP_VT_NN_NGOAI_DM
        '
        Me.CP_VT_NN_NGOAI_DM.Caption = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.FieldName = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Name = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Visible = True
        Me.CP_VT_NN_NGOAI_DM.VisibleIndex = 7
        Me.CP_VT_NN_NGOAI_DM.Width = 100
        '
        'CP_VT_NGOAI_DM
        '
        Me.CP_VT_NGOAI_DM.Caption = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.FieldName = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Name = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Visible = True
        Me.CP_VT_NGOAI_DM.VisibleIndex = 8
        Me.CP_VT_NGOAI_DM.Width = 100
        '
        'CP_THUE_NGOAI
        '
        Me.CP_THUE_NGOAI.Caption = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.FieldName = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Name = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Visible = True
        Me.CP_THUE_NGOAI.VisibleIndex = 9
        Me.CP_THUE_NGOAI.Width = 100
        '
        'GHI_CHU
        '
        Me.GHI_CHU.Caption = "GHI_CHU"
        Me.GHI_CHU.FieldName = "GHI_CHU"
        Me.GHI_CHU.Name = "GHI_CHU"
        Me.GHI_CHU.OptionsColumn.AllowEdit = False
        Me.GHI_CHU.Visible = True
        Me.GHI_CHU.VisibleIndex = 10
        Me.GHI_CHU.Width = 150
        '
        'MS_LOAI_BT
        '
        Me.MS_LOAI_BT.Caption = "MS_LOAI_BT"
        Me.MS_LOAI_BT.FieldName = "MS_LOAI_BT"
        Me.MS_LOAI_BT.Name = "MS_LOAI_BT"
        '
        'NGAY_BTPN
        '
        Me.NGAY_BTPN.Caption = "NGAY_BTPN"
        Me.NGAY_BTPN.FieldName = "NGAY_BTPN"
        Me.NGAY_BTPN.Name = "NGAY_BTPN"
        '
        'LY_DO_SC
        '
        Me.LY_DO_SC.Caption = "LY_DO_SC"
        Me.LY_DO_SC.FieldName = "LY_DO_SC"
        Me.LY_DO_SC.Name = "LY_DO_SC"
        '
        'MS_CACH_TH
        '
        Me.MS_CACH_TH.Caption = "MS_CACH_TH"
        Me.MS_CACH_TH.FieldName = "MS_CACH_TH"
        Me.MS_CACH_TH.Name = "MS_CACH_TH"
        '
        'USERNAME
        '
        Me.USERNAME.Caption = "USERNAME"
        Me.USERNAME.FieldName = "USERNAME"
        Me.USERNAME.Name = "USERNAME"
        '
        'TEN_LOAI_BT
        '
        Me.TEN_LOAI_BT.Caption = "TEN_LOAI_BT"
        Me.TEN_LOAI_BT.Name = "TEN_LOAI_BT"
        '
        'ID
        '
        Me.ID.Caption = "ID"
        Me.ID.FieldName = "ID"
        Me.ID.Name = "ID"
        '
        'HANG_MUC_ID
        '
        Me.HANG_MUC_ID.Caption = "HANG_MUC_ID"
        Me.HANG_MUC_ID.FieldName = "HANG_MUC_ID"
        Me.HANG_MUC_ID.Name = "HANG_MUC_ID"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.btnBoChonAll)
        Me.Panel1.Controls.Add(Me.btnChonAll)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 35)
        Me.Panel1.TabIndex = 3
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(852, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(75, 35)
        Me.btnThucHien.TabIndex = 3
        Me.btnThucHien.Text = "Thực hiện"

        '
        'btnThoat
        '
        Me.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(927, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 35)
        Me.btnThoat.TabIndex = 2
        Me.btnThoat.Text = "Thoát"
        
        '
        'btnBoChonAll
        '
        Me.btnBoChonAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBoChonAll.Location = New System.Drawing.Point(75, 0)
        Me.btnBoChonAll.Name = "btnBoChonAll"
        Me.btnBoChonAll.Size = New System.Drawing.Size(96, 35)
        Me.btnBoChonAll.TabIndex = 1
        Me.btnBoChonAll.Text = "Bỏ chọn tất cả"

        '
        'btnChonAll
        '
        Me.btnChonAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnChonAll.Location = New System.Drawing.Point(0, 0)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(75, 35)
        Me.btnChonAll.TabIndex = 0
        Me.btnChonAll.Text = "Chọn tất cả"

        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cbNam, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnLayDL, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbThang, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(993, 31)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'cbNam
        '
        Me.cbNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbNam.FormattingEnabled = True
        Me.cbNam.Location = New System.Drawing.Point(153, 3)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(144, 21)
        Me.cbNam.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Năm"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLayDL
        '
        Me.btnLayDL.Location = New System.Drawing.Point(562, 3)
        Me.btnLayDL.Name = "btnLayDL"
        Me.btnLayDL.Size = New System.Drawing.Size(144, 25)
        Me.btnLayDL.TabIndex = 4
        Me.btnLayDL.Text = "Load dl khbt nam"

        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(303, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Thang"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbThang
        '
        Me.cbThang.FormattingEnabled = True
        Me.cbThang.Location = New System.Drawing.Point(398, 3)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(144, 21)
        Me.cbThang.TabIndex = 6
        '
        'frmKHTT_LayTuKHBTNam
        '
        Me.AcceptButton = Me.btnThucHien
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_LayTuKHBTNam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DS KHBT trích từ khbt năm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpDanhsachBTDKcanthuchien.ResumeLayout(False)
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpDanhsachBTDKcanthuchien As System.Windows.Forms.GroupBox
    Friend WithEvents gdBTDK As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBoChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLayDL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkChon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HANG_MUC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGAY_DK_HT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHI_CHU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_LOAI_BT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGAY_BTPN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LY_DO_SC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_CACH_TH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents USERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_LOAI_BT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NN_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbNam As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbThang As System.Windows.Forms.ComboBox
End Class
