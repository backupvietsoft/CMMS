using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VietShape
{
    public partial class ucBaoCaoChiPhiChiTietBR : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoChiPhiChiTietBR()
        {
            InitializeComponent();
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

        private void LoadBPChiuPhi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_BP_CHIU_PHI , TEN_BP_CHIU_PHI  FROM BO_PHAN_CHIU_PHI UNION SELECT '-1',' < ALL > ' ORDER BY TEN_BP_CHIU_PHI "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPhi, _table, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", lblBPCPhi.Text);
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
        private void LoadMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sDChuyen = "-1";
                int iBPhan = -1;
                string sLmay = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sDChuyen = cboDDiem.EditValue.ToString();
                if (cboBPCPhi.EditValue.ToString() != "-1") iBPhan = int.Parse(cboBPCPhi.EditValue.ToString());
                if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayBCChiPhi", datTNgay.DateTime, datDNgay.DateTime,
                    iHThong, sDChuyen, iBPhan, sLmay, "-1", Commons.Modules.UserName, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboThietBi, dtTmp, "MS_MAY", "TEN_MAY", "ucBaoCaoChiPhiChiTietBR");
            }
            catch { }
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void ucBaoCaoChiPhiChiTiet_Load(object sender, EventArgs e)
        {
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            datDNgay.DateTime = DateTime.Now;
            LoadNX();
            LoadDChuyen();
            LoadBPChiuPhi();
            LoadLoaiMay();
        }

        private void btnTimMay_Click(object sender, EventArgs e)
        {
            frmTimMay frm = new frmTimMay();
            frm.iLoaiBC = 2;
            frm.MsLoaiMay = cboLMay.EditValue.ToString();
            frm.TuNgay = datTNgay.DateTime;
            frm.DenNgay = datDNgay.DateTime;
            frm.sDiaDiem = cboDDiem.EditValue.ToString();
            frm.iHeThong = int.Parse(cboDChuyen.EditValue.ToString());
            frm.iBoPhan = int.Parse(cboBPCPhi.EditValue.ToString());
            string sLoaiMay;
            sLoaiMay = cboLMay.EditValue.ToString();
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            string sMsMay;

            sMsMay = frm.MsMay;
            sLoaiMay = frm.LoaiMay;
            if (sMsMay == "") return;
            if (sLoaiMay != cboLMay.EditValue.ToString()) cboLMay.EditValue = sLoaiMay;
            cboThietBi.EditValue = sMsMay;
        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboBPCPhi_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();

        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();

        }

        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            int iHThong = -1;
            string sDChuyen = "-1";
            int iBPhan = -1;
            string sLmay = "-1";
            string sMsMay = "-1";
            if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
            if (cboDDiem.EditValue.ToString() != "-1") sDChuyen = cboDDiem.EditValue.ToString();
            if (cboBPCPhi.EditValue.ToString() != "-1") iBPhan = int.Parse(cboBPCPhi.EditValue.ToString());
            if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();
            if (cboThietBi.EditValue.ToString() != " < ALL > ") sMsMay = cboThietBi.EditValue.ToString();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBaoCaoChiPhiChiTietBR", datTNgay.DateTime, datDNgay.DateTime,
                 sDChuyen, iHThong, iBPhan, sLmay, Commons.Modules.UserName, sMsMay));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChiPhiChiTietBR",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }

            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }
            //grvChung.OptionsView.AllowCellMerge = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, false, true, true, true, "ucBaoCaoChiPhiChiTietBR");

            DataTable tmp = new DataTable();
            tmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBaoCaoChiPhiChiTietTheoNX", datTNgay.DateTime, datDNgay.DateTime,
                  sDChuyen, iHThong, iBPhan, sLmay, Commons.Modules.UserName, sMsMay));
            InDuLieuBR(tmp);
        }
        //in báo cáo bà rịa vũng tầu
        private void InDuLieuBR(DataTable dt)
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
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoChiPhiChiTietBR", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
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
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = lblBPCPhi.Text + " : " + cboBPCPhi.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoChiPhiChiTietBR", "TenMay", Commons.Modules.TypeLanguage) + " : " + cboThietBi.GetColumnValue("TEN_MAY").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);

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

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBatTriNamNutifood", "TongCong", Commons.Modules.TypeLanguage), Dong + TDong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 1, 2);

                for (int i = 3; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, i, Dong + TDong + 1, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 1, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, i) + ")";
                    title.NumberFormat = "#,##0";
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;


                //load chi phí theo nhà xưởng
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot + 2, Dong + dt.Rows.Count, TCot + dt.Columns.Count + 1);
                Commons.Modules.MExcel.MExportExcel(dt, xlWorkSheet, title, true, this.Name);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot + 2, Dong, TCot + dt.Columns.Count + 1);
                title.Value = null;


                string tennx = dt.Rows[0][0].ToString();
                string tencc = dt.Rows[dt.Rows.Count - 1][0].ToString();
                int dongmg = Dong + 1;

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i < dt.Rows.Count - 1)
                        {
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1 + i, TCot + 2, Dong + 1 + i, TCot + 2);
                            //kiểm tra nếu giống thì bỏ qua
                            if (title.Value.ToString() != tennx)
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + i, TCot + 5, Dong + i, TCot + 5);
                                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(dongmg, TCot + 4) + ":" +
                                    Commons.Modules.MExcel.TimDiemExcel(Dong + i, TCot + 4) + ")";
                                title.NumberFormat = "#,##0";
                                title.Font.Bold = true;
                                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, dongmg, TCot + 2, Dong + i, TCot + 2);
                                dongmg = Dong + i + 1;
                                title.Value = null;
                                title.Merge();
                                title.Value2 = tennx;
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1 + i, TCot + 2, Dong + 1 + i, TCot + 2);
                                tennx = title.Value.ToString();
                            }
                        }
                        else
                        {
                            if (title.Value.ToString() != tencc)
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + i, TCot + 5, Dong + i, TCot + 5);
                                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(dongmg, TCot + 4) + ":" +
                                    Commons.Modules.MExcel.TimDiemExcel(Dong + i, TCot + 4) + ")";
                                title.NumberFormat = "#,##0";
                                title.Font.Bold = true;
                                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, dongmg, TCot + 2, Dong + i, TCot + 2);
                                dongmg = Dong + i + 1;
                                title.Value = null;
                                title.Merge();
                                title.Value2 = tencc;
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1 + i, TCot + 2, Dong + 1 + i, TCot + 2);


                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1 + i, TCot + 5, Dong + 1 + i, TCot + 5);
                                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(dongmg, TCot + 4) + ":" +
                                    Commons.Modules.MExcel.TimDiemExcel(Dong + 1 + i, TCot + 4) + ")";
                                title.NumberFormat = "#,##0";
                                title.Font.Bold = true;
                                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, dongmg, TCot + 2, Dong + 1 + i, TCot + 2);
                                title.Value = null;
                                title.Value2 = tennx;
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            }
                            else
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + i + 1, TCot + 5, Dong + i + 1, TCot + 5);
                                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(dongmg, TCot + 4) + ":" +
                                    Commons.Modules.MExcel.TimDiemExcel(Dong + i + 1, TCot + 4) + ")";
                                title.NumberFormat = "#,##0";
                                title.Font.Bold = true;
                                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, dongmg, TCot + 2, Dong + i + 1, TCot + 2);
                                title.Value = null;
                                title.Merge();
                                title.Value2 = tennx;
                                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
    "ucKeHoachBatTriNamNutifood", "TongCong", Commons.Modules.TypeLanguage), Dong + dt.Rows.Count + 1, TCot + 2, "@", 10, true,
    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + dt.Rows.Count + 1, TCot + 3);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + dt.Rows.Count + 1, TCot + 4, Dong + dt.Rows.Count + 1, TCot + 4);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 1, TCot + 4) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong + dt.Rows.Count, TCot + 4) + ")";
                title.NumberFormat = "#,##0";
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, TCot + dt.Columns.Count + 1, "#,##0", true, Dong + 1, 3, dt.Rows.Count + Dong, TCot + dt.Columns.Count + 1);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 20;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                //title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 40, "@", true, Dong + 1, 3, TDong + Dong, 3);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 4);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, TDong + Dong, 6);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 7, TDong + Dong, 7);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 8, TDong + Dong, 9);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0", true, Dong + 1, 4, TDong + Dong, TCot);






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
                    "ucBaoCaoChiPhiChiTietBR", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


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
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoChiPhiChiTietBR", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
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
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = lblBPCPhi.Text + " : " + cboBPCPhi.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoChiPhiChiTietBR", "TenMay", Commons.Modules.TypeLanguage) + " : " + cboThietBi.GetColumnValue("TEN_MAY").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);

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

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBatTriNamNutifood", "TongCong", Commons.Modules.TypeLanguage), Dong + TDong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 1, 11);

                for (int i = 12; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, i, Dong + TDong + 1, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 1, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, i) + ")";
                    title.NumberFormat = "#,##0";
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 1, TCot);
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
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 8, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0", true, Dong + 1, 12, TDong + Dong, TCot);

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
                    "ucBaoCaoChiPhiChiTietBR", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


    }
}
