Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmChonNhanVienChoMayCongNhan
    Private dtDsCN As New DataTable
    Private dvDsCN As New DataView

#Region "Subs & Functions"
    Private Sub LoadData()
        commons.Modules.SQLString = "SELECT CONVERT(BIT,0) AS CHON, CN.MS_CONG_NHAN, CN.HO + ' ' + CN.TEN AS HO_TEN, T.TEN_TO, T.MS_TO1 AS MS_TO, TPB.MS_TO AS MS_TO_PB, TPB.MS_DON_VI " & _
            " FROM CONG_NHAN CN  INNER JOIN [TO]T ON CN.MS_TO=T.MS_TO1 " & _
            " INNER JOIN TO_PHONG_BAN TPB ON T.MS_TO=TPB.MS_TO ORDER BY CHON, CN.MS_CONG_NHAN, CN.TEN,CN.HO"
        dtDsCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        dtDsCN.Columns("CHON").ReadOnly = False
        dvDsCN = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvDsCN.RowFilter = ""
        grdDSNhanVien.DataSource = dvDsCN
        DinhDangLuoiNhanVien()
    End Sub
    Private Sub LocData()
        Dim sFilter As String = ""
        sFilter = "MS_CONG_NHAN LIKE '%" & txtMsCN.Text & "%'"

        If Not cboDonVi.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
            If Not cboDonVi.SelectedValue.ToString.Equals("-1") Then
                sFilter = sFilter & " AND MS_DON_VI = '" & cboDonVi.SelectedValue.ToString & "'"
            End If
        End If

        If Not cboDoi.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
            If Not cboDoi.SelectedValue.ToString.Equals("-1") Then
                sFilter = sFilter & " AND MS_TO_PB = " & cboDoi.SelectedValue.ToString
            End If
        End If

        If Not cboTo.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
            If Not cboTo.SelectedValue.ToString.Equals("-1") Then
                sFilter = sFilter & " AND MS_TO = " & cboTo.SelectedValue.ToString
            End If
        End If

        dvDsCN = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvDsCN.RowFilter = sFilter
        grdDSNhanVien.DataSource = dvDsCN
    End Sub
    Private Sub DinhDangLuoiNhanVien()
        With grdDSNhanVien
            .Columns("MS_DON_VI").Visible = False
            .Columns("MS_TO_PB").Visible = False
            .Columns("MS_TO").Visible = False

            .Columns("CHON").HeaderText = "Chọn"
            .Columns("MS_CONG_NHAN").HeaderText = "MS Nhân viên"
            .Columns("HO_TEN").HeaderText = "Họ và tên"
            .Columns("TEN_TO").HeaderText = "Tổ"
            .Columns("MS_CONG_NHAN").ReadOnly = True
            .Columns("HO_TEN").ReadOnly = True
            .Columns("TEN_TO").ReadOnly = True

            .Columns("CHON").Width = 40
            .Columns("MS_CONG_NHAN").Width = 173
            .Columns("HO_TEN").Width = 363
            .Columns("TEN_TO").Width = 93
        End With
    End Sub
    Private Sub LoadComboDonVi()
        Dim dtTmp As New DataTable
        commons.Modules.SQLString = "SELECT MS_DON_VI, TEN_DON_VI FROM DON_VI " & _
            " UNION SELECT '-1' as MS_DON_VI , ' < ALL > ' as TEN_DON_VI FROM DON_VI " & _
            " ORDER BY TEN_DON_VI"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        cboDonVi.DataSource = dtTmp
        cboDonVi.ValueMember = "MS_DON_VI"
        cboDonVi.DisplayMember = "TEN_DON_VI"
    End Sub
    Private Sub LoadComboToPhongBan()
        Dim dtTmp As New DataTable
        commons.Modules.SQLString = ""
        If Not cboDonVi.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
            If Not cboDonVi.SelectedValue.ToString.ToString.Equals("-1") Then
                commons.Modules.SQLString = "WHERE MS_DON_VI='" & cboDonVi.SelectedValue.ToString & "'"
            End If
        End If
        commons.Modules.SQLString = "SELECT MS_TO AS MS_TPB, TEN_TO FROM TO_PHONG_BAN " & commons.Modules.SQLString & _
            " UNION SELECT -1 , ' < ALL > ' FROM TO_PHONG_BAN " & _
            " ORDER BY TEN_TO"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        cboDoi.DataSource = dtTmp
        cboDoi.ValueMember = "MS_TPB"
        cboDoi.DisplayMember = "TEN_TO"
    End Sub
    Private Sub LoadComboTo()
        Dim dtTmp As New DataTable
        commons.Modules.SQLString = ""
        If Not cboDoi.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
            If Not cboDoi.SelectedValue.ToString.ToString.Equals("-1") Then
                commons.Modules.SQLString = "WHERE MS_TO=" & cboDoi.SelectedValue
            End If
        End If
        commons.Modules.SQLString = "SELECT MS_TO1 AS MS_TO, TEN_TO FROM [TO] " & commons.Modules.SQLString & _
            " UNION SELECT -1 , ' < ALL > ' FROM [TO] " & _
            "  ORDER BY TEN_TO "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        cboTo.DataSource = dtTmp
        cboTo.ValueMember = "MS_TO"
        cboTo.DisplayMember = "TEN_TO"
    End Sub
    Private Sub ThucHien()
        Dim sMsMay As String = ""
        Dim blnThem As Boolean = True
        dvDsCN = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvDsCN.RowFilter = "CHON=1"
        With frmPhanCongBaoTri
            sMsMay = .grdDSThietBi.CurrentRow.Cells("MS_MAY").Value
            For i As Integer = 0 To dvDsCN.Count - 1
                blnThem = True
                For j As Integer = 0 To .dvDsCN.Count - 1
                    If dvDsCN(i).Item("MS_CONG_NHAN") = .dvDsCN(j).Item("MS_CONG_NHAN") Then
                        blnThem = False
                        Exit For
                    End If
                Next

                If blnThem Then .dtDsCN.Rows.Add(dvDsCN(i).Item("MS_CONG_NHAN"), dvDsCN(i).Item("HO_TEN"), "", sMsMay, "A")
            Next

        End With
        Me.Dispose()
    End Sub
#End Region
#Region "Events"

#End Region

    Private Sub cboDonVi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDonVi.SelectedIndexChanged
        LoadComboToPhongBan()
    End Sub

    Private Sub cboDoi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoi.SelectedIndexChanged
        LoadComboTo()
    End Sub

    Private Sub cboTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTo.SelectedIndexChanged
        LocData()
    End Sub

    Private Sub frmChonNhanVienChoMayCongNhan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        LoadComboDonVi()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        

        Me.Dispose()
    End Sub

    Private Sub txtMsCN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMsCN.TextChanged
        LocData()
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        ThucHien()
    End Sub
End Class