using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.ApplicationBlocks.Data;
using System.Security.AccessControl;
using System.Net;
using System.Net.Mail;

namespace VSMail
{
    public partial class frmCMMSMailServer : Form
    {
        private string CnnString = "";
        private string TenBC;
        private string sKhongLoad = "";
        Boolean Mashj = false;
        Boolean MRunApp = false;
        DateTime NgayGioHT;
        public frmCMMSMailServer()
        {
            InitializeComponent();
        }

        private void btnStartSV_Click(object sender, EventArgs e)
        {
            if (!KiemDuLieu()) return;
            StartSV();
        }

        private void StartSV()
        {
            btnStartSV.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;

            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStartSV.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            exitToolStripMenuItem.Enabled = true;
            timer1.Enabled = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sKhongLoad == "0load") return;
            try
            {
                string user = Environment.UserDomainName + "\\" + Environment.UserName;

                RegistrySecurity rs = new RegistrySecurity();

                rs.AddAccessRule(new RegistryAccessRule(user,
                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                    InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));

                RegistryKey rk = null;
                rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                               RegistryKeyPermissionCheck.Default, rs);

                if (checkBox1.Checked)
                {

                    rk.SetValue("AutoMailVS", Application.ExecutablePath);
                }
                else
                {
                    rk.DeleteValue("AutoMailVS", false);
                }
                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mashj = true;
            try
            {
                this.Close();
            }
            catch { }
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Mashj)
            {
                e.Cancel = true;
                Hide();
            }
        }
        

        private Boolean KiemDuLieu()
        {
           
            if (!MInternet.IsConnectedToInternet())
            {
                MessageBox.Show("Please connect internet.");
                return false;
            }
            return true;
        }
        
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MRunApp) return;
            MRunApp = true;
            DateTime Ngay = DateTime.Now;
            NgayGioHT = Ngay.Date.AddHours(Ngay.Hour).AddMinutes(Ngay.Minute);
            MSchedules();
            MRunApp = false;
        }

        private void MSchedules()
        {
            try
            {
                DataTable dtDSMail = new DataTable();
                dtDSMail.Load(SqlHelper.ExecuteReader(CnnString, CommandType.Text,
                    "SELECT * FROM MAIL_SCHEDULES A INNER JOIN DS_MAIL B ON A.ID_SCHEDULES = B.ID_SCHEDULES WHERE HIEU_LUC = 1"));
                if (dtDSMail.Rows.Count == 0) return;
                DataTable dtTmp = new DataTable();
                for (int i = 0; i < dtDSMail.Rows.Count; i++)
                {
                    dtTmp = new DataTable();
                    dtTmp = dtDSMail.Copy();
                    dtTmp.DefaultView.RowFilter = " ID_SCHEDULES = " + int.Parse(dtDSMail.Rows[i]["ID_SCHEDULES"].ToString()) +
                        " AND ID = " + int.Parse(dtDSMail.Rows[i]["ID"].ToString());

                    dtTmp = dtTmp.DefaultView.ToTable();
                    if (dtTmp.Rows.Count > 0)
                    {
                        #region "Kieu Goi La Ngay LOAI_SCHEDULES = 1"
                        if (int.Parse(dtDSMail.Rows[i]["LOAI_SCHEDULES"].ToString()) == 1)
                        {
                            MNgay(dtTmp);
                        }
                        #endregion

                        #region "Kieu Goi La Tuan LOAI_SCHEDULES = 2"
                        if (int.Parse(dtDSMail.Rows[i]["LOAI_SCHEDULES"].ToString()) == 2)
                        {
                            MTuan(dtTmp);
                        }
                        #endregion

                        #region "Kieu Goi La Thang LOAI_SCHEDULES = 3"
                        if (int.Parse(dtDSMail.Rows[i]["LOAI_SCHEDULES"].ToString()) == 3)
                        {
                            MThang(dtTmp);
                        }
                        #endregion
                    }
                }

            }
            catch { }

        }

        private void MNgay(DataTable dtSch)
        {
            try
            {
                #region "Kiem Ngay Goi Theo Ngay Bat Dau hieu Luc
                DateTime NgayBDHL, NgayHT;
                int GoiMoi;
                NgayHT = NgayGioHT.Date;
                NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                GoiMoi = int.Parse(dtSch.Rows[0]["GOI_MOI"].ToString());
                TimeSpan timespan = (NgayHT - NgayBDHL);
                if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) != (timespan.TotalDays / GoiMoi)) return;
                #endregion

                #region "Kiem Du Lieu Goi"
                if (!MKiemNgayBDKTSch(dtSch)) return;
                #endregion

                #region Tao Du Lieu Goi
                TaoDuLieu(dtSch);
                #endregion
            }
            catch { return; }

        }

        private void MTuan(DataTable dtSch)
        {
            try
            {
                #region "Kiem Du Lieu Goi"
                if (!MKiemNgayBDKTSch(dtSch)) return;
                #endregion

                #region "Kiem Ngay Goi Theo Ngay Bat Dau hieu Luc"
                DateTime NgayBDHL, NgayHT;
                int GoiMoi;
                Boolean Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, ThuCN;


                Thu2 = Boolean.Parse(dtSch.Rows[0]["THU_2"].ToString());
                Thu3 = Boolean.Parse(dtSch.Rows[0]["THU_3"].ToString());
                Thu4 = Boolean.Parse(dtSch.Rows[0]["THU_4"].ToString());
                Thu5 = Boolean.Parse(dtSch.Rows[0]["THU_5"].ToString());
                Thu6 = Boolean.Parse(dtSch.Rows[0]["THU_6"].ToString());
                Thu7 = Boolean.Parse(dtSch.Rows[0]["THU_7"].ToString());
                ThuCN = Boolean.Parse(dtSch.Rows[0]["THU_CN"].ToString());
                NgayHT = NgayGioHT.Date;
                NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                GoiMoi = int.Parse(dtSch.Rows[0]["GOI_MOI"].ToString()) * 7;

                Boolean KiemNgay = true;

                if (!Thu2 && !Thu3 && !Thu4 && !Thu5 && !Thu6 && !Thu7 && !ThuCN)
                {
                    TimeSpan timespan = (NgayHT - NgayBDHL);
                    if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) != (timespan.TotalDays / GoiMoi)) return;
                }
                else
                {
                    if (Thu2)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Monday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (Thu3)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Tuesday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (Thu4)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Wednesday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (Thu5)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Thursday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (Thu6)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Friday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (Thu7)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Saturday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);
                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    if (ThuCN)
                    {
                        NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());
                        while (NgayBDHL.DayOfWeek != DayOfWeek.Sunday) NgayBDHL = NgayBDHL.AddDays(1);
                        TimeSpan timespan = (NgayHT - NgayBDHL);

                        if (((timespan.TotalDays / GoiMoi) - (timespan.TotalDays % GoiMoi)) == (timespan.TotalDays / GoiMoi)) goto EndKiem;
                    }
                    KiemNgay = false;
                }
                if (KiemNgay == false) return;
                EndKiem:;
                #endregion

                #region Tao Du Lieu Goi
                TaoDuLieu(dtSch);
                #endregion

            }
            catch
            {
                return;
            }

        }

        private void MThang(DataTable dtSch)
        {
            try
            {
                int GoiMoi, VaoNgayThang;
                DateTime NgayBDHL, NgayHT;
                NgayHT = NgayGioHT.Date;
                NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());

                #region "Kiem Du Lieu Goi"
                if (!MKiemNgayBDKTSch(dtSch)) return;
                #endregion

                #region "Kiem Ngay Goi Theo Ngay Bat Dau hieu Luc"

                NgayBDHL = DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString());

                if (int.Parse(dtSch.Rows[0]["LOAI_THANG"].ToString()) == 1)
                {
                    GoiMoi = int.Parse(dtSch.Rows[0]["GOI_MOI"].ToString());
                    VaoNgayThang = int.Parse(dtSch.Rows[0]["VAO_NGAY_THANG"].ToString());
                    while (NgayBDHL.Day != VaoNgayThang) NgayBDHL = NgayBDHL.AddDays(1);
                    int SoThang = MGetSoNgayThang(NgayBDHL, NgayHT);
                    if ((SoThang % GoiMoi) != 0) return;
                    DateTime NgayGoi = NgayBDHL.AddMonths(SoThang);
                    if (NgayGoi != NgayHT) return;
                }
                else
                {
                    NgayBDHL = DateTime.Parse("01/" + NgayBDHL.AddMonths(1).Month + "/" + NgayBDHL.Year);
                    // 0 tuan dau tien, 1 la tuan thu 1, 2 la tuan thu 2, 3 la tuan thu 3, 4 la tuan thu 4, 5 la tuan thu 5 , 6 la tuan thu 6
                    int VaoTuan = int.Parse(dtSch.Rows[0]["LOAI_TUAN_THANG"].ToString());
                    // 0 la CN , 1 la thu 2, 2 thu 3, 3 thu 4
                    VaoNgayThang = int.Parse(dtSch.Rows[0]["THU_TUAN_THANG"].ToString());
                    GoiMoi = int.Parse(dtSch.Rows[0]["SO_THANG_THANG"].ToString());
                    int SoThang = MGetSoNgayThang(NgayBDHL, NgayHT);
                    //GoiMoi = 4;

                    #region "Kiem Coi co dung so thang goi khong
                    if ((SoThang % GoiMoi) != 0) return;
                    #endregion
                    #region "Kiem Coi co dung so tuan goi khong
                    int SoTuan = GetWeekOfMonth(NgayHT);
                    if (SoTuan != VaoTuan) return;
                    #endregion

                    #region "Kiem Coi co dung ngay tuan goi khong
                    if (VaoNgayThang == 0) if (NgayHT.DayOfWeek != DayOfWeek.Sunday) return;
                    if (VaoNgayThang == 1) if (NgayHT.DayOfWeek != DayOfWeek.Monday) return;
                    if (VaoNgayThang == 2) if (NgayHT.DayOfWeek != DayOfWeek.Tuesday) return;
                    if (VaoNgayThang == 3) if (NgayHT.DayOfWeek != DayOfWeek.Wednesday) return;
                    if (VaoNgayThang == 4) if (NgayHT.DayOfWeek != DayOfWeek.Thursday) return;
                    if (VaoNgayThang == 5) if (NgayHT.DayOfWeek != DayOfWeek.Friday) return;
                    if (VaoNgayThang == 6) if (NgayHT.DayOfWeek != DayOfWeek.Saturday) return;
                    #endregion
                }
                #endregion

                #region Tao Du Lieu Goi
                TaoDuLieu(dtSch);
                #endregion
            }
            catch
            {
                return;
            }
        }

        public int MGetSoNgayThang(DateTime Tu, DateTime Den)
        {
            if (Tu > Den)
            {
                DateTime tmp;
                tmp = Tu;
                Tu = Den;
                Den = tmp;
            }

            int month;
            month = 0;
            while ((Tu <= Den))
            {
                Tu = Tu.AddMonths(1);
                month = month + 1;
            }
            return month - 1;
        }

        private void TaoDuLieu(DataTable dtSch)
        {
            TenBC = "";
            int iTinhTrang = 1;
            // iTinhTrang = 0 khong co du lieu. 1 co du lieu.  2 loi
            string sLoi = "";
            if (!TaoBaoCao(dtSch, out iTinhTrang, out sLoi))
            {
                if (TenBC == "KhongCoDuLieuIn")
                    if (iTinhTrang == 0)
                    {
                        TenBC = dtSch.Rows[0]["ID_MAIL"].ToString() + "-" + dtSch.Rows[0]["ID"].ToString() + " : no data print." + sLoi;
                        MInternet.GhiLog(Application.StartupPath.ToString(), "", TenBC, NgayGioHT);
                    }
                if (iTinhTrang == 2)
                {
                    TenBC = dtSch.Rows[0]["ID_MAIL"].ToString() + "-" + dtSch.Rows[0]["ID"].ToString() + " : can not create";
                    if (sLoi != "")
                        TenBC = dtSch.Rows[0]["ID_MAIL"].ToString() + "-" + dtSch.Rows[0]["ID"].ToString() + " | " + sLoi;

                    MInternet.GhiLog(Application.StartupPath.ToString(), "Error", TenBC, NgayGioHT);
                }
                TenBC = "";
            }
        }
        
        private Boolean TaoBaoCao(DataTable dtSch, out int iTinhTrang, out string sLoi)
        {
            try
            {
                // iTinhTrang = 0 khong co du lieu. 1 co du lieu.  2 loi
                iTinhTrang = 1;
                sLoi = "";
                string sBCao;
                sBCao = dtSch.Rows[0]["ID_MAIL"].ToString().ToUpper();

                string Mail_Name = dtSch.Rows[0]["MAIL_NAME"].ToString();
                string Mail_To = dtSch.Rows[0]["MAIL_TO"].ToString();
                string MAIL_CC = dtSch.Rows[0]["MAIL_CC"].ToString();
                string MAIL_BCC = dtSch.Rows[0]["MAIL_BCC"].ToString();
                string TEN_BC = dtSch.Rows[0]["TEN_BC"].ToString();
                string ND_BC = dtSch.Rows[0]["ND_BC"].ToString();
                string MAIL_GUI = dtSch.Rows[0]["MAIL_GUI"].ToString();
                string MAT_KHAU = dtSch.Rows[0]["MAT_KHAU"].ToString();
                string SMTP = dtSch.Rows[0]["SMTP"].ToString();
                string PORT = dtSch.Rows[0]["PORT"].ToString().Trim();

                //PORT = "25";
                //MAIL_GUI = "ecomaint.cmms@gmail.com";
                //MAT_KHAU = "Namviet@2017";
                //SMTP = "smtp.gmail.com";
                if (sBCao.ToUpper() == "LOAI1")
                {
                    try
                    {
                        sLoi = MSendEmail(Mail_To, MAIL_CC, MAIL_BCC, MAIL_GUI, MAT_KHAU, TEN_BC, ND_BC, SMTP, PORT);
                    }
                    catch (Exception ex)
                    {
                        sLoi = ex.Message.ToString();
                    }
                }
            }catch (Exception ex)
            {
                sLoi = ex.Message.ToString();
            }
            if (sLoi.ToString().Trim() == "")
            {
                iTinhTrang = 1;
                return true;
            }
            else
            {
                iTinhTrang = 2;
                return false;
            }
        }

        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        private Boolean MKiemNgayBDKTSch(DataTable dtSch)
        {

            #region "Kiem Ngay hieu luc BD va KT goi"
            if (DateTime.Parse(dtSch.Rows[0]["TG_BD_HL"].ToString()).Date > NgayGioHT.Date) return false;
            if (int.Parse(dtSch.Rows[0]["LOAI_HIEU_LUC"].ToString()) == 1)
                if (DateTime.Parse(dtSch.Rows[0]["TG_KT_HL"].ToString()).Date < NgayGioHT.Date) return false;
            #endregion

            #region "Kiem Goi Vao Luc Hay Goi Moi
            int GoiMoi;
            //Goi co thoi gian xac dinh loai time = 0
            if (int.Parse(dtSch.Rows[0]["LOAI_TIME"].ToString()) == 0)
            {
                DateTime GioGoi;
                GioGoi = DateTime.Parse(dtSch.Rows[0]["GIO_GOI"].ToString());
                GioGoi = NgayGioHT.Date.AddHours(GioGoi.Hour).AddMinutes(GioGoi.Minute).AddSeconds(GioGoi.Second);
                if (GioGoi != NgayGioHT) return false; else return true;
            }
            DateTime GioBD, GioKT;
            GioBD = DateTime.Parse("00:00:00");
            GioBD = NgayGioHT.Date.AddHours(GioBD.Hour).AddMinutes(GioBD.Minute).AddSeconds(GioBD.Second);
            GioKT = DateTime.Parse("23:59:59");
            GioKT = NgayGioHT.Date.AddHours(GioKT.Hour).AddMinutes(GioKT.Minute).AddSeconds(GioKT.Second);
            try
            {
                GioBD = DateTime.Parse(dtSch.Rows[0]["TG_BD"].ToString());
                GioBD = NgayGioHT.Date.AddHours(GioBD.Hour).AddMinutes(GioBD.Minute).AddSeconds(GioBD.Second);
                GioKT = DateTime.Parse(dtSch.Rows[0]["TG_KT"].ToString());
                GioKT = NgayGioHT.Date.AddHours(GioKT.Hour).AddMinutes(GioKT.Minute).AddSeconds(GioKT.Second);
            }
            catch { }


            GoiMoi = int.Parse(dtSch.Rows[0]["SO_GIO_GOI"].ToString());
            if (GioBD > NgayGioHT) return false;
            if (GioKT < NgayGioHT) return false;
            TimeSpan timespan = (NgayGioHT - GioBD);
            //Goi moi gio loai time = 1
            if (int.Parse(dtSch.Rows[0]["LOAI_TIME"].ToString()) == 1)
                if (((timespan.TotalHours / GoiMoi) - (timespan.TotalHours % GoiMoi)) != (timespan.TotalHours / GoiMoi)) return false;

            //Goi moi phut loai time = 2
            if (int.Parse(dtSch.Rows[0]["LOAI_TIME"].ToString()) == 2)
                if (((timespan.TotalMinutes / GoiMoi) - (timespan.TotalMinutes % GoiMoi)) != (timespan.TotalMinutes / GoiMoi)) return false;

            //Goi moi giay loai time = 3
            if (int.Parse(dtSch.Rows[0]["LOAI_TIME"].ToString()) == 3)
                if (((timespan.TotalSeconds / GoiMoi) - (timespan.TotalSeconds % GoiMoi)) != (timespan.TotalSeconds / GoiMoi)) return false;

            #endregion

            return true;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
        }
        

        private void lbmgs_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtDSMail = new DataTable();
            dtDSMail.Load(SqlHelper.ExecuteReader(CnnString, CommandType.Text,
            "SELECT * FROM MAIL_SCHEDULES A INNER JOIN DS_MAIL B ON A.ID_SCHEDULES = B.ID_SCHEDULES WHERE B.ID = 3"));
            if (dtDSMail.Rows.Count == 0) return;

            TaoDuLieu(dtDSMail);
            MessageBox.Show("ok");
        }


        #region "Sent mail"

        private string MSendEmail(string SendTo, string SendCC, string SendBCC, string SendFrom, string SendFromPass, string sSubject, string sBody,  string sSmtp, string sPort)
        {
            try
            {

                // Danh sách email được ngăn cách nhau bởi dấu ";"
                bool result = true;
                String[] ALL_EMAILS;
                //if( SendTo.Substring(SendTo.Length - 1) == ";")

                if (result == true)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient(sSmtp, int.Parse(sPort));
                        client.EnableSsl = true;

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(SendFrom, "VietSoft");
                        result = true;
                        if (SendTo.Trim() != "")
                        {
                            ALL_EMAILS = SendTo.Split(';');
                            foreach (string emailaddress in ALL_EMAILS)
                            {
                                if (emailaddress.ToString().Trim() != "") message.To.Add(emailaddress);
                            }
                        }
                        //client.UseDefaultCredentials = false;
                        //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        message.SubjectEncoding = Encoding.UTF8;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        message.Body = sBody;
                        message.Subject = sSubject;

                        // #Region "Kiem CC"
                        if (SendCC.Trim() != "")
                        {
                            ALL_EMAILS = SendCC.Split(';');
                            foreach (string emailaddress in ALL_EMAILS)
                            {
                                if (emailaddress.ToString().Trim() != "") message.CC.Add(emailaddress);
                            }
                        }
                        if (SendBCC.Trim() != "")
                        {
                            ALL_EMAILS = SendBCC.Split(';');
                            foreach (string emailaddress in ALL_EMAILS)
                            {
                                if (emailaddress.ToString().Trim() != "") message.Bcc.Add(emailaddress.ToString().Trim());
                            }
                        }
                        NetworkCredential myCreds = new NetworkCredential(SendFrom, SendFromPass, "");
                        client.Credentials = myCreds;
                        client.Send(message);
                        message.Dispose();
                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message ;
                    }
                }
                else
                    return "Email not sent";
            }
            catch (Exception ex)
            {
                return ex.Message ;
            }
        }

        #endregion

        private void frmCMMSMailServer_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\vsconfig.xml");
            CnnString = ds.Tables[0].Rows[0]["S"].ToString();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Input ID send", "", "", -1, -1);
            if (input.Trim().ToString() == "") return;
            DataTable dtDSMail = new DataTable();
            dtDSMail.Load(SqlHelper.ExecuteReader(CnnString, CommandType.Text,
            "SELECT * FROM MAIL_SCHEDULES A INNER JOIN DS_MAIL B ON A.ID_SCHEDULES = B.ID_SCHEDULES WHERE B.ID = " + input));
            if (dtDSMail.Rows.Count == 0)
            {
                MessageBox.Show("not data");
                return;
            }

            TaoDuLieu(dtDSMail);
            MessageBox.Show("ok");
        }
    }
}
