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
            gridView2.ExportToXls(path);
            int count_column = _table_source.Columns.Count + 1;
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

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
            // CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
            ////
            //CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[rows, count_column]);
            //CurCell.MergeCells = true;
            //CurCell.Font.Bold = true;
            //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "conghoaxahoichunghiavietnam", Commons.Modules.TypeLanguage);
            //CurCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //CurCell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            //CurCell.Borders.LineStyle = 0;
            ////
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "diachi", Commons.Modules.TypeLanguage) + dtTmp.Rows[0]["DIA_CHI"];
            //

            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[rows, count_column]);
            //CurCell.Merge(true);
            //CurCell.Font.Bold = true;

            //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "doclaptudohanhphuc", Commons.Modules.TypeLanguage);
            //CurCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //CurCell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            //CurCell.Borders.LineStyle = 0;
            //
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


            GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 50);
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
            a3.ColumnWidth = "15";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[count, "C"]);
            a3.ColumnWidth = "20";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[count, "D"]);
            a3.ColumnWidth = "35";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[count, "E"]);
            a3.ColumnWidth = "9.29";
            a3.EntireColumn.Hidden = true;
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[count, "F"]);
            a3.ColumnWidth = "15";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[count, "G"]);
            a3.ColumnWidth = "15";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "H"], excelWorkSheet.Cells[count, "H"]);
            a3.ColumnWidth = "19";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "I"], excelWorkSheet.Cells[count, "I"]);
            a3.ColumnWidth = "10";
            a3.WrapText = true;
            a3.EntireColumn.Hidden = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "J"], excelWorkSheet.Cells[count, "J"]);
            a3.ColumnWidth = "17.43";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "K"], excelWorkSheet.Cells[count, "K"]);
            a3.ColumnWidth = "21";
            a3.WrapText = true;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "L"], excelWorkSheet.Cells[count, "L"]);
            a3.ColumnWidth = "20";
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
            a3.Font.Size = 12;
            a3.Font.Name = "Tahoma";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "Duyet", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "L"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Font.Size = 12;
            a3.Font.Name = "Tahoma";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "NguoiLap", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[rows, count_column + 1]);
            a3.Font.Size = 12;
            a3.Font.Name = "Tahoma";
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            title.Font.Size = 14;
            excelApplication.ActiveWindow.DisplayGridlines = true;
            //excelWorkSheet.PageSetup.PrintGridlines = true;
            excelWorkSheet.PageSetup.PrintTitleRows = "$9:$9";
            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            excelWorkSheet.PageSetup.LeftMargin = 0;
            excelWorkSheet.PageSetup.RightMargin = 0;
            excelWorkSheet.PageSetup.BottomMargin = 0;
            excelWorkSheet.PageSetup.TopMargin = 0;
            excelWorkSheet.PageSetup.FooterMargin = 0.5;
            excelWorkSheet.PageSetup.HeaderMargin = 0.5;
            excelWorkSheet.PageSetup.Zoom = 78;
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Excute();
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



          
            _table_destination = _table_destination.DefaultView.ToTable(true, "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "CHU_KY",
                                                                         "VAT_TU_SU_DUNG", "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");
            DataTable temp = new DataTable();
            // temp = _table_destination.DefaultView.ToTable(false, "MO_TA_CV",  "NGAY_KE", "GHI_CHU");
            temp = _table_destination.DefaultView.ToTable(false, "MO_TA_CV", "CHU_KY", "VAT_TU_SU_DUNG",
                                                  "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");
            gridControl1.DataSource = _table_destination;
            temp.Columns.Add("NO");
            temp.Columns.Add("TEN_MAY");
            temp.Columns.Add("TEN_BO_PHAN");

            temp = temp.DefaultView.ToTable(false, "NO", "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "CHU_KY", "VAT_TU_SU_DUNG",
                                                    "DON_VI_SO_LUONG", "NGUOI_THUC_HIEN", "NGAY_KE", "THOI_GIAN_THUC_HIEN", "XAC_NHAN_DHV", "GHI_CHU");

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
        }
    }
}