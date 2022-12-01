using System;
using System.Threading;
using System.Windows.Forms;

namespace Vietsoft.Reminder
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
            Commons.Modules.UserName = "admin";
            //Commons.IConnections.Server = ".";
            //Commons.IConnections.Server = @"10.39.244.220\sql2008";
            //Commons.IConnections.Server = "10.39.244.220";
            //Commons.IConnections.Database = "CMMS_PILMICO";
            //Commons.IConnections.Database = "CMMS_SUMIRUBBER";
            Commons.IConnections.Server = "27.74.240.29,1434";
            //Commons.IConnections.Server = ".\\sql2016";
            //Commons.IConnections.Server = ".";
            Commons.Modules.sPrivate = "VIFON";
            Commons.IConnections.Database = "CMMS_TN";
            Commons.IConnections.Database = "CMMS_NAKY";
            //Commons.IConnections.Database = "CMMS_VS";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Password = "codaikadaiku";
            Commons.IConnections.Username = "sa";
            Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com";
            Commons.Modules.sMailFromPass = "Namviet@2017";
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            Commons.Modules.sMailFromPort = "25";
            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.bSSL = true;
            //Commons.IConnections.Server = "192.168.10.102";
            //Commons.IConnections.Database = "CMMS_VF";
            //Commons.IConnections.Password = "Vifon@123";
            //Commons.IConnections.Server = "172.23.234.23";
            //Commons.IConnections.Password = "Pil@2018";
            //Commons.IConnections.Username = "sa";
            //Commons.IConnections.Database = "CMMS_demo";
            //Commons.IConnections.Database = "CMMS_VF";
            ////Commons.IConnections.Server = ".";
            //Commons.IConnections.Server = "10.39.244.200";

            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.sPrivate = @"REMINGTON";
            Commons.Modules.PermisString = "Full access";
            Commons.Modules.sMailUser = @"cinemaofasia@gmail.com";
            Commons.Modules.iReport = 1;
            Commons.Modules.iDefault = 2;
            Commons.Modules.iSoLeSL = 1;
            Commons.Modules.iSoLeDG = 2;
            Commons.Modules.iSoLeTT = 3;
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
            Commons.Modules.bDoiFontReport = true;
            //Commons.Modules.sFontReport = "Monotype Corsiva";
            Commons.Modules.iPhutGioPBT = 1;
            Commons.Modules.TypeLanguage = 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Commons.Modules.ObjSystems.KhoMoi = false;

            //Commons.Modules.PermisString = "Read only";
            Thread t = new Thread(new ThreadStart(MRunForm));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        static void MRunForm()
        {
            try
            {
                Application.Run(new frmReminder_new());
                //Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}