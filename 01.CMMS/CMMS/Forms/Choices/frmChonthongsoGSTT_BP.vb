Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmChonthongsoGSTT_BP
    Dim _sMS_MAY As String
    Dim _MS_BO_PHAN As String
    Dim _LOAI_TS As Boolean
    Dim _ATTACHMENT As Boolean

    Private _dtThongso As DataTable
    Dim dtPT As DataTable
    Dim dtPTtmp As DataTable

    Public Property DtThongso() As DataTable
        Get
            Return _dtThongso
        End Get
        Set(ByVal value As DataTable)
            _dtThongso = value
        End Set
    End Property

    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property
    Public Property MS_BO_PHAN() As String
        Get
            Return _MS_BO_PHAN
        End Get
        Set(ByVal value As String)
            _MS_BO_PHAN = value
        End Set
    End Property
    Public Property LOAI_TS() As Boolean
        Get
            Return _LOAI_TS
        End Get
        Set(ByVal value As Boolean)
            _LOAI_TS = value
        End Set
    End Property
    Public Property ATTACHMENT() As Boolean
        Get
            Return _ATTACHMENT
        End Get
        Set(ByVal value As Boolean)
            _ATTACHMENT = value
        End Set
    End Property
    Public dtChonTS As DataTable
    Private Sub frmChonthongsoGSTT_BP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        Commons.Modules.SQLString = "0Load"
        cboBoPhan.Properties.DataSource = Nothing
        Dim tb As New DataTable()
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTT_MS_BP_GSTT_NGON_NGUs", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBoPhan, tb, "MS_BP_GSTT", "TEN_BP_GSTT", "")
        cboBoPhan.EditValue = "-1"
        Commons.Modules.SQLString = ""
        cboBoPhan_EditValueChanged(Nothing, Nothing)
    End Sub

    Sub ShowData()

        If cboBoPhan.Properties.DataSource Is Nothing Then Exit Sub


        dtPT = New DataTable()


        If cboBoPhan.EditValue = 0 Then
            dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Loc_All_THONG_SO_GSTTs", LOAI_TS, MS_MAY, MS_BO_PHAN, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Else
            dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Loc_THONG_SO_GSTT_BP", cboBoPhan.EditValue, MS_MAY, MS_BO_PHAN, Commons.Modules.UserName, LOAI_TS))
        End If

        Try
            grvTS.Columns.Clear()
            grdTS.DataSource = Nothing
        Catch ex As Exception
        End Try

        For Each col As DataColumn In dtPT.Columns
            col.ReadOnly = True
        Next
        dtPT.Columns("CHON").ReadOnly = False

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdTS, grvTS, dtPT, True, True, False, False, True, Name)

        Call FormatGrid()
        'grvTS.Columns("TEN_TS_GSTT").Width = 710
        'grvTS.Columns("TEN_BP_GSTT_TV").Width = 160
        Try
            For i As Integer = 0 To grvTS.RowCount - 1

                Dim str As String = "MS_TS_GSTT='" & grvTS.GetDataRow(i)("MS_TS_GSTT").ToString.Trim & "'"
                Dim r() As DataRow = _dtThongso.Select(str)
                If r.Length > 0 Then
                    grvTS.SetRowCellValue(i, "CHON", True)
                End If
            Next
        Catch ex As Exception
        End Try
        grvTS.Columns("CACH_THUC_HIEN").Visible = False
        grvTS.Columns("TIEU_CHUAN_KT").Visible = False
        grvTS.Columns("YEU_CAU_NS").Visible = False
        grvTS.Columns("YEU_CAU_DUNG_CU").Visible = False
        grvTS.Columns("DUONG_DAN").Visible = False

        grvTS.Columns("CHON").Width = 90
        grvTS.Columns("THOI_GIAN").Width = 90

        grvTS.Columns("TEN_TS_GSTT").BestFit()
        grvTS.Columns("TEN_BP_GSTT_TV").BestFit()
    End Sub '


    Sub FormatGrid()
        With grvTS
            .Columns("MS_TS_GSTT").Visible = False
            .Columns("CHON").Width = 100
            .Columns("TEN_DV_DO").Visible = False
            .Columns("CHON").MinWidth = 100
            .Columns("GHI_CHU").Visible = False
        End With
    End Sub

    Sub SelectAll()
        Dim i As Integer
        For i = 0 To grvTS.RowCount - 1
            grvTS.SetRowCellValue(i, "CHON", True)
            grvTS.UpdateCurrentRow()
        Next
    End Sub

    Sub DeSelectAll()
        Dim i As Integer
        For i = 0 To grvTS.RowCount - 1
            grvTS.SetRowCellValue(i, "CHON", False)
            grvTS.UpdateCurrentRow()
        Next
    End Sub


    Private Sub btnThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuchien.Click
        'Call UpdateDataTable()
        dtChonTS = CType(grdTS.DataSource, DataTable)
        dtChonTS.DefaultView.RowFilter = " CHON = true "
        dtChonTS = dtChonTS.DefaultView.ToTable()
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        Call SelectAll()
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        Call DeSelectAll()
    End Sub

    Dim thutu As Integer = -1
    Dim GiaTri As String = ""

    Private Sub txtGiatri_TextChanged(sender As Object, e As EventArgs) Handles txtGiatri.TextChanged
        Dim dtTmp As New DataTable
        Dim sDk As String = ""
        Try
            dtTmp = CType(grdTS.DataSource, DataTable)
            sDk = "TEN_TS_GSTT LIKE '%" & txtGiatri.Text & "%' "
            dtTmp.DefaultView.RowFilter = sDk

        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub cboBoPhan_EditValueChanged(sender As Object, e As EventArgs) Handles cboBoPhan.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        ShowData()
    End Sub

End Class