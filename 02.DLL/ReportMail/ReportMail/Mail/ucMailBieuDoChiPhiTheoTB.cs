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
    public partial class ucMailBieuDoChiPhiTheoTB : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailBieuDoChiPhiTheoTB";
        private string DK_BAOCAO;

        public ucMailBieuDoChiPhiTheoTB()
        {
            InitializeComponent();
        }


#region Load Du Lieu

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", "Administrator","-1", "-1", "-1"));
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
#endregion

#region Change du lieu
        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) // at least one time
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

#endregion

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

        private void ucMailBieuDoChiPhiTheoTB_Load(object sender, EventArgs e)
        {
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            LockControl(true);
            chkLChiPhi.SelectedIndex = 0;
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

            cboDChuyen.Properties.ReadOnly = Locked;
            cboDDiem.Properties.ReadOnly = Locked;
            cboLMay.Properties.ReadOnly = Locked;
            cboNhomMay.Properties.ReadOnly = Locked;
            
            chkLChiPhi.Enabled = !Locked; 

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            ucSentTo1.MSetNew();
            txtID.Text = "-1";
            clsSchedules.setNull();
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

            int ID;

            DK_BAOCAO = "";
            try
            {
                DK_BAOCAO = (chkSau.Checked ? "1," : "0,") + (txtSNgay.Text == "" ? "0" : txtSNgay.Text) + "," +
                    (cboDDiem.EditValue.ToString() == "" ? "" : cboDDiem.EditValue.ToString()) + "," +
                    (chkLChiPhi.GetItemChecked(0) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(1) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(2) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(3) ? "1," : "0,") +
                    (chkLChiPhi.GetItemChecked(4) ? "1," : "0,") +
                    (cboDChuyen.EditValue.ToString() == "" ? "" : cboDChuyen.EditValue.ToString()) + "," +
                    (cboLMay.EditValue.ToString() == "" ? "" : cboLMay.EditValue.ToString()) + "," +
                    (cboNhomMay.EditValue.ToString() == "" ? "" : cboNhomMay.EditValue.ToString()) + ",";


            }
            catch { DK_BAOCAO = ""; }
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
                        string sStmp;
                        sStmp = Convert.ToString(grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString());
                        string[] chuoi_tach = sStmp.Split(new Char[] { ',' });
                        int i = 0;

                        foreach (string s in chuoi_tach)
                        {

                            if (i == 0) if (s.Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;

                            if (i == 1) txtSNgay.Text = s;

                            if (i == 2) cboDDiem.EditValue = s;

                            if (i == 3)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(0, false); else chkLChiPhi.SetItemChecked(0, true);
                            if (i == 4)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(1, false); else chkLChiPhi.SetItemChecked(1, true);
                            if (i == 5)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(2, false); else chkLChiPhi.SetItemChecked(2, true);
                            if (i == 6)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(3, false); else chkLChiPhi.SetItemChecked(3, true);
                            if (i == 7)
                                if (s.Trim() == "0") chkLChiPhi.SetItemChecked(4, false); else chkLChiPhi.SetItemChecked(4, true);

                            if (i == 8) cboDChuyen.EditValue = int.Parse (s);
                            if (i == 9) cboLMay.EditValue = s;
                            if (i == 10) cboNhomMay.EditValue = s;
                            i++;
                        }
                    }
                    else
                    {
                        chkLChiPhi.SetItemChecked(0, true);
                        chkLChiPhi.SetItemChecked(1, true);
                        chkLChiPhi.SetItemChecked(2, true);
                        chkLChiPhi.SetItemChecked(3, true);
                        chkLChiPhi.SetItemChecked(4, true);

                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                        cboDDiem.EditValue = "-1";

                        cboDChuyen.EditValue = -1;
                        cboLMay.EditValue = "-1";
                        cboNhomMay.EditValue = "-1";

                    }
                }
            }
            catch { }
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
