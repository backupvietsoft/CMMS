
Imports Microsoft.ApplicationBlocks.Data
Imports Commons

Public Class frmChonPhuTungThaySua
    Private _MS_PHIEU_BAO_TRI As String
    Private _MS_MAY As String
    Private _STT_EOR As Integer = -1
    Private MS_BO_PHAN As String = ""
    Private MS_CV As Integer = 0
    Private HANG_MUC_ID As Integer = 0
    Dim bCo1 As Boolean = False
    Dim bCoPT_Cha As Boolean = False
    Private bCo As Boolean = False
    Private bCo2 As Boolean = False
    Private bCo3 As Boolean = False
    Private bCoPT_VT As Boolean = False
    Private intRowCTTB As Integer = -1
    Private bCoPT_Con As Boolean = False
    Private bCoPT_KH As Boolean = False

    Public Property MS_PHIEU_BAO_TRI() As String
        Get
            Return _MS_PHIEU_BAO_TRI
        End Get
        Set(ByVal value As String)
            _MS_PHIEU_BAO_TRI = value
        End Set
    End Property

    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

    Public Property STT_EOR() As Integer
        Get
            Return _STT_EOR
        End Get
        Set(ByVal value As Integer)
            _STT_EOR = value
        End Set
    End Property
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub frmChonPhuTungcho_PBT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Dim str As String = ""
        Dim tb As New DataTable
        Try
            str = "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [dbo].[InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & "]" &
        " @MS_PHIEU_BAO_TRI NVARCHAR(30),@MS_CV INT,@MS_BO_PHAN NVARCHAR(50),@MS_PT NVARCHAR(255),@TEN_PT NVARCHAR(255),@SL_KH FLOAT,@MS_PT_CHA NVARCHAR(50),@MS_PT_NCC NVARCHAR(255),@MS_PT_CTY NVARCHAR(255),@SL_CUM FLOAT,@MS_VI_TRI_PT NVARCHAR(50) " &
        " AS INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,SL_TT,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,SL_CUM,MS_VI_TRI_PT) " &
        " VALUES(@MS_PHIEU_BAO_TRI,@MS_CV,@MS_BO_PHAN,@MS_PT,@TEN_PT,@SL_KH,@SL_KH,@MS_PT_CHA,@MS_PT_NCC,@MS_PT_CTY,@SL_CUM,@MS_VI_TRI_PT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = "SELECT DISTINCT MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,HANG_MUC_ID FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)


        Try
            grdDSCongViec.DataSource = Nothing
            grvDSCongViec.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim dt As New DataTable
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCongViec, grvDSCongViec, tb, False, True, True, True, True, "")
        grvDSCongViec.Columns("MS_CV").Visible = False
        grvDSCongViec.Columns("MS_BO_PHAN").Visible = False
        grvDSCongViec.Columns("HANG_MUC_ID").Visible = False

    End Sub

    Private Sub btnThoat_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat_3.Click
        Me.Close()
    End Sub

    Sub ShowData()
        LoadCauTrucThietBi()
    End Sub
    Sub LoadCauTrucThietBi()
        Dim str As String = ""
        Dim tb1 As New DataTable

        Try
            grdDSPhuTungCha.DataSource = Nothing
            grvDSPhuTungCha.Columns.Clear()
        Catch ex As Exception

        End Try
        Commons.Modules.SQLString = "0Load"
        Dim dt As New DataTable

        dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_CAU_TRUC_THIET_BI_PT_THUE_NGOAIs(Commons.Modules.TypeLanguage, MS_MAY, MS_BO_PHAN, Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV)
        dt.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPhuTungCha, grvDSPhuTungCha, dt, True, False, False, False, True, "")


        Commons.Modules.SQLString = ""


        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE  MS_CV='" & MS_CV & "' AND MS_BO_PHAN='" & MS_BO_PHAN & "' "
        tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb1.Rows.Count - 1
            For j As Integer = 0 To grvDSPhuTungCha.RowCount - 1
                If tb1.Rows(i).Item("MS_PT") = grvDSPhuTungCha.GetDataRow(j)("MS_PT") Then
                    grvDSPhuTungCha.SetRowCellValue(j, "CHON", True)
                    grvDSPhuTungCha.UpdateCurrentRow()
                    Exit For
                End If
            Next
        Next
        'grvDSPhuTungCha.Columns("MS_PT").Visible = False
        grvDSPhuTungCha.Columns("MS_PT_CHA").Visible = False
        grvDSPhuTungCha.Columns("MS_MAY").Visible = False
        grvDSPhuTungCha.Columns("TEN_LOAI_VT_TV").Visible = False
        grvDSPhuTungCha.Columns("MS_BO_PHAN").Visible = False
        grvDSPhuTungCha.Columns("MS_PT").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("TEN_PT").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("MS_PT_NCC").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("MS_PT_CTY").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("TEN_1").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("SL_KH").OptionsColumn.ReadOnly = True
        grvDSPhuTungCha.Columns("TEN_PT").Width = 166
        grvDSPhuTungCha.Columns("SL_KH").Width = 63
        grvDSPhuTungCha.Columns("MS_PT_NCC").Width = 150
        grvDSPhuTungCha.Columns("MS_PT_CTY").Width = 150
        grvDSPhuTungCha.Columns("TEN_1").Width = 70
        grvDSPhuTungCha.Columns("CHON").Width = 50

    End Sub


    Private Sub btnThucHien_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien_3.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub





    Sub BindDataPhuTung(ByVal intRow As Integer)

        Try
            grdDSPhuTungCon.DataSource = Nothing
            grvDSPhuTungCon.Columns.Clear()
        Catch ex As Exception

        End Try
        Commons.Modules.SQLString = "0Load"
        Dim dt As New DataTable

        dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs_ThueNgoai(Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, MS_BO_PHAN, MS_PHIEU_BAO_TRI, MS_CV)
        dt.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPhuTungCon, grvDSPhuTungCon, dt, True, False, False, False, True, "")


        Commons.Modules.SQLString = ""



        Dim tb1 As New DataTable
        Dim str As String = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE  MS_CV='" & MS_CV & "' AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_PT_CHA='Y' "
        tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb1.Rows.Count - 1
            For j As Integer = 0 To grvDSPhuTungCon.RowCount - 1
                If tb1.Rows(i).Item("MS_PT") = grvDSPhuTungCon.GetDataRow(j)("MS_PT") And tb1.Rows(i).Item("MS_VI_TRI_PT").ToString = grvDSPhuTungCon.GetDataRow(j)("MS_VI_TRI_PT") Then
                    grvDSPhuTungCon.SetRowCellValue(j, "CHON", True)
                    grvDSPhuTungCon.UpdateCurrentRow()
                    Exit For
                End If
            Next
        Next
        'grvDSPhuTungCon.Columns("MS_PT").Visible = False
        grvDSPhuTungCon.Columns("MS_PT_CHA").Visible = False
        grvDSPhuTungCon.Columns("TEN_LOAI_VT_TV").Visible = False

        grvDSPhuTungCon.Columns("MS_PT").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("MS_VI_TRI_PT").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("TEN_PT").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("MS_PT_NCC").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("MS_PT_CTY").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("TEN_1").OptionsColumn.ReadOnly = True
        grvDSPhuTungCon.Columns("SL_KH").OptionsColumn.ReadOnly = True

        grvDSPhuTungCon.Columns("TEN_PT").Width = 150
        grvDSPhuTungCon.Columns("SL_KH").Width = 63
        grvDSPhuTungCon.Columns("SL_KH").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        grvDSPhuTungCon.Columns("SL_KH").AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default

        grvDSPhuTungCon.Columns("MS_PT_NCC").Width = 150
        grvDSPhuTungCon.Columns("MS_PT_CTY").Width = 150
        grvDSPhuTungCon.Columns("TEN_1").Width = 70
        grvDSPhuTungCon.Columns("CHON").Width = 50
    End Sub





    Private Sub grvDSCongViec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDSCongViec.FocusedRowChanged

        MS_BO_PHAN = grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN")
        MS_CV = grvDSCongViec.GetFocusedRowCellValue("MS_CV")
        If IsDBNull(grvDSCongViec.GetFocusedRowCellValue("HANG_MUC_ID")) Then
            HANG_MUC_ID = 0
        Else
            HANG_MUC_ID = grvDSCongViec.GetFocusedRowCellValue("HANG_MUC_ID")
        End If

        ShowData()
        BindDataPhuTung(0)

    End Sub

    Private Sub grvDSPhuTungCha_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSPhuTungCha.CellValueChanged
        Dim str As String = ""
        If e.Column.FieldName = "CHON" Then
            If grvDSPhuTungCha.GetFocusedRowCellValue("CHON") Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN,
                 grvDSPhuTungCha.GetFocusedRowCellValue("MS_PT"), grvDSPhuTungCha.GetFocusedRowCellValue("TEN_PT"),
                 grvDSPhuTungCha.GetFocusedRowCellValue("SL_KH"), "N", grvDSPhuTungCha.GetFocusedRowCellValue("MS_PT_NCC"), grvDSPhuTungCha.GetFocusedRowCellValue("MS_PT_CTY"),
                 grvDSPhuTungCha.GetFocusedRowCellValue("SL_KH"), Nothing)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT_CHA='Y'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                BindDataPhuTung(e.RowHandle)
            ElseIf Not grvDSPhuTungCha.GetFocusedRowCellValue("CHON") Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grvDSPhuTungCha.GetFocusedRowCellValue("MS_PT") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub grvDSPhuTungCon_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSPhuTungCon.CellValueChanged
        Dim str As String = ""
        If e.Column.FieldName = "CHON" Then
            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grvDSPhuTungCon.GetFocusedRowCellValue("MS_PT") & "' AND MS_VI_TRI_PT ='" & grvDSPhuTungCon.GetFocusedRowCellValue("MS_VI_TRI_PT") & "' AND MS_PT_CHA='Y'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            If grvDSPhuTungCon.GetFocusedRowCellValue("CHON") Then

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN,
                  grvDSPhuTungCon.GetFocusedRowCellValue("MS_PT"), grvDSPhuTungCon.GetFocusedRowCellValue("TEN_PT"),
                  grvDSPhuTungCon.GetFocusedRowCellValue("SL_KH"), "Y", grvDSPhuTungCon.GetFocusedRowCellValue("MS_PT_NCC"), grvDSPhuTungCon.GetFocusedRowCellValue("MS_PT_CTY"),
                  grvDSPhuTungCon.GetFocusedRowCellValue("SL_KH"), grvDSPhuTungCon.GetFocusedRowCellValue("MS_VI_TRI_PT"))
            End If
        End If
    End Sub



    Private Sub txtGiatri_EditValueChanged(sender As Object, e As EventArgs) Handles txtGiatri.EditValueChanged
        Dim dt As New DataTable
        Try
            dt = CType(grdDSCongViec.DataSource, DataTable)
            dt.DefaultView.RowFilter = "MA_CV LIKE '%" & txtGiatri.Text.Trim & "%' OR TEN_BO_PHAN LIKE %'" & txtGiatri.Text.Trim & "%'"
            dt = dt.DefaultView.ToTable()
        Catch ex As Exception
            dt.DefaultView.RowFilter = ""
            dt = dt.DefaultView.ToTable()
        End Try
    End Sub
End Class
