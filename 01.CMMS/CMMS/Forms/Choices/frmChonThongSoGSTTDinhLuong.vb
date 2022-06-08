
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors

Public Class frmChonThongSoGSTTDinhLuong

    Private _tDinhLuong As DataTable
    Private tbTam As New DataTable()
    Private bKhoitao As Boolean = True
    Private _sMsMay As String = "-1"
    Dim btLuuDL As DataTable

    Public Property sMsMay() As String
        Get
            Return _sMsMay
        End Get
        Set(ByVal value As String)
            _sMsMay = value
        End Set
    End Property

    Public Property tDinhLuong() As DataTable
        Get
            Return _tDinhLuong
        End Get
        Set(ByVal value As DataTable)
            _tDinhLuong = value
        End Set
    End Property
    Private Sub frmChonThongSoGSTTDinhLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.SQLString = "0LOAD"
        btLuuDL = tDinhLuong.Copy
        dtNgay.DateTime = Now
        LoadcboLoaithietbi()
        LoadcboThietbi()
        LoadcboThongsogiamsat()
        Dim MsMay As String
        If sMsMay = "-1" Then
            MsMay = "-1"
        Else
            lblLoaithietbi.Visible = False
            cboLoaithietbi.Visible = False
            lblThietbi.Visible = False
            cboThietbi.Visible = False
            MsMay = sMsMay
        End If

        tbTam = New clsChonthongsoGSTTdinhluongController().GetGIA_TRI_DINH_LUONGs(-1, MsMay)
        CreatetxtGiatri()

        Commons.Modules.SQLString = ""
        Binddata()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
#Region "private "
    Sub LoadcboLoaithietbi()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaithietbi, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1),
                                                   "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
    End Sub

    Sub LoadcboThietbi()
        cboThietbi.Properties.DataSource = Nothing
        If cboLoaithietbi.Text.Trim = "" Then
            Exit Sub
        End If 'GetMayTheoNhomLoai


        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAY_DINH_LUONG", cboLoaithietbi.EditValue, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbi, dt, "MS_MAY", "MS_MAY", "")
    End Sub

    Sub LoadcboThongsogiamsat()
        cboThongsogiamsat.Properties.DataSource = Nothing
        If cboThietbi.Text.Trim = "" Then Exit Sub
        Dim MsMay As String
        If sMsMay <> "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay


        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_TS_GSTT_MAY_TS_GSTT", MsMay))
        Dim row As DataRow
        row = dt.NewRow()
        row("MS_TS_GSTT") = -1
        row("TEN_TS_GSTT") = "< ALL >"
        dt.Rows.Add(row)
        dt.DefaultView.Sort = "TEN_TS_GSTT"
        dt = dt.DefaultView.ToTable

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThongsogiamsat, dt, "MS_TS_GSTT", "TEN_TS_GSTT", "")


    End Sub

    Sub CreatetxtGiatri()

        tbTam.Columns("GIA_TRI").ReadOnly = False
        tbTam.Columns("GIA_TRI").AllowDBNull = True

        tbTam.Columns("MS_TT").ReadOnly = False
        tbTam.Columns("MS_TT").AllowDBNull = True

        HienThi(tbTam.DefaultView.ToTable())
    End Sub
    Sub LocDuLieu()
        'Dim dtData As New DataTable
        Dim dtData As DataTable = TryCast(grdDS.DataSource, DataTable)
        Try

            MsMay = cboThietbi.EditValue
            If MsMay = Nothing Then
                dtData.DefaultView.RowFilter = "0=1"
            Else
                If MsMay = "-1" Then
                    If cboThongsogiamsat.EditValue <> "-1" Then
                        dtData.DefaultView.RowFilter = "MS_TS_GSTT=" + cboThongsogiamsat.EditValue
                    Else
                        dtData.DefaultView.RowFilter = "MS_LOAI_MAY='" + cboLoaithietbi.EditValue + "'"
                    End If
                Else
                    If cboThongsogiamsat.EditValue <> -1 And cboThongsogiamsat.EditValue <> "-1" Then
                        dtData.DefaultView.RowFilter = "MS_TS_GSTT=" + cboThongsogiamsat.EditValue + " AND MS_MAY='" + MsMay + "'"
                    Else
                        dtData.DefaultView.RowFilter = "MS_MAY='" + MsMay + "'"
                    End If
                End If
            End If
        Catch ex As Exception
            dtData.DefaultView.RowFilter = ""
        End Try

    End Sub
    Sub Binddata()
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If Commons.Modules.SQLString = "0LOADLTB" Then Exit Sub
        If Commons.Modules.SQLString = "0LOADTB" Then Exit Sub


        Try
            If cboThietbi.Text.Trim = "" Then
                grdGiaTri.DataSource = Nothing
                grdDS.DataSource = Nothing
                Exit Sub
            End If

            'If sMsMay <> "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay

            grdGiaTri.DataSource = Nothing
            'If bKhoitao Then
            '    HienThi(btLuuDL)
            '    bKhoitao = False
            '    _tDinhLuong.Rows.Clear()
            'Else
            '    HienThi(tbTam.DefaultView.ToTable())
            'End If




            tbTam.Columns("GIA_TRI").ReadOnly = False
            Commons.Modules.SQLString = "0LOADLUOI"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDS, grvDS, tbTam, True, True, True, False, True, Me.Name)
            LocDuLieu()
            Commons.Modules.SQLString = ""


            If grvDS.RowCount > 0 Then
                BtnThucHien.Enabled = True
            Else
                BtnThucHien.Enabled = False
            End If
            grvDS.Columns("GIA_TRI").OptionsColumn.ReadOnly = False

            grvDS.Columns("GIA_TRI").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
            grvDS.Columns("GIA_TRI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grvDS.Columns("GIA_TRI").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            grvDS.Columns("MS_TS_GSTT").Visible = False
            grvDS.Columns("MS_LOAI_MAY").Visible = False
            grvDS.Columns("STT_BP").Visible = False
            grvDS.Columns("MS_TT").Visible = False
            grvDS.Columns("TEN_NHOM_MAY").Visible = False



            grvDS.Columns("MS_MAY").Width = 70
            grvDS.Columns("TEN_MAY").Width = 100
            grvDS.Columns("TEN_BO_PHAN").Width = 77
            grvDS.Columns("MS_BO_PHAN").Width = 77
            grvDS.Columns("TEN_TS_GSTT").Width = 190
            grvDS.Columns("TEN_DV_DO").Width = 70
            grvDS.Columns("GIA_TRI").Width = 60

            grvDS.Columns("MS_MAY").OptionsColumn.ReadOnly = True
            grvDS.Columns("TEN_MAY").OptionsColumn.ReadOnly = True
            grvDS.Columns("TEN_BO_PHAN").OptionsColumn.ReadOnly = True
            grvDS.Columns("MS_BO_PHAN").OptionsColumn.ReadOnly = True
            grvDS.Columns("TEN_TS_GSTT").OptionsColumn.ReadOnly = True
            grvDS.Columns("TEN_DV_DO").OptionsColumn.ReadOnly = True

            grvDS_FocusedRowChanged(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    Sub HienThi(ByVal BangTam As DataTable)
        Try
            For i As Integer = 0 To btLuuDL.Rows.Count - 1
                Dim MSMAY As String = btLuuDL.Rows(i).Item("MS_TS_GSTT")
                For j As Integer = 0 To tbTam.Rows.Count - 1
                    Dim MAY As String = tbTam.Rows(j)("MS_MAY").ToString()
                    If tbTam.Rows(j)("MS_TS_GSTT") = 855 Then
                        i = i
                    End If

                    If tbTam.Rows(j)("MS_MAY").Equals(btLuuDL.Rows(i).Item("MS_MAY")) And
                        tbTam.Rows(j)("MS_TS_GSTT").Equals(btLuuDL.Rows(i).Item("MS_TS_GSTT")) And
                        tbTam.Rows(j)("MS_BO_PHAN").Equals(btLuuDL.Rows(i).Item("MS_BO_PHAN")) Then
                        Try
                            Try
                                tbTam.Rows(j)("GIA_TRI") = btLuuDL.Rows(i).Item("GIA_TRI_DO").ToString()
                            Catch ex As Exception
                                tbTam.Rows(j)("GIA_TRI") = btLuuDL.Rows(i).Item("GIA_TRI").ToString()
                            End Try
                        Catch ex As Exception

                        End Try

                        tbTam.Rows(j)("MS_TT") = btLuuDL.Rows(i).Item("MS_TT").ToString()
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

        'Try
        '    For i As Integer = 0 To BangTam.Rows.Count - 1
        '        Dim MSMAY As String = BangTam.Rows(i).Item("MS_TS_GSTT")
        '        For j As Integer = 0 To tbTam.Rows.Count - 1
        '            'Dim MAY As String = tbTam.Rows(j)("MS_TS_GSTT").ToString()
        '            Dim MAY As String = tbTam.Rows(j)("MS_MAY").ToString()
        '            If tbTam.Rows(j)("MS_TS_GSTT") = 855 Then
        '                i = i
        '            End If
        '            If tbTam.Rows(j)("MS_MAY").Equals(BangTam.Rows(i).Item("MS_MAY")) And
        '                tbTam.Rows(j)("MS_TS_GSTT").Equals(BangTam.Rows(i).Item("MS_TS_GSTT")) And
        '                tbTam.Rows(j)("MS_BO_PHAN").Equals(BangTam.Rows(i).Item("MS_BO_PHAN")) Then
        '                If String.IsNullOrEmpty(tbTam.Rows(j)("GIA_TRI").ToString) Then
        '                    Try
        '                        Try
        '                            tbTam.Rows(j)("GIA_TRI") = BangTam.Rows(i).Item("GIA_TRI_DO").ToString()
        '                        Catch ex As Exception
        '                            tbTam.Rows(j)("GIA_TRI") = BangTam.Rows(i).Item("GIA_TRI").ToString()
        '                        End Try
        '                    Catch ex As Exception
        '                        XtraMessageBox.Show(ex.Message)
        '                    End Try
        '                End If
        '                tbTam.Rows(j)("MS_TT") = BangTam.Rows(i).Item("MS_TT").ToString()
        '            End If
        '        Next
        '    Next
        'Catch ex As Exception

        'End Try

    End Sub
#End Region
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub



    Private Sub BtnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Dim dtTH As New DataTable
        dtTH = tbTam.Copy
        dtTH.DefaultView.RowFilter = "1=1"
        Dim index As Integer = -1
        Dim count As Integer = 0
        Dim sBT As String = "BT_GSDL_DATA" & Commons.Modules.UserName
        Dim sBTGSTT As String = "BT_GSDL_DL" & Commons.Modules.UserName

        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTH, "")
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTGSTT, _tDinhLuong, "")
        Dim sSql As String
        sSql = " UPDATE " & sBTGSTT & " SET GIA_TRI_DO = T1.GIA_TRI
                    FROM            " & sBT & " AS T1 INNER JOIN
                                             dbo." & sBTGSTT & " AS T2 ON T1.MS_MAY = T2.MS_MAY AND T1.MS_TS_GSTT = T2.MS_TS_GSTT AND T1.MS_BO_PHAN = T2.MS_BO_PHAN

                    INSERT INTO " & sBTGSTT & "(STT, MS_MAY, TEN_MAY, MS_BO_PHAN, MS_TT, TEN_BO_PHAN, MS_TS_GSTT, TEN_TS_GSTT, GIA_TRI_DO, TEN_GT, STT_BP, TG_TT, THOI_GIAN , CACH_THUC_HIEN, TIEU_CHUAN_KT,YEU_CAU_DUNG_CU, YEU_CAU_NS, PATH_HD)
                    SELECT (select TOP 1 MS_TT from dbo.CAU_TRUC_THIET_BI_TS_GSTT T2
	                    where  MS_MAY=T1.MS_MAY AND MS_BO_PHAN=T1.MS_BO_PHAN AND MS_TS_GSTT=T1.MS_TS_GSTT
	                    AND GIA_TRI_DUOI <= T1.GIA_TRI and T1.GIA_TRI <= GIA_TRI_TREN),
                    T1.MS_MAY, T1.TEN_MAY, T1.MS_BO_PHAN, T1.MS_TT,  T1.MS_BO_PHAN + ': ' + T1.TEN_BO_PHAN, T1.MS_TS_GSTT, T1.TEN_TS_GSTT, T1.GIA_TRI, 
                    (select TOP 1 TEN_GT from dbo.CAU_TRUC_THIET_BI_TS_GSTT T3
	                    where  MS_MAY=T1.MS_MAY AND MS_BO_PHAN=T1.MS_BO_PHAN AND MS_TS_GSTT=T1.MS_TS_GSTT
	                    AND GIA_TRI_DUOI <= T1.GIA_TRI and T1.GIA_TRI <= GIA_TRI_TREN) AS
                    TEN_GT, STT_BP, T6.THOI_GIAN AS TG_TT,  T6.THOI_GIAN , T6.CACH_THUC_HIEN, T6.TIEU_CHUAN_KT, T6.YEU_CAU_DUNG_CU, T6.YEU_CAU_NS, T6.PATH_HD FROM " & sBT & " T1 INNER JOIN CAU_TRUC_THIET_BI_TS_GSTT T6 ON T1.MS_TS_GSTT = T6.MS_TS_GSTT and T1.MS_BO_PHAN = T6.MS_BO_PHAN and T1.MS_MAY = T6.MS_MAY 
                    and T1.MS_TT = T6.MS_TT 
                    WHERE CONVERT(FLOAT,ISNULL(GIA_TRI,0)) <> 0 AND NOT EXISTS
                    (SELECT * FROM " & sBTGSTT & " T2 WHERE 
                     T1.MS_MAY = T2.MS_MAY AND T1.MS_TS_GSTT = T2.MS_TS_GSTT AND T1.MS_BO_PHAN = T2.MS_BO_PHAN
                    )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


        _tDinhLuong = New DataTable
        _tDinhLuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT STT, MS_MAY, TEN_MAY, MS_BO_PHAN, MS_TT,  TEN_BO_PHAN, MS_TS_GSTT, TEN_TS_GSTT, GIA_TRI_DO, TEN_GT, STT_BP,TG_TT, THOI_GIAN , CACH_THUC_HIEN, TIEU_CHUAN_KT,YEU_CAU_DUNG_CU, YEU_CAU_NS, PATH_HD FROM " & sBTGSTT & " ORDER BY MS_MAY,STT_BP, TEN_TS_GSTT"))

        If (_tDinhLuong.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgVuilongNhapGiatri", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub chkTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTatCa.CheckedChanged
        If cboThietbi.Text.Trim = "" Then Exit Sub
        If chkTatCa.Checked = False Then Exit Sub
        If sMsMay <> "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
        tbTam = New DataTable
        tbTam = New clsChonthongsoGSTTdinhluongController().GetGIA_TRI_DINH_LUONGs(-1, MsMay)
        CreatetxtGiatri()
        Binddata()
        dtNgay.Enabled = False
    End Sub

    Private Sub chkHangmucdenhangGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHangmucdenhangGS.CheckedChanged
        If cboThietbi.Text.Trim = "" Then Exit Sub
        If chkTatCa.Checked = True Then Exit Sub
        'Dim MsMay As String
        'If sMsMay <> "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay tbTam = New DataTable
        'tbTam = New clsChonthongsoGSTTdinhluongController().MGetGIA_TRI_DINH_LUONGsDN(-1, MsMay, dtNgay.DateTime)
        CreatetxtGiatri()
        Binddata()
        dtNgay.Enabled = True
    End Sub

    Private Sub dtNgay_EditValueChanged(sender As Object, e As EventArgs) Handles dtNgay.EditValueChanged
        'Try

        '    If cboThietbi.Text.Trim = "" Then Exit Sub
        '    Dim MsMay As String
        '    If sMsMay <> "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay tbTam = New DataTable
        '    tbTam = New clsChonthongsoGSTTdinhluongController().MGetGIA_TRI_DINH_LUONGsDN(-1, MsMay, dtNgay.DateTime)
        '    CreatetxtGiatri()
        '    Binddata()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub cboLoaithietbi_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaithietbi.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        Commons.Modules.SQLString = "0LOADLTB"
        LoadcboThietbi()
        LoadcboThongsogiamsat()
        Commons.Modules.SQLString = ""
        Binddata()
    End Sub

    Private Sub cboThietbi_EditValueChanged(sender As Object, e As EventArgs) Handles cboThietbi.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If Commons.Modules.SQLString = "0LOADLTB" Then Exit Sub
        Commons.Modules.SQLString = "0LOADTB"
        LoadcboThongsogiamsat()
        Commons.Modules.SQLString = ""
        Binddata()
    End Sub

    Private Sub cboThongsogiamsat_EditValueChanged(sender As Object, e As EventArgs) Handles cboThongsogiamsat.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If Commons.Modules.SQLString = "0LOADLTB" Then Exit Sub
        If Commons.Modules.SQLString = "0LOADTB" Then Exit Sub
        Binddata()
    End Sub

    Private Sub cboDiadiem_EditValueChanged(sender As Object, e As EventArgs)
        LoadcboLoaithietbi()
        LoadcboThietbi()
        LoadcboThongsogiamsat()
        Binddata()
    End Sub

    Private Sub grvDS_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDS.FocusedRowChanged
        If Commons.Modules.SQLString = "0LOADLUOI" Then Exit Sub

        Try
            Dim tsgs As String = grvDS.GetFocusedRowCellValue("MS_TS_GSTT") 'grdDanhsachTSGSTT.Rows(index).Cells("MS_TS_GSTT").Value.ToString()
            Dim may As String = grvDS.GetFocusedRowCellValue("MS_MAY") 'grdDanhsachTSGSTT.Rows(index).Cells("MS_MAY").Value.ToString
            Dim bophan As String = grvDS.GetFocusedRowCellValue("MS_BO_PHAN") ' grdDanhsachTSGSTT.Rows(index).Cells("MS_BO_PHAN").Value.ToString


            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GETGIA_TRI_DL", tsgs, may, bophan))

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdGiaTri, grvGiaTri, dt, True, True, True, False, True, Me.Name)

            grvGiaTri.Columns("GIA_TRI_DUOI").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
            grvGiaTri.Columns("GIA_TRI_DUOI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grvGiaTri.Columns("GIA_TRI_TREN").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
            grvGiaTri.Columns("GIA_TRI_TREN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            grvGiaTri.Columns("GIA_TRI_DUOI").Width = 50
            grvGiaTri.Columns("GIA_TRI_TREN").Width = 50
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvDS_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvDS.ValidateRow, grvGiaTri.ValidateRow
        If BtnThoat.Focused Then
            Exit Sub
        End If
        'If e.ColumnIndex = 8 Then

        If Not grvDS.GetFocusedRowCellValue("GIA_TRI") Is Nothing Then
            If Not IsNumeric(grvDS.GetFocusedRowCellValue("GIA_TRI")) And grvDS.GetFocusedRowCellValue("GIA_TRI").ToString().Trim() <> "" Then
                grvDS.SetColumnError(grvDS.Columns("GIA_TRI"), "Error")
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "Msgnotnumber", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvDS.SetColumnError(grvDS.Columns("GIA_TRI"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgnotnumber", Commons.Modules.TypeLanguage))
                e.Valid = False
                Exit Sub
            End If
            Try
                Dim tsgs As String = grvDS.GetFocusedRowCellValue("MS_TS_GSTT").ToString()
                Dim may As String = grvDS.GetFocusedRowCellValue("MS_MAY")
                Dim bophan As String = grvDS.GetFocusedRowCellValue("MS_BO_PHAN")
                Dim giatri As String = grvDS.GetFocusedRowCellValue("GIA_TRI")
                Dim MSTT As String = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GETGIA_TRI_DINH_LUONG", grvDS.GetFocusedRowCellValue("MS_TS_GSTT").ToString(), grvDS.GetFocusedRowCellValue("MS_MAY").ToString(), grvDS.GetFocusedRowCellValue("MS_BO_PHAN").ToString(), grvDS.GetFocusedRowCellValue("GIA_TRI"))
                If Not MSTT Is Nothing Then
                    grvDS.SetFocusedRowCellValue("MS_TT", MSTT)
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "Msgkhongnamtrongkhoanggiatri", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvDS.SetColumnError(grvDS.Columns("GIA_TRI"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgkhongnamtrongkhoanggiatri", Commons.Modules.TypeLanguage))
                    e.Valid = False
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
        End If

        grvDS.SetColumnError(grvDS.Columns("GIA_TRI"), "")
    End Sub

    Private Sub grvDS_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvDS.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvDS_InvalidValueException(sender As Object, e As Controls.InvalidValueExceptionEventArgs) Handles grvDS.InvalidValueException

    End Sub
End Class