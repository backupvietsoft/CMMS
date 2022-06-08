Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient

Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class ClsMain
    <StructLayout(LayoutKind.Sequential)>
    Private Structure LASTINPUTINFO
        <MarshalAs(UnmanagedType.U4)>
        Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)>
        Public dwTime As Integer
    End Structure

    <DllImport("user32.dll")>
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Private idletime As Integer
    Private lastInputInf As New LASTINPUTINFO()

    Public Function GetIdleTime() As Integer
        idletime = 0
        lastInputInf.cbSize = Marshal.SizeOf(lastInputInf)
        lastInputInf.dwTime = 0

        If GetLastInputInfo(lastInputInf) Then
            idletime = Environment.TickCount - lastInputInf.dwTime
        End If

        If idletime > 0 Then
            Return CType(idletime / 1000, Integer)
        Else
            Return 0
        End If
    End Function
    'Hàm set font cho form 
    Private Shared Sub SetFontForm(ByVal vFrm As Form)
        For Each ctrl As Control In vFrm.Controls
            Dim size As Single = 9
            Dim style As System.Drawing.FontStyle = FontStyle.Regular
            Try
                size = ctrl.Font.Size
            Catch ex As Exception
            End Try
            Try
                style = ctrl.Font.Style
            Catch ex As Exception
            End Try
            ctrl.Font = New Font("Arial", size, style)
            If TypeOf ctrl Is DataGridView Then
                CType(ctrl, DataGridView).ColumnHeadersDefaultCellStyle.Font = New Font("Arial", ctrl.Font.Size, FontStyle.Bold)
                For Each gvColumn As DataGridViewColumn In CType(ctrl, DataGridView).Columns
                    Try
                        style = gvColumn.DefaultCellStyle.Font.Style
                    Catch ex As Exception
                    End Try

                    gvColumn.DefaultCellStyle.Font = New Font("Arial", size, style)
                Next
            End If
            SetFontControl(ctrl)
        Next
    End Sub
    'Hàm set font cho control 
    Private Shared Sub SetFontControl(ByVal vCtrl As Control)
        For Each ctrl As Control In vCtrl.Controls
            Dim size As Single = 9
            Dim style As System.Drawing.FontStyle = FontStyle.Regular
            Try
                size = ctrl.Font.Size
            Catch ex As Exception
            End Try
            Try
                style = ctrl.Font.Style
            Catch ex As Exception
            End Try
            ctrl.Font = New Font("Arial", size, style)
            If TypeOf ctrl Is DataGridView Then
                CType(ctrl, DataGridView).ColumnHeadersDefaultCellStyle.Font = New Font("Arial", ctrl.Font.Size, FontStyle.Bold)
                For Each gvColumn As DataGridViewColumn In CType(ctrl, DataGridView).Columns
                    Try
                        style = gvColumn.DefaultCellStyle.Font.Style
                    Catch ex As Exception
                    End Try

                    gvColumn.DefaultCellStyle.Font = New Font("Arial", size, style)
                Next
            End If
            SetFontControl(ctrl)
        Next
    End Sub
    'Hàm set ngôn ngữ cho form 
    Public Shared Sub SetLanguageForm(ByVal vFrm As Form)
        SetFontForm(vFrm)
        Dim tbLanguage As DataTable = New DataTable()
        Dim strLanguage As String = Nothing
        Select Case commons.Modules.TypeLanguage
            Case 0
                strLanguage = "SELECT KEYWORD , VIETNAM AS CAPTION FROM LANGUAGES WHERE FORM = '" & vFrm.Name.Trim() & "' AND FORM_HAY_REPORT = 0 "
            Case 1
                strLanguage = "SELECT KEYWORD , ENGLISH AS CAPTION FROM LANGUAGES WHERE FORM = '" & vFrm.Name.Trim() & "' AND FORM_HAY_REPORT = 0 "
        End Select
        tbLanguage.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, strLanguage))
        tbLanguage = DataVietsoft.Datavs.SelectDistinct(tbLanguage, "KEYWORD", "CAPTION")
        If (tbLanguage.Rows.Count > 0) Then
            Dim vKey(1) As DataColumn
            vKey(0) = tbLanguage.Columns("KEYWORD")
            tbLanguage.PrimaryKey = vKey
            For Each ctrl As Control In vFrm.Controls
                Dim rLanguage As DataRow = tbLanguage.Rows.Find(ctrl.Name.Trim())
                Try
                    ctrl.Text = rLanguage("CAPTION").ToString().Trim()
                Catch ex As Exception
                End Try
                If TypeOf ctrl Is DataGridView Then
                    CType(ctrl, DataGridView).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    For Each gvColumn As DataGridViewColumn In CType(ctrl, DataGridView).Columns
                        Dim rLanguaecolumn As DataRow = tbLanguage.Rows.Find(gvColumn.Name.Trim())
                        Try
                            gvColumn.HeaderText = rLanguaecolumn("CAPTION").ToString().Trim()
                        Catch ex As Exception
                        End Try
                    Next
                End If
                SetLanguageControl(ctrl, tbLanguage)
            Next
        End If
    End Sub
    'Hàm set ngôn ngữ cho control
    Private Shared Sub SetLanguageControl(ByVal vControl As Control, ByVal tbLanguage As DataTable)
        If (tbLanguage.Rows.Count > 0) Then
            For Each ctrl As Control In vControl.Controls
                Dim rLanguage As DataRow = tbLanguage.Rows.Find(ctrl.Name.Trim())
                Try
                    ctrl.Text = rLanguage("CAPTION").ToString().Trim()
                Catch ex As Exception
                End Try
                If TypeOf ctrl Is DataGridView Then
                    CType(ctrl, DataGridView).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    For Each gvColumn As DataGridViewColumn In CType(ctrl, DataGridView).Columns
                        Dim rLanguaecolumn As DataRow = tbLanguage.Rows.Find(gvColumn.Name.Trim())
                        Try
                            gvColumn.HeaderText = rLanguaecolumn("CAPTION").ToString().Trim()
                        Catch ex As Exception
                        End Try
                    Next
                End If
                If TypeOf ctrl Is ReportManager.navBarControl Then
                    For Each group As ReportManager.navBarGroup In CType(ctrl, ReportManager.navBarControl).Groups
                        Dim rLanguaecolumn As DataRow = tbLanguage.Rows.Find(group.Name.Trim())
                        Try
                            CType(group, ReportManager.navBarGroup).Caption = rLanguaecolumn("CAPTION").ToString().Trim()
                        Catch ex As Exception
                        End Try
                    Next
                End If
                SetLanguageControl(ctrl, tbLanguage)
            Next
        End If
    End Sub

    Public Shared Sub LoadThongTinChung()

        Commons.Modules.LicID = 0

        Dim dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT TOP 1 *  FROM THONG_TIN_CHUNG"))
        Catch ex As Exception

        End Try

        Commons.Modules.bDoiFontReport = False
        Try
            Commons.Modules.bDoiFontReport = Convert.ToBoolean(dtTmp.Rows(0)("DOI_FONT").ToString)
        Catch ex As Exception
            Commons.Modules.bDoiFontReport = False
        End Try

        'Private
        Commons.Modules.sFontReport = ""
        Try
            If dtTmp.Rows(0)("FONT_REPORT").ToString.Equals("") Then
                Commons.Modules.sFontReport = "Tahoma"
                Commons.Modules.bDoiFontReport = False
            Else
                Commons.Modules.sFontReport = dtTmp.Rows(0)("FONT_REPORT").ToString
            End If
        Catch ex As Exception
            Commons.Modules.sFontReport = "Tahoma"
            Commons.Modules.bDoiFontReport = False
        End Try

        'SAVE_TMP excel
        Commons.Modules.sExcelTemp = "0"
        Try
            If dtTmp.Rows(0)("SAVE_TMP").ToString.Equals("") Then
                Commons.Modules.sExcelTemp = "0"
            Else
                If dtTmp.Rows(0)("SAVE_TMP").ToString = 1 Then ' luu vao thu muc temp cua windows
                    Commons.Modules.sExcelTemp = System.IO.Path.GetTempPath()
                End If
                If dtTmp.Rows(0)("SAVE_TMP").ToString = 2 Then ' luu vao thu muc temp chay phan mem ' yeu cầu phai có thu muc temp trong thu muc VietSoft
                    Commons.Modules.sExcelTemp = Application.StartupPath & "\temp\"
                End If
            End If
        Catch ex As Exception
            Commons.Modules.sExcelTemp = "0"
        End Try

        Commons.Modules.bSSL = False
        Try
            Commons.Modules.bSSL = Convert.ToBoolean(dtTmp.Rows(0)("SSL_MAIL").ToString)
        Catch ex As Exception
            Commons.Modules.bSSL = False
        End Try

        'Private
        Commons.Modules.sPrivate = ""
        Try
            Commons.Modules.sPrivate = dtTmp.Rows(0)("PRIVATE").ToString.ToUpper
        Catch ex As Exception
            Commons.Modules.sPrivate = "VIETSOFT"
        End Try
        'Commons.Modules.sPrivate = "SHISEIDO"

        'Report
        Commons.Modules.iReport = 0
        Try
            Commons.Modules.iReport = dtTmp.Rows(0)("MREPORT")
        Catch ex As Exception
            Commons.Modules.iReport = 0
        End Try

        '[MDEFAULT]             'Dung de dinh nghia set so phieu = ma so.     = 0 Binh Thuong, = 1 so phieu = ma so, = 2 so phieu = ma so lock luon so phieu  = 0

        Commons.Modules.iDefault = 0
        Try
            Commons.Modules.iDefault = dtTmp.Rows(0)("MDEFAULT")
        Catch ex As Exception
            Commons.Modules.iDefault = 0
        End Try



        Try
            Commons.Modules.ObjSystems.PBTKho = dtTmp.Rows(0)("PBT_KHO")
        Catch ex As Exception
            Commons.Modules.ObjSystems.PBTKho = False
        End Try


        Try
            Commons.Modules.ObjSystems.KhoMoi = dtTmp.Rows(0)("KHO_MOI")
        Catch ex As Exception
            Commons.Modules.ObjSystems.KhoMoi = False
        End Try


        Try
            Commons.Modules.GoiMail = dtTmp.Rows(0)("SENT_MAIL")
        Catch ex As Exception
            Commons.Modules.GoiMail = False
        End Try

        Try
            Commons.Modules.sMailFrom = dtTmp.Rows(0)("MAIL_FROM")
        Catch ex As Exception
            Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com"
        End Try

        Try
            Commons.Modules.sMailFromPass = Commons.clsXuLy.GiaiMaDL(dtTmp.Rows(0)("PASS_MAIL").ToString())
        Catch ex As Exception
            Commons.Modules.sMailFromPass = "Namviet@2017"
        End Try


        Try
            Commons.Modules.sMailFromSmtp = dtTmp.Rows(0)("SMTP_MAIL")
        Catch ex As Exception
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com"
        End Try

        Try
            Commons.Modules.sMailFromPort = dtTmp.Rows(0)("PORT_MAIL")
        Catch ex As Exception
            Commons.Modules.sMailFromPort = "587"
        End Try


        Try
            Commons.Modules.iLoaiGoiMail = dtTmp.Rows(0)("LOAI_GOI_MAIL")
        Catch ex As Exception
            Commons.Modules.iLoaiGoiMail = 1
        End Try

        Try
            Commons.Modules.sDDanMail = dtTmp.Rows(0)("DUONG_DAN_MAIL")
        Catch ex As Exception
            Commons.Modules.sDDanMail = "D:"
        End Try

        Try
            Commons.Modules.iSoLeSL = Convert.ToInt16(dtTmp.Rows(0)("SO_LE_SL"))
        Catch ex As Exception
            Commons.Modules.iSoLeSL = 0
        End Try
        Try
            Commons.Modules.iSoLeDG = Convert.ToInt16(dtTmp.Rows(0)("SO_LE_DG"))
        Catch ex As Exception
            Commons.Modules.iSoLeDG = 2
        End Try

        Try
            Commons.Modules.iSoLeTT = Convert.ToInt16(dtTmp.Rows(0)("SO_LE_TT"))
        Catch ex As Exception
            Commons.Modules.iSoLeTT = 2
        End Try
        Try
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
        Catch ex As Exception
            Commons.Modules.sSoLeSL = "#,##0"
        End Try
        Try
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
        Catch ex As Exception
            Commons.Modules.sSoLeDG = "#,##0.00"
        End Try
        Try
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        Catch ex As Exception
            Commons.Modules.sSoLeTT = "#,##0.00"
        End Try


        Try
            Commons.Modules.iTRFData = 0
            Commons.Modules.iTRFData = dtTmp.Rows(0)("TRANSFER_DATA")
        Catch ex As Exception

        End Try

        Try
            Commons.Modules.iPBTTheoGio = 0
            Commons.Modules.iPBTTheoGio = dtTmp.Rows(0)("PBT_THEO_GIO")
        Catch ex As Exception

        End Try
        '= 0 nhu cu
        '= 1 dn theo don vi
        Try
            Commons.Modules.iMaPBT = 0
            Commons.Modules.iMaPBT = dtTmp.Rows(0)("DN_PBT")
        Catch ex As Exception

        End Try
        '0 Mặc định thêm CV va PT
        '1 Chi Thêm công việc không thêm phụ tùng 
        '2 Không thêm gì cả'
        Try
            Commons.Modules.iMacDinhCVPT = dtTmp.Rows(0)("THEM_CV_PT")
        Catch ex As Exception
            Commons.Modules.iMacDinhCVPT = 0
        End Try

        '0 Trong PBT cong viec nhan su nhap theo gio
        '1 Trong PBT cong viec nhan su nhap theo Phut
        Try
            Commons.Modules.iPhutGioPBT = 0
            Commons.Modules.iPhutGioPBT = dtTmp.Rows(0)("PHUT_GIO_PBT")
        Catch ex As Exception

        End Try

        Commons.Modules.sDonViMacDinh = ""
        dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT     ISNULL(B.MS_DON_VI, N'') AS MS_DON_VI FROM dbo.USERS AS A " &
                " INNER JOIN dbo.TO_PHONG_BAN AS B ON A.MS_TO = B.MS_TO  " &
                " WHERE USERNAME = '" + Commons.Modules.UserName + "'"))
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.sDonViMacDinh = dtTmp.Rows(0)("MS_DON_VI")
        Catch ex As Exception
            Commons.Modules.sDonViMacDinh = ""
        End Try


        Commons.Modules.sTenNhanVienMD = ""
        Commons.Modules.sMaNhanVienMD = ""
        dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT TOP 1 ISNULL(A.MS_CONG_NHAN, N'') AS MS_CONG_NHAN, ISNULL(B.HO, N'') + ' ' + ISNULL(B.TEN, N'')  AS TEN_CONG_NHAN, A.USER_MAIL " &
                " FROM dbo.USERS A LEFT JOIN CONG_NHAN B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN " &
                " WHERE A.USERNAME = '" + Commons.Modules.UserName + "'"))
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.sTenNhanVienMD = dtTmp.Rows(0)("TEN_CONG_NHAN")
            Commons.Modules.sMaNhanVienMD = dtTmp.Rows(0)("MS_CONG_NHAN")
            Commons.Modules.sMailUser = dtTmp.Rows(0)("USER_MAIL")
        Catch ex As Exception
        End Try



        Commons.Modules.sTienTeMD = "VND"
        dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT TOP 1 ISNULL(NGOAI_TE,'') AS NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"))
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.sTienTeMD = dtTmp.Rows(0)("NGOAI_TE")
        Catch ex As Exception
        End Try

        Commons.Modules.sTenKhoMD = "-1"
        Commons.Modules.iMaKhoMD = -1
        dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT A.MS_KHO , C.TEN_KHO FROM NHOM_KHO A INNER JOIN USERS B ON A.GROUP_ID = B.GROUP_ID " &
                " INNER JOIN IC_KHO C ON A.MS_KHO = C.MS_KHO WHERE B.USERNAME = '" + Commons.Modules.UserName + "'"))
        Catch ex As Exception
        End Try
        Try
            If dtTmp.Rows.Count = 1 Then
                Commons.Modules.sTenKhoMD = dtTmp.Rows(0)("TEN_KHO")
                Commons.Modules.iMaKhoMD = dtTmp.Rows(0)("MS_KHO")
            End If
        Catch ex As Exception
        End Try

        dtTmp = New DataTable
        Dim dt As New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT * FROM THONG_TIN"))

            'Dinh nghia mail trong bbcp de goi mail khi lock phieu xuat
            dtTmp.DefaultView.RowFilter = "MS_TTIN = 'BBCP_MAIL'"
            dt = dtTmp.DefaultView.ToTable().Copy
            Try
                If dt.Rows.Count > 0 Then
                    Commons.Modules.iBBCPMail = Integer.Parse(dt.Rows(0)("THONG_TIN").ToString)
                Else
                    Commons.Modules.iBBCPMail = 0
                End If
            Catch ex As Exception
                Commons.Modules.iBBCPMail = 0
            End Try








        Catch ex As Exception
        End Try

    End Sub





End Class
