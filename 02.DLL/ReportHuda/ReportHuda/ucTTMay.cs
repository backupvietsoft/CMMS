using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

using Commons.VS.Classes.Admin;
using Commons.VS.Classes.Catalogue;

using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using Commons;
using DevExpress.XtraCharts;


namespace ReportHuda
{
    public partial class ucTTMay : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucTTMay";

        DataTable dtTmp = new DataTable();
        public ucTTMay()
        {
            InitializeComponent();
        }
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1"), "MS_N_XUONG", "TEN_N_XUONG", "");
            }
            catch { }
        }
        private void LoadDChuyen()
        {
            try
            {

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", "");
            }
            catch { }
        }
        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }
        private void ucTTMay_Load(object sender, EventArgs e)
        {
            dtTmp = new DataTable();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNX();


            try
            {
                //dtTmp = ((DataTable)grdMay.DataSource).Copy();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTTMay"));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, false  , true, true, true,true, sBC);
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvMay, sBC);
                //grvMay.Columns["thong_tin_chi_tiet"].Width = 450;
                //grvMay.Columns["thong_tin_chi_tiet"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucTTMay", "thong_tin_chi_tiet", Commons.Modules.TypeLanguage);

            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
        }

     
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboLMay_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            dtTmp = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            string sSql = "-1";
            if (chkTTBT.GetItemChecked(0))
                sSql = sSql + " OR STT = 1 ";
            if (chkTTBT.GetItemChecked(1))
                sSql = sSql + " OR STT = 2 ";
            if (chkTTBT.GetItemChecked(2))
                sSql = sSql + " OR STT = 3 ";


            this.Cursor = Cursors.Default;


            InDuLieu();
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvMay.Columns.Count;
                int TDong = grvMay.RowCount;
                int Dong = 1;

                //prbIN.Visible = true;
                //prbIN.Position = 0;
                //prbIN.Properties.Step = 1;
                //prbIN.Properties.PercentView = true;
                //prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                //prbIN.Properties.Minimum = 0;



                grdMay.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;

                SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sTieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                Dong++;
                string stmp = "";
                //stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString(oldCultureInfo.DateTimeFormat.ShortDatePattern) + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString(oldCultureInfo.DateTimeFormat.ShortDatePattern);
                //Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                //         Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion

                stmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);
                Dong++;

                stmp = lblLoaiMay.Text + " : " + cboLoaiMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);
                Dong++;

                stmp = lblDDiem.Text + " : " + cboDDiem.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion


                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion


                Dong++;

                stmp = "";
                if (chkTTBT.GetItemChecked(0))
                    stmp = stmp + " - " + chkTTBT.GetItemText(0);
                if (chkTTBT.GetItemChecked(1))
                    stmp = stmp + " - " + chkTTBT.GetItemText(1);
                if (chkTTBT.GetItemChecked(2))
                    stmp = stmp + " - " + chkTTBT.GetItemText(2);




                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong+=5;


                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion



                //5	14	16	25	20	20	20	20	20	25	18	10	10	14	25	30
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong + 1, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 1, 3, TDong + Dong, 3);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "dd/MM/yyyy", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "dd/MM/yyyy", true, Dong + 1, 5, TDong + Dong, 9);

                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 10, TDong + Dong, 10);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 1, 11, TDong + Dong, 11);

                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 12, TDong + Dong, 13);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 14, TDong + Dong, 14);

                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 15, TDong + Dong, 15);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 16, TDong + Dong, 16);

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion


                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                //prbIN.Position = prbIN.Properties.Maximum;
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
            //prbIN.Position = prbIN.Properties.Maximum;
        }
    }
}
