Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM
    Private SqlText As String = String.Empty
    Private Sub frmrptTHOI_GIAN_NGUNG_MAY_THEO_NAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call CreateTG_NgungMayTheoNam()
        Call PrintpreviewTG_NgungMayTheoNam()
        Me.Cursor = Cursors.Default
    End Sub

    Sub CreateTG_NgungMayTheoNam()
        Try
            SqlText = "DROP TABLE dbo.rptTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT DISTINCT dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY," & _
                         "dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU, dbo.NHA_XUONG.Ten_N_XUONG, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, " & _
                         "dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO " & _
                  "INTO [dbo].rptTG_NgungMayTheoNam FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                       "dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                       "dbo.MAY_NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN " & _
                       "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " & _
                       "dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                       "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                       "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY "

        SqlText = SqlText & "WHERE dbo.THOI_GIAN_NGUNG_MAY.NGAY BETWEEN '" & Format(dtpTu.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDen.Value, "MM/dd/yyyy") & "'"


        If cboTG_LoaiTB.SelectedValue.ToString <> "-1" Then SqlText += " AND dbo.LOAI_MAY.MS_LOAI_MAY='" & cboTG_LoaiTB.SelectedValue.ToString & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub PrintpreviewTG_NgungMayTheoNam()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTG_NgungMayTheoNam")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_NAM", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        RefeshLanguageReportTG_NgungMayTheoNam()
        Call ReportPreview("reports\rptTHOI_GIAN_NGUNG_MAY_THEO_NHIEU_NAM.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReportTG_NgungMayTheoNam()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrangIn", Commons.Modules.TypeLanguage)
        Dim DKLoc As String
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TenNhaXuong", Commons.Modules.TypeLanguage)
        Dim TGSuaChua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGSuaChua", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "GhiChu", Commons.Modules.TypeLanguage)
        Dim TuNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuNam", Commons.Modules.TypeLanguage)
        Dim DenNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenNam", Commons.Modules.TypeLanguage)
        Dim TrongNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrongNam", Commons.Modules.TypeLanguage)
        Dim TuKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuKhi", Commons.Modules.TypeLanguage)
        Dim DenKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenKhi", Commons.Modules.TypeLanguage)
        Dim TGNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGNgungMay", Commons.Modules.TypeLanguage)

        'If txtTG_TuNam.Text <> txtTG_DenNam.Text Then
        '    DKLoc = TuNam & " " & txtTG_TuNam.Text & " " & DenNam & " " & txtTG_DenNam.Text
        'ElseIf txtTG_TuNam.Text = txtTG_DenNam.Text Then
        '    DKLoc = TrongNam & " " & txtTG_TuNam.Text
        'End If
        DKLoc = ""
        str = "Create Table [dbo].rptTieuDeTG_NgungMayTheoNam(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),HeThong nvarchar(30),TenNhaXuong nvarchar(30),TGNgungMay nvarchar(50),TGSuaChua nvarchar(30),GhiChu nvarchar(30),TuNam nvarchar(30),DenNam nvarchar(30),TrongNam nvarchar(30),TuKhi nvarchar(30),DenKhi nvarchar(30),DKLoc nvarchar(255)) " & _
        "Insert into [dbo].rptTieuDeTG_NgungMayTheoNam values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & TGNgungMay & "',N'" & TGSuaChua & "',N'" & GhiChu & "',N'" & TuNam & "',N'" & DenNam & "',N'" & TrongNam & "',N'" & TuKhi & "',N'" & DenKhi & "',N'" & DKLoc & " ')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
