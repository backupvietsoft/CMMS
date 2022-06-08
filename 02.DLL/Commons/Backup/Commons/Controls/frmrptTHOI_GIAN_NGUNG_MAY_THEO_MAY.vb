Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptTHOI_GIAN_NGUNG_MAY_THEO_MAY
    Private SqlText As String = String.Empty

    Private Sub frmrptTHOI_GIAN_NGUNG_MAY_THEO_MAY_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_HU_HONG_THEO_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTieuDeThoiGianHuHong")

    End Sub
    Private Sub frmrptTHOI_GIAN_NGUNG_MAY_THEO_MAY_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Call ShowrptThoiGianHuHongTheoThietBi()
        Me.Cursor = Cursors.Default
    End Sub


    Sub ShowrptThoiGianHuHongTheoThietBi()
        Try

            Dim str As String = ""
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_HU_HONG_THEO_MAY")

            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CreateTHOI_GIAN_HU_HONG_THEO_LOAI_MAY_DATA", _
                    dtpTu.Value, dtpDen.Value, cboTG_LoaiTB.SelectedValue.ToString, Commons.Modules.UserName)


            Dim objReader As SqlDataReader
            str = "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_HU_HONG_THEO_MAY"
            objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While

            CreaterptThoiGianHuHongTheoThietBi()
            ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_MAY.rpt")
KetThuc:
        Catch ex As Exception

        End Try

    End Sub

    Sub CreaterptThoiGianHuHongTheoThietBi()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTieuDeThoiGianHuHongTheoThietBi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim SoLanHuhong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "SoLanHuhong", Commons.Modules.TypeLanguage)
        Dim ThoiGianNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianHuHong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThoiGianHuHong", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "Tong", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = lblTG_TuNam.Text + " " + Format(dtpTu.Value, "Short date") + "     " + lblTG_DenNam.Text + " " + Format(dtpDen.Value, "Short date")
        str = "Create table dbo.rptTieuDeThoiGianHuHongTheoThietBi(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        "DieuKienLoc nvarchar(255),ThoiGian Nvarchar(150),ThietBi nvarchar(30),LoaiThietBi nvarchar(50),SoLanHuhong nvarchar(30),ThoiGianNgungMay nvarchar(30)," & _
        "ThoiGianHuHong nvarchar(50),Tong nvarchar(50),NguoiLap nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeThoiGianHuHongTheoThietBi(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,ThietBi,LoaiThietBi,SoLanHuhong,ThoiGianNgungMay,ThoiGianHuHong,Tong,NguoiLap) values(" & Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & _
        "',N'" & ThietBi & "',N'" & LoaiThietBi & "',N'" & SoLanHuhong & "',N'" & ThoiGianNgungMay & "',N'" & ThoiGianHuHong & "',N'" & Tong & "',N'" & NguoiLap & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
