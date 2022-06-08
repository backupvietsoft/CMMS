Imports Microsoft.ApplicationBlocks.Data
Imports Excel

Public Class Addon_ucMTest
    Private Sub ucMTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtTmp As New System.Data.DataTable

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetNhomMay", "-1"))
        cboNhomMay.DataSource = dtTmp
        cboNhomMay.DisplayMember = "TEN_NHOM_MAY"
        cboNhomMay.ValueMember = "MS_NHOM_MAY"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        ParentForm.Close()

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Me.Cursor = Cursors.WaitCursor

        Dim ExcelApp As Excel.Application
        Try
            ExcelApp = GetObject(, "Excel.Application")
        Catch ex As Exception
            ExcelApp = New Excel.Application
        End Try
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet

        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        Dim Dong, TCot, Cot As Integer
        TCot = 9

        Dong = Commons.Modules.MExcel.TaoTTChung(ExcelSheets, 1, 3, 1, TCot)
        Commons.Modules.MExcel.TaoLogo(ExcelSheets, 0, 0, 110, 45, "D:")

        Commons.Modules.MExcel.DinhDang(ExcelSheets, "TieuDe", Dong, 1, "@", 14, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

        Dong = Dong + 1
        Commons.Modules.MExcel.DinhDang(ExcelSheets, Label1.Text + " : " + cboNhomMay.Text, Dong, 3, "@", 10, True, True, Dong, TCot)

        Dong = Dong + 1
        Cot = 1
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "Ms May", Dong, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, Cot)
        Cot = Cot + 1
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "Ten May", Dong, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, Cot + 1)
        Cot = Cot + 2
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "Mo ta", Dong, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, Cot + 1)
        Cot = Cot + 2
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "Nvu thiet bi", Dong, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, Cot + 1)
        Cot = Cot + 2
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "Model", Dong, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, Cot)
        Cot = Cot + 1
        Commons.Modules.MExcel.DinhDang(ExcelSheets, "NUOC_SX", Dong, Cot, "@", 10, True, True, Dong, Cot)
        Cot = Cot + 1

        Dim Sql As String
        Sql = "SELECT TOP 20 MS_MAY,TEN_MAY,MO_TA,NHIEM_VU_THIET_BI ,MODEL,NUOC_SX  FROM MAY "
        If cboNhomMay.SelectedValue.ToString() <> "-1" Then
            Sql = Sql + " WHERE MS_NHOM_MAY = '" & cboNhomMay.SelectedValue.ToString() & "'  "
        End If

        Dim dtTmp As New System.Data.DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))

        Dong = Dong + 1
        For Each vrow As DataRow In dtTmp.Rows
            Cot = 1
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("MS_MAY").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot)
            Cot = Cot + 1
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("TEN_MAY").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot + 1)
            Cot = Cot + 2
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("MO_TA").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot + 1)

            Cot = Cot + 2
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("NHIEM_VU_THIET_BI").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot + 1)

            Cot = Cot + 2
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("MODEL").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot)

            Cot = Cot + 1
            Commons.Modules.MExcel.DinhDang(ExcelSheets, vrow("NUOC_SX").ToString(), Dong, Cot, "@", 10, False, True, Dong, Cot)

            Dong = Dong + 1
        Next

        Commons.Modules.MExcel.ExcelEnd(ExcelApp, ExcelBooks, ExcelSheets, False, True, True, True, Excel.XlPaperSize.xlPaperA4, _
                Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)

        'Excel.Range title
        Dim title As Excel.Range
        title = Commons.Modules.MExcel.GetRange(ExcelSheets, 7, 1, Dong - 1, TCot)
        title.Borders.LineStyle = 1
        title.WrapText = 1

        title.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Sql As String
        Sql = "SELECT MS_MAY,TEN_MAY,MO_TA,NHIEM_VU_THIET_BI ,MODEL,NUOC_SX  FROM MAY "
        If cboNhomMay.SelectedValue.ToString() <> "-1" Then
            Sql = Sql + " WHERE MS_NHOM_MAY = '" & cboNhomMay.SelectedValue.ToString() & "'  "
        End If


        Dim dtTmp As New System.Data.DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
        dtTmp.TableName = "rptMTestMay"

        Dim FRM = New frmReport

        FRM.rptName = "rptMDataTestMay"
        FRM.AddDataTableSource(dtTmp)
        FRM.Show()


    End Sub
End Class
