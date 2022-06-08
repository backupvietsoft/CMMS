using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace CmmsServerLib
{
   public class CmmsServerDll
    {
        public static bool isServerRunning = false;
        public static int receivePort, sendPort, maxClientReceived, bufferSize;
        public string outPath;
        public static string status = "", presentOperation = "";
        public string currentStatus = "";
        //public string iPServer = "192.168.1.18";
        public string iPServer;
        string fileNameWithPath;
        public string _Path ;//= @"E:\0812 TestData\send files\";
        public string _PathUp;
        public string PathUp
        {
            get
            {
                return _PathUp;
            }
            set
            {
                _PathUp = value;
            }
        }
        //public string _Path;


        public CmmsServerDll(int receivePort,int sendPort,int maxClient, string outPutPath)
        {
            try
            {
                CmmsServerDll.receivePort = receivePort;
                CmmsServerDll.sendPort = sendPort;
                CmmsServerDll.bufferSize = 10 * 1024;
                CmmsServerDll.maxClientReceived = maxClient;

                this._Path = outPutPath;
                if (_Path.Substring(_Path.Length - 2) != "\\")
                    this._Path = outPutPath + "\\";

                outPutPath = outPutPath.Replace("\\", "/");
                if (outPutPath.Substring(outPutPath.Length - 1) != "/")
                    outPutPath += "/";

                this.outPath = outPutPath;
                CmmsServerDll.status = "";
                //this._Path = outPutPath;
                //SyncSocketServerMulClient.progress = 0;
                CmmsServerDll.presentOperation = "";
            }
            catch { }
        }
        /// <summary>
        /// Default sets Receive Port:9050, Send Port:9051, Buffer Size:10KB, Max Client:100 and Out path: C:\
        /// </summary>
        public CmmsServerDll()
        {
            try
            {
                CmmsServerDll.receivePort = 9050;
                CmmsServerDll.sendPort = 9051;
                CmmsServerDll.bufferSize = 10 * 1024;
                CmmsServerDll.maxClientReceived = 100;
                this.outPath = "E:/0812 TestData/send files/";
                CmmsServerDll.status = "";
                //SyncSocketServerMulClient.progress = 0;
                CmmsServerDll.presentOperation = "";
            }
            catch
            {}
            
        }

        Thread threadReceiveServer, threadSendServer;
        Socket receiveSock, sendSock;
        IPEndPoint ipEndReceive, ipEndSend;

        #region Start Server
        //Start Server H2
        public void StartServer()
        {
            //StartReceiveServer();
            StartSendServer();
        }
       #endregion

        #region Send Files
        //Send Data From Server to Client.
        private void StartSendServer()
        {
            try
            {
                currentStatus = "Starting !...";
                CmmsServerDll.isServerRunning = true;
                threadSendServer = new Thread(new ThreadStart(this.StartSendServerThread));
                threadSendServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StartSendServerThread()
        {
            try
            {
                ipEndSend = new IPEndPoint(IPAddress.Parse(iPServer), CmmsServerDll.sendPort);
                sendSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                sendSock.Bind(ipEndSend);
                CmmsServerDll.isServerRunning = true;
                sendSock.Listen(maxClientReceived);
                Console.WriteLine("Waiting for new client connection");
                while (CmmsServerDll.isServerRunning)
                {
                    Socket clientSock;
                    clientSock = sendSock.Accept();
                    CmmsServerDll serObj = new CmmsServerDll(CmmsServerDll.receivePort, CmmsServerDll.sendPort, CmmsServerDll.bufferSize, this.outPath);
                    Thread newClient = new Thread(serObj.SendDataInfoToClient);
                    newClient.Start(clientSock);
                }
                sendSock.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetAllFilesInfoInDirectories()
        {
            string[] filePaths = null;
            string _listFile = "";
            try
            {
                filePaths = Directory.GetFiles(_Path, "*", SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    if (_listFile == "")
                    {
                        string _tmp = filePaths[i].ToString();
                        _listFile = _tmp.Substring(_Path.Length, _tmp.Length - _Path.Length);
                    }
                    else {
                        string _tmp = filePaths[i].ToString();
                        _listFile = _listFile +";" + _tmp.Substring(_Path.Length, _tmp.Length - _Path.Length);
                    }
                }
            }
            catch { }

            return _listFile;
        }
        private void SendDataInfoToClient(object clientObject)
        {
            Socket clientSock = null;
            clientSock = (Socket)clientObject;
            try
            {

                byte[] receiveData = new byte[256];
                int recvLen = clientSock.Receive(receiveData);
                string s = Encoding.ASCII.GetString(receiveData);
                s = Encoding.ASCII.GetString(receiveData, 0, recvLen);
                if (s == "HDD")
                {

                    string sInfo = "";
                    sInfo = ReadSerialHDD();
                    Byte[] data = Encoding.ASCII.GetBytes(sInfo);
                    clientSock.Send(data);

                    clientSock.Shutdown(SocketShutdown.Both);
                    clientSock.Close();
                }
                else
                {
                    if (s == "INFO")
                    {
                        string sInfo = "";
                        sInfo = ReadVersionInfo();
                        Byte[] data = Encoding.ASCII.GetBytes(sInfo);
                        clientSock.Send(data);

                        clientSock.Shutdown(SocketShutdown.Both);
                        clientSock.Close();
                    }
                    else
                    {

                        if (s.Substring(0,2).ToUpper() == "FI")
                        {
                            string sInfo = "";
                            //sInfo = ReadVersionInfo();
                            FileInfo sInfoq = new FileInfo(_Path + s.Substring(2));
                            sInfo = sInfoq.CreationTime.ToString() + "|" +  sInfoq.LastWriteTime.ToString() + "|" + sInfoq.LastAccessTime.ToString();



                            Byte[] data = Encoding.ASCII.GetBytes(sInfo);
                            clientSock.Send(data);

                            clientSock.Shutdown(SocketShutdown.Both);
                            clientSock.Close();
                        }
                        else
                        {
                            if (recvLen == 2)
                            {
                                string filePaths = GetAllFilesInfoInDirectories();
                                byte[] clientInfoData = new byte[1000000];
                                clientInfoData = Encoding.ASCII.GetBytes(filePaths);
                                clientSock.Send(clientInfoData);

                                clientSock.Shutdown(SocketShutdown.Both);
                                clientSock.Close();
                            }
                            else
                            {
                                SendDataToClient(clientObject, Encoding.ASCII.GetString(receiveData, 0, recvLen));
                            }
                        }
                    }
                }
            }
            catch {
                Byte[] data = Encoding.ASCII.GetBytes("");
                clientSock.Send(data);
            }
        }

        private void SendDataToClient(object clientObject, string _file)
        {
            // Tao Socket cho Client.
            Socket clientSock = (Socket)clientObject;
            string newFileName = "";

            try
            {
                CmmsServerDll.status = "";
                CmmsServerDll.presentOperation = "";
                //clientSock = (Socket)clientObject;

                // Send thong tin cua File cho Client

                string onlyFileName, path;

                ////Select a File to transfer

                string fileNameWithPath = _Path +  _file;
                fileNameWithPath = fileNameWithPath.Replace("\\", "/");
                onlyFileName = fileNameWithPath;
                path = "";

                while (onlyFileName.IndexOf("/") != -1)
                {
                    path += onlyFileName.Substring(0, onlyFileName.IndexOf("/")) + "/";
                    onlyFileName = onlyFileName.Substring(onlyFileName.IndexOf("/") + 1);
                }
                newFileName = "#" + onlyFileName;

                string bothName = fileNameWithPath + "?" + path + "/" + newFileName;

                string oldFileName, bothFileName;
                bothFileName = bothName;
                oldFileName = bothFileName.Substring(0, bothFileName.IndexOf("?"));
                newFileName = bothFileName.Substring(bothFileName.IndexOf("?") + 1);

                string filePath = "", tempFileName = oldFileName;
                while (tempFileName.IndexOf("/") != -1)
                {
                    filePath += tempFileName.Substring(0, tempFileName.IndexOf("/") + 1);
                    tempFileName = tempFileName.Substring(tempFileName.IndexOf("/") + 1);
                }
                if (File.Exists(newFileName))
                    File.Delete(newFileName);

                File.Copy(oldFileName, newFileName, true);
                File.SetAttributes(newFileName, FileAttributes.Hidden);

                status = "";
                this.fileNameWithPath = newFileName;

                if (this.fileNameWithPath.Length == 0)
                    return;

                //this.fileNameWithPath = _Path + _file;// this.fileNameWithPath;

                byte[] fileNameByte = Encoding.ASCII.GetBytes(_file);
                byte[] fileData = File.ReadAllBytes(this.fileNameWithPath);
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];

                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes((4 + fileNameByte.Length + fileData.Length).ToString());
                clientSock.Send(clientInfoData);
                Send(clientSock, clientData, 0, clientData.Length, 10000);
                File.Delete(this.fileNameWithPath);
                clientSock.Shutdown(SocketShutdown.Both);
                clientSock.Close();

            }
            catch { }
        }

        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (sent < size);
        }



        public string[] GetAllFilesInDirectories()
        {
            string[] filePaths = null;
            try
            {
                //filePaths = Directory.GetFiles(@"E:\0812 TestData\send files\");
                filePaths =  Directory.GetFiles(_Path);
            }
            catch { }

            return filePaths;
        }

        private void SendAllDataToClient(object clientObject)
        {
            try
            {

                // Gui so luong file can gui toi Client.
                string[] filePaths = GetAllFilesInDirectories();
                Socket clientSock = null;
                clientSock = (Socket)clientObject;

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes(filePaths.Length.ToString());
                clientSock.Send(clientInfoData);
               
                // Bat dau gui tung file.

                string Status = "START";

                for (int i = 0; i < filePaths.Length; i++)
                {
                    while (Status != "END")
                    {
                       
                        if (Status == "START")
                        {
                           
                            Status = SendDataToClient(clientObject, filePaths[i].ToString(), clientSock);
                        }
                        
                    }
                    Status = "START";
                }

                clientSock.Shutdown(SocketShutdown.Both);
                clientSock.Close();

            }
            catch { }

        }
        private string SendDataToClient(object clientObject, string _file ,Socket _skClient )
        {
            // Tao Socket cho Client.
            Socket clientSock = _skClient;
            BinaryWriter bWriter = null;
            string newFileName = "";

            try
            {
                CmmsServerDll.status = "";
                CmmsServerDll.presentOperation = "";
                //clientSock = (Socket)clientObject;
               
                // Send thong tin cua File cho Client

                string onlyFileName, path;

                //Select a File to transfer

                string fileNameWithPath = _file;
                fileNameWithPath = fileNameWithPath.Replace("\\", "/");
                onlyFileName = fileNameWithPath;
                path = "";

                while (onlyFileName.IndexOf("/") != -1)
                {
                    path += onlyFileName.Substring(0, onlyFileName.IndexOf("/")) + "/";
                    onlyFileName = onlyFileName.Substring(onlyFileName.IndexOf("/") + 1);
                }
                newFileName = "#" + onlyFileName;

                string bothName = fileNameWithPath + "?" + path + "/" + newFileName;

                string oldFileName, bothFileName;
                bothFileName = bothName;
                oldFileName = bothFileName.Substring(0, bothFileName.IndexOf("?"));
                newFileName = bothFileName.Substring(bothFileName.IndexOf("?") + 1);

                string filePath = "", tempFileName = oldFileName;
                while (tempFileName.IndexOf("/") != -1)
                {
                    filePath += tempFileName.Substring(0, tempFileName.IndexOf("/") + 1);
                    tempFileName = tempFileName.Substring(tempFileName.IndexOf("/") + 1);
                }
                if (File.Exists(newFileName))
                    File.Delete(newFileName);

                File.Copy(oldFileName, newFileName, true);
                File.SetAttributes(newFileName, FileAttributes.Hidden);

                status = "";
                this.fileNameWithPath = newFileName;
               
                if (this.fileNameWithPath.Length == 0)
                    return null;

                this.fileNameWithPath = filePath + tempFileName;// this.fileNameWithPath;

                byte[] fileNameByte = Encoding.ASCII.GetBytes(tempFileName);
                byte[] fileData = File.ReadAllBytes(fileNameWithPath);
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];

                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes((4 + fileNameByte.Length + fileData.Length).ToString());
                clientSock.Send(clientInfoData);

                clientSock.Send(clientData);

                string _status = "";
                while (_status != "OK")
                {
                    try
                    {
                        byte[] receiveData = new byte[256];
                        int recvLen = clientSock.Receive(receiveData);
                        _status = Encoding.ASCII.GetString(receiveData, 0, recvLen);
                        if ( _status == "OK")
                        {
                            return "END";
                        }
                    }
                    catch { }
                }


                //clientSock.Shutdown(SocketShutdown.Both);
                //clientSock.Close();
             
            }
            catch { }

            return "END";
        }

        #endregion

        #region Stop Server
        //Stop Server H2
        public void StopServer()
        {
            //StopReceiveServer();
            StopSendServer();
        }
        private void StopSendServer()
        {
            currentStatus = "Stoped !...";
            CmmsServerDll.isServerRunning = false;
            //
            try
            {
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CmmsServerDll.sendPort);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                clientSock.Connect(ipEnd);

                string strData = "END";
                byte[] clientData = new byte[30];
                clientData = Encoding.ASCII.GetBytes(strData);
                clientSock.Send(clientData);

                //byte[] serverData = new byte[10];
                //int len = clientSock.Receive(serverData);
                //Console.WriteLine(Encoding.ASCII.GetString(serverData, 0, len));
                clientSock.Close();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            //
        }
        #endregion
        // end class
        public string ReadVersionInfo()
        {
            try
            {
                StreamReader sr = new StreamReader(_Path + "Version.txt");
                try
                {
                    String line;
                    line = sr.ReadLine();
                    sr.Close();
                    return line;
                }
                catch
                {
                    sr.Close();
                    return "";
                }
            }
            catch { return ""; }
        }

        public string ReadSerialHDD()
        {
            try
            {

                return Commons.Modules.ObjSystems.GetSerial();
            }
            catch { return "None"; }
        }


    }
}
