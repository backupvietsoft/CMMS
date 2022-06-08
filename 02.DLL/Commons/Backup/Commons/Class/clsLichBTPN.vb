Imports Commons.VS.Classes.Admin
'Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.Common
'Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Admin
    Public Class clsLichBTPN
        Private Const LOC_THEO_CHU_KY = -1       'Nếu không muốn lọc để loại bỏ các chu kỳ bị trùng thì gán = -1

        Private dtReader As SqlDataReader
        Private objTinhCK As New clsTinhChuKyBTPN
        Private strNgay As String
        Private sConnect As String = Commons.IConnections.ConnectionString

        Public Sub TaoDuLieu(ByVal dateDenNgay As Date, Optional ByVal sGiaiDoan As String = "")
            'test
            Try
                Commons.Modules.SQLString = "DROP TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            Commons.Modules.SQLString = "CREATE TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " (MS_MAY nvarchar (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,NGAY_CUOI datetime NULL ,THU_TU int NULL ,MS_LOAI_BT int NOT NULL ,	[CHU_KY] [int] NULL ,MS_DV_TG int NULL ,NGAY_GH datetime NULL ) "
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & "( MS_MAY, MS_LOAI_BT, NGAY_CUOI ,CHU_KY, MS_DV_TG ) SELECT V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY, V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT, DBO.TINHCHUKY(CONVERT(NVARCHAR(10),[MAY_LOAI_BTPN].[NGAY_CUOI],103),[V_MAY_LOAI_BTPN_CHU_KY_MAX].[CHU_KY],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[MS_DV_TG]) AS NGAY_CUOI, V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY, V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG FROM (V_MAY_LOAI_BTPN_CHU_KY_MAX INNER JOIN MAY_LOAI_BTPN ON (V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT = MAY_LOAI_BTPN.MS_LOAI_BT) AND (V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY = MAY_LOAI_BTPN.MS_MAY)) inner join MAY ON MAY.MS_MAY = MAY_LOAI_BTPN.MS_MAY INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
            "INNER JOIN LOAI_BAO_TRI ON MAY_LOAI_BTPN.MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT WHERE (((V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY)>1) AND ((V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG)=1)) OR (((V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG)<>1)) and ((DBO.TINHCHUKY(CONVERT(NVARCHAR(10),[MAY_LOAI_BTPN].[NGAY_CUOI],103),[V_MAY_LOAI_BTPN_CHU_KY_MAX].[CHU_KY],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[MS_DV_TG])) <= '" & Format(DateValue(dateDenNgay), "MM/dd/yyyy") & "' )"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "DELETE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY WHERE (((MAY.MS_HIEN_TRANG)<>2));"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "SELECT * FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " ORDER BY MS_MAY, NGAY_CUOI, MS_LOAI_BT"

            dtReader = SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Dim strMS_MAY As String
            Dim intMS_LOAI_BT, intCHU_KY, intMS_DV_TG As Integer
            Dim dateNGAY_CUOI As Date

            While dtReader.Read
                strMS_MAY = dtReader.Item("MS_MAY")
                intMS_LOAI_BT = dtReader.Item("MS_LOAI_BT")
                intCHU_KY = dtReader.Item("CHU_KY")
                dateNGAY_CUOI = dtReader.Item("NGAY_CUOI")
                intMS_DV_TG = dtReader.Item("MS_DV_TG")
                Do While DateValue(dateNGAY_CUOI) <= DateValue(dateDenNgay)
                    Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,NGAY_CUOI,CHU_KY,MS_DV_TG) VALUES(N'" & strMS_MAY & "'," & intMS_LOAI_BT & ",'" & Format(dateNGAY_CUOI, "MM/dd/yyyy") & "'," & intCHU_KY & "," & intMS_DV_TG & ")"
                    SqlHelper.ExecuteScalar(sConnect, "QL_SEARCH", Commons.Modules.SQLString)
                    dateNGAY_CUOI = DateValue(objTinhCK.TinhChuKy(Format(dateNGAY_CUOI, "Short date"), dtReader.Item("CHU_KY"), dtReader.Item("MS_DV_TG")))
                Loop
            End While
            dtReader.Close()

            If sGiaiDoan.Trim <> "" Then
                SqlHelper.ExecuteNonQuery(sConnect, CommandType.Text, "DELETE FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI NOT IN (SELECT NGAY_CUOI FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE 1=1 " & sGiaiDoan & ")")
            End If

            Commons.Modules.SQLString = "DELETE A FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY=B.MS_MAY AND A.MS_LOAI_BT =B.MS_LOAI_BT WHERE A.NGAY_CUOI<=B.NGAY_CUOI OR A.NGAY_CUOI>'" & Format(dateDenNgay, "MM/dd/yyyy") & "'"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
        End Sub

        Public Sub TaoDuLieu1(ByVal dateDenNgay As Date, ByVal LoaiMay As String, ByVal MS_MAY As String)
            'test
            Try
                Commons.Modules.SQLString = "DROP TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            Commons.Modules.SQLString = "CREATE TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " (MS_MAY nvarchar (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,NGAY_CUOI datetime NULL ,THU_TU int NULL ,MS_LOAI_BT int NOT NULL ,	[CHU_KY] [int] NULL ,MS_DV_TG int NULL ,NGAY_GH datetime NULL ) "
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & "( MS_MAY, MS_LOAI_BT, NGAY_CUOI ,CHU_KY, MS_DV_TG ) SELECT V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY, V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT, DBO.TINHCHUKY([MAY_LOAI_BTPN].[NGAY_CUOI],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[CHU_KY],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[MS_DV_TG]) AS NGAY_CUOI, V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY, V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG FROM (V_MAY_LOAI_BTPN_CHU_KY_MAX INNER JOIN MAY_LOAI_BTPN ON (V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT = MAY_LOAI_BTPN.MS_LOAI_BT) AND (V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY = MAY_LOAI_BTPN.MS_MAY)) inner join MAY ON MAY.MS_MAY = MAY_LOAI_BTPN.MS_MAY INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
            " INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY =NHOM_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
            " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_MAY.GROUP_ID INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID  INNER JOIN LOAI_BAO_TRI ON MAY_LOAI_BTPN.MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT WHERE ((((V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY)>1) AND ((V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG)=1)) OR (((V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG)<>1)) and ((DBO.TINHCHUKY([MAY_LOAI_BTPN].[NGAY_CUOI],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[CHU_KY],[V_MAY_LOAI_BTPN_CHU_KY_MAX].[MS_DV_TG])) <= '" & Format(DateValue(dateDenNgay), "MM/dd/yyyy") & "' ))"
            If LoaiMay <> "-1" Then
                Commons.Modules.SQLString = Commons.Modules.SQLString + " And LOAI_MAY.MS_LOAI_MAY='" & LoaiMay & "'"
            End If
            If MS_MAY <> "-1" Then
                Commons.Modules.SQLString = Commons.Modules.SQLString + " and V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY=N'" & MS_MAY & "'"
            End If
            Commons.Modules.SQLString = Commons.Modules.SQLString + " AND USERNAME='" & Commons.Modules.UserName & "'"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "DELETE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY WHERE (((MAY.MS_HIEN_TRANG)<>2));"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "SELECT * FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " ORDER BY MS_MAY, NGAY_CUOI, MS_LOAI_BT"

            dtReader = SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Dim strMS_MAY As String
            Dim intMS_LOAI_BT, intCHU_KY, intMS_DV_TG As Integer
            Dim dateNGAY_CUOI As Date

            While dtReader.Read
                strMS_MAY = dtReader.Item("MS_MAY")
                intMS_LOAI_BT = dtReader.Item("MS_LOAI_BT")
                intCHU_KY = dtReader.Item("CHU_KY")
                dateNGAY_CUOI = dtReader.Item("NGAY_CUOI")
                intMS_DV_TG = dtReader.Item("MS_DV_TG")
                Do While DateValue(dateNGAY_CUOI) <= DateValue(dateDenNgay)
                    Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,NGAY_CUOI,CHU_KY,MS_DV_TG) VALUES(N'" & strMS_MAY & "'," & intMS_LOAI_BT & ",'" & Format(dateNGAY_CUOI, "MM/dd/yyyy") & "'," & intCHU_KY & "," & intMS_DV_TG & ")"
                    SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
                    dateNGAY_CUOI = DateValue(objTinhCK.TinhChuKy(dateNGAY_CUOI, dtReader.Item("CHU_KY"), dtReader.Item("MS_DV_TG")))
                Loop
            End While
            dtReader.Close()

            Commons.Modules.SQLString = "DELETE A FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY=B.MS_MAY AND A.MS_LOAI_BT =B.MS_LOAI_BT WHERE A.NGAY_CUOI<=B.NGAY_CUOI OR A.NGAY_CUOI>'" & Format(dateDenNgay, "MM/dd/yyyy") & "'"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

        End Sub

        Public Sub TaoDuLieu2(ByVal prg As Windows.Forms.ProgressBar, ByVal dateTuNgay As Date, ByVal dateDenNgay As Date, _
                ByVal sNhomMay As String, ByVal sLoaiMay As String, ByVal sMay As String, _
                ByVal sNX As String, ByVal sTinh As String, ByVal sQuan As String, _
                Optional ByVal sGiaiDoan As String = "", Optional ByVal iMsHThong As Integer = -1)

            prg.Value = 0
            prg.Step = 50
            prg.Maximum = 900

            Commons.Modules.ObjSystems.XoaTable("DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName)

            Commons.Modules.SQLString = "CREATE TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & _
                " (MS_MAY nvarchar (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,NGAY_CUOI datetime NULL ,THU_TU int NULL , " & _
                " MS_LOAI_BT int NOT NULL ,	[CHU_KY] [int] NULL,MS_DV_TG int NULL ,NGAY_GH_DUOI datetime NULL,NGAY_GH datetime NULL, " & _
                " NGAY_TINH datetime NULL ) "
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            ' ''Insert dữ liệu tinh theo chu ky 
            Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & _
                    "( MS_MAY, MS_LOAI_BT, NGAY_CUOI, THU_TU ,CHU_KY, MS_DV_TG ) " & _
                    " SELECT     dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY, dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT, dbo.TinhChuKy(CONVERT(NVARCHAR(10), dbo.MAY_LOAI_BTPN.NGAY_CUOI, 103),  " & _
                    " dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY, dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG) AS NGAY_CUOI, dbo.LOAI_BAO_TRI.THU_TU,  " & _
                    " dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY, dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG " & _
                    " FROM         (SELECT     MS_N_XUONG " & _
                    " FROM          dbo.MashjGetNXUser(N'" & Commons.Modules.UserName & "', '" & sNX & "') AS MashjGetNXUser_1) AS NNX INNER JOIN " & _
                    " dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX INNER JOIN " & _
                    " dbo.MAY_LOAI_BTPN ON dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_LOAI_BT = dbo.MAY_LOAI_BTPN.MS_LOAI_BT AND  " & _
                    " dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY = dbo.MAY_LOAI_BTPN.MS_MAY INNER JOIN " & _
                    " dbo.MAY ON dbo.MAY.MS_MAY = dbo.MAY_LOAI_BTPN.MS_MAY INNER JOIN " & _
                    " dbo.NHOM_MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " & _
                    " dbo.LOAI_BAO_TRI ON dbo.MAY_LOAI_BTPN.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
                    " (SELECT     NHOM_LOAI_MAY_1.MS_LOAI_MAY, dbo.USERS.USERNAME " & _
                    " FROM          dbo.NHOM_LOAI_MAY AS NHOM_LOAI_MAY_1 INNER JOIN " & _
                    " dbo.NHOM ON NHOM_LOAI_MAY_1.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " & _
                    " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID " & _
                    " WHERE      (dbo.USERS.USERNAME = N'" & Commons.Modules.UserName & "')) AS NHOM_LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                    " dbo.MAY_NHA_XUONG_NGAY_MAX AS MAY_NHA_XUONG ON dbo.MAY_LOAI_BTPN.MS_MAY = MAY_NHA_XUONG.MS_MAY INNER JOIN " & _
                    " dbo.NHA_XUONG ON MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON NNX.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG LEFT OUTER JOIN " & _
                    " dbo.Y_Tinh INNER JOIN " & _
                    " dbo.Y_District ON dbo.Y_Tinh.MA_QG = dbo.Y_District.ms_cha ON dbo.Y_District.ma_qg = dbo.NHA_XUONG.MS_QG " & _
                    " WHERE  ((CHU_KY IS NOT NULL) OR (MS_DV_TG IS NOT NULL) OR (dbo.TinhChuKy(CONVERT(NVARCHAR(10), dbo.MAY_LOAI_BTPN.NGAY_CUOI, 103),   dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.CHU_KY, " & _
                    " dbo.V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_DV_TG) IS NOT NULL) ) "

            If sNhomMay <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (NHOM_MAY.MS_NHOM_MAY='" & sNhomMay & "') "
            If sLoaiMay <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (NHOM_MAY.MS_LOAI_MAY='" & sLoaiMay & "') "
            If sMay <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (MAY.MS_MAY=N'" & sMay & "') "

            If iMsHThong <> -1 Then Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND (dbo.MGetHTTheoNgay(V_MAY_LOAI_BTPN_CHU_KY_MAX.MS_MAY , '" & Format(DateValue(dateDenNgay), "MM/dd/yyyy") & " ') =  " & iMsHThong & " )"


            'If sNX <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND MAY_NHA_XUONG.MS_N_XUONG = N'" & sNX & "' "
            If sTinh <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (dbo.Y_Tinh.ma_qg = N'" & sTinh & "') "
            If sQuan <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (dbo.Y_District.ma_qg = N'" & sQuan & "') "

            If sGiaiDoan <> "" Then Commons.Modules.SQLString = Commons.Modules.SQLString & " " & sGiaiDoan
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()

            Commons.Modules.SQLString = "DELETE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY WHERE (((MAY.MS_HIEN_TRANG)<>2));"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "SELECT * FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " ORDER BY MS_MAY, NGAY_CUOI, MS_LOAI_BT"

            dtReader = SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Dim strMS_MAY As String
            Dim intMS_LOAI_BT, intCHU_KY, intMS_DV_TG As Integer, intTHU_TU As Integer
            Dim dateNGAY_CUOI As Date
            Dim datNgayKe As Date
            Dim sNgay As TimeSpan
            Dim sNgayCK As Integer

            While dtReader.Read
                Try

                    strMS_MAY = dtReader.Item("MS_MAY")
                    intMS_LOAI_BT = dtReader.Item("MS_LOAI_BT")
                    intCHU_KY = dtReader.Item("CHU_KY")
                    dateNGAY_CUOI = dtReader.Item("NGAY_CUOI")
                    intMS_DV_TG = dtReader.Item("MS_DV_TG")
                    intTHU_TU = dtReader.Item("THU_TU")
                    datNgayKe = dateNGAY_CUOI

                    sNgay = DateValue(dateTuNgay) - DateValue(dateNGAY_CUOI)

                    If intMS_DV_TG = 1 Then
                        sNgayCK = Fix(sNgay.Days / intCHU_KY) * intCHU_KY
                        datNgayKe = dateNGAY_CUOI.AddDays(sNgayCK)
                    Else
                        If intMS_DV_TG = 2 Then
                            sNgayCK = Fix(((sNgay.Days) / 7) / intCHU_KY) * intCHU_KY
                            datNgayKe = dateNGAY_CUOI.AddDays(sNgayCK * 7)
                        Else
                            If intMS_DV_TG = 3 Then
                                sNgayCK = Fix(Commons.Modules.ObjSystems.MGetSoNgayThang(DateValue(dateTuNgay), DateValue(dateNGAY_CUOI)) / intCHU_KY) * intCHU_KY
                                datNgayKe = dateNGAY_CUOI.AddMonths(sNgayCK)
                            Else
                                sNgayCK = Fix(((sNgay.Days) / 365) / intCHU_KY) * intCHU_KY
                                datNgayKe = dateNGAY_CUOI.AddYears(sNgayCK)
                            End If
                        End If
                    End If

                    dateNGAY_CUOI = datNgayKe
                    'cuoi+n* chu ky
                    'dateNGAY_CUOI = DateValue(objTinhCK.TinhChuKy(Format(dateNGAY_CUOI, "Short date"), _
                    '        dtReader.Item("CHU_KY"), dtReader.Item("MS_DV_TG")))

                    'Ngày kế -01 chu kỳ <=ngày hiện tại ==>Ngày cuối đến hiện tại
                    Do While DateValue(dateNGAY_CUOI) <= DateValue(dateDenNgay)
                        Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & _
                                "(MS_MAY,MS_LOAI_BT,NGAY_CUOI,THU_TU,CHU_KY,MS_DV_TG,NGAY_TINH) VALUES(N'" & strMS_MAY & "'," & intMS_LOAI_BT & ",'" & _
                                Format(dateNGAY_CUOI, "MM/dd/yyyy") & "'," & intTHU_TU & "," & intCHU_KY & "," & intMS_DV_TG & ", '" & _
                                Format(datNgayKe, "MM/dd/yyyy") & "' )"
                        'SqlHelper.ExecuteScalar(sConnect, "QL_SEARCH", commons.Modules.SQLString)
                        SqlHelper.ExecuteNonQuery(sConnect, CommandType.Text, Commons.Modules.SQLString)
                        dateNGAY_CUOI = DateValue(objTinhCK.TinhChuKy(Format(dateNGAY_CUOI, "Short date"), _
                                dtReader.Item("CHU_KY"), dtReader.Item("MS_DV_TG")))
                    Loop
                Catch ex As Exception

                End Try

            End While
            dtReader.Close()
            prg.PerformStep()
            Commons.Modules.SQLString = "DELETE FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI NOT IN (SELECT NGAY_CUOI FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI  BETWEEN '" & Format(DateValue(dateTuNgay), "MM/dd/yyyy") & "' AND '" & Format(DateValue(dateDenNgay), "MM/dd/yyyy") & "')"
            SqlHelper.ExecuteNonQuery(sConnect, CommandType.Text, "DELETE FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI NOT IN (SELECT NGAY_CUOI FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI  BETWEEN '" & Format(DateValue(dateTuNgay), "MM/dd/yyyy") & "' AND '" & Format(DateValue(dateDenNgay), "MM/dd/yyyy") & "')")

            Commons.Modules.SQLString = "DELETE A FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY=B.MS_MAY AND A.MS_LOAI_BT =B.MS_LOAI_BT WHERE A.NGAY_CUOI<=B.NGAY_CUOI OR ( A.NGAY_CUOI<'" & Format(dateTuNgay, "MM/dd/yyyy") & "' AND A.NGAY_CUOI>'" & Format(dateDenNgay, "MM/dd/yyyy") & "')"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "DELETE FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " WHERE NGAY_CUOI IS NULL OR NGAY_CUOI = ''"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

        End Sub

        Public Sub XoaP4CK(ByVal prg As Windows.Forms.ProgressBar)

            Dim dtDU_LIEU_KE_HOACH_BTDK As New DataTable
            Dim dtDU_LIEU_TAM As New DataTable
            Dim bPhuThuoc As Boolean = False
            'tao table ban dau
            Try
                clsXuLy.DropTable(sConnect, "DU_LIEU_BAO_CAO_KHBT_CHU_KY_TMP" & Commons.Modules.UserName)
                clsXuLy.DropTable(sConnect, "DU_LIEU_BAO_CAO_KHBT_DOC_LAP_TMP" & Commons.Modules.UserName)
                clsXuLy.DropTable(sConnect, "PHU" & Commons.Modules.UserName)
            Catch ex As Exception

            End Try

            Commons.Modules.SQLString = "SELECT DISTINCT DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY, DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI, LOAI_BAO_TRI.THU_TU, DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT, DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".CHU_KY, DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_DV_TG, " & _
                     "DATEADD(DAY,-2-(CASE MS_DV_TG WHEN 1 THEN CHU_KY ELSE CASE MS_DV_TG WHEN 2 THEN (CHU_KY*7.5)/4 ELSE CASE MS_DV_TG WHEN 3 THEN (CHU_KY*30)/4 ELSE (CHU_KY*365)/4 END END END),NGAY_CUOI) AS  NGAY_GH_DUOI, " & _
                     "DATEADD(DAY,2+(CASE MS_DV_TG WHEN 1 THEN CHU_KY ELSE CASE MS_DV_TG WHEN 2 THEN (CHU_KY*7.5)/4 ELSE CASE MS_DV_TG WHEN 3 THEN (CHU_KY*30)/4 ELSE (CHU_KY*365)/4 END END END),NGAY_CUOI) AS  NGAY_GH " & _
                     "INTO PHU" & Commons.Modules.UserName & " " & _
                     "FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN LOAI_BAO_TRI ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT ORDER BY DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY, DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI, LOAI_BAO_TRI.THU_TU DESC"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()

            'LAY NHUNG MAY CO CHU KY DOC LAP (THU TU = 0) RA BANG TAM
            Commons.Modules.SQLString = "SELECT * INTO DU_LIEU_BAO_CAO_KHBT_DOC_LAP_TMP" & Commons.Modules.UserName & " FROM PHU" & Commons.Modules.UserName & " WHERE THU_TU=0"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)

            'LOC LAN 1 TU TREN XUONG
            'loai bo nhung ngay cuoi trung nhau

            Commons.Modules.SQLString = "DELETE FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()

            Commons.Modules.SQLString = "DELETE FROM PHU" & Commons.Modules.UserName & " WHERE THU_TU=0"
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()

            Commons.Modules.SQLString = "SELECT COUNT(MS_MAY) FROM PHU" & Commons.Modules.UserName
            dtReader = SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()

            Dim intItemCount As Integer = 0
            Dim i As Integer = 0
            While dtReader.Read
                intItemCount = dtReader.Item(0)
            End While
            dtReader.Close()
            prg.PerformStep()
            Commons.Modules.SQLString = "SELECT MS_MAY, NGAY_CUOI, MS_LOAI_BT,NGAY_GH_DUOI, NGAY_GH, CHU_KY, THU_TU, MS_DV_TG FROM PHU" & _
                Commons.Modules.UserName & " ORDER BY MS_MAY, NGAY_CUOI, THU_TU DESC"   'MS_LOAI_BT,

            dtDU_LIEU_KE_HOACH_BTDK.Load(SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString))
            dtDU_LIEU_TAM = dtDU_LIEU_KE_HOACH_BTDK.Copy
            dtDU_LIEU_TAM.Rows.Clear()
            prg.PerformStep()
            Dim strMS_MAY As String
            Dim intTHU_TU, intMS_LOAI_BT, intCHU_KY, intMS_DV_TG As Integer
            Dim dateNGAY_CUOI, dateNGAY_GH As Date, dateNGAY_GH_DUOI As Date
            Dim dtRow As DataRow, lTongRecords As Long = 0
            lTongRecords = dtDU_LIEU_KE_HOACH_BTDK.Rows.Count

            While i < lTongRecords
                strMS_MAY = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")
                intMS_LOAI_BT = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT")
                intCHU_KY = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("CHU_KY")
                dateNGAY_CUOI = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI")
                intMS_DV_TG = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_DV_TG")
                dateNGAY_GH = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_GH")
                dateNGAY_GH_DUOI = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_GH_DUOI")
                intTHU_TU = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("THU_TU")
                i = i + 1
                If intMS_LOAI_BT = 67 And strMS_MAY.ToUpper() = "AIC-SC-901" Then
                    strMS_MAY = strMS_MAY
                End If
                If i >= intItemCount Then
                    dtRow = dtDU_LIEU_TAM.NewRow
                    dtRow("MS_MAY") = strMS_MAY
                    dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                    dtRow("THU_TU") = intTHU_TU
                    dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                    dtRow("CHU_KY") = intCHU_KY
                    dtRow("MS_DV_TG") = intMS_DV_TG
                    dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                    dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                    dtDU_LIEU_TAM.Rows.Add(dtRow)
                    Exit While
                End If

                Dim dtRead As SqlDataReader

                dtRead = SqlHelper.ExecuteReader(sConnect, CommandType.Text, "SELECT COUNT(*) AS PHU_THUOC FROM LOAI_BAO_TRI WHERE MS_LOAI_BT=" & intMS_LOAI_BT & " AND MS_LOAI_BT IN (SELECT MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT") & ")")
                'If intTHU_TU > dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("THU_TU") Then
                '    dtRead = SqlHelper.ExecuteReader(sConnect, CommandType.Text, "SELECT COUNT(*) AS PHU_THUOC FROM LOAI_BAO_TRI WHERE MS_LOAI_BT=" & intMS_LOAI_BT & " AND MS_LOAI_BT IN (SELECT MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT") & ")")
                'Else
                '    dtRead = SqlHelper.ExecuteReader(sConnect, CommandType.Text, "SELECT COUNT(*) AS PHU_THUOC FROM LOAI_BAO_TRI WHERE MS_LOAI_BT=" & dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT") & " AND MS_LOAI_BT IN (SELECT MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & intMS_LOAI_BT & ")")
                'End If
                dtRead.Read()
                bPhuThuoc = CBool(dtRead.Item("PHU_THUOC"))
                dtRead.Close()
                'If (UCase((dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY)) And (dtRead.Item("PHU_THUOC") = 0)) Then
                If intMS_LOAI_BT = 67 And strMS_MAY.ToUpper() = "AIC-SC-901" Then
                    strMS_MAY = strMS_MAY
                End If
                If UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) And bPhuThuoc = False Then
                    dtRow = dtDU_LIEU_TAM.NewRow
                    dtRow("MS_MAY") = strMS_MAY
                    dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                    dtRow("THU_TU") = intTHU_TU
                    dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                    dtRow("CHU_KY") = intCHU_KY
                    dtRow("MS_DV_TG") = intMS_DV_TG
                    dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                    dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                    dtDU_LIEU_TAM.Rows.Add(dtRow)
                    If dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("THU_TU") > intTHU_TU And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") >= dateNGAY_GH_DUOI And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") <= dateNGAY_GH And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then
                        i = i + 1
                    End If
                Else
                    If dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") >= dateNGAY_GH_DUOI And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") <= dateNGAY_GH And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then
                        'If Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI")), "dd/MMM/yyyy") >= Format(CDate(dateNGAY_GH_DUOI), "dd/MMM/yyyy") And Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI")), "dd/MMM/yyyy") <= Format(CDate(dateNGAY_GH), "dd/MMM/yyyy") And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then
                        'If DateDiff(DateInterval.Day, dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI"), dateNGAY_GH_DUOI) >= 0 And Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI")), "dd/MMM/yyyy") <= Format(CDate(dateNGAY_GH), "dd/MMM/yyyy") And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then
                    Else
                        'DONG KE TIEP CUNG LOAI VOI DONG TRUOC HOAC DONG KE TIEP CO TT < DONG TRUOC
                        dtRow = dtDU_LIEU_TAM.NewRow
                        dtRow("MS_MAY") = strMS_MAY
                        dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                        dtRow("THU_TU") = intTHU_TU
                        dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                        dtRow("CHU_KY") = intCHU_KY
                        dtRow("MS_DV_TG") = intMS_DV_TG
                        dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                        dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                        dtDU_LIEU_TAM.Rows.Add(dtRow)
                    End If
                End If
                dtRead.Close()
            End While


            prg.PerformStep()

            dtDU_LIEU_TAM.Select("", "MS_MAY,NGAY_CUOI,THU_TU DESC")
            prg.PerformStep()
            dtDU_LIEU_KE_HOACH_BTDK.Clear()
            dtDU_LIEU_KE_HOACH_BTDK = dtDU_LIEU_TAM.Copy
            prg.PerformStep()
            lTongRecords = dtDU_LIEU_KE_HOACH_BTDK.Rows.Count - 1
            i = 0
            While i < lTongRecords
                strMS_MAY = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")
                intMS_LOAI_BT = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT")
                intCHU_KY = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("CHU_KY")
                dateNGAY_CUOI = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI")
                intMS_DV_TG = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_DV_TG")
                dateNGAY_GH_DUOI = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_GH_DUOI")
                dateNGAY_GH = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_GH")
                intTHU_TU = dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("THU_TU")
                i = i + 1

                If i >= intItemCount Then
                    dtRow = dtDU_LIEU_TAM.NewRow
                    dtRow("MS_MAY") = strMS_MAY
                    dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                    dtRow("THU_TU") = intTHU_TU
                    dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                    dtRow("CHU_KY") = intCHU_KY
                    dtRow("MS_DV_TG") = intMS_DV_TG
                    dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                    dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                    dtDU_LIEU_TAM.Rows.Add(dtRow)
                    Exit While
                End If
                'can lay du lieu trong data table
                Dim dtRead As SqlDataReader
                dtRead = SqlHelper.ExecuteReader(sConnect, CommandType.Text, "SELECT COUNT(*) AS PHU_THUOC FROM LOAI_BAO_TRI WHERE MS_LOAI_BT=" & intMS_LOAI_BT & " AND MS_LOAI_BT IN (SELECT MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_LOAI_BT") & ")")
                dtRead.Read()
                bPhuThuoc = CBool(dtRead.Item("PHU_THUOC"))
                dtRead.Close()
                'If (UCase((dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY)) And (dtRead.Item("PHU_THUOC") = 0)) Then
                If UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) And bPhuThuoc = False Then
                    dtRow = dtDU_LIEU_TAM.NewRow
                    dtRow("MS_MAY") = strMS_MAY
                    dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                    dtRow("THU_TU") = intTHU_TU
                    dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                    dtRow("CHU_KY") = intCHU_KY
                    dtRow("MS_DV_TG") = intMS_DV_TG
                    dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                    dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                    dtDU_LIEU_TAM.Rows.Add(dtRow)
                    If dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("THU_TU") > intTHU_TU And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") >= dateNGAY_GH_DUOI And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") <= dateNGAY_GH And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then
                        i = i + 1
                    End If
                Else
                    If dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") >= dateNGAY_GH_DUOI And dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("NGAY_CUOI") <= dateNGAY_GH And UCase(dtDU_LIEU_KE_HOACH_BTDK.Rows(i)("MS_MAY")) = UCase(strMS_MAY) Then



                    Else
                        'DONG KE TIEP CUNG LOAI VOI DONG TRUOC HOAC DONG KE TIEP CO TT < DONG TRUOC
                        dtRow = dtDU_LIEU_TAM.NewRow
                        dtRow("MS_MAY") = strMS_MAY
                        dtRow("NGAY_CUOI") = Format(dateNGAY_CUOI, "dd/MMM/yyyy")
                        dtRow("THU_TU") = intTHU_TU
                        dtRow("MS_LOAI_BT") = intMS_LOAI_BT
                        dtRow("CHU_KY") = intCHU_KY
                        dtRow("MS_DV_TG") = intMS_DV_TG
                        dtRow("NGAY_GH_DUOI") = Format(dateNGAY_GH_DUOI, "dd/MMM/yyyy")
                        dtRow("NGAY_GH") = Format(dateNGAY_GH, "dd/MMM/yyyy")
                        dtDU_LIEU_TAM.Rows.Add(dtRow)
                    End If
                End If
                dtRead.Close()
            End While
            prg.PerformStep()
            dtReader.Close()
            'DO LAY DL CUA NHUNG CHU KY DOC LAP VAO
            Commons.Modules.SQLString = "SELECT * FROM DU_LIEU_BAO_CAO_KHBT_DOC_LAP_TMP" & Commons.Modules.UserName & _
                    " WHERE (CHU_KY IS NOT NULL) OR (MS_DV_TG IS NOT NULL) OR (NGAY_CUOI  IS NOT NULL) "
            dtReader = SqlHelper.ExecuteReader(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()
            While dtReader.Read
                dtRow = dtDU_LIEU_TAM.NewRow
                dtRow("MS_MAY") = dtReader.Item("MS_MAY")
                dtRow("NGAY_CUOI") = Format(dtReader.Item("NGAY_CUOI"), "dd/MMM/yyyy")
                dtRow("THU_TU") = dtReader.Item("THU_TU")
                dtRow("MS_LOAI_BT") = dtReader.Item("MS_LOAI_BT")
                dtRow("CHU_KY") = dtReader.Item("CHU_KY")
                dtRow("MS_DV_TG") = dtReader.Item("MS_DV_TG")
                dtRow("NGAY_GH_DUOI") = Format(dtReader.Item("NGAY_GH_DUOI"), "dd/MMM/yyyy")
                dtRow("NGAY_GH") = Format(dtReader.Item("NGAY_GH"), "dd/MMM/yyyy")
                dtDU_LIEU_TAM.Rows.Add(dtRow)
            End While
            prg.PerformStep()
            dtDU_LIEU_KE_HOACH_BTDK.Clear()
            dtDU_LIEU_KE_HOACH_BTDK = dtDU_LIEU_TAM.Copy
            clsXuLy.DropTable(sConnect, "DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName)
            Commons.Modules.SQLString = "CREATE TABLE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " (MS_MAY nvarchar (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,NGAY_CUOI datetime NULL ,THU_TU int NULL ,MS_LOAI_BT int NOT NULL ,	[CHU_KY] [int] NULL ,MS_DV_TG int NULL ,NGAY_GH_DUOI datetime NULL ,NGAY_GH datetime NULL ) "
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()
            For k As Long = 0 To dtDU_LIEU_KE_HOACH_BTDK.Rows.Count - 1
                Commons.Modules.SQLString = "INSERT INTO DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " VALUES(N'" & dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("MS_MAY") & "','" & Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("NGAY_CUOI")), "dd/MMM/yyyy") & "'," & dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("THU_TU") & "," & dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("MS_LOAI_BT") & "," & dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("CHU_KY") & "," & dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("MS_DV_TG") & ",'" & Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("NGAY_GH_DUOI")), "dd/MMM/yyyy") & "','" & Format(CDate(dtDU_LIEU_KE_HOACH_BTDK.Rows(k)("NGAY_GH")), "dd/MMM/yyyy") & "')"
                SqlHelper.ExecuteNonQuery(sConnect, CommandType.Text, Commons.Modules.SQLString)
            Next
            prg.PerformStep()
            Commons.Modules.SQLString = "DROP TABLE DU_LIEU_BAO_CAO_KHBT_DOC_LAP_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(sConnect, CommandType.Text, Commons.Modules.SQLString)
            prg.PerformStep()
            dtDU_LIEU_KE_HOACH_BTDK.Dispose()
            dtDU_LIEU_TAM.Dispose()


        End Sub
    End Class
End Namespace