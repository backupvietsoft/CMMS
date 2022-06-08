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
    public partial class ucMailBieuDoChiPhiTheoNX : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailBieuDoChiPhiTheoNX";
        private string DK_BAOCAO;
        private Boolean KLoad;


        public ucMailBieuDoChiPhiTheoNX()
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
            btnAll.Enabled = !Locked;
            btnNoAll.Enabled = !Locked;

            chkSau.Properties.ReadOnly = Locked;
            txtSNgay.Properties.ReadOnly = Locked;
            ucSentTo1.LockUnLock(!Locked);
            grdData.Enabled = Locked;
            optBCao.Properties.ReadOnly = Locked;
            cboNXuong.Properties.ReadOnly = Locked;
            chkLChiPhi.Enabled = !Locked;

            

            if (!Locked)
            {
                if (optBCao.SelectedIndex == 0)
                    cboNXuong.Properties.ReadOnly = false;  //Enabled = true;
                else cboNXuong.Properties.ReadOnly = true; //Enabled = false;
            }
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
            optBCao.SelectedIndex = 0;
            cboNXuong.EditValue = "-1";
            txtSNgay.Text = "1";
            chkLChiPhi.SetItemChecked(0, true);
            chkLChiPhi.SetItemChecked(1, true);
            chkLChiPhi.SetItemChecked(2, true);
            chkLChiPhi.SetItemChecked(3, true);
            chkLChiPhi.SetItemChecked(4, true);
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
                for (int i = 0; i <= dtTmp.Rows.Count -1 ; i++)
                {
                    sLuoiChon += dtTmp.Rows[i][1].ToString() + ",";

                }
            }
            else sLuoiChon = "ALL";

            DK_BAOCAO = "";
            if (optBCao.SelectedIndex == 0) DK_BAOCAO = "0";
            if (optBCao.SelectedIndex == 1) DK_BAOCAO = "1";
            if (optBCao.SelectedIndex == 2) DK_BAOCAO = "2";
            if (optBCao.SelectedIndex == 3) DK_BAOCAO = "3";
            

            try
            {
                DK_BAOCAO = (chkSau.Checked ? "1," : "0,") + (txtSNgay.Text == "" ? "0" : txtSNgay.Text) + "," +
                    DK_BAOCAO + "," +
                    (cboNXuong.EditValue.ToString() == "" ? "" : cboNXuong.EditValue.ToString()) + "," +
                    (chkLChiPhi.GetItemChecked(0) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(1) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(2) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(3) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(4) ? "1," : "0,");

            }
            catch { DK_BAOCAO = ""; }
            DK_BAOCAO = DK_BAOCAO + sLuoiChon ;

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
                        string[] chuoi_tach = sStmp.Split(new Char[] { ',' });
                        int i = 0;

                        foreach (string s in chuoi_tach)
                        {

                            if (i == 0) if (s.Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;

                            if (i == 1) txtSNgay.Text = s;

                            if (i == 2)
                            {
                                if (s == "0") optBCao.SelectedIndex = 0;
                                if (s == "1") optBCao.SelectedIndex = 1 ;
                                if (s == "2") optBCao.SelectedIndex = 2 ;
                                if (s == "3") optBCao.SelectedIndex = 3 ;
                            }

                            if (i == 3) cboNXuong.EditValue = s;

                            if (i == 4)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(0, false); else chkLChiPhi.SetItemChecked(0, true);
                            if (i == 5)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(1, false); else chkLChiPhi.SetItemChecked(1, true);
                            if (i == 6)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(2, false); else chkLChiPhi.SetItemChecked(2, true);
                            if (i == 7)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(3, false); else chkLChiPhi.SetItemChecked(3, true);
                            if (i == 8)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(4, false); else chkLChiPhi.SetItemChecked(4, true);

                            if (i == 9)
                            {
                                DataTable dtTmp = new DataTable();
                                KLoad = false;
                                TaoLuoi();
                                sStm1 = sBCao.Substring(1, sBCao.Length - 1);
                                sStm1 = sStmp.Replace(sStm1, "");
                                if (sStm1 == ",ALL") 
                                {
                                    dtTmp = new DataTable();
                                    dtTmp = (DataTable)grdBC.DataSource;
                                    if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                                    break;
                                }
                                sStm1 = sStm1.Substring(1, sStm1.Length - 2);
                                
                                dtTmp = ((DataTable)grdBC.DataSource).Copy();
                                if (dtTmp.Columns[1].ColumnName == "MS_LOAI_MAY")
                                    sStm1 = "'" + sStm1.Replace(",", "','") + "'";

                                
                                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, 
                                    "AAA_MAIL_TMP" + Commons.Modules.UserName , dtTmp, "");
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,CommandType.Text ,
                                    "UPDATE AAA_MAIL_TMP" + Commons.Modules.UserName + " SET CHON = 0 " +
                                    " WHERE " + dtTmp.Columns[1].ColumnName + " NOT IN (" + sStm1 + ") ");

                                sStm1 = dtTmp.Columns[2].ColumnName;
                                dtTmp = new DataTable();
                                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                    "SELECT * FROM AAA_MAIL_TMP" + Commons.Modules.UserName + " ORDER BY " + sStm1));

                                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false);
                                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBC, "ucBieuDoChiPhiTheoNX");
                                for (int j = 1; j < grvBC.Columns.Count; j++)
                                {
                                    dtTmp.Columns[j].ReadOnly = true;
                                }
                                if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                                grvBC.Columns["CHON"].Width = 90;
                                grvBC.Columns[1].Width = 250;

                                break;

                            }
                            sBCao = sBCao + "," + s;
                            i++;
                        }
                    }
                    else
                    {
                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                        cboNXuong.EditValue = "-1";
                        chkLChiPhi.SetItemChecked(0, true);
                        chkLChiPhi.SetItemChecked(1, true);
                        chkLChiPhi.SetItemChecked(2, true);
                        chkLChiPhi.SetItemChecked(3, true);
                        chkLChiPhi.SetItemChecked(4, true);
                        optBCao.SelectedIndex = 0;
                    }
                }
            }
            catch {
                TaoLuoi();
                KLoad = false;
            }

            Commons.Modules.ObjSystems.XoaTable("AAA_MAIL_TMP" + Commons.Modules.UserName);
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
            sSql = "SELECT MS, TEN_N_XUONG  FROM NHA_XUONG A INNER JOIN " +
                        " (SELECT DISTINCT ISNULL(MS_CHA,'') AS MS FROM NHA_XUONG ) B  " +
                        " ON A.MS_N_XUONG = B.MS " +
                        " UNION SELECT '-1', N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "CapCha", Commons.Modules.TypeLanguage) + "' ORDER BY TEN_N_XUONG ";


            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNXuong, sSql, "MS", "TEN_N_XUONG", lblNXuong.Text);

        }


        private void ucMailBieuDoChiPhiTheoNX_Load(object sender, EventArgs e)
        {
            KLoad = false;
            TaoCbo();
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            LockControl(true);

            chkLChiPhi.SelectedIndex = 0;
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (btnGhi.Visible)
                if (optBCao.SelectedIndex == 0)
                    cboNXuong.Properties.ReadOnly = false;
                else cboNXuong.Properties.ReadOnly = true;// Enabled = false;
            TaoLuoi();

        }

        private void cboNXuong_EditValueChanged(object sender, EventArgs e)
        {
            TaoLuoi();
        }

        private void TaoLuoi()
        {
            if (KLoad) return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuongTheoNXCha", cboNXuong.EditValue, optBCao.SelectedIndex));
            //if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else 
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

        private void grvData_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText();
            KLoad = false;

        }


    }
}
