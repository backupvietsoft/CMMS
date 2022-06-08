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
    public partial class ucVTXuatTheoNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public ucVTXuatTheoNhap()
        {
            InitializeComponent();
        }
        private void TaoCbo()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBPCPhiAll", 1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBBCPhi, dtTmp, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", lblBBCPhi.Text);
        }
        private void TaoKho()
        {
            DataTable dtTmp = new DataTable();

            string sSql = " SELECT CONVERT(BIT,1) AS CHON, A.MS_KHO , TEN_KHO" +
                        "   FROM IC_KHO A INNER JOIN NHOM_KHO B ON A.MS_KHO = B.MS_KHO INNER JOIN USERS C ON B.GROUP_ID = C.GROUP_ID " +
                        " 	WHERE (USERNAME = N'" + Commons.Modules.UserName + "') ";

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,  sSql));

            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdKho, grvKho, dtTmp, true, true, true, true, true, "ucVTXuatTheoNhap");

            for (int i = 1; i < grvKho.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvKho.Columns["CHON"].Width = 100;
            grvKho.Columns[1].Width = 250;
            grvKho.Columns["MS_KHO"].Visible = false;

        }

        private void TaoDangXuat()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,1) AS CHON, MS_DANG_XUAT, CASE 0 WHEN 0 THEN DANG_XUAT_VIET WHEN 1 THEN DANG_XUAT_ANH ELSE DANG_XUAT_HOA END AS DXUAT " +
                " FROM DANG_XUAT ORDER BY CASE 0 WHEN 0 THEN DANG_XUAT_VIET WHEN 1 THEN DANG_XUAT_ANH ELSE DANG_XUAT_HOA END"));

            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDXuat, grvDXuat, dtTmp, true, true, true, true, true, "ucVTXuatTheoNhap");

            for (int i = 1; i < grvDXuat.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvDXuat.Columns["CHON"].Width = 100;
            grvDXuat.Columns[1].Width = 250;
            grvDXuat.Columns["MS_DANG_XUAT"].Visible = false;
        }

        private void ucVTXuatTheoNhap_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = DateTime.Now.Date.AddMonths(-1);
            datDNgay.DateTime = DateTime.Now.Date;


            datTNgayNhap.DateTime = DateTime.Now.Date.AddMonths(-1);
            datDNgayNhap.DateTime = DateTime.Now.Date;

            TaoCbo();
            TaoKho();
            TaoDangXuat();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        private void btnALL_Click(object sender, EventArgs e)
        {

            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvKho);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvKho);
        }

        private void btnALL1_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvDXuat);
        }

        private void btnNotALL1_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvDXuat);
        }

        private void txtTKKho_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdKho.DataSource;
            try
            {
                string dk = "";
                if (txtTKKho.Text.Length != 0) dk = " OR  TEN_KHO LIKE '%" + txtTKKho.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

            }
            catch { dtTmp.DefaultView.RowFilter = ""; }

        }

        private void txtTKDXuat_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdDXuat.DataSource;

            try
            {
                string dk = "";

                if (txtTKDXuat.Text.Length != 0) dk = " OR  DXUAT LIKE '%" + txtTKDXuat.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sSql, BTamKho, BtamDXuat, sKho, sDXuat;
            BTamKho = "ZZZ_XTN_CHON_KHO" + Commons.Modules.UserName;
            BtamDXuat = "ZZZ_XTN_CHON_DXUAT" + Commons.Modules.UserName;

            #region Kiem Du Lieu
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonTuNgayXuat", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonDenNgayXuat", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datTNgayNhap.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonTuNgayNhap", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datDNgayNhap.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonDenNgayNhap", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboBBCPhi.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonBPCPhi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            dtTmp = (DataTable)grdKho.DataSource;
            dtTmp = dtTmp.DefaultView.ToTable().Copy();

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonDuLieuKho", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamKho, dtTmp, "");
            sKho = "";
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                sKho = sKho + ", " + dtTmp.Rows[i]["TEN_KHO"].ToString();
            }



            dtTmp = new DataTable();
            dtTmp = (DataTable)grdDXuat.DataSource;
            dtTmp = dtTmp.DefaultView.ToTable().Copy();

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "ChuaChonDuLieuDangXuat", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BtamDXuat, dtTmp, "");
            sDXuat = "";
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                sDXuat = sDXuat + ", " + dtTmp.Rows[i]["DXUAT"].ToString();
            }
            #endregion



            sSql = " SELECT DISTINCT A.MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI INTO #BO_PHAN_CP " +
				 " FROM dbo.BO_PHAN_CHIU_PHI A INNER JOIN NHOM_BO_PHAN_CHIU_PHI B ON A.MS_BP_CHIU_PHI = B.MS_BP_CHIU_PHI " +
				 " INNER JOIN USERS C ON C.GROUP_ID = B.GROUP_ID " + 
				 " WHERE  (C.USERNAME = N'" + Commons.Modules.UserName + "') AND (A.MS_BP_CHIU_PHI = " + cboBBCPhi.EditValue + " OR " + cboBBCPhi.EditValue + " = -1) " +       
            
            
                " SELECT CONVERT(INT,NULL) AS STT, A.MS_PT, TEN_PT, TEN_PT_VIET, QUY_CACH,CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS TEN_DVT ,SLUONG,DGIA,TTIEN " +
                " FROM (SELECT     A.MS_PT, SUM(C.SL_VT) AS SLUONG, SUM(C.SL_VT * B.DON_GIA) / SUM(C.SL_VT) AS DGIA, SUM(C.SL_VT * B.DON_GIA) AS TTIEN " +
                " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS A INNER JOIN " +
                " dbo.IC_DON_HANG_NHAP_VAT_TU AS B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT AND A.MS_PT = B.MS_PT AND A.ID = B.ID INNER JOIN " +
                " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS C ON A.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND A.MS_VI_TRI = C.MS_VI_TRI AND A.MS_PT = C.MS_PT AND  " +
                " A.ID = C.ID_XUAT INNER JOIN " +
                " dbo.IC_DON_HANG_XUAT_VAT_TU AS D ON C.MS_DH_XUAT_PT = D.MS_DH_XUAT_PT AND C.MS_PT = D.MS_PT INNER JOIN " +
                " dbo.IC_DON_HANG_XUAT AS X ON D.MS_DH_XUAT_PT = X.MS_DH_XUAT_PT INNER JOIN " +
                " dbo.IC_DON_HANG_NHAP AS N ON B.MS_DH_NHAP_PT = N.MS_DH_NHAP_PT INNER JOIN " + 
                " #BO_PHAN_CP AS BP ON BP.MS_BP_CHIU_PHI = X.MS_BP_CHIU_PHI  INNER JOIN " + BTamKho + " BTKHO ON " +
                " BTKHO.MS_KHO = X.MS_KHO INNER JOIN " + BtamDXuat + " BTDX ON BTDX.MS_DANG_XUAT = X.MS_DANG_XUAT " +
                " WHERE     (CONVERT(DATETIME,CONVERT(nvarchar(10),X.NGAY,101))  BETWEEN '" + datTNgay.DateTime.ToString("MM/dd/yyyy") + "' AND '" + datDNgay.DateTime.ToString("MM/dd/yyyy") + "') AND  " +
                " (CONVERT(DATETIME,CONVERT(nvarchar(10),N.NGAY,101))  BETWEEN '" + datTNgayNhap.DateTime.ToString("MM/dd/yyyy") + "'  AND '" + datDNgayNhap.DateTime.ToString("MM/dd/yyyy") + "' ) " +    
                " GROUP BY A.MS_PT) A INNER JOIN IC_PHU_TUNG E ON A.MS_PT = E.MS_PT INNER JOIN DON_VI_TINH B ON E.DVT = B.DVT " +
                " ORDER BY A.MS_PT, TEN_PT, TEN_PT_VIET, QUY_CACH ";

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text , sSql));

            Commons.Modules.ObjSystems.XoaTable("#BO_PHAN_CP");

            Commons.Modules.ObjSystems.XoaTable(BTamKho);
            Commons.Modules.ObjSystems.XoaTable(BtamDXuat);

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "KhongCoDulieuIn", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, "ucVTXuatTheoNhap");
            InDuLieu(sKho, sDXuat);

        }


        private void InDuLieu(string sKho, string sDXuat)
        {
            this.Cursor = Cursors.WaitCursor;

            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;

            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount + 1;
                int Dong = 1;
                Excel.Range title;

                //prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 15;
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

                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 10;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TongCong", Commons.Modules.TypeLanguage)
                    , Dong + TDong, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong, 8);

                for (int cot = 9; cot <= 9; cot++)
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", Dong + TDong, cot, Dong + TDong, cot, Dong + 1,
                        cot, TDong, cot, 10, true, 10, "#,##0", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);




                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;

                SCot = (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTXuatTheoNhap", "TieuDe", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblBBCPhi.Text + " : " + cboBBCPhi.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTXuatTheoNhap", "Kho", Commons.Modules.TypeLanguage) + " : " + sKho.Substring(2, sKho.Length - 2);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTXuatTheoNhap", "DangXuat", Commons.Modules.TypeLanguage) + " : " + sDXuat.Substring(2, sDXuat.Length - 2);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblTNgayNhap.Text + " : " + datTNgayNhap.DateTime.ToShortDateString() + " " + lblDNgayNhap.Text + " : " + datDNgayNhap.DateTime.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, SCot);
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, TDong + Dong + 2, TCot);
                title.Borders.LineStyle = 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, Dong + 1, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "##", true, Dong, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "@", true, Dong, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0", true, Dong, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "#,##0", true, Dong, 9, TDong + Dong, 9);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                


                this.Cursor = Cursors.Default;
                //excelWorkbook.Save();
                //excelApplication.Visible = true;
                Commons.Modules.MExcel.ExcelClose(excelApplication, excelWorkbook, excelWorkSheet, true, false);
                prbIN.Position = prbIN.Properties.Maximum;
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucVTXuatTheoNhap", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }

    }
}
