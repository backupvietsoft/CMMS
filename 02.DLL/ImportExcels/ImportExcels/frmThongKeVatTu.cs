using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ImportExcels
{
    public partial class frmThongKeVatTu : DevExpress.XtraEditors.XtraForm
    {
        public string TieuDe, MsNX = "2.2", TenNX = "None Be ta 2";
        public frmThongKeVatTu()
        {
            InitializeComponent();
        }

        private void frmThongKeVatTu_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblMS.Text = MsNX;
            lblTen.Text = TenNX;

            dtTN.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            dtDN.DateTime = dtTN.DateTime.AddMonths(1).AddDays(-1);

            TaoLuoi();
            xtraTabPage1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "xtraTabPage1", Commons.Modules.TypeLanguage);
            xtraTabPage2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "xtraTabPage2", Commons.Modules.TypeLanguage);
        }
        private void SuDung()
        {
            Excel.Application excelApplication = new Excel.Application();
            try            
            {
                Boolean LoaiBC ;
                if (tabData.SelectedTabPageIndex == 0) LoaiBC = false; else LoaiBC = true;

                if (LoaiBC)
                {
                    if (grvNX.RowCount == 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongCoDulieu", Commons.Modules.TypeLanguage));
                        return;
                    }                
                }
                else
                {
                    if (grvData.RowCount == 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongCoDulieu", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
                string path = MashjExcel.MashjSaveFiles("Excel file (*.xls)|*.xls");
                if (string.IsNullOrEmpty(path.ToString())) return;

                this.Cursor = Cursors.WaitCursor;
                
                excelApplication.Visible = false;
                //excelApplication.Visible = true;
                if (LoaiBC) grvNX.ExportToXls(path); else grvData.ExportToXls(path);


                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                excelWorkSheet.PageSetup.BottomMargin = 35;
                excelWorkSheet.PageSetup.LeftMargin = 25;
                excelWorkSheet.PageSetup.RightMargin = 25;


                excelWorkSheet.Cells.Font.Name = "Tahoma";
                excelWorkSheet.Cells.Font.Size = 10;

                int count_column;
                int count_row;
                if (LoaiBC)
                {
                    count_column = grvNX.Columns.Count;
                    count_row = grvNX.RowCount;
                }
                else
                {
                    count_column = grvData.Columns.Count;
                    count_row = grvData.RowCount;
                
                }
                int Cot = 1, Dong = 1;

                Excel.Range Mashj = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong, Cot], excelWorkSheet.Cells[Dong, count_column]);
                Mashj.Font.Bold = true;
                Mashj.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Mashj.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                Mashj = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 3, Cot], excelWorkSheet.Cells[count_row + 3, count_column]);
                Mashj.Font.Bold = true;
                Mashj.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[count_row + 3, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmThongKeVatTu", "TongCong", Commons.Modules.TypeLanguage);

                Mashj = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 2, Cot], excelWorkSheet.Cells[count_row + 2, count_column]);
                Mashj.EntireRow.Delete(Excel.XlDirection.xlUp);


                //them dong
                if (!LoaiBC)
                    MashjExcel.MashjThemDong(excelWorkSheet, Excel.Constants.xlTop, 7, 1, count_column);
                else
                    MashjExcel.MashjThemDong(excelWorkSheet, Excel.Constants.xlTop, 9, 1, count_column);
                //tao logo
                MashjExcel.MashjTaoLogo(excelWorkSheet, 0, 0, 100, 20);
                //tieu de
                Dong = 3;
                MashjExcel.MashjDinhDang(excelWorkSheet, lblTitle.Text, Dong, Cot, 14, true, "@",
                    true, Dong, count_column,
                    Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter);

                Dong = 5; Cot = 2;
                if (!LoaiBC)
                {
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblMSNX.Text, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, MsNX, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblTenNX.Text, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, TenNX, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Dong++; Cot = 2;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblTN.Text, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, dtTN.DateTime.ToShortDateString(),
                        Dong, Cot, 10, true, "",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblDN.Text, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, dtDN.DateTime.ToShortDateString(),
                        Dong, Cot, 10, true, "",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    MashjExcel.MashjDong(excelApplication, excelWorkbooks, excelWorkbook, excelWorkSheet,
                        false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape,
                        35, 35, 25, 25, 0, 0, 0);

                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]).ColumnWidth = 19;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 2]).ColumnWidth = 25;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 3], excelWorkSheet.Cells[1, 3]).ColumnWidth = 29;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 4], excelWorkSheet.Cells[1, 4]).ColumnWidth = 25;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 5], excelWorkSheet.Cells[1, 5]).ColumnWidth = 22;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 6], excelWorkSheet.Cells[1, 6]).ColumnWidth = 19;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[9, count_column],
                            excelWorkSheet.Cells[count_row + 9, count_column]).NumberFormat = "0.00";
                    CreatChartColumn(excelWorkSheet, count_row + 12, 1100, lblTitle.Text);


                }
                else
                {
                    Cot = 1;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblMSNX.Text + " : ", Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignRight,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, MsNX, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Dong++; Cot = 1;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblTenNX.Text + " : ", Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignRight,
                        Excel.XlVAlign.xlVAlignCenter);

                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, TenNX, Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Dong++; Cot = 1;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblTN.Text + " : ", Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignRight,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, dtTN.DateTime.ToShortDateString(),
                        Dong, Cot, 10, true, "",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    Dong++; Cot = 1;
                    MashjExcel.MashjDinhDang(excelWorkSheet, lblDN.Text + " : ", Dong, Cot, 10, true, "@",
                        Excel.XlHAlign.xlHAlignRight,
                        Excel.XlVAlign.xlVAlignCenter);
                    Cot++;
                    MashjExcel.MashjDinhDang(excelWorkSheet, dtDN.DateTime.ToShortDateString(),
                        Dong, Cot, 10, true, "",
                        Excel.XlHAlign.xlHAlignLeft,
                        Excel.XlVAlign.xlVAlignCenter);

                    MashjExcel.MashjDong(excelApplication, excelWorkbooks, excelWorkbook, excelWorkSheet,
                        false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait,
                        35, 35, 25, 25, 0, 0, 0);

                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]).ColumnWidth = 31;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 2]).ColumnWidth = 36;
                    excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 3], excelWorkSheet.Cells[1, 3]).ColumnWidth = 29;

                    excelWorkSheet.get_Range(excelWorkSheet.Cells[11, count_column],
                        excelWorkSheet.Cells[count_row + 11, count_column]).NumberFormat = "0.00";

                    CreatChartColumn(excelWorkSheet, count_row + 14, 1100, lblTitle.Text);

                }

                this.Cursor = Cursors.Default;
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo;
                excelApplication.Visible = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    excelApplication.ActiveWindow.DisplayGridlines = true;
                    excelApplication.Visible = true;
                }
                catch { }
                this.Cursor = Cursors.Default;
                Vietsoft.Information.MsgBox(this, "XuatKhongThanhCong", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            this.Cursor = Cursors.Default;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SuDung();
        }
        private void TaoLuoi()
        {
            if (tabData.SelectedTabPageIndex == 0) TaoLuoiMay(); else TaoLuoiNX();            
        }
        private void TaoLuoiMay()
        {
            int LoaiBC;
            //0 su dung 1 du tru
            if (optSDung.Checked) LoaiBC = 0; else LoaiBC = 1;
            try
            {
                System.Data.DataTable dtLuoi = new System.Data.DataTable();
                dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                    "MashjThongKeVatTu", MsNX, dtTN.DateTime, dtDN.DateTime, LoaiBC));
                grdData.DataSource = dtLuoi;
                if (grvData.OptionsBehavior.Editable == true)
                {
                    grvData.PopulateColumns();
                    grvData.OptionsView.ColumnAutoWidth = true;
                    grvData.OptionsView.AllowHtmlDrawHeaders = true;
                    grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                    grvData.BestFitColumns();
                    grvData.OptionsBehavior.Editable = false;

                    int i = 0;
                    foreach (DataColumn column in dtLuoi.Columns)
                    {
                        grvData.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                        i += 1;
                    }
                }
                CreateSum(grvData, "SO_TIEN");
            }
            catch { }
        }
        private void TaoLuoiNX()
        {
            int LoaiBC;
            //0 su dung 1 du tru
            if (optSDung.Checked) LoaiBC = 0; else LoaiBC = 1;
            try
            {
                System.Data.DataTable dtLuoi = new System.Data.DataTable();
                dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                    "MashjThongKeVatTuNX", MsNX, dtTN.DateTime, dtDN.DateTime, LoaiBC));
                grdNX.DataSource = dtLuoi;
                if (grvNX.OptionsBehavior.Editable == true)
                {
                    grvNX.PopulateColumns();
                    grvNX.OptionsView.ColumnAutoWidth = true;
                    grvNX.OptionsView.AllowHtmlDrawHeaders = true;
                    grvNX.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                    grvNX.BestFitColumns();
                    grvNX.OptionsBehavior.Editable = false;

                    int i = 0;
                    foreach (DataColumn column in dtLuoi.Columns)
                    {
                        grvNX.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                        i += 1;
                    }
                }
                CreateSum(grvNX, "SO_TIEN");
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

        private void dtTN_EditValueChanged(object sender, EventArgs e)
        {
            TaoLuoi();
        }

        private void dtDN_EditValueChanged(object sender, EventArgs e)
        {
            TaoLuoi();
        }

        private void optSDung_CheckedChanged(object sender, EventArgs e)
        {
            TaoLuoi();
        }

        private void optDTru_CheckedChanged(object sender, EventArgs e)
        {
            TaoLuoi();
        }

        public void CreatChartColumn(Excel.Worksheet Exelsheeta, int vRowEx, int vWith, string vChartName)
        {
            try
            {
                Boolean LoaiBC;
                if (tabData.SelectedTabPageIndex == 0) LoaiBC = false; else LoaiBC = true;


                double vTop = 10;
                double vWidth = 10;
                vTop = (double)Exelsheeta.get_Range(Exelsheeta.Cells[vRowEx, 1], Exelsheeta.Cells[vRowEx, 1]).Top;
                if (!LoaiBC)
                    vWidth = (double)Exelsheeta.get_Range(Exelsheeta.Cells[vRowEx, 1], Exelsheeta.Cells[vRowEx, 6]).Width - 8;
                else
                    vWidth = (double)Exelsheeta.get_Range(Exelsheeta.Cells[vRowEx, 1], Exelsheeta.Cells[vRowEx, 3]).Width - 8;

                Excel.ChartObjects chartObjs = default(Excel.ChartObjects);
                chartObjs = (Excel.ChartObjects)Exelsheeta.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(8, vTop, vWidth, 250);
                Excel.Chart xlChart = chartObj.Chart;

                Excel.Range rgEqui = default(Excel.Range);

                if (LoaiBC)
                    rgEqui = Exelsheeta.get_Range(Exelsheeta.Cells[11, 2], Exelsheeta.Cells[vRowEx - 4, 3]);
                else                
                    rgEqui = Exelsheeta.get_Range("B9:B" + (vRowEx - 4) + ",F9:F" + (vRowEx - 4), Type.Missing);
                xlChart.SetSourceData(rgEqui, Type.Missing);
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = vChartName;
                xlChart.Legend.Delete();
            }
            catch { }


        }

        private void tabData_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            TaoLuoi();
        }
    }
}