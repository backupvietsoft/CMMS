using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel;

namespace WareHouse
{
    public partial class frmReportViewer_Y_MATERIAL : DevExpress.XtraEditors.XtraForm
    {
        string path = "";
        public System.Data.DataTable _TableSource;
        public DateTime tungay;
        public DateTime denngay;
        public string loaiVt = "";
       
        public string curr = "";
        public string nha_kho = "";
        public frmReportViewer_Y_MATERIAL()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Y_MATERIAL_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblTest.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "TitleEXEL", Commons.Modules.TypeLanguage);
            //ecomaintGrid1.ShowPrintPreview();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
           // DialogResult res = f.ShowDialog();
            //if (res.Equals(DialogResult.OK))
            //{
            //    path = f.FileName;

            //}
            //else
            //    return;
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
            finally
            {
                if (string.IsNullOrEmpty(path))
                    path = @"D:\" + lblTest.Text  + "_" + DateTime.Now.Millisecond + ".xls";
            }
            progressBar1.Value = 80;
            this.ecomaintGrid1.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count = _TableSource.Columns.Count;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            System.Data.DataTable dtThongtin = new System.Data.DataTable();
            Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            dtThongtin.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_TIN_CHUNG"));
            // Name company
            Excel.Range namecompany = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count]);
            namecompany.Font.Bold = true;
            namecompany.Merge(true);
            namecompany.Font.Bold = true;

            namecompany.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            namecompany.Value2 = dtThongtin.Rows[0]["TEN_CTY_TIENG_ANH"].ToString();

            // Address company
            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            Excel.Range addcompany = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count]);
            addcompany.Font.Bold = true;
            addcompany.Merge(true);
            addcompany.Font.Bold = true;
            addcompany.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            addcompany.Value2 = dtThongtin.Rows[0]["DIA_CHI_ANH"].ToString();

            // Phone
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range tel = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count]);
            tel.Font.Bold = true;
            tel.MergeCells = true;
            tel.Font.Bold = true;
            tel.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            tel.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "Tel", Commons.Modules.TypeLanguage) + " " + dtThongtin.Rows[0]["Phone"].ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "Fax", Commons.Modules.TypeLanguage) + " " + dtThongtin.Rows[0]["Fax"].ToString();

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range excelRange1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count]);
            excelRange1.Merge(true);
            excelRange1.Font.Name = "Tahoma";
            excelRange1.Font.Size = 14;
            excelRange1.Font.Bold = true;
            excelRange1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelRange1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[4, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "TitleEXEL", Commons.Modules.TypeLanguage);
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range excelRange2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count]);
            excelRange2.Merge(true);
            excelRange2.Font.Name = "Tahoma";
            excelRange2.Font.Bold = true;
            excelRange2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelRange2.VerticalAlignment = XlVAlign.xlVAlignCenter;
            excelWorkSheet.Cells[5, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "tungay", Commons.Modules.TypeLanguage) + " " + tungay.ToShortDateString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "denngay", Commons.Modules.TypeLanguage) + " " + denngay.ToShortDateString();
           
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range kho = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count]);
            kho.Font.Bold = true;
            kho.Merge(true);
            kho.MergeCells = true;
            kho.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            kho.VerticalAlignment = XlVAlign.xlVAlignCenter;
            kho.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "warehouse", Commons.Modules.TypeLanguage) + " " + nha_kho;

            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range mate_type = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count]);
            mate_type.Font.Bold = true;
            mate_type.Merge(true);
            mate_type.MergeCells = true;
            mate_type.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            mate_type.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "Warehouse", Commons.Modules.TypeLanguage) + " " + loaiVt ;

            Excel.Range a8 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count]);
            a8.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range currency = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count]);
            currency.Font.Bold = true;
            currency.Merge(true);
            currency.MergeCells = true;
            currency.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            currency.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "Currency", Commons.Modules.TypeLanguage) + " " + curr;
            Excel.Range a9 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count]);
            a9.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range blank = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[9, count]);
            blank.Merge(true);
            try
            {
                int rows = a3.CurrentRegion.Rows.Count + 150;
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[12, 7], excelWorkSheet.Cells[rows, 17]);
                content.NumberFormat = "###,##0.00";


                //Excel.Range Tong = excelWorkSheet.get_Range(excelWorkSheet.Cells[gridView1.RowCount + 15, 1], excelWorkSheet.Cells[gridView1.RowCount + 15, 6]);
                ////Tong.Font.Bold = true;
                //Tong.Merge(true);
                //Tong.MergeCells = true;
                //Tong.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //Tong.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "excTongTien", Commons.Modules.TypeLanguage);
            }
            catch
            {

            }
            progressBar1.Value = 100;
            excelWorkSheet.Columns.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;
            int row = a1.CurrentRegion.Rows.Count;
            excelApplication.Visible = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
        }

        private void gridView1_CustomDrawRowFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName != "GIA_TRI_TON_DAU")
            //    return;

            //if (e.Column.FieldName != "SL_TON_DAU")
            //    return;

            //bool isPrinting = e.Handled;
            //e.Handled = true;
            //e.Appearance.BackColor = Color.Yellow; //When i change this code to Color.Transparent, the text "Custom Draw" in printing preview so bad?
            //e.Appearance.FillRectangle(e.Cache, e.Bounds);
            ////Rectangle rect = e.Bounds;
            ////rect.Width = rect.Height;
            ////e.Appearance.FillRectangle(e.Cache, rect);
            ////e.Graphics.DrawLine(new Pen(Brushes.Red, 3), new Point(rect.X, rect.Y), new Point(rect.Right, rect.Bottom));
            ////e.Graphics.DrawEllipse(new Pen(Brushes.Red, 3), rect);
            //e.Graphics.DrawString("Custom yrtyrtyrtyrtyrtyrtDraw", DevExpress.Utils.AppearanceObject.DefaultFont, Brushes.Black, e.Bounds);

        }
    }
}
