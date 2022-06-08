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
    public partial class ucBaocaoTaiSanDenNgay : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaocaoTaiSanDenNgay()
        {
            InitializeComponent();
        }

        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
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

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDChuyen, grvDChuyen, dtTmp, true, true, true, false, true, "ucBaocaoTaiSanDenNgay");
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

        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNMay.Text);
            }
            catch { }
        }

        private void LoadBPChiuPhi()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBoPhanChiuPhi", 0));
                System.Data.DataColumn cChon = new System.Data.DataColumn("CHON", typeof(System.Boolean));

                cChon.DefaultValue = "0";
                dtTmp.Columns.Add(cChon);
                cChon.DefaultValue = false;
                cChon.SetOrdinal(0);
                dtTmp.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCPhi, grvBPCPhi, dtTmp, true, true, true, false, true, "ucBaocaoTaiSanDenNgay");
                for (int i = 1; i < grvBPCPhi.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                grvBPCPhi.Columns["CHON"].Width = 150;
                grvBPCPhi.Columns["TEN_BP_CHIU_PHI"].Width = grdBPCPhi.Width - 155;
                grvBPCPhi.Columns["MS_BP_CHIU_PHI"].Visible = false;
            }
            catch { }
        }

        #endregion

        #region Change du lieu

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        #endregion


        private void ucBaocaoTaiSanDenNgay_Load(object sender, EventArgs e)
        {
            dtTNgay.DateTime = DateTime.Now;
            LoadNX();
            LoadLoaiMay();
            LoadDChuyen();
            LoadBPChiuPhi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
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

        private void txtTKBPCP_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBPCPhi.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKBPCP.Text.Length != 0) dk = " TEN_BP_CHIU_PHI LIKE '%" + txtTKBPCP.Text + "%' " + dk;
                    dtTmp.DefaultView.RowFilter = dk;

                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
            }
            catch { }
        }

        private void btnAllDC_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvDChuyen);
        }

        private void btnNoDC_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvDChuyen);
        }

        private void btnAllBPCP_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBPCPhi );
        }

        private void btnNoBPCP_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBPCPhi);
        }

        private void btnExecute_Click(object sender, EventArgs e)
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
                    Commons.Modules.ModuleName, "ucBaocaoTaiSanDenNgay", "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage));
                return;
            }
            string sHT = "TSDN_HT" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sHT, dtTmp, "");
            #endregion

            #region BPCP
            dtTmp = new DataTable();
            dtTmp = (DataTable)grdBPCPhi.DataSource;
            dtTmp = dtTmp.Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBaocaoTaiSanDenNgay", "msgChuaChonBPCPhi", Commons.Modules.TypeLanguage));
                return;
            }
            string sBPCP = "TSDN_BPCP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBPCP, dtTmp, "");
            #endregion

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBaoCaoTaiSanDenNgay", dtTNgay.DateTime.Date,Commons.Modules.UserName,
                cboDDiem.EditValue,sHT,sBPCP,cboLMay.EditValue,cboNMay.EditValue,Commons.Modules.TypeLanguage));


            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, "ucKeHoachBaoTriNam");
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
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 12;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

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

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaocaoTaiSanDenNgay", "TieuDeTSDN", Commons.Modules.TypeLanguage) + " : " + dtTNgay.DateTime.Date.ToShortDateString(), 2, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 3, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = 5;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);


                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);

                Dong++;
                stmp = lblNMay.Text + " : " + cboNMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);

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
                    true, Excel.XlPaperSize.xlPaperA3, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4.5, "#,##0", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.86, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20.86, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11.14, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.43, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11.43, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.57, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.43, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong, iCot, TDong + Dong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.43, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong, iCot, TDong + Dong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 7.29, "#,##0", true, Dong, iCot, TDong + Dong + 1, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.43, "#,##0", true, Dong, iCot, TDong + Dong + 1, iCot+3);

                Dong = TDong + Dong + 1;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                     "ucBaocaoTaiSanDenNgay", "bcTongCong", Commons.Modules.TypeLanguage), Dong, 1, "@", 10, true,
                     Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 14);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 15, Dong, 15);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 15) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(10, 15) + ")";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 16, Dong, 16);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 16) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(10, 16) + ")";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 17, Dong, 17);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 17) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(10, 17) + ")";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 18, Dong, 18);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 18) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(10, 18) + ")";
                title.Font.Bold = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong , TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, 1);
                title.RowHeight = 9;

 

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;



                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaocaoTaiSanDenNgay", "bcNguoiDuyet", Commons.Modules.TypeLanguage), Dong, 3, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaocaoTaiSanDenNgay", "bcNguoiLap", Commons.Modules.TypeLanguage), Dong, 12, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 17);



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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaocaoTaiSanDenNgay", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        
    }
}
