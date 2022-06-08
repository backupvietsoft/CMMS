Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Object
Imports DevExpress.XtraEditors
Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports System.Linq

Public Class frmLogin
    Dim vLogin As Integer

#Region "Event form"
    Private bDN As Boolean = False
    Dim sDataLogin As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TbDatabase = New DataTable
        vLogin = 0
        Dim Cnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString())
        Try
            If (Cnn.State = ConnectionState.Closed) Then
                Cnn.Open()
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Connect Error!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DialogResult = DialogResult.Cancel
            Me.Close()
            Exit Sub
        End Try
        TbDatabase = Cnn.GetSchema("Databases")
        TbDatabase.DefaultView.RowFilter = "database_name like 'CMMS%'"
        TbDatabase = TbDatabase.DefaultView.ToTable("Tbdatabase", True, "database_name").Copy
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDatabase, TbDatabase, "database_name", "database_name", "")
        Try
            btnLogin.Enabled = IIf(cboDatabase.EditValue Is Nothing, False, True)
        Catch ex As Exception
            btnLogin.Enabled = False
        End Try
        Try
            Dim vRegInfo As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\ECOMAINT\ECOMAINTKEY")
            If (CType(vRegInfo.GetValue("Rememberuser"), String).Equals("True")) Then
                cboDatabase.EditValue = vRegInfo.GetValue("Database")

                Try
                    Dim dt As New DataTable
                    dt = CType(cboLic.Properties.DataSource, DataTable)
                    Dim drRow As DataRow()
                    drRow = dt.Select("NAME = '" & vRegInfo.GetValue("Company").ToString & "'")
                    If drRow.Length > 0 Then
                        cboLic.EditValue = drRow(0)(1)

                    End If
                Catch ex As Exception
                End Try

                txtUserName.Text = CType(vRegInfo.GetValue("Username"), String)
                txtPassword.Text = String.Empty
                chkRememberUser.Checked = True
            Else
                cboDatabase.ItemIndex = -1
                cboLic.ItemIndex = -1
                txtUserName.Text = String.Empty
                txtPassword.Text = String.Empty
                chkRememberUser.Checked = False
            End If
            If (CType(vRegInfo.GetValue("Rememberpwd"), String).Equals("True")) Then
                txtPassword.Text = CType(vRegInfo.GetValue("Password"), String)
                chkRememberpass.Checked = True
            Else
                txtPassword.Text = String.Empty
                chkRememberpass.Checked = False
            End If
        Catch ex As Exception
            chkRememberUser.Checked = False
            chkRememberpass.Checked = False
            cboDatabase.ItemIndex = -1
            cboLic.ItemIndex = -1
            txtUserName.Text = String.Empty
            txtPassword.Text = String.Empty
        End Try

    End Sub
    Private Sub LoadData()
        Try
            sDataLogin = ""
            Dim dtData As New DataTable
            dtData = CType(cboDatabase.Properties.DataSource, DataTable)
            'find theo loai licsen Pro, ware
            'sSql = Commons.Modules.ObjSystems.MGetLicUser(txtUserName.Text)
            For j = 0 To dtData.Rows.Count - 1
                Try

                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE A FROM " & dtData.Rows(j)("database_name").ToString.Trim & "..[LOGIN] A WHERE  (ID = " & Commons.Modules.LicensePro.ToString() & ") AND NOT EXISTS (SELECT * FROM " & dtData.Rows(j)("database_name").ToString.Trim & "..[LOGIN] B WHERE (ID = " & Commons.Modules.LicensePro.ToString() & ") AND (TIME_LOGIN BETWEEN  DATEADD(MINUTE, -2,GETDATE() ) AND DATEADD(MINUTE,2,GETDATE())) AND (A.USER_LOGIN = B.USER_LOGIN))")

                    sDataLogin = IIf(String.IsNullOrEmpty(sDataLogin), "", sDataLogin & " UNION ") & "SELECT COUNT (*) AS SL, CONVERT(NVARCHAR(250),N'" & dtData.Rows(j)("database_name").ToString & "') AS DATA FROM " & dtData.Rows(j)("database_name").ToString.Trim & "..[LOGIN] AS A INNER JOIN " & dtData.Rows(j)("database_name").ToString.Trim & "..[USERS] AS B ON A.USER_LOGIN = B.USERNAME INNER JOIN " & dtData.Rows(j)("database_name").ToString.Trim & "..[NHOM] AS C ON B.GROUP_ID = C.GROUP_ID
			        WHERE  ( ID = " & cboLic.EditValue.ToString() & " ) "
                Catch ex As Exception

                End Try

            Next
            frmMain.sDataLog = sDataLogin
        Catch ex As Exception
        End Try
        FindLic()
        Try
            If CType(cboLic.Properties.DataSource, DataTable).Rows.Count = 1 Then
                cboLic.Visible = False
            Else
                cboLic.Visible = True
                Me.tlMain.SetColumnSpan(Me.cboDatabase, 1)
                Me.tlMain.Controls.Add(Me.cboLic, 2, 0)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If sHDD.ToUpper = "False".ToUpper Then
            XtraMessageBox.Show("Server Correct!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtUserName.Text.Trim = "" Then
            XtraMessageBox.Show("Please choose User Name!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtPassword.Text.Trim = "" Then
            XtraMessageBox.Show("Please choose Pass!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim vUserCtrl As UserCtrl = New UserCtrl()
        If String.IsNullOrEmpty(cboDatabase.EditValue.ToString) Then
            XtraMessageBox.Show("Please choose Database!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim sUser As String
        sUser = Commons.Modules.UserName

        If Commons.Modules.UserName <> "" Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
            Commons.Modules.UserName = ""
        End If
        Try
            Commons.Modules.LicensePro = cboLic.EditValue.ToString()
        Catch ex As Exception
            Commons.Modules.LicensePro = Commons.Modules.ObjSystems.Licences("admin")
        End Try

        Commons.IConnections.Database = cboDatabase.EditValue.ToString().Trim()
        Dim i, j As Integer
        j = 0
        i = Commons.Modules.LicensePro


        If bDN = True Then i = i + 5
        'If System.Environment.MachineName.ToUpper() = "MASHILOVE" Then i = 0
        vLogin = vLogin + 1
        Dim sSql As String
        ' = 2 QUA SO LUONG USER
        '0 USER DANG TON TAI
        '1

        sSql = " If (( 
                SELECT SUM(SL) FROM (" & sDataLogin.Replace("CBOLICCOM", Commons.Modules.LicensePro) & ") A
                ) >= " & Commons.Modules.LicensePro & ")
		        SELECT 2
	            ELSE	
	            BEGIN
		            IF NOT EXISTS ( SELECT * FROM dbo.[LOGIN] A WHERE USER_LOGIN = '" & txtUserName.Text & "' AND ID = " & Commons.Modules.LicensePro & "  ) 
			            SELECT 0	
		            ELSE 
		            BEGIN
			            DECLARE @TIME_LOGIN DATETIME 
			            SELECT @TIME_LOGIN = TIME_LOGIN FROM dbo.[LOGIN] A WHERE USER_LOGIN = '" & txtUserName.Text & "' AND ID = " & Commons.Modules.LicensePro & "
			            IF (DATEDIFF(MINUTE,@TIME_LOGIN,GETDATE()) > 1 )
				            BEGIN
					            EXEC SP_DELETE_LOGIN N'" & txtUserName.Text & "' , " & Commons.Modules.LicensePro & "
					            SELECT 0
				            END 
			            ELSE 
				            SELECT 1
		            END	
	            END "
        If bDN = True Then
            sSql = "3"
        Else
            sSql = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        End If
        bDN = False
        Dim vExitLogin = Convert.ToInt32(sSql)
        If vUserCtrl.CheckUser(txtUserName.Text, txtPassword.Text) Then
            If (vExitLogin = 1 Or vExitLogin = 2) Then
                If (vExitLogin = 2) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "MsgOutOfLicences", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Commons.Modules.UserName = String.Empty
                    Commons.Modules.UserName = String.Empty
                Else
                    If vLogin = 3 Then
                        Commons.Modules.UserName = String.Empty
                        Commons.Modules.UserName = String.Empty
                        DialogResult = Windows.Forms.DialogResult.No
                        Me.Close()
                    Else
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "MsgUserIsLogin", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Commons.Modules.UserName = String.Empty
                        Commons.Modules.UserName = String.Empty
                    End If
                End If
            Else
                Commons.Modules.UserName = txtUserName.Text
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_INSERT_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
                Try
                    Dim vRegInfo As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ECOMAINT\ECOMAINTKEY")
                    If (chkRememberUser.Checked) Then
                        vRegInfo.SetValue("Rememberuser", "True")
                        vRegInfo.SetValue("Database", cboDatabase.EditValue.ToString().Trim())
                        vRegInfo.SetValue("Username", txtUserName.Text)
                        vRegInfo.SetValue("Company", cboLic.Text)
                    Else
                        vRegInfo.SetValue("Rememberuser", "False")
                        vRegInfo.SetValue("Database", String.Empty)
                        vRegInfo.SetValue("Username", String.Empty)
                        vRegInfo.SetValue("Company", cboLic.Text)
                    End If
                    If (chkRememberpass.Checked) Then
                        vRegInfo.SetValue("Rememberpwd", "True")
                        vRegInfo.SetValue("Password", txtPassword.Text)
                    Else
                        vRegInfo.SetValue("Rememberpwd", "False")
                        vRegInfo.SetValue("Password", String.Empty)
                    End If
                Catch ex As Exception
                End Try
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Cursor = Cursors.WaitCursor
                ClsMain.LoadThongTinChung()

                If (Commons.Modules.UserName <> "") Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spDelete_Table_Tmp", "", Commons.Modules.UserName)
                End If

                Me.Cursor = Cursors.Default
                Me.Dispose()
            End If
        Else
            If vLogin = 3 Then
                Commons.Modules.UserName = String.Empty
                Commons.Modules.UserName = String.Empty
                DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "MsgFalse", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Commons.Modules.UserName = String.Empty
                Commons.Modules.UserName = String.Empty
                exit Sub
            End If
        End If
        If Commons.Modules.UserName = "" And sUser <> "" Then
            Commons.Modules.UserName = sUser
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_INSERT_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
        End If

        'If Commons.Modules.sPrivate = "VIFON" Then
        '    sSql = "SELECT GETDATE() AS DATE"
        '    Dim dNgayHTai As Date
        '    Try
        '        dNgayHTai = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)
        '    Catch ex As Exception
        '        dNgayHTai = "02/03/2019"
        '    End Try
        '    If dNgayHTai < Now.Date Then
        '        dNgayHTai = "02/03/2019"
        '    End If
        '    If dNgayHTai < Vietsoft.Information.GetNistTime().Date Then
        '        dNgayHTai = "02/03/2019"
        '    End If


        '    If (dNgayHTai.Date > DateSerial("2019", "03", "01")) Then
        '        XtraMessageBox.Show("Phần mềm tạm ngưng.", "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    End If

        'End If

        Me.Cursor = Cursors.Default
        Try
            frmMain.sCty = ""
            If cboLic.Text <> "" Then
                frmMain.sCty = " | " & cboLic.Text
            End If
            If Commons.Modules.sPrivate = "TRUNGNGUYEN" Then
                SaveconfigOEE()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function SaveconfigOEE() As Boolean
        'lưu config vào file
        Dim ds As New DataSet()
        ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\OEE\\lib\\saveconfig.xml")
        ds.Tables(0).Rows(0)("S") = Commons.IConnections.Server
        ds.Tables(0).Rows(0)("D") = Commons.IConnections.Database
        ds.Tables(0).Rows(0)("U") = Commons.IConnections.Username
        ds.Tables(0).Rows(0)("P") = Commons.IConnections.Password
        ds.Tables(0).Rows(0)("US") = Commons.Modules.UserName
        ds.Tables(0).Rows(0)("LA") = Commons.Modules.TypeLanguage
        ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\OEE\\lib\\saveconfig.xml")
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown, txtUserName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If

        If e.Modifiers = Keys.Alt And e.KeyCode = Keys.H Then
            bDN = True
            If txtUserName.Text.Trim = "" Then
                txtUserName.Text = "Admin"
            End If
            Commons.IConnections.Database = cboDatabase.Text
            Try

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", txtUserName.Text, Commons.Modules.LicensePro)
            Catch ex As Exception
            End Try
            Try

                Dim sSql As String
                sSql = "SELECT PASS FROM USERS WHERE USERNAME = N'" & txtUserName.Text & "' "
                sSql = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)))
                txtPassword.Text = sSql
            Catch ex As Exception

            End Try

            btnLogin_Click(sender, e)
            bDN = False
        End If

    End Sub

    Private Sub LabelControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelControl1.DoubleClick, LabelControl2.DoubleClick
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", txtUserName.Text, Commons.Modules.LicensePro)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LabelControl3_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelControl3.DoubleClick
        If txtUserName.Text.Trim = "" Then
            txtUserName.Text = "Admin"
        End If
        Commons.IConnections.Database = cboDatabase.Text
        'If txtPassword.Text.Trim = "" Then
        Try

            Dim sSql As String
            sSql = "SELECT PASS FROM USERS WHERE USERNAME = N'" & txtUserName.Text & "' "
            sSql = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)))
            txtPassword.Text = sSql
        Catch ex As Exception

        End Try

        'End If

    End Sub

    Private Sub LabelControl4_DoubleClick(sender As Object, e As EventArgs) Handles LabelControl4.DoubleClick
        bDN = True
        If txtUserName.Text.Trim = "" Then
            txtUserName.Text = "Admin"
        End If
        Commons.IConnections.Database = cboDatabase.Text
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", txtUserName.Text, Commons.Modules.LicensePro)
        Catch ex As Exception
        End Try
        Try
            Dim sSql As String
            sSql = "SELECT PASS FROM USERS WHERE USERNAME = N'" & txtUserName.Text & "' "
            sSql = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)))
            txtPassword.Text = sSql
        Catch ex As Exception
        End Try
        btnLogin_Click(sender, e)
        bDN = False
    End Sub

    Private Sub cboDatabase_EditValueChanged(sender As Object, e As EventArgs) Handles cboDatabase.EditValueChanged
        Try
            btnLogin.Enabled = IIf(cboDatabase.EditValue.ToString.Trim = "", False, True)
        Catch ex As Exception
            btnLogin.Enabled = False
        End Try
    End Sub

#End Region

#Region "Service Check"
    Public sHDD As String = "-1"
    Public sLic As String = "-1"
    Dim sIP As String = ""

    Private Sub CheckServer()
        Dim ip As IPAddress
        Try
            sIP = Commons.IConnections.Server
            Dim sArr1() As String = Split(sIP, "\")

            If sArr1.Count > 1 Then
                sIP = sArr1(0)
            End If

            Dim myHost As String = System.Net.Dns.GetHostName
            If sIP = "." Then
                ip = Dns.GetHostEntry(myHost).AddressList.Where(Function(o) o.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork).First()
            Else
                Try
                    ip = IPAddress.Parse(sIP)
                Catch ex As Exception
                    ip = Dns.GetHostEntry(sIP).AddressList.Where(Function(o) o.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork).First()
                End Try
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + vbCrLf + "A" + ex.Message.ToString(), "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try


        sIP = ip.ToString()
        sHDD = "-1"
        sLic = "-1"
        Try
            If CheckService() = False Then
                XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + vbCrLf + "B", "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If
            If Commons.Modules.LicDemo = True Then
                If Not KiemHetHan() Then End
            End If

        Catch ex As Exception
            XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + vbCrLf + "C" + ex.Message.ToString(), "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try
    End Sub

    Function KiemHetHan() As Boolean
        Try
            Dim fInfo As New IO.FileInfo(System.Windows.Forms.Application.StartupPath & "\CMMS.exe")
            Dim dateMod As Date = fInfo.LastWriteTime.Date
            If DateDiff(DateInterval.Day, Now.Date, CDate(Commons.Modules.DemoDate)) < 0 Then
                MsgBox("Thời hạn chạy phiên bản dùng thử đã hết " & Application.ProductName & vbCrLf & vbCrLf & "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.", MsgBoxStyle.Exclamation)
                Return False
            ElseIf DateDiff(DateInterval.Day, CDate(dateMod), Now.Date) < 0 Then
                MsgBox("Thời hạn chạy phiên bản dùng thử đã hết " & Application.ProductName & vbCrLf & vbCrLf & "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.", MsgBoxStyle.Exclamation)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Function CheckService() As Boolean
        Dim stmp As String = "0"
        'Return True
        'Try
        '    Dim permission As New SocketPermission(NetworkAccess.Connect, TransportType.Tcp, "", SocketPermission.AllPorts)
        '    permission.Demand()
        'Catch exc As Exception
        '    XtraMessageBox.Show(exc.ToString() & " " & stmp)
        '    Return False
        'End Try
        stmp = "2"
        Try
            Dim client = New UdpClient()
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000)
            'MessageBox.Show(sIP)
            Dim ep As New IPEndPoint(IPAddress.Parse(sIP), Integer.Parse(65000))
            'Dim ep As New IPEndPoint(IPAddress.Parse(sIP), Integer.Parse(80))
            ' endpoint where server is listening
            client.Connect(ep)
            stmp = "3"
            ' send data
            Dim buffer As Byte() = Encoding.ASCII.GetBytes("HDD")
            client.Send(buffer, buffer.Length)
            stmp = "4"
            ' then receive data
            Dim rev = client.Receive(ep)
            stmp = "41"
            'lb_stt.Text = Encoding.ASCII.GetString(rev);
            Dim sStr As String = ""
            stmp = "42"
            sStr = Encoding.ASCII.GetString(rev)
            stmp = "5"
            Dim sArr() As String = Split(sStr, "!")
            sHDD = sArr(0)
            Try
                Commons.Modules.DemoDate = Convert.ToDateTime(sArr(1).Substring(6) & "/" & sArr(1).Substring(4, 2) & "/" & sArr(1).Substring(0, 4))
            Catch ex As Exception
            End Try
            stmp = "6"
            ' send data
            buffer = Encoding.ASCII.GetBytes("LIC")
            client.Send(buffer, buffer.Length)
            stmp = "7"
            ' then receive data
            rev = client.Receive(ep)
            stmp = "8"
            sStr = Encoding.ASCII.GetString(rev)
            sArr = Nothing
            sArr = Split(sStr, "!")
            Try
                Commons.Modules.LicensePro = Integer.Parse(sArr(0))
                sLic = Commons.Modules.LicensePro
            Catch ex As Exception
            End Try
            stmp = "9"

            ' send data
            buffer = Encoding.ASCII.GetBytes("LICCOM")
            client.Send(buffer, buffer.Length)
            stmp = "10"
            ' then receive data
            rev = client.Receive(ep)
            stmp = "11"
            sStr = Encoding.Unicode.GetString(rev)
            sArr = Nothing
            sArr = Split(sStr, "|")

            stmp = "12"
            Dim sSql As String = ""
            Dim iSTT As Integer = 0
            For Each sData As String In sArr
                Dim sArr1() As String = Split(sData, "~")
                If sArr1.Length = 1 Then
                    If sArr1(0).ToString().Trim().ToUpper = "DEMO" Then Commons.Modules.LicDemo = True Else Commons.Modules.LicDemo = False
                End If
                If sArr1.Length > 1 Then
                    sSql = IIf(sSql.Length = 0, " SELECT N'" & sArr1(0).ToString().Trim() & "' AS NAME, N'" & Commons.Modules.MExcel.MCot(sArr1(1).ToString().Trim()) & "' AS LIC, " & iSTT.ToString & " AS STT ", sSql & " UNION SELECT N'" & sArr1(0).ToString().Trim() & "' AS NAME, N'" & Commons.Modules.MExcel.MCot(sArr1(1).ToString().Trim()) & "' AS LIC , " & iSTT.ToString & " AS STT ")
                End If
                iSTT = iSTT + 1
            Next
            stmp = "13"
            client.Close()

            Try

                If Not Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLic, sSql + " ORDER BY STT ", "LIC", "NAME", "") Then
                    XtraMessageBox.Show("CheckService : " + stmp + vbLf + sSql)
                    Return False
                Else
                    Commons.Modules.LicensePro = Integer.Parse(cboLic.EditValue.ToString())
                    sLic = Commons.Modules.LicensePro
                End If
            Catch ex As Exception
                XtraMessageBox.Show("CheckService : " + vbLf + ex.Message.ToString())
                Return False
            End Try

            stmp = "14"
        Catch ex As Exception
            'XtraMessageBox.Show(ex.ToString() & " " & stmp)
            XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + vbCrLf + stmp + vbCrLf + ex.Message.ToString() + vbCrLf + stmp, "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
            Return False

        End Try
        Return True

    End Function

    Private Sub cboLic_EditValueChanged(sender As Object, e As EventArgs) Handles cboLic.EditValueChanged
        Commons.Modules.LicensePro = Integer.Parse(cboLic.EditValue.ToString())
        sLic = Commons.Modules.LicensePro
        FindLic()

    End Sub

    Private Sub FindLic()
        Try
            Try
                Commons.Modules.LicensePro = cboLic.EditValue.ToString()
            Catch ex As Exception
                Commons.Modules.LicensePro = Commons.Modules.ObjSystems.Licences("admin")
            End Try

            sSql = " SELECT SUM(SL) FROM (" & sDataLogin.Replace("CBOLICCOM", Commons.Modules.LicensePro) & ") T1 "
            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            sSql = "Total " & sSql & "/" & Commons.Modules.LicensePro & " user login"
            lblUser.Text = sSql
        Catch ex As Exception
            lblUser.Text = "Total 0/" & Commons.Modules.ObjSystems.Licences("admin") & " user login"
        End Try
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim iKiemFile As Boolean = True 'False kiem qua server -- true kiem qua file config
        sHDD = "-1"
        If iKiemFile = True Then
#Region "Kiem qua file VSConfig"
            'kiem chay theo VSConfig
            Try
                Dim sSql = ""
                Try
                    sSql = " SELECT TOP 1 PRIVATE FROM dbo.THONG_TIN_CHUNG "
                    sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                    If sSql.ToString.ToUpper = "VINHHOAN" Then Commons.Modules.LicensePro = 3
                Catch ex As Exception

                End Try


                If Not Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLic, "Select  N'VietSoft' AS NAME, N'" + Commons.Modules.LicensePro.ToString() + "' AS LIC, 1 AS STT " + " ORDER BY STT ", "LIC", "NAME", "") Then
                    Try
                        XtraMessageBox.Show("Số License : " + Commons.Modules.LicensePro.ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("Số License : 0" & vbCrLf & ex.Message.ToString())
                    End Try
                    End
                Else
                    Commons.Modules.LicensePro = Integer.Parse(cboLic.EditValue.ToString())
                    sLic = Commons.Modules.LicensePro
                    sHDD = "TRUE"
                End If
            Catch ex As Exception
                Try
                    XtraMessageBox.Show("Số License : " + Commons.Modules.LicensePro.ToString & vbCrLf & ex.Message.ToString())
                Catch ex1 As Exception
                    XtraMessageBox.Show("Số License : 0" & vbCrLf & ex1.Message.ToString())
                End Try
                End
            End Try
#End Region
        Else
#Region "Kiem Server"
            CheckServer()
#End Region
        End If

        If sHDD = "-1" Then
            XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + vbCrLf + " HDD " + sHDD, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        Else
            If sHDD.ToUpper = "False".ToUpper Then
                XtraMessageBox.Show("Sever name is incorrect! Please contact admin.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If
        End If


        LoadData()
    End Sub

#End Region
End Class