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
    public partial class ucBieuDoTGNMayTheoNX : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoTGNMayTheoNX()
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
            Commons.Modules.ObjSystems.XoaTable("ZZZ_BC_NX_CHON" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("ZZZ_NM_NX_CHON" + Commons.Modules.UserName);
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
            //grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Width = 170;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Width = 400;
            grvNNNgungMay.Columns["HU_HONG"].Width = 100;
            grvNNNgungMay.Columns["BTDK"].Width = 100;
        }


        private void ucBieuDoTGNMayTheoNX_Load(object sender, EventArgs e)
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
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBCaoThoiGianNgungMay", cboNXuong.EditValue, optBCao.SelectedIndex,Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false);

                for (int i = 1; i < grvBC.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "ucBieuDoTGNMayTheoNX");
                grvBC.Columns["CHON"].Width = 100;
                grvBC.Columns[1].Width = 250;
                grvBC.Columns[2].Width = 350;
                if (optBCao.SelectedIndex == 1) grvBC.Columns["MSHT"].Visible = false;
            }
            catch { }
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
            BTamChon = "ZZZ_BC_NX_CHON" + Commons.Modules.UserName;
            BTamChonNN = "ZZZ_NM_NX_CHON" + Commons.Modules.UserName;


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


            if (optBCao.SelectedIndex == 0) TaoBCNXuong(BTamChon, BTamChonNN, dtTmp,0);
            if (optBCao.SelectedIndex == 1) TaoBCDayChuyen(BTamChon, BTamChonNN,0);
            if (optBCao.SelectedIndex == 2) TaoBCLoaiTB(BTamChon, BTamChonNN,0);

            Commons.Modules.ObjSystems.XoaTable(BTamChon);
            Commons.Modules.ObjSystems.XoaTable(BTamChonNN);
            if (grvChung.RowCount == 0)
            {
                prbIN.Position = prbIN.Properties.Maximum;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            InDuLieu(sPath,0);

        }

        private Boolean KiemDLieu()
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (TNgay >= DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
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
                    "ucBieuDoTGNMayTheoNX", "ChuaChonDLIn", Commons.Modules.TypeLanguage));
                return false;
            }

            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNX", "ChuaChonNguyenNhan", Commons.Modules.TypeLanguage));
                return false;
            }




            #endregion

            return true;
        }

        //iLoai = 0 khong group theo nguyen nhan
        //iLoai = 1 group theo nguyen nhan
        private void TaoBCNXuong(string BTamChon, string BTamChonNN, DataTable dtTmp, int iLoai)
        {
            string sSql;
            string sTmp;
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            sSql = "";
            sTmp = "";

            foreach (DataRow dRow in dtTmp.Rows)
            {
                sSql = sSql + (sSql == "" ? "" : " UNION ") + " SELECT *, N'" + dRow["TEN_N_XUONG"].ToString() + "' AS TXC, N'" + dRow["MS_N_XUONG"].ToString() + "' AS NXC FROM [dbo].[MashjGetNXUser]('-1','" + dRow["MS_N_XUONG"].ToString() + "')";
            }


            int iKieuBC;
            iKieuBC = 0;
            if (iKieuBC == 0)
            {

                sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " ( " + sSql + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  NXC,TXC ";
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");

                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");
                if (iLoai == 0)
                    sSql = " SELECT STT,A.NXC,A.TXC,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.NXC = B.NXC ORDER BY THOI_GIAN_SUA_CHUA  DESC";
                else
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ORDER BY THOI_GIAN_SUA_CHUA  DESC";

            }
            if (iKieuBC == 1)
            {

                sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " ( " + sSql + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  NXC,TXC ORDER BY THOI_GIAN_SUA_CHUA DESC";
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

            }
            if (iKieuBC == 2)
            {

                sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " ( " + sSql + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  NXC,TXC ORDER BY THOI_GIAN_SUA  DESC";
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");


            }
            if (iKieuBC == 3)
            {

                sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, COUNT(DISTINCT MS_LAN) AS SO_LAN " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " ( " + sSql + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  NXC,TXC  ORDER BY SO_LAN DESC";
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
            }
            if (iKieuBC == 4)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, NXC,TXC, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " ( " + sSql + " ) B ON A.MS_N_XUONG = B.MS_N_XUONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN INNER JOIN NHA_XUONG D ON A.MS_N_XUONG = D.MS_N_XUONG   " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  NXC,TXC ";
                if (iLoai == 1) sSql = sSql.Replace("NXC,TXC", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");

                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");

                if (iLoai == 0)
                    sSql = " SELECT STT,A.NXC,A.TXC,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.NXC = B.NXC ORDER BY MTTR  DESC";
                else
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ORDER BY MTTR  DESC";
            }

            
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucBieuDoTGNMayTheoNX");

        
        }

        private void TaoBCDayChuyen(string BTamChon, string BTamChonNN, int iLoai)
        {
            string sSql;
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;


            string sTmp;
            sSql = "";
            int iKieuBC;
            iKieuBC = 0;

            if (iKieuBC == 0)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA  " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG  ";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");
                

                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");
                if (iLoai == 0)
                {
                    sSql = " SELECT STT,A.MS_HE_THONG,A.TEN_HE_THONG,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_HE_THONG = B.MS_HE_THONG " +
                                " ORDER BY THOI_GIAN_SUA_CHUA DESC , THOI_GIAN_SUA DESC , SO_LAN DESC, MTTR DESC";
                }
                else
                {
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN " +
                                " ORDER BY THOI_GIAN_SUA_CHUA DESC , THOI_GIAN_SUA DESC , SO_LAN DESC, MTTR DESC";
                }
                

            }
            if (iKieuBC == 1)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ORDER BY THOI_GIAN_SUA_CHUA DESC";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

            }

            if (iKieuBC == 2)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ORDER BY THOI_GIAN_SUA DESC";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");

            }

            if (iKieuBC == 3)
            {

                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, COUNT(DISTINCT MS_LAN) AS SO_LAN " +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG ORDER BY SO_LAN DESC";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN");
                
            }
            if (iKieuBC == 4)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, A.MS_HE_THONG,TEN_HE_THONG, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                            " FROM THOI_GIAN_NGUNG_MAY A  INNER JOIN " +
                            " " + BTamChon + " B ON A.MS_HE_THONG = B.MS_HE_THONG INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  A.MS_HE_THONG,TEN_HE_THONG  ";
                if (iLoai == 1) sSql = sSql.Replace("A.MS_HE_THONG,TEN_HE_THONG", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");

                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");
                if (iLoai == 0)
                {
                    sSql = " SELECT STT,A.MS_HE_THONG,A.TEN_HE_THONG,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_HE_THONG = B.MS_HE_THONG ORDER BY MTTR DESC";
                }
                else
                {
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ORDER BY MTTR DESC";
                }
            }



            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucBieuDoTGNMayTheoNX");


        }

        private void TaoBCLoaiTB(string BTamChon, string BTamChonNN, int iLoai)
        {
            string sSql;
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            string sTmp;
            sSql = "";
            int iKieuBC;
            iKieuBC = 0;

            if (iKieuBC == 0)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA  " +
                            " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                            " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                            " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                            " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");

                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");
                if (iLoai == 0)
                    sSql = " SELECT STT,A.MS_LOAI_MAY,A.TEN_LOAI_MAY,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_LOAI_MAY = B.MS_LOAI_MAY ORDER BY THOI_GIAN_SUA_CHUA DESC";
                else
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA,SO_LAN," +
                                " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                                " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ORDER BY THOI_GIAN_SUA_CHUA DESC";
            }

            if (iKieuBC == 1)
            {
                
                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA " +
                            " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                            " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                            " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                            " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ORDER BY THOI_GIAN_SUA_CHUA DESC ";
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");
            }
            if (iKieuBC == 2)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA  " +
                        " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                        " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                        " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                        " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                        " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                        " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                        " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ORDER BY THOI_GIAN_SUA DESC ";
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");
            }
            if (iKieuBC == 3)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY,COUNT(DISTINCT MS_LAN) AS SO_LAN  " +
                        " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                        " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                        " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                        " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                        " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                        " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                        " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ORDER BY SO_LAN DESC ";
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");
            }

            if (iKieuBC == 4)
            {
                sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA" +
                            " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
                            " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
                            " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
                            " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
                            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
                            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
                            " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";
                if (iLoai == 1) sSql = sSql.Replace("B.MS_LOAI_MAY,TEN_LOAI_MAY", "A.MS_NGUYEN_NHAN,C.TEN_NGUYEN_NHAN");
                sTmp = sSql.Replace("SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA", "COUNT(DISTINCT MS_LAN) AS SO_LAN");
                sTmp = sTmp.Replace("CONVERT(INT,NULL) AS STT,", "");

                if (iLoai == 0)
                    sSql = " SELECT STT,A.MS_LOAI_MAY,A.TEN_LOAI_MAY,THOI_GIAN_SUA_CHUA,SO_LAN," +
                            " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                            " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_LOAI_MAY = B.MS_LOAI_MAY ORDER BY MTTR DESC";
                else
                    sSql = " SELECT STT,A.MS_NGUYEN_NHAN,A.TEN_NGUYEN_NHAN,THOI_GIAN_SUA_CHUA,SO_LAN," +
                            " CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR " +
                            " FROM (" + sSql + ") A LEFT JOIN (" + sTmp + ") B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN ORDER BY MTTR DESC";
            }
            //sSql = " SELECT CONVERT(INT,NULL) AS STT, B.MS_LOAI_MAY,TEN_LOAI_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA ,  " +
            //            " SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA  " +
            //            " FROM         dbo.THOI_GIAN_NGUNG_MAY AS A INNER JOIN " +
            //            " dbo.MAY AS X ON A.MS_MAY = X.MS_MAY INNER JOIN " +
            //            " dbo.NHOM_MAY AS Y ON X.MS_NHOM_MAY = Y.MS_NHOM_MAY INNER JOIN " +
            //            " " + BTamChon + " B ON Y.MS_LOAI_MAY = B.MS_LOAI_MAY INNER JOIN  " + BTamChonNN + " C " +
            //            " ON A.MS_NGUYEN_NHAN = C.MS_NGUYEN_NHAN " +
            //            " WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' " +
            //            " GROUP BY  B.MS_LOAI_MAY,TEN_LOAI_MAY  ";


            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucBieuDoTGNMayTheoNX");
        }

        private void InDuLieu(string sPath, int iLoai)
        {
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
                prbIN.Properties.Maximum = 15;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);

                
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);

                int SCot;

                SCot = TCot;// (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                if (iLoai == 0)
                {
                    if (optBCao.SelectedIndex == 0) stmp = "TieuDeNX";
                    if (optBCao.SelectedIndex == 1) stmp = "TieuDeDC";
                    if (optBCao.SelectedIndex == 2) stmp = "TieuDeLTB";
                }
                else stmp = "TieuDeNN";

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNX",stmp , Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);





                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                



                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong = Dong + 2;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = xlWSheet.get_Range(xlWSheet.Cells[Dong - 1, 1], xlWSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "#,##0", true, Dong + 1, 5, TDong + Dong, 5);

                SCot = 7;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                for (int i = 4; i <= grvChung.Columns.Count; i++)
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0", true, Dong + 1, i, TDong + Dong, i);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD, TCot + 2, DongBD, TCot + 2);
                string TDe;
                
                //LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200);


                //LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 4, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200);

                int iKieuBC;
                iKieuBC = 0;

                if (iKieuBC == 0)
                {
                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TDTGSC", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "D", TDe);

                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TGS", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 2, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "E", TDe);

                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "SLNM", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 3, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "F", TDe);

                    TDe = "MTTR";
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 4, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "G", TDe);
                }

                if (iKieuBC == 1)
                {
                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TDTGSC", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "D", TDe);
                }

                if (iKieuBC == 2)
                {
                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TGS", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "D", TDe);
                }

                if (iKieuBC == 3)
                {
                    TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "SLNM", Commons.Modules.TypeLanguage);
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "D", TDe);
                }


                if (iKieuBC == 4)
                {
                    TDe = "MTTR";
                    LoadBieuDo(xlWorkSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "F", TDe);
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
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoNX", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }


        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan, double iLeft,
            double iTop, double iWidth, double iHeight, string CotDL, string TDBCao)
        {
            try
            {

                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 2);
                double iLan = (iSoLan - 1) % 2;
                iLeft = iLeft + iLan * iWidth;
                iTop = iTop + iHeight * iTmp;

                if (iSoLan > 2) iTop = iTop + 9;
                if (iSoLan == 2 || iSoLan == 4) iLeft = iLeft + 9;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);


                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Series xlSeries = xlSeriesCollection.NewSeries();


                var _with1 = xlSeries;

                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;

                //_with1.Name = TDBCao;
                _with1.Values = ExcelSheets.get_Range(CotDL + "10", (iDong > 30 ? CotDL + "29" : CotDL + iDong.ToString()));
                _with1.XValues = ExcelSheets.get_Range("C10", (iDong > 30 ? "C29" : "C" + iDong.ToString()));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlChart.HasTitle = true;

                xlChart.ChartTitle.Text = TDBCao;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.Legend.Delete();
                xlChart.Refresh();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


            }
            catch
            { }

















            //try
            //{

            //    double iTmp = (iSoLan - 1);
            //    iTmp = Math.Floor(iTmp / 3);
            //    double iLan = (iSoLan - 1) % 3;
            //    iLeft = iLeft + iLan * iWidth;
            //    iTop = iTop + iHeight * iTmp;

            //    if (iSoLan == 4) iTop = iTop + 9;
            //    #region prb
            //    prbIN.PerformStep(); prbIN.Update();
            //    #endregion
            //    Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
            //    Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
            //    Excel.Chart xlChart = chartObj.Chart;
            //    Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);


            //    xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

            //    Excel.Series xlSeries = xlSeriesCollection.NewSeries();
            //    #region prb
            //    prbIN.PerformStep(); prbIN.Update();
            //    #endregion
            //    var _with1 = xlSeries;

            //    _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;

            //    if (iSoLan == 4)
            //    {
            //        _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TGSC", Commons.Modules.TypeLanguage);
            //        _with1.Values = ExcelSheets.get_Range("E10", (iDong > 60 ? "E59" : "E" + iDong.ToString())); //"B33");
            //        _with1.XValues = ExcelSheets.get_Range("C10", (iDong > 60 ? "C59" : "C" + iDong.ToString()));
            //    }
            //    else
            //    {
            //        _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TGNM", Commons.Modules.TypeLanguage);
            //        _with1.Values = ExcelSheets.get_Range("D10", (iDong > 60 ? "D59" : "D" + iDong.ToString())); //"B33");
            //        _with1.XValues = ExcelSheets.get_Range("C10", (iDong > 60 ? "C59" : "C" + iDong.ToString()));
            //    }
            //    xlChart.Refresh();

            //    #region prb
            //    prbIN.PerformStep();
            //    prbIN.Update();
            //    #endregion
            //    xlChart.HasTitle = true;
            //    if (iSoLan == 4)
            //        xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TDTGSC", Commons.Modules.TypeLanguage);
            //    else
            //        xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX", "TDTGNM", Commons.Modules.TypeLanguage);

            //    xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
            //    xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
            //    xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
            //    xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
            //    xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
            //    xlChart.Refresh();

            //}
            //catch
            //{ }
        }

        private void btnALLBC_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);
        }

        private void btnNotALLBC_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);
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
                if (txtTKiemBC.Text.Length != 0) dk = " OR  " +  sMa + " LIKE '%" + txtTKiemBC.Text + "%' " + dk;
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

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;


            string BTamChon, BTamChonNN;

            DataTable dtTmp = new DataTable();
            BTamChon = "ZZZ_BC_NX_CHON" + Commons.Modules.UserName;
            BTamChonNN = "ZZZ_NM_NX_CHON" + Commons.Modules.UserName;


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

            if (optBCao.SelectedIndex == 0) TaoBCNXuong(BTamChon, BTamChonNN, dtTmp,1);
            if (optBCao.SelectedIndex == 1) TaoBCDayChuyen(BTamChon, BTamChonNN,1);
            if (optBCao.SelectedIndex == 2) TaoBCLoaiTB(BTamChon, BTamChonNN,1);

            Commons.Modules.ObjSystems.XoaTable(BTamChon);
            Commons.Modules.ObjSystems.XoaTable(BTamChonNN);

            if (grvChung.RowCount == 0)
            {
                prbIN.Position = prbIN.Properties.Maximum;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoNX",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            InDuLieu(sPath,1);
        }

        private void grdNNNgungMay_Click(object sender, EventArgs e)
        {

        }
    }
}
