using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using DevExpress.XtraEditors;
using OfficeOpenXml.Style;

namespace WareHouse
{
    public partial class frmDonDatHang_New : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo toàn cục
        /// </summary>
        private BindingSource BindingDonDatHang = new BindingSource();
        private DataTable TbDonDatHang = new DataTable();
        private DataTable TbDonDatHangChiTiet = new DataTable();
        private DataTable TbDonDatHangDichVu = new DataTable();
        private DataTable TbDonDatHangDieuKhoan = new DataTable();
        private DataTable TbDuyetDonDatHang = new DataTable();
        private string TrangThai = String.Empty;
        private double sTotal = 0;
        private bool isFirst = false;
        string sPrivate;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public frmDonDatHang_New()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        private void InitializeDatabase()
        {
            DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            datFromDate.DateTime = Convert.ToDateTime("01/" + NgayHT.Month + "/" + NgayHT.Year);
            datToDate.DateTime = NgayHT;
            LoadDDH();
            BindingDonDatHang.CurrentChanged += new EventHandler(BindingDonDatHang_CurrentChanged);
            TbDonDatHang.TableNewRow += new DataTableNewRowEventHandler(TbDonDatHang_TableNewRow);
            DgvDonDatHang.AutoGenerateColumns = false;
            DgvDonDatHang.DataSource = BindingDonDatHang;
            DgvDonDatHang.Columns["DON_DAT_HANG"].DataPropertyName = "MS_DON_DAT_HANG";
            DataTable TbNhaCungCap = new DataTable();
            TbNhaCungCap.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NHA_CUNG_CAP"));
            CboNHA_CUNG_CAP.DataSource = TbNhaCungCap;
            CboNHA_CUNG_CAP.ValueMember = "MS_NCC";
            CboNHA_CUNG_CAP.DisplayMember = "TEN_NHA_CUNG_CAP";
            CboNHA_CUNG_CAP.SelectedIndex = -1;
            TbNhaCungCap = new DataTable();
            TbNhaCungCap.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_NHA_CUNG_CAP"));
            lokSupplier.Properties.ValueMember = "TEN_NHA_CUNG_CAP";
            lokSupplier.Properties.DisplayMember = "TEN_NHA_CUNG_CAP";
            lokSupplier.Properties.DataSource = TbNhaCungCap;
            lokSupplier.EditValue = "All";
            DataTable _table = new DataTable();
            _table.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "[SP_Y_GET_KHO_PT_NEW]"));
            cmbKho.ValueMember = "MS_KHO";
            cmbKho.DisplayMember = "TEN_KHO";
            cmbKho.SelectedValue = -1;
            cmbKho.DataSource = _table;
            _table = new DataTable();


            _table.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "[SP_Y_GET_LOAI_VT]"));
            cmbLoaiVT.ValueMember = "MS_LOAI_VT";
            cmbLoaiVT.DisplayMember = "TEN_VT";
            cmbLoaiVT.SelectedValue = -1;
            cmbLoaiVT.DataSource = _table;
            BindingControl();
            TbDonDatHangChiTiet = new DataTable();
            TbDonDatHangChiTiet.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_DAT_HANG_CHI_TIET"));
            foreach (DataColumn ClDonDatHangChiTiet in TbDonDatHangChiTiet.Columns)
            {
                ClDonDatHangChiTiet.AllowDBNull = true;
            }
            try
            {
                TbDonDatHangChiTiet.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangChiTiet.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangChiTiet.DefaultView.RowFilter = "0=1";
            }
            TbDonDatHangChiTiet.TableNewRow += new DataTableNewRowEventHandler(TbDonDatHangChiTiet_TableNewRow);
            DataTable TbNgoaiTe = new DataTable();
            TbNgoaiTe.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGOAI_TE"));
            ((DataGridViewComboBoxColumn)DgvDonDatHangChiTiet.Columns["NGOAI_TE"]).DataSource = TbNgoaiTe;
            ((DataGridViewComboBoxColumn)DgvDonDatHangChiTiet.Columns["NGOAI_TE"]).ValueMember = "TEN_NGOAI_TE";
            ((DataGridViewComboBoxColumn)DgvDonDatHangChiTiet.Columns["NGOAI_TE"]).DisplayMember = "TEN_NGOAI_TE";

            DgvDonDatHangChiTiet.AutoGenerateColumns = false;
            DgvDonDatHangChiTiet.DataSource = TbDonDatHangChiTiet.DefaultView;
            foreach (DataGridViewColumn ClDonDatHangChiTiet in DgvDonDatHangChiTiet.Columns)
            {
                ClDonDatHangChiTiet.DataPropertyName = ClDonDatHangChiTiet.Name;
            }

            TbDonDatHangDichVu = new DataTable();
            TbDonDatHangDichVu.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_DAT_HANG_DICH_VU"));
            foreach (DataColumn ClDonDatHangDichVu in TbDonDatHangDichVu.Columns)
            {
                ClDonDatHangDichVu.AllowDBNull = true;
            }
            try
            {
                TbDonDatHangDichVu.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangDichVu.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangDichVu.DefaultView.RowFilter = "0=1";
            }
            TbDonDatHangDichVu.TableNewRow += new DataTableNewRowEventHandler(TbDonDatHangDichVu_TableNewRow);
            DataTable TbNgoaiTeDichVu = new DataTable();
            TbNgoaiTeDichVu.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGOAI_TE"));
            ((DataGridViewComboBoxColumn)DgvDonDatHangDichVu.Columns["NGOAI_TE_DV"]).DataSource = TbNgoaiTeDichVu;
            ((DataGridViewComboBoxColumn)DgvDonDatHangDichVu.Columns["NGOAI_TE_DV"]).ValueMember = "TEN_NGOAI_TE";
            ((DataGridViewComboBoxColumn)DgvDonDatHangDichVu.Columns["NGOAI_TE_DV"]).DisplayMember = "TEN_NGOAI_TE";

            DgvDonDatHangDichVu.AutoGenerateColumns = false;
            DgvDonDatHangDichVu.DataSource = TbDonDatHangDichVu.DefaultView;
            foreach (DataGridViewColumn ClDonDatHangDichVu in DgvDonDatHangDichVu.Columns)
            {
                ClDonDatHangDichVu.DataPropertyName = ClDonDatHangDichVu.Name.Replace("_DV", String.Empty);
            }

            TbDonDatHangDieuKhoan.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_DAT_HANG_DIEU_KHOAN"));
            foreach (DataColumn ClDonDatHangDieuKhoan in TbDonDatHangDieuKhoan.Columns)
            {
                ClDonDatHangDieuKhoan.AllowDBNull = true;
            }
            try
            {
                TbDonDatHangDieuKhoan.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangDieuKhoan.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangDieuKhoan.DefaultView.RowFilter = "0=1";
            }
            TbDonDatHangDieuKhoan.TableNewRow += new DataTableNewRowEventHandler(TbDonDatHangDieuKhoan_TableNewRow);
            DgvDonDatHangDieuKhoan.AutoGenerateColumns = false;
            DgvDonDatHangDieuKhoan.DataSource = TbDonDatHangDieuKhoan.DefaultView;
            foreach (DataGridViewColumn ClDonDatHangDieuKhoan in DgvDonDatHangDieuKhoan.Columns)
            {
                ClDonDatHangDieuKhoan.DataPropertyName = ClDonDatHangDieuKhoan.Name.Replace("_DK", String.Empty);
            }
            TbDuyetDonDatHang = new DataTable();
            TbDuyetDonDatHang.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DON_DAT_HANG"));
            foreach (DataColumn ClDuyetDonDatHang in TbDuyetDonDatHang.Columns)
            {
                ClDuyetDonDatHang.AllowDBNull = true;
            }
            try
            {
                TbDuyetDonDatHang.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDuyetDonDatHang.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDuyetDonDatHang.DefaultView.RowFilter = "0=1";
            }
            DataTable TbNguoiDuyet = new DataTable();
            TbNguoiDuyet.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGUOI_DUYET"));
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["NGUOI_DUYET"]).DataSource = TbNguoiDuyet;
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["NGUOI_DUYET"]).ValueMember = "USERNAME";
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["NGUOI_DUYET"]).DisplayMember = "TEN_NGUOI_DUYET";
            DgvDuyetDonDatHang.AutoGenerateColumns = false;
            DgvDuyetDonDatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DataTable TbDonVi = new DataTable();
            TbDonVi.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_VI"));
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["DON_VI"]).DataSource = TbDonVi;
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["DON_VI"]).ValueMember = "TEN_DON_VI";
            ((DataGridViewComboBoxColumn)DgvDuyetDonDatHang.Columns["DON_VI"]).DisplayMember = "TEN_DON_VI";

            DgvDuyetDonDatHang.AutoGenerateColumns = false;
            DgvDuyetDonDatHang.DataSource = null;
            DgvDuyetDonDatHang.DataSource = TbDuyetDonDatHang.DefaultView;
            foreach (DataGridViewColumn ClDuyetDonDatHang in DgvDuyetDonDatHang.Columns)
            {
                ClDuyetDonDatHang.DataPropertyName = ClDuyetDonDatHang.Name;
            }

            Commons.Modules.ObjSystems.MVisGrid(DgvDonDatHangChiTiet, "frmDonDatHang_New", "DgvDonDatHangChiTiet", Commons.Modules.UserName);
        }
        private void LoadDDH()
        {
            DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();

            datToDate.DateTime = datToDate.DateTime.Date.AddDays(1).AddMilliseconds(-1);
            datFromDate.DateTime = datFromDate.DateTime.Date.AddDays(1).AddMilliseconds(-1);

            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            TbDonDatHang = new DataTable();
            TbDonDatHang.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure,
                "SP_NHU_Y_GET_DON_DAT_HANG", lokSupplier.Text, Convert.ToDateTime(datFromDate.DateTime.ToShortDateString()),
                datToDate.DateTime, chkIsLock.Checked));
            foreach (DataColumn ClDonDatHang in TbDonDatHang.Columns)
            {
                ClDonDatHang.AllowDBNull = true;
            }
            TbDonDatHang.Columns["NGAY_LAP"].DefaultValue = NgayHT;
            TbDonDatHang.Columns["NGUOI_LAP"].DefaultValue = Commons.Modules.UserName;
            TbDonDatHang.Columns["TRANG_THAI"].DefaultValue = 1;
            TbDonDatHang.Columns["THUE_VAT"].DefaultValue = 0;
            TbDonDatHang.Columns["TEN_TRANG_THAI"].DefaultValue = "Đang soạn";

            BindingDonDatHang.DataSource = TbDonDatHang;
            TbDonDatHang.TableNewRow += new DataTableNewRowEventHandler(TbDonDatHang_TableNewRow);
            isFirst = true;
        }
        /// <summary>
        /// Điều khiển form
        /// </summary>
        private void InitializeForm()
        {
            TxtNGUOI_LAP.Enabled = false;
            MskNGAY_LAP.Enabled = false;
            TxtNGUOI_SUA.Enabled = false;
            MskNGAY_SUA.Enabled = false;
            TxtNGUOI_DUYET.Enabled = false;
            MskNGAY_DUYET.Enabled = false;
            TxtTINH_TRANG.Enabled = false;
            TxtMS_DON_DAT_HANG.Enabled = false;
            switch (TrangThai)
            {
                case "Add":
                case "Edit":
                    TxtSO_DON_DAT_HANG.Enabled = true;
                    txtTimKiem.Enabled = false;
                    btnTimCX.Enabled = false;
                    MskNGAY_DAT_HANG.Enabled = true;
                    TxtNGUOI_DAT_HANG.Enabled = true;
                    MskNGAY_LIEN_HE.Enabled = true;
                    TxtNGUOI_LIEN_HE.Enabled = true;
                    MskNGAY_HD.Enabled = true;
                    TxtNGUOI_KY_HD.Enabled = true;
                    MskNGAY_GIAO.Enabled = true;
                    TxtNGUOI_GIAO.Enabled = true;
                    TxtDIA_CHI_GIAO.Enabled = true;
                    MskNGAY_XAC_NHAN.Enabled = true;
                    TxtNGUOI_XAC_NHAN.Enabled = true;
                    CboNHA_CUNG_CAP.Enabled = true;

                    cmbKho.Enabled = cmbLoaiVT.Enabled = true;
                    TxtDIA_CHI_NCC.Enabled = true;
                    TxtGHI_CHU.Enabled = true;
                    MskTHUE_VAT.Enabled = true;
                    MskFAX_NCC.Enabled = true;
                    MskDIEN_THOAI_NCC.Enabled = true;

                    DgvDonDatHang.ReadOnly = true;
                    DgvDonDatHang.Enabled = false;
                    DgvDonDatHang.AllowUserToAddRows = false;
                    DgvDonDatHang.AllowUserToDeleteRows = false;

                    DgvDonDatHangChiTiet.Enabled = true;
                    DgvDonDatHangChiTiet.ReadOnly = false;
                    DgvDonDatHangChiTiet.AllowUserToAddRows = false;
                    DgvDonDatHangChiTiet.AllowUserToDeleteRows = false;
                    foreach (DataGridViewColumn ClDonDatHangChiTiet in DgvDonDatHangChiTiet.Columns)
                    {
                        ClDonDatHangChiTiet.ReadOnly = true;
                    }
                    DgvDonDatHangChiTiet.Columns["SL_DAT_HANG"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["DON_GIA"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["THUE_VAT"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["NGOAI_TE"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["TY_GIA"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["TY_GIA_USD"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["NGAY_GIAO"].ReadOnly = false;
                    DgvDonDatHangChiTiet.Columns["GHI_CHU"].ReadOnly = false;

                    DgvDonDatHangDichVu.Enabled = true;
                    DgvDonDatHangDichVu.ReadOnly = false;
                    DgvDonDatHangDichVu.AllowUserToAddRows = true;
                    DgvDonDatHangDichVu.AllowUserToDeleteRows = false;
                    foreach (DataGridViewColumn ClDonDatHangDichVu in DgvDonDatHangDichVu.Columns)
                    {
                        ClDonDatHangDichVu.ReadOnly = true;
                    }
                    DgvDonDatHangDichVu.Columns["TEN_DICH_VU_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["DVT_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["SL_DAT_HANG_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["DON_GIA_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["NGOAI_TE_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["TY_GIA_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["TY_GIA_USD_DV"].ReadOnly = false;
                    DgvDonDatHangDichVu.Columns["GHI_CHU_DV"].ReadOnly = false;


                    DgvDonDatHangDieuKhoan.Enabled = true;
                    DgvDonDatHangDieuKhoan.ReadOnly = false;

                    if (Commons.Modules.sPrivate == "SHISEIDO")
                    {
                        DgvDonDatHangDieuKhoan.AllowUserToAddRows = false;
                        DgvDonDatHangDieuKhoan.AllowUserToDeleteRows = true;
                    }
                    else
                    {
                        DgvDonDatHangDieuKhoan.AllowUserToAddRows = true;
                        DgvDonDatHangDieuKhoan.AllowUserToDeleteRows = false;
                    }
                    foreach (DataGridViewColumn ClDieuKhoanHopDong in DgvDonDatHangDieuKhoan.Columns)
                    {
                        ClDieuKhoanHopDong.ReadOnly = true;
                    }
                    if (Commons.Modules.sPrivate == "SHISEIDO")
                    {
                        DgvDonDatHangDieuKhoan.Columns["TEN_DIEU_KHOAN_DK"].ReadOnly = true;
                    }
                    else
                    {
                        DgvDonDatHangDieuKhoan.Columns["TEN_DIEU_KHOAN_DK"].ReadOnly = false;
                    }

                    DgvDonDatHangDieuKhoan.Columns["NOI_DUNG_DIEU_KHOAN_DK"].ReadOnly = false;

                    DgvDuyetDonDatHang.Enabled = true;
                    DgvDuyetDonDatHang.ReadOnly = false;
                    DgvDuyetDonDatHang.AllowUserToAddRows = false;
                    DgvDuyetDonDatHang.AllowUserToDeleteRows = false;
                    foreach (DataGridViewColumn ClDuyetDonDatHang in DgvDuyetDonDatHang.Columns)
                    {
                        ClDuyetDonDatHang.ReadOnly = true;
                    }
                    DgvDuyetDonDatHang.Columns["NOI_DUNG"].ReadOnly = false;
                    DgvDuyetDonDatHang.Columns["DUYET"].ReadOnly = false;

                    BtnLuu.Visible = true;
                    BtnHuy.Visible = true;
                    BtnThem.Visible = false;
                    BtnSua.Visible = false;
                    BtnXoa.Visible = false;
                    BtnIn.Visible = false;
                    if (Commons.Modules.sPrivate == "SHISEIDO") btnInPR.Visible = false;
                    BtnThoat.Visible = false;
                    BtnTrinhDuyet.Visible = false;
                    btnCNDuyet.Visible = false;
                    BtnDong.Visible = false;
                    BtnChonPT.Visible = true;
                    btnAuto.Visible = true;
                    BtnChonDichVu.Visible = true;
                    btnAuto.Visible = true;
                    break;
                default:
                    txtTimKiem.Enabled = true;
                    btnTimCX.Enabled = true;

                    TxtSO_DON_DAT_HANG.Enabled = false;
                    MskNGAY_DAT_HANG.Enabled = false;
                    TxtNGUOI_DAT_HANG.Enabled = false;
                    MskNGAY_LIEN_HE.Enabled = false;
                    TxtNGUOI_LIEN_HE.Enabled = false;
                    MskNGAY_HD.Enabled = false;
                    TxtNGUOI_KY_HD.Enabled = false;
                    MskNGAY_GIAO.Enabled = false;
                    TxtNGUOI_GIAO.Enabled = false;
                    TxtDIA_CHI_GIAO.Enabled = false;
                    MskNGAY_XAC_NHAN.Enabled = false;
                    TxtNGUOI_XAC_NHAN.Enabled = false;
                    CboNHA_CUNG_CAP.Enabled = false;
                    cmbKho.Enabled = cmbLoaiVT.Enabled = false;
                    TxtDIA_CHI_NCC.Enabled = false;
                    TxtGHI_CHU.Enabled = false;
                    MskTHUE_VAT.Enabled = false;
                    MskFAX_NCC.Enabled = false;
                    MskDIEN_THOAI_NCC.Enabled = false;

                    DgvDonDatHang.ReadOnly = true;
                    DgvDonDatHang.Enabled = true;
                    DgvDonDatHang.AllowUserToAddRows = false;
                    DgvDonDatHang.AllowUserToDeleteRows = false;

                    DgvDonDatHangChiTiet.Enabled = true;
                    DgvDonDatHangChiTiet.ReadOnly = true;
                    DgvDonDatHangChiTiet.AllowUserToAddRows = false;
                    DgvDonDatHangChiTiet.AllowUserToDeleteRows = true;

                    DgvDonDatHangDichVu.Enabled = true;
                    DgvDonDatHangDichVu.ReadOnly = true;
                    DgvDonDatHangDichVu.AllowUserToAddRows = false;
                    DgvDonDatHangDichVu.AllowUserToDeleteRows = true;

                    DgvDonDatHangDieuKhoan.Enabled = true;
                    DgvDonDatHangDieuKhoan.ReadOnly = true;
                    DgvDonDatHangDieuKhoan.AllowUserToAddRows = false;
                    DgvDonDatHangDieuKhoan.AllowUserToDeleteRows = true;

                    DgvDuyetDonDatHang.Enabled = true;
                    DgvDuyetDonDatHang.ReadOnly = true;
                    DgvDuyetDonDatHang.AllowUserToAddRows = false;
                    DgvDuyetDonDatHang.AllowUserToDeleteRows = false;

                    BtnLuu.Visible = false;
                    BtnHuy.Visible = false;
                    BtnThem.Visible = true;
                    BtnChonPT.Visible = false;
                    btnAuto.Visible = false;
                    BtnChonDichVu.Visible = false;
                    btnAuto.Visible = false;
                    BtnThoat.Visible = true;
                    if (BindingDonDatHang.Count > 0)
                    {
                        BtnSua.Visible = true;
                        BtnXoa.Visible = true;
                        BtnIn.Visible = true;
                        if (Commons.Modules.sPrivate == "SHISEIDO") btnInPR.Visible = true;

                        BtnTrinhDuyet.Visible = true;
                        btnCNDuyet.Visible = true;
                        BtnDong.Visible = true;
                    }
                    else
                    {
                        BtnSua.Visible = false;
                        BtnXoa.Visible = false;
                        BtnIn.Visible = false;
                        if (Commons.Modules.sPrivate == "SHISEIDO") btnInPR.Visible = false;

                        BtnTrinhDuyet.Visible = false;
                        btnCNDuyet.Visible = false;
                        BtnDong.Visible = false;
                    }
                    break;
            }
            InitializeControl();
        }
        /// <summary>
        /// Gắn source
        /// </summary>
        private void BindingControl()
        {
            //lblUserID.DataBindings.Clear();
            //lblUserID.DataBindings.Add("Text", BindingDonDatHang, "UserID");
            TxtMS_DON_DAT_HANG.DataBindings.Clear();
            TxtMS_DON_DAT_HANG.DataBindings.Add("Text", BindingDonDatHang, "MS_DON_DAT_HANG");
            TxtSO_DON_DAT_HANG.DataBindings.Clear();
            TxtSO_DON_DAT_HANG.DataBindings.Add("Text", BindingDonDatHang, "SO_DON_DAT_HANG");
            MskNGAY_DAT_HANG.DataBindings.Clear();
            MskNGAY_DAT_HANG.DataBindings.Add("Text", BindingDonDatHang, "NGAY_DAT", false, DataSourceUpdateMode.OnPropertyChanged);
            TxtNGUOI_DAT_HANG.DataBindings.Clear();
            TxtNGUOI_DAT_HANG.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_DAT");
            MskNGAY_LIEN_HE.DataBindings.Clear();
            MskNGAY_LIEN_HE.DataBindings.Add("Text", BindingDonDatHang, "NGAY_LIEN_HE");
            TxtNGUOI_LIEN_HE.DataBindings.Clear();
            TxtNGUOI_LIEN_HE.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_LIEN_HE");
            MskNGAY_HD.DataBindings.Clear();
            MskNGAY_HD.DataBindings.Add("Text", BindingDonDatHang, "NGAY_KY_HD");
            TxtNGUOI_KY_HD.DataBindings.Clear();
            TxtNGUOI_KY_HD.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_KY_HD");
            MskNGAY_GIAO.DataBindings.Clear();
            MskNGAY_GIAO.DataBindings.Add("Text", BindingDonDatHang, "NGAY_GIAO");
            TxtNGUOI_GIAO.DataBindings.Clear();
            TxtNGUOI_GIAO.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_GIAO");
            TxtDIA_CHI_GIAO.DataBindings.Clear();
            TxtDIA_CHI_GIAO.DataBindings.Add("Text", BindingDonDatHang, "DIA_CHI_GIAO");
            MskNGAY_XAC_NHAN.DataBindings.Clear();
            MskNGAY_XAC_NHAN.DataBindings.Add("Text", BindingDonDatHang, "NGAY_XAC_NHAN");
            TxtNGUOI_XAC_NHAN.DataBindings.Clear();
            TxtNGUOI_XAC_NHAN.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_XAC_NHAN");

            CboNHA_CUNG_CAP.DataBindings.Clear();
            CboNHA_CUNG_CAP.DataBindings.Add("Text", BindingDonDatHang, "NHA_CUNG_CAP");
            cmbKho.DataBindings.Clear();

            try
            {

                cmbKho.DataBindings.Add("SelectedValue", BindingDonDatHang, "MS_Kho");

            }
            catch { cmbKho.SelectedValue = "-1"; }
            cmbLoaiVT.DataBindings.Clear();
            try
            {

                cmbLoaiVT.DataBindings.Add("SelectedValue", BindingDonDatHang, "MS_LOAI_VT");

            }
            catch
            {
                cmbLoaiVT.SelectedValue = "-1";
            }
            TxtDIA_CHI_NCC.DataBindings.Clear();
            TxtDIA_CHI_NCC.DataBindings.Add("Text", BindingDonDatHang, "DIA_CHI_NCC", false, DataSourceUpdateMode.OnPropertyChanged);
            TxtGHI_CHU.DataBindings.Clear();
            TxtGHI_CHU.DataBindings.Add("Text", BindingDonDatHang, "GHI_CHU");
            TxtNGUOI_LAP.DataBindings.Clear();
            TxtNGUOI_LAP.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_LAP");
            MskNGAY_LAP.DataBindings.Clear();
            MskNGAY_LAP.DataBindings.Add("Text", BindingDonDatHang, "NGAY_LAP");
            TxtNGUOI_SUA.DataBindings.Clear();
            TxtNGUOI_SUA.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_SUA");
            MskNGAY_SUA.DataBindings.Clear();
            MskNGAY_SUA.DataBindings.Add("Text", BindingDonDatHang, "NGAY_SUA");
            TxtNGUOI_DUYET.DataBindings.Clear();
            TxtNGUOI_DUYET.DataBindings.Add("Text", BindingDonDatHang, "NGUOI_DUYET");
            MskNGAY_DUYET.DataBindings.Clear();
            MskNGAY_DUYET.DataBindings.Add("Text", BindingDonDatHang, "NGAY_DUYET");
            TxtTINH_TRANG.DataBindings.Clear();
            TxtTINH_TRANG.DataBindings.Add("Text", BindingDonDatHang, "TEN_TRANG_THAI");
            MskTHUE_VAT.DataBindings.Clear();
            MskTHUE_VAT.DataBindings.Add("Text", BindingDonDatHang, "THUE_VAT");
            MskFAX_NCC.DataBindings.Clear();
            MskFAX_NCC.DataBindings.Add("Text", BindingDonDatHang, "FAX_NCC", false, DataSourceUpdateMode.OnPropertyChanged);
            MskDIEN_THOAI_NCC.DataBindings.Clear();
            MskDIEN_THOAI_NCC.DataBindings.Add("Text", BindingDonDatHang, "DIEN_THOAI_NCC", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        void TbDonDatHang_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DON_DAT_HANG"] = Vietsoft.Information.GetID("DH");
            try
            {
                DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
                if (Commons.Modules.iDefault == 1 | Commons.Modules.iDefault == 2)
                {
                    if (Commons.Modules.sPrivate == "SHISEIDO")
                    {
                
                        e.Row["SO_DON_DAT_HANG"] = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetSoDonHangSSD", "PO", Commons.Modules.UserName));
                    }
                    else
                    {
                        e.Row["SO_DON_DAT_HANG"] = e.Row["MS_DON_DAT_HANG"];
                    }
                }
                e.Row["NGAY_LIEN_HE"] = NgayHT.ToShortDateString();
                e.Row["NGAY_KY_HD"] = NgayHT.ToShortDateString();
                e.Row["NGAY_GIAO"] = NgayHT.ToShortDateString();
                e.Row["NGAY_XAC_NHAN"] = NgayHT.ToShortDateString();
                e.Row["NGUOI_DAT"] = Commons.Modules.sTenNhanVienMD;
                if (Commons.Modules.iMaKhoMD != -1) e.Row["MS_KHO"] = Commons.Modules.iMaKhoMD;
            }
            catch { }
        }
        void TbDonDatHangChiTiet_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_CHI_TIET_DH"] = Vietsoft.Information.GetID("CT");
        }
        void TbDonDatHangDichVu_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DICH_VU"] = Vietsoft.Information.GetID("DV");
        }
        void TbDonDatHangDieuKhoan_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DIEU_KHOAN"] = Vietsoft.Information.GetID("DK");
        }
        /// <summary>
        /// Chọn dữ liệu mới
        /// </summary>        
        void BindingDonDatHang_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                TbDonDatHangChiTiet.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangChiTiet.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangChiTiet.DefaultView.RowFilter = "0=1";
            }
            try
            {
                TbDonDatHangDichVu.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangDichVu.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangDichVu.DefaultView.RowFilter = "0=1";
            }
            try
            {
                TbDonDatHangDieuKhoan.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDonDatHangDieuKhoan.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDonDatHangDieuKhoan.DefaultView.RowFilter = "0=1";
            }
            try
            {
                TbDuyetDonDatHang.Columns["MS_DON_DAT_HANG"].DefaultValue = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                TbDuyetDonDatHang.DefaultView.RowFilter = "MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString().Trim() + "'";
            }
            catch
            {
                TbDuyetDonDatHang.DefaultView.RowFilter = "0=1";
            }
            GetTotal();
            InitializeForm();
        }
        private void InitializeControl()
        {
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDonDatHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"])
                    {
                        case 4://dong
                            BtnSua.Visible = false;
                            BtnXoa.Visible = false;
                            BtnTrinhDuyet.Visible = false;
                            btnCNDuyet.Visible = false;
                            BtnDong.Visible = false;
                            break;
                        case 3://duyet
                            BtnDong.Visible = true;
                            BtnTrinhDuyet.Visible = false;
                            btnCNDuyet.Visible = false;
                            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"].ToString().Trim().ToUpper().Equals(Commons.Modules.UserName.ToUpper()))
                            {
                                if ((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_DON_DAT_HANG_DON_HANG_NHAP", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"]) > 0)
                                {
                                    BtnSua.Visible = false;
                                    BtnXoa.Visible = false;
                                }
                                else
                                {
                                    BtnSua.Visible = true;
                                    BtnXoa.Visible = true;
                                }
                            }
                            else
                            {
                                BtnSua.Visible = false;
                                BtnXoa.Visible = false;
                            }
                            break;
                        case 2://trinh duyệt
                            BtnDong.Visible = false;
                            BtnTrinhDuyet.Visible = false;
                            btnCNDuyet.Visible = false;
                            if ((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DON_DAT_HANG", Commons.Modules.UserName, ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"]) > 0)
                            {
                                BtnSua.Visible = true;
                                BtnXoa.Visible = true;
                                btnCNDuyet.Visible = true;
                            }
                            else
                            {
                                BtnSua.Visible = false;
                                BtnXoa.Visible = false;
                                btnCNDuyet.Visible = true;
                            }
                            break;
                        case 1://dang soan
                            BtnDong.Visible = false;
                            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim()))
                            {
                                BtnSua.Visible = true;
                                BtnXoa.Visible = true;
                                BtnTrinhDuyet.Visible = true;
                                btnCNDuyet.Visible = true;
                            }
                            else
                            {

                                BtnSua.Visible = false;
                                BtnXoa.Visible = false;
                                BtnTrinhDuyet.Visible = false;
                                btnCNDuyet.Visible = false;
                            }
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Load form
        /// </summary>
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            sPrivate = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 PRIVATE FROM THONG_TIN_CHUNG").ToString();
            InitializeDatabase();
            InitializeForm();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if (sPrivate == "DOFICO")
            {
                this.LabNGAY_HD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LabNGUOI_KY_HD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LabNHA_CUNG_CAP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            btnTimCX.Text = "...";
            if (Commons.Modules.sPrivate != "SHISEIDO") btnInPR.Visible = false;

        }
        /// <summary>
        /// Thêm dữ liệu
        /// </summary> 
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                cmbLoaiVT.SelectedValue = "-1";
                cmbKho.SelectedValue = "-1";

                Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                BindingDonDatHang.AddNew();

                TrangThai = "Add";
                DataTable TbDuyetDonDH = new DataTable();
                TbDuyetDonDH.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DON_DH", Commons.Modules.UserName));
                foreach (DataColumn ClDuyetDonDH in TbDuyetDonDH.Columns)
                {
                    ClDuyetDonDH.ReadOnly = false;
                    ClDuyetDonDH.AllowDBNull = true;
                }
                foreach (DataRow rDuyetDonDH in TbDuyetDonDH.Rows)
                {
                    rDuyetDonDH["MS_DON_DAT_HANG"] = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                    TbDuyetDonDatHang.Rows.Add(rDuyetDonDH.ItemArray);
                }


                DataTable TbDieuKhoanDH = new DataTable();
                TbDieuKhoanDH.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DIEU_KHOAN_HD"));
                foreach (DataRow rDieuKhoanHD in TbDieuKhoanDH.Rows)
                {
                    DataRow rDieuKhoan = TbDonDatHangDieuKhoan.NewRow();
                    rDieuKhoan["MS_DON_DAT_HANG"] = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"];
                    rDieuKhoan["TEN_DIEU_KHOAN"] = rDieuKhoanHD["TEN_DIEU_KHOAN"];
                    rDieuKhoan["NOI_DUNG_DIEU_KHOAN"] = rDieuKhoanHD["NOI_DUNG_DIEU_KHOAN"];
                    TbDonDatHangDieuKhoan.Rows.Add(rDieuKhoan);
                }

                MskNGAY_DAT_HANG.Text = Commons.Modules.ObjSystems.GetNgayHeThong().ToShortDateString();
                InitializeForm();
                tblCondition.Enabled = false;
                if (sPrivate.Trim().ToUpper() == "DOFICO")
                {
                    TxtNGUOI_GIAO.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDonDatHang_New", "DeNghiNhapKho1", Commons.Modules.TypeLanguage);
                    TxtDIA_CHI_GIAO.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDonDatHang_New", "DeNghiNhapKho2", Commons.Modules.TypeLanguage);
                }
                TxtNGUOI_DAT_HANG.Text = Commons.Modules.sTenNhanVienMD;
                if (Commons.Modules.sPrivate == "SHISEIDO")
                {
                    TxtSO_DON_DAT_HANG.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetSoDonHangSSD", "PO", Commons.Modules.UserName));
                }
            }
            catch { }
            if (Commons.Modules.iDefault == 2) TxtSO_DON_DAT_HANG.Enabled = false;
        }
        /// <summary> 
        /// Sửa dữ liệu
        /// </summary> 
        private void BtnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "Edit";
            InitializeForm();
            cmbLoaiVT.Enabled = cmbKho.Enabled = false;
            tblCondition.Enabled = false;
            if (Commons.Modules.iDefault == 2) TxtSO_DON_DAT_HANG.Enabled = false;
        }
        /// <summary>
        /// Chọn vật tư phụ tùng
        /// </summary> 
        private void BtnChonPT_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonPTDatHang frmPhuTung = new frmChonPTDatHang();
                frmPhuTung.CurrentSource = TbDonDatHangChiTiet.DefaultView.ToTable();
                DataTable _table = new DataTable();
                _table = TbDonDatHangChiTiet.DefaultView.ToTable();
                string _ms_pt = "";
                if (frmPhuTung.ShowDialog(this) == DialogResult.OK)
                {
                    frmPhuTung.DataSource.DefaultView.RowFilter = "CHON = 1";
                    for (int i = 0; i < frmPhuTung.DataSource.DefaultView.Count; i++)
                    {
                        DataRow rDonDatHangChiTiet = TbDonDatHangChiTiet.NewRow();
                        rDonDatHangChiTiet["MS_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];

                        _ms_pt = "MS_PT='" + frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"] + "'";
                        DataTable _new_table = new DataTable();
                        _new_table = _table;
                        _new_table.DefaultView.RowFilter = _ms_pt;
                        _new_table = _new_table.DefaultView.ToTable();
                        if (_new_table.Rows.Count > 0)
                        {
                            DialogResult res = Vietsoft.Information.MsgBox(this, "MsgMSPTDuplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            if (DialogResult.Yes.Equals(res))
                            {
                                rDonDatHangChiTiet["MS_PT_CTY"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT_CTY"];
                                rDonDatHangChiTiet["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                                rDonDatHangChiTiet["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["PART_NO"];
                                rDonDatHangChiTiet["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];
                                rDonDatHangChiTiet["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["DVT"];
                                rDonDatHangChiTiet["MS_DE_XUAT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"];
                                rDonDatHangChiTiet["DON_GIA"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA"];


                                if (string.IsNullOrEmpty(frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"].ToString()))
                                    if (Commons.Modules.sTienTeMD != "") rDonDatHangChiTiet["NGOAI_TE"] = Commons.Modules.sTienTeMD;
                                    else rDonDatHangChiTiet["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"];
                                else
                                    rDonDatHangChiTiet["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"];


                                rDonDatHangChiTiet["THUE_VAT"] = frmPhuTung.DataSource.DefaultView[i].Row["THUE_VAT"];
                                if (frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"] != null && !frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"].Equals(DBNull.Value) && !frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"].ToString().Trim().Equals(String.Empty))
                                {
                                    rDonDatHangChiTiet["SL_DE_XUAT"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"];
                                    rDonDatHangChiTiet["SL_DAT_HANG"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"];
                                    rDonDatHangChiTiet["GHI_CHU"] = frmPhuTung.DataSource.DefaultView[i].Row["GHI_CHU"];
                                }
                                else
                                {
                                    rDonDatHangChiTiet["SL_DE_XUAT"] = 1;
                                    rDonDatHangChiTiet["SL_DAT_HANG"] = 1;
                                }
                                try
                                {
                                    Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                                    DataTable TbNgoaiTe = new DataTable();
                                    TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDonDatHangChiTiet["NGOAI_TE"]));
                                    if (TbNgoaiTe.Rows.Count > 0)
                                    {
                                        rDonDatHangChiTiet["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                                        rDonDatHangChiTiet["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                                        try
                                        {
                                            rDonDatHangChiTiet["THANH_TIEN"] = Convert.ToDouble(rDonDatHangChiTiet["SL_DAT_HANG"]) * Convert.ToDouble(rDonDatHangChiTiet["DON_GIA"]);
                                        }
                                        catch { rDonDatHangChiTiet["THANH_TIEN"] = 0; }
                                        rDonDatHangChiTiet["THANH_TIEN_VND"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA"]);
                                        rDonDatHangChiTiet["THANH_TIEN_USD"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA_USD"]);
                                    }
                                }
                                catch
                                {
                                }
                                TbDonDatHangChiTiet.Rows.Add(rDonDatHangChiTiet);
                            }
                        }
                        else
                        {
                            rDonDatHangChiTiet["MS_PT_CTY"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT_CTY"];
                            rDonDatHangChiTiet["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                            rDonDatHangChiTiet["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["PART_NO"];
                            rDonDatHangChiTiet["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];
                            rDonDatHangChiTiet["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["DVT"];
                            rDonDatHangChiTiet["MS_DE_XUAT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"];
                            rDonDatHangChiTiet["DON_GIA"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA"];
                            rDonDatHangChiTiet["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"];
                            rDonDatHangChiTiet["THUE_VAT"] = frmPhuTung.DataSource.DefaultView[i].Row["THUE_VAT"];
                            if (frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"] != null && !frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"].Equals(DBNull.Value) && !frmPhuTung.DataSource.DefaultView[i].Row["MS_DE_XUAT"].ToString().Trim().Equals(String.Empty))
                            {
                                rDonDatHangChiTiet["SL_DE_XUAT"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"];
                                rDonDatHangChiTiet["SL_DAT_HANG"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"];
                                rDonDatHangChiTiet["GHI_CHU"] = frmPhuTung.DataSource.DefaultView[i].Row["GHI_CHU"];
                            }
                            else
                            {
                                rDonDatHangChiTiet["SL_DE_XUAT"] = 1;
                                rDonDatHangChiTiet["SL_DAT_HANG"] = 1;
                            }
                            try
                            {
                                Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                                DataTable TbNgoaiTe = new DataTable();
                                TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDonDatHangChiTiet["NGOAI_TE"]));
                                if (TbNgoaiTe.Rows.Count > 0)
                                {
                                    rDonDatHangChiTiet["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                                    rDonDatHangChiTiet["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                                    rDonDatHangChiTiet["THANH_TIEN"] = Convert.ToDouble(rDonDatHangChiTiet["SL_DAT_HANG"]) * Convert.ToDouble(rDonDatHangChiTiet["DON_GIA"]);
                                    rDonDatHangChiTiet["THANH_TIEN_VND"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA"]);
                                    rDonDatHangChiTiet["THANH_TIEN_USD"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA_USD"]);
                                }
                            }
                            catch
                            {
                            }
                            TbDonDatHangChiTiet.Rows.Add(rDonDatHangChiTiet);
                        }

                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// Chọn dịch vụ
        /// </summary> 
        private void BtnChonDichVu_Click(object sender, EventArgs e)
        {
            frmChonDichVu frmDichVu = new frmChonDichVu();
            frmDichVu.Name = "frmChonDichVuDatHang";
            frmDichVu.CurrentSource = TbDonDatHangDichVu.DefaultView.ToTable();
            if (frmDichVu.ShowDialog(this) == DialogResult.OK)
            {
                frmDichVu.DataSource.DefaultView.RowFilter = "CHON = true";
                for (int j = 0; j < frmDichVu.DataSource.DefaultView.Count; j++)
                {
                    DataRow rDichVu = TbDonDatHangDichVu.NewRow();
                    rDichVu["MS_DE_XUAT"] = frmDichVu.DataSource.DefaultView[j].Row["MS_DE_XUAT"];
                    rDichVu["MS_DICH_VU"] = frmDichVu.DataSource.DefaultView[j].Row["MS_DICH_VU"];
                    rDichVu["TEN_DICH_VU"] = frmDichVu.DataSource.DefaultView[j].Row["TEN_DICH_VU"];
                    rDichVu["DVT"] = frmDichVu.DataSource.DefaultView[j].Row["DVT"];
                    rDichVu["SL_DAT_HANG"] = frmDichVu.DataSource.DefaultView[j].Row["SO_LUONG_DE_XUAT"];
                    rDichVu["DON_GIA"] = frmDichVu.DataSource.DefaultView[j].Row["DON_GIA"];
                    rDichVu["NGOAI_TE"] = frmDichVu.DataSource.DefaultView[j].Row["NGOAI_TE"];
                    try
                    {
                        Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        DataTable TbNgoaiTe = new DataTable();
                        TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDichVu["NGOAI_TE"]));
                        if (TbNgoaiTe.Rows.Count > 0)
                        {
                            rDichVu["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                            rDichVu["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            rDichVu["THANH_TIEN"] = Convert.ToDouble(rDichVu["SL_DAT_HANG"]) * Convert.ToDouble(rDichVu["DON_GIA"]);
                            rDichVu["THANH_TIEN_VND"] = Convert.ToDouble(rDichVu["THANH_TIEN"]) * Convert.ToDouble(rDichVu["TY_GIA"]);
                            rDichVu["THANH_TIEN_USD"] = Convert.ToDouble(rDichVu["THANH_TIEN"]) * Convert.ToDouble(rDichVu["TY_GIA_USD"]);
                        }
                    }
                    catch
                    {
                    }
                    rDichVu["GHI_CHU"] = frmDichVu.DataSource.DefaultView[j].Row["GHI_CHU"];
                    TbDonDatHangDichVu.Rows.Add(rDichVu);
                }
            }
        }
        /// <summary>
        /// Xóa dữ liệu
        /// </summary> 
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                SqlDonDatHang.BeginTransaction();
                try
                {
                    Vietsoft.DataInfo.DeleteDataView(SqlDonDatHang, "SP_Y_DELETE_DON_DAT_HANG_CHI_TIET", TbDonDatHangChiTiet.DefaultView, "MS_DON_DAT_HANG", "MS_PT", "MS_CHI_TIET_DH");
                    Vietsoft.DataInfo.DeleteDataView(SqlDonDatHang, "SP_Y_DELETE_DON_DAT_HANG_DICH_VU", TbDonDatHangDichVu.DefaultView, "MS_DON_DAT_HANG", "MS_DICH_VU");
                    Vietsoft.DataInfo.DeleteDataView(SqlDonDatHang, "SP_Y_DELETE_DON_DAT_HANG_DIEU_KHOAN", TbDonDatHangDieuKhoan.DefaultView, "MS_DON_DAT_HANG", "MS_DIEU_KHOAN");
                    Vietsoft.DataInfo.DeleteDataView(SqlDonDatHang, "SP_Y_DELETE_DUYET_DON_DAT_HANG", TbDuyetDonDatHang.DefaultView, "MS_DON_DAT_HANG", "NGUOI_DUYET");
                    Vietsoft.DataInfo.DeleteDataRow(SqlDonDatHang, "SP_Y_DELETE_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row, "MS_DON_DAT_HANG");
                    Vietsoft.DataInfo.ClearData(TbDonDatHangChiTiet.DefaultView);
                    Vietsoft.DataInfo.ClearData(TbDonDatHangDichVu.DefaultView);
                    Vietsoft.DataInfo.ClearData(TbDonDatHangDieuKhoan.DefaultView);
                    Vietsoft.DataInfo.ClearData(TbDuyetDonDatHang.DefaultView);
                    BindingDonDatHang.RemoveCurrent();
                    TbDonDatHang.AcceptChanges();
                    TbDonDatHangChiTiet.AcceptChanges();
                    TbDonDatHangDichVu.AcceptChanges();
                    TbDonDatHangDieuKhoan.AcceptChanges();
                    TbDuyetDonDatHang.AcceptChanges();
                    SqlDonDatHang.CommitTransaction();
                    InitializeForm();
                }
                catch
                {
                    SqlDonDatHang.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void DgvDonDatHangChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDonDatHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            e.Cancel = true;
                            return;
                        case 3:
                            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"].ToString().Trim().ToUpper().Equals(Commons.Modules.UserName.ToUpper()))
                            {
                                if ((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_DON_DAT_HANG_DON_HANG_NHAP", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"]) > 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 2:
                            if (!((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DON_DAT_HANG", Commons.Modules.UserName) > 0 || ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 1:
                            if (!(((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                    }
                }
            }
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Vietsoft.DataInfo.DeleteDataRow(Vietsoft.Information.ConnectionString, "SP_Y_DELETE_DON_DAT_HANG_CHI_TIET", ((DataRowView)e.Row.DataBoundItem).Row, "MS_DON_DAT_HANG", "MS_PT", "MS_CHI_TIET_DH");
                }
                catch
                {
                    e.Cancel = true;
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void DgvDonDatHangChiTiet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbDonDatHangChiTiet.AcceptChanges();
        }
        private void DgvDonDatHangDichVu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDonDatHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            e.Cancel = true;
                            return;
                        case 3:
                            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"].ToString().Trim().ToUpper().Equals(Commons.Modules.UserName.ToUpper()))
                            {
                                if ((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_DON_DAT_HANG_DON_HANG_NHAP", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"]) > 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 2:
                            if (!((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DON_DAT_HANG", Commons.Modules.UserName) > 0 || ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 1:
                            if (!(((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                    }
                }
            }

            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Vietsoft.DataInfo.DeleteDataRow(Vietsoft.Information.ConnectionString, "SP_Y_DELETE_DON_DAT_HANG_DICH_VU", ((DataRowView)e.Row.DataBoundItem).Row, "MS_DON_DAT_HANG", "MS_DICH_VU");
                }
                catch
                {
                    e.Cancel = true;
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void DgvDonDatHangDichVu_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbDonDatHangDichVu.AcceptChanges();
        }
        private void DgvDonDatHangDieuKhoan_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Commons.Modules.sPrivate == "SHISEIDO")
            {
                e.Cancel = true;
                return;
            }
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDonDatHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            e.Cancel = true;
                            return;
                        case 3:
                            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"].ToString().Trim().ToUpper().Equals(Commons.Modules.UserName.ToUpper()))
                            {
                                if ((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_DON_DAT_HANG_DON_HANG_NHAP", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"]) > 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 2:
                            if (!((int)SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DON_DAT_HANG", Commons.Modules.UserName) > 0 || ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 1:
                            if (!(((DataRowView)BindingDonDatHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                    }
                }
            }
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Vietsoft.DataInfo.DeleteDataRow(Vietsoft.Information.ConnectionString, "SP_Y_DELETE_DON_DAT_HANG_DIEU_KHOAN", ((DataRowView)e.Row.DataBoundItem).Row, "MS_DON_DAT_HANG", "MS_DIEU_KHOAN");
                }
                catch
                {
                    e.Cancel = true;
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private string Company
        {
            get
            {
                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                return SqlPhieuNhapKho.ExecuteScalar(CommandType.Text, "SELECT TOP 1 PRIVATE FROM THONG_TIN_CHUNG").ToString();
            }
        }
        private void DgvDonDatHangDieuKhoan_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbDonDatHangDieuKhoan.AcceptChanges();
        }
        /// <summary>
        /// Lọc dữ liệu
        /// </summary> 

        /// <summary>
        /// In dữ liệu
        /// </summary> 
        private void BtnIn_Click(object sender, EventArgs e)
        {
            try
            {
                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                if (Commons.Modules.sPrivate.Trim().ToUpper() == "SHISEIDO")
                {
                    InSSD();
                    return;
                }
                if (Commons.Modules.sPrivate.Trim().ToUpper() == "ADC")
                {
                    InRongAChau();
                    return;
                }
                if (sPrivate.Trim().ToUpper() == "VINHHOAN")
                {
                    InDonDatHangVinhHoan();
                    return;
                }
                if (sPrivate.Trim().ToUpper() == "DOFICO")
                {
                    InDeNghiNhapKhoDoFiCo();
                    return;
                }
                if (sPrivate.Trim().ToUpper() == "ACECOOK")
                {
                    InDonDatHangACE();
                    return;
                }
                frmReport frmRptDatHang = new frmReport();

                if (sPrivate.Trim().ToUpper() == "CS")
                    frmRptDatHang.rptName = "rptDonDatHangCS";
                else
                    frmRptDatHang.rptName = "rptDonDatHangNew";

                DataTable TbDDH = new DataTable();
                TbDDH.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DDH_RPT", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"], Commons.Modules.TypeLanguage));
                TbDDH.TableName = "rptHonDatHang";
                frmRptDatHang.AddDataTableSource(TbDDH);
                DataTable TbPT = new DataTable();
                TbPT.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DDH_PT_RPT", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"], Commons.Modules.TypeLanguage));
                TbPT.TableName = "rptHonDatHangPT";
                frmRptDatHang.AddDataTableSource(TbPT);
                DataTable TbDV = new DataTable();
                TbDV.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DDH_DV_RPT", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"], Commons.Modules.TypeLanguage));
                TbDV.TableName = "rptDonDatHangDV";
                frmRptDatHang.AddDataTableSource(TbDV);
                DataTable TbDK = new DataTable();
                TbDK.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DDH_DK_RPT", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"], Commons.Modules.TypeLanguage));
                TbDK.TableName = "rptDonDatHangDK";
                frmRptDatHang.AddDataTableSource(TbDK);
                DataTable TbDU = new DataTable();
                TbDU.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DDH_DU_RPT", ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"], Commons.Modules.TypeLanguage));
                TbDU.TableName = "rptDonDatHangDU";
                frmRptDatHang.AddDataTableSource(TbDU);

                DataTable TbTieuDe = new DataTable();
                TbTieuDe.Columns.Add("TIEU_DE");
                TbTieuDe.Columns.Add("DS_VTPT");
                TbTieuDe.Columns.Add("DS_DICH_VU");
                TbTieuDe.Columns.Add("MS_DDH");
                TbTieuDe.Columns.Add("SO_DDH");
                TbTieuDe.Columns.Add("NCC");
                TbTieuDe.Columns.Add("NGUOI_LH");
                TbTieuDe.Columns.Add("NGUOI_DH");
                TbTieuDe.Columns.Add("NGAY_LAP");
                TbTieuDe.Columns.Add("NGAY_GIAO");
                TbTieuDe.Columns.Add("SO_DX");
                TbTieuDe.Columns.Add("GHI_CHU_DH");
                TbTieuDe.Columns.Add("NGUOI_KY_1");
                TbTieuDe.Columns.Add("NGUOI_KY_2");
                TbTieuDe.Columns.Add("NGUOI_KY_3");
                TbTieuDe.Columns.Add("NGUOI_KY_4");
                TbTieuDe.Columns.Add("NGUOI_KY_5");
                TbTieuDe.Columns.Add("NGUOI_KY_6");
                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MS_PT");
                TbTieuDe.Columns.Add("TEN_PT");
                TbTieuDe.Columns.Add("QUY_CACH");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("TON_MIN");
                TbTieuDe.Columns.Add("TON_MAX");
                TbTieuDe.Columns.Add("TON_KHO");
                TbTieuDe.Columns.Add("SO_LUONG");
                TbTieuDe.Columns.Add("SL_CTU");
                TbTieuDe.Columns.Add("SL_DH");
                TbTieuDe.Columns.Add("DON_GIA_VND");
                TbTieuDe.Columns.Add("THANH_TIEN_VND");
                TbTieuDe.Columns.Add("GHI_CHU");
                TbTieuDe.Columns.Add("TEN_DICH_VU");
                TbTieuDe.Columns.Add("DVT_DV");
                TbTieuDe.Columns.Add("SO_LUONG_DV");
                TbTieuDe.Columns.Add("DON_GIA_DV_VND");
                TbTieuDe.Columns.Add("THANH_TIEN_DV_VND");
                TbTieuDe.Columns.Add("GHI_CHU_DV");
                TbTieuDe.Columns.Add("TONG_PT");
                TbTieuDe.Columns.Add("TONG_DV");
                DataRow rTitle = TbTieuDe.NewRow();
                rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TIEU_DE", Commons.Modules.TypeLanguage);
                rTitle["DS_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DS_VTPT", Commons.Modules.TypeLanguage);
                rTitle["DS_DICH_VU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DS_DICH_VU", Commons.Modules.TypeLanguage);
                rTitle["MS_DDH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "MS_DDH", Commons.Modules.TypeLanguage);
                rTitle["SO_DDH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SO_DDH", Commons.Modules.TypeLanguage);
                rTitle["NCC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NCC", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_LH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_LH", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_DH", Commons.Modules.TypeLanguage);
                rTitle["NGAY_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGAY_LAP", Commons.Modules.TypeLanguage);
                rTitle["NGAY_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGAY_GIAO", Commons.Modules.TypeLanguage);
                rTitle["SO_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SO_DX", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "GHI_CHU_DX", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_1", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_2", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_3", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_4", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_5", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_KY_6"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "NGUOI_KY_6", Commons.Modules.TypeLanguage);
                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "STT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TEN_PT", Commons.Modules.TypeLanguage);
                rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "QUY_CACH", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DVT", Commons.Modules.TypeLanguage);
                rTitle["TON_MIN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TON_MIN", Commons.Modules.TypeLanguage);
                rTitle["TON_MAX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TON_MAX", Commons.Modules.TypeLanguage);
                rTitle["TON_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TON_KHO", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SO_LUONG", Commons.Modules.TypeLanguage);
                rTitle["SL_CTU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SL_CTU", Commons.Modules.TypeLanguage);
                rTitle["SL_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SL_DH", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DON_GIA_VND", Commons.Modules.TypeLanguage);
                rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "THANH_TIEN_VND", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "GHI_CHU", Commons.Modules.TypeLanguage);
                rTitle["TEN_DICH_VU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TEN_DICH_VU", Commons.Modules.TypeLanguage);
                rTitle["DVT_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DVT_DV", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "SO_LUONG_DV", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA_DV_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "DON_GIA_DV_VND", Commons.Modules.TypeLanguage);
                rTitle["THANH_TIEN_DV_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "THANH_TIEN_DV_VND", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "GHI_CHU_DV", Commons.Modules.TypeLanguage);
                rTitle["TONG_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TONG_PT", Commons.Modules.TypeLanguage);
                rTitle["TONG_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangNew", "TONG_DV", Commons.Modules.TypeLanguage);
                TbTieuDe.TableName = "rptTieuDeDonDatHangNew";
                TbTieuDe.Rows.Add(rTitle);
                frmRptDatHang.AddDataTableSource(TbTieuDe);
                frmRptDatHang.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSO_DON_DAT_HANG.Focus();
                return;
            }
        }
        private void DinhDangText(ref ExcelWorksheet ws, string Cot, string text, bool bold = false, bool fill = false, bool merge = false, string CotFill = "", bool wraptext = false)
        {
            ws.Cells[Cot].Value = text;
            if (bold == true)
                ws.Cells[Cot].Style.Font.Bold = true;
            if (fill == true)
            {
                ws.Cells[CotFill].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[CotFill].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ccc"));
            }
            if (merge == true)
                ws.Cells[CotFill].Merge = true;
            if (wraptext == true)
                ws.Cells[CotFill].Style.WrapText = true;
        }
        private void InSSD()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDonHangChiTiet", TxtMS_DON_DAT_HANG.Text));
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Cursor = Cursors.Default;
                    return;
                }
                string sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;

                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "sheetPurchaseOrder", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"

                System.Data.DataTable dtTmp = new System.Data.DataTable();

                string sSql = "";
                sSql = " SELECT CASE WHEN " + Commons.Modules.TypeLanguage.ToString() + "=0 " + " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " + " CASE WHEN " + Commons.Modules.TypeLanguage + " = 0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI, Phone," + " Fax,EMAIL, MS_THUE FROM THONG_TIN_CHUNG ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));

                using (var range = ws.Cells["A1:AZ1000"])
                {
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.SetFromFont(new Font("Times New Roman", 14));
                }
                int iDong = 0;

                ws.Cells[2, 2, 2, 15].Merge = true;
                ws.Cells[2, 2, 2, 15].Style.Font.Size = 14;
                ws.Cells[2, 2, 2, 15].Style.Font.Bold = true;
                ws.Cells[2, 2, 2, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[2, 2, 2, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[3, 2, 3, 15].Merge = true;
                ws.Cells[3, 2, 3, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[3, 2, 3, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[4, 2, 4, 15].Merge = true;
                ws.Cells[4, 2, 4, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[4, 2, 4, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[5, 2, 5, 15].Merge = true;
                ws.Cells[5, 2, 5, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[5, 2, 5, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[6, 2, 6, 15].Merge = true;
                ws.Cells[6, 2, 6, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[6, 2, 6, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



                ws.Cells["B2"].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "TenCongTy", Commons.Modules.TypeLanguage);
                ws.Cells["B3"].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DiaChi1", Commons.Modules.TypeLanguage);
                ws.Cells["B4"].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DiaChi2", Commons.Modules.TypeLanguage);
                ws.Cells["B5"].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"];
                ws.Cells["B6"].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "titlePurchaseOrder", Commons.Modules.TypeLanguage);
                ws.Cells["B6"].Style.Font.Bold = true;

                DinhDangText(ref ws, "B9", dtTmp.Rows[0]["TEN_CTY"].ToString());
                DinhDangText(ref ws, "B10", dtTmp.Rows[0]["DIA_CHI"].ToString(), false, false, true, "B10:G11", true);
                DinhDangText(ref ws, "B12", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Taxcode", Commons.Modules.TypeLanguage) + dtTmp.Rows[0]["MS_THUE"].ToString());
                DinhDangText(ref ws, "B13", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Tel", Commons.Modules.TypeLanguage) + dtTmp.Rows[0]["phone"]);
                DinhDangText(ref ws, "B14", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ContactPerson", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "G14", TxtNGUOI_DAT_HANG.Text);
                #endregion
                DinhDangText(ref ws, "B8", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Buyer", Commons.Modules.TypeLanguage), true, true, true, "B8:G8");
                DinhDangText(ref ws, "B15", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Infomation", Commons.Modules.TypeLanguage), true, true, true, "B15:G15");
                DinhDangText(ref ws, "B16", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Purchase", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "G16", TxtSO_DON_DAT_HANG.Text);
                DinhDangText(ref ws, "B17", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DateddMMyyyy", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "G17", DateTime.Now.ToString("dd/MM/yyyy"));
                DinhDangText(ref ws, "B18", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "VendorNo", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "G18", CboNHA_CUNG_CAP.SelectedValue.ToString());
                //Vendor
                DinhDangText(ref ws, "J8", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "VendorNguoiBan", Commons.Modules.TypeLanguage), true, true, true, "J8:O8");
                DinhDangText(ref ws, "J15", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Beneficiary", Commons.Modules.TypeLanguage), true, true, true, "J15:O15");
                DinhDangText(ref ws, "J16", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Name", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "J17", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "AccountNo", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "J18", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "BankName", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "J19", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "SwiftCode", Commons.Modules.TypeLanguage));
                dtTmp = new DataTable();
                sSql = "SELECT * FROM NGUOI_DAI_DIEN WHERE MS_KH = '" + CboNHA_CUNG_CAP.SelectedValue.ToString() + "' AND NGUOI_HUONG = 1";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    DinhDangText(ref ws, "L16", dtTmp.Rows[0]["TEN_NDD"].ToString());
                    DinhDangText(ref ws, "L17", dtTmp.Rows[0]["SO_TAI_KHOAN"].ToString());
                    DinhDangText(ref ws, "L18", dtTmp.Rows[0]["TEN_NH"].ToString());
                    DinhDangText(ref ws, "L19", dtTmp.Rows[0]["SWIFT_CODE"].ToString());
                }


                DinhDangText(ref ws, "J9", CboNHA_CUNG_CAP.Text);
                DinhDangText(ref ws, "J10", TxtDIA_CHI_NCC.Text, false, false, true, "J10:O11", true);
                try
                {
                    dtTmp = new DataTable();
                    sSql = "SELECT T.NHA_CUNG_CAP, T.DIA_CHI_NCC, T.DIEN_THOAI_NCC, T.FAX_NCC, T1.MS_THUE FROM DON_DAT_HANG T LEFT JOIN KHACH_HANG T1 ON T1.TEN_CONG_TY = T.NHA_CUNG_CAP WHERE MS_DON_DAT_HANG = '" + TxtMS_DON_DAT_HANG.Text + "'";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));

                    DinhDangText(ref ws, "J12", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Taxcode", Commons.Modules.TypeLanguage) + " " + dtTmp.Rows[0]["MS_THUE"].ToString());

                }
                catch { }
                DinhDangText(ref ws, "J13", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Tel", Commons.Modules.TypeLanguage) + MskDIEN_THOAI_NCC.Text);
                DinhDangText(ref ws, "J14", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ContactPerson", Commons.Modules.TypeLanguage));
                DinhDangText(ref ws, "M14", TxtNGUOI_LIEN_HE.Text);

                //---------------------------------------------------------------------------------------
                DinhDangText(ref ws, "B21", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ShipTo", Commons.Modules.TypeLanguage), true, false, true, "B21:F21");
                DinhDangText(ref ws, "G21", TxtDIA_CHI_GIAO.Text, false, false, true, "G21:O23", true);
                ws.Cells["G21"].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                ws.Cells["G21"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                DinhDangText(ref ws, "B24", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Delivery time", Commons.Modules.TypeLanguage), true, false, true, "B24:F24");
                DinhDangText(ref ws, "B25", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ThoiGianTH", Commons.Modules.TypeLanguage), false, false, true, "B25:F25");
                DinhDangText(ref ws, "B26", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DKVay", Commons.Modules.TypeLanguage), true, false, true, "B26:F26");
                DinhDangText(ref ws, "B27", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DKThanhToan", Commons.Modules.TypeLanguage), false, false, true, "B27:F27");
                DinhDangText(ref ws, "B28", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "TermsofDelivery", Commons.Modules.TypeLanguage), true, false, true, "B28:F28");
                DinhDangText(ref ws, "B29", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DieuKienGiao", Commons.Modules.TypeLanguage), false, false, true, "B29:F29");
                DinhDangText(ref ws, "B30", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Currency", Commons.Modules.TypeLanguage), true, false, true, "B30:F30");
                try
                {
                    ws.Cells["G24"].Value = DgvDonDatHangDieuKhoan.Rows[0].Cells[1].Value;
                    ws.Cells["G25"].Value = DgvDonDatHangDieuKhoan.Rows[1].Cells[1].Value;
                    ws.Cells["G26"].Value = DgvDonDatHangDieuKhoan.Rows[2].Cells[1].Value;
                    ws.Cells["G27"].Value = DgvDonDatHangDieuKhoan.Rows[3].Cells[1].Value;
                    ws.Cells["G28"].Value = DgvDonDatHangDieuKhoan.Rows[4].Cells[1].Value;
                    ws.Cells["G29"].Value = DgvDonDatHangDieuKhoan.Rows[5].Cells[1].Value;
                   // DinhDangText(ref ws, "G44", DgvDonDatHangDieuKhoan.Rows[6].Cells[1].Value.ToString(), false, false, true, "G44:O45");
                }
                catch
                {
                    dtTmp = new DataTable();
                    sSql = " SELECT * FROM DIEU_KHOAN_MAC_DINH ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        ws.Cells["G24"].Value = dtTmp.Rows[0][2];
                        ws.Cells["G25"].Value = dtTmp.Rows[1][2];
                        ws.Cells["G26"].Value = dtTmp.Rows[2][2];
                        ws.Cells["G27"].Value = dtTmp.Rows[3][2];
                        ws.Cells["G28"].Value = dtTmp.Rows[4][2];
                        ws.Cells["G29"].Value = dtTmp.Rows[5][2];
                       // DinhDangText(ref ws, "G44", dtTmp.Rows[6][2].ToString(), false, false, true, "G44:O45");
                    }
                }
 
                ws.Cells["G30"].Value = Commons.Modules.TypeLanguage == 0 ? "VND" : "USD";

                ws.Cells["B2:O2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["B21:O21"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["B30:O30"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells["B31:O31"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                ws.Row(31).Height = 110;
                ws.Cells["B31"].Style.WrapText = true;
                ws.Cells["B31"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells["B31"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


                ws.Column(2).Width = 5.75;
                ws.Column(3).Width = 1;
                ws.Column(4).Width = 4;
                ws.Column(5).Width = 21;
                ws.Column(6).Width = 19.83;
                ws.Column(7).Width = 27;
                ws.Column(8).Width = 0;
                ws.Column(9).Width = 0.85;
                ws.Column(10).Width = 12.14;
                ws.Column(11).Width = 15.26;
                ws.Column(12).Width = 16.29;
                ws.Column(13).Width = 11.43;
                ws.Column(14).Width = 16.43;
                ws.Column(15).Width = 23;
                
                iDong = 31;
                DinhDangText(ref ws, "B" + iDong.ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Info1", Commons.Modules.TypeLanguage) + Environment.NewLine + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Info2", Commons.Modules.TypeLanguage), false, false, true, "B" + iDong.ToString() + ":O" + iDong.ToString());
                ws.Row(31).Height = 110;
                //định dạng cột
                iDong++;
                ws.Cells[iDong, 2, iDong, 3].Merge = true;
                ws.Cells[iDong, 4, iDong, 7].Merge = true;
                ws.Cells[iDong, 9, iDong, 11].Merge = true;
                ws.Cells[iDong, 12, iDong, 14].Merge = true;

                ws.Cells[iDong, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Item", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 4].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Material", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 9].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "OrderQty", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 12].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "UnitPrice", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 15].Formula = "=\"" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "AmountIn", Commons.Modules.TypeLanguage) + "\" & G30";

                iDong = 33;
                ws.Cells[iDong, 2, iDong, 3].Merge = true;
                ws.Cells[iDong, 4, iDong, 7].Merge = true;
                ws.Cells[iDong, 9, iDong, 11].Merge = true;

                ws.Cells[iDong, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Muc", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 4].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "TenHang", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 9].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "SoLuong", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 12].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DonGia", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 13].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "VAT", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 14].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "TienThue", Commons.Modules.TypeLanguage);
                ws.Cells[iDong, 15].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ThanhTien", Commons.Modules.TypeLanguage);
                ws.Row(iDong).Height = 45;
                ws.Row(iDong).Style.WrapText = true;

                ws.Cells["B" + (iDong - 1).ToString() + ":O" + iDong.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["B" + (iDong - 1).ToString() + ":O" + iDong.ToString()].Style.Font.Bold = true;
                ws.Cells["B" + (iDong - 1).ToString() + ":O" + iDong.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["B" + (iDong - 1).ToString() + ":O" + iDong.ToString()].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ccc"));

                ws.Cells[iDong, 2, iDong, 15].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, 2, iDong, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                iDong++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.Cells[iDong, 2].Value = dt.Rows[i]["STT"];
                    ws.Cells[iDong, 4].Value = dt.Rows[i]["TEN_PT"];
                    ws.Cells[iDong, 10].Value = dt.Rows[i]["SL_DAT_HANG"];
                    ws.Cells[iDong, 11].Value = dt.Rows[i]["DVT"];
                    ws.Cells[iDong, 12].Value = dt.Rows[i]["DON_GIA"];
                    ws.Cells[iDong, 13].Value = dt.Rows[i]["THUE_VAT"];
                    ws.Cells[iDong, 14].Value = dt.Rows[i]["TIEN_THUE"];
                    ws.Cells[iDong, 15].Value = dt.Rows[i]["THANH_TIEN"];
                    iDong++;
                }

                ws.Cells[34, 12, 34 + dt.Rows.Count, 12].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[34, 13, 34 + dt.Rows.Count, 13].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[34, 14, 34 + dt.Rows.Count, 14].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[34, 15, 34 + dt.Rows.Count, 15].Style.Numberformat.Format = "#,##0.00";

                iDong = 33 + dt.Rows.Count + 6;

                DinhDangText(ref ws, "I" + iDong.ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ValueOfGoods", Commons.Modules.TypeLanguage), true, false, true, "I" + iDong.ToString() + ":M" + iDong.ToString());
                DinhDangText(ref ws, "I" + (iDong + 1).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "ThueGTGT", Commons.Modules.TypeLanguage), true, false, true, "I" + (iDong + 1).ToString() + ":M" + (iDong + 1).ToString());
                DinhDangText(ref ws, "I" + (iDong + 2).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "TotalInclude", Commons.Modules.TypeLanguage), true, false, true, "I" + (iDong + 2).ToString() + ":M" + (iDong + 2).ToString());

                ws.Cells[iDong, 2, iDong, 15].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, 2, iDong, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, 2, iDong + 2, 15].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, 2, iDong + 2, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                ws.Cells[iDong, 15].Formula = "=+SUMPRODUCT(L34:L" + (iDong - 1).ToString() + ",J34:J" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 1, 15].Formula = "=SUMPRODUCT(N34:N" + (iDong - 1).ToString() + ",J34:J" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 2, 15].Formula = "= IF(OR(RIGHT(G25, 4) = \"DATA\", RIGHT(G27, 4) = \"DATA\", RIGHT(G29, 4) = \"DATA\", RIGHT(L18, 4) = \"DATA\", RIGHT(L17, 4) = \"DATA\", RIGHT(K16, 4) = \"DATA\", RIGHT(O32, 4) = \"DATA\", G17 = 0, G25 = \"#N/A\", G27 = \"#N/A\", G29 = \"#N/A\", G24: O24 = \"PLEASE INPUT DATA\", G26 = \"PLEASE INPUT DATA\", G28 = \"PLEASE INPUT DATA\"), \"PLEASE CHECK & INPUT DATA\", O49 + O50)";
                ws.Cells[iDong, 15].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[iDong + 1, 15].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[iDong + 2, 15].Style.Numberformat.Format = "#,##0.00";

                DinhDangText(ref ws, "B" + (iDong + 3).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Terms", Commons.Modules.TypeLanguage), true, false, true, "B" + (iDong + 3).ToString() + ":F" + (iDong + 4).ToString(), true);
                ws.Cells[iDong + 3, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                try
                {
                    DinhDangText(ref ws, "G" + (iDong + 3).ToString(), DgvDonDatHangDieuKhoan.Rows[6].Cells[1].Value.ToString(), false, false, true, "G" + (iDong + 3).ToString() + ":O" + (iDong + 4).ToString());
                }
                catch
                {
                    dtTmp = new DataTable();
                    sSql = " SELECT * FROM DIEU_KHOAN_MAC_DINH ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        DinhDangText(ref ws, "G" + (iDong + 3).ToString(), dtTmp.Rows[6][2].ToString(), false, false, true, "G" + (iDong + 3).ToString() + ":O" + (iDong + 4).ToString());
                    }
                }
                ws.Cells["G" + (iDong + 3).ToString() + ":O" + (iDong + 4).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["G" + (iDong + 3).ToString() + ":O" + (iDong + 4).ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                iDong = iDong + 10;
                DinhDangText(ref ws, "B" + iDong.ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Boss", Commons.Modules.TypeLanguage), false, false, true, "B" + iDong.ToString() + ":G" + iDong.ToString(), true);
                DinhDangText(ref ws, "B" + (iDong + 1).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "AuthorizedSignature", Commons.Modules.TypeLanguage), false, false, true, "B" + (iDong + 1).ToString() + ":G" + (iDong + 1).ToString(), true);
                DinhDangText(ref ws, "B" + (iDong + 2).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "OnBehalfOf", Commons.Modules.TypeLanguage), false, false, true, "B" + (iDong + 2).ToString() + ":G" + (iDong + 2).ToString(), true);
                DinhDangText(ref ws, "B" + (iDong + 3).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DaiDien", Commons.Modules.TypeLanguage), false, false, true, "B" + (iDong + 3).ToString() + ":G" + (iDong + 3).ToString(), true);

                DinhDangText(ref ws, "K" + (iDong + 1).ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "AuthorizedSignature", Commons.Modules.TypeLanguage), false, false, true, "K" + (iDong + 1).ToString() + ":O" + (iDong + 1).ToString(), true);

                ws.Cells[iDong + 2, 11].Formula = "=\"" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "OnBehalfOf", Commons.Modules.TypeLanguage) + " \"& J9";
                ws.Cells[iDong + 3, 11].Formula = "=\"" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "DaiDien", Commons.Modules.TypeLanguage) + " \"& J9";

                ws.Cells[2, 2, iDong + 3, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[2, 15, iDong + 3, 15].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 3, 2, iDong + 3, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                iDong = iDong + 5;
                DinhDangText(ref ws, "B" + iDong.ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions", Commons.Modules.TypeLanguage), false, false, true, "B" + iDong.ToString() + ":O" + iDong.ToString(), true);
                ws.Cells[iDong, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iDong, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                iDong++;

                ws.Cells[iDong, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_1", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 2, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_2", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 4, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_3", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 6, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_4", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 8, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_5", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 10, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_6", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 12, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_7", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 14, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_8", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 16, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_9", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 18, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Conditions_10", Commons.Modules.TypeLanguage);

                ws.Cells[iDong, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 2, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 4, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 6, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 8, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 10, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 12, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 14, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 16, 2].Style.Font.Bold = true;
                ws.Cells[iDong + 18, 2].Style.Font.Bold = true;

                ws.Cells[iDong + 1, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_1", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 3, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_2", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 5, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_3", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 7, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_4", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 9, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_5", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 11, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_6", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 13, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_7", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 15, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_8", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 17, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_9", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 19, 2].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDDH_SSD", "Content_10", Commons.Modules.TypeLanguage);

                ws.Cells[iDong + 1, 2].Style.WrapText = true;
                ws.Cells[iDong + 1, 2, iDong + 1, 15].Merge = true;
                ws.Cells[iDong + 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 1).Height = 97.5;
                ws.Cells[iDong + 3, 2].Style.WrapText = true;
                ws.Cells[iDong + 3, 2, iDong + 3, 15].Merge = true;
                ws.Cells[iDong + 3, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 3).Height = 86.5;
                ws.Cells[iDong + 5, 2].Style.WrapText = true;
                ws.Cells[iDong + 5, 2, iDong + 5, 15].Merge = true;
                ws.Cells[iDong + 5, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 5, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 5).Height = 122.2;
                ws.Cells[iDong + 7, 2].Style.WrapText = true;
                ws.Cells[iDong + 7, 2, iDong + 7, 15].Merge = true;
                ws.Cells[iDong + 7, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 7, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 7).Height = 94.5;
                ws.Cells[iDong + 9, 2].Style.WrapText = true;
                ws.Cells[iDong + 9, 2, iDong + 9, 15].Merge = true;
                ws.Cells[iDong + 9, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 9, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 9).Height = 86.3;
                ws.Cells[iDong + 11, 2].Style.WrapText = true;
                ws.Cells[iDong + 11, 2, iDong + 11, 15].Merge = true;
                ws.Cells[iDong + 11, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 11, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 11).Height = 330;
                ws.Cells[iDong + 13, 2].Style.WrapText = true;
                ws.Cells[iDong + 13, 2, iDong + 13, 15].Merge = true;
                ws.Cells[iDong + 13, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 13, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 13).Height = 50;
                ws.Cells[iDong + 15, 2].Style.WrapText = true;
                ws.Cells[iDong + 15, 2, iDong + 15, 15].Merge = true;
                ws.Cells[iDong + 15, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 15, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 15).Height = 72;
                ws.Cells[iDong + 17, 2].Style.WrapText = true;
                ws.Cells[iDong + 17, 2, iDong + 17, 15].Merge = true;
                ws.Cells[iDong + 17, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 17, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 17).Height = 50;
                ws.Cells[iDong + 19, 2].Style.WrapText = true;
                ws.Cells[iDong + 19, 2, iDong + 19, 15].Merge = true;
                ws.Cells[iDong + 19, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[iDong + 19, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong + 19).Height = 76;

                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);


                System.Diagnostics.Process.Start(fi.FullName);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary> 
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            Validate();
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (((DataRowView)BindingDonDatHang.Current).Row["SO_DON_DAT_HANG"] == null || ((DataRowView)BindingDonDatHang.Current).Row["SO_DON_DAT_HANG"].Equals(DBNull.Value))
            {
                Vietsoft.Information.MsgBox(this, "MsgSoDDHNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TxtSO_DON_DAT_HANG.Focus();
                return;
            }
            if (((DataRowView)BindingDonDatHang.Current).Row["NGAY_DAT"] == null || ((DataRowView)BindingDonDatHang.Current).Row["NGAY_DAT"].Equals(DBNull.Value))
            {
                Vietsoft.Information.MsgBox(this, "MsgNgayDatNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MskNGAY_DAT_HANG.Focus();
                return;
            }
            if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DAT"] == null || ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DAT"].Equals(DBNull.Value))
            {
                Vietsoft.Information.MsgBox(this, "MsgNguoiDatNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TxtNGUOI_DAT_HANG.Focus();
                return;
            }
            if (sPrivate != "DOFICO")
            {
                if (((DataRowView)BindingDonDatHang.Current).Row["NGAY_KY_HD"] == null || ((DataRowView)BindingDonDatHang.Current).Row["NGAY_KY_HD"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNgayKyNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MskNGAY_HD.Focus();
                    return;
                }
                if (((DataRowView)BindingDonDatHang.Current).Row["NGUOI_KY_HD"] == null || ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_KY_HD"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNguoiKyNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    TxtNGUOI_KY_HD.Focus();
                    return;
                }

                if (((DataRowView)BindingDonDatHang.Current).Row["NHA_CUNG_CAP"] == null || ((DataRowView)BindingDonDatHang.Current).Row["NHA_CUNG_CAP"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNhaCungCapNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboNHA_CUNG_CAP.Focus();
                    return;
                }
            }
            try
            {
                int ms_kho = Convert.ToInt16(cmbKho.SelectedValue);
            }
            catch
            {
                Vietsoft.Information.MsgBox(this, "MsgKhoInValid", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho.Focus();
                return;
            }
            try
            {

                string ms_loai_vt = Convert.ToString(cmbLoaiVT.SelectedValue);
            }
            catch
            {
                Vietsoft.Information.MsgBox(this, "MsgLoaiVTInvalid", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbLoaiVT.Focus();
                return;
            }
            foreach (DataGridViewRow rDonDatHangChiTiet in DgvDonDatHangChiTiet.Rows)
            {
                if (((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["SL_DAT_HANG"] == null || ((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["SL_DAT_HANG"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["SL_DAT_HANG"]) <= 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSLDXLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDonDatHangChiTiet.CurrentCell = rDonDatHangChiTiet.Cells["SL_DAT_HANG"];
                    return;
                }
                if (((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["MS_DE_XUAT"] != null && !((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["MS_DE_XUAT"].Equals(DBNull.Value))
                {

                    if (Convert.ToDouble(((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["SL_DAT_HANG"]) > Convert.ToDouble(SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_GET_SLDX_HT", ((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["MS_DON_DAT_HANG"], ((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["MS_DE_XUAT"], ((DataRowView)rDonDatHangChiTiet.DataBoundItem).Row["MS_PT"])))
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSL_LONHON_DX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        DgvDonDatHangChiTiet.CurrentCell = rDonDatHangChiTiet.Cells["SL_DAT_HANG"];
                        return;
                    }
                }
            }
            for (int i = 0; i < DgvDonDatHangDichVu.Rows.Count - 1; i++)
            {
                if (((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"] == null || ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"].Equals(DBNull.Value) || ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"].ToString().Trim().Equals(String.Empty))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNullTenDichVu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDonDatHangDichVu.CurrentCell = DgvDonDatHangDichVu.Rows[i].Cells["TEN_DICH_VU_DV"];
                    return;
                }
                if (((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["DVT"] == null || ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["DVT"].Equals(DBNull.Value) || ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["DVT"].ToString().Trim().Equals(String.Empty))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNullDVTDV", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDonDatHangDichVu.CurrentCell = DgvDonDatHangDichVu.Rows[i].Cells["DVT_DV"];
                    return;
                }
                if (((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["SL_DAT_HANG"] == null || ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["SL_DAT_HANG"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["SL_DAT_HANG"]) <= 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSLDHDVLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDonDatHangDichVu.CurrentCell = DgvDonDatHangDichVu.Rows[i].Cells["SL_DAT_HANG_DV"];
                    return;
                }
                if (((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["MS_DE_XUAT"] != null && !((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["MS_DE_XUAT"].Equals(DBNull.Value))
                {
                    if (Convert.ToDouble(((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["SL_DAT_HANG"]) > Convert.ToDouble(SqlDonDatHang.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_GET_SLDXDV_HT", ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["MS_DON_DAT_HANG"], ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["MS_DE_XUAT"], ((DataRowView)DgvDonDatHangDichVu.Rows[i].DataBoundItem).Row["MS_DICH_VU"])))
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSLDVLONHON_DX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        DgvDonDatHangDichVu.CurrentCell = DgvDonDatHangDichVu.Rows[i].Cells["SL_DAT_HANG_DV"];
                        return;
                    }
                }
            }
            if (Commons.Modules.sPrivate == "SHISEIDO")
            {
                if (TrangThai.ToUpper() == "ADD")
                {
                    string sMSPN = "";
                    string sMSPN0ld = TxtSO_DON_DAT_HANG.Text;

                    sMSPN = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetSoDonHangSSD", "PO", Commons.Modules.UserName));
                    if (sMSPN != TxtSO_DON_DAT_HANG.Text)
                    {
                        TxtSO_DON_DAT_HANG.Text = sMSPN;
                        ((DataRowView)BindingDonDatHang.Current).Row["SO_DON_DAT_HANG"] = sMSPN;


                        foreach (DataRow dr in TbDonDatHang.Rows)
                        {
                            if (dr["SO_DON_DAT_HANG"].ToString() == sMSPN0ld)
                                dr["SO_DON_DAT_HANG"] = sMSPN;
                        }
                    }
                }
            }


            SqlDonDatHang.BeginTransaction();


            try
            {
                switch (TrangThai)
                {
                    case "Add":
                        ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_GIAO"] = TxtNGUOI_GIAO.Text;
                        ((DataRowView)BindingDonDatHang.Current).Row["DIA_CHI_GIAO"] = TxtDIA_CHI_GIAO.Text;
                        Vietsoft.DataInfo.InsertDataRow(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row);
                        Vietsoft.DataInfo.InsertDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_CHI_TIET", TbDonDatHangChiTiet.DefaultView);
                        Vietsoft.DataInfo.InsertDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_DICH_VU", TbDonDatHangDichVu.DefaultView);
                        Vietsoft.DataInfo.InsertDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_DIEU_KHOAN", TbDonDatHangDieuKhoan.DefaultView);
                        Vietsoft.DataInfo.InsertDataView(SqlDonDatHang, "SP_Y_INSERT_DUYET_DON_DAT_HANG", TbDuyetDonDatHang.DefaultView);
                        break;
                    case "Edit":
                        ((DataRowView)BindingDonDatHang.Current).Row["NGAY_SUA"] = Commons.Modules.ObjSystems.GetNgayHeThong();
                        ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_SUA"] = Commons.Modules.UserName;
                        ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_GIAO"] = TxtNGUOI_GIAO.Text;
                        ((DataRowView)BindingDonDatHang.Current).Row["DIA_CHI_GIAO"] = TxtDIA_CHI_GIAO.Text;

                        Vietsoft.DataInfo.UpdateDataRow(SqlDonDatHang, "SP_Y_EDIT_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row);
                        Vietsoft.DataInfo.UpdateDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_CHI_TIET", "SP_Y_EDIT_DON_DAT_HANG_CHI_TIET", "SP_Y_CHECK_DON_DAT_HANG_CHI_TIET", TbDonDatHangChiTiet.DefaultView, "MS_DON_DAT_HANG", "MS_PT", "MS_CHI_TIET_DH");
                        Vietsoft.DataInfo.UpdateDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_DICH_VU", "SP_Y_EDIT_DON_DAT_HANG_DICH_VU", "SP_Y_CHECK_DON_DAT_HANG_DICH_VU", TbDonDatHangDichVu.DefaultView, "MS_DON_DAT_HANG", "MS_DICH_VU");
                        Vietsoft.DataInfo.UpdateDataView(SqlDonDatHang, "SP_Y_INSERT_DON_DAT_HANG_DIEU_KHOAN", "SP_Y_EDIT_DON_DAT_HANG_DIEU_KHOAN", "SP_Y_CHECK_DON_DAT_HANG_DIEU_KHOAN", TbDonDatHangDieuKhoan.DefaultView, "MS_DON_DAT_HANG", "MS_DIEU_KHOAN");
                        Vietsoft.DataInfo.UpdateDataView(SqlDonDatHang, "SP_Y_INSERT_DUYET_DON_DAT_HANG", "SP_Y_EDIT_DUYET_DON_DAT_HANG", "SP_Y_CHECK_DUYET_DON_DAT_HANG", TbDuyetDonDatHang.DefaultView, "MS_DON_DAT_HANG", "NGUOI_DUYET");
                        break;
                }
                SqlDonDatHang.CommitTransaction();
                BindingDonDatHang.EndEdit();
                TbDonDatHang.AcceptChanges();
                TbDonDatHangChiTiet.AcceptChanges();
                TbDonDatHangDichVu.AcceptChanges();
                TbDonDatHangDieuKhoan.AcceptChanges();
                TbDuyetDonDatHang.AcceptChanges();
                TrangThai = String.Empty;
                InitializeForm();
                tblCondition.Enabled = true;
            }
            catch
            {
                SqlDonDatHang.RollbackTransaction();
                Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            //InitializeDatabase();
        }
        /// <summary>
        /// Không lưu dữ liệu
        /// </summary> 
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            BindingDonDatHang.CancelEdit();
            TbDonDatHang.RejectChanges();
            TbDonDatHangChiTiet.RejectChanges();
            TbDonDatHangDichVu.RejectChanges();
            TbDonDatHangDieuKhoan.RejectChanges();
            TbDuyetDonDatHang.RejectChanges();
            TrangThai = String.Empty;
            InitializeForm();
            tblCondition.Enabled = true;
            GetTotal();

        }
        /// <summary>
        /// Thoát form
        /// </summary> 
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Trình duyệt
        /// </summary>       
        private void BtnTrinhDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 2;
                ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                Vietsoft.DataInfo.UpdateDataRow(Vietsoft.Information.ConnectionString, "SP_Y_EDIT_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row);
                BindingDonDatHang.EndEdit();
            }
            catch
            {
                BindingDonDatHang.CancelEdit();
            }
            InitializeControl();
        }
        /// <summary>
        /// Đóng tài liệu
        /// </summary> 
        private void BtnDong_Click(object sender, EventArgs e)
        {
            try
            {
                ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 4;
                ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Đóng";

                int result = Vietsoft.DataInfo.UpdateDataRow(Vietsoft.Information.ConnectionString, "SP_Y_EDIT_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row);
                BindingDonDatHang.EndEdit();

                string date = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, "SELECT MAX(NGAY) AS NGAY FROM IC_DON_HANG_NHAP WHERE MS_DDH='" + TxtMS_DON_DAT_HANG.Text + "'").ToString();
                if (Company == "HUDA")
                {
                    if (!string.IsNullOrEmpty(date))
                    {
                        DateTime d = Convert.ToDateTime(date);
                        SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, "UPDATE DON_DAT_HANG SET NGAY_GIAO='" + d.Month + "/" + d.Day + "/" + d.Year + "' WHERE MS_DON_DAT_HANG='" + TxtMS_DON_DAT_HANG.Text + "'");
                    }
                }
                BindingDonDatHang.RemoveCurrent();
                TbDonDatHang.AcceptChanges();
                TbDonDatHangChiTiet.AcceptChanges();
            }
            catch
            {
                BindingDonDatHang.CancelEdit();
            }
            InitializeDatabase();
            InitializeControl();

        }
        /// <summary>
        /// Duyệt tài liệu
        /// </summary> 
        private void DgvDuyetDonDatHang_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";
            if (!DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["NGUOI_DUYET"].Value.ToString().ToUpper().Equals(Commons.Modules.UserName.ToUpper()))
            {
                DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhacUserDuyet", Commons.Modules.TypeLanguage);
                e.Cancel = true;
                return;
            }
            else
            {
                if (!((((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"].Equals(2) || ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"].Equals(3))))
                {
                    DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTrangThaiChuaDuyet", Commons.Modules.TypeLanguage);
                    e.Cancel = true;
                    return;
                }
            }
            string sSql = "SELECT * FROM DON_DAT_HANG_DUYET WHERE MS_DON_DAT_HANG = '" + TxtMS_DON_DAT_HANG.Text + "' AND TT_DUYET < " +
                                    DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["TT_DUYET"].Value.ToString() + " AND BAT_BUOC = 1 ORDER BY TT_DUYET DESC  ";
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                sSql = "SELECT * FROM DON_DAT_HANG_DUYET WHERE MS_DON_DAT_HANG = '" + TxtMS_DON_DAT_HANG.Text + "' AND TT_DUYET = " +
                    dtTmp.Rows[0]["TT_DUYET"].ToString() + " AND BAT_BUOC = 1 AND ISNULL(DUYET,0) = 0 ORDER BY TT_DUYET DESC  ";
                dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBuocTruocBacBuocChuaDuyet", Commons.Modules.TypeLanguage);
                    e.Cancel = true;
                    return;
                }
            }


            sSql = "SELECT * FROM DON_DAT_HANG_DUYET WHERE MS_DON_DAT_HANG = '" + TxtMS_DON_DAT_HANG.Text + "' AND TT_DUYET > " +
                   DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["TT_DUYET"].Value.ToString() + " AND DUYET = 1 ORDER BY TT_DUYET DESC  ";
            dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBuocSauDaDuyet", Commons.Modules.TypeLanguage);
                e.Cancel = true;
                return;

            }
            DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";
        }
        private void DgvDuyetDonDatHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
                if (DgvDuyetDonDatHang.Columns[e.ColumnIndex].Name == "DUYET")
                {
                    if (DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].Value.Equals(true))
                    {
                        DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = NgayHT;
                        if (DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["QUYET_DINH"].Value.Equals(true))
                        {
                            ((DataRowView)BindingDonDatHang.Current).Row["NGAY_DUYET"] = NgayHT;
                            ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"] = Commons.Modules.UserName;
                            ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 3;
                            ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Duyệt";
                        }
                    }
                    else
                    {
                        DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = DBNull.Value;
                        if (DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["QUYET_DINH"].Value.Equals(true))
                        {
                            ((DataRowView)BindingDonDatHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                            ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;
                            if (((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"].Equals(3))
                            {
                                ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 2;
                                ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                            }
                        }
                    }
                }
            }
        }

        private void DgvDuyetDonDatHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        /// <summary>
        /// Kiểm soát sửa tên dich vụ
        /// </summary> 
        private void DgvDonDatHangDichVu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (DgvDonDatHangDichVu.Columns[e.ColumnIndex].Name.Equals("TEN_DICH_VU_DV"))
            {
                if (!(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["MS_DE_XUAT_DV"].Value == null || DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["MS_DE_XUAT_DV"].Value.Equals(DBNull.Value) || DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["MS_DE_XUAT_DV"].Value.ToString().Trim().Equals(String.Empty)))
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Kiểm soát sửa tên dich vụ
        /// </summary> 
        private void DgvDonDatHangChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (DgvDonDatHangChiTiet.Columns[e.ColumnIndex].Name)
                {
                    case "SL_DAT_HANG":
                    case "DON_GIA":
                        try
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value = Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["SL_DAT_HANG"].Value) * Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["DON_GIA"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value = DBNull.Value;
                        }
                        break;
                    case "THANH_TIEN":
                        try
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = DBNull.Value;
                        }
                        try
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA":
                        try
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_USD":
                        try
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = DBNull.Value;
                        }
                        break;
                    case "NGOAI_TE":
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            DataTable TbNgoaiTe = new DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["NGOAI_TE"].Value));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                            else
                            {
                                DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                                DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                            }
                        }
                        catch
                        {
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                            DgvDonDatHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                        }
                        break;

                }
                GetTotal();
            }

        }

        private void GetTotal()
        {
            sTotal = 0;
            for (int i = 0; i < DgvDonDatHangChiTiet.Rows.Count; i++)
            {
                try
                {
                    sTotal += Double.Parse(DgvDonDatHangChiTiet.Rows[i].Cells["THANH_TIEN_VND"].Value.ToString());
                }
                catch { }
            }
            txtTotal.Text = string.Format("{0:n}", sTotal);
        }

        private void DgvDonDatHangDichVu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (DgvDonDatHangDichVu.Columns[e.ColumnIndex].Name)
                {
                    case "SL_DAT_HANG_DV":
                    case "DON_GIA_DV":
                        try
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value = Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["SL_DAT_HANG_DV"].Value) * Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["DON_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "THANH_TIEN_DV":
                        try
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = DBNull.Value;
                        }
                        try
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_DV":
                        try
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_USD_DV":
                        try
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value);
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "NGOAI_TE_DV":
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            DataTable TbNgoaiTe = new DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["NGOAI_TE_DV"].Value));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                            else
                            {
                                DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = DBNull.Value;
                                DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = DBNull.Value;
                            }
                        }
                        catch
                        {
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = DBNull.Value;
                            DgvDonDatHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = DBNull.Value;
                        }
                        break;

                }
            }
        }

        private void CboNHA_CUNG_CAP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboNHA_CUNG_CAP.SelectedValue != null)
            {
                Vietsoft.SqlInfo SqlNCC = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                DataTable TbTTNCC = new DataTable();
                TbTTNCC.Load(SqlNCC.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TT_NHA_CUNG_CAP", CboNHA_CUNG_CAP.SelectedValue));
                if (TbTTNCC.Rows.Count > 0)
                {
                    TxtDIA_CHI_NCC.Text = TbTTNCC.Rows[0]["DIA_CHI"].ToString();
                    MskDIEN_THOAI_NCC.Text = TbTTNCC.Rows[0]["DIEN_THOAI"].ToString();
                    MskFAX_NCC.Text = TbTTNCC.Rows[0]["FAX"].ToString();
                }
            }
        }

        private void TxtSO_DON_DAT_HANG_Validated(object sender, EventArgs e)
        {
            if (TxtSO_DON_DAT_HANG.Text.Trim() != "")
            {
                try
                {
                    Vietsoft.SqlInfo SqlDDH = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                    DataTable Tb = new DataTable();
                    Tb.Load(SqlDDH.ExecuteReader(CommandType.StoredProcedure, "CheckSoDDH", TxtSO_DON_DAT_HANG.Text.Trim(), TxtMS_DON_DAT_HANG.Text));
                    if (Tb.Rows.Count > 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSoDDHTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        TxtSO_DON_DAT_HANG.Focus();
                        return;
                    }
                }
                catch { }
            }
        }


        private void btnAuto_Click(object sender, EventArgs e)
        {
            DataTable _TbSource = new DataTable();
            Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            int kho = -1;
            string loai_vt = "-1";

            try
            {
                kho = Convert.ToInt32(cmbKho.SelectedValue.ToString());
                if (kho == 0 || kho == -1)
                {
                    Vietsoft.Information.MsgBox(this, "MsgChuaChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbKho.Focus();
                    return;
                }
            }
            catch
            {

                Vietsoft.Information.MsgBox(this, "MsgChuaChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho.Focus();
                return;
            }
            try
            {
                loai_vt = cmbLoaiVT.SelectedValue.ToString();
                if (loai_vt == "-1")
                {
                    Vietsoft.Information.MsgBox(this, "MsgChuaChonLoaiVT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbLoaiVT.Focus();
                    return;
                }
            }
            catch
            {

                Vietsoft.Information.MsgBox(this, "MsgChuaChonLoaiVT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbLoaiVT.Focus();
                return;
            }
            DataTable _table = ((DataView)DgvDonDatHangChiTiet.DataSource).ToTable();
            _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHU_TUNG_DAT_HANG_NEW", kho, loai_vt));
            string _ms_pt = "";
            if (_TbSource.Rows.Count <= 0)
            {
                Vietsoft.Information.MsgBox(this, "MsgKhongCoDL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
                cmbKho.Enabled = cmbLoaiVT.Enabled = false;
            for (int i = 0; i < _TbSource.DefaultView.Count; i++)
            {
                DataRow rDonDatHangChiTiet = TbDonDatHangChiTiet.NewRow();
                rDonDatHangChiTiet["MS_PT"] = _TbSource.DefaultView[i].Row["MS_PT"];
                _ms_pt = "MS_PT='" + _TbSource.DefaultView[i].Row["MS_PT"] + "'";
                DataTable _new_table = new DataTable();
                _new_table = _table;
                _new_table.DefaultView.RowFilter = _ms_pt;
                _new_table = _new_table.DefaultView.ToTable();
                if (_new_table.Rows.Count > 0)
                {
                    DialogResult res = Vietsoft.Information.MsgBox(this, "MsgMSPTDuplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (DialogResult.Yes.Equals(res))
                    {
                        rDonDatHangChiTiet["TEN_PT"] = _TbSource.DefaultView[i].Row["TEN_PT"];
                        rDonDatHangChiTiet["PART_NO"] = _TbSource.DefaultView[i].Row["PART_NO"];
                        rDonDatHangChiTiet["QUY_CACH"] = _TbSource.DefaultView[i].Row["QUY_CACH"];
                        rDonDatHangChiTiet["DVT"] = _TbSource.DefaultView[i].Row["TEN_DON_VI"];
                        rDonDatHangChiTiet["MS_DE_XUAT"] = _TbSource.DefaultView[i].Row["MS_DE_XUAT"];
                        rDonDatHangChiTiet["SL_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DE_XUAT"];
                        rDonDatHangChiTiet["SL_DAT_HANG"] = _TbSource.DefaultView[i].Row["SL_DAT_HANG"];
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            DataTable TbNgoaiTe = new DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDonDatHangChiTiet["NGOAI_TE"]));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                rDonDatHangChiTiet["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                                rDonDatHangChiTiet["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                                rDonDatHangChiTiet["THANH_TIEN"] = Convert.ToDouble(rDonDatHangChiTiet["SL_DAT_HANG"]) * Convert.ToDouble(rDonDatHangChiTiet["DON_GIA"]);
                                rDonDatHangChiTiet["THANH_TIEN_VND"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA"]);
                                rDonDatHangChiTiet["THANH_TIEN_USD"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA_USD"]);
                            }
                        }
                        catch
                        {
                        }
                        TbDonDatHangChiTiet.Rows.Add(rDonDatHangChiTiet);
                    }
                }
                else
                {
                    rDonDatHangChiTiet["TEN_PT"] = _TbSource.DefaultView[i].Row["TEN_PT"];
                    rDonDatHangChiTiet["PART_NO"] = _TbSource.DefaultView[i].Row["PART_NO"];
                    rDonDatHangChiTiet["QUY_CACH"] = _TbSource.DefaultView[i].Row["QUY_CACH"];
                    rDonDatHangChiTiet["DVT"] = _TbSource.DefaultView[i].Row["TEN_DON_VI"];
                    rDonDatHangChiTiet["MS_DE_XUAT"] = _TbSource.DefaultView[i].Row["MS_DE_XUAT"];
                    rDonDatHangChiTiet["SL_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DE_XUAT"];
                    rDonDatHangChiTiet["SL_DAT_HANG"] = _TbSource.DefaultView[i].Row["SL_DAT_HANG"];
                    try
                    {
                        Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        DataTable TbNgoaiTe = new DataTable();
                        TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDonDatHangChiTiet["NGOAI_TE"]));
                        if (TbNgoaiTe.Rows.Count > 0)
                        {
                            rDonDatHangChiTiet["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                            rDonDatHangChiTiet["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            rDonDatHangChiTiet["THANH_TIEN"] = Convert.ToDouble(rDonDatHangChiTiet["SL_DAT_HANG"]) * Convert.ToDouble(rDonDatHangChiTiet["DON_GIA"]);
                            rDonDatHangChiTiet["THANH_TIEN_VND"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA"]);
                            rDonDatHangChiTiet["THANH_TIEN_USD"] = Convert.ToDouble(rDonDatHangChiTiet["THANH_TIEN"]) * Convert.ToDouble(rDonDatHangChiTiet["TY_GIA_USD"]);
                        }
                    }
                    catch
                    {
                    }
                    TbDonDatHangChiTiet.Rows.Add(rDonDatHangChiTiet);
                }
            }
        }

        private void lokSupplier_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadDDH();
        }

        private void chkIsLock_CheckedChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadDDH();
        }

        private void datFromDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
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
                        LoadDDH();
                }
            }
            catch { }
        }

        private void datFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
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

        private void datToDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
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
                        LoadDDH();
                }
            }
            catch { }
        }

        private void datToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
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
        #region InRongAChau
        private void InRongAChau()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                frmReport frmRptDexuat = new frmReport();

                frmRptDexuat.rptName = "rptDonDatHangADC";
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetBCDDHADC",
                    ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString(), Commons.Modules.TypeLanguage));
                dtTmp.TableName = "DON_DAT_HANG_ADC";
                frmRptDexuat.AddDataTableSource(dtTmp);

                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("MAU_SO");
                TbTieuDe.Columns.Add("LB_HANH");
                TbTieuDe.Columns.Add("NGAY_BH");
                TbTieuDe.Columns.Add("TIEU_DE_DDH_ADC");

                TbTieuDe.Columns.Add("DEPT");
                TbTieuDe.Columns.Add("ORDER_NO");
                TbTieuDe.Columns.Add("DATE");

                TbTieuDe.Columns.Add("SUP_NAME");

                TbTieuDe.Columns.Add("REQUESTER");
                TbTieuDe.Columns.Add("CON_PER");
                TbTieuDe.Columns.Add("CUS_NO");
                TbTieuDe.Columns.Add("DEL_LOC");

                TbTieuDe.Columns.Add("NO");
                TbTieuDe.Columns.Add("ITEM");
                TbTieuDe.Columns.Add("DESCRIPTION");
                TbTieuDe.Columns.Add("ORDER_QTY");
                TbTieuDe.Columns.Add("UNITS");
                TbTieuDe.Columns.Add("STOCK_OH");
                TbTieuDe.Columns.Add("NEED_TO_ORDER");

                TbTieuDe.Columns.Add("U_PRICE");
                TbTieuDe.Columns.Add("AMOUNT");


                TbTieuDe.Columns.Add("TONG_GD");
                TbTieuDe.Columns.Add("GD_NMAY");
                TbTieuDe.Columns.Add("BP_MHANG");
                TbTieuDe.Columns.Add("PRE_BY");

                TbTieuDe.Columns.Add("TMP1");
                TbTieuDe.Columns.Add("TMP2");
                TbTieuDe.Columns.Add("TMP3");
                TbTieuDe.Columns.Add("TMP4");
                TbTieuDe.Columns.Add("TMP5");
                TbTieuDe.Columns.Add("TMP6");
                TbTieuDe.Columns.Add("TMP7");
                TbTieuDe.Columns.Add("TMP8");
                TbTieuDe.Columns.Add("TMP9");
                TbTieuDe.Columns.Add("TMP10");
                TbTieuDe.Columns.Add("MS_DX");

                TbTieuDe.Columns.Add("TEN_DV");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SL");
                TbTieuDe.Columns.Add("DG");
                TbTieuDe.Columns.Add("TT");

                TbTieuDe.Columns.Add("THOI_HAN");
                TbTieuDe.Columns.Add("N_DX");
                TbTieuDe.Columns.Add("N_GIAO");
                TbTieuDe.Columns.Add("N_NHAN");
                TbTieuDe.Columns.Add("LDO");
                TbTieuDe.Columns.Add("GCHU");

                TbTieuDe.Columns.Add("CO_DV");
                TbTieuDe.Columns.Add("TD_VAT_TU");

                DataRow rTitle = TbTieuDe.NewRow();

                rTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "MAU_SO", Commons.Modules.TypeLanguage);
                rTitle["LB_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "LB_HANH", Commons.Modules.TypeLanguage);
                rTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "NGAY_BH", Commons.Modules.TypeLanguage);

                rTitle["TIEU_DE_DDH_ADC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TIEU_DE_DDH_ADC", Commons.Modules.TypeLanguage);
                rTitle["DEPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DEPT", Commons.Modules.TypeLanguage);
                rTitle["ORDER_NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "ORDER_NO", Commons.Modules.TypeLanguage);
                rTitle["DATE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DATE", Commons.Modules.TypeLanguage);
                rTitle["SUP_NAME"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "SUP_NAME", Commons.Modules.TypeLanguage);

                rTitle["REQUESTER"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "REQUESTER", Commons.Modules.TypeLanguage);
                rTitle["CON_PER"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "CON_PER", Commons.Modules.TypeLanguage);
                rTitle["CUS_NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "CUS_NO", Commons.Modules.TypeLanguage);
                rTitle["DEL_LOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DEL_LOC", Commons.Modules.TypeLanguage);

                rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "NO", Commons.Modules.TypeLanguage);
                rTitle["ITEM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "ITEM", Commons.Modules.TypeLanguage);
                rTitle["DESCRIPTION"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DESCRIPTION", Commons.Modules.TypeLanguage);
                rTitle["ORDER_QTY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "ORDER_QTY", Commons.Modules.TypeLanguage);
                rTitle["UNITS"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "UNITS", Commons.Modules.TypeLanguage);
                rTitle["STOCK_OH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "STOCK_OH", Commons.Modules.TypeLanguage);
                rTitle["NEED_TO_ORDER"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "NEED_TO_ORDER", Commons.Modules.TypeLanguage);

                rTitle["U_PRICE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "U_PRICE", Commons.Modules.TypeLanguage);
                rTitle["AMOUNT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "AMOUNT", Commons.Modules.TypeLanguage);

                rTitle["TONG_GD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TONG_GD", Commons.Modules.TypeLanguage);
                rTitle["GD_NMAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "GD_NMAY", Commons.Modules.TypeLanguage);
                rTitle["BP_MHANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "BP_MHANG", Commons.Modules.TypeLanguage);
                rTitle["PRE_BY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "PRE_BY", Commons.Modules.TypeLanguage);

                rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "SPECIFICATION", Commons.Modules.TypeLanguage);
                rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP2", Commons.Modules.TypeLanguage);
                rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP3", Commons.Modules.TypeLanguage);
                rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP4", Commons.Modules.TypeLanguage);
                rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TD_DV", Commons.Modules.TypeLanguage);

                rTitle["TEN_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TEN_DV", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DVT", Commons.Modules.TypeLanguage);
                rTitle["SL"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "SL", Commons.Modules.TypeLanguage);
                rTitle["DG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "DG", Commons.Modules.TypeLanguage);
                rTitle["TT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TT", Commons.Modules.TypeLanguage);

                rTitle["THOI_HAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "THOI_HAN", Commons.Modules.TypeLanguage);
                rTitle["N_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "N_DX", Commons.Modules.TypeLanguage);
                rTitle["N_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "N_GIAO", Commons.Modules.TypeLanguage);
                rTitle["N_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "N_NHAN", Commons.Modules.TypeLanguage);
                rTitle["LDO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "LDO", Commons.Modules.TypeLanguage);
                rTitle["GCHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "GCHU", Commons.Modules.TypeLanguage);



                rTitle["TMP6"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP6", Commons.Modules.TypeLanguage);
                rTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP7", Commons.Modules.TypeLanguage);
                rTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP8", Commons.Modules.TypeLanguage);
                rTitle["TMP9"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP9", Commons.Modules.TypeLanguage);
                rTitle["TMP10"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TMP10", Commons.Modules.TypeLanguage);
                rTitle["MS_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "MS_DX", Commons.Modules.TypeLanguage);


                if (dtTmp.Rows.Count > 0)
                    rTitle["TD_VAT_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangADC", "TD_VAT_TU", Commons.Modules.TypeLanguage);
                else
                    rTitle["TD_VAT_TU"] = "-1";

                rTitle["CO_DV"] = (DgvDonDatHangDichVu.RowCount > 0 ? 1 : -1);







                dtTmp = new System.Data.DataTable();
                try
                {
                    string ssql = "";
                    ssql = " select MS_DICH_VU,MS_DE_XUAT,TEN_DICH_VU,DVT, " +
                                " SL_DAT_HANG,DON_GIA,NGOAI_TE,TY_GIA, " +
                                " TY_GIA_USD,THANH_TIEN,THANH_TIEN_VND,THANH_TIEN_USD,GHI_CHU " +
                                " from dbo.DON_DAT_HANG_DICH_VU " +
                                " WHERE MS_DON_DAT_HANG = '" + ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString() + "' " +
                                " ORDER BY MS_DICH_VU,MS_DE_XUAT,TEN_DICH_VU";
                    dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, ssql));
                    dtTmp.TableName = "DV_ADC";
                    frmRptDexuat.AddDataTableSource(dtTmp);
                    rTitle["CO_DV"] = (dtTmp.Rows.Count > 0 ? 1 : -1);
                }
                catch { }
                TbTieuDe.TableName = "TIEU_DE_ADC";
                TbTieuDe.Rows.Add(rTitle);
                frmRptDexuat.AddDataTableSource(TbTieuDe);
                this.Cursor = Cursors.Default;
                frmRptDexuat.ShowDialog(this);
            }
            catch (Exception EX)
            { MessageBox.Show(EX.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.Cursor = Cursors.Default;
        }

        #endregion


        private void InDeNghiNhapKhoDoFiCo()
        {
            try
            {
                string sMSDH; DateTime dNDHang; string sNDNghi;

                sMSDH = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString();
                sNDNghi = TxtNGUOI_DAT_HANG.Text; //((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DAT_HANG"].ToString();
                try
                {
                    dNDHang = Convert.ToDateTime(MskNGAY_DAT_HANG.Text);
                }
                catch { dNDHang = Commons.Modules.ObjSystems.GetNgayHeThong().Date; }

                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptDeNghiNhapKhoDFC";
                //frmRptDexuat.rptName = "rptBanDuTruDFC";

                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetGiayDeNghiNhapKhoDFC", sMSDH));
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

                rTitle["TONG_CONG_TY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TONG_CONG_TY", Commons.Modules.TypeLanguage);
                rTitle["CONG_NGHIEP_TP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "CONG_NGHIEP_TP", Commons.Modules.TypeLanguage);
                rTitle["PKT_CO_DIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "PKT_CO_DIEN", Commons.Modules.TypeLanguage);
                rTitle["CONG_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "CONG_HOA", Commons.Modules.TypeLanguage);
                rTitle["DOC_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "DOC_LAP", Commons.Modules.TypeLanguage);
                rTitle["BIEN_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "BIEN_HOA", Commons.Modules.TypeLanguage) + " , " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "NGAY", Commons.Modules.TypeLanguage) + " " +
                        dNDHang.Day.ToString() + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "THANG", Commons.Modules.TypeLanguage) + " " +
                        dNDHang.Month.ToString() + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "NAM", Commons.Modules.TypeLanguage) + " " +
                        dNDHang.Year.ToString();
                rTitle["GIAY_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "GIAY_DE_NGHI", Commons.Modules.TypeLanguage);
                rTitle["KINH_GOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "KINH_GOI", Commons.Modules.TypeLanguage);
                rTitle["KE_TOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "BanTongGD", Commons.Modules.TypeLanguage);
                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "STT", Commons.Modules.TypeLanguage);
                rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TEN", Commons.Modules.TypeLanguage);
                rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "MHH", Commons.Modules.TypeLanguage);
                rTitle["MSKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "MSKT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = sNDNghi;// Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["SLG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "SLG", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "DON_GIA", Commons.Modules.TypeLanguage);
                rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "THANH_TIEN", Commons.Modules.TypeLanguage);
                rTitle["TONG_CONG_VAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TONG_CONG_VAT", Commons.Modules.TypeLanguage);
                rTitle["TONG_CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TONG_CONG", Commons.Modules.TypeLanguage);
                rTitle["LOAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "LOAI", Commons.Modules.TypeLanguage);
                rTitle["TRINH_LANH_DAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TRINH_LANH_DAO", Commons.Modules.TypeLanguage);
                rTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "DUYET", Commons.Modules.TypeLanguage);
                rTitle["DUYET_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "DUYET_KT", Commons.Modules.TypeLanguage);
                rTitle["TPKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "TPKT", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_DN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "NGUOI_DN", Commons.Modules.TypeLanguage);
                rTitle["VO_MINH_TAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "VO_MINH_TAN", Commons.Modules.TypeLanguage);
                rTitle["GACH1"] = TxtNGUOI_GIAO.Text;
                rTitle["GACH2"] = TxtDIA_CHI_GIAO.Text;
                rTitle["GACH3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeNghiNhapKhoDFC", "PhongKeToan", Commons.Modules.TypeLanguage);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetSoTienDFC", sMSDH, 2, Commons.Modules.TypeLanguage));
                rTitle["TIEN_CHU"] = "( " + dtTmp.Rows[0][0].ToString() + " )";

                TbTieuDe.TableName = "TIEU_DE_DFC";
                TbTieuDe.Rows.Add(rTitle);
                frmRptDexuat.AddDataTableSource(TbTieuDe);

                frmRptDexuat.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }


        private void InDonDatHangACE()
        {
            try
            {
                string sMSDH;

                sMSDH = ((DataRowView)BindingDonDatHang.Current).Row["MS_DON_DAT_HANG"].ToString();

                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptDonDatHangACE";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetInDonDatHangACE", sMSDH, Commons.Modules.TypeLanguage));
                dtTmp.TableName = "DON_DAT_HANG_ACE";
                frmRptDexuat.AddDataTableSource(dtTmp);

                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("NGAY_LAP");
                TbTieuDe.Columns.Add("DON_DAT_HANG");
                TbTieuDe.Columns.Add("CHI_NHANH");
                TbTieuDe.Columns.Add("KINH_GOI");
                TbTieuDe.Columns.Add("FAX");
                TbTieuDe.Columns.Add("NGUOI_NHAN");
                TbTieuDe.Columns.Add("CAN_CU");
                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MS_PT");
                TbTieuDe.Columns.Add("TEN_PT");
                TbTieuDe.Columns.Add("QUY_CACH");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SO_LUONG");
                TbTieuDe.Columns.Add("GHI_CHU");
                TbTieuDe.Columns.Add("YEU_CAU");
                TbTieuDe.Columns.Add("NHAN_DUOC");
                TbTieuDe.Columns.Add("CAM_ON");
                TbTieuDe.Columns.Add("XAC_NHAN");
                TbTieuDe.Columns.Add("PHONG_QL");
                TbTieuDe.Columns.Add("DU_1");
                TbTieuDe.Columns.Add("DU_2");
                TbTieuDe.Columns.Add("DU_3");

                DateTime Ngay;
                string sTmp = "";

                try
                {
                    Ngay = Convert.ToDateTime(MskNGAY_LAP.Text);
                }
                catch { Ngay = Convert.ToDateTime(null); }


                DataRow rTitle = TbTieuDe.NewRow();
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Ngay", Commons.Modules.TypeLanguage) + "   " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Thang", Commons.Modules.TypeLanguage) + "   " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Nam", Commons.Modules.TypeLanguage) + " ";
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Ngay", Commons.Modules.TypeLanguage) + " " + Ngay.Day.ToString() + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Thang", Commons.Modules.TypeLanguage) + " " + Ngay.Month.ToString() + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Nam", Commons.Modules.TypeLanguage) + " " + Ngay.Year.ToString() + " ";
                rTitle["NGAY_LAP"] = sTmp;
                rTitle["DON_DAT_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "DON_DAT_HANG", Commons.Modules.TypeLanguage);
                rTitle["CHI_NHANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "CHI_NHANH", Commons.Modules.TypeLanguage);
                rTitle["KINH_GOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "KINH_GOI", Commons.Modules.TypeLanguage) + " : " +
                            CboNHA_CUNG_CAP.Text;
                rTitle["FAX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "FAX", Commons.Modules.TypeLanguage) + " : " + MskFAX_NCC.Text;
                rTitle["NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "NGUOI_NHAN", Commons.Modules.TypeLanguage) + " : " + TxtNGUOI_KY_HD.Text;
                try
                {
                    Ngay = Convert.ToDateTime(MskNGAY_DAT_HANG.Text);
                }
                catch { Ngay = Convert.ToDateTime(null); }
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "CAN_CU", Commons.Modules.TypeLanguage) + " ";
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "CAN_CU", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("MM.yyyy") + " : ";


                rTitle["CAN_CU"] = sTmp;
                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "STT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "TEN_PT", Commons.Modules.TypeLanguage);
                rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "QUY_CACH", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "DVT", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "SO_LUONG", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "GHI_CHU", Commons.Modules.TypeLanguage);
                rTitle["YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "YEU_CAU", Commons.Modules.TypeLanguage);
                rTitle["NHAN_DUOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "NHAN_DUOC", Commons.Modules.TypeLanguage);
                rTitle["CAM_ON"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "CAM_ON", Commons.Modules.TypeLanguage);
                rTitle["XAC_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "XAC_NHAN", Commons.Modules.TypeLanguage);
                rTitle["PHONG_QL"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "PHONG_QL", Commons.Modules.TypeLanguage);
                rTitle["DU_1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "Tong", Commons.Modules.TypeLanguage);
                rTitle["DU_2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "DU_2", Commons.Modules.TypeLanguage);
                rTitle["DU_3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHangACE", "DU_3", Commons.Modules.TypeLanguage);
                TbTieuDe.TableName = "TIEU_DE_AFC";
                TbTieuDe.Rows.Add(rTitle);
                frmRptDexuat.AddDataTableSource(TbTieuDe);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text,
                    "SELECT * FROM DON_DAT_HANG_DIEU_KHOAN WHERE MS_DON_DAT_HANG = '" + sMSDH + "'"));

                dtTmp.TableName = "DIEU_KHOAN_AFC";
                frmRptDexuat.AddDataTableSource(dtTmp);



                frmRptDexuat.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }



        #region InDonDatHangVinhHoan
        private void InDonDatHangVinhHoan()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                frmReport frmRpt = new frmReport();

                frmRpt.rptName = "rptDONDATHANG_VH";
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "SP_DONDATHANG";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_DON_DAT_HANG", TxtMS_DON_DAT_HANG.Text));


                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                DataSet dsTmp = new DataSet();

                try
                {
                    adapter.Fill(dsTmp);
                }
                catch { }
                Int32 i = 0;
                for (i = 0; i <= dsTmp.Tables.Count - 1; i++)
                {
                    dtTmp = new DataTable();
                    dtTmp = dsTmp.Tables[i];
                    switch (i)
                    {
                        case 0:
                            dtTmp.TableName = "DDH_INFO";
                            break;

                        case 1:
                            dtTmp.TableName = "DDH_DETAIL";
                            break;
                    }
                    frmRpt.AddDataTableSource(dtTmp);

                }
                frmRpt.AddDataTableSource(LanguageReportVINHHOAN());
                Commons.Modules.SQLString = "0Design";
                frmRpt.ShowDialog();
                Commons.Modules.SQLString = "";
            }
            catch { }
        }
        private DataTable LanguageReportVINHHOAN()
        {
            DataTable vtbTitle = new DataTable();
            vtbTitle.TableName = "TIEU_DE_DDH";
            Int32 i = 0;
            for (i = 0; i <= 38; i++)
            {
                vtbTitle.Columns.Add();
            }
            try
            {
                vtbTitle.Columns[0].ColumnName = "DON_DAT_HANG";
                vtbTitle.Columns[1].ColumnName = "MA_SO";
                vtbTitle.Columns[2].ColumnName = "NGAY_HIEU_LUC";
                vtbTitle.Columns[3].ColumnName = "LAN_SOAT_XET";

                vtbTitle.Columns[4].ColumnName = "KINH_GUI";
                vtbTitle.Columns[5].ColumnName = "DIA_CHI";
                vtbTitle.Columns[6].ColumnName = "DIEN_THOAI";

                vtbTitle.Columns[7].ColumnName = "FAX";
                vtbTitle.Columns[8].ColumnName = "MA_SO_THUE";

                vtbTitle.Columns[9].ColumnName = "TAI_KHOAN";
                vtbTitle.Columns[10].ColumnName = "MO_TA_DE_NGHI";
                vtbTitle.Columns[11].ColumnName = "STT";
                vtbTitle.Columns[12].ColumnName = "TEN_HANG";

                vtbTitle.Columns[13].ColumnName = "MA";
                vtbTitle.Columns[14].ColumnName = "QUI_CACH";

                vtbTitle.Columns[15].ColumnName = "DVT";
                vtbTitle.Columns[16].ColumnName = "SO_LUONG";

                vtbTitle.Columns[17].ColumnName = "DON_GIA";
                vtbTitle.Columns[18].ColumnName = "THANH_TIEN";



                vtbTitle.Columns[19].ColumnName = "YEU_CAU_DAC_BIET";
                vtbTitle.Columns[20].ColumnName = "PHUONG_THUC_THANH_TOAN";
                vtbTitle.Columns[21].ColumnName = "CHUNG_TU_YEU_CAU";
                vtbTitle.Columns[22].ColumnName = "NGAY_GIAO_HANG";

                vtbTitle.Columns[23].ColumnName = "DIA_CHI_GIAO_HANG";
                vtbTitle.Columns[24].ColumnName = "NGUOI_LIEN_HE";
                vtbTitle.Columns[25].ColumnName = "DON_VI";


                vtbTitle.Columns[26].ColumnName = "DIEN_THOAI_LH";
                vtbTitle.Columns[27].ColumnName = "KINH_CHAO";



                vtbTitle.Columns[28].ColumnName = "NGUOI_LAP";
                vtbTitle.Columns[29].ColumnName = "NGAY_LAP";

                vtbTitle.Columns[30].ColumnName = "PHE_DUYET";

                vtbTitle.Columns[31].ColumnName = "NGAY_PHE_DUYET";

                vtbTitle.Columns[32].ColumnName = "SO_DH";
                vtbTitle.Columns[33].ColumnName = "TMP0";

                vtbTitle.Columns[34].ColumnName = "TMP1";
                vtbTitle.Columns[35].ColumnName = "TMP2";
                vtbTitle.Columns[36].ColumnName = "TMP3";
                vtbTitle.Columns[37].ColumnName = "TMP4";
                vtbTitle.Columns[38].ColumnName = "TMP5";



                DataRow vRowTitle = vtbTitle.NewRow();
                String sBC = "rptDONDATHANG_VH";

                vRowTitle["DON_DAT_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_DAT_HANG", Commons.Modules.TypeLanguage);
                vRowTitle["MA_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_HIEU_LUC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage);
                vRowTitle["LAN_SOAT_XET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage);
                vRowTitle["KINH_GUI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KINH_GUI", Commons.Modules.TypeLanguage);
                vRowTitle["DIA_CHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DIA_CHI", Commons.Modules.TypeLanguage);
                vRowTitle["DIEN_THOAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DIEN_THOAI", Commons.Modules.TypeLanguage);
                vRowTitle["FAX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "FAX", Commons.Modules.TypeLanguage);
                vRowTitle["MA_SO_THUE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO_THUE", Commons.Modules.TypeLanguage);
                vRowTitle["TAI_KHOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TAI_KHOAN", Commons.Modules.TypeLanguage);
                vRowTitle["MO_TA_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MO_TA_DE_NGHI", Commons.Modules.TypeLanguage);
                vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HANG", Commons.Modules.TypeLanguage);
                vRowTitle["MA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA", Commons.Modules.TypeLanguage);
                vRowTitle["QUI_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "QUI_CACH", Commons.Modules.TypeLanguage);
                vRowTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage);
                vRowTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_LUONG", Commons.Modules.TypeLanguage);
                vRowTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_GIA", Commons.Modules.TypeLanguage);
                vRowTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THANH_TIEN", Commons.Modules.TypeLanguage);

                vRowTitle["YEU_CAU_DAC_BIET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "YEU_CAU_DAC_BIET", Commons.Modules.TypeLanguage);
                vRowTitle["PHUONG_THUC_THANH_TOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHUONG_THUC_THANH_TOAN", Commons.Modules.TypeLanguage);
                vRowTitle["CHUNG_TU_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "CHUNG_TU_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_GIAO_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_GIAO_HANG", Commons.Modules.TypeLanguage);
                vRowTitle["DIA_CHI_GIAO_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DIA_CHI_GIAO_HANG", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_LIEN_HE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_LIEN_HE", Commons.Modules.TypeLanguage);
                vRowTitle["DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_VI", Commons.Modules.TypeLanguage);
                vRowTitle["DIEN_THOAI_LH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DIEN_THOAI_LH", Commons.Modules.TypeLanguage);
                vRowTitle["KINH_CHAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KINH_CHAO", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_LAP", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_LAP", Commons.Modules.TypeLanguage);
                vRowTitle["PHE_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHE_DUYET", Commons.Modules.TypeLanguage);

                vRowTitle["NGAY_PHE_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_PHE_DUYET", Commons.Modules.TypeLanguage);
                vRowTitle["SO_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_DH", Commons.Modules.TypeLanguage);
                vRowTitle["TMP0"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP0", Commons.Modules.TypeLanguage);

                vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP1", Commons.Modules.TypeLanguage);
                vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage);
                vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP3", Commons.Modules.TypeLanguage);
                vRowTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP4", Commons.Modules.TypeLanguage);
                vRowTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP5", Commons.Modules.TypeLanguage);

                vtbTitle.Rows.Add(vRowTitle);
            }
            catch { }
            return vtbTitle;

        }
        #endregion


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocData();
        }
        private void LocData()
        {
            try
            {
                string dk = "";
                if (txtTimKiem.Text.Length != 0) dk = dk + " OR MS_DON_DAT_HANG LIKE '%" + txtTimKiem.Text + "%' ";
                if (txtTimKiem.Text.Length != 0) dk = dk + " OR SO_DON_DAT_HANG LIKE '%" + txtTimKiem.Text + "%' ";
                TbDonDatHang.DefaultView.RowFilter = dk.Substring(4, dk.Length - 4);
            }
            catch { TbDonDatHang.DefaultView.RowFilter = ""; }
        }

        private void btnTimCX_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.ToString().Trim() == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgVuiLongNhapGiaTriCanTim", Commons.Modules.TypeLanguage));
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            System.DateTime dNgay = DateTime.Parse("01/01/1900");
            int iLock = 0;
            try
            {
                Commons.Modules.ObjSystems.mGetSoPhieu("DON_DAT_HANG", "MS_DON_DAT_HANG", "NGAY_LAP", "CONVERT(INT, CASE TRANG_THAI WHEN 4 THEN 1 ELSE 0 END)", txtTimKiem.Text, ref dNgay, ref iLock);
                if (dNgay.Date != DateTime.Parse("01/01/1900"))
                {
                    isFirst = false;
                    Commons.Modules.SQLString = "0Load";
                    if (iLock == 1) chkIsLock.Checked = true; else chkIsLock.Checked = false;
                    lokSupplier.EditValue = "All";
                    datFromDate.DateTime = dNgay;
                    datToDate.DateTime = dNgay;
                    Commons.Modules.SQLString = "";
                    isFirst = true;
                    LoadDDH();
                    LocData();
                }
            }
            catch (Exception ex)
            {
                txtTimKiem_TextChanged(sender, e);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtTimKiem.Text.Trim() == "")
            {
                TbDonDatHang.DefaultView.RowFilter = "";
                return;
            }
            string dk = " MS_DON_DAT_HANG = '" + txtTimKiem.Text + "' ";
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp = TbDonDatHang.Copy();

                dtTmp.DefaultView.RowFilter = dk;
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    string sSql = "";
                    sSql = " SELECT  MS_DON_DAT_HANG, TRANG_THAI,NGAY_LAP,NHA_CUNG_CAP FROM DON_DAT_HANG WHERE MS_DON_DAT_HANG = '" + txtTimKiem.Text + "' ";
                    dtTmp = new System.Data.DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        Commons.Modules.SQLString = "0Load";

                        if (lokSupplier.EditValue.ToString().ToUpper() != "ALL")
                        {
                            lokSupplier.EditValue = dtTmp.Rows[0]["NHA_CUNG_CAP"].ToString();
                        }
                        if (int.Parse(dtTmp.Rows[0]["TRANG_THAI"].ToString()) == 4)
                        {
                            chkIsLock.Checked = true;
                        }
                        else
                        {
                            chkIsLock.Checked = false;
                        }
                        datToDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY_LAP"].ToString());
                        datFromDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY_LAP"].ToString());
                        Commons.Modules.SQLString = "";
                        LoadDDH();
                    }
                }
            }
            catch { TbDonDatHang.DefaultView.RowFilter = ""; }
            try
            {
                TbDonDatHang.DefaultView.RowFilter = dk;
            }
            catch { TbDonDatHang.DefaultView.RowFilter = ""; }
        }

        private void DgvDuyetDonDatHang_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DgvDuyetDonDatHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";

        }

        private void btnCNDuyet_Click(object sender, EventArgs e)
        {

            if (Vietsoft.Information.MsgBox(this, "msgBanCoChacCapNhapLaiDuyet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;

            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            try
            {
                Vietsoft.DataInfo.DeleteDataView(SqlDonDatHang, "SP_Y_DELETE_DUYET_DON_DAT_HANG", TbDuyetDonDatHang.DefaultView, "MS_DON_DAT_HANG", "NGUOI_DUYET");
                Vietsoft.DataInfo.ClearData(TbDuyetDonDatHang.DefaultView);
                TbDuyetDonDatHang.AcceptChanges();
            }
            catch
            {
                SqlDonDatHang.RollbackTransaction();
                Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            try
            {

                System.Data.DataTable TbDuyetDonDH = new System.Data.DataTable();
                TbDuyetDonDH.Load(SqlDonDatHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DON_DH", Commons.Modules.UserName));
                foreach (DataColumn ClDuyetDeXuatMH in TbDuyetDonDH.Columns)
                {
                    ClDuyetDeXuatMH.ReadOnly = false;
                    ClDuyetDeXuatMH.AllowDBNull = true;
                }
                foreach (DataRow rDuyetDDH in TbDuyetDonDH.Rows)
                {
                    rDuyetDDH["MS_DON_DAT_HANG"] = ((DataRowView)DgvDonDatHang.CurrentRow.DataBoundItem).Row["MS_DON_DAT_HANG"];
                    TbDuyetDonDatHang.Rows.Add(rDuyetDDH.ItemArray);
                }
                ((DataRowView)BindingDonDatHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                ((DataRowView)BindingDonDatHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;


                if (((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"].Equals(2))
                {
                    ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 1;
                    ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Đang soạn";
                }
                else
                {
                    if (((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"].Equals(3))
                    {
                        ((DataRowView)BindingDonDatHang.Current).Row["TRANG_THAI"] = 2;
                        ((DataRowView)BindingDonDatHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                    }
                }
                Vietsoft.DataInfo.UpdateDataRow(SqlDonDatHang, "SP_Y_EDIT_DON_DAT_HANG", ((DataRowView)BindingDonDatHang.Current).Row);
                Vietsoft.DataInfo.UpdateDataView(SqlDonDatHang, "SP_Y_INSERT_DUYET_DON_DAT_HANG", "SP_Y_EDIT_DUYET_DON_DAT_HANG", "SP_Y_CHECK_DUYET_DON_DAT_HANG", TbDuyetDonDatHang.DefaultView, "MS_DON_DAT_HANG", "NGUOI_DUYET");
                TbDuyetDonDatHang.AcceptChanges();
                InitializeForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvDonDatHang_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmDanhsachDDHtuDexuat frm = new frmDanhsachDDHtuDexuat(TxtMS_DON_DAT_HANG.Text);
            frm.ShowDialog(this);
        }

        private void btnInPR_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "SHISEIDO")
            {
                InPRSSD();
                return;
            }
        }
        private void DinhDangText(ExcelWorksheet ws, int fRow, int fCol, int tRow, int tCol, string text, bool bold = false, bool merge = false, bool wraptext = false, string CotRange = "")
        {
            ws.Cells[fRow, fCol, tRow, tCol].Value = text;
            if (bold == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.Font.Bold = true;

            if (merge == true)
                ws.Cells[fRow, fCol, tRow, tCol].Merge = true;
            if (wraptext == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.WrapText = true;
            if (CotRange != "")
            {
                ws.Cells[CotRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[CotRange].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ccc"));
            }
        }

        private void DinhDangTextAlignMent(ExcelWorksheet ws, int fRow, int fCol, int tRow, int tCol, string text, bool bold = false, bool merge = false, bool wraptext = false, ExcelHorizontalAlignment hAlignment = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlignment = ExcelVerticalAlignment.Center)
        {
            ws.Cells[fRow, fCol, tRow, tCol].Value = text;
            if (bold == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.Font.Bold = true;

            if (merge == true)
                ws.Cells[fRow, fCol, tRow, tCol].Merge = true;
            if (wraptext == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.WrapText = true;
            ws.Cells[fRow, fCol, tRow, tCol].Style.HorizontalAlignment = hAlignment;
            ws.Cells[fRow, fCol, tRow, tCol].Style.VerticalAlignment = vAlignment;
        }
        private void InPRSSD()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDonHangChiTiet", TxtMS_DON_DAT_HANG.Text));

                if (dt.Rows.Count == 0)
                {
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "KhongCoDuLieu", Commons.Modules.TypeLanguage);
                    Cursor = Cursors.Default;
                    return;
                }

                string sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PR");
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws, "");
                #endregion

                using (var range = ws.Cells["A1:AZ1000"])
                {
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.SetFromFont(new System.Drawing.Font("Times New Roman", 11));
                }

                ws.Cells[1, 5, 1, 10].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "InternaleMemorandum", Commons.Modules.TypeLanguage);
                ws.Cells[1, 5, 1, 10].Style.Font.Bold = true;
                ws.Cells[1, 5, 1, 10].Style.Font.Size = 14;
                ws.Cells[1, 5, 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 5, 1, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 5, 1, 10].Merge = true;
                ws.Cells[1, 5, 1, 10].Style.Font.UnderLine = true;
                int iDong = 4;
                int iCot = 1, TCot = 10;



                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TenCongTyEng", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TenCongTyViet", Commons.Modules.TypeLanguage), true);

                iDong = iDong + 3;

                DinhDangText(ws, iDong, iCot, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PurchaseRequestTitleEng", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot, iDong, TCot].Style.Font.Size = 20;
                ws.Cells[iDong, iCot, iDong, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iDong, iCot, iDong, TCot].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong).Height = 25;
                DinhDangText(ws, iDong + 1, iCot, iDong + 1, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PurchaseRequestTitleViet", Commons.Modules.TypeLanguage), false, true, false);
                ws.Row(iDong + 1).Height = 15;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No.", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 2, iCot + 1, iDong + 2, iCot + 1].Value = TxtSO_DON_DAT_HANG.Text;

                DinhDangText(ws, iDong + 2, iCot + 5, iDong + 2, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 2, iCot + 6, iDong + 2, iCot + 6].Value = MskNGAY_LAP.Text;

                iDong = iDong + 3;
                int fDong = iDong;

                DinhDangText(ws, iDong, iCot, iDong, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "EmployeeRequest", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot + 2, iDong, iCot + 2].Value = TxtNGUOI_DAT_HANG.Text;
                ws.Cells[iDong, iCot + 6, iDong, iCot + 6].Value = TxtSO_DON_DAT_HANG.Text.Length > 11 ? TxtSO_DON_DAT_HANG.Text.Substring(0, 2) : "";

                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "ProjectsWork", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangText(ws, iDong + 1, iCot + 2, iDong + 1, TCot, TxtGHI_CHU.Text, true, true, true);

                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Purpose", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangText(ws, iDong + 3, iCot, iDong + 3, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Seller", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangTextAlignMent(ws, iDong + 3, iCot + 2, iDong + 3, iCot + 4, CboNHA_CUNG_CAP.Text, false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                DinhDangText(ws, iDong + 4, iCot, iDong + 4, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "DeliveryTerms", Commons.Modules.TypeLanguage), true, true, true);

                DataTable dtTmp;
                try
                {
                    DinhDangTextAlignMent(ws, iDong + 4, iCot + 2, iDong + 4, iCot + 4, Commons.Modules.TypeLanguage == 0 ? DgvDonDatHangDieuKhoan.Rows[5].Cells[1].Value.ToString() : DgvDonDatHangDieuKhoan.Rows[4].Cells[1].Value.ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                    DinhDangTextAlignMent(ws, iDong + 4, iCot + 6, iDong + 4, TCot, Commons.Modules.TypeLanguage == 0 ? DgvDonDatHangDieuKhoan.Rows[1].Cells[1].Value.ToString() : DgvDonDatHangDieuKhoan.Rows[0].Cells[1].Value.ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);


                }
                catch
                {
                    dtTmp = new DataTable();
                   string sSql = " SELECT * FROM DIEU_KHOAN_MAC_DINH ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        DinhDangTextAlignMent(ws, iDong + 4, iCot + 2, iDong + 4, iCot + 4, Commons.Modules.TypeLanguage == 0 ? dtTmp.Rows[4][2].ToString() : dtTmp.Rows[5][2].ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                        DinhDangTextAlignMent(ws, iDong + 4, iCot + 6, iDong + 4, TCot, Commons.Modules.TypeLanguage == 0 ? dtTmp.Rows[1][2].ToString() : dtTmp.Rows[0][2].ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                    }
                }

                DinhDangText(ws, iDong, iCot + 5, iDong, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Dept", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangText(ws, iDong + 3, iCot + 5, iDong + 3, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Address", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangTextAlignMent(ws, iDong + 3, iCot + 6, iDong + 3, TCot, TxtDIA_CHI_NCC.Text, false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                DinhDangText(ws, iDong + 4, iCot + 5, iDong + 4, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TimeToDelivery", Commons.Modules.TypeLanguage), true, true, true);
              
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 3, iCot, iDong + 3, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 4, iCot, iDong + 4, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 30;
                ws.Row(iDong + 1).Height = 35;
                ws.Row(iDong + 2).Height = 0;
                ws.Row(iDong + 3).Height = 35;
                ws.Row(iDong + 4).Height = 60;
                ws.Column(1).Width = 5.75;
                ws.Column(2).Width = 14;
                ws.Column(3).Width = 5;
                ws.Column(4).Width = 20;
                ws.Column(5).Width = 12;
                ws.Column(6).Width = 15;
                ws.Column(7).Width = 18;
                ws.Column(8).Width = 8;
                ws.Column(9).Width = 13;
                ws.Column(10).Width = 27;

                iDong = iDong + 6;

                DinhDangText(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "OthersVendor", Commons.Modules.TypeLanguage), false, true);


                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].IsRichText = true;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage) + " ");
                ExcelRichText ert = ws.Cells[iDong, iCot + 4, iDong, iCot + 4].RichText.Add("c");
                ert.FontName = "Webdings";

                ws.Cells[iDong, iCot + 5, iDong, iCot + 5].IsRichText = true;
                ws.Cells[iDong, iCot + 5, iDong, iCot + 5].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong, iCot + 5, iDong, iCot + 5].RichText.Add("c");
                ert.FontName = "Webdings";

                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor1", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor2", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 3, iCot, iDong + 3, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor3", Commons.Modules.TypeLanguage));
                iDong = iDong + 4;
            
                ws.Cells[iDong, iCot + 1, iDong, iCot + 3].Merge = true;

                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "STT", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 1, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Item", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Quantity", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 5, iDong, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Unit", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Estimates", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, iCot + 7, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VAT", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 8, iDong, iCot + 8, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VATValue", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 9, iDong, iCot + 9, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "AmountIn", Commons.Modules.TypeLanguage) + (Commons.Modules.TypeLanguage == 0 ? "VND" : "USD"), false, false, true);

                ws.Row(iDong).Height = 30;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                iDong++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.Cells[iDong, iCot].Value = dt.Rows[i]["STT"];
                    ws.Cells[iDong, iCot, iDong + dt.Rows.Count, iCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 1].Value = dt.Rows[i]["TEN_PT"];
                    ws.Cells[iDong, iCot + 1, iDong, iCot + 3].Merge = true;
                    ws.Cells[iDong, iCot + 3, iDong + dt.Rows.Count, iCot + 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 4].Value = dt.Rows[i]["SL_DAT_HANG"];
                    ws.Cells[iDong, iCot + 4, iDong + dt.Rows.Count, iCot + 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 5].Value = dt.Rows[i]["DVT"];
                    ws.Cells[iDong, iCot + 5, iDong + dt.Rows.Count, iCot + 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 6].Value = dt.Rows[i]["DON_GIA"];
                    ws.Cells[iDong, iCot + 6, iDong + dt.Rows.Count, iCot + 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 7].Value = dt.Rows[i]["THUE_VAT"];
                    ws.Cells[iDong, iCot + 7, iDong + dt.Rows.Count, iCot + 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 8].Value = dt.Rows[i]["TIEN_THUE"];
                    ws.Cells[iDong, iCot + 8, iDong + dt.Rows.Count, iCot + 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 9].Value = dt.Rows[i]["THANH_TIEN"];
                    ws.Row(iDong).Height = 18;
                    iDong++;
                }
                ws.Cells[iDong, iCot, iDong + 2, iCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong + 2, iCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong + 2, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong + 2, TCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                iDong = iDong + 3;

          
                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Total", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong + 1, iCot, iDong + 1, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VATGTGT", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong + 2, iCot, iDong + 2, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TotalInclude", Commons.Modules.TypeLanguage), true, true, true);

                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                ws.Cells[iDong, TCot].Formula = "=+SUMPRODUCT(G21:G" + (iDong - 1).ToString() + ",E21:E" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 1, TCot].Formula = "=SUMPRODUCT(E21:E" + (iDong - 1).ToString() + ",I21:I" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 2, TCot].Formula = "=J" + iDong.ToString() + "+J" + (iDong + 1).ToString();

                iDong = iDong + 3;

                DinhDangText(ws, iDong, iCot + 1, iDong, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PriceIncludingVAT", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 1, iCot + 1, iDong + 1, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PriceIncludingCharge", Commons.Modules.TypeLanguage));

                DinhDangTextAlignMent(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage), false, false, false, ExcelHorizontalAlignment.Right);
                DinhDangText(ws, iDong + 1, iCot + 6, iDong + 1, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].IsRichText = true;
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].RichText.Add("c");
                ert.FontName = "Webdings";
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                DinhDangTextAlignMent(ws, iDong, TCot, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage), false, false, false, ExcelHorizontalAlignment.Right);

                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].IsRichText = true;
                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong + 1, TCot, iDong + 1, TCot].RichText.Add("c");
                ert.FontName = "Webdings";
                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                iDong = iDong + 2;

                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "RequestedDept", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 4, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedDept ", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Approved", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                iDong++;



                //Requested by, Date: 	Checked by, Date:	"Name & sign (PD S manager)
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "RequestedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PDManager", Commons.Modules.TypeLanguage), false, true, false, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;




                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign1", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "FAManager", Commons.Modules.TypeLanguage), false, true, false, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign2", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Director", Commons.Modules.TypeLanguage), false, true, false,
                     ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;
                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign3", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;
                ws.Cells[fDong, TCot, iDong, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                iDong = iDong + 2;
                ws.Cells[iDong, iCot, iDong, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NotesEng", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot, iDong + 1, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NotesViet", Commons.Modules.TypeLanguage);
                iDong = iDong + 3;
                ws.Cells[iDong, iCot, iDong, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "POAuthorization", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot, iDong + 1, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "POExpense", Commons.Modules.TypeLanguage);
                iDong = iDong + 3;
                ws.Cells[iDong, iCot + 1, iDong, iCot + 1].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "SeniorManager", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot + 1, iDong + 1, iCot + 1].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "GeneralDirector", Commons.Modules.TypeLanguage);
                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                System.Diagnostics.Process.Start(fi.FullName);
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }

    }
}