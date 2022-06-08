Imports Microsoft.ApplicationBlocks.Data


Public Class frmDS_VT_PT_CS

    Public Shared vtbPT As DataTable = New DataTable()
    Public Shared vtbPT_Tem As DataTable = New DataTable()

    Private Sub structvPT()
    End Sub

    Private Sub SetValue()
       
        Try
            Dim vTbDDH_CT As DataTable = vtbPT.Copy()

            ' Nếu đã thêm vào trong chi tiết
            For Each vRowfrm As DataGridViewRow In gvListPhuTung.Rows
                gvListPhuTung.Rows(vRowfrm.Index).Cells("CHON").Value = 0
            Next
            If (vTbDDH_CT.Rows.Count > 0) Then


                For Each vRowfrm As DataGridViewRow In gvListPhuTung.Rows
                    Dim vStMs_PT As String = vRowfrm.Cells("MS_PT").Value

                    For Each vRow As DataRow In vTbDDH_CT.Rows
                        gvListPhuTung.EndEdit()
                        If (vStMs_PT = vRow("MS_PT")) Then

                            If (Not gvListPhuTung.Rows(vRowfrm.Index).Cells("CHON").Value) Then
                                If (gvListPhuTung.Item("CHON", vRowfrm.Index).Value = False) Then
                                    gvListPhuTung.Item("CHON", vRowfrm.Index).Value = True
                                    gvListPhuTung.Item("CHON", vRowfrm.Index).Selected = True
                                End If
                            End If
                        End If
                    Next
                Next
                'chưa có
            Else
                For Each vRowfrm As DataGridViewRow In gvListPhuTung.Rows
                    gvListPhuTung.Rows(vRowfrm.Index).Cells("CHON").Value() = False
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Load_Data()

        gvListPhuTung.AutoGenerateColumns = False

        Dim vtb As New DataTable()
        Dim sqlStr As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                    " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT "

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sqlStr))
        gvListPhuTung.DataSource = vtb

        gvListPhuTung.Columns("MS_PT").DataPropertyName = "MS_PT"
        gvListPhuTung.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        gvListPhuTung.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
        gvListPhuTung.Columns("TEN_1").DataPropertyName = "TEN_1"

        'Load dữ liệu Cbo
        'Dim tbLoaiVT As New DataTable() ' = clsMain1.GetLoaiVatTu()
        'tbLoaiVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_VT, TEN_LOAI_VT_TV FROM LOAI_VT "))

        cb_LoaiVT.Value = "MS_LOAI_VT"
        cb_LoaiVT.Display = "TEN_LOAI_VT_TV"
        cb_LoaiVT.StoreName = "H_GetLoaiVT_CS"
        cb_LoaiVT.BindDataSource()
        Try
            cb_LoaiVT.SelectedIndex = 0
        Catch ex As Exception
        End Try

        AddHandler cb_LoaiVT.SelectedIndexChanged, AddressOf Me.cb_LoaiVT_SelectedIndexChanged
        If vtbPT_Tem.Rows.Count = 0 Then
            Exit Sub
        Else
            SetValue()
        End If


    End Sub
    Private Sub frmDS_VT_PT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vtbPT_Tem = vtbPT.Copy()
        structvPT()
        Load_Data()
        ' SetValue()

    End Sub
    Private Sub cb_LoaiVT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cb_LoaiVT.SelectedValueChanged

        If Not cb_LoaiVT.SelectedValue.ToString().Equals("-1") Then
            Dim sqlStr As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                                        " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                                                        "WHERE  IC_PHU_TUNG.MS_LOAI_VT = '" & cb_LoaiVT.SelectedValue.ToString() & "'"
            Dim vtb As New DataTable()
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sqlStr))

            gvListPhuTung.DataSource = vtb
            gvListPhuTung.AutoGenerateColumns = False
            gvListPhuTung.Columns("MS_PT").DataPropertyName = "MS_PT"
            gvListPhuTung.Columns("TEN_PT").DataPropertyName = "TEN_PT"
            gvListPhuTung.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
            gvListPhuTung.Columns("TEN_1").DataPropertyName = "TEN_1"
            SetValue()
        Else
            Dim sqlStr1 As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                                                   " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT "
            Dim vtb1 As New DataTable()
            vtb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sqlStr1))

            gvListPhuTung.DataSource = vtb1
            gvListPhuTung.AutoGenerateColumns = False
            gvListPhuTung.Columns("MS_PT").DataPropertyName = "MS_PT"
            gvListPhuTung.Columns("TEN_PT").DataPropertyName = "TEN_PT"
            gvListPhuTung.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
            gvListPhuTung.Columns("TEN_1").DataPropertyName = "TEN_1"
            SetValue()
        End If
    End Sub

    Private Sub gvListPhuTung_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvListPhuTung.CellValueChanged
        Try

            Dim index As Integer
            Dim bl As Boolean
            For Each gvrow As DataGridViewRow In gvListPhuTung.Rows
                index = gvrow.Index
                bl = gvrow.Cells("CHON").Value
                If (bl = True) Then
                    Dim s As String = gvrow.Cells("MS_PT").Value
                    If (CheckedMS_PT(gvrow.Cells("MS_PT").Value) = False) Then
                        Dim ss As DataTable = vtbPT
                        vtbPT.Rows.Add(gvrow.Cells("MS_PT").Value, gvrow.Cells("TEN_PT").Value, 0, gvrow.Cells("TEN_1").Value, 0, "VND", 1, "", 0, 0, "")

                    End If
                Else
                    If (CheckedMS_PT(gvrow.Cells("MS_PT").Value) = True) Then
                        For Each rowTm As DataRow In vtbPT.Select("MS_PT ='" & gvrow.Cells("MS_PT").Value & "'")
                            vtbPT.Rows.Remove(rowTm)
                        Next

                    End If
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    ' Kiem tra Ma Vat tu da co trong danh sach hay chua ?
    Private Function CheckedMS_PT(ByVal vMa) As Boolean

        For Each gvRow As DataRow In vtbPT.Rows
            If (vMa = gvRow("MS_PT")) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub New()


        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub bt_Chon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Chon.Click
        Try
            For Each gvRowTem As DataRow In vtbPT_Tem.Rows
                For Each rowTm As DataRow In vtbPT.Select("MS_PT ='" & gvRowTem("MS_PT") & "'")
                    If (rowTm("MS_PT") <> "") Then
                        vtbPT.Rows.Remove(rowTm)
                        vtbPT.Rows.Add(gvRowTem("MS_PT"), gvRowTem("TEN_PT"), gvRowTem("SO_LUONG"), gvRowTem("DVT"), gvRowTem("DON_GIA"), gvRowTem("NGOAI_TE"), gvRowTem("TI_GIA"), gvRowTem("GHI_CHU"), gvRowTem("THANH_TIEN_NT"), gvRowTem("THANH_TIEN"), gvRowTem("MS_DDH"))
                        ' vtbPT.Rows.Add(gvRowTem("MS_PT"), " ", gvRowTem("NGOAI_TE"), gvRowTem("TI_GIA"), gvRowTem("SO_LUONG"), gvRowTem("DON_GIA"), gvRowTem("TEN_PT"), gvRowTem("DVT"))
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub bt_BoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_BoQua.Click
        vtbPT = vtbPT_Tem
        Me.Close()
    End Sub

    Private Sub txt_seach_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seach.Validated
        Try
            For Each dtr As DataGridViewRow In gvListPhuTung.Rows
                If txt_seach.Text = dtr.Cells("MS_PT").Value Then
                    gvListPhuTung.CurrentCell = gvListPhuTung.Rows(dtr.Index).Cells("MS_PT")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_seach_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_seach.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                For Each dtr As DataGridViewRow In gvListPhuTung.Rows
                    If txt_seach.Text = dtr.Cells("MS_PT").Value Then
                        gvListPhuTung.CurrentCell = gvListPhuTung.Rows(dtr.Index).Cells("MS_PT")
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class