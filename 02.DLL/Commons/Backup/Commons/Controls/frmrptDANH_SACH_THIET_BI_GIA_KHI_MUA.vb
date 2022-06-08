Imports Microsoft.ApplicationBlocks.Data


Public Class frmrptDANH_SACH_THIET_BI_GIA_KHI_MUA
    Dim v_all As DataTable = New DataTable()
    Private Sub frmrptDANH_SACH_THIET_BI_GIA_KHI_MUA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadNhaXuong()
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        Dim frmRepot As frmXMLReport = New frmXMLReport()
        frmRepot.rptName = "rptDANH_SACH_THIET_BI_GIA_KHI_MUA"
        frmRepot.AddDataTableSource(RefeshLanguage())
        Dim vtbData As New DataTable()
        'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DANH_SACH_THIET_BI_GIA_TRI_KHI_MUA", cbxNhaxuong.SelectedValue.ToString))
        v_all = New DataTable()
        vtbData = Get_DataTable(cbxNhaxuong.SelectedValue.ToString(), "-1", "-1", "-1")
        If vtbData.Rows.Count > 0 Then
            vtbData.TableName = "DATA_INFO"
            frmRepot.AddDataTableSource(vtbData)
            frmRepot.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End If
    End Sub

    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 7
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(2).ColumnName = "MS_TB"
        vtbTitle.Columns(3).ColumnName = "TEN_TB"
        vtbTitle.Columns(4).ColumnName = "STT"
        vtbTitle.Columns(5).ColumnName = "LOAI_TB"
        vtbTitle.Columns(6).ColumnName = "NHOM_TB"
        vtbTitle.Columns(7).ColumnName = "GIATRI"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "DIA_DIEM", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "LOAI_TB", Commons.Modules.TypeLanguage)
        vRowTitle("NHOM_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "NHOM_TB", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "MS_TB", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "TEN_TB", Commons.Modules.TypeLanguage)
        vRowTitle("GIATRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_THIET_BI_GIA_KHI_MUA", "GIATRI", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Sub LoadNhaXuong()
        'cbxNhaxuong.Value = "MS_N_XUONG"
        'cbxNhaxuong.Display = "TEN_N_XUONG"
        'cbxNhaxuong.StoreName = "GetNHA_XUONGs"
        'cbxNhaxuong.Param = Commons.Modules.UserName
        'cbxNhaxuong.BindDataSource()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cbxNhaxuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaxuong.ValueMember = "MS_N_XUONG"
        cbxNhaxuong.DataSource = _table

    End Sub
   
    Function Get_DataTable(ByVal MS_N_Xuong As String) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DANH_SACH_THIET_BI_GIA_TRI_KHI_MUA_NEW]"))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"))
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If

                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DANH_SACH_THIET_BI_GIA_TRI_KHI_MUA_NEW]"))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong)
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
  
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
