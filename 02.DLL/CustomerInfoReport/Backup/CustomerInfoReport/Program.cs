using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustomerInfoReport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Vietsoft.Information.UserID = "Administrator";
            Vietsoft.Information.Username = "Administrator";
            Vietsoft.Information.ConnectionString = @"Data Source=Lenovo-pc\sqlexpress2008;Initial Catalog=CMMS_KIDO;User ID=sa;Pwd=123";
            //Vietsoft.Information.ConnectionString = @"Data Source=THIENHANG;Initial Catalog=CMMS_KIDO_KD_TEST;User ID=sa;Pwd=123";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ListMaintain());
        }
    }
}
