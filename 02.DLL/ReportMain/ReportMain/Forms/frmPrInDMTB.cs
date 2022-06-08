using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmPrInDMTB : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtPrInDMTB = new DataTable();
        public string sTenKho, sMsPBT;

        public frmPrInDMTB()
        {
            InitializeComponent();
        }

        private void frmPrInDMTB_Load(object sender, EventArgs e)
        {
            grdChung.Visible = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtPrInDMTB, true, true, true, true, true, "frmTonKhoTheoPBT");

            if (Commons.Modules.sPrivate == "PILMICO")
            {
                grvChung.Columns["MS_PT_CTY"].Visible = false;
                grvChung.Columns["QUY_CACH"].Visible = false;

            }


        }
        private void InDuLieuTonKhoTheoPBT(string sTenKho)
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
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : TCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                string MsMay, MsPBT, SoPhieu, TenMay, LoaiBTri, NgayBDKH;

                MsMay = "";
                MsPBT = "";
                SoPhieu = "";
                TenMay = "";
                LoaiBTri = "";
                NgayBDKH = "";


                DataTable dtTmp = new DataTable();

                stmp = " SELECT TOP 1 ISNULL(A.MS_MAY, '') AS MS_MAY, ISNULL(A.MS_PHIEU_BAO_TRI, '') AS MS_PHIEU_BAO_TRI, " +
                            " ISNULL(A.SO_PHIEU_BAO_TRI, '') AS SO_PHIEU_BAO_TRI, ISNULL(B.TEN_MAY, '') AS TEN_MAY,  " +
                            " ISNULL(C.TEN_LOAI_BT, '') AS TEN_LOAI_BT, ISNULL(A.NGAY_BD_KH, '') AS NGAY_BD_KH " +
                            " FROM dbo.PHIEU_BAO_TRI AS A INNER JOIN dbo.MAY AS B ON A.MS_MAY = B.MS_MAY INNER JOIN " +
                            " dbo.LOAI_BAO_TRI AS C ON A.MS_LOAI_BT = C.MS_LOAI_BT " +
                            " WHERE     (A.MS_PHIEU_BAO_TRI = N'" + sMsPBT + "') ";
                try
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, stmp));
                    MsMay = dtTmp.Rows[0]["MS_MAY"].ToString();
                    MsPBT = dtTmp.Rows[0]["MS_PHIEU_BAO_TRI"].ToString();
                    SoPhieu = dtTmp.Rows[0]["SO_PHIEU_BAO_TRI"].ToString();
                    TenMay = dtTmp.Rows[0]["TEN_MAY"].ToString();
                    LoaiBTri = dtTmp.Rows[0]["TEN_LOAI_BT"].ToString();
                    NgayBDKH = DateTime.Parse(dtTmp.Rows[0]["NGAY_BD_KH"].ToString()).ToShortDateString();
                }
                catch { }



                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "MsMay", Commons.Modules.TypeLanguage) + " : " + MsMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "MsPBT", Commons.Modules.TypeLanguage) + " : " + MsPBT;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "SoPhieu", Commons.Modules.TypeLanguage) + " : " + SoPhieu;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "TenMay", Commons.Modules.TypeLanguage) + " : " + TenMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "LoaiBTri", Commons.Modules.TypeLanguage) + " : " + LoaiBTri;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "NgayBDKH", Commons.Modules.TypeLanguage) + " : " + NgayBDKH;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "Kho", Commons.Modules.TypeLanguage) + " : " + sTenKho;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);



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
                


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 28, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "#,##0", true, Dong + 1, 6, TDong + Dong, 11);



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
                    "frmTonKhoTheoPBT", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            InDuLieuTonKhoTheoPBT(sTenKho);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}