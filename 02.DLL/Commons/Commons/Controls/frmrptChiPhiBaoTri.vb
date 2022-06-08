
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient

Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptChiPhiBaoTri
    Dim v_all As DataTable = New DataTable()
    Dim vtbNx As DataTable = New DataTable()
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If dtTu.Value > dtDen.Value Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "TNPhaiNhoHonDN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Dim sNX As String
        Dim sLBT As String
        Dim sMay As String
        sNX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTongTheoNX", Commons.Modules.TypeLanguage)
        sLBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTongTheoLBT", Commons.Modules.TypeLanguage)
        sMay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcMay", Commons.Modules.TypeLanguage)

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vRow As Integer = 2
            Dim vRowSum As Integer = 2
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim cander As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            Dim vFlag As Boolean = False
            Dim vTheo As String = ""
            If (rdoNgay.Checked) Then
                vTheo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTheoNgay", Commons.Modules.TypeLanguage) '"THEO NGÀY"
            Else
                If (rdoTuan.Checked) Then
                    vTheo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTheoTuan", Commons.Modules.TypeLanguage) '"THEO TUẦN"
                Else
                    If rdoThang.Checked Then
                        vTheo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTheoThang", Commons.Modules.TypeLanguage) '"THEO THÁNG"
                    Else
                        If rdoQuy.Checked Then
                            vTheo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTheoQuy", Commons.Modules.TypeLanguage) '"THEO QUÝ"
                        Else
                            vTheo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTheoNam", Commons.Modules.TypeLanguage) '"THEO NĂM"
                        End If
                    End If
                End If
            End If
            With ExcelSheets
                .Columns(1).ColumnWidth = 15
                .Columns(2).ColumnWidth = 15
                .Columns(2).ColumnWidth = 20

                .Range("A2:H2").Merge()
                .Range("A2:H2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A2:H2").Font.Bold = True
                .Cells(vRow, 1).Font.Color = RGB(0, 0, 192)
                .Cells(vRow, 1).Font.Size = 13
                .Cells(vRow, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcChiPhiBTri", Commons.Modules.TypeLanguage) + " (" + vTheo + ") " ' "CHI PHÍ BẢO TRÌ (" & vTheo & ")"
                vRow = vRow + 1

                .Range("B2:C2").Merge()
                .Range("B2:C2").Font.Italic = True
                .Range("B2:C2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcTNgay", Commons.Modules.TypeLanguage) + " :" & dtTu.Value.ToShortDateString().Trim() '"Từ ngày :" & dtTu.Value.ToShortDateString().Trim()
                .Range("D2:E2").Merge()
                .Range("D2:E2").Font.Italic = True
                .Range("D2:E2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 3) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "bcDNgay", Commons.Modules.TypeLanguage) + " :" & dtDen.Value.ToShortDateString().Trim() '"Đến ngày :" & dtDen.Value.ToShortDateString().Trim()

                vRow = vRow + 2

            End With
            Dim vTablemay As DataTable = New DataTable()
            '====================================
            Dim vTableChiPhi As DataTable = New DataTable()
            Dim vselect As String = "SELECT     dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.MS_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, " & _
            " dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG+dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU + dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG" & _
            " + dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV + dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC AS CHI_PHI, '-1' AS MS_N_XUONG " & _
            " FROM         dbo.PHIEU_BAO_TRI INNER JOIN " & _
            " dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
            " WHERE NGAY_BD_KH >= '" & dtTu.Value.ToString("dd/MMM/yyyy") & "' AND NGAY_BD_KH <= '" & dtDen.Value.ToString("dd/MMM/yyyy") & "' AND (TINH_TRANG_PBT = 3 OR TINH_TRANG_PBT = 4 )" & _
            " UNION " & _
            " SELECT     dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, - 1 AS MS_LOAI_BT, dbo.CONG_VIEC_HANG_NGAY.NGAY_TH AS NGAY_BD_KH, " & _
            " dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC + dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT AS CHI_PHI, '-1' AS MS_N_XUONG " & _
            " FROM         dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
            " dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV "
            Dim vsMayselect As String = ""

            For Each vrowmay As DataRow In vtbDsMayChon.Rows
                If vsMayselect = "" Then
                    vsMayselect = "N'" + vrowmay("MS_MAY") + "'"
                Else
                    vsMayselect = vsMayselect + ", N'" + vrowmay("MS_MAY") + "'"
                End If
            Next

            Dim vStr As String = "SELECT * FROM (" + vselect + ")TMP WHERE TMP.MS_MAY IN (" + vsMayselect + ")"

            If chxChonTungMay.Checked = True Then
                vTableChiPhi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStr))
            Else
                vTableChiPhi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vselect))
            End If

            vTableChiPhi.Columns("MS_N_XUONG").MaxLength = 50
            vTableChiPhi.Columns("MS_N_XUONG").ReadOnly = False
            For h As Integer = 0 To vTableChiPhi.Rows.Count - 1
                Dim vRowt As DataRow = vTableChiPhi.Rows(h)
                Dim vSelectnx As String = "SELECT TOP 1 MS_N_XUONG FROM MAY_NHA_XUONG WHERE MS_MAY = N'" & vRowt("MS_MAY") & "' AND NGAY_NHAP <= '" & Convert.ToDateTime(vRowt("NGAY_BD_KH")).ToString("MM/dd/yyyy") & "' ORDER BY NGAY_NHAP DESC "
                Dim vTableNhaxuong As DataTable = New DataTable()
                vTableNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vSelectnx))
                Try
                    vRowt("MS_N_XUONG") = vTableNhaxuong.Rows(0)("MS_N_XUONG")
                Catch ex As Exception
                End Try
            Next
            '========================================
            Dim count As Integer = vtbNx.Rows.Count
            If count > 0 Then
                For j As Integer = 0 To count - 1
                    Dim vList As ArrayList = New ArrayList()


                    With ExcelSheets
                        .Cells(vRow, 1).Font.Bold = True
                        .Cells(vRow, 1).Font.Color = RGB(255, 0, 0)
                        .Cells(vRow, 1).Font.Size = 12
                        .Cells(vRow, 1) = vtbNx.Rows(j)("Ten_n_Xuong")
                        vRow = vRow + 1
                        vRowSum = vRow
                    End With
                    For i As Integer = 0 To gvLoaiBT.Rows.Count - 1
                        If Not gvLoaiBT.Rows(i).Cells("clChonnguyennhan").Value.Equals(DBNull.Value) Then
                            If Convert.ToBoolean(gvLoaiBT.Rows(i).Cells("clChonnguyennhan").Value) Then
                                With ExcelSheets
                                    .Cells(vRow, 2).Font.Bold = True
                                    .Cells(vRow, 2).Font.Color = RGB(168, 12, 128)
                                    .Cells(vRow, 2).Font.Size = 11
                                    .Cells(vRow, 2) = gvLoaiBT.Rows(i).Cells("clLoaiBT").Value.ToString().Trim()
                                    vRow = vRow + 1
                                End With
                                vTablemay = New DataTable()
                                Dim vView As DataView = New DataView(vTableChiPhi, "MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND CHI_PHI > 0  AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & "", "", DataViewRowState.CurrentRows)
                                vTablemay = SelectDistinct(vView.ToTable(), "MS_MAY")
                                Dim vColum As Integer = 2
                                If (rdoNgay.Checked) Then

                                    With ExcelSheets
                                        .Cells(vRow, vColum).Font.Bold = True
                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                        .Cells(vRow, vColum) = sMay '"Máy"
                                        vColum = vColum + 1
                                        Dim vNgay As Date = dtTu.Value
                                        While vNgay <= dtDen.Value
                                            If (Not vFlag) Then
                                                .Columns(vColum).ColumnWidth = 12
                                            End If
                                            .Cells(vRow, vColum).Font.Bold = True
                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow, vColum) = " " & vNgay.ToString("dd/MM/yyyy").Trim() & " "
                                            vColum = vColum + 1
                                            vNgay = vNgay.AddDays(1)
                                        End While

                                        vFlag = True

                                        For k As Integer = 0 To vTablemay.Rows.Count - 1
                                            vColum = 2
                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                            vNgay = dtTu.Value
                                            vColum = vColum + 1
                                            While vNgay <= dtDen.Value
                                                Dim tbTb As DataTable = New DataTable()
                                                Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                tbTb = vViewCP.ToTable()
                                                Dim vChiphi As Integer = 0
                                                For Each vRowsst As DataRow In tbTb.Rows
                                                    Try
                                                        If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).ToString("MM/dd/yyyy").Trim().Equals(vNgay.ToString("MM/dd/yyyy").Trim())) Then
                                                            vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                        End If
                                                    Catch ex As Exception

                                                    End Try
                                                Next
                                                Try
                                                    .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + k + 1, vColum) = vChiphi.ToString().Trim()
                                                Catch ex As Exception
                                                End Try
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddDays(1)
                                            End While
                                        Next
                                        If vTablemay.Rows.Count > 0 Then
                                            vNgay = dtTu.Value
                                            vColum = 3
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2) = sLBT 'Tổng theo loại BT"
                                            While vNgay <= dtDen.Value
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                If (vColum > 2) Then
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                End If
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddDays(1)
                                            End While
                                            vList.Add(vRow + vTablemay.Rows.Count + 1)
                                        End If
                                    End With
                                Else
                                    If (rdoThang.Checked) Then
                                        With ExcelSheets
                                            .Cells(vRow, vColum).Font.Bold = True
                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow, vColum) = sMay   '"Máy"
                                            vColum = vColum + 1
                                            Dim vNgay As Date = dtTu.Value
                                            While vNgay.Year <= dtDen.Value.Year
                                                If vNgay.Year = dtDen.Value.Year Then
                                                    If (vNgay.Month <= dtDen.Value.Month) Then
                                                        If (Not vFlag) Then
                                                            .Columns(vColum).ColumnWidth = 12
                                                        End If
                                                        .Cells(vRow, vColum).Font.Bold = True
                                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow, vColum) = vNgay.Month.ToString() & "/" & vNgay.Year.ToString()
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddMonths(1)
                                                    Else
                                                        Exit While
                                                    End If
                                                Else
                                                    If (Not vFlag) Then
                                                        .Columns(vColum).ColumnWidth = 12
                                                    End If
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow, vColum) = vNgay.Month.ToString() & "/" & vNgay.Year.ToString()
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(1)
                                                End If

                                            End While

                                            vFlag = True

                                            For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                vColum = 2
                                                .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                                vNgay = dtTu.Value
                                                vColum = vColum + 1
                                                While vNgay.Year <= dtDen.Value.Year
                                                    Dim tbTb As DataTable = New DataTable()
                                                    If vNgay.Year = dtDen.Value.Year And vNgay.Month > dtDen.Value.Month Then
                                                        Exit While
                                                    Else
                                                        Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                        tbTb = vViewCP.ToTable()
                                                        Dim vChiphi As Integer = 0
                                                        For Each vRowsst As DataRow In tbTb.Rows
                                                            Try
                                                                If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month = vNgay.Month) Then
                                                                    vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                End If
                                                            Catch ex As Exception

                                                            End Try
                                                        Next
                                                        'Dim strss As String = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (NGAY) = " & vNgay.Month & " AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "                                                    
                                                        Try
                                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + k + 1, vColum) = vChiphi.ToString().Trim()
                                                        Catch ex As Exception
                                                        End Try
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddMonths(1)
                                                    End If

                                                End While
                                            Next
                                            If vTablemay.Rows.Count > 0 Then
                                                vNgay = dtTu.Value
                                                vColum = 3
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2) = sLBT  '"Tổng theo loại BT"
                                                While vNgay.Year <= dtDen.Value.Year
                                                    If (vNgay.Year = dtDen.Value.Year And vNgay.Month > dtDen.Value.Month) Then
                                                        Exit While
                                                    End If
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                    If (vColum > 2) Then
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                    End If
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(1)
                                                End While
                                                vList.Add(vRow + vTablemay.Rows.Count + 1)
                                            End If
                                        End With
                                    Else
                                        If rdoQuy.Checked Then
                                            With ExcelSheets
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow, vColum) = sMay '"Máy"
                                                vColum = vColum + 1

                                                Dim vNgay As Date = dtTu.Value
                                                Dim vMaxMonth As Integer = -1
                                                If (dtDen.Value.Month > 9) Then
                                                    vMaxMonth = 12
                                                Else
                                                    If (dtDen.Value.Month > 6) Then
                                                        vMaxMonth = 9
                                                    Else
                                                        If (dtDen.Value.Month > 3) Then
                                                            vMaxMonth = 6
                                                        Else
                                                            vMaxMonth = 3
                                                        End If
                                                    End If
                                                End If

                                                While vNgay.Year <= dtDen.Value.Year
                                                    If (vNgay.Year = dtDen.Value.Year And vNgay.Month > vMaxMonth) Then
                                                        Exit While
                                                    End If
                                                    If (Not vFlag) Then
                                                        .Columns(vColum).ColumnWidth = 12
                                                    End If
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    If (vNgay.Month > 9) Then
                                                        .Cells(vRow, vColum) = "IV/" & vNgay.Year.ToString()
                                                    Else
                                                        If (vNgay.Month > 6) Then
                                                            .Cells(vRow, vColum) = "III/" & vNgay.Year.ToString()
                                                        Else
                                                            If (vNgay.Month > 3) Then
                                                                .Cells(vRow, vColum) = "II/" & vNgay.Year.ToString()
                                                            Else
                                                                .Cells(vRow, vColum) = "I/" & vNgay.Year.ToString()
                                                            End If
                                                        End If
                                                    End If
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(3)
                                                End While
                                                vFlag = True

                                                For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                    vColum = 2
                                                    .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                                    vNgay = dtTu.Value
                                                    vColum = vColum + 1
                                                    While vNgay.Year <= dtDen.Value.Year
                                                        Dim tbTb As DataTable = New DataTable()
                                                        Dim strss As String = ""
                                                        If (vNgay.Year = dtDen.Value.Year And vNgay.Month > vMaxMonth) Then
                                                            Exit While
                                                        End If
                                                        Dim vChiphi As Integer = 0
                                                        If (vNgay.Month > 9) Then
                                                            Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                            tbTb = vViewCP.ToTable()
                                                            For Each vRowsst As DataRow In tbTb.Rows
                                                                Try
                                                                    If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month >= 10 And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month <= 12) Then
                                                                        vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                    End If
                                                                Catch ex As Exception

                                                                End Try
                                                            Next
                                                            'strss = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (NGAY) >= 10 AND MONTH (NGAY) <= 12 AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "
                                                        Else
                                                            If (vNgay.Month > 6) Then
                                                                Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                                tbTb = vViewCP.ToTable()
                                                                For Each vRowsst As DataRow In tbTb.Rows
                                                                    Try
                                                                        If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month >= 7 And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month <= 9) Then
                                                                            vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                        End If
                                                                    Catch ex As Exception

                                                                    End Try
                                                                Next
                                                                'strss = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (NGAY) >= 7 AND MONTH (NGAY) <= 9 AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "
                                                            Else
                                                                If (vNgay.Month > 3) Then
                                                                    Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                                    tbTb = vViewCP.ToTable()
                                                                    For Each vRowsst As DataRow In tbTb.Rows
                                                                        Try
                                                                            If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month >= 3 And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month <= 6) Then
                                                                                vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                            End If
                                                                        Catch ex As Exception

                                                                        End Try
                                                                    Next
                                                                    ' strss = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (NGAY) >= 3 AND  MONTH (NGAY) <= 6 AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "
                                                                Else
                                                                    Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                                    tbTb = vViewCP.ToTable()
                                                                    For Each vRowsst As DataRow In tbTb.Rows
                                                                        Try
                                                                            If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year And Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Month <= 2) Then
                                                                                vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                            End If
                                                                        Catch ex As Exception

                                                                        End Try
                                                                    Next
                                                                    'strss = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (NGAY) <= 2 AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "
                                                                End If
                                                            End If
                                                        End If

                                                        'tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                        Try
                                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + k + 1, vColum) = vChiphi.ToString().Trim()
                                                        Catch ex As Exception
                                                        End Try
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddMonths(3)

                                                    End While
                                                Next
                                                If vTablemay.Rows.Count > 0 Then
                                                    vNgay = dtTu.Value
                                                    vColum = 3
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2) = sLBT  ' "Tổng theo loại BT"
                                                    While vNgay.Year <= dtDen.Value.Year
                                                        If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= vMaxMonth) Then
                                                            Exit While
                                                        End If
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                        If (vColum > 2) Then
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                        End If
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddMonths(3)
                                                    End While
                                                    vList.Add(vRow + vTablemay.Rows.Count + 1)
                                                End If
                                            End With
                                        Else
                                            If rdoNam.Checked Then
                                                With ExcelSheets
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow, vColum) = sMay   '"Máy"
                                                    vColum = vColum + 1
                                                    Dim vNgay As Date = dtTu.Value
                                                    While vNgay.Year <= dtDen.Value.Year
                                                        If (Not vFlag) Then
                                                            .Columns(vColum).ColumnWidth = 12
                                                        End If
                                                        .Cells(vRow, vColum).Font.Bold = True
                                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow, vColum) = vNgay.Year.ToString()
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddYears(1)
                                                    End While

                                                    vFlag = True

                                                    For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                        vColum = 2
                                                        .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                                        vNgay = dtTu.Value
                                                        vColum = vColum + 1
                                                        While vNgay.Year <= dtDen.Value.Year
                                                            Dim tbTb As DataTable = New DataTable()
                                                            Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                            tbTb = vViewCP.ToTable()
                                                            Dim vChiphi As Integer = 0
                                                            For Each vRowsst As DataRow In tbTb.Rows
                                                                Try
                                                                    If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")).Year = vNgay.Year) Then
                                                                        vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                    End If
                                                                Catch ex As Exception

                                                                End Try
                                                            Next
                                                            'Dim strss As String = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND YEAR (NGAY) = " & vNgay.Year & ") GROUP BY MS_MAY "
                                                            'tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                            Try
                                                                .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                                .Cells(vRow + k + 1, vColum) = vChiphi.ToString().Trim()
                                                            Catch ex As Exception
                                                            End Try
                                                            vColum = vColum + 1
                                                            vNgay = vNgay.AddYears(1)
                                                        End While
                                                    Next
                                                    If vTablemay.Rows.Count > 0 Then
                                                        vNgay = dtTu.Value
                                                        vColum = 3
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2) = sLBT 'Tổng theo loại BT"
                                                        While vNgay.Year <= dtDen.Value.Year
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                            If (vColum > 2) Then
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                            End If
                                                            vColum = vColum + 1
                                                            vNgay = vNgay.AddYears(1)
                                                        End While
                                                        vList.Add(vRow + vTablemay.Rows.Count + 1)
                                                    End If
                                                End With

                                            Else
                                                If rdoTuan.Checked Then
                                                    With ExcelSheets
                                                        .Cells(vRow, vColum).Font.Bold = True
                                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow, vColum) = sMay ' "Máy"
                                                        vColum = vColum + 1
                                                        Dim vNgay As Date = dtTu.Value
                                                        While vNgay <= dtDen.Value
                                                            If (Not vFlag) Then
                                                                .Columns(vColum).ColumnWidth = 12
                                                            End If
                                                            .Cells(vRow, vColum).Font.Bold = True
                                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow, vColum) = cander.GetWeekOfYear(vNgay, CalendarWeekRule.FirstDay, DayOfWeek.Friday).ToString() & "(" & vNgay.Year.ToString() & ")"
                                                            vColum = vColum + 1
                                                            vNgay = vNgay.AddDays(7)
                                                        End While

                                                        vFlag = True

                                                        For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                            vColum = 2
                                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                                            vNgay = dtTu.Value
                                                            vColum = vColum + 1
                                                            While vNgay <= dtDen.Value
                                                                Dim tbTb As DataTable = New DataTable()
                                                                Dim vViewCP As DataView = New DataView(vTableChiPhi, "MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND MS_LOAI_BT = " & gvLoaiBT.Rows(i).Cells("clMsLoaiBT").Value & " ", "", DataViewRowState.CurrentRows)
                                                                tbTb = vViewCP.ToTable()
                                                                Dim vChiphi As Integer = 0
                                                                For Each vRowsst As DataRow In tbTb.Rows
                                                                    Try
                                                                        If (Convert.ToDateTime(vRowsst("NGAY_BD_KH")) < vNgay.AddDays(-Weekday(vNgay)).AddDays(7) And Convert.ToDateTime(vRowsst("NGAY_BD_KH")) >= vNgay.AddDays(-Weekday(vNgay))) Then
                                                                            vChiphi = vChiphi + Convert.ToInt32(vRowsst("CHI_PHI"))
                                                                        End If
                                                                    Catch ex As Exception

                                                                    End Try
                                                                Next
                                                                'Dim strss As String = "SELECT SUM(dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)  AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvLoaiBT.Rows(i).Cells("clMsnguyennhan").Value & " AND MS_MAY = N'" & vTablemay.Rows(k)("MS_MAY") & "'  AND NGAY >= '" & vNgay.AddDays(-Weekday(vNgay)).ToString("MM/dd/yyyy") & "' AND NGAY < '" & vNgay.AddDays(-Weekday(vNgay)).AddDays(7).ToString("MM/dd/yyyy") & "' GROUP BY MS_MAY "
                                                                'tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                                Try
                                                                    .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                                    .Cells(vRow + k + 1, vColum) = vChiphi.ToString().Trim()
                                                                Catch ex As Exception
                                                                End Try
                                                                vColum = vColum + 1
                                                                vNgay = vNgay.AddDays(7)
                                                            End While
                                                        Next
                                                        If vTablemay.Rows.Count > 0 Then
                                                            vNgay = dtTu.Value
                                                            vColum = 3
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2) = sLBT 'Tổng theo loại BT"
                                                            While vNgay <= dtDen.Value
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                                If (vColum > 2) Then
                                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                                End If
                                                                vColum = vColum + 1
                                                                vNgay = vNgay.AddDays(7)
                                                            End While
                                                            vList.Add(vRow + vTablemay.Rows.Count + 1)
                                                        End If
                                                    End With
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                vRow = vRow + vTablemay.Rows.Count + 2
                            End If
                        End If
                    Next i
                    With ExcelSheets
                        Dim vNgay As Date = dtTu.Value
                        Dim vColum As Integer = 3
                        If vList.Count > 0 Then
                            If (rdoNgay.Checked) Then
                                .Cells(vRow, 2).Font.Bold = True
                                .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                .Cells(vRow, 2) = sNX  '"Tổng theo nhà xưởng"
                                While vNgay <= dtDen.Value
                                    .Cells(vRow, vColum).Font.Bold = True
                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                    If (vColum > 2) Then
                                        Dim vSum As String = ""
                                        For n As Integer = 0 To vList.Count - 1
                                            vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                        Next
                                        If vList.Count > 0 Then
                                            .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                        End If
                                    End If
                                    vColum = vColum + 1
                                    vNgay = vNgay.AddDays(1)
                                End While

                            Else
                                If rdoThang.Checked Then
                                    .Cells(vRow, 2).Font.Bold = True
                                    .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                    .Cells(vRow, 2) = sNX  '"Tổng theo nhà xưởng"
                                    While vNgay.Year <= dtDen.Value.Year
                                        If (vNgay.Year = dtDen.Value.Year And vNgay.Month > dtDen.Value.Month) Then
                                            Exit While
                                        End If
                                        .Cells(vRow, vColum).Font.Bold = True
                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                        If (vColum > 2) Then
                                            Dim vSum As String = ""
                                            Dim vRowTMP As Integer = vRowSum
                                            For n As Integer = 0 To vList.Count - 1
                                                vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                            Next
                                            If vList.Count > 0 Then
                                                .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                            End If
                                        End If
                                        vColum = vColum + 1
                                        vNgay = vNgay.AddMonths(1)
                                    End While
                                Else
                                    If rdoQuy.Checked Then
                                        Dim vMaxMonth As Integer = -1
                                        If (dtDen.Value.Month > 9) Then
                                            vMaxMonth = 12
                                        Else
                                            If (dtDen.Value.Month > 6) Then
                                                vMaxMonth = 9
                                            Else
                                                If (dtDen.Value.Month > 3) Then
                                                    vMaxMonth = 6
                                                Else
                                                    vMaxMonth = 3
                                                End If
                                            End If
                                        End If
                                        .Cells(vRow, 2).Font.Bold = True
                                        .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                        .Cells(vRow, 2) = sNX  '"Tổng theo nhà xưởng"
                                        While vNgay.Year <= dtDen.Value.Year
                                            If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= vMaxMonth) Then
                                                Exit While
                                            End If
                                            .Cells(vRow, vColum).Font.Bold = True
                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                            If (vColum > 2) Then
                                                Dim vSum As String = ""
                                                Dim vRowTMP As Integer = vRowSum
                                                For n As Integer = 0 To vList.Count - 1
                                                    vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                Next
                                                If vList.Count > 0 Then
                                                    .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                End If
                                            End If
                                            vColum = vColum + 1
                                            vNgay = vNgay.AddMonths(3)
                                        End While
                                    Else
                                        If rdoNam.Checked Then
                                            .Cells(vRow, 2).Font.Bold = True
                                            .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                            .Cells(vRow, 2) = sNX  '"Tổng theo nhà xưởng"
                                            While vNgay.Year <= dtDen.Value.Year
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                                If (vColum > 2) Then
                                                    Dim vSum As String = ""
                                                    Dim vRowTMP As Integer = vRowSum
                                                    For n As Integer = 0 To vList.Count - 1
                                                        vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                    Next
                                                    If vList.Count > 0 Then
                                                        .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                    End If
                                                End If
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddYears(1)

                                            End While
                                        Else
                                            If rdoTuan.Checked Then
                                                .Cells(vRow, 2).Font.Bold = True
                                                .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                                .Cells(vRow, 2) = sNX  '"Tổng theo nhà xưởng"
                                                While vNgay <= dtDen.Value
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                                    If (vColum > 2) Then
                                                        Dim vSum As String = ""
                                                        Dim vRowTMP As Integer = vRowSum
                                                        For n As Integer = 0 To vList.Count - 1
                                                            vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                        Next
                                                        If vList.Count > 0 Then
                                                            .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                        End If
                                                    End If
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddDays(7)

                                                End While

                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            vRow = vRow + 1
                        End If
                    End With
                Next j
            End If

            ExcelApp.Visible = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
        Dim lastValues() As Object
        Dim newTable As DataTable

        If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
            Throw New ArgumentNullException("FieldNames")
        End If

        lastValues = New Object(FieldNames.Length - 1) {}
        newTable = New DataTable

        For Each field As String In FieldNames
            newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
        Next

        For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
            If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                setLastValues(lastValues, Row, FieldNames)
            End If
        Next

        Return newTable
    End Function
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
        Dim areEqual As Boolean = True

        For i As Integer = 0 To fieldNames.Length - 1
            If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                areEqual = False
                Exit For
            End If
        Next

        Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
        For Each field As String In fieldNames
            newRow(field) = sourceRow(field)
        Next

        Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
        For i As Integer = 0 To fieldNames.Length - 1
            lastValues(i) = sourceRow(fieldNames(i))
        Next
    End Sub
    Private Sub cbxNhaXuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles cbxNhaXuong.SelectedIndexChanged
        LoadDSMay(cbxNhaXuong.SelectedValue)
    End Sub
    Private Sub chxChonTungMay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxChonTungMay.CheckedChanged
        If chxChonTungMay.Checked = True Then
            grbChonMay.Visible = True
            gNhaxuong.Visible = False
            gNguyennhan.Visible = False
            LoadNhaxuongChon()
        Else
            grbChonMay.Visible = False
            gNhaxuong.Visible = True
            gNguyennhan.Visible = True
        End If
    End Sub

    Private Sub grdDanhSachMay_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhSachMay.CellValidating

        If grdDanhSachMay.Columns(e.ColumnIndex).Name = "CHON_MAY" Then
            Dim vrow() As DataRow = vtbDsMayChon.Select("MS_MAY = '" + grdDanhSachMay.Rows(e.RowIndex).Cells("MS_MAY").Value + "'")
            grdDanhSachMay.EndEdit()

            Dim s As Boolean = grdDanhSachMay.Rows(e.RowIndex).Cells("CHON_MAY").Value
            If grdDanhSachMay.Rows(e.RowIndex).Cells("CHON_MAY").Value = True And vrow.Length <= 0 Then
                vtbDsMayChon.Rows.Add(grdDanhSachMay.Rows(e.RowIndex).Cells("MS_MAY").Value, grdDanhSachMay.Rows(e.RowIndex).Cells("TEN_MAY").Value, "")
            End If

            If grdDanhSachMay.Rows(e.RowIndex).Cells("CHON_MAY").Value = False And vrow.Length > 0 Then
                For Each rowTm As DataRow In vtbDsMayChon.Select("MS_MAY = '" + grdDanhSachMay.Rows(e.RowIndex).Cells("MS_MAY").Value + "'")
                    vtbDsMayChon.Rows.Remove(rowTm)
                Next
            End If
        End If

    End Sub

    Sub LoadNhaxuongChon()
        Dim vstrNx As String = "-1"
        For j As Integer = 0 To gvNhaxuong.Rows.Count - 1
            If Convert.ToBoolean(gvNhaxuong.Rows(j).Cells("clChonnhaxuong").Value) Then

                Dim _table As DataTable = New DataTable()
                _table = Get_DataTable(gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value.ToString().Trim(), cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
                For Each row As DataRow In _table.Rows
                    If vstrNx = "-1" Then
                        vstrNx = "'" + row("MS_N_XUONG") + "'"
                    Else
                        vstrNx = vstrNx + ",'" + row("MS_N_XUONG") + "'"
                    End If
                Next
            End If

        Next
        Dim vStr As String = ""
        If vstrNx = "-1" Then
            vStr = "SELECT TOP 0 MS_N_XUONG, TEN_N_XUONG  FROM NHA_XUONG "
        Else
            vStr = " SELECT MS_N_XUONG, TEN_N_XUONG  FROM NHA_XUONG " & _
                    " WHERE MS_N_XUONG IN (" + vstrNx + ")"
        End If

        cbxNhaXuong.Text = ""
        grdDanhSachMay.DataSource = Nothing
        vtbNx = New DataTable()
        vtbNx.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStr))

        cbxNhaXuong.ValueMember = "MS_N_XUONG"
        cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaXuong.DataSource = vtbNx

    End Sub


    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        Dim i As Integer
        While i < grdDanhSachMay.RowCount
            grdDanhSachMay.Rows(i).Cells("CHON_MAY").Value = True
            Dim vrow() As DataRow = vtbDsMayChon.Select("MS_MAY = '" + grdDanhSachMay.Rows(i).Cells("MS_MAY").Value + "'")
            If vrow.Length = 0 Then
                vtbDsMayChon.Rows.Add(grdDanhSachMay.Rows(i).Cells("MS_MAY").Value, grdDanhSachMay.Rows(i).Cells("TEN_MAY").Value, "")
            End If
            i = i + 1
        End While
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        Dim i As Integer
        While i < grdDanhSachMay.RowCount
            grdDanhSachMay.Rows(i).Cells("CHON_MAY").Value = False
            For Each rowTm As DataRow In vtbDsMayChon.Select("MS_MAY = '" + grdDanhSachMay.Rows(i).Cells("MS_MAY").Value + "'")
                vtbDsMayChon.Rows.Remove(rowTm)
            Next
            i = i + 1
        End While
    End Sub

    Private Sub frmrptChiPhiBaoTri_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtTu.Value = Date.Now.Date.AddMonths(-6)
        dtDen.Value = Date.Now.Date
        dtTu.Format = DateTimePickerFormat.Short
        dtDen.Format = DateTimePickerFormat.Short
        LoadCity()
        BinDataLoaiBT()
        'BinDataNhaxuong()
        'LoadNhaxuong()

        LoadDSMay("-1")
        chxChonTungMay.Checked = False
        grbChonMay.Visible = False
        vtbDsMayChon = CType(grdDanhSachMay.DataSource, DataTable).Copy()
        vtbDsMayChon.Rows.Clear()
        AddHandler cbxNhaXuong.SelectedIndexChanged, AddressOf Me.cbxNhaXuong_SelectedIndexChanged
    End Sub

    'Bind data combo nha xuong 
    Sub LoadNhaxuong()
        cbxNhaXuong.Value = "MS_N_XUONG"
        cbxNhaXuong.Display = "TEN_N_XUONG"
        cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        cbxNhaXuong.Param = Commons.Modules.UserName
        cbxNhaXuong.BindDataSource()
    End Sub
    'Load Danh sach may theo nhà xuong 
    Sub LoadDSMay(ByVal ms_n_xuong As String)
        Dim vtbDsMay As New DataTable()
        vtbDsMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_MAY_NHA_XUONGs", ms_n_xuong))
        grdDanhSachMay.AutoGenerateColumns = False
        grdDanhSachMay.DataSource = vtbDsMay
        grdDanhSachMay.Columns("MS_MAY").DataPropertyName = "MS_MAY"
        grdDanhSachMay.Columns("TEN_MAY").DataPropertyName = "TEN_MAY"
        grdDanhSachMay.Columns("CHON_MAY").DataPropertyName = "CHON"
        CheckDSMay()
    End Sub

    Private vtbDsMayChon As New DataTable()

    Sub CheckDSMay()
        Try
            For Each grow As DataGridViewRow In grdDanhSachMay.Rows
                For Each vrow As DataRow In vtbDsMayChon.Rows
                    If vrow("MS_MAY") = grow.Cells("MS_MAY").Value Then
                        grdDanhSachMay.Rows(grow.Index).Cells("CHON_MAY").Value = True
                    End If
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------------------
    'Bin data 
    Private Sub BinDataLoaiBT()
        Try
            Dim tbLoaiBT As DataTable = New DataTable()
            tbLoaiBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_LOAI_BT , TEN_LOAI_BT , CONVERT ( BIT , 0 ) AS CHON FROM LOAI_BAO_TRI"))
            Dim vRow As DataRow = tbLoaiBT.NewRow()
            vRow("MS_LOAI_BT") = -1
            vRow("TEN_LOAI_BT") = "Chi phí hàng ngày"
            tbLoaiBT.Rows.Add(vRow)
            tbLoaiBT.Columns("CHON").ReadOnly = False
            gvLoaiBT.AutoGenerateColumns = False
            gvLoaiBT.DataSource = tbLoaiBT
            gvLoaiBT.Columns("clMsLoaiBT").DataPropertyName = "MS_LOAI_BT"
            gvLoaiBT.Columns("clLoaiBT").DataPropertyName = "TEN_LOAI_BT"
            gvLoaiBT.Columns("clChonnguyennhan").DataPropertyName = "CHON"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BinDataNhaxuong()
        Try

            Dim tbNhaxuong As DataTable = New DataTable()
            tbNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Y_Get_Nha_XUONG_TKTSNM_NEW", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
            'tbNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_N_XUONG , TEN_N_XUONG , CONVERT (BIT ,0 ) AS CHON FROM NHA_XUONG "))
            tbNhaxuong.Columns("CHON").ReadOnly = False
            gvNhaxuong.AutoGenerateColumns = False
            gvNhaxuong.DataSource = tbNhaxuong
            gvNhaxuong.Columns("clMsnhaxuong").DataPropertyName = "MS_N_XUONG"
            gvNhaxuong.Columns("clNhaxuong").DataPropertyName = "TEN_N_XUONG"
            gvNhaxuong.Columns("clChonnhaxuong").DataPropertyName = "CHON"

        Catch ex As Exception

        End Try
    End Sub

    'In theo May dc chon 

    Sub PrintDsMay()
        If vtbDsMayChon.Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChiPhiBaoTri", "banChuaChonMay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vRow As Integer = 2
            Dim vRowSum As Integer = 2
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim cander As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            Dim vFlag As Boolean = False
            Dim vTheo As String = ""
            If (rdoNgay.Checked) Then
                vTheo = "THEO NGÀY"
            Else
                If (rdoTuan.Checked) Then
                    vTheo = "THEO TUẦN"
                Else
                    If rdoThang.Checked Then
                        vTheo = "THEO THÁNG"
                    Else
                        If rdoQuy.Checked Then
                            vTheo = "THEO QUÝ"
                        Else
                            vTheo = "THEO NĂM"
                        End If
                    End If
                End If
            End If
            'Tieu De
            With ExcelSheets
                .Columns(1).ColumnWidth = 15
                .Columns(2).ColumnWidth = 15
                .Columns(2).ColumnWidth = 20

                .Range("A2:H2").Merge()
                .Range("A2:H2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A2:H2").Font.Bold = True
                .Cells(vRow, 1).Font.Color = RGB(0, 0, 192)
                .Cells(vRow, 1).Font.Size = 13
                .Cells(vRow, 1) = "CHI PHÍ BẢO TRÌ (" & vTheo & ")"
                vRow = vRow + 1
                .Range("B2:C2").Merge()
                .Range("B2:C2").Font.Italic = True
                .Range("B2:C2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 2) = "Từ ngày :" & dtTu.Value.ToShortDateString().Trim()
                .Range("D2:E2").Merge()
                .Range("D2:E2").Font.Italic = True
                .Range("D2:E2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 3) = "Đến ngày :" & dtDen.Value.ToShortDateString().Trim()
                vRow = vRow + 2
            End With
            Dim vColum As Integer = 2
            Dim vTuNgay As DateTime = dtTu.Value ' tu ngay
            Dim vDenNgay As DateTime = dtDen.Value 'Den Ngay
            Dim vList As ArrayList = New ArrayList()
            If (rdoNgay.Checked) Then
                With ExcelSheets
                    .Cells(vRow, vColum).Font.Bold = True
                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Cells(vRow, vColum) = "Máy"
                    vColum = vColum + 1
                    Dim vNgay As Date = dtTu.Value
                    While vNgay <= dtDen.Value
                        If (Not vFlag) Then
                            .Columns(vColum).ColumnWidth = 12
                        End If
                        .Cells(vRow, vColum).Font.Bold = True
                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Cells(vRow, vColum) = " " & vNgay.ToString("dd/MM/yyyy").Trim() & " "
                        vColum = vColum + 1
                        vNgay = vNgay.AddDays(1)
                    End While

                End With


                For Each rowMaychon As DataRow In vtbDsMayChon.Rows
                    Dim vtbChiPhiMay As New DataTable()
                    vtbChiPhiMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CHI_PHI_BAO_TRI", rowMaychon("MS_MAY"), vTuNgay, vDenNgay))
                    With ExcelSheets
                        Dim vNgay As Date = dtTu.Value
                        vFlag = True
                        vColum = 2
                        .Cells(vRow + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Cells(vRow + 1, vColum) = rowMaychon("MS_MAY") '"(" & vtbChiPhiMay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vtbChiPhiMay.Rows(k)("MS_MAY").ToString().Trim()

                        vColum = 2
                        vNgay = dtTu.Value
                        vColum = vColum + 1
                        While vNgay <= dtDen.Value
                            For Each vrowCP As DataRow In vtbChiPhiMay.Rows
                                If vrowCP("NGAY_BD_KH") = vNgay Then
                                    .Cells(vRow + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                    .Cells(vRow + 1, vColum) = vrowCP("CHI_PHI")
                                    .Cells(vRow + 1, vColum).Font.Color = RGB(0, 0, 192)
                                End If
                            Next
                            vColum = vColum + 1
                            vNgay = vNgay.AddDays(1)
                        End While



                    End With
                    vRow = vRow + 1
                Next
            End If ' rad Ngay  
            ExcelApp.Visible = True
        End If

        Me.Cursor = Cursors.Default
    End Sub
#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try

            'cmbStreet.StoreName = "S_Duong"
            'cmbStreet.Param = cmbCity.SelectedValue.ToString()
            'If cmbDistrict.SelectedValue = Nothing Then
            'Else
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            'End If
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable()
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[Y_Get_Nha_XUONG_TKTSNM_NEW]", "-1", "-1", "-1"))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong"))
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_TGSCTB_NEW]", "-1", "-1", "-1"))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable()
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
#End Region
    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
        chxChonTungMay.Checked = False
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
        chxChonTungMay.Checked = False
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        BinDataNhaxuong()
        chxChonTungMay.Checked = False
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
