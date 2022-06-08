using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.General
{
    public partial class frmMaintenance : DevExpress.XtraEditors.XtraForm
    {
        public string ms_thiet_bi; // khi lam thuc te nho truyen ms thiet bi vao
        DataTable _table = new DataTable();
        public frmMaintenance()
        {
            InitializeComponent();
        }
        private void PrepareData()
        {
            if (string.IsNullOrEmpty(ms_thiet_bi))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaCoThietBi", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtMs_May.Text = ms_thiet_bi;
            System.Data.SqlClient.SqlDataReader reader =  SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_MAY_PTB_CV_TH", ms_thiet_bi, Commons.Modules.TypeLanguage);
            reader.Read();
            txtTen_May.Text = reader.GetString(1);
            txtNhom_May.Text =Convert.ToString(reader.GetString(2));
            txtLoai_May.Text =Convert.ToString(reader.GetString(3));
            txtDiaDiem.Text =Convert.ToString(reader.GetString(4));
            txtDayChuyen.Text =Convert.ToString(reader.GetString(5));
            reader.Close();
            cmbTien_Do.SelectedIndex = 0;
            
        }
        private void LoadData()
        {
             _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_CV_CAN_THUC_HIEN", ms_thiet_bi, Commons.Modules.TypeLanguage, cmbTien_Do.SelectedIndex));
            gdList.DataSource = _table;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvList.Columns)
            {
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, col.FieldName, Commons.Modules.TypeLanguage);
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
                col.Width = 120;
            }
        }
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                PrepareData();
                btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnExcute.Name, Commons.Modules.TypeLanguage);
                btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnCancel.Name, Commons.Modules.TypeLanguage);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch
            {
                
                MessageBox.Show("Vui lòng truyền mã số máy vào", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void cmbTien_Do_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
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
        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0)
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
                gdList.ExportToXls(path);
                Excel.Application excelApplication = new Excel.Application();
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int count_column = _table.Columns.Count;
                int count_row = _table.Rows.Count;
                int _row = 1;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
                Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                _row++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
                _row++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
                _row++;
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
                CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[_row, "B"]);
                CurCell.MergeCells = true;
                CurCell.Borders.LineStyle = 0;
                GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 180, 50);
                System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                _row++;


                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, 1] = lblTitle.Text;
                _row++;

                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "A"] = lblMS_May.Text + ":" + txtMs_May.Text;


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "C"] = lblTen_May.Text + ":" + txtTen_May.Text;

                _row++;

                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "A"] = lblDiaDiem.Text + ":" + txtDiaDiem.Text;


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "C"] = lblDayChuyen.Text + ":" + txtDayChuyen.Text;

                _row++;
                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "A"] = lblLoai_TB.Text + ":" + txtLoai_May.Text;


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
                title.Merge(true);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                title.Borders.LineStyle = 0;
                excelWorkSheet.Cells[_row, "C"] = lblNhom_TB.Text + ":" + txtNhom_May.Text;

                _row++;
                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
                title.Merge(true);
                title.Borders.LineStyle = 0;
                excelApplication.Visible = true;
                excelWorkSheet.Columns.AutoFit();

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
                title.ColumnWidth = "17";
                title.WrapText = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "B"]);
                title.ColumnWidth = "16.14";
                title.WrapText = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "K"], excelWorkSheet.Cells[_row, "K"]);
                title.ColumnWidth = "17";
                title.WrapText = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "L"], excelWorkSheet.Cells[_row, "L"]);
                title.ColumnWidth = "17";
                title.WrapText = true;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "N"], excelWorkSheet.Cells[_row, "N"]);
                title.ColumnWidth = "17";
                title.WrapText = true;
                excelWorkSheet.Rows.AutoFit();
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkSheet.PageSetup.PrintTitleRows = "$10:$10";
                excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                excelWorkSheet.PageSetup.LeftMargin = 0;
                excelWorkSheet.PageSetup.RightMargin = 0;
                excelWorkSheet.PageSetup.BottomMargin = 0;
                excelWorkSheet.PageSetup.TopMargin = 0;
                excelWorkSheet.PageSetup.FooterMargin = 0.5;
                excelWorkSheet.PageSetup.HeaderMargin = 0.5;
                excelWorkSheet.PageSetup.Zoom = 70;
                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "khongcodulieudein", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}