using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

namespace ImportExcels
{
    public partial class frmBCTonKhoVTri : DevExpress.XtraEditors.XtraForm
    {
        public string Kho;
        public DateTime TuNgay;
        public DateTime DenNgay;

        private DataTable _table = new DataTable();
        public DataTable _TableSource
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }

        public frmBCTonKhoVTri()
        {
            InitializeComponent();
        }
        public void ExpressionSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, column,gridView1.Columns[column],"{0:N2}")});

            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";

            gridView1.Columns[column].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[column].DisplayFormat.FormatString = "{0:N2}";
            


        }
        public void ExpressionGroupBy(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            try
            {
                gridView1.Columns[column].Group();
                gridView1.ExpandAllGroups();
            }
            catch { }

        }
        private void frmBCTonKhoVTri_Load(object sender, EventArgs e)
        {
            grdSource.DataSource = _TableSource;
            grvSource.PopulateColumns();
            grvSource.OptionsView.ColumnAutoWidth = false;
            grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvSource.BestFitColumns();
            foreach (DataColumn col in _TableSource.Columns)
            {
                if (col.Caption == "MS_PT" || col.Caption == "MS_PT_NCC" || col.Caption == "TEN_PT"
                            || col.Caption == "TEN_KHO" || col.Caption == "TEN_VI_TRI" || col.Caption == "TEN_DVT"
                            || col.Caption == "TEN_CLASS" || col.Caption == "TON_TOI_THIEU" 
                            || col.Caption == "TON_KHO_MAX" || col.Caption == "SO_NGAY_DAT_MUA_HANG")
                { }
                else
                {
                    ExpressionSum(grvSource, col.Caption);
                    //grvSource.Columns[col.Caption].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
            }

            //int i = 0;
            //foreach (DataColumn column in _TableSource.Columns)
            //{
            //    grvSource.Columns[i].Width = 100;
            //    //column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
            //    grvSource.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
            //    i += 1;
            //}
            grvSource.Columns[2].Width = 350;

            //grvSource.Columns["TEN_KHO"].GroupIndex = 1;
            ExpressionGroupBy(grvSource, "TEN_KHO");

            //grvSource.GroupFooterShowMode = true;

            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExit", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                catch
                {

                }
                this.Cursor = Cursors.WaitCursor;
                grdSource.ExportToXls(path);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                int count_column = _TableSource.Columns.Count;
                int count_row = _TableSource.Rows.Count;


                //tao tieu de
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[1, 1] = lblTitle.Text;

                //tao kho
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[2, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "Kho", Commons.Modules.TypeLanguage) + Kho;
                //tao Tu Ngay
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[3, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "TuNgay", Commons.Modules.TypeLanguage) + TuNgay;
                //tao Den Ngay
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[4, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "DenNgay", Commons.Modules.TypeLanguage) + DenNgay;

                //tao logo
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT LOGO FROM THONG_TIN_CHUNG"));
                DataView dv = new DataView(dtTmp);
                GetImage((byte[])dv[0]["LOGO"]);

                //Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                //a2.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Sheets WS = excelWorkbook.Worksheets;
                Excel.Worksheet CurSheet = (Excel.Worksheet)WS.get_Item("Sheet1");
                Excel.Range CurCell = (Excel.Range)CurSheet.get_Range("A1", "A1");

                CurSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue
                        , 0, 0, 100, 20);

                File.Delete(Application.StartupPath + "\\logo.bmp");

                excelWorkSheet.Columns.AutoFit();
                excelWorkSheet.Rows.AutoFit();
                excelApplication.ActiveWindow.DisplayGridlines = true;
                if (Commons.Modules.bDoiFontReport) excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;

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
        public void GetImage(byte[] Logo)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            MemoryStream stream = new MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);

        }
    }

}