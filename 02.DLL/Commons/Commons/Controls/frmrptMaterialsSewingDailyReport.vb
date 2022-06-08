
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptMaterialsSewingDailyReport
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Private vListBPCP As String = ""
    Private tbVTPT As System.Data.DataTable
    Private Sub frmrptMaterialsSewingDailyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        LOADKHO()
        'LoadDSBPCP()
        'loadVTPT(GetListBPCPChon())
        CreatTableTMP()
    End Sub

    Sub LoadDSBPCP()
        Dim vtb As New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_MATERIAL_SEWING_BPCP", vTuNgay, vDenNgay, cboKho.SelectedValue))
        vtb.Columns("CHON").ReadOnly = False
        grdListBPCP.AutoGenerateColumns = False
        grdListBPCP.DataSource = vtb
        grdListBPCP.Columns("MS_BP_CHIU_PHI").DataPropertyName = "MS_BP_CHIU_PHI"
        grdListBPCP.Columns("TEN_BP_CHIU_PHI").DataPropertyName = "TEN_BP_CHIU_PHI"
        grdListBPCP.Columns("CHON").DataPropertyName = "CHON"
        grdVTPT.DataSource = Nothing
    End Sub

    Sub LoadAllVTPT()
        tbVTPT = New System.Data.DataTable()
        tbVTPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_MATERIAL_SEWING_VTPT1", vTuNgay, vDenNgay, cboKho.SelectedValue))
        grdVTPT.AutoGenerateColumns = False
        tbVTPT.Columns("CHON_VTPT").ReadOnly = False
        grdVTPT.DataSource = tbVTPT
        grdVTPT.Columns("CHON_VTPT").ReadOnly = False
        'grdVTPT.Columns("CHON_VTPT").DataPropertyName = "CHON_VTPT"

        'grdVTPT.Columns("MS_PT").DataPropertyName = "MS_PT"
        'grdVTPT.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        'grdVTPT.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
        'grdVTPT.Columns("CHON_VTPT").ReadOnly = False
    End Sub

    Sub loadVTPT(ByVal vListBP As String)
        Dim bpcp As String = String.Empty
        For Each row As DataGridViewRow In grdListBPCP.Rows
            If row.Cells("CHON").Value = True Then
                bpcp = bpcp + "," + row.Cells("MS_BP_CHIU_PHI").Value.ToString()
            End If
        Next
        If (Not bpcp Is Nothing) And (bpcp <> "") Then

            tbVTPT.DefaultView.RowFilter = "MS_BP_CHIU_PHI in (" + bpcp.Substring(1, bpcp.Length - 1) + ")"
            tbVTPT.Columns("CHON_VTPT").ReadOnly = False
            grdVTPT.AutoGenerateColumns = False
            grdVTPT.DataSource = tbVTPT.DefaultView
            grdVTPT.Columns("CHON_VTPT").ReadOnly = False
            'grdVTPT.Columns("MS_PT").DataPropertyName = "MS_PT"
            'grdVTPT.Columns("TEN_PT").DataPropertyName = "TEN_PT"
            'grdVTPT.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
        Else
            grdVTPT.DataSource = Nothing
        End If
    End Sub

    Sub LOADKHO()
        cboKho.Value = "MS_KHO"
        cboKho.Display = "TEN_KHO"
        cboKho.StoreName = "H_GET_DATA_MATERIAL_SEWING_KHO"
        cboKho.BindDataSource()
    End Sub

    Sub CreatTableTMP()
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table dbo.LIST_VTPT_TMP" + Commons.Modules.UserName)
        Catch ex As Exception
        End Try

        Dim str As String = ""
        str = "CREATE TABLE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName + "( MS_PT NVARCHAR(30), CHON BIT )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Function GetListBPCPChon() As String
        Dim vls As String = ""
        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            If grdListBPCP.Rows(i).Cells("CHON").Value = True Then
                If vls = "" Then
                    vls = "'" + grdListBPCP.Rows(i).Cells("MS_BP_CHIU_PHI").Value.ToString + "'"
                Else
                    vls = vls + ",'" + grdListBPCP.Rows(i).Cells("MS_BP_CHIU_PHI").Value.ToString + "'"
                End If
            End If
        Next
        If vls = "" Then
            Return "''"
        Else
            Return vls
        End If
        Return vls
    End Function

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        If CheckSelectBPCP() = False Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "CHUA_CHON_BPCP", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        If CheckChonVT() = False Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "CHUA_CHON_VTPT", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        'Load data
        Dim STR As String = ""
        STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        For Each ir As DataRow In tbVTPT.Rows
            If ir("CHON_VTPT") = True Then
                STR = "INSERT INTO dbo.LIST_VTPT_TMP" + Commons.Modules.UserName + "(MS_PT,CHON) VALUES(N'" + ir("MS_PT").ToString + "',1)"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
            End If
        Next


        Dim vData As New System.Data.DataTable
        vData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_MATERIAL_SEWING_DR", vTuNgay, vDenNgay, GetListBPCPChon(), Commons.Modules.UserName, cboKho.SelectedValue))

        If vData.Rows.Count = 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "KO_CO_DL_DE_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Dim obj As frmReportViews_SewingDaily = New frmReportViews_SewingDaily()
        obj.vtbData = vData
        obj.tieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD1", Commons.Modules.TypeLanguage)

        obj.vMonth = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "tungay", Commons.Modules.TypeLanguage) & " : " & vTuNgay & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "dengay", Commons.Modules.TypeLanguage) & " : " & vDenNgay
        obj.warehouse = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD2", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim _column As String = ""
        Dim _col_group1 As String = ""
        Dim _col_group2 As String = ""
        Dim _col_thanh_tien As String = ""
        Dim _unit As String = ""
        Dim _qty As String = ""
        For Each col As DataColumn In vData.Columns
            _column = col.ColumnName
            Select Case _column
                Case "NGAY"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RNGAY", Commons.Modules.TypeLanguage)
                Case "TEN_BP_CHIU_PHI"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RBO_PHAN", Commons.Modules.TypeLanguage)
                Case "MS_PT"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PT", Commons.Modules.TypeLanguage)
                Case "TEN_PT"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTEN_PT", Commons.Modules.TypeLanguage)
                Case "QUY_CACH"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RQUY_CACH", Commons.Modules.TypeLanguage)
                Case "TEN_1"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RDVT", Commons.Modules.TypeLanguage)
                Case "MS_DH_NHAP_PT"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PHIEU_NHAP", Commons.Modules.TypeLanguage)
                Case "SO_PHIEU_XN"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PHIEU_XUAT", Commons.Modules.TypeLanguage)
                Case "SO_LUONG_THUC_XUAT"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RSO_LUONG", Commons.Modules.TypeLanguage)
                    _qty = col.ColumnName
                Case "DON_GIA"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RDON_GIA", Commons.Modules.TypeLanguage)
                    _unit = col.ColumnName
                Case "THANH_TIEN"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTHANH_TIEN", Commons.Modules.TypeLanguage)
                    _col_thanh_tien = col.ColumnName
                Case "NGUOI_NHAN"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RNGUOI_NHAN", Commons.Modules.TypeLanguage)
                Case "TEN_LOAI_VT_TV"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTEN_LOAI_VT_TV", Commons.Modules.TypeLanguage)
                    _col_group1 = col.ColumnName
                Case "TEN_CLASS"
                    col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTEN_CLASS", Commons.Modules.TypeLanguage)
                    _col_group2 = col.ColumnName
            End Select
        Next
        obj.grdView.DataSource = vData

        obj.grvView.PopulateColumns()
        obj.grvView.OptionsView.ColumnAutoWidth = True
        obj.grvView.OptionsView.AllowHtmlDrawHeaders = True
        obj.grvView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap


        obj.grvView.Columns(_col_group1).Group()
        obj.grvView.Columns(_col_group2).Group()
        obj.grvView.ExpandAllGroups()

        obj.grvView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, _col_thanh_tien, obj.grvView.Columns(_col_thanh_tien), "{0:N2}")})
        obj.grvView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, _qty, obj.grvView.Columns(_qty), "{0:N2}")})
        'obj.grvView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, _col_thanh_tien, obj.grvView.Columns(_unit), "{0:N2}")})
        obj.ShowDialog()
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'Dim ExcelApp As New Excel.Application
        'Dim ExcelBooks As Excel.Workbook
        'Dim ExcelSheets As Excel.Worksheet
        'ExcelApp.Visible = False
        'ExcelBooks = ExcelApp.Workbooks.Add
        'ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        'With ExcelSheets
        '    .Columns(1).ColumnWidth = 15
        '    .Columns(2).ColumnWidth = 20
        '    .Columns(3).ColumnWidth = 20
        '    .Columns(4).ColumnWidth = 20
        '    .Columns(5).ColumnWidth = 20
        '    .Columns(6).ColumnWidth = 6
        '    .Columns(7).ColumnWidth = 12
        '    .Columns(8).ColumnWidth = 12
        '    .Columns(9).ColumnWidth = 8
        '    .Columns(10).ColumnWidth = 8
        '    .Columns(11).ColumnWidth = 8
        '    .Columns(12).ColumnWidth = 8
        'End With

        'With ExcelSheets
        '    .Range("A1", "D1").Font.Bold = True
        '    .Range("A1", "D1").Merge(True)
        '    .Range("A1", "D1").MergeCells = True
        '    .Range("A1", "D1").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD1", commons.Modules.TypeLanguage)

        '    .Range("A2", "D2").Font.Bold = True
        '    .Range("A2", "D2").Merge(True)
        '    .Range("A2", "D2").MergeCells = True
        '    .Range("A2", "D2").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD2", commons.Modules.TypeLanguage)

        '    .Range("A3", "D3").Font.Bold = True
        '    .Range("A3", "D3").Merge(True)
        '    .Range("A3", "D3").MergeCells = True
        '    .Range("A3", "D3").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD3", commons.Modules.TypeLanguage)

        '    .Range("A4", "D4").Font.Bold = True
        '    .Range("A4", "D4").Merge(True)
        '    .Range("A4", "D4").MergeCells = True
        '    .Range("A4", "D4").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TD4", commons.Modules.TypeLanguage)
        'End With

        'With ExcelSheets
        '    .Range("A6", "A6").Font.Bold = True
        '    .Range("A6", "A6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RNGAY", commons.Modules.TypeLanguage)
        '    .Range("A6", "A6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("A6", "A6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("A6", "A6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("B6", "B6").Font.Bold = True
        '    .Range("B6", "B6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RBO_PHAN", commons.Modules.TypeLanguage)
        '    .Range("B6", "B6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("B6", "B6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("B6", "B6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("C6", "C6").Font.Bold = True
        '    .Range("C6", "C6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PT", commons.Modules.TypeLanguage)
        '    .Range("C6", "C6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("C6", "C6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("C6", "C6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


        '    .Range("D6", "D6").Font.Bold = True
        '    .Range("D6", "D6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTEN_PT", commons.Modules.TypeLanguage)
        '    .Range("D6", "D6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("D6", "D6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("D6", "D6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("E6", "E6").Font.Bold = True
        '    .Range("E6", "E6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RQUY_CACH", commons.Modules.TypeLanguage)
        '    .Range("E6", "E6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("E6", "E6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("E6", "E6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("F6", "F6").Font.Bold = True
        '    .Range("F6", "F6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RDVT", commons.Modules.TypeLanguage)
        '    .Range("F6", "F6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("F6", "F6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("F6", "F6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("G6", "G6").Font.Bold = True
        '    .Range("G6", "G6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PHIEU_NHAP", commons.Modules.TypeLanguage)
        '    .Range("G6", "G6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("G6", "G6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("G6", "G6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("H6", "H6").Font.Bold = True
        '    .Range("H6", "H6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RMS_PHIEU_XUAT", commons.Modules.TypeLanguage)
        '    .Range("H6", "H6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("H6", "H6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("H6", "H6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("I6", "I6").Font.Bold = True
        '    .Range("I6", "I6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RSO_LUONG", commons.Modules.TypeLanguage)
        '    .Range("I6", "I6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("I6", "I6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("I6", "I6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("J6", "J6").Font.Bold = True
        '    .Range("J6", "J6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RDON_GIA", commons.Modules.TypeLanguage)
        '    .Range("J6", "J6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("J6", "J6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("J6", "J6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("K6", "K6").Font.Bold = True
        '    .Range("K6", "K6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTHANH_TIEN", commons.Modules.TypeLanguage)
        '    .Range("K6", "K6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("K6", "K6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("K6", "K6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        '    .Range("L6", "L6").Font.Bold = True
        '    .Range("L6", "L6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RNGUOI_NHAN", commons.Modules.TypeLanguage)
        '    .Range("L6", "L6").VerticalAlignment = XlVAlign.xlVAlignCenter
        '    .Range("L6", "L6").HorizontalAlignment = XlHAlign.xlHAlignCenter
        '    .Range("L6", "L6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        'End With

        'Dim vDtLoaiVT As New System.Data.DataTable
        'vDtLoaiVT = vData.DefaultView.ToTable(True, "MS_LOAI_VT", "TEN_LOAI_VT_TV")

        'Dim vRowIndex As Integer = 6
        'Dim vTongTien As Double = 0


        'For Each vrLoaiVt As DataRow In vDtLoaiVT.Rows

        '    Dim vtbListVtPT As New DataView(vData, "MS_LOAI_VT = '" + vrLoaiVt("MS_LOAI_VT").ToString + "'", "NGAY", DataViewRowState.CurrentRows)

        '    vRowIndex = vRowIndex + 1

        '    With ExcelSheets
        '        .Range("A" & vRowIndex, "L" & vRowIndex).Font.Bold = True
        '        .Range("A" & vRowIndex, "L" & vRowIndex).Merge(True)
        '        .Range("A" & vRowIndex, "L" & vRowIndex).MergeCells = True
        '        .Range("A" & vRowIndex, "L" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '        .Range("A" & vRowIndex, "L" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '        .Range("A" & vRowIndex, "L" & vRowIndex).Value = vrLoaiVt("TEN_LOAI_VT_TV").ToString
        '    End With
        '    Dim vTongTienLoai As Double = 0
        '    Dim vDtClass As New System.Data.DataTable
        '    vData.DefaultView.RowFilter = ""
        '    vDtClass = vData.DefaultView.ToTable(True, "MS_CLASS", "TEN_CLASS")
        '    Dim vDvClass As New System.Data.DataView(vDtClass, "", "MS_CLASS", DataViewRowState.CurrentRows)


        '    vDtClass = vDvClass.ToTable()

        '    For Each vrClassVt As DataRow In vDtClass.Rows
        '        Dim sclass = vrClassVt("MS_CLASS").ToString

        '        If sclass <> "" Then
        '            vData.DefaultView.RowFilter = "MS_LOAI_VT = '" + vrLoaiVt("MS_LOAI_VT").ToString + "' AND MS_CLASS=" + sclass
        '        Else
        '            vData.DefaultView.RowFilter = "MS_LOAI_VT = '" + vrLoaiVt("MS_LOAI_VT").ToString + "' AND MS_CLASS IS NULL"
        '        End If

        '        If vData.DefaultView.ToTable.Rows.Count > 0 Then

        '            vRowIndex = vRowIndex + 1

        '            With ExcelSheets
        '                .Range("A" & vRowIndex, "L" & vRowIndex).Font.Bold = True
        '                .Range("A" & vRowIndex, "L" & vRowIndex).Merge(True)
        '                .Range("A" & vRowIndex, "L" & vRowIndex).MergeCells = True
        '                .Range("A" & vRowIndex, "L" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                .Range("A" & vRowIndex, "L" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                .Range("A" & vRowIndex, "L" & vRowIndex).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RCLASS", commons.Modules.TypeLanguage) & vrClassVt("TEN_CLASS").ToString
        '            End With


        '            Dim vTongTienclass As Double = 0

        '            For Each vrow As DataRow In vData.DefaultView.ToTable.Rows

        '                vRowIndex = vRowIndex + 1

        '                With ExcelSheets
        '                    .Range("A" & vRowIndex, "A" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("A" & vRowIndex, "A" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("A" & vRowIndex, "A" & vRowIndex).Value = vrow("NGAY") '.ToString.Substring(0, 2) & "-" & vrow("NGAY").ToString.Substring(3, 2)
        '                    .Range("A" & vRowIndex, "A" & vRowIndex).NumberFormat = "dd-MM"

        '                    .Range("B" & vRowIndex, "B" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("B" & vRowIndex, "B" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("B" & vRowIndex, "B" & vRowIndex).Value = vrow("TEN_BP_CHIU_PHI").ToString

        '                    .Range("C" & vRowIndex, "C" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("C" & vRowIndex, "C" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("C" & vRowIndex, "C" & vRowIndex).Value = vrow("MS_PT").ToString

        '                    .Range("D" & vRowIndex, "D" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("D" & vRowIndex, "D" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("D" & vRowIndex, "D" & vRowIndex).Value = vrow("TEN_PT").ToString

        '                    .Range("E" & vRowIndex, "E" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("E" & vRowIndex, "E" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("E" & vRowIndex, "E" & vRowIndex).Value = vrow("QUY_CACH").ToString

        '                    .Range("F" & vRowIndex, "F" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("F" & vRowIndex, "F" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("F" & vRowIndex, "F" & vRowIndex).Value = vrow("TEN_1").ToString

        '                    .Range("G" & vRowIndex, "G" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("G" & vRowIndex, "G" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '                    .Range("G" & vRowIndex, "G" & vRowIndex).Value = vrow("MS_DH_NHAP_PT").ToString

        '                    .Range("H" & vRowIndex, "H" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("H" & vRowIndex, "H" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                    .Range("H" & vRowIndex, "H" & vRowIndex).Value = vrow("SO_PHIEU_XN").ToString

        '                    .Range("I" & vRowIndex, "I" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("I" & vRowIndex, "I" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                    .Range("I" & vRowIndex, "I" & vRowIndex).Value = vrow("SO_LUONG_THUC_XUAT").ToString

        '                    .Range("J" & vRowIndex, "J" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("J" & vRowIndex, "J" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                    .Range("J" & vRowIndex, "J" & vRowIndex).Value = vrow("DON_GIA").ToString
        '                    .Range("J" & vRowIndex, "J" & vRowIndex).NumberFormat = "#,##0.00"

        '                    .Range("K" & vRowIndex, "K" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("K" & vRowIndex, "K" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                    .Range("K" & vRowIndex, "K" & vRowIndex).Value = vrow("THANH_TIEN").ToString
        '                    .Range("K" & vRowIndex, "K" & vRowIndex).NumberFormat = "#,##0.00"

        '                    .Range("L" & vRowIndex, "L" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                    .Range("L" & vRowIndex, "L" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                    .Range("L" & vRowIndex, "L" & vRowIndex).Value = vrow("NGUOI_NHAN").ToString

        '                    If vrow("THANH_TIEN").ToString <> "" Then
        '                        vTongTienclass = vTongTienclass + vrow("THANH_TIEN")
        '                        vTongTienLoai = vTongTienLoai + vrow("THANH_TIEN")
        '                        vTongTien = vTongTien + vrow("THANH_TIEN")
        '                    Else
        '                        vTongTienclass = 0
        '                        vTongTienLoai = 0
        '                        vTongTien = 0
        '                    End If
        '                End With
        '            Next


        '            vRowIndex = vRowIndex + 1

        '            With ExcelSheets
        '                .Range("A" & vRowIndex, "J" & vRowIndex).Font.Bold = True
        '                .Range("A" & vRowIndex, "J" & vRowIndex).Merge(True)
        '                .Range("A" & vRowIndex, "J" & vRowIndex).MergeCells = True
        '                .Range("A" & vRowIndex, "J" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                .Range("A" & vRowIndex, "J" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                .Range("A" & vRowIndex, "J" & vRowIndex).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTONG_TIEN_CLASS", commons.Modules.TypeLanguage)

        '                .Range("K" & vRowIndex, "K" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                .Range("K" & vRowIndex, "K" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                .Range("K" & vRowIndex, "K" & vRowIndex).Value = vTongTienclass.ToString
        '                .Range("K" & vRowIndex, "K" & vRowIndex).NumberFormat = "#,##0.00"

        '                .Range("L" & vRowIndex, "L" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '                .Range("L" & vRowIndex, "L" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '                .Range("L" & vRowIndex, "L" & vRowIndex).Value = ""

        '            End With
        '        End If
        '    Next

        '    vRowIndex = vRowIndex + 1

        '    With ExcelSheets
        '        .Range("A" & vRowIndex, "J" & vRowIndex).Font.Bold = True
        '        .Range("A" & vRowIndex, "J" & vRowIndex).Merge(True)
        '        .Range("A" & vRowIndex, "J" & vRowIndex).MergeCells = True
        '        .Range("A" & vRowIndex, "J" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '        .Range("A" & vRowIndex, "J" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '        .Range("A" & vRowIndex, "J" & vRowIndex).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "RTONG_TIEN_LOAI", commons.Modules.TypeLanguage)

        '        .Range("K" & vRowIndex, "K" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '        .Range("K" & vRowIndex, "K" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '        .Range("K" & vRowIndex, "K" & vRowIndex).Value = vTongTienLoai.ToString
        '        .Range("K" & vRowIndex, "K" & vRowIndex).NumberFormat = "#,##0.00"

        '        .Range("L" & vRowIndex, "L" & vRowIndex).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '        .Range("L" & vRowIndex, "L" & vRowIndex).HorizontalAlignment = XlHAlign.xlHAlignRight
        '        .Range("L" & vRowIndex, "L" & vRowIndex).Value = ""

        '    End With

        'Next

        'With ExcelSheets
        '    .Range("I5", "J5").Font.Bold = True
        '    .Range("I5", "J5").Merge(True)
        '    .Range("I5", "J5").MergeCells = True
        '    .Range("I5", "J5").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '    .Range("I5", "J5").HorizontalAlignment = XlHAlign.xlHAlignRight
        '    .Range("I5", "J5").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "VND", commons.Modules.TypeLanguage)

        '    .Range("K5", "K5").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        '    .Range("K5", "K5").HorizontalAlignment = XlHAlign.xlHAlignRight
        '    .Range("K5", "K5").Value = vTongTien.ToString
        '    .Range("K5", "K5").NumberFormat = "#,##0.00"
        'End With
        'ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Function CheckSelectBPCP() As Boolean
        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            If (grdListBPCP.Rows(i).Cells("CHON").Value = True) Then
                Return True
            End If
        Next
        Return False
    End Function
    Function CheckChonVT()
        Dim row() As DataRow
        tbVTPT = grdVTPT.DataSource
        row = tbVTPT.Select("CHON_VTPT=1")
        If row.Length <= 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
            Exit Sub
        End Try

        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            e.Cancel = True
            Exit Sub
        End If

        Try
            'Dim STR As String = ""
            'STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        Catch ex As Exception
        End Try

        LoadDSBPCP()
        ''LoadAllVTPT()


    End Sub
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
            Exit Sub
        End Try

        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "DN_PHAI_LON_HON_TN", Commons.Modules.TypeLanguage))
            e.Cancel = True
            Exit Sub
        End If

        Try
            'Dim STR As String = ""
            'STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        Catch ex As Exception
        End Try

        LoadDSBPCP()
        LoadAllVTPT()
        'loadVTPT(GetListBPCPChon())

    End Sub

    Private Sub btnChonALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonALL.Click
        'Dim STR As String = ""
        'STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
        'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        For i As Integer = 0 To grdVTPT.Rows.Count - 1
            grdVTPT.Rows(i).Cells("CHON_VTPT").Value = True
            'Str = "INSERT INTO dbo.LIST_VTPT_TMP" + Commons.Modules.UserName + "(MS_PT,CHON) VALUES(N'" + grdVTPT.Rows(i).Cells("MS_PT").Value.ToString + "',1)"
            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
        Next
    End Sub

    Private Sub btnBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChon.Click

        'Dim STR As String = ""
        'STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
        'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)

        For i As Integer = 0 To grdVTPT.Rows.Count - 1
            grdVTPT.Rows(i).Cells("CHON_VTPT").Value = False
        Next
    End Sub

    Private Sub grdListBPCP_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdListBPCP.CellValidating
        ' loadVTPT("")
    End Sub

    Private Sub cboKho_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKho.SelectedIndexChanged
        Try
            Dim STR As String = ""
            STR = "DELETE dbo.LIST_VTPT_TMP" + Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        Catch ex As Exception
        End Try

        Try
            LoadDSBPCP()

            'LoadAllVTPT()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnChonALL1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonall1.Click
        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            grdListBPCP.Rows(i).Cells("CHON").Value = True
        Next
        If grdListBPCP.Rows.Count > 0 Then
            LoadAllVTPT()
        Else
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMaterialsSewingDailyReport", "CHUA_CHON_BPCP", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

    End Sub

    Private Sub btnBoChon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochonall1.Click
        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            grdListBPCP.Rows(i).Cells("CHON").Value = False
        Next
        tbVTPT = New System.Data.DataTable()
        grdVTPT.DataSource = tbVTPT
    End Sub

    Private Sub grdListBPCP_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Try
        '    If grdListBPCP.Rows(e.RowIndex).Cells("CHON").Value = True Then
        '        loadVTPT(grdListBPCP.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value.ToString())
        '    Else
        '        grdVTPT.DataSource = Nothing
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub grdListBPCP_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdListBPCP.CellContentClick
        Try
            If e.ColumnIndex = 1 Then
                LoadAllVTPT()
                Dim _table As System.Data.DataTable = New System.Data.DataTable()
                Dim _table_merge As System.Data.DataTable = New System.Data.DataTable()
                For Each row As DataGridViewRow In grdListBPCP.Rows

                    If Convert.ToBoolean(row.Cells(1).EditedFormattedValue) = True Then
                        Dim _ms As String = row.Cells("MS_BP_CHIU_PHI").Value.ToString()

                        tbVTPT.DefaultView.RowFilter = "MS_BP_CHIU_PHI='" + _ms + "'"
                        _table = tbVTPT.DefaultView.ToTable()

                        _table_merge.Merge(_table)
                    End If


                Next
                grdVTPT.DataSource = _table_merge

            End If




        Catch ex As Exception
            grdVTPT.DataSource = Nothing
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
