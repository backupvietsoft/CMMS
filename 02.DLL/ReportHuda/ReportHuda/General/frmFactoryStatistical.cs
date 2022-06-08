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
    public partial class frmFactoryStatistical : DevExpress.XtraEditors.XtraForm
    {
        private bool isFirst = false;
        public string ms_n_xuong = "VS"; // khi lam thuc te nho truyen ma so nha xuong vao 
        public frmFactoryStatistical()
        {
            InitializeComponent();
        }

        private void frmFactoryStatistical_Load(object sender, EventArgs e)
        {

            try
            {
                txtMs_NX.Text = ms_n_xuong;
                txtTen_NX.Text = Convert.ToString((SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_TEN_NX", ms_n_xuong)));
                txtTu_Ngay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                txtDen_Ngay.DateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                LoadData();
                isFirst = true;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                
                btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnExcute.Name, Commons.Modules.TypeLanguage);
                btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnCancel.Name, Commons.Modules.TypeLanguage);
            }
            catch
            {

                MessageBox.Show("Vui lòng truyền mã số nhà xưởng vào", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadData()
        {
            DataTable _table = new DataTable();
            int index = cmbOption.SelectedIndex;
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NHA_XUONG_THONG_KE_VT", txtTu_Ngay.DateTime, txtDen_Ngay.DateTime, index, ms_n_xuong));
            gridControl1.DataSource = _table;
            if (index == 0)
            {
                gridView1.Columns["NGAY_THAY_KE"].Visible = false;
                gridView1.Columns["NGAY_HH_BH"].Visible = true;
            }
            else
            {
                gridView1.Columns["NGAY_THAY_KE"].Visible = true;
                gridView1.Columns["NGAY_HH_BH"].Visible = false;
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.AppearanceHeader.Options.UseTextOptions = true;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.Width = 150;
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, col.FieldName, Commons.Modules.TypeLanguage);
                switch(col.FieldName)
                {
                    case "TEN_MAY":
                        col.Width = 200;
                        break;
                    case "TEN_VT":
                        col.Width = 250;
                        break;
                    case "NHA_CC":
                        col.Width =350;
                        break;
                }
                
            }
            
        }
        private void txtTu_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (txtTu_Ngay.DateTime <= txtDen_Ngay.DateTime)
                        LoadData();
                }
            }
            catch { }
        }

        private void txtTu_Ngay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > txtDen_Ngay.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void txtDen_Ngay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < txtTu_Ngay.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }

        private void txtDen_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (txtTu_Ngay.DateTime <= txtDen_Ngay.DateTime)
                        LoadData();
                }
            }
            catch { }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "khongcodulieudein", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;

            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            int count_column = gridView1.Columns.Count - 1;
            int count_row = gridView1.RowCount;
            int _row = 1;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "F"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[_row, "B"]);
            //CurCell.MergeCells = true;
            CurCell.Borders.LineStyle = 0;

            ReportHuda.Class.PrintExcel.GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 140, 30);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            _row++;

            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            Excel.Range title1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            title.RowHeight = 9;


            _row++;
            
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            title1.Merge(true);
            title1.Font.Bold = true;
            title1.Font.Size = 14;
            title1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            title1.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, 1] = lblTitle.Text;
            _row++;



            
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;            
            title.WrapText = true;
            excelWorkSheet.Cells[_row, "B"] = lblNhaXuong.Text + " : " + txtMs_NX.Text;
            title.Borders.LineStyle = 0;
            title.Font.Size = 10;


            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "F"]);
            title.Merge(true);
            title.WrapText = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "D"] = lblTenNX.Text + " : " + txtTen_NX.Text;
            title.Font.Size = 10;
            _row++;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;            
            title.WrapText = true;
            excelWorkSheet.Cells[_row, "B"] = lblTNgay.Text + " : " + txtTu_Ngay.Text;
            title.Borders.LineStyle = 0;
            title.Font.Size = 10;


            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "D"], excelWorkSheet.Cells[_row, "F"]);
            title.Merge(true);
            title.WrapText = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;            
            excelWorkSheet.Cells[_row, "D"] = lblDNgay.Text + " : " + txtDen_Ngay.Text;
            title.Borders.LineStyle = 0;
            title.Font.Size = 10;
            _row++;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "F"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.WrapText = true;
            excelWorkSheet.Cells[_row, "B"] = lblHanBH.Text + " : " + cmbOption.Text;
            title.Borders.LineStyle = 0;
            title.Font.Size = 10;
            _row++;


            excelWorkSheet.Columns.AutoFit();

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "A"], excelWorkSheet.Cells[count_row + _row, "A"]);
            title.ColumnWidth = 12;
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "B"], excelWorkSheet.Cells[count_row + _row, "B"]);
            title.ColumnWidth =18;	
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "C"], excelWorkSheet.Cells[count_row + _row, "C"]);
            title.ColumnWidth = 20;	
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "D"], excelWorkSheet.Cells[count_row + _row, "D"]);
            title.ColumnWidth = 10;
            title.NumberFormat = "dd/MM/yyyy";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "E"], excelWorkSheet.Cells[count_row + _row, "E"]);
            title.NumberFormat = "dd/MM/yyyy";
            title.ColumnWidth = 14;	
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "F"], excelWorkSheet.Cells[count_row + _row, "F"]);
            title.ColumnWidth = 18;
            title.NumberFormat = "@";
            title.WrapText = true;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row , "A"], excelWorkSheet.Cells[count_row + _row, "F"]);
            title.Borders.LineStyle = 1;
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
            title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row - 1, 1], excelWorkSheet.Cells[_row - 1, 1]).Interior.Color;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "F"]);
            title.Font.Bold = true;

            excelWorkSheet.Rows.AutoFit();
            
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            title.RowHeight = 9;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, "A"], excelWorkSheet.Cells[5, "B"]);
            title.RowHeight = 9;




            excelApplication.ActiveWindow.DisplayGridlines = true;
            //excelWorkSheet.PageSetup.PrintTitleRows = "$10:$10";
            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            excelWorkSheet.PageSetup.LeftMargin = 30;
            excelWorkSheet.PageSetup.RightMargin = 30;
            excelWorkSheet.PageSetup.BottomMargin = 30;
            excelWorkSheet.PageSetup.TopMargin = 30;
            excelWorkSheet.PageSetup.FooterMargin = 50;
            excelWorkSheet.PageSetup.HeaderMargin = 50;
            
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;

        }

       

      
    }
}