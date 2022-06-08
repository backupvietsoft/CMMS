using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace ImportExcels
{
    public partial class frmBCTonKhoSum : DevExpress.XtraEditors.XtraForm
    {
        public string Kho;
        public DateTime TuNgay;
        public DateTime DenNgay;

        private DataTable _tableSum = new DataTable();
        public DataTable _dtSum
        {
            get
            {
                return _tableSum;
            }
            set
            {
                _tableSum = value;
            }
        }


        private DataTable _tableCost = new DataTable();
        public DataTable _dtCost
        {
            get
            {
                return _tableCost;
            }
            set
            {
                _tableCost = value;
            }
        }

        public frmBCTonKhoSum()
        {
            InitializeComponent();
        }

        private void frmBCTonKhoSum_Load(object sender, EventArgs e)
        {
            LoadGridSum();
            LoadGridCost();
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExit", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadGridCost()
        {
            grdCost.DataSource = _tableCost;
            grvCost.PopulateColumns();
            grvCost.OptionsView.ColumnAutoWidth = true;
            grvCost.OptionsView.AllowHtmlDrawHeaders = true;
            grvCost.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvCost.BestFitColumns();

            int i = 0;
            foreach (DataColumn column in _tableCost.Columns)
            {

                if (i < 2)
                    grvCost.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                else
                {
                    if (i == _tableCost.Columns.Count -1)
                        grvCost.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                    else
                        grvCost.Columns[i].Caption = column.Caption.ToString();

                    CreateSum(grvCost, column.Caption);
                }
                i += 1;
            }
            
 
        }
        private void LoadGridSum ()
        {
            grdSum.DataSource = _tableSum;
            grvSum.PopulateColumns();
            grvSum.OptionsView.ColumnAutoWidth = false;
            grvSum.OptionsView.AllowHtmlDrawHeaders = true;
            grvSum.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvSum.BestFitColumns();

            int i = 0;
            foreach (DataColumn column in _tableSum.Columns)
            {              
                grvSum.Columns[i].Width = 100;
                grvSum.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                if (i != 0) CreateSum(grvSum, column.Caption);
                i += 1;
            }
            grvSum.Columns[0].Width = 200;
        
        }

        public void CreateSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";

            gridView1.Columns[column].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[column].DisplayFormat.FormatString = "{0:N2}";

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grvSum.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongCoDulieu", Commons.Modules.TypeLanguage));
                return;
            }

            Excel.Application excelApplication = new Excel.Application();

            try
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
                grdSum.ExportToXls(path);
                
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                excelApplication.Visible = false;
                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                int count_column = _tableSum.Columns.Count;
                int count_row = _tableSum.Rows.Count;


                //tao tieu de
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[1, 1] = lblTitle.Text;

                //tao kho
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[2, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "Kho", Commons.Modules.TypeLanguage) + Kho;
                //tao Tu Ngay
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[3, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "TuNgay", Commons.Modules.TypeLanguage) + TuNgay;
                //tao Den Ngay
                a1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[4, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "DenNgay", Commons.Modules.TypeLanguage) + DenNgay;

                //tao logo
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT LOGO FROM THONG_TIN_CHUNG"));
                DataView dv = new DataView(dtTmp);
                GetImage((byte[])dv[0]["LOGO"]);

                //Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                //a2.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Sheets WS = excelWorkbook.Worksheets;
                Excel.Worksheet CurSheet = (Excel.Worksheet)WS.get_Item("Sheet1");
                Excel.Range CurCell = (Excel.Range)CurSheet.get_Range("A1", "A1");

                CurSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue
                        , 0, 0, 100, 20);
                System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                //in Cost

                //////excelWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //////Excel.Worksheet excelWorkSheet2 = (Excel.Worksheet)excelWorkbook.Sheets[1]; co
                int Dong;
                int cot = 1;
                Dong = count_row + 10;

                Excel.Range title1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, 1], excelWorkSheet.Cells[Dong, _tableCost.Columns.Count]);
                title1.Merge(true);
                title1.Font.Bold = true;
                title1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "SUMMARYCOSTCENTER", Commons.Modules.TypeLanguage);
                title1.Font.Name = "Tahoma";
                title1.Font.Size = 8;

                Dong = Dong + 1;
                Excel.Range r = (Excel.Range)excelWorkSheet.Cells[1, 1];
                foreach (GridColumn col in grvCost.Columns)
                {
                    r = (Excel.Range)excelWorkSheet.Cells[Dong, cot];
                    r.Value2 = col.Caption.ToString();
                    r.Font.Name = "Tahoma";
                    r.Font.Size = 8;

                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));

                    r.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    r.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //r.Interior.Color = 11119017.0;//System.Drawing.Color.FromArgb(128, 128, 128);
                    r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(192, 192, 192));

                    cot += 1;

                }
                Dong += 1;
                foreach (DataRow row in _tableCost.Rows)
                {
                    cot = 1;
                    r = (Excel.Range)excelWorkSheet.Cells[Dong, cot];
                    r.Value2 = row[0].ToString(); cot += 1;
                    r.Font.Name = "Tahoma"; r.Font.Size = 8;
                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));

                    r = (Excel.Range)excelWorkSheet.Cells[Dong, cot];
                    r.Value2 = row[1].ToString(); cot += 1;
                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));

                    r.Font.Name = "Tahoma"; r.Font.Size = 8;
                    for (cot = 3; cot < _tableCost.Columns.Count + 1; cot++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[Dong, cot];
                        r.Value2 = row[cot - 1].ToString();
                        r.NumberFormat = "#,##0.00";
                        r.Font.Name = "Tahoma"; r.Font.Size = 8;
                        r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        r.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));
                    }

                    Dong += 1;
                }

                for (cot = 1; cot < _tableCost.Columns.Count + 1; cot++)
                {
                    r = (Excel.Range)excelWorkSheet.Cells[Dong, cot];
                    r.Font.Name = "Tahoma"; r.Font.Size = 8;
                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(169, 169, 169));
                    r.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));
                    if (cot > 2)
                    {
                        r.FormulaArray = "=SUM(" + TimDiemExecl(Dong - _tableCost.Rows.Count, cot) + ":" + TimDiemExecl(Dong - 1, cot) + ")";
                        r.NumberFormat = "#,##0.00";
                    }
                }
                excelWorkSheet.Columns.AutoFit();
                excelWorkSheet.Rows.AutoFit();
                excelApplication.ActiveWindow.DisplayGridlines = true;


                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
            catch {
                excelApplication.Visible = true;
                excelApplication.Quit();
                this.Cursor = Cursors.Default;
                Vietsoft.Information.MsgBox(this, "XuatKhongThanhCong", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        public void GetImage(byte[] Logo)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }
        public string TimDiemExecl(int Dong, int Cot)
        {
            string GTri = "";
            if (Cot > 26)
            {
                GTri = Convert.ToChar(((Cot - 1) / 26) + 64).ToString();
                GTri = GTri + Convert.ToChar(((Cot - 1) % 26) + 65).ToString();
            }
            else
            {
                GTri = Convert.ToChar(Cot + 64).ToString();
            }
            //If Dong <= 0 Then TimDiemExecl = TimDiemExecl Else TimDiemExecl = TimDiemExecl & Dong
            if (Dong > 0)
                GTri = GTri + Dong;
            return GTri;
        }
    }
}