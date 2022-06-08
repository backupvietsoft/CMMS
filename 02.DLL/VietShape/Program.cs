
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VietShape
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            Commons.Modules.UserName = "admin";
            Commons.Modules.TypeLanguage = 0;
            //Commons.IConnections.Server = "192.168.2.40";
            //Commons.IConnections.Server = ".\\SQL2014";
            Commons.IConnections.Database = "CMMS_TN";
            //Commons.IConnections.Database = "CMMS_VF";
            //Commons.IConnections.Database = "CMMS_DEMO";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";
            Commons.Modules.sFontReport = "Tahoma";
            Commons.Modules.ModuleName = "ECOMAIN";
            Commons.Modules.sPrivate = "TRUNGNGUYEN";
            Commons.Modules.sPrivate = "VINAONE";
            //Commons.IConnections.Server = ".\\sql2008";
            //Commons.IConnections.Server = ".";
            Commons.IConnections.Server = ".\\sql2017";

            //Commons.IConnections.Database = "CMMS_dd";
            //Commons.IConnections.Database = "CMMS_GREENFEED";
            //Commons.IConnections.Server = "10.39.244.216";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(LaunchForm));
            thread.SetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
        }

        public static void LaunchForm()
        {
            //Application.Run(new frmDDNhom());
            Application.Run(new XtraForm1());
            //Application.Run(new frmDDNhomCNhan());
            //Application.Run(new frmViewLog());
            //Application.Run(new frmNNgu());
            //Application.Run(new frmDDNhanLuc());
            //Application.Run(new frmDDChart());
            //Application.Run(new frmDieuDo());
            //Application.Run(new frmChiTietCongViec());
            //Application.Run(new XtraForm1());
            //Application.Run(new XtraShape());
            //Application.Run(new frmDashBoard());
            //frmChonPTTuBoPhan frm = new frmChonPTTuBoPhan();
            //frm.MS_MAY = "70.010";
            //frm.ShowDialog();


        }
    }
}
