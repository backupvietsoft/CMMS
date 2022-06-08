Imports Microsoft.ApplicationBlocks.Data

Public Class frmShowXMLReport
    Private dsReportsource As DataSet = New DataSet()
    Public rptName As String = ""
    Private Shared tbrptHeader As DataTable = New DataTable()
    Public iLoaiReport As Integer = 0
    Public sFileReport As String = ""

    'Add Datatable vào dataset
    Public Sub AddDataTableSource(ByVal tbSource As DataTable)
        Try
            Try
                dsReportsource.Tables.Remove(tbSource.TableName)
            Catch ex As Exception
            End Try
            dsReportsource.Tables.Add(tbSource.Copy())
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RemoveDataTableSource()
        dsReportsource.Tables.Clear()
    End Sub

    'Lấy thông tin chung cho report 
    Private Sub AddInformaitionCompany()
        Try

            tbrptHeader = New DataTable()
            Dim vSelect As String = ""
            Dim NgayIn As Date = System.DateTime.Now

            If Commons.Modules.TypeLanguage = 0 Then
                vSelect = "SELECT TEN_CTY_TIENG_VIET AS THONG_TIN_CTY ,DIA_CHI_VIET AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," & _
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "PRINT_DATE", Commons.Modules.TypeLanguage) & "' as NGAY_IN , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "PAGE", Commons.Modules.TypeLanguage) & "' AS PAGE , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "OF", Commons.Modules.TypeLanguage) & "' AS OFPAGE, TTC_CAO,TTC_RONG , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "USER_LOG", Commons.Modules.TypeLanguage) & "' as USER_LOG, '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "NGAY_HT", Commons.Modules.TypeLanguage) & "' as NGAY_HT  FROM THONG_TIN_CHUNG "
            Else
                vSelect = "SELECT TEN_CTY_TIENG_ANH AS THONG_TIN_CTY , DIA_CHI_ANH AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," & _
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "PRINT_DATE", Commons.Modules.TypeLanguage) & "' as NGAY_IN , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "PAGE", Commons.Modules.TypeLanguage) & "' AS PAGE , '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "OF", Commons.Modules.TypeLanguage) & "' AS OFPAGE, TTC_CAO,TTC_RONG, '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "USER_LOG", Commons.Modules.TypeLanguage) & "' as USER_LOG, '" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, rptName, "NGAY_HT", Commons.Modules.TypeLanguage) & "' as NGAY_HT FROM THONG_TIN_CHUNG "
            End If
            tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, vSelect))
            tbrptHeader.TableName = "rptTitlereport"
            If tbrptHeader.Rows.Count > 0 Then
                tbrptHeader.Columns("THONG_TIN_CTY").MaxLength = 1000
                If Commons.Modules.sPrivate.ToUpper() = "GREENFEED" Then
                    Dim dtTmp As New DataTable
                    Dim sSql As String = " SELECT CASE 0 WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS THONG_TIN_CTY, " & _
                                    " C.DIA_CHI AS DIA_CHI_CTY, C.DIEN_THOAI, C.FAX " & _
                                    " FROM dbo.USERS AS A INNER JOIN dbo.TO_PHONG_BAN AS B ON A.MS_TO = B.MS_TO INNER JOIN " & _
                                    " dbo.DON_VI AS C ON B.MS_DON_VI = C.MS_DON_VI WHERE A.USERNAME = N'" + Commons.Modules.UserName + "' "

                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                    If dtTmp.Rows.Count > 0 Then
                        tbrptHeader.Rows(0)("THONG_TIN_CTY") = dtTmp.Rows(0)("THONG_TIN_CTY").ToString().Trim() + vbCrLf + dtTmp.Rows(0)("DIA_CHI_CTY").ToString().Trim() + vbCrLf + "Telephone: " + dtTmp.Rows(0)("DIEN_THOAI").ToString().Trim() + "  Fax: " + dtTmp.Rows(0)("Fax").ToString().Trim()
                    Else
                        tbrptHeader.Rows(0)("THONG_TIN_CTY") = tbrptHeader.Rows(0)("THONG_TIN_CTY").ToString().Trim() + vbCrLf + tbrptHeader.Rows(0)("DIA_CHI_CTY").ToString().Trim() + vbCrLf + "Telephone: " + tbrptHeader.Rows(0)("DIEN_THOAI").ToString().Trim() + "  Fax: " + tbrptHeader.Rows(0)("Fax").ToString().Trim()
                    End If
                    sSql = " DECLARE @NGAYIN DATETIME SET @NGAYIN = GETDATE() SELECT @NGAYIN AS NGAY_HT"
                    dtTmp = New DataTable()
                    Try
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sSql))
                        If (dtTmp.Rows.Count > 0) Then
                            NgayIn = Convert.ToDateTime(dtTmp.Rows(0)(0).ToString())
                        Else
                            NgayIn = System.DateTime.Now
                        End If
                    Catch ex As Exception
                        NgayIn = System.DateTime.Now
                    End Try
                Else
                    tbrptHeader.Rows(0)("THONG_TIN_CTY") = tbrptHeader.Rows(0)("THONG_TIN_CTY").ToString().Trim() & vbCrLf & tbrptHeader.Rows(0)("DIA_CHI_CTY").ToString().Trim() & vbCrLf & "Telephone: " & tbrptHeader.Rows(0)("DIEN_THOAI").ToString().Trim() & "  Fax: " & tbrptHeader.Rows(0)("Fax").ToString().Trim()
                End If


                tbrptHeader.Columns("NGAY_IN").ReadOnly = False
                tbrptHeader.Columns("NGAY_IN").MaxLength = 128
                tbrptHeader.Rows(0)("NGAY_IN") = tbrptHeader.Rows(0)("NGAY_IN").ToString().Trim() & System.DateTime.Now.Date.ToShortDateString

                tbrptHeader.Columns("NGAY_HT").ReadOnly = False
                tbrptHeader.Columns("NGAY_HT").MaxLength = 128
                tbrptHeader.Rows(0)("NGAY_HT") = tbrptHeader.Rows(0)("NGAY_HT").ToString().Trim() & " : " & NgayIn.Date.ToShortDateString

                tbrptHeader.Columns("USER_LOG").ReadOnly = False
                tbrptHeader.Columns("USER_LOG").MaxLength = 128
                tbrptHeader.Rows(0)("USER_LOG") = tbrptHeader.Rows(0)("USER_LOG").ToString().Trim() & " : " & Commons.Modules.UserName

            End If

            tbrptHeader.Columns.Remove(tbrptHeader.Columns("DIA_CHI_CTY"))
            tbrptHeader.Columns.Remove(tbrptHeader.Columns("DIEN_THOAI"))
            tbrptHeader.Columns.Remove(tbrptHeader.Columns("Fax"))
            Try

                dsReportsource.Tables.Remove(tbrptHeader)
            Catch ex As Exception
            End Try
            dsReportsource.Tables.Add(tbrptHeader.Copy())

        Catch ex As Exception

        End Try

    End Sub

    'Set ngôn ngữ cho report 
    Private Sub SetLanguageReport(ByVal rptDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim tbrptLanguage As DataTable = New DataTable()
        Dim vSelect As String = ""
        If (Commons.Modules.TypeLanguage = 0) Then
            vSelect = "SELECT KEYWORD, VIETNAM AS CAPTION FROM LANGUAGES WHERE FORM = '" & rptName & "' AND FORM_HAY_REPORT = 1"
        Else
            vSelect = "SELECT KEYWORD, ENGLISH AS CAPTION FROM LANGUAGES WHERE FORM = '" & rptName & "' AND FORM_HAY_REPORT = 1"
        End If
        tbrptLanguage.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, vSelect))
        If (tbrptLanguage.Rows.Count > 0) Then
            For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptDocument.ReportDefinition.ReportObjects
                If (rptObject.Kind = CrystalDecisions.Shared.ReportObjectKind.TextObject) Then
                    For Each rLanguage As DataRow In tbrptLanguage.Rows
                        If (rptObject.Name.ToUpper().Trim().Equals(rLanguage("KEYWORD").ToString().ToUpper().Trim())) Then
                            CType(rptObject, CrystalDecisions.CrystalReports.Engine.TextObject).Text = rLanguage("CAPTION").ToString().Trim()
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub frmShowXMLReport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    'Sự kiện load form 
    Private Sub frm_Show_report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            CrystalReportViewer_maint.DisplayGroupTree = False
            AddInformaitionCompany()
            dsReportsource.WriteXml(Windows.Forms.Application.StartupPath & "\XML\" & rptName.Trim() & ".xml", XmlWriteMode.WriteSchema)

            Dim rptDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            rptDocument.Load(Windows.Forms.Application.StartupPath & "\reports\" & rptName.Trim & ".rpt")
            rptDocument.SetDataSource(dsReportsource)
            If Commons.Modules.SQLString <> "0Design" Then
                DesignerReport(rptDocument)
            End If
            Commons.Modules.SQLString = ""

            If Commons.Modules.bDoiFontReport Then Commons.Modules.ObjSystems.MDoiFontCrystalReports(rptDocument)
            SetLanguageReport(rptDocument)
            CrystalReportViewer_maint.ReportSource = rptDocument
        Catch ex As Exception
        End Try
    End Sub


    'Định dạng report 
    Public Shared Sub DesignerReport(ByVal rptMain As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        For Each rptObjectMain As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
            If rptObjectMain.Name.Length >= 5 And rptObjectMain.Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                If (rptObjectMain.Name.Trim().ToUpper().Substring(0, 5).Equals("TITLE")) Then
                    Dim rptDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    rptDocument = rptMain.Subreports("rptTitle.rpt")
                    'Dim tbrptHeader As DataTable = New DataTable()
                    'tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
                    If (tbrptHeader.Rows.Count > 0) Then
                        For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptDocument.ReportDefinition.ReportObjects
                            If rptObject.Name.Length >= 4 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))
                                End If

                            End If
                            If rptObject.Name.Length >= 8 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_CAO"))
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_RONG"))
                                End If
                            End If
                            If rptObject.Name.Length >= 6 Then

                                If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                    rptObject.Width = 2500
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    Try
                                        rptObject.Left = rptObjectMain.Width - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    Catch ex As Exception
                                    End Try
                                    rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                If (tbrptHeader.Rows.Count > 0) Then
                    For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
                        If rptObject.Name.Length >= 4 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))

                            End If
                        End If
                        If rptObject.Name.Length >= 8 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_CAO"))
                                rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_RONG"))
                            End If
                        End If
                        If rptObject.Name.Length >= 6 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                rptObject.Width = 2500
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                Try
                                    rptObject.Left = rptMain.PrintOptions.PageContentWidth - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                Catch ex As Exception
                                End Try
                                rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign

                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

End Class