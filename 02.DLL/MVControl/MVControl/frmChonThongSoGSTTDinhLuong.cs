using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
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
    public partial class frmChonThongSoGSTTDinhLuong : DevExpress.XtraEditors.XtraForm
    {
        string sBTamGiaTriDL = "GIA_TRI_TMPDL" + Commons.Modules.UserName;
        public frmChonThongSoGSTTDinhLuong()
        {
            InitializeComponent();
        }
        private void LoadNX()
        {
            try
            {
                //Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                KiemApp.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");

            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                KiemApp.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiMayTheoNXHTCoAll", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
                }
                catch { }
            }
            catch { }
        }

        private void LoadMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMayTheoLMNXHT", Commons.Modules.UserName, (cboLMay.Text == "" ? "-1" : cboLMay.EditValue), "-1", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), 0, 0));
                    DataRow row = dt.NewRow();
                    row["MS_MAY"] = -1;
                    row["TEN_MAY"] = "< ALL >";
                    dt.Rows.Add(row);
                    dt.DefaultView.Sort = "MS_MAY";
                    dt = dt.DefaultView.ToTable();
                    Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboThietbi, dt, "MS_MAY", "TEN_MAY", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }

        private void LoadcboThongsogiamsat()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                if (string.IsNullOrEmpty(cboThietbi.Text.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMS_TS_GSTT_MAY_TS_GSTT", cboThietbi.EditValue));
                    DataRow row = dt.NewRow();
                    row["MS_TS_GSTT"] = -1;
                    row["TEN_TS_GSTT"] = " < ALL > ";
                    dt.Rows.Add(row);
                    dt.DefaultView.Sort = "TEN_TS_GSTT";
                    dt = dt.DefaultView.ToTable();
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThongsogiamsat, dt, "MS_TS_GSTT", "TEN_TS_GSTT", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }
        private void LoadGrdGiamSatDL()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (string.IsNullOrEmpty(cboThietbi.Text.ToString())) return;
            if (string.IsNullOrEmpty(cboThongsogiamsat.Text.ToString())) return;
            DataTable dtTmp = new DataTable();
            if (chkHangmucdenhangGS.Checked)
            {
                //load theo ngay den han
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "getDSThongSoGSDinhLuongByNgay",cboDDiem.EditValue,cboDChuyen.EditValue,cboLMay.EditValue, cboThietbi.EditValue, cboThongsogiamsat.EditValue , dtNgay.DateTime,sBTamGiaTriDL, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            }
            else
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "getDSThongSoGSDinhLuong", cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboThietbi.EditValue, cboThongsogiamsat.EditValue, sBTamGiaTriDL, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            }
            grdDS.DataSource = null;
            dtTmp.Columns[6].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDS, grvDS, dtTmp, true, true, true, true, true, this.Name);

            for (int i = 0; i <= 5; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            dtTmp.Columns[7].ReadOnly = true;

            grvDS.Columns["MS_TS_GSTT"].Visible = false;
            grvDS.Columns["GIA_TRI_DO"].Width = 50;
            grvDS.Columns["TEN_DV_DO"].Width = 50;
            grvDS.Columns["GIA_TRI_DO"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            grvDS.Columns["GIA_TRI_DO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            grvDS_FocusedRowChanged(null, null);

        }

        private void LoadgrdDSGiaTri()
        {
            string sMaThongSo, sMaMay, sMaBP;
            try
            {
                sMaThongSo = grvDS.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
            }
            catch { sMaThongSo = "-1"; }
            try
            {
                sMaMay = grvDS.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { sMaMay = "-1"; }

            try
            {
                sMaBP = grvDS.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { sMaBP = "-1"; }

            //string sSql = "SELECT TEN_GT,GIA_TRI_DUOI, GIA_TRI_TREN, MS_TT FROM GIA_TRI_TMPDLAdmin WHERE MS_MAY='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'";

            string sSql = "SELECT T1.TEN_GT,T1.GIA_TRI_DUOI,T1.GIA_TRI_TREN,T1.MS_TT FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT T1 WHERE T1.MS_MAY = '" + sMaMay+"'AND T1.MS_TS_GSTT ='"+sMaThongSo+"' AND T1.MS_BO_PHAN = '"+sMaBP+"' ORDER BY T1.GIA_TRI_DUOI,T1.GIA_TRI_TREN";

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            grdDSGiaTri.DataSource = null;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSGiaTri, grvDSGiaTri, dtTmp, false, true, true, true, true, this.Name);
            grvDSGiaTri.Columns["GIA_TRI_DUOI"].Width = 50;
            grvDSGiaTri.Columns["GIA_TRI_TREN"].Width = 50;
            grvDSGiaTri.Columns["MS_TT"].Visible = false;

        }
        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                LoadMay();
            }
            catch { }
        }
        private void cboDChuyen_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                LoadLoaiMay();
            }
            catch { }
        }
        private void cboDDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                LoadLoaiMay();
            }
            catch { }
        }
        private void frmChonThongSoGSTTDinhLuong_Load(object sender, EventArgs e)
        {
            dtNgay.EditValue = DateTime.Now;
            Commons.Modules.SQLString = "0Load";
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadGrdGiamSatDL();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void cboThietbi_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            LoadcboThongsogiamsat();
            Commons.Modules.SQLString = "";
            LoadGrdGiamSatDL();
        }

        private void cboThongsogiamsat_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrdGiamSatDL();
        }

        private void grvDS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadgrdDSGiaTri();
        }

        private void UpdateGiaTriDoInBT()
        {
            string sMaThongSo, sMaMay, sMaBP;
            int iMaTT;
            double dGiaTriDo;
            try
            {
                sMaThongSo = grvDS.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
            }
            catch { sMaThongSo = "-1"; }
            try
            {
                sMaMay = grvDS.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { sMaMay = "-1"; }

            try
            {
                sMaBP = grvDS.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { sMaBP = "-1"; }

            try
            {
                dGiaTriDo = Convert.ToDouble(grvDS.GetFocusedRowCellValue("GIA_TRI_DO").ToString());
            }
            catch { dGiaTriDo = -1; }

            try
            {
                iMaTT = Convert.ToInt16(grvDSGiaTri.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { iMaTT = -1; }

            double min = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MIN(GIA_TRI_DUOI) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));

            double max = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MAX(GIA_TRI_TREN) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));

            if (dGiaTriDo <= min || dGiaTriDo > max)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "Msgkhongnamtrongkhoanggiatri", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
            }
            else
            {
                try
                {
                    string sSql = "UPDATE " + sBTamGiaTriDL + " SET GIA_TRI_DO = " + Math.Round(dGiaTriDo,2) + " ,MS_TT = (SELECT MS_TT FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'AND GIA_TRI_TREN > " + dGiaTriDo + " AND GIA_TRI_DUOI <= " + dGiaTriDo + ") WHERE MS_MAY = '" + sMaMay + "' AND MS_TS_GSTT = '" + sMaThongSo + "' AND MS_BO_PHAN = '" + sMaBP + "'";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void TKgrdGS()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdDS.DataSource;
                if (txtTimKiem.Text.Length != 0) sdkien = sdkien + " AND( " + " MS_MAY LIKE '%" + txtTimKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTimKiem.Text + "%'  OR MS_TS_GSTT LIKE '%" + txtTimKiem.Text + "%'OR TEN_TS_GSTT LIKE '%" + txtTimKiem.Text + "%' OR  MS_BO_PHAN LIKE '%" + txtTimKiem.Text + "%' OR TEN_BO_PHAN LIKE '%" + txtTimKiem.Text + "%')";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void BtnThucHien_Click(object sender, EventArgs e)
        {
            string sSql = "SELECT COUNT(*) FROM "+sBTamGiaTriDL+" WHERE ISNULL([GIA_TRI_DO],0)<>0 ";
            int n = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
            if (n == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgVuilongNhapGiatri", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            TKgrdGS();
        }


        private void grvDS_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Value.ToString()))
            { e.Value = 0;
                if (grvDS.FocusedColumn.Name.ToString() == "colGIA_TRI_DO")
                {
                    grvDS.SetFocusedRowCellValue("GIA_TRI_DO", 0);
                }
            }
        }

        private void grvDS_ValidateRow_1(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
            string sMaThongSo, sMaMay, sMaBP;
            int iMaTT;
            double dGiaTriDo;
            try
            {
                sMaThongSo = grvDS.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
            }
            catch { sMaThongSo = "-1"; }
            try
            {
                sMaMay = grvDS.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { sMaMay = "-1"; }

            try
            {
                sMaBP = grvDS.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { sMaBP = "-1"; }

            try
            {
                dGiaTriDo = Convert.ToDouble(grvDS.GetFocusedRowCellValue("GIA_TRI_DO").ToString());
            }
            catch { dGiaTriDo = -1; }

            try
            {
                iMaTT = Convert.ToInt16(grvDSGiaTri.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { iMaTT = -1; }

            double min = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MIN(GIA_TRI_DUOI) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));

            double max = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MAX(GIA_TRI_TREN) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));

            if (dGiaTriDo < min || dGiaTriDo > max)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "Msgkhongnamtrongkhoanggiatri", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grvDS.SetColumnError(grvDS.Columns["GIA_TRI_DO"], "Error");
                e.Valid = false;
            }
            else
            {
                try
                {
                    string sSql = "UPDATE " + sBTamGiaTriDL + " SET GIA_TRI_DO = " + Math.Round(dGiaTriDo,2) + " ,MS_TT = (SELECT MS_TT FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'AND GIA_TRI_TREN >= " + dGiaTriDo + " AND GIA_TRI_DUOI <= " + dGiaTriDo + ") WHERE MS_MAY = '" + sMaMay + "' AND MS_TS_GSTT = '" + sMaThongSo + "' AND MS_BO_PHAN = '" + sMaBP + "'";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
        }

        private void chkHangmucdenhangGS_CheckedChanged(object sender, EventArgs e)
        {
            dtNgay.Enabled = chkHangmucdenhangGS.Checked;
            LoadGrdGiamSatDL();
        }

        private void dtNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtNgay.Text) || string.IsNullOrEmpty(dtNgay.Text))
            {
                dtNgay.DateTime = DateTime.Now;
            }
            LoadGrdGiamSatDL();
        }
    }
}
