Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptBreakdownTime
    Private SqlText As String = String.Empty

    Private Sub frmrptBreakdownTime_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("THOI_GIAN_NGUNG_MAY_DO_HU_HONG_TMP")
    End Sub
    Private Sub frmrptBreakdownTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpTu.Value = CDate("1/1/" & Year(Now))
        dtpDen.Value = CDate("31/12/" & Year(Now))
        LoadLoaiTB()
    End Sub

    Private Sub LoadLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY_PQ", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cboTG_LoaiTB.DataSource = dt
        cboTG_LoaiTB.ValueMember = "MS_LOAI_MAY"
        cboTG_LoaiTB.DisplayMember = "TEN_LOAI_MAY"

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If DateDiff(DateInterval.Day, dtpTu.Value, dtpDen.Value) < 0 Then
            MsgBox("Khoảng thời gian cần in báo cáo không hợp lệ !" & vbCrLf & "Vui lòng kiểm tra lại khoảng thời gian chọn in báo cáo.", MsgBoxStyle.Exclamation)
            dtpTu.Focus()
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        Call ShowrptThoiGianHuHong()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptThoiGianHuHong()
        Try

            Dim str As String = ""
            Dim objReader As SqlDataReader
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "CreateTHOI_GIAN_HU_HONG_DATA", dtpTu.Value, dtpDen.Value)
            objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT THOI_GIAN_NGUNG_MAY.*,THOI_GIAN_NGUNG_MAY.DEN_GIO-THOI_GIAN_NGUNG_MAY.TU_GIO AS THOI_GIAN_NGUNG_MAY FROM THOI_GIAN_NGUNG_MAY INNER JOIN NGUYEN_NHAN_DUNG_MAY ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN WHERE NGUYEN_NHAN_DUNG_MAY.HU_HONG<>0")
            While objReader.Read
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG SET THOI_GIAN_NGUNG_MAY=THOI_GIAN_NGUNG_MAY+" & (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Hour * 60) + (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Minute) & " WHERE MS_HE_THONG=" & objReader.Item("MS_HE_THONG"))
            End While
            objReader.Close()

            objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG,TEN_HE_THONG,COUNT(*) AS SO_LAN_HU_HONG,  SUM(isnull(THOI_GIAN_SUA_CHUA,0)) AS THOI_GIAN_HU_HONG FROM THOI_GIAN_NGUNG_MAY_DO_HU_HONG_TMP WHERE HU_HONG=1 GROUP BY MS_HE_THONG,TEN_HE_THONG")
            While objReader.Read
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG SET SO_LAN_HU_HONG=" & objReader.Item("SO_LAN_HU_HONG") & ",THOI_GIAN_HU_HONG=" & objReader.Item("THOI_GIAN_HU_HONG") & " WHERE MS_HE_THONG=" & objReader.Item("MS_HE_THONG"))
            End While
            objReader.Close()

            objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_HU_HONG")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()
            CreaterptThoiGianHuHong()
            ReportPreview("reports/rptBreakdownTime.rpt")
KetThuc:
            Try
                str = "drop table rptTHOI_GIAN_HU_HONG"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DROP TABLE rptTieuDeThoiGianHuHong"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try

    End Sub
    Sub CreaterptThoiGianHuHong()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTieuDeThoiGianHuHong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "NgayIn", Commons.Modules.TypeLanguage)
        Dim DayChuyen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "DayChuyen", Commons.Modules.TypeLanguage)
        Dim ThoiGianHH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianTBKhacPhucHH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianKhacPhucTB", Commons.Modules.TypeLanguage)
        Dim SoLanHuhong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "SoLanHuhong", Commons.Modules.TypeLanguage)
        Dim ThoiGianTBHuHong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianTBHuHong", Commons.Modules.TypeLanguage)
        Dim ThoiGianChayMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianChayMay", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "Tong", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblTG_TuNam.Text + " " + Format(dtpTu.Value, "Short date") + " " + lblTG_DenNam.Text + " " + Format(dtpDen.Value, "Short date")
        str = "Create table dbo.rptTieuDeThoiGianHuHong(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        "DieuKienLoc nvarchar(255),ThoiGian Nvarchar(150),DayChuyen nvarchar(100),ThoiGianHuhong nvarchar(255),ThoiGianKhacPhucTB nvarchar(255), " & _
        "SoLanHuhong nvarchar(255),ThoiGianTBHuHong nvarchar(255),ThoiGianChayMay nvarchar(255),Tong nvarchar(50),NguoiLap nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeThoiGianHuHong(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,DayChuyen,ThoiGianHuhong,ThoiGianKhacPhucTB,SoLanHuhong,ThoiGianTBHuHong,ThoiGianChayMay,Tong,NguoiLap) values(" & Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & _
        "',N'" & DayChuyen & "',N'" & ThoiGianHH & "',N'" & ThoiGianTBKhacPhucHH & "',N'" & SoLanHuhong & "',N'" & ThoiGianTBHuHong & "',N'" & ThoiGianChayMay & "',N'" & Tong & "',N'" & NguoiLap & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

End Class
