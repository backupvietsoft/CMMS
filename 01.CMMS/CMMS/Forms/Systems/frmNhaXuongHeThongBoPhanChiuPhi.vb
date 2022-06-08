
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class FrmNXHTBPCP
    'Member Class
    Private _MS_MAY As String = ""
    Private ThemSua As Boolean = False


    Public Property MS_MAY() As String
        Get
            MS_MAY = _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

#Region "Control Event"

    Sub BindData()
        BindDataBoPhanChiuPhi()
        BindDataHeThong()
        BindDataNhaXuong()
    End Sub



    Private Sub FrmNXHTBPCP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If grvHThong.RowCount = 0 Then
            MS_MAY = ""
        End If
        If grvBPCP.RowCount = 0 Then
            MS_MAY = ""
        End If
        If grvNXuong.RowCount = 0 Then
            MS_MAY = ""
        End If
    End Sub

    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
        txtMsMay.Text = _MS_MAY ' FrmThongtinthietbi.txtMsMay.Text
        ComboNhaXuong()
        ComboHeThong()
        ComboBPCP()



        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindData()
        VisibleButton(True)
        Try
            If (grvBPCP.RowCount = 0) Then
                cboTenBPCP.ItemIndex = 0
                Try
                    cbtNXuong.SelectedIndex = 0
                Catch ex As Exception
                End Try
                Try
                    cbtHThong.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try



        EnableDataGridView(True)
        Commons.Modules.ObjSystems.ThayDoiNNNew(Me)
        LblTieudeNXHTBPCP.Text = (GrpThietBi.Text & " : " & txtMsMay.Text).ToUpper()
        grvNXuong.BestFitColumns()
        grvHThong.BestFitColumns()
        grvBPCP.BestFitColumns()

        grvNXuong.Columns(0).Width = 100
        grvHThong.Columns(0).Width = 100
        grvBPCP.Columns(0).Width = 100
    End Sub

    Sub EnableDataGridView(ByVal chon As Boolean)
        grdBPCP.Enabled = chon
        grdHThong.Enabled = chon
        grdNXuong.Enabled = chon


    End Sub


    Sub HideDelButton(ByVal An As Boolean)
        If An Then
            BtnXoaHT.Visible = An
            BtnXoaHT.Focus()
            btnThem.Visible = Not An
            BtnSua.Visible = Not An
        Else
            btnThem.Visible = Not An
            BtnSua.Visible = Not An
            btnThem.Focus()
            BtnSua.Focus()
            BtnXoaHT.Visible = An
        End If
        BtnXoaNX.Visible = An
        BtnXoaBPCP.Visible = An
        BtnTroVe.Visible = An
        BtnXoa.Visible = Not An
        BtnThoat.Visible = Not An
    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        EnableDataGridView(True)
        HideDelButton(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click


        If cbtNXuong.TextValue.ToString().Trim() <> "" Then
            If KiemDL("MAY_NHA_XUONG", "MS_N_XUONG", cbtNXuong.EditValue, datNgayNX.DateTime, "NhaXuong") = False Then
                cbtNXuong.Focus()
                Exit Sub
            End If
        End If

        If cbtHThong.TextValue.ToString().Trim() <> "" Then
            If KiemDL("MAY_HE_THONG", "MS_HE_THONG", cbtHThong.EditValue, datNgayHT.DateTime, "HeThong") = False Then
                cbtHThong.Focus()
                Exit Sub
            End If
        End If



        If cboTenBPCP.Text.ToString().Trim() <> "" Then
            If KiemDL("MAY_BO_PHAN_CHIU_PHI", "MS_BP_CHIU_PHI", cboTenBPCP.EditValue, datNgayBPCP.DateTime, "BPCP") = False Then
                cboTenBPCP.Focus()
                Exit Sub
            End If
        End If

        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim tran As SqlTransaction = con.BeginTransaction()
        Try
            'Them
            If ThemSua Then
                'NX
                If cbtNXuong.TextValue.ToString().Trim() <> "" Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue)
                    SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, datNgayNX.DateTime, Me.Name, Commons.Modules.UserName, 1)
                End If
                ' May He Thong
                If cbtHThong.TextValue.ToString().Trim() <> "" Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, cbtHThong.EditValue)
                    SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, datNgayHT.DateTime.Date, Me.Name, Commons.Modules.UserName, 1)
                End If

                'BPCP
                If cboTenBPCP.Text.ToString().Trim() <> "" Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, cboTenBPCP.EditValue)
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, datNgayBPCP.DateTime.Date, Me.Name, Commons.Modules.UserName, 1)
                End If
            Else
                'Sua
                If cbtNXuong.TextValue.ToString().Trim() = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiChuaNhapNhaXuong", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
                    cbtNXuong.Focus()
                    Exit Sub
                End If
                If cbtHThong.TextValue.ToString().Trim() = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiChuaNhapHeThong", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
                    cbtHThong.Focus()
                    Exit Sub
                End If

                If cboTenBPCP.Text.ToString().Trim() = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiChuaNhapBPCP", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
                    cboTenBPCP.Focus()
                    Exit Sub
                End If

                'NX
                SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, datNgayNX.DateTime.Date, Me.Name, Commons.Modules.UserName, 2)
                If grvNXuong.RowCount = 0 Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue)
                Else
                    SqlHelper.ExecuteScalar(tran, "UpdateMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue, grvNXuong.GetFocusedDataRow(3))
                End If
                'HT
                SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, datNgayHT.DateTime.Date, Me.Name, Commons.Modules.UserName, 2)

                If grvHThong.RowCount = 0 Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, cbtHThong.EditValue)
                Else
                    SqlHelper.ExecuteScalar(tran, "UpdateMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, CType(cbtHThong.EditValue, Integer),
                            grvHThong.GetFocusedDataRow(3))
                End If

                'BPCP
                SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, datNgayBPCP.DateTime.Date, Me.Name, Commons.Modules.UserName, 2)
                If grvBPCP.RowCount = 0 Then
                    SqlHelper.ExecuteScalar(tran, "AddMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, cboTenBPCP.EditValue)
                Else
                    SqlHelper.ExecuteScalar(tran, "UpdateMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, CType(cboTenBPCP.EditValue, Integer),
                            grvBPCP.GetFocusedDataRow(3))
                End If
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_NHA_XUONG WHERE MS_MAY = '" & txtMsMay.Text & "' AND MS_N_XUONG IS NULL")
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_HE_THONG WHERE MS_MAY = '" & txtMsMay.Text & "' AND MS_HE_THONG IS NULL")
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY = '" & txtMsMay.Text & "' AND MS_BP_CHIU_PHI IS NULL")
            End If
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiCapNhap0ThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
        End Try



        BindData()
        HienGhi(False)
        If (grvNXuong.RowCount = 0) Or (grvHThong.RowCount = 0) Or (grvBPCP.RowCount = 0) Then
            cboTenBPCP.EditValue = -1
            Try
                cbtNXuong.SelectedIndex = 0
            Catch ex As Exception
            End Try
            Try
                cbtHThong.SelectedIndex = 0
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        BindData()
        HienGhi(False)
        Try
            If (grvNXuong.RowCount = 0) Or (grvHThong.RowCount = 0) Or (grvBPCP.RowCount = 0) Then
                cboTenBPCP.EditValue = -1
                Try
                    cbtNXuong.SelectedIndex = 0
                Catch ex As Exception
                End Try
                Try
                    cbtHThong.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Private Methods"

    Sub BindDataHeThong()
        grdHThong.DataSource = Nothing
        Dim dtHThong As New DataTable
        dtHThong = New NXHTBPCPController().GetMAY_HE_THONG(txtMsMay.Text)
        dtHThong.Columns("NGAY_NHAP_CU").AllowDBNull = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdHThong, grvHThong, dtHThong, False, True, True, True, True, Me.Name)
        grvHThong_FocusedRowChanged(Nothing, Nothing)
        grvHThong.Columns(0).Width = 35

        grvHThong.Columns(4).Visible = False
        grvHThong.Columns(3).Visible = False
        grvHThong.Columns(2).Visible = False
    End Sub

    Sub BindDataBoPhanChiuPhi()
        grdBPCP.DataSource = Nothing
        Dim dtBPCP As New DataTable
        dtBPCP = New NXHTBPCPController().GetMAY_BPCP(txtMsMay.Text)
        dtBPCP.Columns("NGAY_NHAP_CU").AllowDBNull = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCP, grvBPCP, dtBPCP, False, True, True, True, True, Me.Name)
        grvBPCP_FocusedRowChanged(Nothing, Nothing)
        grvBPCP.Columns(0).Width = 35
        grvBPCP.Columns(4).Visible = False
        grvBPCP.Columns(3).Visible = False
        grvBPCP.Columns(2).Visible = False
    End Sub

    Sub BindDataNhaXuong()
        grdNXuong.DataSource = Nothing
        Dim dtNXuong As New DataTable
        dtNXuong = New NXHTBPCPController().GetMAY_NHA_XUONG(txtMsMay.Text)
        dtNXuong.Columns("NGAY_NHAP_CU").AllowDBNull = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdNXuong, grvNXuong, dtNXuong, False, True, True, True, True, Me.Name)
        grvNXuong_FocusedRowChanged(Nothing, Nothing)
        grvNXuong.Columns(0).Width = 35
        grvNXuong.Columns(4).Visible = False
        grvNXuong.Columns(3).Visible = False
        grvNXuong.Columns(2).Visible = False
    End Sub

    Sub ComboHeThong()
        Dim dtTmp As New DataTable
        dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(0)
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtHThong, dtTmp, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
    End Sub

    Sub ComboNhaXuong()
        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtNXuong, dtTmp, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
    End Sub

    Sub ComboBPCP()
        'Dim dtTmp As New DataTable
        'dtTmp = New NXHTBPCPController().GetBO_PHAN_CHIU_PHIs

        Dim dtTmp As DataTable = New DataTable
        If BtnGhi.Visible Then
            dtTmp = Commons.Modules.ObjSystems.MLoadDataBoPhanChiuPhi(0)
        Else
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_CHIU_PHIs"))
        End If

        cboTenBPCP.Properties.DataSource = dtTmp
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTenBPCP, dtTmp, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "")
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        btnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub

    Private Sub BtnThoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        If grvHThong.RowCount = 0 Then
            MS_MAY = ""
        End If
        If grvBPCP.RowCount = 0 Then
            MS_MAY = ""
        End If
        If grvNXuong.RowCount = 0 Then
            MS_MAY = ""
        End If

        Me.Close()

    End Sub
#End Region

    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        EnableDataGridView(True)
        HideDelButton(False)
    End Sub

    Private Sub BtnXoaBPCP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaBPCP.Click
        Dim traLoi As String
        Dim objNXHTBPCPController As New NXHTBPCPController

        If grvBPCP.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If grvBPCP.RowCount = 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Co1DongKhongTheXoaBPCP", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        traLoi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If traLoi = vbNo Then Exit Sub

        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, grvBPCP.GetFocusedDataRow(0), Me.Name, Commons.Modules.UserName, 3)

        objNXHTBPCPController.DeleteMAY_BPCP(txtMsMay.Text, grvBPCP.GetFocusedDataRow(0))
        BindDataBoPhanChiuPhi()
    End Sub

    Private Sub BtnXoaHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaHT.Click
        Dim traLoi As String
        Dim objNXHTBPCPController As New NXHTBPCPController
        If grvHThong.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If grvHThong.RowCount = 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Co1DongKhongTheXoaHT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        traLoi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If traLoi = vbNo Then Exit Sub
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, grvHThong.GetFocusedDataRow(0), Me.Name, Commons.Modules.UserName, 3)

        objNXHTBPCPController.DeleteMAY_HE_THONG(txtMsMay.Text, grvHThong.GetFocusedDataRow(0))
        BindDataHeThong()
    End Sub

    Private Sub BtnXoaNX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaNX.Click
        Dim traLoi As String
        Dim objNXHTBPCPController As New NXHTBPCPController
        If grvNXuong.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If grvNXuong.RowCount = 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Co1DongKhongTheXoaNX", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        traLoi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If traLoi = vbNo Then Exit Sub

        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, grvNXuong.GetFocusedDataRow(0), Me.Name, Commons.Modules.UserName, 3)

        objNXHTBPCPController.DeleteMAY_NHA_XUONG(txtMsMay.Text, grvNXuong.GetFocusedDataRow(0))
        BindDataNhaXuong()
    End Sub


    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        HienGhi(True)
        cboTenBPCP.ItemIndex = 0

        Try
            cbtNXuong.SelectedIndex = 0
        Catch ex As Exception

        End Try



        datNgayBPCP.DateTime = Now
        datNgayNX.DateTime = Now
        datNgayHT.DateTime = Now
        ThemSua = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        HienGhi(True)
        ThemSua = False
    End Sub
    Sub HienGhi(ByVal UnLock As Boolean)
        VisibleButton(Not UnLock)

        cboTenBPCP.Enabled = UnLock
        cbtNXuong.Enabled = UnLock
        cbtHThong.Enabled = UnLock

        datNgayBPCP.Enabled = UnLock
        datNgayNX.Enabled = UnLock
        datNgayHT.Enabled = UnLock


        grdHThong.Enabled = Not UnLock
        grdBPCP.Enabled = Not UnLock
        grdNXuong.Enabled = Not UnLock

    End Sub


    Function KiemDL(ByVal sTable As String, ByVal sCotMaso As String, ByVal sMaSoGT As String, ByVal dNgay As Date, ByVal sLoi As String) As Boolean
        KiemDL = False
        Dim sSql As String
        Dim dtTmp As DataTable

        If ThemSua Then
            dtTmp = New DataTable()
            sSql = " SELECT * FROM " & sTable & " WHERE  (MS_MAY = '" & txtMsMay.Text & "')   AND NGAY_NHAP = '" & dNgay.Date.ToString("MM/dd/yyyy") & "' "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiNhap" & sLoi & "DaCoVaoNgayNay", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
                Exit Function
            End If
        End If

        sSql = " SELECT ISNULL(CONVERT(NVARCHAR," & sCotMaso & "), '')  FROM " & sTable & " A INNER JOIN (SELECT MAX(NGAY_NHAP) AS NGAY_NHAP, MS_MAY " &
                    " FROM " & sTable & " WHERE (dbo." & sTable & ".MS_MAY = '" & txtMsMay.Text & "')  " &
                    " AND NGAY_NHAP < '" & dNgay.Date.ToString("MM/dd/yyyy") & "' GROUP BY MS_MAY ) B ON A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_NHAP "
        Dim s As String
        s = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


        If ThemSua And sMaSoGT.ToString().Trim = s Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiNhap" & sLoi & "lientuc", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
            Exit Function
        End If

        sSql = " SELECT ISNULL(CONVERT(NVARCHAR," & sCotMaso & "), '')  FROM " & sTable & " A INNER JOIN (SELECT MIN(NGAY_NHAP ) AS NGAY_NHAP, MS_MAY " &
            " FROM " & sTable & " WHERE (dbo." & sTable & ".MS_MAY = '" & txtMsMay.Text & "')  " &
            " AND NGAY_NHAP > '" & dNgay.Date.ToString("MM/dd/yyyy") & "' GROUP BY MS_MAY ) B ON A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_NHAP "

        If ThemSua And sMaSoGT.ToString().Trim() = TryCast(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql), String) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoiNhap" & sLoi & "lientuc", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
            Exit Function
        End If
        KiemDL = True
    End Function

    Private Sub grvNXuong_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvNXuong.FocusedRowChanged
        Try
            cbtNXuong.SetValue(grvNXuong.GetFocusedRowCellValue("MS_N_XUONG").ToString)
            datNgayNX.DateTime = grvNXuong.GetFocusedRowCellValue("NGAY_NHAP").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvHThong_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvHThong.FocusedRowChanged
        Try
            cbtHThong.SetValue(Convert.ToInt32(grvHThong.GetFocusedRowCellValue("MS_HE_THONG")))
            datNgayHT.DateTime = grvHThong.GetFocusedRowCellValue("NGAY_NHAP").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvBPCP_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvBPCP.FocusedRowChanged
        Try
            cboTenBPCP.EditValue = grvBPCP.GetFocusedRowCellValue("MS_BP_CHIU_PHI")
            datNgayBPCP.DateTime = grvBPCP.GetFocusedRowCellValue("NGAY_NHAP").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class