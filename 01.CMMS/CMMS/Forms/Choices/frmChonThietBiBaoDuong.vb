
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmChonThietBiBaoDuong

    Private _TBThietBi As New DataTable

    Public Property TBThietBi() As DataTable
        Get
            Return _TBThietBi
        End Get
        Set(ByVal value As DataTable)
            _TBThietBi = value
        End Set
    End Property

    Private Sub frmChonThietBiBaoDuong_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Bind_cboLoaiTB()
        BindData()
    End Sub

    Sub Bind_cboLoaiTB()
        cboLoaiTB.DataSource = Nothing
        cboLoaiTB.Display = "TEN_LOAI_MAY"
        cboLoaiTB.Value = "MS_LOAI_MAY"
        cboLoaiTB.DropDownWidth = 200
        cboLoaiTB.Param = Commons.Modules.UserName
        cboLoaiTB.StoreName = "PermisionLOAI_MAY"
        cboLoaiTB.BindDataSource()
        If cboLoaiTB.Items.Count = 0 Then
            cboLoaiTB.Text = ""
        End If
    End Sub

    Sub BindData()
        Dim col1 As New DataGridViewTextBoxColumn
        grdDanhsacthietbi.Columns.Clear()
        grdDanhsacthietbi.DataSource = Nothing
        col1.DataPropertyName = "MS_MAY"
        col1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
        col1.Name = "MS_MAY"
        col1.Width = 400
        col1.ReadOnly = True
        grdDanhsacthietbi.Columns.Add(col1)
        Dim col2 As New DataGridViewCheckBoxColumn
        col2.Name = "CHON"
        col2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
        col2.Width = 130
        grdDanhsacthietbi.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        col3.Name = "NOI_DUNG"
        col3.HeaderText = "NOI_DUNG"
        col3.Visible = False
        grdDanhsacthietbi.Columns.Add(col3)
        Dim col4 As New DataGridViewTextBoxColumn
        col4.Name = "CHI_PHI_NC"
        col4.HeaderText = "CHI_PHI_NC"
        col4.Visible = False
        grdDanhsacthietbi.Columns.Add(col4)
        Dim col5 As New DataGridViewTextBoxColumn
        col5.Name = "CHI_PHI_VT"
        col5.HeaderText = "CHI_PHI_VT"
        col5.Visible = False
        grdDanhsacthietbi.Columns.Add(col5)


        grdDanhsacthietbi.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetMAY_BD", Commons.Modules.UserName, cboLoaiTB.SelectedValue).Tables(0)
        For i As Integer = 0 To TBThietBi.Rows.Count - 1
            For j As Integer = 0 To grdDanhsacthietbi.Rows.Count - 1
                If TBThietBi.Rows(i).Item("MS_MAY") = grdDanhsacthietbi.Rows(j).Cells("MS_MAY").Value Then
                    grdDanhsacthietbi.Rows(j).Cells("CHON").Value = True
                    grdDanhsacthietbi.Rows(j).Cells("NOI_DUNG").Value = TBThietBi.Rows(i).Item("NOI_DUNG")
                    grdDanhsacthietbi.Rows(j).Cells("CHI_PHI_NC").Value = TBThietBi.Rows(i).Item("CHI_PHI_NC")
                    grdDanhsacthietbi.Rows(j).Cells("CHI_PHI_VT").Value = TBThietBi.Rows(i).Item("CHI_PHI_VT")
                    Exit For
                End If
            Next
        Next
        Try
            Me.grdDanhsacthietbi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsacthietbi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnThuchien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThuchien.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cboLoaiTB_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiTB.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub grdDanhsacthietbi_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsacthietbi.CellValidating
        Try
            If grdDanhsacthietbi.Columns(e.ColumnIndex).Name = "CHON" Then
                grdDanhsacthietbi.EndEdit()
                If (Convert.ToBoolean(grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHON").Value)) Then
                    For i As Integer = 0 To _TBThietBi.Rows.Count - 1
                        If _TBThietBi.Rows(i).Item("MS_MAY") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("MS_MAY").Value Then
                            _TBThietBi.Rows(i).Item("NOI_DUNG") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("NOI_DUNG").Value
                            If (Not grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_NC").Value Is Nothing) Then
                                _TBThietBi.Rows(i).Item("CHI_PHI_NC") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_NC").Value
                            Else
                                _TBThietBi.Rows(i).Item("CHI_PHI_NC") = System.DBNull.Value
                            End If
                            If Not grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_VT").Value Is Nothing Then
                                _TBThietBi.Rows(i).Item("CHI_PHI_VT") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_VT").Value
                            Else
                                _TBThietBi.Rows(i).Item("CHI_PHI_VT") = System.DBNull.Value
                            End If
                            Exit Sub
                        End If
                    Next
                    Dim rCongnhan As DataRow = _TBThietBi.NewRow()
                    rCongnhan("MS_MAY") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("MS_MAY").Value
                    rCongnhan("NOI_DUNG") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("NOI_DUNG").Value
                    If (Not grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_NC").Value Is Nothing) Then
                        rCongnhan("CHI_PHI_NC") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_NC").Value
                    Else
                        rCongnhan("CHI_PHI_NC") = System.DBNull.Value
                    End If
                    If Not grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_VT").Value Is Nothing Then
                        rCongnhan("CHI_PHI_VT") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("CHI_PHI_VT").Value
                    Else
                        rCongnhan("CHI_PHI_VT") = System.DBNull.Value
                    End If


                    _TBThietBi.Rows.Add(rCongnhan)
                Else
                    For i As Integer = 0 To _TBThietBi.Rows.Count - 1
                        If _TBThietBi.Rows(i).Item("MS_MAY") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("MS_MAY").Value Then
                            _TBThietBi.Rows.Remove(TBThietBi.Rows(i))
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            For i As Integer = 0 To _TBThietBi.Rows.Count - 1
                If _TBThietBi.Rows(i).Item("MS_MAY") = grdDanhsacthietbi.Rows(e.RowIndex).Cells("MS_MAY").Value Then
                    _TBThietBi.Rows.Remove(TBThietBi.Rows(i))
                    Exit Sub
                End If
            Next
        End Try
    End Sub
End Class