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
    public partial class ucMailBTDKCThucHien : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailBTDKCThucHien";
        private string DK_BAOCAO;

        public ucMailBTDKCThucHien()
        {
            InitializeComponent();
        }

        private void LoadCbo()
        {
            DataTable TbLPT = new DataTable();
            TbLPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_MAY", Commons.Modules.UserName,
                Commons.Modules.TypeLanguage, "-1", "-1", "-1", "-1", "-1", "-1"));

            DataTable data = new DataTable();
            DataView dv = TbLPT.DefaultView;
            TbLPT.Rows.Add(-1, " < ALL > ", " < ALL > ");
            dv.Sort = "MS_MAY ASC";
            TbLPT = new DataTable();
            TbLPT = dv.ToTable();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietBi, TbLPT, "MS_MAY", "TEN_MAY", lblThietBi.Text);

        }

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
            cboThietBi.Properties.ReadOnly = Locked;    //Enabled = !Locked;
            txtSNgay.Properties.ReadOnly = Locked;
            ucSentTo1.LockUnLock(!Locked);
            grdData.Enabled = Locked;
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

        private void btnGhi_Click(object sender, EventArgs e)
        {
            #region "KiemGhi"


            if (!ucSentTo1.KiemDL(int.Parse(txtID.Text))) return;
            int ID;
            #endregion
            DK_BAOCAO = "";
            try
            {
                DK_BAOCAO = (cboThietBi.EditValue.ToString() == "" ? "" : cboThietBi.EditValue.ToString()) +
                    (cboThietBi.EditValue.ToString() == "" ? "" : ", ") +
                    (chkSau.Checked ? "1, " : "0, ") +
                    (txtSNgay.Text == "" ? "0" : txtSNgay.Text);
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
                            if (i == 0) cboThietBi.EditValue = s;

                            if (i == 1)
                                if (s.Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;

                            if (i == 2) txtSNgay.Text = s;
                            i++;
                        }
                    }
                    else
                    {
                        cboThietBi.EditValue = -1;
                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                    }
                }
            }
            catch { }
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedules frm = new frmSchedules();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucMailBTDKCThucHien_Load(object sender, EventArgs e)
        {
            LoadCbo();
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            LockControl(true);            
        }

    }
}
