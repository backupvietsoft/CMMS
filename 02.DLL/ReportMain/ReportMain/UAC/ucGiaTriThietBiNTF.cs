using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain.UAC
{
    public partial class ucGiaTriThietBiNTF : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGiaTriThietBiNTF()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadTinh()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinh, "SELECT MA_QG,TEN_QG FROM Y_Tinh ORDER BY TEN_QG", "MA_QG", "TEN_QG", lblTinh.Text);
        }

        private void LoadQuan(string MsTinh)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboQuan, "SELECT  MA_QG,TEN_QG FROM Y_District WHERE  ( '" + MsTinh + "' = '-1' ) " +
                " OR ( MS_CHA = '" + MsTinh + "'  ) UNION SELECT '-1',' < ALL > '  ORDER BY TEN_QG", "MA_QG", "TEN_QG", lblQuan.Text);
        }

        private void LoadDuong(string MsTinh, string MsQuan)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDuong, "SELECT MS_DUONG, DUONG_TV FROM Y_Duong WHERE  " +
                " (( '" + MsTinh + "' = '-1' ) OR ( MS_Tinh = '" + MsTinh + "'  )) " +
                " AND (( '" + MsQuan + "' = '-1' ) OR ( MS_Quan = '" + MsQuan + "'  )) " +
                " UNION SELECT '-1',' < ALL > '  ORDER BY DUONG_TV", "MS_DUONG", "DUONG_TV", lblDuong.Text);
        }

        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }

        #endregion
        #region Change du lieu
        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) // at least one time
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

        private void cboTinh_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTinh.EditValue != null) LoadQuan(cboTinh.EditValue.ToString());
                if (cboTinh.EditValue != null && cboQuan.EditValue != null) LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
                LoadNX();
            }
            catch { } 
        }

        private void cboQuan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
                LoadNX();
            }
            catch { }
        }

        private void cboDuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }
        #endregion

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucGiaTriThietBiNTF_Load(object sender, EventArgs e)
        {
            chkLChiPhi.SelectedIndex = 0;
            LoadTinh();
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grpMay.Visible = true;
            else grpMay.Visible = false;
        }
        private Boolean KiemDLieu()
        {
            
            if (cboTinh.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoTinh", Commons.Modules.TypeLanguage));
                cboTinh.Focus();
                return false;
            }

            if (cboQuan.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoQuan", Commons.Modules.TypeLanguage));
                cboQuan.Focus();
                return false;
            }
            if (cboDuong.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoDuong", Commons.Modules.TypeLanguage));
                cboDuong.Focus();
                return false;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }

            if (!chkLChiPhi.GetItemChecked(0) && !chkLChiPhi.GetItemChecked(1) && !chkLChiPhi.GetItemChecked(2) &&
                !chkLChiPhi.GetItemChecked(3) && !chkLChiPhi.GetItemChecked(4) && !chkLChiPhi.GetItemChecked(5))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongChonLChiPhi", Commons.Modules.TypeLanguage));
                chkLChiPhi.Focus();
                return false;
            }
            return true;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MChiPhiTheoThietBi",
                Commons.Modules.UserName, cboTinh.EditValue, cboQuan.EditValue, cboDuong.EditValue,
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue,
                chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                chkLChiPhi.GetItemChecked(4) ? 1 : 0, chkLChiPhi.GetItemChecked(5) ? 1 : 0));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, false, false,true,"ucGiaTriThietBiNTF");
            for (int j = 8; j < dtTmp.Columns.Count; j++)
            {
                CreateSum(grvChung, dtTmp.Columns[j].Caption);
            }
            InDuLieu();
        }
        public void CreateSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";

            gridView1.Columns[column].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[column].DisplayFormat.FormatString = "{0:N2}";

        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                string stmp = "";
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
               
                Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = xlWorkBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;

                // SCot = (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                SCot = TCot;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblNhomMay.Text + " : " + cboNhomMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLoaiChiPhi.Text + " : ";
                if (chkLChiPhi.GetItemChecked(0)) stmp = stmp + chkLChiPhi.Items[0].Description.ToString();
                if (chkLChiPhi.GetItemChecked(1)) stmp = stmp + ", " + chkLChiPhi.Items[1].Description.ToString();
                if (chkLChiPhi.GetItemChecked(2)) stmp = stmp + ", " + chkLChiPhi.Items[2].Description.ToString();
                if (chkLChiPhi.GetItemChecked(3)) stmp = stmp + ", " + chkLChiPhi.Items[3].Description.ToString();
                if (chkLChiPhi.GetItemChecked(4)) stmp = stmp + ", " + chkLChiPhi.Items[4].Description.ToString();
                if (chkLChiPhi.GetItemChecked(5)) stmp = stmp + ", " + chkLChiPhi.Items[5].Description.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong++;
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong+2, TCot);
                title.Borders.LineStyle = 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong +1, 1, Dong + TDong + 2, TCot);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.DisplayAlerts = false;
               
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, 1, Dong + TDong + 1, TCot);
                //title.RowHeight = 1;
                title.Delete(Excel.XlDirection.xlUp);
                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 21, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0.00", true, Dong + 1, 9, TDong + Dong+2, 13);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong +1;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "Tong", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp,Dong,1, "@", 10, true, Excel.XlHAlign.xlHAlignRight,Excel.XlVAlign.xlVAlignCenter, 
                    true,Dong,8,false,false);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                this.Cursor = Cursors.Default;
                xlApp.Visible = true;
                xlWorkBook.Save();

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);


            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGiaTriThietBiNTF", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                xlApp.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            prbIN.Position = prbIN.Properties.Maximum;


        }

    }
}
