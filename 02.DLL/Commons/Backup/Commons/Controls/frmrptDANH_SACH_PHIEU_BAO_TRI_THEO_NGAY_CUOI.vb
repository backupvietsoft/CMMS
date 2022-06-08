
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI
    Dim v_all As DataTable = New DataTable()
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        Dim frmRepot As frmXMLReport = New frmXMLReport()
        frmRepot.rptName = "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI"
        frmRepot.AddDataTableSource(RefeshLanguage())
        v_all = New DataTable()
        Dim vtbData As New DataTable()
        ' vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI", cbxNhaXuong.SelectedValue.ToString))
        vtbData = Get_DataTable(cbxNhaXuong.SelectedValue.ToString(), "-1", "-1", "-1")
        If vtbData.Rows.Count > 0 Then
            ' vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI", cbxNhaXuong.SelectedValue.ToString))
            vtbData.TableName = "DATA_INFO"
            frmRepot.AddDataTableSource(vtbData)
            frmRepot.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "KoCoDuLieuDeIn", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End If

    End Sub

    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 9
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(2).ColumnName = "LOAI_TB"
        vtbTitle.Columns(3).ColumnName = "NHOM_TB"
        vtbTitle.Columns(4).ColumnName = "STT"
        vtbTitle.Columns(5).ColumnName = "THIET_BI"
        vtbTitle.Columns(6).ColumnName = "NGAY_CUOI"
        vtbTitle.Columns(7).ColumnName = "MS_PHIEU_BT"
        vtbTitle.Columns(8).ColumnName = "LOAI_BT"
        vtbTitle.Columns(9).ColumnName = "LY_DO"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "DIA_DIEM", commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LOAI_TB", commons.Modules.TypeLanguage)
        vRowTitle("NHOM_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "NHOM_TB", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "STT", commons.Modules.TypeLanguage)
        vRowTitle("THIET_BI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "THIET_BI", commons.Modules.TypeLanguage)
        vRowTitle("NGAY_CUOI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "NGAY_CUOI", commons.Modules.TypeLanguage)
        vRowTitle("MS_PHIEU_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "MS_PHIEU_BT", commons.Modules.TypeLanguage)
        vRowTitle("LOAI_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LOAI_BT", commons.Modules.TypeLanguage)
        vRowTitle("LY_DO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LY_DO", commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function


    Sub LoadNhaXuong()
        'cbxNhaXuong.Value = "MS_N_XUONG"
        'cbxNhaXuong.Display = "TEN_N_XUONG"
        'cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        'cbxNhaXuong.Param = Commons.Modules.UserName
        'cbxNhaXuong.BindDataSource()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaXuong.ValueMember = "MS_N_XUONG"
        cbxNhaXuong.DataSource = _table
    End Sub

    Private Sub frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadNhaXuong()
    End Sub
#Region "Nhu Y"
    'Function Get_DataTable(ByVal MS_N_Xuong As String) As System.Data.DataTable
    '    If MS_N_Xuong <> "-1" Then
    '        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
    '        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI_NEW]", Commons.Modules.UserName, MS_N_Xuong, Commons.Modules.TypeLanguage))
    '        Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
    '        Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
    '        Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
    '        Dim temp As DataView = vDataParent
    '        If String.IsNullOrEmpty(nhom_may) Then
    '            For Each vr As DataRow In vDataParent.ToTable().Rows
    '                If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
    '                    Try
    '                        temp.Table.TableName = "test"
    '                        temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"))
    '                    Catch ex As Exception

    '                    End Try

    '                Else
    '                    Try
    '                        If (v_all.Rows.Count <= 0) Then
    '                            v_all = vDataParent.ToTable().Copy()
    '                            v_all.Clear()
    '                        End If
    '                        v_all.Rows.Add(vr.ItemArray)
    '                    Catch ex As Exception

    '                    End Try

    '                End If
    '            Next

    '            'v_all.Merge(temp.ToTable())

    '            Return v_all
    '        Else
    '            temp = vDataDetail
    '            Return temp.ToTable()
    '            'vDataParent.
    '        End If
    '    Else
    '        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
    '        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI_NEW]", Commons.Modules.UserName, MS_N_Xuong))
    '        Return objDataTable
    '    End If
    'End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        'Dim _table As System.Data.DataTable = New System.Data.DataTable
        '_table = Get_DataTable(MS_N_Xuong)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI_NEW]", Commons.Modules.UserName, MS_N_Xuong, Commons.Modules.TypeLanguage))

        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then
            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region
   
    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadNhaXuong()
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
