<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_ChuyenCVNamQuaThang
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDanhsachBTDKcanthuchien = New System.Windows.Forms.GroupBox()
        Me.gdBTDK = New DevExpress.XtraGrid.GridControl()
        Me.gvBTDK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkChon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_MAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_MAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_BO_PHAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MO_TA_CV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TU_NGAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEN_NGAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TG_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_VT_NN_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_VT_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ID_TRUOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MA_BO_PHAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MA_CV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KH_TYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KH_NAM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KH_TUAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KH_THANG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TU_NGAY_CHUYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEN_NGAY_CHUYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MA_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBoChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLayDL = New DevExpress.XtraEditors.SimpleButton()
        Me.lbNam = New System.Windows.Forms.Label()
        Me.lbThang = New System.Windows.Forms.Label()
        Me.cbNam = New System.Windows.Forms.ComboBox()
        Me.cbThang = New System.Windows.Forms.ComboBox()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
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
        Me.grpDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(3, 39)
        Me.grpDanhsachBTDKcanthuchien.Name = "grpDanhsachBTDKcanthuchien"
        Me.grpDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(1002, 378)
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
        Me.gdBTDK.Size = New System.Drawing.Size(996, 359)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.chkChon, Me.MS_MAY, Me.TEN_MAY, Me.TEN_HANG_MUC, Me.TEN_BO_PHAN, Me.MO_TA_CV, Me.TU_NGAY, Me.DEN_NGAY, Me.MS_UU_TIEN, Me.TG_KH, Me.CP_VT_NN_NGOAI_DM, Me.CP_VT_NGOAI_DM, Me.CP_THUE_NGOAI, Me.ID_TRUOC, Me.MA_BO_PHAN, Me.MA_CV, Me.KH_TYPE, Me.KH_NAM, Me.KH_TUAN, Me.KH_THANG, Me.TU_NGAY_CHUYEN, Me.DEN_NGAY_CHUYEN, Me.MA_HANG_MUC, Me.ID})
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
        Me.TEN_MAY.Width = 150
        '
        'TEN_HANG_MUC
        '
        Me.TEN_HANG_MUC.Caption = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.FieldName = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.Name = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.OptionsColumn.AllowEdit = False
        Me.TEN_HANG_MUC.Visible = True
        Me.TEN_HANG_MUC.VisibleIndex = 3
        Me.TEN_HANG_MUC.Width = 150
        '
        'TEN_BO_PHAN
        '
        Me.TEN_BO_PHAN.Caption = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.FieldName = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.Name = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.OptionsColumn.AllowEdit = False
        Me.TEN_BO_PHAN.Visible = True
        Me.TEN_BO_PHAN.VisibleIndex = 5
        Me.TEN_BO_PHAN.Width = 150
        '
        'MO_TA_CV
        '
        Me.MO_TA_CV.Caption = "MO_TA_CV"
        Me.MO_TA_CV.FieldName = "MO_TA_CV"
        Me.MO_TA_CV.Name = "MO_TA_CV"
        Me.MO_TA_CV.OptionsColumn.AllowEdit = False
        Me.MO_TA_CV.Visible = True
        Me.MO_TA_CV.VisibleIndex = 6
        Me.MO_TA_CV.Width = 150
        '
        'TU_NGAY
        '
        Me.TU_NGAY.Caption = "TU_NGAY"
        Me.TU_NGAY.FieldName = "TU_NGAY"
        Me.TU_NGAY.Name = "TU_NGAY"
        Me.TU_NGAY.Visible = True
        Me.TU_NGAY.VisibleIndex = 7
        Me.TU_NGAY.Width = 100
        '
        'DEN_NGAY
        '
        Me.DEN_NGAY.Caption = "DEN_NGAY"
        Me.DEN_NGAY.FieldName = "DEN_NGAY"
        Me.DEN_NGAY.Name = "DEN_NGAY"
        Me.DEN_NGAY.Visible = True
        Me.DEN_NGAY.VisibleIndex = 8
        Me.DEN_NGAY.Width = 100
        '
        'MS_UU_TIEN
        '
        Me.MS_UU_TIEN.Caption = "MS_UU_TIEN"
        Me.MS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Name = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Visible = True
        Me.MS_UU_TIEN.VisibleIndex = 9
        Me.MS_UU_TIEN.Width = 100
        '
        'TG_KH
        '
        Me.TG_KH.Caption = "TG_KH"
        Me.TG_KH.FieldName = "TG_KH"
        Me.TG_KH.Name = "TG_KH"
        Me.TG_KH.Visible = True
        Me.TG_KH.VisibleIndex = 10
        '
        'CP_VT_NN_NGOAI_DM
        '
        Me.CP_VT_NN_NGOAI_DM.Caption = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.FieldName = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Name = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Visible = True
        Me.CP_VT_NN_NGOAI_DM.VisibleIndex = 11
        Me.CP_VT_NN_NGOAI_DM.Width = 100
        '
        'CP_VT_NGOAI_DM
        '
        Me.CP_VT_NGOAI_DM.Caption = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.FieldName = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Name = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Visible = True
        Me.CP_VT_NGOAI_DM.VisibleIndex = 12
        Me.CP_VT_NGOAI_DM.Width = 100
        '
        'CP_THUE_NGOAI
        '
        Me.CP_THUE_NGOAI.Caption = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.FieldName = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Name = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Visible = True
        Me.CP_THUE_NGOAI.VisibleIndex = 13
        Me.CP_THUE_NGOAI.Width = 100
        '
        'ID_TRUOC
        '
        Me.ID_TRUOC.Caption = "ID_TRUOC"
        Me.ID_TRUOC.FieldName = "ID_TRUOC"
        Me.ID_TRUOC.Name = "ID_TRUOC"
        '
        'MA_BO_PHAN
        '
        Me.MA_BO_PHAN.Caption = "MA_BO_PHAN"
        Me.MA_BO_PHAN.FieldName = "MA_BO_PHAN"
        Me.MA_BO_PHAN.Name = "MA_BO_PHAN"
        Me.MA_BO_PHAN.OptionsColumn.AllowEdit = False
        Me.MA_BO_PHAN.Visible = True
        Me.MA_BO_PHAN.VisibleIndex = 4
        Me.MA_BO_PHAN.Width = 92
        '
        'MA_CV
        '
        Me.MA_CV.Caption = "MA_CV"
        Me.MA_CV.FieldName = "MA_CV"
        Me.MA_CV.Name = "MA_CV"
        Me.MA_CV.OptionsColumn.AllowEdit = False
        Me.MA_CV.Width = 150
        '
        'KH_TYPE
        '
        Me.KH_TYPE.Caption = "KH_TYPE"
        Me.KH_TYPE.FieldName = "KH_TYPE"
        Me.KH_TYPE.Name = "KH_TYPE"
        '
        'KH_NAM
        '
        Me.KH_NAM.Caption = "KH_NAM"
        Me.KH_NAM.FieldName = "KH_NAM"
        Me.KH_NAM.Name = "KH_NAM"
        '
        'KH_TUAN
        '
        Me.KH_TUAN.Caption = "KH_TUAN"
        Me.KH_TUAN.FieldName = "KH_TUAN"
        Me.KH_TUAN.Name = "KH_TUAN"
        '
        'KH_THANG
        '
        Me.KH_THANG.Caption = "KH_THANG"
        Me.KH_THANG.FieldName = "KH_THANG"
        Me.KH_THANG.Name = "KH_THANG"
        '
        'TU_NGAY_CHUYEN
        '
        Me.TU_NGAY_CHUYEN.Caption = "TU_NGAY_CHUYEN"
        Me.TU_NGAY_CHUYEN.FieldName = "TU_NGAY_CHUYEN"
        Me.TU_NGAY_CHUYEN.Name = "TU_NGAY_CHUYEN"
        '
        'DEN_NGAY_CHUYEN
        '
        Me.DEN_NGAY_CHUYEN.Caption = "DEN_NGAY_CHUYEN"
        Me.DEN_NGAY_CHUYEN.FieldName = "DEN_NGAY_CHUYEN"
        Me.DEN_NGAY_CHUYEN.Name = "DEN_NGAY_CHUYEN"
        '
        'MA_HANG_MUC
        '
        Me.MA_HANG_MUC.Caption = "MA_HANG_MUC"
        Me.MA_HANG_MUC.FieldName = "MA_HANG_MUC"
        Me.MA_HANG_MUC.Name = "MA_HANG_MUC"
        '
        'ID
        '
        Me.ID.Caption = "ID"
        Me.ID.FieldName = "ID"
        Me.ID.Name = "ID"
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
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnLayDL, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbNam, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbThang, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbNam, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbThang, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(978, 30)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'btnLayDL
        '
        Me.btnLayDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLayDL.Location = New System.Drawing.Point(403, 3)
        Me.btnLayDL.Name = "btnLayDL"
        Me.btnLayDL.Size = New System.Drawing.Size(129, 24)
        Me.btnLayDL.TabIndex = 4
        Me.btnLayDL.Text = "Load dl khbt nam"
        '
        'lbNam
        '
        Me.lbNam.AutoSize = True
        Me.lbNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNam.Location = New System.Drawing.Point(3, 0)
        Me.lbNam.Name = "lbNam"
        Me.lbNam.Size = New System.Drawing.Size(94, 30)
        Me.lbNam.TabIndex = 0
        Me.lbNam.Text = "Năm"
        Me.lbNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbThang
        '
        Me.lbThang.AutoSize = True
        Me.lbThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbThang.Location = New System.Drawing.Point(203, 0)
        Me.lbThang.Name = "lbThang"
        Me.lbThang.Size = New System.Drawing.Size(94, 30)
        Me.lbThang.TabIndex = 1
        Me.lbThang.Text = "Tháng"
        Me.lbThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbNam
        '
        Me.cbNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbNam.FormattingEnabled = True
        Me.cbNam.Location = New System.Drawing.Point(103, 3)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(94, 21)
        Me.cbNam.TabIndex = 2
        '
        'cbThang
        '
        Me.cbThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbThang.FormattingEnabled = True
        Me.cbThang.Location = New System.Drawing.Point(303, 3)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(94, 21)
        Me.cbThang.TabIndex = 3
        '
        'frmKHTT_ChuyenCVNamQuaThang
        '
        Me.AcceptButton = Me.btnThucHien
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_ChuyenCVNamQuaThang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DS KHBT cần chuyển từ Nam qua tháng"
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
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbNam As System.Windows.Forms.Label
    Friend WithEvents lbThang As System.Windows.Forms.Label
    Friend WithEvents cbNam As System.Windows.Forms.ComboBox
    Friend WithEvents cbThang As System.Windows.Forms.ComboBox
    Friend WithEvents chkChon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MA_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MA_CV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MA_BO_PHAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KH_NAM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KH_THANG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KH_TUAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TU_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEN_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ID_TRUOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KH_TYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MO_TA_CV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_BO_PHAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TU_NGAY_CHUYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEN_NGAY_CHUYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NN_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TG_KH As DevExpress.XtraGrid.Columns.GridColumn
End Class
