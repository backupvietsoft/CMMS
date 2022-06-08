using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.Utils;

namespace ReportHuda
{
    public partial class frmTaoKHTT : DevExpress.XtraEditors.XtraForm
    {
        public int iHangMuc;
        public string sMsMay;
        public string sNhanVienThucHien;
        public string sNVien = "-1";
        public frmTaoKHTT()
        {
            InitializeComponent();
        }

        private void frmTaoKHTT_Load(object sender, EventArgs e)
        {
            TaoCmb();
            dtTNgay.DateTime = DateTime.Now;
            dtDNgay.DateTime = dtTNgay.DateTime;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if (sNVien == "-1") cboNTHien.EditValue = ""; else cboNTHien.EditValue = sNVien;
            try
            {
                cboMUTien.EditValue = 2;            
                string str = "SELECT ISNULL(MUC_UU_TIEN, 0) AS MUC_UU_TIEN FROM THONG_TIN_CHUNG";
                btnMucUuTienFlag = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str));     
            }
            catch
            { }

            if (btnMucUuTienFlag == false)
                btnMucUuTien.Visible = false;
            else
                btnMucUuTien.Visible = true;
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Contents.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "MucUuTienHint", Commons.Modules.TypeLanguage);
            sTooltip.Setup(args);

            btnMucUuTien.SuperTip = sTooltip;

        }
        private bool btnMucUuTienFlag = false;
        private void TaoCmb()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_MAY_KHTT", Commons.Modules.UserName, Commons.Modules.TypeLanguage, "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, dtTmp, "MS_MAY", "MS_MAY", "");
                cboMay.Properties.Columns["CHON"].Visible = false;
                cboMay.Properties.Columns["MODEL"].Visible = false;
                cboMay.Properties.Columns["TEN_NHOM_MAY"].Visible = false;
                cboMay.Properties.Columns["TEN_LOAI_MAY"].Visible = false;
                cboMay.Properties.Columns["TEN_HE_THONG"].Visible = false;
                cboMay.Properties.Columns["Ten_N_XUONG"].Visible = false;
                cboMay.EditValue = sMsMay;
            }
            catch { }

            try
            {
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMUTien, dtTmp, "MS_UU_TIEN", "TEN_UU_TIEN", "");

            }
            catch
            { }
            try
            {
                DataTable dtTmp1 = new DataTable();
                dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers ", 2, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNTHien, dtTmp1, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblNTHien.Text);

            }
            catch
            { }
            //            _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", Commons.Modules.TypeLanguage))
            //repositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            //repositoryItemLookUpEdit2.NullText = ""
            //repositoryItemLookUpEdit2.ValueMember = "MS_LY_DO"
            //repositoryItemLookUpEdit2.DisplayMember = "TEN_LY_DO"
            try
            {
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLDSChua, dtTmp, "MS_LY_DO", "TEN_LY_DO", "");
            }
            catch
            { }
        }

        private void cboMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
                DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
                txtTMay.Text = Convert.ToString(row["TEN_MAY"]);
            }
            catch { txtTMay.Text = ""; }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonMay",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMay.Focus();
                return;
            }
            if (txtTHangMuc.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapHangMuc",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTHangMuc.Focus();
                return;
            }
            if (dtDNgay.DateTime < dtTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTuNgayLonHonDenNgay",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDNgay.Focus();
                return;
            }
            if (cboLDSChua.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapLyDoSuaChua",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLDSChua.Focus();
                return;
            }
            if (cboMUTien.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonMucUuTien",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMUTien.Focus();
                return;
            }
            if (cboNTHien.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNguoiThucHien",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboNTHien.Focus();
                return;
            }

            string Hmuc;

            string sSql = "select ISNULL(MAX(HANG_MUC_ID),0) + 1 FROM KE_HOACH_TONG_THE";
            Hmuc = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {


                sSql = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_INSERT_KE_HOACH_TONG_THE", cboMay.EditValue.ToString(), int.Parse(Hmuc), dtTNgay.DateTime.Date, dtDNgay.DateTime.Date,
                    txtTHangMuc.Text, txtGChu.Text, int.Parse(cboLDSChua.EditValue.ToString()), Commons.Modules.UserName, int.Parse(cboMUTien.EditValue.ToString()), cboNTHien.EditValue.ToString());
                //SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_INSERT_KE_HOACH_TONG_THE", ms_may, _hang_muc_id, ngay, ngay_bd_kh, ten_hang_muc, ghi_chu, ly_do_sc, 
                //    Commons.Modules.UserName, MucUTien, CNhan);

                sSql = "SET IDENTITY_INSERT KE_HOACH_TONG_THE OFF";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgThucHienKhongThanhCong",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgThucHienThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            iHangMuc = int.Parse(Hmuc);
            sNhanVienThucHien = cboNTHien.EditValue.ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            iHangMuc = -1;
            this.Close();
        }

        private void btnMucUuTien_Click(object sender, EventArgs e)
        {
            try
            {
                string Str = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " + cboMUTien.EditValue;
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str));

                dtTNgay.EditValue = DateTime.Now.AddDays(Convert.ToInt32(dt.Rows[0]["SO_NGAY_PHAI_BD"]));
                dtDNgay.EditValue = DateTime.Now.AddDays(Convert.ToInt32(dt.Rows[0]["SO_NGAY_PHAI_KT"]));
            }
            catch
            {
                dtTNgay.EditValue = DateTime.Now;
                dtDNgay.EditValue = DateTime.Now;
            }
        }
    }
}