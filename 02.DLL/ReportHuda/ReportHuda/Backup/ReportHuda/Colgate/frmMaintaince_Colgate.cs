using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;


using DevExpress.XtraGrid.Columns;


namespace ReportHuda.Colgate
{
    public partial class frmMaintaince_Colgate : DevExpress.XtraEditors.XtraForm
    {
        public DataTable _tableSource = new DataTable();
        public DataTable _tableMaintaince = new DataTable();
        bool isFirst = true;
        public string date;
        public frmMaintaince_Colgate()
        {
            InitializeComponent();
        }

        private void frmMaintaince_Colgate_Load(object sender, EventArgs e)
        {
            gdMachine.DataSource = _tableSource;
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            int c = gridView1.Columns.Count;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                if (!col.Name.Equals("colMachineName") && !col.Name.Equals("colTotal"))
                {
                    string stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        col.Name.Substring(3, 1), Commons.Modules.TypeLanguage);

                    col.Caption = stmp;
                }
                else
                {
                    if (col.Name.Equals("colTotal")) col.Visible = false;
                    if (col.Name.Equals("colMachineName")) col.Width = 200;
                
                }

            }
        }
      
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (isFirst)
            {
                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle == 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(155, 194, 230);
                    //e.Appearance.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                int count = 0;
                string c = "";
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                {
                    if (col.Name != "colMachineName" && col.Name != "colTotal")
                    {
                        string category = View.GetRowCellValue(e.RowHandle, col).ToString();
                        c += View.GetRowCellValue(e.RowHandle, col).ToString();
                        string[] color;
                        color = category.Split(' ');
                        if (color.Length > 2)
                        {
                            if (e.Column.Name == col.Name)
                            {
                                e.Appearance.ForeColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                                e.Appearance.BackColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                            }
                        }
                        count = e.RowHandle;
                    }
                }
                if (string.IsNullOrEmpty(c))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 153, 0);
                }

                if (e.Column.Name == "colTotal")
                {
                    e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
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
                gdMachine.ExportToXlsx(path);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                   " SELECT LOGO,TEN_CTY_TIENG_VIET,TEN_CTY_TIENG_ANH FROM THONG_TIN_CHUNG"));
                
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;

                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int count_column = _tableSource.Columns.Count;
                int count_row = _tableSource.Rows.Count;
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 12]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 12]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Size = 11;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;
                if (Commons.Modules.TypeLanguage == 0)
                    excelWorkSheet.Cells[1, 2] = dtTmp.Rows[0]["TEN_CTY_TIENG_VIET"];
                else
                    excelWorkSheet.Cells[1, 2] = dtTmp.Rows[0]["TEN_CTY_TIENG_ANH"];


                
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 13], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 22;
                excelWorkSheet.Cells[1, 13] = lblTitle.Text;
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = (Excel.Range)excelWorkSheet.Cells[2, 1];
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.NumberFormat = "mmmm yyyy";
                title.Value2 = date;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 2], excelWorkSheet.Cells[2, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = "Dates of Maintenance";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                excelWorkSheet.Columns.ColumnWidth = 2;
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, 1]);
                content.ColumnWidth = 20;
                Excel.Range content1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, count_column], excelWorkSheet.Cells[count_row, count_column]);
                content1.ColumnWidth = 5;
                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                int rowMaintaince = count_row + 6;

                Excel.Range r;
                int j = 2;
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", "A1");
                CurCell.RowHeight = 42;
                GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");

                Excel.Range oResizeRange = (Excel.Range)excelWorkSheet.Rows.Cells[rowMaintaince, "A"];
                int top = Convert.ToInt32(oResizeRange.Top);
                Excel.Shape textBox = excelWorkSheet.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 10, top, 90, 50);
                textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Font.Bold = true;
                textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Text
                    = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "hoanthanh", Commons.Modules.TypeLanguage);

                int count = _tableMaintaince.Rows.Count / 2;
                int k = 0;
                for (int i = 0; i < count; i++)
                {
                    j = 2;
                    r = (Excel.Range)excelWorkSheet.Cells[rowMaintaince, j];
                    r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[k][3]), Convert.ToInt16(_tableMaintaince.Rows[k][4]), Convert.ToInt16(_tableMaintaince.Rows[k][5])));
                    r = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 7]);
                    r.Merge(true);
                    r.Value2 = _tableMaintaince.Rows[k][2];
                    k++;
                    j = 8;
                    r = (Excel.Range)excelWorkSheet.Cells[rowMaintaince, j];
                    r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[k][3]), Convert.ToInt16(_tableMaintaince.Rows[k][4]), Convert.ToInt16(_tableMaintaince.Rows[k][5])));
                    r = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 9], excelWorkSheet.Cells[rowMaintaince, 13]);
                    r.Merge(true);
                    r.Value2 = _tableMaintaince.Rows[k][2];
                    k++;
                    rowMaintaince += 2;
                }

                if (_tableMaintaince.Rows.Count % 2 == 1)
                {
                    j = 2;
                    r = (Excel.Range)excelWorkSheet.Cells[rowMaintaince, j];
                    r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[k][3]), Convert.ToInt16(_tableMaintaince.Rows[k][4]), Convert.ToInt16(_tableMaintaince.Rows[k][5])));
                    r = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 7]);
                    r.Merge(true);
                    r.Value2 = _tableMaintaince.Rows[k][2];
                }
                rowMaintaince = count_row + 6;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 16], excelWorkSheet.Cells[rowMaintaince, 24]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 16] = "ENGINEERING";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 25], excelWorkSheet.Cells[rowMaintaince, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 25] = "PRODUCTION";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                rowMaintaince += 1;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 16], excelWorkSheet.Cells[rowMaintaince, 20]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 16] = "Prepare by";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 21], excelWorkSheet.Cells[rowMaintaince, 24]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 21] = "Review by";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 25], excelWorkSheet.Cells[rowMaintaince, 28]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 25] = "TECH";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 29], excelWorkSheet.Cells[rowMaintaince, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                excelWorkSheet.Cells[rowMaintaince, 29] = "Pro M";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                rowMaintaince += 1;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 16], excelWorkSheet.Cells[rowMaintaince + 4, 20]);
                title.MergeCells = true;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 21], excelWorkSheet.Cells[rowMaintaince + 4, 24]);
                title.MergeCells = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 25], excelWorkSheet.Cells[rowMaintaince + 4, 28]);
                title.MergeCells = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 29], excelWorkSheet.Cells[rowMaintaince + 4, count_column]);
                title.MergeCells = true;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 6, 14], excelWorkSheet.Cells[rowMaintaince + 4, 15]);
                title.MergeCells = true;
                title.Value2 = "CONFIRM";
                title.Orientation = 90;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 6, 14], excelWorkSheet.Cells[rowMaintaince + 4, count_column]);
                title.Borders.LineStyle = 1;
                title.Borders.Weight = 4;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[4, 1]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; ;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Cursor = Cursors.Default;
            excelApplication.Visible = true;
        }
    }
}