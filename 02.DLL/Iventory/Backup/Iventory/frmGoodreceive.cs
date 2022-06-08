using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.Mask;
namespace Iventory
{
    public partial class frmGoodreceive : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource BindingPhieuNhapKho = new BindingSource();
        private DataTable TbPhieuNhapKho = new DataTable();
        private DataTable TbPhieuNhapKhoPhuTung = new DataTable();
        private DataTable TbPhieuNhapKhoPhuTungChiTiet = new DataTable();
        DataTable TbNgoaiTe = new DataTable();
        private string TrangThai = String.Empty;
        private bool isFirst = false;
        private string oldValue = "";
        public frmGoodreceive()
        {
            InitializeComponent();
        }

        private void chklock_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhieuNhapKho();
        }
        private string ngoai_te_default
        {
            get
            {
                try
                {
                    DataTable _ngoai_te = new DataTable();
                    _ngoai_te.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE,MAC_DINH FROM dbo.NGOAI_TE WHERE MAC_DINH=1"));
                    return _ngoai_te.Rows[0][0].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }
       
        private void InitData()
        {
            datFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datToDate.DateTime = DateTime.Now;
                DataTable tblKho = new DataTable();
                tblKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_KHO_DON_HANG_NHAP", Commons.Modules.UserName));
              
                cmbNhapKho.Properties.DataSource = tblKho;
                cmbNhapKho.Properties.DisplayMember = "TEN_KHO";
                cmbNhapKho.Properties.ValueMember = "MS_KHO";
                tblKho = new DataTable();
                tblKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_KHO", Commons.Modules.UserName));
                lokWareHouse.Properties.DataSource = tblKho;
                lokWareHouse.Properties.DisplayMember = "TEN_KHO";
                lokWareHouse.Properties.ValueMember = "MS_KHO";
               
                DataTable tblDangNhap = new DataTable();
                tblDangNhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DANG_NHAP_KHO_X"));               
                cmbDangNhap.Properties.DataSource = tblDangNhap;
                cmbDangNhap.Properties.ValueMember = "MS_DANG_NHAP";
                cmbDangNhap.Properties.DisplayMember = "TEN_DANG_NHAP";
                LoadPX();
                DataTable tblNguoiNhap = new DataTable();
                tblNguoiNhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NGUOI_NHAP"));
                cmbNguoiNhap.Properties.DataSource = tblNguoiNhap;
                cmbNguoiNhap.Properties.ValueMember = "MS_NGUOI_NHAP";
                cmbNguoiNhap.Properties.DisplayMember = "NGUOI_NHAP";
                txtDate_Ngay_Nhap.DateTime = DateTime.Now;
                txtDate_Ngay_Chung_Tu.DateTime = DateTime.Now;
                txtNguoiLap.Text = Commons.Modules.UserName;
                
                
                TbNgoaiTe.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_NGOAI_TE_NHAP_KHO"));
                DataTable TbViTriKho = new DataTable();
                TbViTriKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VI_TRI_KHO"));
                repositoryItemLookUpEdit2.DataSource = TbViTriKho;
                repositoryItemLookUpEdit2.ValueMember = "MS_VI_TRI";
                repositoryItemLookUpEdit2.DisplayMember = "TEN_VI_TRI";
                LoadPhieuNhapKho();
                BindingPhieuNhapKho.CurrentChanged += new EventHandler(BindingPhieuNhapKho_CurrentChanged);
                TbPhieuNhapKho.TableNewRow += new DataTableNewRowEventHandler(TbPhieuNhapKho_TableNewRow);
                grdList.DataSource  = BindingPhieuNhapKho;
                grvList.Columns["MS_DH_NHAP_PT"].FieldName = "MS_DH_NHAP_PT";
                BindingData();
                TbPhieuNhapKhoPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_NHAP_X_VAT_TU"));
                foreach (DataColumn ClPhieuNhapKhoPhuTung in TbPhieuNhapKhoPhuTung.Columns)
                {
                    ClPhieuNhapKhoPhuTung.ReadOnly = false;
                    ClPhieuNhapKhoPhuTung.AllowDBNull = true;
                }
                try
                {
                    TbPhieuNhapKhoPhuTung.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"];
                    TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] + "'";
                }
                catch {
                    TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "0=1";
                }
                repositoryItemLookUpEdit1.DataSource = TbNgoaiTe;
                repositoryItemLookUpEdit1.DisplayMember = "TEN_NGOAI_TE";
                repositoryItemLookUpEdit1.ValueMember = "NGOAI_TE";
                grdDetial.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
                TbPhieuNhapKhoPhuTungChiTiet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_NHAP_X_VAT_TU_CHI_TIET"));
                foreach (DataColumn ClPhieuNhapKhoPhuTungChiTiet in TbPhieuNhapKhoPhuTungChiTiet.Columns)
                {
                    ClPhieuNhapKhoPhuTungChiTiet.ReadOnly = false;
                    ClPhieuNhapKhoPhuTungChiTiet.AllowDBNull = true;
                }
                try
                {
                    System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                    TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_DH_NHAP_PT"].DefaultValue = row["MS_DH_NHAP_PT"];
                    TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue = row["MS_PT"];
                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString().Trim() + "' AND MS_PT = '" + row["MS_PT"].ToString().Trim() + "'";
                }
                catch
                {
                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
                }
                grdDetialIndex.DataSource = TbPhieuNhapKhoPhuTungChiTiet;
                Enable(false);

        }
        private void LoadPX()
        {
            DataTable tblPhieuXuat = new DataTable();

            tblPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_XUAT"));
            cmbPhieuXuat.Properties.DataSource = tblPhieuXuat;
            cmbPhieuXuat.Properties.ValueMember = "MS_DH_XUAT_PT";
            cmbPhieuXuat.Properties.DisplayMember = "MS_DH_XUAT_PT";
            
        }
        private void LoadPhieuNhapKho()
        {
            try
            {
                TbPhieuNhapKho = new DataTable();
                int kho = -1;
                string s_kho = Convert.ToString(lokWareHouse.EditValue);
                bool isLock = chklock.Checked;
                if (!string.IsNullOrEmpty(s_kho))
                    kho = Convert.ToInt32(s_kho);
                TbPhieuNhapKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_HANG_NHAP_X", Commons.Modules.UserName, Convert.ToDateTime(datFromDate.DateTime.ToShortDateString()), Convert.ToDateTime(datToDate.DateTime.ToShortDateString()).AddDays(1), kho,isLock));
                TbPhieuNhapKho.TableNewRow +=new DataTableNewRowEventHandler(TbPhieuNhapKho_TableNewRow);
                foreach (DataColumn ClPhieuNhapKho in TbPhieuNhapKho.Columns)
                {
                    ClPhieuNhapKho.AllowDBNull = true;
                }
                BindingPhieuNhapKho.DataSource = TbPhieuNhapKho;
                
                
            }
            catch { }
           
        }
        void TbPhieuNhapKho_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DH_NHAP_PT"] = Vietsoft.Information.GetID("NX");
            
        }
        void BindingPhieuNhapKho_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                TbPhieuNhapKhoPhuTung.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"];
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
                //grdDetial.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
            }
            catch
            {
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            try
            {
                System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_DH_NHAP_PT"].DefaultValue =row["MS_DH_NHAP_PT"];
                TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue = row["MS_PT"];
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString().Trim() + "' AND MS_PT = '" + row["MS_PT"].ToString().Trim() + "'";
            }
            catch
            {
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
            }
            InitControl();
        }
        private void InitControl()
        {
            try
            {
                if (!((DataRowView)BindingPhieuNhapKho.Current).Row.IsNull("LOCK") && ((DataRowView)BindingPhieuNhapKho.Current).Row["LOCK"].Equals(true))
                {
                    btnLock.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    btnChon_PT.Visible = false;
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
                    btnAdd.Visible = true ;
                }
                if (string.IsNullOrEmpty(TrangThai))
                    cmbPhieuXuat.Properties.ReadOnly = true;
                btnPrint.Enabled = true;
                btnEdit.Enabled = btnDelete.Enabled = btnLock.Enabled = true;
            }
            catch {
                //btnLock.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnChon_PT.Visible = true;
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
            //lokWareHouse.Enabled = !enable;
            //datFromDate.Enabled = !enable;
            //datToDate.Enabled = !enable;
            tblCondition.Enabled = !enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            btnChon_PT.Enabled = enable;
            txtDate_Ngay_Chung_Tu.Properties.ReadOnly = !enable;
            txtDate_Ngay_Nhap.Properties.ReadOnly  = !enable;
            txtDiem_CL.Properties.ReadOnly = !enable;
            txtDiem_GC.Properties.ReadOnly = !enable;
            txtDiem_GH.Properties.ReadOnly = !enable;
            //txtNguoiLap.Properties.ReadOnly = !enable;
            //txtSo_Phieu_Nhap.Properties.ReadOnly = !enable;
            txtSo_Phieu.Properties.ReadOnly = !enable;
            txtSo_CT.Properties.ReadOnly = !enable;
            txtDanh_Gia.Properties.ReadOnly = !enable;
            txtGhi_Chu.Properties.ReadOnly = !enable;
            if (!TrangThai.Equals("Edit"))
            {
                cmbDangNhap.Properties.ReadOnly = !enable;
                cmbNguoiNhap.Properties.ReadOnly = !enable;
                cmbNhapKho.Properties.ReadOnly = !enable;
                cmbPhieuXuat.Properties.ReadOnly = !enable;
            }
            if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
            {
                grvDetial.OptionsBehavior.Editable = true;
                grvDetialIndex.OptionsBehavior.Editable = true;
            }
            else
            {
                grvDetial.OptionsBehavior.Editable = false ;
                grvDetialIndex.OptionsBehavior.Editable = false;
            }
                               
        }
        private void SetLanguage()
        {
            grbFillter.Text = groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "dieukienloc", Commons.Modules.TypeLanguage);
            thong_tin.Text = groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "thongtinphieuxuat", Commons.Modules.TypeLanguage);
            btnAdd.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnAdd", Commons.Modules.TypeLanguage);
            btnEdit.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnEdit", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnExit", Commons.Modules.TypeLanguage);
            btnDelete.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnDelete", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnCancel", Commons.Modules.TypeLanguage);

            btnChon_PT.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnChon_PT", Commons.Modules.TypeLanguage);
            btnLock.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnLock", Commons.Modules.TypeLanguage);
            btnPrint.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnPrint", Commons.Modules.TypeLanguage);
            btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "btnSave", Commons.Modules.TypeLanguage);
            chklock.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "chklock", Commons.Modules.TypeLanguage);
            tapList.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "Danhsachphieunhap", Commons.Modules.TypeLanguage);
            tapDetial.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "Chitietvattunhap", Commons.Modules.TypeLanguage);
            groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "vattuphutungnhap", Commons.Modules.TypeLanguage);
            grvList.Columns["MS_DH_NHAP_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "donhangnhap", Commons.Modules.TypeLanguage);
            grvList.Columns["SO_PHIEU_XN"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "sophieunhap", Commons.Modules.TypeLanguage);
            grvList.Columns["SO_CHUNG_TU"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "sochungtu", Commons.Modules.TypeLanguage);
            grvList.Columns["NGAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "ngaynhap", Commons.Modules.TypeLanguage);
            grvList.Columns["NGAY_CHUNG_TU"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "ngaychungtu", Commons.Modules.TypeLanguage);
            // tabList.SelectedTabPageIndex = 1;
            grvDetial.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "maphutung", Commons.Modules.TypeLanguage);
            grvDetial.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "tenphutung", Commons.Modules.TypeLanguage);
            grvDetial.Columns["QUY_CACH"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "quycach", Commons.Modules.TypeLanguage);
            grvDetial.Columns["PART_NO"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "partno", Commons.Modules.TypeLanguage);
            grvDetial.Columns["SO_LUONG_CTU"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "soluongchungtu", Commons.Modules.TypeLanguage);
            grvDetial.Columns["SL_THUC_NHAP"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "soluongthucnhap", Commons.Modules.TypeLanguage);
            grvDetial.Columns["DVT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "donvitinh", Commons.Modules.TypeLanguage);
            grvDetial.Columns["DON_GIA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreceive", "dongia", Commons.Modules.TypeLanguage);
            grvDetial.Columns["NGOAI_TE"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmGoodreceive", "ngoaite", Commons.Modules.TypeLanguage);
            grvDetial.Columns["TY_GIA"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "tygia", Commons.Modules.TypeLanguage);
            grvDetial.Columns["TY_GIA_USD"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "tygiausd", Commons.Modules.TypeLanguage);
            grvDetial.Columns["THANH_TIEN"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "thanhtien", Commons.Modules.TypeLanguage);
            
            grvDetial.Columns["THANH_TIEN_VND"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "thanhtienvnd", Commons.Modules.TypeLanguage);
            grvDetial.Columns["THANH_TIEN_USD"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "thanhtienusd", Commons.Modules.TypeLanguage);
            grvDetial.Columns["XUAT_XU"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "xuatxu", Commons.Modules.TypeLanguage);
            grvDetial.Columns["BAO_HANH_DEN_NGAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "baohanhdenngay", Commons.Modules.TypeLanguage);



            grvDetialIndex.Columns["MS_VI_TRI"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "vitri", Commons.Modules.TypeLanguage);

            grvDetialIndex.Columns["SL_VT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "soluongxuat", Commons.Modules.TypeLanguage);
            groupControl1.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmGoodreceive", "chitietnhapvattuphutung", Commons.Modules.TypeLanguage);
            //tabList.SelectedTabPageIndex = 0;
        }
        private void frmGoodreceive_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
            isFirst = true;
            SetLanguage();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        
           // grvDetial.OptionsBehavior.Editable = false;
        }

        private void cmbDangNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbDangNhap.EditValue != null)
            {
                short s = Convert.ToInt16(cmbDangNhap.EditValue.ToString());
                if (s == 1)
                {
                   
                    cmbPhieuXuat.Properties.ReadOnly = false;
                }
                else
                {
                    //cmbPhieuXuat.Properties.DataSource = null;
                    cmbPhieuXuat.EditValue = "-1";
                    cmbPhieuXuat.Properties.ReadOnly = true;

                    
                }
            }
           
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            BindingPhieuNhapKho.AddNew();
            TrangThai = "Add";
            Enable(true);
            txtDate_Ngay_Chung_Tu.DateTime = DateTime.Now;
            txtDate_Ngay_Nhap.DateTime = DateTime.Now;
            txtDiem_GH.Text = "1";
            txtNguoiLap.Text = Commons.Modules.UserName;
            grdList.Enabled = false;
            //Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TrangThai = "Edit";
            Enable(true);
            grdList.Enabled = false;
            oldValue = txtSo_Phieu.Text;

        }
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtSo_Phieu.Text))
            {
                Vietsoft.Information.MsgBox(this, "MsgSoPhieuNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtSo_Phieu.Focus();
                return false ;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbNhapKho.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbNhapKho.Focus();
                return false; 
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbDangNhap.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgDangNhap", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbDangNhap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cmbNguoiNhap.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgNguoiNhap", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbNguoiNhap.Focus();
                return false;
            }
            if (cmbDangNhap.EditValue.Equals(1))
            {
                if (string.IsNullOrEmpty(Convert.ToString(cmbPhieuXuat.EditValue)))
                {
                    Vietsoft.Information.MsgBox(this, "MsgChonPX", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbPhieuXuat.Focus();
                    return false;
                }
            }
            for (int j = 0; j < grvDetial.RowCount; j++)
            {
                DataView DgvTmp = new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + grvDetial.GetRowCellValue(j, "MS_DH_NHAP_PT").ToString().Trim() + "' AND MS_PT = '" + grvDetial.GetRowCellValue(j,"MS_PT").ToString().Trim() + "'", "", DataViewRowState.CurrentRows);
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
                if (Convert.ToDouble(grvDetial.GetRowCellValue(j,"SL_THUC_NHAP")) != SlVT)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSLKhongCan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    grvDetial.FocusedRowHandle = j;
                    grvDetial.FocusedColumn = grvDetial.Columns["SL_THUC_NHAP"];                     
                    return false;
                }
            }
                 return true;
       
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);

                SqlPhieuNhapKho.BeginTransaction();
                try
                {
                    DataTable TbPhieuNhapKhoPhuTungTMP = TbPhieuNhapKhoPhuTung.DefaultView.ToTable(true, "MS_DH_NHAP_PT", "MS_PT", "SO_LUONG_CTU", "SL_THUC_NHAP", "DON_GIA", "NGOAI_TE", "TY_GIA", "TY_GIA_USD", "MS_VT_NCC", "BAO_HANH_DEN_NGAY", "SL_DA_SD", "XUAT_XU", "THANH_TIEN", "GHI_CHU");
                    DataRow row = TbPhieuNhapKho.NewRow();
                    row["MS_DH_NHAP_PT"] = txtSo_Phieu_Nhap.Text;
                    row["SO_PHIEU_XN"] = txtSo_Phieu.Text;
                    row["GIO"] = txtDate_Ngay_Nhap.DateTime;
                    row["NGAY"] = txtDate_Ngay_Nhap.DateTime;
                    row["MS_KHO"] = cmbNhapKho.EditValue;
                    row["TEN_KHO"] = cmbNhapKho.Text;
                    row["MS_DANG_NHAP"] = cmbDangNhap.EditValue;
                    row["NGUOI_NHAP"] = txtNguoiLap.Text;
                    row["NGAY_CHUNG_TU"] = txtDate_Ngay_Chung_Tu.DateTime;
                    row["SO_CHUNG_TU"] = txtSo_CT.Text;
                    row["DIEM"] = txtDiem_GH.Text;
                    row["DANH_GIA"] = txtDanh_Gia.Text;
                    row["GHI_CHU"] = txtGhi_Chu.Text;
                    row["LOCK"] = false;
                    //row["STT"] = txtSo_Phieu_Nhap.Text;
                    row["DA_HET"] = false;
                    row["THU_KHO"] = "";
                    row["MS_DDH"] = "";
                    row["SO_DE_XUAT"] = "";
                    row["NGUOI_GIAO"] = cmbNguoiNhap.EditValue;
                    row["BSXE"] = "";
                    row["DIEM1"] = Convert.ToInt32(txtDiem_CL.Text);
                    row["DIEM2"] = Convert.ToInt32(txtDiem_GC.Text);
                    //TbPhieuNhapKho.Rows.InsertAt(row, 0);
                    //BindingPhieuNhapKho.DataSource = TbPhieuNhapKho;
                    DataTable _table = new DataTable();
                    switch (TrangThai)
                    {
                        case "Add":


                            //SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X", txtSo_Phieu_Nhap.Text,
                            //    txtSo_Phieu.Text, txtDate_Ngay_Nhap.DateTime, txtDate_Ngay_Nhap.DateTime, cmbNhapKho.EditValue, cmbNhapKho.Text,
                            //    cmbDangNhap.EditValue, txtNguoiLap.Text, txtDate_Ngay_Chung_Tu.Text, txtSo_CT.Text, txtDiem_GH.Text, txtDiem_GH.Text,
                            //    txtDanh_Gia.Text, txtGhi_Chu.Text, false, false, "", "", "", "", "", txtDiem_CL.Text, txtDiem_GC.Text);

                            Vietsoft.DataInfo.InsertDataRow(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X", row);
                            Vietsoft.DataInfo.InsertDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X_VAT_TU", TbPhieuNhapKhoPhuTungTMP.DefaultView);
                            Vietsoft.DataInfo.InsertDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X_VAT_TU_CHI_TIET", new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows));
                            _table = new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows).ToTable();
                            _table.Columns.Add("MS_KHO");
                            foreach (DataRow _row in _table.Rows)
                            {
                                _row["MS_KHO"] = cmbNhapKho.EditValue;
                            }
                            Vietsoft.DataInfo.InsertDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_VI_TRI_KHO_VAT_TU_X",_table.DefaultView);
                            break;
                        case "Edit":
                            _table = new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows).ToTable();
                            _table.Columns.Add("MS_KHO");
                            foreach (DataRow _row in _table.Rows)
                            {
                                _row["MS_KHO"] = cmbNhapKho.EditValue;
                            }
                            Vietsoft.DataInfo.UpdateDataRow(SqlPhieuNhapKho, "SP_NHU_Y_EDIT_DON_HANG_NHAP_X", row);
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X_VAT_TU", "SP_NHU_Y_EDIT_DON_HANG_NHAP_X_VAT_TU", "SP_NHU_Y_CHECK_DON_HANG_NHAP_X_VAT_TU", TbPhieuNhapKhoPhuTungTMP.DefaultView, "MS_DH_NHAP_PT", "MS_PT");
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_DON_HANG_NHAP_X_VAT_TU_CHI_TIET", "SP_NHU_Y_EDIT_DON_HANG_NHAP_X_VAT_TU_CHI_TIET", "SP_NHU_Y_CHECK_DON_HANG_NHAP_X_VAT_TU_CHI_TIET", new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows), "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI");
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuNhapKho, "SP_NHU_Y_INSERT_VI_TRI_KHO_VAT_TU_X", "SP_NHU_Y_EDIT_DON_HANG_NHAP_X_VI_TRI_VAT_TU", "SP_NHU_Y_CHECK_VI_TRI_X_VAT_TU", _table.DefaultView, "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI");
                           
                            break;
                    }
                    SqlPhieuNhapKho.CommitTransaction();
                    BindingPhieuNhapKho.EndEdit();
                    TbPhieuNhapKho.AcceptChanges();
                    TbPhieuNhapKhoPhuTung.AcceptChanges();
                    TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
                    TrangThai = String.Empty;
                    //InitializeForm();
                    //InitData(); 
                    InitControl();
                    Enable(false);
                    grdList.Enabled = true;
                    if (grvList.RowCount == 0)
                        btnLock.Enabled = btnEdit.Enabled =btnPrint.Enabled = btnDelete.Enabled = false;
                    TrangThai = "";
                }
                catch
                {
                    SqlPhieuNhapKho.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindingPhieuNhapKho.CancelEdit();
            TbPhieuNhapKho.RejectChanges();
            TbPhieuNhapKhoPhuTung.RejectChanges();
            TbPhieuNhapKhoPhuTungChiTiet.RejectChanges();
            TrangThai = String.Empty;
            InitControl();
            Enable(false);
            if (grvList.RowCount == 0)
                btnLock.Enabled = btnEdit.Enabled = btnDelete.Enabled =btnPrint.Enabled = false;
            grdList.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                SqlPhieuNhapKho.BeginTransaction();
                try
                {
                    string SOPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();
                    SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_VI_TRI_KHO_VAT_TU_X", SOPN);
                    Vietsoft.DataInfo.DeleteDataView(SqlPhieuNhapKho, "SP_NHU_Y_DELETE_DON_HANG_NHAP_X_VAT_TU_CHI_TIET", new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows), "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI");
                    Vietsoft.DataInfo.DeleteDataView(SqlPhieuNhapKho, "SP_NHU_Y_DELETE_DON_HANG_NHAP_X_VAT_TU", TbPhieuNhapKhoPhuTung.DefaultView, "MS_DH_NHAP_PT", "MS_PT");
                    Vietsoft.DataInfo.DeleteDataRow(SqlPhieuNhapKho, "SP_NHU_Y_DELETE_DON_HANG_NHAP_X", ((DataRowView)BindingPhieuNhapKho.Current).Row, "MS_DH_NHAP_PT");
                    Vietsoft.DataInfo.ClearData(new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'", "MS_PT", DataViewRowState.CurrentRows));
                    Vietsoft.DataInfo.ClearData(TbPhieuNhapKhoPhuTung.DefaultView);
                    BindingPhieuNhapKho.RemoveCurrent();
                    TbPhieuNhapKho.AcceptChanges();
                    TbPhieuNhapKhoPhuTung.AcceptChanges();
                    TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
                    SqlPhieuNhapKho.CommitTransaction();
                    //InitializeForm();
                }
                catch
                {
                    SqlPhieuNhapKho.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            string pri = SqlPhieuNhapKho.ExecuteScalar(CommandType.Text, "SELECT TOP 1 PRIVATE FROM THONG_TIN_CHUNG").ToString();
            //if (pri == "DUYTAN")
            //    CreateRPT_DUYTAN();

            //else
            //    if (pri == "KKTL")
            //        CreateRPT_KKTL();
            //    else
                    CreateRPT();
        }
        private static DataTable CreateTitle()
        {
            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("SO_ISO");
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("LIEN");
            TbTieuDe.Columns.Add("NO");
            TbTieuDe.Columns.Add("SO_PHIEU_NHAP");
            TbTieuDe.Columns.Add("CO");
            TbTieuDe.Columns.Add("NGUOI_NHAP");
            TbTieuDe.Columns.Add("DANG_NHAP");
            TbTieuDe.Columns.Add("MS_DH_NHAP_PT");
            TbTieuDe.Columns.Add("SO_CHUNG_TU");
            TbTieuDe.Columns.Add("NGAY_CHUNG_TU");
            TbTieuDe.Columns.Add("NGAY_NHAP_KHO");
            TbTieuDe.Columns.Add("TEN_KHO");
            TbTieuDe.Columns.Add("GHI_CHU_DH_NHAP_PT");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("PRAR_NO");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("SL_CTU");
            TbTieuDe.Columns.Add("SL_THUC_NHAP");
            TbTieuDe.Columns.Add("DON_GIA");
            TbTieuDe.Columns.Add("NGOAI_TE");
            TbTieuDe.Columns.Add("TY_GIA");
            TbTieuDe.Columns.Add("THANH_TIEN");
            TbTieuDe.Columns.Add("THANH_TIEN_VND");
            TbTieuDe.Columns.Add("GHI_CHU_CT");
            TbTieuDe.Columns.Add("TONG_TIEN");
            TbTieuDe.Columns.Add("NGAY_THANG_NAM");
            TbTieuDe.Columns.Add("TRUONG_DON_VI");
            TbTieuDe.Columns.Add("TRUONG_DV_KY");
            TbTieuDe.Columns.Add("NGUOI_LAP");
            TbTieuDe.Columns.Add("NGUOI_LAP_KY");
            TbTieuDe.Columns.Add("NGUOI_GIAO");
            TbTieuDe.Columns.Add("NGUOI_GIAO_KY");
            TbTieuDe.Columns.Add("THU_KHO");
            TbTieuDe.Columns.Add("THU_KHO_KY");
            TbTieuDe.Columns.Add("MAU_SO");
            TbTieuDe.Columns.Add("NGAY_BH");
            TbTieuDe.Columns.Add("LAN_BH");
            TbTieuDe.Columns.Add("LIEN_KHO");
            

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["SO_ISO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SO_ISO", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["LIEN"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "LIEN", Commons.Modules.TypeLanguage);
            rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NO", Commons.Modules.TypeLanguage);
            rTitle["SO_PHIEU_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SO_PHIEU_NHAP", Commons.Modules.TypeLanguage);
            rTitle["CO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "CO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGUOI_NHAP", Commons.Modules.TypeLanguage);
            rTitle["DANG_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "DANG_NHAP", Commons.Modules.TypeLanguage);
            rTitle["MS_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["SO_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SO_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["NGAY_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGAY_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TEN_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_NHAP_KHO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGAY_NHAP_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "GHI_CHU_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["PRAR_NO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "PRAR_NO", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "QUY_CACH", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["SL_CTU"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SL_CTU", Commons.Modules.TypeLanguage);
            rTitle["SL_THUC_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "SL_THUC_NHAP", Commons.Modules.TypeLanguage);
            rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "DON_GIA", Commons.Modules.TypeLanguage);
            rTitle["NGOAI_TE"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGOAI_TE", Commons.Modules.TypeLanguage);
            rTitle["TY_GIA"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TY_GIA", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "THANH_TIEN", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "THANH_TIEN_VND", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_CT"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "GHI_CHU_CT", Commons.Modules.TypeLanguage);
            rTitle["TONG_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TONG_TIEN", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TRUONG_DON_VI", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DV_KY"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "TRUONG_DV_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGUOI_LAP", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP_KY"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGUOI_LAP_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGUOI_GIAO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO_KY"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "NGUOI_GIAO_KY", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO_KY"] = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "rptPhieuNhapKhoX", "THU_KHO_KY", Commons.Modules.TypeLanguage);

            rTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuNhapKhoX", "MAU_SO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuNhapKhoX", "NGAY_BH", Commons.Modules.TypeLanguage);
            rTitle["LAN_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuNhapKhoX", "LAN_BH", Commons.Modules.TypeLanguage);
            rTitle["LIEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "rptPhieuNhapKhoX", "LIEN_KHO", Commons.Modules.TypeLanguage);


            TbTieuDe.TableName = "rptTieuDePhieuNhapKhoNew";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }
        private void CreateRPT()
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_DON_HANG_NHAP_RPT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoX";
            frmReport frmRptPhieuNhap = new frmReport();
            //frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVMPACKNew";
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoX";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle();
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }
        private void btnChon_PT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(cmbNhapKho.EditValue)))
            {
                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbNhapKho.Focus();
                return;
            }
            frmChooseAccessory frmPhuTung = new frmChooseAccessory();
            frmPhuTung.CurrentSource = TbPhieuNhapKhoPhuTung.DefaultView.ToTable();
            try
            {
                string s = Convert.ToString(cmbDangNhap.EditValue);
                switch (s)
                {
                    case "1":
                        try
                        {
                            if (cmbPhieuXuat.EditValue.Equals("-1"))
                            {
                                Vietsoft.Information.MsgBox(this, "MsgChonPX", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cmbPhieuXuat.Focus();
                                return;
                                
                            }
                            frmPhuTung.Phieu_Xuat = cmbPhieuXuat.EditValue.ToString();
                            break;
                        }
                        catch
                        {
                            Vietsoft.Information.MsgBox(this, "MsgChonPX", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            cmbPhieuXuat.Focus();
                            return;
                            //break;
                        }
                    case "2":
                        frmPhuTung.Phieu_Xuat = "-1";
                        break;
                    case "":
                    Vietsoft.Information.MsgBox(this, "MsgChonDN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbDangNhap.Focus();
                    return;
                    //break;
                    
                }
               
                
            }
            catch
            {
                frmPhuTung.Phieu_Xuat = "-1";
            }
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_TY_GIA_NGOAI_TE", ngoai_te_default));
            if (frmPhuTung.ShowDialog() == DialogResult.OK)
            {
                frmPhuTung.DataSource.DefaultView.RowFilter = "CHON = true";
                for (int i = 0; i < frmPhuTung.DataSource.DefaultView.Count; i++)
                {
                    if (TbPhieuNhapKhoPhuTung.Columns.Count > 0)
                    {
                        DataRow rPhieuNhapKhoPhuTung = TbPhieuNhapKhoPhuTung.NewRow();
                        rPhieuNhapKhoPhuTung["MS_DH_NHAP_PT"] = txtSo_Phieu_Nhap.Text;
                        rPhieuNhapKhoPhuTung["MS_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];
                        rPhieuNhapKhoPhuTung["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                        rPhieuNhapKhoPhuTung["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];
                        rPhieuNhapKhoPhuTung["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT_NCC"];
                        rPhieuNhapKhoPhuTung["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_DV"];
                        rPhieuNhapKhoPhuTung["SO_LUONG_CTU"] = frmPhuTung.DataSource.DefaultView[i].Row["SL"];
                        rPhieuNhapKhoPhuTung["SL_THUC_NHAP"] = frmPhuTung.DataSource.DefaultView[i].Row["SL"];
                        rPhieuNhapKhoPhuTung["DON_GIA"] = 0;
                        rPhieuNhapKhoPhuTung["NGOAI_TE"] = ngoai_te_default;
                        rPhieuNhapKhoPhuTung["TY_GIA"] = _table.Rows[0]["TI_GIA"].ToString();
                        rPhieuNhapKhoPhuTung["TY_GIA_USD"] = _table.Rows[0]["TI_GIA_USD"].ToString();
                        rPhieuNhapKhoPhuTung["THANH_TIEN"] = 0;
                        rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] = 0;
                        rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] =0;
                        try
                        {
                            rPhieuNhapKhoPhuTung["VI_TRI"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_VI_TRI"];
                        }
                        catch
                        { }

                       
                        TbPhieuNhapKhoPhuTung.Rows.Add(rPhieuNhapKhoPhuTung);
                        DataTable TbViTriKhoPT = new DataTable();
                        TbViTriKhoPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VI_TRI_KHO_PT", cmbNhapKho.EditValue.ToString()));
                        foreach (DataRow rViTriKhoPT in TbViTriKhoPT.Rows)
                        {
                            DataRow rPhieuNhapKhoPhuTungChiTiet = TbPhieuNhapKhoPhuTungChiTiet.NewRow();
                            rPhieuNhapKhoPhuTungChiTiet["MS_DH_NHAP_PT"] = txtSo_Phieu_Nhap.Text;
                            rPhieuNhapKhoPhuTungChiTiet["MS_PT"] = rPhieuNhapKhoPhuTung["MS_PT"];
                            rPhieuNhapKhoPhuTungChiTiet["MS_VI_TRI"] = rViTriKhoPT["MS_VI_TRI"];
                            if (rViTriKhoPT["MS_VI_TRI"].Equals(frmPhuTung.DataSource.DefaultView[i].Row["MS_VI_TRI"]))
                            {
                                rPhieuNhapKhoPhuTungChiTiet["SL_VT"] = frmPhuTung.DataSource.DefaultView[i].Row["SL"];
                            }
                            else
                                rPhieuNhapKhoPhuTungChiTiet["SL_VT"] = 0;
                            TbPhieuNhapKhoPhuTungChiTiet.Rows.Add(rPhieuNhapKhoPhuTungChiTiet);
                        }
                    }
                }

                repositoryItemLookUpEdit1.DataSource = TbNgoaiTe;
                repositoryItemLookUpEdit1.DisplayMember = "TEN_NGOAI_TE";
                repositoryItemLookUpEdit1.ValueMember = "NGOAI_TE";
              
                grdDetial.DataSource = TbPhieuNhapKhoPhuTung;
                grdDetialIndex.DataSource = TbPhieuNhapKhoPhuTungChiTiet;
                cmbNhapKho.Properties.ReadOnly  = true;
                cmbPhieuXuat.Properties.ReadOnly = true;
                cmbDangNhap.Properties.ReadOnly = true;
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            //DataRow _row = ((DataRowView)BindingPhieuNhapKho.Current).Row;
            //DataRow row = TbPhieuNhapKho.NewRow();
            //row["MS_DH_NHAP_PT"] = txtSo_Phieu_Nhap.Text;
            //row["SO_PHIEU_XN"] = txtSo_Phieu.Text;
            //row["GIO"] = txtDate_Ngay_Nhap.DateTime;
            //row["NGAY"] = txtDate_Ngay_Nhap.DateTime;
            //row["MS_KHO"] = cmbNhapKho.EditValue;
            //row["TEN_KHO"] = cmbNhapKho.Text;
            //row["MS_DANG_NHAP"] = cmbDangNhap.EditValue;
            //row["NGUOI_NHAP"] = txtNguoiLap.Text;
            //row["NGAY_CHUNG_TU"] = txtDate_Ngay_Chung_Tu.DateTime;
            //row["SO_CHUNG_TU"] = txtSo_CT.Text;
            //row["DIEM"] = txtDiem_GH.Text;
            //row["DANH_GIA"] = txtDanh_Gia.Text;
            //row["GHI_CHU"] = txtGhi_Chu.Text;
            ////row["LOCK"] = false;
            ////row["STT"] = txtSo_Phieu_Nhap.Text;
            //row["DA_HET"] = false;
            //row["THU_KHO"] = "";
            //row["MS_DDH"] = "";
            //row["SO_DE_XUAT"] = "";
            //row["NGUOI_GIAO"] = cmbNguoiNhap.EditValue;
            //row["BSXE"] = "";
            //row["DIEM1"] = Convert.ToInt32(txtDiem_CL.Text);
            //row["DIEM2"] = Convert.ToInt32(txtDiem_GC.Text);
            //row["LOCK"] = true;
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            SqlPhieuNhapKho.BeginTransaction();
            try
            {
                //Vietsoft.DataInfo.UpdateDataRow(SqlPhieuNhapKho, "SP_NHU_Y_EDIT_DON_HANG_NHAP_X", _row);
                SqlPhieuNhapKho.ExecuteNonQuery("UPDATE IC_DON_HANG_NHAP_X SET LOCK=1 WHERE MS_DH_NHAP_PT='" + txtSo_Phieu_Nhap.Text + "'");
                SqlPhieuNhapKho.ExecuteNonQuery("DELETE dbo.IC_DON_HANG_NHAP_X_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT = N'" + txtSo_Phieu_Nhap.Text + "' AND SL_VT IS NULL OR SL_VT <=0");
                SqlPhieuNhapKho.CommitTransaction();
                BindingPhieuNhapKho.RemoveCurrent();
                TbPhieuNhapKho.AcceptChanges();
                TbPhieuNhapKhoPhuTung.AcceptChanges();
                TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
              
            }
            catch
            {
                SqlPhieuNhapKho.RollbackTransaction();
                TbPhieuNhapKho.RejectChanges();
                Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDetial_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //string s = grvDetial.GetRowCellValue(e.RowHandle, "SL_CT").ToString();
           // grvDetial.Columns["SL_THUC_NHAP"]..UnboundExpression = e.Value.ToString();
            string column = e.Column.FieldName;
            System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_TY_GIA_NGOAI_TE", e.Value.ToString()));
            switch (column)
            {
                case "SO_LUONG_CTU":
                    if (Convert.ToInt32(e.Value) > 0)
                        row["SL_THUC_NHAP"] = e.Value.ToString();
                    else
                    {
                        row["SL_THUC_NHAP"] = 0;
                        row["SO_LUONG_CTU"] = 0;
                    }
                        try
                        {
                            row["THANH_TIEN"] = Convert.ToDouble(row["DON_GIA"]) * Convert.ToDouble(row["SL_THUC_NHAP"]);
                            row["THANH_TIEN_VND"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA"]);
                            row["THANH_TIEN_USD"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA_USD"]);
                        }
                        catch { }
                    break;
                case "SL_THUC_NHAP":
                    //if (Convert.ToInt32(e.Value.ToString()) > Convert.ToInt32(row["SO_LUONG_CTU"].ToString()))
                    //{
                    //    Vietsoft.Information.MsgBox(this, "MsgChonDN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //    return;

                    //}
                    //else
                    //{
                    if (Convert.ToInt32(e.Value) < 0)
                        row["SL_THUC_NHAP"] = 0;
                        try
                        {
                            row["THANH_TIEN"] = Convert.ToDouble(row["DON_GIA"]) * Convert.ToDouble(row["SL_THUC_NHAP"]);
                            row["THANH_TIEN_VND"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA"]);
                            row["THANH_TIEN_USD"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA_USD"]);
                        }
                        catch { }
                    //}
                    break;
                case "DON_GIA":
                    if (Convert.ToInt32(e.Value) < 0)
                        row["DON_GIA"] = 0;
                    try
                    {
                        row["THANH_TIEN"] = Convert.ToDouble(row["DON_GIA"]) * Convert.ToDouble(row["SL_THUC_NHAP"]);
                        row["THANH_TIEN_VND"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA"]);
                        row["THANH_TIEN_USD"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA_USD"]);
                    }
                    catch { }
                    break;
                case "NGOAI_TE":
                  
                    row["TY_GIA"] = _table.Rows[0]["TI_GIA"].ToString();
                    row["TY_GIA_USD"] = _table.Rows[0]["TI_GIA_USD"].ToString();
                    row["THANH_TIEN"] =Convert.ToDouble(row["DON_GIA"]) * Convert.ToDouble(row["SL_THUC_NHAP"]);
                    row["THANH_TIEN_VND"] =Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA"]);
                    row["THANH_TIEN_USD"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA_USD"]);
                    break;
                case "TY_GIA":
                    row["THANH_TIEN_VND"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA"]);
                    break;
                case "TY_GIA_USD":
                    row["THANH_TIEN_USD"] = Convert.ToDouble(row["THANH_TIEN"]) * Convert.ToDouble(row["TY_GIA_USD"]);
                    break;
            }
          
          
        }

        private void grvDetial_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             try
             {
                 System.Data.DataRow row = grvDetial.GetDataRow(grvDetial.FocusedRowHandle);
                 //TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)DgvPhieuNhapKhoChiTiet.CurrentRow.DataBoundItem).Row["MS_DH_NHAP_PT"];
                 // TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue =row["MS_PT"];
                 TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_PT = '" + row["MS_PT"] + "' and MS_DH_NHAP_PT='" + row["MS_DH_NHAP_PT"] +"'";
                 grdDetialIndex.DataSource = TbPhieuNhapKhoPhuTungChiTiet;
             }
             catch
             {
                 TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
             }
        }

        private void lokWareHouse_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuNhapKho();
        }
        private void BindingData()
        {
            try
            {
             
                txtSo_Phieu_Nhap.DataBindings.Clear();
                txtSo_Phieu_Nhap.DataBindings.Add("Text", BindingPhieuNhapKho, "MS_DH_NHAP_PT");
                txtSo_Phieu.DataBindings.Clear();
                txtSo_Phieu.DataBindings.Add("Text", BindingPhieuNhapKho, "SO_PHIEU_XN");

                txtNguoiLap.DataBindings.Add("Text", BindingPhieuNhapKho, "NGUOI_NHAP");
                txtDate_Ngay_Nhap.DataBindings.Clear();

                txtDate_Ngay_Nhap.DataBindings.Add("Text", BindingPhieuNhapKho, "NGAY", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy HH:mm");
                cmbNhapKho.DataBindings.Clear();
                cmbNhapKho.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_KHO",true, DataSourceUpdateMode.OnPropertyChanged , null);
              
                cmbNguoiNhap.DataBindings.Clear();
                cmbNguoiNhap.DataBindings.Add("EditValue", BindingPhieuNhapKho, "NGUOI_GIAO", true, DataSourceUpdateMode.OnPropertyChanged,null);
                txtDate_Ngay_Chung_Tu.DataBindings.Clear();
                txtDate_Ngay_Chung_Tu.DataBindings.Add("Text", BindingPhieuNhapKho, "NGAY_CHUNG_TU", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy");
                cmbDangNhap.DataBindings.Clear();
                cmbDangNhap.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_DANG_NHAP", true, DataSourceUpdateMode.OnPropertyChanged,null);
                txtSo_CT.DataBindings.Clear();
                txtSo_CT.DataBindings.Add("Text", BindingPhieuNhapKho, "SO_CHUNG_TU");
                cmbPhieuXuat.DataBindings.Clear();
                cmbPhieuXuat.DataBindings.Add("EditValue", BindingPhieuNhapKho, "SO_DE_XUAT",true, DataSourceUpdateMode.OnPropertyChanged,null);
                txtDiem_GH.DataBindings.Clear();
                txtDiem_GH.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM");
                txtDiem_CL.DataBindings.Clear();
                txtDiem_CL.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM1");
                txtDiem_GC.DataBindings.Clear();
                txtDiem_GC.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM2");
                txtDanh_Gia.DataBindings.Clear();
                txtDanh_Gia.DataBindings.Add("Text", BindingPhieuNhapKho, "DANH_GIA");
                txtGhi_Chu.DataBindings.Clear();
                txtGhi_Chu.DataBindings.Add("Text", BindingPhieuNhapKho, "GHI_CHU");
            }
            catch { }
        }
       

        private void txtSo_Phieu_Validated(object sender, EventArgs e)
        {
            if (txtSo_Phieu.Text.Trim() != "")
            {
                if (TrangThai.Equals("Add"))
                {
                    Vietsoft.SqlInfo Sql = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                    System.Data.DataTable Tb = new System.Data.DataTable();
                    Tb.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_CHECK_SO_DON_HANG_NHAP", txtSo_Phieu.Text.Trim()));
                    if (Tb.Rows.Count > 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSoDHNTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                            Tb.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_CHECK_SO_DON_HANG_NHAP", txtSo_Phieu.Text.Trim()));
                            if (Tb.Rows.Count > 0)
                            {
                                Vietsoft.Information.MsgBox(this, "MsgSoDHNTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                        LoadPhieuNhapKho();
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
                        LoadPhieuNhapKho();
                }
            }
            catch { }
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
                    if ((DateTime)e.NewValue  <datFromDate.DateTime)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                   
                }
            }
            catch { }
        }

        private void grvDetialIndex_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string column = e.Column.FieldName;
            System.Data.DataRow row = grvDetialIndex.GetDataRow(grvDetialIndex.FocusedRowHandle);
            switch (column)
            {
                case "SL_VT":
                    if (Convert.ToInt32(e.Value) < 0)
                        row["SL_VT"] = 0;
                    break;
            }
        }

        private void grvDetial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                    SqlPhieuNhapKho.BeginTransaction();
                    try
                    {
                        DataRow row = grvDetial.GetFocusedDataRow();
                        string SOPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();
                        string PHU_TUNG = row["MS_PT"].ToString();
                        SqlPhieuNhapKho.ExecuteNonQuery(CommandType.Text, "DELETE VI_TRI_KHO_VAT_TU_X WHERE MS_DH_NHAP_PT='" + SOPN + "' AND MS_PT ='" + PHU_TUNG + "'");
                        SqlPhieuNhapKho.ExecuteNonQuery(CommandType.Text,"DELETE IC_DON_HANG_NHAP_X_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT ='" + SO_PN + "' and MS_PT ='" + PHU_TUNG + "'");
                        SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_NHU_Y_DELETE_DON_HANG_NHAP_X_VAT_TU",SOPN,PHU_TUNG);
                        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        view.DeleteSelectedRows();
                        TbPhieuNhapKhoPhuTung.AcceptChanges();
                        TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
                        SqlPhieuNhapKho.CommitTransaction();
                    }
                    catch {
                        SqlPhieuNhapKho.RollbackTransaction();
                        Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void grvDetial_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;


            string fieldName = view.FocusedColumn.FieldName;
            if (fieldName.Equals("SO_LUONG_CTU"))
            {
                view.FocusedColumn = view.VisibleColumns[4];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("SL_THUC_NHAP"))
            {
                view.FocusedColumn = view.VisibleColumns[5];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("DON_GIA"))
            {
                view.FocusedColumn = view.VisibleColumns[7];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("TY_GIA"))
            {
                view.FocusedColumn = view.VisibleColumns[9];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("TY_GIA_USD"))
            {
                view.FocusedColumn = view.VisibleColumns[10];
                view.ShowEditorByMouse();
                return;
            }
            if (fieldName.Equals("XUAT_XU"))
            {
                view.FocusedColumn = view.VisibleColumns[14];
                view.ShowEditorByMouse();
                return;
            }
            
        }

        private void grvDetialIndex_ShownEditor(object sender, EventArgs e)
        {

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;


            string fieldName = view.FocusedColumn.FieldName;
            if (fieldName.Equals("SL_VT"))
            {
                view.FocusedColumn = view.VisibleColumns[1];
                view.ShowEditorByMouse();
                return;
            }
        }

     
    }
}