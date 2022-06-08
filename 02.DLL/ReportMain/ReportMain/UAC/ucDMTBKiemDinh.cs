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
    public partial class ucDMTBKiemDinh : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDMTBKiemDinh()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadPhongBan()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanAll", 1, "-1"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, dtTmp, "MS_PB", "TEN_PB", lblPBan.Text);
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
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
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

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            Commons.Modules.SQLString = "0LOADLOAI";
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
        }
        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadLoaiMay();
        }
        private void cboPBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadLoaiMay();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

        private void ucDMTBKiemDinh_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadPhongBan();
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            LoadNX();
            LoadDChuyen();
            Commons.Modules.SQLString = "";
            LoadLoaiMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDMTBKiemDinh", "KhongCoNam", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDMTBKiemDinh", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDMTBKiemDinh", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDMTBKiemDinh", "KhongCoLMay", Commons.Modules.TypeLanguage));
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
                TNgay = Convert.ToDateTime("01/01/" + datTNgay.DateTime.Year);
                DNgay = TNgay.AddYears(1).AddDays(-1);
                DataTable dtTmp = new DataTable();


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDMTBKiemDinh",
                        TNgay, DNgay, Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDMTBKiemDinh",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    prbIN.Position = prbIN.Properties.Maximum;
                    return;
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, "ucDMTBKiemDinh");
                InDuLieu(sPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDMTBKiemDinh", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

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
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);

                //Activesheet.HPageBreaks.Count + 1
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = 2;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDMTBKiemDinh", "TieuDe", Commons.Modules.TypeLanguage), Dong, 4, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);


                string stmp = "";
                Dong = 5;
                stmp = lblPBan.Text + " : " + cboPBan.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblNguoiKiemSoat.Text + " : " + txtNKSoat.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);


                Dong = Dong + 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDMTBKiemDinh", "ChiNhanh", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 1);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range title;
                Dong++;
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


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong , 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong , 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong , 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong , 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong , 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 6, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong , 8, TDong + Dong, 9);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 6, TDong + Dong, 7);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                //int n = xlWorkSheet.HPageBreaks.Count + 1;
                //int m = xlWorkSheet.VPageBreaks.Count + 1;
                //n = n * m;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                   "ucDMTBKiemDinh", "DuoiTrai", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDMTBKiemDinh", "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = stmp + " &P / &N";
                //00/30.06.2013
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDMTBKiemDinh", "DuoiPhai", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.RightFooter = stmp;
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
                    "ucDMTBKiemDinh", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }

    }
}
