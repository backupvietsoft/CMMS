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
    public partial class frmKeHoachBTNam_TD : DevExpress.XtraEditors.XtraForm
    {
        DataTable _table_destination = new DataTable();
        DataTable _table_source = new DataTable();
        GridView view;
        private string _subTitle;
        private string _dkLoc;
        private string _year;
        
        public frmKeHoachBTNam_TD()
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
        public string Year
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
                case "CHU_KY":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column));
                        string value3 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_MAY"));
                        string value4 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_MAY"));
                        string value5 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "TEN_BO_PHAN"));
                        string value6 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "TEN_BO_PHAN"));

                        if (value1 == value2 && value3 == value4 && value5 == value6)
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
                case "T1":
                case "T2":
                case "T3":
                case "T4":
                case "T5":
                case "T6":
                case "T7":
                case "T8":
                case "T9":
                case "T10":
                case "T11":
                case "T12":
                // case "CHU_KY":
                case "GHI_CHU":
                case "NGAY_KE":
                    {
                        string value1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, "MO_TA_CV"));
                        string value2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, "MO_TA_CV"));
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

            Excel.Application excelApplication = new Excel.Application();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable _table_copy = _table_source.Copy();
                DataTable _table_may = new DataTable();
                _table_may = _table_source.DefaultView.ToTable(true, "MS_MAY", "TEN_MAY");
                DataTable _temp, _temp_bp, _temp_bp_1;


                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10 + _table_may.Rows.Count;
                prbIN.Properties.Minimum = 0;



                gridView2.ExportToXls(path);
                int count_column = _table_source.Columns.Count - 1;

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int rows = 1;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                rows++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "diachi", Commons.Modules.TypeLanguage)  + dtTmp.Rows[0]["DIA_CHI"];
                rows++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
                rows++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                // CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[rows, "B"]);
                CurCell.MergeCells = true;
                CurCell.Borders.LineStyle = 0;
                GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 50);
                System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                //CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, count_column - 2], excelWorkSheet.Cells[1, count_column]);
                //CurCell.MergeCells = true;
                //CurCell.Borders.LineStyle = 0;
                //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thuduc", Commons.Modules.TypeLanguage) + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "ngay1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "thang1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTThang_TD", "nam1", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year;
                //CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "NgayIn", Commons.Modules.TypeLanguage) + " : " + DateTime.Now.ToShortDateString();
                rows++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[rows, 1] = lblTitle.Text + " " + Year;
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
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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

                int count = 0;
                int count_bp = 0;
                int stt = 0;
                rows = 10;
                Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


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
                        DataView _view = new DataView(_temp_bp_1);
                        _view.Sort = "CHU_KY";
                        _temp_bp_1 = _view.ToTable();
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
                        // a3.ColumnWidth = "20";
                        a3.WrapText = true;
                        a3.Value2 = _row_bp["TEN_BO_PHAN"];
                        string ck = "", ck1 = "";
                        int _start_row = 1;
                        bool isDuplicate = false;
                        for (int j = 0; j < _temp_bp_1.Rows.Count; j++)
                        {
                            ck = ck1 = "";
                            ck = Convert.ToString(_temp_bp_1.Rows[j]["CHU_KY"]);
                            if (j + 1 < _temp_bp_1.Rows.Count)
                                ck1 = Convert.ToString(_temp_bp_1.Rows[j + 1]["CHU_KY"]);
                            if (ck != ck1)
                            {
                                if (!isDuplicate)
                                    _start_row = rows;
                                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "Q"], excelWorkSheet.Cells[rows, "Q"]);
                                a3.MergeCells = true;
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                a3.Value2 = ck;
                                rows++;

                                isDuplicate = false;
                            }
                            else
                            {

                                if (!isDuplicate)
                                {
                                    if (_start_row <= rows)
                                        _start_row = rows;
                                }
                                isDuplicate = true;
                                //  a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "Q"], excelWorkSheet.Cells[rows, "Q"]);
                                // a3.Merge(true);
                                rows++;
                            }

                        }
                        rows = count_bp + 1;

                    }



                    rows = count + 1;
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }
                excelWorkSheet.Columns.AutoFit();
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[count, "B"]);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                a3.ColumnWidth = "15";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[count, "C"]);
                a3.ColumnWidth = "15";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[count, "D"]);
                a3.ColumnWidth = "39";
                a3.WrapText = true;

                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[count, "P"]);
                a3.ColumnWidth = "5";
                a3.WrapText = true;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[count, "A"]);
                a3.ColumnWidth = "5";
                a3.WrapText = true;

                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "S"], excelWorkSheet.Cells[count, "S"]);
                a3.ColumnWidth = "26.71";
                a3.WrapText = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelWorkSheet.Rows.AutoFit();
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, "A"], excelWorkSheet.Cells[rows, count_column]);
                a3.Borders.LineStyle = 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count_column]);
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                rows += 3;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "C"]);
                a3.Merge(true);
                a3.Font.Bold = true;
                a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "Duyet", Commons.Modules.TypeLanguage);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "R"]);
                a3.Merge(true);
                a3.Font.Bold = true;
                a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "NguoiLap", Commons.Modules.TypeLanguage);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlign;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[rows, count_column]);
                a3.Font.Size = 12;
                a3.Font.Name = "Tahoma";
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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
                excelWorkSheet.PageSetup.Zoom = 75;
                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
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
                    "frmKeHoachBTNam_TD", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;

        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKeHoachBTNam_TD_Load(object sender, EventArgs e)
        {
            DataTable _table_value = new DataTable();
            _table_destination = _Table_Source.Copy();
            _table_value = _Table_Source.Copy();
            _table_destination.Clear();
            DataTable _table = new DataTable();
            for (int i = 1; i <= 12; i++)
            {
                _table_destination.Columns.Add("T" + i);
            }
            int month = 1;
            DataRow dr = _table_destination.NewRow();
            dr["MS_MAY"] = _table_value.Rows[0]["MS_MAY"];
            dr["TEN_MAY"] = _table_value.Rows[0]["TEN_MAY"];
            dr["MS_BO_PHAN"] = _table_value.Rows[0]["MS_BO_PHAN"];
            dr["TEN_BO_PHAN"] = _table_value.Rows[0]["TEN_BO_PHAN"];
            dr["MS_CV"] = _table_value.Rows[0]["MS_CV"];
            dr["MO_TA_CV"] = _table_value.Rows[0]["MO_TA_CV"];
            dr["NGAY_DUA_VAO_SD"] = _table_value.Rows[0]["NGAY_DUA_VAO_SD"];
            dr["NGAY_KE"] = _table_value.Rows[0]["NGAY_KE"];
            dr["CHU_KY"] = _table_value.Rows[0]["CHU_KY"];
            dr["GHI_CHU"] = _table_value.Rows[0]["GHI_CHU"];
            month = Convert.ToDateTime(_table_value.Rows[0]["NGAY_KE"]).Month;
            switch (month)
            {
                case 1:
                    dr["T1"] = "X";
                    break;
                case 2:
                    dr["T2"] = "X";
                    break;
                case 3:
                    dr["T3"] = "X";
                    break;
                case 4:
                    dr["T4"] = "X";
                    break;
                case 5:
                    dr["T5"] = "X";
                    break;
                case 6:
                    dr["T6"] = "X";
                    break;
                case 7:
                    dr["T7"] = "X";
                    break;
                case 8:
                    dr["T8"] = "X";
                    break;
                case 9:
                    dr["T9"] = "X";
                    break;
                case 10:
                    dr["T10"] = "X";
                    break;
                case 11:
                    dr["T11"] = "X";
                    break;
                case 12:
                    dr["T12"] = "X";
                    break;
            }
            _table_destination.Rows.Add(dr);
            int k = 1;
            for (int i = 1; i < _table_value.Rows.Count; i++)
            {
                dr = _table_destination.NewRow();
                dr["MS_MAY"] = _table_value.Rows[i]["MS_MAY"];
                dr["TEN_MAY"] = _table_value.Rows[i]["TEN_MAY"];
                dr["MS_BO_PHAN"] = _table_value.Rows[i]["MS_BO_PHAN"];
                dr["TEN_BO_PHAN"] = _table_value.Rows[i]["TEN_BO_PHAN"];
                dr["MS_CV"] = _table_value.Rows[i]["MS_CV"];
                dr["MO_TA_CV"] = _table_value.Rows[i]["MO_TA_CV"];
                dr["NGAY_DUA_VAO_SD"] = _table_value.Rows[i]["NGAY_DUA_VAO_SD"];
                dr["NGAY_KE"] = _table_value.Rows[i]["NGAY_KE"];
                dr["CHU_KY"] = _table_value.Rows[i]["CHU_KY"];
                dr["GHI_CHU"] = _table_value.Rows[i]["GHI_CHU"];
                month = Convert.ToDateTime(_table_value.Rows[i]["NGAY_KE"]).Month;
                switch (month)
                {
                    case 1:
                        dr["T1"] = "X";
                        break;
                    case 2:
                        dr["T2"] = "X";
                        break;
                    case 3:
                        dr["T3"] = "X";
                        break;
                    case 4:
                        dr["T4"] = "X";
                        break;
                    case 5:
                        dr["T5"] = "X";
                        break;
                    case 6:
                        dr["T6"] = "X";
                        break;
                    case 7:
                        dr["T7"] = "X";
                        break;
                    case 8:
                        dr["T8"] = "X";
                        break;
                    case 9:
                        dr["T9"] = "X";
                        break;
                    case 10:
                        dr["T10"] = "X";
                        break;
                    case 11:
                        dr["T11"] = "X";
                        break;
                    case 12:
                        dr["T12"] = "X";
                        break;
                }
                if (dr["MS_MAY"].Equals(_table_destination.Rows[k - 1]["MS_MAY"])
                    && dr["MS_BO_PHAN"].Equals(_table_destination.Rows[k - 1]["MS_BO_PHAN"])
                    && dr["MS_CV"].Equals(_table_destination.Rows[k - 1]["MS_CV"])
                      && dr["CHU_KY"].Equals(_table_destination.Rows[k - 1]["CHU_KY"])
                    )
                {
                    switch (month)
                    {
                        case 1:
                            _table_destination.Rows[k - 1]["T1"] = "X";
                            break;
                        case 2:
                            _table_destination.Rows[k - 1]["T2"] = "X";
                            break;
                        case 3:
                            _table_destination.Rows[k - 1]["T3"] = "X";
                            break;
                        case 4:
                            _table_destination.Rows[k - 1]["T4"] = "X";
                            break;
                        case 5:
                            _table_destination.Rows[k - 1]["T5"] = "X";
                            break;
                        case 6:
                            _table_destination.Rows[k - 1]["T6"] = "X";
                            break;
                        case 7:
                            _table_destination.Rows[k - 1]["T7"] = "X";
                            break;
                        case 8:
                            _table_destination.Rows[k - 1]["T8"] = "X";
                            break;
                        case 9:
                            _table_destination.Rows[k - 1]["T9"] = "X";
                            break;
                        case 10:
                            _table_destination.Rows[k - 1]["T10"] = "X";
                            break;
                        case 11:
                            _table_destination.Rows[k - 1]["T11"] = "X";
                            break;
                        case 12:
                            _table_destination.Rows[k - 1]["T12"] = "X";
                            break;
                    }

                }
                else
                {
                    _table_destination.Rows.Add(dr);
                    k = _table_destination.Rows.Count;
                }
            }
            _table_source = _table_destination.DefaultView.ToTable(true, "MS_MAY", "TEN_MAY", "MS_BO_PHAN", "TEN_BO_PHAN", "MO_TA_CV", "T1", "T2",
                                                   "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "CHU_KY", "NGAY_KE", "GHI_CHU");
            _table_destination = _table_destination.DefaultView.ToTable(true, "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "T1", "T2",
                                                   "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "CHU_KY", "NGAY_KE", "GHI_CHU");
            DataTable temp = new DataTable();
            temp = _table_destination.DefaultView.ToTable(false, "MO_TA_CV", "T1", "T2",
                                                   "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "NGAY_KE", "GHI_CHU");
            DataView _view = new DataView(_table_destination);
            _view.Sort = "TEN_MAY,TEN_BO_PHAN,CHU_KY";
            _table_destination = _view.ToTable();
            gridControl1.DataSource = _table_destination;
            temp.Columns.Add("NO");
            temp.Columns.Add("TEN_MAY");
            temp.Columns.Add("TEN_BO_PHAN");
            temp.Columns.Add("CHU_KY");
            temp = temp.DefaultView.ToTable(false, "NO", "TEN_MAY", "TEN_BO_PHAN", "MO_TA_CV", "T1", "T2",
                                                  "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "CHU_KY", "NGAY_KE", "GHI_CHU");
            gridControl2.DataSource = temp;
            for (int i = 0; i < _table_destination.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                gridView1.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);

                gridView2.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView2.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView2.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                gridView2.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);


            }
            gridView2.Columns[18].AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            for (int i = 0; i < 4; i++)
            {
                gridView2.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            }
            gridView2.Columns[17].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            gridView2.Columns[18].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            for (int i = 4; i <= 16; i++)
            {
                gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gridView2.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView2.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView2.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gridView2.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            }
            gridView1.Columns["MO_TA_CV"].Width = 150;
            gridView1.Columns["TEN_MAY"].Width = 150;
            gridView1.Columns["TEN_BO_PHAN"].Width = 150;
            gridView1.Columns["NGAY_KE"].Width = 100;
            gridView1.Columns["TEN_MAY"].Fixed = FixedStyle.Left;
           
            gridView1.Columns["TEN_BO_PHAN"].Fixed = FixedStyle.Left;
            gridView1.Columns["MO_TA_CV"].Fixed = FixedStyle.Left;
            foreach (GridColumn col1 in gridView1.Columns)
            {
                col1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", col1.FieldName , Commons.Modules.TypeLanguage);
            }
            foreach (GridColumn col1 in gridView2.Columns)
            {
                col1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", col1.FieldName, Commons.Modules.TypeLanguage);
            }
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachBTNam_TD", "btnCancel", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
    }
}