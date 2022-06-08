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
            Commons.Modules.UserName = "Administrator";
            //Commons.Modules.UserName = "trungnv";
            //Commons.Modules.UserName = "trungnv";
            Commons.Modules.TypeLanguage = 0;
            //Commons.Modules.sPrivate = "BARIA";
            //Commons.Modules.sPrivate = "CS";
            //Commons.IConnections.Server = "DELL-PC\\SQL2008R2";
            //Commons.IConnections.Database = "CMMS_ECOMAINT_KM";
            //Commons.IConnections.Password = "123";
            //Commons.IConnections.Username = "sa";

            //Commons.IConnections.Database = "CMMS_BARIA";
            //Commons.IConnections.Database = "CMMS_SHISEIDO";
            Commons.IConnections.Server = ".";
            //Commons.IConnections.Server = "MASHILOVE\\SQL2014";
            
            Commons.IConnections.Database = "CMMS_GREENFEED";
            Commons.IConnections.Database = "CMMS_ADC";
            Commons.IConnections.Database = "CMMS_BARIA";
            //Commons.IConnections.Database = "CMMS_GF";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";

            Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com";
            Commons.Modules.sMailFromPass = "Vietsoft@123";
            Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            Commons.Modules.sMailFromPort = "587";

            Commons.Modules.ObjSystems.KhoMoi = true;
            //Commons.Modules.sMailFrom = "svi.noreply@shiseido.vn";
            //Commons.Modules.sMailFromPass = "sv@00000";
            //Commons.Modules.sMailFromSmtp = "smtp.office365.com";

            //Commons.Modules.bDoiFontReport = true;
            Commons.Modules.sFontReport = "Monotype Corsiva";


            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.bSSL = true;
            Commons.Modules.sMaNhanVienMD = "1753";
            //Commons.IConnections.Server = "192.168.200.57";
            //Commons.IConnections.Database = "CMMS_GREENFEED";
            //Commons.IConnections.Password = "P@ssw0rd1";
            //Commons.IConnections.Username = "sa";

//            nhattc@vietsoft.com.vn

//nhattc@2014

            Commons.Modules.iSoLeSL = 1;
            Commons.Modules.iSoLeDG = 2;
            Commons.Modules.iSoLeTT = 3;

            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Commons.Modules.ObjSystems.KhoMoi = false;
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
                //Application.Run(new Form1());
                //Application.Run(new frmTaoKHTT());
                //Application.Run(new frmChonVTINTPBT());
                //Application.Run(new frmChonVTRequestPBT());
                Application.Run(new frmPhatSinhDichVu());
                //Application.Run(new frmChonPSDV());

                //Application.Run(new frmPhanTichNNNMTheoNN());
                //frmDeNghiVatTuBHS frm = new frmDeNghiVatTuBHS();
                //frm.sMsPBT = "PBT02-11102";
                //frm.dNgayBDKH = DateTime.Parse("21/08/2014");
                //frm.ShowDialog();

                //Application.Run(new frmUserLogin());
                //Application.Run(new Form1());
                //Application.Run(new frmAllocateNhapTra());

                //Application.Run(new frmTinhHinhXuatKhoSoVoiDauKy());
                //Application.Run(new frmThongKeNhapTheoKH());

                //frmMergeCongViec frm = new frmMergeCongViec();
                //frm.sMsLMay = "VP";
                //frm.iMsCV = 1955;
                //frm.sTenCV = "Thay tress";
                //frm.ShowDialog();

                //frmChonVTINTPBT frm = new frmChonVTINTPBT();
                //frm.iLoaiForm = 0;
                ////frm.sMay = "10-01-OFF-013-00";
                ////frm.sPBT = "WO-201510000003";
                //frm.ShowDialog();  

                //Application.Run(new frmTinhHinhTonKho());
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
