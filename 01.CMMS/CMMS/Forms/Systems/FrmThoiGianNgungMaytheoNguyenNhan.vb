Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data


Public Class FrmThoiGianNgungMaytheoNguyenNhan

    Dim vTuNgay As DateTime
    Dim vDenNgay As DateTime
    Dim sDayChuyen As String

    Private Sub FrmThoiGianNgungMaytheoNguyenNhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        cbxNguyenNhan.Value = "MS_NGUYEN_NHAN"
        cbxNguyenNhan.Display = "TEN_NGUYEN_NHAN"
        cbxNguyenNhan.StoreName = "GetNGUYEN_NHAN_DUNG_MAY"
        cbxNguyenNhan.BindDataSource()

        'cbxDayChuyen.Value = "MS_HE_THONG"
        'cbxDayChuyen.Display = "TEN_HE_THONG"
        'cbxDayChuyen.DropDownWidth = 200
        'cbxDayChuyen.Param = "SELECT DISTINCT HE_THONG.* FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY HE_THONG.TEN_HE_THONG"
        'cbxDayChuyen.StoreName = "QL_SEARCH" ' GetHE_THONGs"
        'cbxDayChuyen.BindDataSource()
        Call ShowData()

    End Sub

    Sub ShowData()
        Dim column As New DataGridViewCheckBoxColumn
        gvDaychuyen.Columns.Clear()
        With column
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        Dim sqlT = "SELECT DISTINCT HE_THONG.MS_HE_THONG,HE_THONG.TEN_HE_THONG FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY HE_THONG.TEN_HE_THONG"
        Dim dt As DataTable = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sqlT))
        gvDaychuyen.DataSource = dt
        Me.gvDaychuyen.Columns.Insert(0, column)
        Call FormatGrid()
    End Sub

    Sub FormatGrid()
        gvDaychuyen.ReadOnly = False
        With gvDaychuyen
            .Columns("MS_HE_THONG").Visible = False
            '.Columns("TEN_HE_THONG").Visible = False
            '.Columns("MS_HE_THONG").ReadOnly = False
            .Columns("TEN_HE_THONG").ReadOnly = True
            .Columns("chkChon").ReadOnly = False
            Me.gvDaychuyen.Columns("TEN_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_HE_THONG", Commons.Modules.TypeLanguage)
            Me.gvDaychuyen.Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "chkChon", Commons.Modules.TypeLanguage)

            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

        End With

    End Sub

    Sub FindCheck()
        sDayChuyen = ""
        Dim i As Integer
        For i = 0 To gvDaychuyen.Rows.Count - 1
            Try
                If Boolean.Parse(gvDaychuyen.Rows(i).Cells("chkChon").Value.ToString) = True Then
                    Dim sMS As String = gvDaychuyen.Rows(i).Cells("MS_HE_THONG").Value.ToString()
                    If sDayChuyen <> "" Then
                        sDayChuyen = sDayChuyen & "," & sMS
                    Else
                        sDayChuyen = sMS
                    End If
                End If
            Catch ex As Exception

            End Try
        Next i
    End Sub

    Function CreateTG_NgungMayTheoNguyenNhan() As DataTable
        Dim SqlText As String
        Try
            SqlText = "DROP TABLE rptTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Call FindCheck()
        If sDayChuyen <> "" Then

            SqlText = "SELECT THOI_GIAN_NGUNG_MAY.MS_MAY,dbo.MAY.TEN_MAY, NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN, NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.NGAY, " &
                             "THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_NGAY, THOI_GIAN_NGUNG_MAY.DEN_GIO, " &
                             "THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, THOI_GIAN_NGUNG_MAY.MS_HE_THONG, HE_THONG.TEN_HE_THONG, " &
                             "NHA_XUONG.Ten_N_XUONG, THOI_GIAN_NGUNG_MAY.GHI_CHU " &
                         " FROM   dbo.MAY INNER JOIN" &
                         " dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " &
                         " dbo.NGUYEN_NHAN_DUNG_MAY ON " &
                         " dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " &
                         " dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " &
                         " dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN " &
                         " dbo.NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " &
                         " WHERE THOI_GIAN_NGUNG_MAY.NGAY>='" & Format(vTuNgay, "dd/MMM/yyyy") & "' AND THOI_GIAN_NGUNG_MAY.DEN_NGAY <'" & Format(vDenNgay, "dd/MMM/yyyy") & "' "

            If cbxNguyenNhan.SelectedValue.ToString <> "-1" Then SqlText = SqlText & "AND NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN=" & cbxNguyenNhan.SelectedValue

            If sDayChuyen <> "" Then SqlText = SqlText & "AND dbo.HE_THONG.MS_HE_THONG in (" & sDayChuyen & ")"

            Dim vtb As New DataTable
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
            Return vtb
        End If

        Return New DataTable
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Function


    Private Function RefeshLanguageReportTG_NgungMayTheoNguyenNhan() As DataTable
        'Dim str As String = ""
        'Try
        '    str = "Drop table rptTieuDeTG_NgungMayTheoNguyenNhan"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'Catch ex As Exception
        'End Try

        'Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TieuDe", commons.Modules.TypeLanguage)
        'Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "NgayIn", commons.Modules.TypeLanguage)
        'Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrangIn", commons.Modules.TypeLanguage)
        'Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "ThietBi", commons.Modules.TypeLanguage)
        'Dim NguyenNhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "NguyenNhan", commons.Modules.TypeLanguage)
        'Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "HeThong", commons.Modules.TypeLanguage)
        'Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TenNhaXuong", commons.Modules.TypeLanguage)
        'Dim TGSuaChua As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGSuaChua", commons.Modules.TypeLanguage)
        'Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "GhiChu", commons.Modules.TypeLanguage)
        'Dim TuKhi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuKhi", commons.Modules.TypeLanguage)
        'Dim DenKhi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenKhi", commons.Modules.TypeLanguage)
        'Dim TG_NgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TG_NgungMay", commons.Modules.TypeLanguage)
        Dim sDKLoc As String = lbaTuNgay.Text & " " & Format(vTuNgay, "dd/MM/yyyy") & "  -  " & lbaDenNgay.Text & " " & Format(vDenNgay, "dd/MM/yyyy")
        'Dim tentb As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TEN_MAY", commons.Modules.TypeLanguage)

        'str = "Create Table [dbo].rptTieuDeTG_NgungMayTheoNguyenNhan(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        '"ThietBi nvarchar(50),NguyenNhan nvarchar(30),HeThong nvarchar(30),TenNhaXuong nvarchar(30),TGSuaChua nvarchar(30),GhiChu nvarchar(30),TuKhi nvarchar(30),DenKhi nvarchar(30),TG_NgungMay nvarchar(30), DKLoc nvarchar(255),TEN_MAY NVARCHAR(200) ) " & _
        '"Insert into [dbo].rptTieuDeTG_NgungMayTheoNguyenNhan values(" & commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        'ThietBi & "',N'" & NguyenNhan & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & TGSuaChua & "',N'" & GhiChu & "',N'" & TuKhi & "',N'" & DenKhi & "',N'" & TG_NgungMay & "',N'" & sDKLoc & "',N'" & tentb & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "rptTieuDeTG_NgungMayTheoNguyenNhan"
        For i As Integer = 0 To 15
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
        vRowTitle("DKLoc") = sDKLoc ' Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "DKLoc", commons.Modules.TypeLanguage)
        vRowTitle("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TEN_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("TongNN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TongNN", Commons.Modules.TypeLanguage)
        vRowTitle("TongDC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TongDC", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function


    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        If vTuNgay > vDenNgay Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Dim vtbdata As New DataTable
        vtbdata = CreateTG_NgungMayTheoNguyenNhan()
        If vtbdata.Rows.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CO_DL_DE_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        vtbdata.TableName = "rptTG_NgungMayTheoNguyenNhan"
        Dim frm As frmShowXMLReport = New frmShowXMLReport

        frm.rptName = "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
        frm.AddDataTableSource(vtbdata)
        frm.AddDataTableSource(RefeshLanguageReportTG_NgungMayTheoNguyenNhan())
        frm.ShowDialog()

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnChonhet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonhet.Click
        Dim i As Integer
        For i = 0 To gvDaychuyen.Rows.Count - 1
            gvDaychuyen.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        Dim i As Integer
        For i = 0 To gvDaychuyen.Rows.Count - 1
            gvDaychuyen.Rows(i).Cells(0).Value = False
        Next
    End Sub
End Class