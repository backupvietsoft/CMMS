using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucVatTuDeXuatChuaNhapKho : DevExpress.XtraEditors.XtraUserControl
    {
        public ucVatTuDeXuatChuaNhapKho()
        {
            InitializeComponent();            
        }

        private void LoadPhongBan()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text ,
                        "  SELECT DISTINCT PHONG_BAN AS MS , PHONG_BAN AS TEN FROM DE_XUAT_MUA_HANG WHERE PHONG_BAN IS NOT NULL " + 
                        " UNION SELECT '-1' , ' < ALL > ' ORDER BY PHONG_BAN"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, dtTmp, "MS", "TEN", lblPBan.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaoLuoi()
        {

            DataTable dtTmp = new DataTable();

            string sSql;
            sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucVatTuDeXuatChuaNhapKho", "KhongTheoKho", Commons.Modules.TypeLanguage);

            sSql = " SELECT CONVERT(BIT,0) AS CHON, MS_KHO , TEN_KHO , CONVERT(NVARCHAR(100),MS_KHO) AS MS_KHO_TIM , TEN_KHO AS TEN_KHO_TIM " +
                        " FROM IC_KHO UNION SELECT CONVERT(BIT,0), -1 , '" + sSql + "', '' , 'ZZZZZZ' ORDER BY TEN_KHO_TIM ";

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, true);
            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvBC.Columns["MS_KHO_TIM"].Visible = false;
            grvBC.Columns["TEN_KHO_TIM"].Visible = false;
            grvBC.Columns["MS_KHO"].Width = 200;
            grvBC.Columns["MS_KHO"].Visible = false;
            grvBC.Columns["CHON"].Width = 100;

        }

        private void ucVatTuDeXuatChuaNhapKho_Load(object sender, EventArgs e)
        {
            datTNgay.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            LoadPhongBan();
            TaoLuoi();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtKho = new DataTable();
            dtKho = (DataTable)grdBC.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_KHO_TIM LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtKho.DefaultView.RowFilter = dk;
            }
            catch { dtKho.DefaultView.RowFilter = ""; }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //DataTable dtTmp = new DataTable();
            //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, 
            //    "SELECT * FROM THONG_TIN_CHUNG WHERE ISNULL(DDH_DXMH,0) = 0"));
            ////if (dtTmp.Rows.Count > 0) 
            LoadDLKhongDonHang();
 

        }
        private void LoadDLKhongDonHang()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grdBC.DataSource).Copy();

                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucVatTuDeXuatChuaNhapKho", "ChuaChonDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sBT = "KHO_VTDX";
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");


                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCVatTuDeXuatChuaNhapKho",
                    datTNgay.DateTime, datDNgay.DateTime, cboPBan.EditValue, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.XoaTable("KHO_VTDX");

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucVatTuDeXuatChuaNhapKho", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "ucVatTuDeXuatChuaNhapKho");
                InDuLieuKhongDonHang();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoChiPhiChiTiet", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            
            }
            
        }

        private void InDuLieuKhongDonHang()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
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
                grvChung.ExportToXlsx(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
               

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVatTuDeXuatChuaNhapKho", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                Dong++;
                stmp = lblPBan.Text + " : " + cboPBan.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Excel.Range title;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
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

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                               
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 35, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 1, 4, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 45, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 7, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "dd/MM/yyyy", true, Dong + 1, 9, TDong + Dong,10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 11, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong + 1, 14, TDong + Dong, 15);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (Commons.Modules.sPrivate == "GREENFEED")
                {
                    //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 8, 1, 8);
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 8, 1, 8);
                    title.EntireColumn.Delete(System.Reflection.Missing.Value);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(title);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 4, 1, 4);
                    title.EntireColumn.Delete(System.Reflection.Missing.Value);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(title);
                }

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
                    "ucBaoCaoChiPhiChiTiet", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }

    }
}
