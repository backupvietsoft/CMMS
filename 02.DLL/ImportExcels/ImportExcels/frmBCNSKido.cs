using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ImportExcels
{
    public partial class frmBCNSKido : DevExpress.XtraEditors.XtraForm
    {
        public string Tinh, Quan, NXuong, LTBi, TThang, DThang;
        public string TieuDe;

        private DataTable _tableNSKD = new DataTable();
        public DataTable _dtNSKD
        {
            get
            {
                return _tableNSKD;
            }
            set
            {
                _tableNSKD = value;
            }
        }

        public frmBCNSKido()
        {

            InitializeComponent();
        }

        private void frmBCNSKido_Load(object sender, EventArgs e)
        {
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", "TIEU_DE", Commons.Modules.TypeLanguage);
            lblTitle.Text = TieuDe;

            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                grdData.DataSource = _tableNSKD;

                grvData.PopulateColumns();
                grvData.OptionsView.ColumnAutoWidth = true;
                grvData.OptionsView.AllowHtmlDrawHeaders = true;
                grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grvData.BestFitColumns();

                grvData.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", grvData.Columns[0].Caption, Commons.Modules.TypeLanguage);
                int i = 0;
                foreach (DataColumn column in _tableNSKD.Columns )
                {
                    if (i < 4)
                    {
                        grvData.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", column.Caption, Commons.Modules.TypeLanguage);
                    }
                    else
                    {
                        grvData.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "frmBCNSKido", column.Caption.Substring(0, 2), Commons.Modules.TypeLanguage) + "-" + 
                            column.Caption.Substring(2, column.Caption.Length - 2);

                        CreateSum(grvData, column.Caption);

                    }

                    if (i >= _tableNSKD.Columns.Count - 2)
                    {
                        grvData.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", column.Caption, Commons.Modules.TypeLanguage);
                    }
                    i += 1;
                }
                grvData.ExpandAllGroups();
            }
            catch { }
        }
        public void CreateSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";

            gridView1.Columns[column].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[column].DisplayFormat.FormatString = "{0:N2}";

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
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
                grvData.ExportToXls(path);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelWorkSheet.Cells.Font.Name = "Tahoma";
                excelWorkSheet.Cells.Font.Size = 10;


                int count_column = _tableNSKD.Columns.Count;
                int count_row = _tableNSKD.Rows.Count;
                int Cot = 1, Dong = 1;
                
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                for (int i = 1; i <= 12; i++)
                {
                    a1.EntireRow.Insert(Excel.Constants.xlTop);                    
                }
                
                //tao tieu de
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
                title.Merge(true);
                title.Font.Size = 13;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[3, 1] = TieuDe;
                

                Dong = 12; Cot = 1;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong + 1, Cot]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //Tinh
                Dong = 5; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, 
                    "frmBCNSKido", "TINH", Commons.Modules.TypeLanguage) ;
                excelWorkSheet.Cells[Dong, Cot+1] = Tinh;

                //Quan
                Dong = Dong+1; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmBCNSKido", "QUAN", Commons.Modules.TypeLanguage);
                excelWorkSheet.Cells[Dong, Cot + 1] = Quan;

                //Nha Xuong
                Dong = Dong + 1; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmBCNSKido", "NHA_XUONG", Commons.Modules.TypeLanguage);
                excelWorkSheet.Cells[Dong, Cot + 1] = NXuong;

                //LoaiMay
                Dong = Dong + 1; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmBCNSKido", "LOAI_MAY", Commons.Modules.TypeLanguage);
                excelWorkSheet.Cells[Dong, Cot + 1] = LTBi;

                //Tu Thang
                Dong = Dong + 1; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmBCNSKido", "TU_THANG", Commons.Modules.TypeLanguage);
                title.NumberFormat = "@";
                excelWorkSheet.Cells[Dong, Cot + 1] = TThang;

                //Den Thang
                Dong = Dong + 1; Cot = 2;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[Dong, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmBCNSKido", "DEN_THANG", Commons.Modules.TypeLanguage);
                title.NumberFormat = "@";
                excelWorkSheet.Cells[Dong, Cot + 1] = DThang;

                Dong++;

                //tao logo
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT LOGO FROM THONG_TIN_CHUNG"));
                DataView dv = new DataView(dtTmp);
                GetImage((byte[])dv[0]["LOGO"]);

                Excel.Sheets WS = excelWorkbook.Worksheets;
                Excel.Worksheet CurSheet = (Excel.Worksheet)WS.get_Item("Sheet1");
                Excel.Range CurCell = (Excel.Range)CurSheet.get_Range("A1", "A1");

                CurSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue
                        , 0, 0, 100, 20);

                File.Delete(Application.StartupPath + "\\logo.bmp");

                Dong++;
                excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, 1], excelWorkSheet.Cells[Dong + 1, count_column]).Font.Bold = true;


                excelWorkSheet.Columns.AutoFit();
                excelWorkSheet.Rows.AutoFit();
                excelApplication.ActiveWindow.DisplayGridlines = true;

                // Dinh dang cac cot dau
                excelWorkSheet.PageSetup.TopMargin = 35;
                excelWorkSheet.PageSetup.BottomMargin = 35;
                excelWorkSheet.PageSetup.LeftMargin = 25;
                excelWorkSheet.PageSetup.RightMargin = 25;
                excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                excelApplication.ActiveWindow.DisplayGridlines = true;

                //Them 1 dong de Merge
                excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, 1], excelWorkSheet.Cells[Dong, count_column]).Borders.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong+1, 1], excelWorkSheet.Cells[Dong+1, 1]).Borders.Color;
                excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, 1], excelWorkSheet.Cells[Dong, count_column]).Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, 1]).Interior.Color;

                //Merge 4 cot dau lai
                for (int i = 1; i <= 4; i++)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, i], excelWorkSheet.Cells[Dong + 1, i]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }

                //Merge 2 cot total cuoi
                for (int i = count_column - 1; i <= count_column ; i++)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, i], excelWorkSheet.Cells[Dong + 1, i]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                }

                // Tao Borders lai cho tieu de
                excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, 1], excelWorkSheet.Cells[Dong+1, count_column]).Borders.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 5], excelWorkSheet.Cells[Dong + 1, 5]).Borders.Color;

                //tao Width 4 cot dau
                excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]).ColumnWidth = 6;
                excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 2]).ColumnWidth = 19;
                excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 3], excelWorkSheet.Cells[1, 3]).ColumnWidth = 22;
                excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 4], excelWorkSheet.Cells[1, 4]).ColumnWidth = 20;

                //dinh dang cac cot bt sc
                for (Cot = 5; Cot < count_column -2; Cot++)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot + 1]);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.NumberFormat = "@";
                    
                    string tmp = _tableNSKD.Columns[Cot].ColumnName.ToString();
                    excelWorkSheet.Cells[Dong, Cot] = tmp.Substring(2, tmp.Length - 2).ToString();
                    excelWorkSheet.Cells[Dong + 1, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", "BT", Commons.Modules.TypeLanguage);
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot ]).ColumnWidth = 5;
                    Cot++;
                    excelWorkSheet.Cells[Dong + 1, Cot] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", "SC", Commons.Modules.TypeLanguage);
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot]).ColumnWidth = 5;
                }

                //dinh dang with 2 cot cuoi
                excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, Cot+1]).ColumnWidth = 5;

                //Xoa dong du cuoi sum
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 14, 1], excelWorkSheet.Cells[count_row+14, 1]);
                title.EntireRow.Delete(Excel.XlDirection.xlUp);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 14, 1], excelWorkSheet.Cells[count_row + 14, 1]);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                excelWorkSheet.Cells[count_row + 14, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCNSKido", "TOTAL", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 14, 1], excelWorkSheet.Cells[count_row + 14, count_row]);
                title.Font.Bold = true;

                //dinh dang so 
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[14, 5], excelWorkSheet.Cells[count_row + 14, count_column]);
                title.NumberFormat = "##";

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 14, 1], excelWorkSheet.Cells[count_row + 14, 1]);
                

                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
            catch
            {
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
                Vietsoft.Information.MsgBox(this, "XuatKhongThanhCong", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        public void GetImage(byte[] Logo)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            MemoryStream stream = new MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);

        }

    }
}