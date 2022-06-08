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
    public partial class ucBieuDoTGNMayTheoThang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoTGNMayTheoThang()
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

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
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
        private void LoadNhomMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString()), "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"), "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text); }
        }

        #endregion

        #region Change du lieu

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }


        #endregion

        private void LoadTTNMay()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                " FROM dbo.NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNNNgungMay, grvNNNgungMay, dtTmp, true, false, true, false);

            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["HU_HONG"].ReadOnly = true;
            dtTmp.Columns["BTDK"].ReadOnly = true;
            grvNNNgungMay.Columns["MS_NN"].Visible = false;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Visible = false;

            grvNNNgungMay.Columns["CHON"].Width = 100;
            grvNNNgungMay.Columns["HU_HONG"].Width = 100;
            grvNNNgungMay.Columns["BTDK"].Width = 100;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Width = 100;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Width = 400;
            LoadMay();
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0load") return;
            try
            {
                DataTable dtTmp = new DataTable();
                DateTime DThang,TThang;
                TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year);
                DThang = DThang.AddMonths(1).AddDays(-1);



                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayThoiGianNgungMay",TThang,
                            DThang, "-1", "-1", "-1",
                            cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue, Commons.Modules.UserName));
                for (int i = 0; i <= dtTmp.Columns.Count - 1; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, true, false);
                grvMay.Columns["MSNX"].Visible = false;
                grvMay.Columns["MS_HT"].Visible = false;
                grvMay.Columns["MS_LOAI_MAY"].Visible = false;
                grvMay.Columns["CHON"].Width = 100;
                grvMay.Columns["TEN_MAY"].Width = 400;
                grvMay.Columns["MODEL"].Width = 100;
                grvMay.Columns["MS_MAY"].Width = 150;
            }
            catch
            { }
        }
        private void btnALLNNNM_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);
        }

        private void btnNotALLNNNM_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);
        }


        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvMay);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvMay);

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }

        private Boolean KiemDLieu()
        {


            DateTime TThang, DThang;

            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year);
            //if (TThang == DThang)
            //{
            //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TuThangBangDenThang", Commons.Modules.TypeLanguage));
            //    datTNgay.Focus();
            //    return false;
            //}
            if (TThang > DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);
            if (SoThang > 11)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "LonHonMotNam", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }

            
            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
                
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }
            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoThang", "ChuaChonNguyenNhan", Commons.Modules.TypeLanguage));
                return false;
            }

            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoThang", "ChuaChonMay", Commons.Modules.TypeLanguage));
                return false;
            }


            #endregion

            return true;
        }

        private void ucBieuDoTGNMayTheoThang_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;
            Commons.Modules.SQLString = "0load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
            string sqsq;
            sqsq = btnNotALLNNNM.Name.Substring(0, "btnNoAll".Length);

            LoadTTNMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            try
            {
                LoadData();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoThang", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }

            DateTime TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DateTime DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year);


            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                Commons.Modules.ObjSystems.XoaTable("BDTGNM_THANG" + Thang.ToString("MMyyyy") + Commons.Modules.UserName);
                Thang = Thang.AddMonths(1);
            }
            Commons.Modules.ObjSystems.XoaTable("BDTGNM_THANG_CHON" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("BDTGNM_THANG_MAY_CHON" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNM_MAY_THANG_TONG" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("BDTGNM_TONG_THANG" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNM_MAY_THANG" + Commons.Modules.UserName);
        }

        private void LoadData()
        {
            DateTime TThang, DThang, TNgay, DNgay;
            DataTable dtTmp = new DataTable();
            string BaoCao="";
            if (optBCao.SelectedIndex == 0)
                BaoCao = "THOI_GIAN_SUA_CHUA";
            if (optBCao.SelectedIndex == 1)
                BaoCao = "THOI_GIAN_SUA";
            if (optBCao.SelectedIndex == 2)
                BaoCao = "SO_LAN";
            if (optBCao.SelectedIndex == 3)
                BaoCao = "MTTR";
            string BTam, BTamChon;

            #region Lay du lieu chon in 
            BTamChon = "BDTGNM_THANG_CHON" + Commons.Modules.UserName;
            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChon, dtTmp, "");

            #endregion TGNM
            #region Lay du lieu chon in MAY
            BTamChon = "BDTGNM_THANG_MAY_CHON" + Commons.Modules.UserName;
            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChon, dtTmp, "");
            #endregion

            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime( datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays (-1);
            string  sThang, sSql, BangTam, sThangNull, sThangAvg;
            
            sThang = "";
            sSql = "";
            sThangAvg = "";
            BangTam = "BDTGNM" + Commons.Modules.UserName;
            sThangNull = "";
            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime( Thang.Month + "/" + Thang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);

                BTam = "BDTGNM_THANG" + Thang.ToString("MMyyyy") + Commons.Modules.UserName;
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBDTGNgungMayTheoMay",
                        TNgay, DNgay, "-1", "-1", "-1",
                        cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, "");

                
                sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";
                if (optBCao.SelectedIndex == 3)
                    sSql = sSql + (sSql == "" ? "" : " UNION ") + "SELECT TTNM.MS_MAY, " +
                                " ISNULL(CASE ISNULL(SUM(THOI_GIAN_SUA_CHUA),0) WHEN 0 THEN 0 ELSE SUM(THOI_GIAN_SUA_CHUA) /SUM(SO_LAN) END,0) AS MTTR," +
                                " N'" + TNgay.ToString("MM/yy") + "' AS THANG " +
                                " FROM " + BTam + " TTNM LEFT JOIN (SELECT  A.MS_NGUYEN_NHAN,   A.MS_MAY, COUNT(DISTINCT MS_LAN) AS SO_LAN  " +
                                " FROM THOI_GIAN_NGUNG_MAY A " +
                                " INNER JOIN BDTGNM_THANG_CHON" + Commons.Modules.UserName + " B ON A.MS_NGUYEN_NHAN  = B.MS_NGUYEN_NHAN " +
                                " WHERE A.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                                " AND '" + DNgay.ToString("MM/dd/yyyy") + "'  GROUP BY A.MS_MAY,A.MS_NGUYEN_NHAN ) TGNML ON TTNM.MS_MAY = TGNML.MS_MAY " +
                                " AND TTNM.MS_NGUYEN_NHAN = TGNML.MS_NGUYEN_NHAN GROUP BY TTNM.MS_MAY ";
                else
                    sSql = sSql + (sSql == "" ? "" : " UNION ") + "SELECT TTNM.MS_MAY, ISNULL(SUM(" + BaoCao + "),0) AS " + BaoCao + " , " +
                                " ISNULL(CASE ISNULL(SUM(THOI_GIAN_SUA_CHUA),0) WHEN 0 THEN 0 ELSE SUM(THOI_GIAN_SUA_CHUA) /SUM(SO_LAN) END,0) AS MTTR," +
                                " N'" + TNgay.ToString("MM/yy") + "' AS THANG " +
                                " FROM " + BTam + " TTNM LEFT JOIN (SELECT  A.MS_NGUYEN_NHAN,   A.MS_MAY, COUNT(DISTINCT MS_LAN) AS SO_LAN  " +
                                " FROM THOI_GIAN_NGUNG_MAY A " +
                                " INNER JOIN BDTGNM_THANG_CHON" + Commons.Modules.UserName + " B ON A.MS_NGUYEN_NHAN  = B.MS_NGUYEN_NHAN " +
                                " WHERE A.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                                " AND '" + DNgay.ToString("MM/dd/yyyy") + "'  GROUP BY A.MS_MAY,A.MS_NGUYEN_NHAN ) TGNML ON TTNM.MS_MAY = TGNML.MS_MAY " +
                                " AND TTNM.MS_NGUYEN_NHAN = TGNML.MS_NGUYEN_NHAN GROUP BY TTNM.MS_MAY ";

                Thang = Thang.AddMonths(1);
            }
            sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_MAY,	TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI,THOI_GIAN , THANG INTO " + BangTam + " FROM " +
            " ( " +
            " SELECT A.MS_MAY,SUM(" + BaoCao + ") AS THOI_GIAN, THANG FROM " +
            " ( " + sSql +  " ) A INNER JOIN BDTGNM_THANG_MAY_CHON" + Commons.Modules.UserName + " C ON A.MS_MAY = C.MS_MAY " +
            " GROUP BY A.MS_MAY, THANG ) A INNER JOIN MAY C ON A.MS_MAY = C.MS_MAY ";



            Commons.Modules.ObjSystems.XoaTable(BangTam);
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            string sBTam;
            sBTam = "TGNM_MAY_THANG" + Commons.Modules.UserName;
            TNgay = TThang;
            DNgay = DThang;
            BTam = "BDTGNM_TONG_THANG" + Commons.Modules.UserName;
            string sBTamTong;
            sBTamTong = "TGNM_MAY_THANG_TONG" + Commons.Modules.UserName;

            if (optBCao.SelectedIndex != 3)
            {
                if (optBCao.SelectedIndex == 2)
                {
                    sSql = " SELECT * INTO " + sBTam + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,MS_MAY,TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(THOI_GIAN) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";
                    Commons.Modules.ObjSystems.XoaTable(sBTam);
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBDTGNgungMayTheoMay",
                            TNgay, DNgay, "-1", "-1", "-1",
                            cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, "");

                    sSql = "SELECT TTNM.MS_MAY, ISNULL(SUM(SO_LAN),0) AS SO_LAN  INTO " + sBTamTong +
                                " FROM " + BTam + " TTNM LEFT JOIN (SELECT  A.MS_NGUYEN_NHAN,   A.MS_MAY, COUNT(DISTINCT A.MS_LAN) AS SO_LAN  " +
                                " FROM THOI_GIAN_NGUNG_MAY  A " +
                                " INNER JOIN BDTGNM_THANG_CHON" + Commons.Modules.UserName + " B ON A.MS_NGUYEN_NHAN  = B.MS_NGUYEN_NHAN " +
                                " WHERE A.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                                " AND '" + DNgay.ToString("MM/dd/yyyy") + "'  GROUP BY A.MS_MAY,A.MS_NGUYEN_NHAN ) TGNML ON TTNM.MS_MAY = TGNML.MS_MAY " +
                                " AND  TTNM.MS_NGUYEN_NHAN = TGNML.MS_NGUYEN_NHAN GROUP BY TTNM.MS_MAY";
                    Commons.Modules.ObjSystems.XoaTable(sBTamTong);
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " UPDATE " + sBTam + " SET TONG_TG = SO_LAN FROM " + sBTam + " A INNER JOIN  " + sBTamTong + " B ON A.MS_MAY = B.MS_MAY";
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                    sSql = " SELECT  STT,MS_MAY,TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI, " + sThangNull.Substring(3, sThangNull.Length - 3) + " , TONG_TG " +
                                " FROM  " + sBTam + " ORDER BY TONG_TG DESC";

                }
                else
                {
                    sSql = " SELECT * FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                    "   ( SELECT STT,MS_MAY,TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                    " 	  FROM  " +
                    " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                    " 		PIVOT (SUM(THOI_GIAN) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                    " 		 )) AS PVT)  " +
                    "    A  ) B ORDER BY TONG_TG DESC ";                

                }
            }
            else
            {
                sSql = " SELECT * INTO " + sBTam + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                            "   ( SELECT STT,MS_MAY,TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                            " 	  FROM  " +
                            " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                            " 		PIVOT (SUM(THOI_GIAN) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                            " 		 )) AS PVT)  " +
                            "    A  ) B ORDER BY TONG_TG DESC ";
                Commons.Modules.ObjSystems.XoaTable(sBTam);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBDTGNgungMayTheoMay",
                        TNgay, DNgay, "-1", "-1", "-1",
                        cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, "");

                sSql = "SELECT TTNM.MS_MAY, ISNULL(SUM(SO_LAN),0) AS SO_LAN , " +
                            " ISNULL(CASE ISNULL(SUM(THOI_GIAN_SUA_CHUA),0) WHEN 0 THEN 0 ELSE SUM(THOI_GIAN_SUA_CHUA) / SUM(SO_LAN) END,0) AS MTTR INTO " + sBTamTong +
                            " FROM " + BTam + " TTNM LEFT JOIN (SELECT  A.MS_NGUYEN_NHAN,   A.MS_MAY, COUNT(DISTINCT A.MS_LAN) AS SO_LAN  " +
                            " FROM THOI_GIAN_NGUNG_MAY  A " +
                            " INNER JOIN BDTGNM_THANG_CHON" + Commons.Modules.UserName + " B ON A.MS_NGUYEN_NHAN  = B.MS_NGUYEN_NHAN " +
                            " WHERE A.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' " +
                            " AND '" + DNgay.ToString("MM/dd/yyyy") + "'  GROUP BY A.MS_MAY,A.MS_NGUYEN_NHAN ) TGNML ON TTNM.MS_MAY = TGNML.MS_MAY " +
                            " AND  TTNM.MS_NGUYEN_NHAN = TGNML.MS_NGUYEN_NHAN GROUP BY TTNM.MS_MAY";
                Commons.Modules.ObjSystems.XoaTable(sBTamTong);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " UPDATE " + sBTam + " SET TONG_TG = MTTR FROM " + sBTam + " A INNER JOIN  " + sBTamTong + " B ON A.MS_MAY = B.MS_MAY";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                sSql = " SELECT  STT,MS_MAY,TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI, " + sThangNull.Substring(3, sThangNull.Length - 3) + " , TONG_TG " +
                            " FROM  " + sBTam + " ORDER BY TONG_TG DESC";
            }



            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);

            grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "STT", Commons.Modules.TypeLanguage);
            grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "MS_MAY", Commons.Modules.TypeLanguage);
            grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "TEN_MAY", Commons.Modules.TypeLanguage);
            grvChung.Columns["TONG_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "TONG_TG", Commons.Modules.TypeLanguage);
            
            grvChung.Columns["MODEL"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "MODEL", Commons.Modules.TypeLanguage);
            grvChung.Columns["MO_TA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "MO_TA", Commons.Modules.TypeLanguage);
            grvChung.Columns["NHIEM_VU_THIET_BI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoThang", "NHIEM_VU_THIET_BI", Commons.Modules.TypeLanguage);
            InDuLieu();


            
        }

        private void InDuLieu()
        {
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

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 15 + grvChung.RowCount + 1;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);

                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelApplication.Cells.RowHeight = 23;
                excelApplication.Cells.ColumnWidth = 9;
                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 10;

                Dong = Dong + TDong + 1;
                
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TongCong", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                for (int cot = 7; cot <= TCot; cot++)
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", Dong, cot, Dong, cot,  2, cot, Dong - 1, cot, 10, true, 10, "#,##0");

                TDong = TDong + 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;

                SCot = (TCot > 8 ? 8 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";


                if (optBCao.SelectedIndex == 0)
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TieuDeTGNM", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 1)
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TieuDeTGSC", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 2)
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TieuDeSLNM", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 3)
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TieuDeMTTR", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                
                stmp = lblTThang.Text + " : " + datTNgay.DateTime.ToString("MM/yyyy") + " " + lblDThang.Text + " : " + 
                    datDNgay.DateTime.ToString("MM/yyyy");

                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10,tr
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong++;
                stmp = lblNhomMay.Text + " : " + cboNhomMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);


                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong = Dong + 2;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                

                excelApplication.Cells.RowHeight = 23;
                excelApplication.Cells.ColumnWidth = 9;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", true, Dong + 1, 6, TDong + Dong, 6);

                for (int i = 7; i <= TCot-1; i++)
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "#,##0", true, Dong + 1, i, TDong + Dong, i);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0", true, Dong + 1, TCot, TDong + Dong, TCot);

                SCot = 7;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Boolean dCuoi;
                dCuoi = false;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongBD, TCot + 2, DongBD, TCot + 2);
                double iLeft; double iTop;
                double iWidth; double iHeight;

                iLeft = Convert.ToDouble(title.Left);
                iTop = Convert.ToDouble(title.Top);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongBD, TCot + 2, DongBD + 9, TCot + 2);
                iHeight = Convert.ToDouble(title.Height);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongBD , TCot + 2, DongBD + 9, TCot + 2 + 7);
                iWidth = Convert.ToDouble(title.Width);



                for (int i = 14; i <= Dong + TDong; i++)
                {
                    if (i == Dong + TDong)
                        dCuoi = true;
                    LoadBieuDo(excelWorkSheet, i, TCot, "", i - 13, iLeft, iTop, iWidth, iHeight, dCuoi);
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
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
                    "ucBieuDoTGNMayTheoThang", "InKhongThanhCong", Commons.Modules.TypeLanguage));

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

                if (iSoLan == 4) iTop = iTop + 9;
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

                if (iSoLan == 4)
                {
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TGSC", Commons.Modules.TypeLanguage);
                    _with1.Values = ExcelSheets.get_Range("H14", (iDong > 34 ? "H33" : "H" + iDong.ToString())); //"B33");
                    _with1.XValues = ExcelSheets.get_Range("B14", (iDong > 34 ? "B33" : "B" + iDong.ToString()));
                }
                else
                {
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TGNM", Commons.Modules.TypeLanguage);
                    _with1.Values = ExcelSheets.get_Range("G14", (iDong > 34 ? "G33" : "G" + iDong.ToString())); //"B33");
                    _with1.XValues = ExcelSheets.get_Range("B14", (iDong > 34 ? "B33" : "B" + iDong.ToString()));
                }
                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlChart.HasTitle = true;
                if (iSoLan == 4)
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TDTGSC", Commons.Modules.TypeLanguage);
                else
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TDTGNM", Commons.Modules.TypeLanguage);

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

        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan,
            double iLeft, double iTop, double iWidth, double iHeight, Boolean sCuoi)
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

                    if (iSoLan != 1) iSoLan = int.Parse(sKQ.ToString());


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
                if (optBCao.SelectedIndex == 0)
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TGNM", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 1)
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TGSC", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 2)
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "SLNM", Commons.Modules.TypeLanguage);
                if (optBCao.SelectedIndex == 3)
                    _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "MTTR", Commons.Modules.TypeLanguage);


                _with1.Values = ExcelSheets.get_Range("G" + iDong, Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + iDong); //"B33");
                _with1.XValues = ExcelSheets.get_Range("G13", Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + "13");




                if (sCuoi)
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoThang", "TongCong", Commons.Modules.TypeLanguage);
                else
                    xlChart.ChartTitle.Text = "=Sheet1!$B$" + (iDong);


                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlChart.HasTitle = true;
                //xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        private void txtTKNNNM_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTGNM = new DataTable();
            dtTGNM = (DataTable)grdNNNgungMay.DataSource;

            try
            {
                string dk = "";

                if (txtTKNNNM.Text.Length != 0) dk = " OR  MS_NN LIKE '%" + txtTKNNNM.Text + "%' " + dk;
                if (txtTKNNNM.Text.Length != 0) dk = " OR  TEN_NGUYEN_NHAN LIKE '%" + txtTKNNNM.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTGNM.DefaultView.RowFilter = dk;

                //DataRow[] results = dtTGNM.Select(" MS_NGUYEN_NHAN = " + txtTKNNNM.Text + " ");
                //DataTable newDataTable = results.CopyToDataTable<DataRow>();    
            }
            catch { dtTGNM.DefaultView.RowFilter = ""; }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdMay.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtMay.DefaultView.RowFilter = dk;

            }
            catch { dtMay.DefaultView.RowFilter = ""; }



        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }



    }
}
