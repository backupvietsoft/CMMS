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
    public partial class ucMailBieuDoTGNMayTheoMayThang : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailBieuDoTGNMayTheoMayThang";
        private string DK_BAOCAO;

        public ucMailBieuDoTGNMayTheoMayThang()
        {
            InitializeComponent();
        }

        #region Load Du Lieu

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", "Administrator", "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_HE_THONG, TEN_HE_THONG FROM HE_THONG UNION SELECT -1,' < ALL > ' ORDER BY TEN_HE_THONG "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, _table, "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_MAY "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, _table, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadNhomMay()
        {
            try
            {
                string sql;
                sql = " SELECT MS_NHOM_MAY, TEN_NHOM_MAY FROM dbo.NHOM_MAY WHERE ( '-1' = '" + cboLMay.EditValue + "' " +
                            " OR MS_LOAI_MAY = '" + cboLMay.EditValue + "' ) UNION SELECT '-1',' < ALL > ' ORDER BY TEN_NHOM_MAY";

                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
            
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

        private void LoadMay()
        {

            if (Commons.Modules.SQLString == "0load") return;
            try
            {
            if (string.IsNullOrEmpty (cboNhomMay.EditValue.ToString())) return;
                DataTable dtTmp = new DataTable();
                DateTime DThang, TThang;
                TThang = Convert.ToDateTime("01/01/1900");
                DThang = Convert.ToDateTime("01/01/2900");
                DThang = DThang.AddMonths(1).AddDays(-1);

                string sDK;

                sDK = grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString();
                string[] chuoi_tach = sDK.Split(new Char[] { '@' });
                sDK = chuoi_tach.GetValue(1).ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayThoiGianNgungMay", TThang,
                            DThang, "-1", "-1", "-1",
                            cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue, Commons.Modules.UserName ));


                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                    "AAA_MAIL_TGNMMAYTHANG" + Commons.Modules.UserName, dtTmp, "");

                string sSql = "";
                
                if (sDK != "ALL")
                {
                    sDK = "'" + sDK.Replace(",", "','") + "'";
                    sSql = "UPDATE AAA_MAIL_TGNMMAYTHANG" + Commons.Modules.UserName + " SET CHON = 0  WHERE MS_MAY NOT IN (" + sDK + ") ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                }

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, 
                    "SELECT * FROM AAA_MAIL_TGNMMAYTHANG" + Commons.Modules.UserName + " ORDER BY MS_MAY"));
                for (int i = 0; i <= dtTmp.Columns.Count - 1; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                    //dtTmp.Columns["TEN_MAY"].ReadOnly = true;
                    //dtTmp.Columns["MODEL"].ReadOnly = true;
                }
                dtTmp.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, false, true, false);
                grvBC.Columns["MSNX"].Visible = false;
                grvBC.Columns["MS_HT"].Visible = false;
                grvBC.Columns["MS_LOAI_MAY"].Visible = false;
                if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                
            }
            catch
            { }
            Commons.Modules.ObjSystems.XoaTable("AAA_MAIL_TGNMMAYTHANG" + Commons.Modules.UserName);
        }

        #endregion

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
            btnALL.Enabled = !Locked;
            btnNotALL.Enabled = !Locked;

            btnALL1.Enabled = !Locked;
            btnNotALL1.Enabled = !Locked;

            chkSau.Properties.ReadOnly = Locked;
            txtSNgay.Properties.ReadOnly = Locked;
            ucSentTo1.LockUnLock(!Locked);
            grdData.Enabled = Locked;

            
            cboDChuyen.Properties.ReadOnly = Locked;
            cboDDiem.Properties.ReadOnly = Locked;
            cboLMay.Properties.ReadOnly = Locked;
            cboNhomMay.Properties.ReadOnly = Locked;
            optBCao.Properties.ReadOnly = Locked;

            txtTKiemNNNM.Properties.ReadOnly = Locked;
            txtTKiemMay.Properties.ReadOnly = Locked;

            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdNNNgungMay.DataSource;
                dtTmp.Columns["CHON"].ReadOnly = Locked;
            }
            catch { }

            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;
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
            chkSau.Checked = false;
            txtSNgay.Text = "1";
            optBCao.SelectedIndex = 0;
            cboDChuyen.EditValue = -1;
            cboLMay.EditValue = "-1";
            cboNhomMay.EditValue = "-1";
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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucBieuDoChiPhiTheoNX", "ChuaNhapNgay", Commons.Modules.TypeLanguage));
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
            DataTable dtTmp = new DataTable();

            #region DK May
            try
            {
                
                dtTmp = ((DataTable)grdBC.DataSource).Copy();
                iTongChon = dtTmp.Rows.Count;
                dtTmp.DefaultView.RowFilter = " CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaChonDuLieuMay", Commons.Modules.TypeLanguage));
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
            }
            catch { sLuoiChon = "ALL@"; }
            #endregion

            #region DK NNN May

            string sLChon = "";
            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            iTongChon = dtTmp.Rows.Count;
            dtTmp.DefaultView.RowFilter = " CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaChonDuLieuNNNMay", Commons.Modules.TypeLanguage));
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
            #endregion
            sLuoiChon = sLuoiChon + sLChon;

            DK_BAOCAO = "";
            if (optBCao.SelectedIndex == 0) DK_BAOCAO = "0,";
            if (optBCao.SelectedIndex == 1) DK_BAOCAO = "1,";
            if (optBCao.SelectedIndex == 2) DK_BAOCAO = "2,";
            if (optBCao.SelectedIndex == 3) DK_BAOCAO = "3,";
            try
            {
                DK_BAOCAO = (chkSau.Checked ? "1," : "0,") + (txtSNgay.Text == "" ? "0" : txtSNgay.Text) + "," +
                    (cboDDiem.EditValue.ToString() == "" ? "" : cboDDiem.EditValue.ToString()) + "," + DK_BAOCAO +
                    (cboDChuyen.EditValue.ToString() == "" ? "" : cboDChuyen.EditValue.ToString()) + "," +
                    (cboLMay.EditValue.ToString() == "" ? "" : cboLMay.EditValue.ToString()) + "," +
                    (cboNhomMay.EditValue.ToString() == "" ? "" : cboNhomMay.EditValue.ToString()) + ",";


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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText();

        }

        private void LoadText()
        {
            this.Cursor = Cursors.WaitCursor;
            Commons.Modules.SQLString = "0load";
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

                        foreach (string s in chuoi_tach)
                        {
                            if (i == 0)
                            {
                                sBCao = s;
                                string[] sChuoiBC = sBCao.Split(new Char[] { ',' });
                                
                                if (sChuoiBC.GetValue(0).ToString().Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;
                                txtSNgay.Text = sChuoiBC.GetValue(1).ToString();
                                cboDDiem.EditValue = sChuoiBC.GetValue(2).ToString();
                                optBCao.SelectedIndex = int.Parse(sChuoiBC.GetValue(3).ToString());
                                cboDChuyen.EditValue =  int.Parse(sChuoiBC.GetValue(4).ToString());
                                cboLMay.EditValue = sChuoiBC.GetValue(5).ToString();
                                cboNhomMay.EditValue = sChuoiBC.GetValue(6).ToString();


                            }
                            if (i == 2)
                            {
                                DataTable dtTmp = new DataTable();

                                
                                sStm1 = s;
                                if (sStm1 != ",ALL")
                                if (s == "ALL")
                                    LoadTTNMay("");
                                else
                                    LoadTTNMay(s);
                                break;

                            }
                            i++;
                        }
                    }
                    else
                    {
                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                        optBCao.SelectedIndex = 0;
                        cboDChuyen.EditValue = -1;
                        cboLMay.EditValue = "-1";
                        cboNhomMay.EditValue = "-1";
                        LoadTTNMay("");
                    }
                }
            }
            catch
            {
            }
            Commons.Modules.SQLString = "";
            LoadMay();
            this.Cursor = Cursors.Default;
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


        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);
        }
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

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

        private void ucMailBieuDoTGNMayTheoMayThang_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            LockControl(true);
            LoadTTNMay("");
            optBCao.SelectedIndex = 0;
            Commons.Modules.SQLString = "";
            LoadMay();
            
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void txtTKiemMay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdBC.DataSource;

            try
            {
                string dk = "";

                if (txtTKiemMay.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiemMay.Text + "%' " + dk;
                if (txtTKiemMay.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiemMay.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtMay.DefaultView.RowFilter = dk;

            }
            catch {
                if (dtMay != null)
                    dtMay.DefaultView.RowFilter = "";
            }
        }

        private void btnALL1_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvBC);
        }

        private void btnNotALL1_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvBC);
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

    }
}
