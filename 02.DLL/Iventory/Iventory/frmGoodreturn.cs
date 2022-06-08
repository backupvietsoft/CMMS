using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace Iventory
{
    public partial class frmGoodreturn : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource BindingPhieuXuatKho = new BindingSource();
        private DataTable TbPhieuXuatKho = new DataTable();
        private DataTable TbPhieuXuatKhoPhuTung = new DataTable();
        private DataTable TbPhieuXuatKhoPhuTungChiTiet = new DataTable("CHI_TIET");
        private DataTable TbNhapVT = new DataTable();


        private string TrangThai = String.Empty;
        private string oldValue = "";
        private bool isFirst = false;
        int sl_ton = 0;

        public frmGoodreturn()
        {
            InitializeComponent();
        }
        private void InitData()
        {
            datFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datToDate.DateTime = DateTime.Now;
            DataTable tblKho = new DataTable();
            tblKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_KHO_DON_HANG_NHAP", Commons.Modules.UserName));
            lokWareHouse.Properties.DataSource = tblKho;
            lokWareHouse.Properties.DisplayMember = "TEN_KHO";
            lokWareHouse.Properties.ValueMember = "MS_KHO";

            cmbKho_Xuat.Properties.DataSource = tblKho;
            cmbKho_Xuat.Properties.DisplayMember = "TEN_KHO";
            cmbKho_Xuat.Properties.ValueMember = "MS_KHO";
            tblKho = new DataTable();
            tblKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_KHO", Commons.Modules.UserName));
            lokWareHouse.Properties.DataSource = tblKho;
            lokWareHouse.Properties.DisplayMember = "TEN_KHO";
            lokWareHouse.Properties.ValueMember = "MS_KHO";
            DataTable tblDangXuat = new DataTable();
            tblDangXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DANG_XUAT_KHO_X"));
            cmbDang_Xuat.Properties.DataSource = tblDangXuat;
            cmbDang_Xuat.Properties.ValueMember = "MS_DANG_XUAT";
            cmbDang_Xuat.Properties.DisplayMember = "TEN_DANG_XUAT";
            DataTable tblNguoiNhap = new DataTable();
            tblNguoiNhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NGUOI_NHAP"));
            cmbNguoiNhap.Properties.DataSource = tblNguoiNhap;
            cmbNguoiNhap.Properties.ValueMember = "MS_NGUOI_NHAP";
            cmbNguoiNhap.Properties.DisplayMember = "NGUOI_NHAP";
            txtNguoiLap.Enabled = false;
            DataTable tblPhieuBT = new DataTable();
            tblPhieuBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_PHIEU_BAO_TRI"));
            cmbPhieu_BT.Properties.ValueMember = "MA";
            cmbPhieu_BT.Properties.DisplayMember = "MA";
            cmbPhieu_BT.Properties.DataSource = tblPhieuBT;
            DataTable tblBPCP = new DataTable();
            tblBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI  FROM dbo.BO_PHAN_CHIU_PHI UNION SELECT '-1',''"));
            cmbBPCP.Properties.ValueMember = "MS_BP_CHIU_PHI";
            cmbBPCP.Properties.DisplayMember = "TEN_BP_CHIU_PHI";
            cmbBPCP.Properties.DataSource = tblBPCP;
            //TbNgoaiTe.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_NGOAI_TE_NHAP_KHO"));
            DataTable TbViTriKho = new DataTable();
            TbViTriKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VI_TRI_KHO"));
            repositoryItemLookUpEdit1.DataSource = TbViTriKho;
            repositoryItemLookUpEdit1.ValueMember = "MS_VI_TRI";
            repositoryItemLookUpEdit1.DisplayMember = "TEN_VI_TRI";
            LoadPhieuXuatKho();
            BindingPhieuXuatKho.CurrentChanged += new EventHandler(BindingPhieuXuatKho_CurrentChanged);
            TbPhieuXuatKho.TableNewRow += new DataTableNewRowEventHandler(TbPhieuXuatKho_TableNewRow);
            grdList.DataSource = BindingPhieuXuatKho;
            grvList.Columns["MS_DH_XUAT_PT"].FieldName = "MS_DH_XUAT_PT";
            BindingData();
            TbPhieuXuatKhoPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_XUAT_X_VAT_TU"));
            foreach (DataColumn ClPhieuXuatKhoPhuTung in TbPhieuXuatKhoPhuTung.Columns)
            {
                ClPhieuXuatKhoPhuTung.ReadOnly = false;
                ClPhieuXuatKhoPhuTung.AllowDBNull = true;
            }
            try
            {
                TbPhieuXuatKhoPhuTung.Columns["MS_DH_XUAT_PT"].DefaultValue = ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"];
                TbPhieuXuatKhoPhuTung.DefaultView.RowFilter = "MS_DH_XUAT_PT = '" + ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"] + "'";
            }
            catch
            {
                TbPhieuXuatKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            grdDetial.DataSource = TbPhieuXuatKhoPhuTung.DefaultView;

            TbPhieuXuatKhoPhuTungChiTiet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_XUAT_X_VAT_TU_CHI_TIET"));
            foreach (DataColumn ClPhieuXuatKhoPhuTungChiTiet in TbPhieuXuatKhoPhuTungChiTiet.Columns)
            {
                ClPhieuXuatKhoPhuTungChiTiet.ReadOnly = false;
                ClPhieuXuatKhoPhuTungChiTiet.AllowDBNull = true;
            }
            try
            {

                System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                TbPhieuXuatKhoPhuTungChiTiet.Columns["MS_DH_XUAT_PT"].DefaultValue = row["MS_DH_XUAT_PT"];
                TbPhieuXuatKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue = row["MS_PT"];
                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT = '" + row["MS_DH_XUAT_PT"].ToString().Trim() + "' AND MS_PT = '" + row["MS_PT"].ToString().Trim() + "'";

            }
            catch
            {
                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
            }

            grdDetialIndex.DataSource = TbPhieuXuatKhoPhuTungChiTiet;
            Enable(false);

        }
        private void LoadPhieuXuatKho()
        {
            try
            {
                TbPhieuXuatKho = new DataTable();
                int kho = -1;
                string s_kho = Convert.ToString(lokWareHouse.EditValue);
                bool isLock = chklock.Checked;
                if (!string.IsNullOrEmpty(s_kho))
                    kho = Convert.ToInt32(s_kho);
                TbPhieuXuatKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_XUAT_X", Commons.Modules.UserName, Convert.ToDateTime(datFromDate.DateTime.ToShortDateString()), Convert.ToDateTime(datToDate.DateTime.ToShortDateString()).AddDays(1), kho, isLock));
                TbPhieuXuatKho.TableNewRow += new DataTableNewRowEventHandler(TbPhieuXuatKho_TableNewRow);
                foreach (DataColumn ClPhieuXuatKho in TbPhieuXuatKho.Columns)
                {
                    ClPhieuXuatKho.AllowDBNull = true;
                }
                BindingPhieuXuatKho.DataSource = TbPhieuXuatKho;

            }
            catch { }

        }
        private void BindingData()
        {
            try
            {

                txtSo_Phieu_Xuat.DataBindings.Clear();
                txtSo_Phieu_Xuat.DataBindings.Add("Text", BindingPhieuXuatKho, "MS_DH_XUAT_PT");
                txtSo_Phieu.DataBindings.Clear();
                txtSo_Phieu.DataBindings.Add("Text", BindingPhieuXuatKho, "SO_PHIEU_XN");

                txtNguoiLap.DataBindings.Add("Text", BindingPhieuXuatKho, "USERNAME");
                txt_Ngay_Xuat.DataBindings.Clear();

                txt_Ngay_Xuat.DataBindings.Add("Text", BindingPhieuXuatKho, "NGAY", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy HH:mm");
                cmbKho_Xuat.DataBindings.Clear();
                cmbKho_Xuat.DataBindings.Add("EditValue", BindingPhieuXuatKho, "MS_KHO", true, DataSourceUpdateMode.OnPropertyChanged, null);

                cmbNguoiNhap.DataBindings.Clear();
                cmbNguoiNhap.DataBindings.Add("EditValue", BindingPhieuXuatKho, "NGUOI_NHAN", true, DataSourceUpdateMode.OnPropertyChanged, null);
                txtDate_Ngay_Chung_Tu.DataBindings.Clear();
                txtDate_Ngay_Chung_Tu.DataBindings.Add("Text", BindingPhieuXuatKho, "NGAY_CHUNG_TU", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy");
                cmbDang_Xuat.DataBindings.Clear();
                cmbDang_Xuat.DataBindings.Add("EditValue", BindingPhieuXuatKho, "MS_DANG_XUAT", true, DataSourceUpdateMode.OnPropertyChanged, null);
                txtSo_CT.DataBindings.Clear();
                txtSo_CT.DataBindings.Add("Text", BindingPhieuXuatKho, "SO_CHUNG_TU");
                cmbPhieu_BT.DataBindings.Clear();
                cmbPhieu_BT.DataBindings.Add("EditValue", BindingPhieuXuatKho, "MS_PHIEU_BAO_TRI", true, DataSourceUpdateMode.OnPropertyChanged, null);
                cmbBPCP.DataBindings.Clear();
                cmbBPCP.DataBindings.Add("EditValue", BindingPhieuXuatKho, "MS_BP_CHIU_PHI", true, DataSourceUpdateMode.OnPropertyChanged, null);
                // txtDiem_GH.DataBindings.Clear();
                // txtDiem_GH.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM");
                // txtDiem_CL.DataBindings.Clear();
                // txtDiem_CL.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM1");
                // txtDiem_GC.DataBindings.Clear();
                // txtDiem_GC.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM2");
                //  txtDanh_Gia.DataBindings.Clear();
                //  txtDanh_Gia.DataBindings.Add("Text", BindingPhieuNhapKho, "DANH_GIA");
                txtGhi_Chu.DataBindings.Clear();
                txtGhi_Chu.DataBindings.Add("Text", BindingPhieuXuatKho, "GHI_CHU");
            }
            catch { }
        }

        void TbPhieuXuatKho_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DH_XUAT_PT"] = Vietsoft.Information.GetID("PX");


        }
        void BindingPhieuXuatKho_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                TbPhieuXuatKhoPhuTung.Columns["MS_DH_XUAT_PT"].DefaultValue = ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"];
                TbPhieuXuatKhoPhuTung.DefaultView.RowFilter = "MS_DH_XUAT_PT = '" + ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"].ToString().Trim() + "'";

                //grdDetial.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
            }
            catch
            {
                TbPhieuXuatKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            try
            {
                System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                TbPhieuXuatKhoPhuTungChiTiet.Columns["MS_DH_XUAT_PT"].DefaultValue = row["MS_DH_XUAT_PT"];
                TbPhieuXuatKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue = row["MS_PT"];
                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT = '" + row["MS_DH_XUAT_PT"].ToString().Trim() + "' AND MS_PT = '" + row["MS_PT"].ToString().Trim() + "'";
            }
            catch
            {
                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
            }
            InitControl();
        }
        private void InitControl()
        {
            try
            {
                if (!((DataRowView)BindingPhieuXuatKho.Current).Row.IsNull("LOCK") && ((DataRowView)BindingPhieuXuatKho.Current).Row["LOCK"].Equals(true))
                {
                    btnLock.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    btnChon_PT.Visible = false;
                    btnAuto.Visible = false;
                    btnAdd.Visible = false;
                }
                else
                {
                    btnLock.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = true;
                    btnCancel.Visible = true;
                    btnChon_PT.Visible = true;
                    btnAuto.Visible = true;
                    btnAdd.Visible = true;
                }
                btnPrint.Enabled = true;
                btnEdit.Enabled = btnDelete.Enabled = btnLock.Enabled = true;
            }
            catch
            {
                btnLock.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnChon_PT.Visible = true;
                btnAuto.Visible = true;
                btnAdd.Visible = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnPrint.Enabled = false;
                btnLock.Enabled = false;
            }
        }
        private void Enable(bool enable)
        {
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable;
            btnDelete.Enabled = !enable;
            btnPrint.Enabled = !enable;
            btnExit.Enabled = !enable;
            btnLock.Enabled = !enable;
            btnLock.Enabled = !enable;
            lokWareHouse.Enabled = !enable;
            datFromDate.Enabled = !enable;
            datToDate.Enabled = !enable;
            chklock.Enabled = !enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            btnChon_PT.Enabled = enable;
            btnAuto.Enabled = enable;
            txtDate_Ngay_Chung_Tu.Properties.ReadOnly = !enable;
            txt_Ngay_Xuat.Properties.ReadOnly = !enable;

            // txtNguoiLap.Properties.ReadOnly = !enable;
            // txtSo_Phieu_Xuat.Properties.ReadOnly = !enable;
            txtSo_Phieu.Properties.ReadOnly = !enable;
            txtSo_CT.Properties.ReadOnly = !enable;

            txtGhi_Chu.Properties.ReadOnly = !enable;
            if (!TrangThai.Equals("Edit"))
            {
                cmbDang_Xuat.Properties.ReadOnly = !enable;
                cmbNguoiNhap.Properties.ReadOnly = !enable;
                cmbKho_Xuat.Properties.ReadOnly = !enable;
                cmbPhieu_BT.Properties.ReadOnly = !enable;
                cmbBPCP.Properties.ReadOnly = !enable;
            }
            if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
            {
                grvDetial.OptionsBehavior.Editable = true;
                grvDetialIndex.OptionsBehavior.Editable = true;
            }
            else
            {
                grvDetial.OptionsBehavior.Editable = false;
                grvDetialIndex.OptionsBehavior.Editable = false;
            }
            //cmbDang_Xuat.Enabled = enable;
            //cmbNguoiNhap.Enabled = enable;
            //cmbKho_Xuat.Enabled = enable;
            //cmbPhieu_BT.Enabled = enable;
            //cmbBPCP.Enabled = enable;



        }
        private void frmGoodreturn_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
            isFirst = true;
            SetLanguage();
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            //Commons.Modules.m
        }
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtSo_Phieu.Text))
            {
                Vietsoft.Information.MsgBox(this, "MsgSoPhieuNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                txtSo_Phieu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbKho_Xuat.EditValue)))
            {

                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho_Xuat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbDang_Xuat.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgDangXuat", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbDang_Xuat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbNguoiNhap.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgNguoiNhap", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbNguoiNhap.Focus();
                return false;
            }

            // if (!isAuto)
            // {
            for (int j = 0; j < grvDetial.RowCount; j++)
            {
                if (Convert.ToDouble(grvDetial.GetRowCellValue(j, "SO_LUONG_THUC_XUAT")) == 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSLTHUCXUATLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else
                {
                    DataView DgvTmp = new DataView(TbPhieuXuatKhoPhuTungChiTiet, "MS_DH_XUAT_PT = '" + grvDetial.GetRowCellValue(j, "MS_DH_XUAT_PT").ToString().Trim() + "' AND MS_PT = '" + grvDetial.GetRowCellValue(j, "MS_PT").ToString().Trim() + "'", "", DataViewRowState.CurrentRows);
                    double SlVT = 0;
                    for (int i = 0; i < DgvTmp.Count; i++)
                    {
                        try
                        {
                            SlVT = SlVT + Convert.ToDouble(DgvTmp[i].Row["SL_VT"]);
                        }
                        catch
                        {
                            SlVT = SlVT + 0;
                        }
                    }
                    if (Convert.ToDouble(grvDetial.GetRowCellValue(j, "SO_LUONG_THUC_XUAT")) != SlVT)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSLKhongCan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        grvDetial.FocusedRowHandle = j;
                        grvDetial.FocusedColumn = grvDetial.Columns["SO_LUONG_THUC_XUAT"];
                        //DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SL_THUC_NHAP"];

                        return false;
                    }
                }
            }
            // }
            return true;

        }
        private void chklock_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhieuXuatKho();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BindingPhieuXuatKho.AddNew();
            TrangThai = "Add";
            Enable(true);
            txt_Ngay_Xuat.DateTime = DateTime.Now;
            txtNguoiLap.Text = Commons.Modules.UserName;
            txtDate_Ngay_Chung_Tu.DateTime = DateTime.Now;
            txtSo_Phieu.Focus();
            grdList.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TrangThai = "Edit";
            Enable(true);
            grdList.Enabled = false;
            oldValue = txtSo_Phieu.Text;
            txt_Ngay_Xuat.Properties.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Vietsoft.SqlInfo SqlPhieuXuatKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                SqlPhieuXuatKho.BeginTransaction();
                try
                {
                    DataTable TbPhieuXuatKhoPhuTungTMP = TbPhieuXuatKhoPhuTung.DefaultView.ToTable(true, "MS_DH_XUAT_PT", "MS_PT", "SO_LUONG_CTU", "SO_LUONG_THUC_XUAT", "GHI_CHU");
                    //DataTable TbPhieuXuatKhoTemp = TbPhieuXuatKho.DefaultView.ToTable(true, "MS_DH_XUAT_PT", "SO_PHIEU_XN", "NGAY", "GIO", "MS_KHO", "MS_DANG_XUAT",
                    //  "NGUOI_NHAN", "NGAY_CHUNG_TU", "SO_CHUNG_TU", "MS_PHIEU_BAO_TRI", "GHI_CHU", "LOCK", "LY_DO_XUAT", "THU_KHO", "MS_BP_CHIU_PHI", "USERNAME");
                    //DataTable TbPhieuXuatKhoPhuTungChiTietTMP = TbPhieuXuatKhoPhuTungChiTiet.DefaultView.ToTable(true, "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI", "SL_VT");
                    DataRow row = TbPhieuXuatKho.NewRow();
                    row["MS_DH_XUAT_PT"] = txtSo_Phieu_Xuat.Text;
                    row["SO_PHIEU_XN"] = txtSo_Phieu.Text;
                    row["NGAY"] = txt_Ngay_Xuat.DateTime;
                    row["GIO"] = txt_Ngay_Xuat.DateTime;
                    row["MS_KHO"] = cmbKho_Xuat.EditValue;
                    //row["TEN_KHO"] = cmbNhapKho.Text;
                    row["MS_DANG_XUAT"] = cmbDang_Xuat.EditValue;
                    row["NGUOI_NHAN"] = cmbNguoiNhap.EditValue;
                    row["NGAY_CHUNG_TU"] = txtDate_Ngay_Chung_Tu.DateTime;
                    row["SO_CHUNG_TU"] = txtSo_CT.Text;
                    row["MS_PHIEU_BAO_TRI"] = cmbPhieu_BT.EditValue;
                    row["GHI_CHU"] = txtGhi_Chu.Text;
                    row["LOCK"] = false;
                    row["LY_DO_XUAT"] = "";
                    //row["DA_HET"] = false;
                    row["THU_KHO"] = "";
                    row["MS_BP_CHIU_PHI"] = cmbBPCP.EditValue;
                    row["USERNAME"] = txtNguoiLap.Text;
                    //row["NGUOI_GIAO"] = cmbNguoiNhap.EditValue;
                    //row["BSXE"] = "";
                    //row["DIEM1"] = Convert.ToInt32(txtDiem_CL.Text);
                    //row["DIEM2"] = Convert.ToInt32(txtDiem_GC.Text);

                    DataTable _table = new DataTable();
                    //string pt = "", pn = "", vt = "", fpt = "", fpn = "", fvt = ""; 
                    int temp = 1;//,sl_thuc_ton=0;
                    decimal? sl_thuc_ton = 0; double? sl_thuc_xuat = 0;
                    switch (TrangThai)
                    {
                        case "Add":
                            Vietsoft.DataInfo.InsertDataRow(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X", row);
                            Vietsoft.DataInfo.InsertDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X_VAT_TU", TbPhieuXuatKhoPhuTungTMP.DefaultView);
                            //Vietsoft.DataInfo.InsertDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", new DataView(TbPhieuXuatKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows));
                            _table = new DataView(TbPhieuXuatKhoPhuTungChiTiet, "MS_DH_XUAT_PT = '" + row["MS_DH_XUAT_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows).ToTable();
                            _table.Columns.Add("STT");
                            foreach (DataRow _row in _table.Rows)
                            {

                                temp = temp + 1;
                                _row["STT"] = temp;
                            }
                            _table.DefaultView.RowFilter = "SL_VT>0";
                            Vietsoft.DataInfo.InsertDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", _table.DefaultView);
                            //        Vietsoft.DataInfo.InsertDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_VI_TRI_KHO_VAT_TU_X",_table.DefaultView);
                            foreach (DataRow _datarow in _table.DefaultView.ToTable().Rows)
                            {

                                // sl_thuc_xuat = (double?)SqlPhieuXuatKho.ExecuteScalar(CommandType.StoredProcedure, "SP_NHU_Y_GET_SL_THUC_XUAT", txtSo_Phieu_Xuat.Text,
                                //                                  _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"]);
                                sl_thuc_ton = (decimal?)SqlPhieuXuatKho.ExecuteScalar(CommandType.StoredProcedure, "SP_NHU_Y_GET_SO_LUONG_TON",
                                                                 _datarow["MS_DH_NHAP_PT"], _datarow["MS_VI_TRI"], _datarow["MS_PT"]);

                                decimal ton = sl_thuc_ton == null ? 0 : (decimal)sl_thuc_ton;
                                float xuat = sl_thuc_xuat == null ? 0 : (float)sl_thuc_xuat;
                                // double sl = (double)ton + xuat - Convert.ToDouble(_datarow["SL_VT"]);
                                double sl = (double)ton - Convert.ToDouble(_datarow["SL_VT"]);
                                if (sl < 0)
                                {
                                    SqlPhieuXuatKho.RollbackTransaction();
                                    Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                                SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_EDIT_VI_TRI_KHO_VAT_TU_X", _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"], sl);
                            }
                            break;
                        case "Edit":
                            Vietsoft.DataInfo.UpdateDataRow(SqlPhieuXuatKho, "SP_NHU_Y_EDIT_DON_HANG_XUAT_X", row);
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X_VAT_TU", "SP_NHU_Y_EDIT_DON_HANG_XUAT_X_VAT_TU", "SP_NHU_Y_CHECK_DON_HANG_XUAT_X_VAT_TU", TbPhieuXuatKhoPhuTungTMP.DefaultView, "MS_DH_XUAT_PT", "MS_PT");
                            _table = new DataView(TbPhieuXuatKhoPhuTungChiTiet, "MS_DH_XUAT_PT = '" + row["MS_DH_XUAT_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows).ToTable();
                            _table.Columns.Add("STT");
                            temp = 0;
                            foreach (DataRow _row in _table.Rows)
                            {
                                temp = temp + 1;
                                _row["STT"] = temp;
                            }
                            // _table.DefaultView.RowFilter = "SL_VT>0";

                            foreach (DataRow _datarow in _table.DefaultView.ToTable().Rows)
                            {

                                sl_thuc_xuat = (double?)SqlPhieuXuatKho.ExecuteScalar(CommandType.StoredProcedure, "SP_NHU_Y_GET_SL_THUC_XUAT", txtSo_Phieu_Xuat.Text,
                                                                 _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"]);
                                sl_thuc_ton = (decimal?)SqlPhieuXuatKho.ExecuteScalar(CommandType.StoredProcedure, "SP_NHU_Y_GET_SO_LUONG_TON",
                                                                 _datarow["MS_DH_NHAP_PT"], _datarow["MS_VI_TRI"], _datarow["MS_PT"]);

                                decimal ton = sl_thuc_ton == null ? 0 : (decimal)sl_thuc_ton;
                                float xuat = sl_thuc_xuat == null ? 0 : (float)sl_thuc_xuat;
                                double sl = (double)ton + xuat - Convert.ToDouble(_datarow["SL_VT"]);
                                if (sl < 0)
                                {
                                    SqlPhieuXuatKho.RollbackTransaction();
                                    Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                                SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_EDIT_VI_TRI_KHO_VAT_TU_X", _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"], sl);
                            }
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuXuatKho, "SP_NHU_Y_INSERT_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", "SP_NHU_Y_EDIT_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", "SP_NHU_Y_CHECK_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", _table.DefaultView, "MS_DH_XUAT_PT", "MS_PT", "MS_VI_TRI", "MS_DH_NHAP_PT");
                            break;
                    }
                    SqlPhieuXuatKho.CommitTransaction();
                    BindingPhieuXuatKho.EndEdit();
                    TbPhieuXuatKho.AcceptChanges();
                    TbPhieuXuatKhoPhuTung.AcceptChanges();
                    TbPhieuXuatKhoPhuTungChiTiet.AcceptChanges();
                    TrangThai = String.Empty;

                    Enable(false);
                    grdList.Enabled = true;
                    TrangThai = "";
                    // isAuto = false;
                }
                catch
                {
                    SqlPhieuXuatKho.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindingPhieuXuatKho.CancelEdit();
            TbPhieuXuatKho.RejectChanges();
            TbPhieuXuatKhoPhuTung.RejectChanges();
            TbPhieuXuatKhoPhuTungChiTiet.RejectChanges();
            TrangThai = String.Empty;
            Enable(false);
            grdList.Enabled = true;
            if (grvList.RowCount == 0)
                btnLock.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnPrint.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Vietsoft.SqlInfo SqlPhieuXuatKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                SqlPhieuXuatKho.BeginTransaction();
                try
                {
                    //string SOPN = ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"].ToString();
                    // SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_VI_TRI_KHO_VAT_TU_X", SOPN);
                    int sl_thuc_ton = 0;
                    TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "'";
                    DataTable _table = TbPhieuXuatKhoPhuTungChiTiet.DefaultView.ToTable();
                    foreach (DataRow _datarow in _table.Rows)
                    {

                        DataTable _table_slton = new DataTable();
                        _table_slton.Load(SqlPhieuXuatKho.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_SO_LUONG_TON",
                            _datarow["MS_DH_NHAP_PT"], _datarow["MS_VI_TRI"], _datarow["MS_PT"]));
                        if (_table_slton.Rows.Count > 0)
                            sl_thuc_ton = Convert.ToInt32(_table_slton.Rows[0][0]);
                        else
                            sl_thuc_ton = 0;
                        int sl = sl_thuc_ton + Convert.ToInt32(_datarow["SL_VT"]);
                        SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_EDIT_VI_TRI_KHO_VAT_TU_X", _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"], sl);
                    }


                    SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_DON_HANG_XUAT_X_VAT_TU_CHI_TIET", txtSo_Phieu_Xuat.Text);
                    SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_DON_HANG_XUAT_X_VAT_TU", txtSo_Phieu_Xuat.Text);
                    SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_DON_HANG_XUAT_X", txtSo_Phieu_Xuat.Text);
                    Vietsoft.DataInfo.ClearData(new DataView(TbPhieuXuatKhoPhuTungChiTiet, "MS_DH_XUAT_PT = '" + ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows));
                    Vietsoft.DataInfo.ClearData(TbPhieuXuatKhoPhuTung.DefaultView);
                    BindingPhieuXuatKho.RemoveCurrent();
                    TbPhieuXuatKho.AcceptChanges();
                    TbPhieuXuatKhoPhuTung.AcceptChanges();
                    TbPhieuXuatKhoPhuTungChiTiet.AcceptChanges();
                    SqlPhieuXuatKho.CommitTransaction();
                    //InitializeForm();
                }
                catch
                {
                    SqlPhieuXuatKho.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo PX = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(PX.ExecuteReader(CommandType.StoredProcedure, "MashjBCXuat", ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuXuat";

             
            frmReport frmRptPhieuXuat = new frmReport();
            frmRptPhieuXuat.rptName = "rptPhieuXuatKhoX";
            frmRptPhieuXuat.AddDataTableSource(TbSource);

            TbSource = new DataTable();
            TbSource.Load(PX.ExecuteReader(CommandType.StoredProcedure, "MashjBCXuatCT", ((DataRowView)BindingPhieuXuatKho.Current).Row["MS_DH_XUAT_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuXuatCT";
            frmRptPhieuXuat.AddDataTableSource(TbSource);

            DataTable TbTieuDe = CreateTitle();
            frmRptPhieuXuat.AddDataTableSource(TbTieuDe);
            frmRptPhieuXuat.ShowDialog(this);


            
        }

        private static DataTable CreateTitle()
        {
            DataTable TbTieuDe = new DataTable();            
            TbTieuDe.Columns.Add("MAU_SO");
            TbTieuDe.Columns.Add("NGAY_BH");
            TbTieuDe.Columns.Add("LAN_BH");
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("SO_PX");
            TbTieuDe.Columns.Add("NGAY_IN");
            TbTieuDe.Columns.Add("NO");
            TbTieuDe.Columns.Add("CO");
            TbTieuDe.Columns.Add("NGUOI_NHAN");
            TbTieuDe.Columns.Add("SO_CHUNG_TU");
            TbTieuDe.Columns.Add("DANG_XUAT");
            TbTieuDe.Columns.Add("LY_DO_XUAT");
            TbTieuDe.Columns.Add("NGAY_XUAT");
            TbTieuDe.Columns.Add("KHO");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("SL_CTU");
            TbTieuDe.Columns.Add("SL_THUC_TT");
            TbTieuDe.Columns.Add("DON_GIA");
            TbTieuDe.Columns.Add("NGOAI_TE");            
            TbTieuDe.Columns.Add("THANH_TIEN");
            TbTieuDe.Columns.Add("THANH_TIEN_VND");
            TbTieuDe.Columns.Add("TONG_TIEN");
            TbTieuDe.Columns.Add("NGAY_THANG_NAM");
            TbTieuDe.Columns.Add("PHU_TRACH_BO_PHAN");            
            TbTieuDe.Columns.Add("NGUOI_LAP");            
            TbTieuDe.Columns.Add("NGUOI_NHAN_KT");            
            TbTieuDe.Columns.Add("THU_KHO");
            TbTieuDe.Columns.Add("KY_TEN");


            DataRow rTitle = TbTieuDe.NewRow();

            rTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "MAU_SO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGAY_BH", Commons.Modules.TypeLanguage);
            rTitle["LAN_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "LAN_BH", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["SO_PX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "SO_PX", Commons.Modules.TypeLanguage);
            rTitle["NGAY_IN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGAY_IN", Commons.Modules.TypeLanguage);
            rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NO", Commons.Modules.TypeLanguage);
            rTitle["CO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "CO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGUOI_NHAN", Commons.Modules.TypeLanguage);
            rTitle["SO_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "SO_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["DANG_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "DANG_XUAT", Commons.Modules.TypeLanguage);
            rTitle["LY_DO_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "LY_DO_XUAT", Commons.Modules.TypeLanguage);
            rTitle["NGAY_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGAY_XUAT", Commons.Modules.TypeLanguage);
            rTitle["KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "KHO", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "MS_PT", Commons.Modules.TypeLanguage);            
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["SL_CTU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "SL_CTU", Commons.Modules.TypeLanguage);
            rTitle["SL_THUC_TT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "SL_THUC_TT", Commons.Modules.TypeLanguage);
            rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "DON_GIA", Commons.Modules.TypeLanguage);
            rTitle["NGOAI_TE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGOAI_TE", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "THANH_TIEN", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "THANH_TIEN_VND", Commons.Modules.TypeLanguage);
            rTitle["TONG_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "TONG_TIEN", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage);
            rTitle["PHU_TRACH_BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "PHU_TRACH_BO_PHAN", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGUOI_LAP", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAN_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "NGUOI_NHAN", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["KY_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuXuatKhoX", "KY_TEN", Commons.Modules.TypeLanguage);



            TbTieuDe.TableName = "rptTieuDePhieuXuat";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }
        private void btnChonPT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(cmbKho_Xuat.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho_Xuat.Focus();
                return;
            }
            frmChooseAccessory_Issued frmPhuTung = new frmChooseAccessory_Issued();
            frmPhuTung.CurrentSource = TbPhieuXuatKhoPhuTung.DefaultView.ToTable();
            frmPhuTung.Ngay = txt_Ngay_Xuat.DateTime;
            frmPhuTung.Kho = Convert.ToInt16(cmbKho_Xuat.EditValue);

            if (frmPhuTung.ShowDialog() == DialogResult.OK)
            {
                frmPhuTung.DataSource.DefaultView.RowFilter = "CHON = true";
                for (int i = 0; i < frmPhuTung.DataSource.DefaultView.Count; i++)
                {
                    if (TbPhieuXuatKhoPhuTung.Columns.Count > 0)
                    {
                        DataRow rPhieuXuatKhoPhuTung = TbPhieuXuatKhoPhuTung.NewRow();
                        rPhieuXuatKhoPhuTung["MS_DH_XUAT_PT"] = txtSo_Phieu_Xuat.Text;
                        rPhieuXuatKhoPhuTung["MS_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];
                        rPhieuXuatKhoPhuTung["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                        //rPhieuXuatKhoPhuTung["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];

                        //rPhieuXuatKhoPhuTung["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT_NCC"];
                        rPhieuXuatKhoPhuTung["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_DV"];
                        rPhieuXuatKhoPhuTung["SO_LUONG_CTU"] = 0;
                        rPhieuXuatKhoPhuTung["SO_LUONG_THUC_XUAT"] = 0;
                        //rPhieuXuatKhoPhuTung["DON_GIA"] = 0;
                        // rPhieuXuatKhoPhuTung["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"];
                        try
                        {
                            rPhieuXuatKhoPhuTung["VI_TRI"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_VI_TRI"];
                        }
                        catch
                        { }




                        TbNhapVT = new DataTable();
                        TbNhapVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_VI_TRI_PT_XUAT_X", rPhieuXuatKhoPhuTung["MS_PT"], cmbKho_Xuat.EditValue.ToString()));
                        TbNhapVT.Columns.Add("MS_DH_XUAT_PT");
                        double sl = 0;
                        //TbAutoPhuTungTemp = TbPhieuXuatKhoPhuTungChiTiet.Copy();
                        foreach (DataRow rNhapPT in TbNhapVT.Rows)
                        {
                            rNhapPT["MS_DH_XUAT_PT"] = txtSo_Phieu_Xuat.Text;
                            DataRow rPhieuXuatKhoPhuTungChiTiet = TbPhieuXuatKhoPhuTungChiTiet.NewRow();
                            rPhieuXuatKhoPhuTungChiTiet["MS_DH_XUAT_PT"] = txtSo_Phieu_Xuat.Text;
                            rPhieuXuatKhoPhuTungChiTiet["MS_DH_NHAP_PT"] = rNhapPT["MS_DH_NHAP_PT"];
                            rPhieuXuatKhoPhuTungChiTiet["MS_PT"] = rPhieuXuatKhoPhuTung["MS_PT"];
                            rPhieuXuatKhoPhuTungChiTiet["MS_VI_TRI"] = rNhapPT["MS_VI_TRI"];
                            rPhieuXuatKhoPhuTungChiTiet["SL_VT"] = rNhapPT["SL_VT"];
                            rPhieuXuatKhoPhuTungChiTiet["SL_TON"] = rNhapPT["SL_VT"];
                            sl += Convert.ToDouble(rNhapPT["SL_VT"]);
                            TbPhieuXuatKhoPhuTungChiTiet.Rows.Add(rPhieuXuatKhoPhuTungChiTiet);
                        }
                        rPhieuXuatKhoPhuTung["SL_TT"] = sl;
                        TbPhieuXuatKhoPhuTungChiTiet.DefaultView.Sort = "MS_DH_NHAP_PT";
                        TbPhieuXuatKhoPhuTung.Rows.Add(rPhieuXuatKhoPhuTung);
                    }
                }

                cmbKho_Xuat.Properties.ReadOnly = true;
                txt_Ngay_Xuat.Properties.ReadOnly = true;

            }
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            //DataRow _row = ((DataRowView)BindingPhieuXuatKho.Current).Row;
            // _row["LOCK"] = true;
            Vietsoft.SqlInfo SqlPhieuXuatKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            SqlPhieuXuatKho.BeginTransaction();
            try
            {
                //Vietsoft.DataInfo.UpdateDataRow(SqlPhieuXuatKho, "SP_NHU_Y_EDIT_DON_HANG_XUAT_X", _row);

                SqlPhieuXuatKho.ExecuteNonQuery(CommandType.Text, "UPDATE IC_DON_HANG_XUAT_X SET LOCK= 1  WHERE MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "'");
                SqlPhieuXuatKho.CommitTransaction();
                BindingPhieuXuatKho.RemoveCurrent();
                TbPhieuXuatKho.AcceptChanges();
                TbPhieuXuatKhoPhuTung.AcceptChanges();
                TbPhieuXuatKhoPhuTungChiTiet.AcceptChanges();

            }
            catch
            {
                SqlPhieuXuatKho.RollbackTransaction();
                TbPhieuXuatKho.RejectChanges();
                Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvDetial_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                //TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)DgvPhieuNhapKhoChiTiet.CurrentRow.DataBoundItem).Row["MS_DH_NHAP_PT"];
                // TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue =row["MS_PT"];

                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_PT = '" + row["MS_PT"] + "' and MS_DH_XUAT_PT='" + row["MS_DH_XUAT_PT"] + "'";
                grdDetialIndex.DataSource = TbPhieuXuatKhoPhuTungChiTiet;

            }
            catch
            {
                TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
            }
        }
        private void grvDetial_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string column = e.Column.FieldName;
            System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);

            switch (column)
            {
                case "SO_LUONG_CTU":
                    if (Convert.ToInt32(e.Value) > 0)
                        row["SO_LUONG_THUC_XUAT"] = e.Value.ToString();
                    else
                        row["SO_LUONG_CTU"] = 0;
                    break;
                case "SO_LUONG_THUC_XUAT":
                    if (Convert.ToInt32(e.Value.ToString()) < 0)
                    {

                        Vietsoft.Information.MsgBox(this, "MsgSLTXNhoSLCTU", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        row["SO_LUONG_THUC_XUAT"] = 0;
                        return;

                    } break;
            }
        }
        private void btnAuto_Click(object sender, EventArgs e)
        {
            try
            {

                int sl = 0;
                TbPhieuXuatKhoPhuTung.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "'";

                foreach (DataRow _parent_row in TbPhieuXuatKhoPhuTung.DefaultView.ToTable().Rows)
                {
                    TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "' AND MS_PT='" + _parent_row["MS_PT"] + "' ";
                    sl = Convert.ToInt32(_parent_row["SO_LUONG_THUC_XUAT"]);
                    for (int i = 0; i < TbPhieuXuatKhoPhuTungChiTiet.DefaultView.Count; i++)
                    {
                        DataRow _row = TbPhieuXuatKhoPhuTungChiTiet.DefaultView[i].Row;

                        int _sl_ton = Convert.ToInt32(_row["SL_TON"]);
                        if (sl >= _sl_ton)
                        {
                            sl = sl - _sl_ton;
                            //_myrow["SL_VT"] = _sl_ton;
                            _row["SL_VT"] = _sl_ton;
                        }
                        else
                        {
                            _row["SL_VT"] = sl;

                            sl = sl - Convert.ToInt32(_row["SL_VT"]);
                        }


                    }
                }

            }
            catch
            {

            }
        }
        private void lokWareHouse_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuXuatKho();
        }
        private void datFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > datToDate.DateTime)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }
        private void datToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < datFromDate.DateTime)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }
        private void SetLanguage()
        {
            grbFillter.Text = groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "dieukienloc", Commons.Modules.TypeLanguage);
            grbOutput.Text = groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "thongtinphieuxuat", Commons.Modules.TypeLanguage);
            btnAdd.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnAdd", Commons.Modules.TypeLanguage);
            btnEdit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnEdit", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnExit", Commons.Modules.TypeLanguage);
            btnDelete.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnDelete", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnCancel", Commons.Modules.TypeLanguage);
            btnAuto.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnAuto", Commons.Modules.TypeLanguage);
            btnChon_PT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnChon_PT", Commons.Modules.TypeLanguage);
            btnLock.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnLock", Commons.Modules.TypeLanguage);
            btnPrint.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnPrint", Commons.Modules.TypeLanguage);
            btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "btnSave", Commons.Modules.TypeLanguage);
            chklock.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "chklock", Commons.Modules.TypeLanguage);
            tapList.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "Danhsachphieuxuat", Commons.Modules.TypeLanguage);
            tapDetial.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "Chitietvattuxuat", Commons.Modules.TypeLanguage);
            groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "vattuphutungxuat", Commons.Modules.TypeLanguage);
            grvList.Columns["MS_DH_XUAT_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "donhangxuat", Commons.Modules.TypeLanguage);
            grvList.Columns["SO_PHIEU_XN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "sophieuxuat", Commons.Modules.TypeLanguage);
            grvList.Columns["TEN_NGUOI_NHAP"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "tennguoinhap", Commons.Modules.TypeLanguage);
            grvList.Columns["NGAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "Ngayxuat", Commons.Modules.TypeLanguage);
            grvList.Columns["DANG_XUAT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "dang_xuat", Commons.Modules.TypeLanguage);
            // tabList.SelectedTabPageIndex = 1;
            grvDetial.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "maphutung", Commons.Modules.TypeLanguage);
            grvDetial.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "tenphutung", Commons.Modules.TypeLanguage);
            grvDetial.Columns["SO_LUONG_CTU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "soluongchungtu", Commons.Modules.TypeLanguage);
            grvDetial.Columns["SO_LUONG_THUC_XUAT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "soluongthucxuat", Commons.Modules.TypeLanguage);
            grvDetial.Columns["SL_TT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "sltt", Commons.Modules.TypeLanguage);
            grvDetial.Columns["DVT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "donvitinhb", Commons.Modules.TypeLanguage);
            grvDetial.Columns["Ghi_Chu"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "ghichu", Commons.Modules.TypeLanguage);

            grvDetialIndex.Columns["MS_DH_NHAP_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "donhangnhappt", Commons.Modules.TypeLanguage);
            grvDetialIndex.Columns["MS_VI_TRI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "vitri", Commons.Modules.TypeLanguage);
            grvDetialIndex.Columns["SL_TON"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "soluongton", Commons.Modules.TypeLanguage);
            grvDetialIndex.Columns["SL_VT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "soluongxuat", Commons.Modules.TypeLanguage);
            groupControl1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreturn", "chitietnhapvattuphutung", Commons.Modules.TypeLanguage);
            //tabList.SelectedTabPageIndex = 0;
        }
        private void txtSo_Phieu_Validated(object sender, EventArgs e)
        {
            if (txtSo_Phieu.Text.Trim() != "")
            {
                if (TrangThai.Equals("Add"))
                {

                    Vietsoft.SqlInfo Sql = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                    System.Data.DataTable Tb = new System.Data.DataTable();
                    Tb.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_CHECK_SO_DON_HANG_XUAT", txtSo_Phieu.Text.Trim()));
                    if (Tb.Rows.Count > 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSoDHXTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtSo_Phieu.Focus();
                        return;
                    }
                }
                else
                {
                    if (TrangThai.Equals("Edit"))
                    {
                        if (!txtSo_Phieu.Text.Trim().Equals(oldValue))
                        {
                            Vietsoft.SqlInfo Sql = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                            System.Data.DataTable Tb = new System.Data.DataTable();
                            Tb.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_CHECK_SO_DON_HANG_XUAT", txtSo_Phieu.Text.Trim()));
                            if (Tb.Rows.Count > 0)
                            {
                                Vietsoft.Information.MsgBox(this, "MsgSoDHXTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                txtSo_Phieu.Focus();
                                return;
                            }
                        }
                    }
                }
            }
        }
        private void datFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (datFromDate.DateTime > datToDate.DateTime)
                    {
                        // Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //datFromDate.Focus();
                    }
                    else
                        LoadPhieuXuatKho();
                }
            }
            catch { }
        }
        private void datToDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (datFromDate.DateTime > datToDate.DateTime)
                    {
                        // Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //datToDate.Focus();
                    }
                    else
                        LoadPhieuXuatKho();
                }
            }
            catch { }
        }
        private void grvDetialIndex_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string column = e.Column.FieldName;
            System.Data.DataRow row = grvDetialIndex.GetDataRow(grvDetialIndex.FocusedRowHandle);
            DataTable _table_sl = new DataTable();
            int sl_xuat = 0;
            _table_sl.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_SL_THUC_XUAT", txtSo_Phieu_Xuat.Text,
                                             row["MS_DH_NHAP_PT"], row["MS_PT"], row["MS_VI_TRI"]));
            if (_table_sl.Rows.Count > 0)
                sl_xuat = Convert.ToInt32(_table_sl.Rows[0][0]);

            DataTable _tableSL = new DataTable();
            _tableSL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_SO_LUONG_TON", row["MS_DH_NHAP_PT"], row["MS_VI_TRI"], row["MS_PT"]));
            if (_tableSL.Rows.Count > 0)
                sl_ton = Convert.ToInt32(_tableSL.Rows[0][0]) + sl_xuat;
            switch (column)
            {
                case "SL_VT":
                    if (Convert.ToInt32(e.Value) >= 0 && Convert.ToInt32(e.Value) <= sl_ton)
                        row["SL_VT"] = e.Value.ToString();
                    else
                        row["SL_VT"] = sl_ton;
                    break;

            }
        }

        private void grvDetial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Vietsoft.SqlInfo SqlPhieuXuatKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                    SqlPhieuXuatKho.BeginTransaction();
                    try
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        DataRow row = view.GetFocusedDataRow();
                        TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "'  and MS_PT='" + row["MS_PT"] + "'";
                        DataTable _table = TbPhieuXuatKhoPhuTungChiTiet.DefaultView.ToTable();
                        SqlPhieuXuatKho.ExecuteNonQuery(CommandType.Text, "DELETE IC_DON_HANG_XUAT_X_VAT_TU_CHI_TIET WHERE MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "' AND MS_PT='" + row["MS_PT"] + "'");
                        SqlPhieuXuatKho.ExecuteNonQuery(CommandType.Text, "DELETE IC_DON_HANG_XUAT_X_VAT_TU WHERE MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "' AND MS_PT='" + row["MS_PT"] + "'");
                        int sl_thuc_ton = 0;
                        //TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "'";
                        // DataTable _table = TbPhieuXuatKhoPhuTungChiTiet.DefaultView.ToTable();
                        foreach (DataRow _datarow in _table.Rows)
                        {

                            DataTable _table_slton = new DataTable();
                            _table_slton.Load(SqlPhieuXuatKho.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_SO_LUONG_TON",
                                _datarow["MS_DH_NHAP_PT"], _datarow["MS_VI_TRI"], _datarow["MS_PT"]));
                            if (_table_slton.Rows.Count > 0)
                                sl_thuc_ton = Convert.ToInt32(_table_slton.Rows[0][0]);
                            else
                                sl_thuc_ton = 0;
                            int sl = sl_thuc_ton + Convert.ToInt32(_datarow["SL_VT"]);
                            SqlPhieuXuatKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_EDIT_VI_TRI_KHO_VAT_TU_X", _datarow["MS_DH_NHAP_PT"], _datarow["MS_PT"], _datarow["MS_VI_TRI"], sl);
                        }

                        TbPhieuXuatKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_XUAT_PT='" + txtSo_Phieu_Xuat.Text + "' AND MS_PT='" + row["MS_PT"] + "'";

                        foreach (DataRow _row in TbPhieuXuatKhoPhuTungChiTiet.Rows)
                        {
                            if (_row["MS_DH_XUAT_PT"].Equals(txtSo_Phieu_Xuat.Text) && _row["MS_PT"].Equals(row["MS_PT"]))
                                _row.Delete();
                        }
                        view.DeleteSelectedRows();
                        TbPhieuXuatKho.AcceptChanges();
                        TbPhieuXuatKhoPhuTung.AcceptChanges();
                        TbPhieuXuatKhoPhuTungChiTiet.AcceptChanges();
                        SqlPhieuXuatKho.CommitTransaction();
                    }
                    catch
                    {
                        SqlPhieuXuatKho.RollbackTransaction();
                        Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }


     
        private void grvDetialIndex_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;


            string fieldName = view.FocusedColumn.FieldName;
            if (fieldName.Equals("SL_VT"))
            {
                view.FocusedColumn = view.VisibleColumns[3];
                view.ShowEditorByMouse();
                return;
            }
          
        }

        private void grvDetial_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;


            string fieldName = view.FocusedColumn.FieldName;
            if (fieldName.Equals("SO_LUONG_CTU"))
            {
                view.FocusedColumn = view.VisibleColumns[2];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("SO_LUONG_THUC_XUAT"))
            {
                view.FocusedColumn = view.VisibleColumns[3];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("SL_TT"))
            {
                view.FocusedColumn = view.VisibleColumns[4];
                view.ShowEditorByMouse();
                return;
            }
        }
    }
}

