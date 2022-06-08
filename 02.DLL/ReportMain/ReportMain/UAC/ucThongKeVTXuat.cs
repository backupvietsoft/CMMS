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
    public partial class ucThongKeVTXuat : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucThongKeVTXuat";

        public ucThongKeVTXuat()
        {
            InitializeComponent();
        }
        private void LoadKho()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoPQ", Commons.Modules.UserName, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", "");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ucThongKeVTXuat_Load(object sender, EventArgs e)
        {
            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            datDNgay.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            datTNgay.DateTime = DateTime.Now;
            LoadKho();
        }

        private void TaoDuLieu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                DateTime TNgay, DNgay;
                int iCot = 0;
                TNgay = datTNgay.DateTime;
                DNgay = datDNgay.DateTime;

                TNgay = Convert.ToDateTime("01/01/2000");
                DNgay = Convert.ToDateTime("01/01/2015");


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeVatTuXuat", cboKho.EditValue, TNgay, DNgay));
                string sBT = "", sSql = "", sBTDL = "";
                sBT = "BT_TKVT" + Commons.Modules.UserName;
                sBTDL = "TK" + Commons.Modules.UserName;

                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                DataTable dtDL = new DataTable();
                #region Tinh Xuat theo BPCP
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT DISTINCT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI ORDER BY TEN_BP_CHIU_PHI "));
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    dtDL = new DataTable();
                    dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeVatTuXuatTheo",
                        cboKho.EditValue, dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString(), TNgay, DNgay, 2));
                    if (dtDL.Rows.Count > 0)
                    {
                        iCot++;
                        sSql = " ALTER TABLE " + sBT + " ADD [B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "] FLOAT, GT_BPCP_" + dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString() + " FLOAT ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                        sSql = "UPDATE " + sBT + " SET [B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "] = SL  , " +
                                    " GT_BPCP_" + dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString() + " = GT FROM " + sBT +
                                    " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT AND A.NGAY = B.NGAY";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                    }
                }
                #endregion

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_KHO , TEN_KHO FROM IC_KHO WHERE MS_KHO <> " + cboKho.EditValue + " AND ISNULL(KHO_DD,0) = 0 ORDER BY TEN_KHO "));

                #region Tinh Xuat
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    dtDL = new DataTable();
                    dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeVatTuXuatTheo",
                        cboKho.EditValue, dtTmp.Rows[i]["MS_KHO"].ToString(), TNgay, DNgay, 1));
                    if (dtDL.Rows.Count > 0)
                    {
                        iCot++;
                        sSql = " ALTER TABLE " + sBT + " ADD [X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] FLOAT, GT_XUAT_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " FLOAT ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                        sSql = "UPDATE " + sBT + " SET [X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] = SL  , " +
                                    " GT_XUAT_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " = GT FROM " + sBT +
                                    " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT AND A.NGAY = B.NGAY ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                    }
                }
                #endregion

                #region Tinh Xuat khac
                dtDL = new DataTable();
                dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongKeVatTuXuatTheo",
                    cboKho.EditValue, -1, TNgay, DNgay, 3));
                string sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "Khac", Commons.Modules.TypeLanguage);

                sSql = " ALTER TABLE " + sBT + " ADD [X" + sTmp + "] FLOAT, GT_KHAC_1 FLOAT ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                sSql = "UPDATE " + sBT + " SET [X" + sTmp + "] = SL  , " +
                            " GT_KHAC_1 = GT FROM " + sBT +
                            " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT  AND A.NGAY = B.NGAY ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                #endregion



                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT * FROM " + sBT));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                // , , , ,
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, false, "");
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["NGAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "NGAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "MS_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TEN_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT_CTY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "MS_PT_CTY", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT_NCC"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "MS_PT_NCC", Commons.Modules.TypeLanguage);
                grvChung.Columns["QUY_CACH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "QUY_CACH", Commons.Modules.TypeLanguage);
                grvChung.Columns["TONG_XUAT"].Caption = "G" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TONG_XUAT", Commons.Modules.TypeLanguage);
                grvChung.Columns["GT_TXUAT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "GT_TXUAT", Commons.Modules.TypeLanguage);
                InDuLieu(iCot);
                Commons.Modules.ObjSystems.XoaTable(sBTDL);
                Commons.Modules.ObjSystems.XoaTable(sBT);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InDuLieu(int iCot)
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
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9 + iCot;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                if (System.Environment.MachineName.ToUpper() == "MASHILOVE") xlApp.Visible = true;

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TieuDe", Commons.Modules.TypeLanguage), 2, 4, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "Kho", Commons.Modules.TypeLanguage) + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TNgay", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "DNgay", Commons.Modules.TypeLanguage) + " : " + datDNgay.DateTime.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                Dong = Dong + 2;
                xlApp.DisplayAlerts = false;
                for (int i = 1; i <= 7; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong + 1, i);
                    title.MergeCells = true;
                }

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "TongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong + TDong + 2, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 2, 7);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 2, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 2, 1);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + 1, TCot);
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
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                if (System.Environment.MachineName.ToUpper() == "MASHILOVE") xlApp.Visible = true;

                string sSl, sGT, sXuat;
                sSl = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "SL", Commons.Modules.TypeLanguage);
                sGT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "GT", Commons.Modules.TypeLanguage);                
                sXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "Xuat", Commons.Modules.TypeLanguage);


                for (int i = 8; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i + 1);
                    title.MergeCells = true;
                    stmp = Convert.ToString(xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, i], xlWorkSheet.Cells[Dong + 1, i]).Value2);

                    if (stmp.Substring(0, 1) == "X")
                        stmp = sXuat + " " + stmp.Substring(1, stmp.Length - 1);
                    else
                        stmp = stmp.Substring(1, stmp.Length - 1);
                    
                    title.Value2 = stmp;

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, i, Dong + 1, i);
                    title.Value2 = sSl;
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, @"_(* #,##0_);_(* (#,##0);_(* "" - ""_);_(@_)", true, Dong + 2, i, TDong + Dong, i);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, i + 1, Dong + 1, i + 1);
                    title.Value2 = sGT;
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, @"_(* #,##0_);_(* (#,##0);_(* "" - ""_);_(@_)", true, Dong + 2, i + 1, TDong + Dong, i + 1);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 2, i, Dong + TDong + 2, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 2, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, i) + ")";
                    title.Font.Bold = true;

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 2, i + 1, Dong + TDong + 2, i + 1);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 2, i + 1) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, i + 1) + ")";
                    title.Font.Bold = true;

                    i++;
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                //"dd/mm/yyyy hh:mm:ss"
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, oldCultureInfo.DateTimeFormat.FullDateTimePattern, true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 7, TDong + Dong, 7);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0_);_(* (#,##0);_(* "" - ""_);_(@_)", true, Dong + 2, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, @"_(* #,##0_);_(* (#,##0);_(* "" - ""_);_(@_)", true, Dong + 2, 9, TDong + Dong, 9);


                Dong = Dong + TDong + 2;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkBook.Save();
                xlApp.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            TaoDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

    }
}
