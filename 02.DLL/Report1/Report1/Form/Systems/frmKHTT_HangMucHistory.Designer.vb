<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKHTT_HangMucHistory
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
        Me.TEN_HANG_MUC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.KE_HOACH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TU_NGAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.DEN_NGAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHUYEN_TU = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHUYEN_DEN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEN_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NN_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_VT_NGOAI_DM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CP_THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn
        Me.DUYET = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpInfo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
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
        Me.grpInfo.Location = New System.Drawing.Point(3, 23)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(1002, 394)
        Me.grpInfo.TabIndex = 2
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Chi Tiet "
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(3, 16)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(996, 375)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TEN_HANG_MUC, Me.KE_HOACH, Me.TU_NGAY, Me.DEN_NGAY, Me.CHUYEN_TU, Me.CHUYEN_DEN, Me.TEN_UU_TIEN, Me.CP_VT_NN_NGOAI_DM, Me.CP_VT_NGOAI_DM, Me.CP_THUE_NGOAI, Me.DUYET})
        Me.gvBTDK.GridControl = Me.gdBTDK
        Me.gvBTDK.Name = "gvBTDK"
        Me.gvBTDK.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK.OptionsView.ShowGroupPanel = False
        '
        'TEN_HANG_MUC
        '
        Me.TEN_HANG_MUC.Caption = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.FieldName = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.Name = "TEN_HANG_MUC"
        Me.TEN_HANG_MUC.OptionsColumn.AllowEdit = False
        Me.TEN_HANG_MUC.Visible = True
        Me.TEN_HANG_MUC.VisibleIndex = 0
        Me.TEN_HANG_MUC.Width = 150
        '
        'KE_HOACH
        '
        Me.KE_HOACH.Caption = "KE_HOACH"
        Me.KE_HOACH.FieldName = "KE_HOACH"
        Me.KE_HOACH.Name = "KE_HOACH"
        Me.KE_HOACH.OptionsColumn.AllowEdit = False
        Me.KE_HOACH.Visible = True
        Me.KE_HOACH.VisibleIndex = 1
        Me.KE_HOACH.Width = 100
        '
        'TU_NGAY
        '
        Me.TU_NGAY.Caption = "TU_NGAY"
        Me.TU_NGAY.FieldName = "TU_NGAY"
        Me.TU_NGAY.Name = "TU_NGAY"
        Me.TU_NGAY.OptionsColumn.AllowEdit = False
        Me.TU_NGAY.Visible = True
        Me.TU_NGAY.VisibleIndex = 2
        Me.TU_NGAY.Width = 100
        '
        'DEN_NGAY
        '
        Me.DEN_NGAY.Caption = "DEN_NGAY"
        Me.DEN_NGAY.FieldName = "DEN_NGAY"
        Me.DEN_NGAY.Name = "DEN_NGAY"
        Me.DEN_NGAY.OptionsColumn.AllowEdit = False
        Me.DEN_NGAY.Visible = True
        Me.DEN_NGAY.VisibleIndex = 3
        Me.DEN_NGAY.Width = 100
        '
        'CHUYEN_TU
        '
        Me.CHUYEN_TU.Caption = "CHUYEN_TU"
        Me.CHUYEN_TU.FieldName = "CHUYEN_TU"
        Me.CHUYEN_TU.Name = "CHUYEN_TU"
        Me.CHUYEN_TU.OptionsColumn.AllowEdit = False
        Me.CHUYEN_TU.Visible = True
        Me.CHUYEN_TU.VisibleIndex = 4
        Me.CHUYEN_TU.Width = 100
        '
        'CHUYEN_DEN
        '
        Me.CHUYEN_DEN.Caption = "CHUYEN_DEN"
        Me.CHUYEN_DEN.FieldName = "CHUYEN_DEN"
        Me.CHUYEN_DEN.Name = "CHUYEN_DEN"
        Me.CHUYEN_DEN.OptionsColumn.AllowEdit = False
        Me.CHUYEN_DEN.Visible = True
        Me.CHUYEN_DEN.VisibleIndex = 5
        Me.CHUYEN_DEN.Width = 100
        '
        'TEN_UU_TIEN
        '
        Me.TEN_UU_TIEN.Caption = "TEN_UU_TIEN"
        Me.TEN_UU_TIEN.FieldName = "TEN_UU_TIEN"
        Me.TEN_UU_TIEN.Name = "TEN_UU_TIEN"
        Me.TEN_UU_TIEN.OptionsColumn.AllowEdit = False
        Me.TEN_UU_TIEN.Visible = True
        Me.TEN_UU_TIEN.VisibleIndex = 6
        Me.TEN_UU_TIEN.Width = 120
        '
        'CP_VT_NN_NGOAI_DM
        '
        Me.CP_VT_NN_NGOAI_DM.Caption = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.FieldName = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.Name = "CP_VT_NN_NGOAI_DM"
        Me.CP_VT_NN_NGOAI_DM.OptionsColumn.AllowEdit = False
        Me.CP_VT_NN_NGOAI_DM.Visible = True
        Me.CP_VT_NN_NGOAI_DM.VisibleIndex = 7
        '
        'CP_VT_NGOAI_DM
        '
        Me.CP_VT_NGOAI_DM.Caption = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.FieldName = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.Name = "CP_VT_NGOAI_DM"
        Me.CP_VT_NGOAI_DM.OptionsColumn.AllowEdit = False
        Me.CP_VT_NGOAI_DM.Visible = True
        Me.CP_VT_NGOAI_DM.VisibleIndex = 8
        '
        'CP_THUE_NGOAI
        '
        Me.CP_THUE_NGOAI.Caption = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.FieldName = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.Name = "CP_THUE_NGOAI"
        Me.CP_THUE_NGOAI.OptionsColumn.AllowEdit = False
        Me.CP_THUE_NGOAI.Visible = True
        Me.CP_THUE_NGOAI.VisibleIndex = 9
        '
        'DUYET
        '
        Me.DUYET.Caption = "DUYET"
        Me.DUYET.FieldName = "DUYET"
        Me.DUYET.Name = "DUYET"
        Me.DUYET.OptionsColumn.AllowEdit = False
        Me.DUYET.Visible = True
        Me.DUYET.VisibleIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 35)
        Me.Panel1.TabIndex = 3
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
        'frmKHTT_HangMucHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmKHTT_HangMucHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hang Muc History"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpInfo.ResumeLayout(False)
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents gdBTDK As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEN_HANG_MUC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KE_HOACH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TU_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEN_NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHUYEN_TU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHUYEN_DEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NN_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_VT_NGOAI_DM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CP_THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DUYET As DevExpress.XtraGrid.Columns.GridColumn
End Class
