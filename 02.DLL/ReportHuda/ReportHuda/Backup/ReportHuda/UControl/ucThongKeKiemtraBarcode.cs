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
    public partial class ucThongKeKiemtraBarcode : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucThongKeKiemtraBarcode";

        public ucThongKeKiemtraBarcode()
        {
            InitializeComponent();
        }
        private void ucThongKeKiemtraBarcode_Load(object sender, EventArgs e)
        {
            
            dtTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            dtDNgay.DateTime = dtTNgay.DateTime.AddMonths(1).AddDays(-1);


            string sSql = "SELECT DISTINCT Location AS MA , Location AS TEN FROM VSBarcode UNION SELECT '-1', ' < ALL > ' ORDER BY TEN";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, dtTmp, "MA", "TEN", lblDDiem.Text);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (dtTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaNhapTuNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (dtDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaNhapDenNgay", Commons.Modules.TypeLanguage));
                dtDNgay.Focus();
                return;
            }
            if( dtDNgay.DateTime<dtTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (cboDDiem.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }      
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeKiemTraBarcode", 
                    dtTNgay.DateTime, dtDNgay.DateTime,cboDDiem.EditValue,optBCao.SelectedIndex ));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sUC);
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
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 12;
                prbIN.Properties.Minimum = 0;
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

                //xlApp.Cells.Font.Name = "Tahoma";
                //xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;
                //xlApp.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TieuDeThongKeKiemTraBarCode", Commons.Modules.TypeLanguage) , 4, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 4, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong = 5;

                Dong++;
                stmp = lblTNgay.Text + " : " + dtTNgay.DateTime.ToShortDateString() + " " + lblDNgay.Text + " : " + dtDNgay.DateTime.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);

                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);

                Dong++;
                Dong++;

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

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4.5, "#,##0", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, oldCultureInfo.DateTimeFormat.ShortDatePattern + " HH:mm:ss", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 21, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 21, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 21, "@", true, Dong, iCot, TDong + Dong, iCot+2); 
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = TDong + Dong ;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, 1);
                title.RowHeight = 9;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }



    }
}
