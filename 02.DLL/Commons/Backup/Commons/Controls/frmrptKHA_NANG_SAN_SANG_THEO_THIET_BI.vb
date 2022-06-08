Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms


Public Class frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            Dim vTu As Date
            Dim vDen As Date
            Try
                vTu = Convert.ToDateTime("01/" & mskTu.Text.Trim()).Date
            Catch ex As Exception
                MessageBox.Show("Từ ngày không hợp lệ", "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                mskTu.Focus()
                Exit Sub
            End Try
            Try
                vDen = Convert.ToDateTime("01/" & mskDen.Text.Trim()).Date
                vDen = vDen.AddMonths(1)
            Catch ex As Exception
                MessageBox.Show("Từ ngày không hợp lệ", "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                mskTu.Focus()
                Exit Sub
            End Try
            '//////
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
            With ExcelSheets
                .Columns(1).ColumnWidth = 15
                .Columns(2).ColumnWidth = 15
                .Columns(2).ColumnWidth = 20

                .Range("A2:H2").Merge()
                .Range("A2:H2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A2:H2").Font.Bold = True
                .Cells(vRow, 1).Font.Color = RGB(255, 0, 128)
                .Cells(vRow, 1).Font.Size = 13
                .Cells(vRow, 1) = "KHẢ NĂNG SẴN SÀNG THEO DÂY CHUYỀN (BREAKDOWN AND ADJUSTMENT)"
                vRow = vRow + 1

                .Range("B2:C2").Merge()
                .Range("B2:C2").Font.Italic = True
                .Range("B2:C2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 2) = "Từ tháng :" & mskTu.Text.Trim()
                .Range("D2:E2").Merge()
                .Range("D2:E2").Font.Italic = True
                .Range("D2:E2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 3) = "Đến tháng :" & mskDen.Text.Trim()

                vRow = vRow + 2

            End With
            Dim vTablemay As DataTable = New DataTable()

            For j As Integer = 0 To gvDaychuyen.Rows.Count - 1
                If (Not gvDaychuyen.Rows(j).Cells("clChonDaychuyen").Value Is Nothing) Then
                    If Convert.ToBoolean(gvDaychuyen.Rows(j).Cells("clChonDaychuyen").Value) Then
                        With ExcelSheets
                            .Cells(vRow, 1).Font.Bold = True
                            .Cells(vRow, 1).Font.Color = RGB(255, 0, 0)
                            .Cells(vRow, 1).Font.Size = 12
                            .Cells(vRow, 1) = gvDaychuyen.Rows(j).Cells("clDaychuyen").Value.ToString().Trim()
                            vRow = vRow + 1
                        End With

                        vTablemay = New DataTable()
                        Dim strmay As String = " SELECT   DISTINCT  dbo.MAY.MS_MAY, dbo.MAY.TEN_MAY" & _
                        " FROM         dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                        " dbo.NGUYEN_NHAN_DUNG_MAY ON  " & _
                        " dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " & _
                        " dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY " & _
                        " WHERE NGAY >= '" & vTu.ToString("MM/dd/yyyy") & "' AND NGAY < '" & vDen.ToString("MM/dd/yyyy") & "' " & _
                        " AND MS_HE_THONG = " & gvDaychuyen.Rows(j).Cells("clMsDaychuyen").Value & " AND THOI_GIAN_SUA_CHUA > 0 AND (BTDK = 1 OR HU_HONG = 1) "
                        vTablemay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strmay))
                        Dim vColum As Integer = 2
                        With ExcelSheets
                            .Cells(vRow, vColum).Font.Bold = True
                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Cells(vRow, vColum) = "Máy"
                            vColum = vColum + 1
                            Dim vNgay As Date = vTu
                            While vNgay.Year <= vDen.Year
                                If vNgay.Year = vDen.Year And vNgay.Month >= vDen.Month Then
                                    Exit While
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
                            vRow = vRow + 1
                            For k As Integer = 0 To vTablemay.Rows.Count - 1
                                vColum = 2
                                .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                .Cells(vRow, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("MS_MAY").ToString().Trim()
                                vNgay = vTu
                                vColum = vColum + 1
                                While vNgay.Year <= vDen.Year
                                    Dim tbTb As DataTable = New DataTable()
                                    If vNgay.Year = vDen.Year And vNgay.Month >= vDen.Month Then
                                        Exit While
                                    Else
                                        Dim strss As String = "SELECT ((dbo.KE_HOACH_SX_LINE.SO_GIO_KH  - SUM ( dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)/60) / dbo.KE_HOACH_SX_LINE.SO_GIO_KH ) AS KHA_NANG_SAN_SANG" & _
                                        " FROM         dbo.KE_HOACH_SX_LINE INNER JOIN" & _
                                        " dbo.HE_THONG ON dbo.KE_HOACH_SX_LINE.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                                        " dbo.THOI_GIAN_NGUNG_MAY ON dbo.HE_THONG.MS_HE_THONG = dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG INNER JOIN " & _
                                        " dbo.NGUYEN_NHAN_DUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
                                        " WHERE NGAY >= '" & vTu.ToString("MM/dd/yyyy") & "'  AND NGAY < '" & vDen.ToString("MM/dd/yyyy") & "'AND YEAR (THANG) = YEAR (NGAY) AND MONTH (THANG) = MONTH (NGAY) AND (BTDK = 1 OR HU_HONG = 1 )And Month(NGAY) = " & vNgay.Month & " AND YEAR(NGAY) = " & vNgay.Year & " " & _
                                        " AND HE_THONG.MS_HE_THONG = " & gvDaychuyen.Rows(j).Cells("clMsDaychuyen").Value & " AND MS_MAY = N'" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & "' " & _
                                        "GROUP BY dbo.KE_HOACH_SX_LINE.SO_GIO_KH "
                                        tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                        Try
                                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow, vColum) = Format(Convert.ToDouble(tbTb.Rows(0)("KHA_NANG_SAN_SANG")), "N4").ToString().Trim()
                                        Catch ex As Exception
                                            '.Cells(vRow, vColum) = 1
                                        End Try
                                        vColum = vColum + 1
                                        vNgay = vNgay.AddMonths(1)
                                    End If
                                End While
                                vRow = vRow + 1
                            Next
                            If vTablemay.Rows.Count > 0 Then
                                vNgay = vTu
                                vColum = 3
                                .Cells(vRow, 2).Font.Bold = True
                                .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                .Cells(vRow, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                While vNgay.Year <= vDen.Year
                                    If (vNgay.Year = vDen.Year And vNgay.Month >= vDen.Month) Then
                                        Exit While
                                    End If
                                    .Cells(vRow, vColum).Font.Bold = True
                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                    .Cells(vRow, vColum).Font.Color = RGB(168, 12, 128)
                                    If (vColum > 2) Then
                                        Dim strsskn As String = "SELECT ((dbo.KE_HOACH_SX_LINE.SO_GIO_KH  - SUM ( dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA)/60) / dbo.KE_HOACH_SX_LINE.SO_GIO_KH ) AS KHA_NANG_SAN_SANG" & _
                                        " FROM         dbo.KE_HOACH_SX_LINE INNER JOIN" & _
                                        " dbo.HE_THONG ON dbo.KE_HOACH_SX_LINE.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                                        " dbo.THOI_GIAN_NGUNG_MAY ON dbo.HE_THONG.MS_HE_THONG = dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG INNER JOIN " & _
                                        " dbo.NGUYEN_NHAN_DUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
                                        " WHERE NGAY >= '" & vTu.ToString("MM/dd/yyyy") & "'  AND NGAY < '" & vDen.ToString("MM/dd/yyyy") & "'AND YEAR (THANG) = YEAR (NGAY) AND MONTH (THANG) = MONTH (NGAY) AND (BTDK = 1 OR HU_HONG = 1 )And Month(NGAY) = " & vNgay.Month & " AND YEAR(NGAY) = " & vNgay.Year & " " & _
                                        " AND HE_THONG.MS_HE_THONG = " & gvDaychuyen.Rows(j).Cells("clMsDaychuyen").Value & "  " & _
                                        "GROUP BY dbo.KE_HOACH_SX_LINE.SO_GIO_KH "
                                        Dim tbKN As DataTable = New DataTable()
                                        tbKN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strsskn))
                                        Try
                                            .Cells(vRow, vColum) = Format(Convert.ToDouble(tbKN.Rows(0)("KHA_NANG_SAN_SANG")), "N4").ToString().Trim()
                                            '.Cells(vRow, vColum) = Format(Convert.ToDouble(tbTb.Rows(0)("KHA_NANG_SAN_SANG")), "N4").ToString().Trim()
                                        Catch ex As Exception
                                        End Try

                                    End If
                                    vColum = vColum + 1
                                    vNgay = vNgay.AddMonths(1)
                                End While
                            End If
                            vRow = vRow + 1
                        End With
                    End If
                End If
            Next j
            ExcelApp.Visible = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    'Load nha xưởng
    Private Sub LoadDayChuyen()
        Try
            Dim tbDaychuyen As DataTable = New DataTable()
            tbDaychuyen.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG , CONVERT (BIT ,0 ) AS CHON FROM HE_THONG "))
            tbDaychuyen.Columns("CHON").ReadOnly = False
            gvDaychuyen.AutoGenerateColumns = False
            gvDaychuyen.DataSource = tbDaychuyen
            gvDaychuyen.Columns("clMsDaychuyen").DataPropertyName = "MS_HE_THONG"
            gvDaychuyen.Columns("clDaychuyen").DataPropertyName = "TEN_HE_THONG"
            gvDaychuyen.Columns("clChonDaychuyen").DataPropertyName = "CHON"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mskTu.Text = System.DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy").Substring(3, 7).Replace("/", "")
            mskDen.Text = System.DateTime.Now.ToString("dd/MM/yyyy").Substring(3, 7).Replace("/", "")
            LoadDayChuyen()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
