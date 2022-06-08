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
    public partial class ucBieuDoChiPhiTheoTB : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoChiPhiTheoTB()
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

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
       #endregion


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucBieuDoChiPhiTheoTB_Load(object sender, EventArgs e)
        {
            chkLChiPhi.SelectedIndex =0;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);

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


            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (TNgay >= DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;

            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }

            //== false || chkLChiPhi.GetItemChecked(1) == false || chkLChiPhi.GetItemChecked(2 == false) == false ||
            //        chkLChiPhi.GetItemChecked(3) == false || chkLChiPhi.GetItemChecked(4) == false

            if (!chkLChiPhi.GetItemChecked(0) && !chkLChiPhi.GetItemChecked(1) && !chkLChiPhi.GetItemChecked(2) &&
                !chkLChiPhi.GetItemChecked(3) && !chkLChiPhi.GetItemChecked(4))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KhongChonLChiPhi", Commons.Modules.TypeLanguage));
                chkLChiPhi.Focus();
                return false;
            }
            return true;
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;

            DataTable dtTmp = new DataTable();

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT MS_MAY FROM MAY"));

            if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(
                    Commons.IConnections.ConnectionString, "CHON_MAY_BDCP", dtTmp, ""))
                return;

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBieuDoChiPhi",
                datTNgay.DateTime, datDNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage, "-1",
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue,
                chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                chkLChiPhi.GetItemChecked(4) ? 1 : 0, 1, ""));

            dtTmp.Columns["STT"].ReadOnly = false;
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoTB", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            for (int i = 1; i < dtTmp.Rows.Count+ 1; i++)
            {
                dtTmp.Rows[i-1][0] = i.ToString();
            }            
            
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, false, false, true, "");

            InDuLieu();
            Commons.Modules.ObjSystems.XoaTable("CHON_MAY_BDCP");
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
                prbIN.Properties.Maximum = 15;// grvChung.RowCount + 11 + TCot - 4;
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
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong);

                int SCot;

                // SCot = (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                SCot = TCot;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter , Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

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
                stmp =  lblNhomMay.Text +  " : " + cboNhomMay.Text ;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                Dong++;
                stmp = lblLoaiChiPhi.Text + " : ";
                if (chkLChiPhi.GetItemChecked(0)) stmp = stmp + chkLChiPhi.Items[0].Description.ToString();
                if (chkLChiPhi.GetItemChecked(1)) stmp = stmp + ", " + chkLChiPhi.Items[1].Description.ToString();
                if (chkLChiPhi.GetItemChecked(2)) stmp = stmp + ", " + chkLChiPhi.Items[2].Description.ToString();
                if (chkLChiPhi.GetItemChecked(3)) stmp = stmp + ", " + chkLChiPhi.Items[3].Description.ToString();
                if (chkLChiPhi.GetItemChecked(4)) stmp = stmp + ", " + chkLChiPhi.Items[4].Description.ToString(); 


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

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, 8, TDong + Dong, 8);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong+1, 10, Dong +1, 10);
                
                LoadBieuDo(excelWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble( title.Left), Convert.ToDouble(title.Top), 450, 350);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                //prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }


        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int vDong, int iColum, string sTitle, int iSoLan, double iLeft,
    double iTop, double iWidth, double iHeight)
        {
            try
            {
                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 3);
                double iLan = (iSoLan - 1) % 3;
                iLeft = iLeft + iLan * iWidth;
                iTop = iTop + iHeight * iTmp;
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);

                
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
                var _with1 = xlSeries;
                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KH", Commons.Modules.TypeLanguage);
                _with1.Values = ExcelSheets.get_Range("F15", (vDong > 34 ? "F34" : "F" + vDong.ToString() ));
                _with1.XValues= ExcelSheets.get_Range("B15", (vDong > 34 ? "B34" : "B" + vDong.ToString() )); //"B33");

                Excel.Series xlSeries1 = xlSeriesCollection.NewSeries();
                var _with2 = xlSeries1;
                _with2.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                _with2.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "KKH", Commons.Modules.TypeLanguage);
                _with2.Values = ExcelSheets.get_Range("G15", (vDong > 34 ? "G34" : "G" + vDong.ToString())); //"G33");
                _with2.XValues = ExcelSheets.get_Range("B15", (vDong > 34 ? "B34" : "B" + vDong.ToString())); //"B33");
                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlChart.HasTitle = true;
                //xlChart.ChartTitle.Text = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");     //sTitle;
                xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoTB", "TieuDe", Commons.Modules.TypeLanguage);// "=Sheet1!$A$" + (vDong + 1);                 //"=A" + vDong;

                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.Refresh();
            }
            catch
            { }
        }

        private string LayCot(int iCot)
        {
            string sTmp = "";
            if (iCot > 26)
            {
                sTmp = Convert.ToChar(Convert.ToInt32((iCot - 1) / 26) + 64).ToString();
                sTmp = sTmp + Convert.ToChar(((Convert.ToInt32(iCot) - 1) % 26) + 65).ToString();
            }
            else
            {
                sTmp = Convert.ToChar(64 + iCot).ToString();
            }

            return sTmp;

        }



    }
}
