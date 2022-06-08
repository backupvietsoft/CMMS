using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace ReportHuda.NMN_TD
{
    public partial class frmXuatNhapTon_TD : DevExpress.XtraEditors.XtraForm
    {
        DataTable _table_source = new DataTable();
        string tu_ngay, kho;
        public frmXuatNhapTon_TD()
        {
            InitializeComponent();
        }
        public string TuNgay
        {
            get
            {
                return tu_ngay;
            }
            set
            {
                tu_ngay = value;
            }
        }
        public string Kho
        {
            get
            {
                return kho;
            }
            set
            {
                kho = value;
            }
        }

        
        public DataTable _Table_Source
        {
            get
            {
                return _table_source;
            }
            set
            {
                _table_source = value;
            }
        }
        private void LoadData()
        {
            gridControl1.DataSource = _Table_Source;
            advBandedGridView1.Columns["LOAI_VAT_TU"].Group();
            advBandedGridView1.ExpandAllGroups();
            //advBandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_TON_DAU_THANG",advBandedGridView1.Columns["GIA_TRI_TON_DAU_THANG"],"{0:N2}")});
            //advBandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_XUAT",advBandedGridView1.Columns["GIA_TRI_XUAT"],"{0:N2}")});
            //advBandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_NHAP",advBandedGridView1.Columns["GIA_TRI_NHAP"],"{0:N2}")});
            //advBandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_TON_HT",advBandedGridView1.Columns["GIA_TRI_TON_HT"],"{0:N2}")});
            gridBand2.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "tondauthang", Commons.Modules.TypeLanguage);
            gridBand3.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "nhap", Commons.Modules.TypeLanguage);
            gridBand4.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "xuat", Commons.Modules.TypeLanguage);
            gridBand5.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "toncuoithang", Commons.Modules.TypeLanguage);
            foreach (BandedGridColumn col in advBandedGridView1.Columns)
            {
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", col.FieldName, Commons.Modules.TypeLanguage);
            }
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "btnCancel", Commons.Modules.TypeLanguage);
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
        private void Execute()
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
            
            int count_column = advBandedGridView1.Columns.Count;
            DataTable _temp = new DataTable();
            _temp =_table_source.DefaultView.ToTable(true, "LOAI_VAT_TU");

            int row_data = advBandedGridView1.RowCount + 10;
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = true;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int rows = 1;
            excelApplication.Visible = false;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, count_column]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
          
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, count_column]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "diachi", Commons.Modules.TypeLanguage) + dtTmp.Rows[0]["DIA_CHI"];
          
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, count_column]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
            rows++;

            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, count_column]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
            
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[rows, "C"]);
            CurCell.MergeCells = true;
            CurCell.Borders.LineStyle = 0;
            GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 140, 70);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            rows++;
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
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = Kho;
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[rows, 1] = TuNgay;

            count_column = count_column - 1;
            rows++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
        
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[10, 2]);
            a1.MergeCells = true;
            a1.ColumnWidth = 3;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 3], excelWorkSheet.Cells[10, 3]);
            a1.MergeCells = true;
            a1.ColumnWidth = 20;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 4], excelWorkSheet.Cells[10, 4]);
            a1.MergeCells = true;
            a1.ColumnWidth = 33.14;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 5], excelWorkSheet.Cells[10, 5]);
            a1.MergeCells = true;
            a1.ColumnWidth = 6.31;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 6], excelWorkSheet.Cells[10, 6]);
            a1.ColumnWidth = 12;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 7], excelWorkSheet.Cells[10, 7]);
            a1.ColumnWidth = 21;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 8], excelWorkSheet.Cells[10, 8]);
            a1.ColumnWidth = 12;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 9], excelWorkSheet.Cells[10, 9]);
            a1.ColumnWidth = 21;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 10], excelWorkSheet.Cells[10, 10]);
            a1.ColumnWidth = 12;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 11], excelWorkSheet.Cells[10, 11]);
            a1.ColumnWidth = 21;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 12], excelWorkSheet.Cells[10, 12]);
            a1.ColumnWidth = 12;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, 13], excelWorkSheet.Cells[10, 13]);
            a1.ColumnWidth = 21;
          
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[12, "F"], excelWorkSheet.Cells[row_data, "M"]);
            a1.NumberFormat = "###,##0.00";
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[1, "A"]);
            a1.ColumnWidth   = 0;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "B"], excelWorkSheet.Cells[1, "B"]);
            a1.ColumnWidth = 6.29;
            int _row = row_data;
            row_data++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "D"], excelWorkSheet.Cells[row_data, "D"]);
            a1.Font.Bold = true;
            
            a1.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "TONGCONG", Commons.Modules.TypeLanguage);
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "G"], excelWorkSheet.Cells[row_data, "G"]);
            a1.Value2 = "=SUM(G12:G" + _row + ")";
            a1.NumberFormat = "###,##0.00";
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "I"], excelWorkSheet.Cells[row_data, "I"]);
            a1.Value2 = "=SUM(I12:I" + _row + ")";
            a1.NumberFormat = "###,##0.00";
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "K"], excelWorkSheet.Cells[row_data, "K"]);
            a1.Value2 = "=SUM(K12:K" + _row + ")";
            a1.NumberFormat = "###,##0.00";
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "M"], excelWorkSheet.Cells[row_data, "M"]);
            a1.Value2 = "=SUM(M12:M" + _row + ")";
            a1.NumberFormat = "###,##0.00";
            
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[row_data, count_column+1]);
            title.Borders.LineStyle = 1;
            row_data+=2;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "B"], excelWorkSheet.Cells[row_data, count_column + 1]);
            title.MergeCells = true;
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "hochiminh", Commons.Modules.TypeLanguage) + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "ngay1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thang1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "nam1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            row_data++;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "A"], excelWorkSheet.Cells[row_data, "C"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "noinhan", Commons.Modules.TypeLanguage);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "D"], excelWorkSheet.Cells[row_data, "D"]);
            title.Font.Bold = true;
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "phogiamdoc", Commons.Modules.TypeLanguage);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "E"], excelWorkSheet.Cells[row_data, "G"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "bankhvtth", Commons.Modules.TypeLanguage);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "H"], excelWorkSheet.Cells[row_data, "I"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "thukho", Commons.Modules.TypeLanguage);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "J"], excelWorkSheet.Cells[row_data, "K"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "P.BanKTTC", Commons.Modules.TypeLanguage);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "L"], excelWorkSheet.Cells[row_data, "M"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "P.NguoiLap", Commons.Modules.TypeLanguage);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            row_data++;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "A"], excelWorkSheet.Cells[row_data, "C"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "BanKHVTTH", Commons.Modules.TypeLanguage);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "D"], excelWorkSheet.Cells[row_data + 4, "D"]);
            title.Font.Bold = true;
            title.MergeCells = true;
            title.Borders.LineStyle = 0;

            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "E"], excelWorkSheet.Cells[row_data+4, "G"]);
            title.Font.Bold = true;
            title.MergeCells=true;
            title.Borders.LineStyle = 0;
    
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "E"], excelWorkSheet.Cells[row_data + 4, "G"]);
            title.Font.Bold = true;
            title.MergeCells = true;
            title.Borders.LineStyle = 0;

            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "H"], excelWorkSheet.Cells[row_data + 4, "I"]);
            title.Font.Bold = true;
            title.MergeCells = true;
            title.Borders.LineStyle = 0;

            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "J"], excelWorkSheet.Cells[row_data + 4, "K"]);
            title.Font.Bold = true;
            title.MergeCells = true;
            title.Borders.LineStyle = 0;

            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "L"], excelWorkSheet.Cells[row_data + 4, "M"]);
            title.Font.Bold = true;
            title.MergeCells = true;
            title.Borders.LineStyle = 0;

            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


            row_data++;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[row_data, "A"], excelWorkSheet.Cells[row_data, "C"]);
            title.Font.Bold = true;
            title.Merge(true);
            title.Borders.LineStyle = 0;
            title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "Luu", Commons.Modules.TypeLanguage);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[row_data, count_column + 1]);
            title.Font.Size = 12;
            title.Font.Name = "Tahoma";
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            title.Font.Size = 14;
            excelWorkSheet.Rows.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;
            //excelWorkSheet.PageSetup.PrintGridlines = true;
            excelWorkSheet.PageSetup.PrintTitleRows = "$9:$10";
            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            excelWorkSheet.PageSetup.LeftMargin = 0;
            excelWorkSheet.PageSetup.RightMargin = 0;
            excelWorkSheet.PageSetup.BottomMargin = 0;
            excelWorkSheet.PageSetup.TopMargin = 0;
            excelWorkSheet.PageSetup.FooterMargin = 0.5;
            excelWorkSheet.PageSetup.HeaderMargin = 0.5;
            excelWorkSheet.PageSetup.Zoom = 71;
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }
        private void frmXuatNhapTon_TD_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            Execute();
        }
    }
}