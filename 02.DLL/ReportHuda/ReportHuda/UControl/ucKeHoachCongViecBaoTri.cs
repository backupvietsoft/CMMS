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
    public partial class ucKeHoachCongViecBaoTri : DevExpress.XtraEditors.XtraUserControl
    {
        string uBC = "ucKeHoachCongViecBaoTri";
        public ucKeHoachCongViecBaoTri()
        {
            InitializeComponent();
        }
        //MAY_KHCVBT_TMP
        #region Load Du Lieu


        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 0)
            {
                cboDonVi.Properties.ReadOnly = false;
                cboPhongBan.Properties.ReadOnly = false;

                cboDChuyen.ReadOnly = false;
                cboDDiem.ReadOnly = false;
                cboLMay.Properties.ReadOnly = false;
                cboLBTri.Properties.ReadOnly = false;
            }


            if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2)
            {
                cboDonVi.Properties.ReadOnly = true;
                cboPhongBan.Properties.ReadOnly = true;

                cboDChuyen.ReadOnly = false;
                cboDDiem.ReadOnly = false;
                cboLMay.Properties.ReadOnly = false;
                cboLBTri.Properties.ReadOnly = false;
            }
            if (optBCao.SelectedIndex == 3)
            {
                cboDChuyen.ReadOnly = true;
                cboDDiem.ReadOnly = true;
                cboLMay.Properties.ReadOnly = true;
                cboLBTri.Properties.ReadOnly = true;

                cboDonVi.Properties.ReadOnly = false;
                cboPhongBan.Properties.ReadOnly = false;
            }
        }
        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, _table, "MS_DON_VI", "TEN_DON_VI", lblDonVi.Text);
            }
            catch { }
        }

        private void LoadPhongBan()
        {
            if (cboDonVi.Text == "") return;

            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 1, cboDonVi.EditValue, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhongBan, _table, "MS_PB", "TEN_PB", lblPhongBan.Text);
            }
            catch { }
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhongBan();
        }

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
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");

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
        private string sBaoTriChung = "-1";
        private void LoadLoaiBT()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiBaoTri"));
                DataRow _row = _table.NewRow();
                _row["MS_LOAI_BT"] = -2;
                _row["TEN_LOAI_BT"] = sBaoTriChung;
                _table.Rows.Add(_row);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0DD") return;
            if (Commons.Modules.SQLString == "0DC") return;
            if (Commons.Modules.SQLString == "0LM") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2000"); }
                
                
                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.TextValue == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }
                try
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();

                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetMayNXuongHThongLMay", Commons.Modules.UserName, NXuong, HThong, -1, LMay, "-1", "-1",
                        DNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "1";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);

                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, true, this.Name);

                for (int i = 1; i <= grvMay.Columns.Count - 1; i++)
                {
                    grvMay.Columns[i].Visible = false;
                    dtMay.Columns[i].ReadOnly = true;
                }

                grvMay.Columns["MS_MAY"].Visible = true;
                grvMay.Columns["TEN_NHOM_MAY"].Visible = true;
                grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
                grvMay.Columns["TEN_HE_THONG"].Visible = true;
                grvMay.Columns["Ten_N_XUONG"].Visible = true;
                grvMay.Columns["TEN_MAY"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void ucKeHoachCongViecBaoTri_Load(object sender, EventArgs e)
        {
            sBaoTriChung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, uBC, "BaoTriChung", Commons.Modules.TypeLanguage);
            Commons.Modules.SQLString = "0Load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay;
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiBT();
            Commons.Modules.SQLString = "";
            LoadMay();
            LoadDonVi();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = ((DataTable)grdMay.DataSource).Copy();
                if (optBCao.SelectedIndex != 3)
                {
                    dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
                    if (dtTmp.DefaultView.ToTable().Rows.Count == 0 && int.Parse(cboLBTri.EditValue.ToString()) != -2)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, uBC, "msgChuaChonMay", Commons.Modules.TypeLanguage));
                        return;
                    }
                }                
                string sBTam;
                
                sBTam = "MAY_KHCVBT_TMP" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spKeHoachCongViecBaoTri", sBTam, cboLBTri.EditValue,
                    sBaoTriChung, datTNgay.DateTime.Date, datDNgay.DateTime.Date, Commons.Modules.TypeLanguage,
                    cboDonVi.EditValue, cboPhongBan.EditValue, optBCao.SelectedIndex,Commons.Modules.UserName));
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, uBC, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);

                DataTable dtn = dtTmp.Clone();
                dtn.ImportRow(dtTmp.Rows[0]);

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTmp, grvTmp, dtn, false, true, true, true, true, this.Name);


                InDuLieu();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }

        }

        private void InDuLieu()
        {
            string sPath = "";

            DataTable dtTmp = new DataTable();
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            Excel.Application xlApp = new Excel.ApplicationClass();
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
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


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    uBC, "bcTieuDeKeHoachCongViecBaoTri", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
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
                stmp = "'----o0o----";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                //'----o0o----
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);


                Dong++;
                Excel.Range title;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
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

                //xlApp.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "##", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 1, 6, TDong + Dong, 6);

                if (Commons.Modules.iPBTTheoGio == 0)
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong + 2, 7, TDong + Dong, 7);
                else
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0", true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 8, TDong + Dong, 8);

                dtTmp = new DataTable();
                dtTmp = ((DataTable)grdChung.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "";
                xlApp.DisplayAlerts = false;
                int i;
                try
                {

                    for (i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        if (grvChung.RowCount == i + 1) break;
                        if (DateTime.Parse(grvChung.GetDataRow(i)["NGAY"].ToString()) == DateTime.Parse(grvChung.GetDataRow(i + 1)["NGAY"].ToString()))
                        {
                            dtTmp.DefaultView.RowFilter = "NGAY = '" + DateTime.Parse(grvChung.GetDataRow(i)["NGAY"].ToString()) + "' ";
                            
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 14, 1, i + 13 + dtTmp.DefaultView.ToTable().Rows.Count, 1);
                            title.MergeCells = true;
                            i = i + dtTmp.DefaultView.ToTable().Rows.Count - 1;
                        }
                    }
                }
                catch { }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Dong + TDong + 1;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    uBC, "bcTongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);
                if (Commons.Modules.iPBTTheoGio == 0)
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, 7, Dong, 7, Dong - TDong,
                        7, Dong - 1, 7, 10, true, 12, "#,##0.00", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                else
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, 7, Dong, 7, Dong - TDong,
                        7, Dong - 1, 7, 10, true, 12, "#,##0", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    uBC, "bcSoCongThucHien", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, 7);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 7) + " / 480 ";
                    title.Font.Bold = true;
                    if (Commons.Modules.iPBTTheoGio == 0)
                        title.NumberFormat = "#,##0.00";
                    else
                        title.NumberFormat = "#,##0";
                }
                catch { }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - TDong - 2, 1, Dong , TCot);
                title.Borders.LineStyle = 1;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, uBC,
                                "bcNgayThangNam", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, uBC,
                                "bcLapKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                try
                {
                    Dong = Dong + 4;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.sTenNhanVienMD, Dong, 6, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                }
                catch { }

                
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
                    uBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }


        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
    }
}
