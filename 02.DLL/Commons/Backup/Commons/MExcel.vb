Public Class MExcel
    Dim sFile As String = ""
    Public Function SaveFiles(ByVal MFilter As String) As String
        Try
            Dim f As New Windows.Forms.SaveFileDialog()
            f.Filter = MFilter
            Try
                Dim res As Windows.Forms.DialogResult = f.ShowDialog()
                Return f.FileName
            Catch
                Return ""
            End Try
        Catch ex As Exception
            Return ""
        End Try

    End Function

    'Public Function SaveFiles(ByVal MashjFilter As String) As String
    '    Try
    '        sFile = MashjFilter

    '        Dim oThread As New Thread(AddressOf ThreadMethod)
    '        oThread.SetApartmentState(ApartmentState.STA)
    '        oThread.Start()
    '        Return sFile
    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function

    'Private Sub ThreadMethod()
    '    sFile = ""
    '    Dim f As New Windows.Forms.SaveFileDialog()
    '    f.Filter = sFile
    '    sFile = ""
    '    Try
    '        Dim res As Windows.Forms.DialogResult = f.ShowDialog()
    '        sFile = f.FileName
    '    Catch
    '        sFile = ""
    '    End Try

    'End Sub

    Public Function TimDiemExcel(ByVal Dong As Integer, ByVal Cot As Integer) As String
        Dim sTmp As String
        Try

            sTmp = ""
            If Cot > 26 Then
                sTmp = Char.ConvertFromUtf32((Cot - 1) \ 26 + 64)

                sTmp = sTmp & Char.ConvertFromUtf32((Cot - 1) Mod 26 + 65)
            Else
                sTmp = Char.ConvertFromUtf32(Cot + 64)
            End If
            If Dong <= 0 Then
                sTmp = sTmp
            Else
                sTmp = sTmp & Convert.ToString(Dong)
            End If
            Return sTmp
        Catch ex As Exception
            Return ""
        End Try

    End Function


#Region "Function not range"
    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer, _
                  ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer, _
                  ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                  ByVal MColumnWidth As Double, ByVal MNumberFormat As String)
        Try
            MWsheet.Cells(DongBD, CotBD).Value2 = "=" & MFuntion & "(" & TimDiemExcel(DongBDFuntion, CotBDFuntion) & ")"
            If MFontSize > 0 Then MWsheet.Cells(DongBD, CotBD).Font.Size = MFontSize
            MWsheet.Cells(DongBD, CotBD).ColumnWidth = MColumnWidth
            MWsheet.Cells(DongBD, CotBD).Font.Bold = MFontBold
            MWsheet.Cells(DongBD, CotBD).NumberFormat = MNumberFormat
        Catch ex As Exception

        End Try
    End Sub

    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer, _
              ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer, _
              ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
              ByVal MColumnWidth As Double, ByVal MNumberFormat As String, ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign)
        Try
            MWsheet.Cells(DongBD, CotBD).Value2 = "=" & MFuntion & "(" & TimDiemExcel(DongBDFuntion, CotBDFuntion) & ":" & ")"
            If MFontSize > 0 Then MWsheet.Cells(DongBD, CotBD).Font.Size = MFontSize
            MWsheet.Cells(DongBD, CotBD).ColumnWidth = MColumnWidth
            MWsheet.Cells(DongBD, CotBD).Font.Bold = MFontBold
            MWsheet.Cells(DongBD, CotBD).NumberFormat = MNumberFormat
            MWsheet.Cells(DongBD, CotBD).HorizontalAlignment = MHAlign
            MWsheet.Cells(DongBD, CotBD).VerticalAlignment = MVAlign

        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "Function range"
    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer, _
                  ByVal DongKT As Integer, ByVal CotKT As Integer, ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer, _
                  ByVal DongKTFuntion As Integer, ByVal CotKTFuntion As Integer, ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                  ByVal MColumnWidth As Double, ByVal MNumberFormat As String)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            MRange.Value2 = "=" & MFuntion & "(" & TimDiemExcel(DongBDFuntion, CotBDFuntion) & ":" & TimDiemExcel(DongKTFuntion, CotKTFuntion) & ")"
            If MFontSize > 0 Then MRange.Font.Size = MFontSize
            MRange.ColumnWidth = MColumnWidth
            MRange.Font.Bold = MFontBold
            MRange.NumberFormat = MNumberFormat
        Catch ex As Exception

        End Try
    End Sub

    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer, _
              ByVal DongKT As Integer, ByVal CotKT As Integer, ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer, _
              ByVal DongKTFuntion As Integer, ByVal CotKTFuntion As Integer, ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
              ByVal MColumnWidth As Double, ByVal MNumberFormat As String, ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            MRange.Value2 = "=" & MFuntion & "(" & TimDiemExcel(DongBDFuntion, CotBDFuntion) & ":" & TimDiemExcel(DongKTFuntion, CotKTFuntion) & ")"
            If MFontSize > 0 Then MRange.Font.Size = MFontSize
            MRange.ColumnWidth = MColumnWidth
            MRange.Font.Bold = MFontBold
            MRange.NumberFormat = MNumberFormat
            MRange.HorizontalAlignment = MHAlign
            MRange.VerticalAlignment = MVAlign

        Catch ex As Exception

        End Try
    End Sub
#End Region

    Sub GetImage(ByVal Logo As Byte(), ByVal sPath As String, ByVal sFile As String)
        Try

            Dim strPath As String = sPath + "\" + sFile
            Dim stream As New System.IO.MemoryStream(Logo)
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(stream)
            img.Save(strPath)
        Catch ex As Exception

        End Try
    End Sub

    Sub TaoLogo(ByVal MWsheet As Excel.Worksheet, ByVal MLeft As Double, ByVal MTop As Double, _
                ByVal MWidth As Double, ByVal MHeight As Double, ByVal sPath As String)
        Try
            Dim dtTmp As New System.Data.DataTable()
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"))
            Dim dv As New System.Data.DataView(dtTmp)
            Dim dir As New System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters")
            GetImage(DirectCast(dv(0)("LOGO"), Byte()), sPath, "logo.bmp")
            MWsheet.Shapes.AddPicture(sPath + "\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, _
                            MLeft, MTop, MWidth, MHeight)

            System.IO.File.Delete(sPath + "\logo.bmp")
        Catch
        End Try
    End Sub


    Sub ThemDong(ByVal MWsheet As Excel.Worksheet, ByVal DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection, _
                  ByVal SoDongThem As Integer, ByVal DongBDThem As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBDThem, 1), MWsheet.Cells(DongBDThem, 1))
            For i As Integer = 1 To SoDongThem
                MRange.EntireRow.Insert(DangThem)
            Next

        Catch
        End Try
    End Sub

    Sub ColumnWidth(ByVal MWsheet As Excel.Worksheet, ByVal MColumnWidth As Double, _
                          ByVal MNumberFormat As String, ByVal MWrapText As Boolean, _
                          ByVal DongBD As Integer, ByVal CotBD As Integer, _
                          ByVal DongKT As Integer, ByVal CotKT As Integer)
        Try

            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            MRange.ColumnWidth = MColumnWidth
            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat
            MRange.WrapText = MWrapText
        Catch ex As Exception

        End Try

    End Sub

    Public Function TaoTTChung(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal CotBD As Integer, _
                    ByVal DongKT As Integer, ByVal CotKT As Integer) As Integer

        Try
            Dim dtTmp As New System.Data.DataTable()
            Dim sSql As String = ""
            If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                sSql = "SELECT  CASE " + Commons.Modules.TypeLanguage.ToString + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " & _
                            " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " & _
                            " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " & _
                            " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Commons.Modules.UserName.ToString + "') "
            Else
                sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " & _
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " & _
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," & _
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
            End If
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                        System.Data.CommandType.Text, sSql))

            If dtTmp.Rows.Count = 0 And Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " & _
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " & _
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," & _
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql))
            End If

            Dim CurCell As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, 1), MWsheet.Cells(DongKT, 1))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = dtTmp.Rows(0)("TEN_CTY")

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("DIA_CHI")

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("phone") & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("FAX")

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = "Email : " + dtTmp.Rows(0)("EMAIL")
            Return DongBD + 1
        Catch
            Return DongBD + 1
        End Try
    End Function

    Public Function TaoShape(ByVal DongBD As Integer, ByVal MWsheet As Excel.Worksheet, ByVal MLeft As Double, ByVal MTop As Double, _
                ByVal MWidth As Double, ByVal MHeight As Double, ByVal sText As String, ByVal MFontName As String, ByVal MFontSize As Double, _
                ByVal MFontBold As Boolean, ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign) As Integer
        Try
            Dim dtTmp As New System.Data.DataTable()
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                        System.Data.CommandType.Text, " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " & _
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " & _
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," & _
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "))
            If sText = "-1" Then
                sText = dtTmp.Rows(0)("TEN_CTY").ToString() + vbCrLf + _
                        (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("DIA_CHI").ToString() + vbCrLf + _
                        ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("phone").ToString() & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("FAX").ToString() + vbCrLf + _
                        "Email : " + dtTmp.Rows(0)("EMAIL").ToString()
            End If

            Dim aaa As Excel.Shape
            aaa = MWsheet.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, MLeft, MTop, MWidth, MHeight)
            aaa.TextFrame.Characters.Text = sText
            aaa.TextFrame.Characters.Font.Name = MFontName
            aaa.TextFrame.Characters.Font.Size = MFontSize
            aaa.TextFrame.VerticalAlignment = MVAlign
            aaa.TextFrame.HorizontalAlignment = MHAlign
            aaa.Line.ForeColor.RGB = RGB(255, 255, 255)
            Return DongBD + 4
        Catch
            Return DongBD + 4
        End Try
    End Function


    Sub ExcelEnd(ByVal MApp As Excel.Application, ByVal MWbook As Excel.Workbook, _
                                ByVal MWsheet As Excel.Worksheet, ByVal MVisible As Boolean, ByVal MDisplayGridlines As Boolean, _
                                ByVal MRowFit As Boolean, ByVal MColumnsFit As Boolean, ByVal MPaperSize As Excel.XlPaperSize, _
                                ByVal MOrientation As Excel.XlPageOrientation, ByVal MTopMargin As Double, _
                                ByVal MBottomMargin As Double, ByVal MLeftMargin As Double, ByVal MRightMargin As Double, _
                                ByVal MHeaderMargin As Double, ByVal MFooterMargin As Double, ByVal MZoom As Double)
        Try
            If MColumnsFit = True Then MWsheet.Columns.AutoFit()
            If MRowFit = True Then MWsheet.Rows.AutoFit()
            MApp.ActiveWindow.DisplayGridlines = MDisplayGridlines
            MWsheet.PageSetup.PaperSize = MPaperSize
            MWsheet.PageSetup.Orientation = MOrientation
            If MTopMargin <> 0 Then MWsheet.PageSetup.TopMargin = MTopMargin
            If MBottomMargin <> 0 Then MWsheet.PageSetup.BottomMargin = MBottomMargin
            If MLeftMargin <> 0 Then MWsheet.PageSetup.LeftMargin = MLeftMargin
            If MRightMargin <> 0 Then MWsheet.PageSetup.RightMargin = MRightMargin
            If MHeaderMargin <> 0 Then MWsheet.PageSetup.HeaderMargin = MHeaderMargin
            If MFooterMargin <> 0 Then MWsheet.PageSetup.FooterMargin = MFooterMargin
            If MZoom <> 0 Then MWsheet.PageSetup.Zoom = MZoom
            If Commons.Modules.bDoiFontReport Then MApp.Cells.Font.Name = Commons.Modules.sFontReport
            MApp.Visible = MVisible

            MWbook.Save()
        Catch
        End Try
    End Sub


    Public Sub ExcelClose(ByVal MApp As Excel.Application, ByVal MWbook As Excel.Workbook, _
                            ByVal MWsheet As Excel.Worksheet, ByVal MVisible As Boolean, ByVal MClose As Boolean)
        Try
            MApp.DisplayAlerts = False
            MWbook.Save()
            MApp.Visible = MVisible
            If MClose = True Then MWbook.Close(Type.Missing, Type.Missing, Type.Missing)
            If MClose = True Then MApp.Quit()

            Commons.Modules.ObjSystems.MReleaseObject(MWsheet)
            Commons.Modules.ObjSystems.MReleaseObject(MWbook)
            Commons.Modules.ObjSystems.MReleaseObject(MApp)
        Catch
        End Try
    End Sub

    Public Function GetRange(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal CotBD As Integer, _
                    ByVal DongKT As Integer, ByVal CotKT As Integer) As Excel.Range
        Try

            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            Return MRange
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                    ByVal MNumberFormat As [String])
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                  ByVal MNumberFormat As [String], ByVal MFontSize As Double)
        Try

            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            If MFontSize > 0 Then MRange.Font.Size = MFontSize

            MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                      ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            If MFontSize > 0 Then MRange.Font.Size = MFontSize
            MRange.Font.Bold = MFontBold
            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat

            MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0

        Catch
        End Try
    End Sub

    'Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
    '                ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
    '                ByVal MFontUnderline As Boolean)
    '    Try
    '        Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
    '        If MFontSize > 0 Then MRange.Font.Size = MFontSize
    '        MRange.Font.Bold = MFontBold
    '        If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat

    '        MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '        If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
    '        MRange.Borders.LineStyle = 0

    '    Catch
    '    End Try
    'End Sub

    'Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
    '              ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
    '              ByVal MFontUnderline As Boolean, ByVal MFontItalic As Boolean)
    '    Try
    '        Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
    '        If MFontSize > 0 Then MRange.Font.Size = MFontSize
    '        MRange.Font.Bold = MFontBold
    '        If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat

    '        MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '        If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
    '        MRange.Borders.LineStyle = 0

    '    Catch
    '    End Try
    'End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                      ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                      ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            If MFontSize > 0 Then MRange.Font.Size = MFontSize

            MRange.Font.Bold = MFontBold
            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat

            MRange.HorizontalAlignment = MHAlign
            MRange.VerticalAlignment = MVAlign
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                      ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                      ByVal MMerge As Boolean, ByVal MDongMerge As Integer, ByVal MCotMerge As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(MDongMerge, MCotMerge))
            MRange.Merge(MMerge)
            If MFontSize > 0 Then MRange.Font.Size = MFontSize

            MRange.Font.Bold = MFontBold

            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat

            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                          ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                          ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign, _
                          ByVal MMerge As Boolean, ByVal MDongMerge As Integer, ByVal MCotMerge As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(MDongMerge, MCotMerge))
            MRange.Merge(MMerge)
            If MFontSize > 0 Then MRange.Font.Size = MFontSize

            MRange.Font.Bold = MFontBold
            MRange.HorizontalAlignment = MHAlign
            MRange.VerticalAlignment = MVAlign

            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer, _
                          ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean, _
                          ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign, _
                          ByVal MMerge As Boolean, ByVal MDongMerge As Integer, ByVal MCotMerge As Integer, _
                          ByVal MFontUnderline As Boolean, ByVal MFontItalic As Boolean)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(MDongMerge, MCotMerge))
            MRange.Merge(MMerge)
            If MFontSize > 0 Then MRange.Font.Size = MFontSize

            MRange.Font.Bold = MFontBold
            MRange.Font.Underline = MFontUnderline
            MRange.Font.Italic = MFontItalic
            MRange.HorizontalAlignment = MHAlign
            MRange.VerticalAlignment = MVAlign

            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Public Function MCotExcel(ByVal iCot As Integer) As String
        Dim sTmp As String = ""
        If iCot > 26 Then
            sTmp = Convert.ToChar(Convert.ToInt32((iCot - 1) \ 26) + 64).ToString()
            sTmp = sTmp & Convert.ToChar(((Convert.ToInt32(iCot) - 1) Mod 26) + 65).ToString()
        Else
            sTmp = Convert.ToChar(64 + iCot).ToString()
        End If

        Return sTmp

    End Function

    Public Sub MExportExcel(ByVal dtTmp As DataTable, ByVal ExcelSheets As Excel.Worksheet, ByVal sRange As Excel.Range)
        Dim rawData(dtTmp.Rows.Count, dtTmp.Columns.Count - 1) As Object
        For col = 0 To dtTmp.Columns.Count - 1
            rawData(0, col) = dtTmp.Columns(col).ColumnName.ToUpper
        Next
        For col = 0 To dtTmp.Columns.Count - 1
            For row = 0 To dtTmp.Rows.Count - 1
                rawData(row + 1, col) = dtTmp.Rows(row).ItemArray(col)
            Next
        Next

        sRange.Value2 = rawData
    End Sub

    Public Sub MTaoSTT(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal Cot As Integer, _
                ByVal DongKT As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, Cot), MWsheet.Cells(DongBD, Cot))
            MRange.Value2 = 1

            MRange = MWsheet.Range(MWsheet.Cells(DongBD + 1, Cot), MWsheet.Cells(DongKT, Cot))
            MRange.Value2 = "=OFFSET(A" + (DongBD + 1).ToString + ",-1,0)+1"
        Catch
        End Try
    End Sub

End Class
