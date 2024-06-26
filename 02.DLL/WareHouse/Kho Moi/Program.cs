using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using WareHouse;
using System.Diagnostics;

namespace WareHouse
{
     static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Exit();
            Commons.Modules.UserName = "admin";
            //Commons.Modules.UserName = "ducbpm";
            //Commons.Modules.UserName = "B0001";
            //Commons.IConnections.Server = "27.74.240.29,1435";
            //Commons.IConnections.Server = ".";
            //Commons.IConnections.Server = ".\\SQL2008";
            Commons.IConnections.Server = @"27.74.240.29,1434";
            //Commons.IConnections.Server = "10.39.244.200";
            Commons.IConnections.Password = "codaikadaiku";
            Commons.IConnections.Username = "sa";
            //Commons.IConnections.Password = "123";
            //Commons.IConnections.Database = "CMMS_NUTIFOOD";
            //Commons.IConnections.Database = "CMMS_VH";
            Commons.IConnections.Database = "CMMS_NUTIFOOD";
            Commons.Modules.ModuleName = "ECOMAIN";
            Vietsoft.Information.UserID = Commons.Modules.UserName;
            Vietsoft.Information.ModuleName = Commons.Modules.ModuleName;
            Commons.Modules.TypeLanguage = 0;
            Commons.Modules.iDefault = 1;
            Vietsoft.Information.ConnectionString = @"Data Source=" + Commons.IConnections.Server +
                ";Initial Catalog=" + Commons.IConnections.Database +
                ";User ID=" + Commons.IConnections.Username + ";Pwd=" + Commons.IConnections.Password;
            Commons.Modules.iSoLeSL = 2;
            Commons.Modules.iSoLeDG = 2;
            Commons.Modules.iSoLeTT = 2;
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
            Commons.Modules.sPrivate = "NUTIFOOD";
            Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com";
            Commons.Modules.sMailFromPass = "Vietsoft@123";
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            Commons.Modules.sMailFromPort = "587";
            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.bSSL = true;
            Commons.Modules.bCNDXDuyet = true;
            Commons.Modules.bDoiFontReport = true;
            Commons.Modules.sFontReport = "Monotype Corsiva";
            Commons.Modules.sFontReport = "Tahoma";
            Commons.Modules.iTRFData = 0;
            //Commons.Modules.sTenNhanVienMD = "HUỲNH TRUNG HIẾU";
            //Commons.Modules.sMaNhanVienMD = "B0001";
            //Commons.Modules.PermisString = "READ ONLY";
            Commons.Modules.PermisString = "Full access";
            //Commons.Modules.PermisString = "RE ACCESS";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread thread = new Thread(new ThreadStart(RunForm));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static void RunForm()
        {
            try
            {
                //Application.Run(new WareHouse.Forms.XtraForm1());
                //Application.Run(new frmDeXuatMuaHang_New());
                Application.Run(new frmPhieuNhapKho_New());
                //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Blue";
                //Application.Run(new frmPhieuNhapKho_New());
                //Application.Run(new frmChonPTNhapTra());
                //Application.Run(new frmPhieuNhapKho_New());
                //Application.Run(new frmGoodreceive());
                //Application.Run(new frmGoodreturn());
                //Application.Run(new frmPhieuNhapKho_New());
                //Application.Run(new frmDonDatHang_New());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static bool IsAlreadyRunning()
        {
            System.Diagnostics.Process[] ieProcs = Process.GetProcessesByName("WareHouse");

            if (ieProcs.Length > 0)
                return true;
            else
                return false;
        }
    }
}