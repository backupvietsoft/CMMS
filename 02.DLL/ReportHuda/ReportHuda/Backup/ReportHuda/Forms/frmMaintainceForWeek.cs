using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportHuda
{
    public partial class frmMaintainceForWeek : DevExpress.XtraEditors.XtraForm
    {
        public frmMaintainceForWeek()
        {
            InitializeComponent();
        }
        private DataTable _tableSource;
        private string _dkLoc;
        private string _subTitle;
      
        public string SubTitle
        {
            get
            {
                return _subTitle;
            }
            set
            {
                _subTitle = value;
            }
        }
      
        public string DKLoc
        {
            get
            {
                return _dkLoc;
            }
            set
            {
                _dkLoc = value;
            }
        }
        public DataTable TableSource
        {
            get
            {
                return _tableSource;
            }
            set
            {
                _tableSource = value;
            }
        }
        private void frmMaintainceForWeek_Load(object sender, EventArgs e)
        {
            gdMachine.DataSource = _tableSource;
            if (_tableSource.Rows.Count > 0)
            {
                gridView1.Columns["MO_TA_CV"].Width = 250;
                gridView1.Columns["TEN_PT"].Width = 250;
                gridView1.Columns["SO_LUONG"].Width = 100;
                gridView1.Columns["THUCHIEN"].Width = 250;
                gridView1.Columns["DVT"].Width = 100;
                gridView1.Columns["ISCHECK"].Width = 100;
                gridView1.Columns["MAY"].Group();
                gridView1.Columns["BP"].Group();
                gridView1.ExpandAllGroups();
                for (int i = 0; i<_tableSource.Columns.Count; i++)
                {
                    gridView1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gridView1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
                    gridView1.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                    gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
                    
                }
            }
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        public void GetImage(byte[] Logo)
        {
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }
        private void btnExecute_Click(object sender, EventArgs e)
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
            gdMachine.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count_column = TableSource.Columns.Count;
            int count_row = TableSource.Rows.Count;
            int _row = 1;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "H"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "H"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "H"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "H"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[_row, "C"]);
            CurCell.MergeCells = true;
            CurCell.Borders.LineStyle = 0;
            GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 180, 50);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");


            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "H"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell.Borders.LineStyle = 0;
          
            _row++;

            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[_row, 1] = lblTitle.Text;
            _row++;
            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range _dateFrom = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            _dateFrom.Merge(true);
            _dateFrom.Font.Bold = true;
            _dateFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            _dateFrom.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[_row, 1] = SubTitle;
            _row++;
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[_row, 1] = DKLoc;
         
            int rows = a3.CurrentRegion.Rows.Count+5;
             a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[rows, count_column]);
             a3.Borders.LineStyle = 1;
             rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 2], excelWorkSheet.Cells[rows, 4]);
            a3.Merge(true);
            a3.Font.Name = "Tahoma";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Duyet", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 6], excelWorkSheet.Cells[rows, 8]);
            a3.Merge(true);
            a3.Font.Name = "Tahoma";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NguoiLap", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
  a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[rows, count_column]);
            a3.Font.Size = 10;
            a3.Font.Name = "Tahoma";
            excelWorkSheet.Columns.AutoFit();
            
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "C"]);
            a3.ColumnWidth = "30";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "D"]);
            a3.ColumnWidth = "30";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
            a3.ColumnWidth = "30";
            a3.WrapText = true;
          
            excelWorkSheet.Rows.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
