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
    public partial class ucThongKePhanTichHuHong : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucThongKePhanTichHuHong";
        public ucThongKePhanTichHuHong()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1,"-1","-1","-1"),
                    "MS_N_XUONG", "TEN_N_XUONG", lblNXuong.Text);
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

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDChuyen, grvDChuyen, dtTmp, true, true, true, false, true, sUC);
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
                DataTable dtTmp = new DataTable();
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), 
                    "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
                
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

        private void txtTKDChuyen_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdDChuyen.DataSource;
            try
            {
                string dk = "";
                if (txtTKDChuyen.Text.Length != 0) dk = " OR  TEN_HE_THONG LIKE '%" + txtTKDChuyen.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        #endregion

        private void ucThongKePhanTichHuHong_Load(object sender, EventArgs e)
        {
            dtDNgay.DateTime = DateTime.Now;
            dtTNgay.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString());

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (dtTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonTuNgay", Commons.Modules.TypeLanguage));
                dtTNgay.Focus();
                return;
            }
            if (dtDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonDenNgay", Commons.Modules.TypeLanguage));
                dtDNgay.Focus();
                return;
            }

            if (cboNXuong.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonNhaXuong", Commons.Modules.TypeLanguage));
                cboNXuong.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "msgChuaChonLoaiMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }

            prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 9;
            prbIN.Properties.Minimum = 0;

            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdDChuyen.DataSource;
            dtTmp = dtTmp.Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            #region Day Chuyen
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, sUC, "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage));
                return;
            }
            

            #endregion

            string sBT = "TK_PTHH_DC_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            string sDChuyen = "";
            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            foreach (DataRow drRow in dtTmp.Rows)
            {
                if (Boolean.Parse(drRow["CHON"].ToString()) == true)
                {
                    sDChuyen += (sDChuyen == "" ? "" : ",") + drRow["TEN_HE_THONG"].ToString();
                }

            }

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCThongKePhanTichHuHong", dtTNgay.DateTime, dtDNgay.DateTime,
                cboNXuong.EditValue, sBT,cboLMay.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                    "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name);
                prbIN.Position = prbIN.Properties.Maximum;
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            InDuLieu(sDChuyen);
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;

        }

        private void InDuLieu(string sDChuyen)
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

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TDeThongKePhanTichHuHong", Commons.Modules.TypeLanguage), 2, 5, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                //xlApp.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";

                stmp = lblTNgay.Text + " " + dtTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " " + dtDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 5, "@", 13, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 3, 5);

                Dong = 5;
                stmp = lblNXuong.Text + " : " + cboNXuong.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,sUC, "lblDayChuyen", Commons.Modules.TypeLanguage) + " : " + sDChuyen;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                Dong++;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Size = 10;
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
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 65);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 2, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 2, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 2, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 2, 13, TDong + Dong, 23);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 5;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 150, "@", true, 1, 3, TDong + Dong, 3);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 3, 7, 3);
                title.WrapText = true;
                double tmp = Convert.ToDouble(title.RowHeight);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 3, 7, TCot-1);
                title.MergeCells = true;
                title.WrapText = true;
                title.RowHeight = tmp;

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, 3, TDong + Dong, 3);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;                
                
                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }


    }
}
