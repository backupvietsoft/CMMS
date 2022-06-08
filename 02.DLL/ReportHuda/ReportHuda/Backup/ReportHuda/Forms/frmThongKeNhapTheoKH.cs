using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.Controls;

namespace ReportHuda
{
    public partial class frmThongKeNhapTheoKH : DevExpress.XtraEditors.XtraForm
    {

        public frmThongKeNhapTheoKH()
        {
            Commons.Modules.SQLString = "0Load";
            InitializeComponent();
        }
#region Load Kho
        private void LoadKho()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoPQ", Commons.Modules.UserName,0));
            cboKho.Properties.DataSource = dtTmp;
            cboKho.Properties.DisplayMember = "TEN_KHO";
            cboKho.Properties.ValueMember = "MS_KHO";
            if (dtTmp.Rows.Count > 10) cboKho.Properties.DropDownRows = 15; else cboKho.Properties.DropDownRows = 10;
            cboKho.Properties.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            string sTmp = "";
            foreach (DataRow drRow in dtTmp.Rows)
            {
                sTmp = sTmp + ", " + drRow["MS_KHO"].ToString();
            }
            cboKho.SetEditValue(sTmp.Substring(1, sTmp.Length - 1));
        }
#endregion

        private void frmThongKeNhapTheoKH_Load(object sender, EventArgs e)
        {
            
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadKho();
            Commons.Modules.SQLString = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);


            LoadKhachHang();

            LoadCTKhachHang();
        }

        private void cboKho_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgLoadDuLieuSai", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            

        }

        private void grvKHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadCTKhachHang();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgLoadDuLieuSai", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            

        }

        private void txtTKiem_EditValueChanging(object sender, ChangingEventArgs e)
        {
            
            DataTable dtKH = new DataTable();
            try
            {
                string dk = "";
                dtKH = (DataTable)grdKHang.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_KH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_RUT_GON LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_CONG_TY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  DIA_CHI LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtKH.DefaultView.RowFilter = dk;

            }
            catch 
            {
                try 
                { 
                    dtKH.DefaultView.RowFilter = ""; 
                }
                catch { }
            }
        }

        private void txtTKiemCT_EditValueChanging(object sender, ChangingEventArgs e)
        {
            
            DataTable dtPN = new DataTable();
            try
            {
                string dk = "";
                dtPN = (DataTable)grdCTPN.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_DH_NHAP_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  SO_CHUNG_TU LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtPN.DefaultView.RowFilter = dk;

            }
            catch 
            {
                try 
                { 
                    dtPN.DefaultView.RowFilter = ""; 
                } catch { } 
            }
        }

        private void LoadKhachHang()
        {
            if (Commons.Modules.SQLString == "0Load") return;


            DataTable dtTmp = new DataTable();
            if (cboKho.EditValue.ToString() == "")
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeNhapTheoKH", "01/01/1900",
                    "01/01/1900", "-11", "-11"));
            else
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeNhapTheoKH", datTNgay.DateTime.Date,
                    datDNgay.DateTime.Date, cboKho.EditValue.ToString(), Commons.Modules.UserName));

            if(grvKHang.Columns.Count ==0)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHang, grvKHang, dtTmp, false, false, true, true,true,this.Name);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHang, grvKHang, dtTmp, false, false, true, true);
            for (int j = 5; j < dtTmp.Columns.Count; j++)
            {
                CreateSum(grvKHang, dtTmp.Columns[j].Caption);
            }
            grvKHang.Columns["TT_TAX"].Width = grvKHang.Columns["TT_VND"].Width = 100;
            grvKHang.Columns["MS_KH"].Width = 80;
        }

        private void LoadCTKhachHang()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            if (grvKHang.RowCount == 0)
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "GetThongKeChiTietNhapTheoKH", "-11"));
            else
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "GetThongKeChiTietNhapTheoKH", grvKHang.GetFocusedRowCellValue("MS_KH").ToString()));
            if (grvCTPN.Columns.Count == 0)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTPN, grvCTPN, dtTmp, false, false, true, true,true,this.Name);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTPN, grvCTPN, dtTmp, false, false, true, true);

            for (int j = 5; j < dtTmp.Columns.Count; j++)
            {
                CreateSum(grvCTPN, dtTmp.Columns[j].Caption);
            }
            grvCTPN.Columns["TT_TAX"].Width = grvKHang.Columns["TT_VND"].Width = 100;
        }

        public void CreateSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";

            gridView1.Columns[column].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[column].DisplayFormat.FormatString = "{0:N2}";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecuteKH_Click(object sender, EventArgs e)
        {
            if (grvKHang.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, 
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;

            }
            InDuLieu(grvKHang, 1);
        }

        private void btnExecuteCT_Click(object sender, EventArgs e)
        {
            if (grvCTPN.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;

            }

            InDuLieu(grvCTPN, 2);
        }

        private void InDuLieu(DevExpress.XtraGrid.Views.Grid.GridView grv, int iLoai)
        {
            string sPath = "";
            

            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grv.Columns.Count;
                int TDong = grv.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grv.ExportToXls(sPath);

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
                if (iLoai == 1)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
                else
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                if (iLoai == 1)
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeBC1", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeBC2", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
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
                stmp = lblKho.Text + " : " + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true);

                Excel.Range title;

                if (iLoai == 2)
                {
                    Dong++;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "KhachHang", Commons.Modules.TypeLanguage) + " : " + grvKHang.GetFocusedRowCellValue("TEN_CONG_TY").ToString();
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }

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

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, 1, Dong + TDong + 1, 1);
                title.EntireRow.Delete(Excel.XlInsertShiftDirection.xlShiftDown);


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TongCong", Commons.Modules.TypeLanguage), TDong + Dong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, TDong + Dong + 1, 1);
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


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 1, 6, 1);
                //title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 126, "@", true,  1, 2, TDong + Dong, 2);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 2, 5, 2);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 2, 5, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong + 1, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 2, TDong + Dong + 1, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 4, TDong + Dong + 1, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "#,##0.00", true, Dong + 1, 6, TDong + Dong + 1, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong + 1, 7, TDong + Dong + 1, 7);
                if (iLoai == 1)
                {
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 3, TDong + Dong + 1, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 5, TDong + Dong + 1, 5);
                }
                else
                {
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 3, TDong + Dong + 1, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 5, TDong + Dong + 1, 5);
                }


                

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