using System;
using System.Windows.Forms;
using System.Threading;
using ReportMain.Forms;

namespace ReportMain
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
            //Commons.Modules.UserName = "007635";
            Commons.Modules.PermisString = "Full access";
            //Commons.Modules.UserName = "svi1310278";
            Commons.Modules.TypeLanguage = 0;
            //Commons.IConnections.Server = "10.39.244.220";
            // Commons.IConnections.Server = "10.39.244.219";
            Commons.IConnections.Server = ".\\sql2017";
            Commons.IConnections.Server = ".";
            Commons.IConnections.Server = ".\\sql2016";
            //Commons.IConnections.Database = "CMMS_PILMICO";
            //Commons.IConnections.Database = "CMMS_GREENFEED";
            Commons.IConnections.Database = "CMMS_VS";
            //Commons.IConnections.Database = "CMMS_REMINGTON";
            Commons.IConnections.Password = "123";
            Commons.IConnections.Username = "sa";
            //   Commons.IConnections.Password = "Veco@2015";
            //Commons.IConnections.Server = "172.16.5.50";
            //Commons.IConnections.Password = "Pil@2018";
            //Commons.IConnections.Username = "sa";
            //Commons.IConnections.Database = "CMMS_PILMICO";

            //Commons.Modules.sMailFrom = "thunv@trungnguyenlegend.com";
            //Commons.Modules.sMailFromPass = "ba@00000000";
            //Commons.Modules.sMailFromSmtp = "SMTP.office365.com";
            //Commons.Modules.sMailFromPort = "587";

            //Commons.Modules.sMailFrom = "ecomaint@veco.vn";
            //Commons.Modules.sMailFromPass = "P@ssword123456";
            //Commons.Modules.sMailFromSmtp = "smtp.gmail.com";
            //Commons.Modules.sMailFromPort = "25";

            //canh.huynhhao@veco.vn

            Commons.Modules.iLoaiGoiMail = 1;
            Commons.Modules.sDDanMail = @"E:\Public";
            Commons.Modules.bSSL = true;

            Commons.Modules.sDDanMail = @"E:\Public";
            //Commons.Modules.sPrivate = @"ADC";
            //Commons.Modules.sPrivate = @"VINHHOAN";
            //Commons.Modules.sPrivate = @"VECO";
            //Commons.Modules.sPrivate = "VINHHOANG";
            //Commons.Modules.sPrivate = "VIETSOFT";
            Commons.Modules.sPrivate = "VIFON";


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


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Commons.Modules.ObjSystems.KhoMoi = false;
            Thread thread = new Thread(new ThreadStart(MRunForm));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static void MRunForm()
        {
            try
            {

                Application.Run(new XtraForm1());
                //Application.Run(new frmPhieuTamXuatTaiNhap());
                //Application.Run(new frmYeuCauCuaNSD());
                //frmThemCongViec frm = new frmThemCongViec();
                //frm.sMsMay = "HAM-0006";
                //frm.sMsBoPhan = "01.01.02";
                //frm.sTenBoPhan = "01.01.02";
                //frm.ShowDialog();

                //frmPBTBanHanh frm = new frmPBTBanHanh();
                //frm.iLoai = 1;
                //frm.MsPBT = "WO-201508000004";
                //frm.sNXuong = "X2";
                //frm.ShowDialog();

                //frmChonPhuTungcho_PBT frm = new frmChonPhuTungcho_PBT();
                //frm.MS_CVBT = "45902";
                //frm.MS_PHIEU_BAO_TRI = "WO-201611001281";
                //frm.MS_MAY = "PES-1501";
                //frm.ShowDialog();

                //Application.Run(new frmPBTHinh());
                //////Application.Run(new frmImportExcel());
                //Application.Run(new frmChonMay());

                ////ROW_NUMBER() OVER (ORDER BY A.MS_MAY ASC)
                ////string sSql = "SELECT CONVERT(INT,NULL) AS STT , A.MS_MAY ,B.TEN_MAY, A.TEN_LOAI_BT,  NGAY_CUOI, A.NGAY_BTKT, A.TGCM, A.TGCM_HIEN_TAI, A.TEN_NHOM_MAY FROM         dbo.KHTT_IN_TMPadmiN AS A INNER JOIN dbo.MAY AS B ON A.MS_MAY = B.MS_MAY ORDER BY A.MS_MAY";
                ////System.Data.DataTable dtTmp = new System.Data.DataTable();
                ////dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,System.Data.CommandType.Text,sSql));

                ////clsKHBTDinhKyKHTT.InKHBT(dtTmp,"frmKehoachtongthe_odd");

                ////ReportMain.frmTimMay frm = new ReportMain.frmTimMay();
                ////frm.iLoaiBC = 98;
                ////frm.iKeHoachNam = 2014;
                ////frm.iKeHoachThang = 10;

                ////frm.ShowDialog();

                ////Application.Run(new frmVatTuPhuTung());

                ////ReportMain.frmCopyPhanQuyen frm = new ReportMain.frmCopyPhanQuyen();
                ////frm.iLoai = 9;
                ////frm.sDataGoc = "1";
                ////frm.ShowDialog();

                ////ReportMain.frmInKHTT frm = new ReportMain.frmInKHTT();
                ////frm.iLoai = 3;
                ////frm.NamThang = Convert.ToDateTime("01/01/2014");
                ////frm.ShowDialog();

                ////Application.Run(new frmTimPBT());
                //Application.Run(new frmKhuVucGioiHan());
                ////Application.Run(new frmTimMay());
                ////Application.Run(new frmTimMayTTTB());
                //Application.Run(new frmTimNhanVien());

                //Application.Run(new frmChonInPhieuBaoTri());

                ////ReportMain.frmChonVTPTCongViec frm = new ReportMain.frmChonVTPTCongViec();
                ////frm.sMsMay = "CLF100-01";
                ////frm.iMsLBTri = 8;
                ////frm.dtCongViec  = new System.Data.DataTable();
                ////frm.sBangTam = "MLBTPNCVPTAdministrator";
                ////frm.dtCongViec.Load((Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                ////    "GetMAY_LOAI_BTPN_CONG_VIEC", frm.sMsMay, frm.iMsLBTri)));
                ////frm.ShowDialog();

                ////Application.Run(new frmReport());
                //Application.Run(new frmYeuCauCuaNSD());
                ////ReportMain.Forms.frmYCSDChonMay frm = new ReportMain.Forms.frmYCSDChonMay();
                ////frm.iLoai = 6;
                ////frm.ShowDialog();

                ////ReportMain.Forms.frmYCSDChonMay frm = new ReportMain.Forms.frmYCSDChonMay();
                ////frm.iLoai = 5;
                ////frm.ShowDialog();

                ////ReportMain.frmTimVTPT frm = new ReportMain.frmTimVTPT();
                ////frm.iLoaiBC = 1;
                ////frm.sMsPT = "BEA-0024";
                ////frm.sMsPTTraVe = "BEA-0025,BEA-0026,BEA-0027,BEA-0028,BEA-0442";
                ////frm.ShowDialog();
                //ReportMain.frmYeuCauCuaNSD frm = new ReportMain.frmYeuCauCuaNSD();
                //frm.dtPhieuBaoTri = new System.Data.DataTable();
                //frm.dtPhieuBaoTri.Load((Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                //    "S_PHIEU_BAO_TRI_NEW", "administrator", "06-26-2016", "12-16-2017", 
                //    0, "-1", "-1", "-1", "-1",
                //    -1,-1,"-1", "-1",-1, null, 0)));

                //frm.sNguoiLap = "sNguoiLap";
                //frm.sNgayLap = "01/01/2012";
                //frm.ssDiaDiem = "ssDiaDiem";
                //frm.sDayChuyen = "sDayChuyen";
                //frm.sLyDo = "sLyDo";
                //frm.ShowDialog();
                //ReportMain.Forms.frmChonKhoInDMTB frm = new ReportMain.Forms.frmChonKhoInDMTB();
                //frm.iLBCao = 2;
                //frm.sMsPBT = "WO-201812000034";
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
