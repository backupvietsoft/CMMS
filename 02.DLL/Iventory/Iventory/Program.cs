using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Iventory
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
            //Commons.IConnections.ConnectionString = "Data Source=LENOVO-PC\\SQLEXPRESS2008;Initial Catalog=CMMS;User ID=sa;Pwd=123";
            Commons.IConnections.Database = "CMMS_new";
            Commons.IConnections.Server = "MASHIMARO\\VIETSOFT";
            Commons.IConnections.Username = "sa";
            Commons.IConnections.Password = "123";
            Vietsoft.Information.ConnectionString = "Data Source=MASHIMARO\\VIETSOFT;Initial Catalog=CMMS;User ID=sa;Pwd=123";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGoodreceive());
            //Application.Run(new frmGoodreturn());
        }
    }
}
