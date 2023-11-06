using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace ReportHuda
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
            Commons.Modules.UserName = "binh_1078";
            //Commons.Modules.UserName = "ngannv";
            Commons.Modules.TypeLanguage = 0;
            Commons.Modules.sPrivate = "TRUNGNGUYEN";
            Commons.Modules.sPrivate = "REMINGTON";
            //Commons.Modules.sPrivate = "GREENFEED";
            //Commons.IConnections.Server = @"10.39.244.219\sql2008";
            //Commons.IConnections.Server = @".";

            //Commons.Modules.sExcelTemp = "0";
            Commons.IConnections.Database = "CMMS_BARIA_NEW";
            Commons.IConnections.Server = ".\\sql2017";

            Commons.IConnections.Server = "27.74.240.29,1435";
            Commons.IConnections.Server = "27.74.240.29";
            Commons.IConnections.Server = ".";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";

            //Commons.IConnections.Database = "CMMS_GREENFEED";
            //Commons.IConnections.Database = "CMMS_VF";
            Commons.Modules.sMailFrom = "bamboo271196@gmail.com";
            Commons.Modules.sMailFromPass = "esupavujyhakbxrd";
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            Commons.Modules.sMailFromPort = "587";

            Commons.Modules.ObjSystems.KhoMoi = true;
            Commons.Modules.bDoiFontReport = false;
            Commons.Modules.sFontReport = "Monotype Corsiva";

            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.bSSL = true;
            Commons.Modules.sMaNhanVienMD = "1753";
            Commons.Modules.iSoLeSL = 0;
            Commons.Modules.iSoLeDG = 0;
            Commons.Modules.iSoLeTT = 0;
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Commons.Modules.ObjSystems.KhoMoi = true;
            Commons.Modules.sTenNhanVienMD = "sadasd sada asd a";
            Commons.Modules.iDefault = 1;
            Commons.Modules.iPBTTheoGio = 1;
            Thread thread = new Thread(new ThreadStart(MRunForm));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static void MRunForm()
        {
            try
            {
                Application.Run(new Form1());
                //Application.Run(new frmPhatSinhDichVu());
                //Application.Run(new frmPhanQuyenDVPS());
                //Application.Run(new frmTaoKHTT());
                //Application.Run(new frmChonVTINTPBT());
                // Application.Run(new frmPhatSinhDichVu());
                //Application.Run(new frmChonPSDV());
                //frmDeNghiVatTuBHS frm = new frmDeNghiVatTuBHS();
                //frm.sMsPBT = "PBT02-11102";
                //frm.dNgayBDKH = DateTime.Parse("21/08/2014");
                //frm.ShowDialog();

                //Application.Run(new frmUserLogin());

                //Application.Run(new frmAllocateNhapTra());

                //Application.Run(new frmTinhHinhXuatKhoSoVoiDauKy());
                //Application.Run(new frmThongKeNhapTheoKH());

                //frmTaoKHTT frm = new frmTaoKHTT();
                //frm.sMsMay = "10-01-OCO-005-00";
                //frm.sNVien = "1753";
                //frm.ShowDialog();
                //Application.Run(new frmChonVTRequestPBT());

                //frmChonVTINTPBT frm = new frmChonVTINTPBT();
                //frm.iLoaiForm = 0;
                //frm.sMay = "ACI-01-01-01";
                //frm.sPBT = "WO-201810000001";
                //frm.ShowDialog();


                //Application.Run(new General.frmFactoryStatistical());
                //Application.Run(new General.frmMaterialStatistical());

                //Application.Run(new General.frmTimVT());
                //Application.Run(new General.frmChonMay());

                //General.frmMaterialStatistical FRM = new General.frmMaterialStatistical();
                //FRM.ms_thiet_bi = "MLA-MI-003";
                //FRM.ShowDialog ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private static frmMergeCongViec frmMergeCongViec()
        //{
        //    throw new NotImplementedException();
        //}



    }
}
