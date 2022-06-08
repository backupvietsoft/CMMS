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
    public partial class ReportMaintaince : Form
    {
        public string _city, _district, _street, _factory, _catmachine, _groupmachine, _nguoiTH;
        public int _catMaintaice;
        public string _tungay, _cityName, _districtName, _streetName, _factoryName, _catmachineName, _groupmachineName,_catMaintainceName,_nguoiTHName;
        public DateTime _fromDate, _toDate;
        public bool is_Bao_Tri = false;
        public DataTable _tableSource = new DataTable();
        List<V_ReportMaintaince> v_all = new List<V_ReportMaintaince>();
        public ReportMaintaince()
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
            gridControl1.ExportToXls(path);
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



            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range _dateFrom = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            _dateFrom.Merge(true);
            _dateFrom.Font.Bold = true;

            excelWorkSheet.Cells[2, 1] = _tungay;
            _dateFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = _factoryName;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] =_catmachineName;
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = _groupmachineName;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] =_cityName;

            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range street = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            street.Merge(true);
            street.Font.Bold = true;
            excelWorkSheet.Cells[7, 1] = _districtName;

            Excel.Range a8 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range temp = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            temp.Merge(true); 
            temp.Font.Bold =true;
            excelWorkSheet.Cells[8, 1] = _streetName;
            Excel.Range a9 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count_column]);
            a9.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range temp1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count_column]);
            temp1.Merge(true);
            
            temp1.Font.Bold = true;
            excelWorkSheet.Cells[9, 1] = _catMaintainceName;

            a9 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 1], excelWorkSheet.Cells[10, count_column]);
            a9.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            temp1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 1], excelWorkSheet.Cells[10, count_column]);
            temp1.Merge(true);
            temp1.Font.Bold = true;
            excelWorkSheet.Cells[10, 1] = _nguoiTHName;

            Excel.Range temp2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[11, 1], excelWorkSheet.Cells[11, count_column]);
            temp2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range a10 = excelWorkSheet.get_Range(excelWorkSheet.Cells[11, 1], excelWorkSheet.Cells[11, count_column]);
            a10.Merge(true);
            
            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            Export();
        }
            
        private void ReportMaintaince_Load(object sender, EventArgs e)
        {
            Vietsoft.Information.ThayDoiNN(this);
            foreach (GridColumn col in gridView1.Columns)
            {
                col.Caption = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, col.Caption, Vietsoft.Information.Language);
            }
            if(is_Bao_Tri)
                gridColumn16.Visible = true;
            else
                gridColumn16.Visible = false;
            gridControl1.DataSource = _tableSource;
        }
    }
}
