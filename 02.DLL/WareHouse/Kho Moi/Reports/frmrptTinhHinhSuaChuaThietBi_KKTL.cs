using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmrptTinhHinhSuaChuaThietBi_KKTL : UserControl
    {
        public frmrptTinhHinhSuaChuaThietBi_KKTL()
        {
            InitializeComponent();
        }

        private void frmTinhHinhSuaChuaThietBi_KKTL_Load(object sender, EventArgs e)
        {
            dtpThang.Value = DateTime.Now;
            DataTable _TbSource = new DataTable();
            Vietsoft.SqlInfo SqlDichVu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            _TbSource.Load(SqlDichVu.ExecuteReader(CommandType.StoredProcedure, "GetDON_VIs"));
            DataRow row = _TbSource.NewRow();
            row[0] = -1;
            row[1] = "All";
            row["THUE_NGOAI"] = false;
            row["MAC_DINH"] = false;
            _TbSource.Rows.InsertAt(row, 0);
            cboNhamay.DataSource = _TbSource;
            cboNhamay.DisplayMember = "TEN_DON_VI";
            cboNhamay.ValueMember = "MS_DON_VI";
       
        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);            
            frmReport frmRptPhieuNhap = new frmReport();
            frmRptPhieuNhap.rptName = "rptTinhHinhSuaChuaThietBi_KKTL";            

            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "GET_rptTINH_HINH_SUA_CHUA_THIET_BI", dtpThang.Value, cboNhamay.SelectedValue, 1));
            TbSource.TableName = "rptTinhHinhSuaChuaThietBi_KKTL";
            frmRptPhieuNhap.AddDataTableSource(TbSource);

            DataTable TbSource1 = new DataTable();
            TbSource1.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "GET_rptTINH_HINH_SUA_CHUA_THIET_BI", dtpThang.Value, cboNhamay.SelectedValue, 0));
            TbSource1.TableName = "rptTinhHinhSuaChuaThietBi_koThucHien_KKTL";
            frmRptPhieuNhap.AddDataTableSource(TbSource1);

            DataTable TbSource2 = new DataTable();
            TbSource2.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "GET_rptTINH_HINH_SUA_CHUA_THIET_BI_KQSC", dtpThang.Value, cboNhamay.SelectedValue));
            TbSource2.TableName = "rptTinhHinhSuaChuaThietBi_KQSC";
            frmRptPhieuNhap.AddDataTableSource(TbSource2);

            if (TbSource.Rows.Count <=0 && TbSource1.Rows.Count <=0)
            {
                Vietsoft.Information.MsgBox(this.ParentForm, "Khongcogiatridein", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("DON_VI");
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("MASO");
            TbTieuDe.Columns.Add("LAN_BAN_HANH");
            TbTieuDe.Columns.Add("NGAY_BAN_HANH");
            TbTieuDe.Columns.Add("THANG_NAM");
            TbTieuDe.Columns.Add("TT");
            TbTieuDe.Columns.Add("NHA_MAY_SO");
            TbTieuDe.Columns.Add("PHAN_CO");
            TbTieuDe.Columns.Add("PHAN_DIEN");
            TbTieuDe.Columns.Add("THEO_KE_HOACH");
            TbTieuDe.Columns.Add("THEO_BIEN_BAN_HONG_MAY");
            TbTieuDe.Columns.Add("TEN_TAI_SAN");
            TbTieuDe.Columns.Add("SO_KIEM_KE");
            TbTieuDe.Columns.Add("DANG_SUA");
            TbTieuDe.Columns.Add("CONG");
            TbTieuDe.Columns.Add("DU_KIEN");
            TbTieuDe.Columns.Add("THUC_TE");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("TON_TAI_CUA_THANG");
            TbTieuDe.Columns.Add("SO");
            TbTieuDe.Columns.Add("NGAY_THANG");
            TbTieuDe.Columns.Add("TONG");
            TbTieuDe.Columns.Add("LY_DO_KHONG_THUC_HIEN");
            TbTieuDe.Columns.Add("THIET_KE_CHE_TAO_VA_LAP_DAT");
            TbTieuDe.Columns.Add("DANH_GIA_KQ_SC");
            TbTieuDe.Columns.Add("KH_DA_THUC_HIEN");
            TbTieuDe.Columns.Add("HONG_DOT_XUAT");
            TbTieuDe.Columns.Add("MAY");
            TbTieuDe.Columns.Add("DAT");
            TbTieuDe.Columns.Add("TI_LE");
            TbTieuDe.Columns.Add("NGAY_THANG_IN");
            TbTieuDe.Columns.Add("TONG_HOP_BAO_CAO");
            TbTieuDe.Columns.Add("THOI_GIAN_LUU");
            TbTieuDe.Columns.Add("PHAN");
            TbTieuDe.Columns.Add("CONG1");
            TbTieuDe.Columns.Add("THIETBI_KHONGTHUCHIEN");

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "DON_VI", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["MASO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "MASO", Commons.Modules.TypeLanguage);
            rTitle["LAN_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "LAN_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["NGAY_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "NGAY_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THANG1", Commons.Modules.TypeLanguage) + ": " + dtpThang.Value.Month.ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "NAM1", Commons.Modules.TypeLanguage) + ": " + dtpThang.Value.Year.ToString();
            rTitle["TT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TT", Commons.Modules.TypeLanguage);
            rTitle["NHA_MAY_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "NHA_MAY_SO", Commons.Modules.TypeLanguage);
            rTitle["PHAN_CO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "PHAN_CO", Commons.Modules.TypeLanguage);
            rTitle["PHAN_DIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "PHAN_DIEN", Commons.Modules.TypeLanguage);
            rTitle["THEO_KE_HOACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THEO_KE_HOACH", Commons.Modules.TypeLanguage);
            rTitle["THEO_BIEN_BAN_HONG_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THEO_BIEN_BAN_HONG_MAY", Commons.Modules.TypeLanguage);
            rTitle["TEN_TAI_SAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TEN_TAI_SAN", Commons.Modules.TypeLanguage);
            rTitle["SO_KIEM_KE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "SO_KIEM_KE", Commons.Modules.TypeLanguage);
            rTitle["DANG_SUA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "DANG_SUA", Commons.Modules.TypeLanguage);
            rTitle["CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "CONG", Commons.Modules.TypeLanguage);
            rTitle["DU_KIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "DU_KIEN", Commons.Modules.TypeLanguage);
            rTitle["THUC_TE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THUC_TE", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "GHI_CHU", Commons.Modules.TypeLanguage);
            rTitle["TON_TAI_CUA_THANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TON_TAI_CUA_THANG", Commons.Modules.TypeLanguage);
            rTitle["SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "SO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "NGAY_THANG", Commons.Modules.TypeLanguage);
            rTitle["TONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TONG", Commons.Modules.TypeLanguage);
            rTitle["LY_DO_KHONG_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "LY_DO_KHONG_THUC_HIEN", Commons.Modules.TypeLanguage);
            rTitle["THIET_KE_CHE_TAO_VA_LAP_DAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THIET_KE_CHE_TAO_VA_LAP_DAT", Commons.Modules.TypeLanguage);
            rTitle["DANH_GIA_KQ_SC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "DANH_GIA_KQ_SC", Commons.Modules.TypeLanguage);
            rTitle["KH_DA_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "KH_DA_THUC_HIEN", Commons.Modules.TypeLanguage);
            rTitle["HONG_DOT_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "HONG_DOT_XUAT", Commons.Modules.TypeLanguage);
            rTitle["MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "MAY", Commons.Modules.TypeLanguage);
            rTitle["DAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "DAT", Commons.Modules.TypeLanguage);
            rTitle["TI_LE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TI_LE", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_IN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "NGAY", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day.ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungdacbiet_KKTL", "THANG", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month.ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungdacbiet_KKTL", "NAM", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year.ToString();
            rTitle["TONG_HOP_BAO_CAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "TONG_HOP_BAO_CAO", Commons.Modules.TypeLanguage);
            rTitle["THOI_GIAN_LUU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "THOI_GIAN_LUU", Commons.Modules.TypeLanguage);
            rTitle["PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "PHAN", Commons.Modules.TypeLanguage);
            rTitle["CONG1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "CONG1", Commons.Modules.TypeLanguage);
            rTitle["THIETBI_KHONGTHUCHIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTinhHinhSuaChuaThietBi_KKTL", "CAC_THIET_BI_KHONG_THUC_HIEN", Commons.Modules.TypeLanguage);
   
            TbTieuDe.TableName = "rptTieuDe_TinhHinhSuaChuaThietBi_KKTL";
            TbTieuDe.Rows.Add(rTitle);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

    }
}