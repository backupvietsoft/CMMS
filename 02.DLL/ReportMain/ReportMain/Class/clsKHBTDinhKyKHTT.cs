using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportMain
{
    public static partial class clsKHBTDinhKyKHTT
    {
        public static void InKHBT(DataTable dtTmp, string sFrom) 
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            try
            {
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                int TCot = dtTmp.Columns.Count;
                int TDong = dtTmp.Rows.Count;


                int Dong = 1;
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, dtTmp.Rows.Count + 1, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);

                //xlApp.Visible = true;
                
                foreach (DataColumn drCol in dtTmp.Columns)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, Dong, 1, Dong);
                    title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sFrom, drCol.Caption, Commons.Modules.TypeLanguage);
                    Dong++;
                }

                Dong = 1;
                xlWorkSheet.Outline.SummaryRow = Excel.XlSummaryRow.xlSummaryAbove;
                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, System.Windows.Forms.Application.StartupPath);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sFrom, "KehoachbaotridinhkyKHTT", Commons.Modules.TypeLanguage), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);

                Dong = 8;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 76);

                Dong = Dong + TDong;
                Commons.Modules.MExcel.MTaoSTT(xlWorkSheet, 9, 1, Dong);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, 9, 1, Dong , 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 36, "@", true, 9, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, 9, 4, Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, 9, 5, Dong, 6);                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, 9, 9, Dong, 9);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 5, Dong, 6);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;
                
                

                xlWorkBook.Save();
                xlApp.Visible = true;

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sFrom, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
        }
    }
}
