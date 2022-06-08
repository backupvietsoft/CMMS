using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportHuda.Forms
{
    public partial class frmTKVTChuaXuat : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtVatTu;
        public DataTable TableSource
        {
            get
            {return dtVatTu;}
            set
            {dtVatTu = value;}
        }

        private Boolean bLoaiBC = true;
        public Boolean _bLoaiBC
        {
            get
            { return bLoaiBC; }
            set
            { bLoaiBC = value; }
        }


        private string sLoaiVT;
        public string _LoaiVT
        {
            get
            { return sLoaiVT; }
            set
            { sLoaiVT = value; }
        }

        private string sKho;
        public string _sKho
        {
            get
            {return sKho;}
            set
            {sKho = value;}
        }

        private string sDXuat;
        public string _sDXuat
        {
            get
            { return sDXuat; }
            set
            { sDXuat = value; }
        }

        private string dNgay;
        public string _dNgay
        {
            get
            { return dNgay; }
            set
            { dNgay = value; }
        }

        private int iBaoCao = 1;
        public int _iBaoCao
        {
            get
            { return iBaoCao; }
            set
            { iBaoCao = value; }
        }


        public frmTKVTChuaXuat()
        {
            InitializeComponent();
        }

        private void frmTKVTChuaXuat_Load(object sender, EventArgs e)
        {
            //iBaoCao = 1 bao cao thong ke vat tu
            //iBaoCao = 2 bao cao ucFastSlowNonMovingAnalysic.cs


            try
            {
                if (iBaoCao == 2)
                {
                    grdVTu.DataSource = dtVatTu;
                    grvVTu.PopulateColumns();
                    grvVTu.OptionsView.ColumnAutoWidth = true;
                    grvVTu.OptionsView.AllowHtmlDrawHeaders = true;
                    grvVTu.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                    grvVTu.BestFitColumns();
                    grvVTu.Columns["STT"].Width = 30;
                    grvVTu.Columns["MS_PT"].Width = 90;
                    grvVTu.Columns["TEN_PT"].Width = 150;
                    grvVTu.Columns["TEN_PT_VIET"].Width = 110;
                    grvVTu.Columns["MS_PT_NCC"].Width = 100;
                    grvVTu.Columns["MS_PT_CTY"].Width = 100;
                    grvVTu.Columns["QUY_CACH"].Width = 100;
                    grvVTu.Columns["TONG_TON"].Width = 80;
                    grvVTu.Columns["TSL"].Width = 60;
                    grvVTu.Columns["TAN_XUAT"].Width = 60;
                    grvVTu.Columns["PHAN_LOAI"].Width = 60;
                    grvVTu.Columns["VI_TRI"].Width = 120;
                    grvVTu.OptionsView.ShowFooter = true;
                    grvVTu.Columns["TONG_TON"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grvVTu.Columns["TONG_TON"].SummaryItem.DisplayFormat = "{0:N2}";

                    grvVTu.Columns["TSL"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grvVTu.Columns["TSL"].SummaryItem.DisplayFormat = "{0:N2}";

                    grvVTu.Columns["TAN_XUAT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grvVTu.Columns["TAN_XUAT"].SummaryItem.DisplayFormat = "{0:N2}";


                    Commons.Modules.ObjSystems.ThayDoiNN(this);
                    lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ucFastSlowNonMovingAnalysic", Commons.Modules.TypeLanguage);
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucVTChuaXuatKho", "TongSoVatTu", Commons.Modules.TypeLanguage) + " : " + dtVatTu.Rows.Count;

                    return;
                }

                grdVTu.DataSource = dtVatTu;
                grvVTu.PopulateColumns();
                if (grvVTu.Columns.Count < 17) grvVTu.OptionsView.ColumnAutoWidth = true;                                
                grvVTu.OptionsView.AllowHtmlDrawHeaders = true;
                grvVTu.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grvVTu.BestFitColumns();
                grvVTu.Columns["TEN_1"].Width = 100;
                grvVTu.Columns["MS_PT_CTY"].Width = 120;
                grvVTu.Columns["MS_PT_NCC"].Width = 120;
                grvVTu.Columns["MS_PT"].Width = 120;

                grvVTu.Columns["SL_TON"].Width = 110;
                grvVTu.Columns["SL_TON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvVTu.Columns["SL_TON"].DisplayFormat.FormatString = "{0:N2}";

                grvVTu.Columns["THANH_TIEN"].Width = 120;
                grvVTu.Columns["THANH_TIEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvVTu.Columns["THANH_TIEN"].DisplayFormat.FormatString = "{0:N2}";

                grvVTu.Columns["TT_USD"].Width = 120;
                grvVTu.Columns["TT_USD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvVTu.Columns["TT_USD"].DisplayFormat.FormatString = "{0:N2}";

                Commons.Modules.ObjSystems.ThayDoiNN(this);


                if (grvVTu.Columns.Count < 17)
                {
                    if (sDXuat == "-111")
                        lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "VatTuKhongThayThe", Commons.Modules.TypeLanguage);
                    else
                        lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "VatTuChuaXuatKho", Commons.Modules.TypeLanguage);
                }
                else
                {
                    lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTKhongThayThe", "VatTuKhongThayThe", Commons.Modules.TypeLanguage);
                }
                lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTChuaXuatKho", "TongSoVatTu", Commons.Modules.TypeLanguage) + " : " + dtVatTu.Rows.Count;

            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            string sPath = "-1";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");            
            if (sPath == "") return;

            if (iBaoCao == 2)
            {
                InNSF(sPath);
                return;
            }

            grdVTu.ExportToXls(sPath);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int TCot = TableSource.Columns.Count;
            int TDong = TableSource.Rows.Count;
            int Dong = 1;

            this.Cursor = Cursors.WaitCursor;
            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);            
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 180, 50, Application.StartupPath);
            if (sDXuat != "-111")            
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
            else
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblTitle.Text, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, 
                Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

            Dong++;
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, dNgay, Dong, 2, "@", 10, true, true, Dong, 4);
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, sLoaiVT, Dong, 5, "@", 10, true, true, Dong, TCot);

            Dong++;
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, sKho, Dong, 2, "@", 10, true, true, Dong, TCot);

            int DBDau = Dong;
            DBDau = 10;
            if (sDXuat != "-111")
            {
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sDXuat, Dong, 2, "@", 10, true, true, Dong, TCot);
                DBDau = 11;
            }
            Dong++;
            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);
            int CotBDSum;
            if (grvVTu.Columns.Count < 17) CotBDSum = 6; else CotBDSum = 12;


            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucVTChuaXuatKho", "TongCong", Commons.Modules.TypeLanguage), TDong + Dong + 2, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight,
                Excel.XlVAlign.xlVAlignCenter, true, TDong + Dong + 2, CotBDSum);

            int DSum = TDong + Dong + 1;

            excelApplication.Visible = true;

            CotBDSum++;
            string s;
            s = Commons.Modules.MExcel.TimDiemExcel(DBDau, CotBDSum);

            Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", DSum + 1,CotBDSum, DSum + 1, CotBDSum, 
                DBDau, CotBDSum, DSum, CotBDSum, 0, true,10, "###,##0.00");


            CotBDSum++;

            Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", DSum + 1,CotBDSum, DSum + 1, CotBDSum, 
                DBDau, CotBDSum, DSum, CotBDSum, 0, true,16, "###,##0.00");
             
            CotBDSum++;
            if (grvVTu.Columns.Count < 17)
            {

                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", DSum + 1, CotBDSum, DSum + 1, CotBDSum,
                    DBDau, CotBDSum, DSum, CotBDSum, 0, true, 16, "###,##0.00");

            }
            else
            {

                CotBDSum++;
                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", DSum + 1, CotBDSum, DSum + 1, CotBDSum,
                    DBDau, CotBDSum, DSum, CotBDSum, 0, true, 16, "###,##0.00");
                
                CotBDSum++;

                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", DSum + 1, CotBDSum, DSum + 1, CotBDSum,
                    DBDau, CotBDSum, DSum, CotBDSum, 0, true, 16, "###,##0.00");

            }
            Excel.Range title;
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
            title.RowHeight = 9;

            Dong++;
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, DSum+1, TCot);
            title.Borders.LineStyle = 1;
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
            title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
            title.Font.Bold = true;

            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "", true, Dong + 1, 1, TDong + Dong, 1);
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "", true, Dong + 1, 2, TDong + Dong, 2);
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "", true, Dong + 1, 3, TDong + Dong, 3);
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "", true, Dong + 1, 4, TDong + Dong, 4);
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 38, "", true, Dong + 1, 5, TDong + Dong, 5);

            excelApplication.Visible = true;
            this.Cursor = Cursors.Default;
        }
        private void InNSF(string sPath)
        {
            if (sPath == "") return;
            Excel.Application excelApplication = new Excel.Application();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                grdVTu.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int TCot = TableSource.Columns.Count;
                int TDong = TableSource.Rows.Count;
                int Dong = 1;

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 180, 50, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucFastSlowNonMovingAnalysic", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, dNgay, Dong, 3, "@", 10, true, true, Dong, TCot);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sKho, Dong, 3, "@", 10, true, true, Dong, TCot);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sDXuat, Dong, 3, "@", 10, true, true, Dong, TCot);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sLoaiVT, Dong, 3, "@", 10, true, true, Dong, TCot);

                Dong++;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, true, true, true, true, Excel.XlPaperSize.xlPaperA4,
                    Excel.XlPageOrientation.xlLandscape, 0.17, 0.17, 0.17, 0.17, 0.17, 0.17, 100);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 4, "", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 22, "", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 26, "", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0.00", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "#,##0.00", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "#,##0.00", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "", true, Dong + 1, 12, TDong + Dong, 12);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, TDong + Dong + 1, 1, TDong + Dong + 1, TCot);
                title.EntireRow.Delete(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);


                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucFastSlowNonMovingAnalysic", "TongCong", Commons.Modules.TypeLanguage) + " " , TDong + Dong + 1, 1, "@", 8, true,
                                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, TDong + Dong + 1, 7);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, TDong + Dong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, TDong + Dong + 1, 1, TDong + Dong + 1, TCot);
                title.Font.Bold = true;
                

            }
            catch 
            {
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "XuatKhongThanhCong", Commons.Modules.TypeLanguage));
            }
            this.Cursor = Cursors.Default;        
        
        }
        private string TimDiemExcel(int Dong, int Cot )
        {
            string sTmp;
            sTmp = "";
            if (Cot > 26)
            {
                sTmp = char.ConvertFromUtf32((Cot - 1) / 26 + 64);
                sTmp = sTmp + char.ConvertFromUtf32((Cot - 1) % 26 + 65);
            
            }
            else
            { sTmp = char.ConvertFromUtf32(Cot + 64);}
            if (Dong >= 0) sTmp = sTmp + Convert.ToString(Dong);

            return sTmp;

        }

        public void MFuntion(Excel.Worksheet MWsheet, string MFuntion, int DongBD, int CotBD, int DongKT, int CotKT, 
            int DongBDFuntion, int CotBDFuntion, int DongKTFuntion, int CotKTFuntion, double MFontSize, bool MFontBold, 
                double MColumnWidth, string MNumberFormat)
        {
            try
            {
                Excel.Range MRange = MWsheet.get_Range(MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]);

                MRange = Commons.Modules.MExcel.GetRange(MWsheet, DongBD, DongBD, DongKT, CotKT);
                MRange.Value2 = "=" + MFuntion + "(" + TimDiemExcel(DongBDFuntion, CotBDFuntion) + ":" + TimDiemExcel(DongKTFuntion, CotKTFuntion) + ")";
                if (MFontSize > 0)
                    MRange.Font.Size = MFontSize;
                MRange.ColumnWidth = MColumnWidth;
                MRange.Font.Bold = MColumnWidth;
                MRange.NumberFormat = MNumberFormat;
            }
            catch { }
        }


    }
}