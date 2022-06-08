using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportExcels
{
    public partial class frmIncident_Detail : DevExpress.XtraEditors.XtraForm
    {
        public frmIncident_Detail()
        {
            InitializeComponent();
        }
        private DataTable _table= new DataTable();
        public string _tu_ngay;
        public string tinh, quan,nha_xuong, loai_may, nhom_may;
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
        
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
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
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count_column = _TableSource.Columns.Count;
            int count_row = _TableSource.Rows.Count;
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
            _dateFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            _dateFrom.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[2, 1] = _tu_ngay;

            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range factory = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            factory.Merge(true);
            factory.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = nha_xuong;
            factory.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] = loai_may;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = nhom_may;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] = tinh;
            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            a7.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[7, 1] = quan;

         

            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }

        private void frmIncident_Detail_Load(object sender, EventArgs e)
        {
           
            grdSource.DataSource = _TableSource;
            string name = "";
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                name = col.FieldName;
                switch(name)
                {
                    case "DIA_CHI":
                    case "TEN_CV":
                    case "TEN_PT":
                    case "NGUOI_CC_TT":
                        col.Width = 200;
                            break;
                    case "MS_MAY":
                    case "TEN_MAY":
                    case "TEN_N_XUONG":
                    case "NGUOI_THAY_THE":
                    case "NGAY_BAO_SU_CO":
                    case "NGAY_HOAN_THANH":   
                    case  "MS_PHIEU_BAO_TRI":
                    case  "SO_PHIEU_BAO_TRI":
                    col.Width = 120;
                            break;
                }
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
                col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                col.AppearanceCell.Options.UseTextOptions = true;
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncident_Detail", col.FieldName, Commons.Modules.TypeLanguage);
                 
            }
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncident_Detail", "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncident_Detail", "btnExit", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
    }
}
