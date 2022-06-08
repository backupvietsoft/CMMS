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
    public partial class ucKeHoachBaoTriNamVH : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachBaoTriNamVH()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");

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
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboDDiem.TextValue == "") return;
            if (cboLMay.Text == "") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayUserALL", Commons.Modules.UserName,
                    cboDDiem.EditValue, -1, -1, cboLMay.EditValue, "-1", "-1", datDNgay.DateTime.Date, Commons.Modules.TypeLanguage));

            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtTmp.Columns.Add(newColumn);
            newColumn.DefaultValue = false;
            newColumn.SetOrdinal(0);
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, "ucKeHoachBaoTriNamVH");

            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
                if (dtTmp.Columns[i].ColumnName == "MS_MAY" || dtTmp.Columns[i].ColumnName == "TEN_MAY" || dtTmp.Columns[i].ColumnName == "MODEL" || dtTmp.Columns[i].ColumnName == "TEN_BP_CHIU_PHI" || dtTmp.Columns[i].ColumnName == "Ten_N_XUONG" || dtTmp.Columns[i].ColumnName == "TEN_HE_THONG")
                    grvBC.Columns[i].Visible = true;
                else
                    grvBC.Columns[i].Visible = false;

            }



            grvBC.Columns["CHON"].Width = 10;
            //grvBC.Columns["TEN_HE_THONG"].Width = grdBC.Width - 500;
            //grvBC.Columns["MS_HE_THONG"].Visible = false;

        }



        #endregion

        private void ucKeHoachBaoTriNamSSD_Load(object sender, EventArgs e)
        {
            datThangNam.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            datTNgay.DateTime = Convert.ToDateTime("01/" + datThangNam.DateTime.Month + "/" + datThangNam.DateTime.Year);
            datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            Commons.Modules.SQLString = "0LOAD";
            LoadLoaiMay();
            LoadNX();
            Commons.Modules.SQLString = "";
            LoadMay();
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 1)
            {
                //Thang
                datThangNam.MMonthYear = true;
                datThangNam.Properties.DisplayFormat.FormatString = "MM/yyyy";
                datThangNam.Properties.EditFormat.FormatString = "MM/yyyy";
                datThangNam.Properties.EditMask = "MM/yyyy";
                datTNgay.DateTime = Convert.ToDateTime("01/" + datThangNam.DateTime.Month + "/" + datThangNam.DateTime.Year);
                datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
                datTNgay.Enabled = false;
                datDNgay.Enabled = false;
                datThangNam.Enabled = true;
            }
            else
            {
                datThangNam.MMonthYear = false;
                datThangNam.Properties.DisplayFormat.FormatString = "yyyy";
                datThangNam.Properties.EditFormat.FormatString = "yyyy";
                datThangNam.Properties.EditMask = "yyyy";
                datTNgay.DateTime = Convert.ToDateTime("01/01/" + datThangNam.DateTime.Year);
                datDNgay.DateTime = datTNgay.DateTime.AddYears(1).AddDays(-1);
                datTNgay.Enabled = false;
                datDNgay.Enabled = false;
                datThangNam.Enabled = true;
            }

        }
        private void datThangNam_EditValueChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 1)
            {
                //Thang
                datTNgay.DateTime = Convert.ToDateTime("01/" + datThangNam.DateTime.Month + "/" + datThangNam.DateTime.Year);
                datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            }
            else
            {
                datTNgay.DateTime = Convert.ToDateTime("01/01/" + datThangNam.DateTime.Year);
                datDNgay.DateTime = datTNgay.DateTime.AddYears(1).AddDays(-1);
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
            this.ParentForm.Close();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                //MS_MAY,TEN_MAY,MODEL,TEN_BP_CHIU_PHI,Ten_N_XUONG,TEN_HE_THONG

                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKiem.Text.Length != 0)
                        dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' " +
                            " OR MODEL LIKE '%" + txtTKiem.Text + "%' OR TEN_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' " +
                            " OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%'  OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' ";
                    dtTmp.DefaultView.RowFilter = dk;

                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
            }
            catch { }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {


            try
            {
                if (datTNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgChuaChonTuNgay", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return;
                }
                if (datDNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgChuaChonDenNgay", Commons.Modules.TypeLanguage));
                    datDNgay.Focus();
                    return;
                }

                if (cboDDiem.TextValue == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgChuaChonDiaDiem", Commons.Modules.TypeLanguage));
                    cboDDiem.Focus();
                    return;
                }
                if (cboLMay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgChuaChonLoaiMay", Commons.Modules.TypeLanguage));
                    cboLMay.Focus();
                    return;
                }


                DateTime TNgay, DNgay;
                if (optBCao.SelectedIndex == 1)
                {

                    TNgay = datTNgay.DateTime;
                    DNgay = datDNgay.DateTime;

                }
                else
                {
                    TNgay = Convert.ToDateTime("01/01/" + datThangNam.DateTime.Year);
                    DNgay = TNgay.AddYears(1).AddDays(-1);
                }
                TimeSpan Time = DNgay - TNgay;
                int TongSoNgay = Time.Days;
                if (optBCao.SelectedIndex == 1)
                {
                    if (TongSoNgay > 93)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgKhongChonQua3Thang", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
                else
                {
                    if (TongSoNgay > 366)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgKhongChonQua1Nam", Commons.Modules.TypeLanguage));
                        return;
                    }
                }

                
                DataTable dtTmp1 = new DataTable();
                DataTable dtTmp = new DataTable();
                dtTmp = new DataTable();

                dtTmp1 = (DataTable)grdBC.DataSource;
                dtTmp = dtTmp1.Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "msgChuaChonMay", Commons.Modules.TypeLanguage));
                    return;
                }

                string sSql = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

                dtTmp = new DataTable();


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHBaoTriThangNamVH", TNgay, DNgay,
                    cboDDiem.EditValue, sSql, cboLMay.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));


                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }

                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;

                if (optBCao.SelectedIndex == 1)
                {
                    prbIN.Properties.Maximum = 9 + TongSoNgay;
                    dtTmp = TaoDuLieuThang(dtTmp, TNgay, DNgay, TongSoNgay);
                }
                else
                {
                    prbIN.Properties.Maximum = 9 + 12;
                    dtTmp = TaoDuLieuNam(dtTmp, TNgay, DNgay, TongSoNgay);
                }

                //DataTable dtTmp = new DataTable();
                //string sBTDL = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                //string sSql = " SELECT  ROW_NUMBER() OVER (ORDER BY TEN_MAY,MS_MAY,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG) AS STT , TEN_MAY,MS_MAY,MODEL,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG , [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12] " +
                //            " FROM " + sBTDL + " ORDER BY TEN_MAY,MS_MAY,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG";
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


                //string sSql = " SELECT  ROW_NUMBER() OVER (ORDER BY TEN_MAY,MS_MAY,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG) AS STT , TEN_MAY,MS_MAY,CHU_KY_TG  , [Tue 01 Sep] AS [01] , [Wed 02 Sep] AS [02] , [Thu 03 Sep] AS [03] , [Fri 04 Sep] AS [04] , [Sat 05 Sep] AS [05] , [Sun 06 Sep] AS [06] , [Mon 07 Sep] AS [07] , [Tue 08 Sep] AS [08] , [Wed 09 Sep] AS [09] , [Thu 10 Sep] AS [10] , [Fri 11 Sep] AS [11] , [Sat 12 Sep] AS [12] , [Sun 13 Sep] AS [13] , [Mon 14 Sep] AS [14] , [Tue 15 Sep] AS [15] , [Wed 16 Sep] AS [16] , [Thu 17 Sep] AS [17] , [Fri 18 Sep] AS [18] , [Sat 19 Sep] AS [19] , [Sun 20 Sep] AS [20] , [Mon 21 Sep] AS [21] , [Tue 22 Sep] AS [22] , [Wed 23 Sep] AS [23] , [Thu 24 Sep] AS [24] , [Fri 25 Sep] AS [25] , [Sat 26 Sep] AS [26] , [Sun 27 Sep] AS [27] , [Mon 28 Sep] AS [28] , [Tue 29 Sep] AS [29] , [Wed 30 Sep] AS [30]  FROM KHBT_NAM_SSDAdmin ORDER BY Ten_N_XUONG, TEN_BP_CHIU_PHI,CHU_KY_TG";
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "TEN_MAY", Commons.Modules.TypeLanguage);

                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "MS_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "CHU_KY_TG", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 0)
                {
                    grvChung.Columns["Ten_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                        "Ten_N_XUONG", Commons.Modules.TypeLanguage) + " ";

                    grvChung.Columns["TEN_BP_CHIU_PHI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                            "TEN_BP_CHIU_PHI", Commons.Modules.TypeLanguage);

                    grvChung.Columns["MODEL"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH",
                            "MODEL", Commons.Modules.TypeLanguage);

                }
                this.Cursor = Cursors.WaitCursor;
                InDuLieu(TNgay, DNgay);
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }
            //Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_DL" + Commons.Modules.UserName);
            //Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_SSD" + Commons.Modules.UserName);
            //Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_TMP" + Commons.Modules.UserName);
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;

        }


        private DataTable TaoDuLieuThang(DataTable dtDL, DateTime TNgay, DateTime DNgay, int TongSoNgay)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string sSql = "";
                string sBT = "KHBT_NAM_DL" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtDL, "");

                string sBTDL = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(sBTDL);

                sSql = " SELECT DISTINCT A.TEN_MAY,A.MS_MAY,A.MODEL,TEN_BP_CHIU_PHI,Ten_N_XUONG, CONVERT(NVARCHAR(200) , " +
                            " CONVERT(NVARCHAR(10) ,CHU_KY ) + ' '  +   CASE 0 WHEN 0 THEN TEN_DV_TG WHEN 1 THEN TEN_DV_TG_ANH ELSE TEN_DV_TG_HOA END ) AS CHU_KY_TG, " +
                            " MS_N_XUONG,MS_BP_CHIU_PHI, A.MS_DV_TG, A.CHU_KY INTO " + sBTDL +
                            " FROM " + sBT + "  A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY = B.MS_MAY  INNER JOIN DON_VI_THOI_GIAN C ON A.MS_DV_TG = C.MS_DV_TG ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                string sBTTmp = "KHBT_NAM_TMP" + Commons.Modules.UserName;

                string sGT = "";
                string sNConvert = "";
                string sN = "";
                string sSelect = "";

                for (DateTime dNgay = TNgay.Date; dNgay <= DNgay.Date; dNgay = dNgay.AddDays(1))
                {
                    try
                    {
                        sGT = "[" + Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                                " SELECT CONVERT(INT,CONVERT(DATETIME,'" + dNgay.ToString("MM/dd/yyyy") + "')) ")) + "]";

                        sNConvert = " CONVERT(NVARCHAR(10)," + sGT + ") AS [" + dNgay.ToString("MM/dd/yyyy") + "]";

                        
                        Commons.Modules.ObjSystems.XoaTable(sBTTmp);
                        sSql = " SELECT MS_N_XUONG,MS_BP_CHIU_PHI,MS_MAY,CHU_KY,MS_DV_TG, " +
                                    " NGAY_KE, " + sNConvert +
                                    " INTO " + sBTTmp + " FROM " +
                                    " 	(SELECT Ten_N_XUONG, TEN_BP_CHIU_PHI, MS_MAY, CHU_KY,MS_DV_TG,MS_N_XUONG,MS_BP_CHIU_PHI,NGAY_KE,THANG_NAM, " +
                                    " 		 MS_LOAI_BT AS MS_LOAI_BT FROM " + sBT + " ) p " +
                                    " PIVOT  " +
                                    " 	(SUM(MS_LOAI_BT)  FOR THANG_NAM IN (" + sGT + ")) AS pvt  ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sSql = " ALTER TABLE " + sBTDL + " ADD [" + dNgay.Date.ToString("ddd dd MMM") + "] NVARCHAR(10) ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sN = " CONVERT(NVARCHAR(10),(SELECT TOP 1 CASE ISNULL([" + dNgay.ToString("MM/dd/yyyy") + "],'') " +
                                " WHEN '' THEN NULL ELSE 'X' END AS [" + dNgay.ToString("MM/dd/yyyy") + "] FROM " + sBTTmp + " T1 " +
                                " WHERE T1.MS_MAY = A.MS_MAY AND T1.MS_N_XUONG = A.MS_N_XUONG AND T1.MS_BP_CHIU_PHI = A.MS_BP_CHIU_PHI AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY " +
                                " ORDER BY ISNULL([" + dNgay.ToString("MM/dd/yyyy") + "],'') DESC  )) AS A_COT ";

                        sSql = " UPDATE " + sBTDL + " SET [" + dNgay.Date.ToString("ddd dd MMM") + "] = A_COT " +
                                    "  FROM " + sBTDL + " A INNER JOIN " +
                                    "  ( " +
                                    " 	 SELECT DISTINCT MS_MAY,	MS_N_XUONG, MS_BP_CHIU_PHI,MS_DV_TG,CHU_KY, " + sN + " FROM " + sBTTmp + " A  " +
                                    "  ) B ON A.MS_MAY = B.MS_MAY AND A.MS_N_XUONG = B.MS_N_XUONG AND A.MS_BP_CHIU_PHI = B.MS_BP_CHIU_PHI  " +
                                    " AND A.MS_DV_TG = B.MS_DV_TG  AND A.CHU_KY = B.CHU_KY ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sSelect = sSelect + ", [" + dNgay.Date.ToString("ddd dd MMM") + "] AS [" + dNgay.Date.ToString("dd") + "] ";

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                    }
                    catch { }
                }
                sSql = " SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY TEN_MAY,MS_MAY,CHU_KY_TG) AS STT , TEN_MAY,MS_MAY,CHU_KY_TG  " + sSelect +
                            " FROM " + sBTDL + " ORDER BY TEN_MAY,MS_MAY,CHU_KY_TG";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamVH", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtTmp;
        }

        private DataTable TaoDuLieuNam(DataTable dtDL, DateTime TNgay, DateTime DNgay, int TongSoNgay)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string sSql = "";
                string sBT = "KHBT_NAM_DL" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtDL, "");

                string sBTDL = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(sBTDL);

                sSql = " SELECT DISTINCT A.TEN_MAY,A.MS_MAY,A.MODEL,TEN_BP_CHIU_PHI,Ten_N_XUONG, CONVERT(NVARCHAR(200) , " + 
                            " CONVERT(NVARCHAR(10) ,CHU_KY ) + ' '  +   CASE 0 WHEN 0 THEN TEN_DV_TG WHEN 1 THEN TEN_DV_TG_ANH ELSE TEN_DV_TG_HOA END ) AS CHU_KY_TG, " +
                            " MS_N_XUONG,MS_BP_CHIU_PHI, A.MS_DV_TG, A.CHU_KY INTO " + sBTDL  +
                            " FROM " + sBT + "  A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY = B.MS_MAY  INNER JOIN DON_VI_THOI_GIAN C ON A.MS_DV_TG = C.MS_DV_TG ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                string sBTTmp = "KHBT_NAM_TMP" + Commons.Modules.UserName;

                //string sGT = "";
                string sNConvert = "";
                string sN = "";
                string sSelect = "";

                int i = 1;

                for (DateTime dNgay = TNgay.Date; dNgay <= DNgay.Date; dNgay = dNgay.AddMonths(1))
                {
                    try
                    {


                        sNConvert = " CONVERT(NVARCHAR(10),[" + i.ToString() + "]) AS [" + i.ToString() + "]";

                        Commons.Modules.ObjSystems.XoaTable(sBTTmp);
                        sSql = " SELECT MS_N_XUONG,MS_BP_CHIU_PHI,MS_MAY,CHU_KY,MS_DV_TG, " +
                                    " NGAY_KE, " + sNConvert +
                                    " INTO " + sBTTmp + " FROM " +
                                    " 	(SELECT Ten_N_XUONG, TEN_BP_CHIU_PHI, MS_MAY, CHU_KY,MS_DV_TG,MS_N_XUONG,MS_BP_CHIU_PHI,NGAY_KE,THANG, " +
                                    " 		 MS_LOAI_BT AS MS_LOAI_BT FROM " + sBT + " ) p " +
                                    " PIVOT  " +
                                    " 	(SUM(MS_LOAI_BT)  FOR THANG IN ([" + i.ToString() + "])) AS pvt  ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sSql = " ALTER TABLE " + sBTDL + " ADD [" + i.ToString() + "] NVARCHAR(10) ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sN = " CONVERT(NVARCHAR(10),(SELECT TOP 1 CASE ISNULL([" + i.ToString() + "],'') " +
                                " WHEN '' THEN NULL ELSE 'X' END AS [" + dNgay.ToString("MM/yyyy") + "] FROM " + sBTTmp + " T1 " +
                                " WHERE T1.MS_MAY = A.MS_MAY AND T1.MS_N_XUONG = A.MS_N_XUONG AND T1.MS_BP_CHIU_PHI = A.MS_BP_CHIU_PHI AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY " +
                                " ORDER BY ISNULL([" + i.ToString() + "],'') DESC  )) AS A_COT ";

                        sSql = " UPDATE " + sBTDL + " SET [" + i.ToString() + "] = A_COT " +
                                    "  FROM " + sBTDL + " A INNER JOIN " +
                                    "  ( " +
                                    " 	 SELECT DISTINCT MS_MAY,	MS_N_XUONG, MS_BP_CHIU_PHI,MS_DV_TG,CHU_KY, " + sN + " FROM " + sBTTmp + " A  " +
                                    "  ) B ON A.MS_MAY = B.MS_MAY AND A.MS_N_XUONG = B.MS_N_XUONG AND A.MS_BP_CHIU_PHI = B.MS_BP_CHIU_PHI  " +
                                    " AND A.MS_DV_TG = B.MS_DV_TG  AND A.CHU_KY = B.CHU_KY ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sSelect = sSelect + ", [" + i.ToString() + "] AS [T" + dNgay.Date.Month.ToString() + "] ";

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                        i++;
                    }
                    catch { }
                }
                sSql = " SELECT  ROW_NUMBER() OVER (ORDER BY TEN_MAY,MS_MAY,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG) AS STT , TEN_MAY,MS_MAY,MODEL,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG " + sSelect +
                            " FROM " + sBTDL + " ORDER BY TEN_MAY,MS_MAY,TEN_BP_CHIU_PHI,Ten_N_XUONG,CHU_KY_TG";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamVH", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtTmp;
        }

        private void InDuLieu(DateTime TNgay, DateTime DNgay)
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
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 12;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                int iCot = 0;
                iCot = TCot - 8;

                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 5, 120, 45, Application.StartupPath);
                if (optBCao.SelectedIndex == 1)
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamVH", "TieuDeKHBTThangVH", Commons.Modules.TypeLanguage), 1, 3, "@", 16, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamVH", "TieuDeKHBTNamVH", Commons.Modules.TypeLanguage), 1, 3, "@", 16, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3,2);
                title.MergeCells = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 3, 3, iCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.MergeCells = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                string stmp1 = "";
                iCot++;
                Dong = 1;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamVH", "bcMaSo", Commons.Modules.TypeLanguage);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "bcMaSo", Commons.Modules.TypeLanguage);
                stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamVH", "bcMaSo1", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp + " " + stmp1, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, iCot, Dong, TCot);
                title.get_Characters(stmp.Length + 1, stmp1.Length + 1).Font.Bold = true;



                //Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, iCot, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamVH", "bcNgayHL", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamVH", "bcLanSX", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, iCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Dong++;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong+1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong+1, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong+1, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                if (optBCao.SelectedIndex == 1)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong + 1, i);
                        title.MergeCells = true;
                    }

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong, TCot);
                    title.MergeCells = true;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                "ucKeHoachBaoTriNamVH", "bcThang", Commons.Modules.TypeLanguage) + " " + datTNgay.DateTime.Date.Month.ToString();
                    title.Value2 = stmp;



                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 85);

                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 2, 1, TDong + Dong+1, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong + 2, 2, TDong + Dong + 1, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "##", true, Dong + 2, 3, TDong + Dong + 1, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "##", true, Dong + 2, 4, TDong + Dong + 1, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "@", true, Dong + 2, 5, TDong + Dong + 1, TCot);


                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 5, TDong + Dong + 1, TCot);
                    title.Font.Size = 10;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }
                else
                {
                    for (int i = 1; i < 8; i++)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong + 1, i);
                        title.MergeCells = true;
                    }

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 8, Dong, TCot);
                    title.MergeCells = true;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                "ucKeHoachBaoTriNamVH", "bcNam", Commons.Modules.TypeLanguage) + " " + datThangNam.DateTime.Year.ToString();
                    title.Value2 = stmp;



                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 90);

                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 2, 1, TDong + Dong +1, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 29, "@", true, Dong + 2, 2, TDong + Dong + 1, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "##", true, Dong + 2, 3, TDong + Dong + 1, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "##", true, Dong + 2, 4, TDong + Dong + 1, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 5, TDong + Dong + 1, 6);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, "@", true, Dong + 2, 7, TDong + Dong + 1, 7);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.14, "@", true, Dong + 2, 8, TDong + Dong + 1, TCot);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 8, TDong + Dong + 1, TCot);
                    title.Font.Size = 10;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkSheet.Rows.AutoFit();
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                title.RowHeight = 18;


                Dong = TDong + Dong + 3;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamVH", "bcNguoiLap", Commons.Modules.TypeLanguage), Dong, 1, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, false, Dong+2, 7);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamVH", "bcThamTra", Commons.Modules.TypeLanguage), Dong, 8, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, false, Dong+2, TCot);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong+2, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                xlWorkBook.Save();
                xlApp.Visible = true;
                
                
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamVH", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
    }
}
