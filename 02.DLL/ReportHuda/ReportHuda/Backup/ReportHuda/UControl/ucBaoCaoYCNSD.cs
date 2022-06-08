using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.UControl
{
    public partial class ucBaoCaoYCNSD : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoYCNSD()
        {
            InitializeComponent();
        }

        private void ucBaoCaoYCNSD_Load(object sender, EventArgs e)
        {
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadTTrang();
        }

#region Load Du Lieu
     

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName,
                    "-1", "-1", "-1"));
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

        private void LoadTTrang()
        {
            try
            {
                string DaGQ = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoYCNSD", "DaGiaiQuet", Commons.Modules.TypeLanguage);
                string BoQua = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoYCNSD", "BoQua", Commons.Modules.TypeLanguage);
                string ChuaGQ = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoYCNSD", "ChuaGiaiQuyet", Commons.Modules.TypeLanguage);

                //" SELECT CONVERT(NVARCHAR(15),'-1') AS MS_CTH , '< ALL >' AS TEN UNION SELECT MS_TTRANG, CASE 0 WHEN 0 THEN TEN_TTRANG WHEN 1 THEN TEN_TTRANG_ANH ELSE TEN_TTRANG_HOA END AS TEN_TINH_TRANG FROM TINH_TRANG_YCSD ORDER BY TEN"


                //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTTrang, 
                //    " SELECT CONVERT(NVARCHAR(15),'-1') AS MS_CTH , '< ALL >' AS TEN " +
                //    " UNION SELECT '04' , N'" + DaGQ + "' " +
                //    " UNION SELECT '03' , N'" + BoQua + "'  " +
                //    " UNION SELECT '00' , N'" + ChuaGQ + "' ORDER BY TEN", "MS_CTH", "TEN",  lblTinh.Text);

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTTrang,
                  " SELECT CONVERT(NVARCHAR(15),'-1') AS MS_CTH , '< ALL >' AS TEN UNION SELECT MS_TTRANG, " +
                  " CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_TTRANG WHEN 1 THEN TEN_TTRANG_ANH ELSE TEN_TTRANG_HOA END AS TEN_TINH_TRANG FROM TINH_TRANG_YCSD ORDER BY TEN", "MS_CTH", "TEN", lblTTrang.Text);

            }
            catch { }
        }


        #endregion

        

        private void btnExecute_Click(object sender, EventArgs e)
        {
            frmBCYeuCauNSD frm = new frmBCYeuCauNSD();
            frm._Ngay = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
            frm._DDiem = lblDDiem.Text + " : " + cboDDiem.Text;
            frm._DChuyen = lblDChuyen.Text + " : " + cboDChuyen.Text;
            frm._TTrang = lblTTrang.Text + " : " + cboTTrang.Text;

            frm._dtTable = new DataTable();
            frm._dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBCNguoiSuDung" ,
                datTNgay.DateTime, datDNgay.DateTime, "-1" ,"-1" ,cboDDiem.EditValue ,
                cboDChuyen.EditValue, cboTTrang.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            frm.ShowDialog();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }




    }
}
