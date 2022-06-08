﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace VSMail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                
                //Commons.IConnections.Database = ds.Tables[0].Rows[0]["D"].ToString();

                //Commons.IConnections.Server = sArr[0].ToString();
                //Commons.IConnections.Database = sArr[1].ToString();
                //Commons.IConnections.Username = sArr[2].ToString();
                //Commons.IConnections.Password = sArr[3].ToString();
                //Commons.Modules.TypeLanguage = int.Parse(sArr[4].ToString());
                //Commons.Modules.ModuleName = "ECOMAIN";

                ////Commons.IConnections.Server = ".\\SQL2014";
                ////Commons.IConnections.Database = "CMMS_ECO";
                //  Commons.Modules.UserName = "Admin";
                //Commons.Modules.sMailFrom = "svi.noreply@shiseido.vn";
                //Commons.Modules.sMailFromPass = "sv@00000";
                //Commons.Modules.sMailFromSmtp = "smtp.office365.com";
                //Commons.Modules.sMailFromPort = "587";
                //Commons.Modules.sPrivate = "SHISEIDO";

                //Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com";
                //Commons.Modules.sMailFromPass = "Namviet@2017";
                //Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
                //Commons.Modules.sMailFromPort = "587";
                //Ecomaint@veco.vn / pass: P@ssword123456
                //Imap.gmail.com ssl port 993
                //Smtp.gmail.com tls port 587
                bool firstInstance;
                using (Mutex mutex = new Mutex(true, "MAutoMailVS", out firstInstance))
                {
                    if (firstInstance)
                    {
                        Application.Run(new frmCMMSMailServer());
                    }
                    //else MessageBox.Show("Ứng dụng đang chạy...", "zstar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
