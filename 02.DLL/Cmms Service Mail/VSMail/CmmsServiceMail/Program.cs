using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;

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


                //Commons.IConnections.Server = ".";
                //Commons.IConnections.Database = "CMMS_DEMO1";
                //Commons.Modules.TypeLanguage = 0;
                //Commons.IConnections.Password = "123";
                //Commons.IConnections.Username = "sa";
                //Commons.Modules.ModuleName = "ECOMAIN";

                //Commons.IConnections.Server = ".";
 
                //Commons.IConnections.Database = "CMMS_demo1";

                //Commons.Modules.TypeLanguage = 1;
                //Commons.IConnections.Password = "Veco@2015";
                //Commons.IConnections.Username = "sa";
                //Commons.Modules.ModuleName = "ECOMAIN";
                //Commons.IConnections.Server = "10.234.1.12";
                //Commons.IConnections.Database = "CMMS_ECO";

                //Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com";
                //Commons.Modules.sMailFromPass = "Namviet@2017";
                //Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
                //Commons.Modules.sMailFromPort = "587";
                //Commons.Modules.sPrivate = "VECO";
              

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                string sChuoi;
                StreamReader sFileInclude;
                sFileInclude = File.OpenText(Application.StartupPath + "\\VSConfig.ini");

                sChuoi = sFileInclude.ReadToEnd();
                sChuoi = Commons.Modules.ObjSystems.GiaiMaDL(sChuoi);
                string[] sArr = sChuoi.Split(new Char[] { '!' });

                Commons.IConnections.Server = sArr[0].ToString();
                Commons.IConnections.Database = sArr[1].ToString();
                Commons.IConnections.Username = sArr[2].ToString();
                Commons.IConnections.Password = sArr[3].ToString();
                Commons.Modules.TypeLanguage = int.Parse(sArr[4].ToString());
                Commons.Modules.ModuleName = "ECOMAIN";


                Commons.IConnections.Server = ".";
                Commons.IConnections.Database = "cmms_demo";
                Commons.IConnections.Username = "sa";
                Commons.IConnections.Password = "123";

                //ecomaint @bariaserece.com    ͈ΆΨΖΆ̨̦̪ smtp.office365.com  587
                //pass: Baria123

                Commons.Modules.UserName = "Admin";
                //Commons.Modules.sMailFrom = "cmmsvhcollagen@gmail.com";
                //Commons.Modules.sMailFromPass = "Qq@12345";
                //Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
                //Commons.Modules.sMailFromPort = "587";
                Commons.Modules.sPrivate = "VINHHOAN";

                Commons.Modules.sMailFrom = "ecomaint@bariaserece.com";
                Commons.Modules.sMailFromPass = "Baria123";
                Commons.Modules.sMailFromSmtp = "smtp.office365.com";
                Commons.Modules.sMailFromPort = "587";

                bool firstInstance;
                using (Mutex mutex = new Mutex(true, "MMail", out firstInstance))
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
