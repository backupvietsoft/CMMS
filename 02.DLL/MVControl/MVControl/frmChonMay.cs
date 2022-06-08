using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmChonMay : DevExpress.XtraEditors.XtraForm
    {
        public frmChonMay()
        {
            InitializeComponent();
        }
        public List<string> lstMayChon = new List<string> { };
        public DataTable dtMayReturn = new DataTable();

        //lstMayChon = dtMay.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("MS_MAY")).ToList();
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");

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

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0DD") return;
            if (Commons.Modules.SQLString == "0DC") return;
            if (Commons.Modules.SQLString == "0LM") return;

            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = DateTime.Now; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }


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
                        TNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "0";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dtMay.Columns["CHON"].ReadOnly = false;


                if (lstMayChon.Count > 0)
                    dtMay.AsEnumerable().Where(a => lstMayChon.Contains(a.Field<string>("MS_MAY")))
                                        .Select(b => b["CHON"] = 1)
                                        .ToList();

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, true, this.Name);

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TimKiem();
        }

        #endregion

        private void frmChonMay_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Commons.Modules.SQLString = "0Load";
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            Commons.Modules.SQLString = "";
            LoadMay();
            this.Cursor = Cursors.Default;
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
            TimKiem();
        }



        private void cboDDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            TimKiem();
        }

        private void cboNMay_EditValueChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();            
            string sdkien = "( 1 = 1 )";

            try
            {
                if (cboDDiem.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_N_XUONG = '" + cboDDiem.EditValue.ToString() + "' OR MS_NX_CHA = '" + cboDDiem.EditValue.ToString() + "' ) ";
            }
            catch
            {  }
            try
            { if (cboDChuyen.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_HE_THONG = " + cboDChuyen.EditValue.ToString() + " OR MS_HT_CHA = " + cboDChuyen.EditValue.ToString() + " ) ";  }
            catch { }

            try
            { if (cboLMay.EditValue.ToString() != "-1") sdkien =  sdkien + " AND ( MS_LOAI_MAY = '" + cboLMay.EditValue.ToString() + "' ) "; }
            catch {  }

            try
            { if (cboNMay.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_NHOM_MAY = '" + cboNMay.EditValue.ToString() + "' ) "; }
            catch {}

            sdkien = "( " + sdkien + ") ";
            try
            {

                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) sdkien = sdkien + " AND ( " +  " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ) " ;
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
            lblTCong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TongCong", Commons.Modules.TypeLanguage) + " : " + grvMay.RowCount.ToString();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            TimKiem();
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dtMayReturn = new DataTable();
            dtMayReturn = ((DataTable)grdMay.DataSource).Copy();
            dtMayReturn.DefaultView.RowFilter = "CHON = TRUE ";

            dtMayReturn = dtMayReturn.DefaultView.ToTable();


            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            dtMayReturn = new DataTable();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void grvMay_ShownEditor(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            TextEdit activeEditor = view.ActiveEditor as TextEdit;
            if (activeEditor == null) return;
            activeEditor.Spin -= activeEditor_Spin;
            activeEditor.Spin += activeEditor_Spin;

        

    }
    void activeEditor_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
    {
            grvMay.CloseEditor();
    }
}
}
