using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using eAquaServer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace eAquaServer
{
    class csProcessMessageFromClient
    {
        private Int16 myPort;
        private TcpClient myClient;
        private frmMain frmMain_1 = null;
        ListBox lisbox1 = new ListBox();
        String Stringdata, device = "Anonymox";
        public csProcessMessageFromClient(TcpClient client, Int16 port, frmMain MainFrm)
        {
            myClient = client;
            myPort = port;
            frmMain_1 = MainFrm;
        }
        public byte[] SerializeData(Object o)
	    {
            MemoryStream ms = new MemoryStream();
	        BinaryFormatter bf1 = new BinaryFormatter();
	        bf1.Serialize(ms, o);
	        return ms.ToArray();
	    }
        public void ReceiveData()
        {
            NetworkStream stream = new NetworkStream(myClient.Client);//khởi tạo luồng
            byte[] data = new byte[1024];//kích thước
            int receiv = 0;

                try
                {
                    receiv = myClient.Client.Receive(data);//nhận dữ liệu
                    Stringdata = Encoding.UTF8.GetString(data, 0, receiv).TrimEnd();//chuyển chuỗi dữ liệu
                    if (Stringdata=="")
                    {
                        myClient.Close();
                        return;
                    }
                    /////gửi dữ liệu xuống client
                    byte[] message = Encoding.UTF8.GetBytes("@OK");//dữ liệu
                    myClient.Client.Send(message);//lệnh gửi

                    string[] split_string = { "<", ">" };
                    frmMain_1.Displaylistview(Convert.ToString(myClient.Client.RemoteEndPoint) + " :" + Stringdata);
                    //////////////////////////////////////////////////////////////////////////////////////////////////
                    string[] aaa = Stringdata.Split(split_string, StringSplitOptions.RemoveEmptyEntries);
                    if (aaa.Count() == 3)
                    {
                        string bbb = aaa[0] + ";" + aaa[1];
                        //luu dia chi Ip cua thiet bi vao bang
                        //tach rieng cac client PLC rieng ra
                        if ((aaa[0] == "MeasurementResults") || (aaa[0]=="MeasuringSystem"))
                        {
                            bbb = bbb + "IP=" + Convert.ToString(myClient.Client.RemoteEndPoint) + ";";
                            frmMain_1.list_mess.Add(bbb);
                            frmMain_1.lst_PLCClient.Add(myClient);
                            
                        }
                        //them chuoi nhan duoc vao list de xu ly
                        //tach rieng cac client setup ra
                        else
                        {
                            //frmMain_1.lstClientMsgSetup.Add(bbb);
                            //frmMain_1.list_client_send_file.Add(myClient);
                            myClient.Close();
                        }
                    }
                    //truong hop cua phong co khoang trang cuoi
                    else if (aaa.Count() == 4)
                    {
                        string bbb = aaa[0] + ";" + aaa[1];
                        //luu dia chi Ip cua thiet bi vao bang
                        //tach rieng cac client PLC rieng ra
                        if (aaa[0] == "MeasurementResults")
                        {
                            bbb = bbb + "IP=" + Convert.ToString(myClient.Client.RemoteEndPoint) + ";";
                            frmMain_1.list_mess.Add(bbb);
                            frmMain_1.lst_PLCClient.Add(myClient);

                        }
                        //them chuoi nhan duoc vao list de xu ly
                        //tach rieng cac client setup ra
                        else
                        {
                            //frmMain_1.lstClientMsgSetup.Add(bbb);
                            //frmMain_1.list_client_send_file.Add(myClient);
                            myClient.Close();
                        }
                    }
                    else if (Stringdata.Substring(0, 7) == "TestDO;") //TestDO;DO=5.5;2015-12-01:11....
                    {
                        string[] buffst = Stringdata.Split(';');
                        if (buffst.Count() == 3)
                        {
                            //File.AppendAllText("LogDO.txt", buffst[1].ToString() + "\t" + buffst[2].ToString());
                            //File.AppendAllText("LogDO.txt", "\n\r");
                            StreamWriter sw = new StreamWriter("LogDO.txt", true);
                            sw.WriteLine(buffst[1].ToString() + "\t" + buffst[2].ToString());
                            //sw.WriteLine();
                            sw.Close();
                            myClient.Close();
                        }
                        else
                        {
                            myClient.Close();
                        }
                    }
                    else
                    {
                        //frmMain_1.Displaylistview(device + ": ERROR");
                        //File.AppendAllText("Log.txt", "Loi nhan khong du" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //gui lai bao loi neu chua nhan du
                        myClient.Close();
                    }

                }
                catch (Exception ex)
                {
                    //File.AppendAllText("Log.txt", "Loi nhan" + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    try
                    {
                        myClient.Close();
                    }
                    catch { };
                }
            }
            
        
    }
}
