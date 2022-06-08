using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VietShape
{
    public partial class frmInDSDiChuyenKho : DevExpress.XtraEditors.XtraForm
    {
        public frmInDSDiChuyenKho()
        {
            InitializeComponent();
        }

        private void frmInDSDiChuyenKho_Load(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 1, Commons.Modules.UserName));

            cboKhoDi.DisplayMember = "TEN_KHO";
            cboKhoDi.ValueMember = "MS_KHO";
            cboKhoDi.DataSource = dtTmp;

            DataTable dtTmp1 = dtTmp.Copy();

            cboKhoDen.DataSource = dtTmp1;
            cboKhoDen.DisplayMember = "TEN_KHO";
            cboKhoDen.ValueMember = "MS_KHO";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (datDNgay.Value < datTNgay.Value)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDSDiChuyenKho", datTNgay.Text, datDNgay.Text, cboKhoDi.SelectedValue, cboKhoDen.SelectedValue));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);

                InDuLieu();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = true;
            Excel.Range title;

            int TCot = grvChung.Columns.Count;
            int TDong = grvChung.RowCount;
            int Dong = 1;

            //prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 9;
            prbIN.Properties.Minimum = 0;
            excelApplication.Visible = false;

            grdChung.ExportToXls(sPath);
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion
           // excelApplication.Visible = true;

            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
           // excelApplication.Visible = false;

            try
            {
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;
                excelApplication.Cells.Font.Size = 10;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion




                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, 3);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 6;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeDSDiChuyenKho", Commons.Modules.TypeLanguage)
                    , Dong, 2, "@", 14, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Từ ngày: " + datTNgay.Text + " - Đến ngày: " + datDNgay.Text, Dong + 1, 2, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, TCot - 1);


                Dong = 8;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Kho đi: " + cboKhoDi.Text, Dong, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Kho đến: " + cboKhoDen.Text, Dong + 1, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 4);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5.14, "", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.14, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.86, "@", true, Dong, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 22.14, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.57, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25.14, "@", true, Dong, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 7, Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25.14, "@", true, Dong, 8, Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 9, Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10.71, "@", true, Dong, 10, Dong, 10);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + 4, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 2, 1], excelWorkSheet.Cells[Dong + 2, 1]).Interior.Color;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Font.Bold = true;
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 5, 1, TDong + Dong + 4, TCot);
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 2, 1], excelWorkSheet.Cells[Dong + 2, 1]).Interior.Color;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelWorkbook.Save();
                excelApplication.Visible = true;

                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + ": " + ex.Message);
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            //}));


            prbIN.Position = prbIN.Properties.Maximum;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
