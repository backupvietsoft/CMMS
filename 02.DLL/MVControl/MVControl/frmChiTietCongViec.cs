using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmChiTietCongViec : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietCongViec()
        {
            InitializeComponent();
        }

        public int iSTTGS { get; set; }
        public int msthongso { get; set; }
        public string msmay { get; set; }
        public string msbp { get; set; }
        public int mstt { get; set; }
       

        public string sTenCV { get; set; }
        public string sThaoTac { get; set; }
        public string sTieuChuan { get; set; }
        public string sYeuCauNS { get; set; }
        public string sYeuCauDC { get; set; }
        public string sTaiLieu { get; set; }
        public Boolean bView { get; set; } = false;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            sThaoTac = txtThaoTac.Text;
            sTieuChuan = txtTieuChuan.Text;
            sYeuCauNS = txtYeuCauNS.Text;
            sYeuCauDC = txtYeuCauDC.Text;
            sTaiLieu = txtTaiLieu.Text;
            if (bView && iSTTGS !=-1)
            {
                //LƯU TRỰC TIẾP VÀO DỮ LIỆU
                try
                {
                    string sServer = Commons.Modules.ObjSystems.CapnhatTL(true, "GSTT_TSDT");
                    string sPathMoi;
                    if (sTaiLieu.ToString() != "")
                    {
                        sPathMoi = sServer + @"\" + "GSTT_TSDT" + "_" + msmay + "_" + msbp + "_" + msthongso + "_" + Commons.Modules.ObjSystems.LayDuoiFile(sTaiLieu);
                    }else { sPathMoi = ""; }
                    string sSql = "UPDATE dbo.GIAM_SAT_TINH_TRANG_TS SET CACH_THUC_HIEN =N'" + sThaoTac + "', TIEU_CHUAN_KT =N'" + sTieuChuan + "',YEU_CAU_NS =N'" + sYeuCauNS + "',YEU_CAU_DUNG_CU =N'" + sYeuCauDC + "', PATH_HD=N'" + sPathMoi + "'WHERE STT =" + iSTTGS + " AND MS_MAY = '" + msmay + "' AND MS_TS_GSTT = '" +msthongso + "' AND MS_BO_PHAN = '" +msbp + "' AND MS_TT = " + mstt + "";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                    Commons.Modules.ObjSystems.LuuDuongDan(sTaiLieu,sPathMoi);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            
            this.Close();
        }
        private void frmChiTietCongViec_Load(object sender, EventArgs e)
        {
            txtThaoTac.Text = sThaoTac;
            txtTieuChuan.Text = sTieuChuan;
            txtYeuCauNS.Text = sYeuCauNS;
            txtYeuCauDC.Text = sYeuCauDC;
            txtTaiLieu.Text = sTaiLieu;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblTenCV.Text = sTenCV;
            txtTaiLieu.Properties.ReadOnly = true;
        }
        private void txtTaiLieu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Multiselect = false;
                if (opendialog.ShowDialog() != DialogResult.OK) return;
                txtTaiLieu.Text = opendialog.FileName;
                //}
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtTaiLieu_DoubleClick(object sender, EventArgs e)
        {
            //mo file
            try
            {
                System.Diagnostics.Process.Start(txtTaiLieu.EditValue.ToString());
            }
            catch
            {
                //'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Commons.Modules.UserName,
                                    "MsgKiemtra9", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
}
