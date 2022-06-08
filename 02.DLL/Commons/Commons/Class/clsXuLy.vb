Imports System.IO

Imports Microsoft.Win32
Imports Commons.VS.Classes.Admin
Imports System.Environment
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient.SqlConnection


Public Class clsXuLy
    Private Const _CODE_ = 354

    ' <summary>
    ' Hàm lọc bỏ chuỗi tiếng việt có dấu, kết quả trả về là chuỗi tiếng việt không dấu. ( VD: Tiếng Việt -> Tieng Viet )
    ' </summary>
    ' <param name="str">Chuỗi tiếng việt có đấu cần lọc bỏ.</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Shared Function LocBoDau(ByVal str As String) As String
        Dim Mang(13, 17) As String 'Tạo mảng có 14 hàng và 17 cột, mỗi hàng chứa các ký tự cùng nhóm
        Dim i, j
        Dim Chuoi As String
        Dim Thga, Thge, Thgo, Thgu, Thgi, Thgd, Thgy As String
        Dim HoaA, HoaE, HoaO, HoaU, HoaI, HoaD, HoaY As String
        Dim strKhongDau As String = ""

        Chuoi = "aAeEoOuUiIdDyY"
        Thga = "áàạảãâấầậẩẫăắằặẳẵ"
        HoaA = "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ"
        Thge = "éèẹẻẽêếềệểễeeeeee"
        HoaE = "ÉÈẸẺẼÊẾỀỆỂỄEEEEEE"
        Thgo = "óòọỏõôốồộổỗơớờợởỡ"
        HoaO = "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ"
        Thgu = "úùụủũưứừựửữuuuuuu"
        HoaU = "ÚÙỤỦŨƯỨỪỰỬỮUUUUUU"
        Thgi = "íìịỉĩiiiiiiiiiiii"
        HoaI = "ÍÌỊỈĨIIIIIIIIIIII"
        Thgd = "đdddddddddddddddd"
        HoaD = "ĐDDDDDDDDDDDDDDDD"
        Thgy = "ýỳỵỷỹyyyyyyyyyyyy"
        HoaY = "ÝỲỴỶỸYYYYYYYYYYYY"
        'Nạp vào trong Mảng các ký tự
        'Nạp vào từng đầu hàng các ký tự không dấu
        'Nạp vào cột đầu tiên
        For i = 0 To 13
            Mang(i, 0) = Mid(Chuoi, i + 1, 1)
        Next
        'Nạp vào từng ô các ký tự có dấu
        For j = 1 To 17
            For i = 1 To 17
                Mang(0, i) = Mid(Thga, i, 1) 'Nạp từng ký tự trong chuỗi Thga vào từng ô trong hàng 0
                Mang(1, i) = Mid(HoaA, i, 1) 'Nạp từng ký tự trong chuỗi HoaA vào từng ô trong  hàng 1
                Mang(2, i) = Mid(Thge, i, 1) 'Nạp từng ký tự trong chuỗi Thge vào từng ô trong  hàng 2
                Mang(3, i) = Mid(HoaE, i, 1) 'Nạp từng ký tự trong chuỗi HoaE vào từng ô trong  hàng 3
                Mang(4, i) = Mid(Thgo, i, 1) 'Nạp từng ký tự trong chuỗi Thgo vào từng ô trong  hàng 4
                Mang(5, i) = Mid(HoaO, i, 1) 'Nạp từng ký tự trong chuỗi HoaO vào từng ô trong  hàng 5
                Mang(6, i) = Mid(Thgu, i, 1) 'Nạp từng ký tự trong chuỗi Thgu vào từng ô trong  hàng 6
                Mang(7, i) = Mid(HoaU, i, 1) 'Nạp từng ký tự trong chuỗi HoaU vào từng ô trong  hàng 7
                Mang(8, i) = Mid(Thgi, i, 1) 'Nạp từng ký tự trong chuỗi Thgi vào từng ô trong  hàng 8
                Mang(9, i) = Mid(HoaI, i, 1) 'Nạp từng ký tự trong chuỗi HoaI vào từng ô trong  hàng 9
                Mang(10, i) = Mid(Thgd, i, 1) 'Nạp từng ký tự trong chuỗi Thgd vào từng ô trong  hàng 10
                Mang(11, i) = Mid(HoaD, i, 1) 'Nạp từng ký tự trong chuỗi HoaD vào từng ô trong  hàng 11
                Mang(12, i) = Mid(Thgy, i, 1) 'Nạp từng ký tự trong chuỗi Thgy vào từng ô trong  hàng 12
                Mang(13, i) = Mid(HoaY, i, 1) 'Nạp từng ký tự trong chuỗi HoaY vào từng ô trong  hàng 13
            Next
        Next

        For j = 0 To 13
            For i = 1 To 17
                strKhongDau = str.Replace(Mang(j, i), Mang(j, 0))
                str = strKhongDau
            Next
        Next
        Erase Mang
        Return strKhongDau
    End Function

    Public Shared Sub LayThongTinPhanMem(ByVal sFormName As String, ByVal status As Windows.Forms.StatusStrip, ByVal ExePath As String)
        Dim _NGUOI_DANG_NHAP As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sFormName, "NGUOI_DANG_NHAP", Commons.Modules.TypeLanguage)
        Dim _TEN_CONG_TY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sFormName, "TEN_CONG_TY", Commons.Modules.TypeLanguage)
        Dim _PHIEN_BAN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sFormName, "PHIEN_BAN", Commons.Modules.TypeLanguage)
        Dim _NGAY_CAP_NHAT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sFormName, "NGAY_CAP_NHAT", Commons.Modules.TypeLanguage)

        _NGUOI_DANG_NHAP += IIf(Commons.Modules.UserName <> "", Commons.Modules.UserName, " - - - - -")
        _PHIEN_BAN += Windows.Forms.Application.ProductName.ToString ' & " " & Application.ProductVersion.ToString
        _NGAY_CAP_NHAT += Format(CDate(File.GetLastWriteTime(ExePath).ToString), "hh:mm tt - dd/MM/yyyy")

        status.Items("statusUserLogged").Text = _NGUOI_DANG_NHAP
        status.Items("statusCompanyName").Text = Replace(_TEN_CONG_TY, "''", "'")
        status.Items("statusVersion").Text = _PHIEN_BAN
        status.Items("statusUpdated").Text = _NGAY_CAP_NHAT
    End Sub


    Public Shared Function MaHoaDL(ByVal str As String) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""

        MaHoaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) + _CODE_) * 2).ToString
        Next
        Return sTam
    End Function

    Public Shared Function GiaiMaDL(ByVal str As String) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""
        GiaiMaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) / 2) - _CODE_).ToString
        Next
        Return sTam
    End Function


    Public Shared Function GetHDDSerial() As String
        Dim cls As New clsGetHDDSerial
        Dim sSerial As String = "", sModel As String = "", sFirmware As String = "", sTam As String = ""
        Dim sDrives() As String
        Dim i As Integer, iCount As Integer

        sDrives = GetLogicalDrives()
        For i = 0 To GetLogicalDrives.Length - 1
            If sDrives(i).Chars(0) >= "C" Then
                If cls.GetHDData(iCount, sSerial, sModel, sFirmware) = True Then
                    sTam = sModel & sSerial & sFirmware
                    Exit For
                Else
                    sTam = ""
                End If
                iCount += 1
            End If
        Next i
        Return sTam
    End Function

    Private Shared Function DoiChuSangSo(ByVal strChuoiSo As String) As String
        Dim ReadDigit(10) As String
        Dim temp As String = ""

        ReadDigit(0) = " Không"
        ReadDigit(1) = " Một"
        ReadDigit(2) = " Hai"
        ReadDigit(3) = " Ba"
        ReadDigit(4) = " Bốn"
        ReadDigit(5) = " Năm"
        ReadDigit(6) = " Sáu"
        ReadDigit(7) = " Bảy"
        ReadDigit(8) = " Tám"
        ReadDigit(9) = " Chín"

        If (strChuoiSo = "000") Then Return ""

        'Đọc số hàng trăm
        temp = ReadDigit(Integer.Parse(strChuoiSo(0).ToString)) & " Trăm"
        'Đọc số hàng chục
        If (strChuoiSo(1).ToString() = "0") Then
            If (strChuoiSo(2).ToString() = "0") Then
                Return temp
            Else
                temp &= " Lẻ" + ReadDigit(Integer.Parse(strChuoiSo(2).ToString()))
                Return temp
            End If
        Else
            temp &= ReadDigit(Integer.Parse(strChuoiSo(1).ToString)) + " Mươi"
            'Đọc hàng đơn vị
        End If

        If (strChuoiSo(2).ToString = "5") Then
            temp &= " Lăm"
        ElseIf (strChuoiSo(2).ToString <> "0") Then
            temp &= ReadDigit(Integer.Parse(strChuoiSo(2).ToString()))
        End If
        Return temp
    End Function

    Public Shared Function DocTien(ByVal strMoney As String) As String
        Dim temp As String = ""

        'Cho đủ 12 số
        While (strMoney.Length < 12)
            strMoney = "0" + strMoney
        End While

        Dim g1 As String = strMoney.Substring(0, 3)
        Dim g2 As String = strMoney.Substring(3, 3)
        Dim g3 As String = strMoney.Substring(6, 3)
        Dim g4 As String = strMoney.Substring(9, 3)

        'Đọc nhóm 1 ---------------------
        If (g1 <> "000") Then
            temp = DoiChuSangSo(g1)
            temp &= " Tỷ,"
        End If
        'Đọc nhóm 2-----------------------
        If (g2 <> "000") Then
            temp &= DoiChuSangSo(g2)
            temp &= " Triệu,"
        End If
        '---------------------------------
        If (g3 <> "000") Then
            temp &= DoiChuSangSo(g3)
            temp &= " Ngàn,"
        End If
        '-----------------------------------
        'temp = temp & DoiChuSangSo(g4).Replace("Không Trăm Lẻ", "Lẻ") ' Đọc 1000001 là Một Triệu Lẻ Một thay vì Một Triệu Không Trăm Lẻ 1;
        temp = temp & DoiChuSangSo(g4) & "."
        '---------------------------------
        ' Tinh chỉnh
        temp = temp.Replace("Một Mươi", "Mười")
        temp = temp.Trim()
        If (temp.IndexOf("Không Trăm") = 0) Then temp = temp.Remove(0, 10)
        temp = temp.Trim()
        If (temp.IndexOf("Lẻ") = 0) Then temp = temp.Remove(0, 2)
        temp = temp.Trim()
        temp = temp.Replace("Mươi Một", "Mươi Mốt")
        temp = temp.Trim()

        If temp.Substring(Len(temp) - 1, 1).ToString = "." And temp.Substring(Len(temp) - 2, 1).ToString = "," Then temp = temp.Substring(0, Len(temp) - 2) & "."

        Return temp.Substring(0, 1).ToUpper & temp.Substring(1, Len(temp) - 1).ToLower
    End Function



    '=================================XU LY DU LIEU TREN LUOI===============================================

    'hàm chỉ cho nhập số bắt vào sự kện keypress, trong form có lưới cần lọc khi nhập khai báo 1 biến thuộc kiểu textbox và removehandle, addhandle cho sự kiện
    Public Shared Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub



    '=========================================XỬ LÝ DỮ LIỆU CHO DATABASE=======================================================

    ' <summary>
    ' Thủ tục Delete 1 table trong trong database
    ' </summary>
    ' <param name="ConnectionString">Chuỗi SQL cần kết nối đến SQL SERVER</param>
    ' <param name="sTableName">Tên table cần delete</param>
    ' <remarks></remarks>
    Public Shared Sub DropTable(ByVal ConnectionString As String, ByVal sTableName As String)
        Dim str As String = "IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID=OBJECT_ID(N'[" & _
                            sTableName & "]') AND OBJECTPROPERTY(ID, N'ISUSERTABLE') = 1) DROP TABLE [" & sTableName & "]"

        'xóa table trong database
        SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, str)
    End Sub

    'Tao tieu de report
    Public Shared Sub CreateTitleReport()

        Dim vSelect As String = Nothing

        Try

            Commons.Modules.ObjSystems.XoaTable("rptTHONG_TIN_CHUNG")

            If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                Dim dtTmp As New DataTable
                Dim sSql As String
                sSql = "SELECT CASE 0 WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS THONG_TIN_CTY,  " & _
                            " C.DIA_CHI AS DIA_CHI_CTY,C.DIEN_THOAI, C.FAX,(SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, " & _
                            " (SELECT TOP 1 LE_PHAI_LOGO AS LE_TRAI_LOGO FROM THONG_TIN_CHUNG )  AS LE_TRAI_LOGO, " & _
                            " (SELECT TOP 1 LE_TREN_LOGO  FROM THONG_TIN_CHUNG )  AS LE_TREN_LOGO, " & _
                            " (SELECT TOP 1 WIDTH   FROM THONG_TIN_CHUNG ) AS  WIDTH, " & _
                            " (SELECT TOP 1 HEIGHT  FROM THONG_TIN_CHUNG ) AS HEIGHT, " & _
                            " (SELECT TOP 1 'Ngày in : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN  FROM THONG_TIN_CHUNG )  AS NGAY_IN " & _
                            " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI " & _
                            " INNER JOIN dbo.USERS AS A ON D.MS_TO = A.MS_TO " & _
                            " WHERE(A.USERNAME = N'" + Commons.Modules.UserName + "') "
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    vSelect = "SELECT CASE " & Commons.Modules.TypeLanguage.ToString & " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS THONG_TIN_CTY,  " & _
                                " C.DIA_CHI AS DIA_CHI_CTY,C.DIEN_THOAI, C.FAX,(SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, " & _
                                " (SELECT TOP 1 LE_PHAI_LOGO AS LE_TRAI_LOGO FROM THONG_TIN_CHUNG )  AS LE_TRAI_LOGO, " & _
                                " (SELECT TOP 1 LE_TREN_LOGO  FROM THONG_TIN_CHUNG )  AS LE_TREN_LOGO, " & _
                                " (SELECT TOP 1 WIDTH   FROM THONG_TIN_CHUNG ) AS  WIDTH, " & _
                                " (SELECT TOP 1 HEIGHT  FROM THONG_TIN_CHUNG ) AS HEIGHT, " & _
                                " (SELECT TOP 1 N'Ngày in : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN  FROM THONG_TIN_CHUNG )  AS NGAY_IN " & _
                                " INTO rptTHONG_TIN_CHUNG FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI " & _
                                " INNER JOIN dbo.USERS AS A ON D.MS_TO = A.MS_TO " & _
                                " WHERE(A.USERNAME = N'" + Commons.Modules.UserName + "') "
                Else
                    GoTo 1
                End If

            Else
1:
                If Commons.Modules.TypeLanguage = 0 Then
                    vSelect = "SELECT TEN_CTY_TIENG_VIET AS THONG_TIN_CTY ,DIA_CHI_VIET AS DIA_CHI_CTY , Phone AS DIEN_THOAI , " & _
                    "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT ,'Ngày in : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
                Else
                    vSelect = "SELECT TEN_CTY_TIENG_ANH AS THONG_TIN_CTY , DIA_CHI_ANH AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," & _
                    "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , 'Printing date : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN  INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
                End If
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, vSelect)
        Catch ex As Exception
            Commons.Modules.ObjSystems.XoaTable("rptTHONG_TIN_CHUNG")
            If Commons.Modules.TypeLanguage = 0 Then
                vSelect = "SELECT TEN_CTY_TIENG_VIET AS THONG_TIN_CTY ,DIA_CHI_VIET AS DIA_CHI_CTY , Phone AS DIEN_THOAI , " & _
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT ,'Ngày in : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
            Else
                vSelect = "SELECT TEN_CTY_TIENG_ANH AS THONG_TIN_CTY , DIA_CHI_ANH AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," & _
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , 'Printing date : ' + convert (varchar (11),  getdate () , 103 ) AS NGAY_IN  INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, vSelect)
        End Try

    End Sub

    'Định dạng report 
    Public Shared Sub DesignerReport(ByVal rptMain As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Commons.clsXuLy.CreateTitleReport()
        For Each rptObjectMain As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
            If rptObjectMain.Name.Length >= 5 And rptObjectMain.Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                If (rptObjectMain.Name.Trim().ToUpper().Substring(0, 5).Equals("TITLE")) Then
                    Dim rptDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    rptDocument = rptMain.Subreports("rptTitle.rpt")
                    Dim tbrptHeader As DataTable = New DataTable()
                    tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
                    If (tbrptHeader.Rows.Count > 0) Then
                        For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptDocument.ReportDefinition.ReportObjects
                            If rptObject.Name.Length >= 4 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))
                                End If
                            End If
                            If rptObject.Name.Length >= 8 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Height = 700
                                    rptObject.Width = 5000
                                End If
                            End If
                            If rptObject.Name.Length >= 6 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                    rptObject.Width = 2500
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    Try
                                        rptObject.Left = rptObjectMain.Width - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    Catch ex As Exception
                                    End Try
                                    rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                Dim tbrptHeader As DataTable = New DataTable()
                tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
                If (tbrptHeader.Rows.Count > 0) Then
                    For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
                        If rptObject.Name.Length >= 4 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))
                            End If
                        End If
                        If rptObject.Name.Length >= 8 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                'rptObject.Height = 700
                                'rptObject.Width = 5000
                            End If
                        End If
                        If rptObject.Name.Length >= 6 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                rptObject.Width = 2500
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                Try
                                    rptObject.Left = rptMain.PrintOptions.PageContentWidth - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                Catch ex As Exception
                                End Try
                                rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
End Class
