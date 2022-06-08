using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Columns;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ReportHuda.NMN_TD
{
    public partial class frmKeHoachBTThang_TD : DevExpress.XtraEditors.XtraForm
    {
        DataTable _table_destination = new DataTable();
        DataTable _table_source = new DataTable();
        GridView view;
        private string _subTitle;
        private string _dkLoc;
        private int _year;
        private int _month;
        string sBC = "frmKeHoachBTThang_TD";
        public frmKeHoachBTThang_TD()
        {
            InitializeComponent();
        }
        public DataTable _Table_Source
        {
            get
            {
                return _table_source;
            }
            set {
                _table_source = value;
            }
        }
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
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }
        public int Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }
        }
        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            view = sender as GridView;
            switch (e.Column.FieldName)
            {
                case "TEN_MAY":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column));

                        if (value1 == value2)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }
                case "VAT_TU_SU_DUNG":
                case "NGUOI_THUC_HIEN":
                case "DON_VI_SO_LUONG":
                case "XAC_NHAN_DHV":
                case "TEN_BO_PHAN":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column));
                        string value3 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_MAY"));
                        string value4 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_MAY"));

                        if (value1 == value2 && value3 == value4)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }
                case "MO_TA_CV":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column));
                        string value3 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_MAY"));
                        string value4 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_MAY"));
                        string value5 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_BO_PHAN"));
                        string value6 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_BO_PHAN"));
                        string value7 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "CHU_KY"));
                        string value8 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "CHU_KY"));
                        if (value1 == value2 && value3 == value4 && value5 == value6 && value7 == value8)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }

               
                case "THOI_GIAN_THUC_HIEN":
                case "CHU_KY":
                case "GHI_CHU":
                case "NGAY_KE":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "MO_TA_CV"));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "MO_TA_CV"));
                        string value3 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_MAY"));
                        string value4 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_MAY"));
                        string value5 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_BO_PHAN"));
                        string value6 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_BO_PHAN"));
                        // string value7 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "CHU_KY"));
                        //string value8 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "CHU_KY"));
                        if (value1 == value2 && value3 == value4 && value5 == value6)// && value7 == value8)
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }
            }
        }
        public void GetImage(byte[] Logo)
        {
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }
        private void Excute()
        {
            //gridControl1.ShowPrintPreview();
            SaveFileDialog f = new SaveFileDialog();
            string path = "";
            path = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (path == "") return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gridView2.ExportToXls(path);
                int count_column = _table_source.Columns.Count - 1;
                Excel.Application excelApplication = new Excel.Application();
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                excelApplication.StandardFont = "Tahoma";
                excelApplication.StandardFontSize = 8.5;

                int rows = 1;
                //excelApplication.Visible = true;
                DataTable dtTmp = new DataTable();
                if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                {
                    string sSql = "SELECT  CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " +
                                " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " +
                                " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " +
                                " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Commons.Modules.UserName.ToString() + "') ";
                    dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count == 0)
                    {
                        dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
                    }
                }
                else
                {
                    dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
                }

                Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                //


                //

                rows++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = dtTmp.Rows[0]["DIA_CHI"];



                rows++;

                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
                //CurCell.Merge(true);
                //CurCell.Font.Bold = true;
                //CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];



                rows++;

                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
                //CurCell.Merge(true);
                //CurCell.Font.Bold = true;
                //CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];


                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[rows, count_column]);
                //CurCell.Merge(true);
                //CurCell.Font.Bold = true;

                //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thuduc", Commons.Modules.TypeLanguage) + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "ngay1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thang1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "nam1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year;
                //CurCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //CurCell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //CurCell.Borders.LineStyle = 0;
                //
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[rows, "B"]);
                //CurCell.MergeCells = true;
                //CurCell.Borders.LineStyle = 0;

                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 50);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                }
                catch
                {
                }

                rows++;

                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[rows, 1] = lblTitle.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thang", Commons.Modules.TypeLanguage) + " " + Month + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "nam", Commons.Modules.TypeLanguage) + " " + Year;
                rows++;
                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[rows, 1] = SubTitle;
                rows++;
                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[rows, 1] = DKLoc;
                rows++;
                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                title.Merge(true);
                DataTable _table_copy = _table_source.Copy();
                DataTable _table_may = new DataTable();
                _table_may = _table_source.DefaultView.ToTable(true, "MS_MAY", "TEN_MAY");
                DataTable _temp, _temp_bp, _temp_bp_1;
                int count = 0;
                int count_bp = 0;
                int stt = 0;
                rows = 10;
                Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);

                foreach (DataRow _row in _table_may.Rows)
                {
                    stt++;
                    _table_copy.DefaultView.RowFilter = "MS_MAY='" + _row["MS_MAY"] + "'";

                    _temp = new DataTable();
                    _temp = _table_copy.DefaultView.ToTable();
                    _temp_bp = _temp.DefaultView.ToTable(true, "MS_BO_PHAN", "TEN_BO_PHAN");
                    count = _temp.Rows.Count;
                    if (rows != 10)
                    {
                        count = count - 1 + rows;
                    }
                    else
                        count = count + 9;


                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[count, "B"]);
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    //a3.ColumnWidth = "15";
                    a3.WrapText = true;
                    a3.MergeCells = true;
                    a3.Value2 = _row["TEN_MAY"];

                    // excelApplication.Visible = true;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[count, "A"]);
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    //a3.ColumnWidth = "8";
                    a3.MergeCells = true;
                    a3.Value2 = stt;


                    foreach (DataRow _row_bp in _temp_bp.Rows)
                    {
                        _temp.DefaultView.RowFilter = "MS_BO_PHAN='" + _row_bp["MS_BO_PHAN"] + "'";
                        _temp_bp_1 = _temp.DefaultView.ToTable();
                        count_bp = _temp_bp_1.Rows.Count;
                        if (rows != 10)
                        {
                            count_bp = count_bp - 1 + rows;
                        }
                        else
                            count_bp = count_bp + 9;
                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[count_bp, "C"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        a3.MergeCells = true;

                        a3.WrapText = true;
                        a3.Value2 = _row_bp["TEN_BO_PHAN"];

                        #region merge cell
                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[count_bp, "F"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";

                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[count_bp, "F"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";

                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[count_bp, "G"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";

                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[count_bp, "H"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";

                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "J"], excelWorkSheet.Cells[count_bp, "J"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";

                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "K"], excelWorkSheet.Cells[count_bp, "K"]);
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        a3.MergeCells = true;
                        a3.WrapText = true;
                        a3.Value2 = "";
                        #endregion
                        #region chu ky
                        //string ck = "", ck1 = "";
                        //int _start_row = 1;
                        //bool isDuplicate = false;
                        //for (int j = 0; j < _temp_bp_1.Rows.Count; j++)
                        //{
                        //    ck = ck1 = "";
                        //    ck = Convert.ToString(_temp_bp_1.Rows[j]["CHU_KY"]);
                        //    if (j + 1 < _temp_bp_1.Rows.Count)
                        //        ck1 = Convert.ToString(_temp_bp_1.Rows[j + 1]["CHU_KY"]);
                        //    if (ck != ck1)
                        //    {
                        //        if (!isDuplicate)
                        //            _start_row = rows;
                        //        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "Q"], excelWorkSheet.Cells[rows, "Q"]);
                        //        a3.MergeCells = true;
                        //        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        //        a3.Value2 = ck;
                        //        rows++;

                        //        isDuplicate = false;
                        //    }
                        //    else
                        //    {

                        //        if (!isDuplicate)
                        //        {
                        //            if (_start_row <= rows)
                        //                _start_row = rows;
                        //        }
                        //        isDuplicate = true;
                        //        //  a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "Q"], excelWorkSheet.Cells[rows, "Q"]);
                        //        // a3.Merge(true);
                        //        rows++;
                        //    }

                        //}
                        #endregion
                        rows = count_bp + 1;

                    }



                    rows = count + 1;
                }

                excelWorkSheet.Columns.AutoFit();
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[count, "B"]);
                a3.ColumnWidth = "35";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[count, "C"]);
                a3.ColumnWidth = "35";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[count, "D"]);
                a3.ColumnWidth = "35";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[count, "E"]);
                a3.ColumnWidth = "15";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[count, "F"]);
                a3.ColumnWidth = "12";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[count, "G"]);
                a3.ColumnWidth = "12";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[count, "H"]);
                a3.ColumnWidth = "18";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "I"], excelWorkSheet.Cells[count, "I"]);
                a3.ColumnWidth = "15";
                a3.WrapText = true;
                //a3.EntireColumn.Hidden = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "J"], excelWorkSheet.Cells[count, "J"]);
                a3.ColumnWidth = "16";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "K"], excelWorkSheet.Cells[count, "K"]);
                a3.ColumnWidth = "19";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "L"], excelWorkSheet.Cells[count, "L"]);
                a3.ColumnWidth = "19";
                a3.WrapText = true;
                excelWorkSheet.Rows.AutoFit();
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, "A"], excelWorkSheet.Cells[rows, count_column + 1]);
                a3.Borders.LineStyle = 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count_column + 1]);
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                rows += 3;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                a3.Merge(true);
                a3.Font.Bold = true;
                //a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "Duyet", Commons.Modules.TypeLanguage);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "L"]);
                a3.Merge(true);
                a3.Font.Bold = true;
                //a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "NguoiLap", Commons.Modules.TypeLanguage);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[rows, count_column + 1]);
                //a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
                title.Font.Size = 14;
                excelApplication.ActiveWindow.DisplayGridlines = true;
                //excelWorkSheet.PageSetup.PrintGridlines = true;
                try
                {
                    excelWorkSheet.PageSetup.PrintTitleRows = "$9:$9";
                    excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                    excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    excelWorkSheet.PageSetup.LeftMargin = 0;
                    excelWorkSheet.PageSetup.RightMargin = 0;
                    excelWorkSheet.PageSetup.BottomMargin = 0;
                    excelWorkSheet.PageSetup.TopMargin = 0;
                    excelWorkSheet.PageSetup.FooterMargin = 0.5;
                    excelWorkSheet.PageSetup.HeaderMargin = 0.5;
                    excelWorkSheet.PageSetup.Zoom = 66;
                }
                catch { }
                string stmp = "";
                rows = 1;
                excelApplication.Visible = true;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "sSTLLBTDK", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 11, 1, 11);
                title.Value2 = stmp;
                title.Font.Italic = true;

                    
                stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "sPhienBanLBTDK", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 2, 11, 2, 11);
                title.Value2 = stmp;
                title.Font.Italic = true;

                
                stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "sNgayApDungLBTDK", Commons.Modules.TypeLanguage);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 3, 11, 3, 11);
                title.Value2 = stmp;
                title.Font.Italic = true;

                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;



        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //InDuLieu();
            Excute();

            //sPath = "";
            //sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            //if (sPath == "") return;

            ////if (datDNgay.DateTime.Date < datTNgay.DateTime.Date)
            ////{
            ////    Commons.MssBox.Show(sBC, "msgTuNgayLonHonDenNgay");
            ////    return;
            ////}

            //BeginInvoke((Action)(() =>
            //{
            //    prbPr.Properties.Stopped = false;
            //}));



            //Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            //t.Start(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void frmKeHoachBTThang_TD_Load(object sender, EventArgs e)
        {
            DataTable _table_value = new DataTable();
            _table_destination = _Table_Source.Copy();
        
            _table_destination.Columns.Add("VAT_TU_SU_DUNG");
            _table_destination.Columns.Add("NGUOI_THUC_HIEN");
            _table_destination.Columns.Add("DON_VI_SO_LUONG");
            _table_destination.Columns.Add("THOI_GIAN_THUC_HIEN");
            _table_destination.Columns.Add("XAC_NHAN_DHV");
            DataTable _table = new DataTable();


            DataTable dtTmp = new DataTable();
            string sBT = "BT_BTTHANG_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, _table_destination, "");


            //_table_destination = _table_destination.DefaultView.ToTable(true, "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "CHU_KY",
            //                                                           "VAT_TU_SU_DUNG", "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT TEN_MAY, TEN_BO_PHAN, MO_TA_CV, CHU_KY,VAT_TU_SU_DUNG, DON_VI_SO_LUONG, NGUOI_THUC_HIEN, NGAY_KE, " +
                " THOI_GIAN_THUC_HIEN, XAC_NHAN_DHV, GHI_CHU FROM " + sBT));
            gridControl1.DataSource = dtTmp;



            DataTable temp = new DataTable();
            // temp = _table_destination.DefaultView.ToTable(false, "MO_TA_CV",  "NGAY_KE", "GHI_CHU");
            //temp = _table_destination.DefaultView.ToTable(false, "MO_TA_CV", "CHU_KY", "VAT_TU_SU_DUNG",
            //                                      "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");


            //gridControl1.DataSource = _table_destination;

            //temp.Columns.Add("NO");
            //temp.Columns.Add("TEN_MAY");
            //temp.Columns.Add("TEN_BO_PHAN");

            //temp = temp.DefaultView.ToTable(false, "NO", "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "CHU_KY", "VAT_TU_SU_DUNG",
            //                                        "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");


            temp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT NULL AS NO, NULL AS TEN_MAY, NULL AS TEN_BO_PHAN, MO_TA_CV, CHU_KY, VAT_TU_SU_DUNG, " +
                " DON_VI_SO_LUONG, NGUOI_THUC_HIEN, NGAY_KE, THOI_GIAN_THUC_HIEN, XAC_NHAN_DHV, GHI_CHU FROM " + sBT));

            Commons.Modules.ObjSystems.MLoadXtraGrid(gridControl2, gridView1, temp, false, true, true, false);
            //gridControl2.DataSource = temp;
            //for (int i = 0; i < _table_destination.Columns.Count; i++)
            //{
            //    gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //    gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //    gridView1.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
            //    gridView1.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);

            //    gridView2.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //    gridView2.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //    gridView2.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
            //    gridView2.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);


            //}
            //gridView2.Columns[11].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            //for (int i = 0; i < 4; i++)
            //{
            //    gridView2.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            //}

           
            //gridView1.Columns["TEN_MAY"].Width = 150;
            //gridView1.Columns["TEN_BO_PHAN"].Width = 150;
            //gridView1.Columns["MO_TA_CV"].Width = 150;
            gridView1.Columns["NGAY_KE"].Width = 100;

            //gridView1.Columns["CHU_KY"].Width = 100;
            //gridView1.Columns["THOI_GIAN_THUC_HIEN"].Width = 150;
            //gridView1.Columns["NGUOI_THUC_HIEN"].Width = 150;
            //gridView1.Columns["DON_VI_SO_LUONG"].Width = 150;
            //gridView1.Columns["THOI_GIAN_THUC_HIEN"].Width = 150;
            //gridView1.Columns["XAC_NHAN_DHV"].Width = 150;

            gridView1.Columns["TEN_MAY"].Fixed = FixedStyle.Left;

            gridView1.Columns["TEN_BO_PHAN"].Fixed = FixedStyle.Left;
            gridView1.Columns["MO_TA_CV"].Fixed = FixedStyle.Left;
            //foreach (GridColumn col1 in gridView1.Columns)
            //{
            //    col1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", col1.FieldName, Commons.Modules.TypeLanguage);
            //}
            //foreach (GridColumn col1 in gridView2.Columns)
            //{
            //    col1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", col1.FieldName, Commons.Modules.TypeLanguage);
            //}
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            //gridView1.Columns["TEN_MAY"].Group();
            //gridView1.Columns["TEN_BO_PHAN"].Group();

        }







        Thread t = null;
        private delegate void CallProcessBar(object flag);
        string sPath = "";

        private void ShowProcessBar(object flag)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), true);
            }
            else
            {
                BeginInvoke((Action)(() =>
                {
                    prbPr.Properties.Stopped = false;
                    EnableControl(false);
                    this.Cursor = Cursors.WaitCursor;

                }));
                t = new Thread(new ThreadStart(InExcel));
                t.Start();

            }
        }

        private Boolean TaoData(out DataTable dtData)
        {
            dtData = null;
            #region "TaoData"
            try
            {

                dtData = new DataTable();
                //dtData.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCTinhTrangThietbi", datTNgay.DateTime.Date, datDNgay.DateTime.Date, (optNgay.SelectedIndex == 0 ? 0 : 1), Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNMay.EditValue, Commons.Modules.TypeLanguage, chkBThuong.Checked, chkYCSD.Checked, chkKHTT.Checked, chkBaoTri.Checked, chkDangBaoTri.Checked));


                if (dtData.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgKhongCoDuLieuXuatExcel", Commons.Modules.TypeLanguage));
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
            #endregion

        }


        private void InDuLieu()
        {
            
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                
                int TCot = gridView1.Columns.Count - 1;
                int TDong = gridView1.DataRowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 100;// gridView1.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;



                gridControl1.ExportToXls(sPath);
                


                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);




                TDong = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                int SCot;

                SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoTongHopPBT", "BaoCaoTongHopPBTTieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //Dong++;
                //string stmp = "";
                //stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //Dong++;
                //stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //Dong++;
                //stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //Dong++;
                //stmp = lblLMay.Text + " : " + cboLMay.Text;
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                //Dong++;
                //stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                //int DongBD;
                //DongBD = Dong + 3;
                //Excel.Range title;
                //Dong++;
                //Dong++;

                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, TDong, TCot);
                //title.Borders.LineStyle = 1;
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;
                //title.WrapText = true;
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion
                //title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                //title.Font.Bold = true;
                //title.RowHeight = 30;
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion

                //Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                //    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                //title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                //title.RowHeight = 9;

                //title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                //title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", true, Dong + 1, 1, TDong + Dong, 1);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", true, Dong + 1, 2, TDong + Dong, 2);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.71, "@", true, Dong + 1, 3, TDong + Dong, 3);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 4, TDong + Dong, 4);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 5, TDong + Dong, 5);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21.71, "@", true, Dong + 1, 6, TDong + Dong, 6);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 7, TDong + Dong, 7);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21.43, "@", true, Dong + 1, 8, TDong + Dong, 8);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.43, "@", true, Dong + 1, 9, TDong + Dong, 9);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.43, "@", true, Dong + 1, 10, TDong + Dong, 10);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10.86, "@", true, Dong + 1, 11, TDong + Dong, 11);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "@", true, Dong + 1, 12, TDong + Dong, 12);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10.29, "dd/MM/yyyy", true, Dong + 1, 13, TDong + Dong, 13);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong + 1, 14, TDong + Dong, 14);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10.43, "@", true, Dong + 1, 15, TDong + Dong, 15);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "@", true, Dong + 1, 16, TDong + Dong, 16);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35.29, "@", true, Dong + 1, 17, TDong + Dong, 17);
                //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 18, TDong + Dong, 18);

                //title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 14, 12, TDong, 15);
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;


                //int count = 1;
                //for (int i = 14; i <= TDong; i++)
                //{
                //    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, 1, i, 1);
                //    try
                //    {

                //        Convert.ToInt32(title.Value);
                //        title.Value = count;
                //        count++;
                //    }
                //    catch
                //    {

                //        title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(146, 208, 80));
                //        title.Font.Bold = true;
                //        count = 1;
                //    }
                //    #region prb
                //    prbIN.PerformStep();
                //    prbIN.Update();
                //    #endregion                
                //}


                //#region prb
                //prbIN.PerformStep();
                //prbIN.Update();
                //#endregion

                excelWorkbook.Save();

                excelApplication.WindowState = Excel.XlWindowState.xlMaximized;
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

            }
            catch (Exception ex)
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }


        private void InExcel()
        {
            try
            {
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                


                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBTDKSheet", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                DataTable dtData = new DataTable();
                dtData = (DataTable)gridControl1.DataSource;
                #region "Tao Data"
                //if (TaoData(out dtData) == false)
                //{
                //    try
                //    {
                //        BeginInvoke((Action)(() =>
                //        {
                //            this.Cursor = Cursors.Default;
                //            EnableControl(true);
                //            prbPr.Properties.Stopped = true;
                //        }));
                //        sPath = "";
                //    }
                //    catch { }
                //    return;
                //}
                #endregion

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1);
                #endregion


                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];
                Commons.Modules.MExcel.MText(ws1, sBC, "sBaoCaoTinhTrangThietbi", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;
                //if (optNgay.SelectedIndex == 0)
                //    Commons.Modules.MExcel.MText(ws1, "", lblTNgay.Text + " " + datTNgay.Text + " " + lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtData.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                //else
                //    Commons.Modules.MExcel.MText(ws1, "", lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtData.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                //iDong++;
                //Commons.Modules.MExcel.MText(ws1, "", lblDDiem.Text + " : " + cboDDiem.TextValue, iDong, 2, true);
                //Commons.Modules.MExcel.MText(ws1, "", lblDChuyen.Text + " : " + cboDChuyen.TextValue, iDong, 4, true);

                //iDong++;
                //Commons.Modules.MExcel.MText(ws1, "", lblLMay.Text + " : " + cboLMay.Text, iDong, 2, true);
                //Commons.Modules.MExcel.MText(ws1, "", lblNhomMay.Text + " : " + cboNMay.Text, iDong, 4, true);

                #endregion

                List<string> sCotNgay = new List<string>() { };
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;



                #region "In BTDK"
                sCotNgay = new List<string>()
                    {
                            "NGAY_BD",
                            "NGAY_KT"
                    };

                WidthColumnsName = new List<Object>()
                    {"MS_MAY",15};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_MAY",30};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TINH_TRANG_MAY",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TT_CT",60};
                WidthColumns.Add(WidthColumnsName);

                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, sBC, sCotNgay, "dd/MM/yyyy", WidthColumns);
                #endregion


                if (fi.Exists)
                    fi.Delete();

                pck.SaveAs(fi);

                using (ExcelPackage excel = new ExcelPackage(new System.IO.FileInfo(sPath)))
                {
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                    worksheet.Cells[9, 1, worksheet.Dimension.End.Row, 1].Merge = true;

                    //for (int currentRow = 9; currentRow <= worksheet.Dimension.End.Row; currentRow++)
                    //{
                    //    string firstCellValue = worksheet.Cells[currentRow, 1].Value == null || worksheet.Cells[currentRow, 1].Value.ToString() == "" ? null : worksheet.Cells[currentRow, 1].Value.ToString();
                    //    string secondCellValue = worksheet.Cells[currentRow+1, 1].Value == null || worksheet.Cells[currentRow+1, 1].Value.ToString() == "" ? null : worksheet.Cells[currentRow + 1, 1].Value.ToString();

                    //    if (firstCellValue == secondCellValue)
                    //    {
                    //        try
                    //        {
                    //            worksheet.Cells[currentRow, 1, currentRow + 1, 1].Merge = true;
                    //        }catch { }
                    //    }
                    //}
                    excel.Save();
                    // Save file
                }
                System.Diagnostics.Process.Start(fi.FullName.ToString());

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    EnableControl(true);
                    prbPr.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }

        private void EnableControl(bool flag)
        {
            btnExecute.Enabled = flag;
            btnCancel.Enabled = flag;
            
        }
    }
}