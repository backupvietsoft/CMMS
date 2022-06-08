Imports Microsoft.ApplicationBlocks.Data
Imports System.IO
Public Class frmDanhSach
    Public vtbTB As New DataTable

    Private Sub frmDanhSach_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridControl1.DataSource = vtbTB
        GridView1.Columns("THIETBI").Group()
        GridView1.Columns("THIETBI").Caption = "Thiết bị"
        GridView1.ExpandAllGroups()


        GridView1.Columns("STT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "STT", Commons.Modules.TypeLanguage)
        GridView1.Columns("QUY_CACH").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "QUY_CACH", Commons.Modules.TypeLanguage)
        GridView1.Columns("MS_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "MS_PT", Commons.Modules.TypeLanguage)
        GridView1.Columns("MS_VI_TRI").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "MS_VI_TRI", Commons.Modules.TypeLanguage)
        GridView1.Columns("CHU_KY_HC_NOI").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "CHU_KY_HC_NOI", Commons.Modules.TypeLanguage)
        GridView1.Columns("TEN_DV_TG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "TEN_DV_TG", Commons.Modules.TypeLanguage)
        GridView1.Columns("DIEN_GIAI").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "DIEN_GIAI", Commons.Modules.TypeLanguage)
        GridView1.Columns("TEN_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "TEN_PT", Commons.Modules.TypeLanguage)

        btnExpand.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "btnExpand", Commons.Modules.TypeLanguage)
        btnColapse.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "btnColapse", Commons.Modules.TypeLanguage)
        btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "btnExport", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click
        Try
            GridView1.ExpandAllGroups()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnColapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColapse.Click
        Try
            GridView1.CollapseAllGroups()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim DUONGDAN As String
        Dim vtbTieude As New DataTable
        Dim sql As String
        Try
            If vtbTB.Rows.Count > 0 Then
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    DUONGDAN = SaveFileDialog1.FileName
                    GridControl1.ExportToXls(DUONGDAN)
                    Dim ExcelApp As New Excel.Application
                    Dim ExcelBooks As Excel.Workbook
                    Dim ExcelSheetsS As New Excel.Worksheet

                    ExcelBooks = ExcelApp.Workbooks.Open(DUONGDAN, , False)
                    ExcelSheetsS = ExcelBooks.Sheets.Item(1)
                    'Commons.Modules.TypeLanguage
                    If Commons.Modules.TypeLanguage = "0" Then
                        Sql = "select ten_cty_tieng_viet,Dia_chi_viet,Phone,Fax from thong_tin_chung"
                    Else
                        Sql = "select TEN_CTY_TIENG_ANH AS ten_cty_tieng_viet,DIA_CHI_ANH AS Dia_chi_viet,PHONE,FAX from thong_tin_chung"
                    End If
                    vtbTieude.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
                    Dim I As Integer
                    With ExcelSheetsS

                        .Range(.Cells(1, 1), .Cells(10000, 1)).ColumnWidth = 0
                        .Range(.Cells(1, 3), .Cells(1000, 3)).ColumnWidth = 32
                        .Range(.Cells(1, 3), .Cells(1000, 3)).WrapText = True
                        .Range(.Cells(1, 4), .Cells(1000, 4)).ColumnWidth = 19
                        .Range(.Cells(1, 4), .Cells(1000, 4)).WrapText = True
                        .Range(.Cells(1, 9), .Cells(1000, 9)).ColumnWidth = 24

                        For I = 1 To 8
                            .Rows("1:1").Insert(Excel.Constants.xlTop)
                        Next I

                        '
                        Dim dtTmp As New DataTable()
                        dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"))
                        Dim dv As New DataView(dtTmp)
                        GetImage(DirectCast(dv(0)("LOGO"), Byte()))
                        Dim pic1 As Excel.Shape
                        pic1 = ExcelSheetsS.Shapes.AddPicture(Application.StartupPath + "\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 5, 100, 30)
                        pic1.ScaleHeight(1, Office.MsoTriState.msoFalse)
                        pic1.ScaleWidth(1, Office.MsoTriState.msoFalse)
                        File.Delete(Application.StartupPath + "\logo.bmp")
                        .Range(.Cells(1, 1), .Cells(1, 1)).ColumnWidth = 20
                        Try
                            sql = vtbTieude.Rows(0).Item("ten_cty_tieng_viet").ToString & vbLf
                        Catch ex As Exception

                        End Try
                        Try
                            sql = sql & vtbTieude.Rows(0).Item("Dia_chi_viet").ToString & vbLf
                        Catch ex As Exception

                        End Try
                        Try
                            sql = sql & "Tel : " & vtbTieude.Rows(0).Item("PHONE").ToString & "  Fax : " & vtbTieude.Rows(0).Item("FAX").ToString
                        Catch ex As Exception

                        End Try

                        Dim aaa As Excel.Shape

                        aaa = .Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 220, 0, 400, 50)
                        aaa.TextFrame.Characters.Text = sql
                        aaa.Line.Visible = Office.MsoTriState.msoFalse


                        .Range(.Cells(5, 1), .Cells(5, 9)).Merge()
                        .Range(.Cells(5, 1), .Cells(5, 9)).HorizontalAlignment = 3
                        .Range(.Cells(5, 1), .Cells(5, 9)).VerticalAlignment = 2
                        .Range(.Cells(5, 1), .Cells(5, 9)).Font.Bold = True
                        .Range(.Cells(5, 1), .Cells(5, 9)).Font.Size = 12
                        .Cells(5, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "lblTieuDe", Commons.Modules.TypeLanguage)

                        .Range(.Cells(1, 1), .Cells(1000, 1)).ColumnWidth = 0
                    End With
                    ExcelApp.Visible = True
                End If
            Else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "KhongcoDuLieu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetImage(ByVal Logo As Byte())
        Dim dir As New DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters")
        Dim strPath As String = Application.StartupPath + "\logo.bmp"
        Dim stream As New MemoryStream(Logo)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(stream)
        img.Save(strPath)

    End Sub
End Class
