Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports DevExpress.XtraEditors

Module CMMS_Main
    '<STAThread()>
    Public Sub Main()
        Commons.Modules.ModuleName = "ECOMAIN"
        Vietsoft.Information.ModuleName = "ECOMAIN"
        Dim myHost As String = System.Net.Dns.GetHostName
        Try
            Dim HDDSerial As String
            HDDSerial = ""
            If Not LayThongTinConfig() Then End
            XuLyFileUpdate()
            CheckUpdate(0)
            Dim MyThread As System.Threading.Thread
            MyThread = New System.Threading.Thread(AddressOf LaunchForm)
            MyThread.SetApartmentState(Threading.ApartmentState.STA)
            MyThread.Start()
        Catch ex As Exception
            XtraMessageBox.Show("Sub main" + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub XuLyFileUpdate()
        Try
            'Neu mun cap nhap file update.exe thi thu muc update se khong duoc xoa tu file update.exe cu (neu khong update file update.exe thi thu muc update se bi xoa). Luc nay thu muc update se con ton tai va chua file update.exe va se duoc xu ly tai day
            If Not Directory.Exists(Application.StartupPath & "\Update") Then Exit Sub
            'Xu ly copy file update 
            If File.Exists(Application.StartupPath & "\Update\Update.exe") Then
                File.Copy(Application.StartupPath & "\Update\Update.exe", Application.StartupPath & "\Update.exe", True)
            End If

            Try
                If File.Exists(Application.StartupPath & "\Update\Update.exe") Then
                    File.Delete(Application.StartupPath & "\Update\Update.exe")
                End If
                Directory.Delete(Application.StartupPath & "\Update")
            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Function LayThongTinConfig() As Boolean
        If File.Exists(Application.StartupPath + "\VSConfig.ini") Then
            Dim sFileInclude = System.IO.File.OpenText(Application.StartupPath + "\VSConfig.ini")
            Try
                Dim sRowStream As String = sFileInclude.ReadToEnd()
                sRowStream = Commons.clsXuLy.GiaiMaDL(sRowStream)
                Dim sArr() As String = Split(sRowStream, "!")
                Commons.IConnections.Server = sArr(0)
                Commons.IConnections.Database = sArr(1)
                Commons.IConnections.Username = sArr(2)
                Commons.IConnections.Password = sArr(3)
                Commons.Modules.TypeLanguage = Convert.ToInt32(sArr(4))
                HDDSerial = sArr(6)
                CheckServer = Convert.ToInt32(sArr(7))
                Commons.Modules.LicensePro = Convert.ToInt32(sArr(5))
                Commons.Modules.LicenseProduction = Convert.ToInt32(sArr(8))
                Commons.Modules.LicenseWarehouse = Convert.ToInt32(sArr(9))
                'coi fai la demo hay khong 0 la khong 1 la demo
                Try
                    Commons.Modules.LicDemo = sArr(10)
                Catch ex As Exception
                    Commons.Modules.LicDemo = 0
                End Try

                'Ngay ket thuc demo
                Try
                    Commons.Modules.DemoDate = sArr(11)
                Catch ex As Exception
                    Commons.Modules.DemoDate = Now.Date
                End Try
                sFileInclude.Close()
                sFileInclude.Dispose()
            Catch Excep As Exception
                sFileInclude.Close()
                sFileInclude.Dispose()
                XtraMessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

        Else

            XtraMessageBox.Show("Config not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Public Sub update(ByVal loai As Int16, ByVal link1 As String, ByVal link2 As String, ByVal link3 As String)
        Try
            Process.Start("Update.exe", loai.ToString() + " " + link1 + " " + link2 + " " + link3 + " " + Application.ProductName)
            'link1,2 : link dropbox - link3: path tren server
            ' + https://www.dropbox.com/s/n051eeswfwz12o4/Update.zip?dl=0 https://www.dropbox.com/s/srzbu12hnahlr18/Version.txt?dl=0 \\\\192.168.2.22\\Update")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CapNhapPM()

        XtraMessageBox.Show("Bạn đang dùng phiên bản cũ, phần mềm sẽ tự động cập nhật.", "", MessageBoxButtons.OK)

        Dim vRegInfo As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ECOMAINT\ECOMAINTKEY")
        Try
            If (CType(vRegInfo.GetValue("CNBB"), String).ToUpper.Equals("true".ToUpper)) Then
                CapNhapBB()
                vRegInfo.SetValue("CNBB", "False")
            End If
        Catch
            CapNhapBB()
            vRegInfo.SetValue("CNBB", "False")
        End Try


        Dim startInfo As New System.Diagnostics.ProcessStartInfo
        startInfo.UseShellExecute = True
        startInfo.WorkingDirectory = Environment.CurrentDirectory
        Dim sFileCN As String
        Dim sFileGF As String

        sFileCN = Application.StartupPath.ToString() + "CMMS Client.exe"
        sFileGF = Application.StartupPath.ToString() + "CMMS Client GF.exe"

        If File.Exists(sFileCN) Then
            startInfo.FileName = sFileCN
        Else
            startInfo.FileName = sFileGF
        End If

        startInfo.Verb = "runas"
        Try
            System.Diagnostics.Process.Start(startInfo)
        Catch ex As Exception
            System.Diagnostics.Process.Start(sFileGF)
        End Try
        End
    End Sub
    Public Sub LoadTB()
        Try
            Commons.Modules.SQLString = "00Load"
            Dim frm = New frmThongtinthietbi
            frm.MdiParent = frmMain
            frm.Show()
            frm.Close()
            Commons.Modules.SQLString = ""
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LaunchForm()
        Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(frmMain)
        Catch ex As Exception
       
        End Try
    End Sub

    Public Sub CheckUpdate(ByVal iUpdate As Boolean)
        Try
            Dim sInfoClient, sInfoSer As Double
            sInfoClient = Convert.ToDouble(LayDuLieu("Version.txt", "Version"))
            Try
                Commons.Modules.sInfoClient = sInfoClient.ToString.Substring(0, (sInfoClient.ToString.Length - 4))
                Commons.Modules.sInfoClient = Commons.Modules.sInfoClient.Substring(6, 2) + "/" + Commons.Modules.sInfoClient.Substring(4, 2) + "/" + Commons.Modules.sInfoClient.Substring(0, 4) + "." + sInfoClient.ToString.Substring(8, sInfoClient.ToString.Length - 8)
            Catch ex As Exception
                Commons.Modules.sInfoClient = sInfoClient.ToString
            End Try

            Dim sSql As String
            sSql = "SELECT TOP 1 VER FROM THONG_TIN_CHUNG WHERE CAP_NHAP = 1"
            sInfoSer = Convert.ToDouble(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            bCNUpdate = False
            Try
                Commons.Modules.sInfoSer = sInfoSer.ToString.Substring(0, (sInfoSer.ToString.Length - 4))
                Commons.Modules.sInfoSer = Commons.Modules.sInfoSer.Substring(6, 2) + "/" + Commons.Modules.sInfoSer.Substring(4, 2) + "/" + Commons.Modules.sInfoSer.Substring(0, 4) + "." + sInfoSer.ToString.Substring(8, sInfoSer.ToString.Length - 8)
            Catch ex1 As Exception
                Commons.Modules.sInfoSer = sInfoSer
            End Try

            'If (myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString()) Or (myHost.ToUpper().ToString() = "M4SHI".ToUpper.ToString()) Then
            'Else
            If sInfoSer <> 0 Then
                If sInfoClient <> sInfoSer Then
1:
                    Try
                        sSql = "SELECT TOP 1 (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM THONG_TIN_CHUNG"
                        Dim linkCapNhat As String = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        Dim loai As Integer = Convert.ToInt32(linkCapNhat.Split("!")(0))
                        Dim link1 As String = linkCapNhat.Split("!")(1)
                        Dim link2 As String = linkCapNhat.Split("!")(2)
                        Dim link3 As String = linkCapNhat.Split("!")(3)
                        If loai = -1 Then Exit Sub

                        If (loai = 1 And Not String.IsNullOrEmpty(link3.Trim())) Then
                            If (Not Directory.Exists(link3)) Then
                                XtraMessageBox.Show("Link update : " + link3 + " không tồn tại.")
                                Exit Sub
                            End If
                            update(loai, link1, link2, link3)
                        ElseIf (loai = 2 And Not String.IsNullOrEmpty(link1.Trim())) Then
                            update(loai, link1, link2, link3)
                        Else
                            If KiemUpDate() = True Then
                                CapNhapPM()
                            End If
                        End If
                    Catch ex As Exception
                        If KiemUpDate() = True Then
                            CapNhapPM()
                        End If
                    End Try
                Else
                    If iUpdate = True Then
                        If (XtraMessageBox.Show("Bạn đang dùng phiên bản hiện tại. Bạn có muốn cập nhật lại?", "", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                            GoTo 1
                        End If
                    End If
                End If
            End If
            'End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message & "Update Messenger")
        End Try
    End Sub


    Public Function KiemUpDate() As Boolean
        Dim sInfoClient, sInfoServer As Double
        Dim sIP As String
        sIP = ""
        Try
            sIP = LayDuLieu("Server.txt", "Server")

            If sIP = "." Then
                Return False
            End If
            sInfoClient = Convert.ToDouble(LayDuLieu("Version.txt", "Version"))
            Dim objClient As CMMSClientLib.CMMSClientDll
            objClient = New CMMSClientLib.CMMSClientDll("", "", "")
            objClient.iPServer = sIP
            Dim sInfo As String
            sInfo = objClient.ReceiveInfo(sIP)
            Try
                sInfoServer = Convert.ToDouble(sInfo)
            Catch ex As Exception
                sInfoServer = 0
            End Try
            If sInfoServer > sInfoClient Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            MsgBox("Vui lòng kiểm tra lại Service update." + vbCrLf + ex.Message.ToString())
        End Try
    End Function
    Private Sub KiemTraVerCMMS()
        Try

            Dim newver As String = ""
            Dim oldver As String = ""
            'dowload file version CMMS
            If Not Directory.Exists(Application.StartupPath + "\Update") Then
                Directory.CreateDirectory(Application.StartupPath + "\Update")
            End If
            If File.Exists(Application.StartupPath + "\Update\Version.txt") Then
                File.Delete(Application.StartupPath + "\Update\Version.txt")
            End If
            Dim WebClient As New WebClient
            Try
                WebClient.DownloadFile(New Uri("https://www.dropbox.com/s/tie27yia42dhkmu/Version.txt?dl=1"), Application.StartupPath + "\Update\Version.txt")
            Catch ex As Exception

            End Try

            'đọc file version cmms
            If File.Exists(Application.StartupPath & "\Update\Version.txt") Then
                Dim path = Application.StartupPath & "\Update\Version.txt"
                Dim fileStream = New FileStream(path, FileMode.Open, FileAccess.Read)
                Using streamReader = New StreamReader(fileStream, Encoding.UTF8)
                    newver = streamReader.ReadToEnd()
                End Using
            End If
            'lấy version CMMS hiện tại
            Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.StartupPath & "\CMMS.exe")
            oldver = myFileVersionInfo.FileVersion
            If Chekvertion(newver, oldver) = True Then
                update(2, "https://www.dropbox.com/s/s4jaa9ga6wklxfv/Update.zip?dl=0", "https://www.dropbox.com/s/tie27yia42dhkmu/Version.txt?dl=0", "-99")

            Else
                CheckUpdate(0)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Deletefile()
        Dim destination As String = Application.StartupPath & "\lib"
        Dim Dirs As String() = Directory.GetFiles(destination)
        For Each Dir As String In Dirs
            Dim s As String = Path.GetFileName(Dir)
            File.Delete(Application.StartupPath & "\" & s)
        Next
    End Sub

    Private Function Chekvertion(ByVal vernew As String, ByVal verold As String) As Boolean
        Dim listnew = vernew.Split(".")
        Dim listold = verold.Split(".")
        For i = 0 To 3
            If Convert.ToInt32(listnew(i)) > Convert.ToInt32(listold(i)) Then
                Return True
            Else
                Return False
            End If
        Next


    End Function

    Public Function GetPage(ByVal PageURL As String) As String
        Dim S As String = ""
        Try
            Dim Request As HttpWebRequest = WebRequest.Create(PageURL)
            Dim Response As HttpWebResponse = Request.GetResponse()
            Using Reader As StreamReader = New StreamReader(Response.GetResponseStream())
                S = Reader.ReadToEnd
            End Using
        Catch ex As Exception
            Debug.WriteLine("FAIL: " + ex.Message)
        End Try
        Return S
    End Function

    Public Sub CapNhapBB()
        Dim sr As New StreamReader(Application.StartupPath.ToString() + System.IO.Path.DirectorySeparatorChar & "Server.txt")
        Try
            Dim sIP As [String]
            sIP = sr.ReadLine()
            Dim outPath As String = Application.StartupPath.ToString() + "\" '.Replace("\\", "/") + "/"
            ReceiveFilesFromServer("CMMS Client.exe", sIP, outPath)
            ReceiveFilesFromServer("CMMS Client.exe", sIP, outPath)

            ReceiveFilesFromServer("CMMSClientLib.dll", sIP, outPath)
            ReceiveFilesFromServer("CMMSClientLib.dll", sIP, outPath)

            Try
                ReceiveFilesFromServer("CMMS Client GF.exe", sIP, outPath)
                ReceiveFilesFromServer("CMMS Client GF.exe", sIP, outPath)

                ReceiveFilesFromServer("CMMSClientGFLib.dll", sIP, outPath)
                ReceiveFilesFromServer("CMMSClientGFLib.dll", sIP, outPath)
            Catch ex As Exception

            End Try
        Catch
        End Try
        sr.Close()


        Try
            Dim startInfo As New System.Diagnostics.ProcessStartInfo
            startInfo.UseShellExecute = True
            startInfo.WorkingDirectory = Environment.CurrentDirectory

            If File.Exists("CMMS Client.exe") Then
                startInfo.FileName = Application.StartupPath.ToString() + "\CMMS Client.exe"
            Else
                startInfo.FileName = Application.StartupPath.ToString() + "\CMMS Client GF.exe"
            End If

            startInfo.Verb = "runas"
            Try
                System.Diagnostics.Process.Start(startInfo)
            Catch ex As Exception
                System.Diagnostics.Process.Start(Application.StartupPath.ToString() + "\CMMS Client GF.exe")
            End Try

            End
        Catch ex As Exception

        End Try
    End Sub

    Public Function KiemHDDSerial(ByVal HDDSerial As String) As Boolean
        Try
            Dim sIP As String
            sIP = LayDuLieu("SeHDD.txt", "Server")

            Dim objClient As CMMSClientLib.CMMSClientDll
            objClient = New CMMSClientLib.CMMSClientDll("", "", "")
            objClient.iPServer = sIP
            Dim sInfo As String
            sInfo = objClient.ReceiveHDDSerial(sIP)

            If HDDSerial.ToUpper.ToString().Trim() = sInfo.ToUpper.ToString().Trim() Then
                KiemHDDSerial = True
            Else
                KiemHDDSerial = False
            End If

        Catch ex As Exception
            KiemHDDSerial = False
            MsgBox("Vui lòng kiểm tra lại HDD Service update." + vbCrLf + ex.Message.ToString())
        End Try

    End Function

    Public Function LayDuLieu(ByVal TenFile As String, ByVal Chuoi As String) As String
        Dim sW As StreamWriter
        Dim sr As StreamReader
        Dim sText As String
        sText = ""
        Try
            sText = Application.StartupPath.ToString() + "\" + TenFile
            sr = New StreamReader(sText)
            sText = ""
            sText = sr.ReadLine
            Try
                If sText = Nothing Then
                    sText = ""
                End If

            Catch ex As Exception
                sText = ""
            End Try
            sr.Close()

            If String.IsNullOrEmpty(sText.ToString().Trim()) Then
                sText = InputBox("Please input " & Chuoi & ".")
                sW = New StreamWriter(Application.StartupPath.ToString() + "\" + TenFile)
                'writer.WriteLine(text);
                sW.WriteLine(sText)
                sW.Close()
                sr = New StreamReader(Application.StartupPath.ToString() + "\" + TenFile)
                sText = sr.ReadLine
                sr.Close()
            End If
        Catch ex As Exception
        End Try
        Return sText
    End Function

    Public progress As Integer = 0, portSend As Integer, portReceive As Integer

    Public Sub ReceiveFilesFromServer(ByVal onlyFileNameObj As Object, ByVal iPServer As String, ByVal outPath As String)
        Try
            ReadAndWriteFolder(onlyFileNameObj.ToString(), outPath)
            Dim server As Socket = Nothing
            Dim ipEnd As New IPEndPoint(IPAddress.Parse(iPServer), 9051)
            server = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
            server.Connect(ipEnd)

            Dim onlyFileName As String = onlyFileNameObj.ToString()
            onlyFileName = onlyFileName.Replace("#", "")
            onlyFileName = onlyFileName.Replace("...", "")

            'Send file can nhan cho Server.
            Dim clientInfoData As Byte() = New Byte(255) {}
            clientInfoData = Encoding.ASCII.GetBytes(onlyFileName)
            server.Send(clientInfoData)
            'Nhan file tu Server.
            Dim receiveData As Byte() = New Byte(255) {}
            Dim recvLen As Integer = server.Receive(receiveData)
            Dim BuffLen As Integer = Integer.Parse(Encoding.ASCII.GetString(receiveData, 0, recvLen))
            Dim data As Byte() = New Byte(BuffLen - 1) {}
            'DATA FORMAT: [FILE SIZE LEN INFO[0-3]][FILE NAME LEN INFO[4-7]][FILE NAME DATA][FILE CONTENT]
            'int len = server.Receive(data, server.Available, SocketFlags.None);

            Receive(server, data, 0, data.Length, 10000)
            Dim len As Integer = data.Length

            Dim fileNameLen_h As Integer = BitConverter.ToInt32(data, 0)
            Dim fileName_h As String = Encoding.ASCII.GetString(data, 4, fileNameLen_h)
            Try
                If File.Exists(outPath & onlyFileName) Then
                    File.Delete(outPath & onlyFileName)
                End If
            Catch
            End Try

            Try
                Dim bWrite As New BinaryWriter(File.Open(outPath & onlyFileName, FileMode.Append))
                bWrite.Write(data, 4 + fileNameLen_h, len - 4 - fileNameLen_h)
                bWrite.Flush()
                bWrite.Close()
            Catch
                Try
                    Dim bWrite As New BinaryWriter(File.Open(outPath & onlyFileName, FileMode.CreateNew))
                    bWrite.Write(data, 4 + fileNameLen_h, len - 4 - fileNameLen_h)
                    bWrite.Flush()
                    bWrite.Close()
                Catch
                End Try
            End Try


            Try
                Dim sStmp As String = ReceiveFileInfo(onlyFileName, iPServer)
                Dim chuoi_tach As String() = sStmp.Split(New [Char]() {"|"c})

                File.SetCreationTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach(0).ToString()))
                File.SetLastWriteTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach(1).ToString()))
                File.SetLastAccessTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach(2).ToString()))
            Catch
            End Try

            server.Shutdown(SocketShutdown.Both)
            server.Close()
        Catch
        End Try
    End Sub

    Public Sub ReadAndWriteFolder(ByVal _fileName As String, ByVal outPath As String)
        Try
            _fileName = _fileName.Replace("#", "")
            _fileName = _fileName.Replace("...", "")
            Dim _tmpPath As String = ""
            Dim _tmpFileName As String = _fileName
            While _tmpFileName.IndexOf("\") <> -1
                _tmpPath += _tmpFileName.Substring(0, _tmpFileName.IndexOf("\")) + "/"
                _tmpFileName = _tmpFileName.Substring(_tmpFileName.IndexOf("\") + 1)
            End While
            _tmpPath = _tmpPath.Trim().Substring(0, _tmpPath.Length - 1)
            If Not Directory.Exists(outPath & _tmpPath) Then
                Directory.CreateDirectory(outPath & _tmpPath)
            End If
        Catch
        End Try
    End Sub

    Public Sub Receive(ByVal socket As Socket, ByVal buffer As Byte(), ByVal offset As Integer, ByVal size As Integer, ByVal timeout As Integer)
        Dim startTickCount As Integer = Environment.TickCount
        Dim received As Integer = 0
        ' how many bytes is already received
        Do
            If Environment.TickCount > startTickCount + timeout Then
                Throw New Exception("Timeout.")
            End If
            Try
                received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None)
            Catch ex As SocketException
                If ex.SocketErrorCode = SocketError.WouldBlock OrElse ex.SocketErrorCode = SocketError.IOPending OrElse ex.SocketErrorCode = SocketError.NoBufferSpaceAvailable Then
                    ' socket buffer is probably empty, wait and try again
                    Thread.Sleep(30)
                Else
                    Throw ex
                    ' any serious error occurr
                End If
            End Try
        Loop While received < size
    End Sub

    Public Function ReceiveFileInfo(ByVal fileName As String, ByVal iPServer As String) As String
        Try
            Dim server As Socket = Nothing
            Dim ipEnd As New IPEndPoint(IPAddress.Parse(iPServer), 9051)
            Dim ipEnad As New IPEndPoint(IPAddress.Parse(iPServer), 9051)

            server = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
            server.Connect(ipEnd)

            Dim clientInfoData As Byte() = New Byte(255) {}
            clientInfoData = Encoding.ASCII.GetBytes(Convert.ToString("FI") & fileName)
            server.Send(clientInfoData)



            Dim receiveData As Byte() = New Byte(99999) {}
            Dim recvLen As Integer = server.Receive(receiveData)

            Dim s As String = Encoding.ASCII.GetString(receiveData).Substring(0, recvLen)

            server.Shutdown(SocketShutdown.Both)
            server.Close()

            Return s
        Catch
            Return ""
        End Try
    End Function


End Module