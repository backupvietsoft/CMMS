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
    public partial class ucDanhMucHangTrongKho : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucDanhMucHangTrongKho";
        public ucDanhMucHangTrongKho()
        {
            InitializeComponent();
        }

        private void ucDanhMucHangTrongKho_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVTu, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", "");
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, Commons.Modules.ObjSystems.MLoadDataKho(1), "MS_KHO", "TEN_KHO", "");
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBCDanhMucHangTrongKho", int.Parse(txtTon.Text), 
                    cboKho.EditValue, cboLVTu.EditValue, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, false, true, true, sBC);

            if (Commons.Modules.sPrivate == "VINHHOAN")
            { 
                
            }
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
                iCot = TCot - 2;

                xlApp.DisplayAlerts = false;
                Excel.Range title;

                for (int i = 1; i <= TDong + 1; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 2, i, 3);
                    title.MergeCells = true;
                }

                

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 5, 120, 45, Application.StartupPath);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TieuDeDanhMucHangTrongKho", Commons.Modules.TypeLanguage), 1, 3, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, 2);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 3, 3, 6);
                title.MergeCells = true;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, TCot, 3, TCot);
                //title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //title.MergeCells = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                iCot++;
                Dong = 1;
                string stmp1 = "";

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcMaSo", Commons.Modules.TypeLanguage);
                stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcMaSo1", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp + " " + stmp1, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                title.get_Characters(stmp.Length + 1, stmp1.Length + 1).Font.Bold = true;

                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcNgayHL", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcLanSX", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
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



                Dong++;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong+1, 1, Dong + TDong+2, 4);
                title.MergeCells = true;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcNguoiLap", Commons.Modules.TypeLanguage) + "\n";
                stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcNgay", Commons.Modules.TypeLanguage);
                title.Value2 = stmp + stmp1;
                title.get_Characters(1, stmp.Length).Font.Bold = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, 5, Dong + TDong + 2, 7);
                title.MergeCells = true;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcPheDuyet", Commons.Modules.TypeLanguage) + "\n";
                stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcNgay", Commons.Modules.TypeLanguage);
                title.Value2 = stmp + stmp1; 
                title.get_Characters(1, stmp.Length).Font.Bold = true;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong +2, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;




                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong , TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion




                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong , 1, TDong + Dong , 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, 1, 2, 1, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, 1, 3, 1, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true,  Dong, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 45, "@", true, Dong , 6, TDong + Dong , 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong , 7, TDong + Dong , 7);



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkSheet.Rows.AutoFit();
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                title.RowHeight = 18;

                xlWorkBook.Save();
                xlApp.Visible = true;


                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC  , "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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

        private void SetCellFirstWordBold(Microsoft.Office.Interop.Excel.Range rng, char wordsSeparator)
        {
            string cellString = rng.Value2.ToString();

            int firstWordEndIdx = cellString.IndexOf(wordsSeparator);
            this.SetCellBoldPartial(rng, 0, firstWordEndIdx);
        }

        private void SetCellBoldPartial(Microsoft.Office.Interop.Excel.Range rng, int boldStartIndex, int boldEndIndex)
        {
            //rng.Cells.Characters[boldStartIndex, boldEndIndex].Font.Bold = 1;

        }
        

    }
}
