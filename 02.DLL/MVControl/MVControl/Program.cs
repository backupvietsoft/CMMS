using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace MVControl
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
            //Commons.IConnections.Server = @"10.39.244.220\sql2008";
            Commons.IConnections.Database = "CMMS_REMINGTON";
            //Commons.IConnections.Database = "CMMS_VH";
            Commons.IConnections.Server = "27.74.240.29,1433";
            Commons.IConnections.Password = "codaikadaiku";
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
            Commons.IConnections.Username = "sa";
            //Commons.IConnections.Database = "CMMS_demo";
            //Commons.IConnections.Server = ".";
            //Commons.IConnections.Server = ".\\sql2017";
            //Commons.IConnections.Server = "10.39.244.200";

            Vietsoft.Information.UserID = Commons.Modules.UserName;
            Vietsoft.Information.ModuleName = Commons.Modules.ModuleName;
            Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.sPrivate = "VINHHOAN";
            //Commons.Modules.sPrivate = @"ADC";
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
            Commons.Modules.iPBTTheoGio = 2;
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
                //Application.Run(new frmTGNM());
                Application.Run(new Form1());
                //Application.Run(new frmThoigianngungmayNEW());
                //Application.Run(new frmBaoCaoChiPhi());
                //Application.Run(new frmQuanlynhanvien());
                //Application.Run(new frmKiemKeKho());
                //Application.Run(new frmThoigianchaymay());
                //Application.Run(new frmChonMay());
                //Application.Run(new frmChonNhanSu());
                //Application.Run(new frmGiamSatTinhTrangNew());
                //Application.Run(new frmNhomDieuDo());
                //Application.Run(new frmDanhmuccongviec());
                //Application.Run(new frmNgayNghiTheoNhaXuong());
                //Application.Run(new frmDanhMucHeThong());
                //Application.Run(new frmBaoTri());
                //Application.Run(new frmQuanlynhanvien());
                //Application.Run(new frmKeHoachCongViec());
                //Application.Run(new frmThoigianchaymay());
                //Application.Run(new frmAddCM_BT());
                //frmShowThongTinYCNSD FRM = new frmShowThongTinYCNSD();
                //FRM.STT = "2520";
                //FRM.MS_MAY = "10-05-GBA-002-00";
                //FRM.StartPosition = FormStartPosition.CenterScreen;
                //FRM.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
