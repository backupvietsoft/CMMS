
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptDSTBTNLDHienTai
    Private SqlText As String = String.Empty
    Dim v_all As DataTable = New DataTable()
    Dim vtbValue As DataTable = New DataTable()
    Dim vtbHeader As DataTable = New DataTable("rptTieuDeDSBPChiuPhi")
    Dim vtbThongtinchung As DataTable = New DataTable("rptTHONG_TIN_CHUNG_TMP")

    Private Sub frmrptDSTBTNLDHienTai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadNhaxuong()
    End Sub
    Sub WriteXML()
        Dim source As DataSet = New DataSet()
        source.Tables.Add(vtbValue)
        source.Tables.Add(vtbThongtinchung)
        source.Tables.Add(vtbHeader)
        source.WriteXml(Application.StartupPath + "\XML\rptDSTBTNHienTai.xml", XmlWriteMode.WriteSchema)
    End Sub
    Sub LoadNhaxuong()
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboNhaxuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
    End Sub
    Sub Printpreview11()

        If (vtbValue.Rows.Count <= 0) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default


            GoTo KetThuc
        End If
        Dim vtb As DataTable = New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from THONG_TIN_CHUNG"))
        Try
            If vtb.Rows(0)("PRIVATE") = "DHG" Then
                Dim frmRP As frmXMLReport = New frmXMLReport()
                frmRP.rptName = "rptDSTBTNLDHienTai_DHG"

                CreateData11_DHG()
                'Call ReportPreview("reports\rptDSTBTNLDHienTai_DHG.rpt")
                Cursor = Cursors.Default
                frmRP.AddDataTableSource(vtbThongtinchung)
                frmRP.AddDataTableSource(vtbHeader)
                frmRP.AddDataTableSource(vtbValue)
                frmRP.Show()
            Else
                'Call ReportPreview("reports\rptDSTBTNLDHienTai.rpt")
                Dim frmRP As frmXMLReport = New frmXMLReport()
                frmRP.rptName = "rptDSTBTNLDHienTai"
                CreateData11()
                frmRP.AddDataTableSource(vtbThongtinchung)
                frmRP.AddDataTableSource(vtbHeader)
                frmRP.AddDataTableSource(vtbValue)
                frmRP.Show()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Dim frmRP As frmXMLReport = New frmXMLReport()
            frmRP.rptName = "rptDSTBTNLDHienTai"
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtbHeader)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.Show()
            Cursor = Cursors.Default
        End Try


KetThuc:
        Try
            SqlText = "delete dbo.rptDSTBTNLDHienTai_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeDSThietBiTheoNoiLapDatHT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport11()
        Dim str As String = ""
        Try
            'str = "Drop table rptTieuDeDSThietBiTheoNoiLapDatHT"
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            vtbHeader = New DataTable("rptTieuDeDSBPChiuPhi")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NoiLapDat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NoiLapDat", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "SoThe", Commons.Modules.TypeLanguage)
        Dim NhomThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NhomThietBi", Commons.Modules.TypeLanguage)
        Dim HienTrang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "HienTrang", Commons.Modules.TypeLanguage)
        Dim NuocSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NuocSX", Commons.Modules.TypeLanguage)
        Dim TyLe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TyLe", Commons.Modules.TypeLanguage)
        Dim NgayLD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayLD", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "MoTa", Commons.Modules.TypeLanguage)
        Dim CongSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "CongSuat", Commons.Modules.TypeLanguage)
        Dim NangSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NangSuat", Commons.Modules.TypeLanguage)

        vtbHeader.Columns.Add("commons.Modules.TypeLanguage")
        vtbHeader.Columns.Add("NgayIn")
        vtbHeader.Columns.Add("TrangIn")
        vtbHeader.Columns.Add("TieuDe")
        vtbHeader.Columns.Add("NoiLapDat")
        vtbHeader.Columns.Add("STT")
        vtbHeader.Columns.Add("ThietBi")
        vtbHeader.Columns.Add("SoThe")
        vtbHeader.Columns.Add("NhomThietBi")
        vtbHeader.Columns.Add("HienTrang")
        vtbHeader.Columns.Add("NuocSX")
        vtbHeader.Columns.Add("TyLe")
        vtbHeader.Columns.Add("NgayLD")
        vtbHeader.Columns.Add("MoTa")
        vtbHeader.Columns.Add("CongSuat")
        vtbHeader.Columns.Add("NangSuat")

        vtbHeader.Rows.Add(Commons.Modules.TypeLanguage, NgayIn, TrangIn, TieuDe, NoiLapDat, STT, ThietBi, SoThe, NhomThietBi, HienTrang, NuocSX, TyLe, NgayLD, MoTa, CongSuat, NangSuat)
    End Sub

    Sub CreateData11()
        RefeshThongTin()
        RefeshLanguageReport11()
        Cursor = Cursors.WaitCursor
        
        Dim _nx As String = "-1"
        Try
            _nx = cboNhaxuong.EditValue.ToString()
        Catch ex As Exception
            _nx = "-1"
        End Try
        ' Dim _table As DataTable = New DataTable()
        vtbValue = New DataTable("rptDSTBTNLDHienTai_TMP")
        vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sBCDSTBHienTrang", Modules.UserName, _nx, Modules.TypeLanguage))
        vtbValue.TableName = "rptDSTBTNLDHienTai_TMP"
        WriteXML()
       
    End Sub


    Sub CreateData11_DHG()
        RefeshThongTin()
        RefeshLanguageReport11()
        Cursor = Cursors.WaitCursor
        
        Dim _nx As String = "-1"
        Try
            _nx = cboNhaxuong.EditValue.ToString()
        Catch ex As Exception
            _nx = "-1"
        End Try
        v_all = New DataTable()
        vtbValue = New DataTable("rptDSTBTNLDHienTai_TMP")
        vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sBCDSTBHienTrang", Modules.UserName, _nx, Modules.TypeLanguage))
        vtbValue.TableName = "rptDSTBTNLDHienTai_TMP"
        WriteXML()

    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Private Sub RefeshThongTin()
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        ' clsXuLy.CreateTitleReport()
        Call CreateData11()
        Call Printpreview11()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
