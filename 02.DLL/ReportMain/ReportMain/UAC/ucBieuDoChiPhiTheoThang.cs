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
    public partial class ucBieuDoChiPhiTheoThang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoChiPhiTheoThang()
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

        private void LoadMay()
        {
//            --@MS_TINH  thay the user
//-- @MS_QUAN they the ngon ngu
            try
            {
                DataTable dtTmp = new DataTable();
                DateTime TThang, DThang;
                TThang = Convert.ToDateTime(datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
                DThang = Convert.ToDateTime(datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayBieuDoChiPhi", TThang, DThang, Commons.Modules.UserName, Commons.Modules.TypeLanguage.ToString(), "-1",
                            cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, true, false);
                dtTmp.Columns["MS_MAY"].ReadOnly = true;
                dtTmp.Columns["TEN_MAY"].ReadOnly = true;
                dtTmp.Columns["MODEL"].ReadOnly = true;                
            }
            catch
            { }
        }
        #endregion

        #region Change du lieu


        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            LoadMay();
        }
        private void datTThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void datDThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }




        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        #endregion


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            DataTable dtMay = new DataTable();
            dtMay = ((DataTable)grdMay.DataSource).Copy();

            dtMay.DefaultView.RowFilter = " CHON = 1";
            dtMay = dtMay.DefaultView.ToTable("CHON_MAY_BDCP", true, "MS_MAY");

            if (dtMay.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "ChuaChonMay", Commons.Modules.TypeLanguage));
                return;
            }

            if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(
                    Commons.IConnections.ConnectionString, "CHON_MAY_BDCP", dtMay, ""))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "ThucHienKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }

            string sChiPhi = "";
            if (optCPhi.SelectedIndex == 0)
                sChiPhi = "TONG_CP";
            else
            {
                if (optCPhi.SelectedIndex == 1)
                    sChiPhi = "CHI_PHI_CO_KH";
                else
                    sChiPhi = "CHI_PHI_KHO_KH";
            }
            try
            {
                DateTime TThang, DThang, TNgay, DNgay;
                TThang = Convert.ToDateTime(datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
                DThang = Convert.ToDateTime(datDThang.DateTime.Month + "/" + datDThang.DateTime.Year).AddMonths(1).AddDays(-1);
                string BTam, sThang, sSql, BangTam, sThangNull, sThangAvg;
                BTam = "";
                sThang = "";
                sSql = "";
                sThangAvg = "";
                BangTam = "BDCPTT" + Commons.Modules.UserName;
                sThangNull = "";
                for (DateTime Thang = TThang; Thang <= DThang;)
                {
                    TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                    DNgay = TNgay.AddMonths(1).AddDays(-1);
                    DataTable dtTmp = new DataTable();
                    BTam = "BDCPTT" + Commons.Modules.UserName + Thang.ToString("MMyy");
                    sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                    sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                    sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";

                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBieuDoChiPhi",
                        TNgay, DNgay, Commons.Modules.UserName, Commons.Modules.TypeLanguage.ToString(), "-1",
                        cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue,
                        chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(4) ? 1 : 0, 2, Thang.ToString("MM/yy")));

                    if (sSql == "")
                        sSql = " SELECT STT,MS_MAY,TEN_MAY, " + sChiPhi + " AS TONG_CP,THANG INTO " + BangTam + " FROM " + BTam;
                    else
                        sSql += " UNION SELECT STT,MS_MAY,TEN_MAY, " + sChiPhi + " AS TONG_CP,THANG " + BangTam + " FROM " + BTam;

                    if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, ""))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "ucBieuDoChiPhiTheoThang", "ThucHienKhongThanhCong", Commons.Modules.TypeLanguage));
                        return;
                    }
                    Thang = Thang.AddMonths(1);
                }

                Commons.Modules.ObjSystems.XoaTable(BangTam);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_CP FROM " +
                "   ( SELECT STT,MS_MAY , TEN_MAY, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                " 	  FROM  " +
                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                " 		PIVOT (SUM(TONG_CP) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                " 		 )) AS PVT)  " +
                "    A ORDER BY A.MS_MAY ";

                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                _table.Columns["STT"].ReadOnly = false;
                for (int i = 0; i <= _table.Rows.Count - 1; i++)
                {
                    _table.Rows[i][0] = (i + 1).ToString();
                }


                for (DateTime Thang = TThang; Thang <= DThang;)
                {
                    BTam = "BDCPTT" + Commons.Modules.UserName + Thang.ToString("MMyy");
                    Commons.Modules.ObjSystems.XoaTable(BTam);
                    Thang = Thang.AddMonths(1);
                }

                Commons.Modules.ObjSystems.XoaTable(BangTam);
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, _table, false, true, false, false);
                Commons.Modules.ObjSystems.XoaTable("CHON_MAY_BDCP");

                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "MS_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "TEN_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TONG_CP"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "TONG_CP", Commons.Modules.TypeLanguage);

                InDuLieu();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoThang", "ThucHienKhongThanhCong" + "/n" + ex.Message, Commons.Modules.TypeLanguage));
            }
            Commons.Modules.ObjSystems.XoaTable("CHON_MAY_BDCP");
        }

        private Boolean KiemDLieu()
        {


            if (datTThang.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongCoTuThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;
            }
            if (datDThang.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongCoDenThang", Commons.Modules.TypeLanguage));
                datDThang.Focus();
                return false;
            }
            DateTime TThang, DThang;

            TThang = Convert.ToDateTime(datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
            DThang = Convert.ToDateTime(datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);
            if (TThang == DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "TuThangBangDenThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;
            }
            if (TThang > DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;
            }
            int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);
            if (SoThang > 11)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "LonHonHaiNam", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }

            if (!chkLChiPhi.GetItemChecked(0) && !chkLChiPhi.GetItemChecked(1) && !chkLChiPhi.GetItemChecked(2) &&
                !chkLChiPhi.GetItemChecked(3) && !chkLChiPhi.GetItemChecked(4))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "KhongChonLChiPhi", Commons.Modules.TypeLanguage));
                chkLChiPhi.Focus();
                return false;
            }
            return true;
        }

        private void ucBieuDoChiPhiTheoThang_Load(object sender, EventArgs e)
        {
            
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayBieuDoChiPhi",
                        "01/01/1900", "01/01/1900", Commons.Modules.UserName, Commons.Modules.TypeLanguage.ToString(), "1", "1", "1", 1, "1"));

            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, true, true, true);

            dtTmp.Columns["MS_MAY"].ReadOnly = true;
            dtTmp.Columns["TEN_MAY"].ReadOnly = true;
            dtTmp.Columns["MODEL"].ReadOnly = true;

            grvMay.Columns["CHON"].Width = 100;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTThang.DateTime = Ngay.AddMonths(-6);
            datDThang.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;
        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvMay);
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;

            Excel.Application excelApplication = new Excel.Application();


            try
            {
                this.Cursor = Cursors.WaitCursor;
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount + 1;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 12 + (grvChung.RowCount * 3);
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelApplication.Cells.RowHeight = 23;
                excelApplication.Cells.ColumnWidth = 9;
                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 10;


                Dong = Dong + TDong;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "TongCong", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                for (int cot = 4; cot <= TCot; cot++)
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", Dong, cot, Dong, cot, Dong - TDong + 1, cot, Dong - 1, cot, 10, true, 10, "#,##0");



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong);

                int SCot;

                //SCot = (TCot > 10 ? 8 : (TCot <= 6 ? TCot : TCot - 2));
                SCot = (TCot > 10 ? 10 : TCot);
                //SCot = TCot;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                stmp = lblTThang.Text + " : " + datTThang.DateTime.ToString("dd/MM/yyyy") + " " + lblDThang.Text + " : " + datDThang.DateTime.ToString("dd/MM/yyyy");
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
                stmp = lblNhomMay.Text + " : " + cboNhomMay.Text;
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

                excelApplication.Cells.RowHeight = 23;
                excelApplication.Cells.ColumnWidth = 9;


                excelApplication.Cells.RowHeight = 23;
                excelApplication.Cells.ColumnWidth = 9;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                for (int i = 4; i <= TCot; i++)
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, i, TDong + Dong, i);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong + 1, TCot + 1, TDong + Dong, TCot + 1);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, TCot + 2, Dong + 1, TCot + 2);
                double iLeft; double iTop;
                double iWidth; double iHeight;

                iLeft = Convert.ToDouble(title.Left);
                iTop = Convert.ToDouble(title.Top);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, TCot + 2, Dong + 10, TCot + 2);
                iHeight = Convert.ToDouble(title.Height);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, TCot + 2, Dong + 10, TCot + 2 + 7);
                iWidth = Convert.ToDouble(title.Width);
                
                Boolean dCuoi;
                dCuoi = false;


                for (int i = 15; i <= Dong + TDong; i++)
                {
                    if (i == Dong + TDong)
                    {
                        dCuoi = true;

                    }
                    LoadBieuDo(excelWorkSheet, i, TCot, "", i - 14, iLeft, iTop, iWidth, iHeight, dCuoi);

                }



                //=SUM(D3:D9)



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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }
        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan,
            double iLeft, double iTop, double iWidth, double iHeight, Boolean sCuoi)
        {
            try
            {
              

                double iSLan;
                double sLe;
                double sChan;
                double sKQ;

                iSLan = iSoLan;
                sKQ = 0;
                if (sCuoi)
                {
                    sChan = Math.Floor(iSLan / 10);
                    sLe = iSLan - sChan * 10;
                    if (sLe != 0)
                    {
                        sKQ = ((sChan + 1) * 10) + 1;

                    }


                    iSoLan = int.Parse(sKQ.ToString());


                }

                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 10);
                double iLan = (iSoLan - 1) % 10;
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
                _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "Thang", Commons.Modules.TypeLanguage);// "=Sheet1!$A$" + (vDong + 1);                 //"=A" + vDong;
                _with1.Values = ExcelSheets.get_Range("D" + iDong, Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + iDong); //"B33");
                _with1.XValues = ExcelSheets.get_Range("D14", Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + "14");


                Excel.Range title = Commons.Modules.MExcel.GetRange(ExcelSheets, iDong, 2, iDong, 2);
                Excel.Range title1 = Commons.Modules.MExcel.GetRange(ExcelSheets, iDong, 3, iDong, 3);

                if (sCuoi)
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoThang", "TongCong", Commons.Modules.TypeLanguage);
                else
                    xlChart.ChartTitle.Text = title.Value + " - " + title1.Value;
                        //"=CONCATENATE(Sheet1!$B$" + (iDong) + ", \"-\" , Sheet1!$C$" + (iDong) + ")";
                        //= CONCATENATE(B15, " - ", C15)


                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlChart.HasTitle = true;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Axis ax = xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary) as Excel.Axis;

                ax.TickLabels.Orientation = Excel.XlTickLabelOrientation.xlTickLabelOrientationUpward;


                xlChart.Refresh();





                //Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                //Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                //Excel.Chart chartPage = myChart.Chart;
                //chartRange = xlWorkSheet.get_Range("A1", "d5");
                //chartPage.SetSourceData(chartRange, misValue);
                //chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
                //chartPage.ApplyLayout(6, Type.Missing);

                //chartPage.Axes(Excel.XlAxisType.xlCategory).Select();
                //chartPage.Axes(Excel.XlAxisType.xlCategory).TickLabels.Orientation = 35;




            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


    }
}
