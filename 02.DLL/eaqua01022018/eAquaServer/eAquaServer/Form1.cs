using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace eAquaServer
{
    public partial class frmMain : Form
    {
        public ArrayList list_client = new ArrayList();
        public ArrayList lst_PLCClient = new ArrayList();
        public ArrayList lstClientMsgSetup = new ArrayList();
        public ArrayList list_client_send_file = new ArrayList();
        public ArrayList list_mess = new ArrayList();
        bool bt_connect = false, new_client = false;
        string name_client;
        TcpClient client, myClient, client_to_send;
        IPEndPoint serverEndPoint;
        IAsyncResult result;
        Thread thHandle, langnghe;
        TcpListener myTcpListener;
        public int count = 0;
        public Int16 port, stt_client = 0;

        public DataTable temp_1, data_message;
        public DataRow mess_row;
        public DataColumn column;
        //chuoi ket noi
        public string ConnectionString;
        public bool blExit = false;
        public bool respone_data = false;
        public string _ID, _CustomerLineID, _ContractCode, _BuyerCode, _Finish, _Bran, _Broken, _SmallBroken, _Paddy, _LineLotID, _DateTime, _WeightIn, _WeightOut, _Energy;
        //khai bao thong so hoat dong cua he thong
        public eAquaParameter.Customer tblCustomer = new eAquaParameter.Customer();

        private void lstViewSukien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

       

        public eAquaParameter.MeasurementPoint tblMeasurementPoint = new eAquaParameter.MeasurementPoint();
        public eAquaParameter.MeasurementResults tblMeasurementResults = new eAquaParameter.MeasurementResults();
        public eAquaParameter.MeasuringHead tblMeasuringHead = new eAquaParameter.MeasuringHead();
        public eAquaParameter.MeasuringSystem tblMeasuringSystem = new eAquaParameter.MeasuringSystem();
        public eAquaParameter.Ponds tblPonds = new eAquaParameter.Ponds();
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        //khai bao file ghi lich su lam viec
        //TextWriter txtlog = null;
        public frmMain()
        {
            InitializeComponent();
            DataTable VTB = new DataTable();//khởi tạo bảng.
            string sql = Application.StartupPath + "\\Connect.XML";//lấy đường dẫn file.
            VTB = new DataTable();
            sql = Application.StartupPath + "\\Connect.XML";//??? lấy lại đường dẫn file
            VTB.ReadXmlSchema(sql);
            sql = Application.StartupPath + "\\Connect1.XML";
            VTB.ReadXml(sql);
            if (VTB.Rows.Count > 0)
            //if (VTB.Rows[0]["SERVER"].ToString()=="SERVER03-PC")
            {
                /*if (VTB.Rows[0]["Instance"].ToString() != "")
                    ConnectionString = @"Data Source=" + VTB.Rows[0]["SERVER"].ToString() + "\\" + VTB.Rows[0]["Instance"].ToString() + ";Initial Catalog=" + VTB.Rows[0]["Database"].ToString() + ";User ID=" + VTB.Rows[0]["User"].ToString() + ";Pwd = " + VTB.Rows[0]["Pass"].ToString();
                else
                    ConnectionString = @"Data Source=" + VTB.Rows[0]["SERVER"].ToString() + ";Initial Catalog=" + VTB.Rows[0]["Database"].ToString() + ";User ID=" + VTB.Rows[0]["User"].ToString() + ";Pwd = " + VTB.Rows[0]["Pass"].ToString();
               */
                try
                {
                    ConnectionString = @"Data Source=" + VTB.Rows[0]["SERVER"].ToString() + ";Initial Catalog=" + VTB.Rows[0]["Database"].ToString() + ";User ID=" + VTB.Rows[0]["User"].ToString() + ";Pwd = " + VTB.Rows[0]["Pass"].ToString();
                    Displaylistview("ket noi thanh cong toi 14.161.37.163:...");
                }
                catch(ThreadAbortException)
                {
                    Displaylistview("ket noi khong thanh cong toi 14.161.37.163:...");
                    //tlLblMain.Text = "connect to IP 2";
                    /*  DataTable VTB = new DataTable();
                      string sql = Application.StartupPath + "\\Connect.XML";
                      VTB = new DataTable();
                      sql = Application.StartupPath + "\\Connect.XML";//??? lấy lại đường dẫn file
                      VTB.ReadXmlSchema(sql);
                      sql = Application.StartupPath + "\\Connect2.XML";
                      VTB.ReadXml(sql);
                      ConnectionString = @"Data Source=" + VTB.Rows[0]["SERVER"].ToString() + ";Initial Catalog=" + VTB.Rows[0]["Database"].ToString() + ";User ID=" + VTB.Rows[0]["User"].ToString() + ";Pwd = " + VTB.Rows[0]["Pass"].ToString();
                      Displaylistview("ket noi thanh cong toi ip connect2.xml...");
                      */
                }
                txtBoxPort.Text = VTB.Rows[0]["Port"].ToString();
            }
            //txtlog = new StreamWriter(Application.StartupPath + "\\log.txt");
            //khoi dong giao dien ban dau
            btnKetnoi.Visible = true;
            btnKetnoi.Enabled = true;
            btnNgatketnoi.Visible = false;
            btnNgatketnoi.Enabled = false;
            chkBoxChotudong.Checked = true;
            //tat bien exit
            blExit = false;
            //cho timer tu dong ket noi chay
            
            //cho timer xu ly du lieu chay
            tmrXulydulieu_1s.Enabled = true;
        }
        public delegate void DIDisplay(string s);
        //CAP NHAT TRANG THAI LEN GIAO DIEN
        public void Displaylistview(string s)
        {
            if (this.lstViewSukien.InvokeRequired)
            {
                DIDisplay sd = new DIDisplay(Displaylistview);

                this.Invoke(sd,new object[] { s });
            }
            else
            {
                lstViewSukien.Items.Add(s);
                string datetime = Convert.ToString(DateTime.Now);
                lstViewSukien.Items[count].SubItems.Add(datetime);
                //File.AppendAllText("Log.txt", s + " : " + datetime + Environment.NewLine);
                count += 1;
                if (count>200)
                {
                    lstViewSukien.Items.Clear();
                    count = 0;
                }
            }
        }
        public void threadListen()
        {
            Displaylistview("Listening for a client...");
            string ip = "192.168.1.8";
            //myTcpListener = new TcpListener(IPAddress.Any, port); //IPAddress.Any
            myTcpListener = new TcpListener(IPAddress.Parse(ip), port); //IPAddress.Any
            while (!blExit)
            {
                try
                {
                    //LANG NGHE KET NOI DEN
                    myTcpListener.Start();
                    myClient = myTcpListener.AcceptTcpClient();
                    //LAY DIA CHI THANG KET NOI DEN
                    string s = (Convert.ToString(myClient.Client.RemoteEndPoint));
                    string s1 = ((IPEndPoint)myClient.Client.RemoteEndPoint).Address.ToString();
                    //ghi ip clien len man hinh
                    tlLblMain.Text = "Connection from: " + s;
                    Displaylistview("Connection from: " + s);
                    //new_client = true;
                    //name_client = stt_client.ToString() + ":" + s;
                    //list_client.Insert(stt_client, myClient);
                    //stt_client++;
                    csProcessMessageFromClient Handle = new csProcessMessageFromClient(myClient, port, this);
                    thHandle = new Thread(new ThreadStart(Handle.ReceiveData));
                    thHandle.Start();
                }
                catch (ThreadAbortException)
                {
                    Displaylistview("Disconected");
                    tlLblMain.Text = "Disconected";
                    //File.AppendAllText("Log.txt", "Disconected" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex)
                {
                    tlLblMain.Text = "Lỗi trong qua trình chờ kết nối " + ex.ToString();
                    File.AppendAllText("Log.txt", "Lỗi trong qua trình chờ kết nối " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

            }
        }
        private void chkBoxChotudong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxChotudong.Checked == true)
            {
                btnKetnoi.Visible = false;
                btnKetnoi.Enabled = false;
            } 
            else
            {
                if (btnNgatketnoi.Enabled == false)
                {
                    btnKetnoi.Visible = true;
                    btnKetnoi.Enabled = true;
                }
                
            }
        }

        private void btnKetnoi_Click(object sender, EventArgs e)
        {
            if ((chkBoxChotudong.Checked == false) && (txtBoxPort.Text != ""))
            {
                //thuc hien qua trinh ket noi
                try
                {
                    port = Convert.ToInt16(txtBoxPort.Text);
                    if (MessageBox.Show("Port :" + port.ToString(), "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {

                        langnghe = new Thread(new ThreadStart(threadListen));
                        langnghe.Start();
                        //tai lai giao dien ket noi
                        btnNgatketnoi.Enabled = true;
                        btnNgatketnoi.Visible = true;
                        btnKetnoi.Enabled = false;
                        btnKetnoi.Visible = false;
                        txtBoxPort.Enabled = false;
                        tlLblMain.Text = "Kết nối!";
                        //File.AppendAllText("Log.txt", "Kết nối " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                }
                catch (Exception ex)
                {
                    tlLblMain.Text = "Kết nối lỗi" + ex.ToString();
                    //File.AppendAllText("Log.txt", "Kết nối lỗi" + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                
            }
        }

        private void btnNgatketnoi_Click(object sender, EventArgs e)
        {
            try
            {
                myTcpListener.Stop();
                bt_connect = false;
                btnKetnoi.Enabled = true;
                btnKetnoi.Visible = true;
                btnNgatketnoi.Enabled = false;
                btnNgatketnoi.Visible = false;
                txtBoxPort.Enabled = true;
                tlLblMain.Text = "Ngắt kết nối!";
                //File.AppendAllText("Log.txt", "Ngắt kết nối " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                tlLblMain.Text = "Ngắt kết nối lỗi" + ex.ToString();
                //File.AppendAllText("Log.txt", "Ngắt kết nối lỗi" + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        private void cbBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKiemtraSql_Click(object sender, EventArgs e)
        {
            try
            {
                temp_1 = new DataTable();
                string _temp0_ = "SELECT * FROM Customer";
                temp_1.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                if (temp_1.Rows.Count!=0)
                {
                    tlLblMain.Text = "Load dữ liệu thành công!";
                    //File.AppendAllText("Log.txt", "Kiểm tra load dữ liệu thành công" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    tlLblMain.Text = "Kiểm tra load nhưng không có dữ liệu!";
                    //File.AppendAllText("Log.txt", "Kiểm tra load nhưng không có dữ liệu" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            catch (Exception ex)
            {
                tlLblMain.Text = "Kiểm tra load không thành công!";
                //File.AppendAllText("Log.txt", "Kiểm tra load không thành công! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            } 
        }

        private void btnTrogiup_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                blExit = true;
                tlLblMain.Text = "Tắt chương trình!";
                //File.AppendAllText("Log.txt", "Tắt chương trình" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                Environment.Exit(0);
                Application.Exit();
            }
        }

        private void tmrXulydulieu_1s_Tick(object sender, EventArgs e)
        {
            if ((chkBoxChotudong.Checked==true) && (btnKetnoi.Enabled == false) && (txtBoxPort.Text != "")&&(btnNgatketnoi.Enabled == false))
            {
                try
                {
                    port = Convert.ToInt16(txtBoxPort.Text);
                    langnghe = new Thread(new ThreadStart(threadListen));
                    langnghe.Start();
                    btnNgatketnoi.Enabled = true;
                    btnNgatketnoi.Visible = true;
                    btnKetnoi.Enabled = false;
                    btnKetnoi.Visible = false;
                    txtBoxPort.Enabled = false;
                    tlLblMain.Text = "Kết nối!";
                    //File.AppendAllText("Log.txt", "Kết nối " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch(Exception ex)
                {
                    tlLblMain.Text = "Kết nối lỗi!";
                    File.AppendAllText("Log.txt", "Kết nối lỗi!Lỗi: "+ ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            //kiem tra so luong message cua cac PLC gui len
            int k = list_mess.Count;
            //neu khong co thi kiem tra so luong message cua cac may client setup gui len
            if (k == 0)
            {
                //Displaylistview("Khong co du lieu");
                int iMsgSetup = lstClientMsgSetup.Count;
                if (iMsgSetup == 0)
                    return;
                for (iMsgSetup = lstClientMsgSetup.Count - 1; iMsgSetup >= 0;iMsgSetup--)
                {
                    try
                    {
                        DataTable table_mess = new DataTable();
                        string[] split_string = { ";", "=" };
                        string msgFromclient = lstClientMsgSetup[iMsgSetup].ToString();
                        string[] messs = msgFromclient.Split(split_string, StringSplitOptions.RemoveEmptyEntries);
                        //kiem tra xem co phai la chuoi select all khong
                        if (messs.Count() == 3)
                        {
                            if (messs[2]== "Select")
                            {
                                try
                                {
                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                    string _temp0_ = "SELECT * From " + messs[0];
                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                    try
                                    {
                                        //lay client trong list client send file
                                        client_to_send = new TcpClient();
                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                        //gui bang di
                                        client_to_send.Client.Send(SerializeData(table_mess));
                                        client_to_send.Close();
                                    }
                                    catch (SocketException ex)
                                    {
                                        tlLblMain.Text = "Gửi bảng select all" + messs[0] + " xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Gửi bảng select all" + messs[0] + " xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    catch (System.Exception ex)
                                    {
                                        tlLblMain.Text = "Gửi bảng select all" + messs[0] + " xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Gửi bảng select all" + messs[0] + " xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    lstClientMsgSetup.RemoveAt(iMsgSetup);
                                    list_client_send_file.RemoveAt(iMsgSetup);
                                }
                                catch (System.Exception ex)
                                {
                                    tlLblMain.Text = "Truy xuất select all" + messs[0] + " xảy ra lỗi!";
                                    //File.AppendAllText("Log.txt", "Truy xuất select all" + messs[0] + " xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                        }
                        //neu khong thi xu ly them cac thong so khac nua
                        else
                        {
                            

                            if (messs[0] == "Customer")
                            {

                                int ii = messs[1].IndexOf("ID");
                                if (ii == 0) 
                                { 
                                    tblCustomer.ProcessDataFromClient(messs);
                                    //kiem tra xu ly ID. neu co thi lam tiep
                                    if (tblCustomer.ID != "")
                                    {
                                        //xu ly tac vu cmdQuery
                                        //neu command la delele thi xoa
                                        if (tblCustomer.cmdQuery == "Delete")
                                        {
                                            try
                                            {
                                                string _temp0_ = "DELETE From Customer where ID = " + tblCustomer.ID + " and Name = '" + tblCustomer.Name 
                                                                    + "' and Email = '" + tblCustomer.Email + "' and Password = '" + tblCustomer.Password + "'" ;
                                                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                _temp0_ = "SELECT * From Customer";
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất delete Customer xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất delete Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }

                                        }
                                        //neu command la seclect thi chon va gui lai
                                        else if (tblCustomer.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From Customer where ID = " + tblCustomer.ID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất Customer xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }

                                        }
                                        //neu khong co command thi cap nhat du lieu
                                        else
                                        {
                                            try
                                            {
                                                //ghi du lieu vao co so du lieu
                                                string _temp0_ = "SELECT * FROM Customer WHERE ID = " + tblCustomer.ID + "";
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                if (table_mess.Rows.Count > 0) //neu dulieu da co thi update
                                                {
                                                    _temp0_ = "UPDATE Customer SET Name= '" + tblCustomer.Name + "', Address = '" + tblCustomer.Address + "' , Manager = '" + tblCustomer.Manager 
                                                               + "' , HandPhone = '" + tblCustomer.HandPhone + "' , Province = '" + tblCustomer.Province + "' , Password = '" + tblCustomer.Password
                                                               + "' WHERE ID = " + tblCustomer.ID + " and Email = '" + tblCustomer.Email + "'" ;
                                                    //_temp0_ = "UPDATE LineLot SET CustomerLineID= '" + _CustomerLineID + "' AND BuyerID = '" + _BuyerID + "' WHERE ID = '" + _ID + "'";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                }
                                                else //neu dulieu chua co thi tao record moi
                                                {
                                                    //ghi du lieu vao co so du lieu
                                                    _temp0_ = "INSERT INTO Customer(ID,Name, Address, Manager, HandPhone, Province,Email,Password)" 
                                                            + " values(" + tblCustomer.ID + ",'" + tblCustomer.Name + "','" + tblCustomer.Address + "','" 
                                                            + tblCustomer.Manager + "','" + tblCustomer.HandPhone + "','" + tblCustomer.Province  + "','" + tblCustomer.Email + "','" + tblCustomer.Password + "')";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                }
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                _temp0_ = "SELECT * From Customer";
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Ghi dữ liệu Customer xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Ghi dữ liệu Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lstClientMsgSetup.RemoveAt(iMsgSetup);
                                        list_client_send_file.RemoveAt(iMsgSetup);
                                        tlLblMain.Text = "Xử lý ID Customer xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Xử lý ID Customer xảy ra lỗi!" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }

                                }
                                //truong hop khong co ID trong chuoi message gui len
                                else 
                                {
                                    tblCustomer.ProcessDataFromClient(messs);
                                    tblCustomer.ID = "";
                                    if ((tblCustomer.Name != ""))
                                    {
                                        if (tblCustomer.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                string _temp0_ = "" ;
                                                if (tblCustomer.Email != "")
                                                {
                                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                                    _temp0_ = "SELECT * From Customer where Name = '" + tblCustomer.Name + "' and Email = '" + tblCustomer.Email + "'" ;
                                                }
                                                else
                                                {
                                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                                    _temp0_ = "SELECT * From Customer where Name = '" + tblCustomer.Name + "'";
                                                }
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất Customer xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }

                                        }
                                        //neu khong co command thi ghi du lieu moi
                                        //truong hop nay mac dinh ghi du lieu
                                        else
                                        {
                                            try
                                            {
                                                if ((tblCustomer.Email != "") && (tblCustomer.Password != "") )
                                                {
                                                    //ghi du lieu vao co so du lieu
                                                    string _temp0_ = "INSERT INTO Customer(Name, Address, Manager, HandPhone, Province,Email,Password)" 
                                                                    + " values('" + tblCustomer.Name + "','" + tblCustomer.Address + "','" + tblCustomer.Manager + "','" 
                                                                    + tblCustomer.HandPhone + "','" + tblCustomer.Province + "','" + tblCustomer.Email + "','" + tblCustomer.Password + "')";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                                    _temp0_ = "SELECT * From Customer Where Name = '" + tblCustomer.Name + "' and Email = '" + tblCustomer.Email + "'";
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        //lay client trong list client send file
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        //gui bang di
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Ghi dữ liệu Customer xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Ghi dữ liệu Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                    //tat ca truong hop khong gui ve ten khach hang thi phai o che do cho xem khong duoc thay doi (only read)
                                    else
                                    {
                                        if (tblCustomer.HandPhone != "")
                                        {
                                            //truong hop tim theo so dien thoai
                                            if (tblCustomer.cmdQuery == "Select")
                                            {
                                                try
                                                {
                                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                                    string _temp0_ = "SELECT * From Customer where HandPhone = " + tblCustomer.HandPhone;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        //lay client trong list client send file
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        //gui bang di
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Customer xảy ra lỗi!"+ex;
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                    list_client_send_file.RemoveAt(iMsgSetup);
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Truy xuất Customer xảy ra lỗi!"+ex;
                                                    //File.AppendAllText("Log.txt", "Truy xuất Customer xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }

                                            }
                                        }
                                        else
                                        {
                                            lstClientMsgSetup.RemoveAt(iMsgSetup);
                                            list_client_send_file.RemoveAt(iMsgSetup);
                                            throw new ArgumentNullException(); 
                                        }
                                    }
                                }
                            }
                            else if (messs[0] == "MeasuringSystem")
                            {
                                //kiem tra chuoi co gui ID len khong
                                int ii = messs[1].IndexOf("ID");
                                if (ii == 0) 
                                { 
                                    tblMeasuringSystem.ProcessDataFromClient(messs);
                                    //kiem tra xem co xu ly ra duoc ID khong. neu co thi lam tiep
                                    if (tblMeasuringSystem.ID != "")
                                    {
                                        if (tblMeasuringSystem.cmdQuery == "Select")
                                        {

                                            try
                                            {
                                                //chon tat ca cac phan tu co cung CustomerID trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID ;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else if (tblMeasuringSystem.cmdQuery == "Delete")
                                        {
                                            try
                                            {
                                                if (tblMeasuringSystem.CustomerID != "")
                                                {
                                                    string _temp0_ = "DELETE From MeasuringSystem where ID = " + tblMeasuringSystem.ID + " and Name = '" + tblMeasuringSystem.Name + "' and CutomerID = " + tblMeasuringSystem.CustomerID;
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất delete MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất delete MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                //kiem tra CustomerID truoc khi tien hanh xu ly
                                                if (tblMeasuringSystem.CustomerID != "")
                                                {
                                                    string _temp0_ = "SELECT ID FROM MeasuringSystem WHERE ID = " + tblMeasuringSystem.ID + " and CustomerID = " + tblMeasuringSystem.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    if (table_mess.Rows.Count > 0) //neu dulieu da co thi update
                                                    {
                                                        _temp0_ = "UPDATE MeasuringSystem SET Name= '" + tblMeasuringSystem.Name + "', Note = '" + tblMeasuringSystem.Note + "' , PhoneNo = '" + tblMeasuringSystem.PhoneNo + "' , Cycle = " + tblMeasuringSystem.Cycle + " WHERE ID = " + tblMeasuringSystem.ID + " and CustomerID = " + tblMeasuringSystem.CustomerID ;
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    else
                                                    {
                                                        _temp0_ = "INSERT INTO MeasuringSystem(ID, Name, Note, CustomerID, PhoneNo,Cycle)" + " values(" + tblMeasuringSystem.ID + ",'" + tblMeasuringSystem.Name + "','" + tblMeasuringSystem.Note + "'," + tblMeasuringSystem.CustomerID + ",'" + tblMeasuringSystem.PhoneNo + "'," + tblMeasuringSystem.Cycle + ")";
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    //loc tat ca cac he thong cua khach hang
                                                    _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Ghi bảng MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Ghi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lstClientMsgSetup.RemoveAt(iMsgSetup);
                                        list_client_send_file.RemoveAt(iMsgSetup);
                                        tlLblMain.Text = "Xử lý ID MeasuringSystem xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Xử lý ID MeasuringSystem xảy ra lỗi!" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                }
                                //truong hop gui len ma khong co ID
                                //tien hanh xu ly cac truong hop loc va them phan tu moi vao bang
                                else 
                                {
                                    tblMeasuringSystem.ProcessDataFromClient(messs);
                                    tblMeasuringSystem.ID = "";
                                    if (tblMeasuringSystem.cmdQuery == "Select")
                                    {
                                        if (tblMeasuringSystem.CustomerID != "")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            lstClientMsgSetup.RemoveAt(iMsgSetup);
                                            list_client_send_file.RemoveAt(iMsgSetup);
                                            throw new ArgumentNullException();
                                        }
                                    }
                                    //xu ly truong hop them moi phan tu vao bang
                                    else
                                    {
                                        try
                                        {
                                            //kiem tra CustomerID truoc khi tien hanh xu ly
                                            if ((tblMeasuringSystem.CustomerID != "") && (tblMeasuringSystem.Name != "") && (tblMeasuringSystem.Cycle != "") )
                                            {
                                                //truong hop nay chi cho insert vao bang du co trung hay khong
                                                //truong hop muon update thi phai gui ID
                                                string _temp0_ = "INSERT INTO MeasuringSystem(Name, Note, CustomerID, PhoneNo,Cycle)" + " values('" + tblMeasuringSystem.Name + "','" + tblMeasuringSystem.Note + "'," + tblMeasuringSystem.CustomerID + ",'" + tblMeasuringSystem.PhoneNo + "'," + tblMeasuringSystem.Cycle + ")";
                                                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                //loc tat ca cac he thong cua khach hang
                                                _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                            }
                                            else
                                            {
                                                tlLblMain.Text = "Gửi message MeasuringSystem thiếu thông tin!";
                                                //File.AppendAllText("Log.txt", "Gửi message MeasuringSystem thiếu thông tin! " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                            lstClientMsgSetup.RemoveAt(iMsgSetup);
                                            list_client_send_file.RemoveAt(iMsgSetup);
                                        }
                                        catch (System.Exception ex)
                                        {
                                            tlLblMain.Text = "Ghi bảng MeasuringSystem xảy ra lỗi!";
                                            //File.AppendAllText("Log.txt", "Ghi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                    }
                                }
                            }
                            else if (messs[0] == "MeasuringHead")
                            {
                                //kiem tra chuoi co gui ID len khong
                                int ii = messs[1].IndexOf("ID");
                                if (ii == 0) 
                                { 
                                    tblMeasuringHead.ProcessDataFromClient(messs);
                                    if (tblMeasuringHead.ID != "")
                                    {
                                        if (tblMeasuringHead.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac dau do trong he thong
                                                string _temp0_ = "SELECT * From MeasuringHead where SystemID = " + tblMeasuringHead.SystemID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất MeasuringHead xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else if (tblMeasuringHead.cmdQuery == "Delete")
                                        {
                                            try
                                            {
                                                //kiem tra xem co gui len SystemID khong
                                                //neu co thi moi xoa duoc
                                                if (tblMeasuringHead.SystemID != "")
                                                {
                                                    string _temp0_ = "DELETE From MeasuringHead where ID = " + tblMeasuringHead.ID + " and Name = '" + tblMeasuringHead.Name + "' and SystemID = " + tblMeasuringHead.SystemID;
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    _temp0_ = "SELECT * From MeasuringHead";
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất delete MeasuringHead xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất delete MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            //kiem tra cac phan tu trong bang truoc khi thuc hien
                                            if ((tblMeasuringHead.Name != "") && (tblMeasuringHead.SystemID != "") )
                                            {
                                                try
                                                {
                                                    //kiem tra xem phan tu da co trong bang hay chua
                                                    string _temp0_ = "SELECT * FROM MeasuringHead WHERE ID = " + tblMeasuringHead.ID + " and SystemID = " + tblMeasuringHead.SystemID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    if (table_mess.Rows.Count > 0) //neu dulieu da co thi update
                                                    {
                                                        _temp0_ = "UPDATE MeasuringHead SET Name= '" + tblMeasuringHead.Name + "', Description = '" + tblMeasuringHead.Description + "'  WHERE ID = " + tblMeasuringHead.ID + " and SystemID = " + tblMeasuringHead.SystemID;
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    else
                                                    {
                                                        _temp0_ = "INSERT INTO MeasuringHead(Name, Description, SystemID)" + " values('" + tblMeasuringHead.Name + "','" + tblMeasuringHead.Description + "'," + tblMeasuringHead.SystemID + ")";
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    //lay cac dau do trong he thong
                                                    _temp0_ = "SELECT * From MeasuringHead where SystemID = " + tblMeasuringHead.SystemID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                    list_client_send_file.RemoveAt(iMsgSetup);
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Ghi dữ liệu bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Ghi dữ liệu bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                            }
                                                // neu cac phan tu thiet yeu trong bang thieu thi khong thuc hien cac tac vu
                                            else
                                            {
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                                tlLblMain.Text = "Dữ liệu bảng MeasuringHead gửi lên thiếu!";
                                                //File.AppendAllText("Log.txt", "Dữ liệu bảng MeasuringHead gửi lên thiếu! " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        lstClientMsgSetup.RemoveAt(iMsgSetup);
                                        list_client_send_file.RemoveAt(iMsgSetup);
                                        tlLblMain.Text = "Dữ liệu bảng MeasuringHead gửi lên thiếu!";
                                        //File.AppendAllText("Log.txt", "Dữ liệu bảng MeasuringHead gửi lên thiếu! " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                }
                                //xu ly truong hop khong gui Id len 
                                //luc do chi co 2 truong hop la loc va them moi phan tu
                                else 
                                { 
                                    tblMeasuringHead.ID = "";
                                    tblMeasuringHead.ProcessDataFromClient(messs);
                                    if (tblMeasuringHead.SystemID != "")
                                    {
                                        if (tblMeasuringHead.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From MeasuringHead where SystemID = " + tblMeasuringHead.SystemID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất MeasuringHead xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            if (tblMeasuringHead.Name != "")
                                            {
                                                try
                                                {
                                                    //Them phan tu moi vao bang
                                                    string _temp0_ = "INSERT INTO MeasuringHead(Name, Description, SystemID)" + " values('" + tblMeasuringHead.Name + "','" + tblMeasuringHead.Description + "'," + tblMeasuringHead.SystemID + ")";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    //lay cac dau do trong he thong
                                                    _temp0_ = "SELECT * From MeasuringHead where SystemID = " + tblMeasuringHead.SystemID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng MeasuringHead xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                    list_client_send_file.RemoveAt(iMsgSetup);
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Ghi dữ liệu bảng MeasuringHead xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Ghi dữ liệu bảng MeasuringHead xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                            }
                                            else
                                            {
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                                tlLblMain.Text = "Dữ liệu bảng MeasuringHead gửi lên thiếu!";
                                                //File.AppendAllText("Log.txt", "Dữ liệu bảng MeasuringHead gửi lên thiếu! " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lstClientMsgSetup.RemoveAt(iMsgSetup);
                                        list_client_send_file.RemoveAt(iMsgSetup);
                                        throw new ArgumentNullException(); 
                                    }
                                    
                                }
                                
                            }
                            else if (messs[0] == "Ponds")
                            {
                                //kiem tra chuoi co gui ID len khong
                                int ii = messs[1].IndexOf("ID");
                                if (ii == 0) 
                                {
                                    tblPonds.ProcessDataFromClient(messs);
                                    if (tblPonds.ID != "")
                                    {
                                        if (tblPonds.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu co cung customerID trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From Ponds where CustomerID = " + tblPonds.CustomerID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất Ponds xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else if (tblPonds.cmdQuery == "Delete")
                                        {
                                            try
                                            {
                                                if (tblPonds.CustomerID != "")
                                                {
                                                    string _temp0_ = "DELETE From Ponds where ID = " + tblPonds.ID + " and Name='" + tblPonds.Name + "' and CustomerID = " + tblPonds.CustomerID ;
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    _temp0_ = "SELECT * From Ponds";
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất delete Ponds xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất delete Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if ((tblPonds.CustomerID != "") && (tblPonds.Name != ""))
                                                {
                                                    string _temp0_ = "SELECT ID FROM Ponds WHERE ID = " + tblPonds.ID + " and CustomerID = " + tblPonds.CustomerID ;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    if (table_mess.Rows.Count > 0) //neu dulieu da co thi update
                                                    {
                                                        _temp0_ = "UPDATE Ponds SET Name= '" + tblPonds.Name + "', Description = '" + tblPonds.Description + "' WHERE ID = " + tblPonds.ID + " and CustomerID = " +tblPonds.CustomerID;
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    else
                                                    {
                                                        _temp0_ = "INSERT INTO Ponds(Name, Description, CustomerID)" + " values('" + tblPonds.Name + "','" + tblPonds.Description + "'," + tblPonds.CustomerID + ")";
                                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    }
                                                    _temp0_ = "SELECT * From Ponds WHERE CustomerID = " + tblPonds.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất ghi dữ liệu Ponds xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất ghi dữ liệu Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                }
                                //kiem tra xu ly cac chuoi select CustomerID
                                else 
                                {
                                    tblPonds.ID = "";
                                    tblPonds.ProcessDataFromClient(messs); 
                                    if (tblPonds.CustomerID != "")
                                    {
                                        if (tblPonds.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                if (tblPonds.CustomerID != "")
                                                {
                                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                                    string _temp0_ = "SELECT * From Ponds where CustomerID = " + tblPonds.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        //lay client trong list client send file
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        //gui bang di
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }
                                                
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất Ponds xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if ((tblPonds.CustomerID != "") && (tblPonds.Name != "") )
                                                {
                                                    string _temp0_ = "INSERT INTO Ponds(Name, Description, CustomerID)" + " values('" + tblPonds.Name + "','" + tblPonds.Description + "'," + tblPonds.CustomerID + ")";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                    _temp0_ = "SELECT * From Ponds WHERE CustomerID = " + tblPonds.CustomerID;
                                                    table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    try
                                                    {
                                                        client_to_send = new TcpClient();
                                                        client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                        client_to_send.Client.Send(SerializeData(table_mess));
                                                        client_to_send.Close();
                                                    }
                                                    catch (SocketException ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        tlLblMain.Text = "Gửi bảng Ponds xảy ra lỗi!";
                                                        //File.AppendAllText("Log.txt", "Gửi bảng Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    }
                                                }

                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất ghi dữ liệu Ponds xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất ghi dữ liệu Ponds xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lstClientMsgSetup.RemoveAt(iMsgSetup);
                                        list_client_send_file.RemoveAt(iMsgSetup);
                                        throw new ArgumentNullException();
                                    }
                                     
                                }
                            }
                            else if (messs[0] == "MeasurementPoint")
                            {
                                //kiem tra chuoi co gui ID len khong
                                int ii = messs[1].IndexOf("ID");
                                if (ii == 0)
                                {
                                    //kiem tra chuoi co gui ID len khong
                                    int iii = messs[messs.Count() - 1].IndexOf("MeasuringHeadID");
                                    if (iii == 0)
                                    {
                                        tblMeasurementPoint.ProcessDataFromClient(messs);
                                    }
                                    else { tblMeasurementPoint.ID = ""; throw new ArgumentNullException(); }
                                }
                                else { tblMeasurementPoint.ID = ""; throw new ArgumentNullException(); }
                                //kiem tra lai ID va MeasuringHeadID co xu ly duoc khong
                                if (tblMeasurementPoint.ID != "")
                                {
                                    if (tblMeasurementPoint.MesuringHeadID != "")
                                    {
                                        if (tblMeasurementPoint.cmdQuery == "Select")
                                        {
                                            try
                                            {
                                                //chon tat ca cac phan tu trong bang de gui lai cho client
                                                string _temp0_ = "SELECT * From MeasurementPoint where ID = " + tblMeasurementPoint.ID + " and MeasuringHeadID = " + tblMeasurementPoint.MesuringHeadID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    //lay client trong list client send file
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    //gui bang di
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất MeasurementPoint xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else if (tblMeasurementPoint.cmdQuery == "Delete")
                                        {
                                            try
                                            {
                                                string _temp0_ = "DELETE From MeasurementPoint where ID = " + tblMeasurementPoint.ID + " and MeasuringHeadID = " + tblMeasurementPoint.MesuringHeadID;
                                                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                _temp0_ = "SELECT * From MeasurementPoint";
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                   //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Truy xuất delete MeasurementPoint xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Truy xuất delete MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                string _temp0_ = "SELECT ID FROM MeasurementPoint WHERE ID = " + tblMeasurementPoint.ID + " and MeasuringHeadID = " + tblMeasurementPoint.MesuringHeadID;
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                if (table_mess.Rows.Count > 0) //neu dulieu da co thi update
                                                {
                                                    _temp0_ = "UPDATE MeasurementPoint SET Name = '" + tblMeasurementPoint.Name + "', Description = '" + tblMeasurementPoint.Description
                                                        + "' , UpperTemp = " + tblMeasurementPoint.UpperTemp + " , LowerTemp = " + tblMeasurementPoint.LowerTemp
                                                        + " , UpperPH = " + tblMeasurementPoint.UpperPH + " , LowerPH = " + tblMeasurementPoint.LowerPH
                                                        + " , UpperDO = " + tblMeasurementPoint.UpperDO + " , LowerDO = " + tblMeasurementPoint.LowerDO
                                                        + " , UpperNH3 = " + tblMeasurementPoint.UpperNH3 + " , LowerNH3 = " + tblMeasurementPoint.LowerNH3
                                                        + " , UpperNO2 = " + tblMeasurementPoint.UpperNO2 + " , LowerNO2 = " + tblMeasurementPoint.LowerNO2
                                                        + " , UpperSalinity = " + tblMeasurementPoint.UpperSalinity + " , LowerSalinity = " + tblMeasurementPoint.LowerSalinity
                                                        + " , PondsID = " + tblMeasurementPoint.PondsID + " , MesuringHeadID = " + tblMeasurementPoint.MesuringHeadID
                                                        + " WHERE ID = " + tblMeasurementPoint.ID + "";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                }
                                                else
                                                {
                                                    _temp0_ = "INSERT INTO MeasurementPoint(ID, Name, Description, UpperTemp,LowerTemp,UpperPH,LowerPH,UpperDO,LowerDO,UpperNH3,LowerNH3,UpperNO2,UpperNO2,UpperSalinity,LowerSalinity,PondsID,MesuringHeadID)"
                                                            + " values(" + tblMeasurementPoint.ID + ",'" + tblMeasurementPoint.Name + "','" + tblMeasurementPoint.Description + "'," + tblMeasurementPoint.UpperTemp + "," + tblMeasurementPoint.LowerTemp
                                                            + "," + tblMeasurementPoint.UpperPH + "," + tblMeasurementPoint.LowerPH + "," + tblMeasurementPoint.UpperDO + "," + tblMeasurementPoint.LowerDO
                                                            + "," + tblMeasurementPoint.UpperNH3 + "," + tblMeasurementPoint.LowerNH3 + "," + tblMeasurementPoint.UpperNO2 + "," + tblMeasurementPoint.LowerNO2
                                                            + "," + tblMeasurementPoint.UpperSalinity + "," + tblMeasurementPoint.LowerSalinity + "," + tblMeasurementPoint.PondsID + "," + tblMeasurementPoint.MesuringHeadID + ")";
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                }
                                                _temp0_ = "SELECT * From MeasurementPoint";
                                                table_mess.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)list_client_send_file[iMsgSetup];
                                                    client_to_send.Client.Send(SerializeData(table_mess));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasurementPoint xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                                list_client_send_file.RemoveAt(iMsgSetup);
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Ghi dữ liệu MeasurementPoint xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Ghi dữ liệu bảng MeasurementPoint xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                list_client_send_file.RemoveAt(iMsgSetup);
                            }
                        }
                        
                    }
                    catch
                    {
                        if (lstClientMsgSetup.Count != 0)
                        {
                            if (list_client_send_file.Count != 0)
                            {
                                lstClientMsgSetup.RemoveAt(iMsgSetup);
                                list_client_send_file.RemoveAt(iMsgSetup);
                            }
                        }
                        tlLblMain.Text = "Xử lý cắt chuỗi lỗi!";
                        //File.AppendAllText("Log.txt", "Xử lý cắt chuỗi lỗi!!" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
            }
    //////////neu co message cua PLC gui len thi tien hanh xu ly////
    //////////////////////////////////////////////////////////////
            else
            {
                for (k = list_mess.Count - 1; k >= 0; k--)
                {
                    try
                    {
                        DataTable table_mess1 = new DataTable();
                        string[] split_string1 = { ";", "=" };
                        string msgFromclient1 = list_mess[k].ToString();
                        string[] messs1 = msgFromclient1.Split(split_string1, StringSplitOptions.RemoveEmptyEntries);
                        //kiem tra xem co phai chuoi select all hay khong
                        if (messs1.Count() == 3)
                        {
                            if (messs1[2] == "Select")
                            {
                                try
                                {
                                    //chon tat ca cac phan tu trong bang de gui lai cho client
                                    string _temp0_ = "SELECT * From MeasurementResults";
                                    table_mess1.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                    try
                                    {
                                        //lay client trong list client send file
                                        client_to_send = new TcpClient();
                                        client_to_send = (TcpClient)lst_PLCClient[k];
                                        //gui bang di
                                        client_to_send.Client.Send(SerializeData(table_mess1));
                                        client_to_send.Close();
                                    }
                                    catch (SocketException ex)
                                    {
                                        tlLblMain.Text = "Gửi bảng MeasurementResults xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasurementResults xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    catch (System.Exception ex)
                                    {
                                        tlLblMain.Text = "Gửi bảng MeasurementResults xảy ra lỗi!";
                                        //File.AppendAllText("Log.txt", "Gửi bảng MeasurementResults xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    list_mess.RemoveAt(k);
                                    lst_PLCClient.RemoveAt(k);
                                }
                                catch (System.Exception ex)
                                {
                                    tlLblMain.Text = "Truy xuất MeasurementResults xảy ra lỗi!";
                                    //File.AppendAllText("Log.txt", "Truy xuất MeasurementResults xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                        }
                        if (messs1[0] == "MeasurementResults")
                        {
                             tblMeasurementResults.ProcessDataFromClient(messs1);
                             if (tblMeasurementResults.MeasuringTime != "" && tblMeasurementResults.MeasurementHeadID != "")
                             {
                                    try{
                                        string  _temp0_ = "INSERT INTO MeasurementResults(MeasuringTime, TempValue, pHValue,DOValue,NH3Value,NO2Value,SalinityValue,MeasuringHeadID)"
                                            + " values('" + tblMeasurementResults.MeasuringTime
                                            + "'," + tblMeasurementResults.TempValue 
                                            + "," + tblMeasurementResults.pHValue
                                            + "," + tblMeasurementResults.DOValue 
                                            + "," + tblMeasurementResults.NH3Value
                                            + "," + tblMeasurementResults.NO2Value 
                                            + "," + tblMeasurementResults.SalinityValue //+ "," + tblMeasurementResults.MeasurementPointID
                                            + "," + tblMeasurementResults.MeasurementHeadID 
                                            //+ ",'" + tblMeasurementResults.IpClient + "'," + tblMeasurementResults.Error
                                            //+ ",'" + tblMeasurementResults.Q11 + "'," + tblMeasurementResults.Q12
                                            //+ ",'" + tblMeasurementResults.Q13 + "'," + tblMeasurementResults.Q14
                                            //+ ",'" + tblMeasurementResults.Q21 + "'," + tblMeasurementResults.Q22
                                            //+ ",'" + tblMeasurementResults.Q23 + "'," + tblMeasurementResults.Q24
                                            //+ ",'" + tblMeasurementResults.QP1 + "'," + tblMeasurementResults.QP2
                                            //+ ",'" + tblMeasurementResults.QFS1 + "'," + tblMeasurementResults.QFS2
                                            //+ ",'" + tblMeasurementResults.QFB1 + "'," + tblMeasurementResults.QFB2
                                            + ")";
                                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                        list_mess.RemoveAt(k);
                                        lst_PLCClient.RemoveAt(k);
                                     }
                                    catch (System.Exception ex)
                                    {
                                        tlLblMain.Text = "Ghi dữ liệu vào bảng MeasurementResults lỗi!";
                                        //File.AppendAllText("Log.txt", "Ghi dữ liệu vào bảng MeasurementResults lỗi!Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                       
                                }
                                else 
                                {
                                    list_mess.RemoveAt(k);
                                    lst_PLCClient.RemoveAt(k);
                                    tblMeasurementResults.MeasuringTime = ""; 
                                    throw new ArgumentNullException(); 
                                }
                       
                            
                            
                        }
                        else if (messs1[0] == "MeasuringSystem")
                        {
                            //kiem tra chuoi co gui ID len khong
                            int ii = messs1[1].IndexOf("ID");
                            if (ii == 0)
                            {
                                tblMeasuringSystem.ProcessDataFromClient(messs1);
                                //kiem tra xem co xu ly ra duoc ID khong. neu co thi lam tiep
                                if (tblMeasuringSystem.ID != "")
                                {
                                    if (tblMeasuringSystem.cmdQuery == "Select")
                                    {

                                        try
                                        {
                                            //chon tat ca cac phan tu co cung CustomerID trong bang de gui lai cho client
                                            string _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                            table_mess1.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                            try
                                            {
                                                //lay client trong list client send file
                                                client_to_send = new TcpClient();
                                                client_to_send = (TcpClient)lst_PLCClient[k];
                                                //gui bang di
                                                client_to_send.Client.Send(SerializeData(table_mess1));
                                                client_to_send.Close();
                                            }
                                            catch (SocketException ex)
                                            {
                                                tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                            catch (System.Exception ex)
                                            {
                                                tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            }
                                            list_mess.RemoveAt(k);
                                            lst_PLCClient.RemoveAt(k);
                                        }
                                        catch (System.Exception ex)
                                        {
                                            tlLblMain.Text = "Truy xuất MeasuringSystem xảy ra lỗi!";
                                            //File.AppendAllText("Log.txt", "Truy xuất MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                    }
                                    else if (tblMeasuringSystem.cmdQuery == "Delete")
                                    {
                                        try
                                        {
                                            if (tblMeasuringSystem.CustomerID != "")
                                            {
                                                string _temp0_ = "DELETE From MeasuringSystem where ID = " + tblMeasuringSystem.ID + " and Name = '" + tblMeasuringSystem.Name + "' and CutomerID = " + tblMeasuringSystem.CustomerID;
                                                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                _temp0_ = "SELECT * From MeasuringSystem where CustomerID = " + tblMeasuringSystem.CustomerID;
                                                table_mess1.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                try
                                                {
                                                    client_to_send = new TcpClient();
                                                    client_to_send = (TcpClient)lst_PLCClient[k];
                                                    client_to_send.Client.Send(SerializeData(table_mess1));
                                                    client_to_send.Close();
                                                }
                                                catch (SocketException ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    tlLblMain.Text = "Gửi bảng MeasuringSystem xảy ra lỗi!";
                                                    //File.AppendAllText("Log.txt", "Gửi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                }
                                            }
                                            list_mess.RemoveAt(k);
                                            lst_PLCClient.RemoveAt(k);
                                        }
                                        catch (System.Exception ex)
                                        {
                                            tlLblMain.Text = "Truy xuất delete MeasuringSystem xảy ra lỗi!";
                                            //File.AppendAllText("Log.txt", "Truy xuất delete MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                    }
                                    //them du lieu IP va cycle vao bang
                                    else
                                    {
                                        try
                                        {
                                            //kiem tra CustomerID truoc khi tien hanh xu ly
                                            if (tblMeasuringSystem.CustomerID != "")
                                            {
                                                string _temp0_ = "SELECT ID FROM MeasuringSystem WHERE ID = " + tblMeasuringSystem.ID + " and CustomerID = " + tblMeasuringSystem.CustomerID;
                                                table_mess1.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                if (table_mess1.Rows.Count > 0) //neu dulieu da co thi update
                                                {
                                                    //doc so dau do cua he thong
                                                    _temp0_ = "SELECT Count(*) FROM MeasuringHead WHERE SystemID = " + tblMeasuringSystem.ID;
                                                    DataTable table_mess11 = new DataTable();
                                                    table_mess11.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, _temp0_));
                                                    if (tblMeasuringSystem.Cycle != "")
                                                    {
                                                        //tinh toan gia tri cycle = (so dau do * (thoi gian cai dat + 1))
                                                        int tempCycle = Convert.ToInt16(table_mess11.Rows[0][0].ToString()) * (Convert.ToInt16(tblMeasuringSystem.Cycle) + 1);
                                                        _temp0_ = "UPDATE MeasuringSystem SET IpPLC= '" + tblMeasuringSystem.IpPLC + "', Cycle = " + tempCycle.ToString()
                                                             + " WHERE ID = " + tblMeasuringSystem.ID + " and CustomerID = " + tblMeasuringSystem.CustomerID;
                                                    }
                                                    else
                                                    {
                                                        _temp0_ = "UPDATE MeasuringSystem SET IpPLC= '" + tblMeasuringSystem.IpPLC + "' WHERE ID = " + tblMeasuringSystem.ID + " and CustomerID = " + tblMeasuringSystem.CustomerID;
                                                    }
                                                    
                                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, _temp0_);
                                                }
                                            }

                                            list_mess.RemoveAt(k);
                                            lst_PLCClient.RemoveAt(k);
                                        }
                                        catch (System.Exception ex)
                                        {
                                            tlLblMain.Text = "Ghi bảng MeasuringSystem xảy ra lỗi!";
                                            //File.AppendAllText("Log.txt", "Ghi bảng MeasuringSystem xảy ra lỗi! Lỗi: " + ex.ToString() + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                    }
                                }
                                else
                                {
                                    list_mess.RemoveAt(k);
                                    lst_PLCClient.RemoveAt(k);
                                    tlLblMain.Text = "Xử lý ID MeasuringSystem xảy ra lỗi!";
                                    //File.AppendAllText("Log.txt", "Xử lý ID MeasuringSystem xảy ra lỗi!" + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                        }
                        else
                        {
                            list_mess.RemoveAt(k);
                            lst_PLCClient.RemoveAt(k);
                        }
                    }
                    catch
                    {
                        if (list_mess.Count != 0)
                        {
                            if (lst_PLCClient.Count!=0)
                            {
                                list_mess.RemoveAt(k);
                                lst_PLCClient.RemoveAt(k);
                            }
                        }
                        tlLblMain.Text = "Xử lý chuỗi message MeasurementResults lỗi!";
                        //File.AppendAllText("Log.txt", "Xử lý chuỗi message MeasurementResults lỗi! " + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
            }
            
        }

        private void txtBoxPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
