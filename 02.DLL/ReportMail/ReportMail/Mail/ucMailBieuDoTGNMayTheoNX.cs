using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMail.Mail
{
    public partial class ucMailBieuDoTGNMayTheoNX : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailBieuDoTGNMayTheoNX";
        private string DK_BAOCAO;
        private Boolean KLoad;

        public ucMailBieuDoTGNMayTheoNX()
        {
            InitializeComponent();
        }
#region Control chuan form
        private void LockControl(Boolean Locked)
        {
            btnThem.Visible = Locked;
            btnSua.Visible = Locked;
            btnXoa.Visible = Locked;
            btnThoat.Visible = Locked;
            btnGhi.Visible = !Locked;
            btnKhong.Visible = !Locked;
            btnSchedules.Visible = !Locked;


            chkSau.Properties.ReadOnly = Locked;    //Enabled = !Locked;
            txtSNgay.Properties.ReadOnly = Locked;
            ucSentTo1.LockUnLock(!Locked);
            grdData.Enabled = Locked;

            optBCao.Properties.ReadOnly = Locked; //Enabled = !Locked;
            cboNXuong.Properties.ReadOnly = Locked; //Enabled = !Locked;
            optBCao.Properties.ReadOnly = Locked; //Enabled = !Locked;
            optLBCao.Properties.ReadOnly = Locked; //Enabled = !Locked;

            btnALL.Enabled = !Locked;
            btnALL1.Enabled = !Locked;
            btnNotALL.Enabled = !Locked;
            btnNotALL1.Enabled = !Locked;

            txtTKiemBC.Properties.ReadOnly = Locked;
            txtTKiemNNNM.Properties.ReadOnly = Locked;

            if (!Locked)
            {
                if (optBCao.SelectedIndex == 0)
                    cboNXuong.Properties.ReadOnly = false; //Enabled = true;
                else cboNXuong.Properties.ReadOnly = true; //Enabled = false;
            }
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;
                dtTmp.Columns["CHON"].ReadOnly = Locked;
            }
            catch { }
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdNNNgungMay.DataSource;
                dtTmp.Columns["CHON"].ReadOnly = Locked;
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            ucSentTo1.MSetNew();
            txtID.Text = "-1";
            clsSchedules.setNull();
            if (optBCao.SelectedIndex == 0) LoadLuoi(); else optBCao.SelectedIndex = 0;
            cboNXuong.EditValue = "-1";
            if (optLBCao.SelectedIndex == 0) LoadTTNMay(""); else optLBCao.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (grvData.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongCoGiaTriSua", Commons.Modules.TypeLanguage));
                return;
            }
            txtID.Text = grvData.GetFocusedDataRow()["ID"].ToString();
            LockControl(false);
            if (grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() == "")
            {
                clsSchedules.setNull();
                return;
            }
            else
                clsSchedules._ID_SCHEDULES = Convert.ToInt16(grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString());

            clsSchedules.GetGTClass(clsSchedules._ID_SCHEDULES);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "CoMuonXoa",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (!clsSchedules.XoaSchedules(int.Parse(grvData.GetFocusedDataRow()["ID"].ToString()),
                int.Parse((grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() == "" ? "-1" :
                grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString())), TenMBaoCao))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "XoaKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }
            clsSchedules.LoadDuLieu(int.Parse(grvData.GetFocusedDataRow()["ID"].ToString()), TenMBaoCao, grdData, grvData);


        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            #region "KiemGhi"
            if (!ucSentTo1.KiemDL(int.Parse(txtID.Text))) return;
            if (txtSNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "ChuaNhapSoNgay", Commons.Modules.TypeLanguage));
                txtSNgay.Focus();
                return;
            }

            if (int.Parse(txtSNgay.Text) > 365)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "LonHonMotNam", Commons.Modules.TypeLanguage));
                txtSNgay.Focus();
                return;
            }
            #endregion
            int ID, iTongChon;
            string sLuoiChon;
            sLuoiChon = "";
            iTongChon = 0;
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdBC.DataSource).Copy();
            iTongChon = dtTmp.Rows.Count;
            dtTmp.DefaultView.RowFilter = " CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            if (iTongChon != dtTmp.Rows.Count)
            {
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    sLuoiChon += dtTmp.Rows[i][1].ToString() + ",";

                }
                sLuoiChon = sLuoiChon.Substring(0, sLuoiChon.Length - 1) + "@";
            }
            else sLuoiChon = "ALL@";


            string sLChon = "";
            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            iTongChon = dtTmp.Rows.Count;
            dtTmp.DefaultView.RowFilter = " CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            if (iTongChon != dtTmp.Rows.Count)
            {
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    sLChon += dtTmp.Rows[i][1].ToString() + ",";
                }
                sLChon = sLChon.Substring(0, sLChon.Length - 1) + "@";
            }
            else sLChon = "ALL@";


            sLuoiChon = sLuoiChon + sLChon;

            DK_BAOCAO = "";
            if (optBCao.SelectedIndex == 0) DK_BAOCAO = "0,";
            if (optBCao.SelectedIndex == 1) DK_BAOCAO = "1,";
            if (optBCao.SelectedIndex == 2) DK_BAOCAO = "2,";

            if (optLBCao.SelectedIndex == 0) DK_BAOCAO += "0,";
            if (optLBCao.SelectedIndex == 1) DK_BAOCAO += "1,";
            if (optLBCao.SelectedIndex == 2) DK_BAOCAO += "2,";
            if (optLBCao.SelectedIndex == 3) DK_BAOCAO += "3,";
            if (optLBCao.SelectedIndex == 4) DK_BAOCAO += "4,";


            try
            {
                DK_BAOCAO = (chkSau.Checked ? "1," : "0,") + (txtSNgay.Text == "" ? "0" : txtSNgay.Text) + "," +
                    DK_BAOCAO  +
                    (cboNXuong.EditValue.ToString() == "" ? "" : cboNXuong.EditValue.ToString()) + ",";

            }
            catch { DK_BAOCAO = ""; }

            DK_BAOCAO = DK_BAOCAO + "@" + sLuoiChon;

            ID = Convert.ToInt32(txtID.Text);
            if (!clsSchedules.CapNhapSchedules(TenMBaoCao, ucSentTo1, DK_BAOCAO, ref ID))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }
            clsSchedules.LoadDuLieu(ID, TenMBaoCao, grdData, grvData);
            LockControl(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            LoadText();
            KLoad = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.ParentForm.Close();
        }

        private void LoadText()
        {
            KLoad = true;
            try
            {

                if (grvData.RowCount <= 0)
                {
                    ucSentTo1.MSetNew();
                    txtID.Text = "-1";
                }
                else
                {
                    ucSentTo1.MGetData(grvData);
                    txtID.Text = grvData.GetFocusedDataRow()["ID"].ToString();
                    if (grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() != "")
                    {
                        clsSchedules.GetGTClass(int.Parse(grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString()));
                        ucSentTo1.sSchedules = clsSchedules.DocDuLieu();
                    }
                    if (grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString() != "")
                    {
                        string sStmp, sBCao, sStm1;
                        sBCao = "";

                        sStmp = Convert.ToString(grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString());
                        string[] chuoi_tach = sStmp.Split(new Char[] { '@' });
                        int i = 0;

                        foreach (string s1 in chuoi_tach)
                        {
                            if (i == 0)
                            {
                                sBCao = s1;
                                string[] sChuoiBC = sBCao.Split(new Char[] { ',' });
                                if (sChuoiBC.GetValue(0).ToString().Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;

                                txtSNgay.Text = sChuoiBC.GetValue(1).ToString();

                                optBCao.SelectedIndex = int.Parse(sChuoiBC.GetValue(2).ToString());

                                optLBCao.SelectedIndex = int.Parse(sChuoiBC.GetValue(3).ToString());

                                cboNXuong.EditValue = sChuoiBC.GetValue(4).ToString();
                            }
                            if (i == 1)
                            {
                                DataTable dtTmp = new DataTable();
                                KLoad = false;
                                LoadLuoi();
                                sStm1 = s1;
                                if (sStm1 == "ALL")
                                {
                                    dtTmp = new DataTable();
                                    dtTmp = (DataTable)grdBC.DataSource;
                                    if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                                }
                                else
                                {
                                    dtTmp = ((DataTable)grdBC.DataSource).Copy();
                                    if (dtTmp.Columns[1].ColumnName != "MS_HE_THONG")
                                        sStm1 = "'" + sStm1.Replace(",", "','") + "'";


                                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                                        "AAA_MAIL_TMP_TGNM" + Commons.Modules.UserName, dtTmp, "");
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                                        "UPDATE AAA_MAIL_TMP_TGNM" + Commons.Modules.UserName + " SET CHON = 0 " +
                                        " WHERE " + dtTmp.Columns[1].ColumnName + " NOT IN (" + sStm1 + ") ");

                                    sStm1 = dtTmp.Columns[2].ColumnName;
                                    dtTmp = new DataTable();
                                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                        "SELECT * FROM AAA_MAIL_TMP_TGNM" + Commons.Modules.UserName + " ORDER BY " + sStm1));

                                    dtTmp.Columns["CHON"].ReadOnly = false;
                                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false);

                                    for (int j = 1; j < grvBC.Columns.Count; j++)
                                        dtTmp.Columns[j].ReadOnly = true;

                                    Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "ucBieuDoTGNMayTheoNX");
                                    grvBC.Columns["CHON"].Width = 100;
                                    grvBC.Columns[1].Width = 250;
                                    grvBC.Columns[2].Width = 350;
                                    if (optBCao.SelectedIndex == 1) grvBC.Columns["MSHT"].Visible = false;
                                    if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                                }
                            
                            }
                            if (i == 2)
                            {
                                KLoad = false;
                                if (s1 == "ALL")
                                    LoadTTNMay("");
                                else
                                    LoadTTNMay(s1);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                        cboNXuong.EditValue = "-1";
                        optLBCao.SelectedIndex = 0;
                        optBCao.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
                //TaoLuoi();
                KLoad = false;
            }
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedules frm = new frmSchedules();
            clsSchedules._Test = 1;
            try
            {
                frm.clsSchedules = clsSchedules;
            }
            catch { }
            DialogResult res = frm.ShowDialog();

            if (res.Equals(DialogResult.OK))
            {
                clsSchedules = frm.clsSchedules;
                ucSentTo1.sSchedules = clsSchedules.DocDuLieu();
            }
            else
            {
                clsSchedules._ID_SCHEDULES = Convert.ToInt16(clsSchedules._ID_SCHEDULES);
                return;
            }
        }
#endregion

        private void TaoCbo()
        {
            string sSql = "";
            sSql = "SELECT MS, TEN_N_XUONG , 1 AS STT  FROM NHA_XUONG A INNER JOIN " +
                        " (SELECT DISTINCT ISNULL(MS_CHA,'') AS MS FROM NHA_XUONG ) B  " +
                        " ON A.MS_N_XUONG = B.MS " +
                        " UNION SELECT '-1', N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "CapCha", Commons.Modules.TypeLanguage) + "' , 0 AS STT ORDER  BY STT,TEN_N_XUONG ";

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNXuong, sSql, "MS", "TEN_N_XUONG", lblNXuong.Text);

        }

        private void ucMailBieuDoTGNMayTheoNX_Load(object sender, EventArgs e)
        {
            KLoad = false;
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            LockControl(true);
            TaoCbo();
            LoadLuoi();
            LoadTTNMay("");
            
        }
        private void LoadLuoi()
        {
            if (KLoad) return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBCaoThoiGianNgungMay", cboNXuong.EditValue, optBCao.SelectedIndex,Commons.Modules.UserName,Commons.Modules.TypeLanguage ));
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
            if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;

        }

        private void LoadTTNMay(string DKien)
        {
            string sSql = "";
            if (DKien == "")
                sSql = "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                    " FROM dbo.NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN";
            else
            {
                sSql = "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                        " FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE MS_NGUYEN_NHAN IN(" + DKien + " ) UNION " +
                        "SELECT CONVERT(BIT,0) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                        " FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE MS_NGUYEN_NHAN NOT IN(" + DKien + " ) ORDER BY TEN_NGUYEN_NHAN ";
            }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,sSql));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNNNgungMay, grvNNNgungMay, dtTmp, true, false, true, true);


            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["HU_HONG"].ReadOnly = true;
            dtTmp.Columns["BTDK"].ReadOnly = true;
            grvNNNgungMay.Columns["MS_NN"].Visible = false;

            grvNNNgungMay.Columns["CHON"].Width = 76;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Width = 130;

            grvNNNgungMay.Columns["HU_HONG"].Width = 91;
            grvNNNgungMay.Columns["BTDK"].Width = 91;


            if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;


        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnGhi.Visible)
                if (optBCao.SelectedIndex == 0)
                    cboNXuong.Properties.ReadOnly = false; //Enabled = true;
                else cboNXuong.Properties.ReadOnly = true; //Enabled = false;
            LoadLuoi();
        }

        private void cboNXuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText();
            KLoad = false;
        }

        private void btnNotALLBC_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);

        }

        private void btnALLBC_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);

        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvBC);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvBC);

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

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
    }
}
