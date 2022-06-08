using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Columns;

namespace CustomerInfoReport
{
    public partial class ListWarranty : Form
    {
        List<V_Report_Warranty_Equipment> v_all = new List<V_Report_Warranty_Equipment>();
        public string _city, _district, _street, _factory, _catmachine;
        public DateTime _tungay, _den_ngay;
        public string _amountDateText,_cityName, _districtName, _streetName, _factoryName, _catmachineName,_ngay;

        public int _amountDate = 15;
        public ListWarranty()
        {
            InitializeComponent();
        }

        private void Export()
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
            int count_column = gridView1.Columns.Count;
            //int count_row = _table1.Rows.Count;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);

            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[1, 1] = lblTitle.Text;


            int row = 2;
            Excel.Range a = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            a = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a.Merge(true);
            a.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _ngay;
            a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            row++;
            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range _dateFrom = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            _dateFrom.Merge(true);
            _dateFrom.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _amountDateText;
            _dateFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            row++;
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _factoryName;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            row++;
            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _catmachineName;
            row++;
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _cityName;
            row++;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _districtName;
            row++;
            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range street = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[row, 1] = _streetName;
            row++;
            Excel.Range a8 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range temp = excelWorkSheet.get_Range(excelWorkSheet.Cells[row, 1], excelWorkSheet.Cells[row, count_column]);
            temp.Merge(true);
            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {
           // if (gvWarranty.Rows.Count > 0)
               // exportDataToExcel(Vietsoft.Information.GetLanguage("ECOMAIN", this.Name, "reportTitleWarranty", Vietsoft.Information.Language), gvWarranty);
           /// else
               // MessageBox.Show(Vietsoft.Information.GetLanguage("ECOMAIN", this.Name, "nodataprint", Vietsoft.Information.Language), Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "title", Vietsoft.Information.Language), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ListWarranty_Load(object sender, EventArgs e)
        {
            try
            {
                Vietsoft.Information.ThayDoiNN(this);
                
                //lblTitle.Text = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "lblTitle", Vietsoft.Information.Language);
                btnExcute.Text = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "btnExcute", Vietsoft.Information.Language);
                btnCancel.Text = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "btnCancel", Vietsoft.Information.Language);
                
                foreach (GridColumn col in gridView1.Columns)
                {
                    col.Caption = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, col.Caption, Vietsoft.Information.Language);
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "SP_NHU_Y_GET_LIST_BAO_HANH", Vietsoft.Information.Username, _catmachine, _factory, _city, _district, _street, _amountDate, _tungay.ToString("MM-dd-yyyy"), _den_ngay.ToString("MM-dd-yyyy")));
                gridControl1.DataSource = _table;
              
               
            }
            catch { }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
                Export();
            else
                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "nodataprint", Vietsoft.Information.Language), Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "title", Vietsoft.Information.Language), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
