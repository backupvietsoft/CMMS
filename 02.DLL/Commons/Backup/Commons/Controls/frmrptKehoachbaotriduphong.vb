Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptKehoachbaotriduphong
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptKehoachbaotriduphong_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("TMP_KHBTDK")
    End Sub

    Private Sub frmrptKehoachbaotriduphong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTN.Value = (SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT GETDATE()")).ToString()
        dtpDN.Value = "01/12/" + dtpTN.Value.Year.ToString()
        cboTrangthai.SelectedIndex = 2
        LoadNhaXuong()
    End Sub
    Private Sub LoadNhaXuong()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cboNhaxuong.DisplayMember = "TEN_N_XUONG"
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DataSource = _table
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If cboTrangthai.SelectedIndex >= 0 And dtpTN.Text.Trim <> "/  /" Then
            If dtpDN.Value.Year <> dtpTN.Value.Year Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "DenThangphaicungnam", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpDN.Focus()
                Exit Sub
            End If

            If dtpTN.Value.Month > dtpDN.Value.Month And dtpDN.Value.Year = dtpTN.Value.Year Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "Tuthangphainhohondenthang", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpTN.Focus()
                Exit Sub
            End If
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim TbSource As New DataTable()
            Dim antoan As String = cboTrangthai.SelectedIndex
            Try

                v_all = New DataTable()
                TbSource = Get_DataTable(cboNhaxuong.SelectedValue.ToString(), Convert.ToDateTime(dtpTN.Value), Convert.ToDateTime(dtpDN.Value), cboTrangthai.SelectedIndex, "-1", "-1", "-1")
                If TbSource.Rows.Count <= 0 Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "msgKhongcogiatridein", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            TbSource.TableName = "rptKehoachbaotriduphong"

            Dim frmRptView As New frmXMLReport()
            frmRptView.rptName = "rptKehoachbaotriduphong"
            frmRptView.AddDataTableSource(TbSource)

            Dim TbTieuDe As New DataTable()
            TbTieuDe.Columns.Add("TIEU_DE")
            TbTieuDe.Columns.Add("TIEU_DE1")
            TbTieuDe.Columns.Add("TIEU_DE2")
            TbTieuDe.Columns.Add("MASO")
            TbTieuDe.Columns.Add("SO_SOAT_XET")
            TbTieuDe.Columns.Add("NGAY_HIEU_LUC")
            TbTieuDe.Columns.Add("SO_TRANG")
            TbTieuDe.Columns.Add("BIEN_SOAN")
            TbTieuDe.Columns.Add("SOAT_XET")
            TbTieuDe.Columns.Add("KIEM_TRA")
            TbTieuDe.Columns.Add("DUYET")
            TbTieuDe.Columns.Add("TEN")
            TbTieuDe.Columns.Add("CHUC_VU")
            TbTieuDe.Columns.Add("CHU_KY")
            TbTieuDe.Columns.Add("STT")
            TbTieuDe.Columns.Add("NOI_DUNG_CV")
            TbTieuDe.Columns.Add("LOAI_BT")
            TbTieuDe.Columns.Add("THANG")
            TbTieuDe.Columns.Add("GHICHU")
            TbTieuDe.Columns.Add("LINE")
            TbTieuDe.Columns.Add("MA_TB")
            TbTieuDe.Columns.Add("TEN_TB")
            TbTieuDe.Columns.Add("BO_PHAN")
            TbTieuDe.Columns.Add("TONG_THOI_GIAN")
            TbTieuDe.Columns.Add("TMP1")
            TbTieuDe.Columns.Add("TMP2")

            Dim rTitle As DataRow
            rTitle = TbTieuDe.NewRow()
            rTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TIEU_DE", Commons.Modules.TypeLanguage)
            If antoan = 1 Then
                rTitle("TIEU_DE1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TIEU_DE_ANTOAN", Commons.Modules.TypeLanguage)
            Else
                rTitle("TIEU_DE1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TIEU_DE_BT", Commons.Modules.TypeLanguage)
            End If
            rTitle("TIEU_DE2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "THOI_GIAN_TU", Commons.Modules.TypeLanguage) + " " + dtpTN.Text.Trim + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "DEN", Commons.Modules.TypeLanguage) + " " + dtpDN.Text.Trim
            rTitle("MASO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "MASO", Commons.Modules.TypeLanguage)
            rTitle("SO_SOAT_XET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "SO_SOAT_XET", Commons.Modules.TypeLanguage)
            rTitle("NGAY_HIEU_LUC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage)
            rTitle("SO_TRANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "SO_TRANG", Commons.Modules.TypeLanguage)
            rTitle("BIEN_SOAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "BIEN_SOAN", Commons.Modules.TypeLanguage)
            rTitle("SOAT_XET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "SOAT_XET", Commons.Modules.TypeLanguage)
            rTitle("KIEM_TRA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "KIEM_TRA", Commons.Modules.TypeLanguage)
            rTitle("DUYET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "DUYET", Commons.Modules.TypeLanguage)
            rTitle("TEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TEN", Commons.Modules.TypeLanguage)
            rTitle("CHUC_VU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "CHUC_VU", Commons.Modules.TypeLanguage)
            rTitle("CHU_KY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "CHU_KY", Commons.Modules.TypeLanguage)
            rTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "STT", Commons.Modules.TypeLanguage)
            rTitle("NOI_DUNG_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "NOI_DUNG_CV", Commons.Modules.TypeLanguage)
            rTitle("LOAI_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "LOAI_BT", Commons.Modules.TypeLanguage)
            rTitle("THANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "THANG", Commons.Modules.TypeLanguage)
            rTitle("GHICHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "GHICHU", Commons.Modules.TypeLanguage)
            rTitle("LINE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "LINE", Commons.Modules.TypeLanguage)
            rTitle("MA_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "MA_TB", Commons.Modules.TypeLanguage)
            rTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TEN_TB", Commons.Modules.TypeLanguage)
            rTitle("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "BO_PHAN", Commons.Modules.TypeLanguage)
            rTitle("TONG_THOI_GIAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TONG_THOI_GIAN", Commons.Modules.TypeLanguage)
            rTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TMP1", Commons.Modules.TypeLanguage)
            rTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKehoachbaotriduphong", "TMP2", Commons.Modules.TypeLanguage)

            TbTieuDe.TableName = "rptTieuDe_Kehoachbaotriduphong"
            TbTieuDe.Rows.Add(rTitle)
            frmRptView.AddDataTableSource(TbTieuDe)
            frmRptView.ShowDialog(Me)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dtpTN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTN.ValueChanged
        dtpDN.Value = "01/12/" + dtpTN.Value.Year.ToString()
    End Sub
#Region "Nhu Y"
   
   
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal tungay As Date, ByVal denngay As Date) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getKeHoachBaoTriDuPhong_NEW]", antoan, tungay, denngay))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), antoan, tungay, denngay)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getKeHoachBaoTriDuPhong_NEW]", antoan, tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal antoan As Integer, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, antoan, tungay, denngay)
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
   


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
