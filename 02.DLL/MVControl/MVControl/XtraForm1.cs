using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using System.Net;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Configuration;

namespace MVControl
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        Control abc;
        //public XtraForm1(Control btn)
        //{
        //    abc = btn;
        //    InitializeComponent();
        //}

        public XtraForm1()
        {

            InitializeComponent();
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

        static IEnumerable<DateTime> DaysInRangeUntil(DateTime start, DateTime end)
        {
            return Enumerable.Range(0, 1 + (int)(end.Date - start.Date).TotalDays)
                             .Select(dt => start.Date.AddDays(dt));
        }

        static bool IsWeekendDay(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday
                || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        static DateTime Max(DateTime a, DateTime b)
        {
            return new DateTime(Math.Max(a.Ticks, b.Ticks));
        }

        static DateTime Min(DateTime a, DateTime b)
        {
            return new DateTime(Math.Min(a.Ticks, b.Ticks));
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            //Class1.Total1();

            LicCom();
            //string s = KiemApp.MEn("TRIAL");
            //s = KiemApp.MDe("Xu1K0NWzPo//qJpDRhBhFjFK0dNRt4J6k5k/TGkQFYo=");

            //string sBD = KiemApp.MEn("21/08/2018").ToString();

            ////string sTrial = MEn("Trial").ToString();
            ////sTrial = MDe("Trial").ToString();

            //try
            //{
            //    KiemApp.MKiemTrail("08/21/2018");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());

            //}

            //MVControl.ucBaoCaoChiPhi myUc = new MVControl.ucBaoCaoChiPhi();
            //this.Controls.Add(myUc);
            //myUc.Location = new Point(0, 0);
            //myUc.Dock = DockStyle.Fill;
            //PBTCV();
            PBTNS();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private string LicCom()
        {
            try
            {
                XDocument document = XDocument.Load(@"D:\VietSoft\Server Tool\config.xml");
                var LICLIMIT = from r in document.Descendants("VietsoftCMMS")
                               select r.Element("LIC").Value;
                string sXML = "";
                foreach (var r in LICLIMIT)
                {
                    sXML = r.ToString();
                }
                sXML = Decrypt(sXML, true);
                Byte[] Liccom = Encoding.Unicode.GetBytes(sXML);
                sXML = Encoding.ASCII.GetString(Liccom);
                return sXML;
            }
            catch (Exception ex)
            {
                //eventLog1.WriteEntry("LicNumber error : " + ex.Message);
                return "0";
            }

        }
        static string SecurityKey = "vietsoft.com.vn";
        static string chuoi = "_13579_";
        public static string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
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


        private void PBTDV()
        {

            MVControl.ucDichVuPBT myUc = new MVControl.ucDichVuPBT();

            this.Controls.Add(myUc);
            myUc.sMsPBT = "WO-201808000932";
            myUc.iTTPBTri = 2;
            myUc.sMsMay = "FIA-1501";

            myUc.LoadDichVu();

            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;

            this.Controls.Add(myUc);
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
        }

        private void PBTCV()
        {

            MVControl.ucCongViecPBT myUc = new MVControl.ucCongViecPBT();
            //            public string sPBT = "WO-201810000113";
            //public string sMay = "FAN-01-07";
            this.Controls.Add(myUc);
            myUc.sMsPBT = "WO-202010000205";
            myUc.iTTPBTri = 3;
            myUc.sMsMay = "FCO-FB-902";
            myUc.ngayBDKH = Convert.ToDateTime("2020/10/08");
            myUc.LoadFormCVPBT();
            myUc.LoadCongViec();
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;

        }

        private void PBTCVPhu()
        {

            MVControl.ucCongViecPhuTro myUc = new MVControl.ucCongViecPhuTro();
            myUc.LoadPBTCVPhuTro(-1);
            this.Controls.Add(myUc);
            myUc.sMsPBT = "WO-201808000932";
            myUc.iTTPBTri = 1;
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;

        }
        private void PBTNS()
        {
            MVControl.ucNhanSuPBT myUc = new MVControl.ucNhanSuPBT();
            this.Controls.Add(myUc);
            myUc.sMsPBT = "WO-202103000004";
            myUc.iTTPBTri = 2;
            myUc.sMsMay = "BCH-010";
            myUc.LoadFormNSPBT();
            myUc.ngayBDKH = Convert.ToDateTime("2020/10/08");
            myUc.ngayKTKH = Convert.ToDateTime("2022/10/08");
            //2020 - 09 - 20 00:00:00.000 2020 - 09 - 20 00:00:00.000
            //myUc.tuNgayGioHong = Convert.ToDateTime("1900/01/01");
            //myUc.denNgayGioHong = Convert.ToDateTime("1900/01/01");

            myUc.LoadCongViecChinhNS();

            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ////79	10-05-CRA-005-00
                //frmPBTBanHanh frm = new frmPBTBanHanh();
                //frm.iLoai = 4;
                //frm.sNXuong = "mashinhat@gmail.com";
                //frm.dtTmp = new DataTable();
                //frm.dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                //        "MMailGetXuLyYeuCau", 79, "10-05-CRA-005-00", Commons.Modules.TypeLanguage));
                //frm.ShowDialog();
            }
            catch { }
        }

        private void ucKeHoachBTTuan1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(GetParentForm(abc).Name); //Form1
        }


        private Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form != null)
            {
                return form;
            }
            if (parent != null)
            {
                return GetParentForm(parent.Parent);
            }
            return null;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //MessageBox.Show(ucComboboxTreeList1.EditValue.ToString());
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Show();
        }


        public static DialogResult Show(DevExpress.LookAndFeel.UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound)
        {

            XtraMessageBoxForm form = new XtraMessageBoxForm();
            return form.ShowMessageBoxDialog(new XtraMessageBoxArgs(lookAndFeel, owner, text, caption, buttons, icon, defaultButton));
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            var dlg = new DevExpress.Utils.WaitDialogForm();

        }
    }
}