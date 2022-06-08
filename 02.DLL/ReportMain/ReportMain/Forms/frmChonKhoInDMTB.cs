using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Diagnostics;

namespace ReportMain.Forms
{
    public partial class frmChonKhoInDMTB : DevExpress.XtraEditors.XtraForm
    {
        //iLBCao = 1 IN DANH MUC THIET BI
        //iLBCao = 2 IN TON KHO THEO PHIEU BAO TRI

        public int iLBCao = 1;
        public string MsMay;
        public string TenMay;
        public string sMsPBT;

        public frmChonKhoInDMTB()
        {
            InitializeComponent();
        }

        private void frmChonKhoInDMTB_Load(object sender, EventArgs e)
        {
            try
            {
                TaoLuoi();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                if (iLBCao == 2) this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTonKhoTheoPBT", "frmTonKhoTheoPBT", Commons.Modules.TypeLanguage);
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message);
            }

        }
        private void TaoLuoi()
        {

            DataTable dtTmp = new DataTable();
            try
            {
                string sSql;
                sSql = " SELECT CONVERT(BIT,1) AS CHON, A.MS_KHO , TEN_KHO, CONVERT(NVARCHAR(100),A.MS_KHO ) AS MS_KHO_TIM " +
                            "   FROM IC_KHO A INNER JOIN NHOM_KHO B ON A.MS_KHO = B.MS_KHO INNER JOIN USERS C ON B.GROUP_ID = C.GROUP_ID " +
                            " 	WHERE (USERNAME = N'" + Commons.Modules.UserName + "') " +
                            " ORDER BY TEN_KHO ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, true);
                for (int i = 1; i < grvBC.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "frmTonKhoTheoPBT");
                grvBC.Columns["MS_KHO_TIM"].Visible = false;
                grvBC.Columns["MS_KHO"].Width = 150;
                grvBC.Columns["CHON"].Width = 100;
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message);
            }

        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (iLBCao == 1) InBaoCao();
            if (iLBCao == 2) InTonKhoTheoPBT();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtKho = new DataTable();
            dtKho = (DataTable)grdBC.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_KHO_TIM LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtKho.DefaultView.RowFilter = dk;
            }
            catch { dtKho.DefaultView.RowFilter = ""; }

        }


        #region In Danh Muc Thiet Bi
        private void InBaoCao()
        {
            try
            {
                DataTable dtTmp1 = new DataTable();
                DataTable dtTmp = new DataTable();
                dtTmp = new DataTable();

                dtTmp1 = (DataTable)grdBC.DataSource;
                dtTmp = dtTmp1.DefaultView.ToTable();



                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmChonKhoInDMTB", "ChuaChonDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                string sSql, sTenKho;
                sTenKho = "";
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    sTenKho += (sTenKho == "" ? "" : "; ") + dtTmp.Rows[i]["TEN_KHO"].ToString();
                }

                sSql = "ZZZ_DMTB" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

                if (Commons.Modules.ObjSystems.KhoMoi)
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_PT,MS_PT_NCC, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_PT when 1 then isnull(ten_pt_anh,ten_pt) when 2 then isnull(ten_pt_hoa,ten_pt) end as TEN_PT, MS_PT_CTY,  dbo.IC_PHU_TUNG.QUY_CACH,  " +
                                    " CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT, B.SO_LUONG, " +
                                    " ISNULL(SLTON.SL_TON, 0) AS SL_TON ,  ISNULL(SLTON.DON_GIA, 0) AS DON_GIA FROM (SELECT CONVERT(NVARCHAR(50), MS_PT) AS MS_PT, " +
                                    " SUM(SO_LUONG) AS SO_LUONG FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG AS A " +
                                    " WHERE (MS_MAY = '" + MsMay + "') GROUP BY MS_PT) AS B INNER JOIN " +
                                    " dbo.IC_PHU_TUNG ON B.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " +
                                    " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT LEFT OUTER JOIN " +
                                    " (SELECT X.MS_PT, SUM(X.SL_VT) AS SL_TON ,SUM(X.SL_VT * Z.DON_GIA * Z.TY_GIA) AS DON_GIA " +
                                    " FROM dbo.VI_TRI_KHO_VAT_TU AS X INNER JOIN " + sSql + " Y ON X.MS_KHO = Y.MS_KHO INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU AS Z " +
                                    " ON X.MS_DH_NHAP_PT = Z.MS_DH_NHAP_PT AND X.MS_PT = Z.MS_PT AND X.ID = Z.ID " +
                                    " GROUP BY X.MS_PT) AS SLTON ON dbo.IC_PHU_TUNG.MS_PT = SLTON.MS_PT " +
                                    " ORDER BY B.MS_PT ";
                else
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_PT,MS_PT_NCC, TEN_PT, MS_PT_CTY,  dbo.IC_PHU_TUNG.QUY_CACH,  " +
                                    " CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT, B.SO_LUONG, " +
                                    " ISNULL(SLTON.SL_TON, 0) AS SL_TON ,  ISNULL(SLTON.DON_GIA, 0) AS DON_GIA FROM (SELECT CONVERT(NVARCHAR(50), MS_PT) AS MS_PT, " +
                                    " SUM(SO_LUONG) AS SO_LUONG FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG AS A " +
                                    " WHERE (MS_MAY = '" + MsMay + "') GROUP BY MS_PT) AS B INNER JOIN " +
                                    " dbo.IC_PHU_TUNG ON B.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " +
                                    " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT LEFT OUTER JOIN " +
                                    " (SELECT X.MS_PT, SUM(X.SL_VT) AS SL_TON ,SUM(X.SL_VT * Z.DON_GIA * Z.TY_GIA) AS DON_GIA " +
                                    " FROM dbo.VI_TRI_KHO_VAT_TU AS X INNER JOIN " + sSql + " Y ON X.MS_KHO = Y.MS_KHO INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU AS Z " +
                                    " ON X.MS_DH_NHAP_PT = Z.MS_DH_NHAP_PT AND X.MS_PT = Z.MS_PT " +
                                    " GROUP BY X.MS_PT) AS SLTON ON dbo.IC_PHU_TUNG.MS_PT = SLTON.MS_PT " +
                                    " ORDER BY B.MS_PT ";

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.XoaTable("ZZZ_DMTB" + Commons.Modules.UserName);
                dtTmp.Columns["STT"].ReadOnly = false;
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    dtTmp.Rows[i][0] = (i + 1).ToString();
                }
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmChonKhoInDMTB", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "frmChonKhoInDMTB");

                InDuLieu(sTenKho);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmChonKhoInDMTB", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Commons.Modules.ObjSystems.XoaTable("ZZZ_DMTB" + Commons.Modules.UserName);
        }

        private void InDuLieu(string sTenKho)
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
                prbIN.Properties.Maximum = 9;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
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
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmChonKhoInDMTB", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : TCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Excel.Range title;
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmChonKhoInDMTB", "Kho", Commons.Modules.TypeLanguage) + " : " + sTenKho;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, TCot);
                title.WrapText = true;
                try
                {
                    title.NumberFormat = "";
                }
                catch { }
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmChonKhoInDMTB", "MaThietBi", Commons.Modules.TypeLanguage) + " : " + MsMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmChonKhoInDMTB", "TenThietBi", Commons.Modules.TypeLanguage) + " : " + TenMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

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

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "#,##0", true, Dong + 1, 8, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "#,##0.00", true, Dong + 1, 10, TDong + Dong, 10);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.Visible = true;
                xlWorkBook.Save();
                xlApp.DisplayAlerts = false;
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
                    "frmChonKhoInDMTB", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region In Ton Kho Theo PBT
        private void InTonKhoTheoPBT()
        {
            try
            {
                #region Lay du lieu chon in
                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grdBC.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 1 ";
                dtTmp = dtTmp.DefaultView.ToTable().Copy();
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTonKhoTheoPBT", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                    return;
                }

                #endregion  
                #region Tao Du Lieu
                string sMsKho, sTenKho;
                sTenKho = "";
                sMsKho = "";
                foreach (DataRow drRow in dtTmp.Rows)
                {
                    if (Boolean.Parse(drRow["CHON"].ToString()) == true)
                    {
                        sMsKho += (sMsKho == "" ? "" : ",") + drRow["MS_KHO"].ToString();
                        sTenKho += (sTenKho == "" ? "" : "; ") + drRow["TEN_KHO"].ToString();
                    }

                }

                //if (grvBC.RowCount == dtTmp.Rows.Count) sMsKho = "-1";


                dtTmp = new DataTable();
                if (Commons.Modules.sPrivate == "BARIA")
                {
                    dtTmp = TonTheoBaria(sMsKho);
                }
                else
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MTonKhoTheoPBT", sMsPBT, sMsKho));
                }

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTonKhoTheoPBT", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                dtTmp.Columns["STT"].ReadOnly = false;
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    dtTmp.Rows[i][0] = (i + 1).ToString();
                }


                frmPrInDMTB frm = new frmPrInDMTB();
                frm.dtPrInDMTB = dtTmp;
                frm.sTenKho = sTenKho;
                frm.sMsPBT = sMsPBT;
                frm.ShowDialog();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void InDuLieuTonKhoTheoPBT(string sTenKho)
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
                prbIN.Properties.Maximum = 9;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
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
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : TCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                string MsMay, MsPBT, SoPhieu, TenMay, LoaiBTri, NgayBDKH;

                MsMay = "";
                MsPBT = "";
                SoPhieu = "";
                TenMay = "";
                LoaiBTri = "";
                NgayBDKH = "";


                DataTable dtTmp = new DataTable();

                stmp = " SELECT TOP 1 ISNULL(A.MS_MAY, '') AS MS_MAY, ISNULL(A.MS_PHIEU_BAO_TRI, '') AS MS_PHIEU_BAO_TRI, " +
                            " ISNULL(A.SO_PHIEU_BAO_TRI, '') AS SO_PHIEU_BAO_TRI, ISNULL(B.TEN_MAY, '') AS TEN_MAY,  " +
                            " ISNULL(C.TEN_LOAI_BT, '') AS TEN_LOAI_BT, ISNULL(A.NGAY_BD_KH, '') AS NGAY_BD_KH " +
                            " FROM dbo.PHIEU_BAO_TRI AS A INNER JOIN dbo.MAY AS B ON A.MS_MAY = B.MS_MAY INNER JOIN " +
                            " dbo.LOAI_BAO_TRI AS C ON A.MS_LOAI_BT = C.MS_LOAI_BT " +
                            " WHERE     (A.MS_PHIEU_BAO_TRI = N'" + sMsPBT + "') ";
                try
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, stmp));
                    MsMay = dtTmp.Rows[0]["MS_MAY"].ToString();
                    MsPBT = dtTmp.Rows[0]["MS_PHIEU_BAO_TRI"].ToString();
                    SoPhieu = dtTmp.Rows[0]["SO_PHIEU_BAO_TRI"].ToString();
                    TenMay = dtTmp.Rows[0]["TEN_MAY"].ToString();
                    LoaiBTri = dtTmp.Rows[0]["TEN_LOAI_BT"].ToString();
                    NgayBDKH = DateTime.Parse(dtTmp.Rows[0]["NGAY_BD_KH"].ToString()).ToShortDateString();
                }
                catch { }



                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "MsMay", Commons.Modules.TypeLanguage) + " : " + MsMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "MsPBT", Commons.Modules.TypeLanguage) + " : " + MsPBT;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "SoPhieu", Commons.Modules.TypeLanguage) + " : " + SoPhieu;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "TenMay", Commons.Modules.TypeLanguage) + " : " + TenMay;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "LoaiBTri", Commons.Modules.TypeLanguage) + " : " + LoaiBTri;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "NgayBDKH", Commons.Modules.TypeLanguage) + " : " + NgayBDKH;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "Kho", Commons.Modules.TypeLanguage) + " : " + sTenKho;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);



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
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

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



                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 28, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "#,##0", true, Dong + 1, 6, TDong + Dong, 11);



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlApp.Visible = true;
                xlWorkBook.Save();

                xlApp.DisplayAlerts = false;
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
                    "frmTonKhoTheoPBT", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        #endregion


        private DataTable TonTheoBaria(string sKho)
        {
            string sINTConnect = "";
            string sSql = "";
            string sBT = "TON_KHO_TMP" + Commons.Modules.UserName;
            try
            {
                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                if (sINTConnect == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //Lay du lieu ton tu data NIKITA
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, "sp_PHU_TUNG_SL"));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

                Commons.Modules.ObjSystems.XoaTable("##TON_VT_TMP");
                sSql = "SELECT A.MS_PT,SUM(SL) AS SL_VT INTO ##TON_VT_TMP FROM " + sBT + " A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON A.MS_PT = B.MS_PT " +
                            " WHERE B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' ";
                if (sKho != "-1")
                    sSql += " AND A.MS_KHO IN (SELECT MS_KHO FROM dbo.IC_KHO  WHERE MS_KHO IN (" + sKho + ") ) ";
                sSql += "GROUP BY A.MS_PT ";


                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                // Squ kho co so luong ton thi exec cau tinh ton kho, Luc day thay Bang Tam chua so luong ton = ms kho co
                #region "Cap nhap so luong ton ben NAV"
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MTonKhoTheoPBT", sMsPBT, "##TON_VT_TMP"));
                #endregion
                Commons.Modules.ObjSystems.XoaTable(sBT);
                return dtTmp;


            }
            catch (Exception EX)
            {
                Commons.Modules.ObjSystems.XoaTable("##TON_VT_TMP");
                XtraMessageBox.Show(EX.Message);
                return null;
            }


        }



        private void frmChonKhoInDMTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("ZZZ_DMTB" + Commons.Modules.UserName);
        }

    }
}