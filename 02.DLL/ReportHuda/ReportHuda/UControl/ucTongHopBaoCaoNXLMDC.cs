using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class ucTongHopBaoCaoNXLMDC : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucTongHopBaoCaoNXLMDC";
        public ucTongHopBaoCaoNXLMDC()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong",
                    Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNXuong, _table, "MS_N_XUONG", "TEN_N_XUONG", lblNXuong.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            DataTable dtTmp = new DataTable();
            dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyen(0);
            System.Data.DataColumn cChon = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            cChon.DefaultValue = "0";
            dtTmp.Columns.Add(cChon);
            cChon.DefaultValue = false;
            cChon.SetOrdinal(0);
            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDChuyen, grvDChuyen, dtTmp, true, true, true, false, true, sBC);
            for (int i = 1; i < grvDChuyen.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvDChuyen.Columns["CHON"].Width = 150;
            grvDChuyen.Columns["TEN_HE_THONG"].Width = grdDChuyen.Width - 155;
            grvDChuyen.Columns["MS_HE_THONG"].Visible = false;

        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }

        }
        private void LoadLuoiBC()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = "SELECT CONVERT(INT,1) AS MA , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBCDieuDoBaoTri", Commons.Modules.TypeLanguage) + "' AS TEN ";
                sSql = sSql + " UNION SELECT 2 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBCTyLePhanTichHuHong", Commons.Modules.TypeLanguage) + "' AS TEN ";
                sSql = sSql + " UNION SELECT 3 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBCHieuQuaDuDoan", Commons.Modules.TypeLanguage) + "' AS TEN ";
                sSql = sSql + " ORDER BY MA";


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, false, true, true, false, true, sBC);
                grvBC.Columns["MA"].Visible = false;
            }
            catch { }
        }

        #endregion

        #region Event chuan
        private void btnAll_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvDChuyen);

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvDChuyen);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

        private void ucTongHopBaoCaoNXLMDC_Load(object sender, EventArgs e)
        {
            dtDNgay.DateTime = DateTime.Now;
            dtTNgay.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString());

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLuoiBC();
        }

        private void txtTKDChuyen_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdDChuyen.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKDChuyen.Text.Length != 0) dk = " TEN_HE_THONG LIKE '%" + txtTKDChuyen.Text + "%' " + dk;
                    dtTmp.DefaultView.RowFilter = dk;

                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
            }
            catch { }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdDChuyen.DataSource;
                dtTmp = dtTmp.Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                #region Day Chuyen
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, sBC, "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage));
                    return;
                }
                #endregion

                InDuLieu(dtTmp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                            ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void InDuLieu(DataTable dtDChuyen)
        {
            DataTable dtTmp = new DataTable();
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            string sHT;
            switch (int.Parse(grvBC.GetFocusedRowCellValue("MA").ToString()))
            {

                #region Bao Cao Dieu Do Bao Tri
                case 1:

                    sHT = "DDBT_DC" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sHT, dtDChuyen, "");

                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBCDieuDoBaoTri", Commons.Modules.UserName, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date,
                        cboNXuong.EditValue, cboLMay.EditValue, sHT, Commons.Modules.TypeLanguage));

                    if (dtTmp.Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                            "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                        return;
                    }
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sBC);
                    InDieuDoBaoTri(sPath);
                    break;
                #endregion

                #region Ty Le Phan Tich hu Hong
                case 2:
                    sHT = "TLPTHH_DC" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sHT, dtDChuyen, "");

                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBCTyLePhanTichHuHong", Commons.Modules.UserName, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date,
                        cboNXuong.EditValue, cboLMay.EditValue, sHT, Commons.Modules.TypeLanguage));

                    if (dtTmp.Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                            "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                        return;
                    }
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sBC);


                    InTyLePhanTichHuHong(sPath);
                    break;
                #endregion

                #region Hieu Qua Du Doan
                case 3:
                    sHT = "TLPTHH_DC" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sHT, dtDChuyen, "");

                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBCHieuQuaDuDoan", Commons.Modules.UserName, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date,
                        cboNXuong.EditValue, cboLMay.EditValue, sHT, Commons.Modules.TypeLanguage));

                    if (dtTmp.Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                            "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                        return;
                    }
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sBC);


                    InHieuQuaDuDoan(sPath);
                    break;
                    #endregion

            }
            //Commons.Modules.ObjSystems.XoaTable(sHT);
        }
        #region Bao Cao Dieu Do Bao Tri
        private void InDieuDoBaoTri(string sPath)
        {
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;
                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;
                //xlApp.Visible = true;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDeDDBT", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 3, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 5;
                stmp = lblNXuong.Text + " : " + cboNXuong.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                stmp = lblTNgay.Text + " : " + dtTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text.ToLower() + " : " + dtDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

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
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                //xlApp.Visible = true;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 126, "@", true, 6, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, 3);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "#,##0", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8.5, "#,##0.00", true, Dong, iCot, Dong + TDong + 1, iCot + 1);
                iCot = iCot + 2;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong, iCot, Dong + TDong + 1, iCot + 5);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TongCong", Commons.Modules.TypeLanguage), Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                for (int i = 7; i < TCot - 1; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(9, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong - 1, i) + ")";
                    title.Font.Bold = true;
                }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot - 1, Dong, TCot - 1);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong, 7) + "/" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, 9) + ") * 100";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong, 8) + "/" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, 9) + ") * 100";
                title.Font.Bold = true;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 4, 3, TCot);
                title.Font.Size = 16;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.RowHeight = 40;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 1, 6, 1);
                //title.EntireRow.Delete(Excel.XlInsertShiftDirection.xlShiftDown);


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
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Ty Le Phan Tich hu Hong
        private void InTyLePhanTichHuHong(string sPath)
        {
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;
                //xlApp.Visible = true;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDeTLPTHH", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 3, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 5;
                stmp = lblNXuong.Text + " : " + cboNXuong.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
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
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                //xlApp.Visible = true;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 126, "@", true, 6, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, 3);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "#,##0", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0", true, Dong, iCot, Dong + TDong + 1, iCot + 1);
                iCot = iCot + 2;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong, iCot, Dong + TDong + 1, iCot + 5);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TongCong", Commons.Modules.TypeLanguage), Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                for (int i = 7; i < TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(9, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong - 1, i) + ")";
                    title.Font.Bold = true;
                }



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong, TCot - 1) + "/" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, TCot - 2) + ") * 100";
                title.Font.Bold = true;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 4, 3, TCot);
                title.Font.Size = 16;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.RowHeight = 40;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 1, 6, 1);
                title.EntireRow.Delete(Excel.XlInsertShiftDirection.xlShiftDown);


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
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Hieu Qua Du Doan
        private void InHieuQuaDuDoan(string sPath)
        {
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;
                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;
                //xlApp.Visible = true;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDeHQDD", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 3, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 5;
                stmp = lblNXuong.Text + " : " + cboNXuong.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
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
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                //xlApp.Visible = true;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 126, "@", true, 6, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, 3);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 3, 6, TCot);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "#,##0", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.7, "#,##0.00", true, Dong, iCot, Dong + TDong + 1, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TongCong", Commons.Modules.TypeLanguage), Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                for (int i = 7; i < TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(9, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong - 1, i) + ")";
                    title.Font.Bold = true;
                }



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                title.Value2 = "=((" + Commons.Modules.MExcel.TimDiemExcel(Dong, TCot - 1) + "-" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, TCot - 2) + ") / " + Commons.Modules.MExcel.TimDiemExcel(Dong, TCot - 1) + ") *  100";
                title.Font.Bold = true;

                //((G -H)/ H) * 100)

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 4, 3, TCot);
                title.Font.Size = 16;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.RowHeight = 40;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 6, 1, 6, 1);
                title.EntireRow.Delete(Excel.XlInsertShiftDirection.xlShiftDown);


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
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        #endregion


    }
}
