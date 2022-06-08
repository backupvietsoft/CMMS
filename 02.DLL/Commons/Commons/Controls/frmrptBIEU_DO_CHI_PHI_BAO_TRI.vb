Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptBIEU_DO_CHI_PHI_BAO_TRI
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptBIEU_DO_CHI_PHI_BAO_TRI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("MAY_NHA_XUONG_TMP")
        Commons.Modules.ObjSystems.XoaTable("CONG_VIEC_HANG_NGAY_NX_TMP")
        Commons.Modules.ObjSystems.XoaTable("CHI_PHI_BAO_TRI_BIEU_DO_TMP")
    End Sub
    Private Sub frmrptBIEU_DO_CHI_PHI_BAO_TRI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddYears(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        loadNhaXuong()
    End Sub


    Sub loadNhaXuong()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cbxNhaxuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaxuong.ValueMember = "MS_N_XUONG"
        cbxNhaxuong.DataSource = _table
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception

            e.Cancel = True
        End Try
        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "TNPhaiNhoHonDN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "DenNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "DNPhaiLonHonTN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If
            Dim snx As String = cbxNhaxuong.Text
            Dim tenDB As New DataTable()
            tenDB.Columns.Add("TenNX")
            tenDB.Rows.Add(snx)
            tenDB.TableName = "NAME"
            Dim vtbData As New DataTable()
            v_all = New DataTable()
            vtbData = Get_DataTable(cbxNhaxuong.SelectedValue.ToString(), vTuNgay, vDenNgay, "-1", "-1", "-1")
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptBIEU_DO_CHI_PHI_BAO_TRI"
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.AddDataTableSource(tenDB)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_BAO_TRI", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
        End Try
    End Sub
#Region "Nhu Y"
   
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable()
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_CHI_PHI_BAO_TRI_BIEU_DO_NEW]", tungay, denngay))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_XUONG_FINAL"), tungay, denngay)
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
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_CHI_PHI_BAO_TRI_BIEU_DO_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable()
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay)
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
            _ms_may = "MS_MAY_FINAL<>'' and MS_MAY_FINAL <> ' ' and MS_MAY_FINAL is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region

  

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
