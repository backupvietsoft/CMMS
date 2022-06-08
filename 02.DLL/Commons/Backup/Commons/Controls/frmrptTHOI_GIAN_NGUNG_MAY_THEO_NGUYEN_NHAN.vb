
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN
    Dim vTuNgay As DateTime
    Dim vDenNgay As DateTime

    Private Sub frmrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        MskFromdate.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        MskTodate.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        BinLine()
        BinCause()
    End Sub
    Sub BinCause()
        Dim TbCause As DataTable = New DataTable()
        TbCause.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_NGUYEN_NHAN_DUNG_MAY"))
        TbCause.Columns("CHON_NGUYEN_NHAN").ReadOnly = False
        DgvCause.AutoGenerateColumns = False
        DgvCause.DataSource = TbCause
        DgvCause.Columns("MS_NGUYEN_NHAN").DataPropertyName = "MS_NGUYEN_NHAN"
        DgvCause.Columns("TEN_NGUYEN_NHAN").DataPropertyName = "TEN_NGUYEN_NHAN"
        DgvCause.Columns("CHON_NGUYEN_NHAN").DataPropertyName = "CHON_NGUYEN_NHAN"
    End Sub
    Sub BinLine()
        Dim sqlT = "SELECT DISTINCT HE_THONG.MS_HE_THONG,HE_THONG.TEN_HE_THONG FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY HE_THONG.TEN_HE_THONG"
        Dim TbLine As DataTable = New DataTable()
        TbLine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_DAY_CHUYEN", Commons.Modules.UserName))
        TbLine.Columns("CHON_HE_THONG").ReadOnly = False
        DgvLine.AutoGenerateColumns = False
        DgvLine.DataSource = TbLine
        DgvLine.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
        DgvLine.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
        DgvLine.Columns("CHON_HE_THONG").DataPropertyName = "CHON_HE_THONG"
    End Sub
    Function CreateTG_NgungMayTheoNguyenNhan() As DataTable
        Dim SqlText As String
        Try
            SqlText = "DROP TABLE rptTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Dim sqlLine As String = String.Empty
        For i As Integer = 0 To DgvLine.Rows.Count - 1
            If (DgvLine.Rows(i).Cells("CHON_HE_THONG").Value.Equals(True)) Then
                sqlLine = sqlLine & DgvLine.Rows(i).Cells("MS_HE_THONG").Value.ToString() & ","
            End If
        Next
        Dim sqlCause As String = String.Empty
        For j As Integer = 0 To DgvCause.Rows.Count - 1
            If (DgvCause.Rows(j).Cells("CHON_NGUYEN_NHAN").Value.Equals(True)) Then
                sqlCause = sqlCause & DgvCause.Rows(j).Cells("MS_NGUYEN_NHAN").Value.ToString() & ","
            End If
        Next
        If Not sqlLine.Equals(String.Empty) And Not sqlCause.Equals(String.Empty) Then
            SqlText = "SELECT THOI_GIAN_NGUNG_MAY.MS_MAY,dbo.MAY.TEN_MAY, NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN, NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.NGAY, " & _
                             "THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_NGAY, THOI_GIAN_NGUNG_MAY.DEN_GIO, " & _
                             "THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, THOI_GIAN_NGUNG_MAY.MS_HE_THONG, HE_THONG.TEN_HE_THONG, " & _
                             "NHA_XUONG.Ten_N_XUONG, THOI_GIAN_NGUNG_MAY.GHI_CHU ,THOI_GIAN_NGUNG_MAY.NGUOI_GIAI_QUYET , dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS CONG_NHAN " & _
                         " FROM   dbo.MAY INNER JOIN" & _
                         " dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                         " dbo.NGUYEN_NHAN_DUNG_MAY ON " & _
                         " dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " & _
                         " dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                         " dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN " & _
                         " dbo.NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG  " & _
                         " LEFT OUTER JOIN dbo.CONG_NHAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN " & _
                         " WHERE THOI_GIAN_NGUNG_MAY.NGAY>='" & Format(vTuNgay, "dd/MMM/yyyy") & "' AND THOI_GIAN_NGUNG_MAY.NGAY <'" & Format(vDenNgay, "dd/MMM/yyyy") & "' "
            SqlText = SqlText & "AND dbo.HE_THONG.MS_HE_THONG In(" & sqlLine.Substring(0, sqlLine.Length - 1) & ") AND dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN IN (" & sqlCause.Substring(0, sqlCause.Length - 1) & ")"
            Dim vtb As New DataTable
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
            Return vtb
        End If
        Return New DataTable
    End Function
    Private Function RefeshLanguageReportTG_NgungMayTheoNguyenNhan() As DataTable
        Dim sDKLoc As String = LabFromdate.Text & " " & Format(vTuNgay, "dd/MM/yyyy") & "  -  " & LabTodate.Text & " " & Format(vDenNgay, "dd/MM/yyyy")
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "rptTieuDeTG_NgungMayTheoNguyenNhan"
        For i As Integer = 0 To 17
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TieuDe"
        vtbTitle.Columns(1).ColumnName = "NgayIn"
        vtbTitle.Columns(2).ColumnName = "TrangIn"
        vtbTitle.Columns(3).ColumnName = "ThietBi"
        vtbTitle.Columns(4).ColumnName = "NguyenNhan"
        vtbTitle.Columns(5).ColumnName = "HeThong"
        vtbTitle.Columns(6).ColumnName = "TenNhaXuong"
        vtbTitle.Columns(7).ColumnName = "TGSuaChua"
        vtbTitle.Columns(8).ColumnName = "GhiChu"
        vtbTitle.Columns(9).ColumnName = "TuKhi"
        vtbTitle.Columns(10).ColumnName = "DenKhi"
        vtbTitle.Columns(11).ColumnName = "TG_NgungMay"
        vtbTitle.Columns(12).ColumnName = "DKLoc"
        vtbTitle.Columns(13).ColumnName = "TEN_MAY"
        vtbTitle.Columns(14).ColumnName = "TongNN"
        vtbTitle.Columns(15).ColumnName = "TongDC"
        vtbTitle.Columns(16).ColumnName = "NGUOI_GIAI_QUYET"
        vtbTitle.Columns(17).ColumnName = "CONG_NHAN"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TieuDe") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TieuDe", Commons.Modules.TypeLanguage)
        vRowTitle("NgayIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "NgayIn", Commons.Modules.TypeLanguage)
        vRowTitle("TrangIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TrangIn", Commons.Modules.TypeLanguage)
        vRowTitle("ThietBi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "ThietBi", Commons.Modules.TypeLanguage)
        vRowTitle("NguyenNhan") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "NguyenNhan", Commons.Modules.TypeLanguage)
        vRowTitle("HeThong") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "HeThong", Commons.Modules.TypeLanguage)
        vRowTitle("TenNhaXuong") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TenNhaXuong", Commons.Modules.TypeLanguage)
        vRowTitle("TGSuaChua") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TGSuaChua", Commons.Modules.TypeLanguage)
        vRowTitle("GhiChu") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "GhiChu", Commons.Modules.TypeLanguage)
        vRowTitle("TuKhi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TuKhi", Commons.Modules.TypeLanguage)
        vRowTitle("DenKhi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "DenKhi", Commons.Modules.TypeLanguage)
        vRowTitle("TG_NgungMay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TG_NgungMay", Commons.Modules.TypeLanguage)
        vRowTitle("DKLoc") = sDKLoc
        vRowTitle("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TEN_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("TongNN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TongNN", Commons.Modules.TypeLanguage)
        vRowTitle("TongDC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TongDC", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_GIAI_QUYET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        vRowTitle("CONG_NHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "CONG_NHAN", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Private Sub MskFromdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MskFromdate.Validating
        Try
            vTuNgay = DateTime.ParseExact(MskFromdate.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN", "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub
    Private Sub MskTodate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MskTodate.Validating
        Try
            vDenNgay = DateTime.ParseExact(MskTodate.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN", "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub
    Private Sub BtnAllLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllLine.Click
        For i As Integer = 0 To DgvLine.Rows.Count - 1
            DgvLine.Rows(i).Cells("CHON_HE_THONG").Value = True
        Next
    End Sub
    Private Sub BtnClearLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        For i As Integer = 0 To DgvLine.Rows.Count - 1
            DgvLine.Rows(i).Cells("CHON_HE_THONG").Value = False
        Next
    End Sub
    Private Sub BtnAllCause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllCause.Click
        For i As Integer = 0 To DgvCause.Rows.Count - 1
            DgvCause.Rows(i).Cells("CHON_NGUYEN_NHAN").Value = True
        Next
    End Sub
    Private Sub BtnClearCause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearCause.Click
        For i As Integer = 0 To DgvCause.Rows.Count - 1
            DgvCause.Rows(i).Cells("CHON_NGUYEN_NHAN").Value = False
        Next
    End Sub

    Private Sub btnThucHien_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Dim vtbdata As New DataTable
        vtbdata = CreateTG_NgungMayTheoNguyenNhan()
        If vtbdata.Rows.Count = 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN", "KO_CO_DL_DE_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        vtbdata.TableName = "rptTG_NgungMayTheoNguyenNhan"
        Dim frm As frmXMLReport = New frmXMLReport

        frm.rptName = "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
        frm.AddDataTableSource(vtbdata)
        frm.AddDataTableSource(RefeshLanguageReportTG_NgungMayTheoNguyenNhan())
        frm.ShowDialog()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
