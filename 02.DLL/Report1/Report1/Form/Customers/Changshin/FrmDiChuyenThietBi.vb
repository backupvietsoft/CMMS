
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Public Class FrmDiChuyenThietBi
    Private vNgayChuyen As DateTime
    Private Sub FrmDiChuyenThietBi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0
        lockControlTab1(True)
        loadNhaXuong()
        vNgayChuyen = DateTime.Now.Date
        dtNgayChuyen.DateTime = vNgayChuyen
        LoadHeThong()
        LoadBPCP()

        LoadNXDen()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnChuyendi.Enabled = False
            btnChuyenLai.Enabled = False
            btnDiChuyen.Enabled = False

            btnChuyenDi1.Enabled = False
            btnChuyenLai1.Enabled = False
            btnChuyen1.Enabled = False

            btnChuyenDi2.Enabled = False
            btnChuyenLai2.Enabled = False
            btnChuyen2.Enabled = False
        End If
    End Sub

    Private vChuyenTab As Boolean = True

    'load conbo nhà xưởng
    Sub loadNhaXuong()
        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtNXTu, dtTmp, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtNXDen, dtTmp.Copy(), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")

    End Sub

    Sub LoadHeThong()
        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtHTTu, dtTmp, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
        Commons.Modules.ObjSystems.MLoadCboTreeList(cbtHTDen, dtTmp.Copy(), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
    End Sub

    Sub LoadBPCP()
        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp = Commons.Modules.ObjSystems.MLoadDataBoPhanChiuPhi(0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPTu, dtTmp, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "TEN_BP_CHIU_PHI")
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPDen, dtTmp.Copy(), "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "TEN_BP_CHIU_PHI")
    End Sub

#Region "Di chuyển thiết bị nhà xưởng"

    Private Sub lockControlTab1(ByVal flag As Boolean)
        btnGhi.Visible = Not flag
        btnkhongghi.Visible = Not flag
        btnChuyendi.Enabled = Not flag
        btnChuyenLai.Enabled = False
        btnDiChuyen.Visible = flag
        btnThoat.Visible = flag
        cbtNXTu.Enabled = flag
        cbtNXDen.Enabled = flag
    End Sub

    'ghi -tab di chuyển địa điểm
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Dim vConnection As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If vConnection.State = ConnectionState.Closed Then
            vConnection.Open()
        End If
        Dim vTran As SqlTransaction = vConnection.BeginTransaction
        Try
            grvNXDen.UpdateCurrentRow()
            For i = 0 To grvNXDen.RowCount - 1
                SqlHelper.ExecuteNonQuery(vTran, "H_INSERT_MAY_NHA_XUONG", grvNXDen.GetDataRow(i)("MS_MAY"), cbtNXDen.EditValue, vNgayChuyen, grvNXDen.GetDataRow(i)("GC_NX"))
                SqlHelper.ExecuteNonQuery(vTran, "UPDATE_MAY_NHA_XUONG_LOG", grvNXDen.GetDataRow(i)("MS_MAY"), vNgayChuyen, Me.Name, Commons.Modules.UserName, 1)
            Next
            Dim dt As DataTable = CType(grdNXDen.DataSource, DataTable)
            dt.Rows.Clear()

            vTran.Commit()
            vChuyenTab = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DI_CHUYEN_THANH_CONG", Commons.Modules.TypeLanguage))

            lockControlTab1(True)
            dtNgayChuyen.Enabled = True
            dtNgayChuyen.Properties.ReadOnly = False
        Catch ex As Exception
            vTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_THANH_CONG", Commons.Modules.TypeLanguage) + ex.Message)
        End Try
        vConnection.Close()
    End Sub
    'không ghi- tab di chuyển địa điểm
    Private Sub btnkhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkhongghi.Click
        lockControlTab1(True)
        dtNgayChuyen.Properties.ReadOnly = False
        grvNXDen.UpdateCurrentRow()
        For i = 0 To grvNXDen.RowCount - 1
            Try
                grvNXuong.AddNewRow()
                grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "MS_MAY", grvNXDen.GetDataRow(i)("MS_MAY"))
                grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "TEN_MAY", grvNXDen.GetDataRow(i)("TEN_MAY"))
                grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "NGAY_NHAP", grvNXDen.GetDataRow(i)("NGAY_NHAP"))
            Catch ex As Exception
            End Try
        Next
        Dim dt As DataTable = CType(grdNXDen.DataSource, DataTable)
        dt.Rows.Clear()
        btnChuyenLai.Enabled = False
        vChuyenTab = True
    End Sub
    'button Di chuyển -tab di chuyển địa điểm
    Private Sub btnDiChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiChuyen.Click
        Dim value As String = ""
        If dtNgayChuyen.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            dtNgayChuyen.Focus()
            Exit Sub
        End If
        Try
            value = ""
            Try
                value = cbtNXTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtNXTu.TextValue <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_TU_XUONG", Commons.Modules.TypeLanguage))
                cbtNXTu.Focus()
                Exit Sub
            End If

        Catch ex As Exception

        End Try
        Try
            value = ""
            Try
                value = cbtNXDen.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtNXDen.TextValue <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_XUONG_DEN", Commons.Modules.TypeLanguage))
                cbtNXDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        Try
            If cbtNXTu.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_TU_XUONG", Commons.Modules.TypeLanguage))
                cbtNXTu.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_TU_XUONG", Commons.Modules.TypeLanguage))
            cbtNXTu.Focus()
            Exit Sub
        End Try

        Try
            If cbtNXDen.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_XUONG_DEN", Commons.Modules.TypeLanguage))
                cbtNXDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_XUONG_DEN", Commons.Modules.TypeLanguage))
            cbtNXDen.Focus()
            Exit Sub
        End Try
        Try
            If cbtNXDen.EditValue = cbtNXTu.EditValue Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DENXUONG_PHAI_KHAC_TUXUONG", Commons.Modules.TypeLanguage))
                cbtNXDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        lockControlTab1(False)
        vChuyenTab = False
        dtNgayChuyen.Properties.ReadOnly = True
    End Sub
    'thoát - tab di chuyển địa điểm
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyendi.Click
        btnChuyenLai.Enabled = True
        If grvNXuong.RowCount > 0 Then
            If CheckDateMove(grvNXuong.GetFocusedDataRow("MS_MAY"), vNgayChuyen) Then
                Try
                    grvNXDen.AddNewRow()
                    grvNXDen.SetRowCellValue(grvNXDen.FocusedRowHandle, "MS_MAY", grvNXuong.GetFocusedDataRow("MS_MAY"))
                    grvNXDen.SetRowCellValue(grvNXDen.FocusedRowHandle, "TEN_MAY", grvNXuong.GetFocusedDataRow("TEN_MAY"))
                    grvNXDen.SetRowCellValue(grvNXDen.FocusedRowHandle, "NGAY_NHAP", grvNXuong.GetFocusedDataRow("NGAY_NHAP"))
                    grvNXuong.DeleteRow(grvNXuong.FocusedRowHandle)
                Catch ex As Exception

                End Try
                If grvNXDen.RowCount = 0 Then
                    btnChuyendi.Enabled = False
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NC_TRUOC_LH_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If
    End Sub

    Function CheckDateMove(ByVal _vMS_MAY As String, ByVal _vNgayChuyen As DateTime) As Boolean
        Try
            Dim vTMP As New DataTable
            vTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_CHECK_DATE_MOVE", _vMS_MAY))
            If vTMP.Rows.Count > 0 Then
                Dim vDateTMP As DateTime
                vDateTMP = vTMP.Rows(0)("NGAY_NHAP")
                'vDateTMP = DateTime.ParseExact(vTMP.Rows(0)("NGAY_NHAP").ToString, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                If vDateTMP >= _vNgayChuyen Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnChuyenLai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenLai.Click
        btnChuyendi.Enabled = True
        If grvNXDen.RowCount > 0 Then
            grvNXuong.AddNewRow()
            grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "MS_MAY", grvNXDen.GetFocusedDataRow("MS_MAY"))
            grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "TEN_MAY", grvNXDen.GetFocusedDataRow("TEN_MAY"))
            grvNXuong.SetRowCellValue(grvNXuong.FocusedRowHandle, "NGAY_NHAP", grvNXDen.GetFocusedDataRow("NGAY_NHAP"))
            grvNXDen.DeleteRow(grvNXDen.FocusedRowHandle)
            If grvNXuong.RowCount <= 0 Then
                btnChuyenLai.Enabled = False
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If

    End Sub

#End Region

#Region "Di chuyển thiết bị Hệ Thống"

    Sub lockControlHeThong(ByVal _vflag As Boolean)
        btnChuyenDi1.Enabled = _vflag
        btnChuyenLai1.Enabled = _vflag
        btnChuyen1.Visible = Not _vflag
        btnGhi1.Visible = _vflag
        btnkhongghi1.Visible = _vflag
        btnThoat1.Visible = Not _vflag
        cbtHTTu.Enabled = Not _vflag
        cbtHTDen.Enabled = Not _vflag
        dtNgayChuyen.Enabled = Not _vflag
    End Sub


    Private Sub btnGhi1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi1.Click
        Dim vConnection As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If vConnection.State = ConnectionState.Closed Then
            vConnection.Open()
        End If
        Dim vTran As SqlTransaction = vConnection.BeginTransaction
        Try
            grvHTDen.UpdateCurrentRow()
            For i = 0 To grvHTDen.RowCount - 1
                SqlHelper.ExecuteNonQuery(vTran, "H_INSERT_MAY_HE_THONGs", grvHTDen.GetDataRow(i)("MS_MAY"), vNgayChuyen, cbtHTDen.EditValue, grvHTDen.GetDataRow(i)("GC_HT"))
                SqlHelper.ExecuteNonQuery(vTran, "UPDATE_MAY_HE_THONG_LOG", grvHTDen.GetDataRow(i)("MS_MAY"), vNgayChuyen, Me.Name, Commons.Modules.UserName, 1)
            Next
            Dim dt As DataTable = CType(grdHTDen.DataSource, DataTable)
            dt.Rows.Clear()
            vTran.Commit()
            vChuyenTab = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DI_CHUYEN_THANH_CONG", Commons.Modules.TypeLanguage))
            lockControlHeThong(False)
        Catch ex As Exception
            vTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_THANH_CONG", Commons.Modules.TypeLanguage))
        End Try
        vConnection.Close()
    End Sub

    Private Sub btnkhongghi1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkhongghi1.Click
        lockControlHeThong(False)
        dtNgayChuyen.Properties.ReadOnly = False
        If grvHTDen.RowCount > 0 Then
            grvHTDen.UpdateCurrentRow()
            For i As Integer = 0 To grvHTDen.RowCount - 1
                grvHTDi.AddNewRow()
                grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "MS_MAY", grvHTDen.GetDataRow(i)("MS_MAY"))
                grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "TEN_MAY", grvHTDen.GetDataRow(i)("TEN_MAY"))
                grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "NGAY_NHAP", grvHTDen.GetDataRow(i)("NGAY_NHAP"))
            Next
        End If
        Dim dt As DataTable = CType(grdHTDen.DataSource, DataTable)
        dt.Rows.Clear()
        btnChuyenLai1.Enabled = False
        vChuyenTab = True
    End Sub

    Private Sub btnChuyen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyen1.Click
        Dim value As String = ""
        If dtNgayChuyen.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            dtNgayChuyen.Focus()
            Exit Sub
        End If
        Try
            value = ""
            Try
                value = cbtHTTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtHTTu.TextValue <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DI", Commons.Modules.TypeLanguage))
                cbtHTTu.Focus()
                Exit Sub
            End If

        Catch ex As Exception

        End Try
        Try
            value = ""
            Try
                value = cbtHTDen.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtHTDen.TextValue <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DEN", Commons.Modules.TypeLanguage))
                cbtHTDen.Focus()
                Exit Sub
            End If

        Catch ex As Exception

        End Try

        Try
            If cbtHTTu.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DI", Commons.Modules.TypeLanguage))
                cbtHTTu.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DI", Commons.Modules.TypeLanguage))
            cbtHTTu.Focus()
            Exit Sub
        End Try

        Try
            If cbtHTDen.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DEN", Commons.Modules.TypeLanguage))
                cbtHTDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_HT_DEN", Commons.Modules.TypeLanguage))
            cbtHTDen.Focus()
            Exit Sub
        End Try

        Try
            If cbtHTDen.EditValue = cbtHTTu.EditValue Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HT_DEN_PHAI_KHAC_HT_DI", Commons.Modules.TypeLanguage))
                cbtHTDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        lockControlHeThong(True)

        btnChuyenLai1.Enabled = False
        vChuyenTab = False

    End Sub

    Private Sub btnThoat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat1.Click
        Me.Close()
    End Sub

    Private Sub btnChuyenDi1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenDi1.Click
        btnChuyenLai1.Enabled = True
        If grvHTDi.RowCount > 0 Then
            If CheckDateMoveHT(grvHTDi.GetFocusedDataRow("MS_MAY"), vNgayChuyen) Then
                grvHTDen.AddNewRow()
                grvHTDen.SetRowCellValue(grvHTDen.FocusedRowHandle, "MS_MAY", grvHTDi.GetFocusedDataRow("MS_MAY"))
                grvHTDen.SetRowCellValue(grvHTDen.FocusedRowHandle, "TEN_MAY", grvHTDi.GetFocusedDataRow("TEN_MAY"))
                grvHTDen.SetRowCellValue(grvHTDen.FocusedRowHandle, "NGAY_NHAP", grvHTDi.GetFocusedDataRow("NGAY_NHAP"))
                grvHTDi.DeleteRow(grvHTDi.FocusedRowHandle)
                If grvHTDi.RowCount <= 0 Then
                    btnChuyenDi1.Enabled = False
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NC_TRUOC_LH_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If
    End Sub

    Private Sub btnChuyenLai1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenLai1.Click
        btnChuyenDi1.Enabled = True
        If grvHTDen.RowCount > 0 Then
            grvHTDi.AddNewRow()
            grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "MS_MAY", grvHTDen.GetFocusedDataRow("MS_MAY"))
            grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "TEN_MAY", grvHTDen.GetFocusedDataRow("TEN_MAY"))
            grvHTDi.SetRowCellValue(grvHTDi.FocusedRowHandle, "NGAY_NHAP", grvHTDen.GetFocusedDataRow("NGAY_NHAP"))
            grvHTDen.DeleteRow(grvHTDen.FocusedRowHandle)

            If grvHTDen.RowCount <= 0 Then
                btnChuyenLai.Enabled = False
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If
    End Sub
    Function CheckDateMoveHT(ByVal _vMS_MAY As String, ByVal _vNgayChuyen As DateTime) As Boolean
        Try
            Dim vTMP As New DataTable
            vTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_CHECK_DATE_MOVE_HT", _vMS_MAY))
            If vTMP.Rows.Count > 0 Then
                Dim vDateTMP As DateTime
                vDateTMP = vTMP.Rows(0)("NGAY_NHAP")
                'vDateTMP = DateTime.ParseExact(vTMP.Rows(0)("NGAY_NHAP").ToString, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                If vDateTMP >= _vNgayChuyen Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region

#Region "Di chuyển thiết bị Bộ phận chịu phí"
    Sub lockControlBPCP(ByVal _vflag As Boolean)
        btnChuyenDi2.Enabled = _vflag
        btnChuyenLai2.Enabled = _vflag
        btnChuyen2.Visible = Not _vflag
        btnGhi2.Visible = _vflag
        btnKhongGhi2.Visible = _vflag
        btnThoat2.Visible = Not _vflag
        cboBPCPTu.Enabled = Not _vflag
        cboBPCPDen.Enabled = Not _vflag
        dtNgayChuyen.Enabled = Not _vflag
    End Sub

    Private Sub btnGhi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi2.Click
        Dim vConnection As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If vConnection.State = ConnectionState.Closed Then
            vConnection.Open()
        End If
        Dim vTran As SqlTransaction = vConnection.BeginTransaction
        Try
            grvBPCPDen.UpdateCurrentRow()
            For i = 0 To grvBPCPDen.RowCount - 1
                Try
                    SqlHelper.ExecuteNonQuery(vTran, "H_INSERT_MAY_BO_PHAN_CHIU_PHI", grvBPCPDen.GetDataRow(i)("MS_MAY"), vNgayChuyen, Integer.Parse(cboBPCPDen.EditValue.ToString), grvBPCPDen.GetDataRow(i)("GC_BPCP"))
                    SqlHelper.ExecuteNonQuery(vTran, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", grvBPCPDen.GetDataRow(i)("MS_MAY"), vNgayChuyen, Me.Name, Commons.Modules.UserName, 1)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Next
            Dim dt As DataTable = CType(grdBPCPDen.DataSource, DataTable)
            dt.Rows.Clear()
            vTran.Commit()
            vChuyenTab = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DI_CHUYEN_THANH_CONG", Commons.Modules.TypeLanguage))
            lockControlBPCP(False)
        Catch ex As Exception
            vTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_THANH_CONG", Commons.Modules.TypeLanguage))
        End Try
        vConnection.Close()
    End Sub

    Private Sub btnKhongGhi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi2.Click
        lockControlBPCP(False)
        dtNgayChuyen.Properties.ReadOnly = False
        If grvBPCPDen.RowCount > 0 Then
            grvBPCPDen.UpdateCurrentRow()
            For i = 0 To grvBPCPDen.RowCount - 1
                grvBPCPDi.AddNewRow()
                grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "MS_MAY", grvBPCPDen.GetDataRow(i)("MS_MAY"))
                grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "TEN_MAY", grvBPCPDen.GetDataRow(i)("TEN_MAY"))
                grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "NGAY_NHAP", grvBPCPDen.GetDataRow(i)("NGAY_NHAP"))
            Next
            Dim dt As DataTable = CType(grdBPCPDen.DataSource, DataTable)
            dt.Rows.Clear()
        End If
        btnChuyenLai2.Enabled = False
        vChuyenTab = True
    End Sub

    Private Sub btnChuyen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyen2.Click
        Dim value As String = ""
        If dtNgayChuyen.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            dtNgayChuyen.Focus()
            Exit Sub
        End If

        Try
            value = ""
            Try
                value = cboBPCPTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cboBPCPTu.Text <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DI", Commons.Modules.TypeLanguage))
                cboBPCPTu.Focus()
                Exit Sub

            End If

        Catch ex As Exception

        End Try

        Try
            value = ""
            Try
                value = cboBPCPDen.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cboBPCPDen.Text <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DEN", Commons.Modules.TypeLanguage))
                cboBPCPDen.Focus()
                Exit Sub

            End If

        Catch ex As Exception

        End Try

        Try
            If cboBPCPTu.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DI", Commons.Modules.TypeLanguage))
                cboBPCPTu.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DI", Commons.Modules.TypeLanguage))
            cboBPCPTu.Focus()
            Exit Sub
        End Try

        Try
            If cboBPCPDen.EditValue = "-1" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DEN", Commons.Modules.TypeLanguage))
                cboBPCPDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_BP_DEN", Commons.Modules.TypeLanguage))
            cboBPCPDen.Focus()
            Exit Sub
        End Try

        Try
            If cboBPCPDen.EditValue = cboBPCPTu.EditValue Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BP_DEN_PHAI_KHAC_BP_DI", Commons.Modules.TypeLanguage))
                cboBPCPDen.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        lockControlBPCP(True)
        btnChuyenLai2.Enabled = False
        vChuyenTab = False
    End Sub

    Private Sub btnThoat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat2.Click
        Me.Close()
    End Sub

    Private Sub btnChuyenDi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenDi2.Click
        If grvBPCPDi.RowCount > 0 Then
            If CheckDateMoveBPCP(grvBPCPDi.GetFocusedRowCellValue("MS_MAY"), vNgayChuyen) Then
                grvBPCPDen.AddNewRow()
                grvBPCPDen.SetRowCellValue(grvBPCPDen.FocusedRowHandle, "MS_MAY", grvBPCPDi.GetFocusedRowCellValue("MS_MAY"))
                grvBPCPDen.SetRowCellValue(grvBPCPDen.FocusedRowHandle, "TEN_MAY", grvBPCPDi.GetFocusedRowCellValue("TEN_MAY"))
                grvBPCPDen.SetRowCellValue(grvBPCPDen.FocusedRowHandle, "NGAY_NHAP", grvBPCPDi.GetFocusedRowCellValue("NGAY_NHAP"))
                grvBPCPDi.DeleteRow(grvBPCPDi.FocusedRowHandle)
                btnChuyenLai2.Enabled = True
                If grvBPCPDi.RowCount <= 0 Then
                    btnChuyenDi2.Enabled = False
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NC_TRUOC_LH_NGAY_CHUYEN", Commons.Modules.TypeLanguage))
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If


    End Sub

    Function CheckDateMoveBPCP(ByVal _vMS_MAY As String, ByVal _vNgayChuyen As DateTime) As Boolean
        Try
            Dim vTMP As New DataTable
            vTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_CHECK_DATE_MOVE_BPCP", _vMS_MAY))
            If vTMP.Rows.Count > 0 Then
                Dim vDateTMP As DateTime
                vDateTMP = vTMP.Rows(0)("NGAY_NHAP")
                'vDateTMP = DateTime.ParseExact(vTMP.Rows(0)("NGAY_NHAP").ToString, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                If vDateTMP >= _vNgayChuyen Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnChuyenLai2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenLai2.Click
        btnChuyenDi2.Enabled = True
        If grvBPCPDen.RowCount > 0 Then
            grvBPCPDi.AddNewRow()
            grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "MS_MAY", grvBPCPDen.GetFocusedDataRow("MS_MAY"))
            grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "TEN_MAY", grvBPCPDen.GetFocusedDataRow("TEN_MAY"))
            grvBPCPDi.SetRowCellValue(grvBPCPDi.FocusedRowHandle, "NGAY_NHAP", grvBPCPDen.GetFocusedDataRow("NGAY_NHAP"))
            grvBPCPDen.DeleteRow(grvBPCPDen.FocusedRowHandle)
            If grvBPCPDen.RowCount <= 0 Then
                btnChuyenLai.Enabled = False
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_CON_TB", Commons.Modules.TypeLanguage))
        End If
    End Sub
#End Region

    Private Sub cboTuXuong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cbtNXTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtNXTu.TextValue <> "" Then
                cbtNXTu.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboDenXuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboDenXuong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cbtNXDen.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtNXDen.TextValue <> "" Then
                cbtNXDen.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbtHTTu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cbtHTTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cbtHTTu.TextValue <> "" Then
                cbtHTTu.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbtHTDen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbtHTDen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cbtHTDen.EditValue
            Catch ex As Exception
            End Try
            If value = "" And cbtHTDen.TextValue <> "" Then
                cbtHTDen.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboBPCPTu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cboBPCPTu.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cboBPCPTu.Text <> "" Then
                cboBPCPTu.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboBPCPDen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboBPCPDen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim value As String = ""
            Try
                value = cboBPCPDen.EditValue
            Catch ex As Exception

            End Try
            If value = "" And cboBPCPDen.Text <> "" Then
                cboBPCPDen.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

    End Sub

    Private Sub tbaDiduyen_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tbaDiduyen.SelectedPageChanged

        If vChuyenTab = True Then
            If tbaDiduyen.SelectedTabPageIndex = 1 Then
                lockControlHeThong(False)
            ElseIf tbaDiduyen.SelectedTabPageIndex = 2 Then
                lockControlBPCP(False)
            End If
        End If

        Select Case tbaDiduyen.SelectedTabPageIndex
            Case 1
                LoadHTDen()
            Case 2
                LoadBPCPDen()
            Case Else
        End Select

    End Sub

    Private Sub tbaDiduyen_SelectedPageChanging(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles tbaDiduyen.SelectedPageChanging
        If vChuyenTab = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub LoadNXDen()
        grdNXDen.DataSource = Nothing
        Dim dt As New DataTable()
        Try
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongDiChuyen", cbtNXTu.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
            dt.Rows.Clear()

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNXDen, grvNXDen, dt, True, False, True, True, True, Me.Name)
            grvNXDen.Columns("MS_MAY").OptionsColumn.ReadOnly = True
            grvNXDen.Columns("TEN_MAY").OptionsColumn.ReadOnly = True
            grvNXDen.Columns("MS_N_XUONG").Visible = False
            grvNXDen.Columns("Ten_N_XUONG").Visible = False
            grvNXDen.Columns("NGAY_NHAP").Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cbtNXTu_EditValuedChanged(sender As Object, e As MVControl.ucComboboxTreeList.EventArgs) Handles cbtNXTu.EditValuedChanged
        Dim vtbMay As New DataTable()
        Try
            vtbMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongDiChuyen", cbtNXTu.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
            vtbMay.Columns("NGAY_NHAP").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNXuong, grvNXuong, vtbMay, False, True, False, True, True, Me.Name)
            grvNXuong.Columns("MS_N_XUONG").Visible = False
            grvBPCPDi.Columns("GC_NX").Width = 200
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadHTDen()
        grdHTDen.DataSource = Nothing
        Dim dt As DataTable
        dt = CType(grdHTDi.DataSource, DataTable).Copy()
        dt.Clear()
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdHTDen, grvHTDen, dt, True, True, True, True, True, Me.Name)
        grvHTDen.Columns("MS_MAY").OptionsColumn.ReadOnly = True
        grvHTDen.Columns("TEN_MAY").OptionsColumn.ReadOnly = True
        grvHTDen.Columns("MS_HE_THONG").Visible = False
        grvHTDen.Columns("TEN_HE_THONG").Visible = False
        grvHTDen.Columns("NGAY_NHAP").Visible = False
    End Sub


    Private Sub cbtHTTu_EditValuedChanged(sender As Object, e As MVControl.ucComboboxTreeList.EventArgs) Handles cbtHTTu.EditValuedChanged
        Try
            Dim vtbMay As New DataTable()
            vtbMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongDiChuyen", Integer.Parse(cbtHTTu.EditValue.ToString()), Commons.Modules.UserName, Commons.Modules.TypeLanguage))
            vtbMay.Columns("NGAY_NHAP").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHTDi, grvHTDi, vtbMay, False, True, False, True, True, Me.Name)
            grvHTDi.Columns("MS_HE_THONG").Visible = False
            grvHTDi.Columns("GC_HT").Width = 150
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadBPCPDen()
        grdBPCPDen.DataSource = Nothing
        Dim dt As New DataTable
        dt = CType(grdBPCPDi.DataSource, DataTable).Copy()
        dt.Rows.Clear()
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCPDen, grvBPCPDen, dt, True, True, True, True, True, Me.Name)
        grvBPCPDen.Columns("MS_MAY").OptionsColumn.ReadOnly = True
        grvBPCPDen.Columns("TEN_MAY").OptionsColumn.ReadOnly = True
        grvBPCPDen.Columns("MS_BP_CHIU_PHI").Visible = False
        grvBPCPDen.Columns("NGAY_NHAP").Visible = False
        grvBPCPDen.Columns("TEN_BP_CHIU_PHI").Visible = False
    End Sub
    Private Sub cboBPCPTu_EditValueChanged(sender As Object, e As EventArgs) Handles cboBPCPTu.EditValueChanged
        Try
            Dim vtbBPCP As New DataTable()
            grdBPCPDi.DataSource = Nothing
            vtbBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayBPCPDiChuyen", Integer.Parse(cboBPCPTu.EditValue.ToString()), Commons.Modules.UserName, Commons.Modules.TypeLanguage))
            vtbBPCP.Columns("NGAY_NHAP").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCPDi, grvBPCPDi, vtbBPCP, False, True, False, True, True, Me.Name)
            grvBPCPDi.Columns("MS_BP_CHIU_PHI").Visible = False
            grvBPCPDi.Columns("GC_BPCP").Width = 150
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtNgayChuyen_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtNgayChuyen.Validating

        If btnThoat.Focused Then
            Exit Sub
        End If

        Try
            If dtNgayChuyen.Text.Trim <> "" Then
                vNgayChuyen = DateTime.ParseExact(dtNgayChuyen.DateTime.Date, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            dtNgayChuyen.Focus()
            e.Cancel = True
            Exit Sub
        End Try

    End Sub

    Private Sub timkiem(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal txt As TextEdit)
        Dim dk As String = ""
        Dim dt As DataTable = CType(grid.DataSource, DataTable)
        If String.IsNullOrEmpty(txt.EditValue.ToString()) Then
            dt.DefaultView.RowFilter = dk
        End If
        dk += "MS_MAY LIKE '%" & txt.EditValue & "%' OR TEN_MAY LIKE '" & txt.EditValue & "'"
        dt.DefaultView.RowFilter = dk
    End Sub

    Private Sub txt_TimNX_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TimNX.EditValueChanged
        timkiem(grdNXuong, txt_TimNX)
    End Sub

    Private Sub txt_TimHT_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TimHT.EditValueChanged
        timkiem(grdHTDi, txt_TimHT)
    End Sub

    Private Sub txt_TimBPCP_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TimBPCP.EditValueChanged
        timkiem(grdBPCPDi, txt_TimBPCP)
    End Sub
End Class