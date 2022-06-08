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
    public partial class ucBieuDoTGNMayTheoNXThang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoTGNMayTheoNXThang()
        {
            InitializeComponent();
        }
#region Add event Close form
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("BC_T_NX_CHON" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("NM_NX_T_CHON" + Commons.Modules.UserName);
        }
#endregion

        private void TaoCbo()
        {
            Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");

        }

        private void LoadTTNMay()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                " FROM dbo.NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNNNgungMay, grvNNNgungMay, dtTmp, true, false, true, true);

            
            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["HU_HONG"].ReadOnly = true;
            dtTmp.Columns["BTDK"].ReadOnly = true;
            grvNNNgungMay.Columns["MS_NN"].Visible = false;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Visible = false;

            grvNNNgungMay.Columns["CHON"].Width = 100;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Width = 400;
            //grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Width = 170;

            grvNNNgungMay.Columns["HU_HONG"].Width = 100;
            grvNNNgungMay.Columns["BTDK"].Width = 100;
        }


        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 0)
                cboNXuong.Enabled = true;
            else cboNXuong.Enabled = false;

            LoadLuoi();

            txtTKiemBC.Text = "";

            DataTable dtBC = new DataTable();
            dtBC = (DataTable)grdBC.DataSource;
            dtBC.DefaultView.RowFilter = "";
        }

        private void LoadLuoi()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBCaoThoiGianNgungMay", cboNXuong.EditValue, optBCao.SelectedIndex, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            dtTmp.Columns["CHON"].ReadOnly = false;
            
            
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, "ucBieuDoTGNMayTheoNXThang");

            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            //Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "ucBieuDoTGNMayTheoNXThang");
            grvBC.Columns["CHON"].Width = 100;
            grvBC.Columns[1].Width = 250;
            grvBC.Columns[2].Width = 350;
            if (optBCao.SelectedIndex == 1) grvBC.Columns["MSHT"].Visible = false;

        }

        private void cboNXuong_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadLuoi();
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;


            string BTamChon, BTamChonNN;

            DataTable dtTmp = new DataTable();
            BTamChon = "BC_NX_T_CHON" + Commons.Modules.UserName;
            BTamChonNN = "NM_NX_T_CHON" + Commons.Modules.UserName;


            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChonNN, dtTmp, "");

            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdBC.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChon, dtTmp, "");



            DateTime TThang, DThang;
            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);
            int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);


            prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;

            prbIN.Properties.Maximum = 15 + SoThang + grvChung.RowCount;

            prbIN.Properties.Minimum = 0;

            if (optBCao.SelectedIndex == 0) TaoBCNXuong(BTamChon, BTamChonNN, dtTmp,0);
            if (optBCao.SelectedIndex == 1) TaoBCDayChuyen(BTamChon, BTamChonNN,0);
            if (optBCao.SelectedIndex == 2) TaoBCLoaiTB(BTamChon, BTamChonNN, 0);

            Commons.Modules.ObjSystems.XoaTable(BTamChon);
            Commons.Modules.ObjSystems.XoaTable(BTamChonNN);
            Commons.Modules.ObjSystems.XoaTable("BDTGNM_NX_THANG" + Commons.Modules.UserName);
            DateTime TNgay;
            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            TNgay = Convert.ToDateTime(TThang.Month + "/" + TThang.Year);
            

            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                Commons.Modules.ObjSystems.XoaTable("BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName);
                Thang = Thang.AddMonths(1);
            }

            InDuLieu(sPath,0);
        }

        private Boolean KiemDLieu()
        {
            DateTime TThang, DThang;

            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year);
            //if (TThang == DThang)
            //{
            //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TuThangBangDenThang", Commons.Modules.TypeLanguage));
            //    datTNgay.Focus();
            //    return false;
            //}
            if (TThang > DThang)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);
            if (SoThang > 11)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "LonHonMotNam", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }

            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();

            dtTmp = ((DataTable)grdBC.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNXThang", "ChuaChonDLIn", Commons.Modules.TypeLanguage));
                return false;
            }

            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNXThang", "ChuaChonNguyenNhan", Commons.Modules.TypeLanguage));
                return false;
            }




            #endregion

            return true;
        }

        //iLoai = 0 khong group theo nguyen nhan
        //iLoai = 1 group theo nguyen nhan
        private void TaoBCNXuong(string BTamChon, string BTamChonNN, DataTable dtTmp, int iLoai )
        {
            string sSql;
            DateTime TThang, DThang;
            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);

            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            string BTam, BangTam, sThang, sThangNull, sThangAvg, sTmp;
            
            sThang = "";
            sThangAvg = "";
            sThangNull = "";
            BangTam = "BDTGNM_NX_THANG" + Commons.Modules.UserName;
            
            sTmp = "";

            string sT;
            sT = "";
            foreach (DataRow dRow in dtTmp.Rows)
            {
                sT = sT + (sT == "" ? "" : " UNION ") + " SELECT *, N'" + dRow["TEN_N_XUONG"].ToString() + "' AS TXC, N'" + dRow["MS_N_XUONG"].ToString() + "' AS NXC FROM [dbo].[MashjGetNXUser]('-1','" + dRow["MS_N_XUONG"].ToString() + "')";
            }

            string sTm;
            sTm = "";
            
            sSql = "";
            int iKieuBC;
            iKieuBC = optLBCao.SelectedIndex;            
            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);
                sSql = "";
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;

                if (iKieuBC == 0)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC ";
                }


                if (iKieuBC == 1)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC ";
                }
                if (iKieuBC == 2)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, COUNT(DISTINCT MS_LAN) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC  ";

                }
                if (iKieuBC == 3)
                {
                    if (iLoai == 0)
                    {
                        sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC ";
                        sTm = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                        sTm = sTm.Replace("CONVERT(INT,NULL) AS STT,", "");
                        sSql = " SELECT STT,A.NXC,A.TXC,THOI_GIAN_SUA_CHUA,SO_LAN," +
                        " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                        " FROM (" + sSql + ") A LEFT JOIN (" + sTm + ") B ON A.NXC = B.NXC ";

                        sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC , SUM(MTTR) AS TONG_TG, " +
                            " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam + " FROM ( " + sSql + " ) A GROUP BY NXC,TXC ";
                    }
                    else
                    {

                        sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN ";
                        sTm = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                        sTm = sTm.Replace("CONVERT(INT,NULL) AS STT,", "");
                        sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,SO_LAN," +
                        " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                        " FROM (" + sSql + ") A LEFT JOIN (" + sTm + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ";

                        sSql = " SELECT CONVERT(INT,NULL) AS STT, MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN , SUM(MTTR) AS TONG_TG, " +
                            " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam + " FROM ( " + sSql + " ) A GROUP BY MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN ";
                    }           
                }
                Commons.Modules.ObjSystems.XoaTable(BTam);
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sTmp = sTmp + (sTmp == "" ? "" : " UNION ") + "SELECT * " + (sTmp == "" ? " INTO " + BangTam : "") +
                        " FROM " + BTam + " ";


                sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";


                Thang = Thang.AddMonths(1);
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
            }

            Commons.Modules.ObjSystems.XoaTable(BangTam);
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp);
            string sBT, sBTam;
            sBT = "TGNMX" + Commons.Modules.UserName;
            sBTam = "TGNMX_TONG" + Commons.Modules.UserName;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (iKieuBC != 3)
            {
                if (iKieuBC == 2)
                {
                    sSql = " SELECT * INTO " + sBT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,NXC,TXC, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";

                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, COUNT(DISTINCT MS_LAN) AS TONG_TG INTO " + sBTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC  ";
                    Commons.Modules.ObjSystems.XoaTable(sBTam);
                    if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);




                    sSql = "UPDATE " + sBT + " SET " + sBT + ".TONG_TG = B.TONG_TG FROM " + sBT + " A INNER JOIN " + sBTam + " B ON B.NXC = A.NXC";
                    if (iLoai == 1) sSql = sSql.Replace("NXC", "MS_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT STT,TXC, " + sThangNull.Substring(3, sThangNull.Length - 3) + ", TONG_TG FROM " + sBT + " ORDER BY TONG_TG DESC ";
                }
                else
                    sSql = " SELECT * FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,TXC, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";
            }
            else
            {
                sSql = " SELECT * INTO " + sBT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                            "   ( SELECT STT,NXC,TXC, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                            " 	  FROM  " +
                            " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                            " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                            " 		 )) AS PVT)  " +
                            "    A  ) B ORDER BY TONG_TG DESC ";
                Commons.Modules.ObjSystems.XoaTable(sBT);
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                if (iLoai == 0)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  NXC,TXC ";
                    sTm = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                    sTm = sTm.Replace("CONVERT(INT,NULL) AS STT,", "");
                    sSql = " SELECT STT,A.NXC,A.TXC,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTm + ") B ON A.NXC = B.NXC ";

                    sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC , SUM(MTTR) AS TONG_TG INTO " + sBTam + " FROM ( " + sSql + " ) A GROUP BY NXC,TXC ";
                }
                else
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " ( " + sT + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN ";
                    sTm = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                    sTm = sTm.Replace("CONVERT(INT,NULL) AS STT,", "");
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTm + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ";

                    sSql = " SELECT CONVERT(INT,NULL) AS STT, MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN , SUM(MTTR) AS TONG_TG INTO " + sBTam + " FROM ( " + sSql + " ) A GROUP BY MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN ";
                }
                Commons.Modules.ObjSystems.XoaTable(sBTam);
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);




                sSql = "UPDATE " + sBT + " SET " + sBT + ".TONG_TG = B.TONG_TG FROM " + sBT + " A INNER JOIN " + sBTam + " B ON B.NXC = A.NXC";
                if (iLoai == 1) sSql = sSql.Replace("NXC", "MS_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT,TXC, " + sThangNull.Substring(3, sThangNull.Length - 3) + ", TONG_TG FROM " + sBT + " ORDER BY TONG_TG DESC ";


            }


            if (iLoai == 1) sSql = sSql.Replace("TXC", "TEN_NGUYEN_NHAN");
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            
            grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "STT", Commons.Modules.TypeLanguage);

            if (iLoai == 0)  grvChung.Columns["TXC"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,"ucBieuDoTGNMayTheoNXThang", "TXC", Commons.Modules.TypeLanguage); 
            else
                grvChung.Columns["TEN_NGUYEN_NHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage);

            grvChung.Columns["TONG_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "TONG_TG", Commons.Modules.TypeLanguage);



            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(BTam);
                Thang = Thang.AddMonths(1);
            }
            Commons.Modules.ObjSystems.XoaTable(BangTam);
            Commons.Modules.ObjSystems.XoaTable("TGNMX" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNMX_TONG" + Commons.Modules.UserName);


        }

        private void TaoBCDayChuyen(string BTamChon, string BTamChonNN, int iLoai)
        {
            string sSql,sT;
            DateTime TThang, DThang;
            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);

            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            string BTam, BangTam, sThang, sThangNull, sThangAvg, sTmp;

            sT = "";
            sThang = "";
            sThangAvg = "";
            sThangNull = "";
            BangTam = "BDTGNM_NX_THANG" + Commons.Modules.UserName;

            sTmp = "";
            sSql = "";
            int iKieuBC;
            iKieuBC = optLBCao.SelectedIndex;

            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);
                sSql = "";
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;

                if (iKieuBC == 0)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ";
                }

                if (iKieuBC == 1)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ";
                }

                if (iKieuBC == 2)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, COUNT(DISTINCT MS_LAN) AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ";
                }
                if (iKieuBC == 3)
                {
                    
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,B.TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_HE_THONG,B.TEN_HE_THONG ";

                    if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,B.TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    sT = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                    sT = sT.Replace("CONVERT(INT,NULL) AS STT,", "");
                    

                    sSql = " SELECT CONVERT(INT,NULL) AS STT,A.MS_HE_THONG,A.TEN_HE_THONG," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS TONG_TG, " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sT + ") B ON A.MS_HE_THONG  =  B.MS_HE_THONG ORDER BY " +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END ";

                    if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,A.TEN_HE_THONG", "A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN");
                    if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG  =  B.MS_HE_THONG", "A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN");

                    
                }

                Commons.Modules.ObjSystems.XoaTable(BTam);
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sTmp = sTmp + (sTmp == "" ? "" : " UNION ") + "SELECT * " + (sTmp == "" ? " INTO " + BangTam : "") +
                        " FROM " + BTam + " ";


                sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";

                Thang = Thang.AddMonths(1);
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
            }

            Commons.Modules.ObjSystems.XoaTable(BangTam);
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp);
            string sBT, sBTamTong;
            sBT = "TGNMXDC" + Commons.Modules.UserName;
            sBTamTong = "TGNMXDC_TONG" + Commons.Modules.UserName;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (iKieuBC != 3)
            {
                if (iKieuBC == 2)
                {
                    sSql = " SELECT * INTO " + sBT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,MS_HE_THONG,TEN_HE_THONG, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";

                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    if (iLoai == 1) sSql = sSql.Replace("MS_HE_THONG,TEN_HE_THONG", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, COUNT(DISTINCT MS_LAN) AS SO_LAN INTO " + sBTamTong +
                                " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                                " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ";
                    Commons.Modules.ObjSystems.XoaTable(sBTamTong);
                    if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " UPDATE " + sBT + " SET TONG_TG = SO_LAN FROM " + sBT + " A INNER JOIN " + sBTamTong + " B ON A.MS_HE_THONG = B.MS_HE_THONG ";
                    if (iLoai == 1) sSql = sSql.Replace("MS_HE_THONG", "MS_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT STT,TEN_HE_THONG, " + sThangNull.Substring(3, sThangNull.Length - 3) + " ,TONG_TG " +
                                " 	  FROM  " + sBT + " ORDER BY TONG_TG DESC ";

                }
                else
                    sSql = " SELECT * FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,TEN_HE_THONG, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";

            }
            else
            {
                sSql = " SELECT * INTO " + sBT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                            "   ( SELECT STT,MS_HE_THONG,TEN_HE_THONG, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                            " 	  FROM  " +
                            " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                            " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                            " 		 )) AS PVT)  " +
                            "    A  ) B ORDER BY TONG_TG DESC ";
                Commons.Modules.ObjSystems.XoaTable(sBT);
                if (iLoai == 1) sSql = sSql.Replace("MS_HE_THONG,TEN_HE_THONG", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG  ";

                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                sT = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sT = sT.Replace("CONVERT(INT,NULL) AS STT,", "");

                sSql = " SELECT CONVERT(INT,NULL) AS STT,A.MS_HE_THONG,A.TEN_HE_THONG," +
                            " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                            " INTO " + sBTamTong +
                            " FROM (" + sSql + ") A LEFT JOIN (" + sT + ") B ON A.MS_HE_THONG  =  B.MS_HE_THONG ORDER BY " +
                            " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END ";
                Commons.Modules.ObjSystems.XoaTable(sBTamTong);

                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,A.TEN_HE_THONG", "A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN");
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG  =  B.MS_HE_THONG", "A.MS_NGUYEN_NHAN  =  B.MS_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " UPDATE " + sBT + " SET TONG_TG = MTTR FROM " + sBT + " A INNER JOIN " + sBTamTong + " B ON A.MS_HE_THONG = B.MS_HE_THONG ";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG = B.MS_HE_THONG", "A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT,TEN_HE_THONG, " + sThangNull.Substring(3, sThangNull.Length - 3) + " ,TONG_TG " +
                            " 	  FROM  " + sBT + " ORDER BY TONG_TG DESC ";
            }


            DataTable dtTmp = new DataTable();
            if (iLoai == 1) sSql = sSql.Replace("TEN_HE_THONG", "TEN_NGUYEN_NHAN");
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "STT", Commons.Modules.TypeLanguage);
            if (iLoai == 0)
                grvChung.Columns["TEN_HE_THONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNXThang", "TEN_HE_THONG", Commons.Modules.TypeLanguage);
            else
                grvChung.Columns["TEN_NGUYEN_NHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNXThang", "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage);



            grvChung.Columns["TONG_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "TONG_TG", Commons.Modules.TypeLanguage);


            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(BTam);
                Thang = Thang.AddMonths(1);
            }
            Commons.Modules.ObjSystems.XoaTable("TGNMXDC" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNMXDC_TONG" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable(BangTam);


        }

        private void TaoBCLoaiTB(string BTamChon, string BTamChonNN, int iLoai)
        {
            string sSql,sT;
            DateTime TThang, DThang;
            TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
            DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);

            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            string BTam, BangTam, sThang, sThangNull, sThangAvg, sTmp;
            sThang = "";
            sThangAvg = "";
            sThangNull = "";
            BangTam = "BDTGNM_NX_THANG" + Commons.Modules.UserName;
            sT = "";
            sTmp = ""; 
            int iKieuBC;
            iKieuBC = optLBCao.SelectedIndex;

            sSql = "";
            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);
                sSql = "";
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;
                //sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(" + LoaiBC + ") AS TONG_TG ,  " +
                //            " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                //            " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                //            " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                //            " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                //            " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                //            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                //            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                //            " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";

                if (iKieuBC == 0)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS TONG_TG , " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY   ";
                }
                if (iKieuBC == 1)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY,SUM(THOI_GIAN_SUA) AS TONG_TG ,  " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY   ";
                }
                if (iKieuBC == 2)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY,COUNT(DISTINCT MS_LAN) AS TONG_TG ,  " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY ";
                }

                if (iKieuBC == 3)
                {
                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";

                    if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    sT = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                    sT = sT.Replace("CONVERT(INT,NULL) AS STT,", "");

                    sSql = " SELECT CONVERT(INT,NULL) AS STT,A.MS_LOAI_MAY,A.TEN_LOAI_MAY," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS TONG_TG , " +
                                " N'" + Thang.ToString("MM/yy") + "' AS THANG INTO " + BTam +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sT + ") B ON A.MS_LOAI_MAY  =  B.MS_LOAI_MAY " +
                                "  ";

                    if (iLoai == 1) sSql = sSql.Replace("A.MS_LOAI_MAY,A.TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN");
                    if (iLoai == 1) sSql = sSql.Replace("A.MS_LOAI_MAY  =  B.MS_LOAI_MAY", "A.MS_NGUYEN_NHAN  =  B.MS_NGUYEN_NHAN");
                }

                Commons.Modules.ObjSystems.XoaTable(BTam);
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                

                sTmp = sTmp + (sTmp == "" ? "" : " UNION ") + "SELECT * " + (sTmp == "" ? " INTO " + BangTam : "") +
                        " FROM " + BTam + " ";


                sThang = sThang + " , [" + Thang.ToString("MM/yy") + "] ";
                sThangNull = sThangNull + " , ISNULL([" + Thang.ToString("MM/yy") + "],0) AS [" + Thang.ToString("MM/yy") + "] ";
                sThangAvg = sThangAvg + " + ISNULL([" + Thang.ToString("MM/yy") + "],0) ";

                Thang = Thang.AddMonths(1);
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
            }

            Commons.Modules.ObjSystems.XoaTable(BangTam);
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp);
            string BT;
            BT = "LLOAI_TB" + Commons.Modules.UserName;
            BTam = "LLOAI_TB_TONG" + Commons.Modules.UserName;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;


            if (iKieuBC != 3)
            {
                if (iKieuBC == 2)
                {
                    sSql = " SELECT * INTO " + BT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,MS_LOAI_MAY,TEN_LOAI_MAY, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";
                    Commons.Modules.ObjSystems.XoaTable(BT);
                    if (iLoai == 1) sSql = sSql.Replace("MS_LOAI_MAY,TEN_LOAI_MAY", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY,COUNT(DISTINCT MS_LAN) AS SO_LAN INTO " + BTam +                             
                                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY ";
                    Commons.Modules.ObjSystems.XoaTable(BTam);
                    if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = "UPDATE " + BT + " SET TONG_TG = SO_LAN FROM " + BT + " A INNER JOIN " + BTam + " B ON B.MS_LOAI_MAY = A.MS_LOAI_MAY";
                    if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY = A.MS_LOAI_MAY", "B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = " SELECT STT, TEN_LOAI_MAY, " + sThang.Substring(3, sThang.Length - 3) + ", TONG_TG FROM " + BT + " ORDER BY TONG_TG DESC ";

                }
                else
                {
                    sSql = " SELECT * FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                                "   ( SELECT STT,TEN_LOAI_MAY, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                                " 	  FROM  " +
                                " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                                " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                                " 		 )) AS PVT)  " +
                                "    A  ) B ORDER BY TONG_TG DESC ";
                }
            }
            else
            {
                sSql = " SELECT * INTO " + BT + " FROM (  SELECT A.*, " + sThangAvg.Substring(3, sThangAvg.Length - 3) + " AS TONG_TG FROM " +
                            "   ( SELECT STT, MS_LOAI_MAY,TEN_LOAI_MAY, " + sThangNull.Substring(3, sThangNull.Length - 3) +
                            " 	  FROM  " +
                            " 	(	SELECT * FROM " + BangTam + " 	) P  " +
                            " 		PIVOT (SUM(TONG_TG) FOR THANG IN ( " + sThang.Substring(3, sThang.Length - 3) +
                            " 		 )) AS PVT)  " +
                            "    A  ) B ORDER BY TONG_TG DESC ";
                Commons.Modules.ObjSystems.XoaTable(BT);
                if (iLoai == 1) sSql = sSql.Replace("MS_LOAI_MAY,TEN_LOAI_MAY", "MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";

                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");
                sSql = " SELECT STT,A.MS_LOAI_MAY,A.TEN_LOAI_MAY,THOI_GIAN_SUA_CHUA,SO_LAN," +
                            " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR INTO " + BTam +
                            " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_LOAI_MAY  =  B.MS_LOAI_MAY ORDER BY MTTR DESC";
                Commons.Modules.ObjSystems.XoaTable(BTam);
                if (iLoai == 1) sSql = sSql.Replace("A.MS_LOAI_MAY,A.TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN");
                if (iLoai == 1) sSql = sSql.Replace("A.MS_LOAI_MAY  =  B.MS_LOAI_MAY", "A.MS_NGUYEN_NHAN  =  B.MS_NGUYEN_NHAN");

                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "UPDATE " + BT + " SET TONG_TG = MTTR FROM " + BT + " A INNER JOIN " + BTam + " B ON B.MS_LOAI_MAY = A.MS_LOAI_MAY";

                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY = A.MS_LOAI_MAY", "B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN");
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = " SELECT STT, TEN_LOAI_MAY, " + sThang.Substring(3, sThang.Length - 3) + ", TONG_TG FROM " + BT + " ORDER BY TONG_TG DESC ";


            }
            DataTable dtTmp = new DataTable();
            if (iLoai == 1) sSql = sSql.Replace("TEN_LOAI_MAY", "TEN_NGUYEN_NHAN");
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            
            grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "STT", Commons.Modules.TypeLanguage);
            if(iLoai == 0)
            grvChung.Columns["TEN_LOAI_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "TEN_LOAI_MAY", Commons.Modules.TypeLanguage);
            else
                grvChung.Columns["TEN_NGUYEN_NHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNXThang", "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage);

            grvChung.Columns["TONG_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucBieuDoTGNMayTheoNXThang", "TONG_TG", Commons.Modules.TypeLanguage);

            Commons.Modules.ObjSystems.XoaTable(BangTam);
            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                BTam = "BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(BTam);
                Thang = Thang.AddMonths(1);
            }
            if(iKieuBC ==3)
            {
                Commons.Modules.ObjSystems.XoaTable("LLOAI_TB" + Commons.Modules.UserName);
                Commons.Modules.ObjSystems.XoaTable("LLOAI_TB_TONG" + Commons.Modules.UserName);
            }
        }

        private void InDuLieu(string sPath, int iLoai)
        {

            if (grvChung.RowCount == 0)
            {
                prbIN.Position = prbIN.Properties.Maximum;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                //prbIN.Visible = true;
                //prbIN.Position = 0;
                //prbIN.Properties.Step = 1;
                //prbIN.Properties.PercentView = true;
                //prbIN.Properties.Maximum = 15;// grvChung.RowCount + 11 + TCot - 4;
                //prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.RowHeight = 23;
                xlApp.Cells.ColumnWidth = 9;
                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 10;
                Dong = TDong + 2;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "TongCong", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                for (int cot = 3; cot <= TCot; cot++)
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, cot, Dong, cot, Dong - TDong,
                        cot, Dong - 1, cot, 10, true, 10, "#,##0", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown,4, Dong);

                int SCot;

                SCot = (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                
                if (optLBCao.SelectedIndex == 0)                 
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeTGNM", Commons.Modules.TypeLanguage);
                else
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeTGSC", Commons.Modules.TypeLanguage);
                int iKieuBC;
                iKieuBC = optLBCao.SelectedIndex;
                if (iLoai == 0)
                {
                    if (iKieuBC == 0) stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeTGNM", Commons.Modules.TypeLanguage);
                    if (iKieuBC == 1) stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeTGSC", Commons.Modules.TypeLanguage);
                    if (iKieuBC == 2) stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeSoLan", Commons.Modules.TypeLanguage);
                    if (iKieuBC == 3) stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeMTTR", Commons.Modules.TypeLanguage);
                }else
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TieuDeNNThang", Commons.Modules.TypeLanguage); 

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                
                stmp = lblTThang.Text + " : " + datTNgay.DateTime.ToString("MM/yyyy") + " " + lblDThang.Text + " : " + datDNgay.DateTime.ToString("MM/yyyy");
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

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

                int DongBD;
                Excel.Range title;
                Dong++;
                Dong++;
                DongBD = Dong;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD - 1, 1, TDong + DongBD, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD - 1, 1, DongBD-1, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                

                xlApp.Cells.RowHeight = 23;
                xlApp.Cells.ColumnWidth = 9;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD - 2, 1, DongBD - 2, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, DongBD, 1, TDong + DongBD, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 35, "@", true, DongBD, 2, TDong + DongBD, 2);

                for (int i = 3; i < TCot; i++)
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0", true, DongBD, i, TDong + DongBD, i);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0", true, DongBD, TCot, TDong + DongBD, TCot);
                SCot = TCot + 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD, TCot + 2, DongBD, TCot + 2);
                double iLeft; double iTop;
                double iWidth; double iHeight;

                iLeft = Convert.ToDouble(title.Left);
                iTop = Convert.ToDouble(title.Top);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD, TCot + 2, DongBD + 9, TCot + 2);
                iHeight = Convert.ToDouble(title.Height);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD, TCot + 2, DongBD + 9, TCot + 2 + 7);
                iWidth = Convert.ToDouble(title.Width);




                Boolean dCuoi;
                dCuoi = false;
                for (int i = DongBD; i <= DongBD + TDong ; i++)
                {
                    if (i == DongBD + TDong)
                        dCuoi = true;
                    LoadBieuDo(xlWorkSheet, i, TCot, "", i - DongBD + 1, iLeft, iTop, iWidth, iHeight, dCuoi);

                    #region prb
                    prbIN.PerformStep(); prbIN.Update();
                    #endregion
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                this.Cursor = Cursors.Default;
                xlWorkBook.Save();
                xlApp.Visible = true;


                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }

            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;

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
                    else
                    {
                        sKQ = iSoLan + 1;
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
                _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "Thang", Commons.Modules.TypeLanguage);// "=Sheet1!$A$" + (vDong + 1);                 //"=A" + vDong;
                _with1.Values = ExcelSheets.get_Range("C" + iDong, Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + iDong); //"B33");
                _with1.XValues = ExcelSheets.get_Range("C9", Commons.Modules.MExcel.MCotExcel(iColumKT - 1) + "9");




                if (sCuoi)
                    xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNXThang", "TongCong", Commons.Modules.TypeLanguage);
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

        private void btnALLBC_Click(object sender, EventArgs e)
        {
            //ChooseAll(true, grvNNNgungMay);
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvNNNgungMay);
        }

        private void btnNotALLBC_Click(object sender, EventArgs e)
        {
            //ChooseAll(false, grvNNNgungMay);
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvNNNgungMay);
        }

        private void txtTKiemBC_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtBC = new DataTable();
            dtBC = (DataTable)grdBC.DataSource;

            try
            {
                string dk = "";
                string sTen = "";
                string sMa = "";

                if (optBCao.SelectedIndex == 0)
                {
                    sTen = "TEN_N_XUONG";
                    sMa = "MS_N_XUONG";
                }
                if (optBCao.SelectedIndex == 1)
                {
                    sTen = "TEN_HE_THONG";
                    sMa = "MSHT";
                }
                if (optBCao.SelectedIndex == 2)
                {
                    sTen = "TEN_LOAI_MAY";
                    sMa = "MS_LOAI_MAY";
                }
                if (txtTKiemBC.Text.Length != 0) dk = " OR  " + sMa + " LIKE '%" + txtTKiemBC.Text + "%' " + dk;
                if (txtTKiemBC.Text.Length != 0) dk = " OR  " + sTen + " LIKE '%" + txtTKiemBC.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtBC.DefaultView.RowFilter = dk;

            }
            catch { dtBC.DefaultView.RowFilter = ""; }
        }

        private void txtTKiemNNNM_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTTGM = new DataTable();
            dtTTGM = (DataTable)grdNNNgungMay.DataSource;

            try
            {
                string dk = "";

                if (txtTKiemNNNM.Text.Length != 0) dk = " OR  MS_NN LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                if (txtTKiemNNNM.Text.Length != 0) dk = " OR  TEN_NGUYEN_NHAN LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTTGM.DefaultView.RowFilter = dk;

            }
            catch { dtTTGM.DefaultView.RowFilter = ""; }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void ucBieuDoTGNMayTheoNXThang_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);

            TaoCbo();
            LoadLuoi();
            LoadTTNMay();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void btnInNM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemDLieu()) return;
                string sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
                if (sPath == "") return;


                string BTamChon, BTamChonNN;

                DataTable dtTmp = new DataTable();
                BTamChon = "BC_NX_T_CHON" + Commons.Modules.UserName;
                BTamChonNN = "NM_NX_T_CHON" + Commons.Modules.UserName;


                dtTmp = new DataTable();
                dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 1 ";
                dtTmp = dtTmp.DefaultView.ToTable().Copy();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChonNN, dtTmp, "");

                dtTmp = new DataTable();
                dtTmp = ((DataTable)grdBC.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 1 ";
                dtTmp = dtTmp.DefaultView.ToTable().Copy();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChon, dtTmp, "");



                DateTime TThang, DThang;
                TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                DThang = Convert.ToDateTime(datDNgay.DateTime.Month + "/" + datDNgay.DateTime.Year).AddMonths(1).AddDays(-1);
                int SoThang = Commons.Modules.ObjSystems.MGetSoNgayThang(DThang, TThang);


                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 15 + SoThang + grvChung.RowCount;
                prbIN.Properties.Minimum = 0;

                if (optBCao.SelectedIndex == 0) TaoBCNXuong(BTamChon, BTamChonNN, dtTmp, 1);
                if (optBCao.SelectedIndex == 1) TaoBCDayChuyen(BTamChon, BTamChonNN, 1);
                if (optBCao.SelectedIndex == 2) TaoBCLoaiTB(BTamChon, BTamChonNN, 1);

                Commons.Modules.ObjSystems.XoaTable(BTamChon);
                Commons.Modules.ObjSystems.XoaTable(BTamChonNN);
                Commons.Modules.ObjSystems.XoaTable("BDTGNM_NX_THANG" + Commons.Modules.UserName);
                DateTime TNgay;
                TThang = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                TNgay = Convert.ToDateTime(TThang.Month + "/" + TThang.Year);


                for (DateTime Thang = TThang; Thang <= DThang; )
                {
                    TNgay = Convert.ToDateTime(Thang.Month + "/" + Thang.Year);
                    Commons.Modules.ObjSystems.XoaTable("BDTGNM_NX_THANG" + TNgay.ToString("MMyyyy") + Commons.Modules.UserName);
                    Thang = Thang.AddMonths(1);
                }

                InDuLieu(sPath, 1);
            }
            catch { }
            }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        

    }
}
