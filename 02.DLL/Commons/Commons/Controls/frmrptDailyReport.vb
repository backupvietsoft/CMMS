Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Excel
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Drawing

Public Class frmrptDailyReport
    Private vNgay As DateTime

    Private Sub frmrptDailyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindData()
    End Sub

    ' Set ngôn ngữ
    Private Sub RefeshLanguage()
        Me.lbaChonXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", lbaChonXuong.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", "rptDailyReport", Commons.Modules.TypeLanguage)
        Me.lbaChonNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", lbaChonNgay.Name, Commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", btnThucHien.Name, Commons.Modules.TypeLanguage)
    End Sub

    ' Load Data combo Nhà xưởng
    Private Sub BindData()
        Try
            cbxChonXuong.ValueMember = "MS_N_XUONG"
            cbxChonXuong.DisplayMember = "Ten_N_XUONG"
            cbxChonXuong.DropDownWidth = 200
            Dim vStr As String = "SELECT NHA_XUONG.MS_N_XUONG, NHA_XUONG.TEN_N_XUONG FROM NHA_XUONG INNER JOIN NHOM_NHA_XUONG ON NHA_XUONG.MS_N_XUONG = NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN USERS ON NHOM_NHA_XUONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
            Dim vTbNhaXuong As System.Data.DataTable = New System.Data.DataTable()
            Dim s As String = Commons.IConnections.ConnectionString
            vTbNhaXuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStr))
            cbxChonXuong.DataSource = vTbNhaXuong
        Catch ex As Exception
        End Try

    End Sub

    ' Kiểm tra ngày
    Private Sub mtxtChonNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtChonNgay.Validating

        Try
            vNgay = DateTime.ParseExact(mtxtChonNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", "NgayChuaDungDD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtChonNgay_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtChonNgay.Validated
        Try

        Catch ex As Exception
        End Try
    End Sub
    ' Tinh ngay dau tuan


    Public Shared Function FirstDayOfWeek(ByVal day As DateTime, ByVal weekStarts As DayOfWeek) As DateTime
        Dim d As DateTime = day
        While (d.DayOfWeek <> weekStarts)
            d = d.AddDays(-1)
        End While
        Return (d)
    End Function

    Public Shared Function LocationDayOfWeek(ByVal day As DateTime, ByVal weekStarts As DayOfWeek) As Integer
        Dim d As DateTime = day
        Dim STT As Integer = 0
        While (d.DayOfWeek <> weekStarts)
            d = d.AddDays(-1)
            STT = STT + 1
        End While

        Return STT
    End Function

    Public Shared Function LastDayOfWeek(ByVal day As DateTime, ByVal weekStarts As DayOfWeek) As DateTime
        Dim d As DateTime = day
        While (d.DayOfWeek <> weekStarts)
            d = d.AddDays(+1)
        End While
        Return (d)
    End Function


    'Thực hiện In 
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            'kiểm tra nhà xưởng
            Try
                If cbxChonXuong.Text.ToString.Trim.Equals("") Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", "ChuaChonN_XUONG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    cbxChonXuong.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
            'kiểm tra ngày chọn
            Try
                If mtxtChonNgay.Text.ToString.Trim.Equals("/  /") Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", "ChuaChonNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    mtxtChonNgay.Focus()
                    Exit Sub
                Else
                    vNgay = DateTime.ParseExact(mtxtChonNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDailyReport", "NgayChuaDungDD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtChonNgay.Focus()
                Exit Sub
            End Try
            ' dim vStrListMay =  
            'Creat Excel 

            Dim vTbTTC As New Data.DataTable
            Dim vStrTTC As String = "SELECT * from THONG_TIN_CHUNG "
            Dim s As String = Commons.IConnections.ConnectionString
            vTbTTC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStrTTC))


            Me.Cursor = Cursors.WaitCursor

            Dim excel As New Excel.Application
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet
            excel.Visible = False
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            Dim ss As String = wSheet.Name
            Dim es As String = excel.Name
            Dim sttt As Integer = wBook.Sheets.Count

            With wSheet
                .Columns(1).ColumnWidth = 5
                .Columns(2).ColumnWidth = 5
                .Columns(3).ColumnWidth = 15
                For i As Integer = 4 To 24
                    .Columns(i).ColumnWidth = 4
                Next
                .Rows(1).RowHeight = 20
                .Rows(2).RowHeight = 20
                .Rows(3).RowHeight = 20
                .Rows(4).RowHeight = 18
            End With

            'Xuất Logo
            Try
                Dim ImageCell As Object = "A1"
                Dim range As Excel.Range
                range = wSheet.Range(ImageCell)
                If Not IsDBNull(vTbTTC.Rows(0)("LOGO")) Then
                    Dim arrPicture As Byte() = vTbTTC.Rows(0)("LOGO")
                    Dim ms As New IO.MemoryStream(arrPicture)
                    Dim image As Image = System.Drawing.Image.FromStream(ms)

                    Dim newImage As New Bitmap(170, 30)
                    Dim gr_dest As Graphics = Graphics.FromImage(newImage)
                    gr_dest.DrawImage(image, 0, 0, _
                        newImage.Width + 1, _
                        newImage.Height + 1)
                    image = newImage
                    Clipboard.SetDataObject(image, True)
                    range.Select()
                    wSheet.Paste()
                End If
            Catch ex As Exception
            End Try
            ' Tiêu đề bên trái
            'Xuất thông tin nhà xưởng
            Dim rangeNX As Excel.Range
            rangeNX = wSheet.Range("A2", "D2")
            rangeNX.Merge(True)
            rangeNX.Font.Color = RGB(255, 0, 0)
            rangeNX.Value = cbxChonXuong.Text

            Dim rangelb1 As Excel.Range
            rangelb1 = wSheet.Range("A3", "D3")
            rangelb1.Merge(True)
            rangelb1.Value = " Maintenance Department"

            Dim rangelb2 As Excel.Range
            rangelb2 = wSheet.Range("A4", "D4")
            rangelb2.Merge(True)
            rangelb2.Value = " Date:  " & mtxtChonNgay.Text

            Dim range1 As Excel.Range
            range1 = wSheet.Range("A4", "AB4")
            range1.Merge(True)
            range1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Xuất thông tin tiêu đề
            Dim rangeTieuDe As Excel.Range
            rangeTieuDe = wSheet.Range("E1", "X3")
            rangeTieuDe.Merge(True)
            rangeTieuDe.MergeCells = True
            rangeTieuDe.Value = "MAINTENANCE DAILY REPORT"
            rangeTieuDe.Font.Bold = True
            rangeTieuDe.Font.Size = 18
            rangeTieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeTieuDe.VerticalAlignment = XlVAlign.xlVAlignCenter

            'Tiêu đề bên phải
            For i As Integer = 1 To 3
                Dim rangeTDright As Excel.Range
                rangeTDright = wSheet.Range("Y" & i.ToString, "AB" & i.ToString)
                rangeTDright.Merge(True)
                rangeTDright.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Next
            Dim rangelb3 As Excel.Range
            rangelb3 = wSheet.Range("Y1", "AB1")
            rangelb3.Font.Color = RGB(255, 0, 0)
            rangelb3.Value = "No: "

            Dim rangelb4 As Excel.Range
            rangelb4 = wSheet.Range("Y2", "AB2")
            rangelb4.Font.Color = RGB(255, 0, 0)
            rangelb4.Value = "Rev: "

            Dim rangelb5 As Excel.Range
            rangelb5 = wSheet.Range("Y3", "AB3")
            rangelb5.Font.Color = RGB(255, 0, 0)
            rangelb5.Value = "Date: "

            'Tiêu đề nội dung

            Dim rangeWDL As Excel.Range
            rangeWDL = wSheet.Range("A5", "J5")
            rangeWDL.Merge(True)
            rangeWDL.Font.Bold = True
            rangeWDL.Font.Size = 15
            rangeWDL.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rangeWDL.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeWDL.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeWDL.Value = "Works daily report"

            Dim rangeDTDL As Excel.Range
            rangeDTDL = wSheet.Range("K5", "AB5")
            rangeDTDL.Merge(True)
            rangeDTDL.Font.Bold = True
            rangeDTDL.Font.Size = 15
            rangeDTDL.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rangeDTDL.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeDTDL.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeDTDL.Value = "Down time daily report"

            'No 
            Dim rangeNO As Excel.Range
            rangeNO = wSheet.Range("A6", "A8")
            rangeNO.Merge(True)
            rangeNO.MergeCells = True
            rangeNO.Value = "No"
            rangeNO.Font.Bold = True
            rangeNO.Font.Size = 12
            rangeNO.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeNO.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeNO.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            '"Content of Job"

            Dim rangeCoJ As Excel.Range
            rangeCoJ = wSheet.Range("B6", "H8")
            rangeCoJ.Merge(True)
            rangeCoJ.MergeCells = True
            rangeCoJ.Value = "Content of Job"
            rangeCoJ.Font.Bold = True
            rangeCoJ.Font.Size = 12
            rangeCoJ.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeCoJ.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeCoJ.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Result
            Dim rangeRes As Excel.Range
            rangeRes = wSheet.Range("I6", "J8")
            rangeRes.Merge(True)
            rangeRes.MergeCells = True
            rangeRes.Value = "Results"
            rangeRes.Font.Bold = True
            rangeRes.Font.Size = 12
            rangeRes.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeRes.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeRes.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)


            'No 1
            Dim rangeNo1 As Excel.Range
            rangeNo1 = wSheet.Range("K6", "K8")
            rangeNo1.Merge(True)
            rangeNo1.MergeCells = True
            rangeNo1.Value = "No"
            rangeNo1.Font.Bold = True
            rangeNo1.Font.Size = 12
            rangeNo1.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeNo1.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeNo1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Critical machine
            Dim rangeCriMch As Excel.Range
            rangeCriMch = wSheet.Range("L6", "Q8")
            rangeCriMch.Merge(True)
            rangeCriMch.MergeCells = True
            rangeCriMch.Value = "Critical machine "
            rangeCriMch.Font.Bold = True
            rangeCriMch.Font.Size = 12
            rangeCriMch.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeCriMch.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeCriMch.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Day in week
            Dim rangeDIW As Excel.Range
            rangeDIW = wSheet.Range("R6", "X7")
            rangeDIW.Merge(True)
            rangeDIW.MergeCells = True
            rangeDIW.Value = "Day in week"
            rangeDIW.Font.Bold = True
            rangeDIW.Font.Size = 12
            rangeDIW.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeDIW.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeDIW.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgMon As Excel.Range
            rgMon = wSheet.Range("R8", "R8")
            rgMon.Font.Size = 12
            rgMon.Value = "Mon"
            rgMon.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)


            Dim rgTue As Excel.Range
            rgTue = wSheet.Range("S8", "S8")
            rgTue.Font.Size = 12
            rgTue.Value = "Tue"
            rgTue.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgWed As Excel.Range
            rgWed = wSheet.Range("T8", "T8")
            rgWed.Font.Size = 12
            rgWed.Value = "Wed"
            rgWed.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgThu As Excel.Range
            rgThu = wSheet.Range("U8", "U8")
            rgThu.Font.Size = 12
            rgThu.Value = "Thu"
            rgThu.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgFri As Excel.Range
            rgFri = wSheet.Range("V8", "V8")
            rgFri.Font.Size = 12
            rgFri.Value = "Fri"
            rgFri.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgSat As Excel.Range
            rgSat = wSheet.Range("W8", "W8")
            rgSat.Font.Size = 12
            rgSat.Value = "Sat"
            rgSat.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgSun As Excel.Range
            rgSun = wSheet.Range("X8", "X8")
            rgSun.Font.Size = 12
            rgSun.Value = "Sun"
            rgSun.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Total in week (14th)
            Dim rangeTotalIW As Excel.Range
            rangeTotalIW = wSheet.Range("Y6", "AB6")
            rangeTotalIW.Merge(True)
            rangeTotalIW.MergeCells = True
            rangeTotalIW.Value = "Total in week (14th)"
            rangeTotalIW.Font.Bold = True
            rangeTotalIW.Font.Size = 12
            rangeTotalIW.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeTotalIW.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeTotalIW.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Damage
            Dim rangeDamage As Excel.Range
            rangeDamage = wSheet.Range("Y7", "Z7")
            rangeDamage.Merge(True)
            rangeDamage.MergeCells = True
            rangeDamage.Value = "Damage"
            rangeDamage.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeDamage.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeDamage.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            'Main't
            Dim rangeMain As Excel.Range
            rangeMain = wSheet.Range("AA7", "AB7")
            rangeMain.Merge(True)
            rangeMain.MergeCells = True
            rangeMain.Value = "Main't"
            rangeMain.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
            rangeMain.VerticalAlignment = XlVAlign.xlVAlignCenter
            rangeMain.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgTime1 As Excel.Range
            rgTime1 = wSheet.Range("Y8", "Y8")
            rgTime1.Font.Size = 11
            rgTime1.Value = "Time(hr)"
            rgTime1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgTime2 As Excel.Range
            rgTime2 = wSheet.Range("AA8", "AA8")
            rgTime2.Font.Size = 11
            rgTime2.Value = "Time(hr)"
            rgTime2.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgTimes1 As Excel.Range
            rgTimes1 = wSheet.Range("Z8", "Z8")
            rgTimes1.Font.Size = 11
            rgTimes1.Value = "Times"
            rgTimes1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgTimes2 As Excel.Range
            rgTimes2 = wSheet.Range("AB8", "AB8")
            rgTimes2.Font.Size = 11
            rgTimes2.Value = "Times"
            rgTimes2.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim vTbCV As New Data.DataTable
            Dim vStrCV As String = " Select dbo.PHIEU_BAO_TRI.*, dbo.MAY.TEN_MAY from phieu_bao_tri INNER JOIN" & _
            " dbo.MAY ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY " & _
            " where CONVERT(DATETIME,NGAY_BD_KH,104) <= CONVERT(DATETIME,'" & mtxtChonNgay.Text & "',104) " & _
            " AND CONVERT(DATETIME,NGAY_KT_KH,104) >= CONVERT(DATETIME,'" & mtxtChonNgay.Text & "',104)" & _
            " And TINH_TRANG_PBT >1 "
            vTbCV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStrCV))




            Dim vTbTB As New Data.DataTable
            Dim vTuNgay As DateTime = FirstDayOfWeek(vNgay, DayOfWeek.Monday)
            Dim vDenNgaY As DateTime = LastDayOfWeek(vNgay, DayOfWeek.Sunday)

            vTbTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDataDailyReport", vTuNgay, vDenNgaY, cbxChonXuong.SelectedValue.ToString.Trim))


            Dim vList As String = ""

            Dim vTbListMay As New Data.DataTable

            Dim vSListMay As String = "SELECT distinct MS_MAY FROM THOI_GIAN_NGUNG_MAY_DAILY_TMP"
            vTbListMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vSListMay))

            'Tong so dong 
            Dim vTnumber As Integer = 0
            'Số dòng công việc
            Dim vTCV As Integer = 0
            'Số dòng Thiết bị
            Dim vTThietbi As Integer = 0

            If vTbListMay.Rows.Count > vTbCV.Rows.Count Then
                vTnumber = vTbListMay.Rows.Count
            Else
                vTnumber = vTbCV.Rows.Count
            End If


            For i As Integer = 0 To vTnumber - 1
                Dim rgtt As Excel.Range
                rgtt = wSheet.Range("A" & 9 + i, "AB" & 9 + i)
                rgtt.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlHairline)
            Next

            Dim rg1 As Excel.Range
            rg1 = wSheet.Range("A9", "A" & 9 + vTnumber - 1)
            rg1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg2 As Excel.Range
            rg2 = wSheet.Range("B9", "H" & 9 + vTnumber - 1)
            rg2.Merge(True)
            rg2.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg3 As Excel.Range
            rg3 = wSheet.Range("I9", "J" & 9 + vTnumber - 1)
            rg3.Merge(True)
            rg3.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg4 As Excel.Range
            rg4 = wSheet.Range("K9", "K" & 9 + vTnumber - 1)
            rg4.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg5 As Excel.Range
            rg5 = wSheet.Range("L9", "Q" & 9 + vTnumber - 1)
            rg5.Merge(True)
            rg5.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg6 As Excel.Range
            rg6 = wSheet.Range("S9", "S" & 9 + vTnumber - 1)
            rg6.Merge(True)
            rg6.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg7 As Excel.Range
            rg7 = wSheet.Range("U9", "U" & 9 + vTnumber - 1)
            ' rg7.Merge(True)
            rg7.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg8 As Excel.Range
            rg8 = wSheet.Range("W9", "W" & 9 + vTnumber - 1)
            'rg8.Merge(True)
            rg8.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg9 As Excel.Range
            rg9 = wSheet.Range("Y9", "Y" & 9 + vTnumber - 1)
            'rg9.Merge(True)
            rg9.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg10 As Excel.Range
            rg10 = wSheet.Range("AA9", "AA" & 9 + vTnumber - 1)
            'rg10.
            rg10.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rg11 As Excel.Range
            rg11 = wSheet.Range("AB9", "AB" & 9 + vTnumber - 1)
            'rg11.Merge(True)
            rg11.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)


            ' Xuat cong việc
            Dim xNo As Excel.Range
            Dim xCV As Excel.Range
            For i As Integer = 0 To vTbCV.Rows.Count - 1
                xNo = wSheet.Range("A" & 9 + i, "A" & 9 + i)
                xCV = wSheet.Range("B" & 9 + i, "B" & 9 + i)
                xNo.Value = i + 1
                xNo.VerticalAlignment = XlVAlign.xlVAlignCenter
                xNo.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                xCV.Value = vTbCV.Rows(i)("MS_MAY") & " " & vTbCV.Rows(i)("TEN_MAY") & vTbCV.Rows(i)("LY_DO_BT")
            Next


            Dim xTotalGio As Excel.Range
            Dim xTotalGioHH As Excel.Range
            Dim xTS As Excel.Range
            Dim xTSHH As Excel.Range
            Dim xDay As Excel.Range
            Try


                For i As Integer = 0 To vTbListMay.Rows.Count - 1
                    xNo = wSheet.Range("K" & 9 + i, "K" & 9 + i)
                    xCV = wSheet.Range("L" & 9 + i, "L" & 9 + i)
                    xNo.Value = i + 1
                    xNo.VerticalAlignment = XlVAlign.xlVAlignCenter
                    xNo.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                    xCV.Value = vTbListMay.Rows(i)("MS_MAY")

                    Dim vMSMAY = vTbListMay.Rows(i)("MS_MAY")
                    Dim vTongsogio As Integer = 0
                    Dim vTonggioHuHong As Integer = 0
                    Dim vTS As Integer = 0
                    Dim vTSHH As Integer = 0
                    Dim vDay As String = ""
                    For j As Integer = 0 To vTbTB.Rows.Count - 1
                        If vMSMAY = vTbTB.Rows(j)("MS_MAY") Then
                            'Dim vNgay As String = vTbTB.Rows(j)("NGAY")
                            'Dim hh As String = vTbTB.Rows(j)("HU_HONG")
                            Dim gio As Integer = Integer.Parse(vTbTB.Rows(j)("SOGIO").ToString) / 60
                            If vTbTB.Rows(j)("HU_HONG").ToString.ToUpper = "TRUE" Then
                                vTonggioHuHong = vTonggioHuHong + Integer.Parse(vTbTB.Rows(j)("SOGIO"))
                                vTSHH = vTSHH + 1
                                vDay = "D" & gio.ToString("##.##")
                            Else
                                vTongsogio = vTongsogio + Integer.Parse(vTbTB.Rows(j)("SOGIO"))
                                vTS = vTS + 1
                                If vDay = "" Then
                                    vDay = gio.ToString("##.##")
                                Else
                                    vDay = vDay & ";" & gio.ToString("##.##")
                                End If

                            End If
                            Dim vVT As Integer = LocationDayOfWeek(vTbTB.Rows(j)("NGAY"), DayOfWeek.Monday)

                            If vVT = 0 Then
                                xDay = wSheet.Range("R" & 9 + i, "R" & 9 + i)
                                xDay.Value = vDay
                            End If

                            If vVT = 1 Then
                                xDay = wSheet.Range("S" & 9 + i, "S" & 9 + i)
                                xDay.Value = vDay
                            End If
                            If vVT = 2 Then
                                xDay = wSheet.Range("T" & 9 + i, "T" & 9 + i)
                                xDay.Value = vDay
                            End If
                            If vVT = 3 Then
                                xDay = wSheet.Range("U" & 9 + i, "U" & 9 + i)
                                xDay.Value = vDay
                            End If
                            If vVT = 4 Then
                                xDay = wSheet.Range("V" & 9 + i, "V" & 9 + i)
                                xDay.Value = vDay
                            End If
                            If vVT = 5 Then
                                xDay = wSheet.Range("W" & 9 + i, "W" & 9 + i)
                                xDay.Value = vDay
                            End If
                            If vVT = 6 Then
                                xDay = wSheet.Range("X" & 9 + i, "X" & 9 + i)
                                xDay.Value = vDay
                            End If


                        End If
                    Next


                    xTotalGioHH = wSheet.Range("Y" & 9 + i, "Y" & 9 + i)
                    xTotalGioHH.Value = vTonggioHuHong

                    xTotalGio = wSheet.Range("AA" & 9 + i, "AA" & 9 + i)
                    xTotalGio.Value = vTongsogio

                    xTS = wSheet.Range("AB" & 9 + i, "AB" & 9 + i)
                    xTS.VerticalAlignment = XlVAlign.xlVAlignCenter
                    xTS.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                    xTS.Value = vTS

                    xTSHH = wSheet.Range("Z" & 9 + i, "Z" & 9 + i)
                    xTSHH.VerticalAlignment = XlVAlign.xlVAlignCenter
                    xTSHH.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                    xTSHH.Value = vTSHH





                Next


            Catch ex As Exception

            End Try



            Dim rgfooter As Excel.Range
            rgfooter = wSheet.Range("A" & 9 + vTnumber, "AB" & 9 + vTnumber)
            rgfooter.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim vTbLTB As System.Data.DataTable = New System.Data.DataTable

            Dim vsLoaiMay As String = "SELECT COUNT(dbo.MAY.MS_MAY) AS SOLUONGMAY, dbo.LOAI_MAY.TEN_LOAI_MAY " & _
                                    " FROM dbo.LOAI_MAY INNER JOIN " & _
                      "  dbo.NHOM_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_MAY.MS_LOAI_MAY INNER JOIN " & _
                      " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " & _
                      " dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY " & _
                      " WHERE (dbo.MAY.MS_HIEN_TRANG = 2) AND (dbo.MAY_NHA_XUONG.MS_N_XUONG = N'" & cbxChonXuong.SelectedValue.ToString.Trim & "') " & _
                     " GROUP BY dbo.LOAI_MAY.TEN_LOAI_MAY "
            vTbLTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vsLoaiMay))

            Dim sl As Integer = vTbLTB.Rows.Count
            Dim sodong As Integer = sl / 2
            If sl Mod 2 = 0 Then
                sodong = sl / 2
                If sodong < 7 Then
                    sodong = 7
                End If
            Else
                sodong = sodong + 1
                If sodong < 7 Then
                    sodong = 7
                End If
            End If


            'Footer report

            ''If vTnumber = 1 Then
            vTnumber = vTnumber + 1
            '' End If


            Dim headFoot As Integer = 9 + vTnumber

            For i As Integer = 1 To sodong - 2
                Dim rgtt As Excel.Range
                rgtt = wSheet.Range("A" & headFoot + i + 1, "AB" & headFoot + i + 1)
                rgtt.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlHairline)
            Next

            Dim rgEqui As Excel.Range
            rgEqui = wSheet.Range("A" & 9 + vTnumber, "A" & headFoot + sodong)
            rgEqui.Merge(True)
            rgEqui.MergeCells = True
            rgEqui.Value = "Equipment status list"
            rgEqui.Font.Bold = True
            rgEqui.Font.Size = 10
            rgEqui.Orientation = XlOrientation.xlUpward
            rgEqui.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rgEqui.VerticalAlignment = XlVAlign.xlVAlignCenter



            Dim rgf1 As Excel.Range
            rgf1 = wSheet.Range("B" & headFoot, "B" & headFoot + sodong)
            rgf1.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft1 As Excel.Range
            rgft1 = wSheet.Range("B" & headFoot, "B" & headFoot)
            rgft1.Value = "No"

            Dim rgf2 As Excel.Range
            rgf2 = wSheet.Range("C" & headFoot, "C" & headFoot + sodong)
            rgf2.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft2 As Excel.Range
            rgft2 = wSheet.Range("C" & headFoot, "C" & headFoot)
            rgft2.Value = "Name machine"

            Dim rgf3 As Excel.Range
            rgf3 = wSheet.Range("D" & headFoot, "D" & headFoot + sodong)
            rgf3.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft3 As Excel.Range
            rgft3 = wSheet.Range("D" & headFoot, "D" & headFoot)
            rgft3.Value = "total"

            Dim rgf4 As Excel.Range
            rgf4 = wSheet.Range("E" & headFoot, "E" & headFoot + sodong)
            rgf4.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft4 As Excel.Range
            rgft4 = wSheet.Range("E" & headFoot, "E" & headFoot)
            rgft4.Value = "Damage"

            Dim rgf5 As Excel.Range
            rgf5 = wSheet.Range("F" & headFoot, "F" & headFoot + sodong)
            rgf5.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft5 As Excel.Range
            rgft5 = wSheet.Range("F" & headFoot, "F" & headFoot)
            rgft5.Value = "Good"

            Dim rgf6 As Excel.Range
            rgf6 = wSheet.Range("G" & headFoot, "G" & headFoot + sodong)
            rgf6.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft6 As Excel.Range
            rgft6 = wSheet.Range("G" & headFoot, "G" & headFoot)
            rgft6.Value = "Use"

            Dim rgf7 As Excel.Range
            rgf7 = wSheet.Range("H" & headFoot, "H" & headFoot + sodong)
            rgf7.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft7 As Excel.Range
            rgft7 = wSheet.Range("H" & headFoot, "H" & headFoot)
            rgft7.Value = "Remain"

            Dim rgf8 As Excel.Range
            rgf8 = wSheet.Range("I" & headFoot, "I" & headFoot + sodong)
            rgf8.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft8 As Excel.Range
            rgft8 = wSheet.Range("I" & headFoot, "I" & headFoot)
            rgft8.Value = "No"

            Dim rgf9 As Excel.Range
            rgf9 = wSheet.Range("J" & headFoot, "L" & headFoot + sodong)
            rgf9.Merge(True)
            rgf9.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft9 As Excel.Range
            rgft9 = wSheet.Range("J" & headFoot, "L" & headFoot)
            rgft9.Value = "Name machine"

            Dim rgf11 As Excel.Range
            rgf11 = wSheet.Range("M" & headFoot, "M" & headFoot + sodong)
            rgf11.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft11 As Excel.Range
            rgft11 = wSheet.Range("M" & headFoot, "M" & headFoot)
            rgft11.Value = "Total"

            Dim rgf12 As Excel.Range
            rgf12 = wSheet.Range("N" & headFoot, "N" & headFoot + sodong)
            rgf12.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft12 As Excel.Range
            rgft12 = wSheet.Range("N" & headFoot, "N" & headFoot)
            rgft12.Value = "Damage"

            Dim rgf13 As Excel.Range
            rgf13 = wSheet.Range("O" & headFoot, "O" & headFoot + sodong)
            rgf13.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft13 As Excel.Range
            rgft13 = wSheet.Range("O" & headFoot, "O" & headFoot)
            rgft13.Value = "Good"

            Dim rgf14 As Excel.Range
            rgf14 = wSheet.Range("P" & headFoot, "P" & headFoot + sodong)
            rgf14.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft14 As Excel.Range
            rgft14 = wSheet.Range("P" & headFoot, "P" & headFoot)
            rgft14.Value = "Use"

            Dim rgf10 As Excel.Range
            rgf10 = wSheet.Range("Q" & headFoot, "Q" & headFoot + sodong)
            rgf10.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            Dim rgft10 As Excel.Range
            rgft10 = wSheet.Range("Q" & headFoot, "Q" & headFoot)
            rgft10.Value = "Remain"

            Dim rgf15 As Excel.Range
            rgf15 = wSheet.Range("R" & headFoot, "T" & headFoot + 1)
            rgf15.Merge(True)
            rgf15.MergeCells = True
            rgf15.Font.Bold = True
            rgf15.Value = "Report by"
            rgf15.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rgf15.VerticalAlignment = XlVAlign.xlVAlignCenter
            rgf15.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection


            Dim rgf16 As Excel.Range
            rgf16 = wSheet.Range("U" & headFoot, "X" & headFoot + 1)
            rgf16.Merge(True)
            rgf16.MergeCells = True
            rgf16.Font.Bold = True
            rgf16.Value = "Check by"
            rgf16.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rgf16.VerticalAlignment = XlVAlign.xlVAlignCenter
            rgf16.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

            Dim rgf17 As Excel.Range
            rgf17 = wSheet.Range("Y" & headFoot, "Z" & headFoot + 1)
            rgf17.Merge(True)
            rgf17.MergeCells = True
            rgf17.Font.Bold = True
            rgf17.Value = "Check by"
            rgf17.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rgf17.VerticalAlignment = XlVAlign.xlVAlignCenter
            rgf17.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

            Dim rgf18 As Excel.Range
            rgf18 = wSheet.Range("AA" & headFoot, "AB" & headFoot + 1)
            rgf18.Merge(True)
            rgf18.MergeCells = True
            rgf18.Font.Bold = True
            rgf18.Value = "Approve by"
            rgf18.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)
            rgf18.VerticalAlignment = XlVAlign.xlVAlignCenter
            rgf18.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection


            Dim rgf19 As Excel.Range
            rgf19 = wSheet.Range("R" & headFoot + 2, "T" & headFoot + sodong - 2)
            rgf19.Merge(True)
            rgf19.MergeCells = True
            rgf19.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf20 As Excel.Range
            rgf20 = wSheet.Range("U" & headFoot + 2, "X" & headFoot + sodong - 2)
            rgf20.Merge(True)
            rgf20.MergeCells = True
            rgf20.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf21 As Excel.Range
            rgf21 = wSheet.Range("Y" & headFoot + 2, "Z" & headFoot + sodong - 2)
            rgf21.Merge(True)
            rgf21.MergeCells = True
            rgf21.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf22 As Excel.Range
            rgf22 = wSheet.Range("AA" & headFoot + 2, "AB" & headFoot + sodong - 2)
            rgf22.Merge(True)
            rgf22.MergeCells = True
            rgf22.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)


            Dim rgf23 As Excel.Range
            rgf23 = wSheet.Range("R" & headFoot + sodong - 1, "T" & headFoot + sodong)
            rgf23.Merge(True)
            rgf23.MergeCells = True
            rgf23.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf24 As Excel.Range
            rgf24 = wSheet.Range("U" & headFoot + sodong - 1, "X" & headFoot + sodong)
            rgf24.Merge(True)
            rgf24.MergeCells = True
            rgf24.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf25 As Excel.Range
            rgf25 = wSheet.Range("Y" & headFoot + sodong - 1, "Z" & headFoot + sodong)
            rgf25.Merge(True)
            rgf25.MergeCells = True
            rgf25.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)

            Dim rgf26 As Excel.Range
            rgf26 = wSheet.Range("AA" & headFoot + sodong - 1, "AB" & headFoot + sodong)
            rgf26.Merge(True)
            rgf26.MergeCells = True
            rgf26.BorderAround(ColorIndex:=1, Weight:=XlBorderWeight.xlThin)


            If vTbLTB.Rows.Count < 7 Then

                For i As Integer = 0 To vTbLTB.Rows.Count - 1
                    Dim rfNoF As Excel.Range
                    Dim rgFData As Excel.Range
                    Dim rgFSL As Excel.Range
                    rfNoF = wSheet.Range("B" & headFoot + i + 1, "B" & headFoot + i + 1)
                    rfNoF.Value = i + 1
                    rfNoF.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rfNoF.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                    rgFData = wSheet.Range("C" & headFoot + i + 1, "C" & headFoot + i + 1)
                    rgFData.Value = vTbLTB.Rows(i)("TEN_LOAI_MAY")
                    rgFSL = wSheet.Range("D" & headFoot + i + 1, "D" & headFoot + i + 1)
                    rgFSL.Value = vTbLTB.Rows(i)("SOLUONGMAY")
                    rgFSL.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rgFSL.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

                Next
            Else
                Dim rfNoF As Excel.Range
                Dim rgFData As Excel.Range
                Dim rgFSL As Excel.Range
                For i As Integer = 0 To vTbLTB.Rows.Count / 2

                    rfNoF = wSheet.Range("B" & headFoot + i + 1, "B" & headFoot + i + 1)
                    rfNoF.Value = i + 1
                    rfNoF.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rfNoF.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

                    rgFData = wSheet.Range("C" & headFoot + i + 1, "C" & headFoot + i + 1)
                    rgFData.Value = vTbLTB.Rows(i)("TEN_LOAI_MAY")
                    rgFSL = wSheet.Range("D" & headFoot + i + 1, "D" & headFoot + i + 1)
                    rgFSL.Value = vTbLTB.Rows(i)("SOLUONGMAY")
                    rgFSL.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rgFSL.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

                Next
                Dim j As Integer = 0
                Dim rowNext As Integer = 0
                rowNext = (vTbLTB.Rows.Count / 2)
                If vTbLTB.Rows.Count Mod 2 = 0 Then
                    rowNext = rowNext + 1
                Else
                    rowNext = rowNext + 1
                End If


                For i As Integer = rowNext To vTbLTB.Rows.Count - 1
                    rfNoF = wSheet.Range("I" & headFoot + j + 1, "I" & headFoot + j + 1)
                    rfNoF.Value = i + 1
                    rfNoF.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rfNoF.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection

                    rgFData = wSheet.Range("J" & headFoot + j + 1, "J" & headFoot + j + 1)
                    rgFData.Value = vTbLTB.Rows(i)("TEN_LOAI_MAY")
                    rgFSL = wSheet.Range("M" & headFoot + j + 1, "M" & headFoot + j + 1)
                    rgFSL.Value = vTbLTB.Rows(i)("SOLUONGMAY")
                    rgFSL.VerticalAlignment = XlVAlign.xlVAlignCenter
                    rgFSL.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection
                    j = j + 1
                Next
            End If
            wSheet.Columns.AutoFit()
            excel.Visible = True
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Function tttttth() As Boolean
        Return False
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.Modules.ObjSystems.XoaTable("THOI_GIAN_NGUNG_MAY_DAILY_TMP")
        Me.ParentForm.Close()
    End Sub
End Class
