using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class frmDeNghiVatTuBHS : DevExpress.XtraEditors.XtraForm
    {
        public string sMsPBT = "";
        public DateTime dNgayBDKH = DateTime.Now.Date;

        public string sMsKho = "-1";
        public string sMsPhongBan = "-1";
        public string sTenPhongBan = "-1";
        public string sMsLyDoXuat = "-1";
        public string sNoiDung = "-1";

        String sPGViec = "";
        String sNgayBDKH = "";
        String sPhongBan = "";

        public frmDeNghiVatTuBHS()
        {
            InitializeComponent();
        }

        private void LoadKho()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoPQ", Commons.Modules.UserName, 0));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", "");

        }

        private void LoadPhongBan()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanPQ", Commons.Modules.UserName, 0,"-1"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, dtTmp, "MS_PB", "TEN_PB", "");
            
            try
            {
                string sSql = "SELECT A.MS_TO FROM dbo.USERS AS A WHERE USERNAME = '" + Commons.Modules.UserName + "' ";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (sSql != "SELECT A.MS_TO FROM dbo.USERS AS A WHERE USERNAME = '" + Commons.Modules.UserName + "' ")
                {
                    cboPBan.EditValue = int.Parse(sSql);
                }
            }
            catch { cboPBan.EditValue = dtTmp.Rows[0][0].ToString(); }

        }

        private void LoadLyDoXuat()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLyDoXuatKT",0));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLyDoXuat, dtTmp, "MS_LY_DO_XUAT_KT", "TEN_LY_DO_XUAT_KT", "");
        }

        private void LoadNoiDung()
        {
            //"Theo phiếu giao việc số : " +MS_PHIEU_BAO_TRI+ "ngày : " + Ngày BDKH + " cua phong ban : " + ten Phong ban
            if (cboPBan.Text == "")
                txtNDung.Text = sPGViec + " " + sMsPBT + " " + sNgayBDKH + " " + dNgayBDKH.Date.ToShortDateString();
            else
                txtNDung.Text = sPGViec + " " + sMsPBT + " " + sNgayBDKH + " " + dNgayBDKH.Date.ToShortDateString() + " " + sPhongBan + " " + cboPBan.Text;

        }

        private void frmDeNghiVatTuBHS_Load(object sender, EventArgs e)
        {
            sPGViec = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "PhieuGiaoViec", Commons.Modules.TypeLanguage);
            sNgayBDKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayBDKH", Commons.Modules.TypeLanguage);
            sPhongBan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CuaPhongBan", Commons.Modules.TypeLanguage);

            LoadKho();
            LoadPhongBan();
            LoadLyDoXuat();
            LoadNoiDung();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void cboPBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadNoiDung();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboKho.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaChonKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return;

            }
            if (cboPBan.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaChonPhongBan", Commons.Modules.TypeLanguage));
                cboPBan.Focus();
                return;

            }
            if (cboLyDoXuat.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaLyDoXuat", Commons.Modules.TypeLanguage));
                cboLyDoXuat.Focus();
                return;

            }
#region "Get Mskho INTEGRATION"
            try
            {
                string sSql = "SELECT ISNULL(MS_KHO_INT,'') FROM IC_KHO WHERE MS_KHO = " + cboKho.EditValue.ToString();
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (sSql != "SELECT ISNULL(MS_KHO_INT,'') FROM IC_KHO WHERE MS_KHO = " + cboKho.EditValue.ToString())
                {
                    sMsKho = sSql;
                }
            }
            catch { }
#endregion

#region "Get Ms va Ten Phong Ban INTEGRATION"
            try
            {
                sTenPhongBan = cboPBan.Text;
                string sSql = "SELECT ISNULL(MS_TO_INT,'') FROM TO_PHONG_BAN WHERE MS_TO = " + cboPBan.EditValue.ToString();
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (sSql != "SELECT ISNULL(MS_TO_INT,'') FROM TO_PHONG_BAN WHERE MS_TO = " + cboPBan.EditValue.ToString())
                {
                    sMsPhongBan = sSql;
                }
            }
            catch { }
#endregion
            
            sMsLyDoXuat = cboLyDoXuat.EditValue.ToString();
            sNoiDung = txtNDung.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}