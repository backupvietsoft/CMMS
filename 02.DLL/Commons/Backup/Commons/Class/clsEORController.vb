Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Microsoft.VisualBasic.DateAndTime
Namespace VS.Classes.Catalogue
    Public Class clsEORController

        Public Sub New()
        End Sub
#Region "tab0"
        Public Function Get_EOR_ID(ByVal NGAY As String) As String
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_EOR_ID", NGAY)
            While objDataReader.Read
                Return objDataReader.Item("EOR_ID")
                objDataReader.Close()
            End While
            objDataReader.Close()
            Return ""
        End Function
        Public Function GetTOs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTOs"))
            Return objDataTable
        End Function
        Public Function GetTHIET_BIs(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHIET_BIs", USERNAME))
            Return objDataTable
        End Function

        Public Function GetMUC_UU_TIENs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
            Return objDataTable
        End Function

        Public Function GetCONG_NHANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs1"))
            Return objDataTable
        End Function

        Public Function GetEORs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal Duyet As Boolean) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEORs", TU_NGAY, DEN_NGAY, Commons.Modules.UserName, Duyet)) ', Commons.Modules.UserName
            Return objDataTable
        End Function

        Public Function GetLY_DO_SUA_CHUA(ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", intTypeLanguage))
            Return objDataTable
        End Function

        Public Function GetLY_DO_SUA_CHUAs_Theo_EOR_ID(ByVal EOR_ID As String, ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUAs_Theo_EOR_ID", EOR_ID, intTypeLanguage))
            Return objDataTable
        End Function

        Public Function GetEOR_TAI_LIEUs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_TAI_LIEUs", EOR_ID))
            Return objDataTable
        End Function

        Public Sub DeleteEOR_REFFERENCE(ByVal EOR_ID As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_REFFERENCE", EOR_ID)
        End Sub

        Public Sub DeleteEOR(ByVal EOR_ID As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR", EOR_ID)
        End Sub
        Public Sub AddEOR_REFFERENCE(ByVal objEOR_REFFERENCEInfo As clsEOR_REFFERENCEInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_REFFERENCE", objEOR_REFFERENCEInfo.EOR_ID, objEOR_REFFERENCEInfo.TEN_TAI_LIEU, objEOR_REFFERENCEInfo.DUONG_DAN, objEOR_REFFERENCEInfo.STT_YC_NSD, objEOR_REFFERENCEInfo.STT_GSTT, objEOR_REFFERENCEInfo.LOAI_TAI_LIEU1)
        End Sub

        Public Sub DeleteEOR_LY_DO_SUA_CHUA(ByVal EOR_ID As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_LY_DO_SUA_CHUA", EOR_ID)
        End Sub

        Public Sub AddEOR_LY_DO_SUA_CHUA(ByVal EOR_ID As String, ByVal MS_LY_DO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_LY_DO_SUA_CHUA", EOR_ID, MS_LY_DO)
        End Sub
        Function TaoEORID(ByVal ngay As String) As String
            Dim str As String = "", stt As String = ""
            Dim objEORController As New clsEORController()
            str = objEORController.Get_EOR_ID(ngay)
            If str = "" Then
                stt = "01"
            Else

                Dim t As Integer = 0
                t = str.Substring(9) + 1
                stt = IIf(t.ToString.Length < 2, "0" & t, t)
            End If
            str = "E" & IIf(Day(Date.Parse(ngay)).ToString.Length < 2, 0 & Day(Date.Parse(ngay)), Day(Date.Parse(ngay))) & IIf(Month(Date.Parse(ngay)).ToString.Length < 2, 0 & Month(Date.Parse(ngay)), Month(Date.Parse(ngay))) & Year(Date.Parse(ngay)) & stt
            Return str
        End Function
        Public Function CheckEorID(ByVal EOR_ID As String)
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT EOR_ID FROM EOR WHERE EOR_ID='" & EOR_ID & "'")
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
        Public Function AddEOR(ByVal objEORInfo As clsEORInfo) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim EOR_ID As String = objEORInfo.EOR_ID
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try

                If Not CheckEorID(EOR_ID) Then
                    EOR_ID = TaoEORID(objEORInfo.NGAY_LAP)
                End If
                SqlHelper.ExecuteNonQuery(objTrans, "AddEOR", objEORInfo.EOR_ID, objEORInfo.MS_MAY, objEORInfo.MO_TA_VAN_DE, objEORInfo.BAN_TO_LAP, _
                        objEORInfo.NGAY_LAP, objEORInfo.NGUOI_LAP, objEORInfo.MS_UU_TIEN, objEORInfo.MS_CN, objEORInfo.MS_CN1, objEORInfo.NGAY_KT_EOR, _
                        objEORInfo.NGAY_BD_KH, objEORInfo.NGAY_KT_KH, objEORInfo.LY_DO_KHAC)
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return EOR_ID
            Finally
                objConnection.Close()
            End Try
            Return EOR_ID

        End Function

        Public Sub UpdateEOR(ByVal objEORInfo As clsEORInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR", objEORInfo.EOR_ID, objEORInfo.MS_MAY, objEORInfo.MO_TA_VAN_DE, objEORInfo.BAN_TO_LAP, _
         objEORInfo.NGAY_LAP, objEORInfo.NGUOI_LAP, objEORInfo.MS_UU_TIEN, objEORInfo.MS_CN, objEORInfo.MS_CN1, objEORInfo.NGAY_KT_EOR, _
         objEORInfo.NGAY_BD_KH, objEORInfo.NGAY_KT_KH, objEORInfo.LY_DO_KHAC)
        End Sub

        Public Sub UpdateEOR_REFFERENCE(ByVal objEOR_REFFERENCEInfo As clsEOR_REFFERENCEInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_REFFERENCE", objEOR_REFFERENCEInfo.EOR_ID, objEOR_REFFERENCEInfo.STT, objEOR_REFFERENCEInfo.TEN_TAI_LIEU, objEOR_REFFERENCEInfo.LOAI_TAI_LIEU1)
        End Sub

        Public Sub DeleteEOR_LY_DO_SUA_CHUA_MS_LY_DO(ByVal EOR_ID As String, ByVal MS_LY_DO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_LY_DO_SUA_CHUA_MS_LY_DO", EOR_ID, MS_LY_DO)
        End Sub

        Public Sub DeleteEOR_REFFERENCE_STT(ByVal EOR_ID As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_REFFERENCE_STT", EOR_ID, STT)
        End Sub

        Public Function GetLOAI_TAI_LIEUs(ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_TAI_LIEUs", intTypeLanguage))
            Return objDataTable
        End Function
#End Region
#Region "tab1"
        Public Function GetEOR_SERVICE_CHUNGs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_SERVICE_CHUNGs", EOR_ID))
            Return objDataTable
        End Function
        Public Sub AddEOR_SERVICE_CHUNG(ByVal objEOR_SERVICE_CHUNGInfo As clsEOR_SERVICE_CHUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_SERVICE_CHUNG", objEOR_SERVICE_CHUNGInfo.EOR_ID, objEOR_SERVICE_CHUNGInfo.NOI_DUNG_SERVICE, objEOR_SERVICE_CHUNGInfo.SO_LUONG, _
         objEOR_SERVICE_CHUNGInfo.DON_GIA, objEOR_SERVICE_CHUNGInfo.NGOAI_TE, objEOR_SERVICE_CHUNGInfo.TY_GIA, objEOR_SERVICE_CHUNGInfo.TY_GIA_USD, objEOR_SERVICE_CHUNGInfo.MS_KH, objEOR_SERVICE_CHUNGInfo.NGUOI_GIAO_DICH, objEOR_SERVICE_CHUNGInfo.MS_PHIEU_BAO_TRI)
        End Sub
        Public Sub UpdateEOR_SERVICE_CHUNG(ByVal objEOR_SERVICE_CHUNGInfo As clsEOR_SERVICE_CHUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_SERVICE_CHUNG", objEOR_SERVICE_CHUNGInfo.EOR_ID, objEOR_SERVICE_CHUNGInfo.STT, objEOR_SERVICE_CHUNGInfo.NOI_DUNG_SERVICE, objEOR_SERVICE_CHUNGInfo.SO_LUONG, _
         objEOR_SERVICE_CHUNGInfo.DON_GIA, objEOR_SERVICE_CHUNGInfo.NGOAI_TE, objEOR_SERVICE_CHUNGInfo.TY_GIA, objEOR_SERVICE_CHUNGInfo.TY_GIA_USD, objEOR_SERVICE_CHUNGInfo.MS_KH, objEOR_SERVICE_CHUNGInfo.NGUOI_GIAO_DICH, objEOR_SERVICE_CHUNGInfo.MS_PHIEU_BAO_TRI)
        End Sub
        Public Sub DeleteEOR_SERVICE_CHUNG(ByVal EOR_ID As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_SERVICE_CHUNG", EOR_ID, STT)
        End Sub

        Public Function GetNHA_CUNG_CAP() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_CUNG_CAP"))
            Return objDataTable
        End Function

        Public Function GetNGUOI_DAI_DIENs(ByVal MS_KH As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUOI_DAI_DIENs", MS_KH))
            Return objDataTable
        End Function
        Public Function GetTI_GIA(ByVal NGOAI_TE As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE))
            Return objDataTable
        End Function

        Public Function GetNGUOI_DAI_DIEN() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUOI_DAI_DIEN"))
            Return objDataTable
        End Function
        Public Function GetTHONG_TIN_KHACH_HANG() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_TIN_KHACH_HANG"))
            Return objDataTable
        End Function

        Public Function GetNGOAI_TEs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGOAI_TEs"))
            Return objDataTable
        End Function

        Public Function GetNGUOI_DAI_DIENs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUOI_DAI_DIENs"))
            Return objDataTable
        End Function
#End Region
#Region "tab2"
        Public Function GetEOR_SERVICE_MNRs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_SERVICE_MNRs", EOR_ID))
            Return objDataTable
        End Function

        Public Function GetEOR_TINH_TRANG_MNR(ByVal EOR_ID As String, ByVal STT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_TINH_TRANG_MNR", EOR_ID, STT))
            Dim priCol(4) As DataColumn
            priCol(0) = objDataTable.Columns("EOR_ID")
            priCol(1) = objDataTable.Columns("STT")
            priCol(2) = objDataTable.Columns("BO_PHAN")
            priCol(3) = objDataTable.Columns("MS_TINH_TRANG")
            priCol(4) = objDataTable.Columns("MS_GIAI_PHAP")
            objDataTable.PrimaryKey = priCol
            Return objDataTable
        End Function
        Public Function GetGIAI_PHAPs(ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAI_PHAPs", intTypeLanguage))
            Return objDataTable
        End Function
        Public Function GetTINH_TRANG_BO_PHANs(ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTINH_TRANG_BO_PHANs", intTypeLanguage))
            Return objDataTable
        End Function

        Public Function GetIC_PHU_TUNG1(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG1", USERNAME))
            Return objDataTable
        End Function
        Public Sub AddEOR_SERVICE_MNR(ByVal objEOR_SERVICE_CHUNGInfo As clsEOR_SERVICE_CHUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_SERVICE_MNR", objEOR_SERVICE_CHUNGInfo.EOR_ID, objEOR_SERVICE_CHUNGInfo.NOI_DUNG_SERVICE, objEOR_SERVICE_CHUNGInfo.SO_LUONG, _
         objEOR_SERVICE_CHUNGInfo.DON_GIA, objEOR_SERVICE_CHUNGInfo.NGOAI_TE, objEOR_SERVICE_CHUNGInfo.TY_GIA, objEOR_SERVICE_CHUNGInfo.TY_GIA_USD, objEOR_SERVICE_CHUNGInfo.MS_KH, objEOR_SERVICE_CHUNGInfo.NGUOI_GIAO_DICH, objEOR_SERVICE_CHUNGInfo.MS_PHIEU_BAO_TRI)
        End Sub
        Public Sub UpdateEOR_SERVICE_MNR(ByVal objEOR_SERVICE_CHUNGInfo As clsEOR_SERVICE_CHUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_SERVICE_MNR", objEOR_SERVICE_CHUNGInfo.EOR_ID, objEOR_SERVICE_CHUNGInfo.STT, objEOR_SERVICE_CHUNGInfo.NOI_DUNG_SERVICE, objEOR_SERVICE_CHUNGInfo.SO_LUONG, _
         objEOR_SERVICE_CHUNGInfo.DON_GIA, objEOR_SERVICE_CHUNGInfo.NGOAI_TE, objEOR_SERVICE_CHUNGInfo.TY_GIA, objEOR_SERVICE_CHUNGInfo.TY_GIA_USD, objEOR_SERVICE_CHUNGInfo.MS_KH, objEOR_SERVICE_CHUNGInfo.NGUOI_GIAO_DICH, objEOR_SERVICE_CHUNGInfo.MS_PHIEU_BAO_TRI)
        End Sub

        Public Sub AddEOR_TINH_TRANG_MNR(ByVal objEOR_TINH_TRANG_SERVICEInfo As clsEOR_TINH_TRANGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_TINH_TRANG_MNR", objEOR_TINH_TRANG_SERVICEInfo.EOR_ID, objEOR_TINH_TRANG_SERVICEInfo.STT, objEOR_TINH_TRANG_SERVICEInfo.BO_PHAN, _
         objEOR_TINH_TRANG_SERVICEInfo.MS_TINH_TRANG, objEOR_TINH_TRANG_SERVICEInfo.MS_GIAI_PHAP)
        End Sub

        Public Sub DeleteEOR_TINH_TRANG_MNR(ByVal objEOR_TINH_TRANG_SERVICEInfo As clsEOR_TINH_TRANGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_TINH_TRANG_MNR", objEOR_TINH_TRANG_SERVICEInfo.EOR_ID, objEOR_TINH_TRANG_SERVICEInfo.STT, objEOR_TINH_TRANG_SERVICEInfo.BO_PHAN, _
         objEOR_TINH_TRANG_SERVICEInfo.MS_TINH_TRANG, objEOR_TINH_TRANG_SERVICEInfo.MS_GIAI_PHAP)
        End Sub
        Public Sub DeleteEOR_TINH_TRANG_MNR1(ByVal EOR_ID As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_TINH_TRANG_MNR1", EOR_ID, STT)
        End Sub

        Public Sub DeleteEOR_SERVICE_MNR(ByVal EOR_ID As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_SERVICE_MNR", EOR_ID, STT)
        End Sub
        Public Function GetPHU_TUNG1(ByVal MS_PT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG1", MS_PT))
            Return objDataTable
        End Function

        Public Function GetEOR_TINH_TRANG() As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_TINH_TRANG")
            Dim tmp As Integer = 0
            While objDataReader.Read
                tmp = objDataReader.Item("STT")
            End While
            objDataReader.Close()
            Return tmp
        End Function

        Public Function GetEOR_TINH_TRANG_MNRs(ByVal EOR_ID As String, ByVal STT As Integer, ByVal BO_PHAN As String, ByVal MS_TINH_TRANG As String, ByVal MS_GIAI_PHAP As String) As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_TINH_TRANG_MNRs", EOR_ID, STT, BO_PHAN, MS_TINH_TRANG, MS_GIAI_PHAP)
            Dim tmp As Integer = 0
            While objDataReader.Read
                tmp = objDataReader.Item("STT")
            End While
            objDataReader.Close()
            Return tmp
        End Function
#End Region
#Region "tab3"


        Public Function GetEOR_PHU_TUNGs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_PHU_TUNGs", EOR_ID))
            Return objDataTable
        End Function

        Public Function GetEOR_TINH_TRANG_PHU_TUNGs(ByVal EOR_ID As String, ByVal MS_PT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_TINH_TRANG_PHU_TUNGs", EOR_ID, MS_PT))
            Dim priCol(2) As DataColumn
            priCol(0) = objDataTable.Columns("EOR_ID")
            priCol(1) = objDataTable.Columns("MS_PT")
            priCol(2) = objDataTable.Columns("MS_TINH_TRANG")
            objDataTable.PrimaryKey = priCol
            Return objDataTable
        End Function

        Public Sub DeleteEOR_PHU_TUNG(ByVal EOR_ID As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_PHU_TUNG", EOR_ID, MS_PT)
        End Sub

        Public Sub DeleteEOR_TINH_TRANG_PHU_TUNG(ByVal EOR_ID As String, ByVal MS_PT As String, ByVal MS_TING_TRANG As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_TINH_TRANG_PHU_TUNG", EOR_ID, MS_PT, MS_TING_TRANG)
        End Sub
        Public Sub DeleteEOR_TINH_TRANG_PHU_TUNGs(ByVal EOR_ID As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_TINH_TRANG_PHU_TUNGs", EOR_ID, MS_PT)
        End Sub
        Public Sub AddEOR_PHU_TUNG(ByVal objEOR_PHU_TUNGInfo As clsEOR_PHU_TUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_PHU_TUNG", objEOR_PHU_TUNGInfo.EOR_ID, objEOR_PHU_TUNGInfo.MS_PT, objEOR_PHU_TUNGInfo.SO_LUONG, _
         objEOR_PHU_TUNGInfo.DON_GIA, objEOR_PHU_TUNGInfo.NGOAI_TE, objEOR_PHU_TUNGInfo.TY_GIA, objEOR_PHU_TUNGInfo.TY_GIA_USD, objEOR_PHU_TUNGInfo.MS_KH, objEOR_PHU_TUNGInfo.NGUOI_GIAO_DICH)
        End Sub

        Public Sub UpdateEOR_PHU_TUNG(ByVal objEOR_PHU_TUNGInfo As clsEOR_PHU_TUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_PHU_TUNG", objEOR_PHU_TUNGInfo.EOR_ID, objEOR_PHU_TUNGInfo.MS_PT, objEOR_PHU_TUNGInfo.SO_LUONG, _
         objEOR_PHU_TUNGInfo.DON_GIA, objEOR_PHU_TUNGInfo.NGOAI_TE, objEOR_PHU_TUNGInfo.TY_GIA, objEOR_PHU_TUNGInfo.TY_GIA_USD, objEOR_PHU_TUNGInfo.MS_KH, objEOR_PHU_TUNGInfo.NGUOI_GIAO_DICH)
        End Sub
        Public Sub AddEOR_TINH_TRANG_PHU_TUNG(ByVal EOR_ID As String, ByVal MS_PT As String, ByVal MS_TINH_TRANG As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_TINH_TRANG_PHU_TUNG", EOR_ID, MS_PT, MS_TINH_TRANG)
        End Sub

        Public Function CheckEOR_PHU_TUNG(ByVal EOR_ID As String, ByVal MS_PT As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckEOR_PHU_TUNG", EOR_ID, MS_PT)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
#End Region
#Region "tab4"
        Public Function GetEOR_CONG_VIECs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_CONG_VIECs", EOR_ID))
            Return objDataTable
        End Function

        Public Function GetEOR_CONG_VIEC_PHU_TROs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SQLHELPER.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_CONG_VIEC_PHU_TROs", EOR_ID))
            Return objDataTable
        End Function
        Public Sub AddEOR_CONG_VIEC(ByVal objEOR_CONG_VIECInfo As clsEOR_CONG_VIECInfo)
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_CONG_VIEC", objEOR_CONG_VIECInfo.EOR_ID, objEOR_CONG_VIECInfo.MS_CV, objEOR_CONG_VIECInfo.MS_BO_PHAN, objEOR_CONG_VIECInfo.TU_GIO, _
             objEOR_CONG_VIECInfo.TU_NGAY, objEOR_CONG_VIECInfo.DEN_GIO, objEOR_CONG_VIECInfo.DEN_NGAY, objEOR_CONG_VIECInfo.THOI_GIAN_VICT, objEOR_CONG_VIECInfo.THOI_GIAN_VENDOR, objEOR_CONG_VIECInfo.MS_PHIEU_BAO_TRI, objEOR_CONG_VIECInfo.NHAN_VIEN)
            Catch ex As Exception
                Windows.Forms.MessageBox.Show(ex.ToString)
            End Try
        End Sub

        Public Sub AddEOR_CONG_VIEC_PHU_TRO(ByVal objEOR_CONG_VIECInfo As clsEOR_CONG_VIEC_PHU_TROInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddEOR_CONG_VIEC_PHU_TRO", objEOR_CONG_VIECInfo.EOR_ID, objEOR_CONG_VIECInfo.TEN_CONG_VIEC, objEOR_CONG_VIECInfo.TU_GIO, _
         objEOR_CONG_VIECInfo.TU_NGAY, objEOR_CONG_VIECInfo.DEN_GIO, objEOR_CONG_VIECInfo.DEN_NGAY, objEOR_CONG_VIECInfo.THOI_GIAN_VICT, objEOR_CONG_VIECInfo.THOI_GIAN_VENDOR, objEOR_CONG_VIECInfo.MS_PHIEU_BAO_TRI, objEOR_CONG_VIECInfo.NHAN_VIEN)
        End Sub

        Public Sub UpdateEOR_CONG_VIEC_PHU_TRO(ByVal objEOR_CONG_VIECInfo As clsEOR_CONG_VIEC_PHU_TROInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_CONG_VIEC_PHU_TRO", objEOR_CONG_VIECInfo.EOR_ID, objEOR_CONG_VIECInfo.STT, objEOR_CONG_VIECInfo.TEN_CONG_VIEC, objEOR_CONG_VIECInfo.TU_GIO, _
         objEOR_CONG_VIECInfo.TU_NGAY, objEOR_CONG_VIECInfo.DEN_GIO, objEOR_CONG_VIECInfo.DEN_NGAY, objEOR_CONG_VIECInfo.THOI_GIAN_VICT, objEOR_CONG_VIECInfo.THOI_GIAN_VENDOR, objEOR_CONG_VIECInfo.MS_PHIEU_BAO_TRI, objEOR_CONG_VIECInfo.NHAN_VIEN)
        End Sub

        Public Sub DeleteEOR_CONG_VIEC(ByVal EOR_ID As String, ByVal MS_CV As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_CONG_VIEC", EOR_ID, MS_CV)
        End Sub

        Public Sub DeleteEOR_CONG_VIEC_PHU_TRO(ByVal EOR_ID As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_CONG_VIEC_PHU_TRO", EOR_ID, STT)
        End Sub

        Public Sub DeleteEOR_CONG_VIECs(ByVal EOR_ID As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteEOR_CONG_VIECs", EOR_ID)
        End Sub
#End Region
#Region "tab6"


        Public Function GetPHE_DUYET_EORs(ByVal EOR_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHE_DUYET_EORs", EOR_ID))
            Return objDataTable
        End Function

        Public Sub UpdatePHE_DUYET_EOR(ByVal objEORInfo As clsEORInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHE_DUYET_EOR", objEORInfo.EOR_ID, objEORInfo.LEADER_DUYET, objEORInfo.LEADER_COMMENT, objEORInfo.GHI_CHU_1, _
         objEORInfo.LEADER_NAME)
        End Sub
        Public Sub UpdatePHE_DUYET_EOR1(ByVal objEORInfo As clsEORInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHE_DUYET_EOR1", objEORInfo.EOR_ID, _
         objEORInfo.COST_CONTROL_DUYET, objEORInfo.COST_CONTROL_COMMENT, objEORInfo.GHI_CHU_2, objEORInfo.COST_CONTROL_NAME)
        End Sub

        Public Function GetCHUC_NANG_EOR(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_NANG_EOR", USERNAME))
            Return objDataTable
        End Function
#End Region
    End Class
End Namespace
