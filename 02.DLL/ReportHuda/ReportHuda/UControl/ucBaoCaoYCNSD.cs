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
            Commons.Modules.SQLString = "LoadForm";
            datTNgay.DateTime = Ngay;
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            LoadTTrang();
            Commons.Modules.SQLString = "";
            LoadMay();
        }


#region Load Du Lieu
     

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, _table, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }

        private void LoadNhomMay(string sLMay)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, sLMay), "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
            }
            catch { }
        }


        private void LoadTTrang()
        {
            try
            {

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTTrang,
                  " SELECT CONVERT(NVARCHAR(15),'-1') AS MS_CTH , '< ALL >' AS TEN UNION SELECT MS_TTRANG, " +
                  " CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_TTRANG WHEN 1 THEN TEN_TTRANG_ANH ELSE TEN_TTRANG_HOA END AS TEN_TINH_TRANG FROM TINH_TRANG_YCSD ORDER BY MS_CTH", "MS_CTH", "TEN", lblTTrang.Text);

            }
            catch { }
        }




        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {

            if (Commons.Modules.SQLString == "0Load") return;
            if (cboLMay.Text == "") return;
            string sLMay = "-1";
            try
            {
                sLMay = cboLMay.EditValue.ToString();
            }
            catch { sLMay = "-1"; }
            Commons.Modules.SQLString = "0LM";
            LoadNhomMay(sLMay);
            Commons.Modules.SQLString = "";
            LoadMay();
        }
        private void cboNMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }



        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "LoadForm") return;
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0DD") return;
            if (Commons.Modules.SQLString == "0DC") return;
            if (Commons.Modules.SQLString == "0LM") return;
            //this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2000"); }


                string NXuong = "-1";
                string LMay = "-1";
                string NhomMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.TextValue == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }

                try
                { if (cboNMay.Text == "") NhomMay = "-1"; else NhomMay = cboNMay.EditValue.ToString(); }
                catch { NhomMay = "-1"; }

                try
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetMayNXuongHThongLMay", Commons.Modules.UserName, NXuong, HThong, -1, LMay, NhomMay, "-1",
                        DNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "1";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, false, "");

                for (int i = 1; i <= grvMay.Columns.Count - 1; i++)
                {
                    grvMay.Columns[i].Visible = false;
                    dtMay.Columns[i].ReadOnly = true;
                }
                grvMay.Columns["MS_MAY"].Visible = true;
                grvMay.Columns["TEN_NHOM_MAY"].Visible = true;
                grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
                grvMay.Columns["TEN_HE_THONG"].Visible = true;
                grvMay.Columns["Ten_N_XUONG"].Visible = true;
                grvMay.Columns["TEN_MAY"].Visible = true;
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvMay, "ucDanhSachPBT");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Cursor = Cursors.Default;
        }

        #endregion

        //

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sBTMay = "BCYCNSD";
            DataTable dtTmp = new DataTable();
            if (datDNgay.DateTime < datTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDanhSachPBT", "msgTuNgayLonHonDenNgay",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                datDNgay.Focus();
                this.Cursor = Cursors.Default;
                return;
            }

            if (cboDDiem.TextValue == "") //ucBaoCaucBaoCaoChung   msgKhongCoDiaDiemucBaoCaoChung	msgKhongCoDiaDiemoChung   msgKhongCoDiaDiem
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaucBaoCaoChung", "msgKhongCoDiaDiemu", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaucBaoCaoChung", "msgKhongCoDayChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaucBaoCaoChung", "msgKhongCoLoaiMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }
            if (cboNMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaucBaoCaoChung", "msgKhongCoNhomMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }
            if (cboTTrang.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaucBaoCaoChung", "msgKhongCoTinhTrang", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }
            dtTmp = ((DataTable)grdMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
            if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDanhSachPBT", "msgChuaChonMay", Commons.Modules.TypeLanguage));
                return;
            }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTMay, dtTmp, "");
            frmBCYeuCauNSD frm = new frmBCYeuCauNSD();
            frm._Ngay = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
            frm._DDiem = lblDDiem.Text + " : " + cboDDiem.TextValue;
            frm._DChuyen = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
            frm._TTrang = lblTTrang.Text + " : " + cboTTrang.Text;
            frm._LMay = lblLMay.Text + " : " + cboLMay.Text;
            frm._NMay = lblNhomMay.Text + " : " + cboNMay.Text;

            frm._dtTable = new DataTable();
            frm._dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetBCNguoiSuDung" ,
                datTNgay.DateTime, datDNgay.DateTime,cboTTrang.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage,sBTMay));
            frm.ShowDialog();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            try
            {
                LoadMay();
            }catch { }
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }
        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
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
    }
}
