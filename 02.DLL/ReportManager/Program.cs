using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportManager
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
            Commons.Modules.UserName = Vietsoft.Information.UserID;
            //Commons.IConnections.ConnectionString = @"Data Source=LENOVO-PC\SQLEXPRESS2008;Initial Catalog=CMMS_19_12_2011;User ID=sa;Pwd=123";

            Commons.Modules.TypeLanguage = 0;


            Commons.IConnections.Server = ".";
            Commons.IConnections.Database = "CMMS_VF";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";

            //Commons.IConnections.Server = "192.168.200.57";
            //Commons.IConnections.Database = "CMMS_GREENFEED";
            //Commons.IConnections.Password = "P@ssw0rd1";
            //Commons.IConnections.Username = "sa";
            //Commons.IConnections.Database = "CMMS_GREENFEED";
            
         
            //Commons.ConnectionString = @"Data Source=" +  Commons.IConnections.Server +  
            //    ";Initial Catalog=" +  Commons.IConnections.Database +
            //    ";User ID=" + Commons.IConnections.Username + ";Pwd=" + Commons.IConnections.Password + "";
            //LoaiBC = 1; la report
            //LoaiBC = 2; la mail
            //LoaiBC = 3; An Hien Cot Phan Quyen
            LoaiBaoCao._LoaiBC = 1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmReports());
        }
    }
}