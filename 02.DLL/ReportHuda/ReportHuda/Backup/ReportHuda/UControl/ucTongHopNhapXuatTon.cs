using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class ucTongHopNhapXuatTon : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucTongHopNhapXuatTon";
        public ucTongHopNhapXuatTon()
        {
            InitializeComponent();
        }

        private void ucTongHopNhapXuatTon_Load(object sender, EventArgs e)
        {
            dtTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            dtDNgay.DateTime = dtTNgay.DateTime.AddMonths(1).AddDays(-1);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, Commons.Modules.ObjSystems.MLoadDataKho(1), "MS_KHO", "TEN_KHO", "");

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (dtTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonTuNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (dtDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonDenNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (dtTNgay.DateTime.Date > dtDNgay.DateTime.Date)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgTNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (cboKho.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return;
            }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCTongHopNXT", Commons.Modules.UserName, cboKho.EditValue, Commons.Modules.TypeLanguage,
                            dtTNgay.DateTime.Date, dtDNgay.DateTime.Date));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true,true,sUC);
            InDuLieu();
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 12;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                int iCot = 0;

                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 5, 120, 45, Application.StartupPath);
                
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TieuDeTongHopNXT", Commons.Modules.TypeLanguage), 1, 3, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);
            

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, 2);
                title.MergeCells = true;

                iCot = TCot - 2;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 3, 3, iCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.MergeCells = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                string stmp1 = "";
                iCot++;
                Dong = 1;

                
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,sUC, "bcMaSo", Commons.Modules.TypeLanguage);
                stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "bcMaSo1", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp + " " + stmp1, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, iCot, Dong, TCot);
                title.get_Characters(stmp.Length + 1, stmp1.Length + 1).Font.Bold = true;

                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,sUC, "bcNgayHL", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "bcLanSX", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "bcTuNgay", Commons.Modules.TypeLanguage) + " : " + dtTNgay.DateTime.Date.ToShortDateString();


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "bcDenNgay", Commons.Modules.TypeLanguage) + " : " + dtDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 1, Dong + TDong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong+1, 1, Dong+1, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong+1, 1, Dong + TDong + 1, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 2, 1, TDong + Dong + 1, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 35, "@", true, Dong + 2, 2, TDong + Dong + 1, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 3, TDong + Dong + 1, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong + 2, 4, TDong + Dong + 1, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 2, 9, TDong + Dong + 1, TCot);

                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkSheet.Rows.AutoFit();
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                title.RowHeight = 18;

                Dong = Dong + TDong + 2;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "bcGiamDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 12, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "bcKTTruong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 12, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "bcThuKho", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 7, "@", 12, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);
                //Giám đốc		Kế toán trưởng			Thủ kho		Lập biểu
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "bcLapBieu", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 9, "@", 12, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 9);


                xlWorkBook.Save();
                xlApp.Visible = true;


                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

    }
}
