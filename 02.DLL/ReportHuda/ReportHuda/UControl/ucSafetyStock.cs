using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.UControl
{
    public partial class ucSafetyStock : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSafetyStock()
        {
            InitializeComponent();
        }

        private void ucSafetyStock_Load(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", "");
            }
            catch { }

            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTThang.DateTime = Ngay.AddMonths(-6) ;
            datDThang.DateTime = Ngay.AddMonths(1).AddDays(-1);
            
            

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiVatTu", 1, Commons.Modules.TypeLanguage));
            try 
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiVT, dtTmp, "MS_LOAI_VT", "TEN_LOAI_VT", "");
            }
            catch { }

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetClassVatTu", 1));
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboClassVT, dtTmp, "MS_CLASS", "TEN_CLASS", "");
            }
            catch { }
           
        }
        private void LoadData()
        {
            string SQL, Union, BTam, sBTam, sLVTu, iKho, iClass, sThang, sThangNull, sThangAvg,sBTKho;

            sBTKho = "KHO_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.XoaTable(sBTKho);
            SQL = " SELECT     dbo.IC_KHO.MS_KHO, dbo.IC_KHO.TEN_KHO INTO " + sBTKho +
                        " FROM         dbo.IC_KHO INNER JOIN " +
                        "                       dbo.NHOM_KHO ON dbo.IC_KHO.MS_KHO = dbo.NHOM_KHO.MS_KHO INNER JOIN " +
                        "                       dbo.USERS ON dbo.NHOM_KHO.GROUP_ID = dbo.USERS.GROUP_ID " +
                        " WHERE     (dbo.USERS.USERNAME = '" + Commons.Modules.UserName + "' ) ";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            }
            catch { }


            DateTime TThang, DThang,TNgay,DNgay;
            TThang = Convert.ToDateTime("01/" + datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
            DThang = Convert.ToDateTime("01/" + datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);

            SQL = "";
            Union = "";
            BTam = "AAA_SAFETY" + Commons.Modules.UserName + " ";
            sBTam = " INTO " + BTam;



            Commons.Modules.ObjSystems.XoaTable(BTam);
            try
            {
                if (int.Parse(cboKho.EditValue.ToString()) == -1) iKho = ""; else iKho = " AND (DHX.MS_KHO = " + cboKho.EditValue.ToString() + ")  ";
            }
            catch { iKho = "";}
            try
            {
                if (cboLoaiVT.EditValue.ToString() == "-1") sLVTu = ""; else sLVTu = " AND (dbo.IC_PHU_TUNG.MS_LOAI_VT = N'" + cboLoaiVT.EditValue.ToString() + "') ";
            }
            catch {sLVTu = ""; }

            try
            {
                if (int.Parse(cboClassVT.EditValue.ToString()) == -1) iClass = ""; else iClass = " AND (dbo.IC_PHU_TUNG.MS_CLASS = " + cboClassVT.EditValue.ToString() + ")  ";
            }
            catch { iClass = "";}
            sThang = "";
            sThangNull = "";
            sThangAvg = "";
            int i = 0;
            for (DateTime Thang = TThang; Thang <= DThang; )
            {

                TNgay = Convert.ToDateTime("01/" + Thang.Month + "/" + Thang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);

                if (Commons.Modules.ObjSystems.KhoMoi)
                {
                    SQL = SQL + Union + " SELECT   '" + Thang.ToString("MM/yyyy") + "'  AS THANG, " +
                            " DHXVT.MS_PT, ISNULL(SUM(DHXVT.SO_LUONG_THUC_XUAT),0) - ISNULL(SUM(A.SL_TRA),0) AS SLUONG " + sBTam +
                            " FROM         dbo.PHIEU_BAO_TRI AS PBT INNER JOIN " +
                            " dbo.IC_DON_HANG_XUAT AS DHX ON PBT.MS_PHIEU_BAO_TRI = DHX.MS_PHIEU_BAO_TRI INNER JOIN " + sBTKho + " T1 ON DHX.MS_KHO = T1.MS_KHO INNER JOIN " +
                            " dbo.LOAI_BAO_TRI AS LBT ON PBT.MS_LOAI_BT = LBT.MS_LOAI_BT INNER JOIN " +
                            " dbo.HINH_THUC_BAO_TRI AS HTBT ON LBT.MS_HT_BT = HTBT.MS_HT_BT INNER JOIN " +
                            " dbo.IC_DON_HANG_XUAT_VAT_TU AS DHXVT ON DHX.MS_DH_XUAT_PT = DHXVT.MS_DH_XUAT_PT INNER JOIN " +
                            " dbo.IC_PHU_TUNG ON DHXVT.MS_PT = dbo.IC_PHU_TUNG.MS_PT LEFT OUTER JOIN " +
                            " (SELECT     dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT, SUM(dbo.IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) AS SL_TRA,  " +
                            " dbo.IC_DON_HANG_NHAP.MS_DHX " +
                            " FROM          dbo.IC_DON_HANG_NHAP INNER JOIN " +
                            " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT " +
                            " GROUP BY dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP, dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT, dbo.IC_DON_HANG_NHAP.MS_DHX " +
                            " HAVING      (dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP = 6)) AS A ON A.MS_PT = DHXVT.MS_PT AND DHXVT.MS_DH_XUAT_PT = A.MS_DHX " +
                            " WHERE     (HTBT.PHONG_NGUA = 0) AND DHX.NGAY >= '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                            " AND DHX.NGAY < DATEADD(day,1,'" + DNgay.ToString("MM/dd/yyyy") + "') " + iKho + sLVTu + iClass +
                            " GROUP BY DHX.MS_DANG_XUAT, DHXVT.MS_PT " +
                            " HAVING      (DHX.MS_DANG_XUAT = 1)  " +
                            " UNION SELECT   '" + Thang.ToString("MM/yyyy") + "'  AS THANG, " +
                            " DHXVT.MS_PT, ISNULL(SUM(DHXVT.SO_LUONG_THUC_XUAT),0)  AS SLUONG "  +
                            " FROM         dbo.IC_DON_HANG_XUAT AS DHX INNER JOIN " + sBTKho + " T1 ON DHX.MS_KHO = T1.MS_KHO INNER JOIN " +
                            " dbo.IC_DON_HANG_XUAT_VAT_TU AS DHXVT ON DHX.MS_DH_XUAT_PT = DHXVT.MS_DH_XUAT_PT INNER JOIN " +
                            " dbo.IC_PHU_TUNG ON DHXVT.MS_PT = dbo.IC_PHU_TUNG.MS_PT " +
                            " WHERE     DHX.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " + iKho + sLVTu + iClass +
                            " GROUP BY DHX.MS_DANG_XUAT, DHXVT.MS_PT " +
                            " HAVING      (DHX.MS_DANG_XUAT = 4)  ";
                }
                else
                {
                    SQL = SQL + Union + " SELECT   '" + Thang.ToString("MM/yyyy") + "'  AS THANG, " +
                            " DHXVT.MS_PT, ISNULL(SUM(DHXVT.SO_LUONG_THUC_XUAT),0) - ISNULL(SUM(A.SL_TRA),0) AS SLUONG " + sBTam +
                            " FROM dbo.PHIEU_BAO_TRI AS PBT INNER JOIN " +
                            " dbo.IC_DON_HANG_XUAT AS DHX ON PBT.MS_PHIEU_BAO_TRI = DHX.MS_PHIEU_BAO_TRI INNER JOIN " + sBTKho + " T1 ON DHX.MS_KHO = T1.MS_KHO INNER JOIN " +
                            " dbo.LOAI_BAO_TRI AS LBT ON PBT.MS_LOAI_BT = LBT.MS_LOAI_BT INNER JOIN " +
                            " dbo.HINH_THUC_BAO_TRI AS HTBT ON LBT.MS_HT_BT = HTBT.MS_HT_BT INNER JOIN " +
                            " dbo.IC_DON_HANG_XUAT_VAT_TU AS DHXVT ON DHX.MS_DH_XUAT_PT = DHXVT.MS_DH_XUAT_PT INNER JOIN " +
                            " dbo.IC_PHU_TUNG ON DHXVT.MS_PT = dbo.IC_PHU_TUNG.MS_PT LEFT OUTER JOIN " +
                            " (SELECT     dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT, SUM(dbo.IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) AS SL_TRA  " +
                            " FROM          dbo.IC_DON_HANG_NHAP INNER JOIN " +
                            " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT " +
                            " GROUP BY dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP, dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT " +
                            " HAVING      (dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP = 6)) AS A ON A.MS_PT = DHXVT.MS_PT " +
                            " WHERE     (HTBT.PHONG_NGUA = 0) AND DHX.NGAY >= '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                            " AND DHX.NGAY < DATEADD(day,1,'" + DNgay.ToString("MM/dd/yyyy") + "') " + iKho + sLVTu + iClass +
                            " GROUP BY DHX.MS_DANG_XUAT, DHXVT.MS_PT " +
                            " HAVING      (DHX.MS_DANG_XUAT = 1) AND (DHX.MS_DANG_XUAT = 4)";
                }
                sThang = sThang + " , [" + Thang.ToString("MM/yyyy") + "] ";
                sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yyyy") + "],0) AS [" + Thang.ToString("MM/yyyy") + "] ";
                sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yyyy") + "],0) ";

                i++;
                Thang = Thang.AddMonths(1);
                Union = " UNION ";
                sBTam = "";
            }
            

            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            }
            catch { }
            
            sThangAvg = " , ROUND( CONVERT(FLOAT, (" + sThangAvg.Substring(3, sThangAvg.Length - 3) + " ) / " + i + " ),2) AS AVARAGE "; 
            SQL = " ( SELECT MS_PT " + sThangNull +
                        " FROM ( SELECT * FROM " + BTam + " ) p " +
                        " PIVOT ( SUM(SLUONG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) + "  ) ) AS pvt) A ";


            SQL = " SELECT DISTINCT dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT_CTY, dbo.IC_PHU_TUNG.TEN_PT, " +
                        " dbo.IC_PHU_TUNG.QUY_CACH, CASE 0 WHEN 0 THEN dbo.DON_VI_TINH.TEN_1 " +
                        " WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT " + sThang + 
                        " ,CONVERT(FLOAT,0) AS AVARAGE , CONVERT(FLOAT,0) AS SDEV , ISNULL(dbo.SERVICE_LEVEL.SERVICE_LEVEL,0) AS SL, " +
                        " ISNULL(dbo.SERVICE_LEVEL.SERVICE_FACTOR,0) AS SF,  ISNULL(dbo.IC_PHU_TUNG.SO_NGAY_DAT_MUA_HANG,0) AS LT, " +
                        " CONVERT(FLOAT,0) AS SS , CONVERT(FLOAT,0) AS MIN_STOCK ,  ISNULL(dbo.IC_PHU_TUNG.TON_TOI_THIEU,0) AS TON_TOI_THIEU " +
                        " FROM dbo.IC_PHU_TUNG INNER JOIN dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT " +
                        " INNER JOIN " + SQL + " ON A.MS_PT = dbo.IC_PHU_TUNG.MS_PT  LEFT OUTER JOIN " +
                        " dbo.SERVICE_LEVEL  ON dbo.IC_PHU_TUNG.SERVICE_ID = dbo.SERVICE_LEVEL.SERVICE_ID " +
                        " ORDER BY dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.MS_PT_NCC ";



            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
            try
            {
                grvChung.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "MS_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT_NCC"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "MS_PT_NCC", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT_CTY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "MS_PT_CTY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "TEN_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["QUY_CACH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "QUY_CACH", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_DVT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "TEN_DVT", Commons.Modules.TypeLanguage);

                grvChung.Columns["AVARAGE"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "AVARAGE", Commons.Modules.TypeLanguage);
                grvChung.Columns["SDEV"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "SDEV", Commons.Modules.TypeLanguage);

                grvChung.Columns["SL"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "SL", Commons.Modules.TypeLanguage);

                grvChung.Columns["SF"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "SF", Commons.Modules.TypeLanguage);
                grvChung.Columns["LT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "LT", Commons.Modules.TypeLanguage);

                grvChung.Columns["SS"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "SS", Commons.Modules.TypeLanguage);


                grvChung.Columns["MIN_STOCK"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "MIN_STOCK", Commons.Modules.TypeLanguage);
                grvChung.Columns["TON_TOI_THIEU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSafetyStock", "TON_TOI_THIEU", Commons.Modules.TypeLanguage);
            }
            catch { }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DateTime TThang, DThang;

            if (cboKho.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return;
            }
            if (datTThang.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoTuThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return;
            }
            if (datDThang.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoDenThang", Commons.Modules.TypeLanguage));
                datDThang.Focus();
                return;
            }

            TThang = Convert.ToDateTime("01/" + datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
            DThang = Convert.ToDateTime("01/" + datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);
            if (TThang > DThang)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return;
            
            }
            int SoThang = MonthDiff(DThang,TThang) ;

            if (SoThang<1)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "LonHonMotThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return;

            }

            if (SoThang >24)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "LonHonHaiNam", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return;

            }

            if (cboLoaiVT.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoLoaiVatTu", Commons.Modules.TypeLanguage));
                cboLoaiVT.Focus();
                return;
            }
            if (cboClassVT.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoClassVatTu", Commons.Modules.TypeLanguage));
                cboClassVT.Focus();
                return;
            }



            LoadData();

            if (grvChung.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                grdChung.ExportToXlsx(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                excelApplication.Visible = false;
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSafetyStock", "TieuDe", Commons.Modules.TypeLanguage)                    
                    , Dong,4, "@", 16, true, Excel.XlHAlign.xlHAlignLeft,Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot-2);
                Dong++;

                string stmp = "";
                stmp = lblKho.Text + " : " + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot - 2);

                Dong++;
                stmp = lblTThang.Text + " : " + datTThang.Text + " " + lblDThang.Text + " : " + datDThang.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot - 2);

                Dong++;
                stmp = lblLoaiVT.Text + " : " + cboLoaiVT.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot - 2);

                Dong++;
                stmp = lblClassVT.Text + " : " + cboClassVT.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot - 2);
                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;

                for (int i = DongBD; i <= TDong + Dong + 2; i++)
                {
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "AVERAGE", i, TCot - 8 + 1, i, TCot - 8 + 1, i, 7, i, TCot - 8, 0, false, 10, "###,##0.00");
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "STDEV.P", i, TCot - 8 + 2, i, TCot - 8 + 2, i, 7, i, TCot - 8, 0, false, 10, "###,##0.00");

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, TCot -  2, i, TCot -  2);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(i, TCot - 8 + 2)  + "*" +
                        Commons.Modules.MExcel.TimDiemExcel(i, TCot - 8 + 4) + "* (SQRT(" + 
                        Commons.Modules.MExcel.TimDiemExcel(i, TCot - 8 + 5) + "/30))";

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, TCot - 1, i, TCot - 1);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(i, TCot - 7) + "*" +
                        Commons.Modules.MExcel.TimDiemExcel(i, TCot - 3) + "+" +
                        Commons.Modules.MExcel.TimDiemExcel(i, TCot - 2);
                }
                Dong++;
                Dong++;                
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 13, 16, 13 + TDong, 16);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong + 1, 6, TDong + Dong, 6);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "@", true, Dong , TCot - 5, Dong, TCot - 5);
                excelApplication.DisplayAlerts = false;
                for (int i = 7; i <= TCot; i++)
                {
                    if (i != (TCot - 5))
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "#,##0.00", true, Dong + 1, i, TDong + Dong, i);
                
                }
                excelWorkbook.Save();
                //excelWorkbook.SaveAs(sPath, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null);
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

            }
            catch (Exception ex)
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucSafetyStock", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) // at least one time
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
