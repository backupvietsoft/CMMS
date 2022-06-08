using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace ImportExcels
{
    public partial class frmBCaoHCKD : DevExpress.XtraEditors.XtraForm
    {

        public DateTime DenNgay;
        public string TieuDe;
        public Boolean KT = false;
        public int LoaiBC = 0;
        private DataTable _tableHCKD = new DataTable();
        public DataTable _dtHCKD
        {
            get
            {
                return _tableHCKD;
            }
            set
            {
                _tableHCKD = new DataTable();
                _tableHCKD = value;
            }
        }


        public frmBCaoHCKD()
        {
            InitializeComponent();
        }

        private void frmBCaoHCKD_Load(object sender, EventArgs e)
        {
            LoadGridSum();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadGridSum()
        {

            try
            {
                grdSource.DataSource = null;
                grvSource.Columns.Clear();
            }
            catch { }

            grdSource.DataSource = _tableHCKD;

            grvSource.PopulateColumns();
            grvSource.OptionsView.ColumnAutoWidth = true;
            grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvSource.BestFitColumns();

            int i = 0;
            foreach (DataColumn column in _tableHCKD.Columns)
            {
                grvSource.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                i += 1;
            }
            if (LoaiBC == 1)
            {
                grvSource.Columns[1].Group();
                grvSource.ExpandAllGroups();
            }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grvSource.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongCoDulieu", Commons.Modules.TypeLanguage));
                return;
            }

            Excel.Application excelApplication = new Excel.Application();
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                string path = "";
                f.Filter = "Excel file (*.xls)|*.xls";
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res.Equals(DialogResult.OK))
                    {
                        path = f.FileName;
                    }
                    else
                        return;
                }
                catch { }
                this.Cursor = Cursors.WaitCursor;

                int TCot = grvSource.Columns.Count;
                int TDong = grvSource.RowCount;

                grdSource.ExportToXls(path);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                try
                {
                    excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;
                    excelApplication.Cells.Font.Size = 10;
                    double size = 10;
                    int Dong = 0;

                    Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, 3);
                    Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                    Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);

                    Dong = 6;
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, LoaiBC == 1 ? "ucHCKDTieuDeDHD" : "ucHCKDTieuDeMay", Commons.Modules.TypeLanguage).ToUpper()
                        , Dong, 1, "@", 14, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                    Dong = 8;
                    Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);

                    Excel.Range title;
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong , TCot);
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    title.Borders.Color = System.Drawing.ColorTranslator.ToOle(Color.Black);
                    title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]).Interior.Color;
                    title.RowHeight = 25;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                    title.Borders.Color = System.Drawing.ColorTranslator.ToOle(Color.Black);
                    title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]).Interior.Color;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong + TDong, 2);
                    title.WrapText = true;
                    

                    if (LoaiBC == 0)
                    {
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12.43, "@", true, Dong, 1, Dong, 1);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25.86, "@", true, Dong, 2, Dong, 2);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.43, "@", true, Dong, 3, Dong, 3);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7.41, "@", true, Dong, 4, Dong, 4);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9.14, "@", true, Dong, 5, Dong, 5);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.29, "dd/MM/yyy", true, Dong, 6, Dong, 6);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.41, "@", true, Dong, 7, Dong, 7);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.43, "@", true, Dong, 8, Dong, 8);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.57, "@", true, Dong, 9, Dong, 9);

                    }
                    else
                    {
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 1.86, "@", true, Dong, 1, Dong, 1);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 34.14, "@", true, Dong, 2, Dong, 2);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 27.29, "@", true, Dong, 3, Dong, 3);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 4, Dong, 4);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 29.14, "@", true, Dong, 5, Dong, 5);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14.43, "dd/MM/yyy", true, Dong, 6, Dong, 6);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7.57, "@", true, Dong, 7, Dong, 7);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.29, "@", true, Dong, 8, Dong, 8);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.43, "@", true, Dong, 9, Dong, 9);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.41, "@", true, Dong, 10, Dong, 10);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.43, "@", true, Dong, 11, Dong, 11);
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.57, "@", true, Dong, 12, Dong, 12);
                    }

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       this.Name, "Duyet", Commons.Modules.TypeLanguage)
                       , Dong + TDong + 2, 2, "@", size, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 2, 2);

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                     this.Name, "KiemTra", Commons.Modules.TypeLanguage)
                     , Dong + TDong + 2, 4, "@", size, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 2, 5);

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "NguoiLap", Commons.Modules.TypeLanguage)
                    , Dong + TDong + 2, 7, "@", size, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 2, 8);



                    this.Cursor = Cursors.Default;
                    excelWorkbook.Save();
                    excelApplication.Visible = true;
                }
                catch 
                {
                    excelApplication.Visible = true;
                    excelApplication.Quit();
                    this.Cursor = Cursors.Default;
                    Vietsoft.Information.MsgBox(this, "XuatKhongThanhCong", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {

            }
        }







        public void GetImage(byte[] Logo)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            MemoryStream stream = new MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}