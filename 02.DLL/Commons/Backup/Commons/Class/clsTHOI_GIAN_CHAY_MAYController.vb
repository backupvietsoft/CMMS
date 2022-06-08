Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsTHOI_GIAN_CHAY_MAYController

        Public Sub New()
        End Sub
        Public Function GetTHOI_GIAN_CHAY_MAY(ByVal strMS_LOAI_MAY As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable

            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY", strMS_LOAI_MAY, TU_NGAY, DEN_NGAY, USERNAME))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_CHAY_MAY_MAX(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY_NGAY_MAX", USERNAME))
            Return objDataTable
        End Function

        Public Function GetTHOI_GIAN_CHAY_MAY_MS_MAYs(ByVal strMS_LOAI_MAY As String, ByVal strNGAY As String, ByVal USERNAME As String, ByVal MS_N_XUONG As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY_MS_MAYs", strMS_LOAI_MAY, strNGAY, USERNAME, MS_N_XUONG))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_CHAY_MAY1(ByVal strMS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY1", strMS_LOAI_MAY))
            Return objDataTable
        End Function

        Public Function GetTHOI_GIAN_CHAY_MAYs(ByVal strMS_MAY As String, ByVal USERNAME As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAYs", strMS_MAY, USERNAME, TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function

        Public Function GetTHOI_GIAN_CHAY_MAY_MS_MAY1(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY_MS_MAY1", USERNAME))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_CHAY_MAY_NGAYMAX(ByVal strMS_LOAI_MAY As String) As String
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY_NGAYMAX", strMS_LOAI_MAY)
            While objDataReader.Read
                Return objDataReader.Item("NGAY").ToString()
                objDataReader.Close()
            End While
            objDataReader.Close()
            Return ""
        End Function

        Public Function CheckTHOI_GIAN_CHAY_MAY(ByVal strMS_MAY As String, ByVal strNGAY As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTHOI_GIAN_CHAY_MAY", strMS_MAY, strNGAY)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
        Public Sub AddTHOI_GIAN_CHAY_MAY(ByVal objTHOI_GIAN_CHAY_MAYInfo As THOI_GIAN_CHAY_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTHOI_GIAN_CHAY_MAY", _
              objTHOI_GIAN_CHAY_MAYInfo.MS_MAY, objTHOI_GIAN_CHAY_MAYInfo.NGAY, _
              objTHOI_GIAN_CHAY_MAYInfo.CHI_SO_DONG_HO, objTHOI_GIAN_CHAY_MAYInfo.MS_PBT, _
              objTHOI_GIAN_CHAY_MAYInfo.SO_MOVEMENT)
        End Sub
        Public Sub InsertTHOI_GIAN_CHAY_MAY(ByVal ID As String, ByVal ID1 As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_THOI_GIAN_CHAY_MAY_LOG", ID, ID1, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub UpdateTHOI_GIAN_CHAY_MAY(ByVal objTHOI_GIAN_CHAY_MAYInfo As THOI_GIAN_CHAY_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHOI_GIAN_CHAY_MAY", _
              objTHOI_GIAN_CHAY_MAYInfo.MS_MAY, objTHOI_GIAN_CHAY_MAYInfo.NGAY, _
              objTHOI_GIAN_CHAY_MAYInfo.CHI_SO_DONG_HO, objTHOI_GIAN_CHAY_MAYInfo.MS_PBT, _
              objTHOI_GIAN_CHAY_MAYInfo.SO_MOVEMENT)
        End Sub
        Public Function GetUSER_NHA_XUONG_MS_N_XUONG() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_NHA_XUONG_MS_N_XUONG"))
            Return objDataTable
        End Function
        Public Function GetUSER_LOAI_MAY_MS_LOAI_MAYs(ByVal MS_N_XUONG As String, ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_LOAI_MAY_MS_LOAI_MAYs", MS_N_XUONG, USERNAME))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_CHAY_MAY_NGAY_MAX() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_CHAY_MAY_NGAY_MAX"))
            Return objDataTable
        End Function
        Public Function CheckTHOI_GIAN_CHAY_MAY_NGAY(ByVal strNGAY As String, ByVal strLOAI_MAY As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTHOI_GIAN_CHAY_MAY_NGAY", strNGAY, strLOAI_MAY)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function

        Public Sub DeleteTHOI_GIAN_CHAY_MAY(ByVal strNGAY As String, ByVal strMS_MAY As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHOI_GIAN_CHAY_MAY", strNGAY, strMS_MAY)
        End Sub
        Public Sub DeleteTHOI_GIAN_CHAY_MAY_ALL(ByVal strNGAY As String, ByVal strMS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHOI_GIAN_CHAY_MAY_ALL", strNGAY, strMS_LOAI_MAY)
        End Sub
        Public Function GetTONG_CHI_SO_DONG_HO_THOI_GIAN_CHAY_MAY(ByVal strMS_MAY As String, ByVal TU_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTONG_CHI_SO_DONG_HO_THOI_GIAN_CHAY_MAY", strMS_MAY, TU_NGAY))
            Return objDataTable
        End Function
        Public Function GetNGAY_THOI_GIAN_CHAY_MAYs(ByVal strMS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_THOI_GIAN_CHAY_MAYs", strMS_MAY))
            Return objDataTable
        End Function

        Public Function getDsThietBi(ByVal iLoc As Integer, ByVal LOAI_MAY As String, ByVal HE_THONG As Integer, ByVal NHA_XUONG As String) As DataTable
            Dim objDataTable As DataTable = New DataTable

            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getDsThietBi", LOAI_MAY, HE_THONG, NHA_XUONG, iLoc))
            Return objDataTable
        End Function

        Public Function getDsThoiGianChayMay()
            Dim objDataTable As DataTable = New DataTable

            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getDsThoiGianChayMay"))
            Return objDataTable
        End Function
    End Class
    Public Class ManDataThoiGianChayMay
        Private _DvDsThoiGianChayMay As DataView
        Private _DtDsThoiGianChayMay As DataTable
        Private _DvDsThietBi As DataView
        Private _TuNgay As Date
        Private _DenNgay As Date
        Private _MsMay As String = ""
        Private _GioThu7 As Double
        Private _GioChuNhat As Double
        Private _GioNgayThuong As Double

#Region "Properties"
        Public Property DvDsThoiGianChayMay() As DataView
            Get
                Return _DvDsThoiGianChayMay
            End Get
            Set(ByVal value As DataView)
                _DvDsThoiGianChayMay = value
            End Set
        End Property
        Public Property DtDsThoiGianChayMay() As DataTable
            Get
                Return _DtDsThoiGianChayMay
            End Get
            Set(ByVal value As DataTable)
                _DtDsThoiGianChayMay = value
            End Set
        End Property
        Public Property DvDsThietBi() As DataView
            Get
                Return _DvDsThietBi
            End Get
            Set(ByVal value As DataView)
                _DvDsThietBi = value
            End Set
        End Property
        Public Property TuNgay() As Date
            Get
                Return _TuNgay
            End Get
            Set(ByVal value As Date)
                _TuNgay = value
            End Set
        End Property
        Public Property DenNgay() As Date
            Get
                Return _DenNgay
            End Get
            Set(ByVal value As Date)
                _DenNgay = value
            End Set
        End Property
        Public Property GioThu7() As Double
            Get
                Return _GioThu7
            End Get
            Set(ByVal value As Double)
                _GioThu7 = value
            End Set
        End Property
        Public Property GioChuNhat() As Double
            Get
                Return _GioChuNhat
            End Get
            Set(ByVal value As Double)
                _GioChuNhat = value
            End Set
        End Property
        Public Property GioNgayThuong() As Double
            Get
                Return _GioNgayThuong
            End Get
            Set(ByVal value As Double)
                _GioNgayThuong = value
            End Set
        End Property
        Public Property MsMay() As String
            Get
                Return _MsMay
            End Get
            Set(ByVal value As String)
                _MsMay = value
            End Set
        End Property
#End Region
        Public Sub New()
            _GioThu7 = 0
            _GioChuNhat = 0
            _GioNgayThuong = 0
        End Sub
        Public Sub UpdateGio()
            If _DvDsThoiGianChayMay Is Nothing Then Exit Sub
            For i As Integer = 0 To _DvDsThoiGianChayMay.Count - 1
                Select Case CDate(_DvDsThoiGianChayMay(i).Item("NGAY")).DayOfWeek
                    Case DayOfWeek.Saturday
                        If _GioThu7 <> 0 Then _DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO") = _GioThu7
                    Case DayOfWeek.Sunday
                        If _GioChuNhat <> 0 Then _DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO") = _GioChuNhat
                    Case Else
                        _DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO") = _GioNgayThuong
                End Select
            Next
        End Sub
        Public Sub UpdateGioDsMay()
            If _DvDsThietBi Is Nothing Then Exit Sub
            If _DtDsThoiGianChayMay Is Nothing Then Exit Sub

            Dim strNgay As String = "NGAY >='" & FormatDateTime(_TuNgay, DateFormat.ShortDate).Trim.ToString & " 00:00:00" & _
                    "' AND NGAY<='" & FormatDateTime(_DenNgay, DateFormat.ShortDate).Trim.ToString & " 23:59:59'"
            Dim strTmp As String = ""

            For i As Integer = 0 To _DvDsThietBi.Count - 1
                _MsMay = _DvDsThietBi(i).Item("MS_MAY")
                strTmp = ""
                strTmp = strNgay & " AND MS_MAY='" & _DvDsThietBi(i).Item("MS_MAY") & "'"
                _DvDsThoiGianChayMay = New DataSet().DefaultViewManager.CreateDataView(_DtDsThoiGianChayMay)

                Dim ds As DataView = New DataSet().DefaultViewManager.CreateDataView(_DtDsThoiGianChayMay)


                ' _DvDsThoiGianChayMay = CType(_DtDsThoiGianChayMay, DataView)
                _DvDsThoiGianChayMay.RowFilter = strTmp
                AddNewTimeRunFromDateToDate()
                UpdateGio()
            Next
        End Sub
        Public Sub AddNewTimeRunFromDateToDate()
            Dim blnThem As Boolean
            Dim dtTmp As Date
            Dim strTmp As String = ""

            If _MsMay = "" Then Exit Sub
            If _DvDsThoiGianChayMay Is Nothing Then Exit Sub
            If _DtDsThoiGianChayMay Is Nothing Then Exit Sub

            dtTmp = DateSerial(_TuNgay.Year, _TuNgay.Month, _TuNgay.Day)


            Do Until dtTmp >= _DenNgay
                blnThem = True
                For i As Integer = 0 To _DvDsThoiGianChayMay.Count - 1
                    If _DvDsThoiGianChayMay(i).Item("MS_MAY") = _MsMay And _
                        CDate(_DvDsThoiGianChayMay(i).Item("NGAY")).Year = dtTmp.Year And _
                        CDate(_DvDsThoiGianChayMay(i).Item("NGAY")).Month = dtTmp.Month And _
                        CDate(_DvDsThoiGianChayMay(i).Item("NGAY")).Day = dtTmp.Day Then
                        blnThem = False
                        Exit For
                    End If
                Next
                If blnThem Then
                    'MS_MAY, NGAY, CHI_SO_DONG_HO, MS_PBT, SO_MOVEMENT
                    _DtDsThoiGianChayMay.Rows.Add(_MsMay, dtTmp, 0, "", 0)
                End If
                dtTmp = DateSerial(dtTmp.Year, dtTmp.Month, dtTmp.Day + 1)
            Loop

        End Sub
        Public Sub UpdateDataToDatabase()
            Dim objControl As New clsTHOI_GIAN_CHAY_MAYController()
            Dim objInfo As New THOI_GIAN_CHAY_MAYInfo

            If _DtDsThoiGianChayMay Is Nothing Then Exit Sub

            _DvDsThoiGianChayMay = New DataSet().DefaultViewManager.CreateDataView(_DtDsThoiGianChayMay)

            _DvDsThoiGianChayMay.RowStateFilter = DataViewRowState.Added
            For i As Integer = 0 To _DvDsThoiGianChayMay.Count - 1
                If CDbl(_DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO")) <> 0 Then
                    objInfo.MS_MAY = _DvDsThoiGianChayMay(i).Item("MS_MAY")
                    objInfo.NGAY = Format(_DvDsThoiGianChayMay(i).Item("NGAY"), "short date")
                    objInfo.CHI_SO_DONG_HO = _DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO")
                    objInfo.MS_PBT = _DvDsThoiGianChayMay(i).Item("MS_PBT")
                    objInfo.SO_MOVEMENT = _DvDsThoiGianChayMay(i).Item("SO_MOVEMENT")
                    objControl.AddTHOI_GIAN_CHAY_MAY(objInfo)
                    objControl.InsertTHOI_GIAN_CHAY_MAY(objInfo.MS_MAY, objInfo.NGAY, "frmThoiGianChayMay", Commons.Modules.UserName, 1)
                End If
            Next
            _DvDsThoiGianChayMay.RowStateFilter = DataViewRowState.ModifiedCurrent
            For i As Integer = 0 To _DvDsThoiGianChayMay.Count - 1
                If CDbl(_DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO")) <> 0 Then
                    objInfo.MS_MAY = _DvDsThoiGianChayMay(i).Item("MS_MAY")
                    objInfo.NGAY = Format(_DvDsThoiGianChayMay(i).Item("NGAY"), "short date")
                    objInfo.CHI_SO_DONG_HO = _DvDsThoiGianChayMay(i).Item("CHI_SO_DONG_HO")
                    If Not IsDBNull(_DvDsThoiGianChayMay(i).Item("MS_PBT")) Then
                        objInfo.MS_PBT = _DvDsThoiGianChayMay(i).Item("MS_PBT")
                    End If
                    If Not IsDBNull(_DvDsThoiGianChayMay(i).Item("SO_MOVEMENT")) Then
                        objInfo.SO_MOVEMENT = _DvDsThoiGianChayMay(i).Item("SO_MOVEMENT")
                    End If
                    objControl.InsertTHOI_GIAN_CHAY_MAY(objInfo.MS_MAY, objInfo.NGAY, "frmThoiGianChayMay", Commons.Modules.UserName, 2)
                    objControl.UpdateTHOI_GIAN_CHAY_MAY(objInfo)
                End If
            Next
        End Sub
        Public Sub DeleteMotDongDuLieu()
            Dim objCtl As New clsTHOI_GIAN_CHAY_MAYController()
            If _MsMay = "" Then Exit Sub
            objCtl.InsertTHOI_GIAN_CHAY_MAY(_MsMay, _TuNgay.Date, "frmThoiGianChayMay", Commons.Modules.UserName, 3)
            objCtl.DeleteTHOI_GIAN_CHAY_MAY(_TuNgay.Date, _MsMay)
            'If _DtDsThoiGianChayMay Is Nothing Then Exit Sub
            'If _DvDsThoiGianChayMay Is Nothing Then Exit Sub

        End Sub
    End Class
End Namespace
