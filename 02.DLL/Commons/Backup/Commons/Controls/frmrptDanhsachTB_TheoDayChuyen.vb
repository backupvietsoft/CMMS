Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhsachTB_TheoDayChuyen
    Private SqlText As String = String.Empty

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call CreateDataTB_TheoDC()
        Call PrintpreviewTB_TheoDC()
        WriteXml()
    End Sub

    Private Sub frmrptDanhsachTB_TheoDayChuyen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDaychuyen()
    End Sub
    Private Sub LoadDaychuyen()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow("MS_HE_THONG") = -1
        dtRow("TEN_HE_THONG") = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboDayChuyen.DataSource = dt
        cboDayChuyen.ValueMember = "MS_HE_THONG"
        cboDayChuyen.DisplayMember = "TEN_HE_THONG"
    End Sub
    Public Sub WriteXml()
        Dim frmShow As frmXMLReport = New frmXMLReport()
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        ' Lay tieu de
        Dim sql As String
        Try
            Dim dt As New DataTable
            sql = "Select * From dbo.rptTHONG_TIN_CHUNG "
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            dt.TableName = "rptTHONG_TIN_CHUNG_TMP"
            da.Fill(dt)
            'ds.Tables.Add(dt)

            frmShow.AddDataTableSource(dt)
            ' Lay tieu de tu frmDanhSachPhieuXuat
        Catch ex As Exception
        End Try
        'Dim dt As New DataTable

        Try
            'CreateTitleObjectReport()
            Dim dt As New DataTable
            sql = "Select * From rptDanhsachTB_TheoDayChuyen"
            dt.TableName = "rptDanhsachTB_TheoDayChuyen"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception

        End Try
        Try
            'CreateTitleObjectReport()
            Dim dt As New DataTable
            sql = "Select * From rptTieuDeDanhsachTB_TheoDayChuyen"
            dt.TableName = "rptTieuDeDanhsachTB_TheoDayChuyen"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception

        End Try
        sql = "select private from THONG_TIN_CHUNG"
        Dim condition As String = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        If condition = "HUDA" Then
            frmShow.rptName = "rptDSTB_TheoDayChuyen_Huda"
        Else
            frmShow.rptName = "rptDSTB_TheoDayChuyen"
        End If

        frmShow.ShowDialog()

        'frmReportPhieuNhap.danhSach = ds
        'dsTable = ds
        'ds.WriteXml("XML\PhieuNhapKho.xml", XmlWriteMode.WriteSchema)
    End Sub
    Private Sub RefeshLanguageReportTB_TheoDC()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "ThietBi", Commons.Modules.TypeLanguage)
        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "Ngay", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TenNhaXuong", Commons.Modules.TypeLanguage)
        Dim NgaySuDung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "NgaySuDung", Commons.Modules.TypeLanguage)

        str = "Create Table [dbo].rptTieuDeDanhsachTB_TheoDayChuyen(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "STT nvarchar(5),ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),NgayLap nvarchar(30),HeThong nvarchar(50),TenNhaXuong nvarchar(100) ,NgaySuDung nvarchar(30), TenThietBi NVARCHAR (256)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeDanhsachTB_TheoDayChuyen values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & NgayLap & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & NgaySuDung & "' , N'" & TenThietBi & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub CreateDataTB_TheoDC()
        RefeshLanguageReportTB_TheoDC()
        Cursor = Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE dbo.rptDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT dbo.MAY.MS_MAY,dbo.MAY.TEN_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, V_MAY_HE_THONG_MAX.NGAY_NHAP, " & _
                          "dbo.MAY.NGAY_DUA_VAO_SD,dbo.NHA_XUONG.Ten_N_XUONG, dbo.HE_THONG.TEN_HE_THONG " & _
                  "INTO   [dbo].rptDanhsachTB_TheoDayChuyen FROM dbo.MAY INNER JOIN " & _
                          "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                          "dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " & _
                          "(SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP " & _
                          "FROM MAY_NHA_XUONG " & _
                          "GROUP BY MS_MAY) TAM ON TAM.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                          "dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY AND " & _
                          "TAM.NGAY_NHAP = dbo.MAY_NHA_XUONG.NGAY_NHAP INNER JOIN " & _
                          "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " & _
                          "V_MAY_HE_THONG_MAX ON dbo.MAY.MS_MAY = V_MAY_HE_THONG_MAX.MS_MAY INNER JOIN " & _
                          "dbo.HE_THONG ON V_MAY_HE_THONG_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG "

        If cboDayChuyen.SelectedValue <> -1 Then SqlText = SqlText & "WHERE TEN_HE_THONG=N'" & cboDayChuyen.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub PrintpreviewTB_TheoDC()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDanhsachTB_TheoDayChuyen")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                '  GoTo KetThuc
            End If
        End While
        objReader.Close()
        'Call ReportPreview("reports\rptDSTB_TheoDayChuyen_Huda.rpt")
        Cursor = Cursors.Default
        'KetThuc:
        '        Try
        '            SqlText = "DROP TABLE dbo.rptDanhsachTB_TheoDayChuyen"
        '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        '            SqlText = "Drop table rptTieuDeDanhsachTB_TheoDayChuyen"
        '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        '        Catch ex As Exception
        '        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
