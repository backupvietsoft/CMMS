using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Xml.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;

namespace ReportMain
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {

        public XtraForm1()
        {
            InitializeComponent();
            ///*Check*/();
            //Thread thdUDPServer = new Thread(new ThreadStart(Server));
            //thdUDPServer.Start();
            //checkedComboBoxEdit1.Properties.DataSource


        }

        #region "KhaiBao"

        static readonly string[] VNI_char = {"O\u00C2", "o\u00E2", "y\u00F5", "Y\u00D5", "y\u00FB", "Y\u00DB",
                        "y\u00F8", "Y\u00D8", "\u00F6\u00EF", "\u00D6\u00CF", "\u00F6\u00F5", "\u00D6\u00D5",
                        "\u00F6\u00FB", "\u00D6\u00DB", "\u00F6\u00F8", "\u00D6\u00D8", "\u00F6\u00F9",
                        "\u00D6\u00D9", "u\u00FB", "U\u00DB", "u\u00EF", "U\u00CF", "\u00F4\u00EF", "\u00D4\u00CF",
                        "\u00F4\u00F5", "\u00D4\u00D5", "\u00F4\u00FB", "\u00D4\u00DB", "\u00F4\u00F8",
                        "\u00D4\u00D8", "\u00F4\u00F9", "\u00D4\u00D9", "o\u00E4", "O\u00C4", "o\u00E3", "O\u00C3",
                        "o\u00E5", "O\u00C5", "o\u00E0", "O\u00C0", "o\u00E1", "O\u00C1", "o\u00FB", "O\u00DB",
                        "o\u00EF", "O\u00CF", "e\u00E4", "E\u00C4", "e\u00E3", "E\u00C3", "e\u00E5", "E\u00C5",
                        "e\u00E0", "E\u00C0", "e\u00E1", "E\u00C1", "e\u00F5", "E\u00D5", "e\u00FB", "E\u00DB",
                        "e\u00EF", "E\u00CF", "a\u00EB", "A\u00CB", "a\u00FC", "A\u00DC", "a\u00FA", "A\u00DA",
                        "a\u00E8", "A\u00C8", "a\u00E9", "A\u00C9", "a\u00E4", "A\u00C4", "a\u00E3", "A\u00C3",
                        "a\u00E5", "A\u00C5", "a\u00E0", "A\u00C0", "a\u00E1", "A\u00C1", "a\u00FB", "A\u00DB",
                        "a\u00EF", "A\u00CF", "u\u00F5", "U\u00D5", "a\u00EA", "A\u00CA", "y\u00F9", "u\u00F9",
                        "u\u00F8", "o\u00F5", "o\u00F9", "o\u00F8", "e\u00E2", "e\u00F9", "e\u00F8", "a\u00F5",
                        "a\u00E2", "a\u00F9", "a\u00F8", "Y\u00D9", "U\u00D9", "U\u00D8", "O\u00D5", "O\u00D9",
                        "O\u00D8", "E\u00C2", "E\u00D9", "E\u00D8", "A\u00D5", "A\u00C2", "A\u00D9", "A\u00D8"};

        static readonly string[] Unicode_char = {"\u00C6", "\u00E6", "\u1EF9", "\u1EF8", "\u1EF7", "\u1EF6",
                        "\u1EF3", "\u1EF2", "\u1EF1", "\u1EF0", "\u1EEF", "\u1EEE", "\u1EED", "\u1EEC", "\u1EEB",
                        "\u1EEA", "\u1EE9", "\u1EE8", "\u1EE7", "\u1EE6", "\u1EE5", "\u1EE4", "\u1EE3", "\u1EE2",
                        "\u1EE1", "\u1EE0", "\u1EDF", "\u1EDE", "\u1EDD", "\u1EDC", "\u1EDB", "\u1EDA", "\u1ED9",
                        "\u1ED8", "\u1ED7", "\u1ED6", "\u1ED5", "\u1ED4", "\u1ED3", "\u1ED2", "\u1ED1", "\u1ED0",
                        "\u1ECF", "\u1ECE", "\u1ECD", "\u1ECC", "\u1EC7", "\u1EC6", "\u1EC5", "\u1EC4", "\u1EC3",
                        "\u1EC2", "\u1EC1", "\u1EC0", "\u1EBF", "\u1EBE", "\u1EBD", "\u1EBC", "\u1EBB", "\u1EBA",
                        "\u1EB9", "\u1EB8", "\u1EB7", "\u1EB6", "\u1EB5", "\u1EB4", "\u1EB3", "\u1EB2", "\u1EB1",
                        "\u1EB0", "\u1EAF", "\u1EAE", "\u1EAD", "\u1EAC", "\u1EAB", "\u1EAA", "\u1EA9", "\u1EA8",
                        "\u1EA7", "\u1EA6", "\u1EA5", "\u1EA4", "\u1EA3", "\u1EA2", "\u1EA1", "\u1EA0", "\u0169",
                        "\u0168", "\u0103", "\u0102", "\u00FD", "\u00FA", "\u00F9", "\u00F5", "\u00F3", "\u00F2",
                        "\u00EA", "\u00E9", "\u00E8", "\u00E3", "\u00E2", "\u00E1", "\u00E0", "\u00DD", "\u00DA",
                        "\u00D9", "\u00D5", "\u00D3", "\u00D2", "\u00CA", "\u00C9", "\u00C8", "\u00C3", "\u00C2",
                        "\u00C1", "\u00C0"};
        #endregion

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            //LicNumberWeb();
            UAC.ucNhapXuatTon myUc = new UAC.ucNhapXuatTon();
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            Commons.Modules.ObjSystems.ThayDoiNNNew(this);

            //byte[] s = Encoding.ASCII.GetBytes(CheckHDD() + "!" + LicNumberWeb());
        }

        private string LicNumberWeb()
        {
            try
            {
                XDocument document = XDocument.Load(@"C:\Program Files (x86)\VietSoft\Server Tool" + "\\config.xml");
                var LICLIMIT = from r in document.Descendants("VietsoftCMMS")
                               select r.Element("LW").Value;
                string sXML = "";
                foreach (var r in LICLIMIT)
                {
                    sXML = r.ToString();
                }
                sXML = Decrypt(sXML, true);

                string[] sArr = sXML.Split('|');
                return sArr[0] + "!" + sArr[1];
            }
            catch
            {
                //eventLog1.WriteEntry("LicNumber error : " + ex.Message);
                return "Demo!0";
            }

        }

        private string CheckHDD()
        {
            try
            {
                string sHDD = "aaaaa";


                XDocument document = XDocument.Load(@"C:\Program Files (x86)\VietSoft\Server Tool" + "\\config.xml");
                var LKEY = from r in document.Descendants("VietsoftCMMS")
                           select r.Element("LKEY").Value;
                string sXML = "";
                string sDNgay = "";

                foreach (var r in LKEY)
                {
                    sXML = r.ToString();
                }
                sXML = Decrypt(sXML, true);
                sXML = sXML.Substring(2);
                sDNgay = sXML;
                sXML = sXML.Substring(0, sXML.Length - 10);
                sDNgay = sDNgay.Substring(sHDD.Length, sDNgay.Length - sHDD.Length - 2);

                if (sXML == sHDD) return "TRUE!" + sDNgay; else return "FALSE!" + sDNgay;

            }
            catch
            {
                return "FALSE!19000101";
            }

        }

        private string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                string SecurityKey = "vietsoft.com.vn";
                string chuoi = "_13579_";
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = SecurityKey;//(string)settingsReader.GetValue("SecurityKey", typeof(String));

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                //return UTF8Encoding.UTF8.GetString(byteData).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
                return Convert.ToBase64String(byteData);
            }
        }



        private void Server()
        {

            //TcpListener tcpListener = new TcpListener(IPAddress.Parse(Commons.IConnections.Server), 8080);
            TcpListener server = new TcpListener(IPAddress.Parse(Commons.IConnections.Server), Convert.ToInt32(8080));
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
                Console.WriteLine("Server started...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            };

            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivetBuffer = new byte[100];
                NetworkStream stream = client.GetStream();
                stream.Read(receivetBuffer, 0, receivetBuffer.Length);
                StringBuilder msg = new StringBuilder();
                foreach (byte b in receivetBuffer)
                {
                    if (b.Equals(59))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }
                ////Resive message :
                if (msg.ToString() == "HI")
                {
                    ///@EDIT 1
                    ///// HERE Is SENDING  MESSAGE TO CLIENT//////////  
                    int byteCount = Encoding.ASCII.GetByteCount("You said HI" + 1);
                    byte[] sendData = new byte[byteCount];
                    sendData = Encoding.ASCII.GetBytes("You said HI" + ";");
                    stream.Write(sendData, 0, sendData.Length);
                }

            }

        }
    }
}   
        //private void Check()
        //{

        //    string SERVER_IP = Commons.IConnections.Server;
        //    int PORT_NO = 8080;
        //    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
        //    TcpListener listener = new TcpListener(localAdd, PORT_NO);
        //    //eventLog1.WriteEntry("Listening...");


        //    listener.Start();
        //    while (true)
        //    {
        //        //---incoming client connected---
        //        TcpClient client = listener.AcceptTcpClient();

        //        //---get the incoming data through a network stream---
        //        NetworkStream nwStream = client.GetStream();
        //        byte[] buffer = new byte[client.ReceiveBufferSize];

        //        //---read incoming stream---
        //        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        //        //---convert the data received into a string---
        //        string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        //        Console.WriteLine("Received : " + dataReceived);

        //        //IF YOU WANT TO WRITE BACK TO CLIENT USE
        //        string yourmessage = "ssssssss";
        //        Byte[] sendBytes = Encoding.ASCII.GetBytes(yourmessage);
        //        //---write back the text to the client---
        //        //eventLog1.WriteEntry("Sending back : " + yourmessage);
        //        nwStream.Write(sendBytes, 0, sendBytes.Length);
        //        client.Close();
        //    }
        //    listener.Stop();
        //}

        //public string ConvertVni2Uni(string str)
        //{
        //    StringBuilder strB = new StringBuilder(str);
        //    string[] Unicode_char = { "à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", 
        //                                "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể", "ễ", "ệ", 
        //                                "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ô", "ồ", "ố", "ổ", "ỗ", "ộ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ", 
        //                                "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự", "ỳ", "ý", "ỷ", "ỹ", "ỵ", 
        //                                "À", "Á", "Ả", "Ã", "Ạ", "Ă", "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ", "Â", "Ầ", "Ấ", "Ẩ", "Ẫ", 
        //                                "Đ", "È", "É", "Ẻ", "Ẽ", "Ẹ", "Ê", "Ề", "Ế", "Ể", "Ễ", "Ệ", 
        //                                "Ì","Í", "Ỉ", "Ĩ", "Ị", "Ò", "Ó", "Ỏ", "Õ", "Ọ", "Ô", "Ồ", "Ố", "Ổ", "Ỗ", "Ộ", "Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ", 
        //                                "Ù", "Ú", "Ủ", "Ũ", "Ụ", "Ư", "Ừ", "Ứ", "Ử", "Ữ", "Ự", "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"
        //                            };


        //    string[] VNI_char = { "aø", "aù", "aû", "aõ", "aï", "aê", "aè", "aé", "aú", "aü", "aë", "aâ", "aà", "aá", "aå", "aã", "aä", 
        //                                "ñ", "eø", "eù", "eû", "eõ", "eï", "eâ", "eà", "eá", "eå", "eã", "eä", 
        //                                "ì", "í", "æ", "ó", "ò", "oø", "où", "oû", "oõ", "oï", "oâ", "oà", "oá", "oå", "oã", "oä", "ô", "ôø", "ôù", "ôû", "ôõ", "ôï", 
        //                                "uø", "uù", "uû", "uõ", "uï", "ö", "öø", "öù", "öû", "öõ", "öï", "yø", "yù", "yû", "yõ", "î", 
        //                                "AØ", "AÙ", "AÛ", "AÕ", "AÏ", "AÊ", "AÈ", "AÉ", "AÚ", "AÜ", "AË", "AÂ", "AÀ", "AÁ", "AÅ", "AÃ", 
        //                                "Ñ", "EØ", "EÙ", "EÛ", "EÕ", "EÏ", "EÂ", "EÀ", "EÁ", "EÅ", "EÃ", "EÄ", 
        //                                "Ì","Í", "Æ", "Ó", "Ò", "OØ", "OÙ", "OÛ", "OÕ", "OÏ", "OÂ", "OÀ", "OÁ", "OÅ", "OÃ", "OÄ", "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        //                                "UØ", "UÙ", "UÛ", "UÕ", "UÏ", "Ö", "ÖØ", "ÖÙ", "ÖÛ", "ÖÕ", "ÖÏ", "YØ", "YÙ", "YÛ", "YÕ", "Î" };


        //    //string[] VNI_char = {"O\u00C2", "o\u00E2", "y\u00F5", "Y\u00D5", "y\u00FB", "Y\u00DB",
        //    //            "y\u00F8", "Y\u00D8", "\u00F6\u00EF", "\u00D6\u00CF", "\u00F6\u00F5", "\u00D6\u00D5",
        //    //            "\u00F6\u00FB", "\u00D6\u00DB", "\u00F6\u00F8", "\u00D6\u00D8", "\u00F6\u00F9",
        //    //            "\u00D6\u00D9", "u\u00FB", "U\u00DB", "u\u00EF", "U\u00CF", "\u00F4\u00EF", "\u00D4\u00CF",
        //    //            "\u00F4\u00F5", "\u00D4\u00D5", "\u00F4\u00FB", "\u00D4\u00DB", "\u00F4\u00F8",
        //    //            "\u00D4\u00D8", "\u00F4\u00F9", "\u00D4\u00D9", "o\u00E4", "O\u00C4", "o\u00E3", "O\u00C3",
        //    //            "o\u00E5", "O\u00C5", "o\u00E0", "O\u00C0", "o\u00E1", "O\u00C1", "o\u00FB", "O\u00DB",
        //    //            "o\u00EF", "O\u00CF", "e\u00E4", "E\u00C4", "e\u00E3", "E\u00C3", "e\u00E5", "E\u00C5",
        //    //            "e\u00E0", "E\u00C0", "e\u00E1", "E\u00C1", "e\u00F5", "E\u00D5", "e\u00FB", "E\u00DB",
        //    //            "e\u00EF", "E\u00CF", "a\u00EB", "A\u00CB", "a\u00FC", "A\u00DC", "a\u00FA", "A\u00DA",
        //    //            "a\u00E8", "A\u00C8", "a\u00E9", "A\u00C9", "a\u00E4", "A\u00C4", "a\u00E3", "A\u00C3",
        //    //            "a\u00E5", "A\u00C5", "a\u00E0", "A\u00C0", "a\u00E1", "A\u00C1", "a\u00FB", "A\u00DB",
        //    //            "a\u00EF", "A\u00CF", "u\u00F5", "U\u00D5", "a\u00EA", "A\u00CA", "y\u00F9", "u\u00F9",
        //    //            "u\u00F8", "o\u00F5", "o\u00F9", "o\u00F8", "e\u00E2", "e\u00F9", "e\u00F8", "a\u00F5",
        //    //            "a\u00E2", "a\u00F9", "a\u00F8", "Y\u00D9", "U\u00D9", "U\u00D8", "O\u00D5", "O\u00D9",
        //    //            "O\u00D8", "E\u00C2", "E\u00D9", "E\u00D8", "A\u00D5", "A\u00C2", "A\u00D9", "A\u00D8"};

        //    //string[] Unicode_char = {"\u00C6", "\u00E6", "\u1EF9", "\u1EF8", "\u1EF7", "\u1EF6",
        //    //            "\u1EF3", "\u1EF2", "\u1EF1", "\u1EF0", "\u1EEF", "\u1EEE", "\u1EED", "\u1EEC", "\u1EEB",
        //    //            "\u1EEA", "\u1EE9", "\u1EE8", "\u1EE7", "\u1EE6", "\u1EE5", "\u1EE4", "\u1EE3", "\u1EE2",
        //    //            "\u1EE1", "\u1EE0", "\u1EDF", "\u1EDE", "\u1EDD", "\u1EDC", "\u1EDB", "\u1EDA", "\u1ED9",
        //    //            "\u1ED8", "\u1ED7", "\u1ED6", "\u1ED5", "\u1ED4", "\u1ED3", "\u1ED2", "\u1ED1", "\u1ED0",
        //    //            "\u1ECF", "\u1ECE", "\u1ECD", "\u1ECC", "\u1EC7", "\u1EC6", "\u1EC5", "\u1EC4", "\u1EC3",
        //    //            "\u1EC2", "\u1EC1", "\u1EC0", "\u1EBF", "\u1EBE", "\u1EBD", "\u1EBC", "\u1EBB", "\u1EBA",
        //    //            "\u1EB9", "\u1EB8", "\u1EB7", "\u1EB6", "\u1EB5", "\u1EB4", "\u1EB3", "\u1EB2", "\u1EB1",
        //    //            "\u1EB0", "\u1EAF", "\u1EAE", "\u1EAD", "\u1EAC", "\u1EAB", "\u1EAA", "\u1EA9", "\u1EA8",
        //    //            "\u1EA7", "\u1EA6", "\u1EA5", "\u1EA4", "\u1EA3", "\u1EA2", "\u1EA1", "\u1EA0", "\u0169",
        //    //            "\u0168", "\u0103", "\u0102", "\u00FD", "\u00FA", "\u00F9", "\u00F5", "\u00F3", "\u00F2",
        //    //            "\u00EA", "\u00E9", "\u00E8", "\u00E3", "\u00E2", "\u00E1", "\u00E0", "\u00DD", "\u00DA",
        //    //            "\u00D9", "\u00D5", "\u00D3", "\u00D2", "\u00CA", "\u00C9", "\u00C8", "\u00C3", "\u00C2",
        //    //            "\u00C1", "\u00C0"};

        //    //// Part 1
        //    //strB.Replace('\u00D1', '\u0110'); // DD
        //    //strB.Replace('\u00F1', '\u0111'); // dd
        //    //strB.Replace('\u00D3', '\u0128'); // I~
        //    //strB.Replace('\u00F3', '\u0129'); // i~
        //    //strB.Replace('\u00D2', '\u1ECA'); // I.
        //    //strB.Replace('\u00F2', '\u1ECB'); // i.
        //    //strB.Replace('\u00C6', '\u1EC8'); // I?
        //    //strB.Replace('\u00E6', '\u1EC9'); // i?
        //    //strB.Replace('\u00CE', '\u1EF4'); // Y.
        //    //strB.Replace('\u00EE', '\u1EF5'); // y.

        //    // Part 2
        //    // Transform "O\u00C2" -> "\u00C6" to later transform back to "\u00D4" in Part 3
        //    for (int i = 0; i < VNI_char.Length; i++)
        //    {
        //        strB.Replace(VNI_char[i], Unicode_char[i]);
        //    }

        //    // Part 3
        //    //strB.Replace('\u00D4', '\u01A0'); // O+
        //    //strB.Replace('\u00F4', '\u01A1'); // o+
        //    //strB.Replace('\u00D6', '\u01AF'); // U+
        //    //strB.Replace('\u00F6', '\u01B0'); // u+
        //    //strB.Replace('\u00C6', '\u00D4'); // O^
        //    //strB.Replace('\u00E6', '\u00F4'); // o^

        //    return strB.ToString();
        //}


        //public string ConvertUni2Vni(string str)
        //{
        //    string[] Unicode_char = { "à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", 
        //                                "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể", "ễ", "ệ", 
        //                                "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ô", "ồ", "ố", "ổ", "ỗ", "ộ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ", 
        //                                "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự", "ỳ", "ý", "ỷ", "ỹ", "ỵ", 
        //                                "À", "Á", "Ả", "Ã", "Ạ", "Ă", "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ", "Â", "Ầ", "Ấ", "Ẩ", "Ẫ", 
        //                                "Đ", "È", "É", "Ẻ", "Ẽ", "Ẹ", "Ê", "Ề", "Ế", "Ể", "Ễ", "Ệ", 
        //                                "Ì","Í", "Ỉ", "Ĩ", "Ị", "Ò", "Ó", "Ỏ", "Õ", "Ọ", "Ô", "Ồ", "Ố", "Ổ", "Ỗ", "Ộ", "Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ", 
        //                                "Ù", "Ú", "Ủ", "Ũ", "Ụ", "Ư", "Ừ", "Ứ", "Ử", "Ữ", "Ự", "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"
        //                            };


        //    string[] VNI_char = { "aø", "aù", "aû", "aõ", "aï", "aê", "aè", "aé", "aú", "aü", "aë", "aâ", "aà", "aá", "aå", "aã", "aä", 
        //                                "ñ", "eø", "eù", "eû", "eõ", "eï", "eâ", "eà", "eá", "eå", "eã", "eä", 
        //                                "ì", "í", "æ", "ó", "ò", "oø", "où", "oû", "oõ", "oï", "oâ", "oà", "oá", "oå", "oã", "oä", "ô", "ôø", "ôù", "ôû", "ôõ", "ôï", 
        //                                "uø", "uù", "uû", "uõ", "uï", "ö", "öø", "öù", "öû", "öõ", "öï", "yø", "yù", "yû", "yõ", "î", 
        //                                "AØ", "AÙ", "AÛ", "AÕ", "AÏ", "AÊ", "AÈ", "AÉ", "AÚ", "AÜ", "AË", "AÂ", "AÀ", "AÁ", "AÅ", "AÃ", 
        //                                "Ñ", "EØ", "EÙ", "EÛ", "EÕ", "EÏ", "EÂ", "EÀ", "EÁ", "EÅ", "EÃ", "EÄ", 
        //                                "Ì","Í", "Æ", "Ó", "Ò", "OØ", "OÙ", "OÛ", "OÕ", "OÏ", "OÂ", "OÀ", "OÁ", "OÅ", "OÃ", "OÄ", "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        //                                "UØ", "UÙ", "UÛ", "UÕ", "UÏ", "Ö", "ÖØ", "ÖÙ", "ÖÛ", "ÖÕ", "ÖÏ", "YØ", "YÙ", "YÛ", "YÕ", "Î" }; 
        //    StringBuilder strB = new StringBuilder(str);
        //    for (int i = 0; i < VNI_char.Length; i++)
        //    {
        //        strB.Replace(Unicode_char[i], VNI_char[i]);
        //    }
        //    return strB.ToString();
        //}
        ////string[] sUnicode = { "à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", 
        ////                            "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể", "ễ", "ệ", 
        ////                            "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ô", "ồ", "ố", "ổ", "ỗ", "ộ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ", 
        ////                            "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự", "ỳ", "ý", "ỷ", "ỹ", "ỵ", 
        ////                            "À", "Á", "Ả", "Ã", "Ạ", "Ă", "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ", "Â", "Ầ", "Ấ", "Ẩ", "Ẫ", 
        ////                            "Đ", "È", "É", "Ẻ", "Ẽ", "Ẹ", "Ê", "Ề", "Ế", "Ể", "Ễ", "Ệ", 
        ////                            "Ì","Í", "Ỉ", "Ĩ", "Ị", "Ò", "Ó", "Ỏ", "Õ", "Ọ", "Ô", "Ồ", "Ố", "Ổ", "Ỗ", "Ộ", "Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ", 
        ////                            "Ù", "Ú", "Ủ", "Ũ", "Ụ", "Ư", "Ừ", "Ứ", "Ử", "Ữ", "Ự", "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"
        ////                        };


        ////string[] sVNI = { "aø", "aù", "aû", "aõ", "aï", "aê", "aè", "aé", "aú", "aü", "aë", "aâ", "aà", "aá", "aå", "aã", "aä", 
        ////                            "ñ", "eø", "eù", "eû", "eõ", "eï", "eâ", "eà", "eá", "eå", "eã", "eä", 
        ////                            "ì", "í", "æ", "ó", "ò", "oø", "où", "oû", "oõ", "oï", "oâ", "oà", "oá", "oå", "oã", "oä", "ô", "ôø", "ôù", "ôû", "ôõ", "ôï", 
        ////                            "uø", "uù", "uû", "uõ", "uï", "ö", "öø", "öù", "öû", "öõ", "öï", "yø", "yù", "yû", "yõ", "î", 
        ////                            "AØ", "AÙ", "AÛ", "AÕ", "AÏ", "AÊ", "AÈ", "AÉ", "AÚ", "AÜ", "AË", "AÂ", "AÀ", "AÁ", "AÅ", "AÃ", 
        ////                            "Ñ", "EØ", "EÙ", "EÛ", "EÕ", "EÏ", "EÂ", "EÀ", "EÁ", "EÅ", "EÃ", "EÄ", 
        ////                            "Ì","Í", "Æ", "Ó", "Ò", "OØ", "OÙ", "OÛ", "OÕ", "OÏ", "OÂ", "OÀ", "OÁ", "OÅ", "OÃ", "OÄ", "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        ////                            "UØ", "UÙ", "UÛ", "UÕ", "UÏ", "Ö", "ÖØ", "ÖÙ", "ÖÛ", "ÖÕ", "ÖÏ", "YØ", "YÙ", "YÛ", "YÕ", "Î" };


        ////BMaVniTCVN3 1 vni - 2 Tcvn3
        ////mUnicode true  Chuyen tu unicode sang cac bang ma khac, == false nguoc lai
        //public string MConvertMa(string str, Boolean mUnicode, int iBMa)
        //{
        //    //", "ó", "     
        //    //"ó", 
        //    //"ớ", "ở", "ỡ", "ợ",   "ôù", "ôû", "ôõ", "ôï", 
        //    //"Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ",  "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        //    string[] sUnicode = { "à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", 
        //                            "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể", "ễ", "ệ", 
        //                            "ì", "í", "ỉ",  
        //                            "ỏ", "õ", "ọ", "ồ", "ố", "ổ", "ỗ", "ộ", 

        //                            "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự", "ỳ", "ý", "ỷ", "ỹ", "ỵ", 
        //                            "À", "Á", "Ả", "Ã", "Ạ", "Ă", "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ", "Â", "Ầ", "Ấ", "Ẩ", "Ẫ","Ậ", 
        //                            "Đ", "È", "É", "Ẻ", "Ẽ", "Ẹ", "Ê", "Ề", "Ế", "Ể", "Ễ", "Ệ", 
        //                            "Ì","Í", "Ỉ",  
        //                            "Ò", "Ó", "Ỏ", "Õ", "Ọ", "Ồ", "Ố", "Ổ", "Ỗ", "Ộ", 

        //                            "Ù", "Ú", "Ủ", "Ũ", "Ụ", "Ư", "Ừ", "Ứ", "Ử", "Ữ", "Ự", "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"
        //                        };


        //    string[] sVNI = { "aø", "aù", "aû", "aõ", "aï", "aê", "aè", "aé", "aú", "aü", "aë", "aâ", "aà", "aá", "aå", "aã", "aä", 
        //                            "ñ", "eø", "eù", "eû", "eõ", "eï", "eâ", "eà", "eá", "eå", "eã", "eä", 
        //                            "ì", "í", "æ", 
        //                            "oû", "oõ", "oï", "oà", "oá", "oå", "oã", "oä", 

        //                            "uø", "uù", "uû", "uõ", "uï", "ö", "öø", "öù", "öû", "öõ", "öï", "yø", "yù", "yû", "yõ", "î", 
        //                            "AØ", "AÙ", "AÛ", "AÕ", "AÏ", "AÊ", "AÈ", "AÉ", "AÚ", "AÜ", "AË", "AÂ", "AÀ", "AÁ", "AÅ", "AÃ", "AÄ", 
        //                            "Ñ", "EØ", "EÙ", "EÛ", "EÕ", "EÏ", "EÂ", "EÀ", "EÁ", "EÅ", "EÃ", "EÄ", 
        //                            "Ì","Í", "Æ", 
        //                            "OØ", "OÙ", "OÛ", "OÕ", "OÏ", "OÀ", "OÁ", "OÅ", "OÃ", "OÄ", 

        //                            "UØ", "UÙ", "UÛ", "UÕ", "UÏ", "Ö", "ÖØ", "ÖÙ", "ÖÛ", "ÖÕ", "ÖÏ", "YØ", "YÙ", "YÛ", "YÕ", "Î" };

        //    string[] sTCVN3 = { "µ", "¸", "¶", "·", "¹", "¨", "»", "¾", "¼", "½", "Æ", "©", "Ç", "Ê", "È", "É", "Ë", "®", "Ì", "Ð", "Î", "Ï", "Ñ", "ª", "Ò", "Õ", "Ó", "Ô", "Ö", "×", "Ý", "Ø", "Ü", "Þ", "ß", "ã", "á", "â", "ä", "«", "å", "è", "æ", "ç", "é", "¬", "ê", "í", "ë", "ì", "î", "ï", "ó", "ñ", "ò", "ô", "­", "õ", "ø", "ö", "÷", "ù", "ú", "ý", "û", "ü", "þ", "¡", "¢", "§", "£", "¤", "¥", "¦" };


        //    StringBuilder strB = new StringBuilder(str);
        //    for (int i = 0; i < sVNI.Length; i++)
        //    {
        //        if (mUnicode)
        //        {
        //            if (iBMa == 2)
        //                strB.Replace(sUnicode[i], sTCVN3[i]);
        //            else
        //                strB.Replace(sUnicode[i], sVNI[i]);
        //        }
        //        else
        //        {
        //            if (iBMa == 2)
        //                strB.Replace(sTCVN3[i], sUnicode[i]);
        //            else
        //                strB.Replace(sVNI[i], sUnicode[i]);

        //        }

        //    }


        //    //strB.Replace('\ưù', '\ứ'); // O+
        //    //strB.Replace('\u00F4', '\u01A1'); // o+
        //    //strB.Replace('\u00D6', '\u01AF'); // U+
        //    //strB.Replace('\u00F6', '\u01B0'); // u+
        //    //strB.Replace('\u00C6', '\u00D4'); // O^
        //    //strB.Replace('\u00E6', '\u00F4'); // o^
        //    strB.Replace("ưù", "ứ");
        //    strB.Replace("aeuø", "aé");
        //    strB.Replace("AEUØ", "AÉ");

        //    //"ôø", "ôù", "ôû", "ôõ", "ôï"
        //    //"ờ", "ớ", "ở", "ỡ", "ợ"
        //    //"Ờ", "Ớ", "Ở", "Ỡ", "Ợ"


        //    //"Ư", "Ừ", "Ứ", "Ử", "Ữ", "Ự"
        //    //"ư", "ừ", "ứ", "ử", "ữ", "ự"
        //    strB.Replace("ƯÙ", "Ứ");    // Ứ


        //    strB.Replace("ƯØ", "Ừ");    // Ừ
        //    strB.Replace("ưø", "ừ");    


        //    strB.Replace("ƯÙ", "Ứ");    // Ứ


        //    strB.Replace("ƯÛ", "Ử");    // Ử
        //    strB.Replace("ưû", "ử");

        //    strB.Replace("ƯÕ", "Ữ");    // Ữ
        //    strB.Replace("ưõ", "ữ");

        //    strB.Replace("ƯÏ", "Ự");    // Ự
        //    strB.Replace("ưï", "ự");


        //    strB.Replace("auø", "aù");    // Ự
        //    strB.Replace("AUØ", "AÙ");    // Ự
        //    strB.Replace("aoõ", "aõ");    // Ự
        //    strB.Replace("AOÕ", "AÕ");    // Ự
        //    //aé aè aú aü aë   ắ ằ ẳ ẵ ặ  

        //    strB.Replace("aeø", "aè");    // Ự
        //    strB.Replace("AEØ", "AÈ");    // Ự
        //    strB.Replace("aé", "aé");    // Ự
        //    strB.Replace("auù", "aú");    // Ự
        //    strB.Replace("AUÙ", "AÚ");    // Ự

        //    //eù eø eû eõ eï       é è ẻ ẽ ẹ
        //    strB.Replace("euø", "eù");
        //    strB.Replace("EUØ", "EÙ");
        //    strB.Replace("eoõ", "eõ");
        //    strB.Replace("EOÕ", "EÕ");







        //    if (mUnicode)
        //    {
        //        strB.Replace("ó", "où");
        //        strB.Replace("ò", "oø");

        //        //strB.Replace("ô", "oâ");

        //        //í ì æ ó ò     í ì ỉ ĩ ị
        //        strB.Replace("ouø", "ó");
        //        //strB.Replace("OUØ", "OÙ");

        //        strB.Replace("oø", "ò");
        //        strB.Replace("OUØ", "OÙ");

        //        //ôù ôø ôû ôõ ôï ớ ờ ở ỡ ợ 
        //        strB.Replace("ôuø", "ôù");
        //        strB.Replace("oâuø", "ôù");

        //        strB.Replace("ÔUØ", "ÔÙ");      
        //    }
        //    if (!mUnicode)
        //    {

        //        //où oø oû oõ oï ó ò ỏ õ ọ
        //        strB.Replace("oø", "ò");
        //        strB.Replace("OØ", "Ò");

        //        //strB.Replace("oâ", "ô");
        //        //strB.Replace("OÂ", "Ô");


        //    }


        //    strB.Replace("aeâ", "aê");
        //    strB.Replace("AEÂ", "AÊ");

        //    //ô ôø 
        //    if (mUnicode && str.Contains("ò"))
        //        strB.Replace("ò", "oø");
        //    if (mUnicode && str.Contains("ó"))
        //        strB.Replace("ó", "où");

        //    if (!mUnicode && str.Contains("oø"))
        //        strB.Replace("oø","ò");
        //    if (!mUnicode && str.Contains("où"))
        //        strB.Replace("où","ó");
        //    //"ò"
        //    if (mUnicode && str.Contains("ò"))
        //        strB.Replace("ò", "oø");
        //    if (mUnicode && str.Contains("ó"))
        //        strB.Replace("ó", "où");

        //    //ô ôø    "ơ", "ờ" ờ
        //    if (!mUnicode && str.Contains("ô"))
        //        strB.Replace("ô", "ơ");
        //    if (!mUnicode && str.Contains("ôø"))
        //    {
        //        strB.Replace("ôø", "ờ");
        //        strB.Replace("ơø", "ờ");
        //    }

        //    //Ô 
        //    if (!mUnicode && str.Contains("oâ"))
        //        strB.Replace("oâ", "ô");
        //    if (!mUnicode && str.Contains("OÂ"))
        //        strB.Replace("OÂ", "Ô");
        //    if (mUnicode && str.Contains("ô"))
        //        strB.Replace("ô", "oâ");
        //    if (mUnicode && str.Contains("Ô"))
        //        strB.Replace("Ô", "OÂ");
        //    //"ó", "ò",  "ĩ", "ị",
        //    if (!mUnicode && str.Contains("oâ"))
        //        strB.Replace("oâ", "ô");
        //    if (!mUnicode && str.Contains("OÂ"))
        //        strB.Replace("OÂ", "Ô");
        //    //"ĩ", "ị"      "Ó", "Ò", "Ĩ", "Ị",
        //    if (mUnicode && str.Contains("ĩ"))
        //        strB.Replace("ĩ", "ó");
        //    if (mUnicode && str.Contains("Ĩ"))
        //        strB.Replace("Ĩ", "Ó");

        //    if (mUnicode && str.Contains("ị"))
        //        strB.Replace("ị", "ò");
        //    if (mUnicode && str.Contains("Ĩ"))
        //        strB.Replace("Ĩ", "Ò");

        //    //"ớ", "ở", "ỡ", "ợ",   "ôù", "ôû", "ôõ", "ôï",         "ô", "ôø", 
        //    if (mUnicode && str.Contains("ơ"))
        //        strB.Replace("ơ", "ô");
        //    if (mUnicode && str.Contains("ờ"))
        //        strB.Replace("ờ", "ôø");
        //    if (mUnicode && str.Contains("ớ"))
        //        strB.Replace("ớ", "ôù");
        //    if (mUnicode && str.Contains("ở"))
        //        strB.Replace("ở", "ôû");
        //    if (mUnicode && str.Contains("ỡ"))
        //        strB.Replace("ỡ", "ôõ");
        //    if (mUnicode && str.Contains("ợ"))
        //        strB.Replace("ợ", "ôï");
        //    //"Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ",  "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        //    if (mUnicode && str.Contains("Ơ"))
        //        strB.Replace("Ơ", "Ô");
        //    if (mUnicode && str.Contains("Ờ"))
        //        strB.Replace("Ờ", "ÔØ");
        //    if (mUnicode && str.Contains("Ớ"))
        //        strB.Replace("Ớ", "ÔÙ");
        //    if (mUnicode && str.Contains("Ở"))
        //        strB.Replace("Ở", "ÔÛ");
        //    if (mUnicode && str.Contains("Ỡ"))
        //        strB.Replace("Ỡ", "ÔÕ");
        //    if (mUnicode && str.Contains("Ợ"))
        //        strB.Replace("Ợ", "ÔÏ");


        //    //"ớ", "ở", "ỡ", "ợ",   "ôù", "ôû", "ôõ", "ôï",         "ô", "ôø", 
        //    if (!mUnicode && str.Contains("ô"))
        //        strB.Replace("ô","ơ");
        //    if (!mUnicode && str.Contains("ôø"))
        //        strB.Replace("ôø","ờ");
        //    if (!mUnicode && str.Contains("ôù"))
        //        strB.Replace("ôù","ớ");
        //    if (!mUnicode && str.Contains("ôû"))
        //        strB.Replace("ôû","ở");
        //    if (!mUnicode && str.Contains("ôõ"))
        //        strB.Replace("ôõ","ỡ");
        //    if (!mUnicode && str.Contains("ôï"))
        //        strB.Replace("ôï","ợ");
        //    //"Ơ", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ",  "Ô", "ÔØ", "ÔÙ", "ÔÛ", "ÔÕ", "ÔÏ", 
        //    if (!mUnicode && str.Contains("Ô"))
        //        strB.Replace("Ô","Ơ");
        //    if (!mUnicode && str.Contains("ÔØ"))
        //    {
        //        strB.Replace("ÔØ", "Ờ");
        //        strB.Replace("ƠØ", "Ờ");
        //    }
        //    if (!mUnicode && str.Contains("ÔÙ"))
        //    {
        //        strB.Replace("ÔÙ", "Ớ");
        //        strB.Replace("ƠÙ", "Ớ");
        //    }
        //    if (!mUnicode && str.Contains("ÔÛ"))
        //        strB.Replace("ÔÛ", "Ở");
        //    if (!mUnicode && str.Contains("ÔÕ"))
        //    {
        //        strB.Replace("ÔÕ", "Ỡ");
        //        strB.Replace("ƠÕ", "Ỡ");
        //    }
        //    if (!mUnicode && str.Contains("ÔÏ"))
        //    {
        //        strB.Replace("ÔÏ", "Ợ");
        //        strB.Replace("ƠÏ", "Ợ");
        //    }
        //    return strB.ToString();
        //}



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    textBox2.Text = Commons.Modules.ObjSystems.MVni2Uni(textBox1.Text);
        //    //textBox2.Text = MConvertMa(textBox1.Text, false, 1);

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    textBox1.Text = Commons.Modules.ObjSystems.MUni2Vni(textBox2.Text);
        //    //textBox1.Text = MConvertMa(textBox2.Text, true, 1);
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //textBox2.Text = MConvertMa(textBox3.Text, false, 2);
        //}

        //private string ConvertVni2Uni(string str)
        //{

        //    StringBuilder strB = new StringBuilder(str);

        //    // Part 1
        //    strB.Replace('\u00D1', '\u0110'); // DD
        //    strB.Replace('\u00F1', '\u0111'); // dd
        //    strB.Replace('\u00D3', '\u0128'); // I~
        //    strB.Replace('\u00F3', '\u0129'); // i~
        //    strB.Replace('\u00D2', '\u1ECA'); // I.
        //    strB.Replace('\u00F2', '\u1ECB'); // i.
        //    strB.Replace('\u00C6', '\u1EC8'); // I?
        //    strB.Replace('\u00E6', '\u1EC9'); // i?
        //    strB.Replace('\u00CE', '\u1EF4'); // Y.
        //    strB.Replace('\u00EE', '\u1EF5'); // y.

        //    // Part 2
        //    // Transform "O\u00C2" -> "\u00C6" to later transform back to "\u00D4" in Part 3
        //    for (int i = 0; i < VNI_char.Length; i++)
        //    {
        //        strB.Replace(VNI_char[i], Unicode_char[i]);
        //    }

        //    // Part 3
        //    strB.Replace('\u00D4', '\u01A0'); // O+
        //    strB.Replace('\u00F4', '\u01A1'); // o+
        //    strB.Replace('\u00D6', '\u01AF'); // U+
        //    strB.Replace('\u00F6', '\u01B0'); // u+
        //    strB.Replace('\u00C6', '\u00D4'); // O^
        //    strB.Replace('\u00E6', '\u00F4'); // o^

        //    str = strB.ToString();

        //    return str;
        //}

        //private string ConvertUni2Vni(string str)
        //{

        //    StringBuilder strB = new StringBuilder(str);

        //    // Part 1
        //    strB.Replace('\u0110', '\u00D1'); // DD
        //    strB.Replace('\u0111','\u00F1'); // dd
        //    strB.Replace('\u0128', '\u00D3'); // I~
        //    strB.Replace('\u0129','\u00F3'); // i~
        //    strB.Replace('\u1ECA', '\u00D2'); // I.
        //    strB.Replace('\u1ECB','\u00F2'); // i.
        //    strB.Replace('\u1EC8','\u00C6'); // I?
        //    strB.Replace('\u1EC9','\u00E6'); // i?
        //    strB.Replace('\u1EF4', '\u00CE'); // Y.
        //    strB.Replace('\u1EF5','\u00EE'); // y.

        //    // Part 2
        //    // Transform "O\u00C2" -> "\u00C6" to later transform back to "\u00D4" in Part 3
        //    for (int i = 0; i < VNI_char.Length; i++)
        //    {
        //        strB.Replace(Unicode_char[i], VNI_char[i]);
        //    }

        //    // Part 3
        //    strB.Replace('\u01A0', '\u00D4'); // O+
        //    strB.Replace('\u01A1','\u00F4'); // o+
        //    strB.Replace('\u01AF','\u00D6'); // U+
        //    strB.Replace('\u01B0','\u00F6'); // u+
        //    strB.Replace('\u00D4','\u00C6'); // O^
        //    strB.Replace('\u00F4','\u00E6'); // o^

        //    str = strB.ToString();

        //    return str;
        //}

    //}
