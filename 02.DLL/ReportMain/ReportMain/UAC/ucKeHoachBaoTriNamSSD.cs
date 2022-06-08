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
    public partial class ucKeHoachBaoTriNamSSD : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachBaoTriNamSSD()
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
        
        private void LoadDChuyen()
        {

            DataTable dtTmp = new DataTable();
            dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyen(0);

            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtTmp.Columns.Add(newColumn);
            newColumn.DefaultValue = false;
            newColumn.SetOrdinal(0);


            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, "ucKeHoachBaoTriNamSSD");


            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }



            grvBC.Columns["CHON"].Width = 250;
            grvBC.Columns["TEN_HE_THONG"].Width = grdBC.Width - 500;
            grvBC.Columns["MS_HE_THONG"].Visible = false;

        }



        #endregion

        private void ucKeHoachBaoTriNamSSD_Load(object sender, EventArgs e)
        {
            datThangNam.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            datTNgay.DateTime = Convert.ToDateTime("01/" + datThangNam.DateTime.Month + "/" + datThangNam.DateTime.Year);
            datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            LoadDChuyen();
            LoadLoaiMay();
            LoadNX();
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
                datTNgay.Enabled = true;
                datDNgay.Enabled = true;
                datThangNam.Enabled = false;
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
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKiem.Text.Length != 0) dk = " TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' " + dk;
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
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgChuaChonTuNgay", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return;
                }
                if (datDNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgChuaChonDenNgay", Commons.Modules.TypeLanguage));
                    datDNgay.Focus();
                    return;
                }

                if (cboDDiem.TextValue == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgChuaChonDiaDiem", Commons.Modules.TypeLanguage));
                    cboDDiem.Focus();
                    return;
                }
                if (cboLMay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgChuaChonLoaiMay", Commons.Modules.TypeLanguage));
                    cboLMay.Focus();
                    return;
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
                        Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage));
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
                            Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgKhongChonQua3Thang", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
                else
                {
                    if (TongSoNgay > 366)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD", "msgKhongChonQua1Nam", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
                this.Cursor = Cursors.WaitCursor;
                string sSql = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

                dtTmp = new DataTable();


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHBaoTriThangNamSSD", TNgay, DNgay,
                    cboDDiem.EditValue, sSql, cboLMay.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));


                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
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

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                        "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["Ten_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                    "Ten_N_XUONG", Commons.Modules.TypeLanguage) + " ";
                grvChung.Columns["TEN_HE_THONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                        "TEN_HE_THONG", Commons.Modules.TypeLanguage);
                grvChung.Columns["SL_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                        "SL_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["THUC_HIEN_BOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                        "THUC_HIEN_BOI", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNamSSD",
                        "CHU_KY_TG", Commons.Modules.TypeLanguage);
                InDuLieu(TNgay,DNgay);
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }
            Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_DL" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_SSD" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("KHBT_NAM_TMP" + Commons.Modules.UserName);
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;

        }


        private DataTable TaoDuLieuThang(DataTable dtDL,  DateTime TNgay, DateTime DNgay, int TongSoNgay)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string sSql = "";
                string sBT = "KHBT_NAM_DL" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtDL, "");

                string sBTDL = "KHBT_NAM_SSD" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(sBTDL);

                sSql = " SELECT DISTINCT Ten_N_XUONG, TEN_HE_THONG, (SELECT COUNT(DISTINCT MS_MAY) FROM  " + sBT + " T1 " +
                            " WHERE T1.Ten_N_XUONG = A.Ten_N_XUONG AND T1.TEN_HE_THONG = A.TEN_HE_THONG " +
                            " AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY) AS SL_MAY, '' AS THUC_HIEN_BOI,  CONVERT(NVARCHAR(200) ,CONVERT(NVARCHAR(10) ,CHU_KY ) + ' '  +  " +
                            " CASE 0 WHEN 0 THEN TEN_DV_TG WHEN 1 THEN TEN_DV_TG_ANH ELSE TEN_DV_TG_HOA END ) AS CHU_KY_TG,MS_N_XUONG, MS_HE_THONG, A.MS_DV_TG, A.CHU_KY  " +
                            " INTO " + sBTDL + " FROM " + sBT + "  A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY = B.MS_MAY  INNER JOIN DON_VI_THOI_GIAN C ON A.MS_DV_TG = C.MS_DV_TG ";
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
                        sSql = " SELECT MS_N_XUONG,MS_HE_THONG,MS_MAY,CHU_KY,MS_DV_TG, " +
                                    " NGAY_KE, " + sNConvert +
                                    " INTO " + sBTTmp + " FROM " +
                                    " 	(SELECT Ten_N_XUONG, TEN_HE_THONG, MS_MAY, CHU_KY,MS_DV_TG,MS_N_XUONG,MS_HE_THONG,NGAY_KE,THANG_NAM, " +
                                    " 		 MS_LOAI_BT AS MS_LOAI_BT FROM " + sBT + " ) p " +
                                    " PIVOT  " +
                                    " 	(SUM(MS_LOAI_BT)  FOR THANG_NAM IN (" + sGT + ")) AS pvt  ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sSql = " ALTER TABLE " + sBTDL + " ADD [" + dNgay.Date.ToString("ddd dd MMM") + "] NVARCHAR(10) ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sN = " CONVERT(NVARCHAR(10),(SELECT TOP 1 CASE ISNULL([" + dNgay.ToString("MM/dd/yyyy") + "],'') " +
                                " WHEN '' THEN NULL ELSE 'X' END AS [" + dNgay.ToString("MM/dd/yyyy") + "] FROM " + sBTTmp + " T1 " +
                                " WHERE T1.MS_N_XUONG = A.MS_N_XUONG AND T1.MS_HE_THONG = A.MS_HE_THONG AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY " +
                                " ORDER BY ISNULL([" + dNgay.ToString("MM/dd/yyyy") + "],'') DESC  )) AS A_COT ";

                        sSql = " UPDATE " + sBTDL + " SET [" + dNgay.Date.ToString("ddd dd MMM") + "] = A_COT " +
                                    "  FROM " + sBTDL + " A INNER JOIN " +
                                    "  ( " +
                                    " 	 SELECT DISTINCT	MS_N_XUONG, MS_HE_THONG,MS_DV_TG,CHU_KY, " + sN + " FROM " +  sBTTmp + " A  " +
                                    "  ) B ON A.MS_N_XUONG = B.MS_N_XUONG AND A.MS_HE_THONG = B.MS_HE_THONG  " +
                                    " AND A.MS_DV_TG = B.MS_DV_TG  AND A.CHU_KY = B.CHU_KY ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sSelect = sSelect + ", [" + dNgay.Date.ToString("ddd dd MMM") + "] ";

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion

                    }
                    catch { }
                }
                sSql = " SELECT  ROW_NUMBER() OVER (ORDER BY Ten_N_XUONG, TEN_HE_THONG,CHU_KY_TG) AS STT ,Ten_N_XUONG, TEN_HE_THONG,SL_MAY,THUC_HIEN_BOI,CHU_KY_TG " + sSelect +
                            " FROM " +  sBTDL + " ORDER BY Ten_N_XUONG, TEN_HE_THONG,CHU_KY_TG";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamSSD", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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

                sSql = " SELECT DISTINCT Ten_N_XUONG, TEN_HE_THONG, (SELECT COUNT(DISTINCT MS_MAY) FROM  " + sBT + " T1 " +
                            " WHERE T1.Ten_N_XUONG = A.Ten_N_XUONG AND T1.TEN_HE_THONG = A.TEN_HE_THONG " +
                            " AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY) AS SL_MAY, '' AS THUC_HIEN_BOI,  CONVERT(NVARCHAR(200) ,CONVERT(NVARCHAR(10) ,CHU_KY ) + ' '  +  " +
                            " CASE 0 WHEN 0 THEN TEN_DV_TG WHEN 1 THEN TEN_DV_TG_ANH ELSE TEN_DV_TG_HOA END ) AS CHU_KY_TG,MS_N_XUONG, MS_HE_THONG, A.MS_DV_TG, A.CHU_KY  " +
                            " INTO " + sBTDL + " FROM " + sBT + "  A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY = B.MS_MAY  INNER JOIN DON_VI_THOI_GIAN C ON A.MS_DV_TG = C.MS_DV_TG ";
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
                        sSql = " SELECT MS_N_XUONG,MS_HE_THONG,MS_MAY,CHU_KY,MS_DV_TG, " +
                                    " NGAY_KE, " + sNConvert +
                                    " INTO " + sBTTmp + " FROM " +
                                    " 	(SELECT Ten_N_XUONG, TEN_HE_THONG, MS_MAY, CHU_KY,MS_DV_TG,MS_N_XUONG,MS_HE_THONG,NGAY_KE,THANG, " +
                                    " 		 MS_LOAI_BT AS MS_LOAI_BT FROM " + sBT + " ) p " +
                                    " PIVOT  " +
                                    " 	(SUM(MS_LOAI_BT)  FOR THANG IN ([" + i.ToString() + "])) AS pvt  ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sSql = " ALTER TABLE " + sBTDL + " ADD [" + i.ToString() + "] NVARCHAR(10) ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                        sN = " CONVERT(NVARCHAR(10),(SELECT TOP 1 CASE ISNULL([" + i.ToString() + "],'') " +
                                " WHEN '' THEN NULL ELSE 'X' END AS [" + dNgay.ToString("MM/yyyy") + "] FROM " + sBTTmp + " T1 " +
                                " WHERE T1.MS_N_XUONG = A.MS_N_XUONG AND T1.MS_HE_THONG = A.MS_HE_THONG AND T1.MS_DV_TG = A.MS_DV_TG AND T1.CHU_KY = A.CHU_KY " +
                                " ORDER BY ISNULL([" + i.ToString() + "],'') DESC  )) AS A_COT ";

                        sSql = " UPDATE " + sBTDL + " SET [" + i.ToString() + "] = A_COT " +
                                    "  FROM " + sBTDL + " A INNER JOIN " +
                                    "  ( " +
                                    " 	 SELECT DISTINCT	MS_N_XUONG, MS_HE_THONG,MS_DV_TG,CHU_KY, " + sN + " FROM " +  sBTTmp + " A  " +
                                    "  ) B ON A.MS_N_XUONG = B.MS_N_XUONG AND A.MS_HE_THONG = B.MS_HE_THONG  " +
                                    " AND A.MS_DV_TG = B.MS_DV_TG  AND A.CHU_KY = B.CHU_KY ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        sSelect = sSelect + ", [" + i.ToString() + "] AS [" + dNgay.Date.ToString("MMM") + "] ";

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                        i++;
                    }
                    catch { }
                }
                sSql = " SELECT  ROW_NUMBER() OVER (ORDER BY Ten_N_XUONG, TEN_HE_THONG,CHU_KY_TG) AS STT ,Ten_N_XUONG, TEN_HE_THONG,SL_MAY,THUC_HIEN_BOI,CHU_KY_TG " + sSelect +
                            " FROM " +  sBTDL + " ORDER BY Ten_N_XUONG, TEN_HE_THONG,CHU_KY_TG";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamSSD", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                if (optBCao.SelectedIndex == 1)
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "TieuDeKHBTNSSD", Commons.Modules.TypeLanguage), 2, 4, "@", 16, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "TieuDeKHBTNSSD1", Commons.Modules.TypeLanguage), 2, 4, "@", 16, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                    prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = 5;
                if (optBCao.SelectedIndex == 1)
                {
                    stmp = "( " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "bcTuNgay", Commons.Modules.TypeLanguage) + " " + TNgay.Date.ToShortDateString() + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "bcDenNgay", Commons.Modules.TypeLanguage) + " " + DNgay.Date.ToShortDateString() + " )";
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 5, "@", 13, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 2, 5);

                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "Worksite", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);


                }
                else
                {
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "bcNam", Commons.Modules.TypeLanguage) + " : " + TNgay.Year.ToString() + " ";
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);

                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "Worksite", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong +1, 3, "@", 13, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong+1, 3);

                }

                Dong++;


                Dong++;
                Dong++;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Size = 10;
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


                if (optBCao.SelectedIndex == 1)
                {
                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA3, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 85);

                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 7, "##", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 2, 6, TDong + Dong, 6);


                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 2, 7, TDong + Dong, TCot);
                }
                else
                {
                    //int i = 7;
                    //for (DateTime dNgayIN = TNgay.Date; dNgayIN <= DNgay.Date; dNgayIN = dNgayIN.AddMonths(1))
                    //{
                    //    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong , i, Dong , i);
                    //    title.Value2 = "'" + dNgayIN.ToString("MMM yyyy");

                    //    i++;
                    //}

                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 90);

                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 26, "##", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "##", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 2, 5, TDong + Dong, 6);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 2, 7, TDong + Dong, TCot);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 7, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = 5;
                if (TCot > 37) TCot = 37;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoTriNamSSD", "bcKy1", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot - 11, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 8);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, "", Dong+1, TCot - 11, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong+1, TCot - 8);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamSSD", "bcKy2", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot - 7, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 4);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, "", Dong+1, TCot - 7, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong+1, TCot - 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamSSD", "bcKy3", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot - 3, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, "", Dong+1, TCot - 3, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong+1, TCot);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot - 11, Dong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                xlWorkSheet.Rows.AutoFit();

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                
                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNamSSD", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

    }
}
