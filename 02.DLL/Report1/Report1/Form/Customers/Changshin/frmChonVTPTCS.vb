
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data

Public Class frmChonVTPTCS

    Public vtbData As New DataTable
    Public vEventChon As String = ""
    Public VDonDH As String = ""

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        vEventChon = "OK"
        Me.Close()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        vEventChon = "Cancel"
        Me.Close()
    End Sub

    Private Sub frmChonVTPTCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        LoadLoaiTB()
        LoadLoaiPT()
        LoadLoaiVT()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        AddHandler Me.cbxLoaiVT.SelectedIndexChanged, AddressOf Me.cbxLoaiVT_SelectedIndexChanged
        AddHandler cbxNoiSuDung.SelectedIndexChanged, AddressOf Me.cbxNoiSuDung_SelectedIndexChanged
        AddHandler cbxLoaiTB.SelectedIndexChanged, AddressOf Me.cbxLoaiTB_SelectedIndexChanged
        LoadData()
    End Sub


    Sub LoadData()
        Try
            vtbData = New DataTable

            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_DON_DAT_HANG_SELECT_VTPT_CHON_TMP", cbxLoaiVT.SelectedValue, cbxNoiSuDung.SelectedValue, cbxLoaiTB.SelectedValue, Commons.Modules.UserName))
            grdDanhSachVTPT.DataSource = Nothing
            grdDanhSachVTPT.AutoGenerateColumns = False
            vtbData.Columns("CHON").ReadOnly = False
            grdDanhSachVTPT.DataSource = vtbData

            grdDanhSachVTPT.Columns("CHON").DataPropertyName = "CHON"
            grdDanhSachVTPT.Columns("MS_PT").DataPropertyName = "MS_PT"
            grdDanhSachVTPT.Columns("TEN_PT").DataPropertyName = "TEN_PT"
            grdDanhSachVTPT.Columns("DVT").DataPropertyName = "DVT"
            grdDanhSachVTPT.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"

        Catch ex As Exception
        End Try
    End Sub

    Sub LoadLoaiVT()
        cbxLoaiVT.Value = "MS_LOAI_VT"
        Select Case commons.Modules.TypeLanguage
            Case 0
                cbxLoaiVT.Display = "TEN_LOAI_VT_TV"
                Exit Select
            Case 1
                cbxLoaiVT.Display = "TEN_LOAI_VT_TA"
                Exit Select
            Case 2
                cbxLoaiVT.Display = "TEN_LOAI_VT_TH"
                Exit Select

        End Select
        cbxLoaiVT.StoreName = "QL_LOAD_LIST_LOAI_VAT_TU"
        cbxLoaiVT.BindDataSource()
    End Sub

    Sub LoadLoaiPT()
        cbxNoiSuDung.Value = "MS_LOAI_PT"
        cbxNoiSuDung.Display = "TEN_LOAI_PT"
        cbxNoiSuDung.StoreName = "QL_LOAD_LIST_LOAI_PHU_TUNG"
        cbxNoiSuDung.Param = Commons.Modules.UserName
        cbxNoiSuDung.BindDataSource()
    End Sub

    Sub LoadLoaiTB()
        cbxLoaiTB.Value = "MS_LOAI_MAY"
        cbxLoaiTB.Display = "TEN_LOAI_MAY"
        cbxLoaiTB.StoreName = "QL_LOAD_LIST_LOAI_MAY"
        cbxLoaiTB.Param = Commons.Modules.UserName
        cbxLoaiTB.BindDataSource()
    End Sub

    Private Sub cbxLoaiVT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxLoaiVT.SelectedIndexChanged

        LoadData()

    End Sub

    Private Sub cbxNoiSuDung_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxNoiSuDung.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub cbxLoaiTB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxLoaiTB.SelectedIndexChanged
        LoadData()
    End Sub


    Private Sub grdDanhSachVTPT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhSachVTPT.CellValidating

        If grdDanhSachVTPT.Columns(e.ColumnIndex).Name = "CHON" Then
            Dim cell As DataGridViewCell = grdDanhSachVTPT.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                If e.FormattedValue Then
                    Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(MS_PT) AS SL FROM dbo.CHON_VTPT_DON_DAT_HANG_CS_TMP" & Commons.Modules.UserName & " WHERE MS_PT = '" & grdDanhSachVTPT.Rows(e.RowIndex).Cells("MS_PT").Value & "'")
                    If CType(OBJ, Integer) = 0 Then

                        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPT" & Commons.Modules.UserName, grdDanhSachVTPT.Rows(e.RowIndex).Cells("MS_PT").Value, grdChonPT.Rows(e.RowIndex).Cells("TEN_PT").Value, grdChonPT.Rows(e.RowIndex).Cells("DVT").Value.ToString, grdDanhSachVTPT.Rows(e.RowIndex).Cells("SLTON").Value, grdDanhSachVTPT.Rows(e.RowIndex).Cells("TON_TOI_THIEU").Value, grdDanhSachVTPT.Rows(e.RowIndex).Cells("NGAY_CUOI").Value, vM)
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DON_DAT_HANG_INSERT_VTPT_CHON_TMP", grdDanhSachVTPT.Rows(e.RowIndex).Cells("MS_PT").Value, _
               grdDanhSachVTPT.Rows(e.RowIndex).Cells("TEN_PT").Value, 0, grdDanhSachVTPT.Rows(e.RowIndex).Cells("DVT").Value, 0, "VND", 1, 0, 0, "", VDonDH, Commons.Modules.UserName)

                    End If
                Else
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM    dbo.CHON_VTPT_DON_DAT_HANG_CS_TMP" & Commons.Modules.UserName & " WHERE MS_PT='" & grdDanhSachVTPT.Rows(e.RowIndex).Cells("MS_PT").Value & "'")
                End If
            End If
        End If

    End Sub
    Dim thutu As Integer = -1
    Dim GiaTri As String = ""
    Private Sub txtTimMa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimMa.KeyDown
        If e.KeyCode = 13 Then
            Dim i As Integer
            If GiaTri <> txtTimMa.Text.ToUpper.Trim Then
                GiaTri = txtTimMa.Text.ToUpper.Trim
                GoTo BatDau
            End If
            If thutu = -1 Then
BatDau:
                For i = 0 To grdDanhSachVTPT.RowCount - 1
                    If grdDanhSachVTPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimMa.Text.ToUpper.Trim) Or txtTimMa.Text.ToUpper.Trim.Contains(grdDanhSachVTPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
                        thutu = i
                        grdDanhSachVTPT.CurrentCell() = grdDanhSachVTPT.Rows(i).Cells("CHON")
                        txtTimMa.Focus()
                        Exit Sub
                    Else
                        grdDanhSachVTPT.Rows(i).Cells("CHON").Selected = False
                    End If
                Next
            Else
                For i = thutu + 1 To grdDanhSachVTPT.RowCount - 1
                    If grdDanhSachVTPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimMa.Text.ToUpper.Trim) Or txtTimMa.Text.ToUpper.Trim.Contains(grdDanhSachVTPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
                        thutu = i
                        grdDanhSachVTPT.CurrentCell() = grdDanhSachVTPT.Rows(i).Cells("CHON")
                        txtTimMa.Focus()
                        Exit Sub
                    Else
                        grdDanhSachVTPT.Rows(i).Cells("CHON").Selected = False
                    End If
                Next
                If i = grdDanhSachVTPT.Rows.Count Then
                    GoTo BatDau
                End If
            End If
        End If


    End Sub

    Private Sub txtTimTen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimTen.KeyDown

    End Sub

    Private Sub txtTimTen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimTen.KeyPress
        Try
            If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
                Dim i As Integer
                If GiaTri <> grdDanhSachVTPT.Text.ToUpper.Trim Then
                    GiaTri = txtTimTen.Text.ToUpper.Trim
                    GoTo BatDau
                End If
                If thutu = -1 Then
BatDau:
                    For i = 0 To grdDanhSachVTPT.RowCount - 1

                        If String.Compare(txtTimTen.Text.ToUpper.Trim, 0, grdDanhSachVTPT.Rows(i).Cells("TEN_PT").Value.ToString, 0, txtTimTen.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdDanhSachVTPT.CurrentCell() = grdDanhSachVTPT.Rows(i).Cells("MS_PT")
                            grdDanhSachVTPT.Rows(i).Selected = True
                            txtTimTen.Focus()
                            Exit Sub
                        End If
                    Next
                Else
                    For i = 0 To grdDanhSachVTPT.RowCount - 1

                        If String.Compare(txtTimTen.Text.ToUpper.Trim, 0, grdDanhSachVTPT.Rows(i).Cells("TEN_PT").Value.ToString, 0, txtTimTen.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdDanhSachVTPT.CurrentCell() = grdDanhSachVTPT.Rows(i).Cells("MS_PT")
                            grdDanhSachVTPT.Rows(i).Selected = True
                            txtTimTen.Focus()
                            Exit Sub
                        End If
                    Next

                    If i = grdDanhSachVTPT.Rows.Count Then
                        GoTo BatDau
                    End If
                End If

            End If
        Catch ex As Exception
        End Try

    End Sub
End Class