Imports Microsoft.ApplicationBlocks.Data


Public Class frmDanhSach_CV
    Dim sbt As String = "TEMPT" + Commons.Modules.UserName
    Dim sbtAll As String = "TEMPTALL" + Commons.Modules.UserName
    Dim sbtcv = "TMPCHONCV" + Commons.Modules.UserName
    'load form
    Private Function loadtableall() As DataTable
        Dim sSql As String = "SELECT DISTINCT CAST(1 AS BIT) AS CHON,T2.MS_TS_GSTT,MS_BO_PHAN,T2.MS_CV,T3.MO_TA_CV FROM " + sbt + " T1 INNER JOIN dbo.GSTT_CV T2 ON T2.MS_TS_GSTT = T1.MS_TS_GSTT INNER JOIN  dbo.CONG_VIEC T3 ON T3.MS_CV = T2.MS_CV WHERE CHON =1 UNION SELECT DISTINCT CAST(0 AS BIT) AS CHON,A.MS_TS_GSTT,A.MS_BO_PHAN,B.MS_CV,C.MO_TA_CV FROM   " + sbt + " A INNER JOIN  dbo.CAU_TRUC_THIET_BI_CONG_VIEC B ON B.MS_MAY = A.MS_MAY AND B.MS_BO_PHAN = A.MS_BO_PHAN INNER JOIN dbo.CONG_VIEC C ON C.MS_CV = B.MS_CV WHERE CHON = 1"
        Dim tempt As New DataTable
        tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Return tempt
    End Function
    Private Sub CreateBangTamAll()
        Try
            Commons.Modules.ObjSystems.XoaTable(sbtAll)
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sbtAll, loadtableall(), "")
    End Sub

    Private Sub frmDanhSach_CV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateBangTamAll()
        LoadGrdthongso()
        LoadGrdcongviec()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    'Load grid thông số
    Private Sub LoadGrdthongso()
        Dim tempt As New DataTable
        Dim sSql As String = "SELECT DISTINCT MS_MAY,MS_BO_PHAN,TEN_BO_PHAN,MS_TS_GSTT,TEN_TS_GSTT  FROM " + sbt + " WHERE CHON = 1 ORDER BY TEN_BO_PHAN,TEN_TS_GSTT"
        tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Commons.Modules.ObjSystems.MLoadXtraGrid(Grdthongso, Grvthongso, tempt, False, True, True, True, True, "")
        Grvthongso.Columns("MS_BO_PHAN").Visible = False
        Grvthongso.Columns("MS_TS_GSTT").Visible = False
        Grvthongso.Columns("MS_MAY").Visible = False
    End Sub
    'load grid công viêc
    Private Sub LoadGrdcongviec()
        Try
            Dim tempt As New DataTable
            Dim sSql As String = "SELECT * FROM " + sbtAll + " WHERE MS_TS_GSTT = " + Grvthongso.GetFocusedRowCellValue("MS_TS_GSTT") + " AND MS_BO_PHAN = '" + Grvthongso.GetFocusedRowCellValue("MS_BO_PHAN") + "' ORDER BY MO_TA_CV"

            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            tempt.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(Grdcongviec, Grvcongviec, tempt, True, False, False, False, True, "")
            For index = 1 To tempt.Columns.Count - 1
                tempt.Columns(index).ReadOnly = True
            Next
            Grvcongviec.Columns("CHON").Width = 90
            Grvcongviec.Columns("MO_TA_CV").Width = 385
            Grvcongviec.Columns("MS_BO_PHAN").Visible = False
            Grvcongviec.Columns("MS_TS_GSTT").Visible = False
            Grvcongviec.Columns("MS_CV").Visible = False
        Catch ex As Exception
        End Try
    End Sub
    'sự kiện button ghi
    Private Sub btnGhi_Click(sender As Object, e As EventArgs) Handles btnThucHien.Click
        'Dim tempt As DataTable = CType(Grdcongviec.DataSource, DataTable)
        'tabCV = tempt.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("CHON").Equals(True)).CopyToDataTable()
        Try
            Commons.Modules.ObjSystems.XoaTable(sbtcv)
        Catch ex As Exception

        End Try
        DialogResult = DialogResult.Yes
    End Sub

    'sự kiện botton thoát
    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Try
            Commons.Modules.ObjSystems.XoaTable(sbtcv)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & sbtAll & "")
        Catch ex As Exception
        End Try
        Me.Close()
        DialogResult = DialogResult.No
    End Sub

    Private Sub Grvthongso_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Grvthongso.FocusedRowChanged
        LoadGrdcongviec()
    End Sub

    Private Sub btnChon_Click(sender As Object, e As EventArgs) Handles btnAllGSTT.Click
        Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", Grvcongviec)
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE " + sbtAll + " SET CHON = 1 WHERE MS_TS_GSTT ='" + Grvthongso.GetFocusedRowCellValue("MS_TS_GSTT") + "' AND MS_BO_PHAN = '" + Grvthongso.GetFocusedRowCellValue("MS_BO_PHAN") + "'")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUnSelect_Click(sender As Object, e As EventArgs) Handles btnNotAllGSTT.Click
        Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", Grvcongviec)
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE " + sbtAll + " SET CHON = 0 WHERE MS_TS_GSTT ='" + Grvthongso.GetFocusedRowCellValue("MS_TS_GSTT") + "' AND MS_BO_PHAN = '" + Grvthongso.GetFocusedRowCellValue("MS_BO_PHAN") + "'")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CreateTableChonCV(ByVal tempt As DataTable)
        Try
            Commons.Modules.ObjSystems.XoaTable(sbtcv)
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sbtcv, tempt, "")
    End Sub

    Private Sub BtnChonCongViec_Click(sender As Object, e As EventArgs) Handles BtnChonCongViec.Click
        Dim frm As New FrmChonCongViecBoPhan
        frm.MS_MAY = Grvthongso.GetFocusedRowCellValue("MS_MAY")
        frm.MS_BO_PHAN = Grvthongso.GetFocusedRowCellValue("MS_BO_PHAN")
        frm.MS_LOAI_MAY = "-1"
        frm.dtTableTam = New DataTable()
        frm.ShowDialog()
        frm.dtTableTam.DefaultView.RowFilter = "CHON = TRUE"
        frm.dtTableTam = frm.dtTableTam.DefaultView.ToTable(True, "CHON", "MS_CV", "MO_TA_CV")
        CreateTableChonCV(frm.dtTableTam)
        Dim sSql = "INSERT INTO dbo.TEMPTALLadmin( CHON ,MS_TS_GSTT ,MS_BO_PHAN ,MS_CV ,MO_TA_CV)(SELECT T1.CHON,T1.MS_TS_GSTT,T1.MS_BO_PHAN,T1.MS_CV,T1.MO_TA_CV FROM (SELECT CHON,'" & Grvthongso.GetFocusedRowCellValue("MS_TS_GSTT") & "' AS MS_TS_GSTT,'" & Grvthongso.GetFocusedRowCellValue("MS_BO_PHAN") & "' AS MS_BO_PHAN,MS_CV,MO_TA_CV FROM TMPCHONCVAdmin) T1 WHERE NOT EXISTS (SELECT * FROM TEMPTALLadmin T2 WHERE T1.MS_TS_GSTT = T2.MS_TS_GSTT AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_CV = T2.MS_CV))"
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            LoadGrdcongviec()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Grvcongviec_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles Grvcongviec.ValidateRow
        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If grv.FocusedColumn.FieldName.ToUpper() = "CHON" Then
            Dim sSql As String = "UPDATE TEMPTALLadmin SET CHON = " & IIf(Convert.ToBoolean(Grvcongviec.GetFocusedRowCellValue("CHON")) = True, 1, 0) & " WHERE MS_TS_GSTT = '" & Grvcongviec.GetFocusedRowCellValue("MS_TS_GSTT").ToString() & "' AND MS_BO_PHAN ='" & Grvcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString() & "' AND MS_CV = " & Grvcongviec.GetFocusedRowCellValue("MS_CV")
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txt_TKThongSo_TextChanged(sender As Object, e As EventArgs) Handles txt_TKThongSo.TextChanged
        Dim dt As New DataTable()
        dt = CType(Grdthongso.DataSource, DataTable)
        Try
            dt.DefaultView.RowFilter = " TEN_TS_GSTT like '%" + txt_TKThongSo.Text + "%' OR TEN_BO_PHAN like '%" + txt_TKThongSo.Text + "%' "
        Catch ex As Exception
            dt.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub txt_TKCongViec_TextChanged(sender As Object, e As EventArgs) Handles txt_TKCongViec.TextChanged
        Dim dt As New DataTable()
        dt = CType(Grdcongviec.DataSource, DataTable)
        Try
            dt.DefaultView.RowFilter = "MO_TA_CV like '%" + txt_TKCongViec.Text + "%'"
        Catch ex As Exception
            dt.DefaultView.RowFilter = ""
        End Try
    End Sub
End Class