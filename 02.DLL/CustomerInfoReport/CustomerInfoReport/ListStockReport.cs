using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace CustomerInfoReport
{
    public partial class ListStockReport : DevExpress.XtraEditors.XtraForm
    {
        public int stockid;
        public string stockName;
        public DateTime fromdate, todate;
        DataTable dt = new DataTable();
        public string date, kho;
        public ListStockReport()
        {
            InitializeComponent();
        }
        private string Conn
        {
            get
            {
                string s = Vietsoft.Information.ConnectionString;
                //s = @"Data Source=Lenovo-pc\sqlexpress;Initial Catalog=CMMS;User ID=sa;Pwd=123";
                return s;
            }

        }
        private void LoadData()
        {
           
            dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Conn, "[SP_NHU_Y_GET_TON_KHO]", stockid, fromdate, todate, Vietsoft.Information.Language));
          
            string caption = "";
            foreach (DataColumn  col in dt.Columns)
            {
                caption=Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, col.Caption, Vietsoft.Information.Language);
                col.Caption = caption;
                //Vietsoft.Information.ModuleName 
            }   gridControl1.DataSource = dt;
            Vietsoft.Information.ThayDoiNN(this);

        }

   
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
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
                Excel.Application excelApplication = new Excel.Application();
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int count_column = dt.Columns.Count;
                int count_row = dt.Rows.Count;
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[1, 1] = lblTitle.Text;
                Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
                a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range _kho = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
                _kho.Merge(true);
                _kho.Font.Bold = true;
                excelWorkSheet.Cells[2, 1] = kho ;
                Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
                a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
               
                Excel.Range _ngay = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
                _ngay.Merge(true);
                _ngay.Font.Bold = true;

               excelWorkSheet.Cells[3, 1] = date ;
                excelWorkSheet.Columns.AutoFit();
                excelWorkSheet.Rows.AutoFit();

                excelApplication.ActiveWindow.DisplayGridlines = true;


                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
               
            // exportDataToExcel(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "StockTitle", Vietsoft.Information.Language), gvStock);
            else
                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "nodataprint", Vietsoft.Information.Language), Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "title", Vietsoft.Information.Language), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void ListStockReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
