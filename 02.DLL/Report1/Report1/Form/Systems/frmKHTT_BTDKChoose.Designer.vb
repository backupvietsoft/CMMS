<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_BTDKChoose
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
        Me.TEN_NHOM_MAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TU_NGAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEN_NGAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_VT_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CP_VT_NN_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_LOAI_BT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBoChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(844, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grpDanhsachBTDKcanthuchien
        '
        Me.grpDanhsachBTDKcanthuchien.Controls.Add(Me.gdBTDK)
        Me.grpDanhsachBTDKcanthuchien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachBTDKcanthuchien.ForeColor = System.Drawing.Color.Navy
        Me.grpDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(3, 33)
        Me.grpDanhsachBTDKcanthuchien.Name = "grpDanhsachBTDKcanthuchien"
        Me.grpDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(838, 364)
        Me.grpDanhsachBTDKcanthuchien.TabIndex = 2
        Me.grpDanhsachBTDKcanthuchien.TabStop = False
        Me.grpDanhsachBTDKcanthuchien.Text = "Danh sách KHBT cần chuyển"
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(3, 16)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(832, 345)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.chkChon, Me.MS_MAY, Me.TEN_MAY, Me.TEN_HANG_MUC, Me.TEN_NHOM_MAY, Me.TU_NGAY, Me.DEN_NGAY, Me.MS_UU_TIEN, Me.CP_THUE_NGOAI, Me.CP_VT_NGOAI_DM, Me.CP_VT_NN_NGOAI_DM, Me.MS_LOAI_BT})
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
        Me.TEN_HANG_MUC.Width = 100
        '
        'TEN_NHOM_MAY
        '
        Me.TEN_NHOM_MAY.Caption = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.FieldName = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.Name = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_NHOM_MAY.Visible = True
        Me.TEN_NHOM_MAY.VisibleIndex = 4
        Me.TEN_NHOM_MAY.Width = 150
        '
        'TU_NGAY
        '
        Me.TU_NGAY.Caption = "TU_NGAY"
        Me.TU_NGAY.FieldName = "TU_NGAY"
        Me.TU_NGAY.Name = "TU_NGAY"
        Me.TU_NGAY.Visible = True
        Me.TU_NGAY.VisibleIndex = 5
        Me.TU_NGAY.Width = 100
        '
        'DEN_NGAY
        '
        Me.DEN_NGAY.Caption = "DEN_NGAY"
        Me.DEN_NGAY.FieldName = "DEN_NGAY"
        Me.DEN_NGAY.Name = "DEN_NGAY"
        Me.DEN_NGAY.Visible = True
        Me.DEN_NGAY.VisibleIndex = 6
        Me.DEN_NGAY.Width = 100
        '
        'MS_UU_TIEN
        '
        Me.MS_UU_TIEN.Caption = "MS_UU_TIEN"
        Me.MS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Name = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Visible = True
        Me.MS_UU_TIEN.VisibleIndex = 7
        Me.MS_UU_TIEN.Width = 100
        '
        'CP_THUE_NGOAI
        '
        Me.CP_THUE_NGOAI.Caption = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.FieldName = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Name = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Visible = True
        Me.CP_THUE_NGOAI.VisibleIndex = 8
        Me.CP_THUE_NGOAI.Width = 100
        '
        'CP_VT_NGOAI_DM
        '
        Me.CP_VT_NGOAI_DM.Caption = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.FieldName = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Name = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Visible = True
        Me.CP_VT_NGOAI_DM.VisibleIndex = 9
        Me.CP_VT_NGOAI_DM.Width = 100
        '
        'CP_VT_NN_NGOAI_DM
        '
        Me.CP_VT_NN_NGOAI_DM.Caption = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.FieldName = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Name = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Visible = True
        Me.CP_VT_NN_NGOAI_DM.VisibleIndex = 10
        Me.CP_VT_NN_NGOAI_DM.Width = 100
        '
        'MS_LOAI_BT
        '
        Me.MS_LOAI_BT.Caption = "MS_LOAI_BT"
        Me.MS_LOAI_BT.FieldName = "MS_LOAI_BT"
        Me.MS_LOAI_BT.Name = "MS_LOAI_BT"
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
        Me.Panel1.Size = New System.Drawing.Size(838, 35)
        Me.Panel1.TabIndex = 3
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(688, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(75, 35)
        Me.btnThucHien.TabIndex = 3
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(763, 0)
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
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 403)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(838, 14)
        Me.ProgressBar1.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbType, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbNam, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbThang, 5, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(804, 24)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(36, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loại kế hoạch"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.Location = New System.Drawing.Point(318, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Năm"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Location = New System.Drawing.Point(509, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tháng"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbType
        '
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(117, 3)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(148, 21)
        Me.cbType.TabIndex = 3
        '
        'cbNam
        '
        Me.cbNam.FormattingEnabled = True
        Me.cbNam.Location = New System.Drawing.Point(353, 3)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(94, 21)
        Me.cbNam.TabIndex = 4
        '
        'cbThang
        '
        Me.cbThang.FormattingEnabled = True
        Me.cbThang.Location = New System.Drawing.Point(553, 3)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(94, 21)
        Me.cbThang.TabIndex = 5
        '
        'frmKHTT_BTDKChoose
        '
        Me.AcceptButton = Me.btnThucHien
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(844, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_BTDKChoose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DS KHBT cần chuyển"
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
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents cbNam As System.Windows.Forms.ComboBox
    Friend WithEvents cbThang As System.Windows.Forms.ComboBox
    Friend WithEvents chkChon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_NHOM_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TU_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEN_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NN_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_LOAI_BT As DevExpress.XtraGrid.Columns.GridColumn
End Class
