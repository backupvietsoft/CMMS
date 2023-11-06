using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.Mail;
using System.Linq;
using ReportHuda.UControl;
using ReportHuda.Colgate;

namespace ReportHuda
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //NMN_TD.UCKeHoachBT_Thang myUc = new NMN_TD.UCKeHoachBT_Thang();
            //UControl.ucBaoCaoYCNSD myUc = new UControl.ucBaoCaoYCNSD();
            //ucMaintainMonth myUc = new ucMaintainMonth();
            ucDanhSachPBT myUc = new ucDanhSachPBT();


            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s = Commons.Modules.MMail.MSendEmailNotAttachment("nvhien@vietsoft.com.vn", Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, "asa", "asdas",
                    Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort);
            }
            catch { }
        }
        public bool KiemEmail(string inputEmail, out string sLoi, out string sSentTo, out string sSentCC)
        {
            sLoi = "";
            sSentTo = "";
            sSentCC = "";

            try
            {
                string[] sMail = inputEmail.Split(new Char[] { ';' });

                inputEmail = inputEmail ?? string.Empty;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);

                foreach (string s in sMail)
                {
                    if (s != "")
                        if (!re.IsMatch(s.Trim()))
                        {
                            sLoi = s.Trim();
                            return (false);
                        }
                    if (sSentTo == "")
                        sSentTo = s.Trim();
                    else
                        sSentCC += s.Trim() + ";";
                }
                if (sSentCC.Length > 0) sSentCC = sSentCC.Substring(0, sSentCC.Length - 1);
                return true;
            }
            catch (Exception ex)
            {
                sLoi = ex.Message;
                sSentTo = "";
                sSentCC = "";
                return false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sendTo = "";
            MCheckEmail("man.huynh@bariasecere.com", ref sendTo);
        }
        private void MAddAttachment(MailMessage Message, string sALLAttPaths)
        {
            String[] AllAttPath = sALLAttPaths.Split(';');
            bool result = false;
            try
            {
                foreach (string strAttPath in AllAttPath)
                {
                    result = System.IO.File.Exists(strAttPath);
                    if (result)
                    {
                        Message.Attachments.Add(new System.Net.Mail.Attachment(strAttPath));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool MCheckEmail(string inputEmail, ref string sMailF)
        {

            String[] ALL_EMAILS = inputEmail.Split(';');
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}" + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\" + ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);

            if (ALL_EMAILS.Count() > 1)
            {
                foreach (string emailaddress in ALL_EMAILS)
                {
                    string t = emailaddress ?? string.Empty;
                    if (!re.IsMatch(emailaddress.Trim()))
                    {
                        sMailF = emailaddress.Trim();
                        return (false);
                    }
                }
                sMailF = "";
                return true;
            }
            else
            {
                inputEmail = inputEmail ?? string.Empty;
                if (re.IsMatch(inputEmail.Trim()))
                {
                    sMailF = "";
                    return (true);
                }
                else
                {
                    sMailF = inputEmail.Trim();
                    return (false);
                }

            }

        }
    }
}