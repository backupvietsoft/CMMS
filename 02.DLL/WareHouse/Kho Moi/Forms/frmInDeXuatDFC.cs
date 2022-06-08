using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace WareHouse
{
    public partial class frmInDeXuatDFC : Form
    {
        public string sMsDXuat = string.Empty;
        private string sMSDX
        {
            get
            {
                return sMsDXuat;
            }
        }

        public string sNguoiDXuat = string.Empty;
        private string sNDXuat
        {
            get
            {
                return sNguoiDXuat;
            }
        }

        public DateTime dNgayDXuat =  Commons.Modules.ObjSystems.GetNgayHeThong(); 
        private DateTime dNDXuat
        {
            get
            {
                return dNgayDXuat;
            }
        }

        public frmInDeXuatDFC()
        {
            InitializeComponent();
        }

        private void frmInDeXuatDFC_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            LayDuLieu();
        }
        private void LayDuLieu()
        {
            string sSql = "";
            sSql = " SELECT ISNULL([TD_DN_1],'') AS [TD_DN_1], ISNULL([TD_DN_2],'') AS [TD_DN_2], " +
                        " ISNULL([TD_DT_1],'') AS [TD_DT_1], ISNULL([TD_DT_2],'') AS [TD_DT_2] FROM DE_XUAT_MUA_HANG  " +
                        " WHERE MS_DE_XUAT = '" +  sMSDX + "' ";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            txt1.Text = "";
            txt2.Text = "";
            if (dtTmp.Rows.Count > 0)
            {
                if (optGiayDeNghi.Checked)
                {
                    txt1.Text = dtTmp.Rows[0]["TD_DN_1"].ToString();
                    txt2.Text = dtTmp.Rows[0]["TD_DN_2"].ToString();
                }
                else
                {
                    txt1.Text = dtTmp.Rows[0]["TD_DT_1"].ToString();
                    txt2.Text = dtTmp.Rows[0]["TD_DT_2"].ToString();
                }
            }
            if (txt1.Text == "")
            {
                if (optGiayDeNghi.Checked)
                    txt1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "DeNghiMuaHang1", Commons.Modules.TypeLanguage);
                else
                    txt1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "BanDuTru1", Commons.Modules.TypeLanguage);
            }
            if (txt2.Text == "")
            {
                if (optGiayDeNghi.Checked)
                    txt2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "DeNghiMuaHang2", Commons.Modules.TypeLanguage);
                else
                    txt2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "BanDuTru2", Commons.Modules.TypeLanguage);
            }
        
        }

        private void LuuDuLieu()
        {
            string sSql = "";
            if (optGiayDeNghi.Checked)
                sSql = " UPDATE DE_XUAT_MUA_HANG SET TD_DN_1 = N'" + txt1.Text + "' , TD_DN_2 = N'" + txt2.Text + "' WHERE MS_DE_XUAT = '" + sMSDX + "' ";
            else
                sSql = " UPDATE DE_XUAT_MUA_HANG SET TD_DT_1 = N'" + txt1.Text + "' , TD_DT_2 = N'" + txt2.Text + "' WHERE MS_DE_XUAT = '" + sMSDX + "' ";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            }
            catch { }
        }

        private void optGiayDeNghi_CheckedChanged(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
            if (optGiayDeNghi.Checked) InDeNghiMuaHangDoFiCo();
            if (optBanDuTru.Checked) InBanDuTruDoFiCo();

        }

        #region InDoFiCo
        private void InDeNghiMuaHangDoFiCo()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();

            frmRptDexuat.rptName = "rptDeNghiMuaHangDFC";
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetDeNghiDFC", sMSDX));
            dtTmp.TableName = "DE_NGHI_MUA_HANG_DFC";
            frmRptDexuat.AddDataTableSource(dtTmp);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TONG_CONG_TY");
            TbTieuDe.Columns.Add("CONG_NGHIEP_TP");
            TbTieuDe.Columns.Add("PKT_CO_DIEN");
            TbTieuDe.Columns.Add("CONG_HOA");
            TbTieuDe.Columns.Add("DOC_LAP");
            TbTieuDe.Columns.Add("BIEN_HOA");
            TbTieuDe.Columns.Add("GIAY_DE_NGHI");
            TbTieuDe.Columns.Add("KINH_GOI");
            TbTieuDe.Columns.Add("TGD");
            TbTieuDe.Columns.Add("KTOAN");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("TEN");
            TbTieuDe.Columns.Add("MHH");
            TbTieuDe.Columns.Add("MSKT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("SLG");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("GAP");
            TbTieuDe.Columns.Add("KHONG_GAP");
            TbTieuDe.Columns.Add("LOAI");
            TbTieuDe.Columns.Add("TRINH_LANH_DAO");
            TbTieuDe.Columns.Add("DUYET");
            TbTieuDe.Columns.Add("TPKT");
            TbTieuDe.Columns.Add("NGUOI_DN");
            TbTieuDe.Columns.Add("VO_MINH_TAN");
            TbTieuDe.Columns.Add("GACH1");
            TbTieuDe.Columns.Add("GACH2");

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TGD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TGD", Commons.Modules.TypeLanguage);
            rTitle["KTOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "KTOAN", Commons.Modules.TypeLanguage);
            rTitle["TONG_CONG_TY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TONG_CONG_TY", Commons.Modules.TypeLanguage);
            rTitle["CONG_NGHIEP_TP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "CONG_NGHIEP_TP", Commons.Modules.TypeLanguage);
            rTitle["PKT_CO_DIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "PKT_CO_DIEN", Commons.Modules.TypeLanguage);
            rTitle["CONG_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "CONG_HOA", Commons.Modules.TypeLanguage);
            rTitle["DOC_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "DOC_LAP", Commons.Modules.TypeLanguage);
            rTitle["BIEN_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "BIEN_HOA", Commons.Modules.TypeLanguage) + " , " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "NGAY", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Day.ToString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "THANG", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Month.ToString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "NAM", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Year.ToString(); 
            rTitle["GIAY_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "GIAY_DE_NGHI", Commons.Modules.TypeLanguage);
            rTitle["KINH_GOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "KINH_GOI", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "STT", Commons.Modules.TypeLanguage);
            rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TEN", Commons.Modules.TypeLanguage);
            rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "MHH", Commons.Modules.TypeLanguage);
            rTitle["MSKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "MSKT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = sNDXuat;// Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["SLG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "SLG", Commons.Modules.TypeLanguage);
            rTitle["TON_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TON_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "GHI_CHU", Commons.Modules.TypeLanguage);
            rTitle["GAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "GAP", Commons.Modules.TypeLanguage);
            rTitle["KHONG_GAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "KHONG_GAP", Commons.Modules.TypeLanguage);
            rTitle["LOAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "LOAI", Commons.Modules.TypeLanguage);
            rTitle["TRINH_LANH_DAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TRINH_LANH_DAO", Commons.Modules.TypeLanguage);
            rTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "DUYET", Commons.Modules.TypeLanguage);
            rTitle["TPKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "TPKT", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "NGUOI_DN", Commons.Modules.TypeLanguage);
            rTitle["VO_MINH_TAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiMuaHangDFC", "VO_MINH_TAN", Commons.Modules.TypeLanguage);

            rTitle["GACH1"] = txt1.Text;
            rTitle["GACH2"] = txt2.Text;
            TbTieuDe.TableName = "TIEU_DE_DFC";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }

        private void InBanDuTruDoFiCo()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();

            frmRptDexuat.rptName = "rptBanDuTruDFC";
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetBanDuTruDFC", sMSDX));
            dtTmp.TableName = "BAN_DU_TRU_DFC";
            frmRptDexuat.AddDataTableSource(dtTmp);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TONG_CONG_TY");
            TbTieuDe.Columns.Add("CONG_NGHIEP_TP");
            TbTieuDe.Columns.Add("PKT_CO_DIEN");
            TbTieuDe.Columns.Add("CONG_HOA");
            TbTieuDe.Columns.Add("DOC_LAP");
            TbTieuDe.Columns.Add("BIEN_HOA");
            TbTieuDe.Columns.Add("GIAY_DE_NGHI");
            TbTieuDe.Columns.Add("KINH_GOI");
            TbTieuDe.Columns.Add("KE_TOAN");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("TEN");
            TbTieuDe.Columns.Add("MHH");
            TbTieuDe.Columns.Add("MSKT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("SLG");
            TbTieuDe.Columns.Add("DON_GIA");
            TbTieuDe.Columns.Add("THANH_TIEN");
            TbTieuDe.Columns.Add("TONG_CONG_VAT");
            TbTieuDe.Columns.Add("TONG_CONG");
            TbTieuDe.Columns.Add("LOAI");
            TbTieuDe.Columns.Add("TRINH_LANH_DAO");
            TbTieuDe.Columns.Add("DUYET");
            TbTieuDe.Columns.Add("DUYET_KT");
            TbTieuDe.Columns.Add("TPKT");
            TbTieuDe.Columns.Add("NGUOI_DN");
            TbTieuDe.Columns.Add("VO_MINH_TAN");
            TbTieuDe.Columns.Add("TIEN_CHU");
            TbTieuDe.Columns.Add("GACH1");
            TbTieuDe.Columns.Add("GACH2");
            TbTieuDe.Columns.Add("GACH3");
            TbTieuDe.Columns.Add("GACH4");

            DataRow rTitle = TbTieuDe.NewRow();

            rTitle["TONG_CONG_TY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TONG_CONG_TY", Commons.Modules.TypeLanguage);
            rTitle["CONG_NGHIEP_TP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "CONG_NGHIEP_TP", Commons.Modules.TypeLanguage);
            rTitle["PKT_CO_DIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "PKT_CO_DIEN", Commons.Modules.TypeLanguage);
            rTitle["CONG_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "CONG_HOA", Commons.Modules.TypeLanguage);
            rTitle["DOC_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "DOC_LAP", Commons.Modules.TypeLanguage);
            rTitle["BIEN_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "BIEN_HOA", Commons.Modules.TypeLanguage) + " , " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "NGAY", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Day.ToString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "THANG", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Month.ToString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "NAM", Commons.Modules.TypeLanguage) + " " +
                    dNDXuat.Year.ToString();
            rTitle["GIAY_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "GIAY_DE_NGHI", Commons.Modules.TypeLanguage);
            rTitle["KINH_GOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "KINH_GOI", Commons.Modules.TypeLanguage);
            rTitle["KE_TOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "BanTongGD", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "STT", Commons.Modules.TypeLanguage);
            rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TEN", Commons.Modules.TypeLanguage);
            rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "MHH", Commons.Modules.TypeLanguage);
            rTitle["MSKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "MSKT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = sNDXuat;// Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["SLG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "SLG", Commons.Modules.TypeLanguage);
            rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "DON_GIA", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "THANH_TIEN", Commons.Modules.TypeLanguage);
            rTitle["TONG_CONG_VAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TONG_CONG_VAT", Commons.Modules.TypeLanguage);
            rTitle["TONG_CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TONG_CONG", Commons.Modules.TypeLanguage);
            rTitle["LOAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "LOAI", Commons.Modules.TypeLanguage);
            rTitle["TRINH_LANH_DAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TRINH_LANH_DAO", Commons.Modules.TypeLanguage);
            rTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "DUYET", Commons.Modules.TypeLanguage);
            rTitle["DUYET_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "DUYET_KT", Commons.Modules.TypeLanguage);
            rTitle["TPKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "TPKT", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "NGUOI_DN", Commons.Modules.TypeLanguage);
            rTitle["VO_MINH_TAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "VO_MINH_TAN", Commons.Modules.TypeLanguage);
            rTitle["GACH1"] = txt1.Text;
            rTitle["GACH2"] = txt2.Text;
            rTitle["TIEN_CHU"] = txt2.Text;
            rTitle["GACH3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBanDuTruDFC", "PhongKeToan", Commons.Modules.TypeLanguage);

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetSoTienDFC", sMSDX, 1, Commons.Modules.TypeLanguage));
            rTitle["TIEN_CHU"] = "( " + dtTmp.Rows[0][0].ToString() + " )";

            TbTieuDe.TableName = "TIEU_DE_DFC";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }
        #endregion


    }
}
