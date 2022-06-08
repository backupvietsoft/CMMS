using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils;

namespace ReportMain
{
    public partial class ucBieuDoChiPhiTheoNXThang : DevExpress.XtraEditors.XtraUserControl
    {
        private int iLoaiBC;
        //LoaiBC = 1 theo nha xuong 
        //LoaiBC = 2 theo thang 
        public int LoaiBC { get { return iLoaiBC; } set { iLoaiBC = value; } }


        public ucBieuDoChiPhiTheoNXThang()
        {
            InitializeComponent();
        }
        private void TaoCbo()
        {
            Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");


        }
        private void ucBieuDoChiPhiTheoNXThang_Load(object sender, EventArgs e)
        {
            LoaiBC = 2;
            grdChung.Visible = false;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);

            TaoCbo();
        }

        private void TaoLuoi()
        {

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuongTheoNXCha", cboNXuong.EditValue, optBCao.SelectedIndex, Commons.Modules.TypeLanguage));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false);
            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "ucBieuDoChiPhiTheoNX");
            grvBC.Columns["CHON"].Width = 90;
            grvBC.Columns[1].Width = 250;

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }


        private void cboNXuong_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            TaoLuoi();
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 0)
                cboNXuong.Enabled = true;
            else cboNXuong.Enabled = false;

            TaoLuoi();


        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemDLieu()) return;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;

                Commons.Modules.SQLString = "SSSSSSSS";
                string sSql = "";
                DateTime TNgay, DNgay, dThang;
                dThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                TNgay = Convert.ToDateTime(dThang.Month + "/" + dThang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);

                #region Bao Cao Theo Thang
                if (LoaiBC == 2)
                {

                    DateTime TThang, DThang;
                    TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                    DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);
                    prbIN.Properties.Maximum = 20 + Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);
                    prbIN.Properties.Minimum = 0;

                    string BTam, BangTam, sThang, sThangNull, sThangAvg, sTmp;
                    sThang = "";
                    sThangAvg = "";
                    sThangNull = "";
                    BangTam = "ZZZ_BDCP_THANG";
                    sTmp = "";
                    for (DateTime Thang = TThang; Thang <= DThang;)
                    {
                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion

                        TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                        DNgay = TNgay.AddMonths(1).AddDays(-1);


                        BTam = "ZZZ_BDCP_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;
                        sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                        sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                        sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";

                        sSql = TaoDuLieu(TNgay, DNgay);

                        if (sSql != "")
                        {
                            Commons.Modules.ObjSystems.XoaTable(BTam);
                            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                            sTmp = sTmp + (sTmp == "" ? "" : " UNION ") + "SELECT * " + (sTmp == "" ? " INTO " + BangTam : "") +
                                    " FROM " + BTam + " ";
                        }
                        #region Xoa Bang Tam

                        if (optBCao.SelectedIndex == 0)
                        {
                            int iThang;
                            if (Commons.Modules.SQLString == "SSSSSSSS") iThang = 0; else iThang = int.Parse(Commons.Modules.SQLString);
                            for (int i = 0; i < iThang + 1; i++)
                                Commons.Modules.ObjSystems.XoaTable("ZZZ_DL_THANG" + i.ToString() + TNgay.Month.ToString() + Commons.Modules.UserName);
                        }
                        else
                            Commons.Modules.ObjSystems.XoaTable("ZZZ_DL_THANG" + TNgay.Month.ToString() + Commons.Modules.UserName);
                        #endregion
                        Thang = Thang.AddMonths(1);
                    }
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    #region Xoa Bang Tam
                    Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPLM_THANG" + Commons.Modules.UserName);
                    Commons.Modules.ObjSystems.XoaTable("ZZZ_BDCP_CHON_THANG" + Commons.Modules.UserName);
                    #endregion

                    Commons.Modules.ObjSystems.XoaTable(BangTam);
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion


                    if (optBCao.SelectedIndex == 0) sTmp = "TEN_N_XUONG";
                    if (optBCao.SelectedIndex == 1) sTmp = "TEN_HE_THONG";
                    if (optBCao.SelectedIndex == 2) sTmp = "TEN_BP_CHIU_PHI";
                    if (optBCao.SelectedIndex == 3) sTmp = "TEN_LOAI_MAY";

                    sSql = " SELECT * FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_CP FROM " +
                                "   ( SELECT STT," + sTmp + ", " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_CP) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_CP DESC ";


                    if (sSql == "")
                    {

                        prbIN.Position = prbIN.Properties.Maximum;
                        return;
                    }


                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    dtTmp.Columns["STT"].ReadOnly = false;
                    for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                    {
                        dtTmp.Rows[i][0] = (i + 1).ToString();
                    }

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    for (DateTime Thang = TThang; Thang <= DThang;)
                    {
                        BTam = "ZZZ_BDCP_THANG" + Thang.ToString("MMyyyy") + Commons.Modules.UserName;
                        Commons.Modules.ObjSystems.XoaTable(BTam);
                        Thang = Thang.AddMonths(1);
                    }
                    Commons.Modules.ObjSystems.XoaTable(BangTam);
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
                    grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucBieuDoChiPhiTheoNX", "STT", Commons.Modules.TypeLanguage);
                    grvChung.Columns[sTmp].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucBieuDoChiPhiTheoNX", sTmp, Commons.Modules.TypeLanguage);
                    grvChung.Columns["TONG_CP"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucBieuDoChiPhiTheoNX", "TONG_CP", Commons.Modules.TypeLanguage);
                }
                #endregion

                InDuLieu();
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            catch
            {
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvBC);
        }

        private DataTable TaoDuLieuIn(DateTime TuNgay, DateTime DenNgay, string MaSo)
        {
            try
            {

                DataTable dtTmp = new DataTable();
                string sTmp;
                sTmp = "";

                if (optBCao.SelectedIndex == 0)
                    sTmp = "MBieuDoChiPhiNhaXuongTheoXuong";
                if (optBCao.SelectedIndex == 1)
                    sTmp = "MBieuDoChiPhiHeThongTheoXuong";
                if (optBCao.SelectedIndex == 2)
                    sTmp = "MBieuDoChiPhiBPCPTheoXuong";
                if (optBCao.SelectedIndex == 3)
                    sTmp = "MBieuDoChiPhiLoaiMayTheoXuong";

                if (optBCao.SelectedIndex == 0)
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, sTmp,
                        TuNgay, DenNgay, chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(4) ? 1 : 0, MaSo,Commons.Modules.TypeLanguage, Commons.Modules.UserName));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, sTmp,
                        TuNgay, DenNgay, chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                        chkLChiPhi.GetItemChecked(4) ? 1 : 0, Commons.Modules.TypeLanguage));
                return dtTmp;
            }
            catch
            { return null; }
        }

        private string TaoDuLieu(DateTime TNgay, DateTime DNgay)
        {

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

            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            DataTable dtTmp1 = new DataTable();
            string BTDuLieu;
            BTDuLieu = "ZZZ_BDCP_CHON_THANG" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPLM_THANG" + Commons.Modules.UserName);

            dtTmp1 = (DataTable)grdBC.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTDuLieu, dtTmp, "");

            if (dtTmp.Rows.Count == 0)
            {
                return "";
            }
            #endregion

            string sMa, sTen;
            sMa = "";
            sTen = "";


            string BTam, sSql;
            BTam = "";
            sSql = "";
            DataTable dtDLieu = new DataTable();
            #region Nha Xuong
            if (optBCao.SelectedIndex == 0)
            {
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    BTam = "ZZZ_DL_THANG" + i.ToString() + TNgay.Month.ToString() + Commons.Modules.UserName;
                    dtDLieu = new DataTable();
                    dtDLieu = TaoDuLieuIn(TNgay, DNgay, dtTmp.Rows[i][1].ToString());
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtDLieu, "");
                    sSql = sSql + (sSql == "" ? "" : " UNION ") + " SELECT * FROM " + BTam + " WHERE MS_N_XUONG IN (SELECT MS_N_XUONG FROM "+ BTDuLieu + ")";
                    Commons.Modules.SQLString = i.ToString();
                }
                if (LoaiBC == 1)
                    sSql += " ORDER BY TONG_CP DESC ";
                else
                    sSql = " SELECT AVG(STT) AS STT ,TEN_N_XUONG, SUM(" + sChiPhi + ") AS TONG_CP, N'" + TNgay.ToString("MM/yy") + "' AS THANG  " +
                            " INTO ZZZ_BDCP_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName + " FROM (" + sSql + ") A GROUP BY TEN_N_XUONG";
                #endregion



            }
            else
            {
                if (optBCao.SelectedIndex == 1)
                {
                    sTen = "TEN_HE_THONG";
                    sMa = "MS_HE_THONG";
                }
                if (optBCao.SelectedIndex == 2)
                {
                    sTen = "TEN_BP_CHIU_PHI";
                    sMa = "MS_BP_CHIU_PHI";
                }
                if (optBCao.SelectedIndex == 3)
                {
                    sTen = "TEN_LOAI_MAY";
                    sMa = "MS_LOAI_MAY";
                }
                dtDLieu = new DataTable();
                dtDLieu = TaoDuLieuIn(TNgay, DNgay, "");
                BTam = "ZZZ_DL_THANG" + TNgay.Month.ToString() + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtDLieu, "");

                if (LoaiBC == 1)
                    sSql = " SELECT STT, " + sTen + ", ROUND(CHI_PHI_CO_KH,0) AS CHI_PHI_CO_KH, ROUND(CHI_PHI_KHO_KH,0) AS CHI_PHI_KHO_KH, ROUND(TONG_CP,0) AS TONG_CP " +
                                " FROM " + BTam + " WHERE   " + sMa + " IN ( SELECT DISTINCT " + sMa + " FROM " + BTDuLieu + " ) " +
                                " UNION SELECT NULL, " + sTen + ",  0, 0, 0 " +
                                " FROM " + BTDuLieu + " WHERE  " +
                                " " + sMa + " NOT IN ( SELECT DISTINCT " + sMa + " FROM " + BTam + " )  " +
                                " ORDER BY TONG_CP DESC , " + sTen + " ";
                else
                {
                    sSql = "SELECT AVG(STT) AS STT, " + sTen + ", SUM(" + sChiPhi + ") AS TONG_CP,N'" + TNgay.ToString("MM/yy") + "' AS THANG " +
                                " INTO ZZZ_BDCP_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName +
                                " FROM " + BTam + " WHERE   " + sMa + " IN ( SELECT DISTINCT " + sMa + " FROM " + BTDuLieu + " ) " +
                                " GROUP BY " + sTen + "" +
                                " UNION SELECT NULL, " + sTen + ",  0, N'" + TNgay.ToString("MM/yy") + "' AS THANG " +
                                " FROM " + BTDuLieu + " WHERE  " +
                                " " + sMa + " NOT IN ( SELECT DISTINCT " + sMa + " FROM " + BTam + " )  " +
                                " ORDER BY TONG_CP DESC , " + sTen + " ";
                }

            }
            return sSql;
        }



        private void TaoNXIn()
        {
            string sSql, sTmp;
            DataTable dtTmp = new DataTable();
            dtTmp = new DataTable();
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;


            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBieuDoChiPhi",
                    TNgay, DNgay, Commons.Modules.UserName, Commons.Modules.TypeLanguage, "-1", "-1", "-1", "-1", "-1",
                    chkLChiPhi.GetItemChecked(0) ? 1 : 0, chkLChiPhi.GetItemChecked(1) ? 1 : 0,
                    chkLChiPhi.GetItemChecked(2) ? 1 : 0, chkLChiPhi.GetItemChecked(3) ? 1 : 0,
                    chkLChiPhi.GetItemChecked(4) ? 1 : 0, 1, "-1"));
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                    "ZZZ_MAY_BPCP" + Commons.Modules.UserName, dtTmp, "");

            DataTable dtTmp1 = new DataTable();
            dtTmp = new DataTable();

            sSql = "";
            sTmp = "";
            dtTmp1 = (DataTable)grdBC.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();



            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return;

            }

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                "ZZZ_DC_CHON" + Commons.Modules.UserName, dtTmp, "");

            if (optBCao.SelectedIndex == 3)
            {

                Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPLM" + Commons.Modules.UserName);

                sSql = " SELECT STT, MA_SO,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP INTO ZZZ_BPCPLM" + Commons.Modules.UserName +
                            " FROM ( SELECT AVG(STT) AS STT , MA_SO , SUM(CHI_PHI_CO_KH) AS CHI_PHI_CO_KH , " +
                            " SUM(CHI_PHI_KHO_KH) AS CHI_PHI_KHO_KH  , SUM(TONG_CP) AS TONG_CP " +
                            " FROM(SELECT STT, dbo.MGetLoaiMay(MS_MAY) AS MA_SO , CHI_PHI_CO_KH ,  " +
                            " CHI_PHI_KHO_KH , TONG_CP FROM dbo.ZZZ_MAY_BPCP" + Commons.Modules.UserName + " ) A " +
                            " WHERE ISNULL(MA_SO,'') <> '' GROUP BY MA_SO ) A  " +
                            " WHERE MA_SO IN ( SELECT DISTINCT  MS_LOAI_MAY  FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " )";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT, TEN_LOAI_MAY,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ( " +
                            " SELECT STT, MA_SO,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ZZZ_BPCPLM" + Commons.Modules.UserName + " " +
                            " UNION SELECT CONVERT(FLOAT,NULL) AS STT , MS_LOAI_MAY , " +
                            " CONVERT(FLOAT,0) AS CHI_PHI_CO_KH,CONVERT(FLOAT,0) AS CHI_PHI_KHO_KH, CONVERT(FLOAT,0) AS TONG_CP " +
                            " FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " WHERE MS_LOAI_MAY NOT IN( " +
                            " SELECT DISTINCT MA_SO FROM ZZZ_BPCPLM" + Commons.Modules.UserName + ") ) A " +
                            " INNER JOIN LOAI_MAY ON A.MA_SO = LOAI_MAY.MS_LOAI_MAY  " +
                            " ORDER BY TONG_CP DESC , TEN_LOAI_MAY ";
            }

            if (optBCao.SelectedIndex == 2)
            {

                Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPBPCP" + Commons.Modules.UserName);

                sSql = " SELECT STT, MA_SO,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP INTO ZZZ_BPCPBPCP" + Commons.Modules.UserName +
                            " FROM ( SELECT AVG(STT) AS STT , MA_SO , SUM(CHI_PHI_CO_KH) AS CHI_PHI_CO_KH , " +
                            " SUM(CHI_PHI_KHO_KH) AS CHI_PHI_KHO_KH  , SUM(TONG_CP) AS TONG_CP " +
                            " FROM(SELECT STT, dbo.MGetBPCPhiTheoNgay(MS_MAY,'" + datDNgay.DateTime.ToString("MM/dd/yyyy") + "') AS MA_SO , CHI_PHI_CO_KH ,  " +
                            " CHI_PHI_KHO_KH , TONG_CP FROM dbo.ZZZ_MAY_BPCP" + Commons.Modules.UserName + " ) A " +
                            " WHERE ISNULL(MA_SO,'') <> '' GROUP BY MA_SO ) A  " +
                            " WHERE MA_SO IN ( SELECT DISTINCT  MS_BP_CHIU_PHI  FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " )";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT, TEN_BP_CHIU_PHI,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ( " +
                            " SELECT STT, MA_SO,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ZZZ_BPCPBPCP" + Commons.Modules.UserName + " " +
                            " UNION SELECT CONVERT(FLOAT,NULL) AS STT , MS_BP_CHIU_PHI , " +
                            " CONVERT(FLOAT,0) AS CHI_PHI_CO_KH,CONVERT(FLOAT,0) AS CHI_PHI_KHO_KH, CONVERT(FLOAT,0) AS TONG_CP " +
                            " FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " WHERE MS_BP_CHIU_PHI NOT IN( " +
                            " SELECT DISTINCT MA_SO FROM ZZZ_BPCPBPCP" + Commons.Modules.UserName + ") ) A " +
                            " INNER JOIN BO_PHAN_CHIU_PHI ON A.MA_SO = BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI  " +
                            " ORDER BY TONG_CP DESC , TEN_BP_CHIU_PHI ";
            }

            if (optBCao.SelectedIndex == 1)
            {

                Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPDC" + Commons.Modules.UserName);

                sSql = " SELECT STT, MSHT,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP INTO ZZZ_BPCPDC" + Commons.Modules.UserName +
                            " FROM ( SELECT AVG(STT) AS STT , MSHT , SUM(CHI_PHI_CO_KH) AS CHI_PHI_CO_KH , " +
                            " SUM(CHI_PHI_KHO_KH) AS CHI_PHI_KHO_KH  , SUM(TONG_CP) AS TONG_CP " +
                            " FROM(SELECT STT, dbo.MGetHTTheoNgay(MS_MAY,'" + datDNgay.DateTime.ToString("MM/dd/yyyy") + "') AS MSHT , CHI_PHI_CO_KH ,  " +
                            " CHI_PHI_KHO_KH , TONG_CP FROM dbo.ZZZ_MAY_BPCP" + Commons.Modules.UserName + " ) A " +
                            " WHERE ISNULL(MSHT,'') <> '' GROUP BY MSHT ) A  " +
                            " WHERE MSHT IN ( SELECT DISTINCT  MS_HE_THONG  FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " )";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT, TEN_HE_THONG,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ( " +
                            " SELECT STT, MSHT,CHI_PHI_CO_KH, CHI_PHI_KHO_KH,TONG_CP FROM ZZZ_BPCPDC" + Commons.Modules.UserName + " " +
                            " UNION SELECT CONVERT(FLOAT,NULL) AS STT , MS_HE_THONG , " +
                            " CONVERT(FLOAT,0) AS CHI_PHI_CO_KH,CONVERT(FLOAT,0) AS CHI_PHI_KHO_KH, CONVERT(FLOAT,0) AS TONG_CP " +
                            " FROM ZZZ_DC_CHON" + Commons.Modules.UserName + " WHERE MS_HE_THONG NOT IN( " +
                            " SELECT DISTINCT MSHT FROM ZZZ_BPCPDC" + Commons.Modules.UserName + ") ) A " +
                            " INNER JOIN HE_THONG ON A.MSHT = HE_THONG.MS_HE_THONG  " +
                            " ORDER BY TONG_CP DESC , TEN_HE_THONG ";
            }

            if (optBCao.SelectedIndex == 0)
            {

                sSql = "";
                sTmp = "";

                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    sSql = sSql + (sSql == "" ? "" : " UNION ") + "SELECT * " + (sSql == "" ? " INTO ZZZ_BPCPNX" + Commons.Modules.UserName : "") +
                                " FROM [dbo].[MashjGetMayNXCha]('" + dtTmp.Rows[i]["MS_N_XUONG"].ToString() + "','" + datDNgay.DateTime.ToString("MM/dd/yyyy") + "')";

                    sTmp = sTmp + (sTmp == "" ? "" : " UNION ") + " SELECT CONVERT(FLOAT,NULL) AS STT , '" + dtTmp.Rows[i]["MS_N_XUONG"].ToString() + "' AS MS_CHA , " +
                        " CONVERT(FLOAT,0) AS CHI_PHI_CO_KH,CONVERT(FLOAT,0) AS CHI_PHI_KHO_KH, CONVERT(FLOAT,0) AS TONG_CP ";

                }

                Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPNX" + Commons.Modules.UserName);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT DISTINCT STT , MS_CHA, SUM(CHI_PHI_CO_KH) AS CHI_PHI_CO_KH , " +
                        " SUM(CHI_PHI_KHO_KH) AS CHI_PHI_KHO_KH , SUM(TONG_CP) AS TONG_CP INTO  ZZZ_BPCPNX_TMP" + Commons.Modules.UserName +
                        " FROM ZZZ_MAY_BPCP" + Commons.Modules.UserName + " Y INNER JOIN ZZZ_BPCPNX" + Commons.Modules.UserName + " X ON X.MS_MAY = Y.MS_MAY " +
                        " GROUP BY STT ,MS_CHA ORDER BY TONG_CP DESC ";
                Commons.Modules.ObjSystems.XoaTable("ZZZ_BPCPNX_TMP" + Commons.Modules.UserName);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT * FROM ZZZ_BPCPNX_TMP" + Commons.Modules.UserName +
                            " UNION   " + " SELECT * FROM(   " + sTmp + " ) A " +
                            " WHERE MS_CHA NOT IN (SELECT DISTINCT MS_CHA FROM ZZZ_BPCPNX_TMP" + Commons.Modules.UserName + " )  ORDER BY TONG_CP DESC ";
            }


            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            if (iLoaiBC == 1)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucBieuDoChiPhiTheoNX");
            }

        }

        private void InDuLieu()
        {
            //string sPath = @"C:\Users\HUANNGUYEN\Desktop\012.xls";

            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                excelApplication.Visible = false;

                if (LoaiBC == 2)
                {
                    excelApplication.Cells.RowHeight = 23;
                    excelApplication.Cells.ColumnWidth = 9;
                    excelApplication.Cells.Font.Name = "Tahoma";
                    excelApplication.Cells.Font.Size = 10;

                    Dong = TDong + 2;

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TongCong", Commons.Modules.TypeLanguage)
                        , Dong, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                    for (int cot = 3; cot <= TCot; cot++)
                        Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", Dong, cot, Dong, cot, Dong - TDong,
                            cot, Dong - 1, cot, 10, true, 10, "#,##0", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                }


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                int SCot;

                SCot = (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                if (LoaiBC == 1)
                    stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                else
                    stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("MM/yyyy");

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong++;
                stmp = lblLoaiChiPhi.Text + " : ";
                if (chkLChiPhi.GetItemChecked(0)) stmp = stmp + chkLChiPhi.Items[0].Description.ToString();
                if (chkLChiPhi.GetItemChecked(1)) stmp = stmp + ", " + chkLChiPhi.Items[1].Description.ToString();
                if (chkLChiPhi.GetItemChecked(2)) stmp = stmp + ", " + chkLChiPhi.Items[2].Description.ToString();
                if (chkLChiPhi.GetItemChecked(3)) stmp = stmp + ", " + chkLChiPhi.Items[3].Description.ToString();
                if (chkLChiPhi.GetItemChecked(4)) stmp = stmp + ", " + chkLChiPhi.Items[4].Description.ToString();
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

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
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                if (LoaiBC == 2)
                {

                    excelApplication.Cells.RowHeight = 23;
                    excelApplication.Cells.ColumnWidth = 9;
                    excelApplication.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 1, 9, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", true, Dong + 1, 2, TDong + Dong, 2);

                if (LoaiBC == 1)
                {
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "#,##0", true, Dong + 1, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "#,##0", true, Dong + 1, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "#,##0", true, Dong + 1, 5, TDong + Dong, 5);
                    SCot = 7;
                }
                else
                {
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong + 1, 2, TDong + Dong, 2);
                    for (int i = 3; i <= TCot; i++)
                        Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0", true, Dong + 1, i, TDong + Dong, i);
                    SCot = TCot + 1;
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                if (LoaiBC == 1)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, SCot, Dong + 1, SCot);
                    LoadBieuDo(excelWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 671.25, 395.25);
                }
                else
                {
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
                    for (int i = 11; i <= Dong + TDong + 1; i++)
                    {
                        if (i == Dong + TDong + 1)
                            dCuoi = true;
                        LoadBieuDo(excelWorkSheet, i, TCot, "", i - 10, iLeft, iTop, iWidth, iHeight, dCuoi);

                    }

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong + 1, TCot);
                    title.Borders.LineStyle = 1;

                }
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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }


        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan, double iLeft,
            double iTop, double iWidth, double iHeight)
        {
            try
            {
                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 3);
                double iLan = (iSoLan - 1) % 3;
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
                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "KH", Commons.Modules.TypeLanguage);
                _with1.Values = ExcelSheets.get_Range("C11", (iDong > 61 ? "C61" : "C" + iDong.ToString()));
                _with1.XValues = ExcelSheets.get_Range("B11", (iDong > 61 ? "B61" : "B" + iDong.ToString())); //"B33");

                Excel.Series xlSeries1 = xlSeriesCollection.NewSeries();
                var _with2 = xlSeries1;
                _with2.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                _with2.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "KKH", Commons.Modules.TypeLanguage);
                _with2.Values = ExcelSheets.get_Range("D11", (iDong > 61 ? "D61" : "D" + iDong.ToString())); //"G33");
                _with2.XValues = ExcelSheets.get_Range("B11", (iDong > 61 ? "B61" : "B" + iDong.ToString())); //"B33");
                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TieuDe", Commons.Modules.TypeLanguage);// "=Sheet1!$A$" + (vDong + 1);                 //"=A" + vDong;

                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.Refresh();


            }
            catch
            { }
        }

        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan, double iLeft,
            double iTop, double iWidth, double iHeight, Boolean sCuoi)
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
                _with1.Values = ExcelSheets.get_Range("C" + iDong, Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + iDong); //"B33");
                _with1.XValues = ExcelSheets.get_Range("C10", Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + "10");




                if (sCuoi)
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucDieuChinhThietBi", "TongCong", Commons.Modules.TypeLanguage);
                else
                    xlChart.ChartTitle.Text = "=Sheet1!$B$" + (iDong);


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


            }
            catch
            { }
        }

        private Boolean KiemDLieu()
        {

            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "KhongCoTuThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "KhongCoDenThang", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            DateTime TThang, DThang;

            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year);
            if (TThang == DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TuThangBangDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (TThang > DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (LoaiBC == 2)
            {
                int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);
                if (SoThang > 11)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "LonHonMotNam", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return false;
                }
            }

            if (!chkLChiPhi.GetItemChecked(0) && !chkLChiPhi.GetItemChecked(1) && !chkLChiPhi.GetItemChecked(2) &&
                !chkLChiPhi.GetItemChecked(3) && !chkLChiPhi.GetItemChecked(4))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "KhongChonLChiPhi", Commons.Modules.TypeLanguage));
                chkLChiPhi.Focus();
                return false;
            }


            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            DataTable dtTmp1 = new DataTable();

            dtTmp1 = (DataTable)grdBC.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return false;
            }
            #endregion
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void optBCao_DoubleClick(object sender, EventArgs e)
        {
            //If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then

            
               
        }




        private void optCPhi_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void optBCao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                //var cEdit = (RadioGroup)sender;
                ////string sText = Commons.XtraInputBox.Show(optBCao.Properties.Items[cEdit.SelectedIndex].Description.ToString(), true);
                //string sText = Commons.XtraInputBox.Show((((DevExpress.XtraEditors.ViewInfo.RadioGroupViewInfo)((DevExpress.XtraEditors.BaseEdit)((System.Windows.Forms.Control.ControlAccessibleObject)cEdit.AccessibilityObject).Owner).EditViewInfo).Item.Items[1]).Description, true);

                //this.optBCao = new DevExpress.XtraEditors.RadioGroup();
                var cEdit = (RadioGroup)sender;
                RadioGroupViewInfo cInfo = (RadioGroupViewInfo)cEdit.GetViewInfo();
                //Rectangle r = ((RadioGroupItemViewInfo)cInfo.ItemsInfo[cEdit.SelectedIndex]).GlyphRect;
                
            }
        }
    }
}
