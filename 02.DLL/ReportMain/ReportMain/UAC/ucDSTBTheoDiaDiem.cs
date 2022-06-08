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
    public partial class ucDSTBTheoDiaDiem : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDSTBTheoDiaDiem()
        {
            InitializeComponent();
        }

#region Load Du Lieu
       

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
        
        private void LoadBPChiuPhi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBoPhanChiuPhi", 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPhi, _table, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", lblLBPCPhi.Text);
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

     
#endregion

        private void ucDSTBTheoDiaDiem_Load(object sender, EventArgs e)
        {
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadBPChiuPhi();
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grpMay.Visible = true;
            else grpMay.Visible = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private Boolean KiemDLieu()
        {
           

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDieuChinhThietBi", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDieuChinhThietBi", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDieuChinhThietBi", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }
            return true;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;

            int LoaiBC;
            LoaiBC = 1;
            if (optBCao.SelectedIndex == 0) LoaiBC = 1;
            if (optBCao.SelectedIndex == 1) LoaiBC = 2;
            if (optBCao.SelectedIndex == 2) LoaiBC = 3;

            
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDanhSachThietBiTheoDiaDiem",
                "-1", "-1", "-1",
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, Commons.Modules.UserName, cboBPCPhi.EditValue, LoaiBC));
            dtTmp.Columns["STT"].ReadOnly = false;



            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDieuChinhThietBi", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            int j;
            string MsMay, LoaiGroup;
            MsMay = "";
            LoaiGroup = "";
            j = 0;

            if (optBCao.SelectedIndex == 0) LoaiGroup = "Ten_N_XUONG";
            if (optBCao.SelectedIndex == 1) LoaiGroup = "TEN_HE_THONG";
            if (optBCao.SelectedIndex == 2) LoaiGroup = "TEN_BP_CHIU_PHI";

            for (int i = 0; i < dtTmp.Rows.Count; i++)
            {
                if (MsMay == dtTmp.Rows[i][LoaiGroup].ToString())
                    j++;
                else
                {
                    j = 1;
                    MsMay = "";
                }
                dtTmp.Rows[i][0] = j.ToString();
                if (MsMay == "")
                {
                    MsMay = dtTmp.Rows[i][LoaiGroup].ToString();
                }
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
            if (optBCao.SelectedIndex == 0) grvChung.Columns["Ten_N_XUONG"].Group();
            if (optBCao.SelectedIndex == 1) grvChung.Columns["TEN_HE_THONG"].Group();
            if (optBCao.SelectedIndex == 2) grvChung.Columns["TEN_BP_CHIU_PHI"].Group();
            
            grvChung.ExpandAllGroups();
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucDieuChinhThietBi");
            InDuLieu();
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                 
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                int SCot;

                SCot = TCot;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSTBTheoDiaDiem", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Dong++;
                string stmp = "";
                //stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                Dong++;
                stmp = lblLBPCPhi.Text + " : " + cboBPCPhi.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong++;
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "@", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "@", true, Dong + 1, 13, TDong + Dong, 13);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                excelApplication.Visible = true;
                
                this.Cursor = Cursors.Default;
                excelApplication.Visible = true;
                excelWorkbook.Save();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSTBTheoDiaDiem", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                //prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }


    }
}
