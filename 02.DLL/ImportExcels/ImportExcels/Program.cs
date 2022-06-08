using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace ImportExcels
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Vietsoft.Information.UserID = "Admin";
            Commons.Modules.UserName = "admin";
            Commons.Modules.ModuleName = "ECOMAIN";
            Commons.IConnections.Username = "sa";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Server = @".\SQL2017";
            Commons.IConnections.Database = "CMMS_REMINGTON";
            //Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString;
            //Vietsoft.Information.UserID = "admin";
            //Commons.IConnections.Password = "sa";
            //Commons.IConnections.Database = "123";
            Thread thread = new Thread(new ThreadStart(MRunForm));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static void MRunForm()
        {
            try
            {
                //Application.Run(new frmTest());
                Application.Run(new frmImportExcel());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
