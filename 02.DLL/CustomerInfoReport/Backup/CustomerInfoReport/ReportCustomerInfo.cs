using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Microsoft.ApplicationBlocks.Data;

namespace CustomerInfoReport
{
    public partial class ReportCustomerInfo : Form
    {
        public string _city, _district, _street, _factory, _catmachine, _groupmachine;
        public string _cityName, _districtName, _streetName, _factoryName, _catmachineName, _groupmachineName;
        List<V_ReportCustomer> v_all = new List<V_ReportCustomer>();
        public string tinh, quan,duong, loai_may, nhom_may, nha_xuong;
        public ReportCustomerInfo()
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
        private void ReportCustomerInfo_Load(object sender, EventArgs e)
        {
            Vietsoft.Information.ThayDoiNN(this);

            btnExcute.Text = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "btnExcute", Vietsoft.Information.Language);
            btnCancel.Text = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "btnCancel", Vietsoft.Information.Language);
            DataTable _table1 = new DataTable();
            _table1.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_KHACH_HANG", Vietsoft.Information.Username,
                                                 _catmachine, _groupmachine, _factory, _city, _district, _street));
         
            foreach (GridColumn col in gridview1.Columns)
            {
                col.Caption = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, col.Caption , Vietsoft.Information.Language);
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
          //  col_n_xuong.Caption = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "IDCus", Vietsoft.Information.Language);
            //col_n_xuong.Caption = Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "CusName", Vietsoft.Information.Language);
            gridControl1.DataSource = _table1; ;
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
            gridview1.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count_column = gridview1.Columns.Count;
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

            excelWorkSheet.Cells[2, 1] = nha_xuong;
            _dateFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = loai_may;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] = nhom_may;
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = tinh;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] = quan;

            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range street = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[7, 1] =duong;
            Excel.Range a8 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range temp = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            temp.Merge(true);
            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
      

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (gridview1.RowCount > 0)
            {
                Export();
            }
            //exportDataToExcel(Vietsoft.Information.GetLanguage("ECOMAIN", this.Name, "reportTitleCustomer", Vietsoft.Information.Language), gvReport);
            else
                MessageBox.Show(Vietsoft.Information.GetLanguage("ECOMAIN", this.Name, "nodataprint", Vietsoft.Information.Language), Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, this.Name, "title", Vietsoft.Information.Language), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
