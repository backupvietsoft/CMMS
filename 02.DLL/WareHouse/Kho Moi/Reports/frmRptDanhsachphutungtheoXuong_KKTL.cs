using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmRptDanhsachphutungtheoXuong_KKTL : UserControl
    {
        public frmRptDanhsachphutungtheoXuong_KKTL()
        {
            InitializeComponent();
        }

        private void frmRptDanhsachphutungtheoXuong_KKTL_Load(object sender, EventArgs e)
        {
            LoadNhaxuong();
            dtpNgay.Value = DateTime.Now;
        }

        private void LoadNhaxuong()
        {
            Vietsoft.SqlInfo SqlNX = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbNX = new DataTable();
            TbNX.Load(SqlNX.ExecuteReader(CommandType.StoredProcedure, "GetNHA_XUONGs1", Commons.Modules.UserName));
            if (TbNX.Rows.Count > 0)
            {
                cbNhaxuong.DataSource = TbNX;
                cbNhaxuong.ValueMember = "MS_N_XUONG";
                cbNhaxuong.DisplayMember = "TEN_N_XUONG";
            }
        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "GET_RPT_DANHMUCTHIETBI_KKTL", dtpNgay.Value, cbNhaxuong.SelectedValue.ToString()));
            TbSource.TableName = "rptDanhsachphutungtheoXuong_KKTL";
            if (TbSource.Rows.Count <= 0)
            {
                Vietsoft.Information.MsgBox(this.ParentForm, "khongcodulieuin", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            frmReport frmRptPhieuNhap = new frmReport();
            //frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVMPACKNew";
            frmRptPhieuNhap.rptName = "rptDanhsachphutungtheoXuong_KKTL";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("DON_VI");
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("MASO");
            TbTieuDe.Columns.Add("LAN_BAN_HANH");
            TbTieuDe.Columns.Add("NGAY_BAN_HANH");
            TbTieuDe.Columns.Add("PHAN_XUONG");
            TbTieuDe.Columns.Add("TT");
            TbTieuDe.Columns.Add("TEN_THIET_BI");
            TbTieuDe.Columns.Add("SO_KIEM_KE");
            TbTieuDe.Columns.Add("NAM_SU_DUNG");
            TbTieuDe.Columns.Add("NUOC_SX");
            TbTieuDe.Columns.Add("CONG_SUAT");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("PHONG");
            TbTieuDe.Columns.Add("NGAY_THANG_NAM");
            TbTieuDe.Columns.Add("GIAM_DOC_NHA_MAY");
            TbTieuDe.Columns.Add("THOI_GIAN_LUU");
           

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "DON_VI", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["MASO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "MASO", Commons.Modules.TypeLanguage);
            rTitle["LAN_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "LAN_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["NGAY_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "NGAY_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["PHAN_XUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "PHAN_XUONG", Commons.Modules.TypeLanguage);
            rTitle["TT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "TT", Commons.Modules.TypeLanguage);
            rTitle["TEN_THIET_BI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "TEN_THIET_BI", Commons.Modules.TypeLanguage);
            rTitle["SO_KIEM_KE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "SO_KIEM_KE", Commons.Modules.TypeLanguage);
            rTitle["NAM_SU_DUNG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "NAM_SU_DUNG", Commons.Modules.TypeLanguage);
            rTitle["NUOC_SX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "NUOC_SX", Commons.Modules.TypeLanguage);
            rTitle["CONG_SUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "CONG_SUAT", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "GHI_CHU", Commons.Modules.TypeLanguage);
            rTitle["PHONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "PHONG", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "NGAY", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day.ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "THANG", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month.ToString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "NAM", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year.ToString();
            rTitle["GIAM_DOC_NHA_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "GIAM_DOC_NHA_MAY", Commons.Modules.TypeLanguage);
            rTitle["THOI_GIAN_LUU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachphutungtheoXuong_KKTL", "THOI_GIAN_LUU", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "rptTieuDe_DanhsachphutungtheoXuong_KKTL";
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