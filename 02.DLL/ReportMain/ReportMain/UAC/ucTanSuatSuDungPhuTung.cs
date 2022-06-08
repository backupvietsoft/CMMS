using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucTanSuatSuDungPhuTung : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucTanSuatSuDungPhuTung";
        public ucTanSuatSuDungPhuTung()
        {
            InitializeComponent();
        }

#region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHT", Commons.Modules.UserName, sNX, iHThong));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (Commons.Modules.SQLString == "0LOADLOAI") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                string sLmay = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoLMNXHT", Commons.Modules.UserName,
                    sLmay, "-1", sNX, iHThong, 0, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboThietBi, dtTmp, "MS_MAY", "TEN_MAY", "ucDanhSachVTPT");
            }
            catch { }
        }

        private void LoadVatTu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = "SELECT CONVERT(BIT,1) AS CHON ,MS_PT, MS_PT_CTY, TEN_PT, MS_PT_NCC " +
                                " FROM IC_PHU_TUNG ORDER BY MS_PT, MS_PT_CTY, TEN_PT, MS_PT_NCC";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,sSql));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdVTu, grvVTu, dtTmp, true, true, true, true, true, sUC);
                for (int i = 1; i < grvVTu.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                grvVTu.Columns["CHON"].Width = 100;
            }
            catch { }
        }

#endregion

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            Commons.Modules.SQLString = "0LOADLOAI";
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucTanSuatSuDungPhuTung_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            datDNgay.DateTime = DateTime.Now;
            LoadNX();
            LoadDChuyen();
            Commons.Modules.SQLString = "0LOADLOAI";
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
            LoadVatTu();
        }

        private void btnTimMay_Click(object sender, EventArgs e)
        {
            frmTimMay frm = new frmTimMay();
            frm.iLoaiBC = 1;
            frm.MsLoaiMay = cboLMay.EditValue.ToString();
            frm.TuNgay = datTNgay.DateTime;
            frm.DenNgay = datDNgay.DateTime;
            frm.sDiaDiem = cboDDiem.EditValue.ToString();
            frm.iHeThong = int.Parse(cboDChuyen.EditValue.ToString());
            frm.iBoPhan = -1;
            string sLoaiMay;
            sLoaiMay = cboLMay.EditValue.ToString();
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            string sMsMay;

            sMsMay = frm.MsMay;
            sLoaiMay = frm.LoaiMay;
            if (sMsMay == "") return;
            if (sLoaiMay != cboLMay.EditValue.ToString()) cboLMay.EditValue = sLoaiMay;
            cboThietBi.EditValue = sMsMay;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }


            string sMsMay = "-1";
            string sLoaiMay = "-1";

            if (cboThietBi.EditValue.ToString() != " < ALL > ") sMsMay = cboThietBi.EditValue.ToString();
            if (cboLMay.EditValue.ToString() != "-1") sLoaiMay = cboLMay.EditValue.ToString();

            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdVTu.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                    "ChuaChonVatTu", Commons.Modules.TypeLanguage));
                return;
            }

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                    "VT_TSPT" + Commons.Modules.UserName, dtTmp, "");
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTanSuatSuDungPhuTung", datTNgay.DateTime, datDNgay.DateTime,
                cboDDiem.EditValue, cboDChuyen.EditValue, sLoaiMay, sMsMay, Commons.Modules.UserName, Commons.Modules.TypeLanguage,"VT_TSPT"));

            Commons.Modules.ObjSystems.XoaTable ("VT_TSPT" + Commons.Modules.UserName);
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            dtTmp.TableName = "DL_TSSDPT";
            frmReport frmTSPT = new frmReport();
            frmTSPT.rptName = "rptTanSuatSDPTung";
            frmTSPT.AddDataTableSource(dtTmp);

            dtTmp = new DataTable();
            dtTmp = TieuDe();
            frmTSPT.AddDataTableSource(dtTmp);
            frmTSPT.ShowDialog(this);            
        }
        private DataTable TieuDe()
        {
            
            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("DIA_DIEM");
            TbTieuDe.Columns.Add("DAY_CHUYEN");
            TbTieuDe.Columns.Add("LOAI_TB");
            TbTieuDe.Columns.Add("MSTB");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("NGAY_THAY");
            TbTieuDe.Columns.Add("PHIEU_BT");
            TbTieuDe.Columns.Add("BO_PHAN");
            TbTieuDe.Columns.Add("S_LUONG");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("MA_TB");
            TbTieuDe.Columns.Add("MHH");
            TbTieuDe.Columns.Add("MKT");
            TbTieuDe.Columns.Add("TEN_HH");
            TbTieuDe.Columns.Add("TONG");
            TbTieuDe.Columns.Add("DU1");
            TbTieuDe.Columns.Add("DU2");


            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "TUNGAY", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "DENNGAY", Commons.Modules.TypeLanguage) + " : " + datDNgay.DateTime.Date.ToShortDateString();
            rTitle["DIA_DIEM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "DIA_DIEM", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
            rTitle["DAY_CHUYEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "DAY_CHUYEN", Commons.Modules.TypeLanguage) + " : " + cboDChuyen.TextValue;
            rTitle["LOAI_TB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "LOAI_TB", Commons.Modules.TypeLanguage) + " : " + cboLMay.Text;
            rTitle["MSTB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "MSTB", Commons.Modules.TypeLanguage) + " : " + cboThietBi.Text;

            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "STT", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "NGAY_THAY", Commons.Modules.TypeLanguage);
            rTitle["PHIEU_BT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "PHIEU_BT", Commons.Modules.TypeLanguage);
            rTitle["BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "BO_PHAN", Commons.Modules.TypeLanguage);
            rTitle["S_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "S_LUONG", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DVT", Commons.Modules.TypeLanguage);
            rTitle["MA_TB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "MA_TB", Commons.Modules.TypeLanguage);
            rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "MHH", Commons.Modules.TypeLanguage);
            rTitle["MKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "MKT", Commons.Modules.TypeLanguage);
            rTitle["TEN_HH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TEN_HH", Commons.Modules.TypeLanguage);
            rTitle["TONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TONG", Commons.Modules.TypeLanguage);
            rTitle["DU1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DU1", Commons.Modules.TypeLanguage);
            rTitle["DU2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DU2", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "TD_IN_TSSDPT";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;

        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvVTu);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvVTu);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtPBT = new DataTable();
            dtPBT = (DataTable)grdVTu.DataSource;
            try
            {
                string dk = "";
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_CTY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtPBT.DefaultView.RowFilter = dk;
            }
            catch { dtPBT.DefaultView.RowFilter = ""; }
        }

    }
}
