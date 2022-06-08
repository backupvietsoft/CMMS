Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient

Public Class frmNhapThietBiMoi
    Private dsMay(0) As String
    Private dtTABLE As DataTable
    Private _MS_MAY As String = ""
    Private _ATTACHMENT As Boolean


#Region "Event Form"
    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property
    Public Property ATTACHMENT() As Boolean
        Get
            Return _ATTACHMENT
        End Get
        Set(ByVal value As Boolean)
            _ATTACHMENT = value
        End Set
    End Property
    Private Sub BtnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Try
            Dim check As Boolean = False
            Dim index As Integer = 0
            For i As Integer = 0 To grvMay.RowCount - 1
                Try
                    If grvMay.GetDataRow(0) Is Nothing Or grvMay.GetDataRow(0).ToString.Trim() = "" Then
                        check = True
                        If (grvMay.FocusedRowHandle = grvMay.RowCount - 1) Then
                            If (grvMay.RowCount > 1) Then
                                check = False
                            End If
                        End If
                        Exit For
                    End If
                Catch ex As Exception
                    check = True
                    If (grvMay.FocusedRowHandle = grvMay.RowCount - 1) Then
                        If (grvMay.RowCount > 1) Then
                            check = False
                        End If
                    End If
                End Try
            Next

            If (check = True) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThietBi_Rong", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
                grvMay.FocusedRowHandle = grvMay.RowCount - 1
                Exit Sub
            End If

            Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim tran As SqlTransaction = con.BeginTransaction()
            Try

                If SaoChep(tran) = False Then
                    Try
                        tran.Rollback()
                        If Commons.Modules.SQLString <> "" Then DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.SQLString)
                        Exit Sub
                    Catch ex As Exception
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                        Exit Sub
                    End Try
                End If

                tran.Commit()
                If Commons.Modules.SQLString = "tontai" Then
                    GoTo 1
                End If
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                ''Dữ liệu đã cập nhật thành công, vui lòng kiểm tra lại dữ liệu !
                'Dim dtTmp As New DataTable
                'dtTmp = New MAYController().PermisionALL(Commons.Modules.UserName, True, 0)
                'dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("MS_MAY")}
                'Commons.Modules.ObjSystems.MLoadXtraGrid(frmThongtinthietbi.grdMay, frmThongtinthietbi.grvMay, dtTmp, False, False, True, True)

                'frmThongtinthietbi.ShowMAY()
                Try
                    Commons.Modules.SQLString = grvMay.GetFocusedRow("MS_MAY").ToString
                Catch ex As Exception
                    Commons.Modules.SQLString = ""
                End Try


                Me.Dispose()
            Catch ex As Exception
                tran.Rollback()
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "sauchepkhongthanh", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString)
            End Try
1:
            con.Close()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "sauchepkhongthanh", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString)
        End Try

    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.SQLString = ""
        Me.Dispose()
    End Sub
#End Region

#Region "Sub & Function"

    Sub LoadForm()
        Dim column As DataColumn = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.AllowDBNull = False
        column.ColumnName = "MS_MAY"
        column.Unique = True
        column.MaxLength = 11111
        dtTABLE = New DataTable("MAY_MOI")

        dtTABLE.Columns.Add(column)
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTABLE, True, False, True, True, True, Name)
        grvMay.OptionsBehavior.AllowAddRows = True
        grvMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Sub LayDanhSachMay(ByVal Sqltran As SqlTransaction)
        Dim objMayInfo As MAYInfo
        Dim i, j As Integer
        j = 0
        For i = 0 To grvMay.RowCount - 2
            objMayInfo = New MAYController().GetMAY(Sqltran, grvMay.GetDataRow(i)(0).ToString())
            If objMayInfo.MS_MAY Is Nothing Then 'neu ms may chua co moi dua vao danh sach
                ReDim Preserve dsMay(j)
                dsMay(j) = grvMay.GetDataRow(i)(0).ToString()
                j = j + 1
            Else
            End If
        Next
    End Sub

    Function SaoChep(ByVal Sqltran As SqlTransaction) As Boolean
        Try

            Dim MsMayNguon As String
            If _ATTACHMENT Then
                MsMayNguon = _MS_MAY
            Else
                MsMayNguon = _MS_MAY
            End If
            Commons.Modules.SQLString = ""
            LayDanhSachMay(Sqltran)
            If dsMay(0) Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Commons.Modules.SQLString = "tontai"
                Return True
                Exit Function
            End If
            Commons.Modules.SQLString = ""
            If rdAll.Checked Then
                If _ATTACHMENT Then
                    SaoChepMay(Sqltran, MsMayNguon)
                    SaoChepMayTSChinhMay(Sqltran, MsMayNguon)
                    SaoChepMayCTTB(Sqltran, MsMayNguon)
                    SaoChepMayTS_BoPhan(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_PT(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_CV(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_GSTT(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPN(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNChuKy(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNCongViec(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNCongViecPT(Sqltran, MsMayNguon)
                    SaoChepMayTaiLieu(Sqltran, MsMayNguon)
                Else
                    SaoChepMay(Sqltran, MsMayNguon)
                    SaoChepMayNX(Sqltran, MsMayNguon)
                    SaoChepMayBPCP(Sqltran, MsMayNguon)
                    SaoChepMayDayChuyen(Sqltran, MsMayNguon)
                    SaoChepMayTSChinhMay(Sqltran, MsMayNguon)
                    SaoChepMayChuKiHC(Sqltran, MsMayNguon)
                    SaoChepMayCTTB(Sqltran, MsMayNguon)
                    SaoChepMayTS_BoPhan(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_PT(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_CV(Sqltran, MsMayNguon)
                    SaoChepMayCTTB_GSTT(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPN(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNChuKy(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNCongViec(Sqltran, MsMayNguon)
                    SaoChepMayLoaiBTPNCongViecPT(Sqltran, MsMayNguon)
                    SaoChepMayTaiLieu(Sqltran, MsMayNguon)
                End If

            Else
                If _ATTACHMENT Then
                    SaoChepMay(Sqltran, MsMayNguon)
                    If chkThongsochingmay.Checked Then
                        SaoChepMayTSChinhMay(Sqltran, MsMayNguon)
                    End If
                    If chkTailieu.Checked Then
                        SaoChepMayTaiLieu(Sqltran, MsMayNguon)
                    End If
                    If chkCautructhietbi.Checked Then
                        SaoChepMayCTTB(Sqltran, MsMayNguon)
                        If chkCautructhietbicongviec.Checked Then
                            SaoChepMayCTTB_CV(Sqltran, MsMayNguon)
                        End If
                        If chkCautructhietbiphutung.Checked Then
                            SaoChepMayCTTB_PT(Sqltran, MsMayNguon)
                        End If
                        If chkCautructhietbiGSTT.Checked Then
                            SaoChepMayCTTB_GSTT(Sqltran, MsMayNguon)
                        End If
                        If chkThongsobophan.Checked Then
                            SaoChepMayTS_BoPhan(Sqltran, MsMayNguon)
                        End If
                    End If
                    If chkLoaiBTPN.Checked Then
                        SaoChepMayLoaiBTPN(Sqltran, MsMayNguon)
                        If chkLoaiBTPNchuky.Checked Then
                            SaoChepMayLoaiBTPNChuKy(Sqltran, MsMayNguon)
                        End If
                        If chkLoaiBTPNcongviec.Checked Then
                            SaoChepMayLoaiBTPNCongViec(Sqltran, MsMayNguon)
                            If chkLoaiBTPNCV_PT.Checked Then
                                SaoChepMayLoaiBTPNCongViecPT(Sqltran, MsMayNguon)
                            End If
                        End If
                    End If
                Else
                    SaoChepMay(Sqltran, MsMayNguon)
                    SaoChepMayNX(Sqltran, MsMayNguon)
                    SaoChepMayBPCP(Sqltran, MsMayNguon)
                    If chkDaychuyen.Checked Then
                        SaoChepMayDayChuyen(Sqltran, MsMayNguon)
                    End If
                    If chkThongsochingmay.Checked Then
                        SaoChepMayTSChinhMay(Sqltran, MsMayNguon)
                    End If
                    If chkChukyhieuchuan.Checked Then
                        SaoChepMayChuKiHC(Sqltran, MsMayNguon)
                    End If
                    If chkTailieu.Checked Then
                        SaoChepMayTaiLieu(Sqltran, MsMayNguon)
                    End If
                    If chkCautructhietbi.Checked Then
                        SaoChepMayCTTB(Sqltran, MsMayNguon)
                        If chkCautructhietbicongviec.Checked Then
                            SaoChepMayCTTB_CV(Sqltran, MsMayNguon)
                        End If
                        If chkCautructhietbiphutung.Checked Then
                            SaoChepMayCTTB_PT(Sqltran, MsMayNguon)
                        End If
                        If chkCautructhietbiGSTT.Checked Then
                            SaoChepMayCTTB_GSTT(Sqltran, MsMayNguon)
                        End If
                        If chkThongsobophan.Checked Then
                            SaoChepMayTS_BoPhan(Sqltran, MsMayNguon)
                        End If
                    End If
                    If chkLoaiBTPN.Checked Then
                        SaoChepMayLoaiBTPN(Sqltran, MsMayNguon)
                        If chkLoaiBTPNchuky.Checked Then
                            SaoChepMayLoaiBTPNChuKy(Sqltran, MsMayNguon)
                        End If
                        If chkLoaiBTPNcongviec.Checked Then
                            SaoChepMayLoaiBTPNCongViec(Sqltran, MsMayNguon)
                            If chkLoaiBTPNCV_PT.Checked Then
                                SaoChepMayLoaiBTPNCongViecPT(Sqltran, MsMayNguon)
                            End If
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            Commons.Modules.SQLString = ex.Message
            Return False
            Exit Function
        End Try
        Commons.Modules.SQLString = ""
        Return True
    End Function
    Sub SaoChepMay(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim objMayInfo As MAYInfo
        Dim objMayController As New MAYController
        Dim i As Integer
        Dim Sql As String
        objMayInfo = objMayController.GetMAY(Sqltran, MsMayNguon)
        For i = 0 To dsMay.Length - 1
            objMayInfo.MS_MAY = dsMay(i).ToString
            objMayInfo.TEN_MAY = objMayInfo.MS_MAY
            objMayController.AddMAYSC(Sqltran, objMayInfo)
            Sql = "UPDATE MAY SET USER_INSERT = N'" & Commons.Modules.UserName & "' WHERE MS_MAY =N'" & objMayInfo.MS_MAY & "'"
            SqlHelper.ExecuteNonQuery(Sqltran, CommandType.Text, Sql)

            Sql = "UPDATE MAY SET NGAY_INSERT = '" & Now.ToString("MM/dd/yyyy HH:mm:ss") & "' WHERE MS_MAY =N'" & objMayInfo.MS_MAY & "'"
            SqlHelper.ExecuteNonQuery(Sqltran, CommandType.Text, Sql)


        Next
    End Sub
    Sub SaoChepMayNX(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayNX As DataTable
        Dim dtRd As DataTableReader
        Dim objMayNXInfo As New MAY_NHA_XUONGInfo
        Dim objNXHTBPCPController As New NXHTBPCPController
        Dim i As Integer
        dtMayNX = objNXHTBPCPController.GetMAY_NHA_XUONGSC(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayNXInfo.MS_MAY = dsMay(i)
            dtRd = dtMayNX.CreateDataReader
            While dtRd.Read
                objMayNXInfo.MS_N_XUONG = dtRd.Item("MS_N_XUONG")
                objMayNXInfo.NGAY_NHAP = dtRd.Item("NGAY_NHAP")
                objNXHTBPCPController.AddMAY_NHA_XUONG(Sqltran, objMayNXInfo)
            End While
        Next
    End Sub
    Sub SaoChepMayBPCP(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayBPCP As DataTable
        Dim dtRd As DataTableReader
        Dim objMayBPCPInfo As New MAY_BO_PHAN_CHIU_PHIInfo
        Dim objNXHTBPCPController As New NXHTBPCPController
        Dim i As Integer
        dtMayBPCP = objNXHTBPCPController.GetMAY_BPCPSC(Sqltran, MsMayNguon)
        For i = 0 To dsMay.Length - 1
            objMayBPCPInfo.MS_MAY = dsMay(i)
            dtRd = dtMayBPCP.CreateDataReader
            While dtRd.Read
                objMayBPCPInfo.MS_BP_CHIU_PHI = dtRd.Item("MS_BP_CHIU_PHI")
                objMayBPCPInfo.NGAY_NHAP = dtRd.Item("NGAY_NHAP")
                objNXHTBPCPController.AddMAY_BPCP(Sqltran, objMayBPCPInfo)
            End While
        Next
    End Sub

    Sub SaoChepMayDayChuyen(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayHT As DataTable
        Dim dtRd As DataTableReader
        Dim objMayHTInfo As New MAY_HE_THONGInfo
        Dim objNXHTBPCPController As New NXHTBPCPController
        Dim i As Integer
        dtMayHT = objNXHTBPCPController.GetMAY_HE_THONGSC(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayHTInfo.MS_MAY = dsMay(i)
            dtRd = dtMayHT.CreateDataReader
            While dtRd.Read
                objMayHTInfo.MS_HE_THONG = dtRd.Item("MS_HE_THONG")
                objMayHTInfo.NGAY_NHAP = dtRd.Item("NGAY_NHAP")
                objNXHTBPCPController.AddMAY_HE_THONG(Sqltran, objMayHTInfo)
            End While
        Next
    End Sub

    Sub SaoChepMayTSChinhMay(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayTSChinhMay As DataTable
        Dim dtRd As DataTableReader
        Dim objMayTSChinhMayInfo As New THONG_SO_CHINH_MAYInfo
        Dim objMayTSChinhMayController As New THONG_SO_CHINH_MAYController
        Dim i As Integer
        dtMayTSChinhMay = objMayTSChinhMayController.GetTHONG_SO_CHINH_MAYsSC(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayTSChinhMayInfo.MS_MAY = dsMay(i)
            dtRd = dtMayTSChinhMay.CreateDataReader
            While dtRd.Read
                objMayTSChinhMayInfo.GHI_CHU = IIf(IsDBNull(dtRd.Item("GHI_CHU").ToString()), Nothing, dtRd.Item("GHI_CHU").ToString())
                objMayTSChinhMayInfo.GIA_TRI = dtRd.Item("GIA_TRI")
                objMayTSChinhMayInfo.MS_THONG_SO_MAY = dtRd.Item("MS_THONG_SO_MAY")
                objMayTSChinhMayController.AddTHONG_SO_CHINH_MAYSC(Sqltran, objMayTSChinhMayInfo)
            End While
        Next
    End Sub
    Sub SaoChepMayChuKiHC(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayChuKiHC As DataTable
        Dim dtRd As DataTableReader
        Dim objMayChuKiHCInfo As New CHU_KY_HIEU_CHUANInfo
        Dim objMayChuKiHCController As New CHU_KY_HIEU_CHUANController
        Dim i As Integer
        dtMayChuKiHC = objMayChuKiHCController.GetCHU_KY_HIEU_CHUAN(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayChuKiHCInfo.MS_MAY = dsMay(i)
            dtRd = dtMayChuKiHC.CreateDataReader
            While dtRd.Read
                objMayChuKiHCInfo.GHI_CHU = IIf(IsDBNull(dtRd.Item("GHI_CHU").ToString()), Nothing, dtRd.Item("GHI_CHU").ToString())
                objMayChuKiHCInfo.CHU_KY_HC_NGOAI = IIf(IsDBNull(dtRd.Item("CHU_KY_HC_NGOAI")), Nothing, dtRd.Item("CHU_KY_HC_NGOAI"))
                objMayChuKiHCInfo.CHU_KY_HC_NOI = IIf(IsDBNull(dtRd.Item("CHU_KY_HC_NOI")), Nothing, dtRd.Item("CHU_KY_HC_NOI"))
                objMayChuKiHCInfo.MS_DV_TG = IIf(IsDBNull(dtRd.Item("MS_DV_TG")), Nothing, dtRd.Item("MS_DV_TG"))
                objMayChuKiHCInfo.MS_PT = dtRd.Item("MS_PT")
                objMayChuKiHCInfo.MS_VI_TRI = dtRd.Item("MS_VI_TRI")
                objMayChuKiHCInfo.TEN_VI_TRI = IIf(IsDBNull(dtRd.Item("TEN_VI_TRI").ToString()), Nothing, dtRd.Item("TEN_VI_TRI").ToString())
                objMayChuKiHCInfo.CHU_KY_KD = IIf(IsDBNull(dtRd.Item("CHU_KY_KD")), Nothing, dtRd.Item("CHU_KY_KD"))
                objMayChuKiHCInfo.CHU_KY_KT = IIf(IsDBNull(dtRd.Item("CHU_KY_KT")), Nothing, dtRd.Item("CHU_KY_KT"))
                objMayChuKiHCController.AddCHU_KY_HIEU_CHUAN(Sqltran, objMayChuKiHCInfo)
            End While
        Next
    End Sub
    Sub SaoChepMayLoaiBTPN(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)

        Dim dtMayLoaiBTPN As DataTable
        Dim dtRd As DataTableReader
        Dim objMayLoaiBTPNInfo As New MAY_LOAI_BTPN
        Dim objMayLoaiBTPNController As New MAY_LOAI_BTPNController
        Dim i As Integer
        dtMayLoaiBTPN = objMayLoaiBTPNController.GetMAY_LOAI_BTPN(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            dtRd = dtMayLoaiBTPN.CreateDataReader
            Commons.Modules.SQLString = "INSERT INTO MAY_LOAI_BTPN(MS_MAY,MS_LOAI_BT,NGAY_CUOI,SO_NGAY,THUC_HIEN_BOI,GHI_CHU) SELECT N'" & dsMay(i) & "',MS_LOAI_BT,NGAY_CUOI,SO_NGAY, THUC_HIEN_BOI, GHI_CHU FROM MAY_LOAI_BTPN WHERE MS_MAY=N'" & MsMayNguon & "'"
            SqlHelper.ExecuteScalar(Sqltran, CommandType.Text, Commons.Modules.SQLString)
        Next
    End Sub
    Sub SaoChepMayLoaiBTPNCongViec(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayLoaiBTPN_CV As DataTable
        Dim dtRd As DataTableReader
        Dim objMayLoaiBTPN_CVInfo As New MAY_LOAI_BTPN_CONG_VIECInfo
        Dim objMayLoaiBTPN_CVController As New MAY_LOAI_BTPN_CONG_VIECController
        Dim i As Integer
        dtMayLoaiBTPN_CV = objMayLoaiBTPN_CVController.GetMAY_LOAI_BTPN_CONG_VIECs(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayLoaiBTPN_CVInfo.MS_MAY = dsMay(i)
            dtRd = dtMayLoaiBTPN_CV.CreateDataReader
            While dtRd.Read
                objMayLoaiBTPN_CVInfo.MS_LOAI_BT = dtRd.Item("MS_LOAI_BT")
                objMayLoaiBTPN_CVInfo.MS_CV = dtRd.Item("MS_CV")
                objMayLoaiBTPN_CVInfo.MS_BO_PHAN = dtRd.Item("MS_BO_PHAN")
                objMayLoaiBTPN_CVController.AddMAY_LOAI_BTPN_CONG_VIEC(Sqltran, objMayLoaiBTPN_CVInfo)
            End While
        Next
    End Sub
    Sub SaoChepMayLoaiBTPNCongViecPT(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayLoaiBTPN_CVPT As DataTable
        Dim dtRd As DataTableReader
        Dim objMayLoaiBTPN_CVPTInfo As New MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGInfo
        Dim objMayLoaiBTPN_CVPTController As New MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGController
        Dim i As Integer
        dtMayLoaiBTPN_CVPT = objMayLoaiBTPN_CVPTController.GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGs(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayLoaiBTPN_CVPTInfo.MS_MAY = dsMay(i)
            dtRd = dtMayLoaiBTPN_CVPT.CreateDataReader
            While dtRd.Read
                objMayLoaiBTPN_CVPTInfo.MS_LOAI_BT = dtRd.Item("MS_LOAI_BT")
                objMayLoaiBTPN_CVPTInfo.MS_CV = dtRd.Item("MS_CV")
                objMayLoaiBTPN_CVPTInfo.MS_PT = dtRd.Item("MS_PT")
                objMayLoaiBTPN_CVPTInfo.QUI_CACH = IIf(IsDBNull(dtRd.Item("QUI_CACH")), Nothing, dtRd.Item("QUI_CACH"))
                objMayLoaiBTPN_CVPTInfo.SO_LUONG = dtRd.Item("SO_LUONG")
                objMayLoaiBTPN_CVPTInfo.MS_BO_PHAN = dtRd.Item("MS_BO_PHAN")
                objMayLoaiBTPN_CVPTInfo.GHI_CHU_BTPN = dtRd.Item("GHI_CHU_BTPN").ToString()
                objMayLoaiBTPN_CVPTInfo.QUI_CACH = dtRd.Item("QUI_CACH").ToString()

                objMayLoaiBTPN_CVPTController.AddMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG(Sqltran, objMayLoaiBTPN_CVPTInfo)
            End While
        Next
    End Sub

    Sub SaoChepMayLoaiBTPNCongViecTool(ByVal MsMayNguon As String)
        Dim dtMayLoaiBTPN_CVTool As DataTable
        Dim dtRd As DataTableReader
        Dim objMayLoaiBTPN_CVToolInfo As New MAY_LOAI_BTPN_CONG_VIEC_TOOLInfo
        Dim objMayLoaiBTPN_CVToolController As New MAY_LOAI_BTPN_CONG_VIEC_TOOLController
        Dim i As Integer
        dtMayLoaiBTPN_CVTool = objMayLoaiBTPN_CVToolController.GetMAY_LOAI_BTPN_CONG_VIEC_TOOLs(MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayLoaiBTPN_CVToolInfo.MS_MAY = dsMay(i)
            dtRd = dtMayLoaiBTPN_CVTool.CreateDataReader
            While dtRd.Read
                objMayLoaiBTPN_CVToolInfo.MS_LOAI_BT = dtRd.Item("MS_LOAI_BT")
                objMayLoaiBTPN_CVToolInfo.MS_CV = dtRd.Item("MS_CV")
                objMayLoaiBTPN_CVToolInfo.MS_VT = dtRd.Item("MS_VAT_TU")
                objMayLoaiBTPN_CVToolController.AddMAY_LOAI_BTPN_CONG_VIEC_TOOL(objMayLoaiBTPN_CVToolInfo)
            End While
        Next
    End Sub

    Sub SaoChepMayLoaiBTPNChuKy(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayLoaiBTPN_CK As DataTable
        Dim dtRd As DataTableReader
        Dim objMayLoaiBTPN_CKInfo As New MAY_LOAI_BTPNInfo
        Dim objMayLoaiBTPN_CKController As New MAY_LOAI_BTPNController
        Dim i As Integer
        dtMayLoaiBTPN_CK = objMayLoaiBTPN_CKController.GetMAY_LOAI_BTPN_CHU_KYs(Sqltran, MsMayNguon)
        Try

            For i = 0 To dsMay.Length - 1
                objMayLoaiBTPN_CKInfo.MS_MAY = dsMay(i)
                dtRd = dtMayLoaiBTPN_CK.CreateDataReader
                While dtRd.Read
                    objMayLoaiBTPN_CKInfo.MS_LOAI_BT = dtRd.Item("MS_LOAI_BT")
                    If String.IsNullOrEmpty(dtRd.Item("CHU_KY").ToString) = False Then
                        objMayLoaiBTPN_CKInfo.CHU_KY = dtRd.Item("CHU_KY")
                    Else
                        objMayLoaiBTPN_CKInfo.CHU_KY = Nothing
                    End If
                    objMayLoaiBTPN_CKInfo.MS_DV_TG = dtRd.Item("MS_DV_TG")
                    objMayLoaiBTPN_CKInfo.MS_DVT_RT = dtRd.Item("MS_DVT_RT")
                    objMayLoaiBTPN_CKInfo.NGAY_AD = dtRd.Item("NGAY_AD")
                    objMayLoaiBTPN_CKInfo.RUN_TIME = IIf(IsDBNull(dtRd.Item("RUN_TIME")), 0, dtRd.Item("RUN_TIME"))
                    objMayLoaiBTPN_CKInfo.MOVEMENT = dtRd.Item("MOVEMENT").ToString
                    objMayLoaiBTPN_CKController.AddMAY_LOAI_BTPN_CHU_KY(Sqltran, objMayLoaiBTPN_CKInfo)
                End While
            Next
        Catch ex As Exception

        End Try

    End Sub
    Sub SaoChepMayTS_GSTT(ByVal MsMayNguon As String)
        Dim dtMayTS_GSTT As DataTable
        Dim dtRd As DataTableReader
        Dim objMayTS_GSTT_CKInfo As New MAY_THONG_SO_GSTTInfo
        Dim objMayTS_GSTT_CKController As New clsMAY_THONG_SO_GSTTController
        Dim i As Integer
        dtMayTS_GSTT = objMayTS_GSTT_CKController.getMAY_THONG_SO_GSTTs(MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayTS_GSTT_CKInfo.MS_MAY = dsMay(i)
            dtRd = dtMayTS_GSTT.CreateDataReader
            While dtRd.Read
                objMayTS_GSTT_CKInfo.CHU_KY_DO = IIf(IsDBNull(dtRd.Item("CHU_KY_DO")), 0, dtRd.Item("CHU_KY_DO"))
                objMayTS_GSTT_CKInfo.GHI_CHU = IIf(IsDBNull(dtRd.Item("GHI_CHU").ToString()), Nothing, dtRd.Item("GHI_CHU").ToString())
                objMayTS_GSTT_CKInfo.GIA_TRI_DUOI = IIf(IsDBNull(dtRd.Item("GIA_TRI_DUOI")), 0, dtRd.Item("GIA_TRI_DUOI"))
                objMayTS_GSTT_CKInfo.GIA_TRI_TREN = IIf(IsDBNull(dtRd.Item("GIA_TRI_TREN")), 0, dtRd.Item("GIA_TRI_TREN"))
                objMayTS_GSTT_CKInfo.MS_DV_TG = IIf(IsDBNull(dtRd.Item("MS_DV_TG")), 1, dtRd.Item("MS_DV_TG"))
                objMayTS_GSTT_CKInfo.MS_TS_GSTT = dtRd.Item("MS_TS_GSTT")
                objMayTS_GSTT_CKController.AddMAY_THONG_SO_GSTT(objMayTS_GSTT_CKInfo)
            End While
        Next
    End Sub
    Sub SaoChepMayTS_BoPhan(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)

        Dim dtMayTS_BoPhan As DataTable
        Dim dtRd As DataTableReader
        Dim objMayTS_BoPhanInfo As New THONG_SO_BO_PHANInfo
        Dim objMayTS_BoPhanController As New THONG_SO_BO_PHANController
        Dim i As Integer
        dtMayTS_BoPhan = objMayTS_BoPhanController.GetTHONG_SO_BO_PHAN(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            objMayTS_BoPhanInfo.MS_MAY = dsMay(i)
            dtRd = dtMayTS_BoPhan.CreateDataReader
            While dtRd.Read
                objMayTS_BoPhanInfo.MS_BO_PHAN = dtRd.Item("MS_BO_PHAN")
                objMayTS_BoPhanInfo.STT = dtRd.Item("STT")
                objMayTS_BoPhanInfo.TEN_THONG_SO = dtRd.Item("TEN_THONG_SO")
                objMayTS_BoPhanInfo.GIA_TRI_THONG_SO = dtRd.Item("GIA_TRI_THONG_SO")
                objMayTS_BoPhanController.AddTHONG_SO_BO_PHAN(Sqltran, objMayTS_BoPhanInfo)
            End While
        Next


    End Sub
    Sub SaoChepMayCTTB(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayCTTB As DataTable
        Dim dtRd As DataTableReader
        Dim objMayCTTBInfo As New CAU_TRUC_THIET_BIInfo
        Dim objMayCTTBController As New CAU_TRUC_THIET_BIController
        Dim i As Integer
        Dim sSql As String = ""
        dtMayCTTB = objMayCTTBController.GetCAU_TRUC_THIET_BIs(Sqltran, MsMayNguon)

        For i = 0 To dsMay.Length - 1
            sSql = ""
            objMayCTTBInfo.MS_MAY = dsMay(i)
            dtRd = dtMayCTTB.CreateDataReader
            While dtRd.Read
                objMayCTTBInfo.MS_BO_PHAN = dtRd.Item("MS_BO_PHAN")
                objMayCTTBInfo.GHI_CHU = dtRd.Item("GHI_CHU").ToString

                If Trim(dtRd.Item("MS_BO_PHAN_CHA").ToString().ToUpper()) = Trim(MsMayNguon.ToUpper()) Then
                    objMayCTTBInfo.MS_BO_PHAN_CHA = dsMay(i)
                Else
                    objMayCTTBInfo.MS_BO_PHAN_CHA = dtRd.Item("MS_BO_PHAN_CHA") ' dsMay(i)
                End If

                objMayCTTBInfo.MS_DVT_RT = Nothing
                objMayCTTBInfo.MS_PT = IIf(IsDBNull(dtRd.Item("MS_PT")), Nothing, dtRd.Item("MS_PT"))
                objMayCTTBInfo.RUN_TIME = Val(dtRd.Item("RUN_TIME").ToString)
                objMayCTTBInfo.SO_LUONG = dtRd.Item("SO_LUONG")
                objMayCTTBInfo.TEN_BO_PHAN = dtRd.Item("TEN_BO_PHAN")
                objMayCTTBInfo.CLASS_ID = IIf(IsDBNull(dtRd.Item("CLASS_ID")), Nothing, dtRd.Item("CLASS_ID"))
                objMayCTTBController.AddCAU_TRUC_THIET_BI(Sqltran, objMayCTTBInfo)

                sSql = "UPDATE CAU_TRUC_THIET_BI SET TEN_BO_PHAN_ANH = N'" & dtRd.Item("TEN_BO_PHAN_ANH").ToString & "', TEN_BO_PHAN_HOA = N'" & dtRd.Item("TEN_BO_PHAN_HOA").ToString & "', STT = " & dtRd.Item("STT").ToString & " WHERE MS_MAY = N'" & objMayCTTBInfo.MS_MAY & "' AND MS_BO_PHAN = N'" & objMayCTTBInfo.MS_BO_PHAN & "' "
                SqlHelper.ExecuteNonQuery(Sqltran, CommandType.Text, sSql)

            End While
        Next
    End Sub

    Sub SaoChepMayCTTB_PT(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayCTTB_PT As DataTable
        Dim dtRd As DataTableReader
        Dim objMayCTTB_PTInfo As New CAU_TRUC_THIET_BI_PHU_TUNGInfo
        Dim objMayCTTB_PTController As New CAU_TRUC_THIET_BI_PHU_TUNGController
        Dim i As Integer
        dtMayCTTB_PT = objMayCTTB_PTController.GetCAU_TRUC_THIET_BI_PHU_TUNG(Sqltran, MsMayNguon)
        For i = 0 To dsMay.Length - 1
            objMayCTTB_PTInfo.MS_MAY = dsMay(i)
            dtRd = dtMayCTTB_PT.CreateDataReader
            While dtRd.Read
                objMayCTTB_PTInfo.MS_BO_PHAN = dtRd.Item("MS_BO_PHAN")
                objMayCTTB_PTInfo.MS_PT = IIf(IsDBNull(dtRd.Item("MS_PT")), Nothing, dtRd.Item("MS_PT"))
                objMayCTTB_PTInfo.MS_VI_TRI_PT = IIf(IsDBNull(dtRd.Item("MS_VI_TRI_PT")), Nothing, dtRd.Item("MS_VI_TRI_PT"))
                objMayCTTB_PTInfo.SO_LUONG = IIf(IsDBNull(dtRd.Item("SO_LUONG")), Nothing, dtRd.Item("SO_LUONG"))
                objMayCTTB_PTInfo.ACTIVE = IIf(IsDBNull(dtRd.Item("ACTIVE")), Nothing, dtRd.Item("ACTIVE"))
                objMayCTTB_PTInfo.CHUC_NANG = IIf(IsDBNull(dtRd.Item("CHUC_NANG")), Nothing, dtRd.Item("CHUC_NANG"))
                objMayCTTB_PTController.AddCAU_TRUC_THIET_BI_PHU_TUNG(Sqltran, objMayCTTB_PTInfo)
            End While
        Next
    End Sub

    Sub SaoChepMayCTTB_CV(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim i As Integer
        For i = 0 To dsMay.Length - 1
            Commons.Modules.SQLString = "INSERT INTO [CAU_TRUC_THIET_BI_CONG_VIEC]([MS_MAY],[MS_BO_PHAN],[MS_CV],[GHI_CHU],[ACTIVE],[TG_KH],[THAO_TAC],[TIEU_CHUAN_KT],[YEU_CAU_NS],[YEU_CAU_DUNG_CU],[PATH_HD]) SELECT N'" & dsMay(i) & "',[MS_BO_PHAN],[MS_CV],[GHI_CHU],[ACTIVE],[TG_KH],[THAO_TAC],[TIEU_CHUAN_KT],[YEU_CAU_NS],[YEU_CAU_DUNG_CU],[PATH_HD] FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_MAY = N'" & MsMayNguon & "'"
            SqlHelper.ExecuteScalar(Sqltran, CommandType.Text, Commons.Modules.SQLString)
        Next
    End Sub

    Sub SaoChepMayCTTB_GSTT(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim i As Integer
        For i = 0 To dsMay.Length - 1
            Commons.Modules.SQLString = "INSERT INTO CAU_TRUC_THIET_BI_TS_GSTT ([MS_MAY],[MS_BO_PHAN],[MS_TS_GSTT],[MS_TT],[TEN_GT],[GIA_TRI_TREN],[GIA_TRI_DUOI],[CHU_KY_DO],[MS_DV_TG],[DAT],[GHI_CHU],[ACTIVE],[TIEU_CHUAN_KT],[YEU_CAU_NS],[YEU_CAU_DUNG_CU],[PATH_HD],[CACH_THUC_HIEN],[THOI_GIAN]) SELECT N'" & dsMay(i) & "' ,[MS_BO_PHAN],[MS_TS_GSTT],[MS_TT],[TEN_GT],[GIA_TRI_TREN],[GIA_TRI_DUOI],[CHU_KY_DO],[MS_DV_TG],[DAT],[GHI_CHU],[ACTIVE],[TIEU_CHUAN_KT],[YEU_CAU_NS],[YEU_CAU_DUNG_CU],[PATH_HD],[CACH_THUC_HIEN],[THOI_GIAN] FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY=N'" & MsMayNguon & "'"
            SqlHelper.ExecuteScalar(Sqltran, CommandType.Text, Commons.Modules.SQLString)
        Next
    End Sub

    Sub SaoChepMayTaiLieu(ByVal Sqltran As SqlTransaction, ByVal MsMayNguon As String)
        Dim dtMayTaiLieu As DataTable
        Dim dtRd As DataTableReader
        Dim objMayTaiLieuInfo As New MAY_TAI_LIEUInfo
        Dim objMayTaiLieuController As New MAY_TAI_LIEUController
        Dim i As Integer
        dtMayTaiLieu = objMayTaiLieuController.GetMAY_TAI_LIEUs(Sqltran, MsMayNguon)
        For i = 0 To dsMay.Length - 1
            objMayTaiLieuInfo.MS_MAY = dsMay(i)
            dtRd = dtMayTaiLieu.CreateDataReader
            While dtRd.Read
                objMayTaiLieuInfo.NOI_LUU_TRU = IIf(IsDBNull(dtRd.Item("NOI_LUU_TRU").ToString()), Nothing, dtRd.Item("NOI_LUU_TRU").ToString())
                objMayTaiLieuInfo.TEN_TAI_LIEU = dtRd.Item("TEN_TAI_LIEU").ToString()
                objMayTaiLieuController.AddMAY_TAI_LIEUSC(Sqltran, objMayTaiLieuInfo)
            End While
        Next
    End Sub
#End Region

    Private Sub frmNhapThietBiMoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(780, 550)
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        LoadForm()

    End Sub

    Private Sub grvMay_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub

    Private Sub rdAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdAll.CheckedChanged
        If rdAll.Checked Then
            grpThongtin.Enabled = False

            chkNhaxuong.Checked = False
            chkBophanchiuphi.Checked = False
            chkThongsochingmay.Checked = False
            chkDaychuyen.Checked = False
            chkChukyhieuchuan.Checked = False
            chkTailieu.Checked = False
            chkCautructhietbi.Checked = False
            chkCautructhietbicongviec.Checked = False
            chkCautructhietbiGSTT.Checked = False
            chkCautructhietbiphutung.Checked = False
            chkThongsobophan.Checked = False
            chkLoaiBTPN.Checked = False
            chkLoaiBTPNchuky.Checked = False
            chkLoaiBTPNcongviec.Checked = False
            chkLoaiBTPNCV_PT.Checked = False
        Else

            grpThongtin.Enabled = True
            chkNhaxuong.Checked = True
            chkBophanchiuphi.Checked = True
            chkNhaxuong.Enabled = False
            chkBophanchiuphi.Enabled = False
            chkCautructhietbicongviec.Enabled = False
            chkCautructhietbiGSTT.Enabled = False
            chkCautructhietbiphutung.Enabled = False
            chkThongsobophan.Enabled = False
            chkLoaiBTPNchuky.Enabled = False
            chkLoaiBTPNcongviec.Enabled = False
            chkLoaiBTPNCV_PT.Enabled = False
            chkDaychuyen.Checked = True
            chkDaychuyen.Enabled = False
        End If
    End Sub

    Private Sub chkCautructhietbi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCautructhietbi.CheckedChanged
        If chkCautructhietbi.Checked Then
            chkCautructhietbicongviec.Enabled = True
            chkCautructhietbiGSTT.Enabled = True
            chkCautructhietbiphutung.Enabled = True
            chkThongsobophan.Enabled = True
        Else
            chkCautructhietbicongviec.Checked = False
            chkCautructhietbiGSTT.Checked = False
            chkCautructhietbiphutung.Checked = False
            chkThongsobophan.Checked = False

            chkCautructhietbicongviec.Enabled = False
            chkCautructhietbiGSTT.Enabled = False
            chkCautructhietbiphutung.Enabled = False
            chkThongsobophan.Enabled = False
        End If
    End Sub

    Private Sub chkLoaiBTPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLoaiBTPN.CheckedChanged
        If chkLoaiBTPN.Checked Then
            chkLoaiBTPNchuky.Enabled = True
            chkLoaiBTPNcongviec.Enabled = True
        Else
            chkLoaiBTPNchuky.Checked = False
            chkLoaiBTPNcongviec.Checked = False

            chkLoaiBTPNchuky.Enabled = False
            chkLoaiBTPNcongviec.Enabled = False
        End If
    End Sub

    Private Sub chkLoaiBTPNcongviec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLoaiBTPNcongviec.CheckedChanged
        If chkLoaiBTPNcongviec.Checked Then
            chkLoaiBTPNCV_PT.Enabled = True
        Else
            chkLoaiBTPNCV_PT.Checked = False
            chkLoaiBTPNCV_PT.Enabled = False
        End If
    End Sub
End Class