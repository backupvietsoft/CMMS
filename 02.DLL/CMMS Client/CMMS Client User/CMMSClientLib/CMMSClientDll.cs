using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CMMSClientLib
{
    public class CMMSClientDll
    {
        Thread  startFileReceiveThread;
        //Thread  startHDDReceiveThread;
        public static string status = "", presentOperation = "", ipAddress, outPathDefault = "";
        string clientId = "";
        public static int progress = 0, portSend, portReceive;
        public string iPServer = "192.168.200.57";
        //int bufferSize;
        public static bool isSaveToDefaultPath = false;
        public string outPath = "E:/H/";
        public string currentStatus = "";
        public string FileNameCoping = "";
        public string FilePathInfoCoping = "";
        public int TotalFileNeedReceive = 0;
        public int FileCount = 0;
        public delegate void FileSendCompletedDelegate();
        public event FileSendCompletedDelegate FileReceiveCompleted, FileReceiveFile, CopyToPath, TotalFile, FileReceiveCount,ErrorMsg;

        public CMMSClientDll(string clientId, string ipAddress, int sendPort, int receivePort, string DefaultPath)
        {
            this.clientId = clientId;
            CMMSClientDll.ipAddress = ipAddress;
            CMMSClientDll.portSend = sendPort;
            CMMSClientDll.portReceive = receivePort;
            CMMSClientDll.outPathDefault = DefaultPath;
            //this.bufferSize = 10 * 1024;
        }
        /// <summary>
        /// Conestructor of Client Object
        /// </summary>
        /// <param name="ipAddress">IP Address of Server</param>
        /// <param name="outPathDefault">Path to store receive file temporary basis.</param>
        public CMMSClientDll(string clientId, string ipAddress, string DefaultPath)
        {
            try
            {
                this.clientId = clientId;
                outPathDefault = DefaultPath;
                CMMSClientDll.ipAddress = ipAddress;
                CMMSClientDll.portSend = 9050;
                CMMSClientDll.portReceive = 9051;
                //this.bufferSize = 10 * 1024;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReceiveFileFromServer(string onlyFileName)
        {
            try 
            {
            startFileReceiveThread = new Thread(this.ReceiveInfoFromServer);
                startFileReceiveThread.Start(onlyFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void ReceiveHDDSerialFromServer(string onlyFileName)
        //{
        //    startHDDReceiveThread = new Thread(this.ReceiveHDDFromServer);
        //    startHDDReceiveThread.Start(onlyFileName);
        //}


        //public string StatusThread
        //public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        public string ReceiveInfo(string IPSer)
        {
            try
            {
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(IPSer), CMMSClientDll.portReceive);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);

                Byte[] data = Encoding.ASCII.GetBytes("INFO");
                server.Send(data);

                string FileInfo = "";

                byte[] receiveData = new byte[100000];
                int recvLen = server.Receive(receiveData);

                FileInfo =Encoding.ASCII.GetString(receiveData, 0, recvLen);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                return FileInfo;
            }
            catch
            {
                return "";
            }
        }
        public string ReceiveHDDSerial(string IPSer)
        {
            try
            {
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);


                IPEndPoint ipEnad = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes("HDD");
                server.Send(clientInfoData);



                byte[] receiveData = new byte[100000];
                int recvLen = server.Receive(receiveData);

                string s = Encoding.ASCII.GetString(receiveData).Substring(0, recvLen);

                server.Shutdown(SocketShutdown.Both);
                server.Close();
                return s;
            }
            catch
            {
                return "";
            }
        }

        public string ReceiveFileInfo(string fileName)
        {
            try
            {
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);
                IPEndPoint ipEnad = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes("FI" + fileName);
                server.Send(clientInfoData);



                byte[] receiveData = new byte[100000];
                int recvLen = server.Receive(receiveData);

                string s = Encoding.ASCII.GetString(receiveData).Substring(0, recvLen);

                server.Shutdown(SocketShutdown.Both);
                server.Close();
                return s;
            }
            catch
            {
                return "";
            }
        }


        
        //public void ReceiveHDDFromServer(object _status)
        //{
        //    try
        //    {
        //        Socket server = null;
        //        IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);
        //        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        //        server.Connect(ipEnd);

        //        byte[] clientInfoData = new byte[256];
        //        clientInfoData = Encoding.ASCII.GetBytes("HDD");
        //        server.Send(clientInfoData);



        //        byte[] receiveData = new byte[100000];
        //        int recvLen = server.Receive(receiveData);

        //        string s = Encoding.ASCII.GetString(receiveData).Substring(0, recvLen);

        //        server.Shutdown(SocketShutdown.Both);
        //        server.Close();
        //        HDDSerial = s;

        //    }
        //    catch
        //    {
        //        ErrorMsg();
        //    }
        //}

        public void ReceiveInfoFromServer(object _status)
        {
            try
            {
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes("ST");
                server.Send(clientInfoData);

                
                string FileInfo = "";

                byte[] receiveData = new byte[100000];
                int recvLen = server.Receive(receiveData);

                string s = Encoding.ASCII.GetString(receiveData);

                FileInfo = Encoding.ASCII.GetString(receiveData, 0, recvLen);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                            
                string[] FileArray = null;
                FileArray = FileInfo.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                TotalFileNeedReceive = FileArray.Length;
                TotalFile();
                FilePathInfoCoping = outPath;
                CopyToPath();
               
                for (int i = 0; i < FileArray.Length; i++)
                {
                    FileNameCoping = "..." + FileArray[i].ToString();
                    FileReceiveFile();
                    FileCount = i;
                    FileReceiveCount();
                    ReceiveFilesFromServer(FileArray[i].ToString());
                    //startFileReceiveThread = new Thread(this.ReceiveFilesFromServer);
                    //startFileReceiveThread.Start(FileArray[i].ToString());
                }
                try
                {
                    ReceiveFilesFromServer("CMMS.exe");
                }
                catch { }
                FileReceiveCompleted();

            }
            catch {
                ErrorMsg();
            }
        }
        public void ReadAndWriteFolder(string _fileName)
        {
            try
            {
                _fileName = _fileName.Replace("#", "");
                _fileName = _fileName.Replace("...", "");
                string _tmpPath = "";
                string _tmpFileName = _fileName;
                while (_tmpFileName.IndexOf("\\") != -1)
                {
                    _tmpPath += _tmpFileName.Substring(0, _tmpFileName.IndexOf("\\")) + "/";
                    _tmpFileName = _tmpFileName.Substring(_tmpFileName.IndexOf("\\") + 1);
                }
                _tmpPath = _tmpPath.Trim().Substring(0,_tmpPath.Length -1);
                if (!Directory.Exists(outPath + _tmpPath ))
                {
                   Directory.CreateDirectory(outPath + _tmpPath);
                }
            }
            catch { }
        }
        
        public void ReceiveFilesFromServer(object onlyFileNameObj)
        {
            try
            {
                ReadAndWriteFolder(onlyFileNameObj.ToString());
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);
                status = "";
                string onlyFileName = onlyFileNameObj.ToString();
                onlyFileName = onlyFileName.Replace("#", "");
                onlyFileName = onlyFileName.Replace("...", "");

                //Send file can nhan cho Server.
                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes(onlyFileName);
                server.Send(clientInfoData);
                //Nhan file tu Server.
                byte[] receiveData = new byte[256];
                int recvLen = server.Receive(receiveData);
                int BuffLen = int.Parse(Encoding.ASCII.GetString(receiveData, 0, recvLen));
                byte[] data = new byte[BuffLen];
                //DATA FORMAT: [FILE SIZE LEN INFO[0-3]][FILE NAME LEN INFO[4-7]][FILE NAME DATA][FILE CONTENT]
                //int len = server.Receive(data, server.Available, SocketFlags.None);

                Receive(server, data, 0, data.Length, 10000);
                int len = data.Length;

                int fileNameLen_h = BitConverter.ToInt32(data, 0);
                string fileName_h = Encoding.ASCII.GetString(data, 4, fileNameLen_h);
                try
                {

                    if (File.Exists(outPath + onlyFileName))
                    {
                        File.Delete(outPath + onlyFileName);
                    }
                }
                catch { }

                try
                {
                    BinaryWriter bWrite = new BinaryWriter(File.Open(outPath + onlyFileName, FileMode.Append));
                    bWrite.Write(data, 4 + fileNameLen_h, len - 4 - fileNameLen_h);
                    bWrite.Flush();
                    bWrite.Close();
                }
                catch {
                    try
                    {
                        BinaryWriter bWrite = new BinaryWriter(File.Open(outPath + onlyFileName, FileMode.CreateNew));
                        bWrite.Write(data, 4 + fileNameLen_h, len - 4 - fileNameLen_h);
                        bWrite.Flush();
                        bWrite.Close();
                    }
                    catch { }
                }


                server.Shutdown(SocketShutdown.Both);
                server.Close();
                try
                {
                    string sStmp = ReceiveFileInfo(onlyFileName);
                    string[] chuoi_tach = sStmp.Split(new Char[] { '|' });

                    File.SetCreationTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach[0].ToString()));
                    File.SetLastWriteTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach[1].ToString()));
                    File.SetLastAccessTime(outPath + onlyFileName, Convert.ToDateTime(chuoi_tach[2].ToString()));
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably empty, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (received < size);
        }

        private void ReceiveTotalFilesFromServerByThread(object onlyFileNameObj)
        {
            try
            {
                Socket server = null;
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(iPServer), CMMSClientDll.portReceive);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Connect(ipEnd);
                
                byte[] receiveData = new byte[256];
                int recvLen = server.Receive(receiveData);

                string Status = "START";

                while (Status != "END")
                {
                  
                    if (Status == "START")
                    {
                        Status = "";
                        Status =  ReceiveFileFromServerByThread(onlyFileNameObj, server);     
                    }

                }

                server.Shutdown(SocketShutdown.Both);
                server.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string StatusThread(Socket _Clientob)
        {
            string _str = "WAIT";
            try
            {
                Socket server = _Clientob;
                byte[] receiveData = new byte[256];
                int recvLen = server.Receive(receiveData);
                _str =Encoding.ASCII.GetString(receiveData, 0, recvLen);

            }
            catch { }
            return _str;
        }
        
        private string ReceiveFileFromServerByThread(object onlyFileNameObj, Socket _Clientob)
        {
            try
            {
                Socket server = _Clientob;
                //BinaryWriter bWriter = null; ;
                //string rcvFileName = "", fileName = "";
                status = "";
                string onlyFileName = onlyFileNameObj.ToString();

                presentOperation = "Data Sending";
                byte[] receiveData = new byte[256];
                int recvLen = server.Receive(receiveData);

                int BuffLen = int.Parse(Encoding.ASCII.GetString(receiveData, 0, recvLen));

                byte[] data = new byte[BuffLen];
                int len = server.Receive(data);

                int fileNameLen_h = BitConverter.ToInt32(data, 0);
                string fileName_h = Encoding.ASCII.GetString(data, 4, fileNameLen_h);
                try
                {

                    if (File.Exists(outPath + fileName_h))
                    {
                        File.Delete(outPath + fileName_h);
                    }
                }
                catch { }
                BinaryWriter bWrite = new BinaryWriter(File.Open(outPath + fileName_h, FileMode.Append)); ;
                bWrite.Write(data, 4 + fileNameLen_h, len - 4 - fileNameLen_h);
                bWrite.Close();

                byte[] clientInfoData = new byte[256];
                clientInfoData = Encoding.ASCII.GetBytes("OK");
                server.Send(clientInfoData);

                return "START";
            }
            catch { }
            return "START";
        }
    }
}
