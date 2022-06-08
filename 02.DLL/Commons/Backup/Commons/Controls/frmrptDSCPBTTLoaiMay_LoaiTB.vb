
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDSCPBTTLoaiMay_LoaiTB
    Private SqlText As String = String.Empty
    Dim v_all As DataTable = New DataTable()
    Dim vtbValue As DataTable = New DataTable()
    Dim vtbHeader As DataTable = New DataTable("rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP")
    Dim vtbThongtinchung As DataTable = New DataTable("rptTHONG_TIN_CHUNG_TMP")
    Private Sub frmrptDSCPBTTLoaiMay_LoaiTB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
        dtpDenNgay.Value = DateTime.Now
        loadCboLoaiTB()
        loadCboDiaDiem1()
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function

    Private Sub loadCboLoaiTB()
        Dim str As String = ""
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaiTB1.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB1.ValueMember = "MS_LOAI_MAY"
        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow(0) = -1
        dtRow(1) = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboLoaiTB1.DataSource = dt
        If cboLoaiTB1.Items.Count = 0 Then
            cboLoaiTB1.Text = ""
        End If
    End Sub
    Private Sub loadCboDiaDiem1()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cboDiaDiem1.DisplayMember = "TEN_N_XUONG"
        cboDiaDiem1.ValueMember = "MS_N_XUONG"
        cboDiaDiem1.DataSource = _table
    End Sub
    Private Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "'  FROM THONG_TIN_CHUNG "
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "'  FROM THONG_TIN_CHUNG "
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
    End Sub
    Private Sub RefeshLanguageReport15()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String
        vtbHeader = New DataTable("rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP")
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DEN_NGAY", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DIA_DIEM", Commons.Modules.TypeLanguage)
        NHOM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NHOM_TB", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "MS_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TRANG", Commons.Modules.TypeLanguage)

        vtbHeader.Columns.Add("TIEU_DE_")
        vtbHeader.Columns.Add("TU_NGAY_")
        vtbHeader.Columns.Add("DEN_NGAY_")
        vtbHeader.Columns.Add("DIA_DIEM_")
        vtbHeader.Columns.Add("NHOM_TB_")
        vtbHeader.Columns.Add("TEN_LOAI_TB_")
        vtbHeader.Columns.Add("STT_")
        vtbHeader.Columns.Add("YEU_CAU_")
        vtbHeader.Columns.Add("MS_TB_")
        vtbHeader.Columns.Add("LOAI_BT_")
        vtbHeader.Columns.Add("NGAY_BD_")
        vtbHeader.Columns.Add("NGAY_KT_")
        vtbHeader.Columns.Add("TT_TRUOC_BT_")
        vtbHeader.Columns.Add("TT_SAU_BT_")
        vtbHeader.Columns.Add("TRANG_")

        vtbHeader.Rows.Add(TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)
        'Try
        '    SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'Catch ex As Exception
        'End Try
        'SqlText = "CREATE TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP(TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), DIA_DIEM_ nvarchar(50),
        'NHOM_TB_ nvarchar(50),TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), 
        'NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50),TRANG_ nvarchar(50))"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCPBTTLoaiMay_DiaDiem", TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB,
        ' TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub
    Sub WriteXML()
        Dim source As DataSet = New DataSet()
        source.Tables.Add(vtbValue)
        source.Tables.Add(vtbThongtinchung)
        source.Tables.Add(vtbHeader)
        source.WriteXml(Application.StartupPath + "\XML\rptDSCPBTTLoaiMay_LoaiTB.xml", XmlWriteMode.WriteSchema)
    End Sub

    Sub CreateData15()

        RefeshHeaderReport()
        RefeshLanguageReport15()

        'Try
        '    SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'Catch ex As Exception
        'End Try
        Dim date_Tungay As DateTime
        Dim date_Denngay As DateTime
        date_Tungay = Convert.ToDateTime(dtpTuNgay.Value.ToString())
        date_Denngay = Convert.ToDateTime(dtpDenNgay.Value.ToString())
        v_all = New DataTable()
        vtbValue = Get_DataTable(cboDiaDiem1.SelectedValue.ToString(), date_Tungay, date_Denngay, rdLMDaNghiemThu.Checked, cboLoaiTB1.SelectedValue.ToString(), "-1", "-1", "-1")
        vtbValue.TableName = "rptDSCPBTTLoaiMay_DiaDiem_TMP"
        WriteXML()
    End Sub
    Sub Printpreview15()
        '        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCPBTTLoaiMay_DiaDiem_TMP")
        '        While objReader.Read
        '            If objReader.Item("TONG") = 0 Then
        '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '                objReader.Close()
        '                GoTo KetThuc
        '            End If
        '        End While
        '        objReader.Close()

        '        Cursor = Cursors.WaitCursor

        '        Call ReportPreview("reports\rptDSCPBTTLoaiMay_DiaDiem.rpt")
        '        Cursor = Cursors.Default
        'KetThuc:
        '        Try
        '            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
        '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        '        Catch ex As Exception
        '        End Try

        '        Try
        '            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
        '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
        '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        '        Catch ex As Exception
        '        End Try

    End Sub






    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click


        Call CreateData15()
        Call Printpreview15()
        Dim frmRP As frmXMLReport = New frmXMLReport()
        frmRP.rptName = "rptDSCPBTTLoaiMay_LoaiTB"
        'Dim vtbValue As DataTable = New DataTable("DS_TB")
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetThietBiConHanBaoHanh", vDay, cbxNhaXuong.SelectedValue, cboLoaiTB.SelectedValue))
        'vtbValue = Get_DataTable(cbxNhaXuong.SelectedValue.ToString(), vDay, cboLoaiTB.SelectedValue.ToString(), "-1", "-1", "-1")
        'vtbValue.TableName = "DS_TB"
        If vtbValue.Rows.Count > 0 Then
            'Dim vtblg As DataTable = New DataTable()
            'vtblg = RefeshLanguage()
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtbHeader)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.Show()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
    End Sub

    Private Sub rdLoaiMay_DD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        cboDiaDiem1.SelectedIndex = 0
        cboDiaDiem1.Enabled = True
        cboLoaiTB1.Enabled = False
    End Sub

    Private Sub rdLoaiMay_LoaiTB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        cboLoaiTB1.SelectedIndex = 0
        cboDiaDiem1.Enabled = False
        cboLoaiTB1.Enabled = True
    End Sub
#Region "Nhu Y"
 
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal nghiemthu As Boolean, ByVal loai_may As String, ByVal ms_tinh As String, ByVal ms_quan As String, ByVal ms_duong As String) As System.Data.DataTable



        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_DSCPBTTLoaiMay_NEW]", tungay, denngay, nghiemthu, loai_may, MS_N_Xuong, ms_tinh, ms_quan, ms_duong))


        Return objDataTable

    End Function

#End Region
  
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
