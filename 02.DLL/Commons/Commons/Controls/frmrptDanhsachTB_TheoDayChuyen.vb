Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhsachTB_TheoDayChuyen
    Private SqlText As String = String.Empty

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Cursor = Cursors.WaitCursor
        WriteXml()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmrptDanhsachTB_TheoDayChuyen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDaychuyen()
    End Sub
    Private Sub LoadDaychuyen()
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboDayChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
    End Sub
    Public Sub WriteXml()
        Dim frmShow As frmXMLReport = New frmXMLReport()
        Dim sql As String
        Try
            Dim dt As New DataTable
            sql = "SELECT dbo.MAY.MS_MAY,dbo.MAY.TEN_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, V_MAY_HE_THONG_MAX.NGAY_NHAP, " &
                          "dbo.MAY.NGAY_DUA_VAO_SD,dbo.NHA_XUONG.Ten_N_XUONG, dbo.HE_THONG.TEN_HE_THONG , ISNULL(T1.STT_SORT,9999) AS STT" &
                  " FROM dbo.MAY INNER JOIN " &
                          "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " &
                          "dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " &
                          "(SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP " &
                          "FROM MAY_NHA_XUONG " &
                          "GROUP BY MS_MAY) TAM ON TAM.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " &
                          "dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY AND " &
                          "TAM.NGAY_NHAP = dbo.MAY_NHA_XUONG.NGAY_NHAP INNER JOIN " &
                          "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " &
                          "V_MAY_HE_THONG_MAX ON dbo.MAY.MS_MAY = V_MAY_HE_THONG_MAX.MS_MAY INNER JOIN " &
                          "dbo.HE_THONG ON V_MAY_HE_THONG_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN (SELECT MS_HE_THONG,STT_SORT FROM [dbo].[MashjGetDCSTT]()) T1 ON T1.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " &
                          " WHERE " & cboDayChuyen.EditValue.ToString & " = -1 Or HE_THONG.MS_HE_THONG = " & cboDayChuyen.EditValue.ToString
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sql))
            dt.TableName = "rptDanhsachTB_TheoDayChuyen"
            If dt.Rows.Count = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            frmShow.AddDataTableSource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
            Exit Sub
        End Try
        frmShow.AddDataTableSource(RefeshLanguageReportTB_TheoDC())

        If Commons.Modules.sPrivate = "HUDA" Then
            frmShow.rptName = "rptDSTB_TheoDayChuyen_Huda"
        Else
            frmShow.rptName = "rptDSTB_TheoDayChuyen"
        End If

        frmShow.ShowDialog()
    End Sub
    Function RefeshLanguageReportTB_TheoDC() As DataTable

        Dim str As String = ""
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeDanhsachTB_TheoDayChuyen")
        Dim dtTmp As New DataTable
        Try

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

            str = "Create Table [dbo].rptTieuDeDanhsachTB_TheoDayChuyen(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," &
            "STT nvarchar(5),ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),NgayLap nvarchar(30),HeThong nvarchar(50),TenNhaXuong nvarchar(100) ,NgaySuDung nvarchar(30), TenThietBi NVARCHAR (256)) "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

            str = "Insert into [dbo].rptTieuDeDanhsachTB_TheoDayChuyen values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" &
            STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & NgayLap & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & NgaySuDung & "' , N'" & TenThietBi & "')"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)


            str = "SELECT * FROM rptTieuDeDanhsachTB_TheoDayChuyen"
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            dtTmp.TableName = "rptTieuDeDanhsachTB_TheoDayChuyen"
        Catch ex As Exception
            Commons.Modules.ObjSystems.XoaTable("rptTieuDeDanhsachTB_TheoDayChuyen")
            Return Nothing
        End Try
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeDanhsachTB_TheoDayChuyen")
        Return dtTmp


    End Function


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub

End Class
