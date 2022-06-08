using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucBangKeXNTKhoChinh : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucBangKeXNTKhoChinh";
        public ucBangKeXNTKhoChinh()
        {
            InitializeComponent();
        }

        private void LoadKho()
        { 
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoPQ",Commons.Modules.UserName,0));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", "");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadLVT()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VAT_TU", Commons.Modules.TypeLanguage, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadCheckedComboBoxEdit(cboLVT, dtTmp, "MS_LOAI_VT", "TEN_LOAI_VT");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucBangKeXNTKhoChinh_Load(object sender, EventArgs e)
        {
            datThang.DateTime = DateTime.Now.Date;
            LoadKho();
            LoadLVT();
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datThang.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoThang", Commons.Modules.TypeLanguage));
                datThang.Focus();
                return;
            }
            if (cboKho.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return;
            }

            TaoDuLieu();
        }

        private void TaoDuLieu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                DateTime TNgay, DNgay;
                int iCot = 0;
                TNgay = Convert.ToDateTime(datThang.DateTime.Month + "/" + datThang.DateTime.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);

                string sLVT = cboLVT.EditValue.ToString();
                sLVT = Commons.Modules.ObjSystems.SplitString(sLVT);
                sLVT = "*" + sLVT.Replace(", ", "*,*") + "*";

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBangKeXNTKhoChinh", cboKho.EditValue, TNgay, DNgay, Commons.Modules.TypeLanguage, sLVT));
                string sBT = "", sSql = "", sBTDL = "";
                sBT = "BT_CHINH" + Commons.Modules.UserName;
                sBTDL = "DL" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                //
                DataTable dtDL = new DataTable();
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_KHO , TEN_KHO FROM IC_KHO WHERE MS_KHO <> " + cboKho.EditValue + " ORDER BY TEN_KHO "));
                string sTmpTong = "";
                string sTmpTongXuat = "";
                string sTmpGTTongXuat = "";


                #region Tinh Nhap
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    dtDL = new DataTable();
                    dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSLNhapBangKe",
                        cboKho.EditValue, dtTmp.Rows[i]["MS_KHO"].ToString(), TNgay, DNgay, sLVT));
                    if (dtDL.Rows.Count > 0)
                    {
                        iCot++;
                        sSql = " ALTER TABLE " + sBT + " ADD [N" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] FLOAT, GT_NHAP_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " FLOAT ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                        sSql = "UPDATE " + sBT + " SET [N" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] = SL  , " +
                                    " GT_NHAP_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " = GT FROM " + sBT +
                                    " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sTmpTong = sTmpTong + " + ISNULL([N" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "],0)  ";
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
                    dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSLXuatBangKe",
                        cboKho.EditValue, dtTmp.Rows[i]["MS_KHO"].ToString(), TNgay, DNgay, 1, sLVT));
                    if (dtDL.Rows.Count > 0)
                    {
                        iCot++;
                        sSql = " ALTER TABLE " + sBT + " ADD [X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] FLOAT, GT_XUAT_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " FLOAT ";

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                        sSql = "UPDATE " + sBT + " SET [X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "] = SL  , " +
                                    " GT_XUAT_" + dtTmp.Rows[i]["MS_KHO"].ToString() + " = GT FROM " + sBT +
                                    " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sTmpTong = sTmpTong + " + ISNULL([X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "],0)  ";
                        sTmpTongXuat = sTmpTongXuat + " + ISNULL([X" + dtTmp.Rows[i]["TEN_KHO"].ToString() + "],0)  ";
                        sTmpGTTongXuat = sTmpGTTongXuat + " + ISNULL([GT_XUAT_" + dtTmp.Rows[i]["MS_KHO"].ToString() + "],0)  ";
                    }
                }
                #endregion

                #region Tinh Xuat theo BPCP
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT DISTINCT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI ORDER BY TEN_BP_CHIU_PHI "));
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    dtDL = new DataTable();
                    dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSLXuatBangKe",
                        cboKho.EditValue, dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString(), TNgay, DNgay, 2, sLVT));
                    if (dtDL.Rows.Count > 0)
                    {
                        iCot++;
                        sSql = " ALTER TABLE " + sBT + " ADD [B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "] FLOAT, GT_BPCP_" + dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString() + " FLOAT ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                        sSql = "UPDATE " + sBT + " SET [B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "] = SL  , " +
                                    " GT_BPCP_" + dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString() + " = GT FROM " + sBT +
                                    " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sTmpTong = sTmpTong + " + ISNULL([B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "],0)  ";
                        sTmpTongXuat = sTmpTongXuat + " + ISNULL([B" + dtTmp.Rows[i]["TEN_BP_CHIU_PHI"].ToString() + "],0)  ";
                        sTmpGTTongXuat = sTmpGTTongXuat + " + ISNULL([GT_BPCP_" + dtTmp.Rows[i]["MS_BP_CHIU_PHI"].ToString() + "],0)  ";
                    }
                }
                #endregion

                #region Tinh Xuat khac
                
                dtDL = new DataTable();
                dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSLXuatBangKe",
                    cboKho.EditValue, -1, TNgay, DNgay, 3, sLVT));
                string sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "Khac", Commons.Modules.TypeLanguage);

                sSql = " ALTER TABLE " + sBT + " ADD [X" + sTmp + "] FLOAT, GT_KHAC_1 FLOAT ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");
                sSql = "UPDATE " + sBT + " SET [X" + sTmp + "] = SL  , " +
                            " GT_KHAC_1 = GT FROM " + sBT +
                            " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                sTmpTong = sTmpTong + " + ISNULL([X" + sTmp + "],0)  ";
                sTmpTongXuat = sTmpTongXuat + " + ISNULL([X" + sTmp + "],0)  ";
                sTmpGTTongXuat = sTmpGTTongXuat + " + ISNULL([GT_KHAC_1],0)  ";

                #endregion

                #region Tinh tong xuat
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TongXuat", Commons.Modules.TypeLanguage);
                sSql = " ALTER TABLE " + sBT + " ADD [T" + sTmp + "] FLOAT, [GT_TONG_XUAT] FLOAT ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " UPDATE " + sBT + " SET [T" + sTmp + "] = " + sTmpTongXuat.Substring(2, sTmpTongXuat.Length - 2) + " ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " UPDATE " + sBT + " SET [GT_TONG_XUAT] = " + sTmpGTTongXuat.Substring(2, sTmpGTTongXuat.Length - 2) + " ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                #endregion

                #region Tinh ton cuoi
                dtDL = new DataTable();

                dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBangKeXNTKhoChinh", cboKho.EditValue, DNgay.AddDays(1), "01/01/1900",
                    Commons.Modules.TypeLanguage, sLVT));
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TonKhac", Commons.Modules.TypeLanguage);
                sSql = " ALTER TABLE " + sBT + " ADD [T" + sTmp + "] FLOAT, GT_T_1 FLOAT ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTDL, dtDL, "");

                sSql = "UPDATE " + sBT + " SET [T" + sTmp + "] = B.SL_TON_DK  , " +
                            " GT_T_1 = B.GT_DK FROM " + sBT + " A INNER JOIN " + sBTDL + " B ON A.MS_PT = B.MS_PT";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                sTmpTong = sTmpTong + " + ISNULL([T" + sTmp + "],0)  ";

                #endregion


                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT * FROM " + sBT + " WHERE " + sTmpTong.Substring (2,sTmpTong.Length -2) + " <> 0 ORDER BY STT" ));

                int j = 1;
                foreach (DataRow r in dtTmp.Rows) r["STT"] = j++;

                Commons.Modules.ObjSystems.XoaTable(sBTDL);
                Commons.Modules.ObjSystems.XoaTable(sBT);
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, false, "");
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "MS_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TEN_PT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_LOAI_VT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TEN_LOAI_VT", Commons.Modules.TypeLanguage);
                    grvChung.Columns["DVT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "DVT", Commons.Modules.TypeLanguage);
                grvChung.Columns["SL_TON_DK"].Caption = "G" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "SL_TON_DK", Commons.Modules.TypeLanguage);
                grvChung.Columns["GT_DK"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "GT_DK", Commons.Modules.TypeLanguage);
                grvChung.Columns["SL_NHAPK9"].Caption = "G" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "SL_NHAPK9", Commons.Modules.TypeLanguage);
                grvChung.Columns["GT_NHAPK9"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "GT_NHAPK9", Commons.Modules.TypeLanguage);

                InDuLieu(iCot);

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
                int TCot = grvChung.Columns.Count ;
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

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
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
                    sUC, "Thang", Commons.Modules.TypeLanguage) + " : " + datThang.DateTime.Month.ToString() +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "Nam", Commons.Modules.TypeLanguage) + "/" + datThang.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "Kho", Commons.Modules.TypeLanguage)  + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong = Dong + 2;
                xlApp.DisplayAlerts = false;
                for (int i = 1; i <= 5; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong + 1, i);
                    title.MergeCells = true;
                }

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "TongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong + TDong + 2, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 2, 4);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong+2, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong + 2, 1);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong+1, TCot);
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
                

                string sSl, sGT, sNhap, sXuat;
                sSl = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "SL", Commons.Modules.TypeLanguage);
                sGT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "GT", Commons.Modules.TypeLanguage);
                sNhap = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "Nhap", Commons.Modules.TypeLanguage);
                sXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "Xuat", Commons.Modules.TypeLanguage);


                for (int i = 6; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i + 1);
                    title.MergeCells = true;
                    stmp = Convert.ToString(xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, i], xlWorkSheet.Cells[Dong + 1, i]).Value2);
                    if (stmp.Substring(0, 1) == "N")
                        stmp = sNhap + " " + stmp.Substring(1, stmp.Length - 1);
                    else
                    {
                        if (stmp.Substring(0, 1) == "X")
                            stmp = sXuat + " " + stmp.Substring(1, stmp.Length - 1);
                        else
                            stmp = stmp.Substring(1, stmp.Length - 1);
                    }
                    title.Value2 = stmp;
                    //xlApp.Visible = true;
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, i, Dong + 1, i);
                    title.Value2 = sSl;
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* " + Commons.Modules.sSoLeSL + @"_);_(* (" + Commons.Modules.sSoLeSL + @");_(* "" - ""_);_(@_)", true, Dong + 2, i, TDong + Dong+1, i);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, i + 1, Dong + 1, i + 1);
                    title.Value2 = sGT;
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, @"_(* " + Commons.Modules.sSoLeTT + @"_);_(* (" + Commons.Modules.sSoLeTT + @");_(* "" - ""_);_(@_)", true, Dong + 2, i + 1, TDong + Dong + 1, i + 1);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 2, i, Dong + TDong + 2, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 2, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, i) + ")";
                    title.Font.Bold = true;

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 2, i+1, Dong + TDong + 2, i+1);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 2, i+1) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong + 1, i+1) + ")";
                    title.Font.Bold = true;

                    i++;
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "@", true, Dong + 2, 5, TDong + Dong, 5);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = Dong + TDong + 2;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = Dong  + 2;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sUC, "NguoiBC", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "Ngay", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot - 4, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 4);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "PQLSX", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot - 4, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 4);



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                   sUC, "DuoiTrai", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = stmp + " &P / &N";


                xlWorkBook.Save();
                xlApp.Visible = true;
                
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
                xlApp.DisplayAlerts = false;
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }


    }
}
