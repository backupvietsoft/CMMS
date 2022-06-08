using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace ReportHuda.Kido
{
    public partial class frmBaoCaoKHBT_Kido : DevExpress.XtraEditors.XtraForm
    {
        public string city, district, street, factory, cat, group, day;
        public DataTable _table_source = new DataTable();
        public frmBaoCaoKHBT_Kido()
        {
            InitializeComponent();
        }
        private void ExportToExcel()
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
            gridView1.ExportToXls(path);
            int count_column = _table_source.Columns.Count;
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int rows = 1;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = lblTitle.Text;
            rows++;
            
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = day;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            rows++;
            title.Borders.LineStyle = 0;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = city;
            
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = district ;
          
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = street;
            
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = factory ;

            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = cat;

            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = group;
            
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Borders.LineStyle = 0;
           
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            title.Font.Size = 14;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 1], excelWorkSheet.Cells[10, count_column]);
            title.Font.Size = 10;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Columns.AutoFit();
          
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, count_column], excelWorkSheet.Cells[rows, count_column]);
            title.ColumnWidth = "20";
            title.WrapText = true;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, count_column-1], excelWorkSheet.Cells[rows, count_column-1]);
            title.ColumnWidth = "17.14";
            title.WrapText = true;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 3], excelWorkSheet.Cells[rows, 3]);
            title.ColumnWidth = "14.14";
            title.WrapText = true;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 4], excelWorkSheet.Cells[rows, 4]);
            title.ColumnWidth = "11.14";
            title.WrapText = true;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 8], excelWorkSheet.Cells[rows, 8]);
            title.ColumnWidth = "14";
            title.WrapText = true;
            excelWorkSheet.Rows.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;
            excelWorkSheet.PageSetup.PrintTitleRows = "$10:$10";
            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            excelWorkSheet.PageSetup.LeftMargin = 0;
            excelWorkSheet.PageSetup.RightMargin = 0;
            excelWorkSheet.PageSetup.BottomMargin = 0;
            excelWorkSheet.PageSetup.TopMargin = 0;
            excelWorkSheet.PageSetup.FooterMargin = 0.5;
            excelWorkSheet.PageSetup.HeaderMargin = 0.5;
            excelWorkSheet.PageSetup.Zoom = 75;
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCaoKHBT_Kido_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _table_source;
            string name = "";
            foreach (GridColumn col in gridView1.Columns)
            {
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", col.FieldName, Commons.Modules.TypeLanguage);
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
                name = col.FieldName;
                switch (name)
                {
                    case "NHAN_VIEN":
                        col.Width = 150;
                        break;
                    case "DIA_CHI":
                        col.Width = 140;
                        break;
                    default :
                        col.Width = 120;
                        break;
                }
               
                
            }
            btnExcute.Text  = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", btnExcute.Name, Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", btnCancel.Name, Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
           
        }
    }
}