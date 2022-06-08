using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportMain
{
    public partial class frmTimMayTTTB : DevExpress.XtraEditors.XtraForm
    {
        #region Khai Bao
        string sTSo = "";
        Point ptChung;
        GridView viewChung;
        private string sMsMay = "-1";
        public string MsMay { get { return sMsMay; } set { sMsMay = value; } }

        private int iLoai = 0;
        public int LoaiBC { get { return iLoai; } set { iLoai = value; } }

        private string sDDiem = "-1";
        public string DiaDiem { get { return sDDiem; } set { sDDiem = value; } }

        private string sTinh = "-1";
        public string MsTinh { get { return sTinh; } set { sTinh = value; } }

        private string sQuan = "-1";
        public string MsQuan { get { return sQuan; } set { sQuan = value; } }

        private string sDuong = "-1";
        public string MsDuong { get { return sDuong; } set { sDuong = value; } }

        private int iHThong = -1;
        public int HeThong { get { return iHThong; } set { iHThong = value; } }

        private string sMsLoaiMay = "-1";
        public string MsLMay { get { return sMsLoaiMay; } set { sMsLoaiMay = value; } }

        private string sMsNhomMay = "-1";
        public string MsNMay { get { return sMsNhomMay; } set { sMsNhomMay = value; } }
        #endregion 

        public frmTimMayTTTB()
        {
            InitializeComponent();
        }

        #region Load Du Lieu
        private void LoadTinh()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinh, "SELECT MA_QG,TEN_QG FROM Y_Tinh ORDER BY TEN_QG", "MA_QG", "TEN_QG", lblTinh.Text);
        }

        private void LoadQuan(string MsTinh)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboQuan, "SELECT  MA_QG,TEN_QG FROM Y_District WHERE  ( '" + MsTinh + "' = '-1' ) " +
                " OR ( MS_CHA = '" + MsTinh + "'  ) UNION SELECT '-1',' < ALL > '  ORDER BY TEN_QG", "MA_QG", "TEN_QG", lblQuan.Text);
        }

        private void LoadDuong(string MsTinh, string MsQuan)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDuong, "SELECT MS_DUONG, DUONG_TV FROM Y_Duong WHERE  " +
                " (( '" + MsTinh + "' = '-1' ) OR ( MS_Tinh = '" + MsTinh + "'  )) " +
                " AND (( '" + MsQuan + "' = '-1' ) OR ( MS_Quan = '" + MsQuan + "'  )) " +
                " UNION SELECT '-1',' < ALL > '  ORDER BY DUONG_TV", "MS_DUONG", "DUONG_TV", lblDuong.Text);
        }

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName,
                    cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString(), cboDuong.EditValue.ToString()));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
            }
            catch { }
        }


        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }

        }

        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }
        #endregion
        #region Change du lieu
        private void cboTinh_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTinh.EditValue != null) LoadQuan(cboTinh.EditValue.ToString());
                if (cboTinh.EditValue != null && cboQuan.EditValue != null) LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
                LoadNX();
            }
            catch { }

        }

        private void cboQuan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTinh.EditValue != null && cboQuan.EditValue != null) LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
                LoadNX();
            }
            catch { }
        }

        private void cboDuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            try
            {
                MsMay = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MsMay = "";
                this.Close();
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmTimMayTTTB_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            LockOpt();
            //grvChung.OptionsView.ColumnAutoWidth = false;
            grvChung.Columns["MS_MAY"].Width = 100;
            grvChung.Columns["TEN_MAY"].Width = 200;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            sTSo = lblTSo.Text;
            lblTSo.Text = sTSo + " : " + grvChung.RowCount.ToString() + ". ";


        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LockOpt();
                LoadDuLieu();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LockOpt()
        {
            cboTinh.Properties.ReadOnly = true;
            cboQuan.Properties.ReadOnly = true;
            cboDuong.Properties.ReadOnly = true;
            cboDDiem.Properties.ReadOnly = true;
            cboDChuyen.Properties.ReadOnly = true;
            cboLMay.Properties.ReadOnly = true;
            cboNhomMay.Properties.ReadOnly = true;
            if (optBCao.SelectedIndex == 1)
            {
                cboTinh.Properties.ReadOnly = false;
                cboQuan.Properties.ReadOnly = false;
                cboDuong.Properties.ReadOnly = false;
                cboDDiem.Properties.ReadOnly = false;
                return;
            }
            if (optBCao.SelectedIndex == 2)
            {
                cboDChuyen.Properties.ReadOnly = false;
                return;
            }
            if (optBCao.SelectedIndex == 3)
            {
                cboLMay.Properties.ReadOnly = false;
                cboNhomMay.Properties.ReadOnly = false;
                return;
            }
        }

        private void LoadDuLieu()
        {
            if (Commons.Modules.SQLString == "0load") return;

            try
            {
                DataTable dtTmp = new DataTable();
                if (optBCao.SelectedIndex == 0)
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionALL", Commons.Modules.UserName, 0, 0));

                if (optBCao.SelectedIndex == 1)
                {
                    string sNX, sTinh, sQuan, sDuong;
                    sNX = "-1"; sTinh = "-1"; sQuan = "-1"; sDuong = "-1";
                    if (cboDDiem.Text == "") return;
                    if (cboTinh.Text == "") return;
                    if (cboQuan.Text == "") return;
                    if (cboDuong.Text == "") return;

                    if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();
                    if (cboTinh.EditValue.ToString() != "-1") sTinh = cboTinh.EditValue.ToString();
                    if (cboQuan.EditValue.ToString() != "-1") sQuan = cboQuan.EditValue.ToString();
                    if (cboDuong.EditValue.ToString() != "-1") sDuong = cboDuong.EditValue.ToString();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONG_New",
                            Commons.Modules.UserName, sNX, sTinh, sQuan, sDuong, 0));
                }

                if (optBCao.SelectedIndex == 2)
                {
                    if (cboDChuyen.Text == "") return;
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_HE_THONG", cboDChuyen.EditValue,
                        Commons.Modules.UserName, 0));
                }
                if (optBCao.SelectedIndex == 3)
                {
                    if (cboNhomMay.Text == "") return;
                    if (cboLMay.Text == "") return;
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHOM_MAYs", cboNhomMay.EditValue, cboLMay.EditValue,
                        Commons.Modules.UserName, 0));
                }

                grdChung.DataSource = dtTmp;
                grvChung.OptionsBehavior.Editable = true;
                lblTSo.Text = sTSo + " : " + grvChung.RowCount.ToString() + ". ";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgLoadDuLieuLoi", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdChung.DataSource;

            try
            {
                string dk = "";
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MODEL LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtMay.DefaultView.RowFilter = dk;
            }
            catch { dtMay.DefaultView.RowFilter = ""; }
        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvChung.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (grvChung.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MsMay = "";
                this.Close();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                try
                {
                    GanDLieu();
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grvChung_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
            
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (grvChung.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MsMay = "";
                this.Close();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                try
                {
                    GanDLieu();
                    this.Close();
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GanDLieu()
        {
            try { LoaiBC = optBCao.SelectedIndex; }
            catch { LoaiBC = 0; }
            try { MsTinh = cboTinh.EditValue.ToString(); }
            catch { MsTinh = "-1"; }
            try { MsQuan = cboQuan.EditValue.ToString(); }
            catch { MsQuan = "-1"; }
            try { MsDuong = cboDuong.EditValue.ToString(); }
            catch { MsDuong = "-1"; }
            try { DiaDiem = cboDDiem.EditValue.ToString(); }
            catch { DiaDiem = "-1"; }
            try { HeThong = int.Parse(cboDChuyen.EditValue.ToString()); }
            catch { HeThong = -1; }
            try { MsLMay = cboLMay.EditValue.ToString(); }
            catch { MsLMay = "-1"; }
            try { MsNMay = cboNhomMay.EditValue.ToString(); }
            catch { MsNMay = "-1"; }
            try { MsMay = grvChung.GetFocusedRowCellValue("MS_MAY").ToString(); }
            catch { MsMay = "-1"; }
        }

        private void frmTimMayTTTB_Shown(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            optBCao.SelectedIndex = iLoai;

            if (sTinh != "-1") cboTinh.EditValue = sTinh;
            if (sQuan != "-1") cboQuan.EditValue = sQuan;
            if (sDuong != "-1") cboDuong.EditValue = sDuong;
            if (sDDiem != "-1") cboDDiem.EditValue = sDDiem;
            if (iHThong != -1) cboDChuyen.EditValue = iHThong;
            if (sMsLoaiMay != "-1") cboLMay.EditValue = sMsLoaiMay;
            if (sMsNhomMay != "-1") cboNhomMay.EditValue = sMsNhomMay;
            Commons.Modules.SQLString = "";
            LoadDuLieu();
            if (sMsMay != "-1")
            {
                DataTable dtMay = new DataTable();
                dtMay = (DataTable)grdChung.DataSource;
                dtMay.PrimaryKey = new DataColumn[] { dtMay.Columns["MS_MAY"] };

                int index = dtMay.Rows.IndexOf(dtMay.Rows.Find(MsMay));
                grvChung.FocusedRowHandle = grvChung.GetRowHandle(index);
            }
        }

    }
}