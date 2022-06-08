using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportHuda
{
    public partial class frmBCTHThoiGianNgungMay : DevExpress.XtraEditors.XtraForm
    {
        #region khai bao 
        private DataTable dtChung;
        #endregion

        public DataTable _dtChung
        {
            get
            {
                return dtChung;
            }
            set
            {
                dtChung = value;
            }
        }
        private string sNgay;
        public string _Ngay
        {
            get
            { return sNgay; }
            set
            { sNgay = value; }
        }

        private string sDDiem;
        public string _DDiem
        {
            get
            { return sDDiem; }
            set
            { sDDiem = value; }
        }

        private string sLMay;
        public string _LMay
        {
            get
            { return sLMay; }
            set
            { sLMay = value; }
        }

        private string sDChuyen;
        public string _DChuyen
        {
            get
            { return sDChuyen; }
            set
            { sDChuyen = value; }
        }

        public frmBCTHThoiGianNgungMay()
        {
            InitializeComponent();
        }

        private void frmBCTHThoiGianNgungMay_Load(object sender, EventArgs e)
        {
            try
            {

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtChung, false, true, false, true);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                try
                {
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvData.RowCount.ToString() + "   ";
                }
                catch { lblTVT.Text = ""; }
            }
            catch { }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            try
            {
                grdData.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int TCot = grvData.Columns.Count;
                int TDong = grvData.RowCount;
                int Dong = 1;

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblTitle.Text, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sNgay, Dong, 4, "@", 10, true, true, Dong, TCot - 2);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sDDiem, Dong, 4, "@", 10, true, true, Dong, TCot - 2);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sLMay, Dong, 4, "@", 10, true, true, Dong, TCot - 2);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sDChuyen, Dong, 4, "@", 10, true, true, Dong, TCot - 2);
                Dong++;
                Excel.Range title;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.71, "", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.71, "", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "", true, Dong + 1, 13, TDong + Dong, 13);

                excelWorkbook.Save();
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
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}