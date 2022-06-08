
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository

Public Class frmMayloaiBTPNchuky
    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL As String
    Private MS_VAT_TU_TMP As String
    Private recNum As Integer
    Private _ATTACHMENT As Boolean
#Region "Control Event"
    Public Property ATTACHMENT() As Boolean
        Get
            Return _ATTACHMENT
        End Get
        Set(ByVal value As Boolean)
            _ATTACHMENT = value
        End Set
    End Property
    Private Sub frmMayloaiBTPNchuky_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ATTACHMENT Then
            TxtMS_MAY.Text = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            TxtTEN_NHOM_MAY.Text = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("TEN_NHOM_MAY").ToString()
            'Dim s As String = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString()
        Else
            TxtMS_MAY.Text = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            TxtTEN_NHOM_MAY.Text = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("TEN_NHOM_MAY").ToString()
            Dim s As String = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString()
        End If
        Commons.Modules.SQLString = "0Load"
        LoadMS_LOAI_BT()
        BindData()
        Commons.Modules.SQLString = ""
        Commons.Modules.ObjSystems.DinhDang()
        VisibleButton(True)
        LockData(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        btnThemsua.Enabled = chon
        BtnXoa.Enabled = chon

    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        Dim traloi As String
        If grvBTPN.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
        If traloi = vbNo Then Exit Sub
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_LOAI_BTPN_CHU_KY",
            TxtMS_MAY.Text, CboMS_LOAI_BT.EditValue, grvBTPN.GetFocusedDataRow()("NGAY_AD"))


        BindData()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim sBT As String = "BTDK" & Commons.Modules.UserName
        Try
            If grvBTPN.RowCount - 1 > 0 Then
                Dim _ngaycuoi As DateTime = getNgayCuoiDefault(TxtMS_MAY.Text, CboMS_LOAI_BT.EditValue)
                _ngaycuoi = _ngaycuoi.AddDays(1)
                Dim _ngayADMin As DateTime = grvBTPN.GetFocusedDataRow("NGAY_AD").ToString()
                For j As Integer = 0 To grvBTPN.RowCount - 1
                    Try
                        Dim _ngayTmp As DateTime = Convert.ToDateTime(grvBTPN.GetDataRow(j)("NGAY_AD").ToString())
                        If _ngayTmp.Date <= _ngayADMin.Date Then
                            _ngayADMin = _ngayTmp
                        End If
                    Catch ex As Exception
                    End Try
                Next


                If _ngaycuoi.Date <= _ngayADMin.Date Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayAD_phai_nho_hon_ngaycuoi", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If

            grvBTPN.OptionsBehavior.AllowAddRows = False
            grvBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, CType(grdBTPN.DataSource, DataTable), "")
            Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            sqlcon.Open()
            Dim objTrans As SqlTransaction = sqlcon.BeginTransaction

            Try
                Dim sSql = " DELETE From MAY_LOAI_BTPN_CHU_KY Where MS_MAY = N'" & TxtMS_MAY.Text & "' AND MS_LOAI_BT = " & CboMS_LOAI_BT.EditValue
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)

                sSql = " INSERT INTO MAY_LOAI_BTPN_CHU_KY (MS_MAY, MS_LOAI_BT, NGAY_AD, CHU_KY, MS_DV_TG, RUN_TIME, MS_DVT_RT, MOVEMENT)SELECT MS_MAY,MS_LOAI_BT,NGAY_AD,CHU_KY,MS_DV_TG,RUN_TIME,MS_DVT_RT,MOVEMENT FROM " & sBT
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt59", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            Finally
                sqlcon.Close()
            End Try

            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.XoaTable(sBT)
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        blnThem = False
        VisibleButton(True)
        LockData(True)
        BindData()
        grvBTPN.OptionsBehavior.AllowAddRows = False
        grvBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        blnThem = False
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click


        Me.Close()
    End Sub
#End Region

#Region "Private Methods"

    Sub BindData()
        Dim dt As New DataTable
        dt = New MAY_LOAI_BTPNController().GetMAY_LOAI_BTPN_CHU_KY(TxtMS_MAY.Text, CboMS_LOAI_BT.EditValue)
        'dt.Columns.Add("UPDATE", Type.GetType("System.Boolean"))
        dt.Columns("TEN_DVT_RT").ReadOnly = False
        dt.Columns("NGAY_AD").ReadOnly = False
        dt.Columns("MS_DV_TG").ReadOnly = False
        dt.Columns("RUN_TIME").ReadOnly = False
        dt.Columns("RUN_TIME").AllowDBNull = True
        dt.Columns("NGAY_CU").AllowDBNull = True



        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBTPN, grvBTPN, dt, False, False, True, True, True, Name)

        Dim cbo As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        dt = New DataTable
        dt = New MAY_LOAI_BTPNController().GetDON_VI_THOI_GIANs
        cbo.Name = "cboDonViTG"
        cbo.DisplayMember = "TEN_DV_TG"
        cbo.ValueMember = "MS_DV_TG"
        cbo.DataSource = dt
        cbo.PopulateColumns()
        cbo.Columns(0).Visible = False
        cbo.Columns(1).Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DV_TG", Commons.Modules.TypeLanguage)
        cbo.NullText = ""
        grvBTPN.Columns("MS_DV_TG").ColumnEdit = cbo
        grvBTPN.Columns("MS_MAY").Visible = False
        grvBTPN.Columns("UPDATE").Visible = False
        grvBTPN.Columns("MS_LOAI_BT").Visible = False
        grvBTPN.Columns("MS_DVT_RT").Visible = False
        grvBTPN.Columns("TEN_DVT_RT").OptionsColumn.ReadOnly = True
        grvBTPN.Columns("TEN_DVT_RT").OptionsColumn.AllowEdit = False
        grvBTPN.Columns("MOVEMENT").Visible = False
        grvBTPN.Columns("NGAY_CU").Visible = False
    End Sub


    Sub LoadMS_LOAI_BT()
        Try
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOC_LOAI_BAO_TRI", TxtMS_MAY.Text))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboMS_LOAI_BT, dt, "MS_LOAI_BT", "TEN_LOAI_BT", "")
        Catch ex As Exception

        End Try

    End Sub


    Sub AddIC_VAT_TU()
        Dim objIC_VAT_TUInfo As New IC_VAT_TUInfo
        objIC_VAT_TUInfo.TEN_VAT_TU = TxtTEN_NHOM_MAY.Text
        objIC_VAT_TUInfo.MS_VAT_TU = TxtMS_MAY.Text

        objIC_VAT_TUInfo.DVT = CboMS_LOAI_BT.EditValue

        If Not blnThem Then
            Dim objIC_VAT_TUController As New IC_VAT_TUController()
            objIC_VAT_TUController.UpdateIC_VAT_TU(objIC_VAT_TUInfo)
        Else
            objIC_VAT_TUInfo.MS_VAT_TU = New IC_VAT_TUController().AddIC_VAT_TU(objIC_VAT_TUInfo)
        End If

    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        btnThemsua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        CboMS_LOAI_BT.Enabled = blnLock
    End Sub
#End Region

    Private Sub btnThemsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua.Click

        VisibleButton(False)
        LockData(False)
        blnThem = True
        recNum = grvBTPN.RowCount - 1

        grvBTPN.OptionsBehavior.Editable = True
        grvBTPN.OptionsBehavior.AllowAddRows = True
        grvBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        If (grvBTPN.FocusedRowHandle < 0) Then
            grvBTPN.SetRowCellValue(grvBTPN.FocusedRowHandle, "NGAY_AD", DateTime.Now)
        End If


    End Sub

    Private Function getNgayCuoiDefault(ByVal _ms_may As String, ByVal _loai_btpn As Integer) As DateTime
        Dim result As DateTime = DateTime.Now
        Try
            result = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_TTTB_GET_DEFAULT_NGAY_CUOI", _ms_may, _loai_btpn))
        Catch ex As Exception
        End Try

        Return result
    End Function



    Private Sub grvBTPN_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvBTPN.InitNewRow
        If ATTACHMENT Then

            grvBTPN.SetFocusedRowCellValue("MS_MAY", TxtMS_MAY.Text)
            grvBTPN.SetFocusedRowCellValue("MS_LOAI_BT", CboMS_LOAI_BT.EditValue)

            If e.RowHandle = 0 Then
                grvBTPN.SetFocusedRowCellValue("NGAY_AD", getNgayCuoiDefault(TxtMS_MAY.Text, CboMS_LOAI_BT.EditValue))
            Else
                Try
                    Convert.ToDateTime(grvBTPN.GetFocusedRowCellValue("NGAY_AD"))
                Catch ex As Exception
                    grvBTPN.SetFocusedRowCellValue("NGAY_AD", DateTime.Now)
                End Try
            End If
        Else
            grvBTPN.SetFocusedRowCellValue("MS_MAY", TxtMS_MAY.Text)
            grvBTPN.SetFocusedRowCellValue("MS_LOAI_BT", CboMS_LOAI_BT.EditValue)

            If e.RowHandle = 0 Then
                grvBTPN.SetFocusedRowCellValue("NGAY_AD", getNgayCuoiDefault(TxtMS_MAY.Text, CboMS_LOAI_BT.EditValue))
            Else
                Try
                    Convert.ToDateTime(grvBTPN.GetFocusedRowCellValue("NGAY_AD"))
                Catch ex As Exception
                    grvBTPN.SetFocusedRowCellValue("NGAY_AD", DateTime.Now)
                End Try
            End If
            Try

                If String.IsNullOrEmpty(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString()) Then
                    grvBTPN.SetFocusedRowCellValue("MS_DVT_RT", Nothing)
                    grvBTPN.SetFocusedRowCellValue("TEN_DVT_RT", "")
                Else
                    grvBTPN.SetFocusedRowCellValue("MS_DVT_RT", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString())
                    grvBTPN.SetFocusedRowCellValue("TEN_DVT_RT", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("TEN_DVT_RT").ToString())
                End If
            Catch ex As Exception

            End Try
        End If
        grvBTPN.SetFocusedRowCellValue("RUN_TIME", 0)
        grvBTPN.SetFocusedRowCellValue("UPDATE", False)

    End Sub

    Private Sub grvBTPN_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvBTPN.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvBTPN_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvBTPN.ValidateRow
        Try
            If (Not IsDBNull(grvBTPN.GetFocusedDataRow(3)) And IsDBNull(grvBTPN.GetFocusedDataRow(4))) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        Try
            If String.IsNullOrEmpty(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString()) Then
                grvBTPN.SetFocusedRowCellValue("MS_DVT_RT", Nothing)
                grvBTPN.SetFocusedRowCellValue("TEN_DVT_RT", "")
            Else
                grvBTPN.SetFocusedRowCellValue("MS_DVT_RT", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_DVT_RT").ToString())
                grvBTPN.SetFocusedRowCellValue("TEN_DVT_RT", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("TEN_DVT_RT").ToString())
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboMS_LOAI_BT_EditValueChanged(sender As Object, e As EventArgs) Handles CboMS_LOAI_BT.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Return
        BindData()
    End Sub

    Private Sub frmMayloaiBTPNchuky_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try


            Dim tmp As New DataTable()
            tmp = New MAYController().GetMAY_LOAI_BTPN(TxtMS_MAY.Text)
            Commons.Modules.ObjSystems.MLoadXtraGrid(frmThongtinthietbi.grdLoaiBTPN, frmThongtinthietbi.grvLoaiBTPN, tmp, False, False, False, True, True, "frmThongtinthietbi")

            Dim comboBoxColumn As New RepositoryItemLookUpEdit
            comboBoxColumn.Name = "MS_LOAI_BT"
            comboBoxColumn.ValueMember = "MS_LOAI_BT"
            comboBoxColumn.DisplayMember = "TEN_LOAI_BT"
            comboBoxColumn.DataSource = New MAYController().GetLOAI_BAO_TRIs()
            comboBoxColumn.NullText = ""
            comboBoxColumn.PopulateColumns()
            For i As Integer = 0 To comboBoxColumn.Columns.Count - 1
                comboBoxColumn.Columns(i).Visible = False
            Next
            comboBoxColumn.Columns("TEN_LOAI_BT").Visible = True
            comboBoxColumn.Columns("TEN_LOAI_BT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_LOAI_BT", Commons.Modules.TypeLanguage)
            frmThongtinthietbi.grvLoaiBTPN.Columns("MS_LOAI_BT").ColumnEdit = comboBoxColumn
            Dim col As New RepositoryItemDateEdit
            col.Name = "NGAY_CUOI"
            col.DisplayFormat.FormatString = "dd/MM/yyyy"
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            frmThongtinthietbi.grvLoaiBTPN.Columns("NGAY_CUOI").ColumnEdit = col
            frmThongtinthietbi.grvLoaiBTPN.Columns("THU_TU").Visible = False
            frmThongtinthietbi.grvLoaiBTPN.Columns("CHU_KYS").OptionsColumn.ReadOnly = True
            frmThongtinthietbi.grvLoaiBTPN.Columns("RUN_TIMES").OptionsColumn.ReadOnly = True
            frmThongtinthietbi.grvLoaiBTPN.Columns("MOVEMENT").Visible = False
            Try
                frmThongtinthietbi.grvLoaiBTPN.Columns("MS_LOAI_BT").Width = 100
                frmThongtinthietbi.grvLoaiBTPN.Columns("CHU_KYS").Width = 75
                frmThongtinthietbi.grvLoaiBTPN.Columns("RUN_TIMES").Width = 80
                frmThongtinthietbi.grvLoaiBTPN.Columns("NGAY_CUOI").Width = 80
                frmThongtinthietbi.grvLoaiBTPN.Columns("SO_NGAY").Width = 71
                frmThongtinthietbi.grvLoaiBTPN.Columns("MOVEMENT").Width = 80
                frmThongtinthietbi.grvLoaiBTPN.Columns("MOVEMENT").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                frmThongtinthietbi.grvLoaiBTPN.Columns("SO_NGAY").DisplayFormat.FormatString = "##,#0"
                frmThongtinthietbi.grvLoaiBTPN.Columns("SO_NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                frmThongtinthietbi.grvLoaiBTPN.Columns("MS_LOAI_BT_OLD").Visible = False
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

    End Sub


End Class