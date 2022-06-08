using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucBaoCaoPhieuCongViec : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoPhieuCongViec()
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

        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1,Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, _table, "MS_DON_VI", "TEN_DON_VI", "");
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhongBan, _table, "MS_PB", "TEN_PB", "");
            }
            catch { }
        }

        private void LoadNhanVien(string MsDv, int MsPB, int MsTo)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTimNhanVienUser", MsTo, MsPB, MsDv, "-1",Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhanVien, dtTmp, "MS_CONG_NHAN", "HO_TEN","");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ucBaoCaoPhieuCongViec_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadDonVi();
            Commons.Modules.SQLString = "";
            chkChonNVien.Items[0].Description = " ";
            chkChonNVien.Text = "";
            
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhongBan();
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            frmTimNhanVien frm = new frmTimNhanVien();
            frm.MsDVi = cboDonVi.EditValue.ToString();
            frm.MsPBan = int.Parse ( cboPhongBan.EditValue.ToString());
            
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            string sMSNV;
            sMSNV = frm.MsNVien;
            if (sMSNV == "") return;
            cboNhanVien.EditValue = sMSNV;
        }

        private void cboPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDonVi.Text == "[EditValue is null]" || cboDonVi.Text == "") return;
            if (cboPhongBan.Text == "[EditValue is null]" || cboPhongBan.Text == "") return;
            LoadNhanVien(cboDonVi.EditValue.ToString(), int.Parse(cboPhongBan.EditValue.ToString()), -1);
        }

        private Boolean KiemDLieu()
        {
             
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (TNgay > DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;

            }

            int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(TNgay, DNgay);
            if (SoThang > 12)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "LonHonMotNam", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboDonVi.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoDonVi", Commons.Modules.TypeLanguage));
                cboDonVi.Focus();
                return false;
            }
            if (cboPhongBan.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoPhongBan", Commons.Modules.TypeLanguage));
                cboPhongBan.Focus();
                return false;
            }
            if (cboNhanVien.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "KhongCoNhanVien", Commons.Modules.TypeLanguage));
                cboNhanVien.Focus();
                return false;
            }
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            try
            {
                DataTable dtTmp = new DataTable();
                string sTmp,sCVPBT;
                this.Cursor = Cursors.WaitCursor;
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "CongViecHangNgay", Commons.Modules.TypeLanguage);
                sCVPBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoPhieuCongViec", "CongViecTheoPhieuBaoTri", Commons.Modules.TypeLanguage);

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCPhieuCongViec", datTNgay.DateTime.Date, datDNgay.DateTime.Date,
                    cboDDiem.EditValue, cboDChuyen.EditValue, cboNhanVien.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                    chkChonNVien.GetItemChecked(0) ? 1 : 0, sTmp, sCVPBT));
                dtTmp.Columns["STT"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "ucBaoCaoPhieuCongViec");
                InDuLieu();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
                this.Cursor = Cursors.Default;
        }


        private void InDuLieu()
        {
            string sPath = "";
            
            DataTable dtTmp = new DataTable();
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount ;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 20 + (TDong);
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                

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
                    "ucBaoCaoPhieuCongViec", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
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
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "MsNV", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.EditValue.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblNhanVien.Text + " : " + cboNhanVien.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "TrinhDo", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.GetColumnValue("TRINH_DO_VH").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "BacTho", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.GetColumnValue("BAC_THO").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "To", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.GetColumnValue("TEN_TO").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "PhongBan", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.GetColumnValue("TO_PB").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, 6);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "DonVi", Commons.Modules.TypeLanguage) + " : " + cboNhanVien.GetColumnValue("TEN_DON_VI").ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 7, "@", 10, true, true, Dong, TCot);

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
                        if (grvChung.GetDataRow(i)["MS_PHIEU_BAO_TRI"].ToString() ==grvChung.GetDataRow(i + 1)["MS_PHIEU_BAO_TRI"].ToString() && grvChung.GetDataRow(i)["STT"].ToString() == grvChung.GetDataRow(i + 1)["STT"].ToString() && string.IsNullOrEmpty( grvChung.GetDataRow(i)["MS_PHIEU_BAO_TRI"].ToString()) ==false )
                        {

                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 2, i + 14, 2);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 3, i + 14, 3);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 4, i + 14, 4);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 5, i + 14, 5);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 6, i + 14, 6);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 7, i + 14, 7);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 8, i + 14, 8);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 9, i + 14, 9);
                            title.MergeCells = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 13, 10, i + 14, 10);
                            title.MergeCells = true;
                        }

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                    }
                }
                catch { }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 1, TDong + Dong, 2);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 1, 3, TDong + Dong, 3);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 5);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 6, TDong + Dong, 7);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 9, TDong + Dong, 9); //ttsbt
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 10, TDong + Dong, 10); //tt
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 11, TDong + Dong, 12); //tt
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0", true, Dong + 1, 13, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0.00", true, Dong + 1, 14, TDong + Dong, 15);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 8, TDong + Dong, 8);
                title.NumberFormat = "@";
                title.ColumnWidth = 12;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Rows.RowHeight = 21;
                Dong = Dong + TDong + 1;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoPhieuCongViec", "TongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 12);

                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, 13, Dong, 13, Dong - TDong, 13, Dong - 1, 13, 10, true, 10, "#,##0", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, 14, Dong, 14, Dong - TDong, 14, Dong - 1, 14, 10, true, 10, "#,##0.00", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, 15, Dong, 15, Dong - TDong, 15, Dong - 1, 15, 10, true, 10, "#,##0.00", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - (TDong + 1), 1, Dong , TCot);
                title.Borders.LineStyle = 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkBook.Save();
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
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
                    "ucBaoCaoPhieuCongViec", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
    }
}
