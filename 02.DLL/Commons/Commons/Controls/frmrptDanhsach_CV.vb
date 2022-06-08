Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptDanhsach_CV
    Private SqlText As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        PrintCongViec()
    End Sub


    Sub Bind_cboLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)
        cboLoaiTB.DataSource = dt
        cboLoaiTB.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB.ValueMember = "MS_LOAI_MAY"
    End Sub
    Sub Bind_cboLoaiCV()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_CV", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)
        cboLoaiCV.DataSource = dt
        cboLoaiCV.DisplayMember = "TEN_LOAI_CV"
        cboLoaiCV.ValueMember = "MS_LOAI_CV"
    End Sub

    Sub PrintCongViec()
        Try
            Dim vtbData As New DataTable()
            vtbData = GetDataCongViec()
            vtbData.TableName = "rptDANH_SACH_CV"

            If vtbData.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDanhsach_CV"
                frmRepot.AddDataTableSource(RefeshLanguageCongViec())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try


        Cursor = Cursors.Default

    End Sub

    Private Sub frmrptDanhsach_CV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind_cboLoaiTB()
        Bind_cboLoaiCV()
    End Sub

    Function RefeshLanguageCongViec() As DataTable
        Dim tieude, stt, Loaithietbi, loaicongviec, motacv, chuyenmon, taynghe, thoigianchuan, trang As String

        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "Loaithietbi", Commons.Modules.TypeLanguage)
        loaicongviec = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "loaicongviec", Commons.Modules.TypeLanguage)
        motacv = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "motacv", Commons.Modules.TypeLanguage)
        chuyenmon = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "chuyenmon", Commons.Modules.TypeLanguage)
        taynghe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "taynghe", Commons.Modules.TypeLanguage)
        thoigianchuan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "thoigianchuan", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "trang", Commons.Modules.TypeLanguage)

        Dim vtb As New DataTable("rptDANH_SACH_CV_TMP")

        vtb.Columns.Add("TIEUDE_", Type.GetType("System.String"))
        vtb.Columns.Add("STT_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_TB_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_CV_", Type.GetType("System.String"))
        vtb.Columns.Add("MO_TA_CV_", Type.GetType("System.String"))
        vtb.Columns.Add("CHUYEN_MON_", Type.GetType("System.String"))
        vtb.Columns.Add("TAY_NGHE_", Type.GetType("System.String"))
        vtb.Columns.Add("THOI_GIAN_CHUAN_", Type.GetType("System.String"))
        vtb.Columns.Add("TRANG_", Type.GetType("System.String"))


        Dim vrow As DataRow = vtb.NewRow()
        vrow("TIEUDE_") = tieude
        vrow("STT_") = stt
        vrow("LOAI_TB_") = Loaithietbi
        vrow("LOAI_CV_") = loaicongviec
        vrow("MO_TA_CV_") = motacv
        vrow("CHUYEN_MON_") = chuyenmon
        vrow("TAY_NGHE_") = taynghe
        vrow("THOI_GIAN_CHUAN_") = thoigianchuan
        vrow("TRANG_") = trang

        vtb.Rows.Add(vrow)
        Return vtb

    End Function

    Function GetDataCongViec() As DataTable

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," &
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " &
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " &
                "LEFT OUTER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " &
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " &
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO "
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," &
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " &
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " &
                "LEFT OUTER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " &
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " &
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " &
                "WHERE CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        Else
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," &
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " &
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " &
                "LEFT OUTER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " &
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " &
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " &
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," &
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " &
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " &
                "LEFT OUTER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " &
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " &
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " &
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        End If
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Dim vtb As New DataTable()
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Return vtb
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
