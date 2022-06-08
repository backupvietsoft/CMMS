using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace ReportMail.UControl
{
    public partial class ucVTPTSLTonNhohonTTT : DevExpress.XtraEditors.XtraUserControl
    {

        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucVTPTSLTonNhohonTTT";

        private string DK_BAOCAO;

        public ucVTPTSLTonNhohonTTT()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucVTPTSLTonNhohonTTT_Load(object sender, EventArgs e)
        {
            
            LoadCbo();
            LoadData(-1);
            LockControl(true);
        }

        private void LoadCbo()
        {
            DataTable TbLPT = new DataTable();
            TbLPT.Columns.Add("VALUE", typeof(int));
            TbLPT.Columns.Add("DISLAY");
            TbLPT.Rows.Add(-1, " < ALL > ");
            switch (Commons.Modules.TypeLanguage)
            {
                case 1:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                case 2:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                default:
                    TbLPT.Rows.Add(1, "Vật tư");
                    TbLPT.Rows.Add(0, "Phụ tùng");
                    break;
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVTPT, TbLPT, "VALUE", "DISLAY", lblLVTPT.Text);

            try
            {
                DataTable dtKho = new DataTable();

                dtKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHOs"));
                dtKho.Rows.Add(-1, " < ALL > ");
                dtKho.Rows.Add(0, " < Khong Kho > ");
                dtKho.DefaultView.Sort = "TEN_KHO ASC";
                dtKho = dtKho.DefaultView.ToTable();

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtKho, "MS_KHO", "TEN_KHO", lblKho.Text);

            }
            catch { }



        }

        private void LoadData(int MSo)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDSMail", TenMBaoCao));
            dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID"] };

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, false, true, false);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvData, TenMBaoCao);

            grvData.Columns["ID"].Visible = false;
            grvData.Columns["ID_SCHEDULES"].Visible = false;
            grvData.Columns["ID_MAIL"].Visible = false;
            grvData.Columns["DK_BAOCAO"].Visible = false;
            grvData.Columns["NGON_NGU"].Visible = false;

            if (MSo != -1)
            {
                int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(MSo));
                grvData.FocusedRowHandle = grvData.GetRowHandle(index);
            }
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

            cboKho.Properties.ReadOnly = Locked;    //Enabled = !Locked;
            cboLVTPT.Properties.ReadOnly = Locked;    //Enabled = !Locked;
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
                DK_BAOCAO = (cboLVTPT.EditValue.ToString() == "" ? "" : cboLVTPT.EditValue.ToString()) +
                    (cboLVTPT.EditValue.ToString() == "" ? "" : ", ") +
                    (cboKho.EditValue.ToString() == "" ? "" : cboKho.EditValue.ToString());
            }
            catch { DK_BAOCAO = ""; }
            ID = Convert.ToInt32(txtID.Text);
            if (!clsSchedules.CapNhapSchedules(TenMBaoCao, ucSentTo1, DK_BAOCAO, ref ID))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }


            LoadData(ID);
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
                            if (i == 0) cboLVTPT.EditValue = int.Parse(s);
                            if (i == 1) cboKho.EditValue = int.Parse(s);
                            i++;
                        }
                    }
                    else
                    {
                        cboLVTPT.EditValue = -1;
                        cboKho.EditValue = -1;
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
            LoadData(int.Parse(grvData.GetFocusedDataRow()["ID"].ToString()));


        }

    }
}
