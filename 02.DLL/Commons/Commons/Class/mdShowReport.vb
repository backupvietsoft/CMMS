Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Imports System.Windows.Forms

Public Module mdShowReport

    ''' <summary>
    ''' Thủ tục hiển thị report lên màn hình
    ''' </summary>
    ''' <param name="CrystalReportName">Tên report cần hiển thị
    ''' Ví dụ : Employee.rpt hoặc report\employee.rpt
    ''' </param>
    ''' <remarks></remarks>
    Public Sub ReportPreview(ByVal CrystalReportName As String, Optional ByVal param As String = "", Optional ByVal Formular As String = "")

        Dim reportPath As String = Application.StartupPath & "\" & CrystalReportName
        If Not File.Exists(reportPath) Then
            Throw New InvalidDataException("Không tìm thấy file report yêu cầu, kiểm tra lại.")
            Exit Sub
        End If
        Dim objThongtinchung As New clsTHONG_TIN_CHUNGInfo
        objThongtinchung = New clsTHONG_TIN_CHUNGController().GetTHONG_TIN_CHUNG()
        Dim frmReport As New frmShowReport()
        Dim objRD As New ReportDocument()
        objRD.Load(reportPath)
        Dim intCounter As Integer
        Dim index As Integer
        Dim strParValPair() As String
        Dim strVal() As String

        Dim paraValue As New ParameterDiscreteValue
        Dim currValue As New ParameterValues

        intCounter = objRD.DataDefinition.ParameterFields.Count

        If intCounter = 1 Then
            If InStr(objRD.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
                intCounter = 0
            End If
        End If

        If intCounter > 0 And Trim(param) <> "" Then
            strParValPair = param.Split("&")
            For index = 0 To UBound(strParValPair)
                If InStr(strParValPair(index), "=") > 0 Then
                    strVal = strParValPair(index).Split("=")
                    paraValue.Value = strVal(1)
                    currValue = objRD.DataDefinition.ParameterFields(strVal(0)).CurrentValues
                    currValue.Add(paraValue)
                    objRD.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
                End If
            Next
        End If
        strParValPair = Formular.Split("&")
        For index = 0 To UBound(strParValPair)
            If InStr(strParValPair(index), "=") > 0 Then
                strVal = strParValPair(index).Split("=")
                objRD.DataDefinition.FormulaFields(strVal(0)).Text = strVal(1)
            End If
        Next

        frmReport.oReport.ReportSource = objRD 'str 'reportPath
        Try
            Commons.clsXuLy.DesignerReport(objRD)
        Catch ex As Exception
        End Try

        Dim myConnect As ConnectionInfo = New ConnectionInfo()
        myConnect.DatabaseName = getDatabase()
        myConnect.UserID = getUserLog()
        myConnect.Password = getPasswordSql()
        myConnect.ServerName = getServer()

        objRD.DataSourceConnections.Item(0).SetConnection(myConnect.ServerName, myConnect.DatabaseName, False)
        objRD.DataSourceConnections.Item(0).SetLogon(myConnect.UserID, myConnect.Password)
        frmReport.oReport.ReportSource = objRD 'str 'reportPath

        'Dim myTableLogOnInfos As TableLogOnInfos = frmReport.oReport.LogOnInfo
        'For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
        '    myTableLogOnInfo.ConnectionInfo = myConnect
        'Next
        If Commons.Modules.bDoiFontReport Then Commons.Modules.ObjSystems.MDoiFontCrystalReports(objRD)
        frmReport.oReport.RefreshReport()

        frmReport.oReport.DisplayGroupTree = False
        frmReport.Show()
        frmReport.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub ReportPreviews(ByVal CrystalReportName As String, ByVal Source As DataSet, Optional ByVal param As String = "", Optional ByVal Formular As String = "")

        Dim reportPath As String = Application.StartupPath & "\" & CrystalReportName
        If Not File.Exists(reportPath) Then
            Throw New InvalidDataException("Không tìm thấy file report yêu cầu, kiểm tra lại.")
            Exit Sub
        End If
        Dim objThongtinchung As New clsTHONG_TIN_CHUNGInfo
        objThongtinchung = New clsTHONG_TIN_CHUNGController().GetTHONG_TIN_CHUNG()
        Dim frmReport As New frmShowReport()
        Dim objRD As New ReportDocument()
        objRD.Load(reportPath)

        Dim intCounter As Integer
        Dim index As Integer
        Dim strParValPair() As String
        Dim strVal() As String

        Dim paraValue As New ParameterDiscreteValue
        Dim currValue As New ParameterValues

        intCounter = objRD.DataDefinition.ParameterFields.Count

        If intCounter = 1 Then
            If InStr(objRD.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
                intCounter = 0
            End If
        End If

        If intCounter > 0 And Trim(param) <> "" Then
            strParValPair = param.Split("&")
            For index = 0 To UBound(strParValPair)
                If InStr(strParValPair(index), "=") > 0 Then
                    strVal = strParValPair(index).Split("=")
                    paraValue.Value = strVal(1)
                    currValue = objRD.DataDefinition.ParameterFields(strVal(0)).CurrentValues
                    currValue.Add(paraValue)
                    objRD.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
                End If
            Next
        End If
        strParValPair = Formular.Split("&")
        For index = 0 To UBound(strParValPair)
            If InStr(strParValPair(index), "=") > 0 Then
                strVal = strParValPair(index).Split("=")
                objRD.DataDefinition.FormulaFields(strVal(0)).Text = strVal(1)
            End If
        Next
        objRD.SetDataSource(Source)
        frmReport.oReport.ReportSource = objRD 'str 'reportPath
        'Yen moi sưa
        Try
            Commons.clsXuLy.DesignerReport(objRD)
        Catch ex As Exception
        End Try
        If Commons.Modules.bDoiFontReport Then Commons.Modules.ObjSystems.MDoiFontCrystalReports(objRD)

        'Dim myConnect As ConnectionInfo = New ConnectionInfo()
        'myConnect.DatabaseName = getDatabase()
        'myConnect.UserID = getUserLog()
        'myConnect.Password = getPasswordSql()
        'myConnect.ServerName = getServer()

        'objRD.DataSourceConnections.Item(0).SetConnection(myConnect.ServerName, myConnect.DatabaseName, False)
        'objRD.DataSourceConnections.Item(0).SetLogon(myConnect.UserID, "")        
        frmReport.oReport.ReportSource = objRD 'str 'reportPath

        'Dim myTableLogOnInfos As TableLogOnInfos = frmReport.oReport.LogOnInfo
        'For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
        '    myTableLogOnInfo.ConnectionInfo = myConnect
        'Next
        frmReport.oReport.RefreshReport()

        frmReport.oReport.DisplayGroupTree = False

        frmReport.Show()
        frmReport.WindowState = FormWindowState.Maximized
    End Sub

    Public Function ShowConnectInfo() As String
        Return getServer + Space(1) + getDatabase + Space(1) + getUserLog + Space(1) + getPasswordSql
    End Function

    Private ReadOnly Property getServer() As String
        Get
            Return ReadConnectInfo(0)
        End Get
    End Property

    Private ReadOnly Property getDatabase() As String
        Get
            Return ReadConnectInfo(1)
        End Get
    End Property

    Private ReadOnly Property getUserLog() As String
        Get
            Return ReadConnectInfo(2)
        End Get
    End Property

    Private ReadOnly Property getPasswordSql() As String
        Get
            Return ReadConnectInfo(3)
        End Get
    End Property

    Private Function ReadConnectInfo() As String()
        Dim sDefaultConnectString As String = ".,CMMS_VICT,sa,"
        Dim sRowStreamRead As String
        Dim sArr() As String = Nothing
        Try
            Dim sFileInclude = System.IO.File.OpenText(Application.StartupPath + "\VSConfig.ini")
            sRowStreamRead = sFileInclude.ReadToEnd()
            sRowStreamRead = Commons.clsXuLy.GiaiMaDL(sRowStreamRead)
            sArr = Split(sRowStreamRead, "!")
        Catch
            sRowStreamRead = sDefaultConnectString
        Finally
        End Try

        If sRowStreamRead <> Nothing Then
            sArr = Split(sRowStreamRead, "!")
            sArr(1) = Commons.IConnections.Database
            sArr(2) = Commons.IConnections.Username
            sArr(3) = Commons.IConnections.Password
        End If
        Return sArr
    End Function

End Module
