using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain.UAC
{
    public partial class ucBCPhuTungDGCuoi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCPhuTungDGCuoi()
        {
            InitializeComponent();
        }

        private void ucBCPhuTungDGCuoi_Load(object sender, EventArgs e)
        {
            TaoLuoi();
        }
        private void TaoLuoi()
        {
            string sTmp;
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "KhongKho", Commons.Modules.TypeLanguage);
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,0) AS CHON, MS_KHO, TEN_KHO, 1 AS CO_KHO FROM IC_KHO  " +
                    "UNION SELECT CONVERT(BIT,0), '-1', N'" + sTmp + "' , 0 AS CO_KHO ORDER BY CO_KHO,TEN_KHO"));

            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, true,true,"ucBCPhuTungDGCuoi");
            
            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvBC.Columns["MS_KHO"].Visible = false;
            grvBC.Columns["CO_KHO"].Visible = false;
            grvBC.Columns["CHON"].Width = 150;
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }
        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("ZZZ_PTDGC" + Commons.Modules.UserName);
            ParentForm.Close();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp1 = new DataTable();
            DataTable dtTmp = new DataTable();
            dtTmp = new DataTable();

            dtTmp1 = (DataTable)grdBC.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "ChuaChonDuLieu", Commons.Modules.TypeLanguage), this.ParentForm.Text , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string sSql, sTenKho;
            Boolean bKKho = false;

            sTenKho = "";
            for (int i = 0; i < dtTmp.Rows.Count; i++)
            {
                sTenKho += (sTenKho == "" ? "" : "; ") + dtTmp.Rows[i]["TEN_KHO"].ToString();
                if (dtTmp.Rows[i]["MS_KHO"].ToString() == "-1") bKKho = true;
            }
            sSql = "ZZZ_PTDGC" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

            sSql = " SELECT DISTINCT CONVERT(INT,NULL) AS STT, X.MS_DON_DAT_HANG, X.SO_DON_DAT_HANG, X.NGUOI_LAP, X.NHA_CUNG_CAP, Y.MS_PT, Z.TEN_PT, " +
                    " Z.QUY_CACH, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT, " +
                    " Y.DON_GIA, Y.NGOAI_TE, X.GHI_CHU FROM (SELECT A.* FROM DON_DAT_HANG A  " +
                    " INNER JOIN (SELECT MS_DON_DAT_HANG , MAX(NGAY_LAP) AS NL_MAX FROM DON_DAT_HANG " +
                    " GROUP BY MS_DON_DAT_HANG ) B ON A.MS_DON_DAT_HANG = B.MS_DON_DAT_HANG AND A.NGAY_LAP = B.NL_MAX ) " +
                    " AS X INNER JOIN dbo.DON_DAT_HANG_CHI_TIET AS Y ON X.MS_DON_DAT_HANG = Y.MS_DON_DAT_HANG INNER JOIN " +
                    " dbo.IC_PHU_TUNG AS Z ON Y.MS_PT = Z.MS_PT LEFT OUTER JOIN dbo.IC_KHO AS W ON X.MS_KHO = W.MS_KHO " +
                    " INNER JOIN " + sSql + " K ON W.MS_KHO = K.MS_KHO INNER JOIN dbo.DON_VI_TINH AS L ON Z.DVT = L.DVT ";
            if (bKKho )
                sSql += " UNION SELECT DISTINCT CONVERT(INT,NULL) AS STT, X.MS_DON_DAT_HANG, X.SO_DON_DAT_HANG, X.NGUOI_LAP, X.NHA_CUNG_CAP, Y.MS_PT, Z.TEN_PT, " +
                        " Z.QUY_CACH, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT, " +
                        " Y.DON_GIA, Y.NGOAI_TE, X.GHI_CHU FROM (SELECT A.* FROM DON_DAT_HANG A  " +
                        " INNER JOIN (SELECT MS_DON_DAT_HANG , MAX(NGAY_LAP) AS NL_MAX FROM DON_DAT_HANG " +
                        " GROUP BY MS_DON_DAT_HANG ) B ON A.MS_DON_DAT_HANG = B.MS_DON_DAT_HANG AND A.NGAY_LAP = B.NL_MAX ) " +
                        " AS X INNER JOIN dbo.DON_DAT_HANG_CHI_TIET AS Y ON X.MS_DON_DAT_HANG = Y.MS_DON_DAT_HANG INNER JOIN " +
                        " dbo.IC_PHU_TUNG AS Z ON Y.MS_PT = Z.MS_PT INNER JOIN dbo.DON_VI_TINH AS L ON Z.DVT = L.DVT " +
                        " WHERE ISNULL(MS_KHO,'') = '' " ;

            sSql += " ORDER BY X.MS_DON_DAT_HANG, X.SO_DON_DAT_HANG, X.NGUOI_LAP, X.NHA_CUNG_CAP, Y.MS_PT, Z.TEN_PT ";
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            Commons.Modules.ObjSystems.XoaTable("ZZZ_PTDGC" + Commons.Modules.UserName);
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }



            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.ParentForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "ucBCPhuTungDGCuoi");
            
            InDuLieu(sTenKho);
            Commons.Modules.ObjSystems.XoaTable("ZZZ_PTDGC" + Commons.Modules.UserName);
        }

        private void InDuLieu(string sTenKho)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : TCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "Kho", Commons.Modules.TypeLanguage) + " : " + sTenKho;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Excel.Range title;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                //5	14	14	13	25	13	28	35	10	12	10	20

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 3, TDong + Dong, 3);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 4, TDong + Dong, 4);


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 28, "@", true, Dong + 1, 7, TDong + Dong, 7);


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 35, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 12, TDong + Dong, 12);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlApp.Visible = true;
                xlWorkBook.Save();
                xlApp.DisplayAlerts = false;

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBCPhuTungDGCuoi", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

    }
}
