using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
//using DevExpress.XtraBars

namespace ReportMail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Commons.Modules.UserName = "Administrator";
            Commons.Modules.TypeLanguage = 0;

            Commons.IConnections.Server = @"192.168.2.27\SQL2017";
            Commons.IConnections.Database = "CMMS_TN";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";           
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread myThread = default(Thread);
            try
            {
                myThread = new Thread(MRunForm);
                myThread.SetApartmentState(ApartmentState.STA);
                myThread.Start();
            }
            catch //(Exception ex)
            {
            }
        }
        private static void MRunForm()
        {
            Application.Run(new frmMailBieuDoTGNMayTheoNX());
        }
    }
}

