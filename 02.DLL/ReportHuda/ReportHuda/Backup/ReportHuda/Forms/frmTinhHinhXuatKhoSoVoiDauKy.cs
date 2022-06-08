using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ReportHuda
{
    public partial class frmTinhHinhXuatKhoSoVoiDauKy : DevExpress.XtraEditors.XtraForm
    {
        public frmTinhHinhXuatKhoSoVoiDauKy()
        {
            InitializeComponent();
        }
        #region Load Cmb
        private void LoadCmb()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoPQ", Commons.Modules.UserName, 0));
            Commons.Modules.ObjSystems.MLoadCheckedComboBoxEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO");

            Commons.Modules.ObjSystems.MLoadCheckedComboBoxEdit(cboDXuat, "SELECT MS_DANG_XUAT, CASE " + Commons.Modules.TypeLanguage.ToString() +
                " WHEN 0 THEN DANG_XUAT_VIET WHEN 1 THEN DANG_XUAT_ANH ELSE DANG_XUAT_HOA END AS TEN_DANG_XUAT FROM DANG_XUAT ORDER BY TEN_DANG_XUAT", 
                "MS_DANG_XUAT", "TEN_DANG_XUAT");
        }
        #endregion

        private void frmTinhHinhXuatKhoSoVoiDauKy_Load(object sender, EventArgs e)
        {
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay.AddMonths(-3);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadCmb();
            Commons.Modules.SQLString = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();


            if (cboKho.EditValue.ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }
            if (cboDXuat.EditValue.ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTinhHinhXuatKhoSoVoiDauKy", 
                cboKho.EditValue.ToString(), cboDXuat.EditValue.ToString(),datTNgay.DateTime.Date, datDNgay.DateTime.Date));
            if(dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }
            if (grvChung.Columns.Count == 0)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, true, true, true, this.Name);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, true, true);

            InDuLieu();
        }

        private void InDuLieu()
        {
            string sPath = "";


            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                //xlApp.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeBC", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = lblKho.Text + " : " ;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true);

                stmp = cboKho.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true);
                
                Dong++;
                stmp = lblDangXuat.Text + " : " ;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true);

                stmp = cboDXuat.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true);

                Excel.Range title;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;

                Dong++;



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TongCong", Commons.Modules.TypeLanguage), TDong + Dong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, TDong + Dong + 1, 5);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, TDong + Dong + 1, 6, TDong + Dong + 1, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;


                for (int i = 6; i < TCot - 1; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, i, Dong + TDong + 1, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 1, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong , i) + ")";
                    title.Font.Bold = true;
                }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, 10, Dong + TDong + 1, 10);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, 8) + "/" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, 6) + ") * 100" ;
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, 11, Dong + TDong + 1, 11);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, 9) + "/" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, 7) + ") * 100";

                title.Font.Bold = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                //xlApp.Visible = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 120, "@", true, Dong + 1, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 3, 8, 3);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 3, 8, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 120, "@", true, Dong + 1, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 3, 9, 3);
                title.WrapText = true;
                tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 3, 9, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong + 1, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 2, TDong + Dong + 1, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong + 1, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong + 1, 4, TDong + Dong + 1, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 5, TDong + Dong + 1, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, "#,##0.00", true, Dong + 1, 6, TDong + Dong + 1, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0.00", true, Dong + 1, 7, TDong + Dong + 1, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, "#,##0.00", true, Dong + 1, 8, TDong + Dong + 1, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0.00", true, Dong + 1, 9, TDong + Dong + 1, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "#,##0.00", true, Dong + 1, 10, TDong + Dong + 1, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "#,##0.00", true, Dong + 1, 11, TDong + Dong + 1, 11);



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }

    }
}