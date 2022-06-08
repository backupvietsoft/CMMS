Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports System.Data
Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms

Public Class frmTGSC_TheoMay

    Dim v_all As System.Data.DataTable = New System.Data.DataTable()
    Public Shared strNam As String
    Public Shared bolQuy As Boolean
    Public amay(100000) As String
    Public dem As Integer
    Public baocao As Integer
    Public tu As String
    Public den As String
    Public loaibaocao As Integer
    Private Sub frmTGSC_TheoMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        radTheoXuong.Checked = True
        'loadCboTheoXuong()
        LoadCity()
        loadCboTheoLoaiMay()
        '  loadTemp()
        Me.Cursor = Cursors.Default
        loadDGVShow(0)
        Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub radTheoXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTheoXuong.CheckedChanged

        If radTheoXuong.Checked = True Then
            cboTheoXuong.Enabled = True
            cboTheoLoaiMay.Enabled = False
        Else
            cboTheoXuong.Enabled = False
            cboTheoLoaiMay.Enabled = True
        End If

        Try
            loadDGVShow(0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub radTheoLoaiMay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTheoLoaiMay.CheckedChanged

        If radTheoXuong.Checked = True Then
            cboTheoXuong.Enabled = True
            cboTheoLoaiMay.Enabled = False
            cmbCity.Enabled = True
            cmbDistrict.Enabled = True
            cmbStreet.Enabled = True
        Else
            cboTheoXuong.Enabled = False
            cboTheoLoaiMay.Enabled = True
            cmbCity.Enabled = False
            cmbDistrict.Enabled = False
            cmbStreet.Enabled = False
        End If

        Try
            loadDGVShow(0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub loadCboTheoXuong()

        'Dim dt As New DataTable
        'commons.Modules.SQLString = "SELECT  *  FROM   NHA_XUONG ORDER BY Ten_N_XUONG"
        'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        'cboTheoXuong.DataSource = dt
        'cboTheoXuong.DisplayMember = "Ten_N_XUONG"
        'cboTheoXuong.ValueMember = "MS_N_XUONG"
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cboTheoXuong.DisplayMember = "TEN_N_XUONG"
        cboTheoXuong.ValueMember = "MS_N_XUONG"
        cboTheoXuong.DataSource = _table
        'Try
        '    loadDGVShow(0)
        'Catch ex As Exception
        'End Try
        EnableCboChon()

    End Sub

    Private Sub loadCboTheoLoaiMay()

        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT  *  FROM   LOAI_MAY ORDER BY TEN_LOAI_MAY"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        cboTheoLoaiMay.DataSource = dt
        cboTheoLoaiMay.DisplayMember = "TEN_LOAI_MAY"
        cboTheoLoaiMay.ValueMember = "MS_LOAI_MAY"

        'Try
        '    loadDGVShow(0)
        'Catch ex As Exception
        'End Try
        EnableCboChon()

    End Sub

    Private Sub loadDGVShow(ByVal bitChon As Int16)

        If radTheoXuong.Checked = True Then
            Dim dt As New DataTable
            'commons.Modules.SQLString = "SELECT DISTINCT   dbo.MAY_NHA_XUONG.MS_MAY, " & _
            '"MAX(dbo.MAY_NHA_XUONG.NGAY_NHAP) AS Expr1, dbo.NHOM_MAY.TEN_NHOM_MAY, CAST('" + bitChon.ToString + "' AS BIT) AS CHON " & _
            '"FROM   dbo.MAY_NHA_XUONG INNER JOIN " & _
            '"dbo.MAY ON dbo.MAY_NHA_XUONG.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
            '"dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY " & _
            '"GROUP BY dbo.MAY_NHA_XUONG.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.MAY_NHA_XUONG.MS_N_XUONG " & _
            '"HAVING      (dbo.MAY_NHA_XUONG.MS_N_XUONG = '" + cboTheoXuong.SelectedValue.ToString + "') " & _
            '"ORDER BY dbo.MAY_NHA_XUONG.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY"
            'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
            'dt.Columns("CHON").ReadOnly = False
            'dgvShow.DataSource = dt
            'dgvShow.Columns("Expr1").Visible = False
            v_all = New System.Data.DataTable()
            dt = Get_DataTable(cboTheoXuong.SelectedValue.ToString(), bitChon, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
            dt.Columns("CHON").ReadOnly = False
            dt.DefaultView.Sort = "MS_MAY"
            dgvShow.DataSource = dt

        ElseIf radTheoLoaiMay.Checked = True Then
            Dim dt As New DataTable
            Commons.Modules.SQLString = "SELECT DISTINCT dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, CAST('" + bitChon.ToString + "' AS BIT) AS CHON " & _
            "FROM         dbo.MAY INNER JOIN " & _
            "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
            "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY " & _
            "WHERE     (dbo.NHOM_MAY.MS_LOAI_MAY = '" + cboTheoLoaiMay.SelectedValue.ToString + "') " & _
            "ORDER BY dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY"
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
            dt.Columns("CHON").ReadOnly = False
            dgvShow.DataSource = dt
        End If
        Column1.DataPropertyName = "MS_MAY"
        Column2.DataPropertyName = "TEN_NHOM_MAY"
        Column3.DataPropertyName = "CHON"

        For Each mycolumn As DataGridViewColumn In dgvShow.Columns
            mycolumn.Visible = False
        Next
        dgvShow.Columns("MS_MAY").Visible = True
        dgvShow.Columns("TEN_NHOM_MAY").Visible = True
        dgvShow.Columns("CHON").Visible = True
        dgvShow.Cursor = Cursors.Default
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        loadDGVShow(1)
    End Sub

    Private Sub btnBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChon.Click
        loadDGVShow(0)
    End Sub

    Private Sub dgvShow_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvShow.DataError
        Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboTheoXuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTheoXuong.SelectedIndexChanged
        Try
            loadDGVShow(0)
        Catch ex As Exception
        End Try
        EnableCboChon()
    End Sub

    Private Sub cboTheoLoaiMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTheoLoaiMay.SelectedIndexChanged
        Try
            loadDGVShow(0)
        Catch ex As Exception
        End Try
        EnableCboChon()
    End Sub

    Private Sub EnableCboChon()
        If dgvShow.RowCount > 0 Then
            btnChonAll.Enabled = True
            btnBoChon.Enabled = True
        Else
            btnChonAll.Enabled = False
            btnBoChon.Enabled = False
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub loadTemp()
        'CAST('' AS DATETIME)
        Commons.Modules.ObjSystems.XoaTable("DBO.NHOC")
        Commons.Modules.SQLString = "SELECT  STT=IDENTITY (int, 0,1) , dbo.THOI_GIAN_NGUNG_MAY.MS_MAY,   CONVERT(DATETIME,dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY) AS NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO AS  TU_GIO, " & _
                " CONVERT(DATETIME,dbo.THOI_GIAN_NGUNG_MAY.NGAY) AS NGAY_KE_TIEP, " & _
                "CASE  " & _
                "WHEN MONTH(DEN_NGAY) >= 1 AND MONTH(DEN_NGAY) <= 3 THEN '1/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(DEN_NGAY) >= 4 AND MONTH(DEN_NGAY) <= 6 THEN '2/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(DEN_NGAY) >= 7 AND MONTH(DEN_NGAY) <= 9 THEN '3/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(DEN_NGAY) >= 10 AND MONTH(DEN_NGAY) <= 12 THEN '4/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "END AS QUY, case  " & _
                "WHEN MONTH(DEN_NGAY) = 1  THEN '1/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(DEN_NGAY) = 2  THEN '2/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(DEN_NGAY) = 3  THEN '3/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 4  THEN '4/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 5  THEN '5/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 6  THEN '6/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 7  THEN '7/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 8  THEN '8/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 9  THEN '9/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 10  THEN '10/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 11  THEN '11/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(DEN_NGAY) = 12  THEN '12/' + CAST(YEAR(DEN_NGAY) AS NVARCHAR(4))  " & _
                "END AS thang,  " & _
               "YEAR(DEN_NGAY) AS NAM " & _
                "INTO DBO.NHOC " & _
                "FROM         dbo.MAY INNER JOIN " & _
                        "dbo.THOI_GIAN_NGUNG_MAY " & _
                "ON dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN  dbo.NGUYEN_NHAN_DUNG_MAY  " & _
                "ON dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
                "WHERE(dbo.NGUYEN_NHAN_DUNG_MAY.HU_HONG = 1)  " & _
                "   and  dbo.MAY.MS_MAY in( select MS_MAY  from  NHOC_MS_MAY)   " & _
                "ORDER BY dbo.THOI_GIAN_NGUNG_MAY.MS_MAY,   dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO , THOI_GIAN_NGUNG_MAY.NGAY "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        'Dim dtSTT As New DataTable
        'Commons.Modules.SQLString = "SELECT * FROM DBO.NHOC ORDER BY MS_MAY , NGAY, TU_GIO "
        'dtSTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        'For STT As Int16 = 0 To dtSTT.Rows.Count - 1
        '    Commons.Modules.SQLString = "UPDATE DBO.NHOC SET STT='" + STT.ToString + "'" & _
        '    " WHERE MS_MAY=N'" + dtSTT.Rows(STT)("MS_MAY").ToString + "' AND CONVERT(NVARCHAR(10),NGAY,103) = '" & _
        '    Format(dtSTT.Rows(STT)("NGAY"), "dd/MM/yyyy") + "' AND CONVERT(NVARCHAR(10),TU_GIO,108) = '" & _
        '    Format(dtSTT.Rows(STT)("TU_GIO"), "HH:mm:ss") + "'"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        'Next

        Dim dt, dtt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DBO.NHOC  ORDER BY MS_MAY , NGAY, TU_GIO "))
        Dim rowCount As Integer = dt.Rows.Count
        'Dim ngay As Date

        'For i As Integer = 1 To rowCount - 1
        '    If dt.Rows(i)("MS_MAY").ToString = dt.Rows(i - 1)("MS_MAY").ToString Then

        '        'ngay = DateAdd(DateInterval.Day, -1, dt.Rows(i)("ngay"))
        '        Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = '" + Format(dt.Rows(i)("NGAY"), "MM/dd/yyyy").ToString & _
        '        "' WHERE STT = '" + dt.Rows(i - 1)("STT").ToString + "'"
        '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        '    End If
        'Next


        For i As Integer = 0 To rowCount - 1
            Try
                If i = 0 Then
                    Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY = NULL WHERE STT = 0"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If
                If i = rowCount - 1 Then
                    If dt.Rows(i)("MS_MAY").ToString <> dt.Rows(i + 1)("MS_MAY").ToString Then
                        Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = NULL WHERE STT = '" + dt.Rows(i)("STT").ToString + "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    End If
                Else
                    If dt.Rows(i)("MS_MAY").ToString = dt.Rows(i + 1)("MS_MAY").ToString Then
                        Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = '" + Format(dt.Rows(i + 1)("NGAY_KE_TIEP"), "MM/dd/yyyy").ToString & _
                            "' WHERE STT = '" + dt.Rows(i)("STT").ToString + "'"

                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Else
                        Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = NULL WHERE STT = '" + dt.Rows(i)("STT").ToString + "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    End If
                End If

            Catch ex As Exception
                Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = NULL WHERE STT = '" + dt.Rows(i)("STT").ToString + "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            End Try

        Next

        Try

            dtt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DBO.NHOC  ORDER BY MS_MAY , NGAY, TU_GIO "))
            For Each dr As DataRow In dtt.Rows
                If Convert.ToDateTime(dr("NGAY_KE_TIEP").ToString).Date = "#1/1/1900#" Then
                    Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = '" + Format(dr("NGAY"), "MM/dd/yyyy").ToString + "' WHERE STT = '" + dr("STT").ToString + "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If
            Next
        Catch ex As Exception

        End Try

        Dim obj As New Commons.clsprintnhanvien
        obj.Update_bangngayhuhong()
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            Dim x As Integer
            Dim dt As New DataTable
            '  Dim frmrpt As New frmReports
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If loaibaocao = 2 Then
                Commons.Modules.ObjSystems.XoaTable("dbo.NHOC_MS_MAY")
                Commons.Modules.SQLString = "CREATE TABLE dbo.NHOC_MS_MAY(MS_MAY NVARCHAR(50))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                x = 0
                For x = 1 To dem
                    amay(x) = ""
                Next
                dem = 0
                x = 0
                For Each dr As DataGridViewRow In dgvShow.Rows
                    If dr.Cells("CHON").Value.ToString = "True" Then
                        x = x + 1
                        amay(x) = dr.Cells("MS_MAY").Value.ToString
                        dem = dem + 1
                        Commons.Modules.SQLString = "INSERT INTO dbo.NHOC_MS_MAY VALUES(N'" + dr.Cells("MS_MAY").Value.ToString + "')"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    End If
                Next
                loadTemp()

                Select Case baocao
                    Case 0
                        Xuatexcel_thang()

                        'ReportPreview("reports\rptMTBF_MAY.rpt")
                        'Me.Cursor = Cursors.Default
                    Case 1
                        Xuatexcel_QUy()

                        'ReportPreview("reports\rptMTBF_MAY_NAM.rpt")
                        ' Me.Cursor = Cursors.Default
                    Case 2
                        xuat_excelnam()
                        '  ReportPreview("reports\RPTMTBF_THANG.rpt")
                        ' Me.Cursor = Cursors.Default
                End Select
            Else
                Commons.Modules.ObjSystems.XoaTable("dbo.NHOC_MS_MAY")
                Commons.Modules.SQLString = "CREATE TABLE dbo.NHOC_MS_MAY(MS_MAY NVARCHAR(50))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                x = 0
                For x = 1 To dem
                    amay(x) = ""
                Next
                dem = 0
                x = 0
                For Each dr As DataGridViewRow In dgvShow.Rows

                    If dr.Cells("CHON").Value.ToString = "True" Then
                        x = x + 1
                        amay(x) = dr.Cells("MS_MAY").Value.ToString
                        dem = dem + 1
                        Commons.Modules.SQLString = "INSERT INTO dbo.NHOC_MS_MAY VALUES(N'" + dr.Cells("MS_MAY").Value.ToString + "')"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    End If
                Next
                Commons.Modules.ObjSystems.XoaTable("dbo.Rpttinhthoigiansuachuatrungbinh_haimay")
                Dim obj As New Commons.clsprintnhanvien
                obj.Rpttinhthoigiansuachuatrungbinh()
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Select Case baocao
                    Case 0
                        Xuatexcel_thang_thoigiantrungbinh()

                    Case 1
                        Xuatexcel_QUy_thoigiantrungbinh()

                    Case 2
                        xuat_excelnam_thoigiantrungbinh()
                   
                End Select
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub Xuatexcel_QUy()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True

                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTDTGTB2LANHUQUY", Commons.Modules.TypeLanguage) '"THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)""THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG"
                '.Range("D2:F2").Merge()
                .Cells(2, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTuQuy", _
                            Commons.Modules.TypeLanguage) & " " & tu & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                            "rptTHOI_GIAN_SUA_CHUA_TB", "bcDenQuy", Commons.Modules.TypeLanguage) & " " & den '"Từ Quý  " & tu & "  Đến quý " & den

                ExcelSheets.Cells(2, 2).Font.Bold = True
                dt = obj.Getquy_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) '"MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(3, 1).Font.Bold = True
                ExcelSheets.Cells(3, 1).ColumnWidth = 20
                Dim stmp As String
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcQuy", Commons.Modules.TypeLanguage) '
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = stmp & " " & row("quy")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        Dim TNgay, DNgay As Date
                        TNgay = row("TU_NGAY")
                        DNgay = row("DEN_NGAY")
                        Try
                            dt1 = New DataTable
                            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThoiGianTBHuHongNew", TNgay, DNgay, -1, amay(j)))
                        Catch ex As Exception
                            'Loi thi chay code cu
                            dt1 = obj.Tinhthoigian_baocao(amay(j), row("quy"))
                        End Try


                        'dt1 = obj.Tinhthoigian_baocao(amay(j), row("quy"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
        Catch
        End Try
    End Sub
    Public Sub Xuatexcel_QUy_thoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) '"THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                .Range("D2:F2").Merge()
                .Cells(2, 4) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTuQuy", _
                            Commons.Modules.TypeLanguage) & " " & tu & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                            "rptTHOI_GIAN_SUA_CHUA_TB", "bcDenQuy", Commons.Modules.TypeLanguage) & " " & den '"Từ Quý  " & tu & "  Đến quý " & den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getquy_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) '"MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                ExcelSheets.Cells(3, 1).Font.Bold = True
                Dim stmp As String
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcQuy", Commons.Modules.TypeLanguage) '

                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = stmp & " " & row("quy")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        dt1 = obj.Baocao_Tinhthoigiansuachuatrungbinh_quy(amay(j), row("quy"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub Xuatexcel_thang()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim tong As Double
            Dim sTmp As String
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            With ExcelSheets
                .Range("A1:I1").Merge()
                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTDTGTB2LANHU", Commons.Modules.TypeLanguage) '"THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                '.Range("D2:F2").Merge()

                .Cells(2, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTuThang", _
                            Commons.Modules.TypeLanguage) & " " & tu & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                            "rptTHOI_GIAN_SUA_CHUA_TB", "bcDenThang", Commons.Modules.TypeLanguage) & " " & den

                .Cells(2, 2).Font.Bold = True

                dt = obj.Getthang_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) '"MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(3, 1).Font.Bold = True
                .Cells(3, 1).ColumnWidth = 20
                .Cells(3, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcThang", Commons.Modules.TypeLanguage) '
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = sTmp & " " & row("thang")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1
                        row = dt.Rows(i)
                        Dim TNgay, DNgay, Thang As Date
                        Try
                            Thang = Convert.ToDateTime(row("thang").ToString)
                            TNgay = Thang
                            DNgay = TNgay.AddMonths(1).AddDays(-1)
                            dt1 = New DataTable
                            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThoiGianTBHuHongNew", TNgay, DNgay, -1, amay(j)))
                        Catch ex As Exception
                            'neu loi tinh theo cach cu
                            dt1 = obj.Tinhthoigianbythang(amay(j), row("thang"))
                        End Try

                        'dt1 = obj.Tinhthoigianbythang(amay(j), row("thang"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            '  tong = tong + thoigian
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next


                Next

                k = k + 1
                Dim biendem As Integer
                Dim tongtruoc As Double
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If


                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub


    Public Sub Xuatexcel_thang_thoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Integer
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("K")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("L")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("M")
                colums.ColumnWidth = 15
                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "TIEU_DE", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                .Range("D2:F2").Merge()
                .Cells(2, 4) = "Từ tháng  " & tu & "  Đến tháng " & den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                '.Range("A2:B2").Merge()
                '.Cells(2, 2) = "Từ ngày"
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getthang_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) ' "MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                ExcelSheets.Cells(3, 1).Font.Bold = True
                Dim sTmp As String
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcThang", Commons.Modules.TypeLanguage) '

                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = sTmp & " " & row("thang")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        dt1 = obj.Baocao_Tinhthoigiansuachuatrungbinh_thang(amay(j), row("thang"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            '  tong = tong + thoigian
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next


                Next

                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try


    End Sub
    Public Sub xuat_excelnam()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                '.Range("A1:F1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("A1:F1").Font.Bold = True
                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTDTGTB2LANHUNAM", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG"
                '.Range("A2:D2").Merge()
                .Cells(2, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTuNam", _
                            Commons.Modules.TypeLanguage) & " " & tu & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                            "rptTHOI_GIAN_SUA_CHUA_TB", "bcDenNam", Commons.Modules.TypeLanguage) & " " & den '"Từ năm  " & tu & "  Đến năm " & den
                '.Range(.Cells(2, 1), .Cells(2, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 2).Font.Bold = True
                dt = obj.Getnam_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) '"MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Cells(3, 1).Font.Bold = True
                .Cells(3, 1).ColumnWidth = 15
                Dim stmp As String
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcNam", Commons.Modules.TypeLanguage) '

                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = stmp & " " & row("nam")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1
                        row = dt.Rows(i)

                        Dim Thang, TNgay, DNgay As Date
                        Thang = Convert.ToDateTime("01/01/" + row("nam").ToString)
                        TNgay = Thang
                        DNgay = TNgay.AddYears(1).AddDays(-1)
                        Try
                            dt1 = New DataTable
                            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThoiGianTBHuHongNew", TNgay, DNgay, -1, amay(j)))
                        Catch ex As Exception
                            ' Neu loi chay code cu
                            dt1 = obj.Tinhthoigianbaocaobynam(amay(j), row("nam"))
                        End Try


                        'dt1 = obj.Tinhthoigianbaocaobynam(amay(j), row("nam"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            ExcelSheets.Cells(k, l).ColumnWidth = 20
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            ExcelSheets.Cells(k, l).ColumnWidth = 20

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next

                Dim tongtruoc As Double
                Dim biendem As Integer
                k = k + 1
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If


                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub

    Public Sub xuat_excelnam_thoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:F1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) '"THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                .Range("A2:D2").Merge()
                .Cells(2, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcTuNam", _
                            Commons.Modules.TypeLanguage) & " " & tu & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                            "rptTHOI_GIAN_SUA_CHUA_TB", "bcDenNam", Commons.Modules.TypeLanguage) & " " & den '"Từ năm  " & tu & "  Đến năm " & den
                .Range(.Cells(2, 2), .Cells(2, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getnam_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcMsMay", Commons.Modules.TypeLanguage) '"MS.Máy"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                ExcelSheets.Cells(3, 1).Font.Bold = True
                Dim sTmp As String
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "bcNam", Commons.Modules.TypeLanguage) '

                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = sTmp & " " & row("nam")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        dt1 = obj.Baocao_Tinhthoigiansuachuatrungbinh_nam(amay(j), row("nam"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = amay(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
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
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal check As Integer) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_TGSCTB_NEW]", check))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), check)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_TGSCTB_NEW]", check))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal check As Integer, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, check)
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
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        loadCboTheoXuong()
    End Sub
End Class