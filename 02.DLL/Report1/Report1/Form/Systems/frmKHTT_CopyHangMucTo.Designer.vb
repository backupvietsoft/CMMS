<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_CopyHangMucTo
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
        Me.grpInfo = New System.Windows.Forms.GroupBox
        Me.gdBTDK = New DevExpress.XtraGrid.GridControl
        Me.gvBTDK = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.CHOOSE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MA_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TU_NGAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.DEN_NGAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.MS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NN_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_NHOM_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_LOAI_MAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnBoChonAll = New DevExpress.XtraEditors.SimpleButton
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbKHType = New System.Windows.Forms.ComboBox
        Me.cbNam = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbThang = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpInfo.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.grpInfo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.gdBTDK)
        Me.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpInfo.ForeColor = System.Drawing.Color.Navy
        Me.grpInfo.Location = New System.Drawing.Point(3, 43)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(1002, 374)
        Me.grpInfo.TabIndex = 2
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Danh sách thiết bị cùng loại máy"
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(3, 16)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(996, 355)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CHOOSE, Me.MS_MAY, Me.TEN_MAY, Me.MA_HANG_MUC, Me.TEN_HANG_MUC, Me.TU_NGAY, Me.DEN_NGAY, Me.MS_UU_TIEN, Me.CP_VT_NN_NGOAI_DM, Me.CP_VT_NGOAI_DM, Me.CP_THUE_NGOAI, Me.TEN_NHOM_MAY, Me.TEN_LOAI_MAY})
        Me.gvBTDK.GridControl = Me.gdBTDK
        Me.gvBTDK.Name = "gvBTDK"
        Me.gvBTDK.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK.OptionsView.ShowGroupPanel = False
        '
        'CHOOSE
        '
        Me.CHOOSE.Caption = "CHOOSE"
        Me.CHOOSE.FieldName = "CHOOSE"
        Me.CHOOSE.Name = "CHOOSE"
        Me.CHOOSE.Visible = True
        Me.CHOOSE.VisibleIndex = 0
        '
        'MS_MAY
        '
        Me.MS_MAY.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MS_MAY.AppearanceCell.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.MS_MAY.AppearanceCell.Options.UseBackColor = True
        Me.MS_MAY.AppearanceHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MS_MAY.AppearanceHeader.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.MS_MAY.AppearanceHeader.Options.UseBackColor = True
        Me.MS_MAY.Caption = "MS_MAY"
        Me.MS_MAY.FieldName = "MS_MAY"
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.OptionsColumn.AllowEdit = False
        Me.MS_MAY.Visible = True
        Me.MS_MAY.VisibleIndex = 1
        Me.MS_MAY.Width = 100
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_MAY.AppearanceCell.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_MAY.AppearanceCell.Options.UseBackColor = True
        Me.TEN_MAY.AppearanceHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_MAY.AppearanceHeader.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_MAY.AppearanceHeader.Options.UseBackColor = True
        Me.TEN_MAY.Caption = "TEN_MAY"
        Me.TEN_MAY.FieldName = "TEN_MAY"
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_MAY.Visible = True
        Me.TEN_MAY.VisibleIndex = 2
        Me.TEN_MAY.Width = 200
        '
        'MA_HANG_MUC
        '
        Me.MA_HANG_MUC.Caption = "MA_HANG_MUC"
        Me.MA_HANG_MUC.FieldName = "MA_HANG_MUC"
        Me.MA_HANG_MUC.Name = "MA_HANG_MUC"
        '
        'TEN_HANG_MUC
        '
        Me.TEN_HANG_MUC.Caption = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.FieldName = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.Name = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.Visible = True
        Me.TEN_HANG_MUC.VisibleIndex = 3
        Me.TEN_HANG_MUC.Width = 150
        '
        'TU_NGAY
        '
        Me.TU_NGAY.Caption = "TU_NGAY"
        Me.TU_NGAY.FieldName = "TU_NGAY"
        Me.TU_NGAY.Name = "TU_NGAY"
        Me.TU_NGAY.Visible = True
        Me.TU_NGAY.VisibleIndex = 4
        Me.TU_NGAY.Width = 100
        '
        'DEN_NGAY
        '
        Me.DEN_NGAY.Caption = "DEN_NGAY"
        Me.DEN_NGAY.FieldName = "DEN_NGAY"
        Me.DEN_NGAY.Name = "DEN_NGAY"
        Me.DEN_NGAY.Visible = True
        Me.DEN_NGAY.VisibleIndex = 5
        Me.DEN_NGAY.Width = 100
        '
        'MS_UU_TIEN
        '
        Me.MS_UU_TIEN.Caption = "MS_UU_TIEN"
        Me.MS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Name = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Visible = True
        Me.MS_UU_TIEN.VisibleIndex = 6
        Me.MS_UU_TIEN.Width = 120
        '
        'CP_VT_NN_NGOAI_DM
        '
        Me.CP_VT_NN_NGOAI_DM.Caption = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.FieldName = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Name = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Visible = True
        Me.CP_VT_NN_NGOAI_DM.VisibleIndex = 7
        '
        'CP_VT_NGOAI_DM
        '
        Me.CP_VT_NGOAI_DM.Caption = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.FieldName = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Name = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Visible = True
        Me.CP_VT_NGOAI_DM.VisibleIndex = 8
        '
        'CP_THUE_NGOAI
        '
        Me.CP_THUE_NGOAI.Caption = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.FieldName = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Name = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Visible = True
        Me.CP_THUE_NGOAI.VisibleIndex = 9
        '
        'TEN_NHOM_MAY
        '
        Me.TEN_NHOM_MAY.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_NHOM_MAY.AppearanceCell.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_NHOM_MAY.AppearanceCell.Options.UseBackColor = True
        Me.TEN_NHOM_MAY.AppearanceHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_NHOM_MAY.AppearanceHeader.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_NHOM_MAY.AppearanceHeader.Options.UseBackColor = True
        Me.TEN_NHOM_MAY.Caption = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.FieldName = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.Name = "TEN_NHOM_MAY"
        Me.TEN_NHOM_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_NHOM_MAY.Visible = True
        Me.TEN_NHOM_MAY.VisibleIndex = 10
        Me.TEN_NHOM_MAY.Width = 150
        '
        'TEN_LOAI_MAY
        '
        Me.TEN_LOAI_MAY.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_LOAI_MAY.AppearanceCell.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_LOAI_MAY.AppearanceCell.Options.UseBackColor = True
        Me.TEN_LOAI_MAY.AppearanceHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEN_LOAI_MAY.AppearanceHeader.BackColor2 = System.Drawing.Color.WhiteSmoke
        Me.TEN_LOAI_MAY.AppearanceHeader.Options.UseBackColor = True
        Me.TEN_LOAI_MAY.Caption = "TEN_LOAI_MAY"
        Me.TEN_LOAI_MAY.FieldName = "TEN_LOAI_MAY"
        Me.TEN_LOAI_MAY.Name = "TEN_LOAI_MAY"
        Me.TEN_LOAI_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_LOAI_MAY.Visible = True
        Me.TEN_LOAI_MAY.VisibleIndex = 11
        Me.TEN_LOAI_MAY.Width = 150
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBoChonAll)
        Me.Panel1.Controls.Add(Me.btnChonAll)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 35)
        Me.Panel1.TabIndex = 3
        '
        'btnBoChonAll
        '
        Me.btnBoChonAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBoChonAll.Location = New System.Drawing.Point(75, 0)
        Me.btnBoChonAll.Name = "btnBoChonAll"
        Me.btnBoChonAll.Size = New System.Drawing.Size(75, 35)
        Me.btnBoChonAll.TabIndex = 5
        Me.btnBoChonAll.Text = "Button2"
        
        '
        'btnChonAll
        '
        Me.btnChonAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnChonAll.Location = New System.Drawing.Point(0, 0)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(75, 35)
        Me.btnChonAll.TabIndex = 4
        Me.btnChonAll.Text = "Button1"
        
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbKHType, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbNam, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbThang, 5, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(966, 34)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(72, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loại kế hoạch"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.Location = New System.Drawing.Point(346, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 34)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Năm"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbKHType
        '
        Me.cbKHType.FormattingEnabled = True
        Me.cbKHType.Location = New System.Drawing.Point(153, 3)
        Me.cbKHType.Name = "cbKHType"
        Me.cbKHType.Size = New System.Drawing.Size(121, 21)
        Me.cbKHType.TabIndex = 2
        '
        'cbNam
        '
        Me.cbNam.FormattingEnabled = True
        Me.cbNam.Location = New System.Drawing.Point(381, 3)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(104, 21)
        Me.cbNam.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Location = New System.Drawing.Point(547, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 34)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tháng"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbThang
        '
        Me.cbThang.FormattingEnabled = True
        Me.cbThang.Location = New System.Drawing.Point(591, 3)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(121, 21)
        Me.cbThang.TabIndex = 5
        '
        'frmKHTT_CopyHangMucTo
        '
        Me.AcceptButton = Me.btnThucHien
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_CopyHangMucTo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copy kế hoạch bảo trì "
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpInfo.ResumeLayout(False)
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents gdBTDK As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEN_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TU_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEN_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NN_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_NHOM_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_LOAI_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CHOOSE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbKHType As System.Windows.Forms.ComboBox
    Friend WithEvents cbNam As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbThang As System.Windows.Forms.ComboBox
    Friend WithEvents MA_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnBoChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
End Class
