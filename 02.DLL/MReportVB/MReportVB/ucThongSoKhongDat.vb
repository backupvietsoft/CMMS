Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data

Public Class ucThongSoKhongDat
    Private repositoryItemLookUpEdit6 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit5 As Repository.RepositoryItemLookUpEdit

    Public sDiaDiem As String = "-1"
    Public sHeThong As Integer = "-1"
    Public sLoaiMay As String = "-1"
    Public sNhomMay As String = "-1"
    Public sMsMay As String = "-1"

    Private Sub repositoryItemLookUpEdit4_EditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)

        Try
            Dim cbo As LookUpEdit
            cbo = CType(sender, LookUpEdit)
            If cbo.EditValue <> "04" Then
                gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = False
                gvTSGSTT.SetFocusedRowCellValue("MS_PBT", vbNull)
                Exit Sub
            End If
            Dim tb As New DataTable()
            Dim str As String
            Dim NgayKT As DateTime
            Try
                NgayKT = gvTSGSTT.GetFocusedDataRow()("NGAY_GIO_KT_MAX")
            Catch ex As Exception
                NgayKT = Now
            End Try
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & gvTSGSTT.GetFocusedDataRow()("MS_MAY") & "' " &
                                " AND TINH_TRANG_PBT IN (4,5) And NGAY_NGHIEM_THU >='" & NgayKT.ToString("MM/dd/yyyy") & "'"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            If tb.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "msgChuaCoPBTCoNgayNghiemThuLonHonNgayGiamSat")
                gvTSGSTT.SetFocusedRowCellValue("MS_CACH_TH", "00")
                cbo.EditValue = "00"
                gvTSGSTT.SetFocusedRowCellValue("MS_PBT", vbNull)
                gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = False
                Exit Sub
            End If
            Dim dr As DataRow
            dr = tb.NewRow
            dr.Item("MS_PHIEU_BAO_TRI") = tb.Rows(0).Item(0)
            tb.Rows.InsertAt(dr, 0)
            If tb.Rows.Count > 0 Then
                repositoryItemLookUpEdit5.DataSource = Nothing
                repositoryItemLookUpEdit5.NullText = ""
                repositoryItemLookUpEdit5.ValueMember = "MS_PHIEU_BAO_TRI"
                repositoryItemLookUpEdit5.DisplayMember = "MS_PHIEU_BAO_TRI"
                repositoryItemLookUpEdit5.DataSource = tb
                repositoryItemLookUpEdit5.Columns.Clear()
                repositoryItemLookUpEdit5.Columns.Add(New Controls.LookUpColumnInfo("MS_PHIEU_BAO_TRI"))
            End If
            gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = True

        Catch ex As Exception

        End Try


    End Sub

    Private Sub radChuaGiaiQuyet2_Click(sender As Object, e As EventArgs) Handles radChuaGiaiQuyet2.Click, radDaGiaiQuyet2.Click, RadBoQua2.Click

        LoadDataTSGSTT()

        If radDaGiaiQuyet2.Checked Then
            dtpTNGSTT.Enabled = True
            dtpDNGSTT.Enabled = True
        Else
            'dtpTNGSTT.Enabled = False
            'dtpDNGSTT.Enabled = False
            dtpTNGSTT.Enabled = True
            dtpDNGSTT.Enabled = True
        End If

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien1.Enabled = False
            btnHuy.Enabled = False
        Else
            If radDaGiaiQuyet2.Checked Or RadBoQua2.Checked Then
                btnThucHien1.Enabled = False
                btnHuy.Enabled = True
            Else
                btnThucHien1.Enabled = True
                btnHuy.Enabled = False
            End If
        End If
    End Sub

    Public Sub LoadDataTSGSTT()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim dtTable As New DataTable

        ' chua giai quyet
        If radChuaGiaiQuyet2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", sDiaDiem, sHeThong, sLoaiMay, sNhomMay, sMsMay, 1, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        ElseIf RadBoQua2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", sDiaDiem, sHeThong, sLoaiMay, sNhomMay, sMsMay, 2, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        ElseIf radDaGiaiQuyet2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", sDiaDiem, sHeThong, sLoaiMay, sNhomMay, sMsMay, 3, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Else
            radChuaGiaiQuyet2.Checked = True
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", sDiaDiem, sHeThong, sLoaiMay, sNhomMay, sMsMay, 1, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        End If
        Try
            For Each cl As DataColumn In dtTable.Columns
                cl.ReadOnly = False
            Next
        Catch ex As Exception
        End Try
        dtTable.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(gdTSGSTT, gvTSGSTT, dtTable, True, False, False, True, True, Me.Name)
        Me.Cursor = Cursors.Default
        If gvTSGSTT.Columns("MS_TT").Visible = False Then Exit Sub
        gvTSGSTT.Columns("MS_CACH_TH").Visible = False
        gvTSGSTT.Columns("MS_TS_GSTT").Visible = False
        gvTSGSTT.Columns("MS_BO_PHAN").Visible = False
        gvTSGSTT.Columns("STT").Visible = False
        gvTSGSTT.Columns("STT_GT").Visible = False
        gvTSGSTT.Columns("MS_CONG_NHAN").ColumnEdit = repositoryItemLookUpEdit6
        gvTSGSTT.Columns("NGAY_GIO_KT_MAX").DisplayFormat.FormatString = "MM/dd/yyyy"
        gvTSGSTT.Columns("NGAY_GIO_KT_MAX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Dim str As String = ""
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvTSGSTT.Columns
            Select Case col.FieldName
                'Case "MS_CONG_NHAN", "MS_PBT", "MS_CACH_TH"
                Case "CHON"
                    col.OptionsColumn.AllowEdit = True
                Case Else
                    col.OptionsColumn.AllowEdit = False
            End Select
        Next
        Me.Cursor = Cursors.Default
        gvTSGSTT.Columns("MS_TT").Visible = False
    End Sub

    Private Sub dtpTNGSTT_Validated(sender As Object, e As EventArgs) Handles dtpTNGSTT.Validated, dtpDNGSTT.Validated
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        LoadDataTSGSTT()
    End Sub

    Private Sub ucThongSoKhongDat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpTNGSTT.DateTime = DateSerial(Year(Now), Month(Now), 1)
        dtpDNGSTT.DateTime = DateSerial(Year(Now), Month(Now), 1).AddMonths(1).AddDays(-1)

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien1.Enabled = False
            btnAllGSTT.Visible = False
            btnNotAllGSTT.Visible = False
            btnXemBangChung1.Visible = False
            btnHuy.Visible = False
            btnThucHien1.Visible = False
        End If
    End Sub


    Public Sub BindData_Tab()
        Me.Cursor = Cursors.WaitCursor
        LoadDataTSGSTT()
        Me.Cursor = Cursors.Default
    End Sub

End Class
