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
    public partial class ucDMThietBiChuKyKDHieuChuan : DevExpress.XtraEditors.XtraUserControl
    {
        private string sBc = "ucDMThietBiChuKyKDHieuChuan";

        public ucDMThietBiChuKyKDHieuChuan()
        {
            InitializeComponent();
        }

#region Load Du Lieu
        private void LoadBoPhanChiuPhi()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBPCPhiAll",1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPhi, dtTmp, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "");
        }

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong",
                    Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", "");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, dtTmp, "MS_HE_THONG", "TEN_HE_THONG", "");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHT", Commons.Modules.UserName, sNX, iHThong));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadLoaiMay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            dtTNgay.Enabled = !dtTNgay.Enabled;
            dtDNgay.Enabled = !dtDNgay.Enabled;
        }

#endregion

        private void ucDMThietBiChuKyKDHieuChuan_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadBoPhanChiuPhi();
            dtTNgay.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString());
            dtDNgay.DateTime =  DateTime.Parse("01/01/" + DateTime.Now.Year.ToString()).AddYears(1);
            LoadNX();
            LoadDChuyen();
            Commons.Modules.SQLString = "";
            LoadLoaiMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!chkALL.Checked)
            {
                if (dtTNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoTuNgay", Commons.Modules.TypeLanguage));
                    dtTNgay.Focus();
                    return;
                }
                if (dtDNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoDenNgay", Commons.Modules.TypeLanguage));
                    dtDNgay.Focus();
                    return;
                }
            }
            if (cboBPCPhi.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoBPCPhi", Commons.Modules.TypeLanguage));
                cboBPCPhi.Focus();
                return;
            }
            if (cboDDiem.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc, "msgKhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }

            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;

            prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 9;
            prbIN.Properties.Minimum = 0;

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            try
            {
                DateTime TNgay, DNgay;
                TNgay = dtTNgay.DateTime;
                DNgay = dtDNgay.DateTime;
                DataTable dtTmp = new DataTable();
                if (!chkALL.Checked)
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCThietBiVaChuKyKiemDinh",
                            TNgay, DNgay, cboBPCPhi.EditValue, cboDChuyen.EditValue, cboDDiem.EditValue,
                            cboLMay.EditValue, "-1", Commons.Modules.UserName,1));
                }
                else
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCThietBiVaChuKyKiemDinh",
                            TNgay, DNgay, cboBPCPhi.EditValue, cboDChuyen.EditValue, cboDDiem.EditValue,
                            cboLMay.EditValue, "-1", Commons.Modules.UserName,0));
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBc,
                        "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    prbIN.Position = prbIN.Properties.Maximum;
                    return;
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, sBc);
                InDuLieu(sPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBc, "msgInKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
        }
        private void InDuLieu(string sPath)
        {
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                int TCot = grvChung.Columns.Count -1 ;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                //xlApp.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 11, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);

                //Activesheet.HPageBreaks.Count + 1

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = 2;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBc, "TieuDe", Commons.Modules.TypeLanguage), Dong, 4, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);


                string stmp = "";
                Dong = 5;

                stmp = lblTNgay.Text + " : " + dtTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " " + dtDNgay.DateTime.Date.ToShortDateString() ;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                Dong++;
                stmp = lblBPCPhi.Text + " : " + cboBPCPhi.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                Dong++;
                stmp = lblNguoiKiemSoat.Text + " : " + txtNKSoat.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range title;
                Dong = Dong + 2;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot + 1, Dong + TDong , TCot + 1);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
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
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, 5, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "##", true, Dong, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 13, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, 14, TDong + Dong, 15);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 16, TDong + Dong, 16);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, 17, TDong + Dong, 17);



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
                    sBc, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }
        
    }
}
