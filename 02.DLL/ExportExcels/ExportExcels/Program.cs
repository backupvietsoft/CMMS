using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExportExcels
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Commons.Modules.ModuleName = "ECOMAIN";
            Commons.Modules.UserName = "Administrator";
            Commons.Modules.UserName = "khoBD";
            Commons.Modules.TypeLanguage = 0;

            //Commons.IConnections.Username = "sa";
            //Commons.IConnections.Database = "CMMS_TEST";
            //Commons.IConnections.Password = "123";
            //Commons.IConnections.Server = @"DELL-PC\sql2008r2";



            //Commons.IConnections.Server = ".";
            Commons.IConnections.Database = "CMMS_DEMO";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";

            Commons.Modules.sMailFrom = "mashilove01@gmail.com";
            Commons.Modules.sMailFromPass = "VS@12345678";
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            Commons.Modules.sMailFromPort = "587";
            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.iReport = 1;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTTSP());
            //Application.Run(new frmTest());
            Application.Run(new frmExportExcel());
        }
    }
}
