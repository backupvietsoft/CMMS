using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ImportExcels.UserControl
{
    public partial class ucHCKD : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dtLuoi = new DataTable();
        public ucHCKD()
        {
            InitializeComponent();
        }
        private void LoadMay()
        {
            try
            {
                dtLuoi = new DataTable();
                dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAYCoChuKy", cboDDiem.EditValue, cboDChuyen.EditValue, cboLoai.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                grdSum.DataSource = dtLuoi;
                dtLuoi.Columns[0].ReadOnly = false;
                dtLuoi.Columns[1].ReadOnly = true;
                dtLuoi.Columns[2].ReadOnly = true;


                grvSum.PopulateColumns();
                grvSum.OptionsView.ColumnAutoWidth = true;
                grvSum.OptionsView.AllowHtmlDrawHeaders = true;
                grvSum.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grvSum.BestFitColumns();
                grvSum.Columns[0].Width = 100;
                grvSum.Columns[1].Width = 100;
                grvSum.Columns[1].AppearanceCell.BackColor = Color.WhiteSmoke;
                grvSum.Columns[2].AppearanceCell.BackColor = Color.WhiteSmoke;
            }
            catch { }

        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoai, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLoaiTB.Text);
            }
            catch { }
        }
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



        private void ucHCKD_Load(object sender, EventArgs e)
        {
            try
            {
               
                btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "btnExcute", Commons.Modules.TypeLanguage);
                btnChon.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "btnChon", Commons.Modules.TypeLanguage);
                btnKhong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "btnKhong", Commons.Modules.TypeLanguage);
                btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "btnThoat", Commons.Modules.TypeLanguage);
                dtNgay.DateTime = DateTime.Now.Date.AddMonths(-1);
                LoadLoaiMay();
                LoadDChuyen();
                LoadNX();
                LoadMay();

                grvSum.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", grvSum.Columns[0].Name, Commons.Modules.TypeLanguage);
                grvSum.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", grvSum.Columns[1].Name, Commons.Modules.TypeLanguage);
                grvSum.Columns[2].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", grvSum.Columns[2].Name, Commons.Modules.TypeLanguage);
                grvSum.Columns[3].Visible = false;

                chkTTBT.Items[0].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "radHieuChuanNoi", Commons.Modules.TypeLanguage);
                chkTTBT.Items[1].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "radHieuChuanNgoai", Commons.Modules.TypeLanguage);
                chkTTBT.Items[2].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "radKiemDinh", Commons.Modules.TypeLanguage);
                chkTTBT.Items[3].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "chkKiemTra", Commons.Modules.TypeLanguage);
            }
            catch { }
        }

        private bool KiemTH()
        {
            try
            {
                if (string.IsNullOrEmpty(cboLoai.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "VuiLongChonLoai", Commons.Modules.TypeLanguage));
                    cboLoai.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cboDChuyen.TextValue))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "VuiLongChonNhom", Commons.Modules.TypeLanguage));
                    cboDChuyen.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(dtNgay.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "VuiLongChonDenNgay", Commons.Modules.TypeLanguage));
                    dtNgay.Focus();
                    return false;
                }
                return true;
            }
            catch { return false; }

        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmBCaoHCKD frm = new frmBCaoHCKD();
            DataTable dtTmp = new DataTable();
            string sBTTTBT = "tmpHCKDMay" + Commons.Modules.UserName;

            //if (KiemTH() == false) return;
            string LoaiHC = "";
            try
            {
                if (chkTTBT.GetItemChecked(0))
                    LoaiHC = LoaiHC + ",1";
                if (chkTTBT.GetItemChecked(1))
                    LoaiHC = LoaiHC + ",2";
                if (chkTTBT.GetItemChecked(2))
                    LoaiHC = LoaiHC + ",3";
                if (chkTTBT.GetItemChecked(3))
                    LoaiHC = LoaiHC + ",4";
            }
            catch { }
            if (LoaiHC.Trim().Equals(""))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "msgChuaChonLoaiHC", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtTmpChon = new DataTable();
            dtTmpChon = dtLuoi.Copy();
            dtTmpChon.DefaultView.RowFilter = "CHON = TRUE";
            dtTmpChon = dtTmpChon.DefaultView.ToTable();
           
            Commons.Modules.ObjSystems.XoaTable(sBTTTBT);

            if (dtTmpChon.DefaultView.ToTable().Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCaoHCKD", "ChuaChonMay", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTmpChon.DefaultView.RowFilter = "";
                return;                 
            }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTTTBT, dtTmpChon, "");                    
            string TenMay = "";
            TenMay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "TenThietBi", Commons.Modules.TypeLanguage);

            frm.DenNgay = dtNgay.DateTime;
            try
            {                
                frm.LoaiBC = optBCao.SelectedIndex;
                frm._dtHCKD = new DataTable();
                frm._dtHCKD.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoKHHieuChuanTheoLoaiHC", dtNgay.DateTime, Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, cboLoai.EditValue, optBCao.SelectedIndex, LoaiHC, Commons.Modules.TypeLanguage, sBTTTBT));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (frm._dtHCKD.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frm.ShowDialog();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            CapNhap(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            CapNhap(false);
        }
        private void CapNhap(Boolean  LoaiCN)
        {
            try
            {
                foreach (DataRow dr in dtLuoi.Rows)
                {
                    dr[0] = LoaiCN;
                }
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(optBCao.SelectedIndex == 0)
            {
                chkTTBT.Items.RemoveAt(3);
            }
            else
            {
                chkTTBT.Items.Add("chkKiemTra");
                chkTTBT.Items[3].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "chkKiemTra", Commons.Modules.TypeLanguage);
            }
        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay(); 
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboLoai_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
    }
}
