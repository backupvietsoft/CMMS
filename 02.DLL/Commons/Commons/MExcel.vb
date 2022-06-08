Imports Microsoft.ApplicationBlocks.Data
Imports OfficeOpenXml

Public Class MExcel
    Dim sFile As String = ""


    Public Function SaveFiles(ByVal MFilter As String) As String
        Try
            '--0 Or null nhu cu mo filediaglog len cho nguoi ta chon duong dan
            '--1 luu vao temp
            '--2 luu vao thu muc app luc nay fai co thu muc temp trong app
            '--3 có duong dan file. luu thang vao duong dan file
            Dim tempPath As String = ""
            Dim sFileName = DateTime.Now.ToString("yyyyMMdd_HHmmss")

            If Commons.Modules.sExcelTemp = "0" Then
                Dim f As New Windows.Forms.SaveFileDialog()
                f.Filter = MFilter
                f.FileName = sFileName
                Try
                    Dim res As Windows.Forms.DialogResult = f.ShowDialog()
                    If res = Windows.Forms.DialogResult.OK Then
                        Return f.FileName
                    End If
                    Return ""
                Catch
                    Return ""
                End Try
            Else
                Try
                    If MFilter.ToLower.Contains("excel") Or MFilter.ToLower.Contains("xls") Or MFilter.ToLower.Contains("xlsx") Then
                        If MFilter.ToLower.Contains("xlsx") Then
                            Return Commons.Modules.sExcelTemp & sFileName + ".xlsx"
                        Else
                            Return Commons.Modules.sExcelTemp & sFileName + ".xls"
                        End If

                    End If
                Catch ex As Exception
                    Return ""
                End Try
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
    Public Function SaveFiles(ByVal MFilter As String, MDefault As String) As String
        Try
            '--0 Or null nhu cu mo filediaglog len cho nguoi ta chon duong dan
            '--1 luu vao temp
            '--2 luu vao thu muc app luc nay fai co thu muc temp trong app
            '--3 có duong dan file. luu thang vao duong dan file

            Dim tempPath As String = ""
            Dim sFileName = MDefault & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")

            If Commons.Modules.sExcelTemp = "0" Then
                Dim f As New Windows.Forms.SaveFileDialog()
                f.Filter = MFilter
                f.FileName = sFileName
                Try
                    Dim res As Windows.Forms.DialogResult = f.ShowDialog()
                    If res = Windows.Forms.DialogResult.OK Then
                        Return f.FileName
                    End If
                    Return ""
                Catch
                    Return ""
                End Try
            Else
                Try
                    If MFilter.ToLower.Contains("excel") Or MFilter.ToLower.Contains("xls") Or MFilter.ToLower.Contains("xlsx") Then
                        If MFilter.ToLower.Contains("xlsx") Then
                            Return Commons.Modules.sExcelTemp & sFileName + ".xlsx"
                        Else
                            Return Commons.Modules.sExcelTemp & sFileName + ".xls"
                        End If

                    End If
                Catch ex As Exception
                    Return ""
                End Try
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return ""

    End Function


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

    Public Function MCot(ByVal sCot As String) As Int16
        Dim sStmp As String = ""
        Try
            For i As Integer = 0 To sCot.Length - 1
                If sStmp.Length = 0 Then
                    sStmp = MTimCot(sCot.Substring(i, 1))
                Else
                    sStmp = sStmp + MTimCot(sCot.Substring(i, 1))
                End If
            Next
        Catch ex As Exception

        End Try
        Return sStmp
    End Function

    Private Function MTimCot(ByVal sCot As String) As String
        Dim sTmp As String = 0
        Try
            If sCot = "!" Then Return 1
            If sCot = "@" Then Return 2
            If sCot = "#" Then Return 3
            If sCot = "$" Then Return 4
            If sCot = "%" Then Return 5
            If sCot = "^" Then Return 6
            If sCot = "&" Then Return 7
            If sCot = "*" Then Return 8
            If sCot = "(" Then Return 9
            If sCot = ")" Then Return 0
        Catch ex As Exception
        End Try
        Return sTmp
    End Function


#Region "Function not range"
    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer,
                  ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer,
                  ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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

    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer,
              ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer,
              ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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
    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer,
                  ByVal DongKT As Integer, ByVal CotKT As Integer, ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer,
                  ByVal DongKTFuntion As Integer, ByVal CotKTFuntion As Integer, ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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

    Sub MFuntion(ByVal MWsheet As Excel.Worksheet, ByVal MFuntion As String, ByVal DongBD As Integer, ByVal CotBD As Integer,
              ByVal DongKT As Integer, ByVal CotKT As Integer, ByVal DongBDFuntion As Integer, ByVal CotBDFuntion As Integer,
              ByVal DongKTFuntion As Integer, ByVal CotKTFuntion As Integer, ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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


    Sub TaoLogo(ByVal MWsheet As Excel.Worksheet, ByVal MLeft As Double, ByVal MTop As Double,
                ByVal MWidth As Double, ByVal MHeight As Double, ByVal sPath As String)
        Try
            Dim dtTmp As New System.Data.DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"))
            Dim dv As New System.Data.DataView(dtTmp)
            Dim dir As New System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters")
            GetImage(DirectCast(dv(0)("LOGO"), Byte()), sPath, "logo.bmp")
            MWsheet.Shapes.AddPicture(sPath + "\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, MLeft, MTop, MWidth, MHeight)

            System.IO.File.Delete(sPath + "\logo.bmp")
        Catch
        End Try
    End Sub
    Sub ThemDong(ByVal MWsheet As Excel.Worksheet, ByVal DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection, ByVal SoDongThem As Integer, ByVal DongBDThem As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBDThem, 1), MWsheet.Cells(DongBDThem, 1))
            For i As Integer = 1 To SoDongThem
                MRange.EntireRow.Insert(DangThem)
            Next
        Catch
        End Try
    End Sub

    Sub ThemDongInterop(ByVal MWsheet As Excel.Worksheet, ByVal DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection, ByVal SoDongThem As Integer, ByVal DongBDThem As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBDThem, 1), MWsheet.Cells(DongBDThem, 1))
            For i As Integer = 1 To SoDongThem
                MRange.EntireRow.Insert(DangThem)
            Next
        Catch
        End Try
    End Sub

    Sub ThemDong(ByVal MWsheet As Excel.Worksheet, ByVal DangThem As Excel.XlInsertShiftDirection, ByVal SoDongThem As Integer, ByVal DongBDThem As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBDThem, 1), MWsheet.Cells(DongBDThem, 1))
            For i As Integer = 1 To SoDongThem
                MRange.EntireRow.Insert(DangThem)
            Next

        Catch
        End Try
    End Sub


    Sub ColumnWidth(ByVal MWsheet As Excel.Worksheet, ByVal MColumnWidth As Double,
                          ByVal MNumberFormat As String, ByVal MWrapText As Boolean,
                          ByVal DongBD As Integer, ByVal CotBD As Integer,
                          ByVal DongKT As Integer, ByVal CotKT As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            MRange.ColumnWidth = MColumnWidth
            If MNumberFormat <> "" Then MRange.NumberFormat = MNumberFormat
            MRange.WrapText = MWrapText
        Catch ex As Exception

        End Try

    End Sub

    Public Function TaoTTChung(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal CotBD As Integer,
                    ByVal DongKT As Integer, ByVal CotKT As Integer) As Integer

        Try
            Dim dtTmp As New System.Data.DataTable()
            Dim sSql As String = ""
            If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                sSql = "SELECT  CASE " + Commons.Modules.TypeLanguage.ToString + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " &
                            " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " &
                            " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " &
                            " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Commons.Modules.UserName.ToString + "') "
            Else
                sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
            End If
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        System.Data.CommandType.Text, sSql))

            If dtTmp.Rows.Count = 0 And Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql))
            End If

            Dim CurCell As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, 1), MWsheet.Cells(DongKT, 1))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)

            'CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongBD, CotBD))
            'CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = dtTmp.Rows(0)("TEN_CTY")


            ' them ngay IN
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotKT - 1), MWsheet.Cells(DongBD, CotKT))
            CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            CurCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + DateTime.Now.Date.ToShortDateString()

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            'CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongBD, CotBD))
            'CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("DIA_CHI")

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            'CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongBD, CotBD))
            'CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("phone") & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("FAX")

            DongBD += 1
            DongKT += 1
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, "A"), MWsheet.Cells(DongKT, "A"))
            CurCell.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            'CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongKT, CotKT))
            CurCell = MWsheet.Range(MWsheet.Cells(DongBD, CotBD), MWsheet.Cells(DongBD, CotBD))
            'CurCell.Merge(True)
            CurCell.Font.Bold = True
            CurCell.Borders.LineStyle = 0
            CurCell.Value2 = "Email : " + dtTmp.Rows(0)("EMAIL")
            Return DongBD + 1
        Catch
            Return DongBD + 1
        End Try
    End Function

    Public Function TaoShape(ByVal DongBD As Integer, ByVal MWsheet As Excel.Worksheet, ByVal MLeft As Double, ByVal MTop As Double,
                ByVal MWidth As Double, ByVal MHeight As Double, ByVal sText As String, ByVal MFontName As String, ByVal MFontSize As Double,
                ByVal MFontBold As Boolean, ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign) As Integer
        Try
            Dim dtTmp As New System.Data.DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        System.Data.CommandType.Text, " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "))
            If sText = "-1" Then
                sText = dtTmp.Rows(0)("TEN_CTY").ToString() + vbCrLf +
                        (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("DIA_CHI").ToString() + vbCrLf +
                        ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("phone").ToString() & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) & " : ") + dtTmp.Rows(0)("FAX").ToString() + vbCrLf +
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


    Sub ExcelEnd(ByVal MApp As Excel.Application, ByVal MWbook As Excel.Workbook,
                                ByVal MWsheet As Excel.Worksheet, ByVal MVisible As Boolean, ByVal MDisplayGridlines As Boolean,
                                ByVal MRowFit As Boolean, ByVal MColumnsFit As Boolean, ByVal MPaperSize As Excel.XlPaperSize,
                                ByVal MOrientation As Excel.XlPageOrientation, ByVal MTopMargin As Double,
                                ByVal MBottomMargin As Double, ByVal MLeftMargin As Double, ByVal MRightMargin As Double,
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
            MWbook.CheckCompatibility = False
            MApp.Visible = MVisible
            MWbook.Save()
        Catch
        End Try
    End Sub


    Public Sub ExcelClose(ByVal MApp As Excel.Application, ByVal MWbook As Excel.Workbook,
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

    Public Function GetRange(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal CotBD As Integer,
                    ByVal DongKT As Integer, ByVal CotKT As Integer) As Excel.Range
        Try
            'Dim allCells = MWsheet.Cells(DongBD, CotBD, DongKT, CotKT)
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
                    ByVal MNumberFormat As [String])
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(Dong, Cot), MWsheet.Cells(Dong, Cot))
            MRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            If NoiDung <> "" Then MWsheet.Cells(Dong, Cot) = NoiDung
            MRange.Borders.LineStyle = 0
        Catch
        End Try
    End Sub

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
                      ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
                      ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean,
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
                          ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean,
                          ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign,
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

    Sub DinhDang(ByVal MWsheet As Excel.Worksheet, ByVal NoiDung As String, ByVal Dong As Integer, ByVal Cot As Integer,
                          ByVal MNumberFormat As [String], ByVal MFontSize As Double, ByVal MFontBold As Boolean,
                          ByVal MHAlign As Excel.XlHAlign, ByVal MVAlign As Excel.XlVAlign,
                          ByVal MMerge As Boolean, ByVal MDongMerge As Integer, ByVal MCotMerge As Integer,
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
            rawData(0, col) = dtTmp.Columns(col).ColumnName
        Next
        For col = 0 To dtTmp.Columns.Count - 1
            For row = 0 To dtTmp.Rows.Count - 1
                rawData(row + 1, col) = dtTmp.Rows(row)(col).ToString()
            Next
        Next
        sRange.Value = rawData
    End Sub

    Public Sub MExportExcel(ByVal dtTmp As DataTable, ByVal ExcelSheets As Excel.Worksheet, ByVal sRange As Excel.Range, ByVal loadNN As Boolean, ByVal form As String)
        Dim rawData(dtTmp.Rows.Count, dtTmp.Columns.Count - 1) As Object
        For col = 0 To dtTmp.Columns.Count - 1
            rawData(0, col) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, form, dtTmp.Columns(col).ColumnName, Commons.Modules.TypeLanguage)
        Next
        For col = 0 To dtTmp.Columns.Count - 1
            For row = 0 To dtTmp.Rows.Count - 1
                rawData(row + 1, col) = dtTmp.Rows(row)(col).ToString()
            Next
        Next
        sRange.Value = rawData
    End Sub

    Public Sub MTaoSTT(ByVal MWsheet As Excel.Worksheet, ByVal DongBD As Integer, ByVal Cot As Integer,
                ByVal DongKT As Integer)
        Try
            Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBD, Cot), MWsheet.Cells(DongBD, Cot))
            MRange.Value2 = 1

            MRange = MWsheet.Range(MWsheet.Cells(DongBD + 1, Cot), MWsheet.Cells(DongKT, Cot))
            MRange.Value2 = "=OFFSET(A" + (DongBD + 1).ToString + ",-1,0)+1"
        Catch
        End Try
    End Sub


    Public Sub MTTChung(DongBD As Integer, CotBD As Integer, logoWidth As Double, logoHeight As Double, ws As ExcelWorksheet)
        Dim dtTmp As New System.Data.DataTable()
        Dim sSql As String = ""
        If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
            sSql = "SELECT  CASE " + Commons.Modules.TypeLanguage.ToString + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " &
                            " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " &
                            " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " &
                            " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Commons.Modules.UserName.ToString + "') "
        Else
            sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
        End If
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        System.Data.CommandType.Text, sSql))

        If dtTmp.Rows.Count = 0 And Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
            sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql))
        End If

        AddImage(ws, DongBD, CotBD, logoWidth, logoHeight, dtTmp, "LOGO")

        ws.Cells("B1").Value = dtTmp.Rows(0)("TEN_CTY").ToString()
        ws.Cells("B2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows(0)("DIA_CHI").ToString()

        ws.Cells("B3").Value = ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : ") + dtTmp.Rows(0)("phone") + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : ") + dtTmp.Rows(0)("FAX")

    End Sub


    Public Sub MTTChung(DongBD As Integer, CotBD As Integer, logoWidth As Double, logoHeight As Double, ws As ExcelWorksheet, CotTTBD As String)
        Dim dtTmp As New System.Data.DataTable()
        Dim sSql As String = ""
        If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
            sSql = "SELECT  CASE " + Commons.Modules.TypeLanguage.ToString + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " &
                            " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " &
                            " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " &
                            " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Commons.Modules.UserName.ToString + "') "
        Else
            sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
        End If
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        System.Data.CommandType.Text, sSql))

        If dtTmp.Rows.Count = 0 And Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
            sSql = " SELECT CASE WHEN " & Commons.Modules.TypeLanguage & "=0 " &
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " &
                        " CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," &
                        " Fax,EMAIL FROM THONG_TIN_CHUNG "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql))
        End If

        AddImage(ws, DongBD, CotBD, logoWidth, logoHeight, dtTmp, "LOGO")
        If (CotTTBD = "") Then Return
        ws.Cells(CotTTBD & "1").Value = dtTmp.Rows(0)("TEN_CTY").ToString()
        ws.Cells(CotTTBD & "2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows(0)("DIA_CHI").ToString()

        ws.Cells(CotTTBD & "3").Value = ((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : ") + dtTmp.Rows(0)("phone") + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : ") + dtTmp.Rows(0)("FAX")

    End Sub


    Public Sub AddImage(ws As ExcelWorksheet, DongBD As Integer, CotBD As Integer, logoWidth As Double, logoHeight As Double, dtLogo As DataTable, sCotHinh As String)
        Dim img As System.Drawing.Image
        Dim excelImage As OfficeOpenXml.Drawing.ExcelPicture = Nothing
        If dtLogo.Rows.Count > 0 Then
            Dim data As [Byte]() = New [Byte](-1) {}
            data = DirectCast(dtLogo.Rows(0)(sCotHinh), [Byte]())
            Dim mem As New System.IO.MemoryStream(data)
            img = System.Drawing.Image.FromStream(mem)

            If logoWidth = 0 Then logoWidth = 110
            If logoHeight = 0 Then logoHeight = 45
            excelImage = ws.Drawings.AddPicture(Commons.Modules.sPrivate, img)
            excelImage.From.Column = CotBD
            excelImage.From.Row = DongBD
            excelImage.SetSize(logoWidth, logoHeight)
            excelImage.From.ColumnOff = Pixel2MTU(2)
            excelImage.From.RowOff = Pixel2MTU(2)
        End If
    End Sub
    Public Sub AddImage(ws As ExcelWorksheet, DongBD As Integer, CotBD As Integer, logoWidth As Double, logoHeight As Double, sPath As String)
        Dim image As New System.Drawing.Bitmap(sPath)
        Dim excelImage As OfficeOpenXml.Drawing.ExcelPicture = Nothing
        If image IsNot Nothing Then
            If logoWidth = 0 Then logoWidth = 110
            If logoHeight = 0 Then logoHeight = 45
            excelImage = ws.Drawings.AddPicture(Commons.Modules.sPrivate, image)
            excelImage.From.Column = CotBD
            excelImage.From.Row = DongBD
            excelImage.SetSize(logoWidth, logoHeight)
            excelImage.From.ColumnOff = Pixel2MTU(2)
            excelImage.From.RowOff = Pixel2MTU(2)
        End If
    End Sub

    Private Function Pixel2MTU(pixels As Integer) As Integer
        Dim mtus As Integer = pixels * 9525
        Return mtus
    End Function

#Region "MFormatExcel"
    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin


            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, sCotNgay As List(Of String), sDateFormat As String, Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin


            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If sCotNgay IsNot Nothing Then
                        If sCotNgay.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Style.Numberformat.Format = sDateFormat
                            ws.Column(i).Width = 13
                        End If
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, WidthColumns As List(Of List(Of [Object])), Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin


            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If WidthColumns IsNot Nothing Then
                        For j As Integer = 0 To WidthColumns.Count
                            If WidthColumns(j)(0).ToString().Contains(ws.Cells(iRow, i).Value.ToString()) Then
                                ws.Column(i).Width = Integer.Parse(WidthColumns(j)(1).ToString())
                                Exit For
                            End If
                        Next
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, sCotHide As List(Of String), Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin

            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If sCotHide IsNot Nothing Then
                        If sCotHide.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Hidden = True
                        End If
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, sCotNgay As List(Of String), sDateFormat As String, WidthColumns As List(Of List(Of [Object])), Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin

            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If sCotNgay IsNot Nothing Then
                        If sCotNgay.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Style.Numberformat.Format = sDateFormat
                            ws.Column(i).Width = 13
                        End If
                    End If
                    If WidthColumns IsNot Nothing Then
                        For j As Integer = 0 To WidthColumns.Count
                            If WidthColumns(j)(0).ToString().Contains(ws.Cells(iRow, i).Value.ToString()) Then
                                ws.Column(i).Width = Integer.Parse(WidthColumns(j)(1).ToString())
                                Exit For
                            End If
                        Next
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, sCotNgay As List(Of String), sDateFormat As String, sCotHide As List(Of String), Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin


            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If sCotNgay IsNot Nothing Then
                        If sCotNgay.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Style.Numberformat.Format = sDateFormat
                            ws.Column(i).Width = 13
                        End If
                    End If

                    If sCotHide IsNot Nothing Then
                        If sCotHide.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Hidden = True
                        End If
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub MFormatExcel(ws As ExcelWorksheet, dtData As DataTable, iRow As Integer, sBC As String, sCotNgay As List(Of String), sDateFormat As String, sCotHide As List(Of String), WidthColumns As List(Of List(Of [Object])), Optional mNNgu As Boolean = True, Optional mAutoFitColumns As Boolean = True, Optional mWrapText As Boolean = True)
        Try
            Dim columnCount As Integer = dtData.Columns.Count
            Dim rowCount As Integer = dtData.Rows.Count

            Dim allCells = ws.Cells(iRow, 1, iRow + rowCount, columnCount)
            Dim border = allCells.Style.Border

            border.Top.Style = Style.ExcelBorderStyle.Thin
            border.Left.Style = Style.ExcelBorderStyle.Thin
            border.Bottom.Style = Style.ExcelBorderStyle.Thin
            border.Right.Style = Style.ExcelBorderStyle.Thin


            If mAutoFitColumns Then allCells.AutoFitColumns()
            allCells.Style.WrapText = mWrapText
            allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center

            allCells = ws.Cells(iRow, 1, iRow, columnCount)
            allCells.Style.Font.Bold = True
            allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


            For i As Integer = 1 To columnCount + 1
                Try
                    If sCotNgay IsNot Nothing Then
                        If sCotNgay.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Style.Numberformat.Format = sDateFormat
                            ws.Column(i).Width = 13
                        End If
                    End If

                    If sCotHide IsNot Nothing Then
                        If sCotHide.Contains(ws.Cells(iRow, i).Value.ToString()) Then
                            ws.Column(i).Hidden = True
                        End If
                    End If

                    If WidthColumns IsNot Nothing Then
                        For j As Integer = 0 To WidthColumns.Count
                            If WidthColumns(j)(0).ToString().Contains(ws.Cells(iRow, i).Value.ToString()) Then
                                ws.Column(i).Width = Integer.Parse(WidthColumns(j)(1).ToString())
                                Exit For
                            End If
                        Next
                    End If
                Catch
                End Try

                Try
                    If mNNgu Then ws.Cells(iRow, i).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, dtData.Columns(i - 1).ColumnName, Commons.Modules.TypeLanguage)
                Catch
                End Try

            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


#Region "MText"
    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer)
        If sBC = "" Then
            ws.Cells(DongBD, CotBD).Value = sKeyWord
        Else
            ws.Cells(DongBD, CotBD).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If

    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, mBold As Boolean)
        Dim allCells = ws.Cells(DongBD, CotBD)
        allCells.Style.Font.Bold = mBold
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, mSize As Double)
        Dim allCells = ws.Cells(DongBD, CotBD)
        allCells.Style.Font.Size = mSize
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, mBold As Boolean, mSize As Double)
        Dim allCells = ws.Cells(DongBD, CotBD)
        allCells.Style.Font.Bold = mBold
        allCells.Style.Font.Size = mSize
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, mBold As Boolean, mSize As Double, mHorAli As Style.ExcelHorizontalAlignment, mVerAli As Style.ExcelVerticalAlignment)
        Dim allCells = ws.Cells(DongBD, CotBD)
        allCells.Style.Font.Bold = mBold
        allCells.Style.Font.Size = mSize
        allCells.Style.HorizontalAlignment = mHorAli
        allCells.Style.VerticalAlignment = mVerAli
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, DongKT As Integer, CotKT As Integer, mMerge As Boolean)
        Dim allCells = ws.Cells(DongBD, CotBD, DongKT, CotKT)
        allCells.Merge = mMerge
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, DongKT As Integer, CotKT As Integer, mMerge As Boolean, mBold As Boolean)
        Dim allCells = ws.Cells(DongBD, CotBD, DongKT, CotKT)
        allCells.Merge = mMerge
        allCells.Style.Font.Bold = mBold
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, DongKT As Integer, CotKT As Integer, mMerge As Boolean, mBold As Boolean, mSize As Double)
        Dim allCells = ws.Cells(DongBD, CotBD, DongKT, CotKT)
        allCells.Merge = mMerge
        allCells.Style.Font.Bold = mBold
        allCells.Style.Font.Size = mSize
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub

    Public Sub MText(ws As ExcelWorksheet, sBC As String, sKeyWord As String, DongBD As Integer, CotBD As Integer, DongKT As Integer, CotKT As Integer, mMerge As Boolean, mBold As Boolean, mSize As Double, mHorAli As Style.ExcelHorizontalAlignment, mVerAli As Style.ExcelVerticalAlignment)
        Dim allCells = ws.Cells(DongBD, CotBD, DongKT, CotKT)
        allCells.Merge = mMerge
        allCells.Style.Font.Bold = mBold
        allCells.Style.Font.Size = mSize
        allCells.Style.HorizontalAlignment = mHorAli
        allCells.Style.VerticalAlignment = mVerAli
        If sBC = "" Then
            allCells.Value = sKeyWord
        Else
            allCells.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sKeyWord, Commons.Modules.TypeLanguage)
        End If
    End Sub
#End Region

End Class
